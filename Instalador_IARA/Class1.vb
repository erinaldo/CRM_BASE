Public Class ObtemIP
    Public Function BuscaIP(ip As String)
        Dim myHost As String = System.Net.Dns.GetHostName
        Dim myIPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(myHost)

        For Each myIP As System.Net.IPAddress In myIPs.AddressList

            ip = myIP.ToString
        Next
        MsgBox(ip)

        Return ip
    End Function

End Class
