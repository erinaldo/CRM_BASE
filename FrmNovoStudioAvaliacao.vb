Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNovoStudioAvaliacao

    Dim ofd1 As New OpenFileDialog

    Public TrParentSel As Integer

    'Public Sub PublicaTreeview()

    '    Dim SemAnalise As Integer
    '    Dim IDProcesso As Integer = LblProcesso.Text

    '    If Zero = True Then

    '        Dim ValorContatoGeral As Decimal

    '        Zero = False

    '        TrRespostashecklist.Nodes.Clear()

    '        'FrmCarregarDesmonte.Show(Me)
    '        Dim BuscaRespostaUsuario = From resp In LqOficina.RespostasCheklistUsuario
    '                                   Where resp.IdProesso = IDProcesso
    '                                   Select resp.descricao, resp.IdPergunta, resp.IdRespostaChecklist

    '        ValorContatoGeral = 100 / BuscaRespostaUsuario.Count

    '        Dim C1 As Integer

    '        Dim Pct As Decimal = 0

    '        For Each row In BuscaRespostaUsuario.ToList

    '            'FrmCarregarDesmonte.DtItensBDD.Rows.Add(FrmCarregarDesmonte.ImageList1.Images(3), "", "Carregando dados")
    '            'FrmCarregarDesmonte.DtItensBDD.CurrentCell = FrmCarregarDesmonte.DtItensBDD(0, FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1)

    '            '                FrmCarregarDesmonte.DtItensBDD.Refresh()

    '            C1 += 1

    '            'Busca se reposta entra na avaliação

    '            Dim buscaPergunta = From pg In LqOficina.PerguntasChecklist
    '                                Where pg.UsoResposta = True And pg.IdPerguntaChecklit = row.IdPergunta
    '                                Select pg.Titulo, pg.IdPerguntaChecklit

    '            If buscaPergunta.Count > 0 Then

    '                'FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(2)
    '                'FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(1).Value = buscaPergunta.First
    '                'FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Iniciando pergunta " & C1 & " de " & BuscaRespostaUsuario.Count

    '                'FrmCarregarDesmonte.DtItensBDD.Refresh()

    '                'devera buscar imagens

    '                Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
    '                                   Where img.IdRespostaUsuario = row.IdRespostaChecklist And img.IdProcesso = IDProcesso
    '                                   Select img.Imagem, img.IdImagemProcesso

    '                'varre imagens

    '                'FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem 0 de " & buscaImagens.Count

    '                'FrmCarregarDesmonte.Refresh()

    '                Dim C As Integer = 0

    '                For Each row1 In buscaImagens.ToList

    '                    Dim Fração1 As Decimal = ValorContatoGeral / buscaImagens.Count

    '                    C += 1


    '                    TrRespostashecklist.Nodes.Add(row1.IdImagemProcesso)

    '                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(0)
    '                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(0 + (180 * (TrRespostashecklist.Nodes.Count - 1)))
    '                    TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add("MK")

    '                    TrParentSel = TrRespostashecklist.Nodes.Count - 1

    '                    'busca marcações

    '                    Dim BuscaMarcações = From mark In LqOficina.MarcasImagens
    '                                         Where mark.IdImagem = row1.IdImagemProcesso
    '                                         Select mark.IdMarcaImagem, mark.descricao, mark.X, mark.Y

    '                    For Each row2 In BuscaMarcações.ToList

    '                        Dim Fração2 As Decimal = Fração1 / BuscaMarcações.Count

    '                        Pct += Fração2

    '                        FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"


    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add(row2.descricao)
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
    '                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("red")

    '                        PintaMk()

    '                        Dim NodeXY As TreeNode = TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes(2).Nodes.Count - 1).Nodes.Count - 1)

    '                        NodeXY.Nodes.Add((row2.X * 90) / 100)
    '                        NodeXY.Nodes.Add(((row2.Y * 90) / 100) - 15)
    '                        NodeXY.Nodes.Add(row2.IdMarcaImagem)

    '                        'busca solução

    '                        Dim BuscaSol = From sol In LqOficina.SoluçõesVistoria
    '                                       Where sol.IdMarca = row2.IdMarcaImagem
    '                                       Select sol.IdSolucoes

    '                        If BuscaSol.Count > 0 Then
    '                            NodeXY.Nodes.Add(BuscaSol.First)
    '                        Else
    '                            NodeXY.Nodes.Add(0)
    '                            SemAnalise += 1
    '                        End If
    '                        FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem " & C & " de " & buscaImagens.Count
    '                        FrmCarregarDesmonte.Refresh()

    '                    Next

    '                    If BuscaMarcações.Count = 0 Then

    '                        Pct += Fração1

    '                        FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"

    '                    End If

    '                Next

    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(0)
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Finalizado " & C1 & " de " & BuscaRespostaUsuario.Count
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = ""

    '                If buscaImagens.Count = 0 Then

    '                    Pct += ValorContatoGeral

    '                    FrmCarregarDesmonte.LblPorcentagem.Text = FormatNumber(Pct, NumDigitsAfterDecimal:=2) & " %"

    '                End If

    '                FrmCarregarDesmonte.DtItensBDD.Refresh()

    '            End If

    '        Next

    '        FrmCarregarDesmonte.Refresh()

    '        If SemAnalise > 0 Then

    '            BttConcluirAnalise.Enabled = False

    '        Else

    '            BttConcluirAnalise.Enabled = True

    '        End If

    '        If TrRespostashecklist.Nodes.Count > 0 Then
    '            TrRespostashecklist.SelectedNode = TrRespostashecklist.Nodes(0)
    '            _idTrSel = TrRespostashecklist.SelectedNode.Index
    '        End If

    '        FrmCarregarDesmonte.Close()

    '    Else


    '        FrmCarregarDesmonte.Show(Me)
    '        Dim BuscaRespostaUsuario = From resp In LqOficina.RespostasCheklistUsuario
    '                                   Where resp.IdRespostaChecklist = IDRepsosta
    '                                   Select resp.descricao, resp.IdPergunta, resp.IdRespostaChecklist

    '        Dim C1 As Integer
    '        For Each row In BuscaRespostaUsuario.ToList

    '            FrmCarregarDesmonte.DtItensBDD.Rows.Add(FrmCarregarDesmonte.ImageList1.Images(3), "", "Carregando dados")
    '            FrmCarregarDesmonte.DtItensBDD.CurrentCell = FrmCarregarDesmonte.DtItensBDD(0, FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1)

    '            FrmCarregarDesmonte.DtItensBDD.Refresh()

    '            C1 += 1

    '            'Busca se reposta entra na avaliação

    '            Dim buscaPergunta = From pg In LqOficina.PerguntasChecklist
    '                                Where pg.UsoResposta = True And pg.IdPerguntaChecklit = row.IdPergunta
    '                                Select pg.Titulo, pg.IdPerguntaChecklit

    '            If buscaPergunta.Count > 0 Then

    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(2)
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(1).Value = buscaPergunta.First
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Iniciando pergunta " & C1 & " de " & BuscaRespostaUsuario.Count

    '                FrmCarregarDesmonte.DtItensBDD.Refresh()

    '                TrRespostashecklist.Nodes(_idTrSel).Nodes.Clear()
    '                TrRespostashecklist.Nodes(_idTrSel).Nodes.Add(buscaPergunta.First.Titulo)
    '                TrRespostashecklist.Nodes(_idTrSel).Nodes.Add(row.IdRespostaChecklist)
    '                TrRespostashecklist.Nodes(_idTrSel).Nodes.Add("ImgKey")

    '                'devera buscar imagens

    '                Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
    '                                   Where img.IdRespostaUsuario = row.IdRespostaChecklist And img.IdProcesso = IDProcesso
    '                                   Select img.Imagem, img.IdImagemProcesso

    '                'varre imagens

    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem 0 de " & buscaImagens.Count

    '                FrmCarregarDesmonte.Refresh()

    '                Dim C As Integer = 0

    '                For Each row1 In buscaImagens.ToList

    '                    C += 1

    '                    TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Add(row1.IdImagemProcesso)

    '                    'busca marcações

    '                    Dim BuscaMarcações = From mark In LqOficina.MarcasImagens
    '                                         Where mark.IdImagem = row1.IdImagemProcesso
    '                                         Select mark.IdMarcaImagem, mark.descricao, mark.X, mark.Y


    '                    For Each row2 In BuscaMarcações.ToList

    '                        TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes.Add(row2.descricao)

    '                        Dim NodeXY As TreeNode = TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(_idTrSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1)

    '                        NodeXY.Nodes.Add((row2.X * 90) / 100)
    '                        NodeXY.Nodes.Add(((row2.Y * 90) / 100) - 15)
    '                        NodeXY.Nodes.Add(row2.IdMarcaImagem)

    '                        'busca solução

    '                        Dim BuscaSol = From sol In LqOficina.SoluçõesVistoria
    '                                       Where sol.IdMarca = row2.IdMarcaImagem
    '                                       Select sol.IdSolucoes

    '                        If BuscaSol.Count > 0 Then
    '                            NodeXY.Nodes.Add(BuscaSol.First)
    '                        Else
    '                            NodeXY.Nodes.Add(0)
    '                            SemAnalise += 1
    '                        End If
    '                        FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = "Lendo imagem " & C & " de " & buscaImagens.Count
    '                        FrmCarregarDesmonte.Refresh()

    '                    Next

    '                Next

    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(0).Value = FrmCarregarDesmonte.ImageList1.Images(0)
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(2).Value = "Finalizado " & C1 & " de " & BuscaRespostaUsuario.Count
    '                FrmCarregarDesmonte.DtItensBDD.Rows(FrmCarregarDesmonte.DtItensBDD.Rows.Count - 1).Cells(3).Value = ""

    '                FrmCarregarDesmonte.DtItensBDD.Refresh()

    '            End If

    '        Next

    '        FrmCarregarDesmonte.Close()

    '        If SemAnalise > 0 Then

    '            BttConcluirAnalise.Enabled = False

    '        Else

    '            BttConcluirAnalise.Enabled = True

    '        End If

    '        If TrRespostashecklist.Nodes.Count > 0 Then
    '            TrRespostashecklist.SelectedNode = TrRespostashecklist.Nodes(_idTrSel)
    '            'DesnhaMarcaçõesZoom()
    '        End If

    '    End If

    'End Sub

    Public SelText As String

    Public IdVeiculo As Integer

    Dim LstListaPulicada As New ListBox
    Dim LstYPub As New ListBox

    Public Sub DesenhaMiniatura()

        LstListaPulicada.Items.Clear()
        LstYPub.Items.Clear()

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If TrRespostashecklist.Nodes.Count = 0 Then

            'desenha imagens

            Dim PintarBitmap1 = New Bitmap(220, 128)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Diminuir As Decimal = 100

            Dim ValX As Decimal = (PicSel.Width)
            Dim ValY As Decimal = (PicSel.Height)

            While ValX > 150 Or ValY > 80
                ValX = PicSel.Width * (Diminuir / 100)
                ValY = PicSel.Height * (Diminuir / 100)
                Diminuir -= 1
            End While

            Pintura1.DrawImage(PicSel, 90 - (ValX / 2), 55 - (ValY / 2) + 10, ValX, ValY)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 0, 215, 20)
            Pintura1.DrawString(SelText, New Font("CAlibri", 8), New SolidBrush(Color.DarkSlateGray), 5, 5)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 115, 215, 2)


            PicLocalizadas.BackgroundImage = PintarBitmap1

        Else

            'desenha imagens

            Dim PintarBitmap1 = New Bitmap(220, (128 * (TrRespostashecklist.Nodes.Count)) + 128)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Diminuir As Decimal = 100

            Dim ValX As Decimal = (PicSel.Width)
            Dim ValY As Decimal = (PicSel.Height)

            While ValX > 150 Or ValY > 80
                ValX = PicSel.Width * (Diminuir / 100)
                ValY = PicSel.Height * (Diminuir / 100)
                Diminuir -= 1
            End While

            Pintura1.DrawImage(PicSel, 90 - (ValX / 2), 55 - (ValY / 2) + 10, ValX, ValY)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 0, 215, 20)
            Pintura1.DrawString(SelText, New Font("CAlibri", 8), New SolidBrush(Color.DarkSlateGray), 5, 5)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 115, 215, 2)

            Dim Desenhado As Integer = 0

            Dim Tamanho_C As Integer = 128
            Dim Y As Integer = Tamanho_C

            For Each row As TreeNode In TrRespostashecklist.Nodes

                Dim X As Integer = 2
                Dim Filename As String = row.Text

                Dim Cat As String = row.Nodes(4).Text

                If Cat = SelText Then

                    If Not Filename.StartsWith("+") Then

                        'inserechart

                        Dim Str_id As Integer = Filename

                        Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                           Where img.IdImagemProcesso = Str_id
                                           Select img.Imagem, img.IdImagemProcesso

                        'varre imagens

                        Dim arrImage() As Byte
                        Dim myMS As New IO.MemoryStream
                        arrImage = buscaImagens.First.Imagem.ToArray

                        For Each ar As Byte In arrImage
                            myMS.WriteByte(ar)
                        Next

                        'define o tamanho da imagem 

                        Pintura1.DrawImage(System.Drawing.Image.FromStream(myMS), X + 5, Y, 190, 123)

                        myMS.Dispose()

                    ElseIf Filename.StartsWith("+") Then

                        Filename = Filename.Remove(0, 1)

                        Pintura1.DrawImage(System.Drawing.Image.FromFile(Filename), X + 5, Y, 190, 123)

                    End If

                    If row.Index = TrParentSel Then
                        Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 2), X + 5, Y, 190, 123)
                        'desenha informativos do veiculo
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), X + 143 + 10, Y, 30, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 145 + 10, Y, 30, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X + 173 + 10, Y, 2, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), X + 143 + 10, Y + 50, 30, 123 - 50)

                        Pintura1.DrawImage(My.Resources.iconfinder_trash_4341321_120557, X + 146 + 10, Y + 5, 28, 28)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 52, 30, 20)
                        Pintura1.DrawImage(My.Resources.alert_icon_icons_com_52395, X + 147 + 10, Y + 55, 10, 10)
                        Pintura1.DrawString(row.Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 53.5)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 77, 30, 20)
                        Pintura1.DrawString(row.Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 78.5)
                        Pintura1.DrawImage(My.Resources.check_ok_accept_apply_1582, X + 147 + 10, Y + 80, 10, 10)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 103, 30, 17)
                        Pintura1.DrawString(row.Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 103.5)
                        Pintura1.DrawImage(My.Resources.Delete_80_icon_icons_com_57340, X + 147 + 10, Y + 106, 10, 10)


                    Else
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.DarkSlateGray)), X + 5, Y, 190, 123)
                        Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 2), X + 5, Y, 190, 123)
                    End If

                    LstListaPulicada.Items.Add(row.Index)
                    LstYPub.Items.Add(Y)

                    Y += 130

                End If

            Next

            If LstListaPulicada.Items.Count > 0 Then

                If TrParentSel = -1 Then

                    PintaA = True
                    TrParentSel = LstListaPulicada.Items(0).ToString

                End If

            End If

            If LstListaPulicada.Items.Count > 3 Then

                If _IdSelNode > 0 Then

                    Pintura1.DrawImage(My.Resources.arrow_up_16741, 82, 120, 15, 15)

                End If

                If _IdSelNode + 3 <= TrRespostashecklist.Nodes.Count - 1 Then
                    Pintura1.DrawImage(My.Resources.arrow_down_16740, 82, PicLocalizadas.Height - 45, 15, 15)
                End If

            End If

            PicLocalizadas.BackgroundImage = PintarBitmap1

            'TrRespostashecklist.Visible = False

        End If

        If PintaA = True Then

            PintaAgain()

        End If

        VerificaContagem()

    End Sub

    Public Sub VerificaContagem()

        Dim Dianteira As Integer = 0
        Dim Traseira As Integer = 0
        Dim LE As Integer = 0
        Dim LD As Integer = 0
        Dim Interior As Integer = 0
        Dim PM As Integer = 0

        Dim F_Parachoque As Integer = 0
        Dim F_Capo As Integer = 0
        Dim F_Ilumiação As Integer = 0
        Dim F_Parabrisas As Integer = 0
        Dim F_retrovisores As Integer = 0
        Dim F_Acabamentos As Integer = 0

        Dim T_Parachoque As Integer = 0
        Dim T_Tampatraseira As Integer = 0
        Dim T_Ilumiação As Integer = 0
        Dim T_Acabamentos As Integer = 0
        Dim T_Vidrotraseiro As Integer = 0

        Dim PortasEsq As Integer = 0
        Dim JanelasEsq As Integer = 0
        Dim EstruturaEsq As Integer = 0
        Dim ParalamasEsq As Integer = 0
        Dim PneusEsq As Integer = 0
        Dim RodasEsq As Integer = 0
        Dim AcabamentoEsq As Integer = 0

        Dim PortasDir As Integer = 0
        Dim JanelasDir As Integer = 0
        Dim EstruturaDir As Integer = 0
        Dim ParalamasDir As Integer = 0
        Dim PneusDir As Integer = 0
        Dim RodasDir As Integer = 0
        Dim AcabamentoDir As Integer = 0

        Dim AcabamentoPorta As Integer = 0
        Dim Bancos As Integer = 0
        Dim Console As Integer = 0
        Dim DireçãoComandos As Integer = 0
        Dim Painel As Integer = 0
        Dim PortaMalas As Integer = 0

        Dim Acessorios As Integer = 0
        Dim Amortecedores As Integer = 0
        Dim PartesEletricas As Integer = 0
        Dim SisExaustao As Integer = 0
        Dim SisFrenagem As Integer = 0
        Dim Tracionamento As Integer = 0
        Dim Estepe As Integer = 0
        Dim Lubrificantes As Integer = 0
        Dim PartesMecanicas As Integer = 0

        For Each row As TreeNode In TrRespostashecklist.Nodes

            If row.Nodes(3).Text = "Dianteira" Then

                Dianteira += 1

                'verifica as categorias
                If row.Nodes(4).Text = "F.Parachoque" Then
                    F_Parachoque = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "F.Capô" Then
                    F_Capo = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "F.Iluminação" Then
                    F_Ilumiação = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "F.Parabrisas" Then
                    F_Parabrisas = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Retrovisores" Then
                    F_retrovisores = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Acabamentos" Then
                    F_Acabamentos = row.Nodes(2).Nodes.Count
                End If

            ElseIf row.Nodes(3).Text = "Traseira" Then
                Traseira += 1

                If row.Nodes(4).Text = "T.Parachoque" Then
                    T_Parachoque = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "T.Tampa traseira" Then
                    T_Tampatraseira = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "T.Iluminação" Then
                    T_Ilumiação = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Acabamentos" Then
                    T_Acabamentos = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Vidro traseira" Then
                    T_Vidrotraseiro = row.Nodes(2).Nodes.Count
                End If

            ElseIf row.Nodes(3).Text = "Lateral esquerda" Then
                LE += 1

                If row.Nodes(4).Text = "L.E.Portas" Then
                    PortasEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Vidros" Then
                    JanelasEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Estruturas" Then
                    EstruturaEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Paralamas" Then
                    ParalamasEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Pneus" Then
                    PneusEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Rodas" Then
                    RodasEsq = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.E.Acabamentos" Then
                    AcabamentoEsq = row.Nodes(2).Nodes.Count
                End If

            ElseIf row.Nodes(3).Text = "Lateral direita" Then
                LD += 1

                If row.Nodes(4).Text = "L.D.Portas" Then
                    PortasDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Vidros" Then
                    JanelasDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Estruturas" Then
                    EstruturaDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Paralamas" Then
                    ParalamasDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Pneus" Then
                    PneusDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Rodas" Then
                    RodasDir = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "L.D.Acabamentos" Then
                    AcabamentoDir = row.Nodes(2).Nodes.Count
                End If

            ElseIf row.Nodes(3).Text = "Interior" Then
                Interior += 1

                If row.Nodes(4).Text = "Acab. das Portas" Then
                    AcabamentoPorta = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Bancos" Then
                    Bancos = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Console" Then
                    Console = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Direção e comandos" Then
                    DireçãoComandos = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Painel" Then
                    Painel = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Porta malas" Then
                    PortaMalas = row.Nodes(2).Nodes.Count
                End If

            ElseIf row.Nodes(3).Text = "Partes mecânicas" Then
                PM += 1

                If row.Nodes(4).Text = "Acessórios" Then
                    Acessorios = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Amortecedores" Then
                    Amortecedores = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Partes elétricas" Then
                    PartesEletricas = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Sis. Exaustão" Then
                    SisExaustao = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Sis. Frenagem" Then
                    SisFrenagem = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Tracionamento e aliment." Then
                    Tracionamento = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Estepe" Then
                    Estepe = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Sis. Lubrificação" Then
                    Lubrificantes = row.Nodes(2).Nodes.Count
                ElseIf row.Nodes(4).Text = "Partes mecânicas" Then
                    PartesMecanicas = row.Nodes(2).Nodes.Count
                End If

            End If

        Next

        LblFrontal.Text = "Avaliações.: " & Dianteira
        If Dianteira = 0 Then
            LblFrontal.Text = ""
        End If

        LblTraseira.Text = "Avaliações.: " & Traseira
        If Traseira = 0 Then
            LblTraseira.Text = ""
        End If

        LblLatEsq.Text = "Avaliações.: " & LE
        If LE = 0 Then
            LblLatEsq.Text = ""
        End If

        LblLatDir.Text = "Avaliações.: " & LD
        If LD = 0 Then
            LblLatDir.Text = ""
        End If

        LblInterior.Text = "Avaliações.: " & Interior
        If Interior = 0 Then
            LblInterior.Text = ""
        End If

        LblPm.Text = "Avaliações.: " & PM
        If PM = 0 Then
            LblPm.Text = ""
        End If


        If Carregado = False Then
            BttCarregar.PerformClick()
        End If
    End Sub

    Public Sub DesenhaMiniatura2()

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If TrRespostashecklist.Nodes.Count = 0 Then

            'desenha imagens

            Dim PintarBitmap1 = New Bitmap(220, 128)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Diminuir As Decimal = 100

            Dim ValX As Decimal = (PicSel.Width)
            Dim ValY As Decimal = (PicSel.Height)

            While ValX > 150 Or ValY > 80
                ValX = PicSel.Width * (Diminuir / 100)
                ValY = PicSel.Height * (Diminuir / 100)
                Diminuir -= 1
            End While

            Pintura1.DrawImage(PicSel, 90 - (ValX / 2), 55 - (ValY / 2) + 10, ValX, ValY)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 0, 215, 20)
            Pintura1.DrawString(SelText, New Font("CAlibri", 8), New SolidBrush(Color.DarkSlateGray), 5, 5)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 115, 215, 2)


            PicLocalizadas.BackgroundImage = PintarBitmap1

        Else

            'desenha imagens

            Dim PintarBitmap1 = New Bitmap(220, (128 * (TrRespostashecklist.Nodes.Count)) + 128)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Diminuir As Decimal = 100

            Dim ValX As Decimal = (PicSel.Width)
            Dim ValY As Decimal = (PicSel.Height)

            While ValX > 150 Or ValY > 80
                ValX = PicSel.Width * (Diminuir / 100)
                ValY = PicSel.Height * (Diminuir / 100)
                Diminuir -= 1
            End While

            Pintura1.DrawImage(PicSel, 90 - (ValX / 2), 55 - (ValY / 2) + 10, ValX, ValY)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 0, 215, 20)
            Pintura1.DrawString(SelText, New Font("CAlibri", 8), New SolidBrush(Color.DarkSlateGray), 5, 5)
            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 0, 115, 215, 2)

            Dim Desenhado As Integer = 0

            Dim Tamanho_C As Integer = 128
            Dim Y As Integer = Tamanho_C

            For i_index As Integer = 0 To LstListaPulicada.Items.Count - 1

                Dim i As Integer = LstListaPulicada.Items(i_index).ToString
                Dim X As Integer = 2
                Dim Filename As String = TrRespostashecklist.Nodes(i).Text

                Dim Cat As String = TrRespostashecklist.Nodes(i).Nodes(4).Text

                If Cat = SelText Then

                    If Not Filename.StartsWith("+") Then

                        'inserechart

                        Dim Str_id As Integer = Filename

                        Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                           Where img.IdImagemProcesso = Str_id
                                           Select img.Imagem, img.IdImagemProcesso

                        'varre imagens

                        Dim arrImage() As Byte
                        Dim myMS As New IO.MemoryStream
                        arrImage = buscaImagens.First.Imagem.ToArray

                        For Each ar As Byte In arrImage
                            myMS.WriteByte(ar)
                        Next

                        'define o tamanho da imagem 

                        Pintura1.DrawImage(System.Drawing.Image.FromStream(myMS), X + 5, Y, 190, 123)

                        myMS.Dispose()

                    ElseIf Filename.StartsWith("+") Then

                        Filename = Filename.Remove(0, 1)

                        Pintura1.DrawImage(System.Drawing.Image.FromFile(Filename), X + 5, Y, 190, 123)

                    End If

                    If i = TrParentSel Then
                        Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 2), X + 5, Y, 190, 123)
                        'desenha informativos do veiculo
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), X + 143 + 10, Y, 30, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 145 + 10, Y, 30, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X + 173 + 10, Y, 2, 123)
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), X + 143 + 10, Y + 50, 30, 123 - 50)

                        Pintura1.DrawImage(My.Resources.iconfinder_trash_4341321_120557, X + 146 + 10, Y + 5, 28, 28)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 52, 30, 20)
                        Pintura1.DrawImage(My.Resources.alert_icon_icons_com_52395, X + 147 + 10, Y + 55, 10, 10)
                        Pintura1.DrawString(TrRespostashecklist.Nodes(i).Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 53.5)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 77, 30, 20)
                        Pintura1.DrawString(TrRespostashecklist.Nodes(i).Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 78.5)
                        Pintura1.DrawImage(My.Resources.check_ok_accept_apply_1582, X + 147 + 10, Y + 80, 10, 10)

                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.WhiteSmoke)), X + 143 + 10, Y + 103, 30, 17)
                        Pintura1.DrawString(TrRespostashecklist.Nodes(i).Nodes(2).Nodes.Count, New Font("Calibri", 9), New SolidBrush(Color.DarkSlateGray), X + 147 + 12 + 10, Y + 103.5)
                        Pintura1.DrawImage(My.Resources.Delete_80_icon_icons_com_57340, X + 147 + 10, Y + 106, 10, 10)


                    Else
                        Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.DarkSlateGray)), X + 5, Y, 190, 123)
                        Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 2), X + 5, Y, 190, 123)
                    End If

                    Y += 130

                End If

            Next

            If LstListaPulicada.Items.Count > 3 Then

                If _IdSelNode > 0 Then

                    Pintura1.DrawImage(My.Resources.arrow_up_16741, 82, 120, 15, 15)

                End If

                If _IdSelNode + 3 <= TrRespostashecklist.Nodes.Count - 1 Then
                    Pintura1.DrawImage(My.Resources.arrow_down_16740, 82, PicLocalizadas.Height - 45, 15, 15)
                End If

            End If

            PicLocalizadas.BackgroundImage = PintarBitmap1

            'TrRespostashecklist.Visible = False

        End If

        PintaMk()

    End Sub

    Dim PintaA As Boolean = False

    Public Sub PintaAgain()

        PintaA = False

        DesenhaMiniatura2()

    End Sub

    Public _IdVeiculo As Integer
    Public _IdCliente As Integer
    Public _Placa As String
    Public _idModeloVeic As Integer

    Dim LqOficina As New LqOficinaDataContext

    Public _idTrSel As Integer

    Dim Zero As Boolean = True

    Dim IDRepsosta As Integer

    Private Sub ManchaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManchaToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Acabamentos - Manchas")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("sienna")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Points")

        PintaMk()

    End Sub

    Private Sub PicImagem_Click(sender As Object, e As EventArgs) Handles PicImagem.Click


    End Sub

    Dim _Mx As Integer
    Dim _My As Integer

    Dim LqBase As New DtCadastroDataContext

    Private Sub PicImagem_MouseClick(sender As Object, e As MouseEventArgs) Handles PicImagem.MouseClick

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TrRespostashecklist.Nodes.Count > 0 Then

            If Selecionar = False Then

                If Press = False Then

                    If e.Button = MouseButtons.Right Then

                        ContextMenuStrip1.Show()

                    Else

                        PicImagem.Cursor = Cursors.Cross

                        If TipoRisco = "Line" Or TipoRisco = "Area" Then
                            Press = True
                        ElseIf TipoRisco = "Point" Then

                            If LblStagio.Text <> "" Then
                                'abre form d soluções

                                FrmSoluçãoNovoStudio.Show(Me)

                                FrmSoluçãoNovoStudio.LblCategoria.Text = SelPrincipal

                                'busca categoria 

                                Dim buscaCategoria = From cat In LqBase.CategoriasProdutos
                                                     Where cat.Descricao Like SelPrincipal
                                                     Select cat.IdCategoriaProduto

                                If buscaCategoria.Count > 0 Then
                                    FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria.First
                                Else
                                    'cdastra categoria

                                    LqBase.InsereCategoriaProduto(SelPrincipal)

                                    Dim buscaCategoria2 = From cat In LqBase.CategoriasProdutos
                                                          Where cat.Descricao Like SelPrincipal
                                                          Select cat.IdCategoriaProduto

                                    FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria2.First

                                End If

                                FrmSoluçãoNovoStudio.LblSubCategoria.Text = SelText

                                'busca categoria 

                                Dim buscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                                        Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                        Select cat.IdSubCategoria

                                If buscaSubCategoria.Count > 0 Then
                                    FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First
                                Else
                                    'cdastra categoria

                                    LqBase.InsereSubcategoriaProduto(FrmSoluçãoNovoStudio._IdCategoria, SelText)

                                    Dim buscaCategoria2 = From cat In LqBase.SubCategoriasProduto
                                                          Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                          Select cat.IdSubCategoria

                                    FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First

                                End If

                                'Busca Detalhamento dos itens

                                Dim BuscaDetalhes = From det In LqOficina.ItemsCatOficina
                                                    Where det.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria And det.IdSubCategoria = FrmSoluçãoNovoStudio._IdSubCategoria
                                                    Select det.Item, det.IdItemCatOficina

                                For Each it In BuscaDetalhes.ToList

                                    FrmSoluçãoNovoStudio.TrItens.Nodes.Add(it.Item)

                                    'Busca subitens

                                    Dim BuscaSubItem = From det In LqOficina.SubItemCat
                                                       Where det.IdItem = it.IdItemCatOficina
                                                       Select det.Descricao

                                    For Each it0 In BuscaSubItem.ToList

                                        FrmSoluçãoNovoStudio.TrItens.Nodes(FrmSoluçãoNovoStudio.TrItens.Nodes.Count - 1).Nodes.Add(it0)

                                    Next

                                Next

                                FrmSoluçãoNovoStudio.TrItens.ExpandAll()

                                FrmSoluçãoNovoStudio.PictureBox1.BackgroundImage = PicSel
                                FrmSoluçãoNovoStudio.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

                                'busca dados do veiculo

                                Dim NPlaca As String

                                NPlaca = _Placa.Replace("-", "")

                                Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                                   Where veic.Placa Like NPlaca
                                                   Select veic.Modelo, veic.Versao, veic.Fabricante, veic.IdVersao, veic.Cor, veic.AnoFab, veic.AnoMod, veic.IdModelo, veic.IdVeiculo

                                FrmSoluçãoNovoStudio._IdVersao = BuscaVeiculo.First.IdVersao
                                FrmSoluçãoNovoStudio._IdVeiculo = BuscaVeiculo.First.IdVeiculo
                                FrmSoluçãoNovoStudio._IdModVeic = BuscaVeiculo.First.IdModelo
                                FrmSoluçãoNovoStudio.LblFabricante.Text = BuscaVeiculo.First.Fabricante
                                FrmSoluçãoNovoStudio.LblModelo.Text = BuscaVeiculo.First.Modelo
                                FrmSoluçãoNovoStudio.LblCor.Text = BuscaVeiculo.First.Cor
                                FrmSoluçãoNovoStudio.LblAnoFab.Text = BuscaVeiculo.First.AnoFab
                                FrmSoluçãoNovoStudio.LblAnoMod.Text = BuscaVeiculo.First.AnoMod

                                'bsca versao

                                Dim buscaVersao = From ver In LqOficina.VersaoModelos
                                                  Where ver.Idversao = BuscaVeiculo.First.IdVersao
                                                  Select ver.Combustivel, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Versao

                                FrmSoluçãoNovoStudio.LblMotor.Text = FormatNumber(buscaVersao.First.Potencia, NumDigitsAfterDecimal:=1)
                                FrmSoluçãoNovoStudio.LblCombustível.Text = buscaVersao.First.Combustivel
                                FrmSoluçãoNovoStudio.LblCilindrada.Text = buscaVersao.First.Cilindrada
                                FrmSoluçãoNovoStudio.LblVersao.Text = buscaVersao.First.Versao
                                FrmSoluçãoNovoStudio.LblCambio.Text = buscaVersao.First.Cambio

                            End If

                        End If

                        FrmSoluçãoNovoStudio.CarregaLoad()

                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add(Ferramenta)
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("")
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add(TipoRisco)
                        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Points")

                        PintaMk()

                        DesenhaMiniatura2()

                    End If

                Else

                    'adiciona no pts

                    TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0).Nodes.Add(e.X)
                    TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0).Nodes.Add(e.Y)

                    PintaMk()

                End If

            Else

                'procura quem e o cidadão selecionado

                Dim H As Integer = 848
                Dim V As Integer = 548

                Dim PintarMark = New Bitmap(H, V)

                Dim PinturaMark = Graphics.FromImage(PintarMark)

                'varre marcações

                Dim _indexRemove As Integer = -1

                For Each row As TreeNode In TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes

                    'pinta marcação de acordo com o tamanho dos campos do point

                    Dim _Cor As Color = Color.FromName(row.Nodes(2).Text)

                    If row.Nodes(0).Nodes.Count = 2 Then

                        'desenha um circulo

                        Dim X_MK As Integer = row.Nodes(3).Nodes(0).Text
                        Dim Y_MK As Integer = row.Nodes(3).Nodes(1).Text

                        Y_MK += 5

                        If e.X >= X_MK + 20 + 4 And e.X <= X_MK + 20 + 4 + 160 Then

                            If e.Y >= Y_MK And e.Y <= Y_MK + 20 Then

                                'verifica borda

                                Dim corre As Integer = 0
                                Dim correY As Integer = 0

                                PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.WhiteSmoke)), X_MK, Y_MK - 6 + correY, 180, 20)

                                PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.DarkSlateGray), X_MK + 21 - 1 - corre, Y_MK - 1 + correY)
                                PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK + 8 - 6 - corre, Y_MK - 1 + correY, 14, 14)

                                PinturaMark.DrawImage(My.Resources.Cancel_40972, X_MK + 6 - 3 + 160 - corre, Y_MK - 3 + correY, 15, 15)

                                If LblStagio.Text <> "Avaliação inicial" Then
                                    PinturaMark.DrawImage(My.Resources.checklist_123014, X_MK + 6 - 3 + 140 - corre, Y_MK - 3 + correY, 15, 15)
                                End If

                                PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 2), X_MK - 1 - corre, Y_MK - 6 + 23 + correY, 180, 1)

                                'PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5, Y_MK - 5, 180, 20 + Arest)

                                If corre = 0 Then
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK, Y_MK, X_MK + 4 - corre, Y_MK)
                                Else
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK, Y_MK, X_MK + 4 - corre, Y_MK)
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK + 4 - corre, Y_MK, X_MK + 4 - corre, Y_MK + correY)
                                End If

                                Dim X As Integer = row.Nodes(0).Nodes(0).Text
                                Dim Y As Integer = row.Nodes(0).Nodes(1).Text

                                X -= 6
                                'Y += 5

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(240, Color.SlateGray)), X, Y - 6, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(240, Color.DarkSlateGray)), 1), X, Y - 6, 10, 10)

                                If e.X >= X_MK + 6 - 3 + 160 - corre And e.X <= X_MK + 6 - 3 + 160 - corre + 175 Then

                                    If MsgBox("Deseja realmente remover esta marcação?", vbYesNo + MsgBoxStyle.Information, "Remover marcação") = MsgBoxResult.Yes Then

                                        _indexRemove = row.Index

                                    End If

                                End If

                                If LblStagio.Text <> "Avaliação inicial" Then
                                    If e.X >= X_MK + 6 - 3 + 140 - corre And e.X <= X_MK + 6 - 3 + 140 - corre + 65 Then

                                        'abre form d soluções

                                        FrmSoluçãoNovoStudio.Show(Me)

                                        FrmSoluçãoNovoStudio.LblCategoria.Text = SelPrincipal

                                        'busca categoria 

                                        Dim buscaCategoria = From cat In LqBase.CategoriasProdutos
                                                             Where cat.Descricao Like SelPrincipal
                                                             Select cat.IdCategoriaProduto

                                        If buscaCategoria.Count > 0 Then
                                            FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria.First
                                        Else
                                            'cdastra categoria

                                            LqBase.InsereCategoriaProduto(SelPrincipal)

                                            Dim buscaCategoria2 = From cat In LqBase.CategoriasProdutos
                                                                  Where cat.Descricao Like SelPrincipal
                                                                  Select cat.IdCategoriaProduto

                                            FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria2.First

                                        End If

                                        FrmSoluçãoNovoStudio.LblSubCategoria.Text = SelText

                                        'busca categoria 

                                        Dim buscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                                                Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                                Select cat.IdSubCategoria

                                        If buscaSubCategoria.Count > 0 Then
                                            FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First
                                        Else
                                            'cdastra categoria

                                            LqBase.InsereSubcategoriaProduto(FrmSoluçãoNovoStudio._IdCategoria, SelText)

                                            Dim buscaCategoria2 = From cat In LqBase.SubCategoriasProduto
                                                                  Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                                  Select cat.IdSubCategoria

                                            FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First

                                        End If

                                        FrmSoluçãoNovoStudio.PictureBox1.BackgroundImage = PicSel
                                        FrmSoluçãoNovoStudio.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

                                        'busca dados do veiculo

                                        Dim NPlaca As String

                                        NPlaca = _Placa.Replace("-", "")

                                        Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                                           Where veic.Placa Like NPlaca
                                                           Select veic.Modelo, veic.Versao, veic.Fabricante, veic.IdVersao, veic.Cor, veic.AnoFab, veic.AnoMod, veic.IdModelo, veic.IdVeiculo

                                        FrmSoluçãoNovoStudio._IdVersao = BuscaVeiculo.First.IdVersao
                                        FrmSoluçãoNovoStudio._IdVeiculo = BuscaVeiculo.First.IdVeiculo
                                        FrmSoluçãoNovoStudio._IdModVeic = BuscaVeiculo.First.IdModelo
                                        FrmSoluçãoNovoStudio.LblFabricante.Text = BuscaVeiculo.First.Fabricante
                                        FrmSoluçãoNovoStudio.LblModelo.Text = BuscaVeiculo.First.Modelo
                                        FrmSoluçãoNovoStudio.LblCor.Text = BuscaVeiculo.First.Cor
                                        FrmSoluçãoNovoStudio.LblAnoFab.Text = BuscaVeiculo.First.AnoFab
                                        FrmSoluçãoNovoStudio.LblAnoMod.Text = BuscaVeiculo.First.AnoMod

                                        'bsca versao

                                        Dim buscaVersao = From ver In LqOficina.VersaoModelos
                                                          Where ver.Idversao = BuscaVeiculo.First.IdVersao
                                                          Select ver.Combustivel, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Versao

                                        FrmSoluçãoNovoStudio.LblMotor.Text = FormatNumber(buscaVersao.First.Potencia, NumDigitsAfterDecimal:=1)
                                        FrmSoluçãoNovoStudio.LblCombustível.Text = buscaVersao.First.Combustivel
                                        FrmSoluçãoNovoStudio.LblCilindrada.Text = buscaVersao.First.Cilindrada
                                        FrmSoluçãoNovoStudio.LblVersao.Text = buscaVersao.First.Versao
                                        FrmSoluçãoNovoStudio.LblCambio.Text = buscaVersao.First.Cambio

                                        FrmSoluçãoNovoStudio._IdModeloVeic = _idModeloVeic

                                        'busca fabricantes

                                        Dim BuscaFaricantes = From fab In LqBase.Fabricantes
                                                              Where fab.IdFabricante Like "*"
                                                              Select fab.Fabricante, fab.IdFabricante

                                        For Each row2 In BuscaFaricantes.ToList
                                            FrmSoluçãoNovoStudio.CmbFaricannte.Items.Add(row2.Fabricante)
                                        Next

                                        FrmSoluçãoNovoStudio.CmbFaricannte.Items.Add("-- Solicitações de cadastro --")

                                        'busca serviços

                                        Dim BuscaServiços = From serv In LqBase.Servicos
                                                            Where serv.IdCategoria = buscaCategoria.First And serv.IdSubCategoria = buscaSubCategoria.First
                                                            Select serv.Descricao, serv.IdServico

                                        For Each itens In BuscaServiços.ToList

                                            FrmSoluçãoNovoStudio.LstIdServicos.Items.Add(itens.IdServico)
                                            FrmSoluçãoNovoStudio.CmbServicos.Items.Add(itens.Descricao)

                                        Next

                                        'popula os itens já inseridos

                                        For Each nodeProd As TreeNode In row.Nodes

                                            If nodeProd.Index = 1 Then

                                                'preenche produtos

                                                For Each nodeProd0 As TreeNode In nodeProd.Nodes(0).Nodes

                                                    'separa titulo 

                                                    'preeche no grid

                                                    Dim Contexto As String = FrmSoluçãoNovoStudio.LstIdProduto.SelectedIndex

                                                    Dim str As String = Contexto
                                                    Dim separador As String = " - "
                                                    Dim palavras As String() = str.Split(separador)
                                                    Dim LstPalavras As New ListBox
                                                    Dim palavra As String

                                                    For Each palavra In palavras
                                                        LstPalavras.Items.Add(palavra)
                                                    Next

                                                    '

                                                    If LstPalavras.Items.Count = 1 Then

                                                        'preeche no grid

                                                        FrmSoluçãoNovoStudio.CmbFaricannte.SelectedIndex = FrmSoluçãoNovoStudio.CmbFaricannte.Items.Count - 1
                                                        FrmSoluçãoNovoStudio.LstIdProduto.SelectedItem = nodeProd0.Text

                                                        FrmSoluçãoNovoStudio.CmbProdutos.SelectedIndex = FrmSoluçãoNovoStudio.LstIdProduto.SelectedIndex

                                                        FrmSoluçãoNovoStudio.NmQtPeças.Value = nodeProd0.Nodes(2).Text
                                                        FrmSoluçãoNovoStudio.CkPeça.Checked = nodeProd0.Nodes(3).Text

                                                        FrmSoluçãoNovoStudio.BttVincularProduto.PerformClick()

                                                    End If

                                                Next

                                                'preenche serviços

                                                For Each nodeProd0 As TreeNode In nodeProd.Nodes(1).Nodes

                                                    'preeche no grid

                                                    FrmSoluçãoNovoStudio.LstIdServicos.SelectedItem = nodeProd0.Text

                                                    FrmSoluçãoNovoStudio.CmbServicos.SelectedItem = nodeProd0.Nodes(0).Text

                                                    FrmSoluçãoNovoStudio.NmQtServico.Value = nodeProd0.Nodes(1).Text
                                                    'FrmSoluçãoNovoStudio.CkPeça.Checked = nodeProd0.Nodes(3).Text

                                                    FrmSoluçãoNovoStudio.BttVincularServico.PerformClick()

                                                Next

                                            End If

                                        Next

                                    End If

                                End If

                            End If

                        End If

                    Else

                        Dim PxG_Str As String = ""
                        Dim PxY_Str As String = ""

                        Dim LsptsX As New ListBox
                        Dim LsptsY As New ListBox

                        Dim X_MK1 As Integer = row.Nodes(3).Nodes(0).Text
                        Dim Y_MK1 As Integer = row.Nodes(3).Nodes(1).Text

                        If e.X >= X_MK1 And e.X <= X_MK1 + 160 Then
                            If e.Y >= Y_MK1 And e.Y <= Y_MK1 + 20 Then

                                Y_MK1 += 5

                                For i As Integer = 0 To row.Nodes(0).Nodes.Count - 1 Step 2

                                    'desenha um circulo

                                    Dim X_MK As Integer = row.Nodes(0).Nodes(i).Text
                                    Dim Y_MK As Integer = row.Nodes(0).Nodes(i + 1).Text

                                    LsptsX.Items.Add(X_MK)
                                    LsptsY.Items.Add(Y_MK)

                                    PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)

                                    If PxG_Str <> "" Then

                                        Dim PxG As Integer = PxG_Str
                                        Dim PxY As Integer = PxY_Str

                                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Red)), 2), PxG, PxY, X_MK, Y_MK)

                                        PxG_Str = X_MK
                                        PxY_Str = Y_MK

                                    Else

                                        PxG_Str = X_MK
                                        PxY_Str = Y_MK

                                    End If
                                Next

                                If row.Nodes(2).Text = "Area" Then

                                    Dim Poligono() As Point = Nothing

                                    For i As Integer = 0 To LsptsX.Items.Count - 1 Step 1

                                        Poligono = PointPlus(Poligono, New Point(LsptsX.Items(i).ToString, LsptsY.Items(i).ToString))

                                    Next

                                    PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.OrangeRed)), Poligono)

                                End If

                                'verifica borda

                                Dim corre As Integer = 0
                                Dim correY As Integer = 0

                                PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.WhiteSmoke)), X_MK1, Y_MK1 - 6 + correY, 180, 20)

                                PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.DarkSlateGray), X_MK1 + 21 - 1 - corre, Y_MK1 - 1 + correY)
                                PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK1 + 8 - 6 - corre, Y_MK1 - 1 + correY, 14, 14)

                                If LblStagio.Text <> "Avaliação inicial" Then
                                    PinturaMark.DrawImage(My.Resources.checklist_123014, X_MK1 + 6 - 3 + 140 - corre, Y_MK1 - 3 + correY, 15, 15)
                                End If

                                PinturaMark.DrawImage(My.Resources.Cancel_40972, X_MK1 + 6 - 3 + 160 - corre, Y_MK1 - 3 + correY, 15, 15)

                                PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 2), X_MK1 - 1 - corre, Y_MK1 - 6 + 23 + correY, 180, 1)

                                'PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5, Y_MK - 5, 160, 20 + Arest)

                                If corre = 0 Then
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK1, Y_MK1, X_MK1 + 4 - corre, Y_MK1)
                                Else
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK1, Y_MK1, X_MK1 + 4 - corre, Y_MK1)
                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.LimeGreen)), 1), X_MK1 + 4 - corre, Y_MK1, X_MK1 + 4 - corre, Y_MK1 + correY)
                                End If

                                Dim X As Integer = row.Nodes(0).Nodes(0).Text
                                Dim Y As Integer = row.Nodes(0).Nodes(1).Text

                                X -= 6
                                'Y += 5

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(240, Color.SlateGray)), X, Y - 6, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(240, Color.DarkSlateGray)), 1), X, Y - 6, 10, 10)

                                If e.X >= X_MK1 + 6 - 3 + 160 - corre And e.X <= X_MK1 + 6 - 3 + 160 - corre + 175 Then

                                    If MsgBox("Deseja realmente remover esta marcação?", vbYesNo + MsgBoxStyle.Information, "Remover marcação") = MsgBoxResult.Yes Then

                                        _indexRemove = row.Index

                                    End If

                                End If

                                If LblStagio.Text <> "Avaliação inicial" Then
                                    If e.X >= X_MK1 + 6 - 3 + 140 - corre And e.X <= X_MK1 + 6 - 3 + 140 - corre + 65 Then

                                        'abre form d soluções

                                        FrmSoluçãoNovoStudio.Show(Me)

                                        FrmSoluçãoNovoStudio.LblCategoria.Text = SelPrincipal

                                        'busca categoria 

                                        Dim buscaCategoria = From cat In LqBase.CategoriasProdutos
                                                             Where cat.Descricao Like SelPrincipal
                                                             Select cat.IdCategoriaProduto

                                        If buscaCategoria.Count > 0 Then
                                            FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria.First
                                        Else
                                            'cdastra categoria

                                            LqBase.InsereCategoriaProduto(SelPrincipal)

                                            Dim buscaCategoria2 = From cat In LqBase.CategoriasProdutos
                                                                  Where cat.Descricao Like SelPrincipal
                                                                  Select cat.IdCategoriaProduto

                                            FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria2.First

                                        End If

                                        FrmSoluçãoNovoStudio.LblSubCategoria.Text = SelText

                                        'busca categoria 

                                        Dim buscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                                                Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                                Select cat.IdSubCategoria

                                        If buscaSubCategoria.Count > 0 Then
                                            FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First
                                        Else
                                            'cdastra categoria

                                            LqBase.InsereSubcategoriaProduto(FrmSoluçãoNovoStudio._IdCategoria, SelText)

                                            Dim buscaCategoria2 = From cat In LqBase.SubCategoriasProduto
                                                                  Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                                                  Select cat.IdSubCategoria

                                            FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First

                                        End If

                                        FrmSoluçãoNovoStudio.PictureBox1.BackgroundImage = PicSel
                                        FrmSoluçãoNovoStudio.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

                                        'busca dados do veiculo

                                        Dim NPlaca As String

                                        NPlaca = _Placa.Replace("-", "")

                                        Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                                           Where veic.Placa Like NPlaca
                                                           Select veic.Modelo, veic.Versao, veic.Fabricante, veic.IdVersao, veic.Cor, veic.AnoFab, veic.AnoMod, veic.IdModelo, veic.IdVeiculo

                                        FrmSoluçãoNovoStudio._IdVersao = BuscaVeiculo.First.IdVersao
                                        FrmSoluçãoNovoStudio._IdVeiculo = BuscaVeiculo.First.IdVeiculo
                                        FrmSoluçãoNovoStudio._IdModVeic = BuscaVeiculo.First.IdModelo
                                        FrmSoluçãoNovoStudio.LblFabricante.Text = BuscaVeiculo.First.Fabricante
                                        FrmSoluçãoNovoStudio.LblModelo.Text = BuscaVeiculo.First.Modelo
                                        FrmSoluçãoNovoStudio.LblCor.Text = BuscaVeiculo.First.Cor
                                        FrmSoluçãoNovoStudio.LblAnoFab.Text = BuscaVeiculo.First.AnoFab
                                        FrmSoluçãoNovoStudio.LblAnoMod.Text = BuscaVeiculo.First.AnoMod

                                        'bsca versao

                                        Dim buscaVersao = From ver In LqOficina.VersaoModelos
                                                          Where ver.Idversao = BuscaVeiculo.First.IdVersao
                                                          Select ver.Combustivel, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Versao

                                        FrmSoluçãoNovoStudio.LblMotor.Text = FormatNumber(buscaVersao.First.Potencia, NumDigitsAfterDecimal:=1)
                                        FrmSoluçãoNovoStudio.LblCombustível.Text = buscaVersao.First.Combustivel
                                        FrmSoluçãoNovoStudio.LblCilindrada.Text = buscaVersao.First.Cilindrada
                                        FrmSoluçãoNovoStudio.LblVersao.Text = buscaVersao.First.Versao
                                        FrmSoluçãoNovoStudio.LblCambio.Text = buscaVersao.First.Cambio

                                        'busca produtos

                                        Dim BuscaProdutosAssociados = From mode In LqOficina.AssociaçãoPeçaModelo
                                                                      Where mode.IdModeloVeic = _idModeloVeic
                                                                      Select mode.IdCodProd, mode.IdSolicitaçãoCad

                                        For Each row1 In BuscaProdutosAssociados.ToList

                                            If row1.IdCodProd <> 0 Then

                                                Dim BuscaProdutos = From prod In LqBase.Produtos
                                                                    Where prod.IdProduto = row1.IdCodProd And prod.IdCategoria = buscaCategoria.First And prod.IDSubCategoria = buscaSubCategoria.First
                                                                    Select prod.Descricao, prod.IdProduto, prod.CodFabricante

                                                For Each row2 In BuscaProdutos.ToList

                                                    FrmSoluçãoNovoStudio.CmbProdutos.Items.Add(row2.Descricao)
                                                    FrmSoluçãoNovoStudio.LstIdProduto.Items.Add(row2.IdProduto)
                                                    FrmSoluçãoNovoStudio.LstSN.Items.Add(row2.CodFabricante)

                                                Next

                                            Else

                                                Dim BuscaProdutos = From prod In LqOficina.SolicitacaoCadastroPeca
                                                                    Where prod.IdSolicitacaoCadastro = row1.IdSolicitaçãoCad And prod.IdCategoria = buscaCategoria.First And prod.IdSubCategoria = buscaSubCategoria.First
                                                                    Select prod.Descricao, prod.IdSolicitacaoCadastro, prod.PartNumber

                                                For Each row2 In BuscaProdutos.ToList

                                                    FrmSoluçãoNovoStudio.CmbProdutos.Items.Add(row2.Descricao)
                                                    FrmSoluçãoNovoStudio.LstIdProduto.Items.Add("S" & row2.IdSolicitacaoCadastro)
                                                    FrmSoluçãoNovoStudio.LstSN.Items.Add(row2.PartNumber)

                                                Next

                                            End If

                                        Next

                                        'busca serviços

                                        Dim BuscaServiços = From serv In LqBase.Servicos
                                                            Where serv.IdCategoria = buscaCategoria.First And serv.IdSubCategoria = buscaSubCategoria.First
                                                            Select serv.Descricao, serv.IdServico

                                        For Each itens In BuscaServiços.ToList

                                            FrmSoluçãoNovoStudio.LstIdServicos.Items.Add(itens.IdServico)
                                            FrmSoluçãoNovoStudio.CmbServicos.Items.Add(itens.Descricao)

                                        Next

                                        'popula os itens já inseridos

                                        For Each nodeProd As TreeNode In row.Nodes

                                            If nodeProd.Index = 1 Then

                                                'preenche produtos

                                                For Each nodeProd0 As TreeNode In nodeProd.Nodes(0).Nodes

                                                    'preeche no grid

                                                    Dim Contexto As String = FrmSoluçãoNovoStudio.LstIdProduto.SelectedIndex

                                                    Dim str As String = Contexto
                                                    Dim separador As String = " - "
                                                    Dim palavras As String() = str.Split(separador)
                                                    Dim LstPalavras As New ListBox
                                                    Dim palavra As String

                                                    For Each palavra In palavras
                                                        LstPalavras.Items.Add(palavra)
                                                    Next

                                                    '

                                                    If LstPalavras.Items.Count = 1 Then

                                                        FrmSoluçãoNovoStudio.CmbFaricannte.SelectedIndex = FrmSoluçãoNovoStudio.CmbFaricannte.Items.Count - 1

                                                        FrmSoluçãoNovoStudio.LstIdProduto.SelectedItem = nodeProd0.Text

                                                        FrmSoluçãoNovoStudio.CmbProdutos.SelectedIndex = FrmSoluçãoNovoStudio.LstIdProduto.SelectedIndex

                                                        FrmSoluçãoNovoStudio.NmQtPeças.Value = nodeProd0.Nodes(2).Text
                                                        FrmSoluçãoNovoStudio.CkPeça.Checked = nodeProd0.Nodes(3).Text

                                                        FrmSoluçãoNovoStudio.BttVincularProduto.PerformClick()

                                                    End If

                                                Next

                                                'preenche serviços

                                                For Each nodeProd0 As TreeNode In nodeProd.Nodes(1).Nodes

                                                    'preeche no grid

                                                    FrmSoluçãoNovoStudio.LstIdServicos.SelectedItem = nodeProd0.Text

                                                    FrmSoluçãoNovoStudio.CmbServicos.SelectedItem = nodeProd0.Nodes(0).Text

                                                    FrmSoluçãoNovoStudio.NmQtServico.Value = nodeProd0.Nodes(1).Text
                                                    'FrmSoluçãoNovoStudio.CkPeça.Checked = nodeProd0.Nodes(3).Text

                                                    FrmSoluçãoNovoStudio.BttVincularServico.PerformClick()

                                                Next


                                            End If

                                        Next

                                    End If

                                End If


                            End If

                        End If

                    End If

                Next

                TrRespostashecklist.Visible = False

                PicImagem.Image = PintarMark

                'apaga e pinta mk

                If _indexRemove > -1 Then

                    TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.RemoveAt(_indexRemove)

                    PicImagem.Image = Nothing

                    PintaMk()

                End If

            End If

        End If

    End Sub

    Public Sub PintaMk()

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If LblStagio.Text <> "Avaliação complementar" Then

            If Press = False Then

                Dim H As Integer = 848
                Dim V As Integer = 548

                Dim PintarBitmap = New Bitmap(H, V)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Dim Str As String = TrRespostashecklist.Nodes(TrParentSel).Text

                If Str.StartsWith("+") Then

                    Str = Str.Remove(0, 1)

                    Pintura.DrawImage(System.Drawing.Image.FromFile(Str), 0, 0, H, V)

                Else

                    'inserechart

                    Dim Str_id As Integer = Str

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdImagemProcesso = Str_id
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    Dim arrImage() As Byte
                    Dim myMS As New IO.MemoryStream
                    arrImage = buscaImagens.First.Imagem.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    'define o tamanho da imagem 

                    Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, H, V)

                    myMS.Dispose()

                End If

                PicImagem.Size = New Size(H, V)

                PicImagem.BackgroundImage = PintarBitmap
                PicImagem.BackgroundImageLayout = ImageLayout.Stretch

                Dim PintarMark = New Bitmap(PintarBitmap)

                Dim PinturaMark = Graphics.FromImage(PintarMark)

                'varre marcações

                For Each row As TreeNode In TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes

                    'pinta marcação de acordo com o tamanho dos campos do point

                    Dim Cor As Color = Color.Lavender

                    If row.Nodes(0).Nodes.Count = 2 Then

                        'desenha um circulo

                        Dim X_MK As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK As Integer = row.Nodes(0).Nodes(1).Text

                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 
                        X_MK += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 8.25), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                        End If


                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 8.25), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                        End If

                        Dim corre As Integer = 0
                        Dim correY As Integer = 0

                        If X_MK + 20 + 4 + 160 > 848 Then

                            corre = X_MK + 20 + 4 + 160 - 848 + 20
                            correY += 20

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X_MK + 5 - corre, Y_MK - 5 + correY, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), X_MK + 26 - corre, Y_MK + correY)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK + 8 - corre, Y_MK + correY, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK + 5 - corre, Y_MK - 5 + 23 + correY, 180, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5 - corre, Y_MK - 5 + correY, 180, 20 + Arest)

                        If row.Nodes(3).Nodes.Count = 0 Then
                            row.Nodes(3).Nodes.Add(X_MK + 5 - corre)
                            row.Nodes(3).Nodes.Add(Y_MK - 5 + correY)
                        End If

                        If corre = 0 Then
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 15, Y_MK, X_MK + 5, Y_MK)
                        Else
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 25, Y_MK, X_MK + 5 - corre, Y_MK)
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5 - corre, Y_MK, X_MK + 5 - corre, Y_MK + correY)

                        End If

                    Else

                        Dim PxG_Str As String = ""
                        Dim PxY_Str As String = ""

                        Dim LsptsX As New ListBox
                        Dim LsptsY As New ListBox

                        Dim X_MK1 As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK1 As Integer = row.Nodes(0).Nodes(1).Text

                        For i As Integer = 0 To row.Nodes(0).Nodes.Count - 1 Step 2

                            'desenha um circulo

                            Dim X_MK As Integer = row.Nodes(0).Nodes(i).Text
                            Dim Y_MK As Integer = row.Nodes(0).Nodes(i + 1).Text

                            LsptsX.Items.Add(X_MK)
                            LsptsY.Items.Add(Y_MK)

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.DarkSlateGray)), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                            If PxG_Str <> "" Then

                                Dim PxG As Integer = PxG_Str
                                Dim PxY As Integer = PxY_Str

                                If row.Text <> Ferramenta Then

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), 2), PxG, PxY, X_MK, Y_MK)

                                Else

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Red)), 2), PxG, PxY, X_MK, Y_MK)

                                End If

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            Else

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            End If

                        Next

                        If row.Nodes(2).Text = "Area" Then

                            Dim Poligono() As Point = Nothing

                            For i As Integer = 0 To LsptsX.Items.Count - 1 Step 1

                                Poligono = PointPlus(Poligono, New Point(LsptsX.Items(i).ToString, LsptsY.Items(i).ToString))

                            Next

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), Poligono)

                            Else

                                PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.OrangeRed)), Poligono)

                            End If

                        End If

                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 

                        X_MK1 += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        Dim corre As Integer = 0
                        Dim correY As Integer = 0

                        If X_MK1 + 20 + 4 + 160 > 848 Then

                            corre = X_MK1 + 20 + 4 + 160 - 848 + 20
                            correY += 20

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X_MK1 + 5 - corre, Y_MK1 - 5 + correY, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), X_MK1 + 26 - corre, Y_MK1 + correY)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK1 + 8 - corre, Y_MK1 + correY, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK1 + 5 - corre, Y_MK1 - 5 + 23 + correY, 180, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5 - corre, Y_MK1 - 5 + correY, 180, 20 + Arest)

                        If corre = 0 Then
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 15, Y_MK1, X_MK1 + 5, Y_MK1)
                        Else
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 25, Y_MK1, X_MK1 + 5 - corre, Y_MK1)
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5 - corre, Y_MK1, X_MK1 + 5 - corre, Y_MK1 + correY)

                        End If

                        If row.Nodes(3).Nodes.Count = 0 Then
                            row.Nodes(3).Nodes.Add(X_MK1 + 5 - corre)
                            row.Nodes(3).Nodes.Add(Y_MK1 - 5 + correY)
                        End If


                    End If

                Next

                PicImagem.BackgroundImage = PintarMark

            Else

                Dim H As Integer = 848
                Dim V As Integer = 548

                Dim PintarBitmap = New Bitmap(H, V)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Dim Str As String = TrRespostashecklist.Nodes(TrParentSel).Text

                If Str.StartsWith("+") Then

                    Str = Str.Remove(0, 1)

                    Pintura.DrawImage(System.Drawing.Image.FromFile(Str), 0, 0, H, V)

                Else

                    'inserechart

                    Dim Str_id As Integer = Str

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdImagemProcesso = Str_id
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    Dim arrImage() As Byte
                    Dim myMS As New IO.MemoryStream
                    arrImage = buscaImagens.First.Imagem.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    'define o tamanho da imagem 

                    Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, H, V)

                    myMS.Dispose()

                End If

                Dim PintarMark = New Bitmap(PintarBitmap)

                Dim PinturaMark = Graphics.FromImage(PintarMark)

                'varre marcações

                For Each row As TreeNode In TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes

                    'pinta marcação de acordo com o tamanho dos campos do point

                    Dim Cor As Color = Color.FromName(row.Nodes(2).Text)

                    If row.Nodes(0).Nodes.Count = 2 Then

                        'desenha um circulo

                        Dim X_MK As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK As Integer = row.Nodes(0).Nodes(1).Text


                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 
                        X_MK += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 8.25), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                        End If

                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                        End If

                        Dim corre As Integer = 0
                        Dim correY As Integer = 0

                        If X_MK + 20 + 4 + 160 > 848 Then

                            corre = X_MK + 20 + 4 + 160 - 848 + 20
                            correY += 20

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X_MK + 5 - corre, Y_MK - 5 + correY, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), X_MK + 26 - corre, Y_MK + correY)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK + 8 - corre, Y_MK + correY, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK + 5 - corre, Y_MK - 5 + 23 + correY, 180, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5 - corre, Y_MK - 5 + correY, 180, 20 + Arest)

                        If row.Nodes(3).Nodes.Count = 0 Then
                            row.Nodes(3).Nodes.Add(X_MK + 5 - corre)
                            row.Nodes(3).Nodes.Add(Y_MK - 5 + correY)
                        End If

                        If corre = 0 Then
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 15, Y_MK, X_MK + 5, Y_MK)
                        Else
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 25, Y_MK, X_MK + 5 - corre, Y_MK)
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5 - corre, Y_MK, X_MK + 5 - corre, Y_MK + correY)

                        End If

                    Else

                        Dim PxG_Str As String = ""
                        Dim PxY_Str As String = ""

                        Dim X_MK1 As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK1 As Integer = row.Nodes(0).Nodes(1).Text

                        Dim LsptsX As New ListBox
                        Dim LsptsY As New ListBox

                        For i As Integer = 0 To row.Nodes(0).Nodes.Count - 1 Step 2

                            'desenha um circulo

                            Dim X_MK As Integer = row.Nodes(0).Nodes(i).Text
                            Dim Y_MK As Integer = row.Nodes(0).Nodes(i + 1).Text

                            LsptsX.Items.Add(X_MK)
                            LsptsY.Items.Add(Y_MK)

                            If row.Text = Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.DarkSlateGray)), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                            If PxG_Str <> "" Then

                                Dim PxG As Integer = PxG_Str
                                Dim PxY As Integer = PxY_Str

                                If row.Text = Ferramenta Then

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Red)), 2), PxG, PxY, X_MK, Y_MK)

                                Else

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), 2), PxG, PxY, X_MK, Y_MK)

                                End If

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            Else

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            End If

                        Next

                        If row.Nodes(2).Text = "Area" Then

                            Dim Poligono() As Point = Nothing

                            If LsptsX.Items(0).ToString = LsptsX.Items(LsptsX.Items.Count - 1).ToString Then

                                For i As Integer = 0 To LsptsX.Items.Count - 1 Step 1

                                    Poligono = PointPlus(Poligono, New Point(LsptsX.Items(i).ToString, LsptsY.Items(i).ToString))

                                Next

                                If row.Text = Ferramenta Then

                                    PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.OrangeRed)), Poligono)

                                Else

                                    PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), Poligono)

                                End If

                            End If

                        End If


                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 

                        X_MK1 += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If


                        Dim corre As Integer = 0
                        Dim correY As Integer = 0

                        If X_MK1 + 20 + 4 + 160 > 848 Then

                            corre = X_MK1 + 20 + 4 + 160 - 848 + 20
                            correY += 20

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(220, Color.SlateGray)), X_MK1 + 5 - corre, Y_MK1 - 5 + correY, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), X_MK1 + 26 - corre, Y_MK1 + correY)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK1 + 8 - corre, Y_MK1 + correY, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK1 + 5 - corre, Y_MK1 - 5 + 23 + correY, 180, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5 - corre, Y_MK1 - 5 + correY, 180, 20 + Arest)

                        If row.Nodes(3).Nodes.Count = 0 Then
                            row.Nodes(3).Nodes.Add(X_MK1 + 5 - corre)
                            row.Nodes(3).Nodes.Add(Y_MK1 - 5 + correY)
                        End If

                        If corre = 0 Then
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 15, Y_MK1, X_MK1 + 5, Y_MK1)
                        Else
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 25, Y_MK1, X_MK1 + 5 - corre, Y_MK1)
                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5 - corre, Y_MK1, X_MK1 + 5 - corre, Y_MK1 + correY)

                        End If

                    End If

                Next

                'desenha poligono

                PicImagem.BackgroundImage = PintarMark

            End If

            'redimenciona imagem

            Dim Eixo_X As Integer = PicImagem.Width
            Dim Eixo_Y As Integer = PicImagem.Height

            Dim PCtg As Integer = 100

            Dim Pctg_Find As Integer = ((Eixo_X * Eixo_Y) * 100) / PCtg

            'TtVlrZoom.Text = FormatPercent(Pctg_Find / 100, NumDigitsAfterDecimal:=0)

        Else

            If Press = False Then

                Dim H As Integer = 848
                Dim V As Integer = 548

                Dim PintarBitmap = New Bitmap(H, V)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Dim Str As String = TrRespostashecklist.Nodes(TrParentSel).Text

                If Str.StartsWith("+") Then

                    Str = Str.Remove(0, 1)

                    Pintura.DrawImage(System.Drawing.Image.FromFile(Str), 0, 0, H, V)

                Else

                    'inserechart

                    Dim Str_id As Integer = Str

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdImagemProcesso = Str_id
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    Dim arrImage() As Byte
                    Dim myMS As New IO.MemoryStream
                    arrImage = buscaImagens.First.Imagem.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    'define o tamanho da imagem 

                    Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, H, V)

                    myMS.Dispose()

                End If

                PicImagem.Size = New Size(H, V)

                PicImagem.BackgroundImage = PintarBitmap
                PicImagem.BackgroundImageLayout = ImageLayout.Stretch

                Dim PintarMark = New Bitmap(PintarBitmap)

                Dim PinturaMark = Graphics.FromImage(PintarMark)

                'varre marcações

                For Each row As TreeNode In TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes

                    'pinta marcação de acordo com o tamanho dos campos do point

                    Dim Cor As Color = Color.Lavender

                    If row.Nodes(0).Nodes.Count = 2 Then

                        'desenha um circulo

                        Dim X_MK As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK As Integer = row.Nodes(0).Nodes(1).Text

                        Dim Arest As Integer = 0

                        'verifica os calores dos produos 
                        X_MK += 20

                        'PInta aprovado ou recusado

                        Dim PintaAprovado As Boolean = False

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Or row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            'varre em busca de arovado

                            For Each rw4 As TreeNode In row.Nodes(1).Nodes(0).Nodes

                                If rw4.Nodes.Count = 5 Then

                                    If rw4.Nodes(4).Text = "Item aprovado" Then

                                        PinturaMark.DrawImage(My.Resources.check_ok_accept_apply_1582, X_MK + 20, Y_MK - 15, 30, 30)
                                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(200, Color.Lime)), 1), X_MK - 15, Y_MK, X_MK + 20, Y_MK)

                                        PintaAprovado = True

                                    ElseIf rw4.Nodes(4).Text = "Item recusado" Then

                                        PinturaMark.DrawImage(My.Resources.Cancel_40972, X_MK + 20, Y_MK - 15, 30, 30)
                                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(200, Color.Lime)), 1), X_MK - 15, Y_MK, X_MK + 20, Y_MK)

                                        PintaAprovado = True

                                    ElseIf rw4.Nodes(4).Text = "Item em análise" Then

                                        PinturaMark.DrawImage(My.Resources.alert_icon_icons_com_52395, X_MK + 20, Y_MK - 15, 30, 30)
                                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(200, Color.Lime)), 1), X_MK - 15, Y_MK, X_MK + 20, Y_MK)

                                        PintaAprovado = True

                                    End If

                                End If

                            Next

                            If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                                Arest += 20

                                PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)
                                PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                            End If

                        End If

                        If PintaAprovado = False Then

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5, 180, 20)

                            PinturaMark.DrawString(row.Text, New Font("Calibri", 12), New SolidBrush(Color.Blue), X_MK + 23, Y_MK - 3)
                            PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK + 8, Y_MK, 14, 14)

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK + 5, Y_MK - 5 + 23, 180, 2)

                            PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5, Y_MK - 5, 130, 20 + Arest)

                            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 15, Y_MK, X_MK + 5, Y_MK)

                            X_MK -= 20

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK - 5, Y_MK - 5, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                        Else

                            X_MK -= 20

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Lime)), X_MK - 5, Y_MK - 5, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Lime)), X_MK - 5, Y_MK - 5, 10, 10)
                                PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                        End If

                    Else

                        Dim PxG_Str As String = ""
                        Dim PxY_Str As String = ""

                        Dim LsptsX As New ListBox
                        Dim LsptsY As New ListBox

                        Dim X_MK1 As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK1 As Integer = row.Nodes(0).Nodes(1).Text

                        For i As Integer = 0 To row.Nodes(0).Nodes.Count - 1 Step 2

                            'desenha um circulo

                            Dim X_MK As Integer = row.Nodes(0).Nodes(i).Text
                            Dim Y_MK As Integer = row.Nodes(0).Nodes(i + 1).Text

                            LsptsX.Items.Add(X_MK)
                            LsptsY.Items.Add(Y_MK)

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                            If PxG_Str <> "" Then

                                Dim PxG As Integer = PxG_Str
                                Dim PxY As Integer = PxY_Str

                                If row.Text <> Ferramenta Then

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Red)), 2), PxG, PxY, X_MK, Y_MK)

                                Else

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), 2), PxG, PxY, X_MK, Y_MK)

                                End If

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            Else

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            End If

                        Next

                        If row.Nodes(2).Text = "Area" Then

                            Dim Poligono() As Point = Nothing

                            For i As Integer = 0 To LsptsX.Items.Count - 1 Step 1

                                Poligono = PointPlus(Poligono, New Point(LsptsX.Items(i).ToString, LsptsY.Items(i).ToString))

                            Next

                            If row.Text <> Ferramenta Then

                                PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.DarkRed)), Poligono)

                            Else

                                PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), Poligono)

                            End If

                        End If

                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 

                        X_MK1 += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest - 2)

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 12), New SolidBrush(Color.Blue), X_MK1 + 23, Y_MK1 - 3)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK1 + 8, Y_MK1, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK1 + 5, Y_MK1 - 5 + 23, 180, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5, Y_MK1 - 5, 130, 20 + Arest)

                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 15, Y_MK1, X_MK1 + 5, Y_MK1)


                    End If

                Next

                PicImagem.BackgroundImage = PintarMark

            Else

                Dim H As Integer = 848
                Dim V As Integer = 548

                Dim PintarBitmap = New Bitmap(H, V)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Dim Str As String = TrRespostashecklist.Nodes(TrParentSel).Text

                If Str.StartsWith("+") Then

                    Str = Str.Remove(0, 1)

                    Pintura.DrawImage(System.Drawing.Image.FromFile(Str), 0, 0, H, V)

                Else

                    'inserechart

                    Dim Str_id As Integer = Str

                    Dim buscaImagens = From img In LqOficina.ImagemRespostaCklist
                                       Where img.IdImagemProcesso = Str_id
                                       Select img.Imagem, img.IdImagemProcesso

                    'varre imagens

                    Dim arrImage() As Byte
                    Dim myMS As New IO.MemoryStream
                    arrImage = buscaImagens.First.Imagem.ToArray

                    For Each ar As Byte In arrImage
                        myMS.WriteByte(ar)
                    Next

                    'define o tamanho da imagem 

                    Pintura.DrawImage(System.Drawing.Image.FromStream(myMS), 0, 0, H, V)

                    myMS.Dispose()

                End If


                Dim PintarMark = New Bitmap(PintarBitmap)

                Dim PinturaMark = Graphics.FromImage(PintarMark)

                'varre marcações

                For Each row As TreeNode In TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes

                    'pinta marcação de acordo com o tamanho dos campos do point

                    Dim Cor As Color = Color.FromName(row.Nodes(2).Text)

                    If row.Nodes(0).Nodes.Count = 2 Then

                        'desenha um circulo

                        Dim X_MK As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK As Integer = row.Nodes(0).Nodes(1).Text


                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK - 5, Y_MK - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK - 5, Y_MK - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 
                        X_MK += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest + 1)

                        End If


                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK + 7, Y_MK + Arest - 2)

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK + 5, Y_MK - 5, 180, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 12), New SolidBrush(Color.Blue), X_MK + 23, Y_MK - 3)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK + 8, Y_MK, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK + 5, Y_MK - 5 + 23, 130, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK + 5, Y_MK - 5, 180, 20 + Arest)

                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK - 15, Y_MK, X_MK + 5, Y_MK)

                    Else

                        Dim PxG_Str As String = ""
                        Dim PxY_Str As String = ""

                        Dim X_MK1 As Integer = row.Nodes(0).Nodes(0).Text
                        Dim Y_MK1 As Integer = row.Nodes(0).Nodes(1).Text

                        Dim LsptsX As New ListBox
                        Dim LsptsY As New ListBox

                        For i As Integer = 0 To row.Nodes(0).Nodes.Count - 1 Step 2

                            'desenha um circulo

                            Dim X_MK As Integer = row.Nodes(0).Nodes(i).Text
                            Dim Y_MK As Integer = row.Nodes(0).Nodes(i + 1).Text

                            LsptsX.Items.Add(X_MK)
                            LsptsY.Items.Add(Y_MK)

                            If row.Text = Ferramenta Then

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Blue)), X_MK - 5, Y_MK - 5, 10, 10)

                            Else

                                PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.DarkRed)), X_MK - 5, Y_MK - 5, 10, 10)

                            End If

                            If PxG_Str <> "" Then

                                Dim PxG As Integer = PxG_Str
                                Dim PxY As Integer = PxY_Str

                                If row.Text = Ferramenta Then

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Blue)), 2), PxG, PxY, X_MK, Y_MK)

                                Else

                                    PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.DarkRed)), 2), PxG, PxY, X_MK, Y_MK)

                                End If

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            Else

                                PxG_Str = X_MK
                                PxY_Str = Y_MK

                            End If

                        Next


                        If row.Nodes(2).Text = "Area" Then

                            Dim Poligono() As Point = Nothing

                            If LsptsX.Items(0).ToString = LsptsX.Items(LsptsX.Items.Count - 1).ToString Then

                                For i As Integer = 0 To LsptsX.Items.Count - 1 Step 1

                                    Poligono = PointPlus(Poligono, New Point(LsptsX.Items(i).ToString, LsptsY.Items(i).ToString))

                                Next

                                If row.Text = Ferramenta Then

                                    PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.SlateGray)), Poligono)

                                Else

                                    PinturaMark.FillPolygon(New SolidBrush(Color.FromArgb(100, Color.Red)), Poligono)

                                End If

                            End If

                        End If


                        Dim Arest As Integer = 0

                        If row.Text <> Ferramenta Then

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.WhiteSmoke)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        Else

                            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(200, Color.Red)), X_MK1 - 5, Y_MK1 - 5, 10, 10)
                            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), 1), X_MK1 - 5, Y_MK1 - 5, 10, 10)

                        End If

                        'verifica os calores dos produos 

                        X_MK1 += 20

                        If row.Nodes(1).Nodes(0).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)

                            PinturaMark.DrawString("Produtos: " & row.Nodes(1).Nodes(0).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        If row.Nodes(1).Nodes(1).Nodes.Count > 0 Then

                            Arest += 20

                            PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5 + Arest, 180, 20)
                            PinturaMark.DrawString("Serviços: " & row.Nodes(1).Nodes(1).Nodes.Count, New Font("Calibri", 10), New SolidBrush(Color.DarkSlateGray), X_MK1 + 7, Y_MK1 + Arest + 1)

                        End If

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(180, Color.WhiteSmoke)), X_MK1 + 5, Y_MK1 - 5, 130, 20)

                        PinturaMark.DrawString(row.Text, New Font("Calibri", 12), New SolidBrush(Color.Blue), X_MK1 + 23, Y_MK1 - 3)
                        PinturaMark.DrawImage(My.Resources.kisspng_g_suite_google_analytics_email_administrator_5ac2ab09caa4e7_8837788615227072098301, X_MK1 + 8, Y_MK1, 14, 14)

                        PinturaMark.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.DarkSlateGray)), X_MK1 + 5, Y_MK1 - 5 + 23, 130, 2)

                        PinturaMark.DrawRectangle(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 + 5, Y_MK1 - 5, 130, 20 + Arest)

                        PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(220, Color.DarkSlateGray)), 1), X_MK1 - 15, Y_MK1, X_MK1 + 5, Y_MK1)

                    End If

                Next

                'desenha poligono

                PicImagem.BackgroundImage = PintarMark

            End If

        End If

        'varre e verifica as categorias ja inserida

        VerificaContagem()

    End Sub

    Private Function PointPlus(ByVal OP() As Point, ByVal AP As Point)
        'Adds a point to an existing point array
        If OP Is Nothing Then
            ReDim OP(0)
            OP(0) = AP
        Else
            ReDim Preserve OP(OP.Length)
            OP(OP.Length - 1) = AP
        End If
        Return OP
    End Function

    Private Sub PeçaAusenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeçaAusenteToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Peça ausente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("silver")

        PintaMk()

    End Sub

    Private Sub PeçaIrrecuperávelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeçaIrrecuperávelToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Peça irrecuperável")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("darkblue")

        PintaMk()

    End Sub

    Private Sub PeçaAusenteToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles PeçaAusenteToolStripMenuItem2.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças mecânicas - Peça ausente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("slategray")

        PintaMk()

    End Sub

    Private Sub PeçaQuabradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeçaQuabradaToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças mecânicas - Peça quebrada")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("salmon")

        PintaMk()

    End Sub

    Private Sub FalaConstanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalaConstanteToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças mecânicas - Falha - Falha constante")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("purple")

        PintaMk()

    End Sub

    Private Sub FalhaIntermitenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalhaIntermitenteToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças mecânicas - Falha - Falha intermitente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("darkgreen")

        PintaMk()

    End Sub

    Private Sub PeçaQuebradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PeçaQuebradaToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Acabamentos - Peça quebrada")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("orange")

        PintaMk()

    End Sub

    Private Sub PeçaAusenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PeçaAusenteToolStripMenuItem1.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Acabamentos - Peça ausente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("yellow")

        PintaMk()

    End Sub

    Private Sub QuebradoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuebradoToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Vidros - Vidro quebrado")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("white")

        PintaMk()

    End Sub

    Private Sub VidroAusenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VidroAusenteToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Vidros - Vidro ausente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("pink")

        PintaMk()

    End Sub

    Private Sub FalhaConstanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FalhaConstanteToolStripMenuItem.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças eletrônicas - Falha - Falha intermitente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("violet")

        PintaMk()

    End Sub

    Dim Press As Boolean

    Private Sub FalhaIntermitenteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FalhaIntermitenteToolStripMenuItem1.Click

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Peças eletrônicas - Falha - Falha intermitente")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("darkgoldenrod")

        PintaMk()

    End Sub

    Private Sub RiscosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiscosToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Riscos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("blue")

        PintaMk()

    End Sub

    Private Sub PicImagem_MouseMove(sender As Object, e As MouseEventArgs) Handles PicImagem.MouseMove

        _Mx = e.X
        _My = e.Y

        If Press = True Then

            PintaMk()

            Dim H As Integer = 848
            Dim V As Integer = 548

            Dim PintarMark = New Bitmap(H, V)

            Dim PinturaMark = Graphics.FromImage(PintarMark)

            'varre marcações

            Dim TrPrincipal As TreeNode = TrRespostashecklist.Nodes(TrParentSel)
            Dim TrMk As TreeNode = TrPrincipal.Nodes(2).Nodes(TrPrincipal.Nodes(2).Nodes.Count - 1)
            Dim TrPts As TreeNode = TrMk.Nodes(TrMk.Nodes.Count - 4)
            Dim TrVlr As TreeNode = TrPts.Nodes(TrPts.Nodes.Count - 2)
            Dim TrVlr1 As TreeNode = TrPts.Nodes(TrPts.Nodes.Count - 1)

            Dim M_tr_X As Integer = TrVlr.Text
            Dim M_tr_y As Integer = TrVlr1.Text

            PinturaMark.DrawLine(New Pen(New SolidBrush(Color.FromArgb(100, Color.Red)), 2), M_tr_X, M_tr_y, e.X, e.Y)
            PinturaMark.FillEllipse(New SolidBrush(Color.FromArgb(100, Color.Red)), e.X - 5, e.Y - 5, 10, 10)
            PinturaMark.DrawEllipse(New Pen(New SolidBrush(Color.FromArgb(100, Color.OrangeRed)), 1), e.X - 5, e.Y - 5, 10, 10)

            PicImagem.Image = PintarMark

            PicImagem.Cursor = Cursors.Cross

        End If

    End Sub

    Private Sub PicLocalizadas_Click(sender As Object, e As EventArgs) Handles PicLocalizadas.Click


    End Sub

    Private Sub PicLocalizadas_MouseClick(sender As Object, e As MouseEventArgs) Handles PicLocalizadas.MouseClick

        If TrRespostashecklist.Nodes.Count > 0 Then

            Selecionar = True

            Ferramenta = "Selecionar"
            TipoRisco = "ND"

            Press = False

            Me.Cursor = Cursors.AppStarting

            'procura na lista

            Dim _idSel As Integer = -1
            Dim Apagar As Boolean = False

            For i As Integer = 0 To LstYPub.Items.Count - 1

                'verifica na lista

                If e.X >= 0 And e.X <= 190 Then

                    If e.Y >= LstYPub.Items(i).ToString And e.Y <= LstYPub.Items(i).ToString + 130 Then

                        _idSel = (LstListaPulicada.Items(i).ToString)
                        TrParentSel = _idSel

                        SelText = TrRespostashecklist.Nodes(_idSel).Nodes(4).Text

                        'verifica se foi clicado em apagar

                        If e.X >= +146 + 10 And e.X <= 146 + 10 + 28 Then

                            If e.Y >= LstYPub.Items(i).ToString + 5 And e.Y <= LstYPub.Items(i).ToString + 32 Then

                                Selecionar = True

                                PicImagem.Cursor = Cursors.Arrow

                                Ferramenta = "Selecionar"
                                TipoRisco = "ND"

                                Apagar = True

                            End If

                        End If

                    End If

                End If

            Next

            If Apagar = True Then

                TrRespostashecklist.Nodes.RemoveAt(_idSel)
                TrParentSel = -1

                DesenhaMiniatura()

                PicImagem.Image = Nothing

                If LstListaPulicada.Items.Count = 0 Then

                    PicLocalizadas.BackgroundImage = Nothing
                    BttCarregar.Enabled = False

                    PicImagem.BackgroundImage = My.Resources.untitled_n
                    PicImagem.BackgroundImageLayout = ImageLayout.Center

                Else

                    PintaMk()

                End If

            Else

                DesenhaMiniatura()

                PicImagem.Image = Nothing

                PintaMk()

            End If

            PicImagem.Cursor = Cursors.Arrow

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Dim _IdSelNode As Integer

    Private Sub PicImagem_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles PicImagem.MouseDoubleClick

        'TrRespostashecklist.Visible = False

        If Press = True Then

            'adiciona no pts

            Dim TrFirst As TreeNode = TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0)
            Dim TrSec As TreeNode = TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0)

            If TipoRisco = "Area" Then

                TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0).Nodes.Add(TrFirst.Nodes(0).Text)
                TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(0).Nodes.Add(TrSec.Nodes(1).Text)

            End If

            PintaMk()

            Press = False

            PicImagem.Cursor = Cursors.Cross

            If LblStagio.Text <> "Avaliação inicial" Then
                'abre form d soluções

                FrmSoluçãoNovoStudio.Show(Me)

                FrmSoluçãoNovoStudio.LblCategoria.Text = SelPrincipal

                'busca categoria 

                Dim buscaCategoria = From cat In LqBase.CategoriasProdutos
                                     Where cat.Descricao Like SelPrincipal
                                     Select cat.IdCategoriaProduto

                If buscaCategoria.Count > 0 Then
                    FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria.First
                Else
                    'cdastra categoria

                    LqBase.InsereCategoriaProduto(SelPrincipal)

                    Dim buscaCategoria2 = From cat In LqBase.CategoriasProdutos
                                          Where cat.Descricao Like SelPrincipal
                                          Select cat.IdCategoriaProduto

                    FrmSoluçãoNovoStudio._IdCategoria = buscaCategoria2.First

                End If

                FrmSoluçãoNovoStudio.LblSubCategoria.Text = SelText

                'busca categoria 

                Dim buscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                        Where cat.Descricao Like SelText And cat.IdCategoria = FrmSoluçãoNovoStudio._IdCategoria
                                        Select cat.IdSubCategoria

                If buscaSubCategoria.Count > 0 Then
                    FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First
                Else
                    'cdastra categoria

                    LqBase.InsereSubcategoriaProduto(FrmSoluçãoNovoStudio._IdCategoria, SelText)

                    Dim buscaCategoria2 = From cat In LqBase.CategoriasProdutos
                                          Where cat.Descricao Like SelPrincipal
                                          Select cat.IdCategoriaProduto

                    FrmSoluçãoNovoStudio._IdSubCategoria = buscaSubCategoria.First

                End If

                FrmSoluçãoNovoStudio.PictureBox1.BackgroundImage = PicSel
                'FrmSoluçãoNovoStudio.PictureBox1.BackgroundImageLayout = ImageLayout.Zoom

                'busca dados do veiculo

                Dim NPlaca As String

                NPlaca = _Placa.Replace("-", "")

                Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                                   Where veic.Placa Like NPlaca
                                   Select veic.Modelo, veic.Versao, veic.Fabricante, veic.IdVersao, veic.Cor, veic.AnoFab, veic.AnoMod, veic.IdModelo, veic.IdVeiculo

                FrmSoluçãoNovoStudio._IdVersao = BuscaVeiculo.First.IdVersao
                FrmSoluçãoNovoStudio._IdVeiculo = BuscaVeiculo.First.IdVeiculo
                FrmSoluçãoNovoStudio._IdModVeic = BuscaVeiculo.First.IdModelo
                FrmSoluçãoNovoStudio.LblFabricante.Text = BuscaVeiculo.First.Fabricante
                FrmSoluçãoNovoStudio.LblModelo.Text = BuscaVeiculo.First.Modelo
                FrmSoluçãoNovoStudio.LblCor.Text = BuscaVeiculo.First.Cor
                FrmSoluçãoNovoStudio.LblAnoFab.Text = BuscaVeiculo.First.AnoFab
                FrmSoluçãoNovoStudio.LblAnoMod.Text = BuscaVeiculo.First.AnoMod

                'bsca versao

                Dim buscaVersao = From ver In LqOficina.VersaoModelos
                                  Where ver.Idversao = BuscaVeiculo.First.IdVersao
                                  Select ver.Combustivel, ver.Potencia, ver.Cilindrada, ver.Cambio, ver.Versao

                FrmSoluçãoNovoStudio.LblMotor.Text = FormatNumber(buscaVersao.First.Potencia, NumDigitsAfterDecimal:=1)
                FrmSoluçãoNovoStudio.LblCombustível.Text = buscaVersao.First.Combustivel
                FrmSoluçãoNovoStudio.LblCilindrada.Text = buscaVersao.First.Cilindrada
                FrmSoluçãoNovoStudio.LblVersao.Text = buscaVersao.First.Versao
                FrmSoluçãoNovoStudio.LblCambio.Text = buscaVersao.First.Cambio


                FrmSoluçãoNovoStudio.CarregaLoad()

            End If

        End If

    End Sub

    Private Sub PicLocalizadas_MouseMove(sender As Object, e As MouseEventArgs) Handles PicLocalizadas.MouseMove


    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmNovoStudioAvaliacao_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ToolStripDropDownButton1.PerformClick()

        'PublicaTreeview()

        If TrRespostashecklist.Nodes.Count > 0 Then
            DesenhaMiniatura()
        End If

    End Sub

    Private Sub AmassadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmassadosToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Riscos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("red")

        PintaMk()

    End Sub

    Private Sub DesbotamentoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesbotamentoToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Pintura - Desbotamento")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("darkblue")

        PintaMk()

    End Sub

    Private Sub PercaDeTintaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PercaDeTintaToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Pintura - Perca de tinta")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("snow")

        PintaMk()

    End Sub

    Private Sub CorrosãoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrosãoToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Lataria - Corrosão")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("mistyrose")

        PintaMk()

    End Sub

    Private Sub RiscosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RiscosToolStripMenuItem1.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Acabamentos - Riscos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("darkred")

        PintaMk()

    End Sub

    Private Sub RasgosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RasgosToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Acabamentos - Rasgos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("gold")

        PintaMk()

    End Sub

    Private Sub TrincosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TrincosToolStripMenuItem.Click

        Press = True

        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Add("Vidros - Trincos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Pts")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_Mx)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add(_My)
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("Solução")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Produtos")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Count - 1).Nodes.Add("Serviços")
        TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes(TrRespostashecklist.Nodes(TrParentSel).Nodes(2).Nodes.Count - 1).Nodes.Add("khaki")

        PintaMk()

    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs)

    End Sub

    Public SelPrincipal As String

    Dim Carregado As Boolean = False

    Private Sub BttCarregar_Click(sender As Object, e As EventArgs) Handles BttCarregar.Click

        'TrRespostashecklist.Visible = False
        'OpenFileDialog
        Me.ofd1.Multiselect = True
        Me.ofd1.Title = "Selecionar Arquivos"
        ofd1.InitialDirectory = "C:\"
        'filtra para exibir somente arquivos de imagens
        'ofd1.Filter = "Imagens (*.png | *.jpg)|*.png, *.jpg"
        ofd1.CheckFileExists = True
        ofd1.CheckPathExists = True
        ofd1.FilterIndex = 1
        ofd1.RestoreDirectory = True
        ofd1.ReadOnlyChecked = True
        ofd1.ShowReadOnly = True

        Dim dr As DialogResult = Me.ofd1.ShowDialog()
        If dr = System.Windows.Forms.DialogResult.OK Then

            HabilitaCampos()

            Dim H As Integer = 848
            Dim V As Integer = 548

            PicImagem.Cursor = Cursors.WaitCursor

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Pintura.DrawImage(System.Drawing.Image.FromFile(ofd1.FileName), 0, 0, H, V)
            PicImagem.Size = New Size(H, V)

            PicImagem.BackgroundImage = PintarBitmap
            PicImagem.BackgroundImageLayout = ImageLayout.Stretch
            'varre marcações


            'redimenciona imagem

            PicImagem.Cursor = Cursors.Arrow

            TrRespostashecklist.Nodes.Add("+" & ofd1.FileName)

            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(145 + (128 * (TrRespostashecklist.Nodes.Count - 1)))
            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(0)
            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add("MK")
            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(SelPrincipal)
            TrRespostashecklist.Nodes(TrRespostashecklist.Nodes.Count - 1).Nodes.Add(SelText)

            TrParentSel = TrRespostashecklist.Nodes.Count - 1

            PicImagem.Image = Nothing

            'desenha imagens

            'desenha imagens
            If TrRespostashecklist.Nodes.Count > 3 Then

                _IdSelNode += 1

            End If
            Carregado = True
            DesenhaMiniatura()

        End If

    End Sub

    Public PicSel As Image

    Public Sub DesabilitaCampos()

        Carregado = False

        BtnRiscos.Visible = False
        BtnAmassado.Visible = False
        BtnCorrosão.Visible = False
        BtnImpossívelReparar.Visible = False
        BtnPeçaAusente.Visible = False
        BtnPinturaDesbotada.Visible = False

        BtnRasgos.Visible = False
        BtnManchas.Visible = False

        BtnVidroAusente.Visible = False
        BtnVidroQuebrado.Visible = False
        BtnVidroTrincado.Visible = False

        BtnPEAusente.Visible = False
        BtnPEFalha.Visible = False
        BtnPEQuebrado.Visible = False
        BtnPESubstituição.Visible = False

        BtnPMAusente.Visible = False
        BtnPMFalha.Visible = False
        BtnPmQuebrado.Visible = False
        BtnPmSubst.Visible = False

        BtnAcabAusente.Visible = False
        BtnAcabQuebrado.Visible = False
        BtnAcabRisco.Visible = False

    End Sub
    Public Sub HabilitaCampos()

        BtnRiscos.Enabled = True
        BtnAmassado.Enabled = True
        BtnCorrosão.Enabled = True
        BtnImpossívelReparar.Enabled = True
        BtnPeçaAusente.Enabled = True
        BtnPinturaDesbotada.Enabled = True

        BtnRasgos.Enabled = True
        BtnManchas.Enabled = True

        BtnVidroAusente.Enabled = True
        BtnVidroQuebrado.Enabled = True
        BtnVidroTrincado.Enabled = True

        BtnPEAusente.Enabled = True
        BtnPEFalha.Enabled = True
        BtnPEQuebrado.Enabled = True
        BtnPESubstituição.Enabled = True

        BtnPMAusente.Enabled = True
        BtnPMFalha.Enabled = True
        BtnPmQuebrado.Enabled = True
        BtnPmSubst.Enabled = True

        BtnAcabAusente.Enabled = True
        BtnAcabQuebrado.Enabled = True
        BtnAcabRisco.Enabled = True

    End Sub

    Public Ferramenta As String
    Public TipoRisco As String

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        TrParentSel = -1
        PicImagem.BackgroundImageLayout = ImageLayout.Center


        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        SelPrincipal = "Dianteira"

        DesenhaMiniatura()

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs)

    End Sub

    Dim LstIdCapt As New ListBox
    Dim LstIdOrcamento As New ListBox
    Dim LstIdCliente As New ListBox

    Public FabricanteVeic As String
    Public ModeloVeic As String
    Public AnoFab As String
    Public AnoMod As String
    Public Categoria As String

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

        Me.Cursor = Cursors.WaitCursor

        SelPrincipal = "Frontal"

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (1 / 100))

        'busca Url da imagem

        Dim UrlImagem As String = ""

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()
            LstIdCliente.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)
                LstIdCliente.Items.Add(IdCliente)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)
                LstIdCliente.Items.Add(IdCliente)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            Dim BuscaVeiculo = From veic In LqOficina.Veiculos
                               Where veic.IdVeiculoExt = IdVeiculo
                               Select veic.IdCliente

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca pelo numero do orcamento 

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()
            LstIdCliente.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)
                LstIdCliente.Items.Add(BuscaVeiculo.First)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)
                LstIdCliente.Items.Add(BuscaVeiculo.First)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        If UrlImagem <> "" Then

            Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & UrlImagem

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagem = New WebClient()
            'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
            Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

            Dim img As Image = Image.FromStream(stream)

            Dim Pctg As Decimal = 0

            While img.Width - (img.Width * (Pctg / 100)) > PicImagem.Width Or img.Height - (img.Height * (Pctg / 100)) > PicImagem.Height

                Pctg += 1

            End While

            Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
            Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

            Dim PosX As Decimal = 0 + ((PicImagem.Width - X) / 2)
            Dim PosY As Decimal = 0 + ((PicImagem.Height - Y) / 2)

            Pintura.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

            Pintura.DrawImage(img, PosX, PosY, X, Y)

            PicImagem.BackgroundImage = PintarBitmap

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs)

        SelPrincipal = "Dianteira"

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        TrParentSel = -1
        PicImagem.BackgroundImage = My.Resources.untitled_n
        PicImagem.BackgroundImageLayout = ImageLayout.Center

        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True
        BtnPinturaDesbotada.Visible = True

        BtnVidroAusente.Visible = True
        BtnVidroQuebrado.Visible = True
        BtnVidroTrincado.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

        Me.Cursor = Cursors.WaitCursor

        SelPrincipal = "Traseira"

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (1 / 100))

        'busca Url da imagem

        Dim UrlImagem As String = ""

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        If UrlImagem <> "" Then

            Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & UrlImagem

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagem = New WebClient()
            'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
            Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

            Dim img As Image = Image.FromStream(stream)

            Dim Pctg As Decimal = 0

            While img.Width - (img.Width * (Pctg / 100)) > PicImagem.Width Or img.Height - (img.Height * (Pctg / 100)) > PicImagem.Height

                Pctg += 1

            End While

            Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
            Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

            Dim PosX As Decimal = 0 + ((PicImagem.Width - X) / 2)
            Dim PosY As Decimal = 0 + ((PicImagem.Height - Y) / 2)

            Pintura.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

            Pintura.DrawImage(img, PosX, PosY, X, Y)

            PicImagem.BackgroundImage = PintarBitmap

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton3.Click

        Me.Cursor = Cursors.WaitCursor

        SelPrincipal = "Lateral esquerda"

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (1 / 100))

        'busca Url da imagem

        Dim UrlImagem As String = ""

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        If UrlImagem <> "" Then

            Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & UrlImagem

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagem = New WebClient()
            'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
            Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

            Dim img As Image = Image.FromStream(stream)

            Dim Pctg As Decimal = 0

            While img.Width - (img.Width * (Pctg / 100)) > PicImagem.Width Or img.Height - (img.Height * (Pctg / 100)) > PicImagem.Height

                Pctg += 1

            End While

            Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
            Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

            Dim PosX As Decimal = 0 + ((PicImagem.Width - X) / 2)
            Dim PosY As Decimal = 0 + ((PicImagem.Height - Y) / 2)

            Pintura.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

            Pintura.DrawImage(img, PosX, PosY, X, Y)

            PicImagem.BackgroundImage = PintarBitmap

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Public IdCliente As Integer = 0

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton4.Click

        Me.Cursor = Cursors.WaitCursor

        SelPrincipal = "Lateral direita"

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (1 / 100))

        'busca Url da imagem

        Dim UrlImagem As String = ""

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        If UrlImagem <> "" Then

            Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & UrlImagem

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagem = New WebClient()
            'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
            Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

            Dim img As Image = Image.FromStream(stream)

            Dim Pctg As Decimal = 0

            While img.Width - (img.Width * (Pctg / 100)) > PicImagem.Width Or img.Height - (img.Height * (Pctg / 100)) > PicImagem.Height

                Pctg += 1

            End While

            Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
            Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

            Dim PosX As Decimal = 0 + ((PicImagem.Width - X) / 2)
            Dim PosY As Decimal = 0 + ((PicImagem.Height - Y) / 2)

            Pintura.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

            Pintura.DrawImage(img, PosX, PosY, X, Y)

            PicImagem.BackgroundImage = PintarBitmap

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub ToolStripDropDownButton5_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton5.Click

        SelPrincipal = "Interior"

        Dim UrlImagem As String = ""

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (20 / 100))

        Pintura.DrawImage(My.Resources.VInteriorVetor1, 0, Diminuir / 2, PintarBitmap.Width, PintarBitmap.Height - Diminuir)

        PicImagem.BackgroundImage = PintarBitmap

    End Sub

    Private Sub ToolStripDropDownButton6_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton6.Click

        SelPrincipal = "Funcionamento"

        'desenha a imagem de fundo

        Dim UrlImagem As String = ""

        If LblStagio.Text.StartsWith("0") Then

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdSolicitacao = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        Else

            Dim BuscaImagem = From ImgC In LqOficina.ImagemVeiculosColetado
                              Where ImgC.IdSolicitacao = IdCliente And ImgC.Descricao Like SelPrincipal & " - Principal"
                              Select ImgC.ImagemColetadoUrl

            If BuscaImagem.Count > 0 Then
                UrlImagem = BuscaImagem.First
            End If

            'busca avarias registradas

            Dim BuscaImagemAvaria = From ImgC In LqOficina.ImagemVeiculosColetado
                                    Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao"
                                    Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            'Popula imagens avaria

            LstEncontrados.Items.Clear()
            ImageList1.Images.Clear()
            LstIdCapt.Items.Clear()
            LstIdOrcamento.Items.Clear()

            For Each itm In BuscaImagemAvaria.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)


                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

            'busca avarias registradas

            Dim BuscaImagemAvariaComplementar = From ImgC In LqOficina.ImagemVeiculosColetado
                                                Where ImgC.IdCliente = LblNumSoluçãoN.Text And ImgC.Descricao Like SelPrincipal & " - Avaliacao complementar"
                                                Select ImgC.ImagemColetadoUrl, ImgC.IdImagemColetada, ImgC.idImagemColetadaExt

            For Each itm In BuscaImagemAvariaComplementar.ToList

                LstEncontrados.Items.Add(itm.ImagemColetadoUrl)
                LstIdCapt.Items.Add(itm.idImagemColetadaExt)

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & itm.ImagemColetadoUrl

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Dim PintarBitmapMini = New Bitmap(150, 150)

                Dim PinturaMini = Graphics.FromImage(PintarBitmapMini)

                Dim Pctg As Decimal = 0

                While img.Width - (img.Width * (Pctg / 100)) > 150 Or img.Height - (img.Height * (Pctg / 100)) > 150

                    Pctg += 1

                End While

                Dim X As Decimal = img.Width - (img.Width * (Pctg / 100))
                Dim Y As Decimal = img.Height - (img.Height * (Pctg / 100))

                Dim PosX As Decimal = 0 + ((150 - X) / 2)
                Dim PosY As Decimal = 0 + ((150 - Y) / 2)

                PinturaMini.FillRectangle(New SolidBrush(Color.Black), 0, 0, PicImagem.Width, PicImagem.Height)

                PinturaMini.DrawImage(img, PosX, PosY, X, Y)

                Dim Minisatura As Image = PintarBitmapMini

                ImageList1.Images.Add(Minisatura)

                LstEncontrados.Items(LstEncontrados.Items.Count - 1).ImageIndex = ImageList1.Images.Count - 1

                'busca o numero do orçamento

                Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & itm.idImagemColetadaExt

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientOrcamento = New WebClient()
                Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
                Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

                If readOrcamento.Count > 0 Then
                    LstIdOrcamento.Items.Add(readOrcamento.Item(0).Id)
                Else
                    LstIdOrcamento.Items.Add(0)
                End If

            Next

        End If

        'desenha a imagem de fundo
        Dim PintarBitmap = New Bitmap(PicImagem.Width, PicImagem.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim Diminuir As Decimal = (PicImagem.Height * (20 / 100))

        Pintura.DrawImage(My.Resources.VAcessoriosParteMecanica1, 0, Diminuir / 2, PintarBitmap.Width, PintarBitmap.Height - Diminuir)

        PicImagem.BackgroundImage = PintarBitmap

    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnVidroAusente.Visible = True
        BtnVidroQuebrado.Visible = True
        BtnVidroTrincado.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem23_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem4_Click_1(sender As Object, e As EventArgs)

        SelPrincipal = "Dianteira"

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem5_Click_1(sender As Object, e As EventArgs)

        SelPrincipal = "Dianteira"

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnVidroAusente.Visible = True
        BtnVidroQuebrado.Visible = True
        BtnVidroTrincado.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnVidroAusente.Visible = True
        BtnVidroQuebrado.Visible = True
        BtnVidroTrincado.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnVidroAusente.Visible = True
        BtnVidroQuebrado.Visible = True
        BtnVidroTrincado.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem21_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRiscos.Visible = True
        BtnAmassado.Visible = True
        BtnCorrosão.Visible = True
        BtnImpossívelReparar.Visible = True
        BtnPeçaAusente.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem22_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem26_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem25_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem27_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem28_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnRasgos.Visible = True
        BtnManchas.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem29_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem30_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem31_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem32_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnRasgos.Visible = True
        BtnManchas.Visible = True

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem35_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True


        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem36_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem37_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPEAusente.Visible = True
        BtnPEFalha.Visible = True
        BtnPEQuebrado.Visible = True
        BtnPESubstituição.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem38_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem39_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem40_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem44_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        'PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem42_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem41_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnPMAusente.Visible = True
        BtnPMFalha.Visible = True
        BtnPmQuebrado.Visible = True
        BtnPmSubst.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs)

        'desabilita campos

        DesabilitaCampos()

        'habilita campos

        BtnAcabAusente.Visible = True
        BtnAcabQuebrado.Visible = True
        BtnAcabRisco.Visible = True
        BtnPinturaDesbotada.Visible = True

        BttCarregar.Enabled = True

        PicImagem.BackgroundImageLayout = ImageLayout.Center
        TrParentSel = -1

        PicImagem.BackgroundImage = My.Resources.untitled_n
        PicImagem.Image = Nothing

        DesenhaMiniatura()

    End Sub

    Private Sub PnnInferior_Paint(sender As Object, e As PaintEventArgs) Handles PnnInferior.Paint

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub BtnRiscos_Click(sender As Object, e As EventArgs) Handles BtnRiscos.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Lataria." & BtnRiscos.Text
        TipoRisco = "Line"

        PintaMk()

    End Sub

    Private Sub BtnAcabRisco_Click(sender As Object, e As EventArgs) Handles BtnAcabRisco.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Acabamentos." & BtnAcabRisco.Text
        TipoRisco = "Line"

        PintaMk()

    End Sub

    Private Sub BtnAmassado_Click(sender As Object, e As EventArgs) Handles BtnAmassado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Lataria." & BtnAmassado.Text
        TipoRisco = "Area"

        PintaMk()

    End Sub

    Private Sub BtnImpossívelReparar_Click(sender As Object, e As EventArgs) Handles BtnImpossívelReparar.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Lataria." & BtnImpossívelReparar.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPeçaAusente_Click(sender As Object, e As EventArgs) Handles BtnPeçaAusente.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Lataria." & BtnPeçaAusente.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPinturaDesbotada_Click(sender As Object, e As EventArgs) Handles BtnPinturaDesbotada.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Lataria." & BtnPinturaDesbotada.Text
        TipoRisco = "Area"

        PintaMk()

    End Sub

    Private Sub BtnCorrosão_Click(sender As Object, e As EventArgs) Handles BtnCorrosão.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Lataria." & BtnCorrosão.Text
        TipoRisco = "Area"

        PintaMk()

    End Sub

    Private Sub BtnRasgos_Click(sender As Object, e As EventArgs) Handles BtnRasgos.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Tecidos." & BtnRasgos.Text
        TipoRisco = "Line"

        PintaMk()

    End Sub

    Private Sub BtnManchas_Click(sender As Object, e As EventArgs) Handles BtnManchas.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = True

        Ferramenta = "Tecidos." & BtnManchas.Text
        TipoRisco = "Area"

        PintaMk()

    End Sub

    Private Sub BtnAcabAusente_Click(sender As Object, e As EventArgs) Handles BtnAcabAusente.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Acabamentos." & BtnAcabAusente.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnAcabQuebrado_Click(sender As Object, e As EventArgs) Handles BtnAcabQuebrado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Acabamentos." & BtnAcabQuebrado.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPMAusente_Click(sender As Object, e As EventArgs) Handles BtnPMAusente.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Mecânica." & BtnPMAusente.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPmQuebrado_Click(sender As Object, e As EventArgs) Handles BtnPmQuebrado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Mecânica." & BtnPmQuebrado.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPMFalha_Click(sender As Object, e As EventArgs) Handles BtnPMFalha.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Mecânica." & BtnPMFalha.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPmSubst_Click(sender As Object, e As EventArgs) Handles BtnPmSubst.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Mecânica." & BtnPmSubst.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnVidroAusente_Click(sender As Object, e As EventArgs) Handles BtnVidroAusente.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Vidros." & BtnVidroAusente.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnVidroQuebrado_Click(sender As Object, e As EventArgs) Handles BtnVidroQuebrado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Vidros." & BtnVidroQuebrado.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnVidroTrincado_Click(sender As Object, e As EventArgs) Handles BtnVidroTrincado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Press = False

        Ferramenta = "Vidros." & BtnPEAusente.Text
        TipoRisco = "Line"

        PintaMk()

    End Sub

    Private Sub BtnPEAusente_Click(sender As Object, e As EventArgs) Handles BtnPEAusente.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Eletrica." & BtnPEAusente.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPEFalha_Click(sender As Object, e As EventArgs) Handles BtnPEFalha.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Eletrica." & BtnPEFalha.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPEQuebrado_Click(sender As Object, e As EventArgs) Handles BtnPEQuebrado.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Eletrica." & BtnPEQuebrado.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Private Sub BtnPESubstituição_Click(sender As Object, e As EventArgs) Handles BtnPESubstituição.Click

        Selecionar = False

        PicImagem.Cursor = Cursors.Cross

        Ferramenta = "Eletrica." & BtnPESubstituição.Text
        TipoRisco = "Point"

        PintaMk()

    End Sub

    Public Selecionar As Boolean = False

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        'TrRespostashecklist.Visible = True

        Selecionar = True

        PicImagem.Cursor = Cursors.Arrow

        Ferramenta = "Selecionar"
        TipoRisco = "ND"

        PintaMk()

    End Sub

    Dim LqComercial As New LqComercialDataContext
    Dim LqFinanceiro As New LqFinanceiroDataContext

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        If LblStagio.Text = "Avaliação inicial" Then

            'insere avaliação inicial

            LqOficina.AtualizaEncerraVistoriaVeiculo(LblNumProcessoN.Text, Now.TimeOfDay, Today.Date, True)

            'insere solução

            'insere os iens que foram encontrados

            For Each row As TreeNode In TrRespostashecklist.Nodes

                '
                Dim TrPrincipal As TreeNode = row.Nodes(2)

                'insere nova imagem

                Dim Str_Arq As String = row.Text

                Dim ImageSelecionada As Image

                'varre imagens

                If Str_Arq.StartsWith("+") Then

                    ImageSelecionada = Image.FromFile(Str_Arq.ToString.Remove(0, 1))

                    ''pinta uma imagem menor

                    'Dim H As Integer = 848
                    'Dim V As Integer = 548

                    'Dim PintarBitmap = New Bitmap(H, V)

                    'Dim Pintura = Graphics.FromImage(PintarBitmap)

                    'Dim Str As String = TrRespostashecklist.Nodes(TrParentSel).Text

                    'If Str.StartsWith("+") Then

                    '    Str = Str.Remove(0, 1)

                    '    Pintura.DrawImage(System.Drawing.Image.FromFile(Str), 0, 0, H, V)

                    'End If


                    'ImageSelecionada = PintarBitmap

                    'declara imagem em formato para o banco de dados

                    Dim arrImage() As Byte
                    Dim strImage As String
                    Dim myMs As New IO.MemoryStream
                    '5rt3w6e5,gq6KL
                    If Not IsNothing(ImageSelecionada) Then
                        ImageSelecionada.Save(myMs, ImageSelecionada.RawFormat)
                        arrImage = myMs.GetBuffer
                        strImage = "?"
                    Else
                        arrImage = Nothing
                        strImage = "NULL"
                    End If

                    'insere a imagem

                    Dim _SelPrincipal As String = row.Nodes(3).Text
                    Dim _SelText As String = row.Nodes(4).Text

                    Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                                         Where cat.Descricao Like _SelPrincipal
                                         Select cat.IdCategoriaProduto

                    Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                            Where cat.IdCategoria = BuscaCategoria.First And cat.Descricao Like _SelText
                                            Select cat.IdSubCategoria

                    Dim Conseguir As Boolean = False

                    While Conseguir = False

                        Try

                            LqOficina.InsereImagemRespostaCheklistUsuario(0, arrImage, _SelPrincipal & "," & _SelText, LblNumProcessoN.Text, BuscaCategoria.First, BuscaSubCategoria.First, Nothing)

                            Conseguir = True

                        Catch ex As Exception

                            Conseguir = False

                        End Try

                    End While

                    myMs.Dispose()

                    'busca Id ultima imagem inserida

                    Dim buscaImagem = From img In LqOficina.ImagemRespostaCklist
                                      Where img.IdProcesso = LblNumProcessoN.Text
                                      Select img.IdImagemProcesso
                                      Order By IdImagemProcesso Descending

                    'verifica marcações

                    Dim TrPts As TreeNode = row.Nodes(2)

                    Dim LstCatalogo As New ListBox

                    For Each row1 As TreeNode In TrPts.Nodes

                        LstCatalogo.Items.Add(row1.Text)

                        'procura qtdade de itens 

                        Dim QT As Integer = 0

                        For i As Integer = 0 To LstCatalogo.Items.Count - 1 Step 1

                            If LstCatalogo.Items(i).ToString = row1.Text Then

                                QT += 1

                            End If

                        Next

                        Dim TrPts1 As TreeNode = row1.Nodes(0)

                        Dim Total_da_lista_de_points As Integer = TrPts1.Nodes.Count - 1

                        Dim IdMarca As String = ""
                        Dim IdSolucaoN As String = ""

                        For i As Integer = 0 To Total_da_lista_de_points Step 2

                            Dim X As Integer = TrPts1.Nodes(i).Text
                            Dim Y As Integer = TrPts1.Nodes(i + 1).Text

                            LqOficina.InsereMarcaImagem(buscaImagem.First, row1.Text, X, Y, LblNumProcessoN.Text, row1.Nodes(2).Text)

                            If IdMarca = "" Then

                                'BuscaIdMarca 

                                Dim buscaMarca = From mk In LqOficina.MarcasImagens
                                                 Where mk.IdImagem = buscaImagem.First
                                                 Select mk.IdMarcaImagem

                                IdMarca = buscaMarca.First

                                'insere solução

                                LqOficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, LblNumProcessoN.Text, IdMarca)

                                Dim BuscaSolucao = From sol In LqOficina.SoluçõesVistoria
                                                   Where sol.IdMarca = IdMarca
                                                   Select sol.IdSolucoes

                                IdSolucaoN = BuscaSolucao.First

                            End If

                        Next

                        For Each row3 As TreeNode In TrPrincipal.Nodes

                            Dim TrAvanço2 As TreeNode = row1.Nodes(1)

                            'insere a marca a imagem

                            For Each row2 As TreeNode In TrAvanço2.Nodes(0).Nodes

                                Dim IdProduto As String = row2.Text
                                Dim Qtdade As Integer = row2.Nodes(2).Text
                                Dim NecIni As Boolean = row2.Nodes(3).Text

                                'define o tamanho da imagem 

                                If IdProduto.StartsWith("S") Then

                                    Dim Cod As Integer = IdProduto.Remove(0, 1)

                                    LqOficina.InsereItemSolucao(0, True, Cod, Qtdade, NecIni, IdSolucaoN)

                                Else

                                    LqOficina.InsereItemSolucao(IdProduto, True, 0, Qtdade, NecIni, IdSolucaoN)

                                End If

                            Next


                            For Each row2 As TreeNode In TrAvanço2.Nodes(1).Nodes

                                Dim IdProduto As String = row2.Text
                                'Dim Qtdade As Integer = row2.Nodes(2).Text

                                'define o tamanho da imagem 

                                LqOficina.InsereItemSolucao(IdProduto, False, 0, 1, True, IdSolucaoN)

                            Next

                        Next

                    Next

                End If

            Next

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        ElseIf LblStagio.Text = "Desmonte" Then

            LqOficina.AtualizaEncerraVistoriaVeiculo(LblNumSoluçãoN.Text, Now.TimeOfDay, Today.Date, True)

            'gera orçamento

            'insere novo orçamento

            LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, 0, "1111/11/11", Today.TimeOfDay, Today.Date, Now.TimeOfDay, _IdCliente, _IdVeiculo, False, "1111/11/11", Today.TimeOfDay, 0, LblNumSoluçãoN.Text, 0, 0, False, False, 0, "1111-11-11")

            For Each row As TreeNode In TrRespostashecklist.Nodes

                '
                Dim TrPrincipal As TreeNode = row.Nodes(2)

                'insere nova imagem

                Dim Str_Arq As String = row.Text

                Dim ImageSelecionada As Image

                'varre imagens

                If Str_Arq.StartsWith("+") Then

                    ImageSelecionada = Image.FromFile(Str_Arq.ToString.Remove(0, 1))

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

                    'insere a imagem

                    Dim _SelPrincipal As String = row.Nodes(3).Text
                    Dim _SelText As String = row.Nodes(4).Text

                    Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                                         Where cat.Descricao Like _SelPrincipal
                                         Select cat.IdCategoriaProduto

                    Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                            Where cat.IdCategoria = BuscaCategoria.First And cat.Descricao Like _SelText
                                            Select cat.IdSubCategoria

                    LqOficina.InsereImagemRespostaCheklistUsuario(0, arrImage, _SelPrincipal & "," & _SelText, LblNumProcessoN.Text, BuscaCategoria.First, BuscaSubCategoria.First, Nothing)

                    myMs.Dispose()

                    'busca Id ultima imagem inserida

                    Dim buscaImagem = From img In LqOficina.ImagemRespostaCklist
                                      Where img.IdProcesso = LblNumProcessoN.Text
                                      Select img.IdImagemProcesso

                    'verifica marcações

                    Dim TrPts As TreeNode = row.Nodes(2)

                    Dim LstCatalogo As New ListBox

                    For Each row1 As TreeNode In TrPts.Nodes


                        Dim QtND As Integer = row1.Nodes.Count

                        If QtND < 4 Then

                            LstCatalogo.Items.Add(row1.Text)

                            'procura qtdade de itens 

                            Dim _QT As Integer = 0

                            For i As Integer = 0 To LstCatalogo.Items.Count - 1 Step 1

                                If LstCatalogo.Items(i).ToString = row1.Text Then

                                    _QT += 1

                                End If

                            Next

                            Dim TrPts1 As TreeNode = row1.Nodes(0)

                            Dim Total_da_lista_de_points As Integer = TrPts1.Nodes.Count - 1

                            Dim IdMarca As String = ""
                            Dim IdSolucaoN As String = ""

                            For i As Integer = 0 To Total_da_lista_de_points Step 2

                                Dim X As Integer = TrPts1.Nodes(i).Text
                                Dim Y As Integer = TrPts1.Nodes(i + 1).Text

                                LqOficina.InsereMarcaImagem(buscaImagem.First, row1.Text, X, Y, LblNumProcessoN.Text, row1.Nodes(2).Text)

                                If IdMarca = "" Then

                                    'BuscaIdMarca 

                                    Dim buscaMarca = From mk In LqOficina.MarcasImagens
                                                     Where mk.IdImagem = buscaImagem.First
                                                     Select mk.IdMarcaImagem

                                    IdMarca = buscaMarca.First

                                    'insere solução

                                    LqOficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, LblNumProcessoN.Text, IdMarca)

                                    Dim BuscaSolucao = From sol In LqOficina.SoluçõesVistoria
                                                       Where sol.IdMarca = IdMarca
                                                       Select sol.IdSolucoes

                                    IdSolucaoN = BuscaSolucao.First

                                End If

                            Next

                            For Each row3 As TreeNode In TrPrincipal.Nodes

                                Dim TrAvanço2 As TreeNode = row1.Nodes(1)

                                'insere a marca a imagem

                                For Each row2 As TreeNode In TrAvanço2.Nodes(0).Nodes

                                    Dim IdProduto As String = row2.Text
                                    Dim Qtdade As Integer = row2.Nodes(2).Text
                                    Dim NecIni As Boolean = row2.Nodes(3).Text

                                    'define o tamanho da imagem 

                                    If IdProduto.StartsWith("S") Then

                                        Dim Cod As Integer = IdProduto.Remove(0, 1)

                                        LqOficina.InsereItemSolucao(0, True, Cod, Qtdade, NecIni, IdSolucaoN)

                                        Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                             Select orc.IdOrcamento
                                                             Order By IdOrcamento Descending

                                        LqComercial.InsereNovoItemOrcamento(Cod, 0, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                        'verifica se item necessita de cotação imediata

                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)

                                    Else

                                        LqOficina.InsereItemSolucao(IdProduto, True, 0, Qtdade, NecIni, IdSolucaoN)

                                        Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                             Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                             Select orc.IdOrcamento
                                                             Order By IdOrcamento Descending

                                        LqComercial.InsereNovoItemOrcamento(0, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                        'verifica se item necessita de cotação imediata

                                        'busca armazenagem 

                                        Dim LqEstoque As New LqEstoqueLocalDataContext

                                        Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                               Where arm.IdProduto = IdProduto
                                                               Select arm.Qt

                                        Dim TTEst As Integer = 0

                                        For Each rowItt In buscaImagem.ToList

                                            TTEst += rowItt

                                        Next

                                        If TTEst < Qtdade Then

                                            LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdProduto, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)

                                        End If

                                    End If

                                Next

                                For Each row2 As TreeNode In TrAvanço2.Nodes(1).Nodes

                                    Dim IdProduto As String = row2.Text
                                    Dim Qtdade As Integer = row2.Nodes(1).Text

                                    'define o tamanho da imagem 

                                    LqOficina.InsereItemSolucao(IdProduto, False, 0, Qtdade, True, IdSolucaoN)

                                    Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                         Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                         Select orc.IdOrcamento
                                                         Order By IdOrcamento Descending

                                    LqComercial.InsereNovoItemOrcamento(IdSolucaoN, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, False, LblNumSoluçãoN.Text, 0)

                                Next

                            Next

                        End If

                    Next

                Else

                    LqOficina.DeletaMarcasImagem(row.Text)

                    'insere a imagem

                    Dim _SelPrincipal As String = row.Nodes(3).Text
                    Dim _SelText As String = row.Nodes(4).Text

                    'verifica marcações

                    Dim TrPts As TreeNode = row.Nodes(2)

                    Dim LstCatalogo As New ListBox

                    Dim IdMarca As String = ""
                    Dim IdSolucaoN As String = ""

                    Dim PInta As Boolean = False

                    For Each row1 As TreeNode In row.Nodes(2).Nodes

                        Dim QtND As Integer = row1.Nodes.Count

                        If QtND < 5 Then

                            LstCatalogo.Items.Add(row1.Text)

                            'procura qtdade de itens 

                            Dim _QT As Integer = 0

                            For i As Integer = 0 To LstCatalogo.Items.Count - 1 Step 1

                                If LstCatalogo.Items(i).ToString = row1.Text Then

                                    _QT += 1

                                End If

                            Next

                            Dim TrPts1 As TreeNode = row1.Nodes(0)

                            Dim Total_da_lista_de_points As Integer = TrPts1.Nodes.Count - 1

                            'verifica se ja foi lançado

                            'remove orçamentos

                            For i As Integer = 0 To Total_da_lista_de_points Step 2

                                Dim X As Integer = TrPts1.Nodes(i).Text
                                Dim Y As Integer = TrPts1.Nodes(i + 1).Text

                                LqOficina.InsereMarcaImagem(row.Text, row1.Text, X, Y, LblNumSoluçãoN.Text, row1.Nodes(2).Text)

                                If IdMarca = "" Then

                                    'BuscaIdMarca 

                                    Dim buscaMarca = From mk In LqOficina.MarcasImagens
                                                     Where mk.IdImagem = row.Text
                                                     Select mk.IdMarcaImagem
                                                     Order By IdMarcaImagem Descending

                                    IdMarca = buscaMarca.First

                                    'insere solução 

                                    LqOficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, LblNumSoluçãoN.Text, IdMarca)

                                    Dim BuscaSolucao = From sol In LqOficina.SoluçõesVistoria
                                                       Where sol.IdMarca = IdMarca
                                                       Select sol.IdSolucoes

                                    IdSolucaoN = BuscaSolucao.First

                                End If

                            Next

                            For Each row3 As TreeNode In row1.Nodes(1).Nodes

                                If row3.Nodes.Count > 0 Then

                                    If row3.Text = "Produtos" Then

                                        'insere a marca a imagem

                                        For Each row2 As TreeNode In row3.Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(2).Text
                                            Dim NecIni As Boolean = row2.Nodes(3).Text

                                            'define o tamanho da imagem 

                                            If IdProduto.StartsWith("S") Then

                                                Dim Cod As Integer = IdProduto.Remove(0, 1)

                                                LqOficina.InsereItemSolucao(0, True, Cod, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(Cod, 0, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                   Where cot.IdSolicitacaoCad = Cod
                                                                   Select cot.DataCotacao

                                                If BuscaCotação.Count = 0 Then
                                                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                Else
                                                    If BuscaCotação.First.Value.AddDays(7) < Today.Date Then
                                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                    End If
                                                End If

                                            Else

                                                LqOficina.InsereItemSolucao(IdProduto, True, 0, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(0, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                Dim LqEstoque As New LqEstoqueLocalDataContext

                                                LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

                                                Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                                       Where arm.IdProduto = IdProduto
                                                                       Select arm.Qt

                                                Dim TTEst As Integer = 0

                                                For Each rowItt In BuscaArmazenagem.ToList

                                                    TTEst += rowItt

                                                Next

                                                If TTEst < Qtdade Then

                                                    'verifica se existe cotação ativa

                                                    Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                       Where cot.IdProduto = IdProduto
                                                                       Select cot.DataCotacao

                                                    If BuscaCotação.Count = 0 Then
                                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdProduto, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                    Else
                                                        If BuscaCotação.First.Value.AddDays(7) < Today.Date Then
                                                            LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdProduto, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                        End If
                                                    End If


                                                End If

                                            End If

                                        Next

                                    ElseIf row3.Text = "Serviços" Then

                                        For Each row2 As TreeNode In row3.Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(1).Text

                                            'define o tamanho da imagem 

                                            LqOficina.InsereItemSolucao(IdProduto, False, 0, Qtdade, True, IdSolucaoN)

                                            Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                 Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                 Select orc.IdOrcamento
                                                                 Order By IdOrcamento Descending


                                            LqComercial.InsereNovoItemOrcamento(IdSolucaoN, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, False, LblNumSoluçãoN.Text, 0)

                                        Next

                                    End If

                                End If
                            Next

                        End If

                    Next

                    LqOficina.DeletaSItemolucaoMarcaImagem(LblNumProcessoN.Text)
                    LqOficina.DeletaSolucaoMarcaImagem(LblNumProcessoN.Text)

                End If

            Next

            FrmPrincipal.CarregaDashboard()

            Me.Close()

        ElseIf LblStagio.Text = "Avaliação complementar" Then

            LqOficina.AtualizaEncerraVistoriaVeiculo(LblNumSoluçãoN.Text, Now.TimeOfDay, Today.Date, True)

            'insere novo orçamento

            LqComercial.InsereNovoOrcamento(FrmPrincipal.IdUsuario, 0, "1111/11/11", Today.TimeOfDay, Today.Date, Now.TimeOfDay, _IdCliente, _IdVeiculo, False, "1111/11/11", Today.TimeOfDay, 0, LblNumSoluçãoN.Text, 0, 0, False, False, 0, "1111-11-11")

            For Each row As TreeNode In TrRespostashecklist.Nodes

                '
                Dim TrPrincipal As TreeNode = row.Nodes(2)

                'insere nova imagem

                Dim Str_Arq As String = row.Text

                Dim ImageSelecionada As Image

                'varre imagens

                If Str_Arq.StartsWith("+") Then

                    ImageSelecionada = Image.FromFile(Str_Arq.ToString.Remove(0, 1))

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

                    'insere a imagem

                    Dim _SelPrincipal As String = row.Nodes(3).Text
                    Dim _SelText As String = row.Nodes(4).Text

                    Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                                         Where cat.Descricao Like _SelPrincipal
                                         Select cat.IdCategoriaProduto

                    Dim BuscaSubCategoria = From cat In LqBase.SubCategoriasProduto
                                            Where cat.IdCategoria = BuscaCategoria.First And cat.Descricao Like _SelText
                                            Select cat.IdSubCategoria

                    LqOficina.InsereImagemRespostaCheklistUsuario(0, arrImage, _SelPrincipal & "," & _SelText, LblNumProcessoN.Text, BuscaCategoria.First, BuscaSubCategoria.First, Nothing)

                    myMs.Dispose()

                    'busca Id ultima imagem inserida

                    Dim buscaImagem = From img In LqOficina.ImagemRespostaCklist
                                      Where img.IdProcesso = LblNumProcessoN.Text
                                      Select img.IdImagemProcesso

                    'verifica marcações

                    Dim TrPts As TreeNode = row.Nodes(2)

                    Dim LstCatalogo As New ListBox

                    Dim IdMarca As String = ""
                    Dim IdSolucaoN As String = ""

                    Dim PInta As Boolean = False

                    For Each row1 As TreeNode In row.Nodes(2).Nodes

                        Dim QtND As Integer = row1.Nodes.Count

                        If QtND < 4 Then

                            LstCatalogo.Items.Add(row1.Text)

                            'procura qtdade de itens 

                            Dim _QT As Integer = 0

                            For i As Integer = 0 To LstCatalogo.Items.Count - 1 Step 1

                                If LstCatalogo.Items(i).ToString = row1.Text Then

                                    _QT += 1

                                End If

                            Next

                            Dim TrPts1 As TreeNode = row1.Nodes(0)

                            Dim Total_da_lista_de_points As Integer = TrPts1.Nodes.Count - 1

                            'verifica se ja foi lançado

                            'remove orçamentos

                            For i As Integer = 0 To Total_da_lista_de_points Step 2

                                Dim X As Integer = TrPts1.Nodes(i).Text
                                Dim Y As Integer = TrPts1.Nodes(i + 1).Text

                                LqOficina.InsereMarcaImagem(row.Text, row1.Text, X, Y, LblNumSoluçãoN.Text, row1.Nodes(2).Text)

                                If IdMarca = "" Then

                                    'BuscaIdMarca 

                                    Dim buscaMarca = From mk In LqOficina.MarcasImagens
                                                     Where mk.IdImagem = row.Text
                                                     Select mk.IdMarcaImagem
                                                     Order By IdMarcaImagem Descending

                                    IdMarca = buscaMarca.First

                                    'insere solução 

                                    LqOficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, LblNumSoluçãoN.Text, IdMarca)

                                    Dim BuscaSolucao = From sol In LqOficina.SoluçõesVistoria
                                                       Where sol.IdMarca = IdMarca
                                                       Select sol.IdSolucoes

                                    IdSolucaoN = BuscaSolucao.First

                                End If

                            Next

                            For Each row3 As TreeNode In row1.Nodes(1).Nodes

                                If row3.Nodes.Count > 0 Then

                                    If row3.Text = "Produtos" Then

                                        'insere a marca a imagem

                                        For Each row2 As TreeNode In row3.Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(2).Text
                                            Dim NecIni As Boolean = row2.Nodes(3).Text

                                            'define o tamanho da imagem 

                                            If IdProduto.StartsWith("S") Then

                                                Dim Cod As Integer = IdProduto.Remove(0, 1)

                                                LqOficina.InsereItemSolucao(0, True, Cod, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(Cod, 0, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                   Where cot.IdSolicitacaoCad = Cod And cot.DataCotacao.Value.AddDays(7) <= Today.Date
                                                                   Select cot.DataCotacao

                                                If BuscaCotação.Count = 0 Then
                                                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                End If

                                            Else

                                                LqOficina.InsereItemSolucao(IdProduto, True, 0, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(0, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                Dim LqEstoque As New LqEstoqueLocalDataContext

                                                Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                                       Where arm.IdProduto = IdProduto
                                                                       Select arm.Qt

                                                Dim TTEst As Integer = 0

                                                For Each rowItt In BuscaArmazenagem.ToList

                                                    TTEst += rowItt

                                                Next

                                                If TTEst < Qtdade Then

                                                    'verifica se existe cotação ativa

                                                    Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                       Where cot.IdProduto = IdProduto And cot.DataCotacao.Value.AddDays(7) <= Today.Date
                                                                       Select cot.DataCotacao

                                                    If BuscaCotação.Count = 0 Then
                                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, 0, IdProduto, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                    End If

                                                End If

                                            End If

                                        Next

                                    ElseIf row3.Text = "Serviços" Then

                                        For Each row2 As TreeNode In row3.Nodes(1).Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(2).Text

                                            'define o tamanho da imagem 

                                            LqOficina.InsereItemSolucao(IdProduto, False, 0, Qtdade, True, IdSolucaoN)

                                            Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                 Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                 Select orc.IdOrcamento
                                                                 Order By IdOrcamento Descending


                                            LqComercial.InsereNovoItemOrcamento(IdSolucaoN, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, False, LblNumSoluçãoN.Text, 0)

                                        Next

                                    End If

                                End If
                            Next

                        End If

                    Next

                Else

                    'insere a imagem

                    Dim _SelPrincipal As String = row.Nodes(3).Text
                    Dim _SelText As String = row.Nodes(4).Text

                    'verifica marcações

                    Dim TrPts As TreeNode = row.Nodes(2)

                    Dim LstCatalogo As New ListBox
                    Dim LstIdMarcaDescartada As New ListBox

                    Dim IdMarca As String = ""
                    Dim IdSolucaoN As String = ""

                    Dim PInta As Boolean = False

                    For Each row1 As TreeNode In row.Nodes(2).Nodes

                        Dim QtND As Integer = row1.Nodes.Count

                        If QtND < 4 Then

                            LstCatalogo.Items.Add(row1.Text)

                            'procura qtdade de itens 

                            Dim _QT As Integer = 0

                            For i As Integer = 0 To LstCatalogo.Items.Count - 1 Step 1

                                If LstCatalogo.Items(i).ToString = row1.Text Then

                                    _QT += 1

                                End If

                            Next

                            Dim TrPts1 As TreeNode = row1.Nodes(0)

                            Dim Total_da_lista_de_points As Integer = TrPts1.Nodes.Count - 1

                            'verifica se ja foi lançado
                            'remove orçamentos

                            For i As Integer = 0 To Total_da_lista_de_points Step 2

                                Dim X As Integer = TrPts1.Nodes(i).Text
                                Dim Y As Integer = TrPts1.Nodes(i + 1).Text

                                LqOficina.InsereMarcaImagem(row.Text, row1.Text, X, Y, LblNumSoluçãoN.Text, row1.Nodes(2).Text)

                                If IdMarca = "" Then

                                    'BuscaIdMarca 

                                    Dim buscaMarca = From mk In LqOficina.MarcasImagens
                                                     Where mk.IdImagem = row.Text
                                                     Select mk.IdMarcaImagem
                                                     Order By IdMarcaImagem Descending

                                    IdMarca = buscaMarca.First

                                    'insere solução 

                                    LqOficina.InsereSolucaoVistoria(0, FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, Today.Date, Now.TimeOfDay, True, LblNumSoluçãoN.Text, IdMarca)

                                    Dim BuscaSolucao = From sol In LqOficina.SoluçõesVistoria
                                                       Where sol.IdMarca = IdMarca
                                                       Select sol.IdSolucoes

                                    IdSolucaoN = BuscaSolucao.First

                                End If

                            Next

                            For Each row3 As TreeNode In row1.Nodes(1).Nodes

                                If row3.Nodes.Count > 0 Then

                                    If row3.Text = "Produtos" Then

                                        'insere a marca a imagem

                                        For Each row2 As TreeNode In row3.Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(2).Text
                                            Dim NecIni As Boolean = row2.Nodes(3).Text

                                            'define o tamanho da imagem 

                                            If IdProduto.StartsWith("S") Then

                                                Dim Cod As Integer = IdProduto.Remove(0, 1)

                                                LqOficina.InsereItemSolucao(0, True, Cod, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(Cod, 0, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                'verifica se existe cotação ativa

                                                Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                   Where cot.IdSolicitacaoCad = Cod
                                                                   Select cot.DataCotacao

                                                If BuscaCotação.Count > 0 Then
                                                    'verifica datas

                                                    If BuscaCotação.First.Value.AddDays(7) < Today.Date Then

                                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)

                                                    End If

                                                Else

                                                    LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, 0, Cod, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)

                                                End If

                                            Else

                                                LqOficina.InsereItemSolucao(IdProduto, True, 0, Qtdade, NecIni, IdSolucaoN)

                                                Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                     Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                     Select orc.IdOrcamento
                                                                     Order By IdOrcamento Descending

                                                LqComercial.InsereNovoItemOrcamento(0, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, True, LblNumSoluçãoN.Text, 0)

                                                'verifica se item necessita de cotação imediata

                                                'busca armazenagem 

                                                Dim LqEstoque As New LqEstoqueLocalDataContext

                                                Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                                       Where arm.IdProduto = IdProduto
                                                                       Select arm.Qt

                                                Dim TTEst As Integer = 0

                                                For Each rowItt In BuscaArmazenagem.ToList

                                                    TTEst += rowItt

                                                Next

                                                If TTEst < Qtdade Then

                                                    'verifica se existe cotação ativa

                                                    Dim BuscaCotação = From cot In LqFinanceiro.Cotacoes
                                                                       Where cot.IdProduto = IdProduto
                                                                       Select cot.DataCotacao

                                                    If BuscaCotação.Count = 0 Then
                                                        LqFinanceiro.InsereNovaCotacao(FrmPrincipal.IdUsuario, Today.Date, Now.TimeOfDay, IdProduto, 0, 0, "1111-11-11", Today.TimeOfDay, 0, 0, 0, 0, False, 0, "1111-11-11", Today.TimeOfDay, Qtdade, 0, 0)
                                                    End If

                                                End If

                                            End If

                                        Next

                                    ElseIf row3.Text = "Serviços" Then

                                        For Each row2 As TreeNode In row3.Nodes

                                            Dim IdProduto As String = row2.Text
                                            Dim Qtdade As Integer = row2.Nodes(1).Text

                                            'define o tamanho da imagem 

                                            LqOficina.InsereItemSolucao(IdProduto, False, 0, Qtdade, True, IdSolucaoN)

                                            Dim BuscaOrçamento = From orc In LqComercial.Orcamentos
                                                                 Where orc.IdCliente = _IdCliente And orc.Aprovado = False And orc.IdVeiculo = _IdVeiculo
                                                                 Select orc.IdOrcamento
                                                                 Order By IdOrcamento Descending


                                            LqComercial.InsereNovoItemOrcamento(0, IdProduto, BuscaOrçamento.First, Qtdade, 1, 0, 0, Today.Date, False, LblNumSoluçãoN.Text, 0)

                                        Next

                                    End If

                                End If

                            Next

                        End If

                    Next

                End If

            Next

            FrmPrincipal.CarregaDashboard()

            FrmStart.Close()

            Me.Close()

        End If

        FrmPrincipal.Timer1.Enabled = True

    End Sub

    Private Sub LstEncontrados_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstEncontrados.SelectedIndexChanged

    End Sub

    Private Sub LstEncontrados_DoubleClick(sender As Object, e As EventArgs) Handles LstEncontrados.DoubleClick

        Me.Cursor = Cursors.WaitCursor

        Dim baseUrlOrcamento As String = "http://www.iarasoftware.com.br/consulta_num_orcamento.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdImagemAval=" & LstIdCapt.Items(LstEncontrados.SelectedItems.Item(0).Index).ToString

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientOrcamento = New WebClient()
        Dim contentOrcamento = syncClientOrcamento.DownloadString(baseUrlOrcamento)
        Dim readOrcamento = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))(contentOrcamento)

        If readOrcamento.Count > 0 Then

            Dim OrcAnt As Integer = (100 * 100) * 10

            For Each it In readOrcamento.ToList

                If it.Id < OrcAnt Then

                    OrcAnt = it.Id

                End If

            Next

            'If Not FrmAnalisarveiculo.LstOrcamento.Items.Contains(it.Id) Then
            FrmAnalisarveiculo.LstOrcamento.Items.Add(OrcAnt)
            'End If

        Else
            FrmAnalisarveiculo.LstOrcamento.Items.Add(0)
        End If

        'coloca a imagem no picturebox

        FrmAnalisarveiculo.UrlImagem = LstEncontrados.SelectedItems.Item(0).Text
        FrmAnalisarveiculo.IdImagem = LstIdCapt.Items(LstEncontrados.SelectedItems.Item(0).Index).ToString
        FrmAnalisarveiculo.IdVeiculo = IdVeiculo
        FrmAnalisarveiculo.IdCliente = LstIdCliente.Items(LstEncontrados.SelectedItems.Item(0).Index).ToString
        FrmAnalisarveiculo.LblTitulo.Text &= " - " & SelPrincipal

        'MsgBox(FrmAnalisarveiculo.IdCliente)
        FrmAnalisarveiculo.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub
End Class