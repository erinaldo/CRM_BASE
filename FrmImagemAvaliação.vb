Public Class FrmImagemAvaliação

    Public NomeArquivo As String
    Dim TrImagemTexto As TreeView = FrmRespostaChecklist.TrImagens

    Private Sub FrmImagemAvaliação_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'Insere no grid

        TrImagemTexto.Nodes.Add(NomeArquivo)

        Dim N0 As Integer = TrImagemTexto.Nodes.Count - 1
        TrImagemTexto.Nodes(N0).Nodes.Add(0)
        TrImagemTexto.Nodes(N0).Nodes.Add(0)
        TrImagemTexto.Nodes(N0).Nodes.Add(0)
        TrImagemTexto.Nodes(N0).Nodes.Add(0)

        'insere detalhes encontrados

        TrImagemTexto.Nodes(N0).Nodes.Add("MK")

        'varre o treeview e insere no trimagens

        Dim TrInserir As TreeNode = TrImagemTexto.Nodes(N0).Nodes(4)

        For Each item As TreeNode In TrMarcação.Nodes

            TrInserir.Nodes.Add(item.Text)

            'insere mais uma camada

            Dim N_0 As TreeNode = TrInserir.Nodes(TrInserir.Nodes.Count - 1)

            For Each item1 As TreeNode In item.Nodes

                N_0.Nodes.Add(item1.Text)

                'insere mais uma camada

                Dim N_1 As TreeNode = N_0.Nodes(N_0.Nodes.Count - 1)

                For Each item2 As TreeNode In item1.Nodes

                    N_1.Nodes.Add(item2.Text)

                    'insere mais uma camada

                    Dim N_2 As TreeNode = N_1.Nodes(N_1.Nodes.Count - 1)

                    For Each item3 As TreeNode In item2.Nodes

                        N_2.Nodes.Add(item3.Text)

                        'insere mais uma camada

                        Dim N_3 As TreeNode = N_2.Nodes(N_2.Nodes.Count - 1)

                        For Each item4 As TreeNode In item3.Nodes

                            N_3.Nodes.Add(item4.Text)

                        Next

                    Next

                Next
            Next

        Next

        If TrImagemTexto.Nodes.Count > 0 Then

            FrmRespostaChecklist.BtnPróximo.Enabled = True

        End If

        FrmRespostaChecklist.DesenhaImagens()

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmVistoria.Opacity = 0.95

        Me.Close()

    End Sub

    Dim HabilitaPub As Boolean = True
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttMarcarAvaria.Click

        BttMarcarAvaria.Enabled = False

        HabilitaPub = True

    End Sub

    Dim Cliked As Boolean = False
    Dim MouseX As Integer
    Dim MouseY As Integer

    Dim mouse_tX As Integer
    Dim Mouse_tY As Integer

    Dim Tipo As String

    Dim Hit As Integer = 0

    Dim TipoBtn As Boolean = False

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        If HabilitaPub = True Then

            Hit += 1

            If Hit = 1 Then

                Hit += 1

                mouse_tX = MouseX
                Mouse_tY = MouseY

                Cliked = True

                If TipoBtn = True Then

                    Hit = 0

                    TrMarcação.Nodes.Add(Tipo)
                    TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(mouse_tX)
                    TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(Mouse_tY)
                    Contorna = False

                    Cliked = True

                    PintaGde()

                End If

            ElseIf Hit = 3 Then

                Hit = 0

                If Cliked = True Then

                    'insere 

                    If TipoBtn = False Then

                        TrMarcação.Nodes.Add(Tipo)
                        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseX - mouse_tX)
                        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseX)
                        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseY - Mouse_tY)
                        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseY)

                        DesenhaMarcações()

                        Cliked = False

                        'Insere no grid

                        'verifica a qtdade de zoom q deve ser aplicado

                        Dim CalcX As Integer = 100

                        Dim ValorTotal As Decimal = PictureBox1.Width * 0.8
                        Dim ValorQuadro As Decimal = (MouseX - mouse_tX)

                        Dim ValorEncontrado As Decimal = ValorQuadro

                        While ValorEncontrado < ValorTotal And CalcX < 500

                            CalcX += 1
                            ValorEncontrado = (ValorQuadro * (CalcX / 100))

                        End While

                        'verifica se o y e maior q o painel

                        Dim CalcY As Integer = 100

                        Dim ValorTotalY As Decimal = (PictureBox1.Height * 0.8)
                        Dim ValorQuadroY As Decimal = (MouseY - Mouse_tY)

                        Dim ValorEncontradoY As Decimal = ValorQuadroY

                        While ValorEncontradoY < ValorTotalY And CalcX < 500

                            CalcY += 1

                            ValorEncontradoY = (ValorQuadroY * (CalcY / 100))

                        End While

                        Dim Zoom As Decimal


                        If ValorQuadroY * (CalcY / 100) <= ValorTotalY And ValorQuadro * (CalcX / 100) <= ValorTotal Then

                            Zoom = CalcX / 100

                        ElseIf ValorQuadroY * (CalcY / 100) > ValorTotalY Then

                            Zoom = CalcY / 100

                        ElseIf ValorQuadro * (CalcX / 100) > ValorTotal Then

                            Zoom = CalcX / 100

                        End If

                        FrmDetalheImagem.Zoom = Zoom

                        FrmDetalheImagem.PictureBox1.Size = New Size(PictureBox1.Width * Zoom, PictureBox1.Height * Zoom)
                        FrmDetalheImagem.PictureBox1.Location = New Point(0, 0)

                        Dim Wx_btmp As Integer = Me.Width * Zoom
                        Dim Wy_btmp As Integer = FrmDetalheImagem.PictureBox1.Height * Zoom

                        Dim PintarBitmap = New Bitmap(Wx_btmp, Wy_btmp)

                        Dim Pintura = Graphics.FromImage(PintarBitmap)

                        Pintura.DrawImage(Image.FromFile(NomeArquivo), 0, 0, PictureBox1.Width * Zoom, PictureBox1.Height * Zoom)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.WhiteSmoke)), 0, 0, PictureBox1.Width * Zoom, PictureBox1.Height * Zoom)

                        'da enfase a area marcada

                        'DT
                        Dim Pen As New Pen(Color.White, 0.5)
                        Pen.DashStyle = Drawing2D.DashStyle.Dot

                        Dim Pt1 As New Point(0, 0)
                        Dim Pt2 As New Point(0, Mouse_tY * Zoom)
                        Dim Pt3 As New Point(mouse_tX * Zoom, Mouse_tY * Zoom)
                        Dim Pt4 As New Point(mouse_tX * Zoom, 0)

                        Dim Poligono() As Point = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'DM'

                        Pt1 = New Point(0, Mouse_tY * Zoom)
                        Pt2 = New Point(0, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt3 = New Point(mouse_tX * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt4 = New Point(mouse_tX * Zoom, Mouse_tY * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'DB'

                        Pt1 = New Point(0, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt2 = New Point(0, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt3 = New Point(mouse_tX * Zoom, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt4 = New Point(mouse_tX * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'MB'

                        Pt1 = New Point(mouse_tX * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt2 = New Point(mouse_tX * Zoom, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt3 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt4 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'MT'

                        Pt1 = New Point(mouse_tX * Zoom, Mouse_tY * Zoom)
                        Pt2 = New Point(mouse_tX * Zoom, 0)
                        Pt3 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, 0)
                        Pt4 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, Mouse_tY * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'ET'

                        Pt1 = New Point(PictureBox1.Width * Zoom, 0)
                        Pt2 = New Point(PictureBox1.Width * Zoom, Mouse_tY * Zoom)
                        Pt3 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, Mouse_tY * Zoom)
                        Pt4 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, 0)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'EM'

                        Pt1 = New Point(PictureBox1.Width * Zoom, Mouse_tY * Zoom)
                        Pt2 = New Point(PictureBox1.Width * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt3 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt4 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, Mouse_tY * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'EB'

                        Pt1 = New Point(PictureBox1.Width * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt2 = New Point(PictureBox1.Width * Zoom, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt3 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, FrmDetalheImagem.PictureBox1.Height * Zoom)
                        Pt4 = New Point((mouse_tX + (MouseX - mouse_tX)) * Zoom, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.FromArgb(150, Color.Black)), Poligono)
                        Pintura.DrawPolygon(Pen, Poligono)

                        'Qd0'

                        Pt1 = New Point((mouse_tX * Zoom) - 20, (Mouse_tY * Zoom))
                        Pt2 = New Point((mouse_tX * Zoom) - 20, (Mouse_tY * Zoom) - 20)
                        Pt3 = New Point((mouse_tX * Zoom), (Mouse_tY * Zoom) - 20)
                        Pt4 = New Point((mouse_tX * Zoom), (Mouse_tY * Zoom))

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.Lime), Poligono)

                        'Qd1'

                        Pt1 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom) + 20, (Mouse_tY * Zoom))
                        Pt2 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom) + 20, (Mouse_tY * Zoom) - 20)
                        Pt3 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom), (Mouse_tY * Zoom) - 20)
                        Pt4 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom), (Mouse_tY * Zoom))

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.Lime), Poligono)

                        'Qd2'

                        Pt1 = New Point((mouse_tX * Zoom) - 20, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt2 = New Point((mouse_tX * Zoom) - 20, ((Mouse_tY + (MouseY - Mouse_tY)) * Zoom) + 20)
                        Pt3 = New Point((mouse_tX * Zoom), ((Mouse_tY + (MouseY - Mouse_tY)) * Zoom) + 20)
                        Pt4 = New Point((mouse_tX * Zoom), (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.Lime), Poligono)

                        'Qd3'

                        Pt1 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom) + 20, (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)
                        Pt2 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom) + 20, ((Mouse_tY + (MouseY - Mouse_tY)) * Zoom) + 20)
                        Pt3 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom), ((Mouse_tY + (MouseY - Mouse_tY)) * Zoom) + 20)
                        Pt4 = New Point(((mouse_tX + (MouseX - mouse_tX)) * Zoom), (Mouse_tY + (MouseY - Mouse_tY)) * Zoom)

                        Poligono = {Pt1, Pt2, Pt3, Pt4}

                        Pintura.FillPolygon(New SolidBrush(Color.Lime), Poligono)

                        'divide espaço de interação

                        Dim PtCX As Decimal = FrmDetalheImagem.PictureBox1.Height / 100
                        Dim GdePen As New Pen(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), 0.5)

                        Dim CX As Decimal = 0

                        While CX < FrmDetalheImagem.PictureBox1.Height

                            Pintura.DrawLine(GdePen, 0, CX, FrmDetalheImagem.PictureBox1.Width, CX)

                            CX += PtCX

                        End While

                        'divide espaço de interação

                        Dim PtCY As Decimal = FrmDetalheImagem.PictureBox1.Width / 100

                        Dim Cy As Decimal = 0

                        While Cy < FrmDetalheImagem.PictureBox1.Width

                            Pintura.DrawLine(GdePen, Cy, 0, Cy, FrmDetalheImagem.PictureBox1.Width)

                            Cy += PtCY

                        End While

                        'verifica linha na vertical

                        FrmDetalheImagem.Size = New Size(Me.Width, Me.Height)

                        FrmDetalheImagem.PictureBox1.BackgroundImage = PintarBitmap

                        FrmDetalheImagem.NomeArquivo = NomeArquivo

                        FrmDetalheImagem.MouseX = MouseX
                        FrmDetalheImagem.Mousey = MouseY
                        FrmDetalheImagem.mouse_tX = mouse_tX
                        FrmDetalheImagem.Mouse_ty = Mouse_tY

                        FrmDetalheImagem.Show(Me)

                        Dim ValorY As Decimal = (((Mouse_tY + (MouseY - Mouse_tY)) * Zoom) - (FrmDetalheImagem.Panel2.Height)) + ((FrmDetalheImagem.Panel2.Height) / 2) - ((((MouseY - Mouse_tY)) * Zoom) / 2)

                        FrmDetalheImagem.Panel6.VerticalScroll.Maximum = FrmDetalheImagem.PictureBox1.Height

                        If ValorY > 0 Then
                            FrmDetalheImagem.Panel6.VerticalScroll.Value = ValorY
                        End If

                        Dim ValorX As Decimal = (((mouse_tX + (MouseX - mouse_tX)) * Zoom) - (FrmDetalheImagem.Width)) + (((FrmDetalheImagem.Width) / 2) - ((((MouseX - mouse_tX)) * Zoom) / 2))

                        FrmDetalheImagem.Panel6.HorizontalScroll.Maximum = FrmDetalheImagem.PictureBox1.Width

                        If ValorX > 0 Then
                            FrmDetalheImagem.Panel6.HorizontalScroll.Value = ValorX
                        End If

                    End If

                    Me.Opacity = 0.35

                End If

            End If

        End If

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        MouseX = e.X
        MouseY = e.Y

        'desenha rota de siga

        If Sel = 0 Then

            PictureBox1.Cursor = Cursors.Arrow

        ElseIf tipobtn = False Then

            Dim P0 As Pen = New Pen(New SolidBrush(Color.LimeGreen), 2)
            P0.DashStyle = Drawing2D.DashStyle.Dot

            If Cliked = True Then

                If Contorna = True Then

                    PictureBox1.Cursor = Cursors.VSplit

                    Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

                    Dim Pintura = Graphics.FromImage(PintarBitmap)

                    Pintura.DrawRectangle(P0, mouse_tX, Mouse_tY, e.X - mouse_tX, e.Y - Mouse_tY)

                    Pintura.DrawLine(P0, 0, Mouse_tY, PictureBox1.Width, Mouse_tY)
                    Pintura.DrawLine(P0, mouse_tX, 0, mouse_tX, PictureBox1.Height)

                    Pintura.DrawLine(P0, 0, e.Y, PictureBox1.Width, e.Y)
                    Pintura.DrawLine(P0, e.X, 0, e.X, PictureBox1.Height)

                    PictureBox1.Image = PintarBitmap

                End If

            Else

                PictureBox1.Cursor = Cursors.Cross

                Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

                Dim Pintura = Graphics.FromImage(PintarBitmap)

                Pintura.DrawLine(P0, 0, e.Y, PictureBox1.Width, e.Y)
                Pintura.DrawLine(P0, e.X, 0, e.X, PictureBox1.Height)

                PictureBox1.Image = PintarBitmap

            End If

        ElseIf tipobtn = True Then

            Dim P0 As Pen = New Pen(New SolidBrush(Color.LimeGreen), 2)
            P0.DashStyle = Drawing2D.DashStyle.Dot

            PictureBox1.Cursor = Cursors.Cross

            Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Pintura.DrawLine(P0, 0, e.Y, PictureBox1.Width, e.Y)
            Pintura.DrawLine(P0, e.X, 0, e.X, PictureBox1.Height)

            PictureBox1.Image = PintarBitmap

        End If

    End Sub

    Dim Contorna As Boolean = False

    Public Sub PintaGde()

        Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Pintura.DrawImage(Image.FromFile(NomeArquivo), 0, 0, PictureBox1.Width, PictureBox1.Height)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.WhiteSmoke)), 0, 0, PictureBox1.Width, PictureBox1.Height)

        'divide espaço de interação

        Dim PtCX As Decimal = PictureBox1.Height / 100
        Dim GdePen As New Pen(New SolidBrush(Color.FromArgb(150, Color.SlateGray)), 0.5)

        Dim CX As Decimal = 0

        While CX < FrmDetalheImagem.PictureBox1.Height

            Pintura.DrawLine(GdePen, 0, CX, PictureBox1.Width, CX)

            CX += PtCX

        End While

        'divide espaço de interação

        Dim PtCY As Decimal = PictureBox1.Width / 100

        Dim Cy As Decimal = 0

        While Cy < PictureBox1.Width

            Pintura.DrawLine(GdePen, Cy, 0, Cy, PictureBox1.Width)

            Cy += PtCY

        End While

        Dim PeçaAusente As Integer
        Dim PeçaIrrecuperavel As Integer
        Dim Quebrado As Integer
        Dim QuebradoAcab As Integer
        Dim Inoperante As Integer
        Dim Falha As Integer

        For Each item As TreeNode In TrMarcação.Nodes

            If item.Text = "Risco" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 1 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Amassado" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 2 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If
            ElseIf item.Text = "Peça ausente" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 3 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawString("Peça ausente_" & PeçaAusente, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    PeçaAusente += 1
                End If

            ElseIf item.Text = "Peça irrecuperável" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 4 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawString("Peça irrecuperável_" & PeçaIrrecuperavel, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    PeçaIrrecuperavel += 1
                End If

            ElseIf item.Text = "Corrosão" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 5 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Delaminação" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 6 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Desgaste" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 7 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Trinco" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 8 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Delaminação" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 9 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Quebrado" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 10 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawString("Quebrado_" & Quebrado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    Quebrado += 1
                End If

            ElseIf item.Text = "Rasgado" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 11 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Desgaste acab." Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 12 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Quebrado acab." Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 13 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 140, 15)
                    Pintura.DrawString("Quebrado acab._" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    QuebradoAcab += 1
                End If

            ElseIf item.Text = "Risco acab." Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 14 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Mancha" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Sel = 15 Then
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.DarkGoldenrod)), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.DarkGoldenrod), 2), MEX - MEX_e, MEY - MEY_e, MEX_e, MEY_e)
                End If

            ElseIf item.Text = "Inoperante" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 16 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawString("Inoperante_" & Inoperante, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    Inoperante += 1
                End If

            ElseIf item.Text = "Falha" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                If Sel = 17 Then
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                    Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                    Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)
                    Pintura.DrawString("Falha_" & Falha, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)
                    Falha += 1
                End If

            End If

        Next

        PictureBox1.BackgroundImage = PintarBitmap
        PictureBox1.Cursor = Cursors.Arrow

        'Panel2.Visible = False

    End Sub

    Public Sub DesenhaMarcações()

        Dim Riscos As Integer = 0

        PictureBox1.Cursor = Cursors.WaitCursor

        Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Pintura.DrawImage(Image.FromFile(NomeArquivo), 0, 0, PictureBox1.Width, PictureBox1.Height)
        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.WhiteSmoke)), 0, 0, PictureBox1.Width, PictureBox1.Height)

        'varre o treeview

        'desenha grade

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

        For Each item As TreeNode In TrMarcação.Nodes

            If item.Text = "Risco" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

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

                End If

            ElseIf item.Text = "Amassado" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Amassado_" & amassado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        amassado += 1

                    Next

                End If

            ElseIf item.Text = "Peça ausente" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Peça ausente_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                Peças += 1

            ElseIf item.Text = "Peça irrecuperável" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Peça irrecuperável_" & PeçasIrre, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                PeçasIrre += 1

            ElseIf item.Text = "Corrosão" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Corrosão_" & Corrosão, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Corrosão += 1

                    Next

                End If

            ElseIf item.Text = "Delaminação" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Delaminação_" & Delaminação, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Delaminação += 1

                    Next

                End If

            ElseIf item.Text = "Desgaste" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Desgaste_" & Desgaste, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Desgaste += 1

                    Next

                End If

            ElseIf item.Text = "Trinco" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Trinco_" & Trinco, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Trinco += 1

                    Next

                End If

            ElseIf item.Text = "Delaminação vidro" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Delaminação vidro_" & DelaminaçãoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DelaminaçãoVidro += 1

                    Next

                End If

            ElseIf item.Text = "Quebrado" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Vidro quebrado_" & QuebradoVidro, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                QuebradoVidro += 1

            ElseIf item.Text = "Rasgado" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Rasgado_" & Rasgado, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Rasgado += 1

                    Next

                End If

            ElseIf item.Text = "Desgaste acab." Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Desegaste Acab. _" & DesgasteAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        DesgasteAcab += 1

                    Next

                End If

            ElseIf item.Text = "Quebrado acab." Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Acab. Quebrado_" & QuebradoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                QuebradoAcab += 1

            ElseIf item.Text = "Risco acab." Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Risco avab." & RiscoAcab, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        RiscoAcab += 1

                    Next

                End If

            ElseIf item.Text = "Mancha" Then

                Dim MEX As Integer = item.Nodes(1).Text
                Dim MEY As Integer = item.Nodes(3).Text

                Dim MEX_e As Integer = item.Nodes(0).Text
                Dim MEY_e As Integer = item.Nodes(2).Text

                If Cliked = False Then

                    For Each tr As TreeNode In item.Nodes(4).Nodes

                        Dim MEX_0 As Decimal = tr.Nodes(1).Text
                        Dim MEY_0 As Decimal = tr.Nodes(2).Text

                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                        Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                        Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 100, 15)
                        Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 100, 15)

                        Pintura.DrawString("Mancha_" & Riscos, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                        Mancha += 1

                    Next

                End If

            ElseIf item.Text = "Inoperante" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Inoperante_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                Inoperante += 1

            ElseIf item.Text = "Falha" Then

                Dim MEX_0 As Decimal = item.Nodes(0).Text
                Dim MEY_0 As Decimal = item.Nodes(1).Text

                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
                Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
                Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.SlateGray)), MEX_0 + 8, MEY_0 - 8, 110, 15)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)

                Pintura.DrawString("Falha_" & Peças, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

                falha += 1

            End If

        Next

        PictureBox1.BackgroundImage = PintarBitmap
        PictureBox1.Cursor = Cursors.Arrow

    End Sub
    Private Sub MarcarPeçaAusenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarPeçaAusenteToolStripMenuItem.Click

    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp

        If HabilitaPub = True Then

            If e.Button = MouseButtons.Right Then

            End If

        End If

    End Sub

    Private Sub RiscoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RiscoToolStripMenuItem.Click

    End Sub

    Private Sub AmassadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AmassadoToolStripMenuItem.Click

        Tipo = "Amassado"

        Contorna = True
        Cliked = True

    End Sub

    Private Sub MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcarPeçaSemCondiçãoDeReparoToolStripMenuItem.Click

        Tipo = "Peça irreparável"

        TrMarcação.Nodes.Add(Tipo)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(mouse_tX)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(Mouse_tY)
        Contorna = False

        Cliked = False

        pintagde()

    End Sub

    Dim Sel As Integer = 0

    Public Sub LimpaBotões()

        BttPonteiro.Checked = False
        BttRisco.Checked = False
        BttAmassado.Checked = False
        BttPeçaAusente.Checked = False
        BttPeçaIrrecuperavel.Checked = False
        BttCorrosão.Checked = False

        BttDelaminação.Checked = False
        BttDesgaste.Checked = False

        BttTrinco.Checked = False
        BttQuebrado.Checked = False

        BttRasgado.Checked = False
        BttDesgasteAcab.Checked = False
        BttQuebradoAcab.Checked = False
        BttMancha.Checked = False

        BttInoperante.Checked = False
        BttFalha.Checked = False

        BttRiscosAcab.Checked = False
        BttDelaminaçãoVidro.Checked = False

    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles BttPonteiro.Click

        LimpaBotões()

        BttPonteiro.Checked = True

        Sel = 0

        Hit = 0
        HabilitaPub = False
        Cliked = False

        PictureBox1.Image = Nothing

        DesenhaMarcações()

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles BttRisco.Click

        TipoBtn = False

        LimpaBotões()

        BttRisco.Checked = True

        HabilitaPub = True

        Sel = 1
        Hit = 0

        Tipo = "Risco"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub PictureBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PictureBox1.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Escape) Then

            Hit = 0

            Contorna = False
            Cliked = False

        End If

    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles BttAmassado.Click

        TipoBtn = False

        LimpaBotões()

        BttAmassado.Checked = True

        HabilitaPub = True

        Sel = 2
        Hit = 0

        Tipo = "Amassado"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub BttCorrosão_Click(sender As Object, e As EventArgs) Handles BttCorrosão.Click

        TipoBtn = False

        LimpaBotões()

        BttCorrosão.Checked = True

        HabilitaPub = True

        Sel = 5
        Hit = 0

        Tipo = "Corrosão"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub BttPeçaAusente_Click(sender As Object, e As EventArgs) Handles BttPeçaAusente.Click

        TipoBtn = True

        LimpaBotões()

        BttPeçaAusente.Checked = True

        HabilitaPub = True

        Sel = 3
        Hit = 0

        Tipo = "Peça ausente"

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub BttPeçaIrrecuperavel_Click(sender As Object, e As EventArgs) Handles BttPeçaIrrecuperavel.Click

        TipoBtn = True

        LimpaBotões()

        BttPeçaIrrecuperavel.Checked = True

        HabilitaPub = True

        Sel = 4
        Hit = 0

        Tipo = "Peça irrecuperável"

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles BttDesgaste.Click

        TipoBtn = False

        LimpaBotões()

        BttDesgaste.Checked = True

        HabilitaPub = True

        Sel = 7
        Hit = 0

        Tipo = "Desgaste"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles BttTrinco.Click

        TipoBtn = False

        LimpaBotões()

        BttTrinco.Checked = True

        HabilitaPub = True

        Sel = 8
        Hit = 0

        Tipo = "Trinco"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles BttQuebrado.Click

        TipoBtn = True

        LimpaBotões()

        BttQuebrado.Checked = True

        HabilitaPub = True

        Sel = 10
        Hit = 0

        Tipo = "Quebrado"

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles BttRasgado.Click

        TipoBtn = False

        LimpaBotões()

        BttRasgado.Checked = True

        HabilitaPub = True

        Sel = 11
        Hit = 0

        Tipo = "Rasgado"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles BttDesgasteAcab.Click

        TipoBtn = False

        LimpaBotões()

        BttDesgasteAcab.Checked = True

        HabilitaPub = True

        Sel = 12
        Hit = 0

        Tipo = "Desgaste acab."

        Contorna = True

        PintaGde()

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles BttMancha.Click

        TipoBtn = False

        LimpaBotões()

        BttMancha.Checked = True

        HabilitaPub = True

        Sel = 15
        Hit = 0

        Tipo = "Mancha"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub BttFalha_Click(sender As Object, e As EventArgs) Handles BttFalha.Click

        TipoBtn = True

        LimpaBotões()

        BttFalha.Checked = True

        HabilitaPub = True

        Sel = 17
        Hit = 0

        Tipo = "Falha"

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub BttInoperante_Click(sender As Object, e As EventArgs) Handles BttInoperante.Click

        TipoBtn = True

        LimpaBotões()

        BttInoperante.Checked = True

        HabilitaPub = True

        Sel = 16
        Hit = 0

        Tipo = "Inoperante"

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub BttDelaminação_Click(sender As Object, e As EventArgs) Handles BttDelaminação.Click

        TipoBtn = False

        LimpaBotões()

        BttDelaminação.Checked = True

        HabilitaPub = True

        Sel = 6
        Hit = 0

        Tipo = "Delaminação"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub BttQuebradoAcab_Click(sender As Object, e As EventArgs) Handles BttQuebradoAcab.Click

        TipoBtn = True

        LimpaBotões()

        BttQuebradoAcab.Checked = True

        HabilitaPub = True

        Sel = 13
        Hit = 0

        Tipo = "Quebrado acab."

        Contorna = False

        Cliked = False

        PintaGde()

    End Sub

    Private Sub BttQuebradoAcab_MouseMove(sender As Object, e As MouseEventArgs) Handles BttQuebradoAcab.MouseMove

    End Sub

    Private Sub BttDelaminaçãoVidro_Click(sender As Object, e As EventArgs) Handles BttDelaminaçãoVidro.Click

        TipoBtn = False

        LimpaBotões()

        BttDelaminaçãoVidro.Checked = True

        HabilitaPub = True

        Sel = 9
        Hit = 0

        Tipo = "Delaminação vidro"

        Contorna = True

        PintaGde()

    End Sub

    Private Sub BttRiscosAcab_Click(sender As Object, e As EventArgs) Handles BttRiscosAcab.Click

        TipoBtn = False

        LimpaBotões()

        BttRiscosAcab.Checked = True

        HabilitaPub = True

        Sel = 14
        Hit = 0

        Tipo = "Risco acab."

        Contorna = True

        PintaGde()

    End Sub
End Class