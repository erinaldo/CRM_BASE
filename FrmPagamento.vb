Public Class FrmPagamento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public LstIdFormasPg As New ListBox
    Public LstA_vista As New ListBox
    Public LstIntervalo As New ListBox
    Public LstParcelas As New ListBox
    Public LstTipoIntervalo As New ListBox

    Private Sub FrmPagamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Public Sub CarregaInicio()

        'Busca orçamentos

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim BuscaOrçamentos = From orc In LqFinanceiro.BalanceteFinanceiro
                              Where orc.Tipo = False And orc.DataBaixa = "1111-11-11" And orc.Vencimento <= Today.AddDays(10)
                              Select orc.Status, orc.IdVinculo, orc.Descricao, orc.IdFormaPg, orc.Valor, orc.Vencimento, orc.Identificador, orc.IdItemBalancete

        For Each row In BuscaOrçamentos.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            DtCotFinal.Rows.Add(row.IdVinculo, "", row.Descricao, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), ImageList1.Images(2), 2, row.IdItemBalancete)

        Next

        DtCotFinal.Enabled = True

        If DtCotFinal.Enabled = True And DtCotFinal.Rows.Count > 0 Then

            BtnNovaFormaPg.Enabled = True

            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgSaida
                                Where cart.IdFormasPgSaida Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgSaida, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            LstIdFormasPg.Items.Clear()
            LstA_vista.Items.Clear()
            LstIntervalo.Items.Clear()
            LstParcelas.Items.Clear()
            LstTipoIntervalo.Items.Clear()
            CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgSaida)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            Dim BuscaForma = From frm In LqFinanceiro.FormasPgSaida
                             Where frm.IdFormasPgSaida = BuscaOrçamentos.First.IdFormaPg
                             Select frm.Descricao

            Dim Restante As Decimal = 0
            Dim Total As Decimal = 0

            DtFormas.Rows.Clear()

            If BuscaForma.Count > 0 Then
                If BuscaOrçamentos.First.Status = False Then

                    DtFormas.Rows.Add(BuscaOrçamentos.First.IdFormaPg, BuscaForma.First, "1-1", FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(BuscaOrçamentos.First.Vencimento, DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                    Restante += BuscaOrçamentos.First.Valor
                    Total += BuscaOrçamentos.First.Valor

                Else

                    DtFormas.Rows.Add(BuscaOrçamentos.First.IdFormaPg, BuscaForma.First, "1-1", FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(BuscaOrçamentos.First.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))
                    Total += BuscaOrçamentos.First.Valor

                End If
            Else

                'apaga formas 

            End If

            Calcula_finais()

        ElseIf DtCotFinal.Enabled = False And DtCotFinal.Rows.Count = 0 Then

            BtnNovaFormaPg.Enabled = False

        ElseIf DtCotFinal.Rows.Count = 0 Then

            BtnNovaFormaPg.Enabled = False

        End If

    End Sub
    Private Sub CmbFormasPgEntrada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFormasPgEntrada.SelectedIndexChanged

        If CmbFormasPgEntrada.Items.Contains(CmbFormasPgEntrada.Text) Then

            If LstA_vista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                NmParcelas.Value = LstParcelas.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                NmParcelas.Enabled = False

                TxtValor.Enabled = True

            Else

                NmParcelas.Value = LstParcelas.Items(CmbFormasPgEntrada.SelectedIndex).ToString

                NmParcelas.Enabled = True

                TxtValor.Enabled = True

            End If

        Else

            NmParcelas.Enabled = False
            TxtValor.Enabled = False

            NmParcelas.Value = 1
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End If

        If CmbFormasPgEntrada.Text = "" Then

            NmParcelas.Enabled = False
            TxtValor.Enabled = False

            NmParcelas.Value = 1
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End If

    End Sub

    Dim VlrTotalEnc As Decimal

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If CmbFormasPgEntrada.Items.Contains(CmbFormasPgEntrada.Text) Then
            If TxtValor.Text = "" Then
                TxtValor.Text = 0
                TxtValor.SelectAll()
            End If

            If TxtValor.Text <> "" Then

                BttInsere.Enabled = True

                Dim Vlr As Decimal = LblValorRestante.Text

                'verifica os valores já lançados

                Dim Lançados As Decimal = 0

                For Each row As DataGridViewRow In DtFormas.Rows

                    'verifica se já foi baixado

                    If row.Cells(6).Value = 0 Then
                        Lançados += row.Cells(3).Value
                    End If

                Next

                Dim VlrLancado As Decimal = TxtValor.Text

                If TxtValor.Text > (Vlr - Lançados) Then

                    TxtValor.Text = FormatNumber((Vlr - Lançados), NumDigitsAfterDecimal:=2)
                    TxtValor.SelectAll()
                    BttInsere.Focus()

                End If

                If TxtValor.Text = 0 Then
                    BttInsere.Enabled = False
                End If

            End If

        End If


    End Sub

    Private Sub BttInsere_Click(sender As Object, e As EventArgs) Handles BttInsere.Click

        BttInsere.Enabled = False

        For Each row As DataGridViewRow In DtCotFinal.Rows

            If DtCotFinal.SelectedCells(0).RowIndex <> row.Index Then
                row.Visible = False
            End If
        Next

        Dim Intervalo As Integer = LstIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString

        Dim NumParcela As Integer = NmParcelas.Value
        Dim Valor As Decimal = TxtValor.Text

        Dim C As Integer = 1

        If LstA_vista.Items(CmbFormasPgEntrada.SelectedIndex) = False Then
            While NumParcela >= C

                If LstTipoIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                    DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * Intervalo), DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                End If

                C += 1

            End While

        Else

            DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * 0), DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

        End If

        CmbFormasPgEntrada.Text = ""

        NmParcelas.Enabled = False
        TxtValor.Enabled = False

        NmParcelas.Value = 1
        TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        Dim _ValorPg As Decimal

        For Each row As DataGridViewRow In DtFormas.Rows
            _ValorPg += row.Cells(3).Value
        Next


    End Sub

    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtValor.GotFocus

        TxtValor.Text = FormatNumber(TxtValor.Text, NumDigitsAfterDecimal:=2)
        TxtValor.SelectAll()

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus

        If TxtValor.Text = "" Then
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
        Else
            TxtValor.Text = FormatCurrency(TxtValor.Text, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Public Sub CarregaParcial()

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim IdItem As Integer = DtCotFinal.SelectedCells(7).Value
        Dim BuscaOrçamentos = From orc In LqFinanceiro.BalanceteFinanceiro
                              Where orc.IdItemBalancete = IdItem
                              Select orc.Status, orc.IdVinculo, orc.Descricao, orc.IdFormaPg, orc.Valor, orc.Vencimento, orc.Identificador, orc.IdItemBalancete

        If DtCotFinal.Enabled = True And DtCotFinal.Rows.Count > 0 Then

            BtnNovaFormaPg.Enabled = True
            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgSaida
                                Where cart.IdFormasPgSaida Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgSaida, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            LstIdFormasPg.Items.Clear()
            LstA_vista.Items.Clear()
            LstIntervalo.Items.Clear()
            LstParcelas.Items.Clear()
            LstTipoIntervalo.Items.Clear()
            CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgSaida)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            Dim BuscaForma = From frm In LqFinanceiro.FormasPgSaida
                             Where frm.IdFormasPgSaida = BuscaOrçamentos.First.IdFormaPg
                             Select frm.Descricao

            Dim Restante As Decimal = 0
            Dim Total As Decimal = 0

            DtFormas.Rows.Clear()

            If BuscaForma.Count > 0 Then
                If BuscaOrçamentos.First.Status = False Then

                    DtFormas.Rows.Add(BuscaOrçamentos.First.IdFormaPg, BuscaForma.First, "1-1", FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(BuscaOrçamentos.First.Vencimento, DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                    Restante += BuscaOrçamentos.First.Valor
                    Total += BuscaOrçamentos.First.Valor

                Else

                    DtFormas.Rows.Add(BuscaOrçamentos.First.IdFormaPg, BuscaForma.First, "1-1", FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(BuscaOrçamentos.First.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaOrçamentos.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))
                    Total += BuscaOrçamentos.First.Valor

                End If
            Else

                'apaga formas 

            End If

            Calcula_finais()

        ElseIf DtCotFinal.Enabled = False And DtCotFinal.Rows.Count = 0 Then

            BtnNovaFormaPg.Enabled = False

        ElseIf DtCotFinal.Rows.Count = 0 Then

            BtnNovaFormaPg.Enabled = False

        End If

    End Sub
    Public Sub Calcula_finais()

        Dim Troco As Decimal = 0
        Dim Recebidos As Decimal = 0
        Dim Restante As Decimal = DtCotFinal.SelectedCells(3).Value
        Dim Receber As Integer = 0

        For Each row As DataGridViewRow In DtFormas.Rows
            Troco += row.Cells(6).Value
            Recebidos += row.Cells(5).Value
            If row.Cells(7).Value <> "RC" Then
                Receber += 1
            End If
        Next

        LblTroco.Text = FormatCurrency(Troco, NumDigitsAfterDecimal:=2)
        LblRecebidos.Text = FormatCurrency(Recebidos, NumDigitsAfterDecimal:=2)

        LblValorRestante.Text = FormatCurrency((Restante - Recebidos) + Troco, NumDigitsAfterDecimal:=2)

        If Receber = 0 Then

            BtnConcluirRecebimento.Enabled = False

        End If

    End Sub

    Private Sub LblValorRestante_TextChanged(sender As Object, e As EventArgs) Handles LblValorRestante.TextChanged

        If LblValorRestante.Text = 0 Then
            BtnConcluirRecebimento.Enabled = True
        Else
            BtnConcluirRecebimento.Enabled = False
        End If

    End Sub

    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmReceber" Then

            'procura bandeiras

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim _IdForma As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value

            FrmPagar.LblValorReceber.Text = DtFormas.SelectedCells(3).Value
            FrmPagar.Show(Me)

        ElseIf DtFormas.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            Dim LstIndexApagar As New ListBox

            Dim IdSel As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value

            'varre pra ver se tem mais

            For Each row As DataGridViewRow In DtFormas.Rows

                If row.Cells(0).Value = IdSel Then

                    LstIndexApagar.Items.Add(row.Index)

                End If

            Next

            If MsgBox("Você tem certeza que deseja remover esta forma de pagamento?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                For i As Integer = LstIndexApagar.Items.Count - 1 To 0 Step -1

                    DtFormas.Rows.RemoveAt(LstIndexApagar.Items(i).ToString)

                Next

                Calcula_finais()

            End If


        End If

    End Sub

    Private Sub BtnConcluirRecebimento_Click(sender As Object, e As EventArgs) Handles BtnConcluirRecebimento.Click

        BtnConcluirRecebimento.Enabled = False

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim _id As Integer = row.Cells(0).Value
            Dim _ValorForma As Decimal = row.Cells(3).Value
            Dim _Vencimento As Date = row.Cells(4).Value

            If row.Cells(7).Value <> "RC" Then

                Dim _IdOrcamento As Integer = DtCotFinal.SelectedCells(7).Value

                LqFinanceiro.AtualizaPosicaoBalanceteSaida(_IdOrcamento, _id, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario)

            End If

        Next

        DtCotFinal.SelectedCells(5).Value = My.Resources.check_ok_accept_apply_1582

    End Sub

    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

    End Sub

    Private Sub DtCotFinal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellClick

        CarregaParcial()

    End Sub

    Private Sub DtCotFinal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellEnter

        If DtCotFinal.Enabled = True Then
            CarregaParcial()
        End If

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttInsere.PerformClick()
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnNovaFormaPg.Click

        FrmNovaFormaPgSaida.Show(Me)

    End Sub
End Class