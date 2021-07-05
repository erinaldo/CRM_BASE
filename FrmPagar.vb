Public Class FrmPagar
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtCodProduto_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProduto.TextChanged

        If TxtCodProduto.Text <> "" And LblValorReceber.Text <> "" Then

            'verifica se valor é maior que o necessário

            Dim Vlr As Decimal = TxtCodProduto.Text
            Dim VlrEsp As Decimal = LblValorReceber.Text

            If Vlr >= VlrEsp Then

                BttSalvar.Enabled = True

            End If

        End If

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'manda informaçoes para o grid

        FrmPagamento.DtFormas.SelectedCells(5).Value = FormatCurrency(TxtCodProduto.Text, NumDigitsAfterDecimal:=2)
        FrmPagamento.DtFormas.SelectedCells(6).Value = FormatCurrency(0, NumDigitsAfterDecimal:=2)
        FrmPagamento.DtFormas.SelectedCells(9).Value = My.Resources.pngwing1
        FrmPagamento.DtFormas.SelectedCells(9).Value = My.Resources.check_ok_accept_apply_1582
        FrmPagamento.DtFormas.SelectedCells(10).Value = TxtIdentificador.Text
        FrmPagamento.DtFormas.SelectedCells(7).Value = ""

        Dim valorUnit As Decimal = LblValorReceber.Text
        Dim Data As Date = FrmPagamento.DtFormas.SelectedCells(4).Value

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim IdOrcamento As Integer = FrmPagamento.DtCotFinal.SelectedCells(0).Value

        'LqComercial.InsereNovaFormaPgOrcamento(IdForma, IdOrcamento, 1, valorUnit, TxtParcelas.Value, Data)

        FrmPagamento.Calcula_finais()

        Me.Close()

    End Sub

    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtCodProduto.GotFocus

        TxtCodProduto.Text = FormatNumber(TxtCodProduto.Text, NumDigitsAfterDecimal:=2)

        TxtCodProduto.SelectAll()

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtCodProduto.LostFocus

        Try

            Dim _ValorINserido As Decimal = TxtCodProduto.Text

            TxtCodProduto.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("O valor inserido é invalido.", vbOKOnly)
            TxtCodProduto.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtCodProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodProduto.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True
            BttSalvar.PerformClick()

        End If

    End Sub
End Class