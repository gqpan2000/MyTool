Public Class Form3

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        'Part1:Private Sub InitializeComponent()
        Dim formName As String = Me.txtFormName.Text.Trim
        Dim tableName As String = Me.txttableName.Text.Trim

        ''===============================================================
        ''Validate
        'If String.IsNullOrEmpty(formName) Then
        '    MsgBox("Missing form name")
        '    Me.txtFormName.Focus()
        '    Return
        'End If

        'If String.IsNullOrEmpty(tableName) Then
        '    MsgBox("Missing table name")
        '    Me.TextBoxQuery.Focus()
        '    Return
        'End If
        ''===============================================================
        For i As Integer = DataGridView1.Rows.Count - 1 To 0 Step -1
            DataGridView1.Rows.RemoveAt(i)
        Next

        Me.TextBoxQuery.Text = Me.TextBoxQuery.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("[", "").Replace("]", "").Replace(",", "")
        For i As Integer = 0 To Me.TextBoxQuery.Lines.Length - 1
            Me.DataGridView1.Rows.Add()

            With Me.DataGridView1.Rows(Me.DataGridView1.RowCount - 1)
                .Cells(0).Value = Me.TextBoxQuery.Lines(i)
                .Cells("ColumnType").Value = "TextBox"
            End With
        Next

        Return


    End Sub

    Private Sub btnCreateFormDesignerText_Click(sender As System.Object, e As System.EventArgs) Handles btnCreateFormDesignerText.Click
        ''Validate
        If String.IsNullOrEmpty(Me.txtFormName.Text) Then
            MsgBox("Missing form name")
            Me.txtFormName.Focus()
            Return
        End If

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

        Dim formName As String = Me.txtFormName.Text
        If String.IsNullOrEmpty(formName) Then
            MsgBox("Missing form name")
            Me.txtFormName.Focus()
            Return
        End If

        Dim sbAll As New System.Text.StringBuilder
        sbAll.AppendLine("Public Class " + formName)
        sbAll.AppendLine("")
        sbAll.AppendLine("Dim mds1 As New DataSet")
        sbAll.AppendLine("Dim mBindingSource1 As BindingSource") '对应Parent
        sbAll.AppendLine("Dim mBindingSource2 As BindingSource") '对应Child

        'form load
        sbAll.AppendLine("")
        sbAll.AppendLine("Private Sub " + formName + "_Load(sender As Object, e As EventArgs) Handles MyBase.Load")
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sb1 As New System.Text.StringBuilder
        sb1.AppendLine("'Add button events")
        sb1.AppendLine("Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click")
        sb1.AppendLine("
        Dim ndr As DataRow = mds1.Tables(0).NewRow
        ndr.Item(0) = key'key value if available
        mds1.Tables(0).Rows.Add(ndr)

        Dim ndr1 As DataRow = mds1.Tables(1).NewRow
        ndr1.Item(0) =  key'key value if available
        mds1.Tables(1).Rows.Add(ndr1)

        'position to new row, so detail refresh
        DataGridView1.CurrentCell = DataGridView1.Rows(DataGridView1.RowCount - 1).Cells(0)
        'DataGridView1.Rows(DataGridView1.RowCount - 1).Visible = False
        DataGridView1.Enabled = False

        Me.ToggleButton(""ADD"")
        Me.ToggleDetail(""E"") 'enabele detail text box to edit

")
        sb1.AppendLine("End Sub")
        sb1.AppendLine("")

        sb1.AppendLine("'Modify button events")
        sb1.AppendLine("Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click")
        sb1.AppendLine("
 DataGridView1.Enabled = False
        ToggleButton(""MODIFY"")
        Me.ToggleDetail(""E"") 'enabele detail text box to edit
")
        sb1.AppendLine("End Sub")
        sb1.AppendLine("")

        sb1.AppendLine("'Delete button events")
        sb1.AppendLine("Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click")
        sb1.AppendLine("ToggleButton(""BACK"")")
        sb1.AppendLine("End Sub")
        sb1.AppendLine("")

        sb1.AppendLine("'Duplicate button events")
        sb1.AppendLine("Private Sub btnDuplicate_Click(sender As Object, e As EventArgs) Handles btnDuplicate.Click")
        sb1.AppendLine("'add duplicate code here")
        sb1.AppendLine("ToggleButton(""BACK"")")
        sb1.AppendLine("End Sub")
        sb1.AppendLine("")

        sb1.AppendLine("'Save button events")
        sb1.AppendLine("
        Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
            If IsValidForSave() Then 'validate if good to save
                If SaveForm() Then 'save to database
                    ToggleButton(""BACK"")
                End If
            End If
        End Sub")

        sb1.AppendLine("'Cancel button events")
        sb1.AppendLine("
        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            Me.mds1.Tables(1).RejectChanges()'roll back changes
            Me.mds1.Tables(0).RejectChanges()'roll back changes
            ToggleButton(""BACK"")
            Me.ToggleDetail(""D"") 'disabele detail text box to readonly
            Me.DataGridView1.Enabled = True
        End Sub")


        sb1.AppendLine("")
        sb1.AppendLine("'SaveForm")
        sb1.AppendLine("
        Private Function SaveForm() As Boolean
        'add add,modify,delete code here
        End Function")

        sb1.AppendLine("")
        sb1.AppendLine("'IsValidForSave")
        sb1.AppendLine("
        Private Function IsValidForSave() As Boolean
        'add validate code here before save to database
        End Function")

        sb1.AppendLine("")
        sb1.AppendLine("'ToggleButton")
        sb1.AppendLine("
        Private Sub ToggleButton(action As String)
        Select Case action
            Case ""ADD"" 'add
                Me.btnAdd.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnDuplicate.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
            Case ""MODIFY"" 'modify
                Me.btnAdd.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnDuplicate.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
            Case ""DELETE"" 'delete
                Me.btnAdd.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnDuplicate.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
            Case ""DUPULICATE"" 'duplicate
                Me.btnAdd.Enabled = False
                Me.btnModify.Enabled = False
                Me.btnDelete.Enabled = False
                Me.btnDuplicate.Enabled = False

                Me.btnSave.Enabled = True
                Me.btnCancel.Enabled = True
            Case ""SAVE"" 'save
                Me.btnAdd.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnDuplicate.Enabled = True

                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
            Case ""CANCEL"" 'cancel
                Me.btnAdd.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnDuplicate.Enabled = True

                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
            Case ""BACK"" 'cancel
                Me.btnAdd.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnDuplicate.Enabled = True

                Me.btnSave.Enabled = False
                Me.btnCancel.Enabled = False
        End Select
    End Sub")



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Toggle detail")
        sb1.AppendLine("
         Private Sub ToggleDetail(action As String)
        Select Case action
            Case ""E""
                For Each ctr As Control In Me.Controls
                    If TypeOf (ctr) Is TextBox Then
                        CType(ctr, TextBox).ReadOnly = False
                    ElseIf TypeOf (ctr) Is ComboBox Then
                        CType(ctr, ComboBox).Enabled = True
                    ElseIf TypeOf (ctr) Is CheckBox Then
                        CType(ctr, CheckBox).Enabled = True
                    End If
                Next
            Case ""D""
                For Each ctr As Control In Me.Controls
                    If TypeOf (ctr) Is TextBox Then
                        CType(ctr, TextBox).ReadOnly = True
                    ElseIf TypeOf (ctr) Is ComboBox Then
                        CType(ctr, ComboBox).Enabled = False
                    ElseIf TypeOf (ctr) Is CheckBox Then
                        CType(ctr, CheckBox).Enabled = False
                    End If
                Next
            Case Else
                For Each ctr As Control In Me.Controls
                    If TypeOf (ctr) Is TextBox Then
                        CType(ctr, TextBox).ReadOnly = Not CType(ctr, TextBox).ReadOnly
                    ElseIf TypeOf (ctr) Is ComboBox Then
                        CType(ctr, ComboBox).Enabled = Not CType(ctr, ComboBox).Enabled
                    ElseIf TypeOf (ctr) Is CheckBox Then
                        CType(ctr, CheckBox).Enabled = Not CType(ctr, CheckBox).Enabled
                    End If
                Next
        End Select
    End Sub")



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        Me.txtFormDesigner.Text = sb1.ToString
        Me.txtFormDesigner.SelectAll()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim formName As String = Me.txtFormName.Text.Trim
        If String.IsNullOrEmpty(formName) Then
            MsgBox("Form Name missed.")
            Me.txtFormName.Focus()
            Return
        End If

        Dim sb1 As New System.Text.StringBuilder
        sb1.AppendLine("
Dim mds1 As New DataSet
Dim mBindingSource1 As BindingSource
'Dim mBindingSource2 As BindingSource
Dim mIsFormLoadSuccess As Boolean 'if form load with error, this form will close in activated event, can not dispose in form load event
")

        sb1.AppendLine("#Region ""Form Load,Actived,Closing events""")

        'form active event
        sb1.AppendLine(
            "
             Private Sub " + formName + "_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
               'form activated 
                If Not mIsFormLoadSuccess Then
                    Me.Dispose()
                End If
            End Sub
            ")


        'form closing event
        sb1.AppendLine(
            "
             Private Sub " + formName + "_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
                'For Each OpenForm As Form In FrmMain.MdiChildren          
                'Next
            End Sub
            ")


        'form load event
        sb1.AppendLine(
            "
             Private Sub " + formName + "_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
                Try
                    LoadDataSet()

                    mBindingSource1 = New BindingSource
                    mBindingSource1.DataSource = mds1
                    mBindingSource1.DataMember = ""Parent""

                    'mBindingSource2 = New BindingSource
                    'mBindingSource2.DataSource = mBindingSource1
                    'mBindingSource2.DataMember = ""ParentChild""

                    DataGridView1.DataSource = Nothing
                    DataGridView1.DataSource = mBindingSource1

                    'add control bindings
                     AddControlBindings()

                    ToggleButtons(False)

                    'more form init
                    Me.DataGridView1.ReadOnly = True
                    Me.DataGridView1.AllowUserToAddRows = False

                    mIsFormLoadSuccess = True'this form load without error
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                    mIsFormLoadSuccess = False
                End Try
            End Sub
            ")

        'Show dataset
        sb1.AppendLine(
            "
            Private Sub LoadDataSet()
        Dim strSql As String = ""SELECT * FROM yourtablename""
        Dim errorMsg As String = """"
        mds1 = MyDll.SQLDB.LoadDataSetByQuery(strSql, GetConnection, errorMsg)
        'mds1 = GetYourDataSet
        mds1.Tables(0).TableName = ""Parent""
        'mds1.Tables(1).TableName = ""Child""
        'mds1.Relations.Add(""ParentChild"", mds1.Tables(0).Columns(""yourkey""), mds1.Tables(1).Columns(""yourkey""))
    End Sub
            ")

        'Show Form
        sb1.AppendLine(
            "
             Private Sub ShowForm()
                
            End Sub

            'Add control bindings
             Private Sub AddControlBindings()
            end sub
            ")

        sb1.AppendLine("#End Region")

        Me.txtFormDesigner.Text = sb1.ToString

    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sb1 As New System.Text.StringBuilder
        sb1.Append("
#Region ""Form Load""
Private Sub FrmYourForm_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
'Add form activated code here
End Sub

Private Sub FrmYourFormLoad(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
'add form load code here
End Sub
")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
         Dim sb1 As New System.Text.StringBuilder
        sb1.Append("
#Region ""Toggle control and command button""
    Private Sub ToggleButtons(toEdit As Boolean)
        For Each ctl As Control In Me.PanelDetail.Controls
            If TypeOf (ctl) Is TextBox Then
                CType(ctl, TextBox).ReadOnly = Not toEdit
            ElseIf TypeOf (ctl) Is ComboBox Then
                CType(ctl, ComboBox).Enabled = toEdit
            ElseIf TypeOf (ctl) Is CheckBox Then
                CType(ctl, CheckBox).Enabled = toEdit
            End If
        Next
    End Sub

    Private Sub ToggleCmdButton(action As String)
        'Set all button disabled
        Me.btnDuplicate.Enabled = False
        Me.btnAdd.Enabled = False
        Me.btnModify.Enabled = False
        Me.btnDelete.Enabled = False
        Me.btnCancel.Enabled = False
        Me.btnSave.Enabled = False

        'different action allow some button enabled
        Select Case action
            Case ""Add"", ""Modify"", ""Duplicate""
                Me.btnCancel.Enabled = True
                Me.btnSave.Enabled = True
            Case ""Cancel""
                Me.btnDuplicate.Enabled = True
                Me.btnAdd.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
                Me.btnSave.Enabled = False
            Case ""Save""
                Me.btnDuplicate.Enabled = True
                Me.btnAdd.Enabled = True
                Me.btnModify.Enabled = True
                Me.btnDelete.Enabled = True
        End Select
    End Sub
#End Region
")

        txtFormDesigner.Text = sb1.ToString
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
         Dim sb1 As New System.Text.StringBuilder
        sb1.Append("
#Region ""Duplicate,Add,Modify,Delete,Cancel,Save buttons""


 Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim ndr As DataRow = Me.mds1.Tables(0).NewRow
        Me.mds1.Tables(0).Rows.Add(ndr)
        Me.mBindingSource1.MoveLast()

        Me.DataGridView1.Enabled = False
        ToggleButtons(True)
        ToggleCmdButton(""Add"")
    End Sub



    Private Sub btnDuplicate_Click(sender As Object, e As EventArgs) Handles btnDuplicate.Click
        'current index
        Dim index As Integer = Me.mBindingSource1.IndexOf(Me.mBindingSource1.Current)

        'new duplicated row
        Dim ndr As DataRow = Me.mds1.Tables(0).NewRow
        Dim dr As DataRow = Me.mds1.Tables(0).Rows(index)
        For Each col As DataColumn In Me.mds1.Tables(0).Columns
            ndr.Item(col) = dr.Item(col) 'copy data from current
        Next

        ndr.Item(yourid) = 0

        Me.mds1.Tables(0).Rows.Add(ndr)
        Me.mBindingSource1.MoveLast()

        Me.DataGridView1.Enabled = False
        ToggleButtons(True)
        ToggleCmdButton(""Duplicate"")
    End Sub



    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Me.DataGridView1.Enabled = False
        ToggleButtons(True)
        ToggleCmdButton(""Modify"")
    End Sub

 Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If IsNothing(Me.mBindingSource1.Current) Then
             MsgBox(""Please select a record."")
            Return
        End If

        Dim strMsg As String = 'your message
        If Not PctlLib.SysRefDB.IsConfirmDelete(strMsg, ""Confirm to delete"") Then
            Return
        End If

        Me.mBindingSource1.RemoveCurrent()

        Dim dt1 As DataTable = Me.mds1.Tables(0).GetChanges()

        'Save to database, if not success,database will roll back
'here roll back datasource changed
        If Not SaveToDatabase(dt1) Then
            Me.mds1.RejectChanges()
            Return
        End If
    End Sub


    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.mds1.RejectChanges()

        Me.DataGridView1.Enabled = True
        ToggleButtons(False)
        ToggleCmdButton(""Cancel"")
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not IsValidToSave() Then
            Return
        End If

        'accept these changes or new
        Me.mBindingSource1.EndEdit()

        Dim dt1 As DataTable = Me.mds1.Tables(0).GetChanges()
        If IsNothing(dt1) Then
            MsgBox(""No new or changed"")
            Return
        End If

        If dt1.Rows.Count > 1 Then
            MsgBox(""Should only have one record changed or added"")
            Return
        End If

        Dim myTrans As SqlTransaction = Nothing
        Dim oConn As SqlConnection = GetConnection()
        Dim myCommand As New SqlCommand

        Try
            oConn.Open()
            myTrans = oConn.BeginTransaction()
            With myCommand
                .Connection = oConn
                .Transaction = myTrans
            End With

            Dim errorMsg As String = """"
            Dim affectedRow As Integer = 0
            Dim tableName As String = ""yourtable""
            Dim keys As String() = {""yourid"".ToLower} 'must convert all key name to low case, because later dll use contain function to compare lower case
            MyDll.DataTableDB.SaveByTableName(dt1, tableName, Keys, myCommand, errorMsg,, affectedRow)
            If errorMsg.Length > 0 Then
                Throw New ApplicationException(errorMsg)
            End If

            Dim expectAffectedRow As Integer = 1
            If expectAffectedRow <> affectedRow Then
                Throw New ApplicationException(""expect Affected row not equal to affected row"")
            End If

            myTrans.Commit()

        Catch ex As Exception
            myTrans.Rollback()
            MsgBox(ex.Message.ToString)
        Finally
            oConn.Close()
            myCommand = Nothing
            myTrans = Nothing

            Me.mds1.AcceptChanges()'final accept changes
            Me.DataGridView1.Enabled = True
            ToggleButtons(False)
            ToggleCmdButton(""Save"")
            Me.DataGridView1.Focus()
        End Try
End sub

 Private Function IsValidToSave() As Boolean
        If Not IsTextBoxLengthValid() Then
            Return False
        End If
        Return True
    End Function

Private Function IsTextBoxLengthValid() As Boolean
        'If Me.txtCustomerId.Text.Length = 0 Then
        'MsgBox()
        'Return False
        'End If


        Return True
    End Function
#End Region
")

        txtFormDesigner.Text = sb1.ToString
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim sbAll As New System.Text.StringBuilder
        sbAll.AppendLine("Private function IsTextBoxLengthValid() as Boolean")
        For i As Integer = 0 To Me.DataGridView1.RowCount - 1
            Dim colName As String = Me.DataGridView1.Rows(i).Cells("ColumnName").Value.ToString

            sbAll.AppendLine("IF Me.txt" + colName + ".Text.Length = 0 THEN ")
            sbAll.AppendLine("Msgbox (" + """" + colName + " text length is not correct"")")
            sbAll.AppendLine("Me." + colName + ".Focus()")
            sbAll.AppendLine("Return false")
            sbAll.AppendLine("END IF")
        Next
        sbAll.AppendLine("End Function")

        txtFormDesigner.Text = sbAll.ToString
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim sb1 As New System.Text.StringBuilder
        sb1.AppendLine("
Dim mds1 As New DataSet
Dim mBindingSource1 As BindingSource
")

        txtFormDesigner.Text = sb1.ToString
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim sb1 As New System.Text.StringBuilder
        sb1.AppendLine("
'If Me.txtCustomerID.Text.Trim.Length = 0 Then
            'MsgBox(""Customer ID from SOFI missing"")
            'FocusControl(Me.txtCustomerID)
            'Me.txtCustomerID.Focus()
            'Return False
Private Sub FocusControl(ctl As Object)
        For Each c As Control In Me.TabControl1.TabPages(""tp1"").Controls
            If c.Equals(ctl) Then
                TabControl1.SelectedTab = TabControl1.TabPages(""tp1"")
                c.Focus()
                Return
            End If
        Next

        For Each c As Control In Me.TabControl1.TabPages(""tp2"").Controls
            If c.Equals(ctl) Then
                TabControl1.SelectedTab = TabControl1.TabPages(""tp2"")
                c.Focus()
                Return
            End If
        Next
    End Sub
")

        txtFormDesigner.Text = sb1.ToString
    End Sub
End Class