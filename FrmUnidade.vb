Public Class FrmUnidade

    Dim LqGeral As New DtCadastroDataContext
    Public FormOri As Integer
    Private Sub FrmUnidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'verifica se o form de recebimento esta aberto

        If Application.OpenForms.OfType(Of FrmProdutosNfRecebimento)().Count() > 0 Then

            TxtSigla.Text = FrmProdutosNfRecebimento.DtEsperados.SelectedCells(6).Value.ToString
            TxtSigla.Enabled = False

        End If

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtSigla.TextChanged

        If TxtSigla.Enabled = True Then

            If TxtSigla.Text <> "" Then
                BttSalvar.Enabled = True
            Else
                BttSalvar.Enabled = False
            End If

        End If

    End Sub


    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'insere novo bairro

        LqGeral.InsereNovaUnidade(TxtDescrição.Text, TxtSigla.Text)

        If FormOri = 0 Then
            'manda dados para o frmcadcolaboradores
            'carrega todos os estados
            Dim BuscaEstados = From est In LqGeral.UnidadeParametro
                               Where est.IdUnidade Like "*"
                               Select est.IdUnidade, est.Sigla, est.Descricao

            FrmProduto.LstIdUnidade.Items.Clear()
            FrmProduto.LstSigla.Items.Clear()
            FrmProduto.CmbUnidadeCompra.Items.Clear()

            For Each row In BuscaEstados.ToList
                FrmProduto.LstIdUnidade.Items.Add(row.IdUnidade)
                FrmProduto.LstSigla.Items.Add(row.Sigla)
                FrmProduto.CmbUnidadeCompra.Items.Add(row.Sigla & " - " & row.Descricao)
            Next

            FrmProduto.CmbUnidadeCompra.Enabled = True
            FrmProduto.BttAddUnidade.Enabled = True
            FrmProduto.CmbUnidadeCompra.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

            Dim Chave As Integer = FrmProduto.LstIdUnidade.Items(FrmProduto.CmbUnidadeCompra.SelectedIndex).ToString
            LqGeral.InsereNovaUnidadeFt_X(Chave, 1, Chave, False)

            'busca divisor
            Dim BuscaValor = From div In LqGeral.UnidadesGeral
                             Where div.IdUnidade = FrmProduto.LstIdUnidade.Items(FrmProduto.CmbUnidadeCompra.SelectedIndex).ToString
                             Select div.ft_X, div.ChaveValidada, div.IdUnidadeX

            FrmProduto.LstIdUnidadeFtx.Items.Clear()
            FrmProduto.LstDivisor.Items.Clear()
            FrmProduto.LstChavealidada.Items.Clear()
            FrmProduto.CmbUnidadeVenda.Items.Clear()

            For Each row In BuscaValor.ToList
                FrmProduto.LstIdUnidadeFtx.Items.Add(row.IdUnidadeX)
                FrmProduto.LstDivisor.Items.Add(row.ft_X)
                FrmProduto.LstChavealidada.Items.Add(row.ChaveValidada)
                'busca descricao chave
                Dim BuscaChave = From chav In LqGeral.UnidadeParametro
                                 Where chav.IdUnidade = row.ChaveValidada
                                 Select chav.Descricao, chav.Sigla

                FrmProduto.CmbUnidadeVenda.Items.Add(BuscaChave.First.Sigla & " - " & BuscaChave.First.Descricao)
            Next

        ElseIf FormOri = 1 Then
            'manda dados para o frmcadcolaboradores
            'carrega todos os estados
            Dim BuscaEstados = From est In LqGeral.UnidadeParametro
                               Where est.IdUnidade Like "*"
                               Select est.IdUnidade, est.Sigla, est.Descricao

            FrmUnidadeVenda.LstIdUnidade.Items.Clear()
            FrmUnidadeVenda.LstSigla.Items.Clear()
            FrmUnidadeVenda.CmbUnidadeCompra.Items.Clear()

            For Each row In BuscaEstados.ToList
                FrmUnidadeVenda.LstIdUnidade.Items.Add(row.IdUnidade)
                FrmUnidadeVenda.LstSigla.Items.Add(row.Sigla)
                FrmUnidadeVenda.CmbUnidadeCompra.Items.Add(row.Sigla & " - " & row.Descricao)
            Next

            FrmUnidadeVenda.CmbUnidadeCompra.Enabled = True
            FrmUnidadeVenda.BttAddUnidade.Enabled = True
            FrmUnidadeVenda.CmbUnidadeCompra.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

            Dim Chave As Integer = FrmUnidadeVenda.LstIdUnidade.Items(FrmUnidadeVenda.CmbUnidadeCompra.SelectedIndex).ToString
            LqGeral.InsereNovaUnidadeFt_X(Chave, 1, Chave, False)

        End If

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub TxtDescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If Application.OpenForms.OfType(Of FrmProdutosNfRecebimento)().Count() = 0 Then

            If TxtDescrição.Text <> "" Then
                TxtSigla.Enabled = True
            Else
                TxtSigla.Enabled = False
                TxtSigla.Text = ""
            End If

        Else

            If TxtDescrição.Text <> "" Then
                TxtSigla.Enabled = True
            Else
                TxtSigla.Enabled = False
                TxtSigla.Text = ""
            End If

        End If

    End Sub
End Class