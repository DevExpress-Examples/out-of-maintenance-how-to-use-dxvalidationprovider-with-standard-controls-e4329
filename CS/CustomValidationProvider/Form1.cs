using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.DXErrorProvider;

namespace CustomValidationProvider {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            CustomValidationRule customValidationRule = new CustomValidationRule();
            customValidationRule.ErrorType = ErrorType.Warning;
            customValidationRule.ErrorText = "Enter a valid value";          

            ConditionValidationRule containsValidationRule = new ConditionValidationRule();
            containsValidationRule.ConditionOperator = ConditionOperator.Contains;
            containsValidationRule.Value1 = '@';
            containsValidationRule.ErrorType = ErrorType.Warning;            
            containsValidationRule.ErrorText = "Enter a valid value";

            CompareAgainstControlValidationRule compValidationRule = new CompareAgainstControlValidationRule();
            compValidationRule.Control = textEdit1;
            compValidationRule.CompareControlOperator = CompareControlOperator.Equals;
            compValidationRule.ErrorText = "Please enter a value that equals to the first editor's value";

            dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto;
            dxValidationProvider.SetValidationRule(maskedTextBox1, compValidationRule);
            dxValidationProvider.SetValidationRule(textBox1, compValidationRule);
            dxValidationProvider.SetValidationRule(textBox1, containsValidationRule);
            dxValidationProvider.SetValidationRule(richTextBox1, customValidationRule);
         }
    }
}
