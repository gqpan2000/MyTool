Module ModMain
    Public gUseVPN As Boolean
    'Set up a public connection function
    Public Function GetUTGUSConnection() As SqlClient.SqlConnection
        Try
            Dim myconnection As New SqlClient.SqlConnection
            Dim connectionString As String = ""
            connectionString = "MultipleActiveResultSets=True;"
            connectionString &= "Data Source=192.168.1.3\SQLEXPRESS;"
            connectionString &= "Initial Catalog=utg_pro;"
            connectionString &= "User Id=bob;"
            connectionString &= "Password=0318"
            myconnection.ConnectionString = connectionString

            Return myconnection
        Catch ex As SqlClient.SqlException
            MsgBox("The server you try to connect may not available,connect you network admin")
            Return Nothing
            'Finally
        End Try
    End Function

    Public Function GetSOFIConnection() As SqlClient.SqlConnection
        Try
            Dim myconnection As New SqlClient.SqlConnection
            Dim connectionString As String = ""
            connectionString = "MultipleActiveResultSets=True;"
            connectionString &= "Data Source=192.168.1.3\SQLEXPRESS;"
            connectionString &= "Initial Catalog=utg_pro_test;"
            connectionString &= "User Id=bob;"
            connectionString &= "Password=0318"
            myconnection.ConnectionString = connectionString

            Return myconnection
        Catch ex As SqlClient.SqlException
            MsgBox("The server you try to connect may not available,connect you network admin")
            Return Nothing
            'Finally
        End Try
    End Function

    Public Function GetUTGNTConnection() As SqlClient.SqlConnection
        Try
            Dim myconnection As New SqlClient.SqlConnection
            Dim connectionString As String = ""
            connectionString = "MultipleActiveResultSets=True;"

            If gUseVPN Then
                connectionString &= "Data Source=192.168.2.3\SQLEXPRESS;"
            Else
                connectionString &= "Data Source=122.193.249.70,1433\SQLEXPRESS;"
            End If

            connectionString &= "Initial Catalog=Utg_NT;"
            connectionString &= "User Id=bob;"
            connectionString &= "Password=0318"
            myconnection.ConnectionString = connectionString

            Return myconnection
        Catch ex As SqlClient.SqlException
            MsgBox("The server you try to connect may not available,connect you network admin")
            Return Nothing
            'Finally
        End Try
    End Function

    Private Function MyAccessConnectString() As String
        Dim connectionString As String

        connectionString = ""
        connectionString &= "Provider=Microsoft.Jet.OLEDB.4.0;"
        connectionString &= "Data Source=\\leapers-master\data\AppData\BIS\LeapersBIS_be.mdb"

        MyAccessConnectString = connectionString

        ''连接到C:\Leapers_BIS\LeapersBIS_FE.mde，如果BIS is open,conflict
        'connectionString = "Provider=Microsoft.Jet.OLEDB.4.0" & _
        ' ";Data Source=C:\Leapers_BIS\OFF2007\LeapersBIS_FE.mde"
    End Function

    '***********************新的BIS连接*******************************************
    '
    '
    'C:\Leapers_BIS\LeapersBIS_FE.mde是BIS专用连接，如果BIS已经打开了，这个文件就不能再次打开，不共享；
    '将这个文件复制到更目录C:\LeapersBIS_FE.mde，不与BIS冲突

    '连接到C:\LeapersBIS_FE.mde

    Public Function GetBISConnection() As OleDb.OleDbConnection
        Try
            Dim connectionString As String
            connectionString = MyAccessConnectString()

            Dim MyAccessConnection As New OleDb.OleDbConnection(connectionString)
            Return MyAccessConnection
        Catch ex As OleDb.OleDbException
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function
End Module
