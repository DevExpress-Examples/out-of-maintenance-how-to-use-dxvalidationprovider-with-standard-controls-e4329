Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.XtraEditors

Namespace CustomValidationProvider
	<System.ComponentModel.DesignerCategory("")> _
	Public Class AdvancedDXValidationProvider
		Inherits DXValidationProvider
		Private hashTable As New Dictionary(Of Control, ValidationRuleBase)()
		Private msErrorProvider As New ErrorProvider()

		Public Sub New()

		End Sub
		Public Sub New(ByVal container As IContainer)
			MyBase.New(container)

		End Sub
		Public Sub New(ByVal parentControl As ContainerControl)
			MyBase.New(parentControl)

		End Sub
		Private Sub RemoveFromHash(ByVal control As Control)
			If hashTable.ContainsKey(control) Then
				hashTable.Remove(control)
			End If
		End Sub
		Public Overrides Sub SetValidationRule(ByVal control As Control, ByVal rule As ValidationRuleBase)
			If TypeOf control Is TextBoxBase Then
				RemoveFromHash(control)
				If rule IsNot Nothing Then
					hashTable.Add(control, rule)
					SubscribeValidating(control)
				Else
					UnsubscribeValidating(control)
				End If
			End If
		End Sub
		Private Sub SubscribeValidating(ByVal control As Control)
			AddHandler control.Validating, AddressOf control_Validating
		End Sub
		Private Sub UnsubscribeValidating(ByVal control As Control)
			RemoveHandler control.Validating, AddressOf control_Validating
		End Sub
		Private Sub control_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
			Dim control As TextBoxBase = TryCast(sender, TextBoxBase)
			msErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink
			msErrorProvider.SetIconAlignment(control, ErrorIconAlignment.MiddleLeft)
			If (Not Validate(control)) Then
				msErrorProvider.SetError(control, "Please enter a valid value")
				e.Cancel = True
			Else
				msErrorProvider.SetError(control, "")
			End If
		End Sub
		Public Function Validate(ByVal control As Control) As Boolean
			Dim ctrl As TextBoxBase = TryCast(control, TextBoxBase)
			Dim rule As ValidationRuleBase = hashTable(control)
			If rule Is Nothing OrElse (Not rule.CanValidate(ctrl)) Then
				Return True
			End If
			Return rule.Validate(ctrl, ctrl.Text)
		End Function
	End Class
End Namespace
