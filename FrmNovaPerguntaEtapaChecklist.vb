Public Class FrmNovaPerguntaEtapaChecklist
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmNovaEtapaChecklist.Opacity = 0.95
        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.PerguntasChecklist
                         Where tod.IdEtapaProcesso = FrmNovaEtapaChecklist.ChaveTemp
                         Select tod.IdPerguntaChecklit

        'insere checklist

        'LqOficina.InsereNovaPerguntaEtapaProcessoChecklist(FrmNovaEtapaChecklist.ChaveTemp, txtdescrição.Text, 1, BuscaTodos.Count + 1)

        'completa no frm anterior

        Dim BuscaChecklist = From tod In LqOficina.PerguntasChecklist
                             Where tod.IdEtapaProcesso = FrmNovaEtapaChecklist.ChaveTemp
                             Select tod.IdPerguntaChecklit, tod.Posicao, tod.Titulo, tod.TipoResposta
                             Order By Posicao Ascending

        FrmNovaEtapaChecklist.LstIdPerguntas.Items.Clear()
        FrmNovaEtapaChecklist.LstPosiçãoPergunta.Items.Clear()
        FrmNovaEtapaChecklist.LStTipoResposta.Items.Clear()

        For Each row In BuscaChecklist.ToList

            FrmNovaEtapaChecklist.LstIdPerguntas.Items.Add(row.IdPerguntaChecklit)
            FrmNovaEtapaChecklist.LstPosiçãoPergunta.Items.Add(row.Posicao)
            FrmNovaEtapaChecklist.LStTipoResposta.Items.Add(row.TipoResposta)

        Next

        FrmNovaEtapaChecklist.Opacity = 0.95

        Me.Close()

    End Sub
End Class