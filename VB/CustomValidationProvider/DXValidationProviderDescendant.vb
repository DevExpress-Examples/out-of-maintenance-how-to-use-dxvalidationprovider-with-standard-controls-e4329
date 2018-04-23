Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.XtraEditors

Namespace CustomValidationProvider
	Public Class DXValidationProviderDescendant
		Inherits DXValidationProvider
		Private validationRules As Hashtable
		Private isInitializing As Boolean
		Public Sub New()
			Me.validationRules = New Hashtable()
		End Sub
		Public Sub New(ByVal container As IContainer)
			MyBase.New(container)

		End Sub
		Public Sub New(ByVal parentControl As ContainerControl)
			MyBase.New(parentControl)

		End Sub
		Protected Overrides Function CanValidateControl(ByVal control As Control) As Boolean
			'return base.CanValidateControl(control);
			Dim result As Boolean = CanValidateControlCore(control)
			If result AndAlso (Not control.Visible) Then
				Return ValidateHiddenControls
			End If
			Return result
		End Function
		Private Function CanExtend(ByVal extendee As Object) As Boolean
			If TypeOf extendee Is BaseEdit Then
				Return True
			End If
			Return False
		End Function
		Protected Function CanValidateControlCore(ByVal control As Control) As Boolean
			If control Is Nothing Then
				Return False
			End If
			Return (CType(Me, IExtenderProvider)).CanExtend(control)
		End Function
		Public Overrides Function GetValidationRule(ByVal control As Control) As ValidationRuleBase
			Return (TryCast(validationRules(control), ValidationRuleBase))
		End Function

		Public Overrides Sub SetValidationRule(ByVal control As Control, ByVal rule As ValidationRuleBase)
			'base.SetValidationRule(control, rule);

			If (Not isInitializing) Then
				If (rule IsNot Nothing) AndAlso (Not MyBase.DesignMode) Then
					rule = TryCast(rule.Clone(), ValidationRuleBase)
				End If
			End If
			If rule IsNot Nothing Then
				validationRules(control) = rule
				SubscribeValidatingEvent(control)
			Else
				UnsubscribeValidatingEvent(control)
				validationRules.Remove(control)
				RemoveControlError(control)
			End If
		End Sub
		Protected Overrides Sub Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
			'base.Validating(sender, e);
			If isInitializing OrElse DesignMode OrElse (Not CanAutoValidate) Then
				Return
			End If
			Dim control As BaseEdit = TryCast(sender, BaseEdit)
			If (Not CanValidateControl(control)) Then
				Return
			End If
			Dim rule As ValidationRuleBase = TryCast(validationRules(control), ValidationRuleBase)
			If rule Is Nothing OrElse (Not rule.CanValidate(control)) Then
				Return
			End If
			e.Cancel = Not rule.Validate(control, control.EditValue)
			If e.Cancel Then
				SetControlError(control, rule.ErrorText, rule.ErrorType)
			Else
				RemoveControlError(control)
			End If
		End Sub
		Public Function ValidateDescendant() As Boolean
			Dim isValid As Boolean = True
			For Each control As Control In validationRules.Keys
				If (Not Validate(control)) Then
					isValid = False
				End If
			Next control
			Return isValid
		End Function
		Public Function Validate(ByVal control As Control) As Boolean
			Dim ctrl As BaseEdit = TryCast(control, BaseEdit)
			If (Not CanValidateControl(ctrl)) Then
				Return True
			End If
			Dim rule As ValidationRuleBase = GetValidationRule(ctrl)
			If rule Is Nothing OrElse (Not rule.CanValidate(ctrl)) Then
				Return True
			End If
			If (Not rule.Validate(ctrl, ctrl.EditValue)) Then
				SetControlError(ctrl, rule.ErrorText, rule.ErrorType)
				Return False
			End If
			RemoveControlError(ctrl)
			Return True
		End Function
		Private Sub EndInitCoreDescendant()
			If DesignMode Then
				Return
			End If
			For Each entry As DictionaryEntry In New ArrayList(validationRules)
				Dim rule As ValidationRuleBase = TryCast(entry.Value, ValidationRuleBase)
				If rule IsNot Nothing Then
					validationRules(entry.Key) = rule.Clone()
				End If
			Next entry
		End Sub
		Private Sub BeginInit()
			isInitializing = True
		End Sub
		Private Sub EndInit()
			isInitializing = False
			EndInitCore()
		End Sub
		Private Sub EndInitCore()
			If DesignMode Then
				Return
			End If
			For Each entry As DictionaryEntry In New ArrayList(validationRules)
				Dim rule As ValidationRuleBase = TryCast(entry.Value, ValidationRuleBase)
				If rule IsNot Nothing Then
					validationRules(entry.Key) = rule.Clone()
				End If
			Next entry
		End Sub
	End Class
End Namespace
