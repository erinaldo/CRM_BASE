<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovoLancamento
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
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.LblIdVistoria = New System.Windows.Forms.Label()
        Me.LblIdSolução = New System.Windows.Forms.Label()
        Me.LblIdmarca = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtDescricao = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RdbValorReceber = New System.Windows.Forms.RadioButton()
        Me.RdbValorPagar = New System.Windows.Forms.RadioButton()
        Me.TxtValor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CkRepete = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.NmRepetir = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RdbAno = New System.Windows.Forms.RadioButton()
        Me.RdbMeses = New System.Windows.Forms.RadioButton()
        Me.RdbDias = New System.Windows.Forms.RadioButton()
        Me.NmVlrRepete = New System.Windows.Forms.NumericUpDown()
        Me.CkAferir = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NmDiasSolicitar = New System.Windows.Forms.NumericUpDown()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CmbCategoria = New System.Windows.Forms.ComboBox()
        Me.CmbBeneficiario = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BttAddCategoria = New System.Windows.Forms.Button()
        Me.BttAdicionarFornecedor = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NmRepetir, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.NmVlrRepete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.NmDiasSolicitar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.LblIdVistoria)
        Me.PnnInferior.Controls.Add(Me.LblIdSolução)
        Me.PnnInferior.Controls.Add(Me.LblIdmarca)
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 611)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(450, 32)
        Me.PnnInferior.TabIndex = 93
        '
        'LblIdVistoria
        '
        Me.LblIdVistoria.AutoSize = True
        Me.LblIdVistoria.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdVistoria.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdVistoria.Location = New System.Drawing.Point(30, 5)
        Me.LblIdVistoria.Name = "LblIdVistoria"
        Me.LblIdVistoria.Size = New System.Drawing.Size(15, 17)
        Me.LblIdVistoria.TabIndex = 48
        Me.LblIdVistoria.Text = "0"
        Me.LblIdVistoria.Visible = False
        '
        'LblIdSolução
        '
        Me.LblIdSolução.AutoSize = True
        Me.LblIdSolução.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdSolução.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdSolução.Location = New System.Drawing.Point(15, 5)
        Me.LblIdSolução.Name = "LblIdSolução"
        Me.LblIdSolução.Size = New System.Drawing.Size(15, 17)
        Me.LblIdSolução.TabIndex = 47
        Me.LblIdSolução.Text = "0"
        Me.LblIdSolução.Visible = False
        '
        'LblIdmarca
        '
        Me.LblIdmarca.AutoSize = True
        Me.LblIdmarca.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblIdmarca.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblIdmarca.Location = New System.Drawing.Point(0, 5)
        Me.LblIdmarca.Name = "LblIdmarca"
        Me.LblIdmarca.Size = New System.Drawing.Size(15, 17)
        Me.LblIdmarca.TabIndex = 46
        Me.LblIdmarca.Text = "0"
        Me.LblIdmarca.Visible = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(383, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(383, 0)
        Me.Panel12.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(67, 32)
        Me.Panel12.TabIndex = 50
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(12, 6)
        Me.BttSalvar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(14, 17)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(38, 7)
        Me.BttFechar.Margin = New System.Windows.Forms.Padding(4)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(14, 17)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(450, 22)
        Me.LblTitulo.TabIndex = 94
        Me.LblTitulo.Text = "Novo lançamento financeiro"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 17)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Descrição do lançamento"
        '
        'TxtDescricao
        '
        Me.TxtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescricao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescricao.Location = New System.Drawing.Point(33, 66)
        Me.TxtDescricao.Name = "TxtDescricao"
        Me.TxtDescricao.Size = New System.Drawing.Size(379, 21)
        Me.TxtDescricao.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 17)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "Tipo de item"
        '
        'RdbValorReceber
        '
        Me.RdbValorReceber.AutoSize = True
        Me.RdbValorReceber.Enabled = False
        Me.RdbValorReceber.Location = New System.Drawing.Point(33, 134)
        Me.RdbValorReceber.Name = "RdbValorReceber"
        Me.RdbValorReceber.Size = New System.Drawing.Size(127, 21)
        Me.RdbValorReceber.TabIndex = 98
        Me.RdbValorReceber.Text = "Valores a receber"
        Me.RdbValorReceber.UseVisualStyleBackColor = True
        '
        'RdbValorPagar
        '
        Me.RdbValorPagar.AutoSize = True
        Me.RdbValorPagar.Enabled = False
        Me.RdbValorPagar.Location = New System.Drawing.Point(166, 134)
        Me.RdbValorPagar.Name = "RdbValorPagar"
        Me.RdbValorPagar.Size = New System.Drawing.Size(116, 21)
        Me.RdbValorPagar.TabIndex = 99
        Me.RdbValorPagar.Text = "Valores a pagar"
        Me.RdbValorPagar.UseVisualStyleBackColor = True
        '
        'TxtValor
        '
        Me.TxtValor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValor.Enabled = False
        Me.TxtValor.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtValor.Location = New System.Drawing.Point(34, 321)
        Me.TxtValor.Name = "TxtValor"
        Me.TxtValor.Size = New System.Drawing.Size(379, 21)
        Me.TxtValor.TabIndex = 101
        Me.TxtValor.Text = "R$ 0,00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 301)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 17)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "Valor do item"
        '
        'CkRepete
        '
        Me.CkRepete.AutoSize = True
        Me.CkRepete.Enabled = False
        Me.CkRepete.Location = New System.Drawing.Point(34, 370)
        Me.CkRepete.Name = "CkRepete"
        Me.CkRepete.Size = New System.Drawing.Size(142, 21)
        Me.CkRepete.TabIndex = 102
        Me.CkRepete.Text = "Repetir lançamento"
        Me.CkRepete.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.NmRepetir)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.NmVlrRepete)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(34, 397)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 85)
        Me.Panel1.TabIndex = 103
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 17)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Repetir"
        '
        'NmRepetir
        '
        Me.NmRepetir.Enabled = False
        Me.NmRepetir.Location = New System.Drawing.Point(88, 45)
        Me.NmRepetir.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NmRepetir.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmRepetir.Name = "NmRepetir"
        Me.NmRepetir.Size = New System.Drawing.Size(59, 23)
        Me.NmRepetir.TabIndex = 104
        Me.NmRepetir.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 17)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "A cada"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RdbAno)
        Me.Panel2.Controls.Add(Me.RdbMeses)
        Me.Panel2.Controls.Add(Me.RdbDias)
        Me.Panel2.Location = New System.Drawing.Point(169, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(184, 23)
        Me.Panel2.TabIndex = 102
        '
        'RdbAno
        '
        Me.RdbAno.AutoSize = True
        Me.RdbAno.Dock = System.Windows.Forms.DockStyle.Left
        Me.RdbAno.Location = New System.Drawing.Point(115, 0)
        Me.RdbAno.Name = "RdbAno"
        Me.RdbAno.Size = New System.Drawing.Size(55, 23)
        Me.RdbAno.TabIndex = 101
        Me.RdbAno.TabStop = True
        Me.RdbAno.Text = "anos"
        Me.RdbAno.UseVisualStyleBackColor = True
        '
        'RdbMeses
        '
        Me.RdbMeses.AutoSize = True
        Me.RdbMeses.Dock = System.Windows.Forms.DockStyle.Left
        Me.RdbMeses.Location = New System.Drawing.Point(51, 0)
        Me.RdbMeses.Name = "RdbMeses"
        Me.RdbMeses.Size = New System.Drawing.Size(64, 23)
        Me.RdbMeses.TabIndex = 100
        Me.RdbMeses.TabStop = True
        Me.RdbMeses.Text = "meses"
        Me.RdbMeses.UseVisualStyleBackColor = True
        '
        'RdbDias
        '
        Me.RdbDias.AutoSize = True
        Me.RdbDias.Dock = System.Windows.Forms.DockStyle.Left
        Me.RdbDias.Location = New System.Drawing.Point(0, 0)
        Me.RdbDias.Name = "RdbDias"
        Me.RdbDias.Size = New System.Drawing.Size(51, 23)
        Me.RdbDias.TabIndex = 99
        Me.RdbDias.TabStop = True
        Me.RdbDias.Text = "dias"
        Me.RdbDias.UseVisualStyleBackColor = True
        '
        'NmVlrRepete
        '
        Me.NmVlrRepete.Location = New System.Drawing.Point(88, 16)
        Me.NmVlrRepete.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NmVlrRepete.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmVlrRepete.Name = "NmVlrRepete"
        Me.NmVlrRepete.Size = New System.Drawing.Size(59, 23)
        Me.NmVlrRepete.TabIndex = 101
        Me.NmVlrRepete.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'CkAferir
        '
        Me.CkAferir.AutoSize = True
        Me.CkAferir.Enabled = False
        Me.CkAferir.Location = New System.Drawing.Point(33, 505)
        Me.CkAferir.Name = "CkAferir"
        Me.CkAferir.Size = New System.Drawing.Size(182, 21)
        Me.CkAferir.TabIndex = 104
        Me.CkAferir.Text = "Valor aferido mensalmente"
        Me.CkAferir.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.NmDiasSolicitar)
        Me.Panel3.Enabled = False
        Me.Panel3.Location = New System.Drawing.Point(33, 532)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(379, 51)
        Me.Panel3.TabIndex = 105
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(166, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 17)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "dias antes do vencimento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Solicitar "
        '
        'NmDiasSolicitar
        '
        Me.NmDiasSolicitar.Location = New System.Drawing.Point(88, 16)
        Me.NmDiasSolicitar.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NmDiasSolicitar.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NmDiasSolicitar.Name = "NmDiasSolicitar"
        Me.NmDiasSolicitar.Size = New System.Drawing.Size(59, 23)
        Me.NmDiasSolicitar.TabIndex = 101
        Me.NmDiasSolicitar.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(451, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1, 643)
        Me.Panel4.TabIndex = 106
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 643)
        Me.Panel6.TabIndex = 107
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 17)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Categoria"
        '
        'CmbCategoria
        '
        Me.CmbCategoria.Enabled = False
        Me.CmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbCategoria.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CmbCategoria.FormattingEnabled = True
        Me.CmbCategoria.Location = New System.Drawing.Point(33, 195)
        Me.CmbCategoria.Name = "CmbCategoria"
        Me.CmbCategoria.Size = New System.Drawing.Size(340, 29)
        Me.CmbCategoria.TabIndex = 109
        '
        'CmbBeneficiario
        '
        Me.CmbBeneficiario.Enabled = False
        Me.CmbBeneficiario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBeneficiario.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.CmbBeneficiario.FormattingEnabled = True
        Me.CmbBeneficiario.Location = New System.Drawing.Point(33, 254)
        Me.CmbBeneficiario.Name = "CmbBeneficiario"
        Me.CmbBeneficiario.Size = New System.Drawing.Size(340, 29)
        Me.CmbBeneficiario.TabIndex = 111
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(31, 234)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 17)
        Me.Label9.TabIndex = 110
        Me.Label9.Text = "Beneficiário"
        '
        'BttAddCategoria
        '
        Me.BttAddCategoria.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddCategoria.FlatAppearance.BorderSize = 0
        Me.BttAddCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddCategoria.Location = New System.Drawing.Point(384, 195)
        Me.BttAddCategoria.Margin = New System.Windows.Forms.Padding(4)
        Me.BttAddCategoria.Name = "BttAddCategoria"
        Me.BttAddCategoria.Size = New System.Drawing.Size(31, 21)
        Me.BttAddCategoria.TabIndex = 113
        Me.BttAddCategoria.UseVisualStyleBackColor = True
        '
        'BttAdicionarFornecedor
        '
        Me.BttAdicionarFornecedor.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAdicionarFornecedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAdicionarFornecedor.FlatAppearance.BorderSize = 0
        Me.BttAdicionarFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAdicionarFornecedor.Location = New System.Drawing.Point(384, 254)
        Me.BttAdicionarFornecedor.Margin = New System.Windows.Forms.Padding(4)
        Me.BttAdicionarFornecedor.Name = "BttAdicionarFornecedor"
        Me.BttAdicionarFornecedor.Size = New System.Drawing.Size(31, 21)
        Me.BttAdicionarFornecedor.TabIndex = 112
        Me.BttAdicionarFornecedor.UseVisualStyleBackColor = True
        '
        'FrmNovoLancamento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(452, 643)
        Me.Controls.Add(Me.BttAddCategoria)
        Me.Controls.Add(Me.BttAdicionarFornecedor)
        Me.Controls.Add(Me.CmbBeneficiario)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CmbCategoria)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.CkAferir)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.CkRepete)
        Me.Controls.Add(Me.TxtValor)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RdbValorPagar)
        Me.Controls.Add(Me.RdbValorReceber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDescricao)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovoLancamento"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovoLancamento"
        Me.PnnInferior.ResumeLayout(False)
        Me.PnnInferior.PerformLayout()
        Me.Panel12.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NmRepetir, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NmVlrRepete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.NmDiasSolicitar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PnnInferior As Panel
    Friend WithEvents LblIdVistoria As Label
    Friend WithEvents LblIdSolução As Label
    Friend WithEvents LblIdmarca As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents LblTitulo As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtDescricao As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents RdbValorReceber As RadioButton
    Friend WithEvents RdbValorPagar As RadioButton
    Friend WithEvents TxtValor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents CkRepete As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NmVlrRepete As NumericUpDown
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RdbAno As RadioButton
    Friend WithEvents RdbMeses As RadioButton
    Friend WithEvents RdbDias As RadioButton
    Friend WithEvents CkAferir As CheckBox
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents NmDiasSolicitar As NumericUpDown
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents CmbCategoria As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents NmRepetir As NumericUpDown
    Friend WithEvents CmbBeneficiario As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BttAdicionarFornecedor As Button
    Friend WithEvents BttAddCategoria As Button
End Class
