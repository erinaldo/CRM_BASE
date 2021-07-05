Public Class FrmNovoBairro
    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged
        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Public formori As Integer
    Public IdCidade As Integer
    Dim LqGeral As New DtCadastroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere novo bairro

        LqGeral.InsereBairro(IdCidade, txtdescrição.Text)

        If formori = 0 Then

        ElseIf formori = 1 Then
            'manda dados para o frmcadcolaboradores
            'carrega todos os estados
            Dim BuscaEstados = From est In LqGeral.Bairro
                                   Where est.IdCidade = IdCidade
                                   Select est.IdBairro, est.descricao

            FrmNovoEstoque.CmbBairro.Items.Clear()
            FrmNovoEstoque.LstIdBairroTodos.Items.Clear()

            For Each row In BuscaEstados.ToList
                FrmNovoEstoque.LstIdBairroTodos.Items.Add(row.IdBairro)
                FrmNovoEstoque.CmbBairro.Items.Add(row.descricao)
            Next

            FrmNovoEstoque.CmbBairro.Enabled = True
            FrmNovoEstoque.BttAddBairro.Enabled = True
            FrmNovoEstoque.CmbBairro.SelectedItem = txtdescrição.Text

        End If

            Me.Close()

    End Sub
End Class