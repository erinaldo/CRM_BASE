Public Class FrmBaixarLançamento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmNovoLancamentoBalancete.LeIncio()

        Me.Close()

    End Sub

    Dim LqFinanceiro As New LqFinanceiroDataContext

    Public _Tipo As Boolean = False
    Public IdItemBalancete As Integer = 0
    Public IdFormaPg As Integer = 0
    Public DataEnc As Date

    Dim LstIdFormasPg As New ListBox
    Dim LstA_vista As New ListBox
    Dim LstIntervalo As New ListBox
    Dim LstParcelas As New ListBox
    Dim LstTipoIntervalo As New ListBox

    Private Sub FrmBaixarLançamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        If _Tipo = False Then

            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgSaida
                                Where cart.IdFormasPgSaida Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgSaida, cart.Descricao, cart.A_Vista, cart.Parcelas, cart.Intervalo, cart.TipoIntervalo

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgSaida)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

        Else

            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                Where cart.IdFormasPgEntrada Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Parcelas, cart.Intervalo, cart.TipoIntervalo

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next


        End If

        LblVencimento.Text = DataEnc

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

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If TxtValor.Text = "" Then
            TxtValor.Text = 0
            TxtValor.SelectAll()
        End If

        If TxtValor.Text <> "" Then

            BttInsere.Enabled = True

        End If

    End Sub

    Private Sub BttInsere_Click(sender As Object, e As EventArgs) Handles BttInsere.Click

        Dim Intervalo As Integer = LstIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString

        Dim NumParcela As Integer = NmParcelas.Value
        Dim Valor As Decimal = TxtValor.Text

        Dim C As Integer = 1

        If LstA_vista.Items(CmbFormasPgEntrada.SelectedIndex).ToString = False Then

            While NumParcela >= C

                If LstTipoIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                    DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * Intervalo), DateFormat.ShortDate), "", My.Resources.Delete_80_icon_icons_com_57340)

                Else

                    DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddMonths(C * Intervalo), DateFormat.ShortDate), "", My.Resources.Delete_80_icon_icons_com_57340)

                End If

                C += 1

            End While

        Else

            If LstTipoIntervalo.Items(CmbFormasPgEntrada.SelectedIndex).ToString = True Then

                DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddDays(C * Intervalo), DateFormat.ShortDate), "", My.Resources.Delete_80_icon_icons_com_57340)

            Else

                DtFormas.Rows.Add(LstIdFormasPg.Items(CmbFormasPgEntrada.SelectedIndex).ToString, CmbFormasPgEntrada.SelectedItem, C & " - " & NumParcela, FormatCurrency(Valor / NumParcela, NumDigitsAfterDecimal:=2), FormatDateTime(Today.AddMonths(0), DateFormat.ShortDate), "", My.Resources.Delete_80_icon_icons_com_57340)

            End If

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

    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus

        Try

            Dim _total As Decimal

            For Each row As DataGridViewRow In DtFormas.Rows
                _total += row.Cells(3).Value
            Next

            Dim _ValorINserido As Decimal = TxtValor.Text

            TxtValor.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        Dim LstIndexApagar As New ListBox

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

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

            End If

        End If

    End Sub

    Dim DataGuard As Date

    Private Sub DtFormas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellEndEdit

        'verifica se valor é valido, e se deseja incorporar mudanças nos próximos vencimentos

        Try

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DtFormas.Rows(e.RowIndex).Cells(4).Value, DateFormat.ShortDate)

            If MsgBox("Deseja atualizar as datas abaixo?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim Data As Date = DtFormas.Rows(e.RowIndex).Cells(4).Value
                Dim _Cod As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value
                'busca intervalo

                Dim BuscaIntervalo = From inter In LqFinanceiro.FormasPgSaida
                                     Where inter.IdFormasPgSaida = _Cod
                                     Select inter.Intervalo, inter.TipoIntervalo

                Dim _intervalo As Integer = BuscaIntervalo.First.Intervalo
                Dim _TipoIntervalo As Boolean = BuscaIntervalo.First.TipoIntervalo

                Dim _C As Integer = 1

                For Each row As DataGridViewRow In DtFormas.Rows

                    If row.Index > e.RowIndex Then

                        If row.Cells(0).Value = DtFormas.Rows(e.RowIndex).Cells(0).Value Then

                            If _TipoIntervalo = True Then

                                Data = Data.AddDays(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            Else

                                Data = Data.AddMonths(_C * _intervalo)

                                row.Cells(4).Value = FormatDateTime(Data, DateFormat.ShortDate)

                            End If

                            _C += 1

                        End If

                    End If

                Next

            End If

        Catch ex As Exception

            MsgBox("O valor não é uma data válida.", vbOKOnly)

            DtFormas.Rows(e.RowIndex).Cells(4).Value = FormatDateTime(DataGuard, DateFormat.ShortDate)

        End Try

    End Sub

    Private Sub DtFormas_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DtFormas.CellBeginEdit

        DataGuard = DtFormas.Rows(e.RowIndex).Cells(4).Value

    End Sub

    Public TipoS As Boolean = False
    Public Categoria As String = ""

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        'atualiza as formas de pagamento

        If _Tipo = False Then
            For Each row As DataGridViewRow In DtFormas.Rows

                'atualiza forma de pagamento 0

                Dim Valor As Decimal = row.Cells(3).Value
                Dim CodForma As Integer = row.Cells(0).Value
                Dim Vencimento As Date = row.Cells(4).Value

                If row.Index = 0 Then

                    'atualiza forma de pagamento

                    LqFinanceiro.AtualizaValorBalancete(IdItemBalancete, CodForma, Valor, row.Cells(5).Value)

                    'verifica se a data da baixa é diferente da data de vencimento

                    If DataEnc <> Today.Date Then

                        'lança na data correta

                        Dim BuscaDadosSaida = From cart In LqFinanceiro.FormasPgSaida
                                              Where cart.IdFormasPgSaida = CodForma
                                              Select cart.IdCarteira

                        Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                            Where cart.IdCarteira = BuscaDadosSaida.First And cart.Descricao Like "transferencia"
                                            Select cart.IdFormasPgEntrada

                        Dim BuscaDescricao = From desc In LqFinanceiro.BalanceteFinanceiro
                                             Where desc.IdItemBalancete = IdItemBalancete
                                             Select desc.Descricao

                        'insere a baixa e reinsere o estorno

                        LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, DataEnc, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, BuscaCarteira.First, row.Cells(5).Value, "estorno do item: " & BuscaDescricao.First, Categoria)

                        'lança na data correta


                        LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, Vencimento, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, False, CodForma, row.Cells(5).Value, "baixa do item: " & BuscaDescricao.First & " com vencimento em: " & Vencimento, Categoria)

                    End If

                Else

                    LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, DataEnc, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, False, CodForma, row.Cells(5).Value, "desmembrado do item: " & IdItemBalancete, Categoria)

                    Dim UltimoId As Integer = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                    'verifica se a data da baixa é diferente da data de vencimento

                    If DataEnc <> Today.Date Then

                        Dim BuscaDadosSaida = From cart In LqFinanceiro.FormasPgSaida
                                              Where cart.IdFormasPgSaida = CodForma
                                              Select cart.IdCarteira

                        Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                            Where cart.IdCarteira = BuscaDadosSaida.First And cart.Descricao Like "transferencia"
                                            Select cart.IdFormasPgEntrada

                        Dim BuscaDescricao = From desc In LqFinanceiro.BalanceteFinanceiro
                                             Where desc.IdItemBalancete = UltimoId
                                             Select desc.Descricao

                        'insere a baixa e reinsere o estorno
                        LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, Vencimento, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, BuscaCarteira.First, row.Cells(5).Value, "estorno do item: " & BuscaDescricao.First, Categoria)

                        LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, Today.Date, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, False, CodForma, row.Cells(5).Value, "baixa do item: " & BuscaDescricao.First & " com vencimento em: " & Vencimento, Categoria)

                    End If

                End If

            Next
        Else

            For Each row As DataGridViewRow In DtFormas.Rows

                'atualiza forma de pagamento 0

                Dim Valor As Decimal = row.Cells(3).Value
                Dim CodForma As Integer = row.Cells(0).Value
                Dim Vencimento As Date = row.Cells(4).Value

                If row.Index = 0 Then

                    'atualiza forma de pagamento

                    LqFinanceiro.AtualizaValorBalancete(IdItemBalancete, CodForma, Valor, row.Cells(5).Value)

                Else

                    LqFinanceiro.InsereNovaEntradaBalancete(0, Valor, 0, 0, Vencimento, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, CodForma, row.Cells(5).Value, "desmembrado do item: " & IdItemBalancete, Categoria)

                End If

            Next

        End If

        'atualiza solicitacao balancete

        LqFinanceiro.AtualizaBaixaBalancete(IdItemBalancete, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, TxtAcrescimo.Text, TxtDesconto.Text)

        FrmNovoLancamentoBalancete.LeIncio()
        FrmBalancete.ValidaInicio()

        Me.Close()

    End Sub

    Private Sub LblFormaPG_Click(sender As Object, e As EventArgs) Handles LblFormaPG.Click

        If LblFormaPG.Text <> "" Then

            'popula no grid o valor direcionado

            Dim BuscaForma = From forma In LqFinanceiro.FormasPgSaida
                             Where forma.IdFormasPgSaida = LblFormaPG.Text
                             Select forma.Descricao


        End If

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttInsere.PerformClick()
        End If

    End Sub
End Class