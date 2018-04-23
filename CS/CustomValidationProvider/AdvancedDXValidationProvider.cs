using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using DevExpress.XtraEditors;

namespace CustomValidationProvider {
    [System.ComponentModel.DesignerCategory("")]
    public class AdvancedDXValidationProvider : DXValidationProvider  {
        Dictionary<Control, ValidationRuleBase> hashTable = new Dictionary<Control, ValidationRuleBase>();
        ErrorProvider msErrorProvider = new ErrorProvider();

        public AdvancedDXValidationProvider() {

        }
        public AdvancedDXValidationProvider(IContainer container)
            : base(container) {

        }
        public AdvancedDXValidationProvider(ContainerControl parentControl)
            : base(parentControl) {

        }
        private void RemoveFromHash(Control control) {
            if (hashTable.ContainsKey(control))
                hashTable.Remove(control);
        }
        public override void SetValidationRule(Control control, ValidationRuleBase rule) {
            if (control is TextBoxBase) {
                RemoveFromHash(control);
                if (rule != null) {
                    hashTable.Add(control, rule);
                    SubscribeValidating(control);
                }
                else
                    UnsubscribeValidating(control);
            }
        }
        void SubscribeValidating(Control control) {
            control.Validating += control_Validating;
        }
        void UnsubscribeValidating(Control control) {
            control.Validating -= control_Validating;
        }
        void control_Validating(object sender, CancelEventArgs e) {
            TextBoxBase control = sender as TextBoxBase;
            msErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            msErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft);
            if (!Validate(control)) {
                msErrorProvider.SetError(control, "Please enter a valid value");
                e.Cancel = true;
            }
            else {
                msErrorProvider.SetError(control, "");
            }
        }
        public bool Validate(Control control) {
            TextBoxBase ctrl = control as TextBoxBase;
            ValidationRuleBase rule = hashTable[control];
            if (rule == null || !rule.CanValidate(ctrl)) return true;
            return rule.Validate(ctrl, ctrl.Text);
        }
    }
}
