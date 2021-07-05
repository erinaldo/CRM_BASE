Public Class FrmFuncoesClientes
    Public IdCliente As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Public Sub CarregaInicio()

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaFuncoes = From fun In LqTrabalhista.FuncoesClientes
                           Where fun.IdCliente = IdCliente
                           Select fun.IdFuncaoCliente, fun.Descricao

        DtProdutos.Rows.Clear()

        For Each row In BuscaFuncoes.ToList
            DtProdutos.Rows.Add(row.IdFuncaoCliente, row.Descricao, ImageList1.Images(0), ImageList1.Images(1))
        Next

    End Sub

    Private Sub FrmFuncoesClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovaFuncaoCliente.IdCliente = IdCliente

        FrmNovaFuncaoCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub
End Class