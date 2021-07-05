Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNovaFormaPgSaida
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TxtDescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then

            CkAvista.Enabled = True
            CkCartao.Enabled = True

            CmbContaVinculada.Enabled = True
            BtnAddCarteira.Enabled = True

            TxtIntervalo.Enabled = True
            TxtParcelas.Enabled = True

            PnnIntervalo.Enabled = True

            RdbDia.Enabled = True
            RdbMeses.Enabled = True

        Else

            CkAvista.Enabled = False
            CkCartao.Enabled = False

            CmbContaVinculada.Enabled = False
            TxtIntervalo.Enabled = False
            TxtParcelas.Enabled = False
            BtnAddCarteira.Enabled = False

            PnnIntervalo.Enabled = False

            CkAvista.Checked = False
            CkCartao.Checked = False
            CmbContaVinculada.Text = ""
            TxtIntervalo.Value = 1
            TxtParcelas.Value = 1

            PnnIntervalo.Enabled = False
            RdbDia.Checked = False
            RdbMeses.Checked = False

        End If

    End Sub

    Private Sub CkCartao_CheckedChanged(sender As Object, e As EventArgs) Handles CkCartao.CheckedChanged

        Me.Cursor = Cursors.WaitCursor

        If CkCartao.Checked = True Then

            CmbContaVinculada.Enabled = False
            TxtParcelas.Enabled = False
            TxtIntervalo.Enabled = False

            RdbDebito.Enabled = True
            RdbCredito.Enabled = True
            GpCartao.Enabled = True
            TxtNumCartao.Enabled = True

            CmbContaVinculada.Text = ""
            TxtIntervalo.Value = 1
            TxtParcelas.Value = 1
            PnnIntervalo.Enabled = False
            RdbDia.Checked = False
            RdbMeses.Checked = False

            'busca bandeiras de cartões

            Dim baseUrlBandeira As String = "http://www.iarasoftware.com.br/bandeiras_cartoes.php"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientBandeira = New WebClient()

            ' Chamada sincrona
            Dim contentBandeira = syncClientBandeira.DownloadString(baseUrlBandeira)

            Dim readBandeira = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.BandeiraCartao))(contentBandeira)

            Dim Img As Image = My.Resources.dollars_98561

            For Each read In readBandeira.ToList
                CmbBandeira.Items.Add(read.name.ToUpper)
            Next

            Me.Cursor = Cursors.Arrow

        Else
            RdbDebito.Enabled = False
            RdbCredito.Enabled = False
            GpCartao.Enabled = False
            TxtNumCartao.Enabled = False

            RdbDebito.Checked = False
            RdbCredito.Checked = False
            TxtNumCartao.Text = "0000000000000000"

            CmbContaVinculada.Enabled = True
            TxtParcelas.Enabled = False
            TxtIntervalo.Enabled = False

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub TxtNumCartao_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNumCartao.MaskInputRejected

    End Sub

    Private Sub TxtNumCartao_TextChanged(sender As Object, e As EventArgs) Handles TxtNumCartao.TextChanged

        If TxtNumCartao.Text.Length = 16 And Val(TxtNumCartao.Text) <> 0 Then
            TxtValidade.Enabled = True
            TxtValidade.Focus()
        Else
            TxtValidade.Enabled = False
            TxtValidade.Text = "0000"
        End If

    End Sub

    Private Sub TxtValidade_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtValidade.MaskInputRejected


    End Sub

    Private Sub TxtValidade_TextChanged(sender As Object, e As EventArgs) Handles TxtValidade.TextChanged

        Try

            If TxtValidade.Text.Length = 4 And Val(TxtValidade.Text) <> 0 Then
                'verifica se validade é invalida
                Dim HJ As Date = Today.Day & "/" & Today.Month & "/" & Today.Year.ToString.ToCharArray(2, 2)
                Dim Vali As Date = Today.Day & "/" & TxtValidade.Text.ToCharArray(0, 2) & "/" & TxtValidade.Text.ToCharArray(2, 2)

                If Vali >= HJ Then
                    TxtNomeTitular.Enabled = True
                    TxtNomeTitular.Focus()
                Else
                    If MsgBox("Este cartão está vencido.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                        TxtNomeTitular.Enabled = False
                        TxtNomeTitular.Text = ""

                        TxtValidade.Text = ""
                        TxtValidade.SelectionStart = 0
                    End If
                End If
            Else
                TxtNomeTitular.Enabled = False
                TxtNomeTitular.Text = ""
            End If

        Catch ex As Exception

            MsgBox("O formato da validade está incorreto!", vbOKOnly)

            TxtValidade.Text = ""

        End Try

    End Sub

    Private Sub TxtNumCartao_GotFocus(sender As Object, e As EventArgs) Handles TxtNumCartao.GotFocus

        TxtNumCartao.Text = ""

    End Sub

    Private Sub TxtValidade_GotFocus(sender As Object, e As EventArgs) Handles TxtValidade.GotFocus

        TxtValidade.Text = ""

    End Sub

    Private Sub TxtNomeTitular_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeTitular.TextChanged

        If TxtNomeTitular.Text <> "" Then
            TxtCVV.Enabled = True
        Else
            TxtCVV.Enabled = False
            TxtCVV.Text = ""
        End If

    End Sub

    Private Sub TxtCVV_TextChanged(sender As Object, e As EventArgs) Handles TxtCVV.TextChanged

        If CkCartao.Enabled = True Then

            If TxtCVV.Text <> "" Then
                TxtCVV.Enabled = True
                CmbBandeira.Enabled = True
                CmbContaVinculada.Enabled = True
            Else
                TxtCVV.Enabled = False
                CmbBandeira.Enabled = False
                CmbContaVinculada.Enabled = False

                CmbBandeira.Text = ""
                TxtCVV.Text = ""
            End If

        Else

            If CmbBandeira.Items.Contains(CmbBandeira.Text) Then

                If RdbCredito.Checked = True Then
                    TxtDiaFechamento.Enabled = True
                    TxtDiaVencimento.Enabled = True
                End If

                CmbContaVinculada.Enabled = True

            Else

                TxtDiaFechamento.Enabled = False
                TxtDiaVencimento.Enabled = False

                TxtDiaFechamento.Value = 1
                TxtDiaVencimento.Value = 1

                CmbContaVinculada.Enabled = False

            End If

        End If

    End Sub

    Private Sub CmbBandeira_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBandeira.SelectedIndexChanged

        If CmbBandeira.Enabled = True Then
            If CmbBandeira.Items.Contains(CmbBandeira.Text) Then

                If RdbCredito.Checked = True Then
                    TxtDiaFechamento.Enabled = True
                    TxtDiaVencimento.Enabled = True
                End If

            Else

                TxtDiaFechamento.Enabled = False
                TxtDiaVencimento.Enabled = False

                TxtDiaFechamento.Value = 1
                TxtDiaVencimento.Value = 1

            End If
        End If

    End Sub

    Private Sub FrmNovaFormaPgSaida_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca as contas cadastradas

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaFinanceiro = From fin In LqFinanceiro.Carteira
                              Where fin.IdCarteira Like "*"
                              Select fin.Descricao, fin.IdCarteira

        For Each it In BuscaFinanceiro.ToList
            CmbContaVinculada.Items.Add(it.Descricao)
            LstIdCarteira.Items.Add(it.IdCarteira)
        Next

    End Sub

    Private Sub BttAddBandeira_Click(sender As Object, e As EventArgs)
        FrmBandeiraCartao.Show(Me)
    End Sub

    Private Sub RdbDebito_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDebito.CheckedChanged


    End Sub

    Private Sub TxtNumCartao_MouseClick(sender As Object, e As MouseEventArgs) Handles TxtNumCartao.MouseClick

    End Sub

    Private Sub TxtNumCartao_Click(sender As Object, e As EventArgs) Handles TxtNumCartao.Click

        If TxtNumCartao.Text <> "" Then

            Dim Valor As Integer = TxtNumCartao.Text.Length
            TxtNumCartao.SelectionStart = Valor

        Else

            TxtNumCartao.SelectionStart = 0

        End If

    End Sub

    Private Sub TxtNumCartao_SizeChanged(sender As Object, e As EventArgs) Handles TxtNumCartao.SizeChanged

    End Sub

    Private Sub TxtValidade_Click(sender As Object, e As EventArgs) Handles TxtValidade.Click

        If TxtValidade.Text <> "" Then

            Dim Valor As Integer = TxtValidade.Text.Length
            TxtValidade.SelectionStart = Valor

        Else

            TxtValidade.SelectionStart = 0

        End If
    End Sub

    Private Sub CkAvista_CheckedChanged(sender As Object, e As EventArgs) Handles CkAvista.CheckedChanged

        If CkAvista.Checked = True Then

            TxtIntervalo.Value = 1
            TxtIntervalo.Enabled = False

            TxtParcelas.Value = 1
            TxtParcelas.Enabled = False

            RdbDia.Enabled = False
            RdbMeses.Enabled = False

            RdbDia.Checked = True

        Else

            TxtIntervalo.Value = 1
            TxtIntervalo.Enabled = True

            TxtParcelas.Value = 1
            TxtParcelas.Enabled = True

            RdbDia.Checked = False
            RdbMeses.Checked = False

            RdbDia.Enabled = True
            RdbMeses.Enabled = True

        End If

    End Sub

    Public LstIdCarteira As New ListBox

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'cria nova forma pg saida

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim TipoCartao As Boolean = True
        If RdbCredito.Checked = True Then
            TipoCartao = False
        End If

        If CkAvista.Checked = True Then

            LqFinanceiro.InsereNovaFormaPgSaida(TxtDescrição.Text, CkAvista.CheckState, 0, 0, True, 0, LstIdCarteira.Items(CmbContaVinculada.SelectedIndex).ToString, 0, CmbBandeira.Text, TxtCVV.Text, TxtNomeTitular.Text, TxtDiaFechamento.Value, TxtDiaVencimento.Value, TxtNumCartao.Text, TxtValidade.Text, TxtLimite.Text, CkCartao.CheckState, TipoCartao)
        Else
            Dim ValorSel As Boolean = False
            If RdbDia.Checked = True Then
                ValorSel = True
            End If
            LqFinanceiro.InsereNovaFormaPgSaida(TxtDescrição.Text, CkAvista.CheckState, 0, TxtIntervalo.Value, ValorSel, TxtParcelas.Value, LstIdCarteira.Items(CmbContaVinculada.SelectedIndex).ToString, 0, CmbBandeira.Text, TxtCVV.Text, TxtNomeTitular.Text, TxtDiaFechamento.Value, TxtDiaVencimento.Value, TxtNumCartao.Text, TxtValidade.Text, TxtLimite.Text, CkCartao.CheckState, TipoCartao)
        End If

        Dim ValidadeCt As Date = "01/" & TxtValidade.Text.ToCharArray(0, 2) & "/" & TxtValidade.Text.ToCharArray(2, 2)

        If RdbCredito.Checked = True Then

            Dim Inicio As Date = Today.Date

            Dim Vencimento As Date = TxtDiaVencimento.Value & "/" & Today.Month & "/" & Today.Year

            Dim C As Integer = 1

            While Inicio < ValidadeCt

                If Inicio >= Vencimento Then

                    LqFinanceiro.InsereCategoriaPlanoContas("Cartões de crédito", False)

                    LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, Vencimento.Date, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescrição.Text & " " & C, "Cartões de crédito")

                    Dim IdBalancete As Integer = 0
                    IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                    LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, Inicio.AddDays(TxtDiaVencimento.Value - TxtDiaFechamento.Value), "1111-11-11")

                End If

                Inicio = Inicio.AddMonths(1)

            End While

        End If

        'carrega formas

        'carrega formas de pg entrada

        If Application.OpenForms.OfType(Of FrmPagamento)().Count() > 0 Then

            Dim BuscaCarteira = From cart In LqFinanceiro.FormasPgSaida
                                Where cart.IdFormasPgSaida Like "*" And cart.UsoInterno = False
                                Select cart.IdFormasPgSaida, cart.Descricao, cart.A_Vista, cart.Intervalo, cart.Parcelas, cart.TipoIntervalo

            FrmPagamento.LstIdFormasPg.Items.Clear()
            FrmPagamento.LstA_vista.Items.Clear()
            FrmPagamento.LstIntervalo.Items.Clear()
            FrmPagamento.LstParcelas.Items.Clear()
            FrmPagamento.LstTipoIntervalo.Items.Clear()
            FrmPagamento.CmbFormasPgEntrada.Items.Clear()

            For Each row In BuscaCarteira.ToList

                FrmPagamento.LstIdFormasPg.Items.Add(row.IdFormasPgSaida)
                FrmPagamento.LstA_vista.Items.Add(row.A_Vista)
                FrmPagamento.LstIntervalo.Items.Add(row.Intervalo)
                FrmPagamento.LstParcelas.Items.Add(row.Parcelas)
                FrmPagamento.LstTipoIntervalo.Items.Add(row.TipoIntervalo)
                FrmPagamento.CmbFormasPgEntrada.Items.Add(row.Descricao)

            Next

            FrmPagamento.CmbFormasPgEntrada.SelectedItem = TxtDescrição.Text

        ElseIf Application.OpenForms.OfType(Of ComprasFinanceiro)().Count() > 0 Then
            ComprasFinanceiro.VerificaValores()
            FrmFormasPgAceitaOnLine.Close()
        End If

        Me.Close()

    End Sub

    Private Sub CmbContaVinculada_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbContaVinculada.SelectedIndexChanged

        If CkCartao.Enabled = True Then
            If CmbContaVinculada.Items.Contains(CmbContaVinculada.Text) Then

                TxtParcelas.Enabled = True
                TxtIntervalo.Enabled = True

                If RdbDia.Enabled = False Then
                    BttSalvar.Enabled = True
                Else
                    BttSalvar.Enabled = False
                End If

            Else

                TxtParcelas.Enabled = False
                TxtIntervalo.Enabled = False

            End If
        Else

            If CmbContaVinculada.Items.Contains(CmbContaVinculada.Text) Then

                BttSalvar.Enabled = True

            Else

                BttSalvar.Enabled = False

            End If

        End If

    End Sub

    Private Sub RdbDia_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDia.CheckedChanged

        If RdbDia.Enabled = True Or RdbMeses.Enabled = True Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Private Sub BtnAddCarteira_Click(sender As Object, e As EventArgs) Handles BtnAddCarteira.Click
        FrmNovaConta.Show(Me)
    End Sub
End Class