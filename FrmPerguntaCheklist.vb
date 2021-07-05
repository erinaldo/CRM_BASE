Public Class FrmPerguntaCheklist

    Public _IdChecklist As Integer

    Private Sub FrmPerguntaCheklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RdbTexto.Checked = True

    End Sub

    Private Sub RdbTexto_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTexto.CheckedChanged
        VerificaTipo()
    End Sub

    Private Sub RdbSimNão_CheckedChanged(sender As Object, e As EventArgs) Handles RdbSimNão.CheckedChanged
        VerificaTipo()
    End Sub

    Private Sub RdbEscala_CheckedChanged(sender As Object, e As EventArgs) Handles RdbEscala.CheckedChanged
        VerificaTipo()
    End Sub

    Private Sub RdbUnicaEscolha_CheckedChanged(sender As Object, e As EventArgs) Handles RdbUnicaEscolha.CheckedChanged
        VerificaTipo()
    End Sub

    Private Sub RdbMultiplaEscolha_CheckedChanged(sender As Object, e As EventArgs) Handles RdbMultiplaEscolha.CheckedChanged
        VerificaTipo()
    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Dim LStTipoResposta As New ListBox

    Dim TipoResp As Integer

    Public Sub VerificaTipo()

        If RdbTexto.Checked = True Then

            TipoResp = 1

            PnnTexto.Visible = True
            PnnTexto.Dock = DockStyle.Fill

            'torna ivisivel os demais

            Panel5.Visible = False
            PnnEscala.Visible = False
            PnnUnicaEsolha.Visible = False

            'atualiza painel da pergunta

            BttSalvar.Enabled = True

        ElseIf RdbSimNão.Checked = True Then

            TipoResp = 2

            PnnTexto.Visible = False
            PnnEscala.Visible = False

            Panel5.Visible = True
            Panel5.Dock = DockStyle.Fill
            PnnUnicaEsolha.Visible = False

            BttSalvar.Enabled = True

        ElseIf RdbEscala.Checked = True Then

            TipoResp = 3

            PnnEscala.Visible = True
            PnnEscala.Dock = DockStyle.Fill

            PnnTexto.Visible = False
            Panel5.Visible = False
            PnnUnicaEsolha.Visible = False

            BttSalvar.Enabled = True

        ElseIf RdbUnicaEscolha.Checked = True Then

            TipoResp = 4

            GpDetalhe.Enabled = True
            txtdescriçãoOpção.Enabled = True
            PnnTexto.Visible = False
            Panel5.Visible = False
            PnnEscala.Visible = False

            PnnUnicaEsolha.Visible = True
            PnnUnicaEsolha.Dock = DockStyle.Fill

            txtdescriçãoOpção.Text = ""
            ListBox1.Items.Clear()

            BttSalvar.Enabled = False

        ElseIf RdbMultiplaEscolha.Checked = True Then

            TipoResp = 5

            GpDetalhe.Enabled = True

            txtdescriçãoOpção.Enabled = True

            PnnTexto.Visible = False
            Panel5.Visible = False
            PnnEscala.Visible = False

            PnnUnicaEsolha.Visible = True
            PnnUnicaEsolha.Dock = DockStyle.Fill

            txtdescriçãoOpção.Text = ""
            ListBox1.Items.Clear()

            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub TxtPergunta_TextChanged(sender As Object, e As EventArgs) Handles TxtPergunta.TextChanged

        If TxtPergunta.Text <> "" Then
            GpTipo.Enabled = True
            CkExigeImagem.Enabled = True

        Else
            GpTipo.Enabled = False
            CkExigeImagem.Enabled = False
            CkExigeImagem.Checked = True

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'busca a qtdade de itens já cadastrados

        Dim BuscaTodos = From tod In LqOficina.PerguntasChecklist
                         Where tod.IdEtapaProcesso = _IdChecklist
                         Select tod.IdPerguntaChecklit

        'insere checklist

        LqOficina.InsereNovaPerguntaEtapaProcessoChecklist(_IdChecklist, TxtPergunta.Text, TipoResp, BuscaTodos.Count + 1, CkExigeImagem.CheckState)

        'verifica se opções são de MP

        If TipoResp > 3 Then

            Dim BuscaPergunta = From tod In LqOficina.PerguntasChecklist
                                Where tod.IdEtapaProcesso = _IdChecklist
                                Select tod.IdPerguntaChecklit
                                Order By IdPerguntaChecklit Descending

            For i As Integer = 0 To ListBox1.Items.Count - 1

                'insere checklist

                LqOficina.InsereNovaRespostaPerguntaProcessoChecklist(BuscaPergunta.First, False, ListBox1.Items(i).ToString)

            Next

        End If

        FrmFluxo.PublicaTreeview()

        FrmFluxo.PublicaLista()

        Me.Close()

    End Sub

    Private Sub BttAddOpção_Click(sender As Object, e As EventArgs) Handles BttAddOpção.Click

        BttRemoveItem.Enabled = False

        Dim C As Integer = 0

        'insere items no listbox

        For i As Integer = 0 To ListBox1.Items.Count - 1

            If ListBox1.Items(i).ToString.ToLower = txtdescriçãoOpção.Text.ToLower Then

                C += 1

            End If

        Next

        If C = 0 Then
            ListBox1.Items.Add(txtdescriçãoOpção.Text)

            txtdescriçãoOpção.Text = ""
        Else
            MsgBox("Este item já se encontra na lista.")
        End If

        If ListBox1.Items.Count > 0 Then
            BttSalvar.Enabled = True
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        If ListBox1.Items.Count = 0 Then
            BttRemoveItem.Enabled = False
        Else
            BttRemoveItem.Enabled = True
        End If

    End Sub

    Private Sub txtdescriçãoOpção_TextChanged(sender As Object, e As EventArgs) Handles txtdescriçãoOpção.TextChanged

        If txtdescriçãoOpção.Text <> "" Then

            BttAddOpção.Enabled = True

        Else

            BttAddOpção.Enabled = False

        End If

    End Sub

    Private Sub BttRemoveItem_Click(sender As Object, e As EventArgs) Handles BttRemoveItem.Click

        BttRemoveItem.Enabled = False

        If ListBox1.Items.Count > 0 Then
            ListBox1.Items.Remove(ListBox1.SelectedItem.ToString)
        End If

    End Sub
End Class