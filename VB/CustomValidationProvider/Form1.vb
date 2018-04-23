Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.DXErrorProvider

Namespace CustomValidationProvider
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()

			Dim customValidationRule As New CustomValidationRule()
			customValidationRule.ErrorType = ErrorType.Warning
			customValidationRule.ErrorText = "Enter a valid value"

			Dim containsValidationRule As New ConditionValidationRule()
			containsValidationRule.ConditionOperator = ConditionOperator.Contains
			containsValidationRule.Value1 = "@"c
			containsValidationRule.ErrorType = ErrorType.Warning
			containsValidationRule.ErrorText = "Enter a valid value"

			Dim compValidationRule As New CompareAgainstControlValidationRule()
			compValidationRule.Control = textEdit1
			compValidationRule.CompareControlOperator = CompareControlOperator.Equals
			compValidationRule.ErrorText = "Please enter a value that equals to the first editor's value"

			dxValidationProvider.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.Auto
			dxValidationProvider.SetValidationRule(maskedTextBox1, compValidationRule)
			dxValidationProvider.SetValidationRule(textBox1, compValidationRule)
			dxValidationProvider.SetValidationRule(textBox1, containsValidationRule)
			dxValidationProvider.SetValidationRule(richTextBox1, customValidationRule)
		End Sub
	End Class
End Namespace
