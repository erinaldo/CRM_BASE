Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.ServiceModel
Imports CRM_BASE.WebReference
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class FrmESocial

    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub AssinarDocumentoXML(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String)

        'Try

        'assina com o certificado selecionados

        ObjCertificadoX509 = objColecaoCertificadosX509.Item(0)

        Dim DocXML As New XmlDocument()

        DocXML.PreserveWhitespace = False
        DocXML.Load(ArqXmlAssinar)

        Dim signedXml As New Xml.SignedXml(DocXML)

        signedXml.SigningKey = ObjCertificadoX509.PrivateKey

        Dim Referencia As New Xml.Reference()
        Referencia.Uri = TagXml

        Dim env As New XmlDsigEnvelopedSignatureTransform

        Referencia.AddTransform(env)

        Dim c14 As New XmlDsigC14NTransform

        Referencia.AddTransform(c14)

        signedXml.AddReference(Referencia)

        Dim KeyInfo As New KeyInfo

        KeyInfo.AddClause(New KeyInfoX509Data(ObjCertificadoX509))

        signedXml.KeyInfo = KeyInfo

        Try

            signedXml.ComputeSignature()

            Dim XmlDigitalSignature As XmlElement
            XmlDigitalSignature = signedXml.GetXml()

            DocXML.DocumentElement.AppendChild(DocXML.ImportNode(XmlDigitalSignature, True))

            Dim EscreverXML As New StreamWriter(ArqXmlAssinar)
            EscreverXML.Write(DocXML.OuterXml)
            EscreverXML.Close()

            If DocXML.GetElementsByTagName(TagXml).Count = 1 Then
                'MsgBox("Existe")
            End If

            Process.Start("C:\Iara\ESocial\" & Chave & ".xml")

        Catch ex As Exception

            MsgBox("Certificado não suportado!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro de certificado")

        End Try


        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub SelecionarCertificado(ByVal ArqXmlAssinar As String)

        'Try

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
"Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

        If objColecaoCertificadosX509.Count > 0 Then

            AssinarDocumentoXML(ArqXmlAssinar, "Signature", objColecaoCertificadosX509.Item(0).SerialNumber.ToString)

        End If

        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub FrmESocial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrab = From trab In LqTrabalhista.ESocial
                        Where trab.IdESocial Like "*"
                        Select trab.Arquivo, trab.Status, trab.IdColaborador, trab.IdCliente, trab.HoraResposta, trab.DataResposta, trab.HoraSolicitacao, trab.DataSolicitacao, trab.Evento, trab.IdESocial

        For Each rw In BuscaTrab.ToList

            Dim DtFinal As String = FormatDateTime(rw.DataResposta, DateFormat.ShortDate)
            Dim HrFinal As String = FormatDateTime(rw.HoraResposta.ToString, DateFormat.ShortTime)

            If DtFinal.StartsWith("11/11/1111") Then
                DtFinal = ""
                HrFinal = ""
            End If

            Dim BuscaColaborador = From col In LqTrabalhista.ColaboradoresCliente
                                   Where col.IdColaboradorCliente = rw.IdColaborador
                                   Select col.NomeColaborador, col.DocColaborador

            Dim _NomeColaborador As String = ""
            Dim _DocColaborador As String = ""

            If BuscaColaborador.Count > 0 Then

                _NomeColaborador = BuscaColaborador.First.NomeColaborador
                _DocColaborador = BuscaColaborador.First.DocColaborador

            End If

            DtProdutos.Rows.Add(rw.Status, rw.IdESocial, _NomeColaborador, _DocColaborador, rw.Evento, FormatDateTime(rw.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(rw.HoraSolicitacao.ToString, DateFormat.ShortTime), DtFinal, HrFinal, ImageList1.Images(1), ImageList1.Images(0), rw.Arquivo)

        Next

    End Sub

    Dim Chave As String
    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick



    End Sub

    Private Sub DtProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellDoubleClick

        ArqStr = DtProdutos.SelectedCells(11).Value
        TaskOfTResult_MethodAsync()

    End Sub

    Dim ArqStr As String = ""

    Async Function TaskOfTResult_MethodAsync() As Task(Of String)

        Dim Certificado As X509Certificate2
        Certificado = objColecaoCertificadosX509.Item(0)
        Dim Key As RSA = Certificado.GetRSAPrivateKey

        Dim myBinding = New BasicHttpsBinding()
        myBinding.Security.Mode = SecurityMode.Transport
        myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

        Dim Client As ServicoEnviarLoteEventos = New ServicoEnviarLoteEventos(myBinding)

        Client.ClientCertificates.Add(Certificado)

        Dim doc As XmlDocument = New XmlDocument()
        doc.Load(New XmlTextReader(ArqStr))

        Dim result As String = Await Client.EnviarLoteEventosAsync(doc.DocumentElement)
        Dim json As String = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented, New JsonSerializerSettings With {
.ContractResolver = New CamelCasePropertyNamesContractResolver()})

        Return json

    End Function

End Class


