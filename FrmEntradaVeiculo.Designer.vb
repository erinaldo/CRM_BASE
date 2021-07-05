<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEntradaVeiculo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEntradaVeiculo))
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.LblPedido = New System.Windows.Forms.Label()
        Me.TxtModelo = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.MaskedTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCelular = New System.Windows.Forms.MaskedTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtPlaca = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNomeCompleto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtRg = New System.Windows.Forms.TextBox()
        Me.RdbProprietario = New System.Windows.Forms.RadioButton()
        Me.RdbPrestador = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LblOrçamento = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblProcesso = New System.Windows.Forms.Label()
        Me.LblPlaca = New System.Windows.Forms.Label()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TrAvaliações = New System.Windows.Forms.TreeView()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PicAvaliações = New System.Windows.Forms.PictureBox()
        Me.BttBuscarCliente = New System.Windows.Forms.Button()
        Me.BttBuscarRg = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PicAvaliações, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(1269, 28)
        Me.LblTitulo.TabIndex = 31
        Me.LblTitulo.Text = "Recebimento do veículo"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPedido
        '
        Me.LblPedido.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPedido.Location = New System.Drawing.Point(587, 27)
        Me.LblPedido.Name = "LblPedido"
        Me.LblPedido.Size = New System.Drawing.Size(267, 26)
        Me.LblPedido.TabIndex = 32
        Me.LblPedido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblPedido.Visible = False
        '
        'TxtModelo
        '
        Me.TxtModelo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModelo.Enabled = False
        Me.TxtModelo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtModelo.Location = New System.Drawing.Point(258, 188)
        Me.TxtModelo.Name = "TxtModelo"
        Me.TxtModelo.Size = New System.Drawing.Size(315, 17)
        Me.TxtModelo.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(161, 191)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Modelo"
        '
        'TxtEmail
        '
        Me.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmail.Enabled = False
        Me.TxtEmail.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtEmail.Location = New System.Drawing.Point(258, 138)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(315, 17)
        Me.TxtEmail.TabIndex = 28
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(161, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "E-mail"
        '
        'TxtCelular
        '
        Me.TxtCelular.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCelular.Enabled = False
        Me.TxtCelular.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCelular.Location = New System.Drawing.Point(258, 111)
        Me.TxtCelular.Mask = "(00) 0 0000-0000"
        Me.TxtCelular.Name = "TxtCelular"
        Me.TxtCelular.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtCelular.Size = New System.Drawing.Size(151, 17)
        Me.TxtCelular.TabIndex = 10
        Me.TxtCelular.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(161, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Celular"
        '
        'TxtPlaca
        '
        Me.TxtPlaca.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPlaca.Enabled = False
        Me.TxtPlaca.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPlaca.Location = New System.Drawing.Point(258, 161)
        Me.TxtPlaca.Mask = "LLL-0000"
        Me.TxtPlaca.Name = "TxtPlaca"
        Me.TxtPlaca.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtPlaca.Size = New System.Drawing.Size(151, 17)
        Me.TxtPlaca.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(161, 164)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Placa do veículo"
        '
        'TxtNomeCompleto
        '
        Me.TxtNomeCompleto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeCompleto.Enabled = False
        Me.TxtNomeCompleto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeCompleto.Location = New System.Drawing.Point(258, 88)
        Me.TxtNomeCompleto.Name = "TxtNomeCompleto"
        Me.TxtNomeCompleto.Size = New System.Drawing.Size(315, 17)
        Me.TxtNomeCompleto.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(161, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nome completo"
        '
        'TxtRg
        '
        Me.TxtRg.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRg.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtRg.Location = New System.Drawing.Point(258, 65)
        Me.TxtRg.Name = "TxtRg"
        Me.TxtRg.Size = New System.Drawing.Size(169, 17)
        Me.TxtRg.TabIndex = 3
        '
        'RdbProprietario
        '
        Me.RdbProprietario.AutoSize = True
        Me.RdbProprietario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbProprietario.Location = New System.Drawing.Point(22, 37)
        Me.RdbProprietario.Name = "RdbProprietario"
        Me.RdbProprietario.Size = New System.Drawing.Size(263, 17)
        Me.RdbProprietario.TabIndex = 2
        Me.RdbProprietario.Text = "Entregue por proprietário ou condutor responsável"
        Me.RdbProprietario.UseVisualStyleBackColor = True
        '
        'RdbPrestador
        '
        Me.RdbPrestador.AutoSize = True
        Me.RdbPrestador.Checked = True
        Me.RdbPrestador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdbPrestador.Location = New System.Drawing.Point(292, 37)
        Me.RdbPrestador.Name = "RdbPrestador"
        Me.RdbPrestador.Size = New System.Drawing.Size(133, 17)
        Me.RdbPrestador.TabIndex = 1
        Me.RdbPrestador.TabStop = True
        Me.RdbPrestador.Text = "Entregue por prestador"
        Me.RdbPrestador.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(161, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "RG"
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 643)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(1269, 38)
        Me.PnnInferior.TabIndex = 36
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1221, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(1221, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(48, 38)
        Me.Panel12.TabIndex = 29
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(1270, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 680)
        Me.Panel3.TabIndex = 38
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(0, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 680)
        Me.Panel5.TabIndex = 39
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1271, 1)
        Me.Panel6.TabIndex = 40
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel7.Location = New System.Drawing.Point(0, 681)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1271, 1)
        Me.Panel7.TabIndex = 41
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel10.Controls.Add(Me.LblOrçamento)
        Me.Panel10.Controls.Add(Me.Label10)
        Me.Panel10.Controls.Add(Me.Panel2)
        Me.Panel10.Controls.Add(Me.LblPedido)
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Controls.Add(Me.Label9)
        Me.Panel10.Controls.Add(Me.LblProcesso)
        Me.Panel10.Controls.Add(Me.LblPlaca)
        Me.Panel10.Controls.Add(Me.Panel13)
        Me.Panel10.Controls.Add(Me.Label11)
        Me.Panel10.Controls.Add(Me.Panel11)
        Me.Panel10.Controls.Add(Me.Label12)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(1, 29)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1269, 57)
        Me.Panel10.TabIndex = 43
        '
        'LblOrçamento
        '
        Me.LblOrçamento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblOrçamento.ForeColor = System.Drawing.Color.SlateGray
        Me.LblOrçamento.Location = New System.Drawing.Point(1077, 25)
        Me.LblOrçamento.Name = "LblOrçamento"
        Me.LblOrçamento.Size = New System.Drawing.Size(181, 26)
        Me.LblOrçamento.TabIndex = 125
        Me.LblOrçamento.Text = "0"
        Me.LblOrçamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(1077, 3)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(181, 21)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Orçamento rápido"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel2.Location = New System.Drawing.Point(860, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(2, 50)
        Me.Panel2.TabIndex = 123
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label8.Location = New System.Drawing.Point(587, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(200, 21)
        Me.Label8.TabIndex = 122
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(587, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(267, 21)
        Me.Label9.TabIndex = 120
        Me.Label9.Text = "Chave de rastreio"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblProcesso
        '
        Me.LblProcesso.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblProcesso.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblProcesso.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblProcesso.Location = New System.Drawing.Point(373, 27)
        Me.LblProcesso.Name = "LblProcesso"
        Me.LblProcesso.Size = New System.Drawing.Size(200, 21)
        Me.LblProcesso.TabIndex = 119
        Me.LblProcesso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblPlaca
        '
        Me.LblPlaca.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblPlaca.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblPlaca.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblPlaca.Location = New System.Drawing.Point(3, 27)
        Me.LblPlaca.Name = "LblPlaca"
        Me.LblPlaca.Size = New System.Drawing.Size(356, 21)
        Me.LblPlaca.TabIndex = 118
        Me.LblPlaca.Text = "Dados do veículo"
        Me.LblPlaca.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel13.Location = New System.Drawing.Point(579, 4)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(2, 50)
        Me.Panel13.TabIndex = 114
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(373, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(200, 21)
        Me.Label11.TabIndex = 113
        Me.Label11.Text = "Num. processo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel11.Location = New System.Drawing.Point(365, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(2, 50)
        Me.Panel11.TabIndex = 112
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label12.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label12.Location = New System.Drawing.Point(3, 3)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(356, 21)
        Me.Label12.TabIndex = 111
        Me.Label12.Text = "Dados do veículo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel8.Controls.Add(Me.BttBuscarCliente)
        Me.Panel8.Controls.Add(Me.TrAvaliações)
        Me.Panel8.Controls.Add(Me.Label14)
        Me.Panel8.Controls.Add(Me.RdbPrestador)
        Me.Panel8.Controls.Add(Me.TxtModelo)
        Me.Panel8.Controls.Add(Me.RdbProprietario)
        Me.Panel8.Controls.Add(Me.Label7)
        Me.Panel8.Controls.Add(Me.Label1)
        Me.Panel8.Controls.Add(Me.TxtEmail)
        Me.Panel8.Controls.Add(Me.TxtPlaca)
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Controls.Add(Me.TxtRg)
        Me.Panel8.Controls.Add(Me.Label6)
        Me.Panel8.Controls.Add(Me.BttBuscarRg)
        Me.Panel8.Controls.Add(Me.TxtCelular)
        Me.Panel8.Controls.Add(Me.Label5)
        Me.Panel8.Controls.Add(Me.TxtNomeCompleto)
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(1, 86)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1269, 225)
        Me.Panel8.TabIndex = 44
        '
        'TrAvaliações
        '
        Me.TrAvaliações.Location = New System.Drawing.Point(1080, 31)
        Me.TrAvaliações.Name = "TrAvaliações"
        Me.TrAvaliações.Size = New System.Drawing.Size(175, 191)
        Me.TrAvaliações.TabIndex = 112
        Me.TrAvaliações.Visible = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Gainsboro
        Me.Label14.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label14.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label14.Location = New System.Drawing.Point(3, 3)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(1255, 21)
        Me.Label14.TabIndex = 111
        Me.Label14.Text = "Informações necessarias para entrada"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gainsboro
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(4, 323)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1255, 21)
        Me.Label4.TabIndex = 112
        Me.Label4.Text = "Avaliações obtidas"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.PicAvaliações)
        Me.Panel1.Location = New System.Drawing.Point(7, 355)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1252, 277)
        Me.Panel1.TabIndex = 113
        '
        'PicAvaliações
        '
        Me.PicAvaliações.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PicAvaliações.Location = New System.Drawing.Point(5, 3)
        Me.PicAvaliações.Name = "PicAvaliações"
        Me.PicAvaliações.Size = New System.Drawing.Size(1244, 268)
        Me.PicAvaliações.TabIndex = 0
        Me.PicAvaliações.TabStop = False
        '
        'BttBuscarCliente
        '
        Me.BttBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscarCliente.Enabled = False
        Me.BttBuscarCliente.FlatAppearance.BorderSize = 0
        Me.BttBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscarCliente.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BttBuscarCliente.ImageIndex = 0
        Me.BttBuscarCliente.ImageList = Me.ImageList1
        Me.BttBuscarCliente.Location = New System.Drawing.Point(22, 67)
        Me.BttBuscarCliente.Name = "BttBuscarCliente"
        Me.BttBuscarCliente.Size = New System.Drawing.Size(106, 141)
        Me.BttBuscarCliente.TabIndex = 113
        Me.BttBuscarCliente.Text = "Receber  veiculo"
        Me.BttBuscarCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BttBuscarCliente.UseVisualStyleBackColor = True
        '
        'BttBuscarRg
        '
        Me.BttBuscarRg.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Search_find_locate_1542
        Me.BttBuscarRg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscarRg.Enabled = False
        Me.BttBuscarRg.FlatAppearance.BorderSize = 0
        Me.BttBuscarRg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscarRg.Location = New System.Drawing.Point(434, 65)
        Me.BttBuscarRg.Name = "BttBuscarRg"
        Me.BttBuscarRg.Size = New System.Drawing.Size(20, 16)
        Me.BttBuscarRg.TabIndex = 26
        Me.BttBuscarRg.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(15, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(20, 23)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "garage_13258.png")
        '
        'FrmEntradaVeiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1271, 682)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmEntradaVeiculo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEntradaVeiculo"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PicAvaliações, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents TxtPlaca As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNomeCompleto As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtRg As TextBox
    Friend WithEvents RdbProprietario As RadioButton
    Friend WithEvents RdbPrestador As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents TxtCelular As MaskedTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BttBuscarRg As Button
    Friend WithEvents TxtModelo As MaskedTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtEmail As MaskedTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LblPedido As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel10 As Panel
    Friend WithEvents LblProcesso As Label
    Friend WithEvents LblPlaca As Label
    Friend WithEvents Panel13 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel11 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PicAvaliações As PictureBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents TrAvaliações As TreeView
    Friend WithEvents LblOrçamento As Label
    Friend WithEvents BttBuscarCliente As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents ImageList1 As ImageList
End Class
