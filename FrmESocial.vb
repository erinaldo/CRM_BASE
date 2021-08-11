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

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmESocial_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        VerificaServidor()

    End Sub

    Dim Chave As String

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

        LogResurltadoEsocial.LblResult.Text = DtProdutos.SelectedCells(15).Value
        LogResurltadoEsocial.Show(Me)

    End Sub

    Dim RefreshConsulta As Integer = (5)

    Private Sub VerificaServidor()

        Dim Lst_Marca_delete As New ListBox

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        For Each row As DataGridViewRow In DtProdutos.Rows
            If row.Cells(0).Value = 1 Then

                'carrega certificado

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaCertificado = From cert In LqBase.BASE_CERTIFICADO
                                       Where cert.SERIAL_CERT Like "*"
                                       Select cert.RAZAO, cert.SERIAL_CERT

                If BuscaCertificado.Count > 0 Then

                    'lista todos os certificados e compara com o numero serial

                    GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

                    For Each item_c In GetCerificateX509.Certificates

                        If item_c.SerialNumber = (BuscaCertificado.First.SERIAL_CERT) Then

                            Dim Certificado As X509Certificate2
                            Certificado = item_c
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

                            'cria XML

                            'transmite doc

                            Dim myBinding = New BasicHttpsBinding()
                            myBinding.Security.Mode = SecurityMode.Transport
                            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

                            Dim settings As New XmlReaderSettings()

                            AddHandler settings.ValidationEventHandler, AddressOf Me.ValidationEventHandler

                            Dim Client As ServicoConsultarLoteEventos = New ServicoConsultarLoteEventos(myBinding)

                            Client.ClientCertificates.Add(Certificado)

                            'executa leitura e validação

                            Dim Arquivo_ASSR As String = row.Cells(11).Value

                            Try

                                Dim doc As XmlDocument = New XmlDocument()
                                doc.PreserveWhitespace = False
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

                                                        For Each item3 As XmlElement In item2.ChildNodes

                                                            For Each item4 As XmlElement In item3.ChildNodes

                                                                For Each item5 As XmlElement In item4.ChildNodes

                                                                    If item5.Name = "processamento" Then

                                                                        Dim Result_cons As String = ""

                                                                        For Each item6 As XmlElement In item5.ChildNodes

                                                                            If item6.Name = "cdResposta" Then
                                                                                Result_cons = item6.InnerText & " - "
                                                                            End If

                                                                            If item6.Name = "descResposta" Then

                                                                                Result_cons &= item6.InnerText

                                                                                row.Cells(14).Value = Result_cons
                                                                                row.Cells(9).Value = ImageList1.Images(3)
                                                                                row.Cells(10).Value = ImageList1.Images(3)

                                                                            End If

                                                                        Next

                                                                    End If

                                                                Next

                                                            Next

                                                        Next

                                                        'MsgBox(jsonR)

                                                    End If

                                                Next

                                            Next

                                        End If

                                    Next

                                Next

                                row.Cells(15).Value = json
                                row.Cells(0).Value = 2
                                'atualiza recibo

                                LqTrabalhista.atualizaStatusReciboEsocial(row.Cells(16).Value, json)

                                Lst_Marca_delete.Items.Add(row.Index)

                            Catch ex As Exception

                                If ex.Message.StartsWith("Não foi possível localizar o arquivo") Then
                                    row.Cells(14).Value = "Arquivo não encontrado"
                                ElseIf ex.Message.StartsWith("O documento enviado não é") Then
                                    row.Cells(14).Value = "Documento inválido"
                                End If
                                row.Cells(9).Value = ImageList1.Images(1)
                                row.Cells(10).Value = ImageList1.Images(1)
                                row.Cells(0).Value = 2

                                LqTrabalhista.atualizaStatusReciboEsocial(row.Cells(16).Value, ex.Message)

                                Lst_Marca_delete.Items.Add(row.Index)

                            End Try

                            'Process.Start(Arquivo_ASS)

                        End If

                    Next

                End If

            End If

        Next

        For i As Integer = 0 To Lst_Marca_delete.Items.Count - 1
            DtProdutos.Rows.RemoveAt(Lst_Marca_delete.Items(i).ToString)
        Next

        'apaga as duas listas

        DtProdutos.Rows.Clear()
        DtTransacoesconcluidas.Rows.Clear()

        Dim BuscaTrab = From trab In LqTrabalhista.ESocial
                        Where trab.IdESocial Like "*"
                        Select trab.Protocolo, trab.Arquivo, trab.Status, trab.IdColaborador, trab.IdCliente, trab.HoraResposta, trab.DataResposta, trab.HoraSolicitacao, trab.DataSolicitacao, trab.Evento, trab.IdESocial, trab.IDEVENTO, trab.Recibo

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

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaCliente = From cliente In LqBase.Clientes
                                   Where cliente.IdCliente = rw.IdCliente
                                   Select cliente.Apelido

                If rw.Status = 1 Then
                    'verifica resposta do servidor

                    Try

                        DtProdutos.Rows.Add(rw.Status, rw.IdESocial, _DocColaborador, BuscaCliente.First & " - " & _NomeColaborador, rw.Evento, FormatDateTime(rw.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(rw.HoraSolicitacao.ToString, DateFormat.ShortTime), DtFinal, HrFinal, ImageList1.Images(1), ImageList1.Images(0), rw.Arquivo, rw.IdESocial, rw.Protocolo, Stt, "", rw.IDEVENTO)

                        VerificaServidor()

                    Catch ex As Exception

                        Stt = ex.Message

                    End Try

                ElseIf rw.Status = 2 Then

                    DtTransacoesconcluidas.Rows.Add(rw.Status, rw.IdESocial, _DocColaborador, BuscaCliente.First & " - " & _NomeColaborador, rw.Evento, FormatDateTime(rw.DataSolicitacao, DateFormat.ShortDate), FormatDateTime(rw.HoraSolicitacao.ToString, DateFormat.ShortTime), DtFinal, HrFinal, ImageList1.Images(3), ImageList1.Images(3), rw.Arquivo, rw.IdESocial, rw.Protocolo, Stt, rw.Recibo, rw.IDEVENTO)

                End If

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

    Private Sub DtTransacoesconcluidas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtTransacoesconcluidas.CellContentClick

    End Sub

    Private Sub DtTransacoesconcluidas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtTransacoesconcluidas.CellDoubleClick

        LogResurltadoEsocial.LblResult.Text = DtTransacoesconcluidas.SelectedCells(15).Value
        LogResurltadoEsocial.Show(Me)

    End Sub
End Class

