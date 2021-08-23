Public Class Form2

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
         

        Dim ip As String = "192.168.1."
        Dim str As New List(Of String)
        Dim lastd As Integer = 0
        For i As Integer = 0 To 254
            lastd += 1
            Dim ip1 As String = ip & lastd.ToString
            'ip &= lastd.ToString
            If My.Computer.Network.Ping(ip1) Then
                'MsgBox("success")
                Me.Label1.Text = ip1
                'Application.DoEvents()
                str.Add(ip1)
            Else
                Me.Text = ip1
                Application.DoEvents()
            End If
        Next
        'If My.Computer.Network.Ping("192.168.0.152") Then
        '    MsgBox("success")
        'Else
        '    MsgBox("no reply")
        'End If
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim hostname As String = System.Net.Dns.GetHostName()
        'MessageBox.Show(hostname)
        ''Dim ips As Net.IPAddress() = Net.Dns.GetHostAddresses(Net.Dns.GetHostName())
        ''Dim Imyipaddlist As Net.IPHostEntry = Net.Dns.GetHostByName(hostname)
        ''For Each ips As Net.IPAddress In myipaddlist.AddressList

        ''Next

        ''MessageBox.Show(ipa.ToString())
        'Class1.GetAllIP()

    End Sub
End Class