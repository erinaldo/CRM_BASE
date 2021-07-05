Public Class FrmFluxo
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqOficina As New LqOficinaDataContext

    Dim V_X As Integer
    Dim V_Y As Integer

    Public Sub PublicaTreeview()

        Dim LstTopicos As New ListBox

        LstTopicos.Items.Add("Vistoria Liberada?")
        LstTopicos.Items.Add("Veiculo na oficina?")
        'LstTopicos.Items.Add("Veiculo pronto para desmonte?")
        'LstTopicos.Items.Add("Veiculo liberado para inicio do reparo?")

        TrFluxo.Nodes.Clear()

        Dim MY As Integer

        Dim DY As Decimal = 100

        For i As Integer = 0 To LstTopicos.Items.Count - 1 Step 1

            TrFluxo.Nodes.Add(LstTopicos.Items(i).ToString)

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes.Add("MK")

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(0).Nodes.Add(60)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(0).Nodes.Add(DY)

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes.Add("Sim")
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes.Add("MK")

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(190 + 60)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(DY)

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(0)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(0)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(0)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1).Nodes(0).Nodes.Add(0)

            Dim BuscaChecklist = From ck In LqOficina.Cheklist
                                 Where ck.Nivel_req = i
                                 Select ck.IdChecklist, ck.Titulo, ck.Posicao
                                 Order By Posicao Ascending

            Dim TrFluxoNode0 As TreeNode = TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(1)

            Dim Av As Decimal = 190 * 2

            For Each item In BuscaChecklist.ToList

                TrFluxoNode0.Nodes.Add(item.Titulo)
                TrFluxoNode0.Nodes(TrFluxoNode0.Nodes.Count - 1).Nodes.Add("MK")

                Dim TrMArk As TreeNode = TrFluxoNode0.Nodes(TrFluxoNode0.Nodes.Count - 1).Nodes(0)

                TrMArk.Nodes.Add(60 + (190 * 2))
                TrMArk.Nodes.Add(0 + DY)

                'insere caracteristicas de botão

                TrMArk.Nodes.Add(item.IdChecklist)
                TrMArk.Nodes.Add(0)
                TrMArk.Nodes.Add(0)
                TrMArk.Nodes.Add(0)
                TrMArk.Nodes.Add(0)

                Dim BuscaItemChecklist = From ck In LqOficina.ItemCheklist
                                         Where ck.IdChecklist = item.IdChecklist
                                         Select ck.IdItem, ck.Descricao, ck.Posicao
                                         Order By Posicao Ascending

                Dim TrFluxoNode1 As TreeNode = TrFluxoNode0.Nodes(TrFluxoNode0.Nodes.Count - 1)

                Dim DY_0 As Decimal = DY

                If DY > MY Then

                    MY = DY

                End If

                For Each item1 In BuscaItemChecklist.ToList

                    TrFluxoNode1.Nodes.Add(item1.descricao)
                    TrFluxoNode1.Nodes(TrFluxoNode1.Nodes.Count - 1).Nodes.Add("MK")

                    Dim TrMArk1 As TreeNode = TrFluxoNode1.Nodes(TrFluxoNode1.Nodes.Count - 1).Nodes(0)

                    TrMArk1.Nodes.Add(60 + (190 * 3))
                    TrMArk1.Nodes.Add(0 + DY_0)

                    'insere caracteristicas de botão

                    TrMArk1.Nodes.Add(item1.IdItem)
                    TrMArk1.Nodes.Add(0)
                    TrMArk1.Nodes.Add(0)
                    TrMArk1.Nodes.Add(0)
                    TrMArk1.Nodes.Add(0)

                    Dim BuscaProcessoChecklist = From ck In LqOficina.ProcessosChecklist
                                                 Where ck.IdItem = item1.IdItem
                                                 Select ck.IdProcesso, ck.Descricao, ck.Posicao
                                                 Order By Posicao Ascending

                    Dim TrFluxoNode2 As TreeNode = TrFluxoNode1.Nodes(TrFluxoNode1.Nodes.Count - 1)

                    Dim DY_1 As Decimal = DY_0

                    If DY_0 > MY Then

                        MY = DY_0

                    End If

                    For Each item2 In BuscaProcessoChecklist.ToList

                        TrFluxoNode2.Nodes.Add(item2.descricao)
                        TrFluxoNode2.Nodes(TrFluxoNode2.Nodes.Count - 1).Nodes.Add("MK")

                        Dim TrMArk2 As TreeNode = TrFluxoNode2.Nodes(TrFluxoNode2.Nodes.Count - 1).Nodes(0)

                        TrMArk2.Nodes.Add(60 + (190 * 4))
                        TrMArk2.Nodes.Add(0 + DY_1)

                        'insere caracteristicas de botão

                        TrMArk2.Nodes.Add(item2.IdProcesso)
                        TrMArk2.Nodes.Add(0)
                        TrMArk2.Nodes.Add(0)
                        TrMArk2.Nodes.Add(0)
                        TrMArk2.Nodes.Add(0)

                        Dim BuscaEtapaChecklist = From ck In LqOficina.EtapasChecklist
                                                  Where ck.IdProcesso = item2.IdProcesso
                                                  Select ck.IdEtapaProcessoChecklist, ck.Titulo, ck.Posicao, ck.Tipo, ck.Descricao
                                                  Order By Posicao Ascending

                        Dim TrFluxoNode3 As TreeNode = TrFluxoNode2.Nodes(TrFluxoNode2.Nodes.Count - 1)

                        Dim DY_2 As Decimal = DY_1

                        If DY_1 > MY Then

                            MY = DY_1

                        End If

                        For Each item3 In BuscaEtapaChecklist.ToList

                            TrFluxoNode3.Nodes.Add(item3.Titulo)
                            TrFluxoNode3.Nodes(TrFluxoNode3.Nodes.Count - 1).Nodes.Add("MK")

                            Dim TrMArk3 As TreeNode = TrFluxoNode3.Nodes(TrFluxoNode3.Nodes.Count - 1).Nodes(0)

                            TrMArk3.Nodes.Add(60 + (190 * 5))
                            TrMArk3.Nodes.Add(0 + DY_2)
                            TrMArk3.Nodes.Add(item3.Tipo)

                            'insere caracteristicas de botão

                            TrMArk3.Nodes.Add(item3.IdEtapaProcessoChecklist)
                            TrMArk3.Nodes.Add(0)
                            TrMArk3.Nodes.Add(0)
                            TrMArk3.Nodes.Add(0)
                            TrMArk3.Nodes.Add(0)

                            Dim DY_3 As Decimal = DY_2

                            If DY_2 > MY Then

                                MY = DY_2

                            End If

                            Dim TrFluxoNode4 As TreeNode = TrFluxoNode3.Nodes(TrFluxoNode3.Nodes.Count - 1)

                            If item3.Tipo = 0 Then

                                Dim BuscaPerguntaChecklist = From ck In LqOficina.PerguntasChecklist
                                                             Where ck.IdEtapaProcesso = item3.IdEtapaProcessoChecklist
                                                             Select ck.IdPerguntaChecklit, ck.Titulo, ck.TipoResposta, ck.Posicao
                                                             Order By Posicao Ascending

                                For Each item4 In BuscaPerguntaChecklist.ToList

                                    TrFluxoNode4.Nodes.Add(item4.Titulo)
                                    TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1).Nodes.Add("MK")

                                    Dim TrMArk4 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1).Nodes(0)

                                    TrMArk4.Nodes.Add(60 + (190 * 6))
                                    TrMArk4.Nodes.Add(0 + DY_3)
                                    TrMArk4.Nodes.Add(item4.TipoResposta)

                                    'insere caracteristicas de botão

                                    TrMArk4.Nodes.Add(item4.IdPerguntaChecklit)
                                    TrMArk4.Nodes.Add(0)
                                    TrMArk4.Nodes.Add(0)
                                    TrMArk4.Nodes.Add(0)
                                    TrMArk4.Nodes.Add(0)

                                    'insere segundo o item

                                    If item4.TipoResposta = 1 Then

                                        Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)
                                        _camadaAbaixo.Nodes.Add("descricao inserida pelo usuário")
                                        _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes.Add("MK")

                                        Dim TrMArk5 As TreeNode = _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes(0)

                                        TrMArk5.Nodes.Add(60 + (190 * 7))
                                        TrMArk5.Nodes.Add(0 + DY_3)

                                        DY_3 += 140

                                    ElseIf item4.TipoResposta = 2 Then

                                        Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                        _camadaAbaixo.Nodes.Add("Sim")
                                        _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes.Add("MK")

                                        Dim TrMArk5 As TreeNode = _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes(0)

                                        TrMArk5.Nodes.Add(60 + (190 * 7))
                                        TrMArk5.Nodes.Add(0 + DY_3)

                                        DY_3 += 110

                                        _camadaAbaixo.Nodes.Add("Não")
                                        _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes.Add("MK")

                                        TrMArk5 = _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes(0)

                                        TrMArk5.Nodes.Add(60 + (190 * 7))
                                        TrMArk5.Nodes.Add(0 + DY_3)

                                        DY_3 += 110

                                    ElseIf item4.TipoResposta = 3 Then

                                        Dim _camadaAbaixo As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                        _camadaAbaixo.Nodes.Add("Escala")
                                        _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes.Add("MK")


                                        Dim TrMArk5 As TreeNode = _camadaAbaixo.Nodes(_camadaAbaixo.Nodes.Count - 1).Nodes(0)

                                        TrMArk5.Nodes.Add(60 + (190 * 7))
                                        TrMArk5.Nodes.Add(0 + DY_3)

                                        DY_3 += 130

                                    ElseIf item4.TipoResposta = 4 Then

                                        'busca repostas

                                        Dim BuscaResposta = From resp In LqOficina.RespostasChecklist
                                                            Where resp.IdPerguntaEtapa = item4.IdPerguntaChecklit
                                                            Select resp.descricao

                                        Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                        For Each item5 In BuscaResposta.ToList

                                            TrFluxoNode5.Nodes.Add(item5)
                                            TrFluxoNode5.Nodes(TrFluxoNode5.Nodes.Count - 1).Nodes.Add("MK")

                                            Dim TrMArk6 As TreeNode = TrFluxoNode5.Nodes(TrFluxoNode5.Nodes.Count - 1).Nodes(0)

                                            TrMArk6.Nodes.Add(60 + (190 * 6))
                                            TrMArk6.Nodes.Add(0 + DY_3)
                                            TrMArk6.Nodes.Add(item4.TipoResposta)

                                            'insere caracteristicas de botão

                                            TrMArk6.Nodes.Add("-")
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)

                                            DY_3 += 60

                                        Next

                                        DY_3 += 30

                                    ElseIf item4.TipoResposta = 5 Then

                                        'busca repostas

                                        Dim BuscaResposta = From resp In LqOficina.RespostasChecklist
                                                            Where resp.IdPerguntaEtapa = item4.IdPerguntaChecklit
                                                            Select resp.descricao

                                        Dim TrFluxoNode5 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1)

                                        For Each item5 In BuscaResposta.ToList

                                            TrFluxoNode5.Nodes.Add(item5)
                                            TrFluxoNode5.Nodes(TrFluxoNode5.Nodes.Count - 1).Nodes.Add("MK")

                                            Dim TrMArk6 As TreeNode = TrFluxoNode5.Nodes(TrFluxoNode5.Nodes.Count - 1).Nodes(0)

                                            TrMArk6.Nodes.Add(60 + (190 * 6))
                                            TrMArk6.Nodes.Add(0 + DY_3)
                                            TrMArk6.Nodes.Add(item4.TipoResposta)

                                            'insere caracteristicas de botão

                                            TrMArk6.Nodes.Add("-")
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)
                                            TrMArk6.Nodes.Add(0)

                                            DY_3 += 60

                                        Next

                                        DY_3 += 30

                                    End If

                                Next

                                If BuscaPerguntaChecklist.Count = 0 Then
                                    'adiciona a linha a suceder
                                    DY_3 += 80
                                Else
                                    DY_3 += 15
                                End If

                            Else

                                TrFluxoNode4.Nodes.Add("Informativo ao usuário")
                                TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1).Nodes.Add("MK")

                                Dim TrMArk4 As TreeNode = TrFluxoNode4.Nodes(TrFluxoNode4.Nodes.Count - 1).Nodes(0)

                                TrMArk4.Nodes.Add(60 + (190 * 6))
                                TrMArk4.Nodes.Add(0 + DY_3)
                                TrMArk4.Nodes.Add(0)
                                TrMArk4.Nodes.Add(0)
                                TrMArk4.Nodes.Add(0)
                                TrMArk4.Nodes.Add(0)
                                TrMArk4.Nodes.Add(0)
                                TrMArk4.Nodes.Add(item3.descricao)

                                DY_3 += 140


                            End If

                            DY_3 += 20

                            If DY_3 > MY Then

                                MY = DY_3

                            End If

                            DY_2 = DY_3

                        Next

                        If BuscaEtapaChecklist.Count = 0 Then
                            'adiciona a linha a suceder
                            DY_2 += 100

                        End If

                        DY_1 = DY_2

                    Next

                    If BuscaProcessoChecklist.Count = 0 Then
                        'adiciona a linha a suceder
                        DY_1 += 100

                    End If

                    DY_0 = DY_1

                Next

                If BuscaItemChecklist.Count = 0 Then
                    'adiciona a linha a suceder
                    DY_0 += 150
                Else

                    DY_0 += 15

                End If

                DY = DY_0

            Next

            DY += 20

            If BuscaChecklist.Count = 0 Then
                'adiciona a linha a suceder
                DY += 100

            End If

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes.Add("Não")
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(2).Nodes.Add("MK")

            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(2).Nodes(0).Nodes.Add(190 + 60)
            TrFluxo.Nodes(TrFluxo.Nodes.Count - 1).Nodes(2).Nodes(0).Nodes.Add(DY)

            DY += 100

            MY = DY

        Next

        TrFluxo.ExpandAll()

        'varre a lista e determina os pontos

        Dim PI_X As Integer = 0
        Dim PI_Y As Integer = 0

        For Each node0 As TreeNode In TrFluxo.Nodes

            For Each node1 As TreeNode In node0.Nodes

            Next

        Next

        V_Y = MY

        PublicaLista()


    End Sub

    Public Sub PublicaSeleçãoTEmp()

        'carrega fluxo de trabalho

        Dim Wx_btmp As Integer = Me.Width
        Dim Wy_btmp As Integer = Me.Height

        'desenha form

        Dim _C As Integer = 0
        Dim Pausa As Integer = 0

        Dim PintarBitmap = New Bitmap(190 * 10, 120 + V_Y)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        'varre e pinta

        'pinta fundo
        'varre o treeview

        Dim P0 As New Pen(New SolidBrush(Color.SlateGray), 2)

        P0.DashStyle = Drawing2D.DashStyle.Dot

        Dim Yg1_0 As Decimal
        Dim Xg1_0 As Decimal

        For Each item As TreeNode In TrFluxo.Nodes

            For Each item1 As TreeNode In item.Nodes(1).Nodes

                If item1.Index = 0 Then

                    Dim X2 As Decimal
                    Dim Y2 As Decimal

                    X2 = item.Nodes(1).Nodes(0).Nodes(2).Text
                    Y2 = item.Nodes(1).Nodes(0).Nodes(3).Text

                    If X2 > 0 And Y2 > 0 Then

                        If MouseX >= X2 And MouseX <= X2 + 20 Then
                            If MouseY >= Y2 And MouseY <= Y2 + 20 Then
                                'abre o form de checklist

                                FrmNovoCadCheckList.NivelReq = item.Index

                                If Application.OpenForms.OfType(Of FrmNovoCadCheckList)().Count() = 0 Then
                                    FrmNovoCadCheckList.Show(Me)
                                End If

                            End If

                        End If

                    End If

                    Dim X3 As Decimal
                    Dim Y3 As Decimal

                    X3 = item.Nodes(1).Nodes(0).Nodes(4).Text
                    Y3 = item.Nodes(1).Nodes(0).Nodes(5).Text

                    If X3 > 0 And Y3 > 0 Then

                        If MouseX >= X3 And MouseX <= X3 + 50 Then
                            If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                FrmNovoCadCheckList.NivelReq = item.Index

                                If Application.OpenForms.OfType(Of FrmNovoCadCheckList)().Count() = 0 Then
                                    FrmNovoCadCheckList.Show(Me)
                                End If

                            End If
                        End If

                    End If

                ElseIf item1.Index > 0 Then

                    For Each item2 As TreeNode In item1.Nodes

                        'verifica botões checlist

                        If item2.Index = 0 Then

                            Dim X2 As Decimal
                            Dim Y2 As Decimal

                            X2 = item2.Nodes(3).Text
                            Y2 = item2.Nodes(4).Text

                            If MouseX >= X2 And MouseX <= X2 + 20 Then
                                If MouseY >= Y2 And MouseY <= Y2 + 20 Then

                                    FrmCadastroDeCategoriaChecklist._IdChecklist = item2.Nodes(2).Text

                                    If Application.OpenForms.OfType(Of FrmCadastroDeCategoriaChecklist)().Count() = 0 Then
                                        FrmCadastroDeCategoriaChecklist.Show(Me)
                                    End If

                                End If
                            End If

                            Dim X3 As Decimal
                            Dim Y3 As Decimal

                            X3 = item2.Nodes(5).Text
                            Y3 = item2.Nodes(6).Text

                            If X3 > 0 And Y3 > 0 Then

                                If MouseX >= X3 And MouseX <= X3 + 50 Then
                                    If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                        FrmCadastroDeCategoriaChecklist._IdChecklist = item2.Nodes(2).Text

                                        If Application.OpenForms.OfType(Of FrmCadastroDeCategoriaChecklist)().Count() = 0 Then
                                            FrmCadastroDeCategoriaChecklist.Show(Me)
                                        End If

                                    End If
                                End If

                            End If

                        Else

                            For Each item3 As TreeNode In item2.Nodes

                                'verifica botões checlist

                                If item3.Index = 0 Then

                                    Dim X2 As Decimal
                                    Dim Y2 As Decimal

                                    X2 = item3.Nodes(3).Text
                                    Y2 = item3.Nodes(4).Text

                                    If MouseX >= X2 And MouseX <= X2 + 20 Then
                                        If MouseY >= Y2 And MouseY <= Y2 + 20 Then

                                            FrmNovoProcessohecklist._IdChecklist = item3.Nodes(2).Text

                                            If Application.OpenForms.OfType(Of FrmNovoProcessohecklist)().Count() = 0 Then
                                                FrmNovoProcessohecklist.Show(Me)
                                            End If

                                        End If
                                    End If

                                    Dim X3 As Decimal
                                    Dim Y3 As Decimal

                                    X3 = item3.Nodes(5).Text
                                    Y3 = item3.Nodes(6).Text

                                    If X3 > 0 And Y3 > 0 Then

                                        If MouseX >= X3 And MouseX <= X3 + 50 Then
                                            If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                                FrmNovoProcessohecklist._IdChecklist = item3.Nodes(2).Text

                                                If Application.OpenForms.OfType(Of FrmNovoProcessohecklist)().Count() = 0 Then
                                                    FrmNovoProcessohecklist.Show(Me)
                                                End If

                                            End If
                                        End If

                                    End If

                                Else

                                    For Each item4 As TreeNode In item3.Nodes

                                        'verifica botões checlist

                                        If item4.Index = 0 Then

                                            Dim X2 As Decimal
                                            Dim Y2 As Decimal

                                            X2 = item4.Nodes(3).Text
                                            Y2 = item4.Nodes(4).Text

                                            If MouseX >= X2 And MouseX <= X2 + 20 Then
                                                If MouseY >= Y2 And MouseY <= Y2 + 20 Then

                                                    FrmNovaEtapaChecklist._IdChecklist = item4.Nodes(2).Text

                                                    If Application.OpenForms.OfType(Of FrmNovaEtapaChecklist)().Count() = 0 Then
                                                        FrmNovaEtapaChecklist.Show(Me)
                                                    End If

                                                End If
                                            End If

                                            'pinta se houver

                                            Dim X3 As Decimal
                                            Dim Y3 As Decimal

                                            X3 = item4.Nodes(5).Text
                                            Y3 = item4.Nodes(6).Text

                                            If MouseX >= X3 And MouseX <= X3 + 50 Then
                                                If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                                    FrmNovaEtapaChecklist._IdChecklist = item4.Nodes(2).Text

                                                    If Application.OpenForms.OfType(Of FrmNovaEtapaChecklist)().Count() = 0 Then
                                                        FrmNovaEtapaChecklist.Show(Me)
                                                    End If

                                                End If
                                            End If

                                        Else

                                            For Each item5 As TreeNode In item4.Nodes

                                                'verifica botões checlist

                                                If item5.Index = 0 Then

                                                    Dim X2 As Decimal
                                                    Dim Y2 As Decimal

                                                    X2 = item5.Nodes(4).Text
                                                    Y2 = item5.Nodes(5).Text

                                                    If MouseX >= X2 And MouseX <= X2 + 20 Then
                                                        If MouseY >= Y2 And MouseY <= Y2 + 20 Then

                                                            FrmPerguntaCheklist._IdChecklist = item5.Nodes(3).Text

                                                            If Application.OpenForms.OfType(Of FrmPerguntaCheklist)().Count() = 0 Then
                                                                FrmPerguntaCheklist.Show(Me)
                                                            End If

                                                        End If
                                                    End If

                                                    'pinta se houver

                                                    Dim X3 As Decimal
                                                    Dim Y3 As Decimal

                                                    X3 = item5.Nodes(6).Text
                                                    Y3 = item5.Nodes(7).Text

                                                    If MouseX >= X3 And MouseX <= X3 + 50 Then
                                                        If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                                            FrmPerguntaCheklist._IdChecklist = item5.Nodes(3).Text

                                                            If Application.OpenForms.OfType(Of FrmPerguntaCheklist)().Count() = 0 Then
                                                                FrmPerguntaCheklist.Show(Me)
                                                            End If


                                                        End If
                                                    End If

                                                Else

                                                    For Each item6 As TreeNode In item5.Nodes

                                                        'verifica botões checlist

                                                        If item6.Index = 0 Then

                                                            Try

                                                                Dim X2 As Decimal
                                                                Dim Y2 As Decimal

                                                                X2 = item6.Nodes(4).Text
                                                                Y2 = item6.Nodes(5).Text

                                                                If MouseX >= X2 And MouseX <= X2 + 20 Then
                                                                    If MouseY >= Y2 And MouseY <= Y2 + 20 Then

                                                                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Red), 2), X2, Y2, 20, 20)

                                                                    End If
                                                                End If

                                                                'pinta se houver

                                                                Dim X3 As Decimal
                                                                Dim Y3 As Decimal

                                                                X3 = item6.Nodes(6).Text
                                                                Y3 = item6.Nodes(7).Text

                                                                If MouseX >= X3 And MouseX <= X3 + 50 Then
                                                                    If MouseY >= Y3 And MouseY <= Y3 + 50 Then

                                                                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Red), 2), X3, Y3, 50, 50)

                                                                    End If

                                                                End If


                                                            Catch ex As Exception

                                                            End Try

                                                        End If

                                                    Next

                                                End If

                                            Next

                                        End If

                                    Next

                                End If

                            Next

                        End If

                    Next

                End If

            Next

        Next


        PicFluxo.Image = PintarBitmap

    End Sub
    Public Sub PublicaLista()

        'carrega fluxo de trabalho

        Dim Wx_btmp As Integer = Me.Width
        Dim Wy_btmp As Integer = Me.Height

        'desenha form

        Dim _C As Integer = 0
        Dim Pausa As Integer = 0

        Dim PintarBitmap = New Bitmap(190 * 10, 120 + V_Y)

        PicFluxo.Size = New Size(PintarBitmap.Size.Width, PintarBitmap.Size.Height)
        PicFluxo.BorderStyle = BorderStyle.FixedSingle

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        'pinta fundo

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.LightSlateGray)), 0, 0, 400, PintarBitmap.Size.Height)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.DarkGoldenrod)), 400, 0, PintarBitmap.Size.Width - 400, PintarBitmap.Size.Height)

        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.LightSlateGray)), 10, 20, PintarBitmap.Size.Width - 40, 40)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.LightSlateGray)), 10, 60, PintarBitmap.Size.Width - 40, PintarBitmap.Size.Height - 40)

        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 60 + 190, 20, 60 + 190, PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 2), 20, 40 + (190 * 2), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 3), 20, 40 + (190 * 3), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 4), 20, 40 + (190 * 4), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 5), 20, 40 + (190 * 5), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 6), 20, 40 + (190 * 6), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 40 + (190 * 7), 20, 40 + (190 * 7), PintarBitmap.Size.Height - 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 10, 20, PintarBitmap.Size.Width - 10, 20)
        Pintura.DrawLine(New Pen(New SolidBrush(Color.FromArgb(50, Color.White)), 1), 10, 60, PintarBitmap.Size.Width - 10, 60)

        Pintura.DrawString("Inicio do processo", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40, 30)
        Pintura.DrawString("Cheklist", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 2) + 10, 30)
        Pintura.DrawString("Categorias", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 3) + 10, 30)
        Pintura.DrawString("Processos", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 4) + 10, 30)
        Pintura.DrawString("Etapas", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 5) + 10, 30)
        Pintura.DrawString("Perguntas", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 6) + 10, 30)
        Pintura.DrawString("Respostas", New Font("Calibri", 12.25), New SolidBrush(Color.WhiteSmoke), 40 + (190 * 7) + 10, 30)

        'varre o treeview

        Dim P0 As New Pen(New SolidBrush(Color.SlateGray), 2)

        P0.DashStyle = Drawing2D.DashStyle.Dot

        Dim Yg1_0 As Decimal
        Dim Xg1_0 As Decimal

        Dim Pdefin As New Pen(New SolidBrush(Color.SlateGray), 1)

        Pdefin.DashStyle = Drawing2D.DashStyle.Dot

        Dim YFimMk As Decimal

        For Each item As TreeNode In TrFluxo.Nodes

            Dim X As Decimal = item.Nodes(0).Nodes(0).Text
            Dim Y As Decimal = item.Nodes(0).Nodes(1).Text

            'topo da lista

            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X + 5, Y, 140, 40)

            Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X, Y, 150, 30)

            Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X, Y + 40, 150, 5)

            Pintura.DrawString(item.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), X + 5, Y + 10)

            If item.Index > 1 Then

                'Pintura.DrawLine(P0, X - 20, Y + 25, X - 20, YFimMk + 65)

            End If

            'desenha linha inicial

            Pintura.DrawLine(P0, X + 150, Y + 25, X + 150 + 20, Y + 25)
            Pintura.DrawLine(P0, X - 20, Y + 25, X, Y + 25)

            Dim Yg1_1 As Decimal
            Dim Xg1_1 As Decimal

            For Each item1 As TreeNode In item.Nodes(1).Nodes

                If item1.Index = 0 Then

                    'marca desenho form

                    Dim X1 As Decimal = item1.Nodes(0).Text
                    Dim Y1 As Decimal = item1.Nodes(1).Text

                    Pintura.FillEllipse(New SolidBrush(Color.DarkGoldenrod), X1 + 53, Y1 - 2, 55, 55)
                    Pintura.FillEllipse(New SolidBrush(Color.LightSlateGray), X1 + 58, Y1 + 3, 45, 45)
                    Dim Retangulo As New Rectangle(X1 + 70, Y1 + 19, 45, 15)

                    Pintura.DrawString("Sim", New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                    'desenha linha inicial

                    Pintura.DrawLine(Pdefin, X1 + 53 + 55, Y1 + 25, X1 + 150 + 20, Y1 + 25)
                    Pintura.DrawLine(Pdefin, X1 - 20, Y1 + 25, X1 + 53, Y1 + 25)
                    Pintura.DrawLine(Pdefin, X1 - 20, Y + 25, X1 - 20, Y1 + 25)

                    'desenha indicador

                    Dim Pt1 As New Point(X1 + 53, Y1 + 25)
                    Dim Pt2 As New Point(X1 + (53 - 7), Y1 + (25 - 7))
                    Dim Pt3 As New Point(X1 + (53 - 7), Y1 + 25 + 7)

                    Dim Points() As Point = {Pt1, Pt2, Pt3}

                    Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                    Yg1_1 = Y + 25
                    Xg1_1 = X1 + ((150 + 20) + 53 + 20)

                Else

                    'desenha sim

                    Dim Yg2 As Decimal
                    Dim Xg2 As Decimal

                    For Each item2 As TreeNode In item1.Nodes

                        If item2.Index = 0 Then

                            Dim X2 As Decimal = item2.Nodes(0).Text
                            Dim Y2 As Decimal = item2.Nodes(1).Text

                            Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X2, Y2, 150, 50)
                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X2, Y2, 10, 50)
                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X2 + 140, Y2, 10, 50)
                            Dim Retangulo As New Rectangle(X2 + 12, Y2 + 10, 125, 30)
                            Pintura.DrawString(item1.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                            'desenha linha inicial

                            Dim P1 As New Pen(New SolidBrush(Color.Red), 1)
                            P1.DashStyle = Drawing2D.DashStyle.Dot

                            If item1.Nodes.Count = 1 Then

                                Pintura.DrawImage(My.Resources.add_1_icon, X2 + 170 + 70, Y2, 50, 50)

                                item1.Nodes(0).Nodes(5).Text = X2 + 170 + 70
                                item1.Nodes(0).Nodes(6).Text = Y2

                                Pintura.DrawLine(P0, X2 + 150, Y2 + 25, X2 + 150 + 20, Y2 + 25)
                                Pintura.DrawLine(P0, X2 - 20, Y2 + 25, X2, Y2 + 25)

                                'desenha indicador

                                If item1.Index > 1 Then

                                    Pintura.DrawLine(P0, X2 - 20, Y2 + 25, X2 - 20, Yg2 + 65)

                                End If

                                Dim Pt1 As New Point(X2, Y2 + 25)
                                Dim Pt2 As New Point(X2 - 7, Y2 + (25 - 7))
                                Dim Pt3 As New Point(X2 - 7, Y2 + 25 + 7)

                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                Yg2 = Y2 + 25
                                Xg2 = X2

                                'veriica proximo item

                                Pintura.DrawLine(P0, X2 + (170) + 95, Y2 + 50, X2 + (170) + 95, Y2 + 90)
                                Pintura.DrawLine(P0, X2 - 20, Y2 + 90, X2 + (170) + 95, Y2 + 90)

                                'desenha indicador

                                Dim Pt4 As New Point(X2 + (170) + 70, Y2 + 25)
                                Dim Pt5 As New Point(X2 + (170) + 70 - 7, Y2 + (25 - 7))
                                Dim Pt6 As New Point(X2 + (170) + 70 - 7, Y2 + 25 + 7)

                                Dim Points1() As Point = {Pt4, Pt5, Pt6}

                                Pintura.DrawLine(P0, X2 + 170, Y2 + 25, X2 + (170) + 70, Y2 + 25)

                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points1)

                                'verifica se é o ultimo da lista

                                If item1.Index = item.Nodes(1).Nodes.Count - 1 Then

                                    'desenha botão de nova etapa

                                    'desnha linhas

                                    Pintura.DrawLine(P0, X2 - 20, Y2 + 90, X + 180, Y2 + 90)

                                    Pintura.DrawLine(P0, X, Y2 + 90, X, Y2 + 90)

                                    Pintura.DrawLine(P0, X + 85, Y2 + 90, X + 160, Y2 + 90)

                                    Pintura.DrawLine(P0, X - 20, Y2 + 90, X + 65, Y2 + 90)

                                    Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(80, Color.SlateGray)), 2), X + 65, Y2 + 80, 20, 20, 180, 45 * 4)

                                    Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(80, Color.SlateGray)), 2), X + 160, Y2 + 80, 20, 20, 180, 45 * 4)

                                    'y

                                    'Pintura.DrawLine(P1, X - 20, Yg5 + 30, X - 20, Yg5 + 30 + 120)

                                Else


                                End If


                            Else

                                Pintura.DrawLine(P0, X2 + 150, Y2 + 25, X2 + 150 + 20, Y2 + 25)
                                Pintura.DrawLine(P0, X2 - 20, Y2 + 25, X2, Y2 + 25)

                                If item1.Index > 1 Then

                                    Pintura.DrawLine(P0, X2 - 20, Y2 + 25, X2 - 20, Yg2 + 25)

                                End If

                                'desenha indicador

                                Dim Pt1 As New Point(X2, Y2 + 25)
                                Dim Pt2 As New Point(X2 - 7, Y2 + (25 - 7))
                                Dim Pt3 As New Point(X2 - 7, Y2 + 25 + 7)

                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                Yg2 = Y2 + 25
                                Xg2 = X2

                            End If

                        Else

                            Dim Yg3 As Integer
                            Dim Xg3 As Integer

                            For Each item3 As TreeNode In item2.Nodes

                                If item3.Index = 0 Then

                                    Dim X3 As Decimal = item3.Nodes(0).Text
                                    Dim Y3 As Decimal = item3.Nodes(1).Text

                                    Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 50)
                                    Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 50)
                                    Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 50)
                                    Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 30)
                                    Pintura.DrawString(item2.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                    'desenha linha inicial

                                    Dim P1 As New Pen(New SolidBrush(Color.Red), 1)
                                    P1.DashStyle = Drawing2D.DashStyle.Dot

                                    Dim Pt As New Pen(New SolidBrush(Color.Green), 2)
                                    Pt.DashStyle = Drawing2D.DashStyle.Dot

                                    If item2.Nodes.Count = 1 Then

                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                        Pintura.DrawImage(My.Resources.add_1_icon, X3 + 170 + 70, Y3, 50, 50)

                                        item2.Nodes(0).Nodes(5).Text = X3 + 170 + 70
                                        item2.Nodes(0).Nodes(6).Text = Y3

                                        If item2.Index > 1 Then

                                            Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Yg3 + 65)

                                        End If

                                        'desenha indicador

                                        Dim Pt1 As New Point(X3, Y3 + 25)
                                        Dim Pt2 As New Point(X3 - 7, Y3 + (25 - 7))
                                        Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                        Yg3 = Y3 + 25
                                        Xg3 = X3

                                        'veriica proximo item

                                        Pintura.DrawLine(P0, X3 + (170) + 95, Y3 + 50, X3 + (170) + 95, Y3 + 90)
                                        Pintura.DrawLine(P0, X3 + 170, Y3 + 90, X3 + (170) + 95, Y3 + 90)

                                        'desenha indicador

                                        Dim Pt4 As New Point(X3 + (170) + 70, Y3 + 25)
                                        Dim Pt5 As New Point(X3 + (170) + 70 - 7, Y3 + (25 - 7))
                                        Dim Pt6 As New Point(X3 + (170) + 70 - 7, Y3 + 25 + 7)

                                        Dim Points1() As Point = {Pt4, Pt5, Pt6}

                                        Pintura.DrawLine(P0, X3 + 170, Y3 + 25, X3 + (170) + 70, Y3 + 25)

                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points1)

                                        If item3.Index = item2.Nodes.Count - 1 Then

                                            Pintura.DrawLine(P0, Xg3 - 20, Y3 + 90, X3 + 170, Y3 + 90)

                                            If item2.Index = item1.Nodes.Count - 1 Then

                                                Pintura.DrawLine(P0, Xg2 - 20, Y3 + 90, Xg3 - 20, Y3 + 90)

                                                If item1.Index = item.Nodes(1).Nodes.Count - 1 Then

                                                    Pintura.DrawLine(P0, X - 20, Y3 + 90, Xg2 - 20, Y3 + 90)

                                                End If

                                            End If

                                        End If

                                    Else

                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                        If item2.Index > 1 Then

                                            Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Yg3 + 65)

                                        End If

                                        'desenha indicador

                                        Dim Pt1 As New Point(X3, Y3 + 25)
                                        Dim Pt2 As New Point(X3 - 7, Y3 + (25 - 7))
                                        Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                        Yg3 = Y3 + 25
                                        Xg3 = X3

                                    End If

                                Else

                                    Dim Yg4 As Integer
                                    Dim Xg4 As Integer

                                    For Each item4 As TreeNode In item3.Nodes

                                        If item4.Index = 0 Then

                                            Dim X3 As Decimal = item4.Nodes(0).Text
                                            Dim Y3 As Decimal = item4.Nodes(1).Text

                                            Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 50)
                                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 50)
                                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 50)
                                            Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 30)
                                            Pintura.DrawString(item3.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                            Dim P1 As New Pen(New SolidBrush(Color.Red), 1)
                                            P1.DashStyle = Drawing2D.DashStyle.Dot

                                            If item3.Nodes.Count = 1 Then

                                                Pintura.DrawLine(P0, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                                Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                                Pintura.DrawImage(My.Resources.add_1_icon, X3 + 170 + 70, Y3, 50, 50)

                                                item3.Nodes(0).Nodes(5).Text = X3 + 170 + 70
                                                item3.Nodes(0).Nodes(6).Text = Y3

                                                'Pintura.DrawLine(P1, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                                'Pintura.DrawLine(P1, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                                If item3.Index > 1 Then

                                                    Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Yg3)

                                                End If

                                                'desenha indicador

                                                Dim Pt1 As New Point(X3, Y3 + 25)
                                                Dim Pt2 As New Point(X3 - 7, Y3 + (25 - 7))
                                                Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                Yg4 = Y3 + 25
                                                Xg4 = X3

                                                'veriica proximo item

                                                Pintura.DrawLine(P0, X3 + (170) + 95, Y3 + 50, X3 + (170) + 95, Y3 + 90)

                                                'desenha indicador

                                                Dim Pt4 As New Point(X3 + (170) + 70, Y3 + 25)
                                                Dim Pt5 As New Point(X3 + (170) + 70 - 7, Y3 + (25 - 7))
                                                Dim Pt6 As New Point(X3 + (170) + 70 - 7, Y3 + 25 + 7)

                                                Dim Points1() As Point = {Pt4, Pt5, Pt6}

                                                Pintura.DrawLine(P0, X3 + 170, Y3 + 25, X3 + (170) + 70, Y3 + 25)

                                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points1)

                                                If item4.Index = item3.Nodes.Count - 1 Then

                                                    Pintura.DrawLine(P0, Xg4 - 20, Y3 + 90, X3 + 170 + 95, Y3 + 90)

                                                    If item3.Index = item2.Nodes.Count - 1 Then

                                                        Pintura.DrawLine(P0, Xg3 - 20, Y3 + 90, Xg4 - 20, Y3 + 90)

                                                        If item2.Index = item1.Nodes.Count - 1 Then

                                                            Pintura.DrawLine(P0, Xg2 - 20, Y3 + 90, Xg3 - 20, Y3 + 90)

                                                            If item1.Index = item.Nodes(1).Nodes.Count - 1 Then

                                                                Pintura.DrawLine(P0, X - 20, Y3 + 90, Xg2 - 20, Y3 + 90)

                                                            End If

                                                        End If

                                                    End If

                                                End If

                                            Else

                                                Pintura.DrawLine(Pdefin, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                                Pintura.DrawLine(Pdefin, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                                If item3.Index > 1 Then

                                                    Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Yg3 + 65)

                                                End If

                                                'desenha indicador

                                                Dim Pt1 As New Point(X3, Y3 + 25)
                                                Dim Pt2 As New Point(X3 - 7, Y3 + (25 - 7))
                                                Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                Yg4 = Y3 + 25
                                                Xg4 = X3

                                            End If

                                        Else

                                            Dim Yg5 As Integer
                                            Dim Xg5 As Integer

                                            Dim Tipo As Integer

                                            Dim PintaAdd As Boolean = False

                                            For Each item5 As TreeNode In item4.Nodes

                                                If item5.Index = 0 Then

                                                    Dim X3 As Decimal = item5.Nodes(0).Text
                                                    Dim Y3 As Decimal = item5.Nodes(1).Text
                                                    Tipo = item5.Nodes(2).Text

                                                    'Tipo = item5.Nodes(2).Text

                                                    Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 50)
                                                    Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 50)
                                                    Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 50)
                                                    Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 50)
                                                    Pintura.DrawString(item4.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                    Pintura.DrawLine(Pdefin, X3 + 150, Y3 + 25, X3 + 150 + 20, Y3 + 25)
                                                    Pintura.DrawLine(Pdefin, X3 - 20, Y3 + 25, X3, Y3 + 25)

                                                    If item4.Index = 1 Then

                                                        Pintura.DrawLine(P0, X3 - 20, Yg4, X3 - 20, Y3 + 25)

                                                    Else

                                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Yg5 + 25)

                                                    End If

                                                    'desenha indicador

                                                    Dim Pt1 As New Point(X3, Y3 + 25)
                                                    Dim Pt2 As New Point(X3 - 7, Y3 + (25 - 7))
                                                    Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                                    Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                    Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                    Yg5 = Y3 + 25
                                                    Xg5 = X3

                                                Else

                                                    Dim AddRotaX As Integer = 1

                                                    Dim Yg6 As Decimal
                                                    Dim Xg6 As Decimal

                                                    Dim YgGuarda As Decimal

                                                    For Each item6 As TreeNode In item5.Nodes

                                                        If item6.Index = 0 Then

                                                            Dim X3 As Decimal = item6.Nodes(0).Text
                                                            Dim Y3 As Decimal = item6.Nodes(1).Text

                                                            Dim YAnterior As Decimal

                                                            Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 90)
                                                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 90)
                                                            Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 90)
                                                            Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 70)
                                                            Pintura.DrawString(item5.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)
                                                            Pintura.DrawLine(P0, X3 + 150, Y3 + 45, X3 + 150 + 20, Y3 + 45)
                                                            Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3, Y3 + 45)

                                                            If item5.Index = 1 Then

                                                                Pintura.DrawLine(P0, X3 - 20, Yg5, X3 - 20, Y3 + 45)

                                                            Else

                                                                Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3 - 20, Yg6 + 25)

                                                            End If

                                                            'desenha indicador

                                                            Dim Pt1 As New Point(X3, Y3 + 45)
                                                            Dim Pt2 As New Point(X3 - 7, Y3 + (45 - 7))
                                                            Dim Pt3 As New Point(X3 - 7, Y3 + 45 + 7)

                                                            Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                            Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                            Yg6 = Y3 + 45
                                                            Xg6 = X3

                                                            YgGuarda = Y3 + 45

                                                            'manda informaçao do informativo

                                                            If Tipo = -1 Then

                                                                Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3 + 190, Y3, 150, 90)
                                                                Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 190, Y3, 10, 90)
                                                                Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 190 + 140, Y3, 10, 90)
                                                                Retangulo = New Rectangle(X3 + 12, Y3 + 10, 125, 70)
                                                                Pintura.DrawString(item5.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                Pintura.DrawLine(P0, X3 + 170, Y3 + 45, X3 + 190, Y3 + 45)
                                                                Pintura.DrawLine(P0, X3 + 190 + 150, Y3 + 45, X3 + 190 + 150 + 20, Y3 + 45)
                                                                Pintura.DrawLine(P0, X3 + 190 + 150 + 20, Y3 + 45, X3 + 190 + 150 + 20, Y3 + 110)
                                                                Pintura.DrawLine(P0, X3 - 20, Y3 + 110, X3 + 190 + 150 + 20, Y3 + 110)

                                                                'Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3, Y3 + 45)

                                                                'desenha indicador

                                                                Pt1 = New Point(X3 + 190, Y3 + 45)
                                                                Pt2 = New Point(X3 + 190 - 7, Y3 + (45 - 7))
                                                                Pt3 = New Point(X3 + 190 - 7, Y3 + 45 + 7)

                                                                Points = {Pt1, Pt2, Pt3}

                                                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                                If item5.Index = item4.Nodes.Count - 1 Then

                                                                    Pintura.DrawLine(P0, Xg5 - 20, Y3 + 110, Xg6 - 20, Y3 + 110)

                                                                    If item4.Index = item3.Nodes.Count - 1 Then

                                                                        Pintura.DrawLine(P0, Xg4 - 20, Y3 + 110, Xg5 - 20, Y3 + 110)

                                                                        If item3.Index = item2.Nodes.Count - 1 Then

                                                                            Pintura.DrawLine(P0, Xg3 - 20, Y3 + 110, Xg4 - 20, Y3 + 110)

                                                                            If item2.Index = item1.Nodes.Count - 1 Then

                                                                                Pintura.DrawLine(P0, Xg2 - 20, Y3 + 110, Xg3 - 20, Y3 + 110)

                                                                                If item1.Index = item.Nodes(1).Nodes.Count - 1 Then

                                                                                    Pintura.DrawLine(P0, X - 20, Y3 + 110, Xg2 - 20, Y3 + 110)

                                                                                End If

                                                                            End If

                                                                        End If

                                                                    End If

                                                                End If

                                                            Else

                                                                If item6.Index = item5.Nodes.Count - 1 Then

                                                                    Dim NewX2 As Integer = Xg6 + (150 / 2)
                                                                    'pinta botao
                                                                    Pintura.DrawImage(My.Resources.add_1_icon, NewX2 - 10, Yg6 + 35 + 20, 20, 20)

                                                                    Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX2 - 5, Yg6 + 25 + 20, 8, 8, -90, 45 * 4)

                                                                    'insere informaçao do botão
                                                                    item5.Nodes(0).Nodes(3).Text = NewX2 - 10
                                                                    item5.Nodes(0).Nodes(4).Text = Yg6 + 35 + 20

                                                                End If

                                                            End If

                                                        Else

                                                            For Each item7 As TreeNode In item6.Nodes

                                                                Dim Yg7 As Integer
                                                                Dim Xg7 As Integer

                                                                If item7.Index = 0 Then

                                                                    Dim X3 As Decimal = item7.Nodes(0).Text
                                                                    Dim Y3 As Decimal = item7.Nodes(1).Text

                                                                    'verifica qual o item

                                                                    If item5.Nodes(0).Nodes(2).Text = 1 Then
                                                                        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 90)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 90)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 90)
                                                                        Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 70)
                                                                        Pintura.DrawString(item6.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 45, X3 + 150 + 20, Y3 + 45)
                                                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3, Y3 + 45)
                                                                        Pintura.DrawLine(P0, X3 - 20, Yg6, X3 - 20, Y3 + 45)

                                                                        'desenha linha inicial de saida

                                                                        Dim X_Final As Integer = X3 + 130

                                                                        Pintura.DrawLine(P0, X3 - 20 - 190, Y3 + 45 + 80, X3 + 150 + 20, Y3 + 45 + 80)
                                                                        Pintura.DrawLine(P0, X3 + 150 + 20, Y3 + 45, X3 + 150 + 20, Y3 + 45 + 80)

                                                                        'insere verificação da lista suspensa anterior

                                                                        If item5.Index < item4.Nodes.Count - 1 Then
                                                                            'Pintura.DrawLine(Pdefin, X3 - 20 - 190, Y3 + 45 + 55 + 55, X3 - 20 - 190, Y3 + 45 + 55)
                                                                        End If

                                                                        Yg7 = Y3 + 100
                                                                        Xg7 = X3

                                                                    ElseIf item5.Nodes(0).Nodes(2).Text = 2 Then

                                                                        Pintura.FillEllipse(New SolidBrush(Color.DarkGoldenrod), (X3 + 53) - 12, Y3 + 22 - 2, 55, 55)
                                                                        Pintura.FillEllipse(New SolidBrush(Color.LightSlateGray), (X3 + 58) - 12, (Y3 + 22) + 3, 45, 45)
                                                                        Dim Retangulo As New Rectangle((X3 + 58), Y3 + 40, 45, 45)
                                                                        Pintura.DrawString(item6.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3 + 53 - 10, Y3 + 45)

                                                                        'desenha indicador

                                                                        Dim Pt1 As New Point(X3 + 43, Y3 + 45)
                                                                        Dim Pt2 As New Point(X3 + 43 - 7, Y3 + 45 - 7)
                                                                        Dim Pt3 As New Point(X3 + 43 - 7, Y3 + 45 + 7)

                                                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                                        Yg7 = Y3 + 80

                                                                        If AddRotaX = 1 Then

                                                                            Dim X_Final As Integer = X3 + 170

                                                                            Pintura.DrawLine(P0, X3 + 53 + 43, Y3 + 45, X_Final, Y3 + 45)

                                                                            Pintura.DrawLine(P0, X_Final, Y3 + 45, X_Final, Y3 + 45 + 80)

                                                                            Pintura.DrawLine(P0, X3 - 10, Y3 + 45 + 80, X_Final, Y3 + 45 + 80)
                                                                            Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), X3 - 30, Y3 + 45 + 80 - 10, 20, 20, 180, 45 * 4)
                                                                            Pintura.DrawLine(P0, Xg6 - 20, Y3 + 45 + 80, X3 - 30, Y3 + 45 + 80)

                                                                            Pintura.DrawLine(P0, Xg6 - 20, Y3 + 45 + 80, Xg6 - 20, Y3 + 45 + 65 + 80)

                                                                            Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), Xg6 - 25, Y3 + 45 + 65 + 75, 20, 20, 45 * 5, 45 * 5)

                                                                            Pintura.DrawLine(P0, Xg6 - 15, Y3 + 45 + 65 + 80 + 15, Xg6, Y3 + 45 + 65 + 80 + 30)

                                                                            'desenha indicador

                                                                            Dim Pt1_1 As New Point(Xg6, Y3 + 45 + 65 + 80 + 30)
                                                                            Dim Pt2_1 As New Point(Xg6 - 7, Y3 + 45 + 65 + 80 + 30)
                                                                            Dim Pt3_1 As New Point(Xg6, Y3 + 45 + 65 + 80 + 30 - 7)

                                                                            Dim Points_1() As Point = {Pt1_1, Pt2_1, Pt3_1}

                                                                            Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points_1)

                                                                            AddRotaX = 2

                                                                        ElseIf AddRotaX = 2 Then

                                                                            Dim X_Final As Integer = X3 + 170

                                                                            Pintura.DrawLine(P0, X3 - 20, Yg6 - 30, X3 - 20, Y3 + 45)

                                                                            Pintura.DrawLine(P0, X3 + 53 + 43, Y3 + 40, X_Final, Y3 + 40)

                                                                            Pintura.DrawLine(P0, X_Final, Y3 + 40, X_Final, Y3 + 40 + 45)
                                                                            Pintura.DrawLine(P0, Xg6 - 20, Y3 + 40 + 45, X_Final, Y3 + 40 + 45)

                                                                            Pintura.DrawLine(P0, Xg6 - 20, Y3 + 40 + 45, Xg6 - 20, Y3 + 40 + 45 + 70)

                                                                            AddRotaX = 1

                                                                        End If

                                                                    ElseIf item5.Nodes(0).Nodes(2).Text = 3 Then

                                                                        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3 + 20, 150, 10)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3 + 30, 150, 30)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3 + 60, 150, 10)
                                                                        Dim Retangulo As New Rectangle(X3 + 42, Y3 + 38, 125, 70)
                                                                        Pintura.DrawString(item6.Text & " 0-10", New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 45, X3 + 150 + 20, Y3 + 45)
                                                                        Pintura.DrawLine(P0, X3 - 20, Y3 + 45, X3, Y3 + 45)
                                                                        Pintura.DrawLine(P0, X3 - 20, Yg6, X3 - 20, Y3 + 45)

                                                                        'desenha linha inicial de saida

                                                                        Dim X_Final As Integer = X3 + 130

                                                                        Pintura.DrawLine(P0, X3 - 20 - 190, Y3 + 45 + 75, X3 + 150 + 20, Y3 + 45 + 75)
                                                                        Pintura.DrawLine(P0, X3 + 150 + 20, Y3 + 45, X3 + 150 + 20, Y3 + 45 + 75)

                                                                        Dim Pt1 As New Point(X3, Y3 + 45)
                                                                        Dim Pt2 As New Point(X3 - 7, Y3 + 45 - 7)
                                                                        Dim Pt3 As New Point(X3 - 7, Y3 + 45 + 7)

                                                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                                        'insere verificação da lista suspensa anterior

                                                                        If item5.Index < item4.Nodes.Count - 1 Then

                                                                            Pintura.DrawLine(Pdefin, X3 - 20 - 190, Y3 + 45 + 55 + 50, X3 - 20 - 190, Y3 + 45 + 50)

                                                                        Else

                                                                            Pintura.DrawLine(Pdefin, X3 - 20 - (190) * 2, Y3 + 45 + 50, X3 - 20 - 190, Y3 + 45 + 50)

                                                                            'verifica se o item anterior e o ultimo da lista - se sim conecta a o nivel acima

                                                                            If item4.Index < item3.Nodes.Count - 1 Then

                                                                                Pintura.DrawLine(Pdefin, X3 - 20 - (190) * 2, Y3 + 45 + 55 + 50, X3 - 20 - (190) * 2, Y3 + 45 + 50)

                                                                            End If

                                                                        End If

                                                                        Yg7 = Y3 + 100
                                                                        Xg7 = X3

                                                                    ElseIf item5.Nodes(0).Nodes(2).Text = 4 Then

                                                                        X3 += 190

                                                                        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 50)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 50)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 50)
                                                                        Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 70)
                                                                        Pintura.DrawString(item6.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 25, X3 + 150 + 15, Y3 + 25)
                                                                        Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3, Y3 + 25)

                                                                        If item6.Index < item5.Nodes.Count - 1 Then

                                                                            If item6.Index = 1 Then

                                                                                Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Y3 + 50)
                                                                                Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3 - 20, Y3 + 25)

                                                                            End If

                                                                            'desenha instrução vertical
                                                                            Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3 - 15, Y3 + 25 + 60)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 15, Y3 + 25, X3 + 150 + 15, Y3 + 25 + 60)

                                                                        Else

                                                                            Pintura.DrawLine(P0, X3 - 20 - 190, Y3 + 70, X3 + 150 + 20, Y3 + 70)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 20, Y3 + 25, X3 + 150 + 20, Y3 + 70)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 15, Y3 + 25, X3 + 150 + 20, Y3 + 25)

                                                                            If item5.Index = item4.Nodes.Count - 1 Then

                                                                                Pintura.DrawLine(P0, Xg5 - 20, Y3 + 70, Xg6 - 20, Y3 + 70)

                                                                                If item4.Index = item3.Nodes.Count - 1 Then

                                                                                    Pintura.DrawLine(P0, Xg4 - 20, Y3 + 70, Xg5 - 20, Y3 + 70)

                                                                                    If item3.Index = item2.Nodes.Count - 1 Then

                                                                                        Pintura.DrawLine(P0, Xg3 - 20, Y3 + 70, Xg4 - 20, Y3 + 70)

                                                                                        If item2.Index = item1.Nodes(1).Nodes.Count - 1 Then

                                                                                            Pintura.DrawLine(P0, Xg2 - 20, Y3 + 70, Xg3 - 20, Y3 + 70)

                                                                                            If item.Index = item1.Nodes.Count - 1 Then

                                                                                                Pintura.DrawLine(P0, X - 20, Y3 + 70, Xg2 - 20, Y3 + 70)

                                                                                            End If

                                                                                        End If

                                                                                    End If

                                                                                End If

                                                                            End If

                                                                        End If

                                                                        Dim X_Final As Integer = X3 + 130

                                                                        'Pintura.DrawLine(Pdefin, X3 + 150 + 20, Y3 + 45, X3 + 150 + 20, Y3 + 45 + 55)

                                                                        'insere verificação da lista suspensa anterior

                                                                        Dim Pt1 As New Point(X3, Y3 + 25)
                                                                        Dim Pt2 As New Point(X3 - 7, Y3 + 25 - 7)
                                                                        Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)

                                                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                                        Yg7 = Y3 + 45
                                                                        Xg7 = X3

                                                                    ElseIf item5.Nodes(0).Nodes(2).Text = 5 Then

                                                                        X3 += 190

                                                                        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), X3, Y3, 150, 50)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3, Y3, 10, 50)
                                                                        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), X3 + 140, Y3, 10, 50)
                                                                        Dim Retangulo As New Rectangle(X3 + 12, Y3 + 10, 125, 70)
                                                                        Pintura.DrawString(item6.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                                                                        Pintura.DrawLine(P0, X3 + 150, Y3 + 25, X3 + 150 + 15, Y3 + 25)
                                                                        Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3, Y3 + 25)

                                                                        Dim Pt1 As New Point(X3, Y3 + 25)
                                                                        Dim Pt2 As New Point(X3 - 7, Y3 + 25 - 7)
                                                                        Dim Pt3 As New Point(X3 - 7, Y3 + 25 + 7)
                                                                        Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                                        Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                                        If item6.Index < item5.Nodes.Count - 1 Then

                                                                            If item6.Index = 1 Then

                                                                                Pintura.DrawLine(P0, X3 - 20, Y3 + 25, X3 - 20, Y3 + 50)
                                                                                Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3 - 20, Y3 + 25)

                                                                            End If

                                                                            'desenha instrução vertical
                                                                            Pintura.DrawLine(P0, X3 - 15, Y3 + 25, X3 - 15, Y3 + 25 + 60)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 15, Y3 + 25, X3 + 150 + 15, Y3 + 25 + 60)

                                                                        Else

                                                                            Pintura.DrawLine(P0, X3 - 20 - 190, Y3 + 70, X3 + 150 + 20, Y3 + 70)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 20, Y3 + 25, X3 + 150 + 20, Y3 + 70)
                                                                            Pintura.DrawLine(P0, X3 + 150 + 15, Y3 + 25, X3 + 150 + 20, Y3 + 25)

                                                                            If item5.Index = item4.Nodes.Count - 1 Then

                                                                                Pintura.DrawLine(P0, Xg5 - 20, Y3 + 70, Xg6 - 20, Y3 + 70)

                                                                                If item4.Index = item3.Nodes.Count - 1 Then

                                                                                    Pintura.DrawLine(P0, Xg4 - 20, Y3 + 70, Xg5 - 20, Y3 + 70)

                                                                                    If item3.Index = item2.Nodes.Count - 1 Then

                                                                                        Pintura.DrawLine(P0, Xg3 - 20, Y3 + 70, Xg4 - 20, Y3 + 70)

                                                                                        If item2.Index = item1.Nodes(1).Nodes.Count - 1 Then

                                                                                            Pintura.DrawLine(P0, Xg2 - 20, Y3 + 70, Xg3 - 20, Y3 + 70)

                                                                                            If item.Index = item1.Nodes.Count - 1 Then

                                                                                                Pintura.DrawLine(P0, X - 20, Y3 + 70, Xg2 - 20, Y3 + 70)

                                                                                            End If

                                                                                        End If

                                                                                    End If

                                                                                End If

                                                                            End If

                                                                        End If

                                                                        Dim X_Final As Integer = X3 + 130


                                                                        'Pintura.DrawLine(Pdefin, X3 + 150 + 20, Y3 + 45, X3 + 150 + 20, Y3 + 45 + 55)

                                                                        'insere verificação da lista suspensa anterior

                                                                        If item5.Index < item4.Nodes.Count - 1 Then
                                                                            'Pintura.DrawLine(Pdefin, X3 - 20 - 190, Y3 + 45 + 55 + 55, X3 - 20 - 190, Y3 + 45 + 55)
                                                                        End If

                                                                        Yg7 = Y3 + 45
                                                                        Xg7 = X3


                                                                    End If

                                                                    Yg6 = Yg7

                                                                Else

                                                                    If item7.Index = item6.Nodes.Count - 1 Then

                                                                        Dim NewX2 As Integer = Xg7 + (150 / 2)
                                                                        'pinta botao
                                                                        Pintura.DrawImage(My.Resources.add_1_icon, NewX2 - 10, Yg7 + 35 + 20, 20, 20)

                                                                        Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX2 - 5, Yg7 + 25 + 20, 8, 8, -90, 45 * 4)

                                                                        'insere informaçao do botão
                                                                        item6.Nodes(0).Nodes(4).Text = NewX2 - 10
                                                                        item6.Nodes(0).Nodes(5).Text = Yg7 + 35 + 20

                                                                    End If

                                                                End If

                                                            Next

                                                        End If

                                                        Yg5 = Yg6

                                                    Next

                                                    If item5.Index = item4.Nodes.Count - 1 Then

                                                        If Tipo = 0 Then
                                                            Dim NewX2 As Integer = Xg6 + (150 / 2)
                                                            'pinta botao
                                                            Pintura.DrawImage(My.Resources.add_1_icon, NewX2 - 10, YgGuarda + 55, 20, 20)

                                                            Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX2 - 5, YgGuarda + 45, 8, 8, -90, 45 * 4)

                                                            'insere informaçao do botão
                                                            item4.Nodes(0).Nodes(4).Text = NewX2 - 10
                                                            item4.Nodes(0).Nodes(5).Text = YgGuarda + 55

                                                        End If

                                                    End If

                                                End If

                                                Yg4 = Yg5

                                            Next

                                            'verifica a quantidade de itens

                                            If item4.Nodes.Count = 1 Then

                                                Dim P1 As New Pen(Color.Red)

                                                P1.DashStyle = Drawing2D.DashStyle.Dot

                                                Dim NewX3 As Integer = Xg5 + (190) + 60
                                                'pinta botao
                                                Pintura.DrawImage(My.Resources.add_1_icon, NewX3 - 10, Yg5 - 25, 50, 50)

                                                'insere informaçao do botão
                                                item4.Nodes(0).Nodes(6).Text = NewX3 - 10
                                                item4.Nodes(0).Nodes(7).Text = Yg5 - 25

                                                Pintura.DrawLine(P1, Xg5 + 150, Yg5, NewX3 - 20, Yg5)

                                                Pintura.DrawLine(P1, NewX3 + 15, Yg5 + 25, NewX3 + 15, Yg5 + 30)

                                                Pintura.DrawLine(P1, Xg5 - 20, Yg5 + 30, NewX3 + 15, Yg5 + 30)

                                                'desenha indicador

                                                Dim Pt1 As New Point(NewX3 - 12, Yg5)
                                                Dim Pt2 As New Point(NewX3 - 12 - 7, Yg5 - 7)
                                                Dim Pt3 As New Point(NewX3 - 12 - 7, Yg5 + 7)

                                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                                                'verifica proxima conexão

                                                'insere verificação da lista suspensa anterior

                                            End If

                                            If item4.Index = item3.Nodes.Count - 1 Then

                                                Dim NewX2 As Integer = Xg5 + (150 / 2)
                                                'pinta botao
                                                Pintura.DrawImage(My.Resources.add_1_icon, NewX2 - 10, Yg5 + 35, 20, 20)

                                                Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX2 - 5, Yg5 + 25, 8, 8, -90, 45 * 4)

                                                'insere informaçao do botão
                                                item3.Nodes(0).Nodes(3).Text = NewX2 - 10
                                                item3.Nodes(0).Nodes(4).Text = Yg5 + 35

                                            End If

                                        End If

                                        Yg3 = Yg4

                                    Next

                                    If item3.Index = item2.Nodes.Count - 1 Then

                                        Dim NewX2 As Integer = Xg4 + (150 / 2)
                                        'pinta botao
                                        Pintura.DrawImage(My.Resources.add_1_icon, NewX2 - 10, Yg4 + 35, 20, 20)

                                        Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX2 - 5, Yg4 + 25, 8, 8, -90, 45 * 4)

                                        'insere informaçao do botão
                                        item2.Nodes(0).Nodes(3).Text = NewX2 - 10
                                        item2.Nodes(0).Nodes(4).Text = Yg4 + 35

                                    End If

                                End If

                                YFimMk = Yg2

                                Yg2 = Yg3

                            Next

                            If item2.Index = item1.Nodes.Count - 1 Then

                                Dim NewX1 As Integer = Xg3 + (150 / 2)
                                'pinta botao
                                Pintura.DrawImage(My.Resources.add_1_icon, NewX1 - 10, Yg3 + 35, 20, 20)
                                Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX1 - 5, Yg3 + 25, 8, 8, -90, 45 * 4)

                                'insere informaçao do botão
                                item1.Nodes(0).Nodes(3).Text = NewX1 - 10
                                item1.Nodes(0).Nodes(4).Text = Yg3 + 35
                            End If

                            If item.Nodes(1).Nodes.Count = 1 Then

                                Dim NewX As Integer = Xg1_1
                                'pinta botao
                                Pintura.DrawImage(My.Resources.add_1_icon, NewX - 10, Y, 50, 50)

                                item.Nodes(1).Nodes(0).Nodes(4).Text = NewX - 10
                                item.Nodes(1).Nodes(0).Nodes(5).Text = Y

                                'desenha linha inicial

                                Pintura.DrawLine(Pdefin, NewX - 10, Y + 25, X + ((150 + 20) * 2) + 20, Y + 25)
                                Pintura.DrawLine(Pdefin, NewX - 10, Yg1_1, NewX - 20, Y + 25)

                                Pintura.DrawLine(Pdefin, X + ((150 + 20) * 2) + 20 + 50 + 38, Y + 50, X + ((150 + 20) * 2) + 20 + 50 + 38, Y + 70)
                                'Pintura.DrawLine(P0, NewX - 10, Y + 25, NewX - 20, Y + 25)

                                'desenha indicador

                                Dim Pt1 As New Point(NewX - 10, Y + 25)
                                Dim Pt2 As New Point(NewX - 7 - 10, Y + (25 - 7))
                                Dim Pt3 As New Point(NewX - 7 - 10, Y + 25 + 7)

                                Dim Points() As Point = {Pt1, Pt2, Pt3}

                                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                            End If

                        End If

                        Yg2 = Yg1_1

                    Next

                    If item1.Index = item.Nodes(1).Nodes.Count - 1 Then

                        'desenha botão para novo cheklist

                        Dim NewX As Integer = Xg2 + (150 / 2)
                        'pinta botao
                        Pintura.DrawImage(My.Resources.add_1_icon, NewX - 10, Yg2 + 35, 20, 20)
                        Pintura.DrawArc(New Pen(New SolidBrush(Color.FromArgb(130, Color.SlateGray)), 2), NewX - 5, Yg2 + 25, 8, 8, -90, 45 * 4)

                        'insere informaçao do botão
                        item.Nodes(1).Nodes(0).Nodes(2).Text = NewX - 10
                        item.Nodes(1).Nodes(0).Nodes(3).Text = Yg2 + 35

                    End If

                End If

                'desenha indicador

                Dim Pt1_0 As New Point(X, Y + 25)
                Dim Pt2_0 As New Point(X - 7, (Y + 25) - 7)
                Dim Pt3_0 As New Point(X - 7, (Y + 25) + 7)

                Dim Points_0() As Point = {Pt1_0, Pt2_0, Pt3_0}

                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points_0)

                Yg1_0 = Yg1_1

            Next

            If item.Nodes(1).Nodes.Count = 1 Then

                Dim NewX As Integer = Xg1_1
                'pinta botao
                Pintura.DrawImage(My.Resources.add_1_icon, NewX - 10, Y, 50, 50)

                item.Nodes(1).Nodes(0).Nodes(4).Text = NewX - 10
                item.Nodes(1).Nodes(0).Nodes(5).Text = Y


                'desenha linha inicial

                Pintura.DrawLine(Pdefin, NewX - 10, Y + 25, X + ((150 + 20) * 2) + 20, Y + 25)
                Pintura.DrawLine(Pdefin, NewX - 10, Yg1_1, NewX - 20, Y + 25)

                Pintura.DrawLine(Pdefin, X + ((150 + 20) * 2) + 20 + 50 + 38, Y + 50, X + ((150 + 20) * 2) + 20 + 50 + 38, Y + 70)
                'Pintura.DrawLine(P0, NewX - 10, Y + 25, NewX - 20, Y + 25)

                'desenha indicador

                Dim Pt1 As New Point(NewX - 10, Y + 25)
                Dim Pt2 As New Point(NewX - 7 - 10, Y + (25 - 7))
                Dim Pt3 As New Point(NewX - 7 - 10, Y + 25 + 7)

                Dim Points() As Point = {Pt1, Pt2, Pt3}

                Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

            End If
            'insere o não

            Dim Y_não As Integer

            For Each item1 As TreeNode In item.Nodes(2).Nodes

                Dim Yg1 As Decimal

                If item1.Index = 0 Then

                    Dim X1 As Decimal = item1.Nodes(0).Text
                    Dim Y1 As Decimal = item1.Nodes(1).Text

                    Pintura.FillEllipse(New SolidBrush(Color.DarkGoldenrod), X1 + 53, Y1 - 2, 55, 55)
                    Pintura.FillEllipse(New SolidBrush(Color.LightSlateGray), X1 + 58, Y1 + 3, 45, 45)
                    Dim Retangulo As New Rectangle(X1 + 70, Y1 + 19, 45, 15)

                    Pintura.DrawString("Não", New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), Retangulo)

                    'desenha linha inicial

                    Pintura.DrawLine(P0, X1 + 53 + 55, Y1 + 25, X1 + 150 + 20, Y1 + 25)
                    Pintura.DrawLine(P0, X1 - 20, Y1 + 25, X1 + 53, Y1 + 25)
                    Pintura.DrawLine(P0, X1 - 20, Y + 25, X1 - 20, Y1 + 25)

                    'desenha indicador

                    Dim Pt1 As New Point(X1 + 53, Y1 + 25)
                    Dim Pt2 As New Point(X1 + (53 - 7), Y1 + (25 - 7))
                    Dim Pt3 As New Point(X1 + (53 - 7), Y1 + 25 + 7)

                    Dim Points() As Point = {Pt1, Pt2, Pt3}

                    Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                    'deswnha linha de saida

                    Pintura.DrawLine(P0, X1 + 150 + 20, Y1 + 25, X1 + 150 + 20, Y1 + 70)
                    Pintura.DrawLine(P0, X1 + 150 + 20, Y1 + 70, X + 75, Y1 + 70)
                    Pintura.DrawLine(P0, X + 75, Y1 + 70, X + 75, Y + 45)

                    'desenha indicador

                    Pt1 = New Point(X + 75, Y + 45)
                    Pt2 = New Point(X + 75 + 7, Y + 45 + 7)
                    Pt3 = New Point(X + (75 - 7), Y + 45 + 7)

                    Points = {Pt1, Pt2, Pt3}

                    Pintura.FillPolygon(New SolidBrush(Color.SlateGray), Points)

                    Yg1 = Y + 25
                    Y_não = Y1 + 25

                End If

            Next

            'insre conexão com o ultimo

            If item.Nodes(1).Nodes.Count = 1 Then

                Dim NewX As Integer = X + (150 / 2)

                Pintura.DrawLine(P0, X + ((150 + 20) * 2) + 20 + 50 + 38, Y + 70, X + ((150 + 20) * 2) + 20 + 50 + 38, Y_não + 70)
                Pintura.DrawLine(P0, NewX, Y_não + 70, X + ((150 + 20) * 2) + 20 + 50 + 38, Y_não + 70)

                If item.Index < TrFluxo.Nodes.Count - 1 Then

                    Pintura.DrawLine(P0, X - 20, Y_não + 70, NewX, Y_não + 70)

                End If

                Yg1_0 = Y_não + 95

            End If

            Yg1_0 = Y_não

        Next

        'DESENHA FIM DO PROCESSO

        Dim XFim As Decimal = 60
        Dim YFim As Decimal = Yg1_0 + 120

        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), XFim, YFim, 150, 10)
        Pintura.FillRectangle(New SolidBrush(Color.DarkGoldenrod), XFim + 10, YFim + 10, 130, 15)
        Pintura.FillRectangle(New SolidBrush(Color.LightSlateGray), XFim, YFim + 25, 150, 25)

        Dim RetanguloFim As New Rectangle(XFim + 10, YFim + 12, 130, 15)

        Pintura.DrawString("Fim do Fluxo", New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), RetanguloFim)

        'desenha linha inicial

        Dim X0_1 As Integer = XFim + (150 / 2)
        Pintura.DrawLine(P0, X0_1, YFim - 25, X0_1, YFim - 25)

        'desenha indicador

        Dim Pt1_fim As New Point(X0_1, YFim)
        Dim Pt2_fim As New Point(X0_1 - 7, YFim - 7)
        Dim Pt3_fim As New Point(X0_1 + 7, YFim - 7)

        Dim Points_fim() As Point = {Pt1_fim, Pt2_fim, Pt3_fim}

        Pintura.DrawLine(P0, X0_1, YFim, X0_1, YFim - 25)

        Pintura.FillPolygon(New SolidBrush(Color.LightSlateGray), Points_fim)


        PicFluxo.BackgroundImage = PintarBitmap

    End Sub


    Private Sub FrmFluxo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PublicaTreeview()

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub PicFluxo_Click(sender As Object, e As EventArgs) Handles PicFluxo.Click

        PublicaTreeview()

        PublicaLista()
        PublicaSeleçãoTEmp()

    End Sub

    Dim MouseX As Integer
    Dim MouseY As Integer

    Private Sub PicFluxo_MouseMove(sender As Object, e As MouseEventArgs) Handles PicFluxo.MouseMove

        MouseX = e.X
        MouseY = e.Y

        LblPtxy.Text = "X." & e.X & "-Y." & e.Y

    End Sub
End Class