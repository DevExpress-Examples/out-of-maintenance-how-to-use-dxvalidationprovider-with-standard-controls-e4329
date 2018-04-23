Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.XtraEditors.DXErrorProvider
Imports System.Windows.Forms

Namespace CustomValidationProvider
	 Public Class CustomValidationRule
		 Inherits ValidationRule
		Public Overrides Function Validate(ByVal control As Control, ByVal value As Object) As Boolean
			Dim str As String = CStr(value)
			Dim values() As String = { "Dr.", "Mr.", "Mrs.", "Miss", "Ms." }
			Dim res As Boolean = False
			For Each val As String In values
				If ValidationHelper.Validate(str, ConditionOperator.BeginsWith, val, Nothing, Nothing, False) Then
					Dim name As String = str.Substring(val.Length)
					If name.Trim().Length > 0 Then
						res = True
					End If
				End If
			Next val
			Return res
		End Function
	 End Class
End Namespace
