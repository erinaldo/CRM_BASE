Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization.Json
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class ClasseValidaLogin
    Public Shared Function VerificaLogin(User As String, Pass As String, Doc As String) As ClasseLogin

        Dim baseUrl As String = "http://www.iarasoftware.com.br/login_net_new.php?User=" & User & "&Pass=" & Pass & "&Doc=" & Doc

        Try
            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            'Dim arquivoJson = JObject.Parse(content)

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(ClasseLogin))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), ClasseLogin)
                Dim read = JsonConvert.DeserializeObject(Of List(Of ClasseLogin))(content)
                'MsgBox(read.Item(0).ChaveOficina)

                Return weatherData
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
