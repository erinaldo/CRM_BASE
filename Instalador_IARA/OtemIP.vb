Imports System.Net.Dns

Public Class ObteIP

    Shared Function ObtemEnderecoIP() As String


        Dim oEndereco As System.Net.IPAddress

        Dim sEndereco As String

        With GetHostByName(GetHostName)

            oEndereco = New System.Net.IPAddress(.AddressList(0).Address)

            sEndereco = oEndereco.ToString

        End With

        ObtemEnderecoIP = sEndereco

    End Function

End Class
