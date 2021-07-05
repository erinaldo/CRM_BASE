Public Class FrmRuasEstoqueLocalvb

    Public IdEstoque As Integer
    Public IdQuadra As Integer

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
    Public Sub CarregaInicio()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        TrEstoque.Nodes.Clear()

        ListView2.Items.Clear()

        'busca estoques locais

        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.RuasEstoqueLocal
                                Where est.IdEstoque = IdEstoque And est.IdQuadra = IdQuadra
                                Select est.NomeRua, est.IdRua

        TrEstoque.Nodes.Add("Ruas")

        For Each row In BuscaEstoqueLocal.ToList

            TrEstoque.Nodes(0).Nodes.Add(row.IdRua)
            ListView2.Items.Add(row.NomeRua.ToString)
            ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 0

        Next

    End Sub

    Private Sub BtnNovaQuadra_Click(sender As Object, e As EventArgs) Handles BtnNovaQuadra.Click

        FrmNovaRua.IdEstoque = IdEstoque
        FrmNovaRua.IdQuadra = IdQuadra

        FrmNovaRua.Show(Me)

    End Sub

    Private Sub FrmRuasEstoqueLocalvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Dim SelectIndex As Integer = -1

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex > -1 Then

                Dim _IdQuadra As Integer = TrEstoque.Nodes(0).Nodes(SelectIndex).Text

                FrmPrediosEstoqueLocal.IdRua = _IdQuadra
                FrmPrediosEstoqueLocal.IdEstoque = IdEstoque

                FrmPrediosEstoqueLocal.Show(Me)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

        Catch ex As Exception

        End Try

    End Sub

End Class