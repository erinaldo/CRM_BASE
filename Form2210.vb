Imports System.IO
Imports System.Net
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml
Imports System.ServiceModel
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Xml.Schema
Imports Newtonsoft.Json

Public Class Form2210
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub BttColaboradores_Click(sender As Object, e As EventArgs) Handles BttColaboradores.Click

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

                Doc = "000000" & LstDoc.Items(CmbTodosClientes.SelectedIndex).ToString.Replace(".", "").Replace("-", "").Replace("/", "").ToCharArray(0, 8)

            End If

        End If

        Dim Mes As Integer = Today.Month

        If Mes.ToString.Length = 1 Then

            Mes = "0" & Mes

        End If

        Dim Dia As Integer = Today.Day

        If Dia.ToString.Length = 1 Then

            Dia = "0" & Dia

        End If

        Dim Hora As Integer = Now.Hour

        If Hora.ToString.Length = 1 Then

            Hora = "0" & Hora

        End If

        Dim Minuto As Integer = Now.Minute

        If Minuto.ToString.Length = 1 Then

            Minuto = "0" & Minuto

        End If

        Dim Segundo As Integer = Now.Second

        If Segundo.ToString.Length = 1 Then

            Segundo = "0" & Segundo

        End If

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim IdSocial As String

        If LqTrabalhista.ESocial.ToList.Count > 0 Then

            IdSocial = LqTrabalhista.ESocial.ToList.Last.IdESocial

        Else

            IdSocial = "1"

        End If

        If IdSocial.ToString.Length = 1 Then

            IdSocial = "0000" & IdSocial

        ElseIf IdSocial.ToString.Length = 2 Then

            IdSocial = "000" & IdSocial

        ElseIf IdSocial.ToString.Length = 3 Then

            IdSocial = "00" & IdSocial

        ElseIf IdSocial.ToString.Length = 4 Then

            IdSocial = "0" & IdSocial

        End If

        Dim Identificacao As String = "ID" & PersonaSel & Doc & Today.Year & Mes & Dia & Hora & Minuto & Segundo & IdSocial

        'cria documento xml
        Dim writer As New XmlTextWriter("C:\Iara\ESocial\" & IdSocial & ".xml", Encoding.UTF8)

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

        writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1")

        'inicia evtCAT

        writer.WriteStartElement("evtCAT")
        writer.WriteElementString("Id", Identificacao)

        'inicia ideEvento

        writer.WriteStartElement("ideEvento")
        writer.WriteElementString("indRetif", "1")
        writer.WriteElementString("nrRecibo", "")
        writer.WriteElementString("tpAmb", "8")
        writer.WriteElementString("procEmi", "1")
        writer.WriteElementString("verProc", "1.0.0")

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
        writer.WriteElementString("matricula", LstMatricula.Items(CmbColaboradores.SelectedIndex).ToString)
        writer.WriteElementString("codCateg", LstGrupoTrab.Items(CmbColaboradores.SelectedIndex).ToString)

        'encerra ideEmpregador

        writer.WriteEndElement()

        'inicia cat

        Dim _dtAcid As Date = DtAcidente.Value

        Dim _ANO As String = _dtAcid.Year
        Dim _MES As String = _dtAcid.Month
        If _MES.Length < 2 Then
            _MES = "0" & _dtAcid.Month
        End If
        Dim _DIA As String = _dtAcid.Day
        If _DIA.Length < 2 Then
            _DIA = "0" & _dtAcid.Day
        End If

        Dim tpAcid As Integer
        If RdbTipico.Checked = True Then
            tpAcid = 1
        ElseIf RdbDoenca.Checked = True Then
            tpAcid = 2
        ElseIf RdbTrajeto.Checked = True Then
            tpAcid = 3
        End If

        Dim HorasAntesTrab As Date = Today.Date & " 00:00:00"

        If RdbTipico.Checked = True Or RdbTrajeto.Checked = True Then

            Dim HorasInicioExp As Date = Today.Date & " " & TxtInicioExp.Text.ToCharArray(0, 2) & ":" & TxtInicioExp.Text.ToCharArray(2, 2)
            Dim HoraAcidente As Date = Today.Date & " " & TxtHoraAcid.Text.ToCharArray(0, 2) & ":" & TxtInicioExp.Text.ToCharArray(2, 2)

            While HorasInicioExp < HoraAcidente

                HorasAntesTrab = HorasAntesTrab.AddMinutes(1)
                HorasInicioExp = HorasInicioExp.AddMinutes(1)

            End While

        End If

        writer.WriteStartElement("cat")
        writer.WriteElementString("dtAcid", _ANO & _MES & _DIA)
        writer.WriteElementString("tpAcid", tpAcid)
        If HorasAntesTrab.TimeOfDay.ToString <> "00:00:00" Then
            writer.WriteElementString("hrsTrabAntesAcid", HorasAntesTrab.TimeOfDay.ToString.ToCharArray(0, 5).ToString.Replace(":", ""))
        Else
            writer.WriteElementString("hrsTrabAntesAcid", "")
        End If

        Dim Obito As Integer = 1
        Dim H_Obito As String = "N"

        If CkObito.Checked = True Then
            Obito = 3
            H_Obito = "S"
        End If

        writer.WriteElementString("tpCat", Obito)
        writer.WriteElementString("indCatObito", H_Obito)

        'inicia cat

        Dim _dtobito As Date = DtObito.Value

        Dim _ANO_obt As String = _dtobito.Year
        Dim _MES_obt As String = _dtobito.Month
        If _MES_obt.Length < 2 Then
            _MES_obt = "0" & _dtobito.Month
        End If
        Dim _DIA_obt As String = _dtobito.Day
        If _DIA_obt.Length < 2 Then
            _DIA_obt = "0" & _dtobito.Day
        End If

        If CkObito.Checked = True Then
            writer.WriteElementString("dtObito", _ANO_obt & _MES_obt & _DIA_obt)
        Else
            writer.WriteElementString("dtObito", "")
        End If

        Dim Ocorrencia As String = "N"

        If CkObito.Checked = True Then
            Ocorrencia = "S"
        End If

        writer.WriteElementString("indComunPolicia", Ocorrencia)

        writer.WriteElementString("codSitGeradora", CodTabela_15_16.Items(CmbSituacaoGeradora.SelectedIndex).ToString)

        Dim iniciatCAT As Integer
        If RdbEmpregador.Checked = True Then
            iniciatCAT = 1
        ElseIf RdbOrdemJud.Checked = True Then
            iniciatCAT = 2
        ElseIf RdbFiscalizador.Checked = True Then
            iniciatCAT = 3
        End If

        writer.WriteElementString("iniciatCAT", iniciatCAT)
        writer.WriteElementString("obsCAT", TxtObservacao.Text)

        writer.WriteStartElement("localAcidente")
        writer.WriteElementString("dscLocal", TxtDescricaoLocal.Text)

        Dim BuscaDadosTabela20 = From l In LqTrabalhista.Tabela20
                                 Where l.Descricao Like DescLogradouro
                                 Select l.Codigo, l.Descricao

        If BuscaDadosTabela20.Count > 0 Then
            writer.WriteElementString("tpLograd", BuscaDadosTabela20.First.Codigo)
        Else
            writer.WriteElementString("tpLograd", "")
        End If

        writer.WriteElementString("dscLograd", TxtEndereco.Text)
        writer.WriteElementString("nrLograd", TxtNumero.Text)
        writer.WriteElementString("complemento", TxtComplemento.Text)
        writer.WriteElementString("bairro", TxtBairro.Text)
        writer.WriteElementString("cep", TxtCep.Text)
        writer.WriteElementString("codMunic", CodMunicipio)
        writer.WriteElementString("uf", TxtEstado.Text)

        If CmbTipoLocal.SelectedItem.ToString.StartsWith("2") Then

            writer.WriteElementString("pais", LstCodPaises.Items(CmbPaises.SelectedIndex).ToString)

        Else

            writer.WriteElementString("pais", "")

        End If

        writer.WriteElementString("codPostal", TxtCodPostal.Text)

        writer.WriteStartElement("ideLocalAcid")
        writer.WriteElementString("tpInsc", TxtCodPostal.Text)
        writer.WriteElementString("nrInsc", TxtTipoInscr.Text)

        'encerra ideLocalAcid

        writer.WriteEndElement()

        'encerra localAcidente

        writer.WriteEndElement()

        writer.WriteStartElement("parteAtingida")
        writer.WriteElementString("codParteAting", LstCodTabela13.Items(CmbPArteCorpo.SelectedIndex).ToString)
        writer.WriteElementString("lateralidade", CmbLateralidade.SelectedItem.ToString.ToCharArray(0, 1))

        'encerra parteAtingida

        writer.WriteEndElement()

        writer.WriteStartElement("agenteCausador")
        writer.WriteElementString("codAgntCausador", LstCodTab14_15.Items(CmbDescricao.SelectedIndex).ToString)

        'encerra parteAtingida

        writer.WriteEndElement()

        writer.WriteEndElement()

        writer.WriteStartElement("atestado")

        Dim _dtAtestado As Date = DtAtestado.Value

        Dim _ANO_Atestado As String = _dtAtestado.Year
        Dim _MES_Atestado As String = _dtAtestado.Month
        If _MES_Atestado.Length < 2 Then
            _MES_Atestado = "0" & _dtAtestado.Month
        End If
        Dim _DIA_Atestado As String = _dtAtestado.Day
        If _DIA_Atestado.Length < 2 Then
            _DIA_Atestado = "0" & _dtAtestado.Day
        End If

        If CkAtestadoMedico.Checked = True Then
            writer.WriteElementString("dtAtendimento", _ANO_Atestado & _MES_Atestado & _DIA_Atestado)
            writer.WriteElementString("hrAtendimento", TxtHoraAtendimento.Text)
        Else
            writer.WriteElementString("dtAtendimento", "")
            writer.WriteElementString("hrAtendimento", "")
        End If

        If CkINternacao.Checked = True Then
            writer.WriteElementString("indInternacao", "S")
            writer.WriteElementString("durTrat", NmDurTrat.Value)
        Else
            writer.WriteElementString("indInternacao", "N")
            writer.WriteElementString("durTrat", 0)
        End If

        If CkAfastamento.Checked = True Then
            writer.WriteElementString("indAfast", "S")
        Else
            writer.WriteElementString("indAfast", "N")
        End If

        writer.WriteElementString("dscLesao", LstTabela17.Items(CmbLesao.SelectedIndex).ToString)
        writer.WriteElementString("dscCompLesao", TxtInfoCompl.Text)
        writer.WriteElementString("diagProvavel", TxtDiagnostico.Text)
        writer.WriteElementString("codCID", TxtCodCid.Text)

        writer.WriteStartElement("emitente")
        writer.WriteElementString("nmEmit", TxtNomeMedico.Text)

        Dim ideOC As Integer = 0
        If RdbCRM.Checked = True Then
            writer.WriteElementString("ideOC", "1")
        ElseIf RdbCRO.Checked = True Then
            writer.WriteElementString("ideOC", "2")
        ElseIf RdbRMS.Checked = True Then
            writer.WriteElementString("ideOC", "3")
        End If

        writer.WriteElementString("nrOC", TxtNumDocumento.Text)
        writer.WriteElementString("ufOC", CmbEstadoEmitente.Text)

        'encerra emitente

        writer.WriteEndElement()

        writer.WriteStartElement("catOrigem")
        writer.WriteElementString("nrRecCatOrig", "")

        'encerra catOrigem

        writer.WriteEndElement()

        'encerra cat

        writer.WriteEndElement()

        'encerra evtCAT

        writer.WriteEndElement()

        'Escreve o XML para o arquivo e fecha o objeto escritor

        writer.Close()

        Dim settings As New XmlReaderSettings()

        AddHandler settings.ValidationEventHandler, AddressOf Me.ValidationEventHandler

        'Valida o arquivo XML com o seu Schema XSD

        'insere informações no banco de envio do evento

        'inicia o processo de assinatura

        'assina documento

        SelecionarCertificado("C:\Iara\ESocial\" & IdSocial & ".xml", Identificacao)

    End Sub

    Private Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)
        Throw New NotImplementedException()
    End Sub

    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub SelecionarCertificado(ByVal ArqXmlAssinar As String, ByVal StrIdentificacao As String)

        Try

            GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
    "Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

            If objColecaoCertificadosX509.Count > 0 Then

                AssinarDocumentoXML(ArqXmlAssinar, "Signature", objColecaoCertificadosX509.Item(0).SerialNumber.ToString, StrIdentificacao)

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub AssinarRSA(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String, ByVal StrIdentificacao As String)

        Dim Certificado As X509Certificate2
        Certificado = objColecaoCertificadosX509.Item(0)

        Dim crypto As RSACryptoServiceProvider
        crypto = Certificado.PrivateKey

        Dim arquivo As FileInfo = New FileInfo(ArqXmlAssinar)
        Dim FS As FileStream = arquivo.OpenRead()

        Dim signature As Byte() = crypto.SignData(FS, New SHA1Managed())

        Dim FsCrypto As FileStream

        FsCrypto = New FileStream(ArqXmlAssinar & ".signature", FileMode.Create)
        FsCrypto.Write(signature, 0, signature.Length())

        FsCrypto = New FileStream(ArqXmlAssinar & ".key", FileMode.Create)
        Dim XmlCert As String = crypto.ToXmlString(False)
        FsCrypto.Write(Encoding.Default.GetBytes(XmlCert), 0, XmlCert.Length)

    End Sub
    Private Sub AssinarDocumentoXML(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String, ByVal StrIdentificacao As String)

        Try

            Dim Certificado As X509Certificate2
            Certificado = objColecaoCertificadosX509.Item(0)
            Dim Key As RSA = Certificado.GetRSAPrivateKey

            SignVerify.SignVerifyEnvelope.CreateSomeXml("C:\Iara\ESocial\Signed" & StrIdentificacao & ".xml")

            Dim Arquivo_ASS As String = "C:\Iara\ESocial\" & StrIdentificacao & ".xml"

            SignVerify.SignVerifyEnvelope.SignXmlFile(ArqXmlAssinar, Arquivo_ASS, Key)

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.InsereESocial(LstIDCliente.Items(CmbTodosClientes.SelectedIndex).ToString, LstIdColaborador.Items(CmbColaboradores.SelectedIndex).ToString _
                                    , "S-2210", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, "C:\Iara\ESocial\" & StrIdentificacao & ".xml", StrIdentificacao, "", "", 0)

            'SignedXML.ComputeSignature()

            If MsgBox("Arquivo assinado com sucesso!", vbOKOnly) = DialogResult.OK Then

                'envia para o webservice

                Dim myBinding = New BasicHttpsBinding()
                myBinding.Security.Mode = SecurityMode.Transport
                myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

                Dim cc As WebReference.ServicoEnviarLoteEventos = New WebReference.ServicoEnviarLoteEventos(myBinding)

                cc.ClientCertificates.Add(Certificado)

                MsgBox(cc.SoapVersion.ToString)

                ' Cliente = New WebReference.ServicoEnviarLoteEventos(myBinding, ea)

                'Dim cc = New(myBinding, ea)


                Process.Start(Arquivo_ASS)

            End If


        Catch ex As Exception

            MsgBox(ex.Message & Chr(13) & ex.StackTrace, vbOKOnly)

        End Try


    End Sub

    Dim LstDoc As New ListBox
    Dim LstIDCliente As New ListBox
    Dim LStDoColab As New ListBox
    Private Sub Form2210_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista




    End Sub

    Dim LstMatricula As New ListBox
    Dim LstGrupoTrab As New ListBox
    Dim LstIdColaborador As New ListBox

    Private Sub CmbTodosClientes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTodosClientes.SelectedIndexChanged

        If CmbTodosClientes.Items.Contains(CmbTodosClientes.Text) Then

            CmbTodosClientes.BackColor = Color.White

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdCliente As Integer = LstIDCliente.Items(CmbTodosClientes.SelectedIndex).ToString

            Dim BuscaColaborador = From col In LqTrabalhista.ColaboradoresCliente
                                   Where col.IdCliente = IdCliente
                                   Select col.IdColaboradorCliente, col.NomeColaborador, col.DocColaborador, col.CatTrab, col.GrupoTrab

            LStDoColab.Items.Clear()
            CmbColaboradores.Items.Clear()
            LstIdColaborador.Items.Clear()

            For Each row In BuscaColaborador.ToList
                LStDoColab.Items.Add(row.DocColaborador)
                CmbColaboradores.Items.Add(row.NomeColaborador)
                LstIdColaborador.Items.Add(row.IdColaboradorCliente)

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

    Private Sub CmbColaboradores_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles CmbColaboradores.SelectedIndexChanged

        If CmbColaboradores.Items.Contains(CmbColaboradores.Text) Then

            CmbColaboradores.BackColor = Color.White

            CmbTodosClientes.BackColor = Color.White

            TabControl1.Enabled = True

        Else

            TabControl1.Enabled = False

        End If

    End Sub

    Dim CodTabela_15_16 As New ListBox

    Private Sub VerificaTipoAcid()

        RdbTipico.ForeColor = Color.SlateGray
        RdbDoenca.ForeColor = Color.SlateGray
        RdbTrajeto.ForeColor = Color.SlateGray

        If RdbTipico.Checked = True Then

            TxtHoraAcid.Enabled = True

            'busca tabela 15
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela15
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            CodTabela_15_16.Items.Clear()
            CmbSituacaoGeradora.Items.Clear()

            For Each row In BuscaTabela.ToList

                CodTabela_15_16.Items.Add(row.Codigo)
                CmbSituacaoGeradora.Items.Add(row.Codigo & " " & row.Descricao)

            Next

        ElseIf RdbDoenca.Checked = True Then
            TxtHoraAcid.Enabled = False
            TxtHoraAcid.Text = ""
            'busca tabela 16

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela16
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            CodTabela_15_16.Items.Clear()
            CmbSituacaoGeradora.Items.Clear()

            For Each row In BuscaTabela.ToList

                CodTabela_15_16.Items.Add(row.Codigo)
                CmbSituacaoGeradora.Items.Add(row.Codigo & " " & row.Descricao)

            Next

            CmbSituacaoGeradora.Enabled = True

        ElseIf RdbTrajeto.Checked = True Then
            TxtHoraAcid.Enabled = True

            'busca tabela 15
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaTabela = From tab In LqTrabalhista.Tabela15
                              Where tab.Codigo Like "*"
                              Select tab.Codigo, tab.Descricao

            CodTabela_15_16.Items.Clear()
            CmbSituacaoGeradora.Items.Clear()

            For Each row In BuscaTabela.ToList

                CodTabela_15_16.Items.Add(row.Codigo)
                CmbSituacaoGeradora.Items.Add(row.Codigo & " " & row.Descricao)

            Next

        End If

    End Sub
    Private Sub RdbTipico_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTipico.CheckedChanged
        VerificaTipoAcid()
    End Sub

    Private Sub RdbDoenca_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDoenca.CheckedChanged
        VerificaTipoAcid()
    End Sub

    Private Sub RdbTrajeto_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTrajeto.CheckedChanged
        VerificaTipoAcid()
    End Sub

    Private Sub TxtHoraAcid_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtHoraAcid.MaskInputRejected

    End Sub

    Private Sub CkObito_CheckedChanged(sender As Object, e As EventArgs) Handles CkObito.CheckedChanged

        If CkObito.Checked = True Then
            DtObito.Enabled = True
        Else
            DtObito.Enabled = False
        End If

    End Sub

    Private Sub TxtHoraAcid_TextChanged(sender As Object, e As EventArgs) Handles TxtHoraAcid.TextChanged

        If TxtHoraAcid.Text.Length = 4 Then
            TxtInicioExp.Enabled = True
            TxtInicioExp.Focus()
        Else
            TxtInicioExp.Enabled = False
            TxtInicioExp.Text = ""
        End If

    End Sub

    Private Sub TxtInicioExp_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtInicioExp.MaskInputRejected

    End Sub

    Private Sub TxtInicioExp_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioExp.TextChanged

        If TxtInicioExp.Text.Length = 4 Then
            CmbSituacaoGeradora.Enabled = True
            CmbSituacaoGeradora.Focus()
        Else
            CmbSituacaoGeradora.Enabled = False
            CmbSituacaoGeradora.Text = ""
        End If

    End Sub

    Dim CodMunicipio As String
    Dim DescLogradouro As String

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        If TxtCep.Text.Length = 8 Then

            Me.Cursor = Cursors.WaitCursor

            TxtCep.BackColor = Color.White

            Dim _Endereco As String = ""

            'busca dados do 
            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
            ds.ReadXml(xml)

            TxtEndereco.Text = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
            TxtBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            TxtCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            TxtEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()

            'procura codigo do muicipio na api do ibge

            Dim Municipio As String = ds.Tables(0).Rows(0)("cidade").ToString()

            'limpa e insere todos os estados de acordo com o IBGE

            Dim baseUrlImagemUsuario As String = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagemUsuario = New WebClient()
            Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

            Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.UFEMIT))(contentImagemUsuario)

            Me.Cursor = Cursors.AppStarting

            For Each i In readImagemUsuario.ToList

                If i.sigla = ds.Tables(0).Rows(0)("uf").ToString() Then

                    'busca municipio

                    Dim baseUrlUf As String = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/" & i.id & "/distritos"

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientUf = New WebClient()
                    Dim contentuf = syncClientUf.DownloadString(baseUrlUf)

                    Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(contentuf)
                    Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

                    Dim readUf = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.MunRoot))(TextURLDevolvidaDadosRF)

                    For Each l In readUf.ToList

                        If l.nome = TxtCidade.Text Then

                            CodMunicipio = l.id

                        End If

                    Next

                End If

            Next

            DescLogradouro = ds.Tables(0).Rows(0)("tipo_logradouro").ToString()

            Me.Cursor = Cursors.Arrow

            TxtNumero.Enabled = True
            TxtNumero.Focus()

        Else

            CmbDescricao.BackColor = Color.MistyRose

            TxtEndereco.Enabled = False
            TxtNumero.Enabled = False
            TxtComplemento.Enabled = False
            TxtBairro.Enabled = False
            TxtCidade.Enabled = False
            TxtEstado.Enabled = False
            TxtPais.Enabled = False

            TxtEndereco.Text = ""
            TxtNumero.Text = ""
            TxtComplemento.Text = ""
            TxtBairro.Text = ""
            TxtCidade.Text = ""
            TxtEstado.Text = ""
            TxtPais.Text = ""

        End If

    End Sub

    Dim LstCodPaises As New ListBox

    Private Sub CmbTipoLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoLocal.SelectedIndexChanged

        If CmbTipoLocal.Items.Contains(CmbTipoLocal.Text) Then
            CmbTipoLocal.BackColor = Color.White
            If CmbTipoLocal.SelectedItem.ToString.ToCharArray(0, 1).ToString <> "2" Then
                TxtDescricaoLocal.Enabled = True
                CmbPaises.Items.Clear()
            Else
                TxtDescricaoLocal.Enabled = True

                Dim LqTrabalhista As New LqTrabalhistaDataContext
                LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                Dim BuscaPaises = From p In LqTrabalhista.Tabela06
                                  Where p.Codigo Like "*"
                                  Select p.Codigo, p.Nome

                CmbPaises.Items.Clear()
                LstCodPaises.Items.Clear()

                For Each p In BuscaPaises.ToList
                    CmbPaises.Items.Add(p.Nome)
                    LstCodPaises.Items.Add(p.Codigo)
                Next

            End If

        Else
            TxtCep.Text = ""
            TxtCep.Enabled = False
            CmbTipoLocal.BackColor = Color.MistyRose

        End If

    End Sub

    Dim LstCodTabela13 As New ListBox

    Private Sub CmbSituacaoGeradora_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSituacaoGeradora.SelectedIndexChanged

        If CmbSituacaoGeradora.Items.Contains(CmbSituacaoGeradora.Text) Then
            CmbSituacaoGeradora.BackColor = Color.White

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaLog = From l In LqTrabalhista.Tabela13
                           Where l.Codigo Like "*"
                           Select l.Codigo, l.Descricao

            LstCodTabela13.Items.Clear()
            CmbPArteCorpo.Items.Clear()

            For Each l In BuscaLog.ToList

                LstCodTabela13.Items.Add(l.Codigo)
                CmbPArteCorpo.Items.Add(l.Descricao)

            Next

            CmbPArteCorpo.Enabled = True

        Else

            CmbPArteCorpo.Enabled = False
            CmbPArteCorpo.Text = ""

        End If

    End Sub

    Private Sub CmbDescricao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbDescricao.SelectedIndexChanged

        If CmbDescricao.Items.Contains(CmbDescricao.Text) Then

            CmbDescricao.BackColor = Color.White

            If CmbPaises.Items.Count > 0 Then
                CmbPaises.Enabled = True
                TxtCep.Enabled = False
                TxtCep.Text = ""
            Else
                TxtCep.Enabled = True
                CmbPaises.Enabled = False
                CmbPaises.Text = ""
            End If
        Else

            CmbDescricao.BackColor = Color.MistyRose

            TxtCep.Text = ""
            TxtCep.Enabled = False
            CmbPaises.Text = ""
        End If

    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then
            TxtNumero.BackColor = Color.White

            TxtComplemento.Enabled = True
            CkAtestadoMedico.Enabled = True
            CkINternacao.Enabled = True
            CmbLesao.Enabled = True

            RdbCNPJ.Enabled = True
            RdbCAEPF.Enabled = True
            RdbCNO.Enabled = True

        Else
            TxtNumero.BackColor = Color.MistyRose

            TxtComplemento.Enabled = False
            TxtComplemento.Text = ""
            CkAtestadoMedico.Enabled = False
            CkINternacao.Enabled = False
            CkAtestadoMedico.Checked = False
            CkINternacao.Checked = False
            CmbLesao.Enabled = False
            CmbLesao.Text = ""

            RdbCNPJ.Enabled = False
            RdbCAEPF.Enabled = False
            RdbCNO.Enabled = False

            RdbCNPJ.Checked = False
            RdbCAEPF.Checked = False
            RdbCNO.Checked = False
        End If

    End Sub

    Dim LstCodTab14_15 As New ListBox

    Private Sub VerificaIniciativa()

        RdbEmpregador.ForeColor = Color.SlateGray
        RdbOrdemJud.ForeColor = Color.SlateGray
        RdbFiscalizador.ForeColor = Color.SlateGray

        TxtObservacao.Enabled = True
        CmbTipoLocal.Enabled = True

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        If RdbTipico.Checked = True Or RdbTrajeto.Checked = True Then

            Dim BuscaLog = From l In LqTrabalhista.Tabela14
                           Where l.Codigo Like "*"
                           Select l.Codigo, l.Descricao

            CmbDescricao.Items.Clear()
            LstCodTab14_15.Items.Clear()

            For Each l In BuscaLog.ToList

                CmbDescricao.Items.Add(l.Descricao)
                LstCodTab14_15.Items.Add(l.Codigo)

            Next

        End If

        If RdbDoenca.Checked = True Then

            Dim BuscaLog = From l In LqTrabalhista.Tabela15
                           Where l.Codigo Like "*"
                           Select l.Codigo, l.Descricao

            CmbDescricao.Items.Clear()
            LstCodTab14_15.Items.Clear()

            For Each l In BuscaLog.ToList

                CmbDescricao.Items.Add(l.Descricao)
                LstCodTab14_15.Items.Add(l.Codigo)

            Next

        End If

    End Sub
    Private Sub RdbEmpregador_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEmpregador.CheckedChanged

        VerificaIniciativa()

    End Sub

    Private Sub RdbOrdemJud_CheckedChanged(sender As Object, e As EventArgs) Handles RdbOrdemJud.CheckedChanged
        VerificaIniciativa()
    End Sub

    Private Sub RdbFiscalizador_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFiscalizador.CheckedChanged
        VerificaIniciativa()
    End Sub

    Private Sub CmbPaises_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPaises.SelectedIndexChanged

        If CmbPaises.Items.Contains(CmbPaises.Text) Then

            CmbPaises.BackColor = Color.White

            TxtCodPostal.Enabled = True

        Else

            CmbPaises.BackColor = Color.MistyRose

            TxtCodPostal.Enabled = False
            TxtCodPostal.Text = ""

        End If
    End Sub

    Dim LstTabela17 As New ListBox

    Private Sub LiberaTipoInsc()

        RdbCNPJ.ForeColor = Color.SlateGray
        RdbCAEPF.ForeColor = Color.SlateGray
        RdbCNO.ForeColor = Color.SlateGray

        TxtTipoInscr.Enabled = True
        'busca dados da tabela 17

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTabela17 = From t In LqTrabalhista.Tabela17
                            Where t.Codigo Like "*"
                            Select t.Codigo, t.Descricao

        CmbLesao.Items.Clear()
        LstTabela17.Items.Clear()

        For Each t In BuscaTabela17.ToList
            CmbLesao.Items.Add(t.Descricao)
            LstTabela17.Items.Add(t.Codigo)
        Next

        Me.Cursor = Cursors.WaitCursor

        Try

            API_HTML = pegaHTML(URL_API_CID)

            Me.Cursor = Cursors.WaitCursor

            Dim ValoresTags As String = removeTags(API_HTML, 0)

            'varre resultados

        Catch ex As Exception
            MessageBox.Show(" Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        TxtTipoInscr.Focus()

    End Sub
    Private Sub RdbCNPJ_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCNPJ.CheckedChanged
        LiberaTipoInsc()
    End Sub

    Private Sub RdbCAEPF_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCAEPF.CheckedChanged
        LiberaTipoInsc()
    End Sub

    Private Sub RdbCNO_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCNO.CheckedChanged
        LiberaTipoInsc()
    End Sub

    Private Sub CmbLateralidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLateralidade.SelectedIndexChanged

        If CmbLateralidade.Items.Contains(CmbLateralidade.Text) Then

            CmbLateralidade.BackColor = Color.White

            RdbEmpregador.Enabled = True
            RdbFiscalizador.Enabled = True
            RdbOrdemJud.Enabled = True

        Else

            RdbEmpregador.Enabled = False
            RdbEmpregador.Checked = False
            RdbFiscalizador.Enabled = False
            RdbFiscalizador.Checked = False
            RdbOrdemJud.Enabled = True
            RdbOrdemJud.Checked = False

        End If

    End Sub

    Private Sub CmbPArteCorpo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPArteCorpo.SelectedIndexChanged

        If CmbPArteCorpo.Items.Contains(CmbPArteCorpo.Text) Then
            CmbPArteCorpo.BackColor = Color.White

            CmbLateralidade.Enabled = True

        Else

            CmbLateralidade.Enabled = False
            CmbLateralidade.Text = ""

        End If
    End Sub

    Private Sub CmbAgenteCausador_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtTipoInscr_TextChanged(sender As Object, e As EventArgs) Handles TxtTipoInscr.TextChanged

        If TxtTipoInscr.Text <> "" Then
            TxtTipoInscr.BackColor = Color.White
            CkAtestadoMedico.Enabled = True
            CkAfastamento.Enabled = True
            CmbLesao.Enabled = True
        Else
            TxtTipoInscr.BackColor = Color.MistyRose
            CkAtestadoMedico.Enabled = False
            CkAfastamento.Enabled = False
            CkAtestadoMedico.Checked = False
            CkAfastamento.Checked = False
            CmbLesao.Enabled = False
            CmbLesao.Text = ""
        End If

    End Sub

    Private Sub CkAtestadoMedico_CheckedChanged(sender As Object, e As EventArgs) Handles CkAtestadoMedico.CheckedChanged

        If CkAfastamento.Checked = True Then
            DtAtestado.Enabled = True
            TxtHoraAtendimento.Enabled = True
        Else
            DtAtestado.Enabled = False
            TxtHoraAtendimento.Text = ""
        End If

    End Sub

    Private Sub NmDurTrat_ValueChanged(sender As Object, e As EventArgs) Handles NmDurTrat.ValueChanged

        If NmDurTrat.Value > 0 Then
            CkAfastamento.Enabled = True
        Else
            CkAfastamento.Checked = False
            CkAfastamento.Enabled = False
        End If
    End Sub

    Private Sub CmbLesao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbLesao.SelectedIndexChanged

        If CmbLesao.Items.Contains(CmbLesao.Text) Then

            CmbLesao.BackColor = Color.White

            TxtInfoCompl.Enabled = True
            TxtDiagnostico.Enabled = True
            TxtCodCid.Enabled = True
            TxtDescricaoCID.Enabled = True

            DtCIDS.Enabled = True

        Else

            CmbLesao.BackColor = Color.MistyRose

            TxtInfoCompl.Enabled = False
            TxtInfoCompl.Text = ""
            TxtDiagnostico.Enabled = False
            TxtCodCid.Enabled = False
            TxtDescricaoCID.Enabled = False
            TxtDiagnostico.Text = ""
            TxtCodCid.Text = ""
            TxtDescricaoCID.Text = ""

            DtCIDS.Enabled = False

        End If

    End Sub

    Dim API_HTML As String
    Dim URL_API_CID As String = "https://pebmed.com.br/cid10/?utm_source=google&utm_medium=cpc&utm_campaign=search_cid&gclid=Cj0KCQjwiqWHBhD2ARIsAPCDzamEWf-v7VoaI8UGFbaePV3-6o7S_XGKYuj7GwlKA1l0ysQDnapbSQQaAl7REALw_wcB"
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Public Function pegaHTML(ByVal URL As String) As String

        Me.Cursor = Cursors.AppStarting

        ' Retorna o HTML da URL informada
        Dim objWC As New System.Net.WebClient
        Return New UTF8Encoding().GetString(objWC.DownloadData(URL))
    End Function
    Public Function removeTags(ByVal HTML As String, ByVal Valid As Integer) As String

        Me.Cursor = Cursors.AppStarting
        Dim TagsEncontrados As String = ""

        'Remove as tags do HTML

        If Valid = 0 Then

            '<select scrolling = "auto" Class="fundo_select_tabnet" name="SDiagn_Lesão_(CID10_4díg)" id="S56" size="10" multiple="" style="display: block;">
            '<option value = "TODAS_AS_CATEGORIAS__" selected="">Todas As categorias
            '</option><option value="1">S00.0 Traum superf do couro cabeludo

            Dim str As String = HTML.Replace("""", "'")
            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(str)

            Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(str)
            Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

            Dim separador As String = "<"
            Dim palavras As String() = TextURLDevolvidaDadosRF.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            DtCIDS.Rows.Clear()

            Dim Validado As Boolean = False

            For Each palavra In palavras
                Dim Procura As String = "panel"
                If Validado = False Then
                    If palavra.Contains(Procura) Then
                        Validado = True
                    End If
                Else
                    If palavra.StartsWith("a href") Then

                        Dim strOpt As String = palavra
                        Dim separadorOpt As String = "/"
                        Dim palavrasOpt As String() = strOpt.Split(separadorOpt)
                        Dim LstPalavrasOpt As New ListBox
                        Dim palavraOpt As String

                        Dim Insere As Boolean = False
                        Dim ValidOpt As Boolean = False
                        Dim CVal As Integer = 0

                        For Each palavraOpt In palavrasOpt

                            CVal += 1

                            If CVal = 3 Then

                                'separa o primeiro para o codigo e remove do outro campo
                                Dim strCID As String = palavraOpt
                                Dim separadorCID As String = "-"
                                Dim palavrasCID As String() = strCID.Split(separadorCID)
                                Dim LstPalavrasCID As New ListBox
                                Dim palavraCID As String

                                Dim CodCid As String = ""

                                For Each palavraCID In palavrasCID

                                    If CodCid = "" Then
                                        CodCid = palavraCID
                                    End If

                                Next

                                Dim PalavraToda As String = palavraOpt.ToLower.Remove(0, CodCid.Length)

                                If PalavraToda <> "" Then
                                    If PalavraToda.Contains(TxtDescricaoCID.Text.ToLower) Then
                                        DtCIDS.Rows.Add(CodCid, palavraOpt.Remove(0, CodCid.Length).Replace("-", " "))
                                    End If
                                End If

                                Insere = False


                            ElseIf CVal = 3 Then

                                CVal += 1

                            End If

                        Next

                    End If

                End If

            Next
            '<select scrolling = "auto" Class="fundo_select_tabnet" name="SDiagn_Lesão_(CID10_4díg)" id="S56" size="10" multiple="" style="display: block;">
            '<option value = "TODAS_AS_CATEGORIAS__" selected="">Todas As categorias
            '</option><option value="1">S00.0 Traum superf do couro cabeludo
            Me.Cursor = Cursors.Arrow

        Else

            Dim str As String = HTML.Replace("""", "'")
            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(str)

            Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(str)
            Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

            Dim separador As String = "<"
            Dim palavras As String() = TextURLDevolvidaDadosRF.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            DtCIDS.Rows.Clear()

            Dim Validado As Boolean = False

            For Each palavra In palavras
                Dim Procura As String = "S56"
                If Validado = False Then
                    If palavra.Contains(Procura) Then
                        Validado = True
                    End If
                Else
                    If palavra.StartsWith("OPTION") Then

                        Dim strOpt As String = palavra
                        Dim separadorOpt As String = ">"
                        Dim palavrasOpt As String() = strOpt.Split(separadorOpt)
                        Dim LstPalavrasOpt As New ListBox
                        Dim palavraOpt As String

                        Dim Insere As Boolean = False
                        Dim ValidOpt As Boolean = False
                        For Each palavraOpt In palavrasOpt

                            If palavraOpt.StartsWith("Em") Then
                                ValidOpt = True
                                Validado = False
                            End If

                            If ValidOpt = False Then

                                If Not palavraOpt.StartsWith("Todas") Then
                                    If Insere = True Then

                                        'separa o primeiro para o codigo e remove do outro campo
                                        Dim strCID As String = palavraOpt
                                        Dim separadorCID As String = " "
                                        Dim palavrasCID As String() = strCID.Split(separadorCID)
                                        Dim LstPalavrasCID As New ListBox
                                        Dim palavraCID As String

                                        Dim CodCid As String = ""

                                        For Each palavraCID In palavrasCID

                                            If CodCid = "" Then
                                                CodCid = palavraCID
                                            End If

                                        Next

                                        Dim PalavraToda As String = palavraOpt.ToLower.Remove(0, CodCid.Length)

                                        If CodCid = TxtCodCid.Text Then
                                            LblDescricao.Text = palavraOpt.Remove(0, CodCid.Length)
                                        End If

                                        Insere = False

                                    Else
                                        Insere = True
                                    End If

                                End If

                            End If

                        Next

                    End If
                End If

            Next
            '<select scrolling = "auto" Class="fundo_select_tabnet" name="SDiagn_Lesão_(CID10_4díg)" id="S56" size="10" multiple="" style="display: block;">
            '<option value = "TODAS_AS_CATEGORIAS__" selected="">Todas As categorias
            '</option><option value="1">S00.0 Traum superf do couro cabeludo
            Me.Cursor = Cursors.Arrow

        End If

        Return TagsEncontrados

    End Function

    Private Sub TxtCodCid_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCid.TextChanged

        If TxtCodCid.Text <> "" Then

            TxtDescricaoCID.Text = ""
            'filtra so os correspondentes
            TxtCodCid.BackColor = Color.White

            Dim F_Ind As Integer = -1
            For Each row As DataGridViewRow In DtCIDS.Rows

                If row.Cells(0).Value.ToString.Contains(TxtCodCid.Text) Then

                    row.Visible = True

                    If F_Ind = -1 Then
                        row.Selected = True
                        LblDescricao.Text = row.Cells(1).Value
                    End If

                Else

                    If F_Ind = row.Index Then
                        F_Ind = -1
                    End If

                    row.Visible = False

                End If

            Next

            TxtNomeMedico.Enabled = True

        Else

            TxtCodCid.BackColor = Color.MistyRose

            LblDescricao.Text = ""
            TxtNomeMedico.Text = ""
            TxtNomeMedico.Enabled = False

            For Each row As DataGridViewRow In DtCIDS.Rows
                row.Visible = True
            Next

            DtCIDS.Rows(0).Selected = True

        End If

    End Sub

    Private Sub TxtCodCid_LostFocus(sender As Object, e As EventArgs) Handles TxtCodCid.LostFocus

    End Sub

    Private Sub TxtDescricaoLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricaoLocal.TextChanged

        If TxtDescricaoLocal.Text <> "" Then
            TxtDescricaoLocal.BackColor = Color.White
            CmbDescricao.Enabled = True
        Else
            TxtDescricaoLocal.BackColor = Color.MistyRose
            CmbDescricao.Enabled = False
            CmbDescricao.Text = ""
        End If

    End Sub

    Private Sub TxtDescricaoCID_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricaoCID.TextChanged

        If TxtDescricaoCID.Text <> "" Then
            'filtra so os correspondentes
            TxtCodCid.Text = ""

            Dim F_Ind As Integer = -1
            For Each row As DataGridViewRow In DtCIDS.Rows

                If row.Cells(1).Value.ToString.Contains(TxtDescricaoCID.Text) Then

                    row.Visible = True

                    If F_Ind = -1 Then
                        F_Ind = row.Index
                    End If

                Else

                    If F_Ind = row.Index Then
                        F_Ind = -1
                    End If

                    row.Visible = False

                End If

            Next

            If F_Ind <> -1 Then
                DtCIDS.Rows(F_Ind).Selected = True
            Else
                DtCIDS.Rows(0).Selected = True
            End If

        Else

            For Each row As DataGridViewRow In DtCIDS.Rows
                row.Visible = True
            Next

            DtCIDS.Rows(0).Selected = True

        End If

    End Sub

    Private Sub LiberaDadosMedico()
        TxtNumDocumento.Enabled = True
        RdbCRM.ForeColor = Color.SlateGray
        RdbCRO.ForeColor = Color.SlateGray
        RdbRMS.ForeColor = Color.SlateGray

        'limpa e insere todos os estados de acordo com o IBGE

        Dim baseUrlImagemUsuario As String = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientImagemUsuario = New WebClient()
        Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

        Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.UFEMIT))(contentImagemUsuario)

        CmbEstadoEmitente.Items.Clear()

        For Each i In readImagemUsuario.ToList

            CmbEstadoEmitente.Items.Add(i.sigla)

        Next

    End Sub
    Private Sub RdbCRM_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCRM.CheckedChanged
        LiberaDadosMedico()
    End Sub

    Private Sub RdbCRO_CheckedChanged(sender As Object, e As EventArgs) Handles RdbCRO.CheckedChanged
        LiberaDadosMedico()
    End Sub

    Private Sub RdbRMS_CheckedChanged(sender As Object, e As EventArgs) Handles RdbRMS.CheckedChanged
        LiberaDadosMedico()
    End Sub

    Private Sub TxtNomeMedico_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeMedico.TextChanged

        If TxtNomeMedico.Text <> "" Then
            TxtNomeMedico.BackColor = Color.White
            RdbCRM.Enabled = True
            RdbRMS.Enabled = True
            RdbCRO.Enabled = True
        Else
            TxtNomeMedico.BackColor = Color.MistyRose

            RdbCRM.Enabled = False
            RdbRMS.Enabled = False
            RdbCRO.Enabled = False

            RdbCRM.Checked = False
            RdbRMS.Checked = False
            RdbCRO.Checked = False
        End If

    End Sub

    Private Sub TxtNumDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtNumDocumento.TextChanged
        If TxtNumDocumento.Text <> "" Then
            TxtNumDocumento.BackColor = Color.White
            CmbEstadoEmitente.Enabled = True
        Else
            TxtNumDocumento.BackColor = Color.MistyRose
            CmbEstadoEmitente.Enabled = False
            CmbEstadoEmitente.Text = ""
        End If
    End Sub

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub TxtObservacao_TextChanged(sender As Object, e As EventArgs) Handles TxtObservacao.TextChanged
        If TxtObservacao.Text <> "" Then
            TxtObservacao.BackColor = Color.White
        Else
            TxtObservacao.BackColor = Color.MistyRose
        End If
    End Sub

    Private Sub TxtCodPostal_TextChanged(sender As Object, e As EventArgs) Handles TxtCodPostal.TextChanged

        If TxtCodPostal.Text <> "" Then
            TxtCodPostal.BackColor = Color.White

            CkAtestadoMedico.Enabled = True
            CkINternacao.Enabled = True
            CmbLesao.Enabled = True

            RdbCNPJ.Enabled = True
            RdbCAEPF.Enabled = True
            RdbCNO.Enabled = True

        Else
            TxtCodPostal.BackColor = Color.MistyRose

            TxtComplemento.Enabled = False
            TxtComplemento.Text = ""
            CkAtestadoMedico.Enabled = False
            CkINternacao.Enabled = False
            CkAtestadoMedico.Checked = False
            CkINternacao.Checked = False
            CmbLesao.Enabled = False
            CmbLesao.Text = ""

            RdbCNPJ.Enabled = False
            RdbCAEPF.Enabled = False
            RdbCNO.Enabled = False

            RdbCNPJ.Checked = False
            RdbCAEPF.Checked = False
            RdbCNO.Checked = False

        End If

    End Sub

    Private Sub TxtInfoCompl_TextChanged(sender As Object, e As EventArgs) Handles TxtInfoCompl.TextChanged

        If TxtInfoCompl.Text <> "" Then
            TxtInfoCompl.BackColor = Color.White
        Else
            TxtInfoCompl.BackColor = Color.MistyRose
        End If

    End Sub

    Private Sub TxtDiagnostico_TextChanged(sender As Object, e As EventArgs) Handles TxtDiagnostico.TextChanged

        If TxtDiagnostico.Text <> "" Then
            TxtDiagnostico.BackColor = Color.White
        Else
            TxtDiagnostico.BackColor = Color.MistyRose
        End If

    End Sub

    Private Sub CmbEstadoEmitente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstadoEmitente.SelectedIndexChanged

        If CmbEstadoEmitente.Items.Contains(CmbEstadoEmitente.Text) Then

            CmbEstadoEmitente.BackColor = Color.White

        Else

            CmbEstadoEmitente.BackColor = Color.MistyRose

        End If
    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellContentClick

    End Sub

    Private Sub DtCIDS_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCIDS.CellDoubleClick

        TxtCodCid.Text = DtCIDS.SelectedCells(0).Value

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        FrmESocial.Show(Me)

    End Sub
End Class