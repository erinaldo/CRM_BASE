Public Class FrmAjusteItemNFvb
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub


    Dim LstCFOP As New ListBox

    Private Sub FrmAjusteItemNFvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'carrega CST

        'verifica se empresa cad simples

        If FrmEmitirNovaNF.CLienteSimples = False Then

            Label2.Text = "CST"

        Else

            Label2.Text = "CSOSN"

            CmbCST.Items.Add("102 - Tributada pelo Simples Nacional sem permissão de crédito")
            CmbCST.Items.Add("103 - Isenção do ICMS no Simples Nacional para faixa de receita bruta")
            CmbCST.Items.Add("300 - Imune")
            CmbCST.Items.Add("400 - Não tributada pelo Simples Nacional")
            CmbCST.Items.Add("500 - ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação")
            CmbCST.Items.Add("900 - Outros (a critério da UF)")

        End If

        'cadastra cfop 5000

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        'verifica se dentro do mesmo estado

        If FrmEmitirNovaNF.UfDestinatario = FrmEmitirNovaNF.UFEmissor Then

            Dim BuscaSaidasCFOP = From _CF In LqFinanceiro.CFOP
                                  Where _CF.idCFOP > 4999 And _CF.idCFOP < 5200
                                  Select _CF.descricao, _CF.Aplicacao, _CF.idCFOP

            For Each row In BuscaSaidasCFOP.ToList
                CmbCFOP.Items.Add(row.idCFOP & " - " & row.descricao)
                LstCFOP.Items.Add(row.idCFOP)
            Next

        Else

            Dim BuscaSaidasCFOP = From _CF In LqFinanceiro.CFOP
                                  Where _CF.idCFOP > 5999 And _CF.idCFOP < 6200
                                  Select _CF.descricao, _CF.Aplicacao, _CF.idCFOP

            For Each row In BuscaSaidasCFOP.ToList
                CmbCFOP.Items.Add(row.idCFOP & " - " & row.descricao)
                LstCFOP.Items.Add(row.idCFOP)
            Next

        End If

    End Sub

    Public IdProduto As Integer

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles BtnOk.Click

        'popula no grid
        Dim strCST As String = CmbCST.SelectedItem
        Dim separadorCST() As Char = "-"
        ' Separa string baseado no delimitador
        Dim palavrasCST As String() = strCST.Split(separadorCST)

        FrmEmitirNovaNF.DtProdutos.Rows(FrmEmitirNovaNF.DtProdutos.SelectedCells(0).RowIndex).Cells(4).Value = palavrasCST.First.Remove(palavrasCST.First.ToLower.Length - 1, 1)

        Dim strCFOP As String = CmbCFOP.SelectedItem
        Dim separadorCFOP() As Char = "-"
        ' Separa string baseado no delimitador
        Dim palavrasCFOP As String() = strCFOP.Split(separadorCFOP)

        FrmEmitirNovaNF.DtProdutos.Rows(FrmEmitirNovaNF.DtProdutos.SelectedCells(0).RowIndex).Cells(5).Value = palavrasCFOP.First.Remove(palavrasCFOP.First.ToLower.Length - 1, 1)

        'popula dados fiscais

        If TxtNCM.Text <> "" Then

            'atualiza dados 

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            LqBase.AtualizaNCM(IdProduto, TxtNCM.Text)

            FrmEmitirNovaNF.DtProdutos.Rows(FrmEmitirNovaNF.DtProdutos.SelectedCells(0).RowIndex).Cells(2).Value = TxtNCM.Text

        End If

        If TxtEAN.Text <> "" Then

            Dim LqBase As New DtCadastroDataContext
            LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            LqBase.AtualizaEAN(IdProduto, TxtEAN.Text)

            FrmEmitirNovaNF.DtProdutos.Rows(FrmEmitirNovaNF.DtProdutos.SelectedCells(0).RowIndex).Cells(3).Value = TxtEAN.Text

        End If

        Me.Close()

    End Sub

    Private Sub CmbCFOP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCFOP.SelectedIndexChanged

        If CmbCFOP.Items.Contains(CmbCFOP.Text) Then

            Dim strCFOP As String = CmbCFOP.SelectedItem
            Dim separadorCFOP() As Char = "-"
            ' Separa string baseado no delimitador
            Dim palavrasCFOP As String() = strCFOP.Split(separadorCFOP)

            Dim NumCFOP = palavrasCFOP.First.Remove(palavrasCFOP.First.ToLower.Length - 1, 1)

            'procura CST

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaCST = From cst In LqFinanceiro.CST
                           Where cst.CFOP = NumCFOP
                           Select cst.IdCST, cst.descricao, cst.CSTPISCOFINS

            CmbCST.Items.Clear()

            For Each row In BuscaCST.ToList

                Dim NumCST As String = row.CSTPISCOFINS

                If NumCST.Length = 1 Then
                    NumCST = "00" & NumCST
                ElseIf NumCST.Length = 2 Then
                    NumCST = "0" & NumCST
                End If

                If Not CmbCST.Items.Contains(NumCST & " - " & row.descricao) Then
                    CmbCST.Items.Add(NumCST & " - " & row.descricao)
                End If

            Next

        End If

    End Sub
End Class