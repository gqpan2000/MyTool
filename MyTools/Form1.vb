Public Class Form1
    Dim mdt1 As DataTable
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

#Region "Tab Ascii"

    'get a GUID
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuid.Click
        'MsgBox(Date.)
        Dim str As String = System.Guid.NewGuid().ToString
        MsgBox(str)
    End Sub

    'temp folder
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim str As String = IO.Path.GetTempPath()
        MsgBox(str)
        GetTempFolderGuid()
    End Sub

    'display text ASCII
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Dim s As String = Me.txtInput.Text
        'Me.txtAsciiTest.Clear()
        Dim str1 As String = ""
        For Each c As Char In s
            str1 &= vbNewLine & c & " " & Asc(c)
        Next
        Me.txtOutput.Text = str1
    End Sub

    'display text ASCII unicode
    Private Sub Button17_Click(sender As System.Object, e As System.EventArgs) Handles Button17.Click
        Dim s As String = Me.txtInput.Text
        'Me.txtAsciiTest.Clear()
        Dim str1 As String = ""
        For Each c As Char In s
            str1 &= vbNewLine & c & " " & AscW(c)
        Next
        Me.txtOutput.Text = str1
    End Sub

    'replace white letter to ~ as segment delimiter
    Private Sub Button16_Click(sender As System.Object, e As System.EventArgs) Handles Button16.Click
        'Assume LF+CR, LF change to segment delimer ~, CR replace with empty
        Dim str As String = Me.txtInput.Text

        Dim sb1 As New System.Text.StringBuilder
        For Each c As Char In str
            If Asc(c) = 10 Then
                sb1.Append("~")
            ElseIf Asc(c) = 13 Then
                sb1.Append("~")
            Else
                sb1.Append(c)
            End If
        Next

        Me.txtInput.Text = sb1.ToString.Replace("~~", "~")
    End Sub

    Private Sub Button13_Click(sender As System.Object, e As System.EventArgs) Handles Button13.Click
        'Dim str1 As String = "jpan@leapers.com;gqpan@leapers.com"
        Dim str1 As String = ""
        If str1.Contains(CChar(";")) Then
            'Dim str2 As String = str1.Substring(0, str1.IndexOf(CChar(";")))
            'Return
        End If

        Dim listEmailAddess As New List(Of String)
        'ReceiverEmail可能有多个，用；分开，这里convert成一个一个email，加入到listEmailAddess
        Dim s1 As String() = str1.Split(CChar(";"))
        For Each s As String In s1
            listEmailAddess.Add(s.ToLower)
        Next
        listEmailAddess.Add("jpan1@leapers.com")
        listEmailAddess.Add("jpan2@leapers.com")

        '非empty的email加入到email array
        Dim pkgArrayNew() As String
        pkgArrayNew = MyStringArray(listEmailAddess)
        Return
    End Sub


