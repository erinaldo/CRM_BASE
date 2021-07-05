Public Class FrmNovaConta
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub CkSemvinculo_CheckedChanged(sender As Object, e As EventArgs) Handles CkSemvinculo.CheckedChanged

        If CkSemvinculo.Checked = True Then

            CmbContasBancarias.Enabled = False
            TxtAgencia.Enabled = False
            TxtNumConta.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False

            RadioButton1.Checked = False
            RadioButton2.Checked = False
            CmbContasBancarias.Text = ""
            TxtAgencia.Text = ""
            TxtNumConta.Text = ""

        Else

            CmbContasBancarias.Enabled = True
            CmbContasBancarias.Text = ""

            TxtValor.Enabled = False
            TxtValor.Text = "R$ 0,00"

        End If

    End Sub

    Private Sub TxtNomeConta_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeConta.TextChanged

        If TxtNomeConta.Text <> "" Then

            CkCofre.Enabled = True
            CkSemvinculo.Enabled = True
            CmbContasBancarias.Enabled = True

        Else

            CkCofre.Enabled = False
            CkSemvinculo.Enabled = False

            CmbContasBancarias.Enabled = False
            CmbContasBancarias.Text = ""

            CkCofre.Checked = False
            CkSemvinculo.Checked = False

        End If

    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If TxtValor.Text = "" Then
            TxtValor.Text = 0
            TxtValor.SelectAll()
        End If

    End Sub

    Private Sub TxtAgencia_TextChanged(sender As Object, e As EventArgs) Handles TxtAgencia.TextChanged

        If TxtAgencia.Text <> "" Then
            TxtNumConta.Enabled = True
        Else
            TxtNumConta.Enabled = False
            TxtNumConta.Text = ""
        End If

    End Sub

    Private Sub TxtNumConta_TextChanged(sender As Object, e As EventArgs) Handles TxtNumConta.TextChanged

        If TxtNumConta.Text <> "" Then

            RadioButton1.Enabled = True
            RadioButton2.Enabled = True

        Else

            RadioButton1.Enabled = False
            RadioButton2.Enabled = False

            RadioButton1.Checked = False
            RadioButton2.Checked = False

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged

        If RadioButton1.Enabled = True Then

            If RadioButton1.Checked = True Or RadioButton2.Checked = True Then
                TxtValor.Enabled = True
                BttSalvarFormaDePgSaida.Enabled = True
            ElseIf RadioButton1.Checked = False And RadioButton2.Checked = False Then
                TxtValor.Enabled = False
                BttSalvarFormaDePgSaida.Enabled = False

                TxtValor.Text = "R$ 0,00"
            End If

        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged

        If RadioButton2.Enabled = True Then

            If RadioButton1.Checked = True Or RadioButton2.Checked = True Then
                TxtValor.Enabled = True
                BttSalvarFormaDePgSaida.Enabled = True
            ElseIf RadioButton1.Checked = False And RadioButton2.Checked = False Then
                TxtValor.Enabled = False
                BttSalvarFormaDePgSaida.Enabled = False

                TxtValor.Text = "R$ 0,00"
            End If

        End If
    End Sub

    Dim LstIdBanco As New ListBox

    Private Sub FrmNovaConta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaContas = From cont In LqFinanceiro.Bancos
                          Where cont.IdBanco Like "*"
                          Select cont.value, cont.label, cont.IdBanco

        For Each it In BuscaContas.ToList

            LstIdBanco.Items.Add(it.IdBanco)
            CmbContasBancarias.Items.Add(it.value & " - " & it.label)

        Next

    End Sub

    Private Sub CmbContasBancarias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContasBancarias.SelectedIndexChanged

        If CmbContasBancarias.Items.Contains(CmbContasBancarias.Text) Then
            TxtAgencia.Enabled = True
        Else
            TxtAgencia.Enabled = False
            TxtAgencia.Text = ""
        End If

    End Sub

    Private Sub BttSalvarFormaDePgSaida_Click(sender As Object, e As EventArgs) Handles BttSalvarFormaDePgSaida.Click

        'insere nova conta

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim TipoConta As Boolean = False

        If RadioButton2.Checked = True Then
            TipoConta = False
        End If

        LqFinanceiro.InsereNovaCarteira(TxtNomeConta.Text, CkCofre.CheckState, TxtAgencia.Text, TxtNomeConta.Text, TipoConta, LstIdBanco.Items(CmbContasBancarias.SelectedIndex).ToString, CmbContasBancarias.Text)

        Dim UltimaCarteira As Integer = LqFinanceiro.Carteira.ToList.Last.IdCarteira

        'insere formas de pg padrao

        LqFinanceiro.InsereNovaFormaPgSaida("transferencia", True, 0, 1, False, 1, UltimaCarteira, True, "", 0, "", 0, 0, "", 0, 0, False, False)
        LqFinanceiro.InsereNovaFormaPgEntrada("transferencia", True, False, 1, 1, UltimaCarteira, False, False, True)

        Dim _IdCarteira As Integer = LqFinanceiro.FormasPgEntrada.ToList.Last.IdFormasPgEntrada

        'insere entrada no caixa

        LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, Today.Date, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, _IdCarteira, "saldo inicial", "saldo inicial da conta: " & TxtNomeConta.Text, "Inicio de movimento bancário")

        If Application.OpenForms.OfType(Of FrmNovaFormaPgSaida)().Count() > 0 Then

            'busca as contas cadastradas

            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaFinanceiro = From fin In LqFinanceiro.Carteira
                                  Where fin.IdCarteira Like "*"
                                  Select fin.Descricao, fin.IdCarteira

            FrmNovaFormaPgSaida.CmbContaVinculada.Items.Clear()
            FrmNovaFormaPgSaida.LstIdCarteira.Items.Clear()

            For Each it In BuscaFinanceiro.ToList
                FrmNovaFormaPgSaida.CmbContaVinculada.Items.Add(it.Descricao)
                FrmNovaFormaPgSaida.LstIdCarteira.Items.Add(it.IdCarteira)
            Next

        End If

        Me.Close()

    End Sub

    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtValor.GotFocus

        TxtValor.Text = FormatNumber(TxtValor.Text, NumDigitsAfterDecimal:=2)
        TxtValor.SelectAll()

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus

        Try

            Dim _ValorINserido As Decimal = TxtValor.Text

            TxtValor.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

End Class