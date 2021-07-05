Public Class FrmNovoFornecedor
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If Application.OpenForms.OfType(Of FrmCotações)().Count() > 0 Then

            Me.Close()

        ElseIf Application.OpenForms.OfType(Of FrmCotações)().Count() = 0 Then

            Me.Cursor = Cursors.WaitCursor

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        End If

    End Sub

    Private Sub TxtDocumento_TextChanged(sender As Object, e As EventArgs) Handles TxtDocumento.TextChanged

        If TxtDocumento.Text.Length <= 11 Then

            TxtDocumento.Mask = "000,000,000-000"

        Else

            TxtDocumento.Mask = "00,000,000/0000-00"

        End If

        If TxtDocumento.Text.Length = 11 Or TxtDocumento.Text.Length = 14 Then

            TxtNomeFantasia.Enabled = True
            TxtIe.Enabled = True

            If TxtDocumento.Text.Length = 14 Then

                TxtNomeFantasia.Focus()

            End If

        Else

            TxtNomeFantasia.Enabled = False
            TxtIe.Enabled = False

            TxtNomeFantasia.Text = ""
            TxtIe.Text = ""

        End If

    End Sub

    Private Sub TxtNomeFantasia_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeFantasia.TextChanged

        If TxtNomeFantasia.Text <> "" Then

            TxtRazaoSocial.Enabled = True

        Else

            TxtRazaoSocial.Enabled = False
            TxtRazaoSocial.Text = ""

        End If

    End Sub

    Private Sub TxtRazaoSocial_TextChanged(sender As Object, e As EventArgs) Handles TxtRazaoSocial.TextChanged

        If TxtRazaoSocial.Text <> "" Then

            TxtCep.Enabled = True

        Else

            TxtCep.Enabled = True
            TxtCep.Text = ""

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

    Dim LqCadastros As New DtCadastroDataContext

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then

            TxtComplemento.Enabled = True
            TxtValorFaturamento.Enabled = True
            CmbFormaPagamento.Enabled = True
            BttNovaForma.Enabled = True

        Else

            BttNovaForma.Enabled = False
            TxtComplemento.Enabled = False
            TxtValorFaturamento.Enabled = False
            TxtValorFaturamento.Text = "R$ 0,00"
            CmbFormaPagamento.Enabled = False
            CmbFormaPagamento.Items.Clear()

        End If

    End Sub

    Private Sub TxtValorFaturamento_TextChanged(sender As Object, e As EventArgs) Handles TxtValorFaturamento.TextChanged

        If TxtValorFaturamento.Text = "" Then
            TxtValorFaturamento.Text = 0
        End If

    End Sub

    Public LstAvista As New ListBox

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Private Sub TxtNumero_LostFocus(sender As Object, e As EventArgs)

        If TxtNumero.Text <> "" Then

            'procura formas de pagamento cadastradas

            Dim BuscaFormasPg = From fm In LqFinanceiro.FormasPgSaida
                                Where fm.IdFormasPgSaida Like "*"
                                Select fm.Descricao, fm.IdFormasPgSaida, fm.A_Vista

            LstIdFormas.Items.Clear()
            LstAvista.Items.Clear()
            CmbFormaPagamento.Items.Clear()

            For Each row In BuscaFormasPg.ToList

                LstIdFormas.Items.Add(row.IdFormasPgSaida)
                LstAvista.Items.Add(row.A_Vista)
                CmbFormaPagamento.Items.Add(row.Descricao)

            Next

            BttNovaForma.Enabled = True

        Else

            LstIdFormas.Items.Clear()
            LstAvista.Items.Clear()
            CmbFormaPagamento.Items.Clear()

            TxtComplemento.Enabled = False
            TxtValorFaturamento.Enabled = False
            TxtValorFaturamento.Text = "R$ 0,00"
            CmbFormaPagamento.Enabled = False

            BttNovaForma.Enabled = False

        End If

    End Sub

    Public LstIdFormas As New ListBox

    Private Sub CmbFormaPagamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFormaPagamento.SelectedIndexChanged

        If CmbFormaPagamento.Items.Contains(CmbFormaPagamento.Text) Then

            If LstAvista.Items(CmbFormaPagamento.SelectedIndex).ToString = False Then

                'habilita campos

                NmMaximo.Enabled = True
                NmIntervaloPg.Enabled = True

                RdbDias.Enabled = True
                RdbMeses.Enabled = True

                NmMaximo.Value = 1
                NmIntervaloPg.Value = 1
                RdbDias.Checked = False
                RdbMeses.Checked = False

            Else

                NmMaximo.Enabled = False
                NmMaximo.Value = 1

                NmIntervaloPg.Enabled = False
                NmIntervaloPg.Value = 1

                RdbDias.Enabled = False
                RdbMeses.Enabled = False
                RdbDias.Checked = False
                RdbMeses.Checked = False

                BttInserirForma.Enabled = True

            End If

        Else

            NmMaximo.Enabled = False
            NmMaximo.Value = 1

            NmIntervaloPg.Enabled = False
            NmIntervaloPg.Value = 1

            RdbDias.Enabled = False
            RdbMeses.Enabled = False
            RdbDias.Checked = False
            RdbMeses.Checked = False

            BttInserirForma.Enabled = False

        End If

    End Sub

    Private Sub BttInserirForma_Click(sender As Object, e As EventArgs) Handles BttInserirForma.Click

        Dim TipoFormaPG As String

        If RdbDias.Checked = True Then
            TipoFormaPG = "d"
        Else
            TipoFormaPG = "m"
        End If

        Dim Intervalo As String

        Dim Pc As Integer = 0

        Dim Acrescentar As Integer

        While Pc < NmMaximo.Value

            If Pc < NmMaximo.Value - 1 Then

                Acrescentar += NmIntervaloPg.Value
                Intervalo &= Acrescentar & " " & TipoFormaPG & " / "

            Else

                Acrescentar += NmIntervaloPg.Value
                Intervalo &= Acrescentar & " " & TipoFormaPG

            End If

            Pc += 1

        End While

        'insere na lista

        If RdbDias.Enabled = True Then
            DtFormas.Rows.Add(LstIdFormas.Items(CmbFormaPagamento.SelectedIndex).ToString, CmbFormaPagamento.SelectedItem.ToString & " " & Intervalo, TipoFormaPG, NmMaximo.Value, NmIntervaloPg.Value)
        Else
            DtFormas.Rows.Add(LstIdFormas.Items(CmbFormaPagamento.SelectedIndex).ToString, CmbFormaPagamento.SelectedItem.ToString, TipoFormaPG, NmMaximo.Value, NmIntervaloPg.Value)
        End If

        'limpa campos

        NmMaximo.Enabled = False
        NmIntervaloPg.Enabled = False
        RdbDias.Enabled = False
        RdbMeses.Enabled = False

        NmMaximo.Value = 1
        NmIntervaloPg.Value = 1
        RdbDias.Checked = False
        RdbMeses.Checked = False

        BttInserirForma.Enabled = False

        CmbFormaPagamento.Text = ""

        BttSalvarFornecedor.Enabled = True

    End Sub

    Private Sub BttNovaForma_Click(sender As Object, e As EventArgs) Handles BttNovaForma.Click

        FrmFormasPgSaida.Show(Me)

    End Sub

    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            DtFormas.Rows.RemoveAt(e.RowIndex)

            If DtFormas.Rows.Count = 0 Then

                BttSalvarFornecedor.Enabled = False

            End If

        End If

    End Sub

    Private Sub RdbDias_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDias.CheckedChanged

        BttInserirForma.Enabled = True

    End Sub

    Private Sub RdbMeses_CheckedChanged(sender As Object, e As EventArgs) Handles RdbMeses.CheckedChanged

        BttInserirForma.Enabled = True

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Private Sub BttSalvarFornecedor_Click(sender As Object, e As EventArgs) Handles BttSalvarFornecedor.Click

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'busca cep

        Dim BuscaCep = From cep In LqBase.Enderecos
                       Where cep.CEP = TxtCep.Text
                       Select cep.IdEndereco, cep.IdBairro

        Dim BuscaBairro = From cep In LqBase.Bairro
                          Where cep.IdBairro = BuscaCep.First.IdBairro
                          Select cep.IdCidade

        Dim BuscaCidade = From cep In LqBase.Cidade
                          Where cep.IdCidade = BuscaBairro.First
                          Select cep.IdEstado

        Dim BuscaEstado = From cep In LqBase.Estados
                          Where cep.IdEstado = BuscaCidade.First
                          Select cep.IdPais

        LqBase.InsereNovoFornecedor(TxtDocumento.Text, TxtRazaoSocial.Text, TxtCep.Text, BuscaCep.First.IdEndereco, TxtNumero.Text, TxtComplemento.Text, BuscaCep.First.IdBairro, TxtBairro.Text, BuscaBairro.First, TxtCidade.Text, BuscaCidade.First, TxtEstado.Text, BuscaEstado.First, TxtPais.Text, 0, TxtNomeFantasia.Text, CkFornecedorInsumo.CheckState, CkPrestador.CheckState, CkComissionado.CheckState, CkTransportadora.CheckState, TxtIe.Text)

        Dim VLTIpo As Boolean = True

        If RdbDias.Checked = True Then

            VLTIpo = True

        Else

            VLTIpo = False

        End If

        'popula no solicitador

        Dim BuscaFornecedores = From fornec In LqBase.Fornecedores
                                Where fornec.IdFornecedor Like "*"
                                Select fornec.IdFornecedor, fornec.Apelido, fornec.Doc
                                Order By IdFornecedor Descending

        'insere dados do ultimo fornecedor

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim Tipo As String = row.Cells(2).Value
            Dim Max As Integer = row.Cells(3).Value
            Dim Interv As Integer = row.Cells(4).Value
            Dim TipoVL As Boolean = False

            If Tipo = "d" Then

                TipoVL = True

            Else

                TipoVL = False

            End If

            Dim CodFormaPg As Integer = row.Cells(0).Value
            LqBase.InsereNovaFormaPgFornecedor(BuscaFornecedores.First.IdFornecedor, Max, Interv, TipoVL, CodFormaPg)

        Next

        FrmCotações.Enabled = False

        FrmCotações.DtFornecedores.Rows.Clear()

        For Each row In BuscaFornecedores.ToList

            FrmCotações.DtFornecedores.Rows.Add(row.IdFornecedor, row.Doc, row.Apelido)

        Next

        FrmCotações.Enabled = True

        FrmCotações.DtFornecedores.Rows(FrmCotações.DtFornecedores.Rows.Count - 1).Selected = True

        If CkFornecedorInsumo.Enabled = False Then
            'popula

            FrmNovoLancamento.CmbBeneficiario.Items.Clear()
            'busca fornecedores que nao sao de produtos de consumo

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaFornecedoresA = From fornec In LqBase.Fornecedores
                                     Where fornec.Prestador = True Or fornec.Comissionado = True
                                     Select fornec.Apelido

            FrmNovoLancamento.CmbBeneficiario.Items.Clear()
            FrmNovoLancamento.CmbBeneficiario.Text = ""

            For Each row In BuscaFornecedoresA.ToList

                FrmNovoLancamento.CmbBeneficiario.Items.Add(row)

            Next

            FrmNovoLancamento.CmbBeneficiario.SelectedItem = TxtNomeFantasia.Text

        End If


        If Application.OpenForms.OfType(Of FrmCotações)().Count() > 0 Then

            Me.Close()

        ElseIf Application.OpenForms.OfType(Of FrmCotações)().Count() = 0 Then

            Me.Cursor = Cursors.WaitCursor

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        End If

    End Sub

    Dim _idEndereco As Integer

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TxtCep.Text.Length = 8 Then

            'busca endereco

            'busca dados do 
            Dim dsInd As New DataSet()
            Dim xmlInd As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
            dsInd.ReadXml(xmlInd)

            TxtEndereco.Text = dsInd.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & dsInd.Tables(0).Rows(0)("logradouro").ToString()
                TxtBairro.Text = dsInd.Tables(0).Rows(0)("bairro").ToString()
                TxtCidade.Text = dsInd.Tables(0).Rows(0)("cidade").ToString()
            TxtEstado.Text = dsInd.Tables(0).Rows(0)("uf").ToString()

            If TxtEndereco.Text <> " " Then

                TxtNumero.Enabled = True

            Else

                If MsgBox("Não encontrei nenhum endereço para o CEP " & TxtCep.Text, vbOKOnly) Then
                    TxtNumero.Enabled = False
                    TxtNumero.Text = ""
                End If

            End If


                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaFormas = From fm In LqFinanceiro.FormasPgSaida
                              Where fm.IdFormasPgSaida Like "*" And fm.UsoInterno = False
                              Select fm.Descricao, fm.A_Vista, fm.IdFormasPgSaida

            LstAvista.Items.Clear()
            LstIdFormas.Items.Clear()
            CmbFormaPagamento.Items.Clear()

            For Each row In BuscaFormas.ToList

                LstAvista.Items.Add(row.A_Vista)
                LstIdFormas.Items.Add(row.IdFormasPgSaida)
                CmbFormaPagamento.Items.Add(row.Descricao)

            Next

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

    Private Sub FrmNovoFornecedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtDocumento.Focus()

    End Sub

    Private Sub TxtDocumento_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtDocumento.MaskInputRejected

    End Sub

    Private Sub TxtDocumento_GotFocus(sender As Object, e As EventArgs) Handles TxtDocumento.GotFocus

        If TxtDocumento.Text <> "" Then

            Dim Valor As Integer = TxtDocumento.Text.Length
            TxtDocumento.SelectionStart = Valor

        Else

            TxtDocumento.SelectionStart = 0

        End If

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