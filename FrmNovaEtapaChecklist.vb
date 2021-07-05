Public Class FrmNovaEtapaChecklist
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        FrmNovoChecklist.Opacity = 0.95
        Me.Close()
    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Dim _Tipo As Integer

    Public _IdChecklist As Integer
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.EtapasChecklist
                         Where tod.IdProcesso = _IdChecklist
                         Select tod.IdEtapaProcessoChecklist

        'insere checklist

        LqOficina.InsereNovaEtapaProcessoChecklist(_IdChecklist, txtdescrição.Text, TxtDetalhesEtapa.Text, RdbInteração.Checked, BuscaTodos.Count + 1)


        FrmFluxo.PublicaTreeview()

        FrmFluxo.PublicaLista()

        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            GpModoInteração.Enabled = True
        Else
            GpModoInteração.Enabled = False
        End If

    End Sub

    Private Sub FrmCadastroDeCategoriaChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtdescrição.Focus()

    End Sub


    Private Sub RdbInteração_CheckedChanged(sender As Object, e As EventArgs) Handles RdbInteração.CheckedChanged

        If RdbInteração.Checked = True Then
            PnnInfo.Enabled = True
            PnnInfo.Dock = DockStyle.Fill
            BttSalvar.Enabled = False
        Else
            PnnInfo.Enabled = False
            BttSalvar.Enabled = True
        End If

    End Sub

    Private Sub RdbPergunta_CheckedChanged(sender As Object, e As EventArgs) Handles RdbPergunta.CheckedChanged

        If RdbInteração.Checked = True Then
            PnnInfo.Enabled = True
            PnnInfo.Dock = DockStyle.Fill
            BttSalvar.Enabled = False
        Else
            PnnInfo.Enabled = False
            BttSalvar.Enabled = True
        End If

    End Sub

    Private Sub TxtDetalhesEtapa_TextChanged(sender As Object, e As EventArgs) Handles TxtDetalhesEtapa.TextChanged

        If RdbInteração.Checked = True Then

            If TxtDetalhesEtapa.Text <> "" Then
                BttSalvar.Enabled = True
            Else
                BttSalvar.Enabled = False
            End If

        End If

    End Sub

    Public ChaveTemp As Integer = Now.Hour & Now.Minute & Now.Second & Now.Millisecond

    Public LstIdPerguntas As New ListBox
    Public LstPosiçãoPergunta As New ListBox
    Public LStTipoResposta As New ListBox

End Class