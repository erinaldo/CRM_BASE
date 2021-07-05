Public Class FrmVistoria
    Private Sub GroupBox3_Enter(sender As Object, e As EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub BttBuscarCliente_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Dim _idChecklist As Integer
    Dim _idItemChecklist As Integer
    Dim _idProcessoChecklist As Integer
    Dim _idEtapaChecklist As Integer

    Dim _PosChecklist As Integer = 1
    Dim _PosItemChecklist As Integer = 1
    Dim _PosProcessoChecklist As Integer = 1
    Dim _PosEtapaChecklist As Integer = 1
    Private Sub FrmVistoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DeclaraFormulario()

    End Sub

    Public Sub PopulaCountTT()

        Dim Count_CkList As Integer = 0
        Dim Count_Catklst As Integer = 0
        Dim Count_ProcessoCatCheklist As Integer = 0
        Dim Count_EtapaCatChecklist As Integer = 0
        Dim Count_PerguntaEtapaCatCkLst As Integer = 0

        'popula resultados  o treeview do resumo

        Dim BuscaChecklist = From ch In LqOficina.Cheklist
                             Where ch.Nivel_req = 0
                             Select ch.Posicao, ch.IdChecklist, ch.Titulo
                             Order By Posicao Ascending

        For Each item0 In BuscaChecklist.ToList

            Count_CkList += 1

            'busca categorias

            Dim BuscaCategoria = From ch In LqOficina.ItemCheklist
                                 Where ch.IdChecklist = item0.IdChecklist
                                 Select ch.IdItem, ch.Descricao, ch.Posicao
                                 Order By Posicao Ascending

            For Each item1 In BuscaCategoria.ToList

                Count_Catklst += 1

                'busca categorias

                Dim BuscaProcesso = From ch In LqOficina.ProcessosChecklist
                                    Where ch.IdItem = item1.IdItem
                                    Select ch.IdProcesso, ch.Descricao, ch.Posicao
                                    Order By Posicao Ascending

                For Each item2 In BuscaProcesso.ToList

                    Count_ProcessoCatCheklist += 1

                    'busca categorias

                    Dim BuscaEtapa = From ch In LqOficina.EtapasChecklist
                                     Where ch.IdProcesso = item2.IdProcesso And ch.Tipo = 0
                                     Select ch.IdEtapaProcessoChecklist, ch.Titulo, ch.Posicao
                                     Order By Posicao Ascending

                    For Each item3 In BuscaEtapa.ToList

                        Count_EtapaCatChecklist += 1

                        Dim BuscaPerguntaChlist = From ch In LqOficina.PerguntasChecklist
                                                  Where ch.IdEtapaProcesso = item3.IdEtapaProcessoChecklist
                                                  Select ch.IdPerguntaChecklit, ch.Titulo, ch.Posicao
                                                  Order By Posicao Ascending

                        For Each item4 In BuscaPerguntaChlist.ToList

                            Count_PerguntaEtapaCatCkLst += 1

                        Next

                    Next
                    '   
                Next

            Next

        Next

    End Sub
    Public Sub ProcuraValoresInciais()

        PopulaCountTT()

        'carrega checklist para este form

        Dim BuscaChecklist = From ch In LqOficina.Cheklist
                             Where ch.Nivel_req = 0 And ch.Posicao = _PosChecklist
                             Select ch.Titulo, ch.Posicao, ch.IdChecklist

        If BuscaChecklist.Count > 0 Then

            LblTituloChecklist.Text = "Titulo do checklist: " & BuscaChecklist.First.Titulo

            _idChecklist = BuscaChecklist.First.IdChecklist
            _PosChecklist = BuscaChecklist.First.Posicao

            'procura Item CheckList

            Dim BuscaItemChecklist = From ch In LqOficina.ItemCheklist
                                     Where ch.IdChecklist = _idChecklist And ch.Posicao = _PosItemChecklist
                                     Select ch.Descricao, ch.Posicao, ch.IdItem


            If BuscaItemChecklist.Count > 0 Then

                LblTituloChecklist.Text &= " | Categoria do cheklist: " & BuscaItemChecklist.First.descricao

                _idItemChecklist = BuscaItemChecklist.First.IdItem
                _PosItemChecklist = BuscaItemChecklist.First.Posicao

                'procura processos

                Dim BuscaProcessoChecklist = From ch In LqOficina.ProcessosChecklist
                                             Where ch.IdItem = BuscaItemChecklist.First.IdItem And ch.Posicao = _PosProcessoChecklist
                                             Select ch.Descricao, ch.Posicao, ch.IdProcesso

                If BuscaProcessoChecklist.Count > 0 Then

                    LblTituloChecklist.Text &= " | Processo: " & BuscaProcessoChecklist.First.descricao

                    _idProcessoChecklist = BuscaProcessoChecklist.First.IdProcesso
                    _PosProcessoChecklist = BuscaProcessoChecklist.First.Posicao

                    'busca Etapas

                    Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.EtapasChecklist
                                                      Where ch.IdProcesso = BuscaProcessoChecklist.First.IdProcesso And ch.Posicao = _PosEtapaChecklist
                                                      Select ch.descricao, ch.Posicao, ch.IdProcesso, ch.Tipo, ch.Titulo, ch.IdEtapaProcessoChecklist

                    If BuscaEtapaProcessoChecklist.Count > 0 Then

                        If BuscaEtapaProcessoChecklist.First.Tipo = -1 Then

                            _idEtapaChecklist = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist
                            _PosEtapaChecklist = BuscaEtapaProcessoChecklist.First.Posicao

                            LblTituloCheklist.Text = "Nota: " & BuscaEtapaProcessoChecklist.First.Titulo
                            LblDetalheInteração.Text = BuscaEtapaProcessoChecklist.First.descricao

                            PnOpcInteração.Visible = True
                            PnnInteração.Visible = False

                            PnOpcInteração.Dock = DockStyle.Fill

                        Else

                            _idEtapaChecklist = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist
                            _PosEtapaChecklist = BuscaEtapaProcessoChecklist.First.Posicao

                            LblTituloPnnInteração.Text = "Etapa: " & BuscaEtapaProcessoChecklist.First.Titulo

                            PnOpcInteração.Visible = False
                            PnnInteração.Visible = True

                            PnnInteração.Dock = DockStyle.Fill

                            'busca perguntas 

                            Dim BuscaPergunta = From perg In LqOficina.PerguntasChecklist
                                                Where perg.IdEtapaProcesso = _idEtapaChecklist And perg.Posicao = _PosPerguntaEtapa
                                                Select perg.IdPerguntaChecklit, perg.Posicao, perg.TipoResposta, perg.Titulo

                            If BuscaPergunta.Count > 0 Then

                                _IdPerguntaEtapa = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist
                                _PosPerguntaEtapa = BuscaEtapaProcessoChecklist.First.Posicao

                                LblTituloPnnInteração.Text &= " | Questão " & _PosPerguntaEtapa & ": " & BuscaPergunta.First.Titulo

                                If BuscaPergunta.First.TipoResposta = 1 Then

                                    PnnEscala.Visible = False

                                    PnnTexto.Visible = True
                                    PnnTexto.Dock = DockStyle.Fill

                                ElseIf BuscaPergunta.First.TipoResposta = 2 Then

                                    PnnEscala.Visible = False

                                    PnnTexto.Visible = False

                                ElseIf BuscaPergunta.First.TipoResposta = 3 Then

                                    PnnTexto.Visible = False

                                    PnnEscala.Visible = True
                                    PnnEscala.Dock = DockStyle.Fill

                                End If

                            End If

                        End If

                    End If

                End If

            Else

                PnOpcInteração.Visible = False
                PnnInteração.Visible = False

                LblTituloChecklist.Text &= " | Não foi possível encontrar alguma categoria valida para o chekclist. Edite as categorias e tente novamente."

            End If

        End If
    End Sub
    Public Sub DeclaraFormulario()

        'carrega checklist para este form

        Dim BuscaChecklist = From ch In LqOficina.Cheklist
                             Where ch.Nivel_req = 0 And ch.Posicao = _PosChecklist
                             Select ch.Titulo, ch.Posicao, ch.IdChecklist

        If BuscaChecklist.Count > 0 Then

            _idChecklist = BuscaChecklist.First.IdChecklist

            LblTituloChecklist.Text = "Titulo do checklist: " & BuscaChecklist.First.Titulo

            'procura Item CheckList

            Dim BuscaItemChecklist = From ch In LqOficina.ItemCheklist
                                     Where ch.IdChecklist = BuscaChecklist.First.IdChecklist And ch.Posicao = _PosItemChecklist
                                     Select ch.Descricao, ch.Posicao, ch.IdItem

            If BuscaItemChecklist.Count > 0 Then

                _idItemChecklist = BuscaItemChecklist.First.IdItem

                LblTituloChecklist.Text &= " | Categoria do checklist: " & BuscaItemChecklist.First.descricao

                'procura processos

                Dim BuscaProcessoChecklist = From ch In LqOficina.ProcessosChecklist
                                             Where ch.IdItem = BuscaItemChecklist.First.IdItem And ch.Posicao = _PosProcessoChecklist
                                             Select ch.Descricao, ch.Posicao, ch.IdProcesso

                If BuscaProcessoChecklist.Count > 0 Then

                    _idProcessoChecklist = BuscaProcessoChecklist.First.IdProcesso

                    LblTituloChecklist.Text &= " | Processo: " & BuscaProcessoChecklist.First.descricao

                    'busca Etapas

                    Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.EtapasChecklist
                                                      Where ch.IdProcesso = BuscaProcessoChecklist.First.IdProcesso And ch.Posicao = _PosEtapaChecklist
                                                      Select ch.descricao, ch.Posicao, ch.IdProcesso, ch.Tipo, ch.Titulo, ch.IdEtapaProcessoChecklist

                    If BuscaEtapaProcessoChecklist.Count > 0 Then

                        _idEtapaChecklist = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist

                        TipoEtapa = BuscaEtapaProcessoChecklist.First.Tipo

                        If BuscaEtapaProcessoChecklist.First.Tipo = -1 Then

                            LblTituloCheklist.Text = "Nota: " & BuscaEtapaProcessoChecklist.First.Titulo
                            LblDetalheInteração.Text = BuscaEtapaProcessoChecklist.First.descricao

                            PnOpcInteração.Visible = True
                            PnnInteração.Visible = False

                            PnOpcInteração.Dock = DockStyle.Fill

                        Else

                            LblTituloPnnInteração.Text = "Etapa: " & BuscaEtapaProcessoChecklist.First.Titulo

                            PnOpcInteração.Visible = False
                            PnnInteração.Visible = True

                            PnnInteração.Dock = DockStyle.Fill

                            'busca perguntas 

                            Dim BuscaPergunta = From perg In LqOficina.PerguntasChecklist
                                                Where perg.IdEtapaProcesso = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist And perg.Posicao = _PosPerguntaEtapa
                                                Select perg.IdPerguntaChecklit, perg.Posicao, perg.TipoResposta, perg.Titulo, perg.ExigeImagem

                            If BuscaPergunta.Count > 0 Then

                                If BuscaPergunta.First.ExigeImagem = True Then
                                    LblImagemObrigatoria.Visible = True
                                End If

                                LblPerguntaEscala.Text = "Questão " & _PosPerguntaEtapa & ": " & BuscaPergunta.First.Titulo

                                If BuscaPergunta.First.TipoResposta = 1 Then

                                    PnnEscala.Visible = False
                                    PnnSimNão.Visible = False

                                    PnnTexto.Visible = True
                                    PnnTexto.Dock = DockStyle.Fill

                                ElseIf BuscaPergunta.First.TipoResposta = 2 Then

                                    PnnEscala.Visible = False
                                    PnnTexto.Visible = False

                                    PnnSimNão.Visible = True
                                    PnnSimNão.Dock = DockStyle.Fill

                                ElseIf BuscaPergunta.First.TipoResposta = 3 Then

                                    PnnTexto.Visible = False
                                    PnnSimNão.Visible = False

                                    PnnEscala.Visible = True
                                    PnnEscala.Dock = DockStyle.Fill

                                End If

                            End If

                        End If

                    End If

                End If

            Else

                PnOpcInteração.Visible = False
                PnnInteração.Visible = False

                LblTituloChecklist.Text &= " | Não foi possível encontrar alguma categoria valida para o chekclist. Edite as categorias e tente novamente."

            End If

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim _IdPerguntaEtapa As Integer
    Dim _PosPerguntaEtapa As Integer = 1
    Dim TipoEtapa As Integer

    Public Sub DeclaraAvança()

        Dim Interrompe As Boolean = False

        'While Interrompe = False

        _PosPerguntaEtapa += 1

        'busca perguntas 
        If TipoEtapa = 0 Then

            Dim BuscaPergunta = From perg In LqOficina.PerguntasChecklist
                                Where perg.IdEtapaProcesso = _idEtapaChecklist And perg.Posicao = _PosPerguntaEtapa
                                Select perg.IdPerguntaChecklit, perg.Posicao, perg.TipoResposta, perg.Titulo, perg.ExigeImagem

            If BuscaPergunta.Count > 0 Then

                If BuscaPergunta.First.ExigeImagem = True Then
                    LblImagemObrigatoria.Visible = True
                End If

                LblPerguntaEscala.Text = "Questão " & _PosPerguntaEtapa & ": " & BuscaPergunta.First.Titulo

                If BuscaPergunta.First.TipoResposta = 1 Then

                    PnnEscala.Visible = False
                    PnnSimNão.Visible = False
                    PnnUp.Visible = False
                    PnnMp.Visible = False

                    PnnTexto.Visible = True
                    PnnTexto.Dock = DockStyle.Fill

                ElseIf BuscaPergunta.First.TipoResposta = 2 Then

                    PnnEscala.Visible = False
                    PnnTexto.Visible = False
                    PnnUp.Visible = False
                    PnnMp.Visible = False

                    PnnSimNão.Visible = True
                    PnnSimNão.Dock = DockStyle.Fill

                ElseIf BuscaPergunta.First.TipoResposta = 3 Then

                    PnnTexto.Visible = False
                    PnnSimNão.Visible = False
                    PnnUp.Visible = False
                    PnnMp.Visible = False

                    PnnEscala.Visible = True
                    PnnEscala.Dock = DockStyle.Fill

                ElseIf BuscaPergunta.First.TipoResposta = 4 Then

                    PnnTexto.Visible = False
                    PnnSimNão.Visible = False
                    PnnEscala.Visible = False
                    PnnMp.Visible = False

                    PnnUp.Visible = True

                    PnnUp.Dock = DockStyle.Fill

                    Dim BuscaReposta = From rsp In LqOficina.RespostasChecklist
                                       Where rsp.IdPerguntaEtapa = BuscaPergunta.First.IdPerguntaChecklit
                                       Select rsp.descricao, rsp.IdPerguntaEtapa

                    For Each row In BuscaReposta.ToList

                        Dim Titulo As String = row.descricao

                        TrUp.Nodes.Add(Titulo)

                    Next

                ElseIf BuscaPergunta.First.TipoResposta = 5 Then

                    PnnTexto.Visible = False
                    PnnSimNão.Visible = False
                    PnnEscala.Visible = False
                    PnnUp.Visible = False

                    PnnMp.Visible = True

                    PnnMp.Dock = DockStyle.Fill

                    Dim BuscaReposta = From rsp In LqOficina.RespostasChecklist
                                       Where rsp.IdPerguntaEtapa = BuscaPergunta.First.IdPerguntaChecklit
                                       Select rsp.descricao, rsp.IdPerguntaEtapa

                    For Each row In BuscaReposta.ToList

                        Dim Titulo As String = row.descricao

                        TrMp.Nodes.Add(Titulo)

                    Next

                End If

            Else

                DeclaraNovaEtapa()

            End If

            PnOpcInteração.Visible = False
            PnnInteração.Visible = True

        Else

            Dim BuscaEtapaProcessoChecklist = From et In LqOficina.EtapasChecklist
                                              Where et.IdEtapaProcessoChecklist = _idEtapaChecklist
                                              Select et.Titulo, et.descricao

            LblTituloCheklist.Text = "Nota: " & BuscaEtapaProcessoChecklist.First.Titulo
            LblDetalheInteração.Text = BuscaEtapaProcessoChecklist.First.descricao

            PnOpcInteração.Visible = True
            PnnInteração.Visible = False

            PnOpcInteração.Dock = DockStyle.Fill

            'DeclaraNovaEtapa()

        End If

        'End While

    End Sub

    Public Sub DeclaraNovaEtapa()

        _PosEtapaChecklist += 1

        'busca Etapas

        Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.EtapasChecklist
                                          Where ch.IdProcesso = _idProcessoChecklist And ch.Posicao = _PosEtapaChecklist
                                          Select ch.descricao, ch.Posicao, ch.IdProcesso, ch.Tipo, ch.Titulo, ch.IdEtapaProcessoChecklist

        If BuscaEtapaProcessoChecklist.Count > 0 Then

            _PosPerguntaEtapa = 0

            TipoEtapa = BuscaEtapaProcessoChecklist.First.Tipo

            _idEtapaChecklist = BuscaEtapaProcessoChecklist.First.IdEtapaProcessoChecklist

            DeclaraAvança()

        Else

            DeclaraNovaProcesso()

        End If

    End Sub
    Public Sub DeclaraNovaProcesso()

        _PosProcessoChecklist += 1

        'busca Etapas

        Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.ProcessosChecklist
                                          Where ch.IdItem = _idItemChecklist And ch.Posicao = _PosProcessoChecklist
                                          Select ch.Descricao, ch.Posicao, ch.IdProcesso

        If BuscaEtapaProcessoChecklist.Count > 0 Then

            _PosEtapaChecklist = 0

            _idProcessoChecklist = BuscaEtapaProcessoChecklist.First.IdProcesso

            DeclaraNovaEtapa()

        Else

            DeclaraNovaItem()

        End If

    End Sub

    Public Sub DeclaraNovaItem()

        _PosItemChecklist += 1

        'busca Etapas

        Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.ItemCheklist
                                          Where ch.IdChecklist = _idItemChecklist And ch.Posicao = _PosItemChecklist
                                          Select ch.Descricao, ch.Posicao, ch.IdItem

        If BuscaEtapaProcessoChecklist.Count > 0 Then

            _PosProcessoChecklist = 0

            _idItemChecklist = BuscaEtapaProcessoChecklist.First.IdItem

            DeclaraNovaProcesso()

        Else

            DeclaraNovaChecklist()

        End If

    End Sub

    Public Sub DeclaraNovaChecklist()

        _PosChecklist += 1

        'busca Etapas

        Dim BuscaEtapaProcessoChecklist = From ch In LqOficina.Cheklist
                                          Where ch.Nivel_req = 0 And ch.Posicao = _PosChecklist
                                          Select ch.Titulo, ch.Posicao, ch.IdChecklist

        If BuscaEtapaProcessoChecklist.Count > 0 Then

            _PosItemChecklist = 0

            _idChecklist = BuscaEtapaProcessoChecklist.First.IdChecklist

            DeclaraNovaItem()

        Else

            PnnInteração.Visible = True
            PnnInformativo.Visible = True

        End If

    End Sub


    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs)

    End Sub

    Private Sub BttAvançaUm_Click_1(sender As Object, e As EventArgs)

        DeclaraAvança()

    End Sub

    'Limpa campos

    Public Sub Limpa()

        PnnI1.Visible = True
        PnnS1.Visible = True

        LblEsc01.Font = New Font("Calibri", 16)
        LblEsc01.BackColor = Color.SlateGray


        PnnI2.Visible = True
        PnnS2.Visible = True

        LblEsc02.Font = New Font("Calibri", 16)
        LblEsc02.BackColor = Color.SlateGray


        PnnI3.Visible = True
        PnnS3.Visible = True

        LblEsc03.Font = New Font("Calibri", 16)
        LblEsc03.BackColor = Color.SlateGray


        PnnI4.Visible = True
        PnnS4.Visible = True

        LblEsc04.Font = New Font("Calibri", 16)
        LblEsc04.BackColor = Color.SlateGray


        PnnI5.Visible = True
        PnnS5.Visible = True

        LblEsc05.Font = New Font("Calibri", 16)
        LblEsc05.BackColor = Color.SlateGray


        PnnI6.Visible = True
        PnnS6.Visible = True

        LblEsc06.Font = New Font("Calibri", 16)
        LblEsc06.BackColor = Color.SlateGray


        PnnI7.Visible = True
        PnnS7.Visible = True

        LblEsc07.Font = New Font("Calibri", 16)
        LblEsc07.BackColor = Color.SlateGray

        PnnI8.Visible = True
        PnnS8.Visible = True

        LblEsc08.Font = New Font("Calibri", 16)
        LblEsc08.BackColor = Color.SlateGray


        PnnI9.Visible = True
        PnnS9.Visible = True

        LblEsc09.Font = New Font("Calibri", 16)
        LblEsc09.BackColor = Color.SlateGray


        PnnI10.Visible = True
        PnnS10.Visible = True

        LblEsc010.Font = New Font("Calibri", 16)
        LblEsc010.BackColor = Color.SlateGray


    End Sub

    Dim _Valor As Integer = 0

    Private Sub LblEsc01_Click(sender As Object, e As EventArgs) Handles LblEsc01.Click

        Limpa()

        PnnI1.Visible = False
        PnnS1.Visible = False

        LblEsc01.Font = New Font("Calibri", 22)
        LblEsc01.BackColor = Color.DarkGoldenrod

        _Valor = 1

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc02_Click(sender As Object, e As EventArgs) Handles LblEsc02.Click

        Limpa()

        PnnI2.Visible = False
        PnnS2.Visible = False

        LblEsc02.Font = New Font("Calibri", 22)
        LblEsc02.BackColor = Color.DarkGoldenrod

        _Valor = 2

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc03_Click(sender As Object, e As EventArgs) Handles LblEsc03.Click

        Limpa()

        PnnI3.Visible = False
        PnnS3.Visible = False

        LblEsc03.Font = New Font("Calibri", 22)
        LblEsc03.BackColor = Color.DarkGoldenrod

        _Valor = 3

        BtnProximo2.Enabled = True

    End Sub

    Private Sub K_Click(sender As Object, e As EventArgs) Handles LblEsc04.Click

        Limpa()

        PnnI4.Visible = False
        PnnS4.Visible = False

        LblEsc04.Font = New Font("Calibri", 22)
        LblEsc04.BackColor = Color.DarkGoldenrod

        _Valor = 4

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc05_Click(sender As Object, e As EventArgs) Handles LblEsc05.Click

        Limpa()

        PnnI5.Visible = False
        PnnS5.Visible = False

        LblEsc05.Font = New Font("Calibri", 22)
        LblEsc05.BackColor = Color.DarkGoldenrod

        _Valor = 5

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc06_Click(sender As Object, e As EventArgs) Handles LblEsc06.Click

        Limpa()

        PnnI6.Visible = False
        PnnS6.Visible = False

        LblEsc06.Font = New Font("Calibri", 22)
        LblEsc06.BackColor = Color.DarkGoldenrod

        _Valor = 6

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc07_Click(sender As Object, e As EventArgs) Handles LblEsc07.Click

        Limpa()

        PnnI7.Visible = False
        PnnS7.Visible = False

        LblEsc07.Font = New Font("Calibri", 22)
        LblEsc07.BackColor = Color.DarkGoldenrod

        _Valor = 7

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc08_Click(sender As Object, e As EventArgs) Handles LblEsc08.Click

        Limpa()

        PnnI8.Visible = False
        PnnS8.Visible = False

        LblEsc08.Font = New Font("Calibri", 22)
        LblEsc08.BackColor = Color.DarkGoldenrod

        _Valor = 8

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc09_Click(sender As Object, e As EventArgs) Handles LblEsc09.Click

        Limpa()

        PnnI9.Visible = False
        PnnS9.Visible = False

        LblEsc09.Font = New Font("Calibri", 22)
        LblEsc09.BackColor = Color.DarkGoldenrod

        _Valor = 9

        BtnProximo2.Enabled = True

    End Sub

    Private Sub LblEsc010_Click(sender As Object, e As EventArgs) Handles LblEsc010.Click

        Limpa()

        PnnI10.Visible = False
        PnnS10.Visible = False

        LblEsc010.Font = New Font("Calibri", 22)
        LblEsc010.BackColor = Color.DarkGoldenrod

        _Valor = 10

        BtnProximo2.Enabled = True

    End Sub

    Private Sub PnnEscala_VisibleChanged(sender As Object, e As EventArgs) Handles PnnEscala.VisibleChanged
        Limpa()
    End Sub

    Private Sub LblDetalheInteração_Click(sender As Object, e As EventArgs) Handles LblDetalheInteração.Click
    End Sub

    Private Sub PnOpcInteração_Paint(sender As Object, e As PaintEventArgs) Handles PnOpcInteração.Paint

    End Sub

    Private Sub BtnPróximo_Click(sender As Object, e As EventArgs) Handles BtnPróximo.Click

        Desenha_Galeria_inicio()

        DeclaraNovaEtapa()

    End Sub

    Private Sub BtnProximo2_Click(sender As Object, e As EventArgs) Handles BtnProximo2.Click

        Salva_valores()

        TrImagemTexto.Nodes.Clear()

        DesenhaImagens()

        'torna invisivel todos os padrões de paineis de interação

        PnnSimNão.Visible = False
        PnnEscala.Visible = False
        PnnTexto.Visible = False

        BtnProximo2.Enabled = False

        DeclaraAvança()

    End Sub

    Public Sub Salva_valores()

        'pinta inicial

        Desenha_Galeria_inicio()

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

            If LblEsc01.BackColor = Color.DarkGoldenrod Then

                Resposta = "1"

            ElseIf LblEsc02.BackColor = Color.DarkGoldenrod Then

                Resposta = "2"

            ElseIf LblEsc03.BackColor = Color.DarkGoldenrod Then

                Resposta = "3"

            ElseIf LblEsc04.BackColor = Color.DarkGoldenrod Then

                Resposta = "4"

            ElseIf LblEsc05.BackColor = Color.DarkGoldenrod Then

                Resposta = "5"

            ElseIf LblEsc06.BackColor = Color.DarkGoldenrod Then

                Resposta = "6"

            ElseIf LblEsc07.BackColor = Color.DarkGoldenrod Then

                Resposta = "7"

            ElseIf LblEsc08.BackColor = Color.DarkGoldenrod Then

                Resposta = "8"

            ElseIf LblEsc09.BackColor = Color.DarkGoldenrod Then

                Resposta = "9"

            ElseIf LblEsc010.BackColor = Color.DarkGoldenrod Then

                Resposta = "19"

            End If

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, Resposta, LblProcesso.Text)

        ElseIf PnnUp.Visible = True Then

            LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, UpSel, LblProcesso.Text)

        ElseIf PnnMp.Visible = True Then

            For Each row As TreeNode In TrMp.Nodes

                If row.Checked = True Then
                    LqOficina.InsereRespostaCheklistUsuario(_IdPerguntaEtapa, 0, UpSel, LblProcesso.Text)
                End If

            Next

        End If

    End Sub

    Dim UpSel As String
    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles LblSim.Click

        LblSim.BackColor = Color.DarkSlateGray
        LblNão.BackColor = Color.SlateGray

        PnnImagens.Enabled = True
        PicImagemTexto.Visible = True

        BtnProximo2.Enabled = True

        'verifica se resposta exige imagens

        Dim BUscaImagem = From img In LqOficina.RespostasChecklist
                          Where img.IdPerguntaEtapa = _IdPerguntaEtapa
                          Select img.IdRespostaProcesso, img.ExigeImagem


    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles LblNão.Click

        LblNão.BackColor = Color.DarkSlateGray
        LblSim.BackColor = Color.SlateGray

        PnnImagens.Enabled = True
        PicImagemTexto.Visible = True

        BtnProximo2.Enabled = True

    End Sub

    Private Sub Panel16_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BttBuscarCliente_Click_1(sender As Object, e As EventArgs) Handles BttBuscarCliente.Click

        FrmNovoChecklist.Show(Me)

        Me.Opacity = 0.4
        LblTitulo.BackColor = Color.DarkGreen
        PnnInferior.BackColor = Color.DarkGreen

    End Sub

    Private Sub PnnSimNão_VisibleChanged(sender As Object, e As EventArgs) Handles PnnSimNão.VisibleChanged

        LblSim.BackColor = Color.SlateGray

        LblNão.BackColor = Color.SlateGray

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then

            PnnImagens.Enabled = True
            PicImagemTexto.Visible = True

            DesenhaImagens()

            If LblImagemObrigatoria.Visible = False Then
                BtnProximo2.Enabled = True
            End If

        Else

                BtnProximo2.Enabled = False

        End If

    End Sub

    Private Sub LblPlaca_Click(sender As Object, e As EventArgs) Handles LblPlaca.Click

    End Sub

    Private Sub LblCkLst_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PnnResumo_Paint(sender As Object, e As PaintEventArgs) Handles PnnResumo.Paint

    End Sub

    Private Sub PnnResumo_VisibleChanged(sender As Object, e As EventArgs) Handles PnnResumo.VisibleChanged

        LblTituloChecklist.Text = "Resumo do checklist"

    End Sub

    Public Sub Desenha_Galeria_inicio()

        Dim PintarBitmap = New Bitmap(220, 220)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.SlateGray, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = 220
        Dim ValorQuadraUnitY As Decimal = 220

        Dim addx As Decimal = 5

        Pintura.DrawImage(My.Resources.add_1_icon, addx + 70, 70, ValorQuadraUnitY - 125, ValorQuadraUnitY - 125)

        addx += ValorQuadraUnitX + 10

        Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), AddX - 7, 0, 5, ValorQuadraUnitY + 10)



        PicImagemTexto.BackgroundImage = PintarBitmap

        PicImagemTexto.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicImagemTexto.Location = New Point((Panel10.Width / 2) - (PicImagemTexto.Width / 2), 5)

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim OpenDiaglog As New OpenFileDialog

    Public Sub DesenhaImagens()

        'FrmImagemAvaliação.PictureBox1.Width, FrmImagemAvaliação.PictureBox1.Height

        Dim ValorDiminuidoX As Decimal = FrmImagemAvaliação.PictureBox1.Width * 0.35
        Dim ValorDiminuidoY As Decimal = FrmImagemAvaliação.PictureBox1.Height * 0.35

        Dim BmtpX As Integer = ValorDiminuidoX
        Dim BmtpY As Integer = ValorDiminuidoY

        Dim PintarBitmap = New Bitmap(BmtpX * (TrImagemTexto.Nodes.Count + 1), BmtpY)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        ' Create pen.
        Dim SlateGrayPen As New Pen(Color.SlateGray, 0.5)
        SlateGrayPen.DashStyle = Drawing2D.DashStyle.Dot

        'cria fontes
        Dim drawFont_0 As New Font("Calibri", 10)

        'valor de 1 quadra
        Dim ValorQuadraUnitX As Decimal = ValorDiminuidoX
        Dim ValorQuadraUnitY As Decimal = ValorDiminuidoY

        'varre lista inserida

        Dim AddX As Decimal = 5

        Pintura.DrawImage(My.Resources.add_1_icon, AddX + 70, 70, ValorQuadraUnitY - 125, ValorQuadraUnitY - 125)
        'Pintura.DrawRectangle(SlateGrayPen, AddX, 5, ValorQuadraUnitY, ValorQuadraUnitY)

        AddX += ValorQuadraUnitY + 10

        Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), AddX - 7, 0, 5, ValorQuadraUnitY + 10)

        For Each item As TreeNode In TrImagemTexto.Nodes

            Pintura.DrawImage(Image.FromFile(item.Text), AddX, 5, ValorQuadraUnitX, ValorQuadraUnitY)
            Pintura.DrawRectangle(SlateGrayPen, AddX, 5, ValorQuadraUnitX + 5, ValorQuadraUnitY + 5)

            'pinta pontos encontrados

            For Each item1 As TreeNode In item.Nodes(4).Nodes

                'verifica a qtdade da camada abaixo

                If item1.Nodes.Count > 2 Then

                    'varre a ultimalinha

                    For Each item2 As TreeNode In item1.Nodes(4).Nodes

                        Dim Valor_X As Decimal = item2.Nodes(1).Text
                        Valor_X = Valor_X * 0.35

                        Dim Valor_y As Decimal = item2.Nodes(2).Text
                        Valor_y = Valor_y * 0.35

                        Pintura.FillRectangle(New SolidBrush(Color.LimeGreen), (AddX + Valor_X), ((Valor_y)), 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), (AddX + Valor_X) + 5, ((Valor_y)) - 7, 25, 12)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 0.5), (AddX + Valor_X) + 5, ((Valor_y)) - 7, 25, 12)

                        Pintura.DrawString(item1.Index & "." & item2.Index, New Font("Calibri", 8), New SolidBrush(Color.WhiteSmoke), (AddX + Valor_X) + 7, ((Valor_y)) - 7.5)

                    Next

                ElseIf item1.Nodes.Count <= 2 Then

                    Dim Valor_X As Decimal = item1.Nodes(0).Text
                    Valor_X = Valor_X * 0.35

                    Dim Valor_y As Decimal = item1.Nodes(1).Text
                    Valor_y = Valor_y * 0.35

                    Pintura.FillRectangle(New SolidBrush(Color.LimeGreen), (AddX + Valor_X), ((Valor_y)), 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), (AddX + Valor_X) + 5, ((Valor_y)) - 7, 15, 12)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 0.5), (AddX + Valor_X) + 5, ((Valor_y)) - 7, 15, 12)

                    Pintura.DrawString(item1.Index, New Font("Calibri", 8), New SolidBrush(Color.WhiteSmoke), (AddX + Valor_X) + 7, ((Valor_y)) - 7.5)

                End If

            Next

            AddX += ValorQuadraUnitX + 10

            item.Nodes(0).Text = AddX
            item.Nodes(1).Text = 5

            item.Nodes(2).Text = AddX + ValorQuadraUnitX
            item.Nodes(3).Text = 5 + ValorQuadraUnitY

            Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), AddX - 7, 0, 5, ValorQuadraUnitY + 10)


        Next

        PicImagemTexto.BackgroundImage = PintarBitmap

        PicImagemTexto.Size = New Size(PintarBitmap.Width, PintarBitmap.Height)

        PicImagemTexto.Location = New Point(5, 5)

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim _IdREspostaUsuario As Integer

    Public Sub Salva_imagens()

        ' varre treeview 

        Dim ImageSelecionada As Image

        For Each row As TreeNode In TrImagemTexto.Nodes

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

            'LqOficina.InsereImagemRespostaCheklistUsuario(_IdREspostaUsuario, arrImage, "")

        Next
    End Sub

    Dim Mouse_X As Integer
    Dim Mouse_Y As Integer

    Private Sub PicImagemTexto_Click(sender As Object, e As EventArgs) Handles PicImagemTexto.Click

        'Pintura.DrawImage(My.Resources.add_1_icon, AddX + 70, 70, ValorQuadraUnitY - 125, ValorQuadraUnitY - 125)

        'verifica ponto do clique

        Dim ValorQuadraUnitX As Decimal = 240

        If Mouse_X >= 75 And Mouse_X <= 75 + (ValorQuadraUnitX - 125) Then

            If Mouse_Y >= 70 And Mouse_Y <= 70 + (ValorQuadraUnitX - 125) Then

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

                    Me.Opacity = 0.35

                End If

            Else

                DesenhaImagens()

            End If

        End If

        If TrImagemTexto.Nodes.Count > 0 Then

            If LblImagemObrigatoria.Visible = True Then
                BtnProximo2.Enabled = True
            End If

        End If

    End Sub

    Private Sub PicImagemTexto_SizeChanged(sender As Object, e As EventArgs) Handles PicImagemTexto.SizeChanged

        'verifica a habilidade de habilitar os bot~~oes uteis

    End Sub

    Private Sub PicImagemTexto_MouseMove(sender As Object, e As MouseEventArgs) Handles PicImagemTexto.MouseMove

        Mouse_X = e.X
        Mouse_Y = e.Y

    End Sub

    Private Sub TrUp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrUp.AfterSelect

        UpSel = TrUp.SelectedNode.Text

        BtnProximo2.Enabled = True

    End Sub

    Private Sub TrMp_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrMp.AfterSelect

    End Sub

    Private Sub TrMp_BeforeCheck(sender As Object, e As TreeViewCancelEventArgs) Handles TrMp.BeforeCheck

    End Sub

    Private Sub TrMp_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TrMp.NodeMouseClick

        Dim _C As Integer = 0

        For Each row As TreeNode In TrMp.Nodes

            If row.Checked = True Then

                _C += 1

            End If

        Next

        If _C > 0 Then

            BtnProximo2.Enabled = True

        Else

            BtnProximo2.Enabled = False

        End If

    End Sub
End Class