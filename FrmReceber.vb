Public Class FrmReceber

    Public LstIdBandeira As New ListBox
    Public LstParcela As New ListBox
    Public LstIdentifica As New ListBox

    Public IdForma As Integer = 0

    Private Sub FrmReceber_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        TxtCodProduto.Focus()

    End Sub

    Private Sub CmbBandeira_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBandeira.SelectedIndexChanged

        'seleciona 

        If CmbBandeira.Items.Contains(CmbBandeira.Text) Then
            TxtParcelas.Maximum = LstParcela.Items(CmbBandeira.SelectedIndex).ToString
            If LstIdentifica.Items(CmbBandeira.SelectedIndex).ToString = True Then
                TxtIdentificador.Enabled = True
            Else
                TxtIdentificador.Enabled = False
                TxtIdentificador.Text = "NA"
            End If
        End If

        If TxtParcelas.Minimum = TxtParcelas.Maximum Then
            TxtParcelas.Enabled = False
        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtCodProduto_TextChanged(sender As Object, e As EventArgs) Handles TxtCodProduto.TextChanged

        If TxtCodProduto.Text <> "" And LblValorReceber.Text <> "" Then

            'verifica se valor é maior que o necessário

            Dim Vlr As Decimal = TxtCodProduto.Text
            Dim VlrEsp As Decimal = LblValorReceber.Text

            If Vlr >= VlrEsp Then

                LblTroco.Text = FormatCurrency(Vlr - VlrEsp, NumDigitsAfterDecimal:=2)
                BttSalvar.Enabled = True

            End If

        End If

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

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'manda informaçoes para o grid

        FrmCaixa.DtFormas.SelectedCells(5).Value = TxtCodProduto.Text
        FrmCaixa.DtFormas.SelectedCells(6).Value = LblTroco.Text
        FrmCaixa.DtFormas.SelectedCells(9).Value = My.Resources.pngwing1
        FrmCaixa.DtFormas.SelectedCells(9).Value = My.Resources.check_ok_accept_apply_1582
        FrmCaixa.DtFormas.SelectedCells(10).Value = TxtIdentificador.Text
        FrmCaixa.DtFormas.SelectedCells(7).Value = ""

        Dim valorUnit As Decimal = LblValorReceber.Text
        Dim Data As Date = FrmCaixa.DtFormas.SelectedCells(4).Value

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim IdOrcamento As Integer = FrmCaixa.DtCotFinal.SelectedCells(0).Value

        'LqComercial.InsereNovaFormaPgOrcamento(IdForma, IdOrcamento, 1, valorUnit, TxtParcelas.Value, Data)

        FrmCaixa.Calcula_finais()

        Me.Close()

    End Sub

    Private Sub TxtCodProduto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCodProduto.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If TxtIdentificador.Enabled = False Then
                TxtCodProduto.Text = FormatCurrency(TxtCodProduto.Text, NumDigitsAfterDecimal:=2)
                BttSalvar.PerformClick()
            Else
                TxtIdentificador.Focus()
            End If
        End If

    End Sub
End Class