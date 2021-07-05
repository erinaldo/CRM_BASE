Public Class FrmUnidadeVenda
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
    End Sub

    Public LstIdUnidade As New ListBox
    Public LstSigla As New ListBox

    Private Sub BttAddUnidadeVEnda_Click(sender As Object, e As EventArgs) Handles BttAddUnidade.Click
        FrmUnidade.FormOri = 1
        FrmUnidade.Show(Me)
    End Sub

    Private Sub CmbUnidadeCompra_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbUnidadeCompra.SelectedIndexChanged
        If CmbUnidadeCompra.Items.Contains(CmbUnidadeCompra.Text) Then
            TxtEquivalencia.Enabled = True
        Else
            TxtEquivalencia.Enabled = False
            TxtEquivalencia.Text = ""
        End If
    End Sub

    Private Sub TxtEquivalencia_TextChanged(sender As Object, e As EventArgs) Handles TxtEquivalencia.TextChanged
        If TxtEquivalencia.Text <> "" Then
            RdbDividir.Enabled = True
            RdbMultiplicar.Enabled = True
        Else
            RdbDividir.Enabled = False
            RdbMultiplicar.Enabled = False
            RdbDividir.Checked = False
            RdbMultiplicar.Checked = False
        End If
    End Sub

    Private Sub RdbDividir_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDividir.CheckedChanged
        If RdbDividir.Checked = False And RdbMultiplicar.Checked = False Then
            BttSalvar.Enabled = False
        ElseIf RdbDividir.Checked = True Or RdbMultiplicar.Checked = True Then
            BttSalvar.Enabled = True
        End If
    End Sub

    Private Sub RdbMultiplicar_CheckedChanged(sender As Object, e As EventArgs) Handles RdbMultiplicar.CheckedChanged
        If RdbDividir.Checked = False And RdbMultiplicar.Checked = False Then
            BttSalvar.Enabled = False
        ElseIf RdbDividir.Checked = True Or RdbMultiplicar.Checked = True Then
            BttSalvar.Enabled = True
        End If
    End Sub

    Public _IdUnidadeOrigem As Integer
    Dim LqGeral As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        LqGeral.InsereNovaUnidadeFt_X(_IdUnidadeOrigem, TxtEquivalencia.Text, LstIdUnidade.Items(CmbUnidadeCompra.SelectedIndex).ToString, RdbDividir.Checked)
        LqGeral.InsereNovaUnidadeFt_X(LstIdUnidade.Items(CmbUnidadeCompra.SelectedIndex).ToString, TxtEquivalencia.Text, _IdUnidadeOrigem, RdbMultiplicar.Checked)

        Dim GuardaString As String = FrmProduto.CmbUnidadeCompra.Text

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

        FrmProduto.CmbUnidadeCompra.SelectedItem = GuardaString

        'carrega no formulario frmprodutos
        'busca divisor
        Dim BuscaValor = From div In LqGeral.UnidadesGeral
                         Where div.IdUnidade = _IdUnidadeOrigem
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
            Dim BuscaChave = From chave In LqGeral.UnidadeParametro
                             Where chave.IdUnidade = row.ChaveValidada
                             Select chave.Descricao, chave.Sigla

            FrmProduto.CmbUnidadeVenda.Items.Add(BuscaChave.First.Sigla & " - " & BuscaChave.First.Descricao)
        Next

        FrmProduto.CmbUnidadeVenda.SelectedItem = CmbUnidadeCompra.Text

        Me.Close()
    End Sub
End Class