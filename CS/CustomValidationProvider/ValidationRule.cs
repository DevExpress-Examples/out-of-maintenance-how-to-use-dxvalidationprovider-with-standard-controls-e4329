using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Windows.Forms;

namespace CustomValidationProvider {
     public class CustomValidationRule : ValidationRule {
        public override bool Validate(Control control, object value) {
            string str = (string)value;
            string[] values = new string[] { "Dr.", "Mr.", "Mrs.", "Miss", "Ms." };
            bool res = false;
            foreach (string val in values) {
                if (ValidationHelper.Validate(str, ConditionOperator.BeginsWith,
                    val, null, null, false)) {
                    string name = str.Substring(val.Length);
                    if (name.Trim().Length > 0) res = true;
                }
            }
            return res;
        }
    }
}
