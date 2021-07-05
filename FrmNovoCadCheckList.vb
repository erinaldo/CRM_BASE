Public Class FrmNovoCadCheckList
    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Public NivelReq As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.Cheklist
                         Where tod.Nivel_req = NivelReq
                         Select tod.IdChecklist

        'insere checklist

        LqOficina.InsereNovoChecklist(0, Today.Date, True, NivelReq, BuscaTodos.Count + 1, txtdescrição.Text)

        FrmFluxo.TrFluxo.Nodes.Clear()

        FrmFluxo.PublicaTreeview()

        Me.Close()

    End Sub
End Class