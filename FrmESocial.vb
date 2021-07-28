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
Imports System.Xml.Schema
Imports CRM_BASE.ConsultaLote
Imports CRM_BASE.ConsultaResultProt

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

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
"Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrab = From trab In LqTrabalhista.ESocial
                        Where trab.IdESocial Like "*"
                        Select trab.Protocolo, trab.Arquivo, trab.Status, trab.IdColaborador, trab.IdCliente, trab.HoraResposta, trab.DataResposta, trab.HoraSolicitacao, trab.DataSolicitacao, trab.Evento, trab.IdESocial

        For Each rw In BuscaTrab.ToList

            If rw.Protocolo <> "" Then
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

                Dim Stt As String

                If rw.Status = 1 Then

                    If objColecaoCertificadosX509.Count > 0 Then
                        'verifica resposta do servidor

                        Try

                            DtProdutos.Rows.Add(rw.Status, rw.IdESocial, _DocColaborador, _NomeColaborador, rw.Evento, FormatDateTime(rw.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(rw.HoraSolicitacao.ToString, DateFormat.ShortTime), DtFinal, HrFinal, ImageList1.Images(1), ImageList1.Images(0), rw.Arquivo, rw.IdESocial, rw.Protocolo, Stt)

                            VerificaServidor()

                        Catch ex As Exception

                            Stt = ex.Message

                        End Try
                    End If

                End If


            End If

        Next

    End Sub

    Dim Chave As String
    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick



    End Sub
    Private isValid As Boolean = True
    Public Sub MyValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)
        isValid = False
        Console.WriteLine("Validation event" & vbCrLf & args.Message)
    End Sub

    Public Sub ValidationEventHandler(ByVal sender As Object, ByVal args As ValidationEventArgs)

        If args.Severity = XmlSeverityType.Warning Then

            MsgBox("Nenhum arquivo de Schema foi encontrado para efetuar a validação...")

        ElseIf args.Severity = XmlSeverityType.Error Then

            MsgBox("Ocorreu um erro durante a validação....")

        End If

        If Not (args.Exception Is Nothing) Then ' Erro na validação do schema XSD

            MsgBox(args.Exception.SourceUri + "," & args.Exception.LinePosition & "," & args.Exception.LineNumber)

        End If

    End Sub
    Private Sub DtProdutos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellDoubleClick

        LogResurltadoEsocial.LblResult.Text = DtProdutos.SelectedCells(14).Value
        LogResurltadoEsocial.Show(Me)


    End Sub

    Dim RefreshConsulta As Integer = (30)

    Private Sub VerificaServidor()
        For Each row As DataGridViewRow In DtProdutos.Rows
            If row.Cells(0).Value = 1 Then

                Dim Certificado As X509Certificate2
                Certificado = objColecaoCertificadosX509.Item(0)
                Dim Key As RSA = Certificado.GetRSAPrivateKey

                'declara o xml de envio de consulta

                Dim Mes As Integer = Today.Month
                Dim MStr As String = Mes
                If Mes < 10 Then

                    MStr = "0" & Mes

                End If

                Dim Dia As Integer = Today.Day
                Dim DStr As String = Dia

                If Dia < 10 Then

                    DStr = "0" & Dia

                End If

                Dim Hora As Integer = Now.Hour
                Dim HrStr As String = Hora

                If Hora < 10 Then

                    HrStr = "0" & Hora

                End If

                Dim Minuto As Integer = Now.Minute
                Dim MinStr As String = Minuto

                If Minuto < 10 Then

                    MinStr = "0" & Minuto

                End If

                Dim Segundo As Integer = Now.Second
                Dim SgStr As String = Segundo

                If Segundo < 10 Then

                    SgStr = "0" & Segundo

                End If

                Dim ArquivoStrRes As String = "C:\Iara\ESocial\Consulta\" & row.Cells(12).Value & Today.Year & MStr & DStr & HrStr & MinStr & SgStr & Now.TimeOfDay.Milliseconds & ".xml"
                Dim ArquivoStrIniRes As String = "C:\Iara\ESocial\Consulta\Signed" & row.Cells(12).Value & MStr & DStr & HrStr & MinStr & SgStr & Now.TimeOfDay.Milliseconds & ".xml"
                Dim Arquivo_ASSRes As String = "C:\Iara\ESocial\Consulta\ID" & row.Cells(12).Value & MStr & DStr & HrStr & MinStr & SgStr & Now.TimeOfDay.Milliseconds & ".xml"

                'cria XML
                Dim writer As New XmlTextWriter(ArquivoStrRes, Encoding.UTF8)

                writer.WriteStartDocument()

                writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/lote/eventos/envio/consulta/retornoProcessamento/v1_0_0")
                writer.WriteStartElement("consultaLoteEventos")
                writer.WriteElementString("protocoloEnvio", row.Cells(13).Value)

                writer.WriteEndElement()
                writer.WriteEndElement()

                writer.Close()

                'SignVerify.SignVerifyEnvelope.CreateSomeXml(ArquivoStrIni)

                'SignVerify.SignVerifyEnvelope.SignXmlFile(ArquivoStrRes, Arquivo_ASSRes, Key)

                'transmite doc

                Dim myBinding = New BasicHttpsBinding()
                myBinding.Security.Mode = SecurityMode.Transport
                myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

                Dim settings As New XmlReaderSettings()

                AddHandler settings.ValidationEventHandler, AddressOf Me.ValidationEventHandler

                Dim Client As ServicoConsultarLoteEventos = New ServicoConsultarLoteEventos(myBinding)

                Client.ClientCertificates.Add(Certificado)

                'executa leitura e validação

                Dim doc As XmlDocument = New XmlDocument()

                Dim Arquivo_ASSR As String = ArquivoStrRes
                doc.Load(New XmlTextReader(Arquivo_ASSR))

                Dim result = Client.ConsultarLoteEventos(doc.DocumentElement)

                Dim json As String = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented, New JsonSerializerSettings With {
                .ContractResolver = New CamelCasePropertyNamesContractResolver()})


                Dim reader As XmlElement = (result)
                Dim elementos As ArrayList = New ArrayList

                Dim ResultadoConsulta As String = ""

                For Each item In reader.ChildNodes

                    'le os childs
                    For Each item0 As XmlElement In item.ChildNodes

                        If item0.Name = "retornoEventos" Then

                            For Each item1 As XmlElement In item0.ChildNodes

                                For Each item2 As XmlElement In item1.ChildNodes

                                    If item2.Name = "retornoEvento" Then

                                        Dim jsonR As String = JsonConvert.SerializeObject(item2, Newtonsoft.Json.Formatting.Indented, New JsonSerializerSettings With {
                .ContractResolver = New CamelCasePropertyNamesContractResolver()})

                                        row.Cells(14).Value = jsonR

                                        'MsgBox(jsonR)

                                    End If

                                Next

                            Next

                        End If

                    Next

                Next


                'Process.Start(Arquivo_ASS)

            End If


        Next
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If RefreshConsulta = 0 Then

            VerificaServidor()

            RefreshConsulta = 30

        Else

            RefreshConsulta -= 1

        End If
    End Sub
End Class

