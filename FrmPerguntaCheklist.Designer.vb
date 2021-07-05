<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPerguntaCheklist
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnPergunta = New System.Windows.Forms.Panel()
        Me.CkExigeImagem = New System.Windows.Forms.CheckBox()
        Me.TxtPergunta = New System.Windows.Forms.TextBox()
        Me.GpDetalhe = New System.Windows.Forms.GroupBox()
        Me.PnnUnicaEsolha = New System.Windows.Forms.Panel()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.BttAddOpção = New System.Windows.Forms.Button()
        Me.TxtDescriçãoOpção = New System.Windows.Forms.TextBox()
        Me.BttRemoveItem = New System.Windows.Forms.Button()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.PnnEscala = New System.Windows.Forms.Panel()
        Me.Panel33 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel34 = New System.Windows.Forms.Panel()
        Me.Panel35 = New System.Windows.Forms.Panel()
        Me.Panel30 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel31 = New System.Windows.Forms.Panel()
        Me.Panel32 = New System.Windows.Forms.Panel()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel28 = New System.Windows.Forms.Panel()
        Me.Panel29 = New System.Windows.Forms.Panel()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PnnTexto = New System.Windows.Forms.Panel()
        Me.CkPermiteCaracter = New System.Windows.Forms.CheckBox()
        Me.CkPermiteNumero = New System.Windows.Forms.CheckBox()
        Me.CkPermiteLetras = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GpTipo = New System.Windows.Forms.GroupBox()
        Me.RdbMultiplaEscolha = New System.Windows.Forms.RadioButton()
        Me.RdbUnicaEscolha = New System.Windows.Forms.RadioButton()
        Me.RdbEscala = New System.Windows.Forms.RadioButton()
        Me.RdbSimNão = New System.Windows.Forms.RadioButton()
        Me.RdbTexto = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.PnnPergunta.SuspendLayout()
        Me.GpDetalhe.SuspendLayout()
        Me.PnnUnicaEsolha.SuspendLayout()
        Me.PnnEscala.SuspendLayout()
        Me.Panel33.SuspendLayout()
        Me.Panel30.SuspendLayout()
        Me.Panel27.SuspendLayout()
        Me.Panel24.SuspendLayout()
        Me.Panel21.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.PnnTexto.SuspendLayout()
        Me.GpTipo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(573, 32)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Cadastro de nova pergunta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnPergunta
        '
        Me.PnnPergunta.Controls.Add(Me.CkExigeImagem)
        Me.PnnPergunta.Controls.Add(Me.TxtPergunta)
        Me.PnnPergunta.Controls.Add(Me.GpDetalhe)
        Me.PnnPergunta.Controls.Add(Me.GpTipo)
        Me.PnnPergunta.Controls.Add(Me.Label3)
        Me.PnnPergunta.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnnPergunta.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.PnnPergunta.Location = New System.Drawing.Point(0, 32)
        Me.PnnPergunta.Name = "PnnPergunta"
        Me.PnnPergunta.Size = New System.Drawing.Size(573, 445)
        Me.PnnPergunta.TabIndex = 49
        '
        'CkExigeImagem
        '
        Me.CkExigeImagem.AutoSize = True
        Me.CkExigeImagem.Checked = True
        Me.CkExigeImagem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkExigeImagem.Enabled = False
        Me.CkExigeImagem.Location = New System.Drawing.Point(387, 407)
        Me.CkExigeImagem.Name = "CkExigeImagem"
        Me.CkExigeImagem.Size = New System.Drawing.Size(174, 17)
        Me.CkExigeImagem.TabIndex = 4
        Me.CkExigeImagem.Text = "Exige comprovação por imagem"
        Me.CkExigeImagem.UseVisualStyleBackColor = True
        '
        'TxtPergunta
        '
        Me.TxtPergunta.Location = New System.Drawing.Point(13, 33)
        Me.TxtPergunta.Multiline = True
        Me.TxtPergunta.Name = "TxtPergunta"
        Me.TxtPergunta.Size = New System.Drawing.Size(548, 54)
        Me.TxtPergunta.TabIndex = 57
        '
        'GpDetalhe
        '
        Me.GpDetalhe.Controls.Add(Me.PnnUnicaEsolha)
        Me.GpDetalhe.Controls.Add(Me.PnnEscala)
        Me.GpDetalhe.Controls.Add(Me.Panel5)
        Me.GpDetalhe.Controls.Add(Me.PnnTexto)
        Me.GpDetalhe.Enabled = False
        Me.GpDetalhe.Location = New System.Drawing.Point(13, 194)
        Me.GpDetalhe.Name = "GpDetalhe"
        Me.GpDetalhe.Size = New System.Drawing.Size(547, 207)
        Me.GpDetalhe.TabIndex = 50
        Me.GpDetalhe.TabStop = False
        Me.GpDetalhe.Text = "Detalhe"
        '
        'PnnUnicaEsolha
        '
        Me.PnnUnicaEsolha.Controls.Add(Me.ListBox1)
        Me.PnnUnicaEsolha.Controls.Add(Me.BttAddOpção)
        Me.PnnUnicaEsolha.Controls.Add(Me.TxtDescriçãoOpção)
        Me.PnnUnicaEsolha.Controls.Add(Me.BttRemoveItem)
        Me.PnnUnicaEsolha.Controls.Add(Me.Label18)
        Me.PnnUnicaEsolha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnUnicaEsolha.Location = New System.Drawing.Point(3, 17)
        Me.PnnUnicaEsolha.Name = "PnnUnicaEsolha"
        Me.PnnUnicaEsolha.Size = New System.Drawing.Size(541, 187)
        Me.PnnUnicaEsolha.TabIndex = 3
        Me.PnnUnicaEsolha.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(541, 147)
        Me.ListBox1.TabIndex = 58
        '
        'BttAddOpção
        '
        Me.BttAddOpção.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddOpção.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddOpção.Enabled = False
        Me.BttAddOpção.FlatAppearance.BorderSize = 0
        Me.BttAddOpção.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddOpção.Location = New System.Drawing.Point(455, 12)
        Me.BttAddOpção.Name = "BttAddOpção"
        Me.BttAddOpção.Size = New System.Drawing.Size(38, 21)
        Me.BttAddOpção.TabIndex = 57
        Me.BttAddOpção.UseVisualStyleBackColor = True
        '
        'TxtDescriçãoOpção
        '
        Me.TxtDescriçãoOpção.Location = New System.Drawing.Point(129, 12)
        Me.TxtDescriçãoOpção.Name = "TxtDescriçãoOpção"
        Me.TxtDescriçãoOpção.Size = New System.Drawing.Size(318, 21)
        Me.TxtDescriçãoOpção.TabIndex = 56
        '
        'BttRemoveItem
        '
        Me.BttRemoveItem.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.icons8_menos_16
        Me.BttRemoveItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttRemoveItem.Enabled = False
        Me.BttRemoveItem.FlatAppearance.BorderSize = 0
        Me.BttRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttRemoveItem.Location = New System.Drawing.Point(498, 12)
        Me.BttRemoveItem.Name = "BttRemoveItem"
        Me.BttRemoveItem.Size = New System.Drawing.Size(38, 21)
        Me.BttRemoveItem.TabIndex = 55
        Me.BttRemoveItem.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label18.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label18.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Location = New System.Drawing.Point(9, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 13)
        Me.Label18.TabIndex = 53
        Me.Label18.Text = "Decrição da opção"
        '
        'PnnEscala
        '
        Me.PnnEscala.Controls.Add(Me.Panel33)
        Me.PnnEscala.Controls.Add(Me.Panel30)
        Me.PnnEscala.Controls.Add(Me.Panel27)
        Me.PnnEscala.Controls.Add(Me.Panel24)
        Me.PnnEscala.Controls.Add(Me.Panel21)
        Me.PnnEscala.Controls.Add(Me.Panel18)
        Me.PnnEscala.Controls.Add(Me.Panel15)
        Me.PnnEscala.Controls.Add(Me.Panel12)
        Me.PnnEscala.Controls.Add(Me.Panel9)
        Me.PnnEscala.Controls.Add(Me.Panel6)
        Me.PnnEscala.Location = New System.Drawing.Point(3, 84)
        Me.PnnEscala.Name = "PnnEscala"
        Me.PnnEscala.Size = New System.Drawing.Size(70, 15)
        Me.PnnEscala.TabIndex = 2
        Me.PnnEscala.Visible = False
        '
        'Panel33
        '
        Me.Panel33.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel33.Controls.Add(Me.Label17)
        Me.Panel33.Controls.Add(Me.Panel34)
        Me.Panel33.Controls.Add(Me.Panel35)
        Me.Panel33.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel33.Location = New System.Drawing.Point(486, 0)
        Me.Panel33.Name = "Panel33"
        Me.Panel33.Size = New System.Drawing.Size(54, 15)
        Me.Panel33.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.SlateGray
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label17.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label17.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label17.Location = New System.Drawing.Point(0, 12)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 0)
        Me.Label17.TabIndex = 48
        Me.Label17.Text = "10"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel34
        '
        Me.Panel34.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel34.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel34.Location = New System.Drawing.Point(0, 3)
        Me.Panel34.Name = "Panel34"
        Me.Panel34.Size = New System.Drawing.Size(54, 12)
        Me.Panel34.TabIndex = 2
        '
        'Panel35
        '
        Me.Panel35.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel35.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel35.Location = New System.Drawing.Point(0, 0)
        Me.Panel35.Name = "Panel35"
        Me.Panel35.Size = New System.Drawing.Size(54, 12)
        Me.Panel35.TabIndex = 1
        '
        'Panel30
        '
        Me.Panel30.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel30.Controls.Add(Me.Label16)
        Me.Panel30.Controls.Add(Me.Panel31)
        Me.Panel30.Controls.Add(Me.Panel32)
        Me.Panel30.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel30.Location = New System.Drawing.Point(432, 0)
        Me.Panel30.Name = "Panel30"
        Me.Panel30.Size = New System.Drawing.Size(54, 15)
        Me.Panel30.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SlateGray
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label16.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label16.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label16.Location = New System.Drawing.Point(0, 12)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 0)
        Me.Label16.TabIndex = 48
        Me.Label16.Text = "9"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel31
        '
        Me.Panel31.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel31.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel31.Location = New System.Drawing.Point(0, 3)
        Me.Panel31.Name = "Panel31"
        Me.Panel31.Size = New System.Drawing.Size(54, 12)
        Me.Panel31.TabIndex = 2
        '
        'Panel32
        '
        Me.Panel32.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel32.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel32.Location = New System.Drawing.Point(0, 0)
        Me.Panel32.Name = "Panel32"
        Me.Panel32.Size = New System.Drawing.Size(54, 12)
        Me.Panel32.TabIndex = 1
        '
        'Panel27
        '
        Me.Panel27.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel27.Controls.Add(Me.Label15)
        Me.Panel27.Controls.Add(Me.Panel28)
        Me.Panel27.Controls.Add(Me.Panel29)
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel27.Location = New System.Drawing.Point(378, 0)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(54, 15)
        Me.Panel27.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.SlateGray
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label15.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label15.Location = New System.Drawing.Point(0, 12)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 0)
        Me.Label15.TabIndex = 48
        Me.Label15.Text = "8"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel28
        '
        Me.Panel28.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel28.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel28.Location = New System.Drawing.Point(0, 3)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(54, 12)
        Me.Panel28.TabIndex = 2
        '
        'Panel29
        '
        Me.Panel29.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel29.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel29.Location = New System.Drawing.Point(0, 0)
        Me.Panel29.Name = "Panel29"
        Me.Panel29.Size = New System.Drawing.Size(54, 12)
        Me.Panel29.TabIndex = 1
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel24.Controls.Add(Me.Label14)
        Me.Panel24.Controls.Add(Me.Panel25)
        Me.Panel24.Controls.Add(Me.Panel26)
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel24.Location = New System.Drawing.Point(324, 0)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(54, 15)
        Me.Panel24.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SlateGray
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label14.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label14.Location = New System.Drawing.Point(0, 12)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 0)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "7"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel25.Location = New System.Drawing.Point(0, 3)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(54, 12)
        Me.Panel25.TabIndex = 2
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel26.Location = New System.Drawing.Point(0, 0)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(54, 12)
        Me.Panel26.TabIndex = 1
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel21.Controls.Add(Me.Label13)
        Me.Panel21.Controls.Add(Me.Panel22)
        Me.Panel21.Controls.Add(Me.Panel23)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel21.Location = New System.Drawing.Point(270, 0)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(54, 15)
        Me.Panel21.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SlateGray
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label13.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label13.Location = New System.Drawing.Point(0, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 0)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "6"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel22.Location = New System.Drawing.Point(0, 3)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(54, 12)
        Me.Panel22.TabIndex = 2
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(0, 0)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(54, 12)
        Me.Panel23.TabIndex = 1
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel18.Controls.Add(Me.Label12)
        Me.Panel18.Controls.Add(Me.Panel19)
        Me.Panel18.Controls.Add(Me.Panel20)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel18.Location = New System.Drawing.Point(216, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(54, 15)
        Me.Panel18.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SlateGray
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label12.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label12.Location = New System.Drawing.Point(0, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(54, 0)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "5"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel19
        '
        Me.Panel19.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel19.Location = New System.Drawing.Point(0, 3)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(54, 12)
        Me.Panel19.TabIndex = 2
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(0, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(54, 12)
        Me.Panel20.TabIndex = 1
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel15.Controls.Add(Me.Label11)
        Me.Panel15.Controls.Add(Me.Panel16)
        Me.Panel15.Controls.Add(Me.Panel17)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel15.Location = New System.Drawing.Point(162, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(54, 15)
        Me.Panel15.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SlateGray
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label11.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Location = New System.Drawing.Point(0, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 0)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "4"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel16.Location = New System.Drawing.Point(0, 3)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(54, 12)
        Me.Panel16.TabIndex = 2
        '
        'Panel17
        '
        Me.Panel17.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(0, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(54, 12)
        Me.Panel17.TabIndex = 1
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel12.Controls.Add(Me.Label10)
        Me.Panel12.Controls.Add(Me.Panel13)
        Me.Panel12.Controls.Add(Me.Panel14)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel12.Location = New System.Drawing.Point(108, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(54, 15)
        Me.Panel12.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SlateGray
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label10.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label10.Location = New System.Drawing.Point(0, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 0)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "3"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel13.Location = New System.Drawing.Point(0, 3)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(54, 12)
        Me.Panel13.TabIndex = 2
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(0, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(54, 12)
        Me.Panel14.TabIndex = 1
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Controls.Add(Me.Label9)
        Me.Panel9.Controls.Add(Me.Panel10)
        Me.Panel9.Controls.Add(Me.Panel11)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel9.Location = New System.Drawing.Point(54, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(54, 15)
        Me.Panel9.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SlateGray
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label9.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Location = New System.Drawing.Point(0, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 0)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "2"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel10.Location = New System.Drawing.Point(0, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(54, 12)
        Me.Panel10.TabIndex = 2
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(54, 12)
        Me.Panel11.TabIndex = 1
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(54, 15)
        Me.Panel6.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SlateGray
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Calibri", 20.25!)
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(0, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 0)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "1"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(54, 12)
        Me.Panel8.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(54, 12)
        Me.Panel7.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label6)
        Me.Panel5.Location = New System.Drawing.Point(208, 44)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(78, 29)
        Me.Panel5.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.Label6.ForeColor = System.Drawing.Color.SlateGray
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 29)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Esta condição é do tipo verdadeiro ou falso, seja objetivo(a) na pergunta."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnnTexto
        '
        Me.PnnTexto.Controls.Add(Me.CkPermiteCaracter)
        Me.PnnTexto.Controls.Add(Me.CkPermiteNumero)
        Me.PnnTexto.Controls.Add(Me.CkPermiteLetras)
        Me.PnnTexto.Controls.Add(Me.Label5)
        Me.PnnTexto.Location = New System.Drawing.Point(3, 20)
        Me.PnnTexto.Name = "PnnTexto"
        Me.PnnTexto.Size = New System.Drawing.Size(41, 31)
        Me.PnnTexto.TabIndex = 0
        Me.PnnTexto.Visible = False
        '
        'CkPermiteCaracter
        '
        Me.CkPermiteCaracter.AutoSize = True
        Me.CkPermiteCaracter.Checked = True
        Me.CkPermiteCaracter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkPermiteCaracter.Location = New System.Drawing.Point(5, 190)
        Me.CkPermiteCaracter.Name = "CkPermiteCaracter"
        Me.CkPermiteCaracter.Size = New System.Drawing.Size(148, 17)
        Me.CkPermiteCaracter.TabIndex = 3
        Me.CkPermiteCaracter.Text = "Permite caracter especial"
        Me.CkPermiteCaracter.UseVisualStyleBackColor = True
        '
        'CkPermiteNumero
        '
        Me.CkPermiteNumero.AutoSize = True
        Me.CkPermiteNumero.Checked = True
        Me.CkPermiteNumero.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkPermiteNumero.Location = New System.Drawing.Point(205, 190)
        Me.CkPermiteNumero.Name = "CkPermiteNumero"
        Me.CkPermiteNumero.Size = New System.Drawing.Size(103, 17)
        Me.CkPermiteNumero.TabIndex = 2
        Me.CkPermiteNumero.Text = "Permite número"
        Me.CkPermiteNumero.UseVisualStyleBackColor = True
        '
        'CkPermiteLetras
        '
        Me.CkPermiteLetras.AutoSize = True
        Me.CkPermiteLetras.Checked = True
        Me.CkPermiteLetras.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CkPermiteLetras.Location = New System.Drawing.Point(364, 190)
        Me.CkPermiteLetras.Name = "CkPermiteLetras"
        Me.CkPermiteLetras.Size = New System.Drawing.Size(94, 17)
        Me.CkPermiteLetras.TabIndex = 1
        Me.CkPermiteLetras.Text = "Permite letras"
        Me.CkPermiteLetras.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.Label5.ForeColor = System.Drawing.Color.SlateGray
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 187)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Usuário deverá responder a pergunta por escrito."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GpTipo
        '
        Me.GpTipo.Controls.Add(Me.RdbMultiplaEscolha)
        Me.GpTipo.Controls.Add(Me.RdbUnicaEscolha)
        Me.GpTipo.Controls.Add(Me.RdbEscala)
        Me.GpTipo.Controls.Add(Me.RdbSimNão)
        Me.GpTipo.Controls.Add(Me.RdbTexto)
        Me.GpTipo.Enabled = False
        Me.GpTipo.Location = New System.Drawing.Point(13, 93)
        Me.GpTipo.Name = "GpTipo"
        Me.GpTipo.Size = New System.Drawing.Size(545, 93)
        Me.GpTipo.TabIndex = 49
        Me.GpTipo.TabStop = False
        Me.GpTipo.Text = "Tipo de interação da resposta"
        '
        'RdbMultiplaEscolha
        '
        Me.RdbMultiplaEscolha.AutoSize = True
        Me.RdbMultiplaEscolha.Location = New System.Drawing.Point(131, 59)
        Me.RdbMultiplaEscolha.Name = "RdbMultiplaEscolha"
        Me.RdbMultiplaEscolha.Size = New System.Drawing.Size(103, 17)
        Me.RdbMultiplaEscolha.TabIndex = 4
        Me.RdbMultiplaEscolha.Text = "Múltipla escolha"
        Me.RdbMultiplaEscolha.UseVisualStyleBackColor = True
        '
        'RdbUnicaEscolha
        '
        Me.RdbUnicaEscolha.AutoSize = True
        Me.RdbUnicaEscolha.Location = New System.Drawing.Point(7, 59)
        Me.RdbUnicaEscolha.Name = "RdbUnicaEscolha"
        Me.RdbUnicaEscolha.Size = New System.Drawing.Size(91, 17)
        Me.RdbUnicaEscolha.TabIndex = 3
        Me.RdbUnicaEscolha.Text = "Unica escolha"
        Me.RdbUnicaEscolha.UseVisualStyleBackColor = True
        '
        'RdbEscala
        '
        Me.RdbEscala.AutoSize = True
        Me.RdbEscala.Location = New System.Drawing.Point(281, 32)
        Me.RdbEscala.Name = "RdbEscala"
        Me.RdbEscala.Size = New System.Drawing.Size(78, 17)
        Me.RdbEscala.TabIndex = 2
        Me.RdbEscala.Text = "Escala 0-10"
        Me.RdbEscala.UseVisualStyleBackColor = True
        '
        'RdbSimNão
        '
        Me.RdbSimNão.AutoSize = True
        Me.RdbSimNão.Location = New System.Drawing.Point(131, 32)
        Me.RdbSimNão.Name = "RdbSimNão"
        Me.RdbSimNão.Size = New System.Drawing.Size(65, 17)
        Me.RdbSimNão.TabIndex = 1
        Me.RdbSimNão.Text = "Sim/Não"
        Me.RdbSimNão.UseVisualStyleBackColor = True
        '
        'RdbTexto
        '
        Me.RdbTexto.AutoSize = True
        Me.RdbTexto.Location = New System.Drawing.Point(7, 32)
        Me.RdbTexto.Name = "RdbTexto"
        Me.RdbTexto.Size = New System.Drawing.Size(50, 17)
        Me.RdbTexto.TabIndex = 0
        Me.RdbTexto.Text = "Texto"
        Me.RdbTexto.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label3.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Location = New System.Drawing.Point(12, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Pergunta "
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Location = New System.Drawing.Point(0, 483)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(573, 36)
        Me.Panel2.TabIndex = 51
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(478, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BttFechar)
        Me.Panel3.Controls.Add(Me.BttSalvar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Location = New System.Drawing.Point(478, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(95, 36)
        Me.Panel3.TabIndex = 26
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(60, 7)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 20)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(19, 7)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 27
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'FrmPerguntaCheklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(573, 519)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PnnPergunta)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmPerguntaCheklist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPerguntaCheklist"
        Me.PnnPergunta.ResumeLayout(False)
        Me.PnnPergunta.PerformLayout()
        Me.GpDetalhe.ResumeLayout(False)
        Me.PnnUnicaEsolha.ResumeLayout(False)
        Me.PnnUnicaEsolha.PerformLayout()
        Me.PnnEscala.ResumeLayout(False)
        Me.Panel33.ResumeLayout(False)
        Me.Panel30.ResumeLayout(False)
        Me.Panel27.ResumeLayout(False)
        Me.Panel24.ResumeLayout(False)
        Me.Panel21.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.PnnTexto.ResumeLayout(False)
        Me.PnnTexto.PerformLayout()
        Me.GpTipo.ResumeLayout(False)
        Me.GpTipo.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnPergunta As Panel
    Friend WithEvents GpDetalhe As GroupBox
    Friend WithEvents PnnUnicaEsolha As Panel
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents BttAddOpção As Button
    Friend WithEvents TxtDescriçãoOpção As TextBox
    Friend WithEvents BttRemoveItem As Button
    Friend WithEvents Label18 As Label
    Friend WithEvents PnnEscala As Panel
    Friend WithEvents Panel33 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Panel34 As Panel
    Friend WithEvents Panel35 As Panel
    Friend WithEvents Panel30 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Panel31 As Panel
    Friend WithEvents Panel32 As Panel
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Label15 As Label
    Friend WithEvents Panel28 As Panel
    Friend WithEvents Panel29 As Panel
    Friend WithEvents Panel24 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Panel25 As Panel
    Friend WithEvents Panel26 As Panel
    Friend WithEvents Panel21 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel22 As Panel
    Friend WithEvents Panel23 As Panel
    Friend WithEvents Panel18 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel19 As Panel
    Friend WithEvents Panel20 As Panel
    Friend WithEvents Panel15 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel16 As Panel
    Friend WithEvents Panel17 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Panel14 As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel10 As Panel
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents PnnTexto As Panel
    Friend WithEvents CkPermiteCaracter As CheckBox
    Friend WithEvents CkPermiteNumero As CheckBox
    Friend WithEvents CkPermiteLetras As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents GpTipo As GroupBox
    Friend WithEvents CkExigeImagem As CheckBox
    Friend WithEvents RdbMultiplaEscolha As RadioButton
    Friend WithEvents RdbUnicaEscolha As RadioButton
    Friend WithEvents RdbEscala As RadioButton
    Friend WithEvents RdbSimNão As RadioButton
    Friend WithEvents RdbTexto As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents TxtPergunta As TextBox
End Class
