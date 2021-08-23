Imports System.Net


Public Class Class1
    'Public Shared Function GetAllIP(Optional ByVal args As String() = Nothing) As Collection


    '    Dim strHostName As New String(CType("", Char()))
    '    Dim col As New Collection
    '    ' Getting Ip address of local machine...        
    '    ' First get the host name of local machine.     
    '    strHostName = Dns.GetHostName()
    '    Console.WriteLine("Local Machine's Host Name: " + strHostName)
    '    ' Then using host name, get the IP address list..      
    '    Dim ipEntry As IPHostEntry = Dns.GetHostEntry(strHostName)
    '    Dim addr As IPAddress() = ipEntry.AddressList



    '    Dim i As Integer = 0
    '    While i < addr.Length


    '        col.Add(addr(i).ToString())
    '        Console.WriteLine("IP Address {0}: {1} ", i, addr(i).ToString())
    '        i += 1
    '    End While
    '    Return col
    'End Function

    Public Shared Function GetAllIP(Optional ByVal args As String() = Nothing) As Integer
        'args in the signature is optional, without it
        'the function will simply get the hostname
        'of the local machine then go from there
        Dim strHostName As New String(CType("", Char()))
        If args.Length = 0 Then
            ' Getting Ip address of local machine...
            ' First get the host name of local machine.
            strHostName = DNS.GetHostName()
            Console.WriteLine("Local Machine's Host Name: " + strHostName)
        Else
            strHostName = args(0)
        End If

        ' Then using host name, get the IP address list..
        Dim ipEntry As IPHostEntry = DNS.GetHostByName(strHostName)
        Dim addr As IPAddress() = ipEntry.AddressList

        Dim i As Integer = 0
        While i < addr.Length
            Console.WriteLine("IP Address {0}: {1} ", i, addr(i).ToString())
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return 0
    End Function


    Public Shared Function LoadDataTableByOledbCommand(ByVal myDataTable As DataTable, _
                                      ByVal oledbCommand As OleDb.OleDbCommand, _
                                      ByVal oledbConn As OleDb.OleDbConnection) As Boolean
        If IsNothing(myDataTable) Then
            Return False
        ElseIf IsNothing(oledbCommand) Then
            Return False
        ElseIf IsNothing(oledbConn) Then
            Return False
        End If

        Dim dataAdapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter

        With oledbCommand
            .Connection = oledbConn
        End With

        Try
            oledbConn.Open()
            dataAdapter.SelectCommand = oledbCommand

            ' Populate a new data table and bind it to the BindingSource.
            myDataTable.Locale = System.Globalization.CultureInfo.InvariantCulture
            dataAdapter.Fill(myDataTable)

            Return True
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            Return False
        Finally
            'Close connection       
            oledbConn.Close()
            dataAdapter = Nothing
            oledbCommand = Nothing
        End Try
    End Function

End Class
