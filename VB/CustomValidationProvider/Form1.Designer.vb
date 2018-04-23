Imports Microsoft.VisualBasic
Imports System
Namespace CustomValidationProvider
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.textBox1 = New System.Windows.Forms.TextBox()
			Me.maskedTextBox1 = New System.Windows.Forms.MaskedTextBox()
			Me.richTextBox1 = New System.Windows.Forms.RichTextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label4 = New System.Windows.Forms.Label()
			Me.dxValidationProvider = New CustomValidationProvider.AdvancedDXValidationProvider(Me.components)
			Me.textEdit1 = New DevExpress.XtraEditors.TextEdit()
			CType(Me.dxValidationProvider, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' textBox1
			' 
			Me.textBox1.Location = New System.Drawing.Point(43, 50)
			Me.textBox1.Name = "textBox1"
			Me.textBox1.Size = New System.Drawing.Size(100, 20)
			Me.textBox1.TabIndex = 6
			' 
			' maskedTextBox1
			' 
			Me.maskedTextBox1.Location = New System.Drawing.Point(43, 113)
			Me.maskedTextBox1.Name = "maskedTextBox1"
			Me.maskedTextBox1.Size = New System.Drawing.Size(100, 20)
			Me.maskedTextBox1.TabIndex = 8
			' 
			' richTextBox1
			' 
			Me.richTextBox1.Location = New System.Drawing.Point(234, 50)
			Me.richTextBox1.Name = "richTextBox1"
			Me.richTextBox1.Size = New System.Drawing.Size(100, 96)
			Me.richTextBox1.TabIndex = 9
			Me.richTextBox1.Text = ""
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(231, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(68, 13)
			Me.label1.TabIndex = 10
			Me.label1.Text = "RichTextBox"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(42, 95)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(84, 13)
			Me.label2.TabIndex = 11
			Me.label2.Text = "MaskedTextBox"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(41, 33)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(46, 13)
			Me.label3.TabIndex = 12
			Me.label3.Text = "TextBox"
			' 
			' label4
			' 
			Me.label4.AutoSize = True
			Me.label4.Location = New System.Drawing.Point(42, 153)
			Me.label4.Name = "label4"
			Me.label4.Size = New System.Drawing.Size(46, 13)
			Me.label4.TabIndex = 14
			Me.label4.Text = "TextEdit"
			' 
			' textEdit1
			' 
			Me.textEdit1.Location = New System.Drawing.Point(43, 169)
			Me.textEdit1.Name = "textEdit1"
			Me.textEdit1.Size = New System.Drawing.Size(100, 20)
			Me.textEdit1.TabIndex = 13
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(408, 261)
			Me.Controls.Add(Me.label4)
			Me.Controls.Add(Me.textEdit1)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.richTextBox1)
			Me.Controls.Add(Me.maskedTextBox1)
			Me.Controls.Add(Me.textBox1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.dxValidationProvider, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.textEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private textBox1 As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private richTextBox1 As System.Windows.Forms.RichTextBox
		Private maskedTextBox1 As System.Windows.Forms.MaskedTextBox
		Private label4 As System.Windows.Forms.Label
		Private dxValidationProvider As AdvancedDXValidationProvider
		Private textEdit1 As DevExpress.XtraEditors.TextEdit
	End Class
End Namespace

