Public Class FrmAndarEstoqueLocal

    Public IdPredio As Integer
    Public IdEstoque As Integer

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Dim SelectIndex As Integer = -1

    Private Sub ListView2_DoubleClick(sender As Object, e As EventArgs) Handles ListView2.DoubleClick
        Try

            SelectIndex = ListView2.SelectedItems.Item(0).Index

            'verifica qual item esta selecionado

            If SelectIndex > -1 Then

                Dim _IdQuadra As Integer = TrEstoque.Nodes(0).Nodes(SelectIndex).Text

                FrmEndereciEstoqueLocal.IdAndar = _IdQuadra
                FrmEndereciEstoqueLocal.IdEstoque = IdEstoque

                FrmEndereciEstoqueLocal.Show(Me)

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
    Public Sub CarregaInicio()

        Dim LqEstoqueLocal As New LqEstoqueLocalDataContext
        LqEstoqueLocal.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        TrEstoque.Nodes.Clear()

        ListView2.Items.Clear()

        'busca estoques locais

        Dim BuscaEstoqueLocal = From est In LqEstoqueLocal.AndarEstoqueLocal
                                Where est.IdPredio = IdPredio And est.IdEstoque = IdEstoque
                                Select est.NomeAndar, est.IdAndar

        TrEstoque.Nodes.Add("Andares")

        For Each row In BuscaEstoqueLocal.ToList

            TrEstoque.Nodes(0).Nodes.Add(row.IdAndar)
            ListView2.Items.Add(row.NomeAndar.ToString)
            ListView2.Items(ListView2.Items.Count - 1).ImageIndex = 0

        Next

    End Sub

    Private Sub FrmAndarEstoqueLocal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        carregaInicio()

    End Sub

    Private Sub BtnNovo_Click(sender As Object, e As EventArgs) Handles BtnNovo.Click

        FrmNovoAndarEstoqueLocal.IdPredio = IdPredio
        FrmNovoAndarEstoqueLocal.IdEstoque = IdEstoque

        FrmNovoAndarEstoqueLocal.Show(Me)

    End Sub
End Class