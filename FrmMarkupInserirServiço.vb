Imports System.Net
Imports Newtonsoft.Json

Public Class FrmMarkupInserirServiço
    Private Sub BttSalvarMarkup_Click(sender As Object, e As EventArgs) Handles BttSalvarMarkup.Click

        'atualiza markup

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        LqBase.AtualizaMarkupServico(LblCodigo.Text, TxtMarkup.Value, LblCustoTotal.Text, LblRevenda.Text)

        FrmListaMarkup.DtServicos.SelectedCells(2).Value = FormatPercent(TxtMarkup.Value / 100, NumDigitsAfterDecimal:=4)
        FrmListaMarkup.DtServicos.SelectedCells(3).Value = FrmListaMarkup.ImageList1.Images(1)

        'carrega codigo ext

        Dim BuscaCodigoExt = From ext In LqBase.Servicos
                             Where ext.IdServico = _IdInterno
                             Select ext.IdServicoInt

        'atualiza preco on line

        Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_preco_mkp_servico.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdServicoInt=" & BuscaCodigoExt.First & "&VlrSugerido=" & FormatNumber(LblRevenda.Text, NumDigitsAfterDecimal:=2).Replace(",", ".")

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)


        Me.Close()

    End Sub

    Private Sub TxtMarkup_ValueChanged(sender As Object, e As EventArgs) Handles TxtMarkup.ValueChanged

        If TxtMarkup.Value > 0 Then

            Dim VlrAquisicao As Decimal = LblAquisicao.Text

            LblRevenda.Text = FormatCurrency(VlrAquisicao + (VlrAquisicao * (TxtMarkup.Value / 100)), NumDigitsAfterDecimal:=2)

            BttSalvarMarkup.Enabled = True
            BttSalvarMarkup.Enabled = True

        Else

            Dim VlrAquisicao As Decimal = LblAquisicao.Text

            LblRevenda.Text = FormatCurrency(VlrAquisicao, NumDigitsAfterDecimal:=2)

            BttSalvarMarkup.Enabled = False
            BttSalvarMarkup.Enabled = False

        End If

    End Sub
    Public Sub CalculaValores()

        Dim Aquisicao As Decimal = LblAquisicao.Text

        Dim SomaTudo As Decimal = Aquisicao

        LblCustoTotal.Text = FormatCurrency(SomaTudo, NumDigitsAfterDecimal:=2)

        'Calcula valores para markup

        If Aquisicao > 0 Then
            Dim Pct As Decimal = ((Aquisicao * 100) / SomaTudo) - 100
            LblMkpSug.Text = FormatPercent(((Pct + 15) / 100), NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub LblAquisicao_Click(sender As Object, e As EventArgs) Handles LblAquisicao.Click

    End Sub

    Private Sub LblAquisicao_TextChanged(sender As Object, e As EventArgs) Handles LblAquisicao.TextChanged

        If LblAquisicao.Text <> "" Then
            CalculaValores()
        End If

    End Sub

    Public _IdInterno As Integer

    Private Sub FrmMarkupInserirServiço_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca custos operacionais

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaProfissionais = From prof In LqBase.ProfissionalServico
                                 Where prof.IdServico = _IdInterno
                                 Select prof.IdProfissional

        Dim VlrTotal As Decimal = 0
        For Each row In BuscaProfissionais.ToList

            Dim BuscaCargo = From carg In LqBase.Cargos
                             Where carg.IdCargo = row
                             Select carg.RemuneracaoBase

            VlrTotal += BuscaCargo.First

        Next

        VlrTotal /= 220

        LblAquisicao.Text = FormatCurrency(VlrTotal, NumDigitsAfterDecimal:=2)

        'busca ferramentas

        Dim BuscaFerramentas = From prof In LqBase.FerramentasServico
                               Where prof.IdServico = _IdInterno
                               Select prof.Qtdade, prof.IdFerramenta

        For Each row In BuscaFerramentas.ToList

            'VlrTotal += BuscaCargo.First

        Next


    End Sub
End Class