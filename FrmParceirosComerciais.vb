Public Class FrmParceirosComerciais

    Public FrmOri As Integer = 0

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged
        If RdbJuridica.Checked = True Then
            If TxtCPF.Text.Length = 14 Then
                TxtIE.Enabled = True
                TxtIE.Focus()
            Else
                TxtIE.Text = ""
                TxtIE.Enabled = False
                Ckisento.Checked = False
            End If
        Else
            If TxtCPF.Text.Length = 11 Then
                TxtIE.Enabled = True
                TxtIE.Focus()
            Else
                TxtIE.Text = ""
                TxtIE.Enabled = False
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Dim _ChaveTemporaria As Integer

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then
            RdbJuridica.Checked = True
            RdbJuridica.Enabled = True
            RdbFisica.Enabled = True

            If FrmOri = 1 Then
                TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
                TxtCPF.Enabled = False

                If TxtCPF.Text.Length = 14 Then
                    LblDocCPF_CPNJ.Text = "CNPJ"
                    LblRG_IE.Text = "IE"
                    Ckisento.Visible = True

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                Else
                    LblDocCPF_CPNJ.Text = "CPF"
                    LblRG_IE.Text = "RG"
                    Ckisento.Visible = False
                    Ckisento.Checked = False

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                End If

            End If

        Else
            RdbFisica.Enabled = False
            RdbFisica.Checked = False
            RdbJuridica.Enabled = False
            RdbJuridica.Checked = False
        End If

    End Sub

    Private Sub RdbJuridica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbJuridica.CheckedChanged

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True

            TxtCPF.Enabled = True
        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False

            TxtCPF.Enabled = True
            TxtIE.Enabled = False

            TxtCPF.Text = ""
        End If

        If FrmOri = 1 Then
            TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
            TxtCPF.Enabled = False
        End If

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

    Dim LqCadastros As New DtCadastroDataContext

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

    Private Sub BttBuscaCep_Click(sender As Object, e As EventArgs) Handles BttBuscaCep.Click

        'LIMPA TODOS OS COMBOX

        CmbPais.Items.Clear()
        CmbEstado.Items.Clear()
        CmbCidade.Items.Clear()
        CmbBairro.Items.Clear()

        LstIdPaisesTodos.Items.Clear()
        LstidEstadoTodos.Items.Clear()
        LstIdCidadeTodos.Items.Clear()
        LstIdBairro.Items.Clear()
        LstdescricaoEstado.Items.Clear()
        LstSiglaEstado.Items.Clear()
        LstdescricaoPais.Items.Clear()
        LstSiglaPais.Items.Clear()

        CmbPais.Text = Nothing
        CmbEstado.Text = Nothing
        CmbCidade.Text = Nothing
        CmbBairro.Text = Nothing
        TxtNumero.Text = Nothing

        TxtNumero.Enabled = False
        CmbPais.Enabled = False
        CmbEstado.Enabled = False
        CmbCidade.Enabled = False
        CmbBairro.Enabled = False

        'busca pelo CEP

        Dim BuscaCep = From Cep In LqCadastros.Enderecos
                       Where Cep.CEP = TxtCep.Text
                       Select Cep.IdBairro, Cep.IdAbreviacao, Cep.IdEndereco, Cep.Descricao

        LstIdEndereço.Items.Clear()
        CmbEndereço.Items.Clear()

        For Each row In BuscaCep.ToList
            LstIdEndereço.Items.Add(row.IdEndereco)
            LstIdBairro.Items.Add(row.IdBairro)
            'busca descricao
            Dim Buscadescricao = From desc In LqCadastros.DescricaoLogradouros
                                 Where desc.IdDescricaoLog = row.IdAbreviacao
                                 Select desc.Abreviacao

            CmbEndereço.Items.Add(Buscadescricao.First & row.Descricao)
        Next

        'busca paises

        Dim BuscaPais = From pai In LqCadastros.Paises
                        Where pai.IdPais Like "*"
                        Select pai.Descricao, pai.Sigla, pai.IdPais

        LstIdPaisesTodos.Items.Clear()
        LstSiglaPais.Items.Clear()
        LstdescricaoPais.Items.Clear()
        CmbPais.Items.Clear()

        For Each row In BuscaPais.ToList

            LstIdPaisesTodos.Items.Add(row.IdPais)
            LstSiglaPais.Items.Add(row.Sigla)
            LstdescricaoPais.Items.Add(row.descricao)
            CmbPais.Items.Add(row.Sigla & " - " & row.descricao)

        Next

        If BuscaCep.Count = 0 Then

            CmbEndereço.Enabled = True
            BttAddEndereço.Enabled = True

            FrmEndereço._CEP = TxtCep.Text

            FrmEndereço.Show(Me)

        ElseIf BuscaCep.Count = 1 Then

            CmbEndereço.Enabled = False
            BttAddEndereço.Enabled = True

            CmbEndereço.SelectedIndex = 0

            'verifica se o bairro esta preenchido

            If LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString = 0 Then
                CmbPais.Enabled = True
                BttAddPais.Enabled = True
            Else
                CmbPais.Enabled = False
                BttAddPais.Enabled = False
                CmbEstado.Enabled = False
                BttAddEstado.Enabled = False
                CmbCidade.Enabled = False
                BttAddCidade.Enabled = False
                CmbBairro.Enabled = False

                'seleciona o restante
                Dim BuscaBairro = From cid In LqCadastros.Bairro
                                  Where cid.IdBairro = Val(LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString)
                                  Select cid.IdCidade, cid.Descricao, cid.IdBairro

                LstIdBairroTodos.Items.Clear()
                CmbBairro.Items.Clear()

                Dim _indexBairro As Integer

                For Each row In BuscaBairro.ToList
                    LstIdBairroTodos.Items.Add(row.IdBairro)
                    CmbBairro.Items.Add(row.descricao)

                    If row.IdBairro = BuscaBairro.First.IdBairro Then
                        _indexBairro = LstIdBairroTodos.Items.Count - 1
                    End If

                Next

                CmbBairro.SelectedIndex = _indexBairro

                'busca cidades

                Dim BuscaCidade = From cid In LqCadastros.Cidade
                                  Where cid.IdCidade Like "*"
                                  Select cid.IdEstado, cid.Descricao, cid.IdCidade

                LstIdCidadeTodos.Items.Clear()
                CmbCidade.Items.Clear()

                Dim _indexCid As Integer

                For Each row In BuscaCidade.ToList

                    LstIdCidadeTodos.Items.Add(row.IdCidade)
                    CmbCidade.Items.Add(row.descricao)

                    If row.IdCidade = BuscaBairro.First.IdCidade Then
                        _indexCid = LstIdCidadeTodos.Items.Count - 1
                    End If

                Next

                CmbCidade.SelectedIndex = _indexCid

                'busca Estados

                Dim BuscaEstado = From cid In LqCadastros.Estados
                                  Where cid.IdEstado Like "*"
                                  Select cid.IdPais, cid.Descricao, cid.Sigla, cid.IdEstado

                LstidEstadoTodos.Items.Clear()
                CmbEstado.Items.Clear()

                Dim _indexEst As Integer

                For Each row In BuscaEstado.ToList

                    LstidEstadoTodos.Items.Add(row.IdEstado)
                    CmbEstado.Items.Add(row.Sigla & " - " & row.descricao)

                    If row.IdEstado = BuscaCidade.First.IdEstado Then
                        _indexEst = LstidEstadoTodos.Items.Count - 1
                    End If

                Next

                CmbEstado.SelectedIndex = _indexEst

                Dim BuscaPaisTodos = From cid In LqCadastros.Paises
                                     Where cid.IdPais Like "*"
                                     Select cid.IdPais, cid.Descricao, cid.Sigla

                LstIdPaisesTodos.Items.Clear()
                CmbPais.Items.Clear()

                Dim _indexPais As Integer

                For Each row In BuscaPaisTodos.ToList

                    LstIdPaisesTodos.Items.Add(row.IdPais)
                    CmbPais.Items.Add(row.Sigla & " - " & row.descricao)

                    If row.IdPais = BuscaEstado.First.IdPais Then
                        _indexPais = LstIdPaisesTodos.Items.Count - 1
                    End If

                Next

                CmbPais.SelectedIndex = _indexPais

                TxtNumero.Enabled = True
                TxtNumero.Focus()

            End If

        ElseIf BuscaCep.Count > 1 Then

            CmbEndereço.Enabled = True
            BttAddEndereço.Enabled = True

        End If

    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then
            TxtComplemento.Enabled = True
            GpContatos.Enabled = True
            BttSalvarColaborador.Enabled = True
            GpTipoParceiro.Enabled = True
        Else
            TxtComplemento.Enabled = False
            GpContatos.Enabled = False
            BttSalvarColaborador.Enabled = False
            GpTipoParceiro.Enabled = False

            RdbPrestador.Checked = False
            RdbSeguradora.Checked = False
            RdbParceiro.Checked = False

            TxtComplemento.Text = ""

            TxtTelefone.Text = ""
            TxtCelular.Text = ""
            TxtEmail.Text = ""

        End If
    End Sub

    Dim LstIdFuncionarios As New ListBox

    Private Sub BttSalvarColaborador_Click(sender As Object, e As EventArgs) Handles BttSalvarColaborador.Click

        Dim _Select As String = CmbColaboradores.Text

        Dim TipoParceiro As Integer

        If RdbParceiro.Checked = True Then

            TipoParceiro = 0

        ElseIf RdbSeguradora.Checked = True Then

            TipoParceiro = 1

        ElseIf RdbPrestador.Checked = True Then

            TipoParceiro = 2

        End If


        If CmbColaboradores.Text = "" Then
            'salva colaborador

            LqCadastros.InsereParceiroComercial(TxtNomeCompleto.Text, TxtCPF.Text, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, LstIdEndereço.Items(CmbEndereço.SelectedIndex).ToString, CmbEndereço.Text, TxtNumero.Text, TxtComplemento.Text, CmbBairro.Text, CmbCidade.Text, CmbEstado.Text, CmbPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TipoParceiro)

            _Select = TxtNomeCompleto.Text

        Else

            LqCadastros.AtualizaParceiro(LstIdFuncionarios.Items(CmbColaboradores.SelectedIndex).ToString, TxtNomeCompleto.Text, TxtCPF.Text, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, LstIdEndereço.Items(CmbEndereço.SelectedIndex).ToString, CmbEndereço.Text, TxtNumero.Text, TxtComplemento.Text, CmbBairro.Text, CmbCidade.Text, CmbEstado.Text, CmbPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TipoParceiro)

        End If

        'carrega colaboradores

        Dim BuscaColaboradores = From col In LqCadastros.ParceirosComerciais
                                 Where col.IdParceiro Like "*"
                                 Select col.RazaoSocial_nome, col.IdParceiro

        LstIdFuncionarios.Items.Clear()
        CmbColaboradores.Items.Clear()

        For Each row In BuscaColaboradores.ToList
            LstIdFuncionarios.Items.Add(row.IdParceiro)
            CmbColaboradores.Items.Add(row.RazaoSocial_nome)
        Next

        CmbColaboradores.SelectedItem = _Select

        'limpa todos
        LimpaTodos()

        GpDadosPessoais.Enabled = False
        BttAddColaborador.Enabled = True
        BttSalvarColaborador.Enabled = False
        CmbColaboradores.Enabled = True
        BttCancelar.Enabled = False

    End Sub
    Private Sub LimpaTodos()
        TxtNomeCompleto.Text = ""
        RdbJuridica.Checked = False
        RdbFisica.Checked = False

        TxtCPF.Text = ""
        TxtIE.Text = ""
        CmbEndereço.Text = ""
        CmbBairro.Text = ""
        CmbCidade.Text = ""
        CmbEstado.Text = ""
        CmbPais.Text = ""
        TxtNumero.Text = ""
        TxtNumero.Enabled = False
        TxtComplemento.Enabled = False

        TxtNomeCompleto.Enabled = False
        CmbEndereço.Enabled = False

    End Sub

    Private Sub RdbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFisica.CheckedChanged

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True

            TxtCPF.Enabled = True
        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False

            TxtCPF.Enabled = True
            TxtIE.Enabled = False

            TxtCPF.Text = ""
        End If

        If FrmOri = 1 Then
            TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
            TxtCPF.Enabled = False
        End If

    End Sub

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged
        LstIdEndereço.Items.Clear()
        CmbEndereço.Items.Clear()
        CmbEndereço.Text = ""

        If TxtCep.Text.Length >= 8 Then
            BttBuscaCep.Enabled = True
        Else
            BttBuscaCep.Enabled = False
        End If
    End Sub

    Private Sub FrmNovoCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Cursor = Cursors.AppStarting
        FrmPrincipal.Cursor = Cursors.Arrow

        'carrega colaboradores

        Dim BuscaColaboradores = From col In LqCadastros.ParceirosComerciais
                                 Where col.IdParceiro Like "*"
                                 Select col.RazaoSocial_nome, col.IdParceiro

        LstIdFuncionarios.Items.Clear()
        CmbColaboradores.Items.Clear()

        For Each row In BuscaColaboradores.ToList
            LstIdFuncionarios.Items.Add(row.IdParceiro)
            CmbColaboradores.Items.Add(row.RazaoSocial_nome)
        Next

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub CmbColaboradores_Click(sender As Object, e As EventArgs) Handles CmbColaboradores.Click

    End Sub

    Private Sub CmbColaboradores_TextChanged(sender As Object, e As EventArgs) Handles CmbColaboradores.TextChanged

        If CmbColaboradores.Items.Contains(CmbColaboradores.Text) Then
            BttEditColaborador.Enabled = True
            BttDesligar.Enabled = True
        Else
            BttEditColaborador.Enabled = False
            BttDesligar.Enabled = False
        End If

    End Sub

    Private Sub BttAddColaborador_Click(sender As Object, e As EventArgs) Handles BttAddColaborador.Click

        _ChaveTemporaria = 9 & TimeOfDay.Hour & TimeOfDay.Minute & TimeOfDay.Second

        CmbColaboradores.Text = ""

        BttAddColaborador.Enabled = False
        BttEditColaborador.Enabled = False
        BttSalvarColaborador.Enabled = False
        BttCancelar.Enabled = True
        BttDesligar.Enabled = False
        CmbColaboradores.Enabled = False

        GpDadosPessoais.Enabled = True

        TxtNomeCompleto.Enabled = True

    End Sub

    Private Sub BttEditColaborador_Click(sender As Object, e As EventArgs) Handles BttEditColaborador.Click

        _ChaveTemporaria = LstIdFuncionarios.Items(CmbColaboradores.SelectedIndex).ToString

        'busca colaborador selecionado

        BttAddColaborador.Enabled = False
        BttEditColaborador.Enabled = False
        BttCancelar.Enabled = True
        BttDesligar.Enabled = False
        CmbColaboradores.Enabled = False

        GpDadosPessoais.Enabled = True
        TxtNomeCompleto.Enabled = True

        Dim BUscaColaborador = From col In LqCadastros.ParceirosComerciais
                               Where col.IdParceiro = LstIdFuncionarios.Items(CmbColaboradores.SelectedIndex).ToString
                               Select col.TipoParceiro, col.RazaoSocial_nome, col.CPF_CNPJ, col.RG_IE, col.TipoPersonalidade, col.CEP, col.Numero, col.Complemento, col.Telefone, col.Celular, col.Email

        TxtNomeCompleto.Text = BUscaColaborador.First.RazaoSocial_nome

        RdbJuridica.Checked = BUscaColaborador.First.TipoPersonalidade
        TxtCPF.Text = BUscaColaborador.First.CPF_CNPJ
        If BUscaColaborador.First.RG_IE = "Isento" Then
            Ckisento.Checked = True
        End If
        TxtIE.Text = BUscaColaborador.First.RG_IE
        TxtCep.Text = BUscaColaborador.First.CEP
        BttBuscaCep.PerformClick()
        TxtNumero.Text = BUscaColaborador.First.Numero
        TxtComplemento.Text = BUscaColaborador.First.Complemento
        TxtTelefone.Text = BUscaColaborador.First.Telefone
        TxtCelular.Text = BUscaColaborador.First.Celular
        TxtEmail.Text = BUscaColaborador.First.Email

        If BUscaColaborador.First.TipoParceiro = 0 Then

            RdbParceiro.Checked = True

        ElseIf BUscaColaborador.First.TipoParceiro = 1 Then

            RdbSeguradora.Checked = True

        ElseIf BUscaColaborador.First.TipoParceiro = 2 Then

            RdbPrestador.Checked = True

        End If
    End Sub

    Private Sub BttCancelar_Click(sender As Object, e As EventArgs) Handles BttCancelar.Click
        LimpaTodos()

        GpDadosPessoais.Enabled = False
        BttAddColaborador.Enabled = True
        BttSalvarColaborador.Enabled = False
        CmbColaboradores.Enabled = True
        BttCancelar.Enabled = False

    End Sub

    Private Sub TxtCep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCep.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttBuscaCep.PerformClick()
        End If
    End Sub

End Class