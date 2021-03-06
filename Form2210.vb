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
Imports CRM_BASE.WebReference
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Serialization

Public Class Form2210
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub BttColaboradores_Click(sender As Object, e As EventArgs) Handles BttTransmitirCAT.Click

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

        writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/evt/evtCAT/v_S_01_00_00")

        'inicia evtCAT

        writer.WriteStartElement("evtCAT")
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
            writer.WriteElementString("codCateg", LstGrupoTrab.Items(CmbColaboradores.SelectedIndex).ToString)
        End If

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
        writer.WriteElementString("dtAcid", _ANO & "-" & _MES & "-" & _DIA)
        writer.WriteElementString("tpAcid", tpAcid)
        If HorasAntesTrab.TimeOfDay.ToString <> "00:00:00" Then

            Dim HrStrAtnTrab As String = HorasAntesTrab.TimeOfDay.ToString
            HrStrAtnTrab = HrStrAtnTrab.ToCharArray(0, 5)
            HrStrAtnTrab = HrStrAtnTrab.Replace(":", "")
            writer.WriteElementString("hrsTrabAntesAcid", HrStrAtnTrab)
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
        If TxtObservacao.Text <> "" Then
            writer.WriteElementString("obsCAT", TxtObservacao.Text)
        End If

        writer.WriteStartElement("localAcidente")

        writer.WriteElementString("tpLocal", CmbTipoLocal.SelectedItem.ToString.ToCharArray(0, 1))

        writer.WriteElementString("dscLocal", TxtDescricaoLocal.Text)

        Dim BuscaDadosTabela20 = From l In LqTrabalhista.Tabela20
                                 Where l.Descricao Like DescLogradouro
                                 Select l.Codigo, l.Descricao

        If BuscaDadosTabela20.Count > 0 Then
            writer.WriteElementString("tpLograd", BuscaDadosTabela20.First.Codigo)
        End If

        writer.WriteElementString("dscLograd", LblEndereco.Text)
        writer.WriteElementString("nrLograd", TxtNumero.Text)
        If TxtComplemento.Text <> "" Then
            writer.WriteElementString("complemento", TxtComplemento.Text)
        End If

        writer.WriteElementString("bairro", LblBairro.Text)
        writer.WriteElementString("cep", TxtCep.Text)
        writer.WriteElementString("codMunic", CodMunicipio.Remove(0, 2))
        writer.WriteElementString("uf", LblEstado.Text)

        If CmbTipoLocal.SelectedItem.ToString.StartsWith("2") Then

            writer.WriteElementString("pais", LstCodPaises.Items(CmbPaises.SelectedIndex).ToString)

        End If

        If TxtCodPostal.Text <> "" Then
            writer.WriteElementString("codPostal", TxtCodPostal.Text)

            writer.WriteStartElement("ideLocalAcid")
            writer.WriteElementString("tpInsc", TxtCodPostal.Text)
            writer.WriteElementString("nrInsc", TxtTipoInscr.Text)

            'encerra ideLocalAcid

            writer.WriteEndElement()
        End If

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

        If CkAtestadoMedico.Checked = True Then
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
            writer.WriteElementString("dtAtendimento", _ANO_Atestado & _MES_Atestado & _DIA_Atestado)
            writer.WriteElementString("hrAtendimento", TxtHoraAtendimento.Text)
            If CkINternacao.Checked = True Then
                writer.WriteElementString("indInternacao", "S")
                writer.WriteElementString("durTrat", NmDurTrat.Value)
            Else
                writer.WriteElementString("indInternacao", "N")
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

            writer.WriteEndElement()

        End If

        'encerra cat

        'encerra evtCAT

        writer.WriteEndElement()

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

                    SignVerify.SignVerifyEnvelope.SignXmlFile("C:\Iara\ESocial\Eventos\" & Identificacao & ".xml", "C:\Iara\ESocial\Eventos\Signed" & Identificacao & ".xml", item_c, Identificacao, "S2210")
                    criaEventoEnviaLote("C:\Iara\ESocial\Eventos\Signed" & Identificacao & ".xml", Identificacao, Doc, Today.Year, MStr, DStr, HrStr, MinStr, SgStr)

                End If

            Next

        End If

        'writer.WriteEndElement()
        'Escreve o XML para o arquivo e fecha o objeto escritor
        'Process.Start("C:\Iara\ESocial\Eventos\" & Identificacao & ".xml")

        'gera o envio de lote

    End Sub

    Private Sub ValidationEventHandler(sender As Object, e As ValidationEventArgs)
        Throw New NotImplementedException()
    End Sub

    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub SelecionarCertificado(ByVal ArqXmlAssinar As String, ByVal StrIdentificacao As String, ByVal IDSOCIAL As Integer)

        'Try

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

            objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
    "Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

            If objColecaoCertificadosX509.Count > 0 Then

            SignVerify.SignVerifyEnvelope.SignXmlFile(ArqXmlAssinar, "C:\Iara\ESocial\" & StrIdentificacao & ".xml", objColecaoCertificadosX509.Item(0), StrIdentificacao, "S2210")

            'AssinarDocumentoXML(ArqXmlAssinar, "Signature", objColecaoCertificadosX509.Item(0).SerialNumber.ToString, StrIdentificacao, IDSOCIAL)

        End If

        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub AssinarDocumentoXML(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String, ByVal StrIdentificacao As String, ByVal IDSOCIAL As Integer)

        Try

            Dim Certificado As X509Certificate2
            Certificado = objColecaoCertificadosX509.Item(0)
            Dim Key As RSA = Certificado.GetRSAPrivateKey
            Dim X509 As X509Certificate2 = Certificado
            'SignVerify.SignVerifyEnvelope.CreateSomeXml("C:\Iara\ESocial\Signed" & StrIdentificacao & ".xml")

            Dim Arquivo_ASS As String = "C:\Iara\ESocial\" & StrIdentificacao & ".xml"


            'SignedXML.ComputeSignature()

            'If MsgBox("Arquivo assinado com sucesso!", vbOKOnly) = DialogResult.OK Then

            'envia para o webservice

            'Process.Start(Arquivo_ASS)

            ' Cliente = New WebReference.ServicoEnviarLoteEventos(myBinding, ea)

            'Dim cc = New(myBinding, ea)

            'FrmESocial.Show(FrmPrincipal)

            Me.Close()

        Catch ex As Exception

            MsgBox(ex.Message & Chr(13) & ex.StackTrace, vbOKOnly)

        End Try


    End Sub

    Public LstDoc As New ListBox
    Public LstIDCliente As New ListBox
    Public LStDoColab As New ListBox
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

    End Sub

    Public LstMatricula As New ListBox
    Public LstGrupoTrab As New ListBox
    Public LstIdColaborador As New ListBox

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
            TxtDocColaborador.Text = LStDoColab.Items(CmbColaboradores.SelectedIndex).ToString.Replace(".", "").Replace("-", "")
            ImgValColab.BackgroundImage = My.Resources.check_ok

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
        ImgValidSelTipo.BackgroundImage = My.Resources.check_ok
        DtAcidente.Enabled = True

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
                CmbSituacaoGeradora.Items.Add(row.Descricao)

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
                CmbSituacaoGeradora.Items.Add(row.Descricao)

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
                                    , "S-2210", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, "C:\Iara\ESocial\Lotes\" & CNPJ & AAAA & MM & DD & "T" & HH & MM_ & SS & ".xml", IDENTIFICACAO, "", "", 0)

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

                                    'Me.Close()

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

            LblEndereco.Text = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
            lblbairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            LblCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            LblEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()

            ImgValCepLocal.BackgroundImage = My.Resources.check_ok

            'procura codigo do muicipio na api do ibge

            Dim Municipio As String = ds.Tables(0).Rows(0)("cidade").ToString()

            'limpa e insere todos os estados de acordo com o IBGE

            Dim baseUrlImagemUsuario As String = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/"

            'carrega informações no site

            Try

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

                        Try

                            ' Chamada sincrona
                            Dim syncClientUf = New WebClient()
                            Dim contentuf = syncClientUf.DownloadString(baseUrlUf)

                            Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(contentuf)
                            Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

                            Dim readUf = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.MunRoot))(TextURLDevolvidaDadosRF)

                            For Each l In readUf.ToList

                                If l.nome = LblCidade.Text Then

                                    CodMunicipio = l.id

                                End If

                            Next

                        Catch ex As Exception

                            CodMunicipio = "000000"

                        End Try

                    End If

                Next

            Catch ex As Exception

                CodMunicipio = "000000"

            End Try

            DescLogradouro = ds.Tables(0).Rows(0)("tipo_logradouro").ToString()

            Me.Cursor = Cursors.Arrow

            TxtNumero.Enabled = True
            TxtNumero.Focus()

        Else

            CmbDescricao.BackColor = Color.MistyRose

            TxtNumero.Enabled = False
            TxtComplemento.Enabled = False

            LblEndereco.Text = ""
            TxtNumero.Text = ""
            TxtComplemento.Text = ""
            LblBairro.Text = ""
            LblCidade.Text = ""
            LblEstado.Text = ""
            lblPais.Text = ""

        End If

    End Sub

    Dim LstCodPaises As New ListBox

    Private Sub CmbTipoLocal_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoLocal.SelectedIndexChanged

        If CmbTipoLocal.Items.Contains(CmbTipoLocal.Text) Then
            CmbTipoLocal.BackColor = Color.White

            ImgValTpLocal.BackgroundImage = My.Resources.check_ok

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

            ImgValNumEndereco.BackgroundImage = My.Resources.check_ok

            TxtComplemento.Enabled = True
            CkAtestadoMedico.Enabled = True
            CkINternacao.Enabled = True
            CmbLesao.Enabled = True

            RdbCNPJ.Enabled = True
            RdbCAEPF.Enabled = True
            RdbCNO.Enabled = True

        Else

            ImgValNumEndereco.BackgroundImage = My.Resources.alertar_obg

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

        ImgValResponsável.BackgroundImage = My.Resources.check_ok

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

        TabControl1.SelectedIndex = 1

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
    Dim LstCodCid As New ListBox
    Dim LstDescricaoCid As New ListBox

    Private Sub LiberaTipoInsc()

        RdbCNPJ.ForeColor = Color.SlateGray
        RdbCAEPF.ForeColor = Color.SlateGray
        RdbCNO.ForeColor = Color.SlateGray

        ImgTipoInscr.BackgroundImage = My.Resources.check_ok

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

        If Not IO.File.Exists("C:\Iara\UTEIS\BDD\Bdd_Trabalhista\Tabelas\CID_0.txt") Then

            Using sw As FileStream = File.Create("C:\Iara\UTEIS\BDD\Bdd_Trabalhista\Tabelas\CID_0.txt")

                Dim TextoString As String = "CREATE TABLE dbo.CID_FIND" & Chr(13) &
                                            "([CODIGO] [varchar](10) NULL," & Chr(13) &
                                            "[DESCRICAO] [varchar](200) NULL)" & Chr(13) & Chr(13)

                Dim INSERT_STRING As String = "INSERT INTO dbo.CID_FIND" & Chr(13) &
                                              "(CODIGO,DESCRICAO)" & Chr(13) &
                                              "VALUES" & Chr(13)

                Try

                    API_HTML = pegaHTML(URL_API_CID)

                    Me.Cursor = Cursors.WaitCursor

                    '<select scrolling = "auto" Class="fundo_select_tabnet" name="SDiagn_Lesão_(CID10_4díg)" id="S56" size="10" multiple="" style="display: block;">
                    '<option value = "TODAS_AS_CATEGORIAS__" selected="">Todas As categorias
                    '</option><option value="1">S00.0 Traum superf do couro cabeludo

                    Dim str As String = API_HTML.Replace("""", "'")
                    Dim textoUrl As Byte() = New UTF8Encoding(True).GetBytes(str)

                    Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(str)
                    Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

                    Dim separador As String = "<"
                    Dim palavras As String() = TextURLDevolvidaDadosRF.Split(separador)
                    Dim LstPalavras As New ListBox
                    Dim palavra As String

                    Dim Validado As Boolean = False
                    Dim Contador As Integer = 0

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

                                Dim Lote As Integer = 1

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
                                            'DtCIDS.Rows.Add(CodCid, palavraOpt.Remove(0, CodCid.Length).Replace("-", " "))

                                            If Contador < 999 Then
                                                    Contador += 1
                                                    INSERT_STRING &= "('" & CodCid.ToUpper & "','" & palavraOpt.Remove(0, CodCid.Length).Replace("-", " ") & "')," & Chr(13)
                                                Else
                                                    INSERT_STRING = INSERT_STRING.Remove(INSERT_STRING.Length - 2, 1)
                                                    Contador = 0
                                                    Lote += 1
                                                    INSERT_STRING &= Chr(13) & Chr(13) & "INSERT INTO dbo.CID_FIND" & Chr(13) &
                                                                        "(CODIGO,DESCRICAO)" & Chr(13) &
                                                                        "VALUES" & Chr(13)
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

                    Dim ValoresTags As String = removeTags(API_HTML, 0)

                    'varre resultados

                Catch ex As Exception
                    MessageBox.Show(" Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString & INSERT_STRING.Remove(INSERT_STRING.Length - 2, 1))
                sw.Write(texto, 0, texto.Length)

                sw.Close()

                'roda no BDD pra nao utilizar novamente

                Dim SQLString As String = IO.File.OpenText("C:\Iara\UTEIS\BDD\Bdd_Trabalhista\Insert\CID\CID_0.txt").ReadToEnd()

                'Try

                Dim ConecctionServer As String

                ConecctionServer = FrmPrincipal.ConnectionStringTrabalhista

                'carrega 

                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    Dim ConnState As Boolean = False

                    'MsgBox(ConnState & " " & ConecctionServer)

                    Try

                        Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                        Conexão.Open()

                        SQLCommand1.ExecuteNonQuery()

                        Conexão.Close()

                        'row.Visible = False

                    Catch ex As Exception

                        Conexão.Close()

                    End Try

                    'adiciona pra ver se onsegue inserir

                End Using

            End Using

        End If

        'busca cids

        Dim BuscaCIDS = From cid In LqTrabalhista.CID_FIND
                        Where cid.CODIGO Like "*"
                        Select cid.CODIGO, cid.DESCRICAO

        LstDescricaoCid.Items.Clear()
        LstCodCid.Items.Clear()

        For Each row In BuscaCIDS.ToList

            LstCodCid.Items.Add(row.CODIGO)
            LstDescricaoCid.Items.Add(row.DESCRICAO)

        Next

        'carrega informaçoes da lista de cids

        If RdbCNPJ.Checked = True Then
            TxtTipoInscr.Mask = "00,000,000/0000-00"
        ElseIf RdbCAEPF.Checked = True Then
            TxtTipoInscr.Mask = "00,000,000/0000-00"
        ElseIf RdbCNO.Checked = True Then
            TxtTipoInscr.Mask = "00,000,00000/00"
        End If
        Me.Cursor = Cursors.Arrow

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

            ImgValLateralidade.BackgroundImage = My.Resources.check_ok
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

        Else

            CmbLesao.BackColor = Color.MistyRose

            TxtInfoCompl.Enabled = False
            TxtInfoCompl.Text = ""
            TxtDiagnostico.Enabled = False
            TxtCodCid.Enabled = False
            TxtDiagnostico.Text = ""
            TxtCodCid.Text = ""

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
                                            LblDescricaoCID.Text = palavraOpt.Remove(0, CodCid.Length)
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


    Private Sub TxtDescricaoLocal_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricaoLocal.TextChanged

        If TxtDescricaoLocal.Text <> "" Then
            TxtDescricaoLocal.BackColor = Color.White
            CmbDescricao.Enabled = True
            ImgValDescricaoLocal.BackgroundImage = My.Resources.check_ok

        Else
            TxtDescricaoLocal.BackColor = Color.MistyRose
            CmbDescricao.Enabled = False
            CmbDescricao.Text = ""
            ImgValDescricaoLocal.BackgroundImage = My.Resources.alertar_obg

        End If

    End Sub

    Private Sub LiberaDadosMedico()

        TxtNumDocumento.Enabled = True
        RdbCRM.ForeColor = Color.SlateGray
        RdbCRO.ForeColor = Color.SlateGray
        RdbRMS.ForeColor = Color.SlateGray

        ImgValDocMedico.BackgroundImage = My.Resources.check_ok

        'limpa e insere todos os estados de acordo com o IBGE

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

        If RdbCRM.Checked = True Then
            TxtNumDocumento.Mask = "0000000-0"
        ElseIf RdbCRO.Checked = True Then
            TxtNumDocumento.Mask = "000,000-0"
        ElseIf RdbRMS.Checked = True Then
            TxtNumDocumento.Mask = "00000,000000/00-00"
        End If

        TxtNumDocumento.Focus()

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

            ImgValNomeMEdico.BackgroundImage = My.Resources.check_ok

            RdbCRM.Enabled = True
            RdbRMS.Enabled = True
            RdbCRO.Enabled = True

        Else

            RdbCRM.Enabled = False
            RdbRMS.Enabled = False
            RdbCRO.Enabled = False

            RdbCRM.Checked = False
            RdbRMS.Checked = False
            RdbCRO.Checked = False

            ImgValNomeMEdico.BackgroundImage = My.Resources.alertar_obg

        End If

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
            BttTransmitirCAT.Enabled = True
            ImgValEstadoEmitente.BackgroundImage = My.Resources.check_ok

        Else

            CmbEstadoEmitente.BackColor = Color.MistyRose
            BttTransmitirCAT.Enabled = False
            ImgValEstadoEmitente.BackgroundImage = My.Resources.alertar_obg

        End If

    End Sub

    Private Sub DtCIDS_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

        FrmESocial.Show(Me)

    End Sub

    Private Sub MaskedTextBox1_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDodCliente.MaskInputRejected

    End Sub

    Private Sub MaskedTextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtDodCliente.TextChanged

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

    Private Sub TxtCodSitGeradora_TextChanged(sender As Object, e As EventArgs) Handles TxtCodSitGeradora.TextChanged

        'busca na lista de situação geradora

        Dim DescricaoSitGera As String

        For i As Integer = 0 To CodTabela_15_16.Items.Count - 1

            If CodTabela_15_16.Items(i).ToString = TxtCodSitGeradora.Text Then

                DescricaoSitGera = CmbSituacaoGeradora.Items(i).ToString
                LblDescricaoSitGera.Text = DescricaoSitGera
                ImgValSitGer.BackgroundImage = My.Resources.check_ok

                'carrega proxima lista

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

            End If

        Next

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtCodParteCorpo.TextChanged

        'busca na lista de situação geradora

        Dim DescricaoSitGera As String

        For i As Integer = 0 To LstCodTabela13.Items.Count - 1

            If LstCodTabela13.Items(i).ToString = TxtCodParteCorpo.Text Then

                DescricaoSitGera = CmbPArteCorpo.Items(i).ToString
                LblDescricaoParteCorpo.Text = DescricaoSitGera
                ImgValParteCorpo.BackgroundImage = My.Resources.check_ok

                CmbLateralidade.Enabled = True

            End If

        Next

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click

        FrmTab15_16.Show(Me)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        FrmTabela13.Show(Me)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        FrmTabela14.Show(Me)

    End Sub

    Private Sub TextBox1_TextChanged_1(sender As Object, e As EventArgs) Handles TxtCodAgenteCAusador.TextChanged

        Dim DescricaoSitGera As String

        For i As Integer = 0 To LstCodTab14_15.Items.Count - 1

            If LstCodTab14_15.Items(i).ToString = TxtCodAgenteCAusador.Text Then

                DescricaoSitGera = CmbDescricao.Items(i).ToString
                LblAgenteCausador.Text = DescricaoSitGera
                ImgValAgenteCausador.BackgroundImage = My.Resources.check_ok

                If CmbPaises.Items.Count > 0 Then
                    CmbPaises.Enabled = True
                    TxtCep.Enabled = False
                    TxtCep.Text = ""
                Else
                    TxtCep.Enabled = True
                    CmbPaises.Enabled = False
                    CmbPaises.Text = ""
                End If

            End If

        Next

    End Sub

    Private Sub TxtTipoInscr_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTipoInscr.MaskInputRejected

    End Sub

    Private Sub TxtTipoInscr_TextChanged(sender As Object, e As EventArgs) Handles TxtTipoInscr.TextChanged
        If TxtTipoInscr.Text.Length = TxtTipoInscr.Mask.Replace(",", "").Replace("/", "").Replace("-", "").Length Then
            TabControl1.SelectedIndex = 2

            If TxtTipoInscr.Text <> "" Then
                TxtTipoInscr.BackColor = Color.White
                CkAtestadoMedico.Enabled = True
                CkAfastamento.Enabled = True
                CmbLesao.Enabled = True
                ImgValNDocumento.BackgroundImage = My.Resources.check_ok
            Else
                TxtTipoInscr.BackColor = Color.MistyRose
                CkAtestadoMedico.Enabled = False
                CkAfastamento.Enabled = False
                CkAtestadoMedico.Checked = False
                CkAfastamento.Checked = False
                CmbLesao.Enabled = False
                CmbLesao.Text = ""
                ImgValNDocumento.BackgroundImage = My.Resources.alertar_obg

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        FrmTabela17.Show(Me)

    End Sub

    Private Sub TxtCodLesao_TextChanged(sender As Object, e As EventArgs) Handles TxtCodLesao.TextChanged

        Dim DescricaoSitGera As String

        For i As Integer = 0 To LstTabela17.Items.Count - 1

            If LstTabela17.Items(i).ToString = TxtCodLesao.Text Then

                DescricaoSitGera = CmbLesao.Items(i).ToString
                LblDescricaoLesao.Text = DescricaoSitGera
                ImgValLesao.BackgroundImage = My.Resources.check_ok

                TxtInfoCompl.Enabled = True
                TxtDiagnostico.Enabled = True
                TxtCodCid.Enabled = True

                TabControl1.SelectedIndex = 3

            End If

        Next

    End Sub

    Private Sub TxtCodCid_TextChanged(sender As Object, e As EventArgs) Handles TxtCodCid.TextChanged

        Dim DescricaoSitGera As String

        LblDescricaoCID.Text = ""
        ImgValCid.BackgroundImage = My.Resources.alertar_obg

        For i As Integer = 0 To LstCodCid.Items.Count - 1

            If LstCodCid.Items(i).ToString = TxtCodCid.Text Then

                DescricaoSitGera = LstDescricaoCid.Items(i).ToString
                LblDescricaoCID.Text = DescricaoSitGera
                ImgValCid.BackgroundImage = My.Resources.check_ok

                TxtNomeMedico.Enabled = True

                TxtNomeMedico.Focus()

            End If

        Next

    End Sub

    Private Sub TxtNumDocumento_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNumDocumento.MaskInputRejected

    End Sub

    Private Sub TxtNumDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtNumDocumento.TextChanged

        If TxtNumDocumento.Text.Length = TxtNumDocumento.Mask.Replace(",", "").Replace("-", "").Replace("/", "").Length Then

            CmbEstadoEmitente.Enabled = True

            ImgValDocMedico.BackgroundImage = My.Resources.check_ok

            'limpa e insere todos os estados de acordo com o IBGE

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

        Else

            CmbEstadoEmitente.Text = ""
            CmbEstadoEmitente.Enabled = False
            ImgvalNumDocMedico.BackgroundImage = My.Resources.alertar_obg

        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        FrmCID.Show(Me)

    End Sub
End Class