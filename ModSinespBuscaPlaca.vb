Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks
Imports System.Xml

Namespace ModSinespBuscaPlaca
    Public Class DebitosVeiculo
        Public Property codigoRetorno As String
        Public Property mensagemRetorno As String
        Public Property codigoSituacao As String
        Public Property situacao As String
        Public Property modelo As String
        Public Property marca As String
        Public Property cor As String
        Public Property ano As String
        Public Property anoModelo As String
        Public Property chassi As String
        Public Property uf As String
        Public Property municipio As String
    End Class

    Public Class ConsultarPlaca2
        Private secret As String = "#8.1.0#0KnlVSWHxOih3zKXBWlo"
        Private url As String = "https://cidadao.sinesp.gov.br/sinesp-cidadao/mobile/consultar-placa/v5"
        Private proxy As String = Nothing
        Private placa As String = ""
        Private response As String = ""
        Private dados As Array
        Private cookies As CookieContainer

        Private Function RemoverAcentos(ByVal texto As String) As String
            Dim s As String = texto.Normalize(NormalizationForm.FormD)
            Dim sb As StringBuilder = New StringBuilder()

            For k As Integer = 0 To s.Length - 1
                Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(s(k))

                If uc <> UnicodeCategory.NonSpacingMark Then
                    sb.Append(s(k))
                End If
            Next

            Return sb.ToString()
        End Function

        Private Function ByteToString(ByVal buff As Byte()) As String
            Dim sbinary As String = ""

            For i As Integer = 0 To buff.Length - 1
                sbinary += buff(i).ToString("X2")
            Next

            Return (sbinary)
        End Function

        Public Function ConsultarPlaca(ByVal placa As String) As String
            Dim document As XmlDocument = New XmlDocument()
            Dim doc As XmlDocument = New XmlDocument()

            Try
                Dim nErros As Integer = 0
                Dim urlpost As Uri = New Uri(url)
                Dim httpPostConsulta As HttpWebRequest = CType(HttpWebRequest.Create(urlpost), HttpWebRequest)
                Dim key As String = placa & secret
                Dim encoding As System.Text.ASCIIEncoding = New System.Text.ASCIIEncoding()
                Dim keyByte As Byte() = encoding.GetBytes(key)
                Dim hmacsha1 As HMACSHA1 = New HMACSHA1(keyByte)
                Dim messageBytes As Byte() = encoding.GetBytes(placa)
                Dim hashmessage As Byte() = hmacsha1.ComputeHash(messageBytes)
                Dim hmac2 As String = ByteToString(hashmessage).ToLower()
                Dim postConsultaComParametros As StringBuilder = New StringBuilder()
                postConsultaComParametros.Append("<v:Envelope xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns:d='http://www.w3.org/2001/XMLSchema' xmlns:c='http://schemas.xmlsoap.org/soap/encoding/' xmlns:v='http://schemas.xmlsoap.org/soap/envelope/'>")
                postConsultaComParametros.Append("<v:Header>                                                                  ")
                postConsultaComParametros.Append("<b>Google Android SDK built for x86</b>                                                     ")
                postConsultaComParametros.Append("<c>ANDROID</c>                                                              ")
                postConsultaComParametros.Append("<d>8.1.0</d>                                                                ")
                postConsultaComParametros.Append("<e>4.3.2</e>                                                                ")
                postConsultaComParametros.Append("<f>10.0.2.15</f>                                                             ")
                postConsultaComParametros.Append("<g>" & hmac2 & "</g>                                                                   ")
                postConsultaComParametros.Append("<h>0.0</h>                                                                   ")
                postConsultaComParametros.Append("<i>0.0</i>                                                                   ")
                postConsultaComParametros.Append("<k></k>                                                                     ")
                postConsultaComParametros.Append("<l>" & String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) & "</l>")
                postConsultaComParametros.Append("<m>8797e74f0d6eb7b1ff3dc114d4aa12d3</m>                                     ")
                postConsultaComParametros.Append("</v:Header>                                                                 ")
                postConsultaComParametros.Append("<v:Body>                                                                    ")
                postConsultaComParametros.Append("<n0:getStatus xmlns:n0='http://soap.ws.placa.service.sinesp.serpro.gov.br/'>")
                postConsultaComParametros.Append("<a>" & placa & "</a>")
                postConsultaComParametros.Append("</n0:getStatus>")
                postConsultaComParametros.Append("</v:Body>")
                postConsultaComParametros.Append("</v:Envelope>")
                Dim data = encoding.ASCII.GetBytes(postConsultaComParametros.ToString())
                httpPostConsulta.Method = "POST"
                httpPostConsulta.ContentType = "text/xml;charset=utf-8"
                httpPostConsulta.ContentLength = data.Length
                httpPostConsulta.KeepAlive = False
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                ServicePointManager.ServerCertificateValidationCallback = Function() True

                Using stream = httpPostConsulta.GetRequestStream()
                    stream.Write(data, 0, data.Length)
                End Using

                Dim response = CType(httpPostConsulta.GetResponse(), HttpWebResponse)
                Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
                Return responseString.ToString()
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

            Return ""
        End Function

        Private Shared Function longitude() As Double
            Dim rng As Random = New Random()
            Dim random As Integer = rng.[Next](100000, 999999)
            Return -3.7R - random / 1000000000.0R
        End Function

        Private Shared Function latitude() As Double
            Dim rng As Random = New Random()
            Dim random As Integer = rng.[Next](100000, 999999)
            Return -38.5R - random / 1000000000.0R
        End Function
    End Class
End Namespace
