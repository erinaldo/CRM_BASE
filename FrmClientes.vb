Imports System.Net
Imports Newtonsoft.Json

Public Class FrmClientes

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then
            'RdbJuridica.Checked = True
            RdbJuridica.Enabled = False
            RdbFisica.Enabled = False

            If Application.OpenForms.OfType(Of FrmEntradaVeículo)().Count() > 0 Then

                TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
                TxtCPF.Enabled = False

                If TxtCPF.Text.Length = 14 Then
                    LblDocCPF_CPNJ.Text = "CNPJ"
                    LblRG_IE.Text = "IE"
                    Ckisento.Visible = True

                    TxtApelido.Enabled = True

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                    'RdbJuridica.Checked = True
                Else
                    LblDocCPF_CPNJ.Text = "CPF"
                    LblRG_IE.Text = "RG"

                    TxtApelido.Enabled = False
                    TxtApelido.Text = TxtNomeCompleto.Text

                    Ckisento.Visible = False
                    Ckisento.Checked = False
                    RdbFisica.Checked = True

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                End If

            ElseIf Application.OpenForms.OfType(Of FrmNovoORçamento)().Count() > 0 Then

                TxtCPF.Enabled = True

            ElseIf Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                RdbJuridica.Checked = True
                TxtApelido.Enabled = True

            End If

            If RdbFisica.Checked = True Then
                TxtApelido.Text = TxtNomeCompleto.Text
            End If

        Else

            RdbFisica.Checked = False
            RdbJuridica.Checked = False
            TxtCPF.Enabled = False
            TxtCPF.Text = ""
            TxtApelido.Enabled = False
            TxtApelido.Text = ""

        End If

    End Sub
    Private Sub RdbJuridica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbJuridica.CheckedChanged

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True

            'TxtCPF.Enabled = True
        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False

            TxtCPF.Enabled = False
            TxtIE.Enabled = False

            'TxtCPF.Text = ""
        End If

        TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
        TxtCPF.Enabled = False

    End Sub
    Private Sub Ckisento_CheckedChanged(sender As Object, e As EventArgs) Handles Ckisento.CheckedChanged
        If Ckisento.Checked = True Then
            TxtIE.Enabled = False
            TxtIE.Text = "Isento"
            TxtCep.Focus()
        Else
            TxtIE.Enabled = True
            TxtIE.Text = ""
        End If
    End Sub
    Private Sub TxtIE_TextChanged(sender As Object, e As EventArgs) Handles TxtIE.TextChanged
        If TxtIE.Text <> "" Then
            TxtCep.Enabled = True
        Else
            TxtCep.Text = ""
            TxtCep.Enabled = False
        End If
    End Sub
    Dim LstIdFuncionarios As New ListBox

    Private Sub LimpaTodos()
        TxtNomeCompleto.Text = ""
        RdbJuridica.Checked = False
        RdbFisica.Checked = False

        TxtCPF.Text = ""
        TxtIE.Text = ""
        TxtEndereco.Text = ""
        TxtBairro.Text = ""
        TxtCidade.Text = ""
        TxtEstado.Text = ""
        TxtPais.Text = ""
        TxtNumero.Text = ""
        TxtNumero.Enabled = False
        TxtComplemento.Enabled = False

        TxtNomeCompleto.Enabled = False

    End Sub
    Private Sub RdbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFisica.CheckedChanged

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True

            TxtCPF.Enabled = False
            TxtApelido.Visible = True

        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False

            TxtCPF.Enabled = False
            TxtIE.Enabled = False

            If TxtCPF.Text <> "" Then
                TxtIE.Enabled = True
            End If
            TxtApelido.Visible = False

        End If

        If FrmOri = 1 Then
            TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
            TxtCPF.Enabled = False
        End If

    End Sub

    Public FrmOri As Integer

    Dim LqCadastros As New DtCadastroDataContext
    Dim LqBase As New DtCadastroDataContext

    Public LstIdEndereço As New ListBox
    Public LstIdBairro As New ListBox

    Public LstIdPaisesTodos As New ListBox
    Public LstSiglaPais As New ListBox
    Public LstdescricaoPais As New ListBox

    Public LstIdCidadeTodos As New ListBox

    Public LstidEstadoTodos As New ListBox
    Public LstSiglaEstado As New ListBox
    Public LstdescricaoEstado As New ListBox

    Public LstIdBairroTodos As New ListBox
    Public _IdEndereco As Integer

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TxtCep.Text.Length = 8 Then

            Dim _Endereco As String = ""

            'busca dados do 
            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
            ds.ReadXml(xml)

            TxtEndereco.Text = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
            TxtBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            TxtCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            TxtEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()

            TxtNumero.Enabled = True

        Else

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
    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then

            TxtComplemento.Enabled = True

            TxtTelefone.Enabled = True

        Else

            TxtComplemento.Enabled = False
            TxtTelefone.Enabled = False

            TxtComplemento.Text = ""
            TxtTelefone.Text = ""

        End If

    End Sub
    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged

        If TxtTelefone.Text <> "" And TxtEmail.Text <> "" Then

            BttSalvarColaborador.Enabled = True

            BttFunções.Enabled = True
            BttSetores.Enabled = True

        ElseIf TxtTelefone.Text = "" Or TxtEmail.Text = "" Then

            BttSalvarColaborador.Enabled = False

            BttFunções.Enabled = False
            BttSetores.Enabled = False

        End If

    End Sub

    Public IdCliente As Integer = 0
    Private Sub TxtCPF_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged

        If TxtCPF.Enabled = True Then

            If RdbFisica.Checked = True Then

                If TxtCPF.Text.Length <= 11 Then
                    TxtIE.Enabled = True
                Else
                    TxtIE.Text = ""
                    TxtIE.Enabled = False
                End If

            Else

                If TxtCPF.Text.Length = 14 Then

                    TxtIE.Enabled = True
                    Ckisento.Checked = False
                    Ckisento.Enabled = True
                    Ckisento.Visible = True

                ElseIf TxtCPF.Text.Length < 12 Then

                    TxtIE.Text = ""
                    TxtIE.Enabled = False
                    Ckisento.Checked = False
                    Ckisento.Checked = False
                    Ckisento.Visible = False

                    TxtCPF.Mask = "000,000,000-000"

                ElseIf TxtCPF.Text.Length > 11 Then

                    TxtCPF.Mask = "00,000,000/0000-00"

                End If

            End If
        End If

    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtPais_TextChanged(sender As Object, e As EventArgs) Handles TxtPais.TextChanged



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttSalvarColaborador.Click

        If IdCliente = 0 Then

            LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Documento As String = ""

            If TxtCPF.Text.Length = 11 Then

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text.Replace(" ", "")

            Else

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text

            End If

            'salva colaborador

            LqCadastros.InsereCliente(TxtNomeCompleto.Text, Documento, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, 0, TxtEndereco.Text, TxtNumero.Text, TxtComplemento.Text, TxtBairro.Text, TxtCidade.Text, TxtEstado.Text, TxtPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, 0, TxtApelido.Text)

            'pega ultimo Id

            Dim BuscaUltimoID = From ult In LqBase.Clientes
                                Where ult.IdCliente Like "*"
                                Select ult.IdCliente
                                Order By IdCliente Descending

            Dim UltimID As Integer = BuscaUltimoID.First

            'atualiza id do cliente 

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.AtualizaSetorIdClientetodos(IdCliente)

            'insere na base on-line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_cliente_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Doc=" & Documento & "&NomeCliente=" & TxtNomeCompleto.Text & "&email=" & TxtEmail.Text & "&celular=" & TxtCelular.Text & "&cep=" & TxtCep.Text & "&endereco=" & TxtEndereco.Text & "&bairro=" & TxtBairro.Text & "&cidade=" & TxtCidade.Text & "&estado=" & TxtEstado.Text & "&pais=" & TxtPais.Text & "&numero=" & TxtNumero.Text & "&complemento=" & TxtComplemento.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                LqCadastros.AtualizaIdVinculoExtCliente(UltimID, read.Item(0).Id)

            End If
            'carrega colaboradores

            If Application.OpenForms.OfType(Of FrmEntradaVeículo)().Count() > 0 Then

                FrmEntradaVeículo.TxtDocumento.Text = TxtCPF.Text
                FrmEntradaVeículo.BttBuscarCliente.PerformClick()

            ElseIf Application.OpenForms.OfType(Of FrmNovoORçamento)().Count() > 0 Then

                'atualiza 

                Dim LqComercial As New LqComercialDataContext
                LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                Dim BUscaCliente = From cli In LqBase.Clientes
                                   Where cli.CPF_CNPJ Like TxtCPF.Text
                                   Select cli.IdCliente

                LqComercial.AtualizaClienteOrcameto(FrmNovoORçamento.LblNumOrcamento.Text, BUscaCliente.First)

                FrmNovoORçamento.Close()

            ElseIf Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                FrmListaClientes.CarregaInicio()

            End If

        Else

            'atualiza dados

            If Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                FrmListaClientes.CarregaInicio()

            End If

        End If

        Me.Close()

    End Sub

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'verifica a origem do form

        If Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then
            'adiciona nos vinculos
            BttSetores.Visible = True
            BttFunções.Visible = True
            BttColaboradores.Visible = True

            Label4.Text = "Razão Social"

        Else

            BttSetores.Visible = False
            BttFunções.Visible = False
            BttColaboradores.Visible = False

            Label4.Text = "Nome completo"

        End If

    End Sub

    Private Sub TxtApelido_TextChanged(sender As Object, e As EventArgs) Handles TxtApelido.TextChanged

        If TxtApelido.Text <> "" Then
            TxtCPF.Enabled = True
        Else
            TxtCPF.Enabled = False
        End If

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub

    Private Sub TxtTelefone_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefone.MaskInputRejected

    End Sub

    Private Sub TxtTelefone_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefone.TextChanged

        If TxtTelefone.Text.Length < 11 Then
            TxtTelefone.Mask = "(00) 0000-00000"
        ElseIf TxtTelefone.Text.Length = 11 Then
            TxtTelefone.Mask = "(00) 0 0000-00000"
        ElseIf TxtTelefone.Text.Length = 12 Then
            TxtTelefone.Mask = "(00) 00 0000-00000"
        ElseIf TxtTelefone.Text.Length = 13 Then
            TxtTelefone.Mask = "(00) 000 0000-00000"
        End If

        If TxtTelefone.Text.Length = 10 Then
            TxtCelular.Enabled = True
            TxtEmail.Enabled = True
        Else
            TxtCelular.Enabled = False
            TxtEmail.Enabled = False
            TxtCelular.Text = ""
            TxtEmail.Text = ""
        End If

    End Sub

    Private Sub TxtCelular_TextChanged(sender As Object, e As EventArgs) Handles TxtCelular.TextChanged

        If TxtCelular.Text.Length < 11 Then
            TxtCelular.Mask = "(00) 0000-00000"
        ElseIf TxtCelular.Text.Length = 11 Then
            TxtCelular.Mask = "(00) 0 0000-00000"
        ElseIf TxtCelular.Text.Length = 12 Then
            TxtCelular.Mask = "(00) 00 0000-00000"
        ElseIf TxtCelular.Text.Length = 13 Then
            TxtCelular.Mask = "(00) 000 0000-00000"
        End If

    End Sub

    Private Sub BttSetores_Click(sender As Object, e As EventArgs) Handles BttSetores.Click

        Me.Cursor = Cursors.WaitCursor

        FrmSetoresClientes.IdCliente = IdCliente
        FrmSetoresClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFunções_Click(sender As Object, e As EventArgs) Handles BttFunções.Click

        Me.Cursor = Cursors.WaitCursor

        FrmFuncoesClientes.IdCliente = IdCliente
        FrmFuncoesClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttColaboradores_Click(sender As Object, e As EventArgs) Handles BttColaboradores.Click

        Me.Cursor = Cursors.WaitCursor

        FrmColaboradoresClientes.IdCliente = IdCliente

        FrmColaboradoresClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

End Class