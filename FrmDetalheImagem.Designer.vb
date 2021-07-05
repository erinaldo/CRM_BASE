<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalheImagem
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.TkZoom = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.LblEsc05 = New System.Windows.Forms.Label()
        Me.PnnDkInf5 = New System.Windows.Forms.Panel()
        Me.PnnDkSup5 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.LblEsc04 = New System.Windows.Forms.Label()
        Me.PnnDkInf4 = New System.Windows.Forms.Panel()
        Me.PnnDkSup4 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.LblEsc03 = New System.Windows.Forms.Label()
        Me.PnnDkInf3 = New System.Windows.Forms.Panel()
        Me.PnnDkSup3 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.LblEsc02 = New System.Windows.Forms.Label()
        Me.PnnDkInf2 = New System.Windows.Forms.Panel()
        Me.PnnDkSup2 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.LblEsc01 = New System.Windows.Forms.Label()
        Me.PnnDkInf1 = New System.Windows.Forms.Panel()
        Me.PnnDkSup1 = New System.Windows.Forms.Panel()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtDetalhe = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PicDetalhe = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TrMarcação = New System.Windows.Forms.TreeView()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        CType(Me.TkZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel26.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel20.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel14.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PicDetalhe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.DarkSlateGray
        Me.PnnInferior.Controls.Add(Me.TkZoom)
        Me.PnnInferior.Controls.Add(Me.Label1)
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 598)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1076, 38)
        Me.PnnInferior.TabIndex = 35
        '
        'TkZoom
        '
        Me.TkZoom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TkZoom.Location = New System.Drawing.Point(49, 5)
        Me.TkZoom.Maximum = 1000
        Me.TkZoom.Minimum = 100
        Me.TkZoom.Name = "TkZoom"
        Me.TkZoom.Size = New System.Drawing.Size(940, 33)
        Me.TkZoom.TabIndex = 31
        Me.TkZoom.Value = 100
        Me.TkZoom.Visible = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 33)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Zoom"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Visible = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(989, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(989, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(87, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(51, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1076, 570)
        Me.Panel1.TabIndex = 34
        '
        'Panel6
        '
        Me.Panel6.AutoSize = True
        Me.Panel6.Controls.Add(Me.Panel2)
        Me.Panel6.Controls.Add(Me.PictureBox1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1072, 566)
        Me.Panel6.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.TrMarcação)
        Me.Panel2.Location = New System.Drawing.Point(384, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(330, 490)
        Me.Panel2.TabIndex = 1
        Me.Panel2.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Controls.Add(Me.TxtDetalhe)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(330, 487)
        Me.Panel3.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.Panel26)
        Me.Panel10.Controls.Add(Me.Panel23)
        Me.Panel10.Controls.Add(Me.Panel20)
        Me.Panel10.Controls.Add(Me.Panel17)
        Me.Panel10.Controls.Add(Me.Panel14)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 271)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(330, 75)
        Me.Panel10.TabIndex = 45
        '
        'Panel26
        '
        Me.Panel26.Controls.Add(Me.LblEsc05)
        Me.Panel26.Controls.Add(Me.PnnDkInf5)
        Me.Panel26.Controls.Add(Me.PnnDkSup5)
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel26.Location = New System.Drawing.Point(264, 5)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(66, 65)
        Me.Panel26.TabIndex = 6
        '
        'LblEsc05
        '
        Me.LblEsc05.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEsc05.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.LblEsc05.Location = New System.Drawing.Point(0, 5)
        Me.LblEsc05.Name = "LblEsc05"
        Me.LblEsc05.Size = New System.Drawing.Size(66, 55)
        Me.LblEsc05.TabIndex = 3
        Me.LblEsc05.Text = "5"
        Me.LblEsc05.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnDkInf5
        '
        Me.PnnDkInf5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnDkInf5.Location = New System.Drawing.Point(0, 60)
        Me.PnnDkInf5.Name = "PnnDkInf5"
        Me.PnnDkInf5.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkInf5.TabIndex = 2
        '
        'PnnDkSup5
        '
        Me.PnnDkSup5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnDkSup5.Location = New System.Drawing.Point(0, 0)
        Me.PnnDkSup5.Name = "PnnDkSup5"
        Me.PnnDkSup5.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkSup5.TabIndex = 1
        '
        'Panel23
        '
        Me.Panel23.Controls.Add(Me.LblEsc04)
        Me.Panel23.Controls.Add(Me.PnnDkInf4)
        Me.Panel23.Controls.Add(Me.PnnDkSup4)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel23.Location = New System.Drawing.Point(198, 5)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(66, 65)
        Me.Panel23.TabIndex = 5
        '
        'LblEsc04
        '
        Me.LblEsc04.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEsc04.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.LblEsc04.Location = New System.Drawing.Point(0, 5)
        Me.LblEsc04.Name = "LblEsc04"
        Me.LblEsc04.Size = New System.Drawing.Size(66, 55)
        Me.LblEsc04.TabIndex = 3
        Me.LblEsc04.Text = "4"
        Me.LblEsc04.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnDkInf4
        '
        Me.PnnDkInf4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnDkInf4.Location = New System.Drawing.Point(0, 60)
        Me.PnnDkInf4.Name = "PnnDkInf4"
        Me.PnnDkInf4.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkInf4.TabIndex = 2
        '
        'PnnDkSup4
        '
        Me.PnnDkSup4.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnDkSup4.Location = New System.Drawing.Point(0, 0)
        Me.PnnDkSup4.Name = "PnnDkSup4"
        Me.PnnDkSup4.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkSup4.TabIndex = 1
        '
        'Panel20
        '
        Me.Panel20.Controls.Add(Me.LblEsc03)
        Me.Panel20.Controls.Add(Me.PnnDkInf3)
        Me.Panel20.Controls.Add(Me.PnnDkSup3)
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel20.Location = New System.Drawing.Point(132, 5)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(66, 65)
        Me.Panel20.TabIndex = 4
        '
        'LblEsc03
        '
        Me.LblEsc03.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEsc03.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.LblEsc03.Location = New System.Drawing.Point(0, 5)
        Me.LblEsc03.Name = "LblEsc03"
        Me.LblEsc03.Size = New System.Drawing.Size(66, 55)
        Me.LblEsc03.TabIndex = 3
        Me.LblEsc03.Text = "3"
        Me.LblEsc03.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnDkInf3
        '
        Me.PnnDkInf3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnDkInf3.Location = New System.Drawing.Point(0, 60)
        Me.PnnDkInf3.Name = "PnnDkInf3"
        Me.PnnDkInf3.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkInf3.TabIndex = 2
        '
        'PnnDkSup3
        '
        Me.PnnDkSup3.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnDkSup3.Location = New System.Drawing.Point(0, 0)
        Me.PnnDkSup3.Name = "PnnDkSup3"
        Me.PnnDkSup3.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkSup3.TabIndex = 1
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.LblEsc02)
        Me.Panel17.Controls.Add(Me.PnnDkInf2)
        Me.Panel17.Controls.Add(Me.PnnDkSup2)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.Location = New System.Drawing.Point(66, 5)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(66, 65)
        Me.Panel17.TabIndex = 3
        '
        'LblEsc02
        '
        Me.LblEsc02.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEsc02.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.LblEsc02.Location = New System.Drawing.Point(0, 5)
        Me.LblEsc02.Name = "LblEsc02"
        Me.LblEsc02.Size = New System.Drawing.Size(66, 55)
        Me.LblEsc02.TabIndex = 3
        Me.LblEsc02.Text = "2"
        Me.LblEsc02.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnDkInf2
        '
        Me.PnnDkInf2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnDkInf2.Location = New System.Drawing.Point(0, 60)
        Me.PnnDkInf2.Name = "PnnDkInf2"
        Me.PnnDkInf2.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkInf2.TabIndex = 2
        '
        'PnnDkSup2
        '
        Me.PnnDkSup2.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnDkSup2.Location = New System.Drawing.Point(0, 0)
        Me.PnnDkSup2.Name = "PnnDkSup2"
        Me.PnnDkSup2.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkSup2.TabIndex = 1
        '
        'Panel14
        '
        Me.Panel14.Controls.Add(Me.LblEsc01)
        Me.Panel14.Controls.Add(Me.PnnDkInf1)
        Me.Panel14.Controls.Add(Me.PnnDkSup1)
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(0, 5)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(66, 65)
        Me.Panel14.TabIndex = 2
        '
        'LblEsc01
        '
        Me.LblEsc01.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblEsc01.Font = New System.Drawing.Font("Calibri", 16.0!)
        Me.LblEsc01.Location = New System.Drawing.Point(0, 5)
        Me.LblEsc01.Name = "LblEsc01"
        Me.LblEsc01.Size = New System.Drawing.Size(66, 55)
        Me.LblEsc01.TabIndex = 3
        Me.LblEsc01.Text = "1"
        Me.LblEsc01.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnDkInf1
        '
        Me.PnnDkInf1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnDkInf1.Location = New System.Drawing.Point(0, 60)
        Me.PnnDkInf1.Name = "PnnDkInf1"
        Me.PnnDkInf1.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkInf1.TabIndex = 2
        '
        'PnnDkSup1
        '
        Me.PnnDkSup1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnDkSup1.Location = New System.Drawing.Point(0, 0)
        Me.PnnDkSup1.Name = "PnnDkSup1"
        Me.PnnDkSup1.Size = New System.Drawing.Size(66, 5)
        Me.PnnDkSup1.TabIndex = 1
        '
        'Panel13
        '
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel13.Location = New System.Drawing.Point(0, 70)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(330, 5)
        Me.Panel13.TabIndex = 1
        '
        'Panel11
        '
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(330, 5)
        Me.Panel11.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(293, 461)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 43
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.Enabled = False
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(267, 461)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 44
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TxtDetalhe
        '
        Me.TxtDetalhe.Enabled = False
        Me.TxtDetalhe.Location = New System.Drawing.Point(6, 365)
        Me.TxtDetalhe.Multiline = True
        Me.TxtDetalhe.Name = "TxtDetalhe"
        Me.TxtDetalhe.Size = New System.Drawing.Size(314, 90)
        Me.TxtDetalhe.TabIndex = 42
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 349)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Detalhe do dano"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Calibri", 10.25!)
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(0, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(330, 30)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Nível do dano"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.PicDetalhe)
        Me.Panel5.Controls.Add(Me.Panel9)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 30)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(330, 211)
        Me.Panel5.TabIndex = 36
        '
        'PicDetalhe
        '
        Me.PicDetalhe.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.PicDetalhe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PicDetalhe.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicDetalhe.Location = New System.Drawing.Point(5, 0)
        Me.PicDetalhe.Name = "PicDetalhe"
        Me.PicDetalhe.Size = New System.Drawing.Size(320, 206)
        Me.PicDetalhe.TabIndex = 35
        Me.PicDetalhe.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(5, 206)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(320, 5)
        Me.Panel9.TabIndex = 39
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel8.Location = New System.Drawing.Point(325, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(5, 211)
        Me.Panel8.TabIndex = 38
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(5, 211)
        Me.Panel7.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(245, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Label2"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.25!)
        Me.Label10.ForeColor = System.Drawing.Color.SlateGray
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(330, 30)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Imagem aproximada"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TrMarcação
        '
        Me.TrMarcação.BackColor = System.Drawing.Color.White
        Me.TrMarcação.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TrMarcação.Location = New System.Drawing.Point(0, 487)
        Me.TrMarcação.Name = "TrMarcação"
        Me.TrMarcação.Size = New System.Drawing.Size(330, 79)
        Me.TrMarcação.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Location = New System.Drawing.Point(-1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1030, 609)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1076, 28)
        Me.LblTitulo.TabIndex = 33
        Me.LblTitulo.Text = "Imagem detalhada"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'FrmDetalheImagem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 636)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDetalheImagem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDetalheImagem"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        CType(Me.TkZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel26.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.Panel20.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel14.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PicDetalhe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TrMarcação As TreeView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblTitulo As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PicDetalhe As PictureBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TkZoom As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtDetalhe As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel26 As Panel
    Friend WithEvents LblEsc05 As Label
    Friend WithEvents PnnDkInf5 As Panel
    Friend WithEvents PnnDkSup5 As Panel
    Friend WithEvents Panel23 As Panel
    Friend WithEvents LblEsc04 As Label
    Friend WithEvents PnnDkInf4 As Panel
    Friend WithEvents PnnDkSup4 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents LblEsc03 As Label
    Friend WithEvents PnnDkInf3 As Panel
    Friend WithEvents PnnDkSup3 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents LblEsc02 As Label
    Friend WithEvents PnnDkInf2 As Panel
    Friend WithEvents PnnDkSup2 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents LblEsc01 As Label
    Friend WithEvents PnnDkInf1 As Panel
    Friend WithEvents PnnDkSup1 As Panel
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel11 As Panel
End Class
