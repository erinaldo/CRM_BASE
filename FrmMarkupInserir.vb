Imports System.Net

Public Class FrmMarkupInserir

    Public LstProds As New ListBox

    Public Sub Veriica_Lista()

        If LstProds.Items.Count > 0 Then

            'busca o item

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim LqBase As New LqOficinaDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Cod_Str As String = LstProds.Items(0).ToString

            'verifica se produto é uma solicitação

            If Cod_Str.ToString.StartsWith("S") Then

                'procura solicitação de cadastro

                'Dim BuscaSol = From ofi In LqOficina.SolicitacaoCadastroPeca
                'Where ofi.IdSolicitacaoCadastro = 
            End If

        End If

    End Sub

    Private Sub FrmMarkupInserir_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub


    Private Sub TxtMarkup_ValueChanged(sender As Object, e As EventArgs) Handles TxtMarkup.ValueChanged

        If TxtMarkup.Value > 0 Then

            Dim VlrAquisicao As Decimal = LblAquisicao.Text

            LblRevenda.Text = FormatCurrency(VlrAquisicao + (VlrAquisicao * (TxtMarkup.Value / 100)), NumDigitsAfterDecimal:=2)

            BttSalvarMarkup.Enabled = True
            BttSalvarMarkupCot.Enabled = True

        Else

            Dim VlrAquisicao As Decimal = LblAquisicao.Text

            LblRevenda.Text = FormatCurrency(VlrAquisicao, NumDigitsAfterDecimal:=2)

            BttSalvarMarkup.Enabled = False
            BttSalvarMarkupCot.Enabled = False

        End If

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub LblAquisicao_Click(sender As Object, e As EventArgs) Handles LblAquisicao.Click

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
    Private Sub LblAquisicao_TextChanged(sender As Object, e As EventArgs) Handles LblAquisicao.TextChanged

        If LblAquisicao.Text <> "" Then
            CalculaValores()
        End If

    End Sub

    Private Sub BttSalvarMarkup_Click(sender As Object, e As EventArgs) Handles BttSalvarMarkup.Click

        'Atualiza os dados do markup do produto

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim Cod As String = LblCodigo.Text

        If Not LblCodigo.Text.StartsWith("S") Then

            Cod = LblCodigo.Text

            LqBase.AtualizaMarkupProduto(LblCodigo.Text, TxtMarkup.Value)

            'Atualiza preço nos produtos armazenados

            Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
            LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

            LqEstoqueLocal.AtualizavalorRevendaArmaz(LblCodigo.Text, LblRevenda.Text)
            'Manda informaçao para o grid


            Dim BuscaExterno = From sol In LqBase.Produtos
                               Where sol.IdProduto = Cod
                               Select sol.IdProdutoExt

            Cod = BuscaExterno.First

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Else

            Cod = LblCodigo.Text

            Cod = Cod.Remove(0, 5)

            LqFinanceiro.AtualizaMarkupCotacaoProdutos(0, Cod, TxtMarkup.Value)

            'busca codigo externo

            Dim LqOficina As New LqOficinaDataContext
            LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

            Dim BuscaExterno = From sol In LqOficina.SolicitacaoCadastroPeca
                               Where sol.IdSolicitacaoCadastro = Cod
                               Select sol.IdCodExt

            'atualiza markup da solicitacao de cadastro

            LqOficina.AtualizaIMkpSolicitacaoCadPeca(Cod, TxtMarkup.Value)

            Cod = BuscaExterno.First

        End If


        FrmListaMarkup.DtEsperados.SelectedCells(3).Value = FormatPercent(TxtMarkup.Value / 100, NumDigitsAfterDecimal:=4)
        FrmListaMarkup.DtEsperados.SelectedCells(4).Value = FrmListaMarkup.ImageList1.Images(1)

        'atualiza preço na base de dados

        Dim LqEstoque As New LqEstoqueLocalDataContext
        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                               Where arm.IdProduto = Cod
                               Select arm.Qt, arm.ValorRevenda

        If BuscaArmazenagem.Count > 0 Then

            Dim qt As Integer = 0

            For Each rows In BuscaArmazenagem.ToList

                qt += rows.Qt

            Next

            Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_preco_mkp.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdProdutoEst=" & Cod & "&VlrUnit" & LblRevenda.Text.Replace(",", ".") & "&QtdadeEstoque=" & qt

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

        Else

            'atualiza markup do produto cotado

            Dim Revenda As Decimal = LblRevenda.Text

            Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_preco_mkp.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdProdutoEst=" & Cod & "&VlrUnit=" & Revenda.ToString.Replace(",", ".") & "&QtdadeEstoque=" & 0

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

        End If

        Me.Close()

    End Sub

    Private Sub BttSalvarMarkupCot_Click(sender As Object, e As EventArgs) Handles BttSalvarMarkupCot.Click

    End Sub
End Class