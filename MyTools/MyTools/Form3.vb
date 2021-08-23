Public Class Form3

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        'Part1:Private Sub InitializeComponent()
        Dim formName As String = Me.txtFormName.Text.Trim
        Dim query As String = Me.TextBoxQuery.Text.Trim

        '===============================================================
        'Validate
        If String.IsNullOrEmpty(formName) Then
            MsgBox("Missing form name")
            Me.txtFormName.Focus()
            Return
        End If

        If String.IsNullOrEmpty(query) Then
            MsgBox("Missing query")
            Me.TextBoxQuery.Focus()
            Return
        End If

        If query.Contains(";") Or query.ToLower.Contains("insert") Or query.ToLower.Contains("update") Or query.ToLower.Contains("delete") Or query.ToLower.Contains("drop") Then
            MsgBox("Query contains illege characters.")
            Me.TextBoxQuery.Focus()
            Return
        End If
        '===============================================================


        Dim strSql As String = query '"SELECT * FROM customers WHERE 1=0"
        Dim dt1 As DataTable = MyDll.SQLDB.LoadDataTableBySqlString(strSql, GetSOFIConnection)
        For i As Integer = Me.DataGridView1.RowCount - 1 To 0 Step -1
            Me.DataGridView1.Rows.Remove(Me.DataGridView1.Rows(i))
        Next

        For Each col As DataColumn In dt1.Columns
            Me.DataGridView1.Rows.Add()
            With Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1)
                .Cells("ColumnName").Value = col.ColumnName
                .Cells("ColumnType").Value = "TextBox"
            End With
        Next
        Return
    End Sub

    Private Sub btnCreateFormDesignerText_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateFormDesignerText.Click
        'use below code to replace this form designer code
        Dim sbAll As New System.Text.StringBuilder

        sbAll.AppendLine("<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _")
        sbAll.AppendLine("Partial Class " + Me.txtFormName.Text)
        sbAll.AppendLine("Inherits System.Windows.Forms.Form")
        sbAll.AppendLine("'Form overrides dispose to clean up the component list.")
        sbAll.AppendLine("<System.Diagnostics.DebuggerNonUserCode()> _")
        sbAll.AppendLine("Protected Overrides Sub Dispose(ByVal disposing As Boolean)")
        sbAll.AppendLine("Try")
        sbAll.AppendLine(" If disposing AndAlso components IsNot Nothing Then")
        sbAll.AppendLine("components.Dispose()")
        sbAll.AppendLine("End If")
        sbAll.AppendLine("Finally")
        sbAll.AppendLine("MyBase.Dispose(disposing)")
        sbAll.AppendLine("End Try")
        sbAll.AppendLine("End Sub")

        sbAll.AppendLine("'Required by the Windows Form Designer")
        sbAll.AppendLine(" Private components As System.ComponentModel.IContainer")

        sbAll.AppendLine("'NOTE: The following procedure is required by the Windows Form Designer")
        sbAll.AppendLine(" 'It can be modified using the Windows Form Designer. ")
        sbAll.AppendLine("'Do not modify it using the code editor.")
        sbAll.AppendLine(" <System.Diagnostics.DebuggerStepThrough()> _")
        sbAll.AppendLine("Private Sub InitializeComponent()")

        '========================================================
        'Part1:SuspendLayout
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString
            Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString
            'create all control label
            sbAll.AppendLine(" Me.lbl" + colName + " = New System.Windows.Forms.Label()")

            Select Case colType
                Case "TextBox"
                    sbAll.AppendLine("Me.txt" + colName + " = New System.Windows.Forms.TextBox()")
                Case "ComboBox"
                    sbAll.AppendLine("Me.cmb" + colName + " = New System.Windows.Forms.ComboBox()")
                Case "CheckBox"
                    sbAll.AppendLine("Me.chk" + colName + " = New System.Windows.Forms.CheckBox()")
                Case Else
                    sbAll.AppendLine("Me.txt" + colName + " = New System.Windows.Forms.TextBox()")
            End Select

        Next

        sbAll.AppendLine("Me.SuspendLayout()")
        '========================================================

        sbAll.AppendLine("")
        sbAll.AppendLine("")
        sbAll.AppendLine("")

        '========================================================
        'Part:create controls
        Dim k As Integer = 20
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString
            Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString

            Dim xPos As Integer = 33 + CInt(Math.Floor(CInt(i / k))) * 200
            Dim yPos As Integer = (i Mod k) * 30
            sbAll.AppendLine("Me.lbl" + colName + ".AutoSize = True")
            'sbAll.AppendLine("Me.lbl" + colName + ".Location = New System.Drawing.Point(33, " & i * 30 & ")")
            sbAll.AppendLine("Me.lbl" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")


            sbAll.AppendLine("Me.lbl" + colName + ".Name = " + """lbl" + colName + """")
            sbAll.AppendLine("Me.lbl" + colName + ".Size = New System.Drawing.Size(51, 17)")
            sbAll.AppendLine("Me.lbl" + colName + ".TabIndex = 2")
            sbAll.AppendLine("Me.lbl" + colName + ".Text = """ + colName + """")

            sbAll.AppendLine("")
            sbAll.AppendLine("")
            sbAll.AppendLine("")

            xPos += 100
            Select Case colType
                Case "TextBox"
                    'sbAll.AppendLine("Me.txt" + colName + ".Location = New System.Drawing.Point(180, " & i * 30 & ")")
                    sbAll.AppendLine("Me.txt" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")
                    sbAll.AppendLine("Me.txt" + colName + ".Name = """ + "txt" + colName + """")
                    sbAll.AppendLine("Me.txt" + colName + ".Size = New System.Drawing.Size(100, 22)")
                    sbAll.AppendLine("Me.txt" + colName + ".TabIndex = 3")
                Case "ComboBox"
                    '
                    sbAll.AppendLine("Me.cmb" + colName + ".FormattingEnabled = True")
                    sbAll.AppendLine("Me.cmb" + colName + ".Location =New System.Drawing.Point(" & xPos & ", " & yPos & ")") 'New System.Drawing.Point(180, 83)")
                    sbAll.AppendLine("Me.cmb" + colName + ".Name = """ + "cmb" + colName + """")
                    sbAll.AppendLine("Me.cmb" + colName + ".Size = New System.Drawing.Size(121, 24)")
                    sbAll.AppendLine("Me.cmb" + colName + ".TabIndex = 4")
                Case "CheckBox"
                    sbAll.AppendLine("Me.chk" + colName + ".AutoSize = True")
                    sbAll.AppendLine("Me.chk" + colName + ".Location =New System.Drawing.Point(" & xPos & ", " & yPos & ")") 'New System.Drawing.Point(180, 134)")
                    sbAll.AppendLine("Me.chk" + colName + ".Name = """ + "chk" + colName + """")
                    sbAll.AppendLine("Me.chk" + colName + ".Size = New System.Drawing.Size(100, 21)")
                    sbAll.AppendLine("Me.chk" + colName + ".TabIndex = 5")
                    sbAll.AppendLine("Me.chk" + colName + ".Text = """ + "chk" + colName + """")
                    sbAll.AppendLine("Me.chk" + colName + ".UseVisualStyleBackColor = True")
                Case Else
                    sbAll.AppendLine("Me.txt" + colName + ".Location =New System.Drawing.Point(" & xPos & ", " & yPos & ")") 'New System.Drawing.Point(180, " & i * 30 & ")")
                    sbAll.AppendLine("Me.txt" + colName + ".Name = """ + "txt" + colName + """")
                    sbAll.AppendLine("Me.txt" + colName + ".Size = New System.Drawing.Size(100, 22)")
                    sbAll.AppendLine("Me.txt" + colName + ".TabIndex = 3")
            End Select
            sbAll.AppendLine("")
            sbAll.AppendLine("")
            sbAll.AppendLine("")
        Next
        '========================================================

        sbAll.AppendLine("")
        sbAll.AppendLine("")
        sbAll.AppendLine("")

        '========================================================
        'Part3
        sbAll.AppendLine("Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)")
        sbAll.AppendLine("Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font")
        sbAll.AppendLine("Me.ClientSize = New System.Drawing.Size(282, 255)")

        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString
            sbAll.AppendLine("Me.Controls.Add(Me.lbl" + colName + ")")
            Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString
            Select Case colType
                Case "TextBox"
                    sbAll.AppendLine("Me.Controls.Add(Me.txt" + colName + ")")        
                Case "ComboBox"
                    sbAll.AppendLine("Me.Controls.Add(Me.cmb" + colName + ")")
                Case "CheckBox"
                    sbAll.AppendLine("Me.Controls.Add(Me.chk" + colName + ")")
                Case Else
                    sbAll.AppendLine("Me.Controls.Add(Me.txt" + colName + ")")
            End Select
        Next
        sbAll.AppendLine("")
         sbAll.AppendLine("")

        sbAll.AppendLine("Me.Name = """ + Me.txtFormName.Text + """")
        sbAll.AppendLine("Me.Text = """ + Me.txtFormName.Text + """")
        sbAll.AppendLine("Me.ResumeLayout(False)")
        sbAll.AppendLine("Me.PerformLayout()")
        '========================================================
      

        sbAll.AppendLine("End Sub")

        sbAll.AppendLine("")
        sbAll.AppendLine("")
        sbAll.AppendLine("")

        'Part4: with events
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString
            sbAll.AppendLine("Friend WithEvents lbl" + colName + " As System.Windows.Forms.Label")
            Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString
            Select Case colType
                Case "TextBox"
                    sbAll.AppendLine("Friend WithEvents txt" + colName + " As System.Windows.Forms.TextBox")
                Case "ComboBox"
                    sbAll.AppendLine("Friend WithEvents cmb" + colName + " As System.Windows.Forms.ComboBox")
                Case "CheckBox"
                    sbAll.AppendLine("Friend WithEvents chk" + colName + " As System.Windows.Forms.CheckBox")
                Case Else
                    sbAll.AppendLine("Friend WithEvents txt" + colName + " As System.Windows.Forms.TextBox")
            End Select
        Next

        sbAll.AppendLine("End Class")

        Me.txtFormDesigner.Text = sbAll.ToString


    End Sub

    Private Sub btnCreateBinding_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateBinding.Click
        '替换整个form，Form3换成你的Form name
        '一个Dataset mds1载入2个table Parent和Child，建立一个ParentChild关系
        'binding control format must=true to allow Null set value
        '必须处理NullValue
        'use below code to replace this form designer code
        Dim sbAll As New System.Text.StringBuilder
        sbAll.AppendLine("Public Class Form3")
        sbAll.AppendLine("Dim mds1 As New DataSet")
        sbAll.AppendLine("Dim mBindingSource1 As BindingSource") '对应Parent
        sbAll.AppendLine("Dim mBindingSource2 As BindingSource") '对应Child

        'form load
        sbAll.AppendLine("Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load")
        sbAll.AppendLine("LoadDataSet()")
        sbAll.AppendLine("mBindingSource1 = New BindingSource")
        sbAll.AppendLine("mBindingSource1.DataSource = mds1")
        sbAll.AppendLine("mBindingSource1.DataMember = " + """Parent""") '
        sbAll.AppendLine("")
        sbAll.AppendLine("mBindingSource2 = New BindingSource")
        sbAll.AppendLine("mBindingSource2.DataSource = mBindingSource1")
        sbAll.AppendLine("mBindingSource2.DataMember = " + """ParentChild""") 'ParentChild是Parent Child relation
        sbAll.AppendLine("")
        sbAll.AppendLine("DataGridView1.DataSource = Nothing")
        sbAll.AppendLine("DataGridView1.DataSource = mBindingSource1")
        sbAll.AppendLine("AddControlBindings()")
        sbAll.AppendLine("End Sub")

        'Load Dataset
        sbAll.AppendLine("Private Sub LoadDataSet()")
        sbAll.AppendLine("mds1 =GetYourDataSet ")
        sbAll.AppendLine("mds1.Tables(0).TableName = " + """Parent""")
        sbAll.AppendLine("mds1.Tables(1).TableName = " + """Child""")
        sbAll.AppendLine("mds1.Relations.Add(" + """ParentChild""" + ", mds1.Tables(0).Columns(YourKey), mds1.Tables(1).Columns(YourKey))")
        sbAll.AppendLine("End Sub")
        sbAll.AppendLine("")
        sbAll.AppendLine("")

        'AddControlBindings
        sbAll.AppendLine("Private Sub AddControlBindings()")
        '========================================================
        'Part1: 
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString
            Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString


            Select Case colType
                Case "TextBox"
                    sbAll.AppendLine("Me.txt" + colName + ".DataBindings.Clear()")
                    sbAll.AppendLine("Me.txt" + colName + ".DataBindings.Add(New Binding(" + """Text""" + ", mBindingSource2, " + """" & colName & """" + ", True))") 'format must=true to allow Null set value
                    sbAll.AppendLine("Me.txt" + colName + ".DataBindings(0).NullValue = """ + """")

                    sbAll.AppendLine("")
                Case "ComboBox"
                    'sbAll.AppendLine("Me.cmb" + colName + " = New System.Windows.Forms.ComboBox()")
                    sbAll.AppendLine("Me.cmb" + colName + ".DataBindings.Clear()")
                    sbAll.AppendLine("Me.cmb" + colName + ".DataBindings.Add(New Binding(" + """Text""" + ", mBindingSource2, " + """" & colName & """" + ", True))")
                    sbAll.AppendLine("Me.cmb" + colName + ".DataBindings(0).NullValue = """ + """")
                    sbAll.AppendLine("")
                Case "CheckBox"
                    'sbAll.AppendLine("Me.chk" + colName + " = New System.Windows.Forms.CheckBox()")
                    sbAll.AppendLine("Me.chk" + colName + ".DataBindings.Clear()")
                    sbAll.AppendLine("Me.chk" + colName + ".DataBindings.Add(New Binding(" + """Checked""" + ", mBindingSource2, " + """" & colName & """" + ", True))")
                    sbAll.AppendLine("Me.chk" + colName + ".DataBindings(0).NullValue = " & False)
                    sbAll.AppendLine("")
                Case Else
                    'sbAll.AppendLine("Me.txt" + colName + " = New System.Windows.Forms.TextBox()")
            End Select
        Next

        sbAll.AppendLine("End Sub")

        sbAll.AppendLine("End Class")

        sbAll.AppendLine("")

        Me.txtFormDesigner.Text = sbAll.ToString
        Me.txtFormDesigner.SelectAll()
        Return
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
        'sbAll.AppendLine("")
    End Sub
End Class