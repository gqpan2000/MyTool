<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 78)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Query:"
        '
        'TextBoxQuery
        '
        Me.TextBoxQuery.Location = New System.Drawing.Point(16, 108)
        Me.TextBoxQuery.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxQuery.Multiline = True
        Me.TextBoxQuery.Name = "TextBoxQuery"
        Me.TextBoxQuery.Size = New System.Drawing.Size(480, 70)
        Me.TextBoxQuery.TabIndex = 9
        Me.TextBoxQuery.Text = "select * from edi_setting where 1=0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 46)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Form name:"
        '
        'txtFormName
        '
        Me.txtFormName.Location = New System.Drawing.Point(104, 46)
        Me.txtFormName.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormName.MaxLength = 50
        Me.txtFormName.Name = "txtFormName"
        Me.txtFormName.Size = New System.Drawing.Size(132, 22)
        Me.txtFormName.TabIndex = 7
        Me.txtFormName.Text = "Form3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 11)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(345, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Add controls to a win form by a datatable column type"
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(244, 40)
        Me.Button19.Margin = New System.Windows.Forms.Padding(4)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(140, 28)
        Me.Button19.TabIndex = 11
        Me.Button19.Text = "Add Controls"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnName, Me.ColumnType})
        Me.DataGridView1.Location = New System.Drawing.Point(25, 205)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(471, 348)
        Me.DataGridView1.TabIndex = 12
        '
        'ColumnName
        '
        Me.ColumnName.HeaderText = "ColumnName"
        Me.ColumnName.Name = "ColumnName"
        Me.ColumnName.Width = 117
        '
        'ColumnType
        '
        Me.ColumnType.HeaderText = "ColumnType"
        Me.ColumnType.Items.AddRange(New Object() {"TextBox", "ComboBox", "CheckBox"})
        Me.ColumnType.Name = "ColumnType"
        Me.ColumnType.Width = 93
        '
        'btnCreateFormDesignerText
        '
        Me.btnCreateFormDesignerText.Location = New System.Drawing.Point(392, 40)
        Me.btnCreateFormDesignerText.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCreateFormDesignerText.Name = "btnCreateFormDesignerText"
        Me.btnCreateFormDesignerText.Size = New System.Drawing.Size(115, 28)
        Me.btnCreateFormDesignerText.TabIndex = 13
        Me.btnCreateFormDesignerText.Text = "Create Controls"
        Me.btnCreateFormDesignerText.UseVisualStyleBackColor = True
        '
        'txtFormDesigner
        '
        Me.txtFormDesigner.Location = New System.Drawing.Point(530, 16)
        Me.txtFormDesigner.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFormDesigner.Multiline = True
        Me.txtFormDesigner.Name = "txtFormDesigner"
        Me.txtFormDesigner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFormDesigner.Size = New System.Drawing.Size(506, 537)
        Me.txtFormDesigner.TabIndex = 14
        '
        'btnCreateBinding
        '
        Me.btnCreateBinding.Location = New System.Drawing.Point(392, 72)
        Me.btnCreateBinding.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCreateBinding.Name = "btnCreateBinding"
        Me.btnCreateBinding.Size = New System.Drawing.Size(115, 28)
        Me.btnCreateBinding.TabIndex = 15
        Me.btnCreateBinding.Text = "Create Binding"
        Me.btnCreateBinding.UseVisualStyleBackColor = True
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1049, 600)
        Me.Controls.Add(Me.btnCreateBinding)
        Me.Controls.Add(Me.txtFormDesigner)
        Me.Controls.Add(Me.btnCreateFormDesignerText)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TextBoxQuery)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFormName)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form3"
        Me.Text = "Form3"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
End Class
