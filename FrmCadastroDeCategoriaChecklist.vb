Public Class FrmCadastroDeCategoriaChecklist
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        FrmNovoChecklist.Opacity = 0.95
        Me.Close()
    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public _IdChecklist As Integer

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.ItemCheklist
                         Where tod.IdChecklist = _IdChecklist
                         Select tod.IdChecklist

        'insere checklist

        LqOficina.InsereNovaCategoriaChecklist(BuscaTodos.Count + 1, _IdChecklist, txtdescrição.Text)

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

    Private Sub FrmCadastroDeCategoriaChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtdescrição.Focus()

    End Sub
End Class