Imports System.Drawing

Public Class FrmDesmonte

    Dim LqOficina As New LqOficinaDataContext

    Public _Placa As String
    Public _IdVeiculo As Integer
    Public _IdCliente As Integer

    Private Sub FrmDesmonte_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PublicaTreeview()

    End Sub

    Public _idTrSel As Integer
    Public _idModeloVeic As Integer

    Dim Zero As Boolean = True

    Dim IDRepsosta As Integer

    Public Sub PublicaTreeview()

        Dim SemAnalise As Integer
        Dim IDProcesso As Integer = LblProcesso.Text

        If Zero = True Then

            Dim ValorContatoGeral As Decimal

            Zero = False

            TrRespostashecklist.Nodes.Clear()

            FrmCarregarDesmonte.Show(Me)
            Dim BuscaRespostaUsuario = From resp In LqOficina.RespostasCheklistUsuario
                                       Where resp.IdProesso = IDProcesso
                                       Select resp.descricao, resp.IdPergunta, resp.IdRespostaChecklist

            ValorContatoGeral = 100 / BuscaRespostaUsuario.Count

            Dim C1 As Integer

            Dim Pct As Decimal = 0

            For Each row In BuscaRespostaUsuario.ToList

                FrmCarregarDesmonte.DtItensBDD.Rows.Add(FrmCarregarDesmonte.ImageList1.Images(3), "", "Carregando dados")
                FrmCarregarDesmonte.DtItensBDD.CurrentCell = FrmCarregarDesmonte.DtItensBDD(0, FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1)

                FrmCarregarDesmonte.DtItensBDD.Refresh()

                C1 += 1

                'Busca se reposta entra na avaliação

                Dim buscaPergunta = From pg In LqOficina.PerguntasChecklist
                                    Where pg.UsoResposta = True And pg.IdPerguntaChecklit = row.IdPergunta
                                    Select pg.Titulo, pg.IdPerguntaChecklit

                If buscaPergunta.Count > 0 Then

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(2)
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(1).Value = buscaPergunta.First
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Iniciando pergunta " & C1 & " de " & BuscaRespostaUsuario.Count

                    FrmCarregarDesmonte.DtItensBDD.Refresh()

                    TrRespostashecklist.Nodes.Add(buscaPergunta.First.Titulo)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(buscaPergunta.First.Titulo)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(row.IdRespostaChecklist)
                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add("ImgKey")

                    'devera buscar imagens

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdRespostaUsuario = row.IdRespostaChecklist And img.IdProcesso = IDProcesso
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem 0 de " & buscaImagens.Count

                    FrmCarregarDesmonte.Refresh()

                    Dim C As Integer = 0

                    For Each row1 In buscaImagens.ToList

                        Dim Fração1 As Decimal = ValorContatoGeral / buscaImagens.Count

                        C += 1

                        TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Add(row1.IdImagemProcesso)

                        'busca marcações

                        Dim BuscaMarcações = From mark In LqOficina.MarcasImagens
                                             Where mark.IdImagem = row1.IdImagemProcesso
                                             Select mark.IdMarcaImagem, mark.descricao, mark.X, mark.Y

                        For Each row2 In BuscaMarcações.ToList

                            Dim Fração2 As Decimal = Fração1 / BuscaMarcações.Count

                            Pct += Fração2

                            FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"

                            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Count - 1).Nodes.Add(row2.descricao)

                            Dim NodeXY As TreeNode = TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Count - 1).Nodes.Count - 1)

                            NodeXY.Nodes.Add((row2.X * 90) / 100)
                            NodeXY.Nodes.Add(((row2.Y * 90) / 100) - 15)
                            NodeXY.Nodes.Add(row2.IdMarcaImagem)

                            'busca solução

                            Dim BuscaSol = From sol In LqOficina.SoluçõesVistoria
                                           Where sol.IdMarca = row2.IdMarcaImagem
                                           Select sol.IdSolucoes


                            If BuscaSol.Count > 0 Then
                                NodeXY.Nodes.Add(BuscaSol.First)
                            Else
                                NodeXY.Nodes.Add(0)
                                SemAnalise += 1
                            End If
                            FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem " & C & " de " & buscaImagens.Count
                            FrmCarregarDesmonte.Refresh()

                        Next

                        If BuscaMarcações.Count = 0 Then

                            Pct += Fração1

                            FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"

                        End If

                    Next

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(0)
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Finalizado " & C1 & " de " & BuscaRespostaUsuario.Count
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = ""

                    If buscaImagens.Count = 0 Then

                        Pct += ValorContatoGeral

                        FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"

                    End If

                    FrmCarregarDesmonte.DtItensBDD.Refresh()

                End If

            Next

            FrmCarregarDesmonte.Refresh()

            If SemAnalise > 0 Then

                BttConcluirAnalise.Enabled = False

            Else

                BttConcluirAnalise.Enabled = True

            End If

            If TrRespostashecklist.Nodes.Count > 0 Then
                TrRespostashecklist.SelectedNode = TrRespostashecklist.Nodes(0)
                _idTrSel = TrRespostashecklist.SelectedNode.Index
            End If

            FrmCarregarDesmonte.Close()

        Else


            FrmCarregarDesmonte.Show(Me)
            Dim BuscaRespostaUsuario = From resp In LqOficina.RespostasCheklistUsuario
                                       Where resp.IdRespostaChecklist = IDRepsosta
                                       Select resp.Descricao, resp.IdPergunta, resp.IdRespostaChecklist

            Dim C1 As Integer
            For Each row In BuscaRespostaUsuario.ToList

                FrmCarregarDesmonte.DtItensBDD.Rows.Add(FrmCarregarDesmonte.ImageList1.Images(3), "", "Carregando dados")
                FrmCarregarDesmonte.DtItensBDD.CurrentCell = FrmCarregarDesmonte.DtItensBDD(0, FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1)

                FrmCarregarDesmonte.DtItensBDD.Refresh()

                C1 += 1

                'Busca se reposta entra na avaliação

                Dim buscaPergunta = From pg In LqOficina.PerguntasChecklist
                                    Where pg.UsoResposta = True And pg.IdPerguntaChecklit = row.IdPergunta
                                    Select pg.Titulo, pg.IdPerguntaChecklit

                If buscaPergunta.Count > 0 Then

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(2)
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(1).Value = buscaPergunta.First
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Iniciando pergunta " & C1 & " de " & BuscaRespostaUsuario.Count

                    FrmCarregarDesmonte.DtItensBDD.Refresh()

                    TrRespostashecklist.Nodes(_idTrSel).Nodes.Clear()
                    TrRespostashecklist.Nodes(_idTrSel).Nodes.Add(buscaPergunta.First.Titulo)
                    TrRespostashecklist.Nodes(_idTrSel).Nodes.Add(row.IdRespostaChecklist)
                    TrRespostashecklist.Nodes(_idTrSel).Nodes.Add("ImgKey")

                    'devera buscar imagens

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdRespostaUsuario = row.IdRespostaChecklist And img.IdProcesso = IDProcesso
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem 0 de " & buscaImagens.Count

                    FrmCarregarDesmonte.Refresh()

                    Dim C As Integer = 0

                    For Each row1 In buscaImagens.ToList

                        C += 1

                        TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Add(row1.IdImagemProcesso)

                        'busca marcações

                        Dim BuscaMarcações = From mark In LqOficina.MarcasImagens
                                             Where mark.IdImagem = row1.IdImagemProcesso
                                             Select mark.IdMarcaImagem, mark.Descricao, mark.X, mark.Y


                        For Each row2 In BuscaMarcações.ToList

                            TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes.Add(row2.descricao)

                            Dim NodeXY As TreeNode = TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1)

                            NodeXY.Nodes.Add((row2.X * 90) / 100)
                            NodeXY.Nodes.Add(((row2.Y * 90) / 100) - 15)
                            NodeXY.Nodes.Add(row2.IdMarcaImagem)

                            'busca solução

                            Dim BuscaSol = From sol In LqOficina.SoluçõesVistoria
                                           Where sol.IdMarca = row2.IdMarcaImagem
                                           Select sol.IdSolucoes

                            If BuscaSol.Count > 0 Then
                                NodeXY.Nodes.Add(BuscaSol.First)
                            Else
                                NodeXY.Nodes.Add(0)
                                SemAnalise += 1
                            End If
                            FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem " & C & " de " & buscaImagens.Count
                            FrmCarregarDesmonte.Refresh()

                        Next

                    Next

                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(0)
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Finalizado " & C1 & " de " & BuscaRespostaUsuario.Count
                    FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = ""

                    FrmCarregarDesmonte.DtItensBDD.Refresh()

                End If

            Next

            FrmCarregarDesmonte.Close()

            If SemAnalise > 0 Then

                BttConcluirAnalise.Enabled = False

            Else

                BttConcluirAnalise.Enabled = True

            End If

            If TrRespostashecklist.Nodes.Count > 0 Then
                TrRespostashecklist.SelectedNode = TrRespostashecklist.Nodes(_idTrSel)
                DesnhaMarcaçõesZoom()
            End If

        End If

    End Sub

    Dim PX As Integer
    Dim PY As Integer

    Dim Executa As Boolean = False
    Private Sub TrRespostashecklist_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TrRespostashecklist.AfterSelect

        PicImagem.Location = New Point(0, 0)

        TrackBar1.Value = 90

        PicImagem.Visible = False
        PicImagem.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2), (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2))

        PicLoad2.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicLoad2.Width / 2), (PnnAreaTrabalho.Height / 2) - (PicLoad2.Height / 2))

        PicLoad.Visible = True
        PicLoad2.Visible = True

        Me.Refresh()

        Me.Cursor = Cursors.AppStarting

        Dim PintarBitmap1 = New Bitmap(ListView1.Width, ListView1.Height)

        'Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

        'Pintura1.DrawImage(My.Resources.giphy, 10, 10, 150, 100)

        'PicLoad.Image = PintarBitmap1

        PicLoad.Size = New Size(PintarBitmap1.Width, PintarBitmap1.Height)

        _idTrSel = TrRespostashecklist.SelectedNode.Index

        ListView1.Items.Clear()

        'devera buscar imagens

        IDRepsosta = TrRespostashecklist.SelectedNode.Nodes(1).Text

        Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                           Where img.IdRespostaUsuario = IDRepsosta And img.IdProcesso = LblProcesso.Text
                           Select img.Imagem, img.IdImagemProcesso

        'varre imagens

        For Each row1 In buscaImagens.ToList

            Me.Refresh()

            Dim arrImage() As Byte
            Dim myMS As New IO.MemoryStream
            arrImage = row1.Imagem.ToArray

            For Each ar As Byte In arrImage
                myMS.WriteByte(ar)
            Next

            'define o tamanho da imagem 

            Dim Image As Image = System.Drawing.Image.FromStream(myMS)

            ImageList1.Images.Add(Image)

            ListView1.Items.Add(ImageList1.Images.Count - 1)

            myMS.Dispose()

        Next

        'varre e completa os images

        For Each row As ListViewItem In ListView1.Items

            Me.Refresh()

            row.ImageIndex = row.Text

        Next

        PicLoad.Visible = False

        Me.Refresh()


        If ListView1.Items.Count > 0 Then

            ListView1.Items(0).Selected = True
            DesenhaMarcações()

        End If

        LblValZoom.Text = TrackBar1.Value & "%"

        PicImagem.Location = New Point(0, 0)

        PicImagem.Size = New Size(PicImagem.Width * (TrackBar1.Value / 100), PicImagem.Height * (TrackBar1.Value / 100))

        If (PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2) > 0 Then
            If (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2) > 0 Then
                PicImagem.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2), (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2))
            Else
                PicImagem.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2), 0)
            End If
        Else
            If (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2) > 0 Then
                PicImagem.Location = New Point(0, (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2))
            Else
                PicImagem.Location = New Point(0, 0)
            End If
        End If

        DesnhaMarcaçõesZoom()

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ListView1_Click(sender As Object, e As EventArgs) Handles ListView1.Click

        Me.Cursor = Cursors.AppStarting

        DesenhaMarcações()

        Me.Cursor = Cursors.Arrow

    End Sub
    Public Sub DesenhaMarcações()

        Me.Refresh()

        PicImagem.BackgroundImageLayout = ImageLayout.Center

        'busca a imagem e preenche no picture ao lado

        Me.Cursor = Cursors.WaitCursor

        Dim BuscaIMagem = From img In LqOficina.ImagemRespostaCklist
                          Where img.IdImagemProcesso = TrRespostashecklist.SelectedNode.Nodes(2).Nodes(ListView1.SelectedItems.Item(0).Index).Text
                          Select img.Imagem, img.Titulo, img.IdImagemProcesso

        Dim arrImage() As Byte
        Dim myMS As New IO.MemoryStream
        arrImage = BuscaIMagem.First.Imagem.ToArray

        For Each ar As Byte In arrImage
            myMS.WriteByte(ar)
        Next

        Dim H As Integer = (FrmImagemAvaliação.PictureBox1.Width * 90) / 100
        Dim V As Integer = (FrmImagemAvaliação.PictureBox1.Height * 90) / 100

        PicImagem.Cursor = Cursors.WaitCursor

        Dim PintarBitmap = New Bitmap(H, V)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim PintarBitmap2 = New Bitmap(PicImagem.Width, PicImagem.Height)
        Dim Pintura2 = Graphics.FromImage(PintarBitmap2)

        Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, H, V)
        PicImagem.Size = New Size(H, V)

        'varre o treeview

        'desenha grade

        Dim Riscos As Integer = 0
        Dim Peças As Integer = 0
        Dim PeçasIrre As Integer = 0
        Dim Trinco As Integer = 0
        Dim Quebrado As Integer = 0
        Dim Rasgado As Integer = 0
        Dim DesgasteAcab As Integer = 0
        Dim Inoperante As Integer = 0
        Dim falha As Integer = 0
        Dim Mancha As Integer = 0
        Dim Delaminação As Integer = 0
        Dim DelaminaçãoVidro As Integer = 0
        Dim QuebradoVidro As Integer = 0
        Dim Desgaste As Integer = 0
        Dim amassado As Integer = 0
        Dim Corrosão As Integer = 0
        Dim QuebradoAcab As Integer = 0
        Dim RiscoAcab As Integer = 0

        Me.Cursor = Cursors.AppStarting

        'calcula diferenca e acrescenta

        For Each item As TreeNode In TrRespostashecklist.SelectedNode.Nodes(2).Nodes(ListView1.SelectedItems.Item(0).Index).Nodes

            Me.Refresh()

            If item.Nodes(3).Text = 0 Then
                If item.Text = "Risco" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 70, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 70, 15)

                        Pintura.DrawString("Risco_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Riscos += 1

                    Next

                ElseIf item.Text = "Amassado" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Amassado_" & amassado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        amassado += 1

                    Next

                ElseIf item.Text = "Peça ausente" Then

                    Dim MEX_0 As Decimal = (item.Nodes(0).Text * (TrackBar1.Value / 100))
                    Dim MEY_0 As Decimal = (item.Nodes(1).Text * (TrackBar1.Value / 100))

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Peça ausente_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    Peças += 1

                ElseIf item.Text = "Peça irrecuperável" Then

                    Dim MEX_0 As Decimal = (item.Nodes(0).Text * (TrackBar1.Value / 100))
                    Dim MEY_0 As Decimal = (item.Nodes(1).Text * (TrackBar1.Value / 100))

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Peça irrecuperável_" & PeçasIrre, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    PeçasIrre += 1

                ElseIf item.Text = "Corrosão" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Corrosão_" & Corrosão, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Corrosão += 1

                    Next

                ElseIf item.Text = "Delaminação" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Delaminação_" & Delaminação, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Delaminação += 1

                    Next

                ElseIf item.Text = "Desgaste" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Desgaste_" & Desgaste, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Desgaste += 1

                    Next

                ElseIf item.Text = "Trinco" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Trinco_" & Trinco, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Trinco += 1

                    Next

                ElseIf item.Text = "Delaminação vidro" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Delaminação vidro_" & DelaminaçãoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DelaminaçãoVidro += 1

                    Next

                ElseIf item.Text = "Quebrado" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Vidro quebrado_" & QuebradoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    QuebradoVidro += 1

                ElseIf item.Text = "Rasgado" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Rasgado_" & Rasgado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Rasgado += 1

                    Next

                ElseIf item.Text = "Desgaste acab." Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Desegaste Acab. _" & DesgasteAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DesgasteAcab += 1

                    Next

                ElseIf item.Text = "Quebrado acab." Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Acab. Quebrado_" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    QuebradoAcab += 1

                ElseIf item.Text = "Risco acab." Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Risco avab." & RiscoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        RiscoAcab += 1

                    Next

                ElseIf item.Text = "Mancha" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Mancha_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Mancha += 1

                    Next

                ElseIf item.Text = "Inoperante" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Inoperante_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    Inoperante += 1

                ElseIf item.Text = "Falha" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Falha_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    falha += 1

                End If
            Else
                If item.Text = "Risco" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 70, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 70, 15)

                        Pintura2.DrawString("Risco_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Riscos += 1

                    Next

                ElseIf item.Text = "Amassado" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Amassado_" & amassado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        amassado += 1

                    Next

                ElseIf item.Text = "Peça ausente" Then

                    Dim MEX_0 As Decimal = (item.Nodes(0).Text * (TrackBar1.Value / 100))
                    Dim MEY_0 As Decimal = (item.Nodes(1).Text * (TrackBar1.Value / 100))

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Peça ausente_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    Peças += 1

                ElseIf item.Text = "Peça irrecuperável" Then

                    Dim MEX_0 As Decimal = (item.Nodes(0).Text * (TrackBar1.Value / 100))
                    Dim MEY_0 As Decimal = (item.Nodes(1).Text * (TrackBar1.Value / 100))


                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Peça irrecuperável_" & PeçasIrre, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    PeçasIrre += 1

                ElseIf item.Text = "Corrosão" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Corrosão_" & Corrosão, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Corrosão += 1

                    Next

                ElseIf item.Text = "Delaminação" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Delaminação_" & Delaminação, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Delaminação += 1

                    Next

                ElseIf item.Text = "Desgaste" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Desgaste_" & Desgaste, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Desgaste += 1

                    Next

                ElseIf item.Text = "Trinco" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Trinco_" & Trinco, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Trinco += 1

                    Next

                ElseIf item.Text = "Delaminação vidro" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Delaminação vidro_" & DelaminaçãoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DelaminaçãoVidro += 1

                    Next

                ElseIf item.Text = "Quebrado" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Vidro quebrado_" & QuebradoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    QuebradoVidro += 1

                ElseIf item.Text = "Rasgado" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Rasgado_" & Rasgado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Rasgado += 1

                    Next

                ElseIf item.Text = "Desgaste acab." Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Desegaste Acab. _" & DesgasteAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DesgasteAcab += 1

                    Next

                ElseIf item.Text = "Quebrado acab." Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Acab. Quebrado_" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    QuebradoAcab += 1

                ElseIf item.Text = "Risco acab." Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Risco avab." & RiscoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        RiscoAcab += 1

                    Next

                ElseIf item.Text = "Mancha" Then

                    Dim MEX As Integer = item.Nodes(1).Text
                    Dim MEY As Integer = item.Nodes(3).Text

                    Dim MEX_e As Integer = item.Nodes(0).Text
                    Dim MEY_e As Integer = item.Nodes(2).Text

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura2.DrawString("Mancha_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Mancha += 1

                    Next

                ElseIf item.Text = "Inoperante" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Inoperante_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    Inoperante += 1

                ElseIf item.Text = "Falha" Then

                    Dim MEX_0 As Decimal = item.Nodes(0).Text
                    Dim MEY_0 As Decimal = item.Nodes(1).Text

                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                    Pintura2.DrawString("Falha_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                    falha += 1

                End If

            End If

        Next

        Me.Cursor = Cursors.WaitCursor

        PicImagem.Image = PintarBitmap2
        PicImagem.BackgroundImage = PintarBitmap
        PicImagem.Cursor = Cursors.Arrow
        PicImagem.Visible = True
        PicLoad2.Visible = False

        PicImagem.BackgroundImageLayout = ImageLayout.Stretch

        If ValueX = 0 Then
            ValueX = PicImagem.Width
        End If
        If ValueY = 0 Then
            ValueY = PicImagem.Height
        End If

        PicLoad2.Visible = False

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Private Sub PicImagem_Click(sender As Object, e As EventArgs) Handles PicImagem.Click

        'procura na lista se existe correspondencia

        For Each item As TreeNode In TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(ListView1.SelectedItems.Item(0).Index).Nodes

            Dim MEX As Integer = item.Nodes(0).Text * ((TrackBar1.Value) / 100)
            Dim MEY As Integer = item.Nodes(1).Text * ((TrackBar1.Value) / 100)

            If MouseX >= MEX And MouseX <= MEX + 110 Then

                If MouseY >= MEY - 7.5 And MouseY <= MEY + 7.5 Then

                    FrmSoluçãoAplicada._IdProcesso = LblIdSolução.Text
                    FrmSoluçãoAplicada._IdMarca = item.Nodes(2).Text
                    FrmSoluçãoAplicada.LblIdVistoria.Text = LblIdSolução.Text
                    FrmSoluçãoAplicada.LblIdmarca.Text = item.Nodes(2).Text
                    'procura solução já inserida

                    Dim BuscaSolução = From sol In LqOficina.SoluçõesVistoria
                                       Where sol.IdMarca = item.Nodes(2).Text
                                       Select sol.IdSolucoes, sol.Status

                    If BuscaSolução.Count > 0 Then

                        If BuscaSolução.First.Status = True Then

                            If MsgBox("Esta avaria foi ignorada, deseja reabri-la para edição?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                                LqOficina.RemoveSolucaoSemTriagem(item.Nodes(3).Text)

                                PublicaTreeview()

                                FrmSoluçãoAplicada.Show(Me)

                            End If

                        Else

                            'busca itens

                            Dim BuscaItensSolução = From sol In LqOficina.ItensSoluçãoN
                                                    Where sol.IdSolucao = item.Nodes(3).Text
                                                    Select sol.IdProduto, sol.IdSolicitacao, sol.Qt, sol.Tipo, sol.NeessitaInicio

                            FrmSoluçãoAplicada.IdSoluções = item.Nodes(3).Text

                            For Each row In BuscaItensSolução.ToList

                                If row.IdProduto = 0 Then

                                    'busca solicitação de cadastro
                                    Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                                           Where sol.IdSolicitacaoCadastro = row.IdSolicitacao
                                                           Select sol.Descricao, sol.IdCodCad

                                    If BuscaSolicitação.Count > 0 Then

                                        'verifica se existe atualização de cadastro

                                        If BuscaSolicitação.First.IdCodCad = 0 Then
                                            FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add("S" & row.IdSolicitacao, "", "", BuscaSolicitação.First.Descricao, "", row.Qt, False, row.NeessitaInicio)
                                        Else

                                            'procura produto

                                            'procura produto

                                            Dim BuscaProduto = From prod In LqBase.Produtos
                                                               Where prod.IdProduto = BuscaSolicitação.First.IdCodCad
                                                               Select prod.Categoria, prod.SubCategoria, prod.Fabricante, prod.Descricao

                                            FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add(BuscaSolicitação.First.IdCodCad, BuscaProduto.First.Categoria, BuscaProduto.First.SubCategoria, BuscaProduto.First.Descricao, BuscaProduto.First.Fabricante, row.Qt, False, row.NeessitaInicio)

                                            'apaga solicitação

                                            LqOficina.DeletaSolucaoItemMarcaDesmonte(row.IdSolicitacao, LblIdSolução.Text)

                                        End If

                                    End If

                                Else

                                    'procura produto

                                    Dim BuscaProduto = From prod In LqBase.Produtos
                                                       Where prod.IdProduto = row.IdProduto
                                                       Select prod.Categoria, prod.SubCategoria, prod.Fabricante, prod.Descricao

                                    FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add(row.IdProduto, BuscaProduto.First.Categoria, BuscaProduto.First.SubCategoria, BuscaProduto.First.Descricao, BuscaProduto.First.Fabricante, row.Qt, False, row.NeessitaInicio)

                                End If

                            Next

                            If Application.OpenForms.OfType(Of FrmSoluçãoAplicada)().Count() > 0 Then
                                FrmSoluçãoAplicada.Show(Me)

                                If FrmSoluçãoAplicada.DtrodutosSolução.Rows.Count > 0 Then

                                    FrmSoluçãoAplicada.Button4.Enabled = False
                                    FrmSoluçãoAplicada.BttRemover.Enabled = True

                                Else

                                    FrmSoluçãoAplicada.Button4.Enabled = True
                                    FrmSoluçãoAplicada.BttRemover.Enabled = False

                                End If

                            Else
                                FrmSoluçãoAplicada.Close()
                                FrmSoluçãoAplicada._IdProcesso = LblIdSolução.Text
                                FrmSoluçãoAplicada._IdMarca = item.Nodes(2).Text
                                FrmSoluçãoAplicada.LblIdVistoria.Text = LblIdSolução.Text
                                FrmSoluçãoAplicada.LblIdmarca.Text = item.Nodes(2).Text
                                FrmSoluçãoAplicada.IdSoluções = item.Nodes(3).Text
                                FrmSoluçãoAplicada.LblIdSolução.Text = item.Nodes(3).Text

                                For Each row In BuscaItensSolução.ToList

                                    If row.IdProduto = 0 Then

                                        'busca solicitação de cadastro
                                        Dim BuscaSolicitação = From sol In LqOficina.SolicitacaoCadastroPeca
                                                               Where sol.IdSolicitacaoCadastro = row.IdSolicitacao
                                                               Select sol.Descricao, sol.IdCodCad

                                        If BuscaSolicitação.Count > 0 Then

                                            'verifica se existe atualização de cadastro

                                            If BuscaSolicitação.First.IdCodCad = 0 Then
                                                FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add("S" & row.idsolicitacao, "", "", BuscaSolicitação.First.descricao, "", row.Qt, False, row.NeessitaInicio)
                                            Else

                                                'procura produto

                                                'procura produto

                                                Dim BuscaProduto = From prod In LqBase.Produtos
                                                                   Where prod.IdProduto = BuscaSolicitação.First.IdCodCad
                                                                   Select prod.Categoria, prod.SubCategoria, prod.Fabricante, prod.Descricao

                                                FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add(BuscaSolicitação.First.IdCodCad, BuscaProduto.First.Categoria, BuscaProduto.First.SubCategoria, BuscaProduto.First.descricao, BuscaProduto.First.Fabricante, row.Qt, False, row.NeessitaInicio)

                                                'apaga solicitação

                                                LqOficina.DeletaSolucaoItemMarcaDesmonte(row.idsolicitacao, LblIdSolução.Text)

                                            End If

                                        End If

                                    Else

                                        'procura produto

                                        Dim BuscaProduto = From prod In LqBase.Produtos
                                                           Where prod.IdProduto = row.IdProduto
                                                           Select prod.Categoria, prod.SubCategoria, prod.Fabricante, prod.Descricao

                                        FrmSoluçãoAplicada.DtrodutosSolução.Rows.Add(row.IdProduto, BuscaProduto.First.Categoria, BuscaProduto.First.SubCategoria, BuscaProduto.First.descricao, BuscaProduto.First.Fabricante, row.Qt, False, row.NeessitaInicio)

                                    End If

                                Next

                                FrmSoluçãoAplicada.Show(Me)
                                If FrmSoluçãoAplicada.DtrodutosSolução.Rows.Count > 0 Then

                                    FrmSoluçãoAplicada.Button4.Enabled = False
                                    FrmSoluçãoAplicada.BttRemover.Enabled = True

                                Else

                                    FrmSoluçãoAplicada.Button4.Enabled = True
                                    FrmSoluçãoAplicada.BttRemover.Enabled = False

                                End If

                            End If

                        End If

                    Else

                        FrmSoluçãoAplicada.IdSoluções = item.Nodes(3).Text
                        FrmSoluçãoAplicada.LblIdSolução.Text = item.Nodes(3).Text

                        If Application.OpenForms.OfType(Of FrmSoluçãoAplicada)().Count() > 0 Then
                            FrmSoluçãoAplicada.Show(Me)
                            If FrmSoluçãoAplicada.DtrodutosSolução.Rows.Count > 0 Then

                                FrmSoluçãoAplicada.Button4.Enabled = False
                                FrmSoluçãoAplicada.BttRemover.Enabled = True

                            Else

                                FrmSoluçãoAplicada.Button4.Enabled = True
                                FrmSoluçãoAplicada.BttRemover.Enabled = False

                            End If

                        Else
                            FrmSoluçãoAplicada.Close()
                            FrmSoluçãoAplicada._IdProcesso = LblIdSolução.Text
                            FrmSoluçãoAplicada._IdMarca = item.Nodes(2).Text
                            FrmSoluçãoAplicada.LblIdVistoria.Text = LblIdSolução.Text
                            FrmSoluçãoAplicada.LblIdmarca.Text = item.Nodes(2).Text
                            FrmSoluçãoAplicada.IdSoluções = item.Nodes(3).Text
                            FrmSoluçãoAplicada.LblIdSolução.Text = item.Nodes(3).Text
                            FrmSoluçãoAplicada.Show(Me)
                            If FrmSoluçãoAplicada.DtrodutosSolução.Rows.Count > 0 Then

                                FrmSoluçãoAplicada.Button4.Enabled = False
                                FrmSoluçãoAplicada.BttRemover.Enabled = True

                            Else

                                FrmSoluçãoAplicada.Button4.Enabled = True
                                FrmSoluçãoAplicada.BttRemover.Enabled = False

                            End If

                        End If

                    End If

                End If

            End If

        Next

    End Sub

    Dim MouseX As Decimal
    Dim MouseY As Decimal

    Private Sub PicImagem_MouseMove(sender As Object, e As MouseEventArgs) Handles PicImagem.MouseMove

        MouseX = e.X
        MouseY = e.Y

        LblPos.Text = "X:" & MouseX & "; Y:" & MouseY

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim Mk As Integer = 1

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Executa = True

        Mk += 1

    End Sub

    Private Sub LblMk_TextChanged(sender As Object, e As EventArgs)

        Me.Refresh()

    End Sub

    Dim ValueX As Decimal = 0
    Dim ValueY As Decimal = 0
    Dim AcresX As Decimal = 0
    Dim Acresy As Decimal = 0

    Public Sub DesnhaMarcaçõesZoom()

        If ValueX > 0 And ValueY > 0 Then

            If ListView1.Items.Count > 0 Then
                Dim PintarBitmap2 = New Bitmap(PicImagem.Width, PicImagem.Height)
                Dim Pintura2 = Graphics.FromImage(PintarBitmap2)

                'varre o treeview

                'desenha grade

                Dim Riscos As Integer = 0
                Dim Peças As Integer = 0
                Dim PeçasIrre As Integer = 0
                Dim Trinco As Integer = 0
                Dim Quebrado As Integer = 0
                Dim Rasgado As Integer = 0
                Dim DesgasteAcab As Integer = 0
                Dim Inoperante As Integer = 0
                Dim falha As Integer = 0
                Dim Mancha As Integer = 0
                Dim Delaminação As Integer = 0
                Dim DelaminaçãoVidro As Integer = 0
                Dim QuebradoVidro As Integer = 0
                Dim Desgaste As Integer = 0
                Dim amassado As Integer = 0
                Dim Corrosão As Integer = 0
                Dim QuebradoAcab As Integer = 0
                Dim RiscoAcab As Integer = 0

                Me.Cursor = Cursors.AppStarting

                'calcula diferenca e acrescenta

                For Each item As TreeNode In TrRespostashecklist.SelectedNode.Nodes(2).Nodes(ListView1.SelectedItems.Item(0).Index).Nodes

                    Me.Refresh()

                    If item.Nodes(3).Text = 0 Then
                        If item.Text = "Risco" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 70, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 70, 15)

                                Pintura2.DrawString("Risco_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Riscos += 1

                            Next

                        ElseIf item.Text = "Amassado" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Amassado_" & amassado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                amassado += 1

                            Next

                        ElseIf item.Text = "Peça ausente" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text * ((TrackBar1.Value) / 100)
                            Dim MEY_0 As Decimal = item.Nodes(1).Text * ((TrackBar1.Value) / 100)

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Peça ausente_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            Peças += 1

                        ElseIf item.Text = "Peça irrecuperável" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text * ((TrackBar1.Value) / 100)
                            Dim MEY_0 As Decimal = item.Nodes(1).Text * ((TrackBar1.Value) / 100)

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Peça irrecuperável_" & PeçasIrre, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            PeçasIrre += 1

                        ElseIf item.Text = "Corrosão" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Corrosão_" & Corrosão, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Corrosão += 1

                            Next

                        ElseIf item.Text = "Delaminação" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Delaminação_" & Delaminação, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Delaminação += 1

                            Next

                        ElseIf item.Text = "Desgaste" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Desgaste_" & Desgaste, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Desgaste += 1

                            Next

                        ElseIf item.Text = "Trinco" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Trinco_" & Trinco, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Trinco += 1

                            Next

                        ElseIf item.Text = "Delaminação vidro" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Delaminação vidro_" & DelaminaçãoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                DelaminaçãoVidro += 1

                            Next

                        ElseIf item.Text = "Quebrado" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Vidro quebrado_" & QuebradoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            QuebradoVidro += 1

                        ElseIf item.Text = "Rasgado" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Rasgado_" & Rasgado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Rasgado += 1

                            Next

                        ElseIf item.Text = "Desgaste acab." Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Desegaste Acab. _" & DesgasteAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                DesgasteAcab += 1

                            Next

                        ElseIf item.Text = "Quebrado acab." Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Acab. Quebrado_" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            QuebradoAcab += 1

                        ElseIf item.Text = "Risco acab." Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Risco avab." & RiscoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                RiscoAcab += 1

                            Next

                        ElseIf item.Text = "Mancha" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Mancha_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Mancha += 1

                            Next

                        ElseIf item.Text = "Inoperante" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Inoperante_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            Inoperante += 1

                        ElseIf item.Text = "Falha" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Falha_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            falha += 1

                        End If
                    Else
                        If item.Text = "Risco" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 70, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 70, 15)

                                Pintura2.DrawString("Risco_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Riscos += 1

                            Next

                        ElseIf item.Text = "Amassado" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Amassado_" & amassado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                amassado += 1

                            Next

                        ElseIf item.Text = "Peça ausente" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text * ((TrackBar1.Value) / 100)
                            Dim MEY_0 As Decimal = item.Nodes(1).Text * ((TrackBar1.Value) / 100)

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Peça ausente_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            Peças += 1

                        ElseIf item.Text = "Peça irrecuperável" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text * ((TrackBar1.Value) / 100)
                            Dim MEY_0 As Decimal = item.Nodes(1).Text * ((TrackBar1.Value) / 100)

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Peça irrecuperável_" & PeçasIrre, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            PeçasIrre += 1

                        ElseIf item.Text = "Corrosão" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Corrosão_" & Corrosão, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Corrosão += 1

                            Next

                        ElseIf item.Text = "Delaminação" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Delaminação_" & Delaminação, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Delaminação += 1

                            Next

                        ElseIf item.Text = "Desgaste" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Desgaste_" & Desgaste, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Desgaste += 1

                            Next

                        ElseIf item.Text = "Trinco" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Trinco_" & Trinco, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Trinco += 1

                            Next

                        ElseIf item.Text = "Delaminação vidro" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Delaminação vidro_" & DelaminaçãoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                DelaminaçãoVidro += 1

                            Next

                        ElseIf item.Text = "Quebrado" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Vidro quebrado_" & QuebradoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            QuebradoVidro += 1

                        ElseIf item.Text = "Rasgado" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Rasgado_" & Rasgado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Rasgado += 1

                            Next

                        ElseIf item.Text = "Desgaste acab." Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Desegaste Acab. _" & DesgasteAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                DesgasteAcab += 1

                            Next

                        ElseIf item.Text = "Quebrado acab." Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Acab. Quebrado_" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            QuebradoAcab += 1

                        ElseIf item.Text = "Risco acab." Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Risco avab." & RiscoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                RiscoAcab += 1

                            Next

                        ElseIf item.Text = "Mancha" Then

                            Dim MEX As Integer = item.Nodes(1).Text
                            Dim MEY As Integer = item.Nodes(3).Text

                            Dim MEX_e As Integer = item.Nodes(0).Text
                            Dim MEY_e As Integer = item.Nodes(2).Text

                            For Each tr As TreeNode In item.Nodes(4).Nodes

                                Dim MEX_0 As Decimal = tr.Nodes(1).Text
                                Dim MEY_0 As Decimal = tr.Nodes(2).Text

                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                                Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                                Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                                Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                                Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                                Pintura2.DrawString("Mancha_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                                Mancha += 1

                            Next

                        ElseIf item.Text = "Inoperante" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Inoperante_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            Inoperante += 1

                        ElseIf item.Text = "Falha" Then

                            Dim MEX_0 As Decimal = item.Nodes(0).Text
                            Dim MEY_0 As Decimal = item.Nodes(1).Text

                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                            Pintura2.DrawLine(New Pen(New SolidBrush(Color.Purple), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                            Pintura2.FillEllipse(New SolidBrush(Color.Purple), MEX_0 - 2, MEY_0 - 2, 2, 2)
                            Pintura2.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                            Pintura2.DrawRectangle(New Pen(New SolidBrush(Color.Purple), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                            Pintura2.DrawString("Falha_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                            falha += 1

                        End If

                    End If

                Next

                Me.Cursor = Cursors.WaitCursor

                PicImagem.Image = PintarBitmap2

            Else

                PicLoad.Visible = False
                PicLoad2.Visible = False

                Me.Cursor = Cursors.Arrow

                PicImagem.Image = Nothing

            End If

        Else

            PicLoad.Visible = False
            PicLoad2.Visible = False

            Me.Cursor = Cursors.Arrow

            PicImagem.Image = Nothing

        End If

    End Sub

    Dim LqComercial As New LqComercialDataContext
    Dim LqFinanceiro As New LqFinanceiroDataContext

    Private Sub BttConcluirAnalise_Click(sender As Object, e As EventArgs) Handles BttConcluirAnalise.Click

        'Atualiza desmonte

        LqOficina.AtualizaEncerraVistoriaVeiculo(LblIdSolução.Text, Now.TimeOfDay, Today.Date, True)

        'insere novo orçamento

        LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, 0, "1111/11/11", Today.TimeOfDay, Today.Date, Now.TimeOfDay, _IdCliente, _IdVeiculo, False, "1111/11/11", Today.TimeOfDay, 0, LblIdSolução.Text, 0, 0, False, False, 0, "1111-11-11")

        'insere itens pertencentes ao orçamento

        Dim buscaSolução = From sol In LqOficina.SoluçõesVistoria
                           Where sol.IdProcesso = LblIdSolução.Text
                           Select sol.IdSolucoes

        For Each row In buscaSolução.ToList

            Dim BUscaItens = From it In LqOficina.ItensSoluçãoN
                             Where it.IdSolucao = row
                             Select it.Qt, it.idsolicitacao, it.IdProduto

            For Each row1 In BUscaItens.ToList

                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                     Select orc.IdOrcamento

                LqComercial.InsereNovoItemOrcamento(row1.idsolicitacao, row1.IdProduto, BuscaOrçamento.First, row1.Qt, 1, 0, 0, Today.Date, True, LblIdSolução.Text, 0)

                'verifica se item necessita de cotação imediata

                If row1.idsolicitacao > 0 Then

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, row1.idsolicitacao, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, row1.Qt, 0, 0)

                Else

                    'verifica se item possui estoque

                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, 0, row1.IdProduto, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, row1.Qt, 0, 0)

                End If

            Next


        Next

            FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged

    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

        LblValZoom.Text = TrackBar1.Value & "%"

        PicImagem.Location = New Point(0, 0)

        PicImagem.Size = New Size((ValueX * TrackBar1.Value) / 100, (ValueY * TrackBar1.Value) / 100)

        PicImagem.Image = Nothing

        If (PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2) > 0 Then
            If (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2) > 0 Then
                PicImagem.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2), (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2))
            Else
                PicImagem.Location = New Point((PnnAreaTrabalho.Width / 2) - (PicImagem.Width / 2), 0)
            End If
        Else
            If (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2) > 0 Then
                PicImagem.Location = New Point(0, (PnnAreaTrabalho.Height / 2) - (PicImagem.Height / 2))
            Else
                PicImagem.Location = New Point(0, 0)
            End If
        End If

        DesnhaMarcaçõesZoom()

        Me.Cursor = Cursors.Arrow

    End Sub

End Class