Public Class FrmRespostaChecklist
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        LqOficina.AtualizaInicioVistoriaVeiculo(LblProcesso.Text, Now.TimeOfDay, Today.Date, False)

        LqOficina.DeletaRespostasCheklist(LblProcesso.Text)

        'deleta imagens e marcas


        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Private Sub FrmRespostaChecklist_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim BuscaChecklist = From ck In LqOficina.Cheklist
                             Where ck.Nivel_req = 0
                             Select ck.IdChecklist, ck.Titulo, ck.Posicao
                             Order By Posicao Ascending

        Dim Av As Decimal = 190 * 2

        For Each item In BuscaChecklist.ToList

            TrChecklist.Nodes.Add(item.Titulo)

            Dim BuscaItemChecklist = From ck In LqOficina.ItemCheklist
                                     Where ck.IdChecklist = item.IdChecklist
                                     Select ck.IdItem, ck.Descricao, ck.Posicao
                                     Order By Posicao Ascending

            Dim TrFluxoNode1 As TreeNode = TrChecklist.Nodes(TrChecklist.Nodes.Count - 1)

            For Each item1 In BuscaItemChecklist.ToList

                TrFluxoNode1.Nodes.Add(item1.descricao)

                Dim BuscaProcessoChecklist = From ck In LqOficina.ProcessosChecklist
                                             Where ck.IdItem = item1.IdItem
                                             Select ck.IdProcesso, ck.Descricao, ck.Posicao
                                             Order By Posicao Ascending

                Dim TrFluxoNode2 As TreeNode = TrFluxoNode1.Nodes(TrFluxoNode1.Nodes.Count - 1)

                For Each item2 In BuscaProcessoChecklist.ToList

                    TrFluxoNode2.Nodes.Add(item2.descricao)

                    Dim BuscaEtapaChecklist = From ck In LqOficina.EtapasChecklist
                                              Where ck.IdProcesso = item2.IdProcesso
                                              Select ck.IdEtapaProcessoChecklist, ck.Titulo, ck.Posicao, ck.Tipo, ck.Descricao
                                              Order By Posicao Ascending

                    Dim TrFluxoNode3 As TreeNode = TrFluxoNode2.Nodes(TrFluxoNode2.Nodes.Count - 1)

                    For Each item3 In BuscaEtapaChecklist.ToList

                        TrFluxoNode3.Nodes.Add(item3.Titulo)

                        Dim TrFluxoNode4 As TreeNode = TrFluxoNode3.Nodes(TrFluxoNode3.Nodes.Count - 1)

                        If item3.Tipo = 0 Then

                            Dim BuscaPerguntaChecklist = From ck In LqOficina.PerguntasChecklist
                                                         Where ck.IdEtapaProcesso = item3.IdEtapaProcessoChecklist
                                                         Select ck.IdPerguntaChecklit, ck.Titulo, ck.TipoResposta, ck.Posicao, ck.ExigeImagem
                                                         Order By Posicao Ascending

                            For Each item4 In BuscaPerguntaChecklist.ToList

                                TrFluxoNode4.Nodes.Add(item4.TipoResposta)

                                If item4.TipoResposta = 1 Then

                                    Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)
                                    _camadaAbaixo.Nodes.Add(item4.Titulo)
                                    _camadaAbaixo.Nodes.Add(item4.IdPerguntaChecklit)
                                    _camadaAbaixo.Nodes.Add(item4.ExigeImagem)

                                ElseIf item4.TipoResposta = 2 Then

                                    Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                    _camadaAbaixo.Nodes.Add(item4.Titulo)
                                    _camadaAbaixo.Nodes.Add(item4.IdPerguntaChecklit)
                                    _camadaAbaixo.Nodes.Add(item4.ExigeImagem)

                                ElseIf item4.TipoResposta = 3 Then

                                    Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                    _camadaAbaixo.Nodes.Add(item4.Titulo)
                                    _camadaAbaixo.Nodes.Add(item4.IdPerguntaChecklit)
                                    _camadaAbaixo.Nodes.Add(item4.ExigeImagem)

                                ElseIf item4.TipoResposta = 4 Then

                                    'busca repostas

                                    Dim BuscaResposta = From resp In LqOficina.RespostasChecklist
                                                        Where resp.IdPerguntaEtapa = item4.IdPerguntaChecklit
                                                        Select resp.descricao

                                    Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                    TrFluxoNode5.Nodes.Add(item4.Titulo)
                                    TrFluxoNode5.Nodes.Add(item4.IdPerguntaChecklit)
                                    TrFluxoNode5.Nodes.Add(item4.ExigeImagem)

                                    For Each item5 In BuscaResposta.ToList

                                        TrFluxoNode5.Nodes.Add(item5)

                                    Next

                                ElseIf item4.TipoResposta = 5 Then

                                    'busca repostas

                                    Dim BuscaResposta = From resp In LqOficina.RespostasChecklist
                                                        Where resp.IdPerguntaEtapa = item4.IdPerguntaChecklit
                                                        Select resp.descricao

                                    Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                    TrFluxoNode5.Nodes.Add(item4.Titulo)
                                    TrFluxoNode5.Nodes.Add(item4.IdPerguntaChecklit)
                                    TrFluxoNode5.Nodes.Add(item4.ExigeImagem)

                                    For Each item5 In BuscaResposta.ToList

                                        TrFluxoNode5.Nodes.Add(item5)

                                    Next

                                End If

                            Next

                        Else

                            TrFluxoNode4.Nodes.Add("Informativo ao usuário")
                            Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)
                            TrFluxoNode5.Nodes.Add(item3.descricao)
                            TrFluxoNode5.Nodes.Add(item3.IdEtapaProcessoChecklist)

                        End If

                    Next

                Next

            Next

        Next

        TrChecklist.ExpandAll()

        'seleciona primeira pergunta

        ProcuraPergunta()

    End Sub

    'procura pergunta

    Dim SelIndex As Integer = -1
    Dim SelParentIndex As Integer = 0
    Dim Valida As Boolean = False

    Dim LStPopulado As New ListBox

    Dim _IdPerguntaEtapa As Integer

    Public Sub ProcuraPergunta()

        DesenhaImagens()

        For Each row As TreeNode In TrChecklist.Nodes

            For Each row1 As TreeNode In row.Nodes

                For Each row2 As TreeNode In row1.Nodes

                    For Each row3 As TreeNode In row2.Nodes

                        For Each row4 As TreeNode In row3.Nodes

                            If Valida = False Then

                                If Not LStPopulado.Items.Contains(row.Index & "." & row1.Index & "." & row2.Index & "." & row3.Index & "." & row4.Index) Then

                                    LStPopulado.Items.Add(row.Index & "." & row1.Index & "." & row2.Index & "." & row3.Index & "." & row4.Index)

                                    Valida = True

                                    ' MsgBox(row4.Text)

                                    LblPergunta.Text = row4.Nodes(0).Text

                                    If row4.Text = "Informativo ao usuário" Then

                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        LblInformativo.Text = row4.Nodes(0).Text

                                        PnnInteração.Visible = False
                                        PnnInformação.Visible = True
                                        PnnInformação.Dock = DockStyle.Fill
                                        BtnPróximo.Enabled = True

                                    ElseIf row4.Text = 1 Then
                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        PnnInteração.Visible = True
                                        PnnInformação.Visible = False
                                        PnnInteração.Dock = DockStyle.Fill

                                        PnnTexto.Visible = True
                                        PnnTexto.Dock = DockStyle.Fill

                                        'apaga os demais
                                        PnnSimNão.Visible = False
                                        PnnEscala.Visible = False
                                        PnnUp.Visible = False
                                        PnnMp.Visible = False

                                        If row4.Nodes(2).Text = "True" Then
                                            PicObrigatorio.Visible = True
                                        Else
                                            PicObrigatorio.Visible = False
                                        End If

                                    ElseIf row4.Text = 2 Then
                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        PnnInteração.Visible = True
                                        PnnSimNão.Visible = True
                                        PnnInformação.Visible = False
                                        PnnInteração.Dock = DockStyle.Fill

                                        PnnSimNão.Dock = DockStyle.Fill

                                        'apaga os demais
                                        PnnTexto.Visible = False
                                        PnnEscala.Visible = False
                                        PnnUp.Visible = False
                                        PnnMp.Visible = False

                                        If row4.Nodes(2).Text = "True" Then
                                            PicObrigatorio.Visible = True
                                        Else
                                            PicObrigatorio.Visible = False
                                        End If

                                    ElseIf row4.Text = 3 Then
                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        PnnInteração.Visible = True
                                        PnnEscala.Visible = True
                                        PnnInformação.Visible = False
                                        PnnInteração.Dock = DockStyle.Fill

                                        PnnEscala.Dock = DockStyle.Fill
                                        'desenha os campos de interação
                                        Dim ValorX As Integer = PnnMeio.Width / 10
                                        PmmEsc01.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc02.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc03.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc04.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc05.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc06.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc07.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc08.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc09.Size = New Size(ValorX, PmmEsc01.Height)
                                        PmmEsc00.Size = New Size(ValorX, PmmEsc01.Height)

                                        'apaga os demais
                                        PnnTexto.Visible = False
                                        PnnSimNão.Visible = False
                                        PnnUp.Visible = False
                                        PnnMp.Visible = False

                                        If row4.Nodes(2).Text = "True" Then
                                            PicObrigatorio.Visible = True
                                        Else
                                            PicObrigatorio.Visible = False
                                        End If

                                    ElseIf row4.Text = 4 Then
                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        PnnInteração.Visible = True
                                        PnnInformação.Visible = False
                                        PnnInteração.Dock = DockStyle.Fill

                                        PnnUp.Visible = True
                                        PnnUp.Dock = DockStyle.Fill

                                        'carrega respostas validas

                                        TrUp.Nodes.Clear()

                                        For Each row5 As TreeNode In row4.Nodes

                                            If row5.Index > 2 Then
                                                TrUp.Nodes.Add(row5.Text)
                                            End If

                                        Next

                                        'apaga os demais
                                        PnnTexto.Visible = False
                                        PnnEscala.Visible = False
                                        PnnSimNão.Visible = False
                                        PnnMp.Visible = False

                                        If row4.Nodes(2).Text = "True" Then
                                            PicObrigatorio.Visible = True
                                        Else
                                            PicObrigatorio.Visible = False
                                        End If

                                    ElseIf row4.Text = 5 Then
                                        _IdPerguntaEtapa = row4.Nodes(1).Text

                                        PnnInteração.Visible = True
                                        PnnInformação.Visible = False
                                        PnnInteração.Dock = DockStyle.Fill

                                        PnnMp.Visible = True
                                        PnnMp.Dock = DockStyle.Fill

                                        'carrega respostas validas

                                        TrMp.Nodes.Clear()

                                        For Each row5 As TreeNode In row4.Nodes

                                            If row5.Index > 2 Then
                                                TrMp.Nodes.Add(row5.Text)
                                            End If

                                        Next

                                        'apaga os demais
                                        PnnTexto.Visible = False
                                        PnnEscala.Visible = False
                                        PnnSimNão.Visible = False
                                        PnnUp.Visible = False

                                        If row4.Nodes(2).Text = "True" Then
                                            PicObrigatorio.Visible = True
                                        Else
                                            PicObrigatorio.Visible = False
                                        End If

                                    End If

                                End If

                            End If

                        Next

                    Next

                Next

            Next

        Next

        If Valida = False Then

            PnnInteração.Visible = False
            PnnInformação.Visible = False

            PnnResumo.Visible = True
            PnnResumo.Dock = DockStyle.Fill

            Dim BuscaChecklist = From ck In LqOficina.Cheklist
                                 Where ck.Nivel_req = 0
                                 Select ck.IdChecklist, ck.Titulo, ck.Posicao
                                 Order By Posicao Ascending

            Dim Av As Decimal = 190 * 2

            For Each item In BuscaChecklist.ToList

                TrResumo.Nodes.Add(item.Titulo)

                Dim BuscaItemChecklist = From ck In LqOficina.ItemCheklist
                                         Where ck.IdChecklist = item.IdChecklist
                                         Select ck.IdItem, ck.Descricao, ck.Posicao
                                         Order By Posicao Ascending

                Dim TrFluxoNode1 As TreeNode = TrResumo.Nodes(TrResumo.Nodes.Count - 1)

                For Each item1 In BuscaItemChecklist.ToList

                    TrFluxoNode1.Nodes.Add(item1.descricao)

                    Dim BuscaProcessoChecklist = From ck In LqOficina.ProcessosChecklist
                                                 Where ck.IdItem = item1.IdItem
                                                 Select ck.IdProcesso, ck.Descricao, ck.Posicao
                                                 Order By Posicao Ascending

                    Dim TrFluxoNode2 As TreeNode = TrFluxoNode1.Nodes(TrFluxoNode1.Nodes.Count - 1)

                    For Each item2 In BuscaProcessoChecklist.ToList

                        TrFluxoNode2.Nodes.Add(item2.descricao)

                        Dim BuscaEtapaChecklist = From ck In LqOficina.EtapasChecklist
                                                  Where ck.IdProcesso = item2.IdProcesso
                                                  Select ck.IdEtapaProcessoChecklist, ck.Titulo, ck.Posicao, ck.Tipo, ck.Descricao
                                                  Order By Posicao Ascending

                        Dim TrFluxoNode3 As TreeNode = TrFluxoNode2.Nodes(TrFluxoNode2.Nodes.Count - 1)

                        For Each item3 In BuscaEtapaChecklist.ToList

                            TrFluxoNode3.Nodes.Add(item3.Titulo)

                            Dim TrFluxoNode4 As TreeNode = TrFluxoNode3.Nodes(TrFluxoNode3.Nodes.Count - 1)

                            If item3.Tipo = 0 Then

                                Dim BuscaPerguntaChecklist = From ck In LqOficina.PerguntasChecklist
                                                             Where ck.IdEtapaProcesso = item3.IdEtapaProcessoChecklist
                                                             Select ck.IdPerguntaChecklit, ck.Titulo, ck.TipoResposta, ck.Posicao
                                                             Order By Posicao Ascending

                                For Each item4 In BuscaPerguntaChecklist.ToList

                                    TrFluxoNode4.Nodes.Add(item4.Titulo)

                                    'busca respostas do usuario

                                    Dim BuscaRespostaUser = From usu In LqOficina.RespostasCheklistUsuario
                                                            Where usu.IdPergunta = item4.IdPerguntaChecklit
                                                            Select usu.descricao, usu.IdRespostaChecklist

                                    Try

                                        If item4.TipoResposta = 1 Then

                                            Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)
                                            _camadaAbaixo.Nodes.Add(BuscaRespostaUser.First.descricao)

                                        ElseIf item4.TipoResposta = 2 Then

                                            Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                            _camadaAbaixo.Nodes.Add(BuscaRespostaUser.First.descricao)

                                        ElseIf item4.TipoResposta = 3 Then

                                            Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                            _camadaAbaixo.Nodes.Add(BuscaRespostaUser.First.descricao)

                                        ElseIf item4.TipoResposta = 4 Then

                                            Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                            For Each item5 In BuscaRespostaUser.ToList

                                                TrFluxoNode5.Nodes.Add(item5.descricao)

                                            Next

                                        ElseIf item4.TipoResposta = 5 Then

                                            Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                            For Each item5 In BuscaRespostaUser.ToList

                                                TrFluxoNode5.Nodes.Add(item5.descricao)

                                            Next

                                        End If

                                    Catch ex As Exception

                                    End Try

                                Next

                            End If

                        Next

                    Next

                Next

            Next

            TrResumo.ExpandAll()

            BtnPróximo.Visible = False
            BtnConcluir.Visible = True
            BtnConcluir.Enabled = True

        End If

        Valida = False

    End Sub

    Dim _IdRespostaUsuarioN As Integer

    Public Sub Salva_valores()

        'pinta inicial

        'Desenha_Galeria_inicio()

        If PnnTexto.Visible = True Then

            'insere resposta de texto

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, txtdescrição.Text, LblProcesso.Text)

        ElseIf PnnSimNão.Visible = True Then

            Dim Resposta As String

            If LblSim.BackColor = Color.DarkSlateGray Then

                Resposta = "Sim"

            Else

                Resposta = "Não"

            End If

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, Resposta, LblProcesso.Text)

        ElseIf PnnEscala.Visible = True Then

            Dim Resposta As String

            If LblEsc01.BackColor = Color.DarkSlateGray Then

                Resposta = "1"

            ElseIf LblEsc02.BackColor = Color.DarkSlateGray Then

                Resposta = "2"

            ElseIf LblEsc03.BackColor = Color.DarkSlateGray Then

                Resposta = "3"

            ElseIf LblEsc04.BackColor = Color.DarkSlateGray Then

                Resposta = "4"

            ElseIf LblEsc05.BackColor = Color.DarkSlateGray Then

                Resposta = "5"

            ElseIf LblEsc06.BackColor = Color.DarkSlateGray Then

                Resposta = "6"

            ElseIf LblEsc07.BackColor = Color.DarkSlateGray Then

                Resposta = "7"

            ElseIf LblEsc08.BackColor = Color.DarkSlateGray Then

                Resposta = "8"

            ElseIf LblEsc09.BackColor = Color.DarkSlateGray Then

                Resposta = "9"

            ElseIf LblEsc00.BackColor = Color.DarkSlateGray Then

                Resposta = "19"

            End If

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, Resposta, LblProcesso.Text)

        ElseIf PnnUp.Visible = True Then

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, TrUp.SelectedNode.Text, LblProcesso.Text)

        ElseIf PnnMp.Visible = True Then

            For Each row As TreeNode In TrMp.Nodes

                If row.Checked = True Then
                    LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, row.Text, LblProcesso.Text)
                End If

            Next

        End If

        'busca id da resposta

        Dim BuscaRespostaUsuario = From Resp In LqOficina.RespostasCheklistUsuario
                                   Where Resp.IdPergunta = _IdPerguntaEtapa And Resp.IdProesso = LblProcesso.Text
                                   Select Resp.IdRespostaChecklist

        If BuscaRespostaUsuario.Count > 0 Then
            _IdRespostaUsuarioN = BuscaRespostaUsuario.First
        End If

    End Sub

    Dim _idEtapa As Integer
    Dim _IdPergunta As Integer
    Dim _IdResposta As Integer
    Private Sub BtnPróximo_Click(sender As Object, e As EventArgs) Handles BtnPróximo.Click

        BtnPróximo.Enabled = False

        'insere a resposta

        Salva_valores()

        Salva_imagens()

        LimpaTudo()

        TrImagens.Nodes.Clear()

        ProcuraPergunta()

    End Sub

    Private Sub LblSim_Click(sender As Object, e As EventArgs) Handles LblSim.Click

        If LblSim.ForeColor = Color.DarkSlateGray Then

            LblSim.ForeColor = Color.Gainsboro
            LblSim.BackColor = Color.DarkSlateGray

            LblNão.ForeColor = Color.DarkSlateGray
            LblNão.BackColor = Color.Gainsboro


            If PicObrigatorio.Visible = True Then
                If TrImagens.Nodes.Count > 0 Then
                    BtnPróximo.Enabled = True
                Else
                    BtnPróximo.Enabled = False
                End If
            Else
                BtnPróximo.Enabled = True
            End If

        End If

    End Sub

    Private Sub LblNão_Click(sender As Object, e As EventArgs) Handles LblNão.Click

        If LblNão.ForeColor = Color.DarkSlateGray Then

            LblNão.ForeColor = Color.Gainsboro
            LblNão.BackColor = Color.DarkSlateGray

            LblSim.ForeColor = Color.DarkSlateGray
            LblSim.BackColor = Color.Gainsboro


            If PicObrigatorio.Visible = True Then
                If TrImagens.Nodes.Count > 0 Then
                    BtnPróximo.Enabled = True
                Else
                    BtnPróximo.Enabled = False
                End If
            Else
                BtnPróximo.Enabled = True
            End If

        End If

    End Sub

    Public Sub LimpaTudo()

        LblSim.ForeColor = Color.DarkSlateGray
        LblSim.BackColor = Color.Gainsboro

        LblNão.ForeColor = Color.DarkSlateGray
        LblNão.BackColor = Color.Gainsboro

        LblEsc01.ForeColor = Color.DarkSlateGray
        LblEsc01.BackColor = Color.Gainsboro

        LblEsc02.ForeColor = Color.DarkSlateGray
        LblEsc02.BackColor = Color.Gainsboro

        LblEsc03.ForeColor = Color.DarkSlateGray
        LblEsc03.BackColor = Color.Gainsboro

        LblEsc04.ForeColor = Color.DarkSlateGray
        LblEsc04.BackColor = Color.Gainsboro

        LblEsc05.ForeColor = Color.DarkSlateGray
        LblEsc05.BackColor = Color.Gainsboro

        LblEsc06.ForeColor = Color.DarkSlateGray
        LblEsc06.BackColor = Color.Gainsboro

        LblEsc07.ForeColor = Color.DarkSlateGray
        LblEsc07.BackColor = Color.Gainsboro

        LblEsc08.ForeColor = Color.DarkSlateGray
        LblEsc08.BackColor = Color.Gainsboro

        LblEsc09.ForeColor = Color.DarkSlateGray
        LblEsc09.BackColor = Color.Gainsboro

        LblEsc00.ForeColor = Color.DarkSlateGray
        LblEsc00.BackColor = Color.Gainsboro

        PnnInf01.Visible = True
        PnnSup01.Visible = True

        PnnInf02.Visible = True
        PnnSup02.Visible = True

        PnnInf03.Visible = True
        PnnSup03.Visible = True

        PnnInf04.Visible = True
        PnnSup04.Visible = True

        PnnInf05.Visible = True
        PnnSup05.Visible = True

        PnnInf06.Visible = True
        PnnSup06.Visible = True

        PnnInf07.Visible = True
        PnnSup07.Visible = True

        PnnInf08.Visible = True
        PnnSup08.Visible = True

        PnnInf09.Visible = True
        PnnSup09.Visible = True

        PnnInf00.Visible = True
        PnnSup00.Visible = True

    End Sub

    Private Sub LblEsc01_Click(sender As Object, e As EventArgs) Handles LblEsc01.Click

        LimpaTudo()

        LblEsc01.ForeColor = Color.Gainsboro
        LblEsc01.BackColor = Color.DarkSlateGray

        PnnInf01.Visible = False
        PnnSup01.Visible = False


        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc02_Click(sender As Object, e As EventArgs) Handles LblEsc02.Click

        LimpaTudo()

        LblEsc02.ForeColor = Color.Gainsboro
        LblEsc02.BackColor = Color.DarkSlateGray

        PnnInf02.Visible = False
        PnnSup02.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc03_Click(sender As Object, e As EventArgs) Handles LblEsc03.Click

        LimpaTudo()

        LblEsc03.ForeColor = Color.Gainsboro
        LblEsc03.BackColor = Color.DarkSlateGray

        PnnInf03.Visible = False
        PnnSup03.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc04_Click(sender As Object, e As EventArgs) Handles LblEsc04.Click

        LimpaTudo()

        LblEsc04.ForeColor = Color.Gainsboro
        LblEsc04.BackColor = Color.DarkSlateGray

        PnnInf04.Visible = False
        PnnSup04.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc05_Click(sender As Object, e As EventArgs) Handles LblEsc05.Click

        LimpaTudo()

        LblEsc05.ForeColor = Color.Gainsboro
        LblEsc05.BackColor = Color.DarkSlateGray

        PnnInf05.Visible = False
        PnnSup05.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc06_Click(sender As Object, e As EventArgs) Handles LblEsc06.Click

        LimpaTudo()

        LblEsc06.ForeColor = Color.Gainsboro
        LblEsc06.BackColor = Color.DarkSlateGray

        PnnInf06.Visible = False
        PnnSup06.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc07_Click(sender As Object, e As EventArgs) Handles LblEsc07.Click

        LimpaTudo()

        LblEsc07.ForeColor = Color.Gainsboro
        LblEsc07.BackColor = Color.DarkSlateGray

        PnnInf07.Visible = False
        PnnSup07.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc08_Click(sender As Object, e As EventArgs) Handles LblEsc08.Click

        LimpaTudo()

        LblEsc08.ForeColor = Color.Gainsboro
        LblEsc08.BackColor = Color.DarkSlateGray

        PnnInf08.Visible = False
        PnnSup08.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc09_Click(sender As Object, e As EventArgs) Handles LblEsc09.Click

        LimpaTudo()

        LblEsc09.ForeColor = Color.Gainsboro
        LblEsc09.BackColor = Color.DarkSlateGray

        PnnInf09.Visible = False
        PnnSup09.Visible = False

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub LblEsc00_Click(sender As Object, e As EventArgs) Handles LblEsc00.Click

        LimpaTudo()

        LblEsc00.ForeColor = Color.Gainsboro
        LblEsc00.BackColor = Color.DarkSlateGray

        PnnInf00.Visible = False
        PnnSup00.Visible = False


        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then

            If PicObrigatorio.Visible = False Then
                If TrImagens.Nodes.Count > 0 Then
                    BtnPróximo.Enabled = True
                Else
                    BtnPróximo.Enabled = False
                End If
            End If

        Else
            BtnPróximo.Enabled = False
        End If

    End Sub

    Dim _IdREspostaUsuario As Integer

    Public Sub Salva_imagens()

        ' varre treeview 

        Dim ImageSelecionada As Image

        For Each row As TreeNode In TrImagens.Nodes

            ImageSelecionada = Image.FromFile(row.Text)

            'declara imagem em formato para o banco de dados

            Dim arrImage() As Byte
            Dim strImage As String
            Dim myMs As New IO.MemoryStream
            '
            If Not IsNothing(ImageSelecionada) Then
                ImageSelecionada.Save(myMs, ImageSelecionada.RawFormat)
                arrImage = myMs.GetBuffer
                strImage = "?"
            Else
                arrImage = Nothing
                strImage = "NULL"
            End If

            'busca o id da categoria
            'LqOficina.InsereImagemRespostaCheklistUsuario(_IdRespostaUsuarioN, arrImage, "", LblProcesso.Text)

            'busca ultima imagem

            Dim BusaImagem = From img In LqOficina.ImagemRespostaCklist
                             Where img.IdImagemProcesso Like "*"
                             Select img.IdImagemProcesso
                             Order By IdImagemProcesso Descending

            'insere as marcas no sistema

            For Each row1 As TreeNode In row.Nodes(4).Nodes

                LqOficina.InsereMarcaImagem(BusaImagem.First, row1.Text, row1.Nodes(0).Text, row1.Nodes(1).Text, LblProcesso.Text, "RED")

            Next

        Next
    End Sub


    Public Sub DesenhaImagens()

        Dim Zoom_img As Decimal = 0.18

        'FrmImagemAvaliação.PictureBox1.Width, FrmImagemAvaliação.PictureBox1.Height

        Dim ValorDiminuidoX As Decimal = 200
        Dim ValorDiminuidoY As Decimal = 200 + (TrImagens.Nodes.Count * (FrmImagemAvaliação.PictureBox1.Height * Zoom_img))

        Dim BmtpX As Integer = ValorDiminuidoX
        Dim BmtpY As Integer = ValorDiminuidoY

        Dim PintarBitmap = New Bitmap(BmtpX, BmtpY)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.SlateGray, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = FrmImagemAvaliação.PictureBox1.Width * Zoom_img
        Dim ValorQuadraUnitY As Decimal = FrmImagemAvaliação.PictureBox1.Height * Zoom_img

        'varre lista inserida

        Dim AddX As Decimal = 5

        Dim Frac As Integer = 180 / 3
        Pintura.DrawImage(My.Resources.add_1_icon, Frac + 10, Frac - 30, Frac, Frac)

        Dim AddY As Decimal = (Frac - 30) + 80

        For Each item As TreeNode In TrImagens.Nodes

            Pintura.DrawImage(Image.FromFile(item.Text), AddX + 5, AddY + 5, ValorQuadraUnitX, ValorQuadraUnitY)
            Pintura.DrawRectangle(SlateGrayPen, AddX, AddY, ValorQuadraUnitX + 10, ValorQuadraUnitY + 10)

            'pinta pontos encontrados


            AddY += ValorQuadraUnitY + 10

            item.Nodes(0).Text = AddX
            item.Nodes(1).Text = 5

            item.Nodes(2).Text = AddX + ValorQuadraUnitX
            item.Nodes(3).Text = 5 + ValorQuadraUnitY

            Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), AddX - 7, 0, 5, ValorQuadraUnitY + 10)

        Next

        PicImagens.BackgroundImage = PintarBitmap

        PicImagens.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicImagens.Location = New Point(0, 0)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub TrMp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrMp.AfterSelect

        BtnPróximo.Enabled = False

        For Each row As TreeNode In TrMp.Nodes

            If row.Checked = True Then

                If PicObrigatorio.Visible = False Then
                    If TrImagens.Nodes.Count > 0 Then
                        BtnPróximo.Enabled = True
                    Else
                        BtnPróximo.Enabled = False
                    End If
                End If

            End If

        Next

    End Sub

    Private Sub TrUp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrUp.AfterSelect

        If PicObrigatorio.Visible = False Then
            If TrImagens.Nodes.Count > 0 Then
                BtnPróximo.Enabled = True
            Else
                BtnPróximo.Enabled = False
            End If
        End If

    End Sub

    Dim MouseX As Decimal
    Dim MouseY As Decimal

    Dim OpenDiaglog As New OpenFileDialog

    Private Sub PicImagens_Click(sender As Object, e As EventArgs) Handles PicImagens.Click

        Me.Cursor = Cursors.WaitCursor

        If MouseX >= (180 / 3) + 10 And MouseX <= (180 / 3) + 10 + 50 Then

            If MouseY >= (180 / 3) - 40 And MouseY <= ((180 / 3) - 40) + 70 Then

                'Exibe a caixa de diálogo

                If OpenDiaglog.ShowDialog = Windows.Forms.DialogResult.OK Then

                    FrmImagemAvaliação.Size = New Size(1100, 710)

                    'Insere no grid

                    FrmImagemAvaliação.NomeArquivo = OpenDiaglog.FileName.ToString

                    Dim PintarBitmap = New Bitmap(FrmImagemAvaliação.PictureBox1.Width, FrmImagemAvaliação.PictureBox1.Height)

                    Dim Pintura = Graphics.FromImage(PintarBitmap)

                    Pintura.DrawImage(Image.FromFile(OpenDiaglog.FileName.ToString), 0, 0, FrmImagemAvaliação.PictureBox1.Width, FrmImagemAvaliação.PictureBox1.Height)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.WhiteSmoke)), 0, 0, FrmImagemAvaliação.PictureBox1.Width, FrmImagemAvaliação.PictureBox1.Height)

                    FrmImagemAvaliação.PictureBox1.BackgroundImage = PintarBitmap

                    FrmImagemAvaliação.Show(Me)

                    'Me.Opacity = 0.35

                    Me.Cursor = Cursors.Arrow

                Else

                    Me.Cursor = Cursors.Arrow

                End If

            End If

        Else
            DesenhaImagens()
        End If

    End Sub

    Private Sub PicImagens_MouseMove(sender As Object, e As MouseEventArgs) Handles PicImagens.MouseMove

        PicImagens.Cursor = Cursors.Arrow

        MouseX = e.X
        MouseY = e.Y

        If MouseX >= (180 / 3) + 10 And MouseX <= (180 / 3) + 10 + 60 Then

            If MouseY >= (180 / 3) - 30 And MouseY <= ((180 / 3) - 40) + 70 Then

                PicImagens.Cursor = Cursors.Hand

            End If

        End If

    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BtnConcluir.Click

        LqOficina.AtualizaEncerraVistoriaVeiculo(LblProcesso.Text, Now.TimeOfDay, Today.Date, True)

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Public _Placa As String
    Public _IdVeiculo As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        FrmEntradaVeiculo._Placa = _placa

        FrmEntradaVeiculo.LblPlaca.Text = LblPlaca.Text

        Dim BuscaProcesso = From conc In LqOficina.Vistorias
                            Where conc.NivelReq = 0 And conc.IdVeiculo = _IdVeiculo
                            Select conc.IdVistoria, conc.IdCliente

        FrmEntradaVeiculo.LblProcesso.Text = BuscaProcesso.First.IdVistoria

        FrmEntradaVeiculo._IdVeiculo = _Idveiculo
        FrmEntradaVeiculo._IdCliente = BuscaProcesso.First.IdCliente

        FrmEntradaVeiculo.Show(Me)

    End Sub

    Private Sub LblPergunta_Click(sender As Object, e As EventArgs) Handles LblPergunta.Click

        Salva_imagens()

    End Sub
End Class