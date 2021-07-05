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
Imports Newtonsoft.Json

Public Class FrmEntradaVeículo

    Dim LqGeral As New DtCadastroDataContext
    Public _IdCliente As Integer

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TxtDocumento.Text.Length = 11 Or TxtDocumento.Text.Length = 14 Then

            Me.Cursor = Cursors.WaitCursor

            TxtDocumento.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

            Dim Documento As String = TxtDocumento.Text

            Documento = Documento.Replace(" ", "")

            Dim BuscaCliente = From cli In LqGeral.Clientes
                               Where cli.CPF_CNPJ Like Documento
                               Select cli.RazaoSocial_nome, cli.Endereco, cli.Numero, cli.Complemento, cli.Bairro, cli.Estado, cli.Pais, cli.CIdade, cli.CEP, cli.IdCliente

            If BuscaCliente.Count > 0 Then

                _IdCliente = BuscaCliente.First.IdCliente
                LblNomeCompleto.Text = BuscaCliente.First.RazaoSocial_nome
                LblEndereço.Text = BuscaCliente.First.Endereco & ", " & BuscaCliente.First.Numero

                If BuscaCliente.First.Complemento <> "" Then
                    LblEndereço.Text &= " - " & BuscaCliente.First.Complemento
                End If

                LblBairro.Text = BuscaCliente.First.Bairro
                LblCidade.Text = BuscaCliente.First.CIdade
                LblEstado.Text = BuscaCliente.First.Estado
                LblPaís.Text = BuscaCliente.First.Pais
                LblCep.Text = BuscaCliente.First.CEP

                If LblCep.Text.Length >= 8 Then

                    'Try
                    Me.Cursor = Cursors.WaitCursor

                    Dim ds As New DataSet()
                    Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", BuscaCliente.First.CEP)
                    ds.ReadXml(xml)
                    LblEndereço.Text = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & BuscaCliente.First.Numero
                    LblBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
                    LblCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
                    LblEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()
                    LblPaís.Text = "Brasil"

                    Me.Cursor = Cursors.Arrow

                Else

                    LblEndereço.Text = ""
                    LblBairro.Text = ""
                    LblCidade.Text = ""
                    LblEstado.Text = ""
                    LblPaís.Text = ""

                End If

                Me.Cursor = Cursors.Arrow

                RdbSegurado.Enabled = True
                RdbTerceiro.Enabled = True

                If RdbSeguradora.Checked = False Then
                    TxtPlaca.Enabled = True
                    TxtPlaca.Focus()
                End If

            Else

                Me.Cursor = Cursors.Arrow

                TxtDocumento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

                If TxtDocumento.Text.Length = 11 Then

                    FrmClientes.RdbFisica.Checked = True

                Else

                    FrmClientes.RdbJuridica.Checked = True

                End If

                FrmClientes.FrmOri = 1

                'FrmClientes.BttAddColaborador.PerformClick()
                FrmClientes.TxtNomeCompleto.Enabled = True

                FrmClientes.Show(Me)

            End If

            TxtDocumento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

        End If
    End Sub

    Private Sub TxtDocumento_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDocumento.MaskInputRejected

    End Sub

    Private Sub TxtDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtDocumento.TextChanged

        BttBuscarCliente.Enabled = False

        If TxtDocumento.Text.Length = 11 Or TxtDocumento.Text.Length = 14 Then

            BttBuscarCliente.Enabled = True

        End If

    End Sub

    Private Sub TxtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDocumento.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttBuscarCliente.PerformClick()

        End If

    End Sub

    Public LengthPlaca As Integer = 7
    Dim LqOficina As New LqOficinaDataContext

    Public LstSeguradoras As New ListBox
    Public LstParceiros As New ListBox
    Public IdVeiculo As Integer
    Private Sub BttBuscarPlaca_Click(sender As Object, e As EventArgs) Handles BttBuscarPlaca.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If TxtPlaca.Text.Length = LengthPlaca Then

            Me.Cursor = Cursors.WaitCursor

            'busca placa no servidor PlacaAPI

            'verifica lista de clientes e atualiza ou cria

            Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_placa_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Placa=" & TxtPlaca.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DadosVeiculo))("[" & content & "]")

            If read.Count > 0 Then

                IdVeiculo = 0

                LblChassi.Text = read.Item(0).Chassi
                LblAno.Text = read.Item(0).Ano

                LblFabricante.Text = read.Item(0).CarMake.CurrentTextValue
                LblModelo.Text = read.Item(0).Modelo
                LblVersão.Text = read.Item(0).Power

                LblCombustível.Text = read.Item(0).Fuel
                LblTipo.Text = read.Item(0).Type
                LblCC.Text = read.Item(0).EngineCC
                LblCor.Text = read.Item(0).Colour

                Me.Cursor = Cursors.Arrow

                If RdbSeguradora.Checked = True Then

                    Dim BuscaParceiro = From seg In LqOficina.Seguradoras
                                        Where seg.Tipo Like "Seguradora"
                                        Select seg.NomeFantasia, seg.IdCadSeguradora

                    CmbSeguradoras.Text = ""
                    LstSeguradoras.Items.Clear()
                    CmbSeguradoras.Items.Clear()

                    For Each row In BuscaParceiro.ToList

                        LstSeguradoras.Items.Add(row.IdCadSeguradora)
                        CmbSeguradoras.Items.Add(row.NomeFantasia)

                    Next

                    BttSalvar.Enabled = False

                ElseIf RdbParticular.Checked = True Then

                    BttSalvar.Enabled = True

                ElseIf RdbParceiro.Checked = True Then

                    Dim BuscaParceiro = From seg In LqOficina.Seguradoras
                                        Where seg.Tipo Like "Parceiro comercial"
                                        Select seg.NomeFantasia, seg.IdCadSeguradora

                    LstParceiros.Items.Clear()
                    ComboBox1.Items.Clear()

                    For Each row In BuscaParceiro.ToList

                        LstParceiros.Items.Add(row.IdCadSeguradora)
                        ComboBox1.Items.Add(row.NomeFantasia)

                    Next

                    BttSalvar.Enabled = False

                End If

                If RdbOrçamentoRápido.Checked = True Then

                    BttSalvar.Enabled = True

                End If

            Else

                Me.Cursor = Cursors.Arrow
                FrmVeiculo.Show(Me)

            End If

            'busca no sinesp

            'ConsultarPlaca(TxtPlaca.Text.ToString)

        End If

    End Sub

    Private Sub TxtPlaca_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs)

    End Sub

    Private Sub TxtPlaca_TextChanged(sender As Object, e As EventArgs) Handles TxtPlaca.TextChanged

        LblChassi.Text = Nothing
        LblAno.Text = Nothing

        LblFabricante.Text = Nothing
        LblModelo.Text = Nothing
        LblVersão.Text = Nothing

        LblCC.Text = Nothing
        LblCor.Text = Nothing
        LblCombustível.Text = Nothing
        LblTipo.Text = Nothing

        If TxtPlaca.Text.Length = LengthPlaca Then

            BttBuscarPlaca.Enabled = True

        End If

    End Sub

    Private Sub TxtPlaca_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPlaca.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttBuscarPlaca.PerformClick()

        End If

    End Sub

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

    Private Sub CheckOption()

        If RdbParceiro.Checked = True Then

            TxtDocumento.Enabled = False

            RdbSegurado.Visible = False
            RdbTerceiro.Visible = False

            PnnParceiro.Visible = True

            PnnSeguradora.Visible = False
            LblItem.Visible = False

        ElseIf RdbSeguradora.Checked = True Then

            TxtDocumento.Enabled = True

            RdbSegurado.Visible = True
            RdbTerceiro.Visible = True

            PnnSeguradora.Visible = True

            PnnParceiro.Visible = False
            LblItem.Visible = False

            'busca seguradoras vinculadas 

            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaSeguradoras = From seg In LqOficina.Seguradoras
                                   Where seg.IdCadSeguradora Like "*"
                                   Select seg.NomeFantasia

            If BuscaSeguradoras.Count = 0 Then
                If MsgBox("Não existem seguradoras cadastradas na base de dados.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    RdbParticular.Checked = True
                End If
            End If

            ElseIf RdbParticular.Checked = True Then

            RdbSegurado.Visible = False
            RdbTerceiro.Visible = False

            TxtDocumento.Enabled = True

            LblItem.Visible = True

            PnnParceiro.Visible = False
            PnnSeguradora.Visible = False

        ElseIf RdbOrçamentoRápido.Checked = True Then

            RdbSegurado.Visible = False
            RdbTerceiro.Visible = False

            TxtDocumento.Enabled = False

            LblItem.Visible = True

            PnnParceiro.Visible = False
            PnnSeguradora.Visible = False

            TxtPlaca.Enabled = True

            TxtPlaca.Focus()

        End If

    End Sub
    Private Sub RdbParceiro_CheckedChanged(sender As Object, e As EventArgs) Handles RdbParceiro.CheckedChanged
        CheckOption()
    End Sub

    Private Sub RdbSeguradora_CheckedChanged(sender As Object, e As EventArgs) Handles RdbSeguradora.CheckedChanged
        CheckOption()
    End Sub

    Private Sub RdbParticular_CheckedChanged(sender As Object, e As EventArgs) Handles RdbParticular.CheckedChanged
        CheckOption()
    End Sub

    Private Sub RdbSegurado_CheckedChanged(sender As Object, e As EventArgs) Handles RdbSegurado.CheckedChanged
        If RdbSegurado.Visible = True Then
            TxtPlaca.Enabled = True

            PnnSeguradora.Visible = True
            PnnSeguradora.Dock = DockStyle.Fill
            LblItem.Visible = False

            TxtPlaca.Focus()
        ElseIf RdbTerceiro.Visible = True Then
            TxtPlaca.Enabled = True

            PnnParceiro.Visible = False
            PnnParceiro.Dock = DockStyle.Fill

            LblItem.Visible = False

            TxtPlaca.Focus()

        ElseIf RdbParticular.Visible = True Then

            TxtPlaca.Enabled = True

            PnnSeguradora.Visible = False
            PnnParceiro.Visible = False

            LblItem.Visible = True
            LblItem.Dock = DockStyle.Fill

            TxtPlaca.Focus()

        End If
    End Sub

    Private Sub RdbTerceiro_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTerceiro.CheckedChanged
        If RdbSegurado.Visible = True Then
            TxtPlaca.Enabled = True
            TxtPlaca.Focus()
        ElseIf RdbTerceiro.Visible = True Then
            TxtPlaca.Enabled = True
            TxtPlaca.Focus()
        End If
    End Sub

    Private Sub CmbSeguradoras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSeguradoras.SelectedIndexChanged

        If CmbSeguradoras.Items.Contains(CmbSeguradoras.Text) Then
            TxtNumeroSinistro.Enabled = True
            TxtFranquia.Enabled = True
            BttSalvar.Enabled = True

            'busca item obrgatórios para esta seguradora

            Dim BuscaItems = From ite In LqOficina.ItemObgSeguradora
                             Where ite.IdCadSeguradora = LstSeguradoras.Items(CmbSeguradoras.SelectedIndex).ToString
                             Select ite.Descricao, ite.IdItemObgSeguradora, ite.tipo

            DtItensParceiros.Rows.Clear()

            For Each row In BuscaItems.ToList

                DtItensParceiros.Rows.Add(My.Resources.alert_icon_icons_com_52395, row.IdItemObgSeguradora, row.Descricao, row.tipo, My.Resources.Cancel_40972)

            Next

        Else
            TxtNumeroSinistro.Enabled = False
            TxtFranquia.Enabled = False
            BttSalvar.Enabled = False

            TxtNumeroSinistro.Text = Nothing
            TxtFranquia.Text = Nothing
        End If

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Me.Cursor = Cursors.WaitCursor

        'insere a liberação do veículo para vistoria

        Dim LqBase As New DtCadastroDataContext

        If RdbOrçamentoRápido.Checked = True Then

            _IdCliente = 0

            'Cria um orçamento rapido para o veiculo

            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            LqBase.InsereOrcamentoRapido(Today.Date, Now.TimeOfDay, IdVeiculo, 0, False)

        End If

        'insere veiculo para vistoria
        Dim HrPadrao As Date = Today.Date & " " & "11:11"
        LqOficina.InsereNovaVistoriaVeiculo(IdVeiculo, _IdCliente, "1111-11-11", HrPadrao.TimeOfDay, 0, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, False, 0, HrPadrao.TimeOfDay, "1111-11-11")

        If RdbSeguradora.Checked = True Then
            LqOficina.InsereNovaSeguradora_Entrada(_IdCliente, LstSeguradoras.Items(CmbSeguradoras.SelectedIndex).ToString, Today.Date, Now.TimeOfDay, TxtNumeroSinistro.Text, TxtFranquia.Text)
        ElseIf RdbParceiro.Checked = True Then

        End If

        Dim _IdVeiculo As Integer = 0

        'cria veiculo na base e on line
        'insere nova solicitacao

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaIdExternoCliente = From cli In LqBase.Clientes
                                    Where cli.IdCliente = _IdCliente
                                    Select cli.IdClienteExt

        Dim baseUrl As String = "http://www.iarasoftware.com.br/create_veiculo_local.php?Placa=" & TxtPlaca.Text & "&Chassi=" & LblChassi.Text & "&Renavan=" & "" & "&IdModelo=0&Modelo=" & LblModelo.Text & "&IdFabricante=0&Fabricante=" & LblFabricante.Text & "&IdVersao=0&Versao=" & LblCombustível.Text & "/" & LblCC.Text & "/" & LblVersão.Text & "&AnoFabricacao=" & LblAno.Text & "&AnoModelo=" & LblAno.Text & "&IdCliente=" & BuscaIdExternoCliente.First & "&ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdCor=0&Cor=" & LblCor.Text & "&IdCategoria=0&Categoria=" & LblTipo.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)
        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

        LqOficina.InsereNovoVeiculo(_IdCliente, TxtPlaca.Text, 0, LblFabricante.Text, 0, LblModelo.Text, 0, LblCombustível.Text & "/" & LblCC.Text & "/" & LblVersão.Text, "", LblChassi.Text, LblAno.Text, LblAno.Text, 0, LblCor.Text, read.Item(0).Id)

        'cria primeira solicitacao

        Dim baseUrl_sol As String = "http://www.iarasoftware.com.br/create_solicitacao_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdSolicitante=" & FrmPrincipal.IdUsuario & "&Solicitante=" & FrmPrincipal.LblNomeUsuario.Text & "&IdVeiculo=" & read.Item(0).Id & "&Placa=" & TxtPlaca.Text & "&Status=0&IdTecnico=0&Tecnico=ND&IdCliente=" & _IdCliente & "&NomeCliente=" & LblNomeCompleto.Text & "&DataInicio=" & Today.Date.ToString.Replace("/", "-") & "&HoraInicio=" & Now.TimeOfDay.ToString & "&Tipo=0"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient_sol = New WebClient()
        Dim content_sol = syncClient_sol.DownloadString(baseUrl_sol)

        FrmPrincipal.CarregaDashboard()

        'If MsgBox("BOT ligado") = MsgBoxResult.Ok Then

        'LqOficina.AtualizaRecebimentoPeloTecnicoNovaVistoriaVeiculo(IdVeiculo, 1, True, Today.TimeOfDay, Today.Date)

        Me.Close()


    End Sub

    Private Sub TxtNumeroSinistro_TextChanged(sender As Object, e As EventArgs) Handles TxtNumeroSinistro.TextChanged

    End Sub

    Private Sub BttTeste_Click(sender As Object, e As EventArgs)

        FrmVistoriavb.Show(Me)
        FrmVistoriavb.LblTitulo.Text = "teste OK"

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        If ComboBox1.Items.Contains(ComboBox1.Text) Then

            BttSalvar.Enabled = True

            'busca item obrgatórios para esta seguradora

            Dim BuscaItems = From ite In LqOficina.ItemObgSeguradora
                             Where ite.IdCadSeguradora = LstParceiros.Items(ComboBox1.SelectedIndex).ToString
                             Select ite.Descricao, ite.IdItemObgSeguradora, ite.tipo

            DtItensParceiros.Rows.Clear()

            For Each row In BuscaItems.ToList

                DtItensParceiros.Rows.Add(My.Resources.alert_icon_icons_com_52395, row.IdItemObgSeguradora, row.Descricao, row.tipo, My.Resources.Cancel_40972)

            Next

        Else

            DtItensParceiros.Rows.Clear()

            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub RdbOrçamentoRápido_CheckedChanged(sender As Object, e As EventArgs) Handles RdbOrçamentoRápido.CheckedChanged
        CheckOption()
    End Sub

    Private Sub TxtDocumento_GotFocus(sender As Object, e As EventArgs) Handles TxtDocumento.GotFocus

    End Sub

    Private Sub TxtDocumento_Click(sender As Object, e As EventArgs) Handles TxtDocumento.Click

        If TxtDocumento.Text <> "" Then

            Dim Valor As Integer = TxtDocumento.Text.Length
            TxtDocumento.SelectionStart = Valor

        Else

            TxtDocumento.SelectionStart = 0

        End If

    End Sub
End Class