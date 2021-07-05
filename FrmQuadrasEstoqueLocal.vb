Public Class FrmQuadrasEstoqueLocal

    Public _IdEstoque As Integer = 0

    Dim SelectIndex As Integer = -1
    Public Sub CarregaInicio()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        TrEstoque.Nodes.Clear()

        ListView2.Items.Clear()

        'busca estoques locais

        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.QuadrasEstoqueLocal
                                Where est.IdEstoque = _IdEstoque
                                Select est.NomeQuadra, est.IdQuadra

        TrEstoque.Nodes.Add("Quadras")

        For Each row In BuscaEstoqueLocal.ToList

            TrEstoque.Nodes(0).Nodes.Add(row.IdQuadra)
            ListView2.Items.Add(row.NomeQuadra.ToString)
            ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 0

        Next

    End Sub

    Private Sub BtnNovaQuadra_Click(sender As Object, e As EventArgs) Handles BtnNovaQuadra.Click

        FrmNovaQuadraEstoqueLocal.IdEstoque = _IdEstoque
        FrmNovaQuadraEstoqueLocal.Show(Me)

    End Sub

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged

        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex > -1 Then

                Dim _IdQuadra As Integer = TrEstoque.Nodes(0).Nodes(SelectIndex).Text

                FrmRuasEstoqueLocalvb.IdQuadra = _IdQuadra
                FrmRuasEstoqueLocalvb.IdEstoque = _IdEstoque

                FrmRuasEstoqueLocalvb.Show(Me)

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub FrmQuadrasEstoqueLocal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub
End Class