Imports System.Net
Imports Newtonsoft.Json

Public Class FrmCadColaboradores

    Dim LqCadastros As New DtCadastroDataContext

    'listas ID

    Public LstIdNacionalidades As New ListBox

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)

        _ChaveTemporaria = 9 & TimeOfDay.Hour & TimeOfDay.Minute & TimeOfDay.Second

        GpDadosPessoais.Enabled = True

        TxtNomeCompleto.Enabled = True

        'busca nacionalidades

        Dim BuscaNac = From nac In LqCadastros.Nacionalidades
                       Where nac.IdNacionalidade Like "*"
                       Select nac.Nacionalidade, nac.IdNacionalidade

        LstIdNacionalidades.Items.Clear()
        CmbNacionalidade.Items.Clear()

        For Each row In BuscaNac.ToList

            LstIdNacionalidades.Items.Add(row.IdNacionalidade)
            CmbNacionalidade.Items.Add(row.Nacionalidade)

        Next

        'busca todos os vinculos

        Dim BuscaVinculo = From vin In LqCadastros.VinculosParentais
                           Where vin.IDVinculoParentesco Like "*"
                           Select vin.Descricao, vin.IDVinculoParentesco

        LstIdVinculoParental.Items.Clear()
        CmbVinculo.Items.Clear()

        For Each row In BuscaVinculo.ToList
            LstIdVinculoParental.Items.Add(row.IDVinculoParentesco)
            CmbVinculo.Items.Add(row.Descricao)
        Next

        TxtNomeCompleto.Focus()

    End Sub

    Private Sub BttAddNacionalidade_Click(sender As Object, e As EventArgs) Handles BttAddNacionalidade.Click

        FrmNacionalidade.ShowDialog()

    End Sub

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then
            CmbNacionalidade.Enabled = True
            BttAddNacionalidade.Enabled = True
        Else
            CmbNacionalidade.Enabled = False
            BttAddNacionalidade.Enabled = False
            CmbNacionalidade.Text = ""
        End If

    End Sub

    Private Sub CmbNacionalidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNacionalidade.SelectedIndexChanged
        If CmbNacionalidade.Items.Contains(CmbNacionalidade.Text) Then
            TxtNomeMae.Enabled = True
            TxtNomePai.Enabled = True
        Else
            TxtNomeMae.Enabled = False
            TxtNomePai.Enabled = False
            TxtNomeMae.Text = ""
            TxtNomePai.Text = ""
        End If
    End Sub

    Private Sub TxtNomeMae_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeMae.TextChanged
        If TxtNomeMae.Text <> "" Then
            TxtCep.Enabled = True
        Else
            TxtCep.Enabled = False
            TxtCep.Text = ""
        End If
    End Sub

    Private Sub GpDadosPessoais_Enter(sender As Object, e As EventArgs) Handles GpDadosPessoais.Enter

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        FrmEndereço._CEP = TxtCep.Text
        FrmEndereço.FormOri = 0
        FrmEndereço.Show(Me)

    End Sub

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        If TxtCep.Text.Length >= 8 Then

            'Try
            Me.Cursor = Cursors.WaitCursor

            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
            ds.ReadXml(xml)
            LblEndereco.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
            LblBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            LblCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            LblEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()
            LblPais.Text = "Brasil"

            TxtNumero.Enabled = True
            Me.Cursor = Cursors.Arrow

            TxtNumero.Focus()

        Else

            LblEndereco.Text = ""
            LblBairro.Text = ""
            LblCidade.Text = ""
            LblEstado.Text = ""
            LblPais.Text = ""

            TxtNumero.Text = ""
            TxtNumero.Enabled = False
            TxtComplemento.Text = ""
            TxtComplemento.Enabled = False

        End If
    End Sub

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

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then
            TxtComplemento.Enabled = True
            GpContatos.Enabled = True
            GpReferencias.Enabled = True
            GpDependentes.Enabled = True
            GpFuncao.Enabled = True
            GpDadosBancarios.Enabled = True

            TxtCelular.Text = CelularEnc
            TxtEmail.Text = EmailEnc

        Else
            TxtComplemento.Enabled = False
            GpContatos.Enabled = False
            GpReferencias.Enabled = False
            GpDependentes.Enabled = False
            GpFuncao.Enabled = False
            GpDadosBancarios.Enabled = False

            TxtTelefoneRef01.Text = ""
            TxtComplemento.Text = ""

            TxtTelefone.Text = ""
            TxtCelular.Text = ""
            TxtEmail.Text = ""

        End If
    End Sub

    Private Sub MaskedTextBox3_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefone.MaskInputRejected

    End Sub

    Private Sub MaskedTextBox3_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefone.TextChanged

        If TxtTelefone.Text.Length <= 10 Then
            TxtTelefone.Mask = "(00) 0000-00000"
        ElseIf TxtTelefone.Text.Length = 11 Then
            TxtTelefone.Mask = "(00) 0 0000-00000"
            TxtTelefone.Select(16, 0)
        ElseIf TxtTelefone.Text.Length = 12 Then
            TxtTelefone.Mask = " (00) 00 0000-00000"
        ElseIf TxtTelefone.Text.Length = 13 Then
            TxtTelefone.Mask = " (00) 000 0000-0000"
        End If

    End Sub

    Private Sub TxtTelefone_Enter(sender As Object, e As EventArgs) Handles TxtTelefone.Enter


    End Sub

    Private Sub TxtTelefone_MaskChanged(sender As Object, e As EventArgs) Handles TxtTelefone.MaskChanged

    End Sub

    Public _IdExterno As Integer = 0

    Public _IdInterno As Integer = 0

    Private Sub BttSalvarColaborador_Click(sender As Object, e As EventArgs)

        If _IdExterno = 0 Then
            'salva colaborador

            If CmbBanco.Text <> "" Then

                Dim Sel As Boolean = False
                If RdbCC.Checked = True Then
                    Sel = True
                End If

                LqCadastros.InsereColaborador(TxtNomeCompleto.Text, "", "", TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, 0, "", LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, LStNumBanco.Items(CmbBanco.SelectedIndex).ToString, CmbBanco.SelectedItem, LstIdBairro.Items(CmbBanco.SelectedIndex).ToString, TxtAg.Text, TxtNumConta.Text, TxtOperacao.Text, Sel, CmbDocEspecial.Text, TxtNumDocEspecial.Text)
            Else
                LqCadastros.InsereColaborador(TxtNomeCompleto.Text, "", "", TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, 0, "", LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, 0, "", "", "", "", "", False, CmbDocEspecial.Text, TxtNumDocEspecial.Text)
            End If

        Else

            If CmbBanco.Text <> "" Then

                Dim Sel As Boolean = False
                If RdbCC.Checked = True Then
                    Sel = True
                End If

                LqCadastros.AtualizaFuncionario(_IdInterno, TxtNomeCompleto.Text, "", "", TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, 0, "", LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, LStNumBanco.Items(CmbBanco.SelectedIndex).ToString, CmbBanco.SelectedItem, LstIdBairro.Items(CmbBanco.SelectedIndex).ToString, TxtAg.Text, TxtNumConta.Text, TxtOperacao.Text, Sel, CmbDocEspecial.Text,TxtNumDocEspecial.Text )

            Else

                LqCadastros.AtualizaFuncionario(_IdInterno, TxtNomeCompleto.Text, "", "", TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, 0, "", LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, "", "", "", "", "", False, CmbDocEspecial.Text, TxtNumDocEspecial.Text)

            End If

        End If

            'busca colaborador recem cadastrado

            Dim BuscaRecem = From rec In LqCadastros.Funcionarios
                         Where rec.IdFuncionario = _IdInterno
                         Select rec.IdFuncionario

        _ChaveTemporaria = BuscaRecem.First

        'atualiza dependentes

        For Each row As DataGridViewRow In DtDependentes.Rows
            LqCadastros.AtualizaIdDependenteFuncionario(BuscaRecem.First, row.Cells(0).Value)
        Next


        LimpaTodos()

        GpDadosPessoais.Enabled = False
        BttSalvar.Enabled = False

        If primeiro = True Then

            FrmPrincipal.Close()

            FrmLogin.Visible = True

            Me.Close()

        End If

    End Sub

    Private Sub LimpaTodos()
        TxtNomeCompleto.Text = ""
        TxtNomePai.Text = ""
        TxtNomeMae.Text = ""

        TxtNumero.Text = ""
        TxtNumero.Enabled = False
        TxtComplemento.Text = ""
        TxtComplemento.Enabled = False

        TxtNomeCompleto.Enabled = False

        TxtNomePai.Enabled = False
        TxtNomeMae.Enabled = False

        TxtNomeDependente.Text = ""
        LblEndereco.Text = ""
        LblBairro.Text = ""
        LblCidade.Text = ""
        LblPais.Text = ""
        LblEstado.Text = ""

        DtDependentes.Rows.Clear()

    End Sub

    Private Sub TxtTelefoneRef01_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefoneRef01.MaskInputRejected

    End Sub

    Private Sub TxtNomeRef01_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeRef01.TextChanged
        If TxtNomeRef01.Text <> "" Then
            TxtTelefoneRef02.Enabled = True
        Else
            TxtTelefoneRef02.Enabled = False
            TxtTelefoneRef02.Text = Nothing
        End If
    End Sub

    Private Sub TxtTelefoneRef01_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefoneRef01.TextChanged
        If TxtTelefoneRef01.Text.Length > 9 Then
            TxtNomeRef01.Enabled = True
        Else
            TxtNomeRef01.Enabled = False
            TxtNomeRef01.Text = Nothing
        End If
    End Sub

    Private Sub TxtTelefoneRef02_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefoneRef02.MaskInputRejected

    End Sub

    Private Sub TxtTelefoneRef02_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefoneRef02.TextChanged
        If TxtTelefoneRef02.Text.Length > 9 Then
            TxtNomeRef02.Enabled = True
        Else
            TxtNomeRef02.Enabled = False
            TxtNomeRef02.Text = Nothing
        End If
    End Sub

    Private Sub TxtTelefoneRef03_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefoneRef03.MaskInputRejected

    End Sub

    Private Sub TxtNomeRef02_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeRef02.TextChanged
        If TxtNomeRef02.Text <> "" Then
            TxtTelefoneRef03.Enabled = True
        Else
            TxtTelefoneRef03.Enabled = False
            TxtTelefoneRef03.Text = Nothing
        End If
    End Sub

    Private Sub TxtTelefoneRef03_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefoneRef03.TextChanged
        If TxtTelefoneRef03.Text.Length > 9 Then
            TxtNomeRef03.Enabled = True
        Else
            TxtNomeRef03.Enabled = False
            TxtNomeRef03.Text = Nothing
        End If
    End Sub

    Dim LstIdFuncionarios As New ListBox

    Public NomeCompleto As String
    Public CelularEnc As String
    Public EmailEnc As String

    Public LstIdCargo As New ListBox
    Public LstRemuneracao As New ListBox

    Public LstIdBanco As New ListBox
    Public LStNumBanco As New ListBox

    Public NomeUsuario As String
    Public SenhaUsuario As String

    Public LstIdVinculosParentais As New ListBox

    Private Sub FrmCadColaboradores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If primeiro = True Then
            FrmPrincipal.Opacity = 0
        End If

        'carrega colaboradores

        LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'Busca Nacionalidades

        Dim BuscaNacional = From nac In LqCadastros.Nacionalidades
                            Where nac.IdNacionalidade Like "*"
                            Select nac.IdNacionalidade, nac.Nacionalidade

        For Each lin In BuscaNacional.ToList
            LstIdNacionalidades.Items.Add(lin.IdNacionalidade)
            CmbNacionalidade.Items.Add(lin.Nacionalidade)
        Next

        Dim BuscaFuncao = From nac In LqCadastros.Cargos
                          Where nac.IdCargo Like "*"
                          Select nac.IdCargo, nac.Descricao, nac.RemuneracaoBase

        For Each lin In BuscaFuncao.ToList
            LstIdCargo.Items.Add(lin.IdCargo)
            CmbFuncao.Items.Add(lin.Descricao)
            LstRemuneracao.Items.Add(lin.RemuneracaoBase)
        Next

        Dim BuscaVinculos = From nac In LqCadastros.VinculosParentais
                            Where nac.IDVinculoParentesco Like "*"
                            Select nac.IDVinculoParentesco, nac.Descricao

        For Each lin In BuscaVinculos.ToList
            LstIdVinculosParentais.Items.Add(lin.IDVinculoParentesco)
            CmbVinculo.Items.Add(lin.Descricao)
        Next

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaBancos = From nac In LqFinanceiro.Bancos
                          Where nac.IdBanco Like "*"
                          Select nac.IdBanco, nac.label, nac.value

        For Each lin In BuscaBancos.ToList
            LstIdBanco.Items.Add(lin.IdBanco)
            CmbBanco.Items.Add(lin.value & " - " & lin.label)
            LStNumBanco.Items.Add(lin.value)
        Next

        'busca dados do funcionario
        Dim BuscaColaboradores = From col In LqCadastros.Funcionarios
                                 Where col.IdFuncionario = _IdInterno
                                 Select col.Ag, col.Conta, col.Op, col.TipoConta, col.NomeBanco, col.CPF, col.RG, col.Cargo, col.Numero, col.Complemento, col.CEP, col.Celular, col.Email, col.NomeCompleto, col.IdFuncionario, col.Nacionalidade, col.NomeMae, col.NomePai

        If BuscaColaboradores.Count > 0 Then

            CmbNacionalidade.SelectedItem = BuscaColaboradores.First.Nacionalidade
            TxtCPF.Text = BuscaColaboradores.First.CPF
            TxtRg.Text = BuscaColaboradores.First.RG
            TxtNomeMae.Text = BuscaColaboradores.First.NomeMae
            TxtNomePai.Text = BuscaColaboradores.First.NomePai
            TxtCep.Text = BuscaColaboradores.First.CEP

            CelularEnc = BuscaColaboradores.First.Celular
            EmailEnc = BuscaColaboradores.First.Email

            CmbFuncao.SelectedItem = BuscaColaboradores.First.Cargo
            CmbBanco.SelectedItem = BuscaColaboradores.First.NomeBanco

            TxtAg.Text = BuscaColaboradores.First.Ag
            TxtNumConta.Text = BuscaColaboradores.First.Conta
            TxtOperacao.Text = BuscaColaboradores.First.Op

            'busca login e senha

            If BuscaColaboradores.First.TipoConta = True Then

                RdbCC.Checked = True

            Else

                RdbCP.Checked = True

            End If

            If BuscaColaboradores.First.CEP <> "" Then
                TxtNumero.Text = BuscaColaboradores.First.Numero
                TxtComplemento.Text = BuscaColaboradores.First.Complemento
                TxtCelular.Text = CelularEnc
                TxtEmail.Text = EmailEnc
            End If

            'busca dependetes cadastrados

            Dim BuscsaDependentes = From dep In LqCadastros.DependentesFuncionarios
                                    Where dep.IdFuncionario = _IdInterno
                                    Select dep.Nome, dep.Vinculo, dep.IdDependente, dep.IdVinculo

            For Each row In BuscsaDependentes.ToList

                DtDependentes.Rows.Add(row.IdDependente, row.Nome, row.Vinculo, ImageList2.Images(0))

            Next

        End If

    End Sub

    Private Sub CmbColaboradores_Click(sender As Object, e As EventArgs)

    End Sub

    Public LstIdVinculoParental As New ListBox

    Private Sub BttEditColaborador_Click(sender As Object, e As EventArgs)

        _ChaveTemporaria = _IdInterno

        'busca colaborador selecionado

        BttSalvar.Enabled = True


        GpDadosPessoais.Enabled = True
        TxtNomeCompleto.Enabled = True

        Dim BUscaColaborador = From col In LqCadastros.Funcionarios
                               Where col.IdFuncionario = _IdInterno
                               Select col.NomeCompleto, col.Nacionalidade, col.NomePai, col.NomeMae, col.CEP, col.Numero, col.Complemento, col.Telefone, col.Celular, col.Email, col.TelefoneCont1, col.NomeCont1, col.telefoneCont2, col.NomeCont2, col.telefoneCont3, col.NomeCont3

        TxtNomeCompleto.Text = BUscaColaborador.First.NomeCompleto

        'busca nacionalidades

        Dim BuscaNac = From nac In LqCadastros.Nacionalidades
                       Where nac.IdNacionalidade Like "*"
                       Select nac.Nacionalidade, nac.IdNacionalidade

        LstIdNacionalidades.Items.Clear()
        CmbNacionalidade.Items.Clear()

        For Each row In BuscaNac.ToList

            LstIdNacionalidades.Items.Add(row.IdNacionalidade)
            CmbNacionalidade.Items.Add(row.Nacionalidade)

        Next

        CmbNacionalidade.SelectedItem = BUscaColaborador.First.Nacionalidade
        TxtNomeMae.Text = BUscaColaborador.First.NomeMae
        TxtNomePai.Text = BUscaColaborador.First.NomePai
        TxtCep.Text = BUscaColaborador.First.CEP
        TxtNumero.Text = BUscaColaborador.First.Numero
        TxtComplemento.Text = BUscaColaborador.First.Complemento
        TxtTelefone.Text = BUscaColaborador.First.Telefone
        TxtCelular.Text = BUscaColaborador.First.Celular
        TxtEmail.Text = BUscaColaborador.First.Email

        TxtTelefoneRef01.Text = BUscaColaborador.First.TelefoneCont1
        TxtTelefoneRef02.Text = BUscaColaborador.First.telefoneCont2
        TxtTelefoneRef03.Text = BUscaColaborador.First.telefoneCont3

        TxtNomeRef01.Text = BUscaColaborador.First.NomeCont1
        TxtNomeRef02.Text = BUscaColaborador.First.NomeCont2
        TxtNomeRef03.Text = BUscaColaborador.First.NomeCont3

        'busca todos os vinculos

        Dim BuscaVinculo = From vin In LqCadastros.VinculosParentais
                           Where vin.IDVinculoParentesco Like "*"
                           Select vin.Descricao, vin.IDVinculoParentesco

        LstIdVinculoParental.Items.Clear()
        CmbVinculo.Items.Clear()

        For Each row In BuscaVinculo.ToList
            LstIdVinculoParental.Items.Add(row.IDVinculoParentesco)
            CmbVinculo.Items.Add(row.Descricao)
        Next

        'busca e popula lista

        Dim BuscaDep = From dep In LqCadastros.DependentesFuncionarios
                       Where dep.IdFuncionario = _ChaveTemporaria
                       Select dep.IdDependente, dep.Nome, dep.Vinculo

        DtDependentes.Rows.Clear()

        For Each row In BuscaDep.ToList

            DtDependentes.Rows.Add(row.IdDependente, row.Nome, row.Vinculo)

        Next

        'publica login sugerido
        Dim Contexto As String = TxtNomeCompleto.Text

        Dim str As String = Contexto
        Dim separador As String = " "

        ' Separa string baseado no delimitador
        Dim palavras As String() = str.Split(separador)
        Dim LstPalavras As New ListBox
        Dim palavra As String

        For Each palavra In palavras
            LstPalavras.Items.Add(palavra)
        Next

    End Sub

    Private Sub BttCancelar_Click(sender As Object, e As EventArgs)

        LimpaTodos()

        GpDadosPessoais.Enabled = False

    End Sub

    Private Sub TxtNomeDependente_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNomeDependente.MaskInputRejected

    End Sub

    Private Sub BttAddVinculo_Click(sender As Object, e As EventArgs) Handles BttAddVinculo.Click
        FrmNovoVinculoParental.Show(Me)
    End Sub

    Private Sub TxtNomeDependente_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeDependente.TextChanged
        If TxtNomeDependente.Text <> "" Then
            CmbVinculo.Enabled = True
            BttAddVinculo.Enabled = True
        Else
            CmbVinculo.Enabled = False
            BttAddVinculo.Enabled = False
            CmbVinculo.Text = ""
        End If
    End Sub

    Dim _ChaveTemporaria As Integer
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'adiciona no bdd

        LqCadastros.InsereDependenteFuncionario(_IdInterno, TxtNomeDependente.Text, LstIdVinculosParentais.Items(CmbVinculo.SelectedIndex).ToString, CmbVinculo.Text)

        'busca e popula lista

        Dim BuscaDep = From dep In LqCadastros.DependentesFuncionarios
                       Where dep.IdFuncionario = _IdInterno
                       Select dep.IdDependente, dep.Nome, dep.Vinculo

        DtDependentes.Rows.Clear()

        For Each row In BuscaDep.ToList

            DtDependentes.Rows.Add(row.IdDependente, row.Nome, row.Vinculo, ImageList2.Images(0))

        Next

        TxtNomeDependente.Text = ""

    End Sub

    Private Sub CmbVinculo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbVinculo.SelectedIndexChanged
        If CmbVinculo.Items.Contains(CmbVinculo.Text) Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Private Sub TxtNomeCompleto_LostFocus(sender As Object, e As EventArgs) Handles TxtNomeCompleto.LostFocus

        'publica login sugerido
        Dim Contexto As String = TxtNomeCompleto.Text

        Dim str As String = Contexto
        Dim separador As String = " "

        ' Separa string baseado no delimitador
        Dim palavras As String() = str.Split(separador)
        Dim LstPalavras As New ListBox
        Dim palavra As String

        For Each palavra In palavras
            LstPalavras.Items.Add(palavra)
        Next

    End Sub


    Dim Ltr As Boolean = False
    Dim Nmb As Boolean = False
    Dim Crt As Boolean = False

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs)

        Ltr = False
        Nmb = False
        Crt = False

        Dim LstCarcter As New ListBox
        LstCarcter.Items.Add("!")
        LstCarcter.Items.Add("@")
        LstCarcter.Items.Add("#")
        LstCarcter.Items.Add("$")
        LstCarcter.Items.Add("%")
        LstCarcter.Items.Add("&")
        LstCarcter.Items.Add("-")
        LstCarcter.Items.Add(".")
        LstCarcter.Items.Add("+")

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub BttAddPais_Click(sender As Object, e As EventArgs)

        FrmNovoPais.Ori = 0
        FrmNovoPais.Show(Me)

    End Sub

    Public primeiro As Boolean = False
    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click

        If primeiro = True Then

            FrmLogin.Visible = True

            FrmPrincipal.Close()

            Me.Close()

        Else

            Me.Close()

        End If


    End Sub

    Private Sub TxtEmail_TextChanged(sender As Object, e As EventArgs) Handles TxtEmail.TextChanged


    End Sub

    Public Comissionado As Boolean = False
    Public VlrComissao As Decimal = 0

    Private Sub CmbFuncao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFuncao.SelectedIndexChanged

        If CmbFuncao.Items.Contains(CmbFuncao.Text) Then

            LblRemuneracao.Text = FormatCurrency(LstRemuneracao.Items(CmbFuncao.SelectedIndex).ToString, NumDigitsAfterDecimal:=2)
            CkComissionar.Enabled = True

            If Comissionado = True Then
                CkComissionar.Checked = True
                TxtComissao.Value = VlrComissao
            End If

        Else

            CkComissionar.Checked = False
            CkComissionar.Enabled = False

        End If

    End Sub

    Private Sub CmbBanco_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBanco.SelectedIndexChanged

        If CmbBanco.Items.Contains(CmbBanco.Text) Then

            TxtAg.Enabled = True

        Else

            TxtAg.Enabled = False
            TxtAg.Text = ""

        End If

    End Sub

    Private Sub CkComissionar_CheckedChanged(sender As Object, e As EventArgs) Handles CkComissionar.CheckedChanged

        If CkComissionar.Checked = True Then
            TxtComissao.Enabled = True
        Else
            TxtComissao.Value = 0
            TxtComissao.Enabled = False
        End If

    End Sub

    Private Sub TxtNumConta_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNumConta.MaskInputRejected

    End Sub

    Private Sub TxtAg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtAg.MaskInputRejected

    End Sub

    Private Sub TxtAg_TextChanged(sender As Object, e As EventArgs) Handles TxtAg.TextChanged

        If TxtAg.Text <> "" Then

            TxtNumConta.Enabled = True

        Else

            TxtNumConta.Text = ""
            TxtNumConta.Enabled = False

        End If

    End Sub

    Private Sub TxtNumConta_TextChanged(sender As Object, e As EventArgs) Handles TxtNumConta.TextChanged

        If TxtNumConta.Text <> "" Then

            TxtOperacao.Enabled = True

            RdbCC.Enabled = True
            RdbCP.Enabled = True

        Else

            TxtOperacao.Text = ""
            TxtOperacao.Enabled = False

            RdbCC.Enabled = False
            RdbCP.Enabled = False

        End If

    End Sub

    Private Sub TxtOperacao_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtOperacao.MaskInputRejected

    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BtnConcluir.Click

        Me.Cursor = Cursors.WaitCursor

        If _IdInterno = 0 Then

            'salva colaborador

            If CmbBanco.Text <> "" Then

                Dim Sel As Boolean = False
                If RdbCC.Checked = True Then
                    Sel = True
                End If

                LqCadastros.InsereColaborador(TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, LstIdCargo.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.SelectedItem, LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, LStNumBanco.Items(CmbBanco.SelectedIndex).ToString, CmbBanco.SelectedItem, LstIdBanco.Items(CmbBanco.SelectedIndex).ToString, TxtAg.Text, TxtNumConta.Text, TxtOperacao.Text, Sel, CmbDocEspecial.Text, TxtNumDocEspecial.Text)
            Else
                LqCadastros.InsereColaborador(TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, LstIdCargo.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.SelectedItem, LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, 0, "", 0, "", "", "", False, CmbDocEspecial.Text, TxtNumDocEspecial.Text)
            End If

            'verifica valor do ultimo registro

            Dim BuscaUltimo = From ult In LqCadastros.Funcionarios
                              Where ult.NomeCompleto Like TxtNomeCompleto.Text
                              Select ult.IdFuncionario
                              Order By IdFuncionario Descending

            _IdInterno = BuscaUltimo.First

            'cria novo colaborador externo

            TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            TxtCelular.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

            Dim baseUrl_insere As String = "http://www.iarasoftware.com.br/create_usuario_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&NomeCompleto=" & TxtNomeCompleto.Text &
                "&Documento=" & TxtCPF.Text & "&FotoPerfil=ND&Cep=" & TxtCep.Text & "&Endereco=" & LblEndereco.Text & "&Bairro=" & LblBairro.Text & "&Cidade=" & LblCidade.Text & "&Estado=" &
                LblEstado.Text & "&Numero=" & TxtNumero.Text & "&Complemento=" & TxtComplemento.Text & "&Celular=" & TxtCelular.Text & "&email=" & TxtEmail.Text & "&Cargo=" &
                CmbFuncao.SelectedItem & "&IdVinculoExt=" & BuscaUltimo.First & "&User=" & NomeUsuario & "&Pass=" & SenhaUsuario

            Dim syncClient_insere = New WebClient()
            Dim content_insere = syncClient_insere.DownloadString(baseUrl_insere)

            'le o id inserido e atualiza interno

            Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content_insere & "]")

            LqCadastros.AtualizaVinculoExt_Funcionario(BuscaUltimo.First, read0.Item(0).Id)

            'cria acessos

            TxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            TxtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

        Else

            If CmbBanco.Text <> "" Then

                Dim Sel As Boolean = False
                If RdbCC.Checked = True Then
                    Sel = True
                End If

                LqCadastros.AtualizaFuncionario(_IdInterno, TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, LstIdCargo.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.SelectedItem, LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, LStNumBanco.Items(CmbBanco.SelectedIndex).ToString, CmbBanco.SelectedItem, LstIdBanco.Items(CmbBanco.SelectedIndex).ToString, TxtAg.Text, TxtNumConta.Text, TxtOperacao.Text, Sel, CmbDocEspecial.Text, TxtNumDocEspecial.Text)

            Else

                LqCadastros.AtualizaFuncionario(_IdInterno, TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, LblPais.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, TxtTelefoneRef01.Text, TxtNomeRef01.Text, TxtTelefoneRef02.Text, TxtNomeRef02.Text, TxtTelefoneRef03.Text, TxtNomeRef03.Text, Nothing, LstIdCargo.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.SelectedItem, LstIdNacionalidades.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, "", 0, "", "", "", False, CmbDocEspecial.Text, TxtNumDocEspecial.Text)

            End If

            'atualiza online

            TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            TxtCelular.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

            Dim baseUrl_insere As String = "http://www.iarasoftware.com.br/atualiza_dados_usuario_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&NomeCompleto=" & TxtNomeCompleto.Text &
                "&Documento=" & TxtCPF.Text & "&FotoPerfil=ND&Cep=" & TxtCep.Text & "&Endereco=" & LblEndereco.Text & "&Bairro=" & LblBairro.Text & "&Cidade=" & LblCidade.Text & "&Estado=" &
                LblEstado.Text & "&Numero=" & TxtNumero.Text & "&Complemento=" & TxtComplemento.Text & "&Celular=" & TxtCelular.Text & "&email=" & TxtEmail.Text & "&Cargo=" &
                CmbFuncao.SelectedItem & "&IdUsuario=" & _IdExterno & "&User=" & NomeUsuario & "&Pass=" & SenhaUsuario

            Dim syncClient_insere = New WebClient()
            Dim content_insere = syncClient_insere.DownloadString(baseUrl_insere)

            TxtCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            TxtCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals

        End If

        'busca colaborador recem cadastrado

        Dim BuscaRecem = From rec In LqCadastros.Funcionarios
                         Where rec.IdFuncionario = _IdInterno
                         Select rec.IdFuncionario

        _ChaveTemporaria = BuscaRecem.First

        'atualiza dependentes

        For Each row As DataGridViewRow In DtDependentes.Rows
            LqCadastros.AtualizaIdDependenteFuncionario(BuscaRecem.First, row.Cells(0).Value)
        Next

        FrmListaColaboradores.CarregaInicio()

        Me.Close()

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub

    Private Sub TxtCPF_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged

        If TxtCPF.Text.Length = 14 Then
            TxtRg.Enabled = True
        Else
            TxtRg.Text = ""
            TxtRg.Enabled = False
        End If

    End Sub

    Private Sub TxtRg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtRg.MaskInputRejected

    End Sub

    Private Sub TxtRg_TextChanged(sender As Object, e As EventArgs) Handles TxtRg.TextChanged

        If TxtRg.Text <> "" Then

            TxtNomeCompleto.Enabled = True
            TxtNomeCompleto.Text = NomeCompleto

        Else

            TxtNomeCompleto.Text = ""
            TxtNomeCompleto.Enabled = False

        End If

    End Sub

    Private Sub BttLogin_Click(sender As Object, e As EventArgs) Handles BttLogin.Click

        FrmCadLoginUsuario.TxtPlaca.Text = NomeUsuario
        FrmCadLoginUsuario.Pass = SenhaUsuario

        FrmCadLoginUsuario.Show(Me)

    End Sub

    Private Sub DtDependentes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtDependentes.CellContentClick

        If DtDependentes.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            'apaga do banco de dados

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            LqBase.DeletaDependenteColaborador(DtDependentes.Rows(e.RowIndex).Cells(0).Value, _IdInterno)

            DtDependentes.Rows.RemoveAt(e.RowIndex)

        End If

    End Sub

    Private Sub BttAddFuncao_Click(sender As Object, e As EventArgs) Handles BttAddFuncao.Click

        FrmNovaFuncao.Show(Me)

    End Sub
End Class