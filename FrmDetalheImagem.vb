Public Class FrmDetalheImagem

    Public NomeArquivo As String


    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmImagemAvaliação.Opacity = 0.95

        Me.Close()

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PicDetalhe.Click

        Dim OpgDi As New OpenFileDialog

        If OpgDi.ShowDialog = Windows.Forms.DialogResult.OK Then

            'Insere no grid

            Dim PintarBitmap = New Bitmap(PicDetalhe.Width, PicDetalhe.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Pintura.DrawImage(Image.FromFile(OpgDi.FileName.ToString), 0, 0, PicDetalhe.Width, PicDetalhe.Height)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(50, Color.WhiteSmoke)), 0, 0, PicDetalhe.Width, PicDetalhe.Height)

            PicDetalhe.BackgroundImage = PintarBitmap

            NomeDetalhe = OpgDi.FileName

        End If

    End Sub

    Public MouseX As Decimal
    Public mouse_tX As Decimal
    Public Mousey As Decimal
    Public Mouse_ty As Decimal

    Private Sub Panel6_Paint(sender As Object, e As PaintEventArgs) Handles Panel6.Paint

    End Sub

    Private Sub Panel6_Scroll(sender As Object, e As ScrollEventArgs) Handles Panel6.Scroll

        Label2.Text = Panel6.VerticalScroll.Value

    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove

        MouseMoveX = e.X
        MouseMoveY = e.Y

        PictureBox1.Cursor = Cursors.Cross

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Me.Cursor = Cursors.WaitCursor

        MouseMark_x = MouseMoveX
        MouseMark_Y = MouseMoveY

        Panel2.Visible = True

        Me.Cursor = Cursors.Arrow

    End Sub

    Dim MouseMoveX As Decimal
    Dim MouseMoveY As Decimal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Panel2.Visible = False

    End Sub

    Dim MouseMark_x As Decimal
    Dim MouseMark_Y As Decimal

    Dim NomeDetalhe As String

    Public Sub DesenhaSeleção()

        PictureBox1.Cursor = Cursors.WaitCursor

        Dim PintarBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        'varre o treeview

        For Each item As TreeNode In TrMarcação.Nodes

            Dim MEX_0 As Integer = item.Nodes(1).Text
            Dim MEY_0 As Integer = item.Nodes(2).Text

            Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 - 5, MEY_0 - 5, MEX_0 + 5, MEY_0 + 5)
            Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 5, MEY_0 - 5, MEX_0 - 5, MEY_0 + 5)
            Pintura.DrawLine(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0, MEY_0, MEX_0 + 8, MEY_0)
            Pintura.FillEllipse(New SolidBrush(Color.LimeGreen), MEX_0 - 2, MEY_0 - 2, 2, 2)
            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(200, Color.Red)), MEX_0 + 8, MEY_0 - 8, 110, 15)
            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.LimeGreen), 1), MEX_0 + 8, MEY_0 - 8, 110, 15)
            Pintura.DrawString("Ponto marcado_" & item.Index, New Font("Calibri", 10.25), New SolidBrush(Color.WhiteSmoke), MEX_0 + 8, MEY_0 - 9)

        Next

        PictureBox1.Image = PintarBitmap
        PictureBox1.Cursor = Cursors.Arrow

        Panel2.Visible = False

    End Sub

    Public Sub LimpaEscala()

        LblEsc01.BackColor = Color.WhiteSmoke
        LblEsc01.ForeColor = Color.SlateGray
        LblEsc01.Font = New Font("Calibri", 16)

        LblEsc02.BackColor = Color.WhiteSmoke
        LblEsc02.ForeColor = Color.SlateGray
        LblEsc02.Font = New Font("Calibri", 16)

        LblEsc03.BackColor = Color.WhiteSmoke
        LblEsc03.ForeColor = Color.SlateGray
        LblEsc03.Font = New Font("Calibri", 16)

        LblEsc04.BackColor = Color.WhiteSmoke
        LblEsc04.ForeColor = Color.SlateGray
        LblEsc04.Font = New Font("Calibri", 16)

        LblEsc05.BackColor = Color.WhiteSmoke
        LblEsc05.ForeColor = Color.SlateGray
        LblEsc05.Font = New Font("Calibri", 16)

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        LimpaEscala()

        TxtDetalhe.Text = ""
        TxtDetalhe.Enabled = False

        PicDetalhe.BackgroundImage = My.Resources.Resources.add_1_icon

        'adiciona no treeview

        TrMarcação.Nodes.Add("Mk_" & TrMarcação.Nodes.Count)

        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(NomeDetalhe)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseMark_x)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(MouseMark_Y)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(ValorEscala)
        TrMarcação.Nodes(TrMarcação.Nodes.Count - 1).Nodes.Add(TxtDetalhe.Text)

        DesenhaSeleção()

        Panel2.Visible = False

    End Sub

    Public Zoom As Decimal

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'insere tudo q leu

        Dim TreeView_Pr As TreeNode = FrmImagemAvaliação.TrMarcação.Nodes(FrmImagemAvaliação.TrMarcação.Nodes.Count - 1)

        TreeView_Pr.Nodes.Add("Marcações adicionais")

        For Each tr As TreeNode In TrMarcação.Nodes

            Dim TrAdd As TreeNode = TreeView_Pr.Nodes(TreeView_Pr.Nodes.Count - 1)

            TrAdd.Nodes.Add("MK_" & tr.Index)

            For Each tr_1 As TreeNode In tr.Nodes

                If TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Count = 0 Then
                    TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Add(tr_1.Text)
                ElseIf TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Count > 0 And TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Count < 3 Then
                    TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Add(tr_1.Text / (Zoom))
                ElseIf TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Count > 2 Then
                    TrAdd.Nodes(TrAdd.Nodes.Count - 1).Nodes.Add(tr_1.Text)
                End If

            Next

        Next

        FrmImagemAvaliação.DesenhaMarcações()

        FrmImagemAvaliação.Opacity = 0.95

        FrmImagemAvaliação.BttPonteiro.PerformClick()

        Me.Close()

    End Sub

    Dim ValorEscala As Integer = 0

    Private Sub LblEsc01_Click(sender As Object, e As EventArgs) Handles LblEsc01.Click

        LimpaEscala()

        If LblEsc01.BackColor = Color.SlateGray Then

            PnnDkInf1.Visible = True
            PnnDkSup1.Visible = True

            LblEsc01.ForeColor = Color.SlateGray
            LblEsc01.BackColor = Color.WhiteSmoke
            LblEsc01.Font = New Font("Calibri", 16)

        Else

            PnnDkInf1.Visible = False
            PnnDkSup1.Visible = False

            LblEsc01.ForeColor = Color.WhiteSmoke
            LblEsc01.BackColor = Color.SlateGray
            LblEsc01.Font = New Font("Calibri", 20)

            ValorEscala = 1

            TxtDetalhe.Enabled = True
            Button2.Enabled = True

        End If

    End Sub

    Private Sub LblEsc02_Click(sender As Object, e As EventArgs) Handles LblEsc02.Click

        LimpaEscala()

        If LblEsc02.BackColor = Color.SlateGray Then

            PnnDkInf2.Visible = True
            PnnDkSup2.Visible = True

            LblEsc02.ForeColor = Color.SlateGray
            LblEsc02.BackColor = Color.WhiteSmoke
            LblEsc02.Font = New Font("Calibri", 16)

        Else

            PnnDkInf2.Visible = False
            PnnDkSup2.Visible = False

            LblEsc02.ForeColor = Color.WhiteSmoke
            LblEsc02.BackColor = Color.SlateGray
            LblEsc02.Font = New Font("Calibri", 20)

            ValorEscala = 2

            TxtDetalhe.Enabled = True
            Button2.Enabled = True

        End If

    End Sub

    Private Sub LblEsc03_Click(sender As Object, e As EventArgs) Handles LblEsc03.Click

        LimpaEscala()

        If LblEsc03.BackColor = Color.SlateGray Then

            PnnDkInf3.Visible = True
            PnnDkSup3.Visible = True

            LblEsc03.ForeColor = Color.SlateGray
            LblEsc03.BackColor = Color.WhiteSmoke
            LblEsc03.Font = New Font("Calibri", 16)

        Else

            PnnDkInf3.Visible = False
            PnnDkSup3.Visible = False

            LblEsc03.ForeColor = Color.WhiteSmoke
            LblEsc03.BackColor = Color.SlateGray
            LblEsc03.Font = New Font("Calibri", 20)

            ValorEscala = 3

            TxtDetalhe.Enabled = True
            Button2.Enabled = True

        End If

    End Sub


    Private Sub LblEsc04_Click(sender As Object, e As EventArgs) Handles LblEsc04.Click

        LimpaEscala()

        If LblEsc04.BackColor = Color.SlateGray Then

            PnnDkInf4.Visible = True
            PnnDkSup4.Visible = True

            LblEsc04.ForeColor = Color.SlateGray
            LblEsc04.BackColor = Color.WhiteSmoke
            LblEsc04.Font = New Font("Calibri", 16)

        Else

            PnnDkInf4.Visible = False
            PnnDkSup4.Visible = False

            LblEsc04.ForeColor = Color.WhiteSmoke
            LblEsc04.BackColor = Color.SlateGray
            LblEsc04.Font = New Font("Calibri", 20)

            ValorEscala = 4

            TxtDetalhe.Enabled = True
            Button2.Enabled = True

        End If

    End Sub


    Private Sub LblEsc05_Click(sender As Object, e As EventArgs) Handles LblEsc05.Click

        LimpaEscala()

        If LblEsc05.BackColor = Color.SlateGray Then

            PnnDkInf5.Visible = True
            PnnDkSup5.Visible = True

            LblEsc05.ForeColor = Color.SlateGray
            LblEsc05.BackColor = Color.WhiteSmoke
            LblEsc05.Font = New Font("Calibri", 16)

        Else

            PnnDkInf5.Visible = False
            PnnDkSup5.Visible = False

            LblEsc05.ForeColor = Color.WhiteSmoke
            LblEsc05.BackColor = Color.SlateGray
            LblEsc05.Font = New Font("Calibri", 20)

            ValorEscala = 5

            TxtDetalhe.Enabled = True
            Button2.Enabled = True

        End If

    End Sub
End Class