Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.ServiceModel
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema
Imports CRM_BASE.WebReference
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class Frm2220
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public LstDoc As New ListBox
    Public LStDoColab As New ListBox
    Public LstMatricula As New ListBox
    Public LstGrupoTrab As New ListBox
    Public LstIdColaborador As New ListBox
    Public LstIDCliente As New ListBox
    Public LstTipoCodTrab As New ListBox
    Public LstNumTipoTrab As New ListBox

    Private Sub BttTransmitirCAT_Click(sender As Object, e As EventArgs) Handles BttTransmitirCAT.Click

        'monta arquivo xml

        Dim Persona As String = "2 - CPF"
        Dim PersonaSel As Integer = 2

        If CmbTodosClientes.Text <> "" Then
            If LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Length = 14 Then
                Persona = "2"
                PersonaSel = 2
            Else
                Persona = "1"
                PersonaSel = 1
            End If
        Else
            Persona = "0"
            PersonaSel = 0
        End If

        Dim Doc As String = "000000"

        If PersonaSel = 2 Then

            Doc = "000000" & LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "")

        Else

            'verifica os inicios

            Dim Valid As String = LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "")

            Doc = Valid

            If Valid.StartsWith("1015") Or Valid.StartsWith("1040") Or Valid.StartsWith("1074") Or Valid.StartsWith("1163") Then

                Doc = LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "")

            ElseIf Not Valid.StartsWith("1015") And Not Valid.StartsWith("1040") And Not Valid.StartsWith("1074") And Not Valid.StartsWith("1163") Then

                Doc = LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "")

            ElseIf Not Valid.StartsWith("1015") And Not Valid.StartsWith("1040") And Not Valid.StartsWith("1074") And Not Valid.StartsWith("1163") Then

                Doc = "000000" & LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "").ToCharArray(0, 8)

            End If

        End If

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

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim IdSocial As String = HrStr.Remove(0, 1) & MinStr & SgStr

        If IdSocial.ToString.Length = 1 Then

            IdSocial = "0000" & IdSocial

        ElseIf IdSocial.ToString.Length = 2 Then

            IdSocial = "000" & IdSocial

        ElseIf IdSocial.ToString.Length = 3 Then

            IdSocial = "00" & IdSocial

        ElseIf IdSocial.ToString.Length = 4 Then

            IdSocial = "0" & IdSocial

        End If

        Dim Identificacao As String = "ID" & PersonaSel & Doc & Today.Year & MStr & DStr & HrStr & MinStr & SgStr & IdSocial

        'cria documento xml
        Dim writer As New XmlTextWriter("C:\Iara\ESocial\Eventos\" & Identificacao & ".xml", Encoding.UTF8)

        'replace 
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;
        Text.Replace(">", "&gt").Replace("<", "&lt").Replace("&", "&amp").Replace("""", "&quot").Replace("'", "&apos")
        'inicia o documento xml

        writer.WriteStartDocument()

        'escreve o elmento raiz

        writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/evt/evtMonit/v_S_01_00_00")

        'inicia evtCAT

        writer.WriteStartElement("evtMonit")
        writer.WriteAttributeString("Id", Identificacao)

        'inicia ideEvento

        writer.WriteStartElement("ideEvento")
        writer.WriteElementString("indRetif", "1")

        writer.WriteElementString("tpAmb", "2")
        writer.WriteElementString("procEmi", "1")
        writer.WriteElementString("verProc", My.Application.Info.Version.ToString)

        'encerra ideEvento

        writer.WriteEndElement()

        'inicia ideEmpregador

        writer.WriteStartElement("ideEmpregador")
        writer.WriteElementString("tpInsc", Persona)
        writer.WriteElementString("nrInsc", Doc)

        'encerra ideEmpregador

        writer.WriteEndElement()

        'inicia ideEmpregador

        writer.WriteStartElement("ideVinculo")
        writer.WriteElementString("cpfTrab", LStDoColab.Items(CmbColaboradores.SelectedIndex).ToString.Replace(".", "").Replace("-", ""))

        If LstMatricula.Items(CmbColaboradores.SelectedIndex).ToString <> "" Then
            writer.WriteElementString("matricula", LstMatricula.Items(CmbColaboradores.SelectedIndex).ToString)
        Else
            Dim CatTrab As String = LstGrupoTrab.Items(CmbColaboradores.SelectedIndex).ToString

            If CatTrab <> 901 And CatTrab <> 903 And CatTrab <> 904 Then
                writer.WriteElementString("nisTrab", LstNumTipoTrab.Items(CmbColaboradores.SelectedIndex).ToString.Replace(".", "").Replace("-", ""))
            End If

            writer.WriteElementString("codCateg", LstGrupoTrab.Items(CmbColaboradores.SelectedIndex).ToString)
        End If

        'encerra ideEmpregador

        writer.WriteEndElement()

        '

        writer.WriteStartElement("exMedOcup")
        writer.WriteElementString("tpExameOcup", CmbTipoDoExame.SelectedItem.ToString.ToCharArray(0, 1))

        writer.WriteStartElement("aso")

        Dim Apto As String = 1

        If CkValidadoApto.Checked = True Then
            Apto = 2
        End If

        Dim _Data_Aso As Date = Today.Date

        Dim _D_Mes_Aso As Integer = _Data_Aso.Month
        Dim _D_MStr_Aso As String = _D_Mes_Aso
        If _D_Mes_Aso < 10 Then

            _D_MStr_Aso = "0" & _D_Mes_Aso

        End If

        Dim _D_Dia_Aso As Integer = _Data_Aso.Day
        Dim _D_DStr_Aso As String = _D_Dia_Aso
        If _D_Dia_Aso < 10 Then

            _D_DStr_Aso = "0" & _D_Dia_Aso

        End If
        writer.WriteElementString("dtAso", _Data_Aso.Year & "-" & _D_MStr_Aso & "-" & _D_DStr_Aso)

        writer.WriteElementString("resAso", Apto)

        writer.WriteStartElement("exame")

        Dim _Data As Date = DtExame.Value

        Dim _D_Mes As Integer = _Data.Month
        Dim _D_MStr As String = _D_Mes
        If _D_Mes < 10 Then

            _D_MStr = "0" & _D_Mes

        End If

        Dim _D_Dia As Integer = _Data.Day
        Dim _D_DStr As String = _D_Dia

        If _D_Dia < 10 Then

            _D_DStr = "0" & _D_Dia

        End If

        writer.WriteElementString("dtExm", DtExame.Value.Year & "-" & _D_MStr & "-" & _D_DStr)
        writer.WriteElementString("procRealizado", TxtCodProcedimento.Text)

        If TxtObs.Text <> "" Then
            writer.WriteElementString("obsProc", TxtObs.Text)
        End If

        writer.WriteElementString("ordExame", Inicial)
        writer.WriteElementString("indResult", Indicacao)

        writer.WriteEndElement()
        writer.WriteStartElement("medico")
        writer.WriteElementString("nmMed", TxtNomeMedico.Text)
        writer.WriteElementString("nrCRM", TxtNumDocumento.Text)
        writer.WriteElementString("ufCRM", CmbEstadoEmitente.Text)

        writer.WriteEndElement()
        writer.WriteEndElement()

        writer.WriteStartElement("respMonit")
        writer.WriteElementString("cpfResp", TxtCPFMedico.Text)
        writer.WriteElementString("nmResp", TxtNomeMedico.Text)
        writer.WriteElementString("nrCRM", TxtNumDocumento.Text)
        writer.WriteElementString("ufCRM", CmbEstadoEmitente.Text)

        writer.Close()

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCertificado = From cert In LqBase.BASE_CERTIFICADO
                               Where cert.SERIAL_CERT Like "*"
                               Select cert.RAZAO, cert.SERIAL_CERT

        If BuscaCertificado.Count > 0 Then

            For Each item_c In GetCerificateX509.Certificates

                If item_c.SerialNumber = (BuscaCertificado.First.SERIAL_CERT) Then

                    SignVerify.SignVerifyEnvelope.SignXmlFile("C:\Iara\ESocial\Eventos\" & Identificacao & ".xml", "C:\Iara\ESocial\Eventos\Signed" & Identificacao & ".xml", item_c, Identificacao, "S2220")
                    criaEventoEnviaLote("C:\Iara\ESocial\Eventos\Signed" & Identificacao & ".xml", Identificacao, Doc, Today.Year, MStr, DStr, HrStr, MinStr, SgStr)

                End If

            Next

        End If

        'Process.Start("C:\Iara\ESocial\Eventos\" & Identificacao & ".xml")

    End Sub
    Private Sub criaEventoEnviaLote(FileName As String, IDENTIFICACAO As String, CNPJ As String, AAAA As String, MM As String, DD As String, HH As String, MM_ As String, SS As String)

        Try


            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaCertificado = From cert In LqBase.BASE_CERTIFICADO
                                   Where cert.SERIAL_CERT Like "*"
                                   Select cert.RAZAO, cert.SERIAL_CERT

            If BuscaCertificado.Count > 0 Then

                For Each item_c In GetCerificateX509.Certificates

                    If item_c.SerialNumber = (BuscaCertificado.First.SERIAL_CERT) Then


                        'replace 
                        ''> (sinal de maior) &gt; 
                        ''< (sinal de menor) &lt; 
                        ''& (e comercial) &amp;
                        ''> (sinal de maior) &gt; 
                        ''< (sinal de menor) &lt; 
                        ''& (e comercial) &amp;
                        Text.Replace(">", "&gt").Replace("<", "&lt").Replace("&", "&amp").Replace("""", "&quot").Replace("'", "&apos")
                        'inicia o documento xml

                        Dim PERSONA As Integer

                        If CNPJ.Length > 11 Then
                            PERSONA = 1
                        Else
                            PERSONA = 2
                        End If

                        'carrega xml do lote
                        Dim doc As XmlDocument = New XmlDocument()
                        doc.PreserveWhitespace = False
                        doc.Load(New XmlTextReader(FileName))

                        'Carrega XML

                        Dim xmltw As XmlTextWriter = New XmlTextWriter("C:\Iara\ESocial\Lotes\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml", New UTF8Encoding(True))

                        xmltw.WriteStartDocument()
                        xmltw.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1")

                        xmltw.WriteStartElement("envioLoteEventos")
                        xmltw.WriteAttributeString("grupo", 2)

                        xmltw.WriteStartElement("ideEmpregador")
                        xmltw.WriteElementString("tpInsc", PERSONA)
                        xmltw.WriteElementString("nrInsc", CNPJ)

                        xmltw.WriteEndElement()

                        xmltw.WriteStartElement("ideTransmissor")

                        xmltw.WriteElementString("tpInsc", "1")
                        xmltw.WriteElementString("nrInsc", FrmPrincipal.CNPJ.Replace(".", "").Replace("/", "").Replace("-", ""))

                        xmltw.WriteEndElement()

                        xmltw.WriteStartElement("eventos")

                        xmltw.WriteStartElement("evento")
                        xmltw.WriteAttributeString("Id", IDENTIFICACAO)

                        doc.WriteTo(xmltw)
                        xmltw.Close()

                        'envia evento para o servidor Serpro

                        Dim myBinding = New BasicHttpsBinding()
                        myBinding.Security.Mode = SecurityMode.Transport
                        myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

                        'rotina para teste -- apagar

                        'cria documento xml

                        Dim settings As New XmlReaderSettings()

                        AddHandler settings.ValidationEventHandler, AddressOf Me.ValidationEventHandler

                        'ecerra arquivo de test

                        Dim Client As ServicoEnviarLoteEventos = New ServicoEnviarLoteEventos(myBinding)

                        Client.ClientCertificates.Add(item_c)

                        Dim LqTrabalhista As New LqTrabalhistaDataContext
                        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                        LqTrabalhista.InsereESocial(LstIDCliente.Items(CmbTodosClientes.SelectedIndex).ToString, LstIdColaborador.Items(CmbColaboradores.SelectedIndex).ToString _
                                    , "S-2220", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, "C:\Iara\ESocial\Lotes\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml", IDENTIFICACAO, "", "", 0)

                        Dim docLote As XmlDocument = New XmlDocument()
                        docLote.Load(New XmlTextReader("C:\Iara\ESocial\Lotes\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml"))

                        'Process.Start(Arquivo_ASS)

                        Try

                            Dim result = Client.EnviarLoteEventos(docLote.DocumentElement)
                            Dim json As String = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented, New JsonSerializerSettings With {
            .ContractResolver = New CamelCasePropertyNamesContractResolver()})

                            Dim reader As XmlElement = (result)
                            Dim elementos As ArrayList = New ArrayList
                            Dim ResultadoConsulta As String = ""
                            Dim Cod As Integer

                            For Each res As XmlNode In result.ChildNodes
                                For Each res_0 As XmlNode In res.ChildNodes

                                    If res_0.Name = "status" Then

                                        For Each res_1 As XmlNode In res_0.ChildNodes

                                            If res_1.Name = "cdResposta" Then
                                                Cod = res_1.InnerText
                                            End If

                                        Next

                                    ElseIf res_0.Name = "dadosRecepcaoLote" Then

                                        For Each res_1 As XmlNode In res_0.ChildNodes

                                            If Cod = 201 Then

                                                If res_1.Name = "protocoloEnvio" Then
                                                    ResultadoConsulta = res_1.InnerText
                                                End If

                                            End If

                                        Next


                                    End If

                                Next

                            Next

                            Dim Erro As String = json

                            If ResultadoConsulta <> "" Then

                                If MsgBox("Evento transmitido com sucesso!", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Sucesso!") = MsgBoxResult.Ok Then

                                    'atualiza protocolo
                                    Dim writer As New XmlTextWriter("C:\Iara\ESocial\Consultas\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml", Encoding.UTF8)

                                    writer.WriteStartDocument()

                                    writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/lote/eventos/envio/consulta/retornoProcessamento/v1_0_0")
                                    writer.WriteStartElement("consultaLoteEventos")
                                    writer.WriteElementString("protocoloEnvio", ResultadoConsulta)

                                    writer.WriteEndElement()
                                    writer.WriteEndElement()

                                    writer.Close()

                                    LqTrabalhista.AtualizaProtocoloESocial(IDENTIFICACAO, ResultadoConsulta, "C:\Iara\ESocial\Consultas\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml")

                                    FrmESocial.Show(FrmPrincipal)

                                    Me.Close()

                                End If

                            Else

                                MsgBox("Não foi possível ler o protocolo de retorno do evento :(" & Chr(13) & Erro, MsgBoxStyle.OkOnly)

                            End If

                        Catch ex As Exception

                            MsgBox(ex.Message & ex.StackTrace)

                        End Try

                        'salva xml do lote de envio

                        'Process.Start("C:\Iara\ESocial\Lotes\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml")

                    End If

                Next

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub
    Private Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)
        Throw New NotImplementedException()
    End Sub

    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Public LstTabela27 As New ListBox

    Private Sub Frm2220_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca clientes

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaClientes = From cli In LqBase.Clientes
                            Where cli.IdCliente Like "*"
                            Select cli.CPF_CNPJ, cli.RazaoSocial_nome, cli.IdCliente

        For Each row In BuscaClientes.ToList
            LstDoc.Items.Add(row.CPF_CNPJ)
            CmbTodosClientes.Items.Add(row.RazaoSocial_nome)
            LstIDCliente.Items.Add(row.IdCliente)
        Next

        'busca tabela 27
        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTabela = From tab In LqTrabalhista.Tabela27
                          Where tab.Codigo Like "*"
                          Select tab.Codigo, tab.Descricao

        LstTabela27.Items.Clear()
        CmbTabela27.Items.Clear()

        For Each row In BuscaTabela.ToList

            LstTabela27.Items.Add(row.Codigo.Replace(vbCrLf, ""))
            CmbTabela27.Items.Add(row.Descricao)

        Next

    End Sub

    Private Sub TxtDodCliente_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDodCliente.MaskInputRejected

    End Sub

    Private Sub TxtDodCliente_TextChanged(sender As Object, e As EventArgs) Handles TxtDodCliente.TextChanged

        If TxtDodCliente.Text.Length < 12 Then

            TxtDodCliente.Mask = "000,000,000-000"
            CmbTodosClientes.Text = ""

        Else

            TxtDodCliente.Mask = "00,000,000/0000-00"

        End If

        If TxtDodCliente.Text.Length = 11 Or TxtDodCliente.Text.Length = 14 Then
            'procura qual indice selecionar
            For i As Integer = 0 To LstDoc.Items.Count - 1
                If LstDoc.Items(i).ToString.Replace(".", "").Replace("-", "").Replace("/", "") = TxtDodCliente.Text Then
                    CmbTodosClientes.SelectedIndex = i
                End If
            Next

        Else

            CmbTodosClientes.Text = ""

        End If

    End Sub

    Private Sub TxtDocColaborador_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDocColaborador.MaskInputRejected

    End Sub

    Private Sub TxtDocColaborador_TextChanged(sender As Object, e As EventArgs) Handles TxtDocColaborador.TextChanged

        If TxtDocColaborador.Text.Length < 11 Then

            TxtDocColaborador.Mask = "000,000,000-00"
            CmbColaboradores.Text = ""

        End If

        If TxtDocColaborador.Text.Length = 11 Then
            'procura qual indice selecionar
            For i As Integer = 0 To LStDoColab.Items.Count - 1
                If LStDoColab.Items(i).ToString.Replace(".", "").Replace("-", "") = TxtDocColaborador.Text Then
                    CmbColaboradores.SelectedIndex = i
                End If
            Next

        Else

            CmbColaboradores.Text = ""

        End If

    End Sub

    Private Sub CmbColaboradores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbColaboradores.SelectedIndexChanged

        If CmbColaboradores.Items.Contains(CmbColaboradores.Text) Then

            CmbColaboradores.BackColor = Color.White
            TxtDocColaborador.Text = LStDoColab.Items(CmbColaboradores.SelectedIndex).ToString.Replace(".", "").Replace("-", "")
            ImgValColab.BackgroundImage = My.Resources.check_ok

            TabControl1.Enabled = True

        Else

            TabControl1.Enabled = False

        End If

    End Sub

    Private Sub CmbTodosClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTodosClientes.SelectedIndexChanged

        If CmbTodosClientes.Items.Contains(CmbTodosClientes.Text) Then

            TxtDodCliente.Text = LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "").ToCharArray(0, 14)
            TxtDodCliente.Text &= LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "").ToCharArray(12, 2)
            ImgValCliente.BackgroundImage = My.Resources.check_ok

            CmbTodosClientes.BackColor = Color.White
            TxtDocColaborador.Enabled = True

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdCliente As Integer = LstIDCliente.Items(CmbTodosClientes.SelectedIndex).ToString

            LStDoColab.Items.Clear()
            CmbColaboradores.Items.Clear()
            LstIdColaborador.Items.Clear()
            LstTipoCodTrab.Items.Clear()
            LstNumTipoTrab.Items.Clear()

            For Each row In LqTrabalhista.Seleciona_COLABORADORES(IdCliente).ToList

                LStDoColab.Items.Add(row.DocColaborador)
                CmbColaboradores.Items.Add(row.NomeColaborador)
                LstIdColaborador.Items.Add(row.IdColaboradorCliente)

                Dim TipoDocCatTrab As Integer
                If row.TipoDocCatTrab = 0 Then
                    TipoDocCatTrab = 0
                Else
                    TipoDocCatTrab = row.TipoDocCatTrab
                End If

                LstTipoCodTrab.Items.Add(TipoDocCatTrab)

                Dim NumTipoTrab As String
                If row.NumDocCatTrab = "" Then
                    NumTipoTrab = ""
                Else
                    NumTipoTrab = row.NumDocCatTrab
                End If

                LstNumTipoTrab.Items.Add(NumTipoTrab)

                If row.GrupoTrab = "" Then
                    LstMatricula.Items.Add(row.CatTrab)
                    LstGrupoTrab.Items.Add("")
                Else
                    LstGrupoTrab.Items.Add(row.CatTrab.ToCharArray(0, 3))
                    LstMatricula.Items.Add("")
                End If
            Next

            If CmbColaboradores.Items.Count > 0 Then

                CmbColaboradores.Enabled = True

            Else

                CmbColaboradores.Text = ""
                CmbColaboradores.Enabled = False

            End If

        End If

    End Sub

    Private Sub CmbTipoDoExame_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoDoExame.SelectedIndexChanged

        If CmbTipoDoExame.Items.Contains(CmbTipoDoExame.Text) Then

            ImgValInfo.BackgroundImage = My.Resources.check_ok
            DtExame.Enabled = True
            TxtCodProcedimento.Enabled = True
            BtnBuscaProcedimento.Enabled = True
            CkValidadoApto.Enabled = True

        Else

            ImgValInfo.BackgroundImage = My.Resources.alertar_obg

            TxtCodProcedimento.Enabled = False
            TxtCodProcedimento.Text = ""
            BtnBuscaProcedimento.Enabled = False
            CkValidadoApto.Enabled = False
            CkValidadoApto.Checked = False

            DtExame.Value = Today.Date
            DtExame.Enabled = False

        End If

    End Sub

    Private Sub TxtCodProcedimento_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProcedimento.TextChanged

        'busca na lista de situação geradora

        Dim DescricaoSitGera As String

        Dim Success As Boolean = False

        For i As Integer = 0 To LstTabela27.Items.Count - 1 Step 1

            If LstTabela27.Items(i).ToString = (TxtCodProcedimento.Text) Then
                Success = True
                DescricaoSitGera = CmbTabela27.Items(i).ToString
                LblProcedimento.Text = DescricaoSitGera
                ImgValTabela27.BackgroundImage = My.Resources.check_ok

                TxtObs.Enabled = True
                'carrega proxima lista

                RdbInicial.Enabled = True
                RdbSequencial.Enabled = True

            End If

        Next

        If Success = False Then

            LblProcedimento.Text = ""
            ImgValTabela27.BackgroundImage = My.Resources.alertar_obg

            TxtObs.Enabled = False

            RdbInicial.Enabled = False
            RdbSequencial.Enabled = False
            RdbInicial.Checked = False
            RdbSequencial.Checked = False

        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBuscaProcedimento.Click

        FrmTabela27.Show(Me)

    End Sub

    Dim Inicial As Integer
    Private Sub SelecionaInicial()

        If RdbInicial.Checked = True Then

            RdbNormal.Enabled = True
            RdbAlterado.Enabled = True
            RdbEstavel.Enabled = True
            RdbAgravamento.Enabled = True
            Inicial = 1

        Else

            RdbNormal.Enabled = True
            RdbAlterado.Enabled = True
            RdbEstavel.Enabled = True
            RdbAgravamento.Enabled = True
            Inicial = 2

        End If

    End Sub
    Private Sub RdbInicial_CheckedChanged(sender As Object, e As EventArgs) Handles RdbInicial.CheckedChanged
        SelecionaInicial()
    End Sub

    Private Sub RdbSequencial_CheckedChanged(sender As Object, e As EventArgs) Handles RdbSequencial.CheckedChanged
        SelecionaInicial()
    End Sub

    Dim Indicacao As Integer

    Private Sub SelecionaIndicacao()

        If RdbNormal.Checked = True Then

            TabControl1.SelectedIndex = 1

            Indicacao = 1

            TxtCPFMedico.Enabled = True
            TxtCPFMedico.Focus()

        ElseIf RdbAlterado.Checked = True Then

            TabControl1.SelectedIndex = 1

            Indicacao = 2

            TxtCPFMedico.Enabled = True
            TxtCPFMedico.Focus()

        ElseIf RdbEstavel.Checked = True Then

            TabControl1.SelectedIndex = 1

            Indicacao = 3

            TxtCPFMedico.Enabled = True
            TxtCPFMedico.Focus()

        ElseIf RdbEstavel.Checked = True Then

            TabControl1.SelectedIndex = 1

            Indicacao = 4

            TxtCPFMedico.Enabled = True
            TxtCPFMedico.Focus()

        End If

    End Sub

    Private Sub RdbNormal_CheckedChanged(sender As Object, e As EventArgs) Handles RdbNormal.CheckedChanged
        SelecionaIndicacao()
    End Sub

    Private Sub RdbAlterado_CheckedChanged(sender As Object, e As EventArgs) Handles RdbAlterado.CheckedChanged
        SelecionaIndicacao()
    End Sub

    Private Sub RdbEstavel_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEstavel.CheckedChanged
        SelecionaIndicacao()
    End Sub

    Private Sub RdbAgravamento_CheckedChanged(sender As Object, e As EventArgs) Handles RdbAgravamento.CheckedChanged
        SelecionaIndicacao()
    End Sub

    Private Sub TxtCPFMedico_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPFMedico.MaskInputRejected

    End Sub

    Private Sub TxtCPFMedico_TextChanged(sender As Object, e As EventArgs) Handles TxtCPFMedico.TextChanged

        If TxtCPFMedico.Text.Length = 11 Then

            ImgValCPF.BackgroundImage = My.Resources.check_ok
            TxtNomeMedico.Enabled = True
            TxtNomeMedico.Focus()

        Else

            ImgValCPF.BackgroundImage = My.Resources.alertar_obg
            TxtNomeMedico.Enabled = False
            TxtNomeMedico.Text = ""

        End If

    End Sub

    Private Sub TxtNumDocumento_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNumDocumento.MaskInputRejected

    End Sub

    Private Sub TxtNumDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtNumDocumento.TextChanged

        If TxtNumDocumento.Text.Length = TxtNumDocumento.Mask.Replace(",", "").Replace("-", "").Replace("/", "").Length Then


            Dim baseUrlImagemUsuario As String = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/"

            'carrega informações no site

            Try

                ' Chamada sincrona
                Dim syncClientImagemUsuario = New WebClient()
                Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

                Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.UFEMIT))(contentImagemUsuario)

                CmbEstadoEmitente.Items.Clear()

                For Each i In readImagemUsuario.ToList

                    CmbEstadoEmitente.Items.Add(i.sigla)

                Next

            Catch ex As Exception

                CmbEstadoEmitente.Items.Add("SP")

            End Try

            CmbEstadoEmitente.Enabled = True
            ImgvalNumDocMedico.BackgroundImage = My.Resources.check_ok
            CmbEstadoEmitente.Focus()

        Else

            CmbEstadoEmitente.Text = ""
            CmbEstadoEmitente.Enabled = False
            ImgvalNumDocMedico.BackgroundImage = My.Resources.alertar_obg

        End If

    End Sub

    Private Sub CmbEstadoEmitente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstadoEmitente.SelectedIndexChanged

        If CmbEstadoEmitente.Items.Contains(CmbEstadoEmitente.Text) Then

            CmbEstadoEmitente.BackColor = Color.White
            BttTransmitirCAT.Enabled = True
            ImgValEstadoEmitente.BackgroundImage = My.Resources.check_ok

        Else

            CmbEstadoEmitente.BackColor = Color.MistyRose
            BttTransmitirCAT.Enabled = False
            ImgValEstadoEmitente.BackgroundImage = My.Resources.alertar_obg

        End If

    End Sub

    Private Sub TxtNomeMedico_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeMedico.TextChanged

        If TxtNomeMedico.Text <> "" Then

            ImgValNome.BackgroundImage = My.Resources.check_ok
            TxtNumDocumento.Enabled = True

        Else

            ImgValNome.BackgroundImage = My.Resources.alertar_obg
            TxtNumDocumento.Enabled = False
            TxtNumDocumento.Text = ""

        End If

    End Sub
End Class