#End Region

    

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
        Class1.LoadDataTableByOledbCommand(dt, OledbCmd, GetBISConnection)

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
                Case "smalldatetime", "datetime", "datetime2"
                    Me.txtClassType.Text &= "Date"
                Case Else
                    Me.txtClassType.Text &= Me.txtClassType.Lines(i)
            End Select
        Next
    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "'//class a,class b to your class "

        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "a."
            insertString &= Me.txtClassName.Lines(i)
            insertString &= "=b."
            insertString &= Me.txtClassName.Lines(i)
        Next
        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub chkTest_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTest.CheckedChanged
        If chkTest.Checked Then
            gIsTest = True
        Else
            gIsTest = False
        End If
    End Sub

   

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        Dim lineCount As Integer = Me.txtClassName.Lines.Length
        Dim insertString As String = "//Replace single quote to double quote in below string"

        '-----Fields part
        insertString &= vbNewLine
        insertString &= "Dim sb As New System.Text.StringBuilder"

        insertString &= vbNewLine
        insertString &= "sb.Append("""
        insertString &= "UPDATE " & Me.txtTableName.Text.Trim & " "")"

        insertString &= vbNewLine
        insertString &= "sb.Append(""SET " & " "")"


        For i As Integer = 0 To lineCount - 1
            insertString &= vbNewLine
            insertString &= "IF newClass." & Me.txtClassName.Lines(i) & "<>oldClass." & Me.txtClassName.Lines(i) & " THEN "
            insertString &= "sb.Append("""
            insertString &= Me.txtClassName.Lines(i)
            insertString &= "=@"
            insertString &= Me.txtClassName.Lines(i)
            insertString &= ","")"
        Next

        'Last columne:use a non important field as last must update field, no matter if have other fields need update
        insertString &= vbNewLine
        insertString &= "sb.Append(""nonImportantColumn=@nonImportantColumn "")"


        '-----WHERE part
        insertString &= vbNewLine
        insertString &= "sb.Append(""WHERE keyColumn=@keyColumn "")"

        Me.txtNewClass.Text = insertString
    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        For Each s As String In Me.txtInput.Lines
            If s.Contains(Me.TextBox1.Text) Then
                MsgBox(s)
                Return
            End If
        Next
    End Sub


    Private Function MyStringArray(list1 As List(Of String)) As String()
        Dim s() As String 'define a string array, here s()=nothing

        For Each sn As String In list1
            If sn.Length > 0 Then
                If IsNothing(s) Then
                    ReDim Preserve s(0) 'if s() is nothing, re adjust string array length to 1
                Else
                    ReDim Preserve s(UBound(s) + 1) 'if s() has value,re adjust string array length by add 1
                End If
                s(UBound(s)) = sn
            End If
        Next
        Return s
    End Function

    Private Sub Button14_Click(sender As System.Object, e As System.EventArgs) Handles Button14.Click
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("strSql &=""", "strSql &=|")
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("""", """)")
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("strSql &=|", "sb1.AppendLine(""")
        Return
    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        txtInput.Clear()
        txtInput.Focus()
    End Sub


  

    Private Sub Button19_Click(sender As System.Object, e As System.EventArgs) Handles Button19.Click
        Form3.Show()
        Return



    End Sub

    Private Shared Sub AddControlPart1(ByRef sb1 As System.Text.StringBuilder, ctlName As String, ctlType As System.Type, ByRef sbError As System.Text.StringBuilder)
        Select Case ctlType
            Case GetType(System.String)
                'Textbox add a label on left
                sb1.AppendLine("Me.Lbl" + ctlName + " = New System.Windows.Forms.Label()")
                sb1.AppendLine("Me.Txt" + ctlName + " = New System.Windows.Forms.TextBox()")
            Case GetType(System.Boolean)
                sb1.AppendLine("Me.Chk" + ctlName + " = New System.Windows.Forms.CheckBox()")
            Case Else
                sbError.AppendLine(ctlName + " not in")
        End Select
    End Sub

    Private Shared Sub AddControlPart2(ByRef sb1 As System.Text.StringBuilder, ctlName As String, ctlType As System.Type, colIndex As Integer, ByRef sbError As System.Text.StringBuilder)
        Dim objName As String
        Select Case ctlType
            Case GetType(System.String)
                

                objName = "Me.Lbl" + ctlName
                sb1.AppendLine(objName + ".AutoSize = True")
                sb1.AppendLine(objName + ".Location = New System.Drawing.Point(" + (10 * colIndex - 30).ToString + ", " + (20 * colIndex).ToString + ")")
                sb1.AppendLine(objName + ".Name = """ + "Lbl" + ctlName + """")
                sb1.AppendLine(objName + ".Size = New System.Drawing.Size(39, 13)")
                sb1.AppendLine(objName + ".Text = " + """" + ctlName + """")


                objName = "Me.Txt" + ctlName
                sb1.AppendLine(objName + ".Location = New System.Drawing.Point(" + (10 * colIndex).ToString + ", " + (20 * colIndex).ToString + ")")
                sb1.AppendLine(objName + ".Name = """ + "TextBox" + ctlName + """")
                sb1.AppendLine(objName + ".Size = New System.Drawing.Size(100, 20)")
                sb1.AppendLine(objName + ".TabIndex = " + colIndex.ToString)
            Case GetType(System.Boolean)
                objName = "Me.Chk" + ctlName
                sb1.AppendLine(objName + ".AutoSize = True")
                sb1.AppendLine(objName + ".Location = New System.Drawing.Point(158, 62)")
                sb1.AppendLine(objName + ".Name = " + """CheckBox1""")
                sb1.AppendLine(objName + ".Size = New System.Drawing.Size(81, 17)")
                sb1.AppendLine(objName + ".TabIndex = " + colIndex.ToString)
                sb1.AppendLine(objName + ".Text = " + """CheckBox1""")
                sb1.AppendLine(objName + ".UseVisualStyleBackColor = True")
            Case Else
                sbError.AppendLine(ctlName + " not in body")
        End Select
    End Sub

    Private Shared Sub AddControlPart3(ByRef sb1 As System.Text.StringBuilder, ctlName As String, ctlType As System.Type, colIndex As Integer, ByRef sbError As System.Text.StringBuilder)
        Dim objName As String
        Select Case ctlType
            Case GetType(System.String)
                objName = "Me.Txt" + ctlName          
                sb1.AppendLine("Me.Controls.Add(" + objName + ")")

                objName = "Me.Lbl" + ctlName
                sb1.AppendLine("Me.Controls.Add(" + objName + ")")
            Case GetType(System.Boolean)
                objName = "Me.Chk" + ctlName
                sb1.AppendLine("Me.Controls.Add(" + objName + ")")
            Case Else
                sbError.AppendLine(ctlName + " not in body3")
        End Select
    End Sub

    Private Shared Sub AddControlPart4(ByRef sb2 As System.Text.StringBuilder, ctlName As String, ctlType As System.Type, ByRef sbError As System.Text.StringBuilder)
        Select Case ctlType
            Case GetType(System.String)
                sb2.AppendLine("Friend WithEvents " + "Lbl" + ctlName + " As Label")
                sb2.AppendLine("Friend WithEvents " + "Txt" + ctlName + " As TextBox")
            Case GetType(System.Boolean)
                sb2.AppendLine("Friend WithEvents " + "Chk" + ctlName + " As CheckBox")
            Case Else
                sbError.AppendLine(ctlName + " not in part4")
        End Select
    End Sub


  
    'generate Insert or update from a datatable
    'exclude identity,computed,timestamp,guid column
    Private Sub Button21_Click(sender As System.Object, e As System.EventArgs) Handles Button21.Click
        Dim validCols As New List(Of String)
        'remove invalid column
        For Each dr As DataRow In Me.mdt1.Rows 'one table column names
            If Convert.ToBoolean(dr.Item("is_identity")) Then
                Continue For
            ElseIf Convert.ToBoolean(dr.Item("is_computed")) Then
                Continue For
            ElseIf Convert.ToBoolean(dr.Item("is_rowguidcol")) Then
                Continue For
            ElseIf Convert.ToString(dr.Item("system_data_type")).ToUpper = "TIMESTAMP" Then
                Continue For
            End If
            validCols.Add(dr.Item("column_name").ToString)
        Next



        Dim tableName As String = Me.mdt1.Rows(0).Item("table_name").ToString
        Dim listCmdTest As New List(Of String)

        listCmdTest.Add("IF NOT EXISTS (SELECT 1 FROM [" + tableName + "] WHERE keyCol_" + """+n.ToString+" + """ = @keyCol_" + """+n.ToString+" + """) ")

        'Insert string
        listCmdTest.Add("BEGIN ")
        listCmdTest.Add("INSERT INTO " + tableName + " ")
        listCmdTest.Add("(")
        For Each col As String In validCols
            listCmdTest.Add("[" + col + "],")
        Next
        listCmdTest(listCmdTest.Count - 1) = listCmdTest(listCmdTest.Count - 1).Remove(listCmdTest(listCmdTest.Count - 1).Length - 1, 1) 'remove last ,
        listCmdTest.Add(") ")

        listCmdTest.Add(" VALUES ")
        listCmdTest.Add("(")
        For Each col As String In validCols
            listCmdTest.Add("@" + col + "_" + """+n.ToString" + "+" + """,")
        Next
        listCmdTest(listCmdTest.Count - 1) = listCmdTest(listCmdTest.Count - 1).Remove(listCmdTest(listCmdTest.Count - 1).Length - 1, 1) 'remove last ,
        listCmdTest.Add(") ")

        listCmdTest.Add("END ")


        'Update string
        listCmdTest.Add("ELSE ")
        listCmdTest.Add("BEGIN ")

        listCmdTest.Add("UPDATE [" + tableName + "] " + "SET ")
        For Each col As String In validCols
            listCmdTest.Add(col + "=@" + col + "_" + """+n.ToString" + "+" + """,")
        Next
        listCmdTest(listCmdTest.Count - 1) = listCmdTest(listCmdTest.Count - 1).Remove(listCmdTest(listCmdTest.Count - 1).Length - 1, 1) 'remove last ,

        listCmdTest.Add("WHERE keyCol_" + """+n.ToString+" + """ = @keyCol_" + """+n.ToString+" + """) ")

        listCmdTest.Add("END ")

        'add sb1
        Dim sbT1 As New System.Text.StringBuilder
        For Each s As String In listCmdTest
            sbT1.AppendLine("sb1.appendline(""" + s + """)")
        Next

        Me.txtNewClass.Text = sbT1.ToString

        Me.txtNewClass.Text &= vbNewLine
        Me.txtNewClass.Text &= vbNewLine
        '++++++++++++++++++++++++++

        'parameter text directly project to text box
        listCmdTest.Clear()
        sbT1.Clear()
        For Each col As String In validCols
            listCmdTest.Add(".Parameters.AddWithValue(""" + "@" + col + "_""" + "+n.ToString,dr.Item(""" + col + """))")
        Next
        For Each s As String In listCmdTest
            sbT1.AppendLine(s)
        Next
        Me.txtNewClass.Text &= sbT1.ToString      
    End Sub

    Private Sub Button22_Click(sender As System.Object, e As System.EventArgs) Handles Button22.Click
        Dim n As Integer = 2
        Dim sb1 As New System.Text.StringBuilder
        Dim mycmd As New SqlClient.SqlCommand

        With mycmd

 
        End With

        Me.txtNewClass.Text = sb1.ToString
    End Sub

#Region "Tab: Compare two database"
    Private Sub btnCompare_Click(sender As System.Object, e As System.EventArgs) Handles btnCompare.Click
        If txtConnStr1.Text.Trim.Length = 0 Then
            MsgBox("Connection 1 string missing")
            Me.txtConnStr1.Focus()
            Return
        ElseIf txtConnStr2.Text.Trim.Length = 0 Then
            MsgBox("Connection 2 string missing")
            Me.txtConnStr2.Focus()
            Return
        End If

        '' "MultipleActiveResultSets=True;Data Source=Leapers-SQL;Initial Catalog=sofi_test;User Id=bob;Password=0318"
        Dim strSql As String = ""
        Dim mycommand As New SqlClient.SqlCommand
        Dim oConn1 As SqlClient.SqlConnection
        oConn1 = GetOtherConnection(Me.txtConnStr1.Text.Trim)
        Dim oConn2 As SqlClient.SqlConnection
        oConn2 = GetOtherConnection(Me.txtConnStr2.Text.Trim)


        strSql &= "SELECT OBJECT_SCHEMA_NAME(T.[object_id],DB_ID()) AS [Schema], "
        strSql &= "T.[name] AS [table_name], AC.[name] AS [column_name],   "
        strSql &= "TY.[name] AS system_data_type, AC.[max_length],  "
        strSql &= "AC.[precision], AC.[scale], AC.[is_nullable], AC.[is_ansi_padded],"
        strSql &= "ac.is_computed, ac.is_identity, ac.is_rowguidcol "

        strSql &= "FROM sys.[tables] AS T   "
        strSql &= "INNER JOIN sys.[all_columns] AC ON T.[object_id] = AC.[object_id]  "
        strSql &= "INNER JOIN sys.[types] TY ON AC.[system_type_id] = TY.[system_type_id] AND AC.[user_type_id] = TY.[user_type_id]   "
        strSql &= "WHERE (T.[is_ms_shipped] = 0)"
        strSql &= "ORDER BY T.[name], AC.[column_id]"

        'db1 all tables
        mycommand.CommandText = strSql
        Dim dt1 As DataTable = New DataTable
        PctlLib.SqlDB.LoadDataTableBySqlCommand(dt1, mycommand, oConn1)

        'db2 all tables
        mycommand = New SqlClient.SqlCommand
        mycommand.CommandText = strSql
        Dim dt2 As DataTable = New DataTable
        PctlLib.SqlDB.LoadDataTableBySqlCommand(dt2, mycommand, oConn2)

        Dim dictTb1 As New Dictionary(Of String, String)
        Dim dictTb2 As New Dictionary(Of String, String)
        Dim dictTbInBoth As New Dictionary(Of String, String)

        'compare table
        For i As Integer = 0 To dt1.Rows.Count - 1        
            If Not dictTb1.ContainsKey(dt1.Rows(i).Item("table_name").ToString) Then
                dictTb1.Add(dt1.Rows(i).Item("table_name").ToString, "")
            End If
        Next

        For i As Integer = 0 To dt2.Rows.Count - 1        
            If Not dictTb2.ContainsKey(dt2.Rows(i).Item("table_name").ToString) Then
                dictTb2.Add(dt2.Rows(i).Item("table_name").ToString, "")
            End If
        Next

        Dim sbSPError As New System.Text.StringBuilder

        sbSPError.AppendLine("Below are table in db1 but not in db2")
        sbSPError.AppendLine("")
        For Each key As String In dictTb1.Keys
            If Not dictTb2.ContainsKey(key) Then
                sbSPError.AppendLine("Table:" + key)
            Else
                dictTbInBoth.Add(key, "")
            End If
        Next

        'compare table columns
        dictTb1.Clear()
        dictTb2.Clear()

        For i As Integer = 0 To dt1.Rows.Count - 1
            If dictTbInBoth.ContainsKey(dt1.Rows(i).Item("table_name").ToString) Then
                If Not dictTb1.ContainsKey(dt1.Rows(i).Item("table_name").ToString + "." + dt1.Rows(i).Item("column_name").ToString) Then
                    dictTb1.Add(dt1.Rows(i).Item("table_name").ToString + "." + dt1.Rows(i).Item("column_name").ToString, "")
                End If
            End If         
        Next

        For i As Integer = 0 To dt2.Rows.Count - 1
            If dictTbInBoth.ContainsKey(dt2.Rows(i).Item("table_name").ToString) Then
                If Not dictTb2.ContainsKey(dt2.Rows(i).Item("table_name").ToString + "." + dt2.Rows(i).Item("column_name").ToString) Then
                    dictTb2.Add(dt2.Rows(i).Item("table_name").ToString + "." + dt2.Rows(i).Item("column_name").ToString, "")
                End If
            End If
        Next

        sbSPError.AppendLine("")
        sbSPError.AppendLine("")
        sbSPError.AppendLine("Below are column in db1 but not in db2")
        sbSPError.AppendLine("")
        For Each key As String In dictTb1.Keys
            If Not dictTb2.ContainsKey(key) Then
                sbSPError.AppendLine("Table Column:" + key)
            Else
                dictTbInBoth.Add(key, "")
            End If
        Next

        ' Return

        'compare procedure
        strSql = "SELECT "
        strSql &= "ROUTINE_NAME, "
        strSql &= "ROUTINE_TYPE, "
        strSql &= "ROUTINE_DEFINITION as First4000, "
        strSql &= "OBJECT_DEFINITION(object_id(ROUTINE_NAME)) as FullDefinition "
        strSql &= "FROM "
        strSql &= "INFORMATION_SCHEMA.ROUTINES "
        strSql &= "WHERE ROUTINE_TYPE='PROCEDURE' "
 
        strSql &= "ORDER BY "
        strSql &= "ROUTINE_NAME"

        Dim dtSp1 As DataTable = New DataTable
        mycommand = New SqlClient.SqlCommand
        mycommand.CommandText = strSql
        PctlLib.SqlDB.LoadDataTableBySqlCommand(dtSp1, mycommand, oconn1)

        Dim dtSp2 As DataTable = New DataTable
        mycommand = New SqlClient.SqlCommand
        mycommand.CommandText = strSql
        PctlLib.SqlDB.LoadDataTableBySqlCommand(dtSp2, mycommand, oConn2)

        Dim dictSp1 As New Dictionary(Of String, String)
        Dim dictSp2 As New Dictionary(Of String, String)
        For Each dr As DataRow In dtSp1.Rows
            dictSp1.Add(dr.Item("ROUTINE_NAME").ToString, dr.Item("FullDefinition").ToString)
        Next

        For Each dr As DataRow In dtSp2.Rows
            dictSp2.Add(dr.Item("ROUTINE_NAME").ToString, dr.Item("FullDefinition").ToString)
        Next

        sbSPError.AppendLine("")
        sbSPError.AppendLine("")
        sbSPError.AppendLine("Below are stored procedure not in both database:")
        sbSPError.AppendLine("")
        Dim listInBoth As New List(Of String)
        For Each key As String In dictSp1.Keys
            If Not dictSp2.ContainsKey(key) Then
                sbSPError.AppendLine("SP " + key)
            Else
                listInBoth.Add(key)
            End If
        Next

        For Each key As String In dictSp2.Keys
            If Not dictSp1.ContainsKey(key) Then
                sbSPError.AppendLine("SP " + key)
            Else

            End If
        Next


        sbSPError.AppendLine("")
        sbSPError.AppendLine("")
        sbSPError.AppendLine("Below are SP text compare not match:")
        sbSPError.AppendLine("")
        For Each spName As String In listInBoth
            CompareTwoSp(spName, dictSp1(spName), dictSp2(spName), sbSPError)
        Next

        Me.txtCompareResult.Text = sbSPError.ToString

        Return

    End Sub

    Private Sub CompareTwoSp(spName As String, spText1 As String, spText2 As String, ByRef sbSpCmpError As System.Text.StringBuilder)
        Dim sbError As New System.Text.StringBuilder
        If spText1 <> spText2 Then
            sbSpCmpError.AppendLine(spName)
        End If
    End Sub
#End Region
    Private Sub TextBoxQuery_TextChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub btnBindTextBoxCode_Click(sender As System.Object, e As System.EventArgs) Handles btnBindTextBoxCode.Click
        Dim sb1 As New System.Text.StringBuilder
        For Each s As String In Me.txtBindTextBox.Lines
            sb1.AppendLine("")
            sb1.AppendLine("With Me.txt" + s)
            sb1.AppendLine(".DataBindings.Clear()")
            sb1.AppendLine(".DataBindings.Add(" + """Text""" + ", Me.mBindingSource2.Current," + """" + s + """" + ")")
            sb1.AppendLine("End With")
        Next

        Me.txtBindTextBoxCode.Text = sb1.ToString
    End Sub

    Private Sub btnBindComboBox_Click(sender As System.Object, e As System.EventArgs) Handles btnBindComboBox.Click
        Dim sb1 As New System.Text.StringBuilder
        For Each s As String In Me.txtBindComboBox.Lines
            sb1.AppendLine("")
            sb1.AppendLine("With Me.cmb" + s)
            sb1.AppendLine(".DataBindings.Clear()")
            sb1.AppendLine(".DataBindings.Add(" + """Text""" + ", Me.mBindingSource2.Current," + """" + s + """" + ")")
            sb1.AppendLine("End With")
        Next

        Me.txtBindComboBoxCode.Text = sb1.ToString
    End Sub

    Private Sub btnBindCheckBox_Click(sender As System.Object, e As System.EventArgs) Handles btnBindCheckBox.Click
        Dim sb1 As New System.Text.StringBuilder
        For Each s As String In Me.txtBindCheckBox.Lines
            sb1.AppendLine("")
            sb1.AppendLine("With Me.chk" + s)
            sb1.AppendLine(".DataBindings.Clear()")
            sb1.AppendLine(".DataBindings.Add(" + """Checked""" + ", Me.mBindingSource2.Current," + s + ", True, DataSourceUpdateMode.OnPropertyChanged, False)")
            sb1.AppendLine("End With")
        Next

        Me.txtBindCheckBoxCode.Text = sb1.ToString
    End Sub

    Private Sub Button20_Click(sender As System.Object, e As System.EventArgs) Handles Button20.Click
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("strSql &=""", "strSql &=|")
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("""", """)")
        Me.txtNewClass.Text = Me.txtNewClass.Text.Replace("strSql &=|", "sb1.AppendLine(""")
        Return
    End Sub

    

    

    Private Function parseInput(sInput As String) As List(Of String)
        sInput = sInput.Replace("(", "")
        sInput = sInput.Replace(")", "")

        'remove <>, 
        Dim s1 As String() = sInput.Split(CChar("<"))
        Dim list1 As New List(Of String)
        For Each s As String In s1
            s = s.Replace(CChar(">"), "")
            s = s.Replace(CChar(" "), "")
            s = s.Replace(vbCrLf, "")
            list1.Add(s)
        Next

        'remove first or last empty
        For i As Integer = list1.Count - 1 To 0 Step -1
            If String.IsNullOrEmpty(list1(i)) Then
                list1.Remove(list1(i))
            End If
        Next


        For i As Integer = 0 To list1.Count - 1
            Dim s As String() = list1(i).Split(CChar(","))
            's(0) is column name,s(1) is data type
        Next


        'Me.txtClassType.Text = s1.ToString
        Return list1

    End Function

    Private Sub Button26_Click(sender As System.Object, e As System.EventArgs) Handles Button26.Click
        Me.txtClassName.Clear()
        Me.txtNewClass.Clear()
        Me.txtClassType.Clear()
    End Sub


    'Private Sub Button27_Click(sender As System.Object, e As System.EventArgs) Handles btnG01FormText.Click
    '    '##########################################################
    '    If String.IsNullOrEmpty(txtClassName.Text.Trim) Then
    '        MsgBox("")
    '    End If

    '    Dim sInput As String = txtClassName.Text.Trim

    '    Dim list1 As List(Of String) = parseInput(sInput)
    '    '##########################################################


    '    Dim sb1 As New System.Text.StringBuilder

    '    'textbox
    '    For Each s As String In list1
    '        's1(0) is column name,s1(1) is data type
    '        Dim s1 As String() = s.Split(CChar(","))
    '        sb1.AppendLine("Me.txt" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
    '    Next



    '    sb1.AppendLine("")
    '    sb1.AppendLine("")
    '    sb1.AppendLine("")
    '    sb1.AppendLine("'Below for combo box")

    '    For Each s As String In list1
    '        's1(0) is column name,s1(1) is data type
    '        Dim s1 As String() = s.Split(CChar(","))
    '        sb1.AppendLine("Me.cmb" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
    '    Next



    '    sb1.AppendLine("")
    '    sb1.AppendLine("")
    '    sb1.AppendLine("")
    '    sb1.AppendLine("'Below for check box")

    '    For Each s As String In list1
    '        's1(0) is column name,s1(1) is data type
    '        Dim s1 As String() = s.Split(CChar(","))
    '        sb1.AppendLine("Me.chk" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
    '    Next


    '    txtNewClass.Text = sb1.ToString

    'End Sub



#Region "Generate Form related controls, events"


    Private Sub btnAddControl_Click(sender As System.Object, e As System.EventArgs) Handles _
                            btnG01AddControl.Click, _
        btnG01CmbReadOnly.Click, btnG01CmdParameter.Click, _
        btnG01ControlReadOnly.Click, btnG01FormClear.Click, _
        btnG01FormText.Click, btnG01GetDataTable.Click, btnG01GetDgv.Click, _
        btnG01InsertUpdate.Click, btnG01LoadClass.Click, btnG01Validate.Click, btnG01FormText.Click, btnG01InsertUpdate.Click


        '##########################################################
        'validate input string
        If String.IsNullOrEmpty(txtClassName.Text.Trim) Then
            MsgBox("")
        End If

        Dim sInput As String = txtClassName.Text.Trim

        Dim list1 As List(Of String) = parseInput(sInput)

        'only leave column name
        For i As Integer = 0 To list1.Count - 1
            Dim s1 As String() = list1(i).Split(CChar(","))
            list1(i) = s1(0)
        Next

        'use below code to replace this form designer code
        Dim sb1 As New System.Text.StringBuilder
        '##########################################################

        Select Case CType(sender, Button).Name
            Case btnG01AddControl.Name
                _G01AddControl(sb1, list1)
            Case btnG01CmbReadOnly.Name
                _G01CmbReadOnly(sb1, list1)
            Case btnG01CmdParameter.Name
                _G01CmdParameter(sb1, list1)
            Case btnG01ControlReadOnly.Name
                _G01ControlReadOnly(sb1, list1)
            Case btnG01FormClear.Name
                _G01FormClear(sb1, list1)
            Case btnG01FormText.Name
                _G01FormText(sb1, list1)
            Case btnG01GetDataTable.Name
                _G01GetDataTable(sb1, list1)
            Case btnG01GetDgv.Name
                _G01GetDgv(sb1, list1)
            Case btnG01InsertUpdate.Name
                _G01InsertUpdate(sb1, list1)
            Case btnG01LoadClass.Name
                _G01LoadClass(sb1, list1)
            Case btnG01Validate.Name
                _G01Validate(sb1, list1)
        End Select

        Me.txtNewClass.Text = sb1.ToString
    End Sub

    Private Sub _G01AddControl(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))
        MsgBox("Replace Form1234 with your Form Name")

        sb1.AppendLine("<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _")
        sb1.AppendLine("Partial Class Form1234")
        sb1.AppendLine("Inherits System.Windows.Forms.Form")
        sb1.AppendLine("'Form overrides dispose to clean up the component list.")
        sb1.AppendLine("<System.Diagnostics.DebuggerNonUserCode()> _")
        sb1.AppendLine("Protected Overrides Sub Dispose(ByVal disposing As Boolean)")
        sb1.AppendLine("Try")
        sb1.AppendLine(" If disposing AndAlso components IsNot Nothing Then")
        sb1.AppendLine("components.Dispose()")
        sb1.AppendLine("End If")
        sb1.AppendLine("Finally")
        sb1.AppendLine("MyBase.Dispose(disposing)")
        sb1.AppendLine("End Try")
        sb1.AppendLine("End Sub")

        sb1.AppendLine("'Required by the Windows Form Designer")
        sb1.AppendLine(" Private components As System.ComponentModel.IContainer")

        sb1.AppendLine("'NOTE: The following procedure is required by the Windows Form Designer")
        sb1.AppendLine(" 'It can be modified using the Windows Form Designer. ")
        sb1.AppendLine("'Do not modify it using the code editor.")
        sb1.AppendLine(" <System.Diagnostics.DebuggerStepThrough()> _")
        sb1.AppendLine("Private Sub InitializeComponent()")

        '========================================================
        'Part1:SuspendLayout
        For Each s As String In list1
            Dim colName As String = s
            'create all control label
            sb1.AppendLine(" Me.lbl" + colName + " = New System.Windows.Forms.Label()")
            sb1.AppendLine("Me.txt" + colName + " = New System.Windows.Forms.TextBox()")

            sb1.AppendLine(" Me.lbl2" + colName + " = New System.Windows.Forms.Label()")
            sb1.AppendLine("Me.cmb" + colName + " = New System.Windows.Forms.ComboBox()")

            sb1.AppendLine(" Me.lbl3" + colName + " = New System.Windows.Forms.Label()")
            sb1.AppendLine("Me.chk" + colName + " = New System.Windows.Forms.CheckBox()")
        Next


        sb1.AppendLine("Me.SuspendLayout()")
        '========================================================

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        '========================================================
        'Part:create controls
        Dim k As Integer = 20
        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)
            'Dim colType As String = Me.DataGridView1.Rows(i).Cells("ColumnType").Value.ToString

            Dim xPos As Integer = 100
            Dim yPos As Integer = (i Mod k) * 30
            sb1.AppendLine("Me.lbl" + colName + ".AutoSize = True")
            sb1.AppendLine("Me.lbl" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")


            sb1.AppendLine("Me.lbl" + colName + ".Name = " + """lbl" + colName + """")
            sb1.AppendLine("Me.lbl" + colName + ".Size = New System.Drawing.Size(51, 17)")
            sb1.AppendLine("Me.lbl" + colName + ".TabIndex = 2")
            sb1.AppendLine("Me.lbl" + colName + ".Text = """ + colName + """")

            sb1.AppendLine("")
            sb1.AppendLine("")
            sb1.AppendLine("")

            xPos += 100
            sb1.AppendLine("Me.txt" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")
            sb1.AppendLine("Me.txt" + colName + ".Name = """ + "txt" + colName + """")
            sb1.AppendLine("Me.txt" + colName + ".Size = New System.Drawing.Size(100, 22)")
            sb1.AppendLine("Me.txt" + colName + ".TabIndex = 3")
        Next

        'combo box
        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)

            Dim xPos As Integer = 400
            Dim yPos As Integer = (i Mod k) * 30
            sb1.AppendLine("Me.lbl2" + colName + ".AutoSize = True")
            sb1.AppendLine("Me.lbl2" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")


            sb1.AppendLine("Me.lbl2" + colName + ".Name = " + """lbl2" + colName + """")
            sb1.AppendLine("Me.lbl2" + colName + ".Size = New System.Drawing.Size(51, 17)")
            sb1.AppendLine("Me.lbl2" + colName + ".TabIndex = 2")
            sb1.AppendLine("Me.lbl2" + colName + ".Text = """ + colName + """")

            sb1.AppendLine("")
            sb1.AppendLine("")
            sb1.AppendLine("")

            xPos += 100
            sb1.AppendLine("Me.cmb" + colName + ".FormattingEnabled = True")
            sb1.AppendLine("Me.cmb" + colName + ".Location =New System.Drawing.Point(" & xPos & ", " & yPos & ")") 'New System.Drawing.Point(180, 83)")
            sb1.AppendLine("Me.cmb" + colName + ".Name = """ + "cmb" + colName + """")
            sb1.AppendLine("Me.cmb" + colName + ".Size = New System.Drawing.Size(121, 24)")
            sb1.AppendLine("Me.cmb" + colName + ".TabIndex = 4")
        Next

        'check box
        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)

            Dim xPos As Integer = 800
            Dim yPos As Integer = (i Mod k) * 30
            sb1.AppendLine("Me.lbl3" + colName + ".AutoSize = True")
            sb1.AppendLine("Me.lbl3" + colName + ".Location = New System.Drawing.Point(" & xPos & ", " & yPos & ")")


            sb1.AppendLine("Me.lbl3" + colName + ".Name = " + """lbl2" + colName + """")
            sb1.AppendLine("Me.lbl3" + colName + ".Size = New System.Drawing.Size(51, 17)")
            sb1.AppendLine("Me.lbl3" + colName + ".TabIndex = 2")
            sb1.AppendLine("Me.lbl3" + colName + ".Text = """ + colName + """")

            sb1.AppendLine("")
            sb1.AppendLine("")
            sb1.AppendLine("")

            xPos += 100
            sb1.AppendLine("Me.chk" + colName + ".AutoSize = True")
            sb1.AppendLine("Me.chk" + colName + ".Location =New System.Drawing.Point(" & xPos & ", " & yPos & ")") 'New System.Drawing.Point(180, 134)")
            sb1.AppendLine("Me.chk" + colName + ".Name = """ + "chk" + colName + """")
            sb1.AppendLine("Me.chk" + colName + ".Size = New System.Drawing.Size(100, 21)")
            sb1.AppendLine("Me.chk" + colName + ".TabIndex = 5")
            sb1.AppendLine("Me.chk" + colName + ".Text = """ + colName + """")
            sb1.AppendLine("Me.chk" + colName + ".UseVisualStyleBackColor = True")
        Next


        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        '========================================================

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        '========================================================
        'Part3
        sb1.AppendLine("Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)")
        sb1.AppendLine("Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font")
        sb1.AppendLine("Me.ClientSize = New System.Drawing.Size(282, 255)")

        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)
            sb1.AppendLine("Me.Controls.Add(Me.lbl" + colName + ")")
            sb1.AppendLine("Me.Controls.Add(Me.txt" + colName + ")")
        Next

        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)
            sb1.AppendLine("Me.Controls.Add(Me.lbl2" + colName + ")")
            sb1.AppendLine("Me.Controls.Add(Me.cmb" + colName + ")")
        Next

        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)
            sb1.AppendLine("Me.Controls.Add(Me.lbl3" + colName + ")")
            sb1.AppendLine("Me.Controls.Add(Me.chk" + colName + ")")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")

        sb1.AppendLine("Me.Name = " + """" + "Form1234" + """")
        sb1.AppendLine("Me.Text = " + """" + "Form1234" + """")
        sb1.AppendLine("Me.ResumeLayout(False)")
        sb1.AppendLine("Me.PerformLayout()")
        '========================================================


        sb1.AppendLine("End Sub")

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        'Part4: with events
        For i As Integer = 0 To list1.Count - 1
            Dim colName As String = list1(i)
            sb1.AppendLine("Friend WithEvents lbl" + colName + " As System.Windows.Forms.Label")
            sb1.AppendLine("Friend WithEvents lbl2" + colName + " As System.Windows.Forms.Label")
            sb1.AppendLine("Friend WithEvents lbl3" + colName + " As System.Windows.Forms.Label")
            sb1.AppendLine("Friend WithEvents txt" + colName + " As System.Windows.Forms.TextBox")
            sb1.AppendLine("Friend WithEvents cmb" + colName + " As System.Windows.Forms.ComboBox")
            sb1.AppendLine("Friend WithEvents chk" + colName + " As System.Windows.Forms.CheckBox")
        Next

        sb1.AppendLine("End Class")
    End Sub

    Private Sub _G01FormClear(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.txt" + list1(i) + ".Clear()")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.cmb" + list1(i) + ".SelectedIndex = -1")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.chk" + list1(i) + ".Checked = False")
        Next
    End Sub

    Private Sub _G01ControlReadOnly(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.txt" + list1(i) + ".ReadOnly = boolChange")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.cmb" + list1(i) + ".Enabled = boolChange")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("Me.chk" + list1(i) + ".Enabled = boolChange")
        Next
    End Sub

    Private Sub _G01CmbReadOnly(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))

        sb1.AppendLine("Private Sub cmbRep_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _")

        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("cmb" + list1(i) + ".KeyPress, _")
        Next

        sb1.AppendLine("If Me.mstrTag = " + """" + """" + " Then")
        sb1.AppendLine("e.Handled = True")
        sb1.AppendLine("End If")

        sb1.AppendLine("End Sub")



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        sb1.AppendLine("Private Sub cmbRep_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles _")

        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("cmb" + list1(i) + ".SelectionChangeCommitted, _")
        Next

        sb1.AppendLine("If Me.mstrTag = " + """" + """" + " Then")
        sb1.AppendLine("Dim str As String = CType(sender, ComboBox).Text")
        sb1.AppendLine("CType(sender, ComboBox).SelectedIndex = -1")
        sb1.AppendLine("CType(sender, ComboBox).Text = str")
        sb1.AppendLine("End If")

        sb1.AppendLine("End Sub")
    End Sub

    Private Sub _G01GetDgv(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.txt" + s1(0) + ".text = O2Str(.Cells(" + """" + s1(0) + """" + ").Value)")
        Next



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for combo box")


        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.cmb" + s1(0) + ".text = O2Str(.Cells(" + """" + s1(0) + """" + ").Value)")
        Next



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for check box")


        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.chk" + s1(0) + ".Checked =  O2Bool(.Cells(" + """" + s1(0) + """" + ").Value)")
        Next
    End Sub

    Private Sub _G01LoadClass(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))        
        sb1.AppendLine("With MyClass")
        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("." + list1(i) + " = txt" + list1(i) + ".text")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("." + list1(i) + " = cmb" + list1(i) + ".text")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("." + list1(i) + " = cmb" + list1(i) + ".SelectedValue")
        Next




        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")

        For i As Integer = 0 To list1.Count - 1
            sb1.AppendLine("." + list1(i) + " = chk" + list1(i) + ".Checked")
        Next

        sb1.AppendLine("End With")
    End Sub

    Private Sub _G01CmdParameter(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))      
        sb1.AppendLine("With myCommand")
        sb1.AppendLine(" .CommandText = strSql")
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(".Parameters.AddWithValue(" + """" + "@" + s1(0) + """" + "," + "txt" + s1(0) + ".text.trim)")
        Next
        sb1.AppendLine("End With")


        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for combo box")
        sb1.AppendLine("With myCommand")
        sb1.AppendLine(" .CommandText = strSql")

        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(".Parameters.AddWithValue(" + """" + "@" + s1(0) + """" + "," + "cmb" + s1(0) + ".text.trim)")
        Next
        sb1.AppendLine("End With")


        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for check box")
        sb1.AppendLine("With myCommand")
        sb1.AppendLine(" .CommandText = strSql")

        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(".Parameters.AddWithValue(" + """" + "@" + s1(0) + """" + "," + "chk" + s1(0) + ".text.trim)")
        Next
        sb1.AppendLine("End With")
    End Sub

    Private Sub _G01GetDataTable(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))     
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.txt" + s1(0) + ".text = .Item(" + """" + s1(0) + """" + ")")
        Next

        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for combo box")


        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.cmb" + s1(0) + ".text = .Item(" + """" + s1(0) + """" + ")")
        Next



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for check box")


        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.chk" + s1(0) + ".text = .Item(" + """" + s1(0) + """" + ")")
        Next
    End Sub

    Private Sub _G01Validate(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))     
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))

            sb1.AppendLine("If String.IsNullOrEmpty(txt" + s1(0) + ".Text.Trim) Then")
            sb1.AppendLine("MsgBox(" + """" + s1(0) + " is required.""" + ", MsgBoxStyle.Critical, " + """Missing information""" + ")")
            sb1.AppendLine("Me.txt" + s1(0) + ".Focus()")
            sb1.AppendLine("Return")
            sb1.AppendLine("End If")
        Next

        'Combo Box
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))

            sb1.AppendLine("If String.IsNullOrEmpty(cmb" + s1(0) + ".Text.Trim) Then")
            sb1.AppendLine("MsgBox(" + """" + s1(0) + " is required.""" + ", MsgBoxStyle.Critical, " + """Missing information""" + ")")
            sb1.AppendLine("Me.cmb" + s1(0) + ".Focus()")
            sb1.AppendLine("Return")
            sb1.AppendLine("End If")
        Next

        'check box
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))

            sb1.AppendLine("If String.IsNullOrEmpty(txt" + s1(0) + ".Text.Trim) Then")
            sb1.AppendLine("MsgBox(" + """" + s1(0) + " is required.""" + ", MsgBoxStyle.Critical, " + """Missing information""" + ")")
            sb1.AppendLine("Me.txt" + s1(0) + ".Focus()")
            sb1.AppendLine("Return")
            sb1.AppendLine("End If")
        Next
    End Sub

    Private Sub _G01FormText(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))       
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.txt" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
        Next



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for combo box")

        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.cmb" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
        Next



        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("")
        sb1.AppendLine("'Below for check box")

        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine("Me.chk" + s1(0) + ".text=OReader(" + """" + s1(0) + """" + ")")
        Next
    End Sub

    Private Sub _G01InsertUpdate(ByRef sb1 As System.Text.StringBuilder, list1 As List(Of String))
        
        Dim prefix As String = "sb1.AppendLine(" + """"
        Dim suffix As String = """" + ")"
        sb1.AppendLine(prefix + "IF NOT EXISTS (SELECT 1 FROM tableName WHERE key=@key) " + suffix)
        sb1.AppendLine(prefix + "BEGIN " + suffix)

        sb1.AppendLine(prefix + "INSERT INTO tablename " + suffix)
        sb1.AppendLine(prefix + "(" + suffix)
        'textbox
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(prefix + "[" + s1(0) + "]," + suffix)
        Next
        sb1.AppendLine(prefix + ") " + suffix)

        sb1.AppendLine(prefix + "VALUES " + suffix)
        sb1.AppendLine(prefix + "(" + suffix)
        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(prefix + "@" + s1(0) + "," + suffix)
        Next
        sb1.AppendLine(prefix + ") " + suffix)

        sb1.AppendLine(prefix + "END " + suffix)

        sb1.AppendLine(prefix + "ELSE " + suffix)

        sb1.AppendLine(prefix + "BEGIN " + suffix)
        sb1.AppendLine(prefix + "UPDATE tablename " + suffix)
        sb1.AppendLine(prefix + "SET " + suffix)

        For Each s As String In list1
            's1(0) is column name,s1(1) is data type
            Dim s1 As String() = s.Split(CChar(","))
            sb1.AppendLine(prefix + s1(0) + " = @" + s1(0) + "," + suffix)
        Next

        sb1.AppendLine(prefix + "WHERE key=@key " + suffix)
        sb1.AppendLine(prefix + "END " + suffix)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sb1 As New System.Text.StringBuilder
        Dim str1 As String =
            "
  Private Shared Function _EpicorToSofi_PkgBinAndAllocBin(customerId As Integer,
                                            mid1 As Integer,
                                           ByRef ds As DataSet, oConn As SqlConnection, Optional ByRef errorMsg As String = Nothing) As Boolean
                 
        'DataSet ds each table bind or set value,create insert string by table column
        Dim myTrans As SqlTransaction = Nothing
        Dim myCommand As New SqlCommand

       
  
        Try
            oConn.Open()
            myTrans = oConn.BeginTransaction()
            myCommand.Connection = oConn
            myCommand.Transaction = myTrans

            'set key to each table
            
            'Insert each table to database
            myCommand.CommandText = ""
            myCommand.Parameters.Clear()
            MyDll.DataTableDB.InsertDatatable(myCommand, ds.Tables(0), errorMsg, True)

            myCommand.CommandText = ""
            myCommand.Parameters.Clear()
            MyDll.DataTableDB.InsertDatatable(myCommand, ds.Tables(1), errorMsg, True)

            '//if need identity backup
            'myCommand.CommandText = 'SELECT SCOPE_IDENTITY()'
            'myCommand.Parameters.Clear() 
            'key=myCommand.ExecuteScalar

             

            myTrans.Commit()
            'Return True
        Catch ex As SqlException
            myTrans.Rollback()
            If Not IsNothing(errorMsg) Then
                errorMsg = ex.Message.ToString
            End If
            Return False
        Catch ex As Exception
            myTrans.Rollback()
            If Not IsNothing(errorMsg) Then
                errorMsg = ex.Message.ToString
            End If
            Return False
        Finally
            oConn.Close()
            myCommand.Dispose()
            myTrans = Nothing
        End Try

        Return True
    End Function

"
        Me.txtSaveForm.Text = str1
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim formName As String = Me.txtFormName4.Text.Trim
        If String.IsNullOrEmpty(formName) Then
            MsgBox("Form Name missed.")
            Me.txtFormName4.Focus()
            Return
        End If

        Dim sb1 As New System.Text.StringBuilder

        'form active event
        sb1.AppendLine(
            "
             Private Sub " + formName + "_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
               'form activated 
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
                    LoadDS()
                Catch ex As Exception

                End Try
            End Sub
            ")

        'Show dataset
        sb1.AppendLine(
            "
             Private Sub LoadDS()
                
            End Sub
            ")

        'Show Form
        sb1.AppendLine(
            "
             Private Sub ShowForm()
                
            End Sub
            ")



        Me.txtSaveForm.Text = sb1.ToString

    End Sub

#End Region
    'like me.txtItemID.text=O2Str(me.dgvProduct.SelectedRow(0).Cells("ItemID").Value)
End Class
