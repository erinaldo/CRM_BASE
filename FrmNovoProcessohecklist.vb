Public Class FrmNovoProcessohecklist
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        FrmNovoChecklist.Opacity = 0.95
        Me.Close()
    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public _IdChecklist As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.ProcessosChecklist
                         Where tod.IdItem = _IdChecklist
                         Select tod.IdProcesso

        'insere checklist

        LqOficina.InsereNovoProcessoChecklist(_IdChecklist, BuscaTodos.Count + 1, txtdescrição.Text)

        FrmFluxo.TrFluxo.Nodes.Clear()

        FrmFluxo.PublicaTreeview()

        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub
End Class
