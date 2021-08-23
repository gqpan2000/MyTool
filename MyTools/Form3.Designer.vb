<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBoxQuery = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFormName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.btnCreateFormDesignerText = New System.Windows.Forms.Button()
        Me.txtFormDesigner = New System.Windows.Forms.TextBox()
        Me.btnCreateBinding = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTableName = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(156, 26)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SQL insert will remove identity," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "computed and timestamp colum"
        '
        'TextBoxQuery
        '
        Me.TextBoxQuery.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxQuery.Location = New System.Drawing.Point(0, 26)
        Me.TextBoxQuery.Multiline = True
        Me.TextBoxQuery.Name = "TextBoxQuery"
        Me.TextBoxQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxQuery.Size = New System.Drawing.Size(182, 540)
        Me.TextBoxQuery.TabIndex = 9
        Me.TextBoxQuery.Text = "([InvID]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           ,[InvDate]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           ,[CustomerId]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           ,[SubTotal]" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "           ,[SysGuid])"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Form name:"
        '
        'txtFormName
        '
        Me.txtFormName.Location = New System.Drawing.Point(79, 44)
        Me.txtFormName.MaxLength = 50
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.Size = New System.Drawing.Size(100, 20)
        Me.txtFormName.TabIndex = 7
        Me.txtFormName.Text = "Form3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(259, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Add controls to a win form by a datatable column type"
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(185, 42)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(105, 23)
        Me.Button19.TabIndex = 11
        Me.Button19.Text = "Get Controls"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.ColumnType})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 13)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(2)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(269, 553)
        Me.DataGridView1.TabIndex = 12
        '
        'ColumnName
        '
        Me.ColumnName.HeaderText = "ColumnName"
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.Width = 95
        '
        'ColumnType
        '
        Me.ColumnType.HeaderText = "ColumnType"
        Me.ColumnType.Items.AddRange(New Object() {"TextBox", "ComboBox", "CheckBox"})
        Me.ColumnType.Name = "ColumnType"
        Me.ColumnType.Width = 72
        '
        'btnCreateFormDesignerText
        '
        Me.btnCreateFormDesignerText.Location = New System.Drawing.Point(17, 24)
        Me.btnCreateFormDesignerText.Name = "btnCreateFormDesignerText"
        Me.btnCreateFormDesignerText.Size = New System.Drawing.Size(155, 23)
        Me.btnCreateFormDesignerText.TabIndex = 13
        Me.btnCreateFormDesignerText.Text = "Create Controls in form design"
        Me.btnCreateFormDesignerText.UseVisualStyleBackColor = True
        '
        'txtFormDesigner
        '
        Me.txtFormDesigner.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtFormDesigner.Location = New System.Drawing.Point(658, 113)
        Me.txtFormDesigner.Multiline = True
        Me.txtFormDesigner.Name = "txtFormDesigner"
        Me.txtFormDesigner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFormDesigner.Size = New System.Drawing.Size(435, 566)
        Me.txtFormDesigner.TabIndex = 14
        '
        'btnCreateBinding
        '
        Me.btnCreateBinding.Location = New System.Drawing.Point(17, 51)
        Me.btnCreateBinding.Name = "btnCreateBinding"
        Me.btnCreateBinding.Size = New System.Drawing.Size(155, 23)
        Me.btnCreateBinding.TabIndex = 15
        Me.btnCreateBinding.Text = "Create Binding"
        Me.btnCreateBinding.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Table name:"
        '
        'txtTableName
        '
        Me.txtTableName.Location = New System.Drawing.Point(79, 70)
        Me.txtTableName.MaxLength = 50
        Me.txtTableName.Name = "txtTableName"
        Me.txtTableName.Size = New System.Drawing.Size(100, 20)
        Me.txtTableName.TabIndex = 16
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtTableName)
        Me.Panel1.Controls.Add(Me.txtFormName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Button19)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1093, 113)
        Me.Panel1.TabIndex = 18
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TextBoxQuery)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 113)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(182, 566)
        Me.Panel2.TabIndex = 19
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(182, 113)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(269, 566)
        Me.Panel3.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Select Textbox or Combo box or checkbox"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Button9)
        Me.Panel4.Controls.Add(Me.Button8)
        Me.Panel4.Controls.Add(Me.Button7)
        Me.Panel4.Controls.Add(Me.Button6)
        Me.Panel4.Controls.Add(Me.Button5)
        Me.Panel4.Controls.Add(Me.Button4)
        Me.Panel4.Controls.Add(Me.Button2)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Controls.Add(Me.btnCreateFormDesignerText)
        Me.Panel4.Controls.Add(Me.btnCreateBinding)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(451, 113)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(207, 566)
        Me.Panel4.TabIndex = 21
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(17, 441)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(155, 23)
        Me.Button9.TabIndex = 24
        Me.Button9.Text = "Focus Control"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(17, 402)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(155, 23)
        Me.Button8.TabIndex = 23
        Me.Button8.Text = "All in one"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(17, 361)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(155, 23)
        Me.Button7.TabIndex = 22
        Me.Button7.Text = "Valid Textbox length"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button6.Location = New System.Drawing.Point(17, 189)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(155, 42)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Add,Modify,Delete,Save button"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button5.Location = New System.Drawing.Point(17, 332)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(155, 23)
        Me.Button5.TabIndex = 20
        Me.Button5.Text = "ToggleButton"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(17, 284)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(155, 23)
        Me.Button4.TabIndex = 19
        Me.Button4.Text = "All for form templete"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button2.Location = New System.Drawing.Point(17, 107)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(155, 23)
        Me.Button2.TabIndex = 17
        Me.Button2.Text = "Form Load,Active,Closing"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(17, 156)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(155, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Add,Modify,Delete button"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1093, 679)
        Me.Controls.Add(Me.txtFormDesigner)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxQuery As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFormName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnType As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents btnCreateFormDesignerText As System.Windows.Forms.Button
    Friend WithEvents txtFormDesigner As System.Windows.Forms.TextBox
    Friend WithEvents btnCreateBinding As System.Windows.Forms.Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTableName As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
End Class
