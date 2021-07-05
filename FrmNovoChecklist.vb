Public Class FrmNovoChecklist

    Public NivelReq As Integer = 0

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If NivelReq = 0 Then
            FrmVistoria.Opacity = 0.95
            FrmVistoria.LblTitulo.BackColor = Color.DarkSlateGray
            FrmVistoria.PnnInferior.BackColor = Color.DarkSlateGray
        End If

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Dim Node_0 As Integer
    Dim Node_1 As Integer
    Dim Node_2 As Integer
    Dim node_3 As Integer

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)


    End Sub

    Public LstIdChecklist As New ListBox
    Private Sub BttcadChecllist_Click(sender As Object, e As EventArgs) Handles BttcadChecllist.Click

        'cadastra 1

        FrmNovoCadCheckList.Show(Me)

        Me.Opacity = 0.3

    End Sub

    Dim LqOficina As New LqOficinaDataContext
    Public LstPosiçãoChecklist As New ListBox

    Private Sub FrmNovoChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'completa no frm anterior

        Dim BuscaChecklist = From ch In LqOficina.Cheklist
                             Where ch.Nivel_req = NivelReq
                             Select ch.IdChecklist, ch.Posicao, ch.Titulo
                             Order By Posicao Ascending

        LstIdChecklist.Items.Clear()
        LstPosiçãoChecklist.Items.Clear()
        CmbChecklist.Items.Clear()

        For Each row In BuscaChecklist.ToList

            LstIdChecklist.Items.Add(row.IdChecklist)
            LstPosiçãoChecklist.Items.Add(row.Posicao)
            CmbChecklist.Items.Add(row.Titulo)

        Next

    End Sub

    Private Sub CmbChecklist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbChecklist.SelectedIndexChanged

        If CmbChecklist.Items.Contains(CmbChecklist.Text) Then
            If NivelReq = 0 Then
                LblNivelReq.Text = "Vistoria inicial"
            End If
            NmPosição.Minimum = 1
            NmPosição.Maximum = CmbChecklist.Items.Count
            NmPosição.Value = LstPosiçãoChecklist.Items(CmbChecklist.SelectedIndex).ToString
            NmPosição.Enabled = True
            GpCategoriasChecklist.Enabled = False
            GpCategoriasChecklist.Enabled = True

        Else
            LblNivelReq.Text = ""
            NmPosição.Minimum = 0
            NmPosição.Value = 0
            NmPosição.Maximum = 0
            NmPosição.Enabled = False
            GpCategoriasChecklist.Enabled = False

        End If
    End Sub

    Private Sub CmbChecklist_TextChanged(sender As Object, e As EventArgs) Handles CmbChecklist.TextChanged

        If Not CmbChecklist.Items.Contains(CmbChecklist.Text) Then

            LblNivelReq.Text = ""
            NmPosição.Minimum = 0
            NmPosição.Value = 0
            NmPosição.Maximum = 0
            NmPosição.Enabled = False
            GpCategoriasChecklist.Enabled = False

        End If

    End Sub

    Private Sub GpCategoriasChecklist_Enter(sender As Object, e As EventArgs) Handles GpCategoriasChecklist.Enter

    End Sub

    Private Sub GpCategoriasChecklist_EnabledChanged(sender As Object, e As EventArgs) Handles GpCategoriasChecklist.EnabledChanged

        If GpCategoriasChecklist.Enabled = False Then
            CmbCategoriasChecklist.Text = ""
        Else
            'busca categorias 

            'completa no frm anterior

            Dim BuscaChecklist = From ch In LqOficina.ItemCheklist
                                 Where ch.IdChecklist = LstIdChecklist.Items(CmbChecklist.SelectedIndex).ToString
                                 Select ch.IdItem, ch.Posicao, ch.Descricao
                                 Order By Posicao Ascending

            LstIdItemChecklist.Items.Clear()
            CmbCategoriasChecklist.Items.Clear()
            LstPosiçãoItemChecklist.Items.Clear()

            For Each row In BuscaChecklist.ToList

                LstIdItemChecklist.Items.Add(row.IdItem)
                CmbCategoriasChecklist.Items.Add(row.descricao)
                LstPosiçãoItemChecklist.Items.Add(row.Posicao)

            Next

        End If

    End Sub

    Public LstIdItemChecklist As New ListBox
    Public LstPosiçãoItemChecklist As New ListBox

    Private Sub BttAddCatChecklist_Click(sender As Object, e As EventArgs) Handles BttAddCatChecklist.Click

        FrmCadastroDeCategoriaChecklist.LblTituloChecklist.Text = CmbChecklist.SelectedItem
        Me.Opacity = 0.3
        FrmCadastroDeCategoriaChecklist.Show(Me)

    End Sub

    Private Sub CmbCategoriasChecklist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoriasChecklist.SelectedIndexChanged

        If CmbCategoriasChecklist.Items.Contains(CmbCategoriasChecklist.Text) Then

            NmPosiçãoCatChecklist.Minimum = 1
            NmPosiçãoCatChecklist.Maximum = CmbCategoriasChecklist.Items.Count
            NmPosiçãoCatChecklist.Value = LstPosiçãoItemChecklist.Items(CmbCategoriasChecklist.SelectedIndex).ToString
            NmPosiçãoCatChecklist.Enabled = True
            GpProcesso.Enabled = False
            GpProcesso.Enabled = True

        Else
            NmPosiçãoCatChecklist.Minimum = 0
            NmPosiçãoCatChecklist.Value = 0
            NmPosiçãoCatChecklist.Maximum = 0
            NmPosiçãoCatChecklist.Enabled = False
            GpProcesso.Enabled = False

        End If
    End Sub

    Private Sub CmbCategoriasChecklist_TextChanged(sender As Object, e As EventArgs) Handles CmbCategoriasChecklist.TextChanged

        If CmbCategoriasChecklist.Items.Contains(CmbCategoriasChecklist.Text) Then

            NmPosiçãoCatChecklist.Minimum = 0
            NmPosiçãoCatChecklist.Value = 0
            NmPosiçãoCatChecklist.Maximum = 0
            NmPosiçãoCatChecklist.Enabled = False
            GpProcesso.Enabled = False

        End If

    End Sub

    Private Sub BttAddProcesso_Click(sender As Object, e As EventArgs) Handles BttAddProcesso.Click

        FrmNovoProcessohecklist.LblTituloChecklist.Text = CmbCategoriasChecklist.Text
        FrmNovoProcessohecklist.Show(Me)
        Me.Opacity = 0.3

    End Sub

    Private Sub GpProcesso_Enter(sender As Object, e As EventArgs) Handles GpProcesso.Enter

    End Sub

    Public LstIdProcesso As New ListBox
    Public LstPosiçãoProcesso As New ListBox

    Private Sub GpProcesso_EnabledChanged(sender As Object, e As EventArgs) Handles GpProcesso.EnabledChanged

        If GpProcesso.Enabled = False Then
            CmbProcessos.Text = ""
        Else
            'busca categorias 

            'completa no frm anterior

            Dim BuscaChecklist = From ch In LqOficina.ProcessosChecklist
                                 Where ch.IdItem = LstIdItemChecklist.Items(CmbCategoriasChecklist.SelectedIndex).ToString
                                 Select ch.IdProcesso, ch.Posicao, ch.Descricao
                                 Order By Posicao Ascending

            LstIdProcesso.Items.Clear()
            CmbProcessos.Items.Clear()
            LstPosiçãoProcesso.Items.Clear()

            For Each row In BuscaChecklist.ToList

                LstIdProcesso.Items.Add(row.IdProcesso)
                CmbProcessos.Items.Add(row.descricao)
                LstPosiçãoProcesso.Items.Add(row.Posicao)

            Next

        End If

    End Sub

    Public LstPosiçãoEtapaCheckList As New ListBox
    Public LstIdEtapaCheckList As New ListBox

    Private Sub CmbProcessos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProcessos.SelectedIndexChanged

        If CmbProcessos.Items.Contains(CmbProcessos.Text) Then

            NmPosiçãoProcesso.Minimum = 1
            NmPosiçãoProcesso.Maximum = CmbProcessos.Items.Count
            NmPosiçãoProcesso.Value = LstPosiçãoProcesso.Items(CmbProcessos.SelectedIndex).ToString
            NmPosiçãoProcesso.Enabled = True
            GpEtapas.Enabled = False
            GpEtapas.Enabled = True

        Else
            NmPosiçãoProcesso.Minimum = 0
            NmPosiçãoProcesso.Value = 0
            NmPosiçãoProcesso.Maximum = 0
            NmPosiçãoProcesso.Enabled = False
            GpEtapas.Enabled = False

        End If
    End Sub

    Private Sub CmbProcessos_TextChanged(sender As Object, e As EventArgs) Handles CmbProcessos.TextChanged

        If Not CmbProcessos.Items.Contains(CmbProcessos.Text) Then

            NmPosiçãoEtapaProcesso.Minimum = 0
            NmPosiçãoEtapaProcesso.Value = 0
            NmPosiçãoEtapaProcesso.Maximum = 0
            NmPosiçãoEtapaProcesso.Enabled = False
            GpProcesso.Enabled = False

        End If
    End Sub

    Private Sub BttAddEtapa_Click(sender As Object, e As EventArgs) Handles BttAddEtapa.Click

        FrmNovaEtapaChecklist.LblTituloChecklist.Text = CmbProcessos.Text
        FrmNovaEtapaChecklist.Show(Me)
        Me.Opacity = 0.3

    End Sub

    Private Sub GpEtapas_Enter(sender As Object, e As EventArgs) Handles GpEtapas.Enter

    End Sub

    Public Lstdescricao As New ListBox
    Public LstPosiçãoEtapa As New ListBox
    Public LstIdEtapaProcesso As New ListBox
    Public LstIpoEtapa As New ListBox

    Private Sub GpEtapas_EnabledChanged(sender As Object, e As EventArgs) Handles GpEtapas.EnabledChanged

        If GpEtapas.Enabled = False Then
            CmbEtapasProcesso.Text = ""
        Else
            'busca categorias 

            'completa no frm anterior

            Dim BuscaChecklist = From ch In LqOficina.EtapasChecklist
                                 Where ch.IdProcesso = LstIdProcesso.Items(CmbProcessos.SelectedIndex).ToString
                                 Select ch.IdEtapaProcessoChecklist, ch.Posicao, ch.Descricao, ch.Titulo, ch.Tipo
                                 Order By Posicao Ascending

            Lstdescricao.Items.Clear()
            LstPosiçãoEtapa.Items.Clear()
            LstIdEtapaProcesso.Items.Clear()
            LstIpoEtapa.Items.Clear()
            CmbEtapasProcesso.Items.Clear()

            For Each row In BuscaChecklist.ToList

                Lstdescricao.Items.Add(row.descricao)
                LstPosiçãoEtapa.Items.Add(row.Posicao)
                LstIdEtapaProcesso.Items.Add(row.IdEtapaProcessoChecklist)

                Dim _Tipo As String = "Desconhecido"

                If row.Tipo = -1 Then
                    _Tipo = "Informativo"
                Else
                    _Tipo = "Pergunta e resposta"
                End If


                LstIpoEtapa.Items.Add(_Tipo)
                CmbEtapasProcesso.Items.Add(row.Titulo)

            Next

        End If

    End Sub

    Dim LstIdPergunta As New ListBox
    Dim TipoResposta As New ListBox

    Private Sub CmbEtapasProcesso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEtapasProcesso.SelectedIndexChanged

        If CmbEtapasProcesso.Items.Contains(CmbEtapasProcesso.Text) Then

            NmPosiçãoEtapaProcesso.Minimum = 1
            NmPosiçãoEtapaProcesso.Maximum = CmbEtapasProcesso.Items.Count
            NmPosiçãoEtapaProcesso.Value = LstPosiçãoEtapa.Items(CmbEtapasProcesso.SelectedIndex).ToString
            NmPosiçãoEtapaProcesso.Enabled = True
            BttSalvar.Enabled = True
            LblModoInteração.Text = LstIpoEtapa.Items(CmbEtapasProcesso.SelectedIndex).ToString

            If LblModoInteração.Text = "Informativo" Then

                LblDetalhesEtapa.Text = Lstdescricao.Items(CmbEtapasProcesso.SelectedIndex).ToString

                GpDetalhes.Visible = True
                GpDetalhes.Dock = DockStyle.Fill

                GpCriterios.Visible = False

            Else

                'busca resposta

                GpDetalhes.Visible = False
                GpCriterios.Visible = True
                GpCriterios.Dock = DockStyle.Fill

                Dim BuscaPerguntas = From pg In LqOficina.PerguntasChecklist
                                     Where pg.IdEtapaProcesso = LstIdEtapaProcesso.Items(CmbEtapasProcesso.SelectedIndex).ToString
                                     Select pg.IdPerguntaChecklit, pg.TipoResposta, pg.Titulo

                LstIdPergunta.Items.Clear()
                TipoResposta.Items.Clear()
                CmbPergunta.Items.Clear()

                For Each row In BuscaPerguntas.ToList

                    LstIdPergunta.Items.Add(row.IdPerguntaChecklit)
                    TipoResposta.Items.Add(row.TipoResposta)
                    CmbPergunta.Items.Add(row.Titulo)

                Next

            End If

        Else

            NmPosiçãoEtapaProcesso.Minimum = 0
            NmPosiçãoEtapaProcesso.Value = 0
            NmPosiçãoEtapaProcesso.Maximum = 0
            NmPosiçãoEtapaProcesso.Enabled = False
            BttSalvar.Enabled = False
            LblModoInteração.Text = ""

        End If

    End Sub

    Private Sub CmbEtapasProcesso_TextChanged(sender As Object, e As EventArgs) Handles CmbEtapasProcesso.TextChanged
        If Not CmbEtapasProcesso.Items.Contains(CmbEtapasProcesso.Text) Then

            NmPosiçãoEtapaProcesso.Minimum = 0
            NmPosiçãoEtapaProcesso.Value = 0
            NmPosiçãoEtapaProcesso.Maximum = 0
            NmPosiçãoEtapaProcesso.Enabled = False
            BttSalvar.Enabled = False
            LblModoInteração.Text = ""

        End If
    End Sub

    Private Sub CmbPergunta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPergunta.SelectedIndexChanged

        If CmbPergunta.Items.Contains(CmbPergunta.Text) Then

            Dim TipoR As String

            If TipoResposta.Items(CmbPergunta.SelectedIndex).ToString = 1 Then

                TipoR = "Texto"

            ElseIf TipoResposta.Items(CmbPergunta.SelectedIndex).ToString = 2 Then

                TipoR = "Sim/Não"

            ElseIf TipoResposta.Items(CmbPergunta.SelectedIndex).ToString = 3 Then

                TipoR = "Escala 0-10"

            ElseIf TipoResposta.Items(CmbPergunta.SelectedIndex).ToString = 4 Then

                TipoR = "Unica escolha"

            ElseIf TipoResposta.Items(CmbPergunta.SelectedIndex).ToString = 5 Then

                TipoR = "Multipla escolha"

            End If

            LblTipoResposta.Text = TipoR

        End If

    End Sub

    Private Sub LblTipoResposta_TextChanged(sender As Object, e As EventArgs) Handles LblTipoResposta.TextChanged

        If LblTipoResposta.Text = "Texto" Then

            LblResposta.Visible = True

            LblResposta.Text = "Valor será inserido pelo usuario por escrito."

        ElseIf LblTipoResposta.Text = "Sim/Não" Then

            LblResposta.Visible = True

            LblResposta.Text = "Valor do tipo verdadeiro ou falso."

        ElseIf LblTipoResposta.Text = "Escala 0-10" Then

            LblResposta.Visible = False

        End If

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        FrmNovaEtapaChecklist.ChaveTemp = LstIdEtapaProcesso.Items(CmbEtapasProcesso.SelectedIndex).ToString

        FrmNovaEtapaChecklist.Show(Me)

        FrmNovaEtapaChecklist.txtdescrição.Text = CmbEtapasProcesso.Text

        FrmNovaEtapaChecklist.txtdescrição.Enabled = False

        FrmNovaEtapaChecklist.RdbInteração.Enabled = False

        FrmNovaEtapaChecklist.RdbPergunta.Enabled = False

        FrmNovaEtapaChecklist.RdbPergunta.Checked = True

        FrmNovaEtapaChecklist.Refresh()

    End Sub
End Class