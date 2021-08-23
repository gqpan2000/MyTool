<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.txtNewClass = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.btnGetShowClass = New System.Windows.Forms.Button
        Me.btnString = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.btnInteger = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkVPN = New System.Windows.Forms.CheckBox
        Me.rdBIS = New System.Windows.Forms.RadioButton
        Me.rdUTGUS = New System.Windows.Forms.RadioButton
        Me.rdSOFI = New System.Windows.Forms.RadioButton
        Me.rdUTGNT = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtTableName = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.btnBoolean = New System.Windows.Forms.Button
        Me.btnTexttoClass = New System.Windows.Forms.Button
        Me.btnDecimal = New System.Windows.Forms.Button
        Me.btnClasstoText = New System.Windows.Forms.Button
        Me.btnDate = New System.Windows.Forms.Button
        Me.btnCreateNewClass = New System.Windows.Forms.Button
        Me.txtClassType = New System.Windows.Forms.TextBox
        Me.txtClassName = New System.Windows.Forms.TextBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(875, 603)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtNewClass)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.txtClassType)
        Me.TabPage1.Controls.Add(Me.txtClassName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(867, 577)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtNewClass
        '
        Me.txtNewClass.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNewClass.Location = New System.Drawing.Point(578, 3)
        Me.txtNewClass.Multiline = True
        Me.txtNewClass.Name = "txtNewClass"
        Me.txtNewClass.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtNewClass.Size = New System.Drawing.Size(286, 571)
        Me.txtNewClass.TabIndex = 19
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.btnGetShowClass)
        Me.Panel1.Controls.Add(Me.btnString)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.btnInteger)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnBoolean)
        Me.Panel1.Controls.Add(Me.btnTexttoClass)
        Me.Panel1.Controls.Add(Me.btnDecimal)
        Me.Panel1.Controls.Add(Me.btnClasstoText)
        Me.Panel1.Controls.Add(Me.btnDate)
        Me.Panel1.Controls.Add(Me.btnCreateNewClass)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(341, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(237, 571)
        Me.Panel1.TabIndex = 24
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(12, 479)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(146, 23)
        Me.Button8.TabIndex = 27
        Me.Button8.Text = "OReader String"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(12, 450)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(146, 23)
        Me.Button7.TabIndex = 26
        Me.Button7.Text = "Load Class String From Dgv "
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 421)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(146, 23)
        Me.Button6.TabIndex = 25
        Me.Button6.Text = "Load Class String "
        Me.Button6.UseVisualStyleBackColor = True
        '
        'btnGetShowClass
        '
        Me.btnGetShowClass.Location = New System.Drawing.Point(12, 392)
        Me.btnGetShowClass.Name = "btnGetShowClass"
        Me.btnGetShowClass.Size = New System.Drawing.Size(146, 23)
        Me.btnGetShowClass.TabIndex = 24
        Me.btnGetShowClass.Text = "Show Class String "
        Me.btnGetShowClass.UseVisualStyleBackColor = True
        '
        'btnString
        '
        Me.btnString.Location = New System.Drawing.Point(12, 12)
        Me.btnString.Name = "btnString"
        Me.btnString.Size = New System.Drawing.Size(65, 23)
        Me.btnString.TabIndex = 11
        Me.btnString.Text = "String"
        Me.btnString.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 363)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(146, 23)
        Me.Button5.TabIndex = 23
        Me.Button5.Text = "Update Detail String "
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnInteger
        '
        Me.btnInteger.Location = New System.Drawing.Point(86, 12)
        Me.btnInteger.Name = "btnInteger"
        Me.btnInteger.Size = New System.Drawing.Size(65, 23)
        Me.btnInteger.TabIndex = 12
        Me.btnInteger.Text = "Integer"
        Me.btnInteger.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 334)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(102, 23)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Parameter String "
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkVPN)
        Me.GroupBox1.Controls.Add(Me.rdBIS)
        Me.GroupBox1.Controls.Add(Me.rdUTGUS)
        Me.GroupBox1.Controls.Add(Me.rdSOFI)
        Me.GroupBox1.Controls.Add(Me.rdUTGNT)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTableName)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(210, 142)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Get Table Columns"
        '
        'chkVPN
        '
        Me.chkVPN.AutoSize = True
        Me.chkVPN.Location = New System.Drawing.Point(104, 45)
        Me.chkVPN.Name = "chkVPN"
        Me.chkVPN.Size = New System.Drawing.Size(70, 17)
        Me.chkVPN.TabIndex = 28
        Me.chkVPN.Text = "Use VPN"
        Me.chkVPN.UseVisualStyleBackColor = True
        '
        'rdBIS
        '
        Me.rdBIS.AutoSize = True
        Me.rdBIS.Location = New System.Drawing.Point(104, 68)
        Me.rdBIS.Name = "rdBIS"
        Me.rdBIS.Size = New System.Drawing.Size(42, 17)
        Me.rdBIS.TabIndex = 27
        Me.rdBIS.TabStop = True
        Me.rdBIS.Text = "BIS"
        Me.rdBIS.UseVisualStyleBackColor = True
        '
        'rdUTGUS
        '
        Me.rdUTGUS.AutoSize = True
        Me.rdUTGUS.Location = New System.Drawing.Point(16, 89)
        Me.rdUTGUS.Name = "rdUTGUS"
        Me.rdUTGUS.Size = New System.Drawing.Size(66, 17)
        Me.rdUTGUS.TabIndex = 26
        Me.rdUTGUS.TabStop = True
        Me.rdUTGUS.Text = "UTG US"
        Me.rdUTGUS.UseVisualStyleBackColor = True
        '
        'rdSOFI
        '
        Me.rdSOFI.AutoSize = True
        Me.rdSOFI.Location = New System.Drawing.Point(16, 68)
        Me.rdSOFI.Name = "rdSOFI"
        Me.rdSOFI.Size = New System.Drawing.Size(49, 17)
        Me.rdSOFI.TabIndex = 25
        Me.rdSOFI.TabStop = True
        Me.rdSOFI.Text = "SOFI"
        Me.rdSOFI.UseVisualStyleBackColor = True
        '
        'rdUTGNT
        '
        Me.rdUTGNT.AutoSize = True
        Me.rdUTGNT.Location = New System.Drawing.Point(16, 45)
        Me.rdUTGNT.Name = "rdUTGNT"
        Me.rdUTGNT.Size = New System.Drawing.Size(66, 17)
        Me.rdUTGNT.TabIndex = 24
        Me.rdUTGNT.TabStop = True
        Me.rdUTGNT.Text = "UTG NT"
        Me.rdUTGNT.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Table Name"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(74, 19)
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(113, 20)
        Me.txtTableName.TabIndex = 22
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(16, 112)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(158, 24)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Get Table Columns"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'btnBoolean
        '
        Me.btnBoolean.Location = New System.Drawing.Point(12, 41)
        Me.btnBoolean.Name = "btnBoolean"
        Me.btnBoolean.Size = New System.Drawing.Size(65, 23)
        Me.btnBoolean.TabIndex = 13
        Me.btnBoolean.Text = "Boolean"
        Me.btnBoolean.UseVisualStyleBackColor = True
        '
        'btnTexttoClass
        '
        Me.btnTexttoClass.Location = New System.Drawing.Point(12, 305)
        Me.btnTexttoClass.Name = "btnTexttoClass"
        Me.btnTexttoClass.Size = New System.Drawing.Size(102, 23)
        Me.btnTexttoClass.TabIndex = 18
        Me.btnTexttoClass.Text = "Update String "
        Me.btnTexttoClass.UseVisualStyleBackColor = True
        '
        'btnDecimal
        '
        Me.btnDecimal.Location = New System.Drawing.Point(86, 41)
        Me.btnDecimal.Name = "btnDecimal"
        Me.btnDecimal.Size = New System.Drawing.Size(65, 23)
        Me.btnDecimal.TabIndex = 14
        Me.btnDecimal.Text = "Decimal"
        Me.btnDecimal.UseVisualStyleBackColor = True
        '
        'btnClasstoText
        '
        Me.btnClasstoText.Location = New System.Drawing.Point(12, 276)
        Me.btnClasstoText.Name = "btnClasstoText"
        Me.btnClasstoText.Size = New System.Drawing.Size(102, 23)
        Me.btnClasstoText.TabIndex = 17
        Me.btnClasstoText.Text = "Insert String"
        Me.btnClasstoText.UseVisualStyleBackColor = True
        '
        'btnDate
        '
        Me.btnDate.Location = New System.Drawing.Point(12, 70)
        Me.btnDate.Name = "btnDate"
        Me.btnDate.Size = New System.Drawing.Size(65, 23)
        Me.btnDate.TabIndex = 15
        Me.btnDate.Text = "Date"
        Me.btnDate.UseVisualStyleBackColor = True
        '
        'btnCreateNewClass
        '
        Me.btnCreateNewClass.Location = New System.Drawing.Point(12, 247)
        Me.btnCreateNewClass.Name = "btnCreateNewClass"
        Me.btnCreateNewClass.Size = New System.Drawing.Size(102, 23)
        Me.btnCreateNewClass.TabIndex = 16
        Me.btnCreateNewClass.Text = "New Class"
        Me.btnCreateNewClass.UseVisualStyleBackColor = True
        '
        'txtClassType
        '
        Me.txtClassType.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtClassType.Location = New System.Drawing.Point(178, 3)
        Me.txtClassType.Multiline = True
        Me.txtClassType.Name = "txtClassType"
        Me.txtClassType.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtClassType.Size = New System.Drawing.Size(163, 571)
        Me.txtClassType.TabIndex = 2
        Me.txtClassType.Text = "Data Type"
        '
        'txtClassName
        '
        Me.txtClassName.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtClassName.Location = New System.Drawing.Point(3, 3)
        Me.txtClassName.Multiline = True
        Me.txtClassName.Name = "txtClassName"
        Me.txtClassName.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtClassName.Size = New System.Drawing.Size(175, 571)
        Me.txtClassName.TabIndex = 1
        Me.txtClassName.Text = "Class Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button2)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(867, 577)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(41, 77)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "My folder"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(41, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Guid"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(156, 12)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 52)
        Me.Button9.TabIndex = 28
        Me.Button9.Text = "Convert SQL to Class"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(875, 603)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents txtClassName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtNewClass As System.Windows.Forms.TextBox
    Friend WithEvents btnTexttoClass As System.Windows.Forms.Button
    Friend WithEvents btnClasstoText As System.Windows.Forms.Button
    Friend WithEvents btnCreateNewClass As System.Windows.Forms.Button
    Friend WithEvents btnDate As System.Windows.Forms.Button
    Friend WithEvents btnDecimal As System.Windows.Forms.Button
    Friend WithEvents btnBoolean As System.Windows.Forms.Button
    Friend WithEvents btnInteger As System.Windows.Forms.Button
    Friend WithEvents btnString As System.Windows.Forms.Button
    Friend WithEvents txtClassType As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdBIS As System.Windows.Forms.RadioButton
    Friend WithEvents rdUTGUS As System.Windows.Forms.RadioButton
    Friend WithEvents rdSOFI As System.Windows.Forms.RadioButton
    Friend WithEvents rdUTGNT As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTableName As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkVPN As System.Windows.Forms.CheckBox
    Friend WithEvents btnGetShowClass As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button

End Class
