Public Class FrmNovoEstado
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged
        If txtdescrição.Text <> "" Then
            TxtSigla.Enabled = True
        Else
            TxtSigla.Enabled = False
            TxtSigla.Text = ""
        End If
    End Sub

    Private Sub TxtSigla_TextChanged(sender As Object, e As EventArgs) Handles TxtSigla.TextChanged
        If TxtSigla.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Public FormOri As Integer
    Dim LqGeral As New DtCadastroDataContext
    Public IdPais As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqGeral.InsereEstado(IdPais, txtdescrição.Text, TxtSigla.Text, 0)

        If FormOri = 0 Then

        ElseIf FormOri = 1 Then

            'carrega para o form de colaborador

            'carrega todos os estados
            Dim BuscaEstados = From est In LqGeral.Estados
                               Where est.IdPais = IdPais
                               Select est.IdEstado, est.Sigla, est.Descricao

            FrmNovoEstoque.LstSiglaEstado.Items.Clear()
            FrmNovoEstoque.LstdescricaoEstado.Items.Clear()
            FrmNovoEstoque.CmbEstado.Items.Clear()
            FrmNovoEstoque.LstidEstadoTodos.Items.Clear()

            For Each row In BuscaEstados.ToList
                FrmNovoEstoque.LstidEstadoTodos.Items.Add(row.IdEstado)
                FrmNovoEstoque.LstSiglaEstado.Items.Add(row.Sigla)
                FrmNovoEstoque.LstdescricaoEstado.Items.Add(row.descricao)
                FrmNovoEstoque.CmbEstado.Items.Add(row.Sigla & " - " & row.descricao)
            Next

            FrmNovoEstoque.CmbEstado.SelectedItem = TxtSigla.Text & " - " & txtdescrição.Text

        End If

        Me.Close()

    End Sub
End Class