Public Class FrmCaixa
    Private Sub FrmCaixa_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Busca orçamentos

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim BuscaOrçamentos = From orc In LqComercial.Orcamentos
                              Where orc.Aprovado = True And orc.ValorRecebido = False
                              Select orc.IdOrcamento, orc.IdCliente, orc.DataAprov, orc.ValorRecebido

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        For Each row In BuscaOrçamentos.ToList

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaCliente = From cli In LqBase.Clientes
                               Where cli.IdCliente = row.IdCliente
                               Select cli.RazaoSocial_nome

            'calcula total aprovado

            Dim BuscaItens = From it In LqComercial.ProdutosOrcamento
                             Where it.IdOrcamento = row.IdOrcamento
                             Select it.ValorUnit, it.DescontoUnit, it.Qtdade, it.Versao
                             Order By Versao Ascending

            Dim Total As Decimal = 0
            Dim _Versao As Integer = 0
            For Each linha0 In BuscaItens.ToList

                If _Versao <> linha0.Versao Then
                    _Versao = linha0.Versao
                    Total = 0
                    Total += (linha0.ValorUnit - linha0.DescontoUnit) * linha0.Qtdade
                Else
                    Total += (linha0.ValorUnit - linha0.DescontoUnit) * linha0.Qtdade
                End If

            Next

            DtCotFinal.Rows.Add(row.IdOrcamento, row.IdCliente, BuscaCliente.First, FormatCurrency(Total, NumDigitsAfterDecimal:=2), FormatDateTime(BuscaOrçamentos.First.DataAprov, DateFormat.ShortDate), ImageList1.Images(2), 2)

        Next

        DtCotFinal.Enabled = True

        If DtCotFinal.Enabled = True And DtCotFinal.Rows.Count > 0 Then

            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                Where cart.IdFormasPgEntrada Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            LstIdFormasPg.Items.Clear()
            LstA_vista.Items.Clear()
            LstIntervalo.Items.Clear()
            LstParcelas.Items.Clear()
            LstTipoIntervalo.Items.Clear()
            CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            Dim _IdOrcamento As Integer = DtCotFinal.SelectedCells(0).Value.ToString
            'Busca Formas de pagamento

            Dim BuscaFormasPgOrc = From forma In LqComercial.FormasPGOrcamento
                                   Where forma.IdOrcamento = _IdOrcamento
                                   Select forma.IdForma, forma.Pc, forma.Vencimento, forma.Valor, forma.IdFormPgOrc

            DtFormas.Rows.Clear()

            Dim Restante As Decimal = 0
            Dim Total As Decimal = 0

            For Each row In BuscaFormasPgOrc.ToList

                Dim BuscaForma = From frm In LqFinanceiro.FormasPgEntrada
                                 Where frm.IdFormasPgEntrada = row.IdForma
                                 Select frm.Descricao

                Dim BuscaREcebido = From rec In LqFinanceiro.BalanceteFinanceiro
                                    Where rec.IdOrcamento = _IdOrcamento And rec.IdFormaPg <> 0
                                    Select rec.Status, rec.Valor, rec.Identificador

                If BuscaREcebido.Count > 0 Then
                    If BuscaREcebido.First.Status = False Then

                        DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                        Restante += row.Valor
                        Total += row.Valor

                    Else

                        DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))
                        Total += row.Valor

                    End If
                Else

                    'apaga formas 

                End If

            Next

            Calcula_finais()

        End If

    End Sub

    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

    End Sub

    Dim LstIdFormasPg As New ListBox
    Dim LstA_vista As New ListBox
    Dim LstIntervalo As New ListBox
    Dim LstParcelas As New ListBox
    Dim LstTipoIntervalo As New ListBox

    Private Sub DtCotFinal_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellClick

        'carrega formas de pg entrada

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                            Where cart.IdFormasPgEntrada Like "*" And cart.UsoInterno = False
                            Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

        LstIdFormasPg.Items.Clear()
        LstA_vista.Items.Clear()
        LstIntervalo.Items.Clear()
        LstParcelas.Items.Clear()
        LstTipoIntervalo.Items.Clear()
        CmbFormasPgEntrada.Items.Clear()

        For Each row In BuscaCarteira.ToList

            LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
            LstA_vista.Items.Add(row.A_Vista)
            LstIntervalo.Items.Add(row.Intervalo)
            LstParcelas.Items.Add(row.Parcelas)
            LstTipoIntervalo.Items.Add(row.TipoIntervalo)
            CmbFormasPgEntrada.Items.Add(row.Descricao)

        Next

        'Busca Formas de pagamento

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim BuscaFormasPgOrc = From forma In LqComercial.FormasPGOrcamento
                               Where forma.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString
                               Select forma.IdForma, forma.Pc, forma.Vencimento, forma.Valor, forma.IdFormPgOrc

        DtFormas.Rows.Clear()

        Dim Restante As Decimal = 0
        Dim Total As Decimal = 0

        For Each row In BuscaFormasPgOrc.ToList

            Dim BuscaForma = From frm In LqFinanceiro.FormasPgEntrada
                             Where frm.IdFormasPgEntrada = row.IdForma
                             Select frm.Descricao

            Dim BuscaREcebido = From rec In LqFinanceiro.BalanceteFinanceiro
                                Where rec.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString And rec.IdFormaPg <> 0
                                Select rec.Status, rec.Valor, rec.Identificador

            If BuscaREcebido.Count > 0 Then
                If BuscaREcebido.First.Status = False Then

                    DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(0, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                    Restante += row.Valor
                    Total += row.Valor

                Else

                    DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))
                    Total += row.Valor

                End If
            Else

                'apaga formas 

            End If

        Next

        LblValorRestante.Text = FormatCurrency(Restante, NumDigitsAfterDecimal:=2)
        VlrTotalEnc = Restante

        Calcula_finais()

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

    Private Sub BttReceber_Click(sender As Object, e As EventArgs)

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        'Salva informaçoes

        Dim IdOrcamento As Integer = DtCotFinal.SelectedCells(0).Value
        Dim IdForma As Integer = DtFormas.SelectedCells(9).Value

        'LqFinanceiro.InsereNovaFormaEntradaBalancete(IdOrcamento, IdForma, LblTotalReceber.Text, TxtValor.Text, LblTroco.Text, Today.Date, Now.TimeOfDay)

        'Busca compensaçao

        Dim BuscaComp = From comp In LqFinanceiro.FormaRecebimentoBalancete
                        Where comp.IdOrcamento = IdOrcamento And comp.IdFormaOrcamento = IdForma
                        Select comp.IdFormaRecebimentoValor

        DtFormas.SelectedCells(10).Value = BuscaComp.First

        DtFormas.SelectedCells(6).Value = 0
        DtFormas.SelectedCells(5).Value = ImageList1.Images(0)

        DtFormas.SelectedCells(7).Value = TxtValor.Text

        TxtValor.Text = "R$ 0,00"
        TxtValor.Enabled = False

        'Calcula os recebidos

        Dim rec As Decimal = 0

        Dim C As Integer = 0

        For Each dt As DataGridViewRow In DtFormas.Rows

            If dt.Cells(6).Value = 0 Then
                rec += dt.Cells(2).Value
                C += 1
            End If

        Next

        Dim Restante As Decimal = DtFormas.SelectedCells(2).Value

        Restante -= rec

        If C = DtFormas.Rows.Count Then

            DtCotFinal.SelectedCells(6).Value = 0
            DtCotFinal.SelectedCells(5).Value = ImageList1.Images(0)

            'atualiza a finzalizaçao do orçamento

            LqFinanceiro.AtualizaPosicaoBalancete(IdOrcamento, IdForma, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario)

            DtCotFinal.Rows(DtCotFinal.SelectedCells(6).RowIndex).Visible = False

        Else

            DtCotFinal.SelectedCells(6).Value = 2
            DtCotFinal.SelectedCells(5).Value = ImageList1.Images(2)

        End If

        'Verifica se ainda existem lançamentos

        Dim Lanc As Integer = 0

        For Each row As DataGridViewRow In DtCotFinal.Rows

            If row.Cells(6).Value <> 0 Then

                Lanc += 1

            End If

        Next

        If Lanc = 0 Then

            If MsgBox("Não existem mais pagamentos a serem recebidos no momento.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information) Then
                Me.Close()
            End If

        End If

    End Sub

    Private Sub BttExtornar_Click(sender As Object, e As EventArgs)

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        LqFinanceiro.RemoveComensacaoBalancete(DtFormas.SelectedCells(10).Value.ToString)

        'Salva informaçoes

        DtFormas.SelectedCells(6).Value = 2
        DtFormas.SelectedCells(5).Value = ImageList1.Images(2)

        'Calcula os recebidos

        Dim rec As Decimal = 0

        Dim C As Integer = 0

        For Each dt As DataGridViewRow In DtFormas.Rows

            If dt.Cells(6).Value = 0 Then
                rec += dt.Cells(2).Value
                C += 1
            End If

        Next

        Dim Restante As Decimal = DtFormas.SelectedCells(2).Value

        Restante -= rec

        If C = DtFormas.Rows.Count Then

            DtCotFinal.SelectedCells(6).Value = 0
            DtCotFinal.SelectedCells(5).Value = ImageList1.Images(0)

        Else

            DtCotFinal.SelectedCells(6).Value = 2
            DtCotFinal.SelectedCells(5).Value = ImageList1.Images(2)

        End If

        'TxtValorRecebido.Focus()

    End Sub

    Private Sub DtFormas_CellEnter(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub BttSalvarMarkup_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

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


    Private Sub DtFormas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFormas.CellContentClick

        If DtFormas.Columns(e.ColumnIndex).Name = "ClmReceber" Then

            'procura bandeiras

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim _IdForma As Integer = DtFormas.Rows(e.RowIndex).Cells(0).Value

            Dim BuscaFinanceiro = From fin In LqFinanceiro.BandeirasFormaPG
                                  Where fin.IdForma = _IdForma
                                  Select fin.Descricao, fin.IdBandeira, fin.Parcelas, fin.IdentificaOpe

            'completa 

            FrmReceber.CmbBandeira.Items.Clear()
            FrmReceber.LstIdBandeira.Items.Clear()
            FrmReceber.LstParcela.Items.Clear()
            FrmReceber.LstIdentifica.Items.Clear()

            For Each row In BuscaFinanceiro.ToList

                FrmReceber.CmbBandeira.Items.Add(row.Descricao)
                FrmReceber.LstIdBandeira.Items.Add(row.IdBandeira)
                FrmReceber.LstParcela.Items.Add(row.Parcelas)
                FrmReceber.LstIdentifica.Items.Add(row.IdentificaOpe)

            Next

            If BuscaFinanceiro.Count = 1 Then

                FrmReceber.CmbBandeira.SelectedIndex = 0
                FrmReceber.CmbBandeira.Enabled = False

            End If

            FrmReceber.LblValorReceber.Text = DtFormas.SelectedCells(3).Value
            FrmReceber.Show(Me)

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

    Private Sub DtCotFinal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellEnter

        If DtCotFinal.Enabled = True Then

            'carrega formas de pg entrada

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                Where cart.IdFormasPgEntrada Like "*"
                                Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            LstIdFormasPg.Items.Clear()
            LstA_vista.Items.Clear()
            LstIntervalo.Items.Clear()
            LstParcelas.Items.Clear()
            LstTipoIntervalo.Items.Clear()
            CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            'Busca Formas de pagamento

            Dim LqComercial As New LqComercialDataContext
            LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

            Dim BuscaFormasPgOrc = From forma In LqComercial.FormasPGOrcamento
                                   Where forma.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString
                                   Select forma.IdForma, forma.Pc, forma.Vencimento, forma.Valor, forma.IdFormPgOrc

            DtFormas.Rows.Clear()

            Dim Restante As Decimal = 0
            Dim Total As Decimal = 0

            For Each row In BuscaFormasPgOrc.ToList

                Dim BuscaForma = From frm In LqFinanceiro.FormasPgEntrada
                                 Where frm.IdFormasPgEntrada = row.IdForma
                                 Select frm.Descricao

                Dim BuscaREcebido = From rec In LqFinanceiro.BalanceteFinanceiro
                                    Where rec.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString And rec.IdFormaPg <> 0
                                    Select rec.Status, rec.Valor, rec.Identificador

                If BuscaREcebido.Count > 0 Then
                    If BuscaREcebido.First.Status = False Then

                        DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                        Restante += row.Valor
                        Total += row.Valor

                    Else

                        DtFormas.Rows.Add(row.IdForma, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(0), My.Resources.alert_icon_icons_com_52395, "", ImageList2.Images(2))

                        Total += row.Valor

                    End If
                Else

                    'apaga formas 

                End If

            Next

            LblValorRestante.Text = FormatCurrency(Restante, NumDigitsAfterDecimal:=2)
            VlrTotalEnc = Restante

            Calcula_finais()

        End If

    End Sub

    Private Sub LblValorRestante_Click(sender As Object, e As EventArgs) Handles LblValorRestante.Click

    End Sub

    Private Sub LblValorRestante_TextChanged(sender As Object, e As EventArgs) Handles LblValorRestante.TextChanged

        If LblValorRestante.Text = 0 Then
            BtnConcluirRecebimento.Enabled = True
        Else
            BtnConcluirRecebimento.Enabled = False
        End If

    End Sub

    Private Sub BtnConcluirRecebimento_Click(sender As Object, e As EventArgs) Handles BtnConcluirRecebimento.Click

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim _IdOrcamento As Integer = DtCotFinal.SelectedCells(0).Value

        'apaga formas de pagamento da versão do orçamento

        LqComercial.DeletaFormasPgOrcamentoOrcamento(_IdOrcamento, 1)

        'insere novamente os produtos encontrados

        For Each row As DataGridViewRow In DtFormas.Rows

            Dim valorUnit As Decimal = row.Cells(3).Value
            Dim Cod As Decimal = row.Cells(0).Value
            Dim Data As Date = row.Cells(4).Value

            LqComercial.InsereNovaFormaPgOrcamento(Cod, _IdOrcamento, 1, valorUnit, row.Cells(2).Value, Data)

        Next

        'limpa os baixados

        'Busca orçamentos

        Dim BuscaOrçamentos = From orc In LqComercial.Orcamentos
                              Where orc.Aprovado = True
                              Select orc.IdOrcamento, orc.IdCliente

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        'manda informações de recebimento ao financeiro

        Dim BuscaIdOrcamento = From orc In LqFinanceiro.BalanceteFinanceiro
                               Where orc.IdOrcamento = _IdOrcamento
                               Select orc.IdItemBalancete

        If BuscaIdOrcamento.Count = 0 Then
            For Each row As DataGridViewRow In DtFormas.Rows

                Dim _id As Integer = row.Cells(0).Value
                Dim _ValorForma As Decimal = row.Cells(3).Value
                Dim _Vencimento As Date = row.Cells(4).Value

                LqFinanceiro.InsereNovaEntradaBalancete(_IdOrcamento, _ValorForma, 0, 0, _Vencimento, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, 0, True, _id, row.Cells(10).Value.ToString, "", "")

            Next

        Else

            For Each row As DataGridViewRow In DtFormas.Rows

                Dim _id As Integer = row.Cells(0).Value
                Dim _ValorForma As Decimal = row.Cells(3).Value
                Dim _Vencimento As Date = row.Cells(4).Value

                If row.Cells(7).Value <> "RC" Then
                    LqFinanceiro.AtualizaPosicaoBalancete(_IdOrcamento, _id, True, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario)
                End If

            Next

        End If

        LqComercial.AtualizaValorRecebidoOrcamento(_IdOrcamento)

        'reenvia informações de formulário
        DtCotFinal.Enabled = True

        If DtCotFinal.Enabled = True Then

            'carrega formas de pg entrada

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgEntrada
                                Where cart.IdFormasPgEntrada Like "*"
                                Select cart.IdFormasPgEntrada, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            LstIdFormasPg.Items.Clear()
            LstA_vista.Items.Clear()
            LstIntervalo.Items.Clear()
            LstParcelas.Items.Clear()
            LstTipoIntervalo.Items.Clear()
            CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                LstIdFormasPg.Items.Add(row.IdFormasPgEntrada)
                LstA_vista.Items.Add(row.A_Vista)
                LstIntervalo.Items.Add(row.Intervalo)
                LstParcelas.Items.Add(row.Parcelas)
                LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            'Busca Formas de pagamento

            Dim BuscaFormasPgOrc = From forma In LqComercial.FormasPGOrcamento
                                   Where forma.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString
                                   Select forma.IdForma, forma.Pc, forma.Vencimento, forma.Valor, forma.IdFormPgOrc

            DtFormas.Rows.Clear()

            Dim Restante As Decimal = 0
            Dim Total As Decimal = 0

            For Each row In BuscaFormasPgOrc.ToList

                Dim BuscaForma = From frm In LqFinanceiro.FormasPgEntrada
                                 Where frm.IdFormasPgEntrada = row.IdForma
                                 Select frm.Descricao

                Dim BuscaREcebido = From rec In LqFinanceiro.BalanceteFinanceiro
                                    Where rec.IdOrcamento = DtCotFinal.SelectedCells(0).Value.ToString And rec.IdFormaPg <> 0
                                    Select rec.Status, rec.Valor, rec.Identificador

                If BuscaREcebido.Count > 0 Then
                    If BuscaREcebido.First.Status = False Then

                        DtFormas.Rows.Add(row, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "", ImageList2.Images(0), My.Resources.check_ok_accept_apply_1582, BuscaREcebido.First.Identificador, ImageList2.Images(2))

                        Restante += row.Valor
                        Total += row.Valor

                    Else

                        DtFormas.Rows.Add(row, BuscaForma.First, row.Pc, FormatCurrency(row.Valor, NumDigitsAfterDecimal:=2), FormatDateTime(row.Vencimento, DateFormat.ShortDate), FormatCurrency(BuscaREcebido.First.Valor, NumDigitsAfterDecimal:=2), FormatCurrency(0, NumDigitsAfterDecimal:=2), "RC", ImageList2.Images(1), My.Resources.check_ok_accept_apply_1582, BuscaREcebido.First.Identificador, ImageList2.Images(2))
                        Total += row.Valor

                    End If
                Else

                    'apaga formas 

                End If

            Next

            Calcula_finais()

        End If

        'atualiza para recebido

        If DtCotFinal.Rows.Count = 0 Then

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        End If

        DtCotFinal.SelectedCells(5).Value = My.Resources.check_ok_accept_apply_1582

        For Each row As DataGridViewRow In DtCotFinal.Rows
            row.Visible = True
        Next

    End Sub

    Private Sub CmbFormasPgEntrada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbFormasPgEntrada.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            If NmParcelas.Enabled = True Then
                NmParcelas.Focus()
            Else
                TxtValor.Focus()
            End If
        End If
    End Sub

    Private Sub NmParcelas_ValueChanged(sender As Object, e As EventArgs) Handles NmParcelas.ValueChanged

    End Sub

    Private Sub NmParcelas_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NmParcelas.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            TxtValor.Focus()
        End If

    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttInsere.PerformClick()
        End If

    End Sub

    Private Sub FrmCaixa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

        If e.KeyCode = Keys.F12 Then

            If BtnConcluirRecebimento.Enabled = True Then
                BtnConcluirRecebimento.PerformClick()
            Else
                MsgBox("Não é possível encerrar o recebimento neste momento porque a valores que não foram recebidos.")
            End If

        End If

    End Sub
End Class