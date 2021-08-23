Public Class Form1

    Private Sub btnString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnString.Click
        If Me.txtClassType.Lines.Length = 0 Then
            Me.txtClassType.Text = "String"
        Else
            Me.txtClassType.Text &= vbNewLine
            Me.txtClassType.Text &= "String"
        End If
    End Sub

    Private Sub btnInteger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInteger.Click
        If Me.txtClassType.Lines.Length = 0 Then
            Me.txtClassType.Text = "Integer"
        Else
            Me.txtClassType.Text &= vbNewLine
            Me.txtClassType.Text &= "Integer"
        End If
    End Sub

    Private Sub btnBoolean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoolean.Click
        If Me.txtClassType.Lines.Length = 0 Then
            Me.txtClassType.Text = "Boolean"
        Else
            Me.txtClassType.Text &= vbNewLine
            Me.txtClassType.Text &= "Boolean"
        End If
    End Sub

    Private Sub btnDecimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecimal.Click
        If Me.txtClassType.Lines.Length = 0 Then
            Me.txtClassType.Text = "Decimal"
        Else
            Me.txtClassType.Text &= vbNewLine
            Me.txtClassType.Text &= "Decimal"
        End If
    End Sub

    Private Sub btnDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDate.Click
        If Me.txtClassType.Lines.Length = 0 Then
            Me.txtClassType.Text = "Date"
        Else
            Me.txtClassType.Text &= vbNewLine
            Me.txtClassType.Text &= "Date"
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim str As String = System.Guid.NewGuid().ToString
        MsgBox(str)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim str As String = IO.Path.GetTempPath()
        MsgBox(str)
        GetTempFolderGuid()
    End Sub

    Private Sub btnCreateNewClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNewClass.Click

        If Me.txtClassName.Lines.Length = 0 OrElse _
           Me.txtClassType.Lines.Length = 0 OrElse _
           Me.txtClassName.Lines.Length <> Me.txtClassType.Lines.Length Then
            MsgBox("Class name, type lines must larger than zero and equal in lines")
            Return
        End If

        Dim lineCount As Integer = Me.txtClassType.Lines.Length

        'new class string
        Dim newClass As String = ""

        'define part
        '--------------------------------------------------------------------------------------------------------------
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= "Private m_" & Me.txtClassName.Lines(i - 1) & " As "
            newClass &= Me.txtClassType.Lines(i - 1)
        Next

        'Initial Empty Part
        newClass &= vbNewLine
        newClass &= vbNewLine
        newClass &= "Public Sub New()"
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= "ME." & Me.txtClassName.Lines(i - 1)
            Select Case Me.txtClassType.Lines(i - 1)
                Case "String"
                    newClass &= " = """
                Case "Integer"
                    newClass &= " = 0"
                Case "Decimal"
                    newClass &= " = 0"
                Case "Date"
                    newClass &= " = Today"
                Case "Boolean"
                    newClass &= " = False"
            End Select
        Next
        newClass &= vbNewLine
        newClass &= "End Sub"


        'Initial with value Part1
        '--------------------------------------------------------------------------------------------------------------
        newClass &= vbNewLine
        newClass &= vbNewLine
        newClass &= "Public Sub New( _"
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= "ByVal "
            'first letter to lower
            newClass &= Me.txtClassName.Lines(i - 1).Substring(0, 1).ToLower & Me.txtClassName.Lines(i - 1).Substring(1)
            newClass &= " As " & Me.txtClassType.Lines(i - 1)
            'last variant no , _
            If i < lineCount Then
                newClass &= ", _"
            Else
                newClass &= " _"
            End If
        Next

        newClass &= vbNewLine
        newClass &= ")"

        'Initial with value Part, SetValue
        newClass &= vbNewLine
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= "Me." & Me.txtClassName.Lines(i - 1)
            newClass &= " = " & Me.txtClassName.Lines(i - 1).Substring(0, 1).ToLower & Me.txtClassName.Lines(i - 1).Substring(1)
        Next

        newClass &= vbNewLine
        newClass &= "End Sub"


        'Property Part
        '--------------------------------------------------------------------------------------------------------------
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= vbNewLine
            newClass &= "Public Property "
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= "() AS "
            newClass &= Me.txtClassType.Lines(i - 1)

            'Get
            newClass &= vbNewLine
            newClass &= "Get"
            newClass &= vbNewLine
            newClass &= "Return m_" & Me.txtClassName.Lines(i - 1)
            newClass &= vbNewLine
            newClass &= "End Get"

            'Set
            newClass &= vbNewLine
            newClass &= "Set(ByVal value As "
            newClass &= Me.txtClassType.Lines(i - 1) & ")"
            newClass &= vbNewLine
            newClass &= "m_" & Me.txtClassName.Lines(i - 1) & "=value"
            newClass &= vbNewLine
            newClass &= "End Set"
            newClass &= vbNewLine
            newClass &= "End Property"
        Next
        'Public Property ItemID() As String
        '    Get
        '        Return m_ItemID
        '    End Get
        '    Set(ByVal value As String)
        '        m_ItemID = value
        '    End Set
        'End Property


        Me.txtNewClass.Text = newClass
    End Sub


    Private Function GetTempFolderGuid() As String
        Dim folder As String = IO.Path.Combine(IO.Path.GetTempPath, Guid.NewGuid.ToString)
        Do While IO.Directory.Exists(folder)
            folder = IO.Path.Combine(IO.Path.GetTempPath, Guid.NewGuid.ToString)
        Loop
        Return folder
    End Function

    ''' <summary>
    ''' create SQL insert string with parameter
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClasstoText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClasstoText.Click
        If Me.txtTableName.Text.Trim.Length = 0 Then
            MsgBox("Missign Table Name")
            Me.txtTableName.Focus()
            Return
        End If

        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Replace single quote to double quote in below string"

        '-----Fields part
        'insertString &= vbNewLine
        'insertString &= "strSql=''"
        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "INSERT INTO " & Me.txtTableName.Text.Trim & " "
        insertString &= """"

        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "("
        insertString &= """"

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "strSql &="""
            'insertString &= "@"
            insertString &= Me.txtClassName.Lines(i)
            If i < lineCount - 1 Then
                insertString &= ","
            End If
            insertString &= """"    
        Next

        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= ")"
        insertString &= """"

        '-----VALUES part
        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "VALUES "
        insertString &= """"

        '-----Parameter part
        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "("
        insertString &= """"
        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "strSql &="""
            insertString &= "@"
            insertString &= Me.txtClassName.Lines(i)
            If i < lineCount - 1 Then
                insertString &= ","
            End If
            insertString &= """"
        Next

        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= ")"
        insertString &= """"

        Me.txtNewClass.Text = insertString
    End Sub

    ''' <summary>
    ''' Create SQL Update string
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTexttoClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTexttoClass.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "//Replace single quote to double quote in below string"

        '-----Fields part
        insertString &= vbNewLine
        insertString &= "strSql=''"
        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "UPDATE " & Me.txtTableName.Text.Trim & " "
        insertString &= """"
        insertString &= vbNewLine
        insertString &= "strSql &="""
        insertString &= "SET "
        insertString &= """"

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "strSql &="""
            insertString &= Me.txtClassName.Lines(i)
            insertString &= "=@"
            insertString &= Me.txtClassName.Lines(i)
            If i < lineCount - 1 Then
                insertString &= ","
            End If
            insertString &= """"
        Next

        '-----WHERE part
        insertString &= vbNewLine
        insertString &= "strSql &="
        insertString &= """"
        insertString &= " WHERE"
        insertString &= """"

        Me.txtNewClass.Text = insertString
    End Sub

    ''' <summary>
    ''' SQL Parameter List
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Handle Null, Date Type accordingly"

        '-----Fields part
        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= ".Parameters.AddWithValue("
            insertString &= """"

            insertString &= "@"
            insertString &= Me.txtClassName.Lines(i)

            insertString &= """"
            insertString &= ","
            insertString &= Me.txtTableName.Text.Trim & "." & Me.txtClassName.Lines(i)
            insertString &= ")"
        Next

        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Me.txtTableName.Text.Trim.Length = 0 Then
            MsgBox("Missign Table Name")
            Me.txtTableName.Focus()
            Return
        End If

        Me.txtClassName.Text = ""
        Me.txtClassType.Text = ""

        Dim strSql As String = ""
        strSql &= "SELECT ORDINAL_POSITION,"
        strSql &= "COLUMN_NAME,"
        strSql &= "DATA_TYPE,"
        strSql &= "CHARACTER_MAXIMUM_LENGTH,"
        strSql &= "IS_NULLABLE,"
        strSql &= "COLUMN_DEFAULT "
        strSql &= "FROM INFORMATION_SCHEMA.COLUMNS "
        strSql &= "WHERE TABLE_NAME ="
        strSql &= "'" & Me.txtTableName.Text.Trim & "'"
        'use nature order
        'strSql &= "ORDER BY ORDINAL_POSITION ASC "

        Dim oconn As SqlClient.SqlConnection
        If Me.rdUTGNT.Checked Then
            oconn = GetUTGNTConnection()
        ElseIf Me.rdUTGUS.Checked Then
            oconn = GetUTGUSConnection()
        ElseIf Me.rdSOFI.Checked Then
            oconn = GetSOFIConnection()
        ElseIf Me.rdBIS.Checked Then
            HandleAccessTable()
            Return
        End If

        Dim dt As New DataTable
        Dim mycommand As New SqlClient.SqlCommand
        mycommand.CommandText = strSql
        PctlLib.SqlDB.LoadDataTableBySqlCommand(dt, mycommand, oconn)

        For i As Integer = 0 To dt.Rows.Count - 1
            If i > 0 Then
                Me.txtClassName.Text &= vbNewLine
            End If
            Me.txtClassName.Text &= dt.Rows(i).Item("COLUMN_NAME").ToString
            If i > 0 Then
                Me.txtClassType.Text &= vbNewLine
            End If
            Me.txtClassType.Text &= dt.Rows(i).Item("DATA_TYPE").ToString
        Next

        Return

    End Sub

    Private Sub HandleAccessTable()   
        Dim strSql As String = ""
        strSql &= "SELECT * "
        strSql &= "FROM " & Me.txtTableName.Text.Trim
        strSql &= " WHERE 1=0 "

        'oledb database  
        Dim dt As New DataTable
        Dim OledbCmd As New OleDb.OleDbCommand
        With OledbCmd
            .CommandText = strSql
        End With
        PctlLib.SqlDB.LoadDataTableByOledbCommand(dt, OledbCmd, GetBISConnection)

        For i As Integer = 0 To dt.Columns.Count - 1
            If i > 0 Then
                Me.txtClassName.Text &= vbNewLine
            End If
            Me.txtClassName.Text &= dt.Columns(i).ColumnName.ToString
            If i > 0 Then
                Me.txtClassType.Text &= vbNewLine
            End If
            Me.txtClassType.Text &= dt.Columns(i).DataType.Name.ToString
        Next
    End Sub
    ''' <summary>
    ''' Compare two class, get changed update string
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click    
        If Me.txtClassName.Lines.Length = 0 OrElse _
          Me.txtClassName.Lines.Length = 0 OrElse _
          Me.txtClassName.Lines.Length <> Me.txtClassName.Lines.Length Then
            MsgBox("Class name, type lines must larger than zero and equal in lines")
            Return
        End If

        Dim lineCount As Integer = Me.txtClassName.Lines.Length

        '-----------
        'Message part
        Dim newClass As String = ""
        newClass &= "'************************************************************"
        newClass &= vbNewLine
        newClass &= "'************************************************************"
        newClass &= vbNewLine
        newClass &= "'1. User your owntable name to replace"
        newClass &= vbNewLine
        newClass &= "'2. Use your own newClass and oldClass to replace."
        newClass &= vbNewLine
        newClass &= "'3. If key field, like ItemID also changed, make sure use @newItemID and @oldItemID parameter properly"
        newClass &= vbNewLine
        newClass &= "'4. Use correct ID in WHERE Clause"
        newClass &= vbNewLine
        newClass &= "'************************************************************"
        newClass &= vbNewLine
        newClass &= "'************************************************************"

        '-----------
        'Define part
        newClass &= vbNewLine
        newClass &= "Dim strSql As String = """""
        newClass &= vbNewLine
        newClass &= "Dim myCommand As New SqlClient.SqlCommand"


        newClass &= vbNewLine
        newClass &= vbNewLine
        newClass &= "strSql &="""
        newClass &= "UPDATE tableName "
        newClass &= """"
        newClass &= vbNewLine
        newClass &= "strSql &="""
        newClass &= "SET "
        newClass &= """"
        newClass &= vbNewLine
        newClass &= vbNewLine

        newClass &= "'//Get changed string. If there is change, append changed string to sql string"
        newClass &= vbNewLine
        newClass &= "'//If there is no change, this command will not execute"
        newClass &= vbNewLine
        newClass &= "Dim changedSql As String = """""
        newClass &= vbNewLine

        'define part
        '--------------------------------------------------------------------------------------------------------------
        For i As Integer = 1 To lineCount
            newClass &= vbNewLine
            newClass &= "If newClass."
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= "<>"
            newClass &= "oldClass."
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= vbNewLine

            '-----
            newClass &= "changedSql &="
            newClass &= """"
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= "=@" & Me.txtClassName.Lines(i - 1)
            newClass &= ","
            newClass &= """"

            '-----

            '-----
            newClass &= vbNewLine
            newClass &= "myCommand.Parameters.AddWithValue("
            newClass &= """"
            '.Parameters.AddWithValue("@firstName", customer.FirstName)
            newClass &= "@"
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= """"
            newClass &= ","
            newClass &= "newClass."
            newClass &= Me.txtClassName.Lines(i - 1)
            newClass &= ")"
            '-----

            newClass &= vbNewLine
            newClass &= "End If"
            newClass &= vbNewLine
        Next

        'test if has changed
        newClass &= vbNewLine
        newClass &= "'//test if has changed"

        newClass &= vbNewLine
        newClass &= "If changedSql=""""" & " Then"
        newClass &= vbNewLine
        newClass &= "'//no change, return True. Dispose myCommand"
        newClass &= vbNewLine
        newClass &= "myCommand.Dispose"
        newClass &= vbNewLine
        newClass &= "Return True"
        newClass &= vbNewLine
       
        newClass &= "Else"
        newClass &= vbNewLine
        newClass &= "'//Has change, continue transaction command"
        newClass &= vbNewLine

        'remove last ,
        newClass &= "'//Remove last ,"
        newClass &= vbNewLine
        newClass &= "changedSql = changedSql.Remove(changedSql.Length - 1)"
        newClass &= vbNewLine
        newClass &= "strSql &=changedSql"
        newClass &= vbNewLine
        'add WHERE filter
        'strSql &=""
        newClass &= "strSql &=""" & " WHERE ID=@ID """
        newClass &= vbNewLine
        newClass &= "myCommand.Parameters.AddWithValue("
        newClass &= """"
        newClass &= "@ID"
        newClass &= """"
        newClass &= ","
        newClass &= "ID"  
        newClass &= ")"

        newClass &= vbNewLine
        newClass &= "myCommand.CommandText=strSql"
        newClass &= vbNewLine
        newClass &= "End If"


        Me.txtNewClass.Text = newClass
    End Sub

    Private Sub chkVPN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVPN.CheckedChanged
        gUseVPN = Me.chkVPN.Checked
    End Sub

    Private Sub btnGetShowClass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetShowClass.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Replace non text field to other controls"

        '-----Fields part
        'insertString &= vbNewLine
        'insertString &= "strSql=''"
      
        insertString = ""
        insertString &= vbNewLine
      
        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "Me.txt"
            insertString &= Me.txtClassName.Lines(i) & ".text"
            insertString &= "=" & Me.txtTableName.Text.Trim & "."
            insertString &= Me.txtClassName.Lines(i)
        Next
        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Replace non text field to other controls"

        '-----Fields part
        'insertString &= vbNewLine
        'insertString &= "strSql=''"

        insertString = ""
        insertString &= vbNewLine

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "."
            insertString &= Me.txtClassName.Lines(i)
            insertString &= "=Me.txt"
            insertString &= Me.txtClassName.Lines(i)
            insertString &= ".Text.Trim"
        Next
        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Replace dgv1 with your own datagridview "

        '-----Fields part
        'insertString &= vbNewLine
        'insertString &= "strSql=''"

        insertString = ""
        insertString &= vbNewLine

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "."
            insertString &= Me.txtClassName.Lines(i)

            insertString &= "= PctlLib.Pmath.Field2Str(Me.dgv1.SelectedRows(0).Cells("
            insertString &= """"
            insertString &= Me.txtClassName.Lines(i)
            insertString &= """"
            insertString &= ").Value"
            insertString &= ")"
        Next
        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//Replace non string type field "
        insertString &= vbNewLine
        insertString &= "'//Handle Datetime type "
        insertString &= vbNewLine
        insertString &= "'//Handle Null Value "

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "."
            insertString &= Me.txtClassName.Lines(i)

            insertString &= "= PctlLib.Pmath.Field2Str(oReader("
            insertString &= """"
            insertString &= Me.txtClassName.Lines(i)
            insertString &= """"
            insertString &= ")"
            insertString &= ")"
        Next
        Me.txtNewClass.Text = insertString
    End Sub

    '//Convert SQL table column data type to VB.net Data type, like int to Integer
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim lineCount As Integer = Me.txtClassType.Lines.Length
     
        For i As Integer = 0 To lineCount - 1
            Me.txtClassType.Text &= vbNewLine
            Select Case Me.txtClassType.Lines(i).ToLower
                Case "smallint", "int", "int16", "int32"
                    Me.txtClassType.Text &= "Integer"
                Case "varchar", "nvarchar"
                    Me.txtClassType.Text &= "String"
                Case "bit"
                    Me.txtClassType.Text &= "Boolean"
                Case "numeric", "single"
                    Me.txtClassType.Text &= "Decimal"
                Case "smalldatetime", "datetime"
                    Me.txtClassType.Text &= "Date"
                Case Else
                    Me.txtClassType.Text &= Me.txtClassType.Lines(i)
            End Select
        Next
    End Sub
End Class
