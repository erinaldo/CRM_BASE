<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovaFormaPgSaida
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
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.CkAvista = New System.Windows.Forms.CheckBox()
        Me.CkCartao = New System.Windows.Forms.CheckBox()
        Me.RdbDebito = New System.Windows.Forms.RadioButton()
        Me.RdbCredito = New System.Windows.Forms.RadioButton()
        Me.GpCartao = New System.Windows.Forms.GroupBox()
        Me.TxtLimite = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.CmbBandeira = New System.Windows.Forms.ComboBox()
        Me.TxtCVV = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtDiaVencimento = New System.Windows.Forms.NumericUpDown()
        Me.TxtDiaFechamento = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNomeTitular = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtValidade = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNumCartao = New System.Windows.Forms.MaskedTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbContaVinculada = New System.Windows.Forms.ComboBox()
        Me.TxtParcelas = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TxtIntervalo = New System.Windows.Forms.NumericUpDown()
        Me.PnnIntervalo = New System.Windows.Forms.Panel()
        Me.RdbMeses = New System.Windows.Forms.RadioButton()
        Me.RdbDia = New System.Windows.Forms.RadioButton()
        Me.BtnAddCarteira = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.GpCartao.SuspendLayout()
        CType(Me.TxtDiaVencimento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDiaFechamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtParcelas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtIntervalo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnIntervalo.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(488, 29)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nova forma de pagamento de saída"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 613)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(488, 36)
        Me.PnnInferior.TabIndex = 59
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(414, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(414, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(74, 36)
        Me.Panel12.TabIndex = 28
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.Enabled = False
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(18, 19)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(42, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 19)
        Me.BttFechar.TabIndex = 28
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 649)
        Me.Panel1.TabIndex = 60
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(489, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 649)
        Me.Panel2.TabIndex = 61
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(10, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 17)
        Me.Label16.TabIndex = 104
        Me.Label16.Text = "Descrição"
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescrição.Location = New System.Drawing.Point(98, 53)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(378, 21)
        Me.TxtDescrição.TabIndex = 105
        '
        'CkAvista
        '
        Me.CkAvista.AutoSize = True
        Me.CkAvista.Enabled = False
        Me.CkAvista.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CkAvista.Location = New System.Drawing.Point(13, 94)
        Me.CkAvista.Name = "CkAvista"
        Me.CkAvista.Size = New System.Drawing.Size(184, 21)
        Me.CkAvista.TabIndex = 106
        Me.CkAvista.Text = "Modo de pagamento a vista"
        Me.CkAvista.UseVisualStyleBackColor = True
        '
        'CkCartao
        '
        Me.CkCartao.AutoSize = True
        Me.CkCartao.Enabled = False
        Me.CkCartao.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CkCartao.Location = New System.Drawing.Point(13, 121)
        Me.CkCartao.Name = "CkCartao"
        Me.CkCartao.Size = New System.Drawing.Size(117, 21)
        Me.CkCartao.TabIndex = 107
        Me.CkCartao.Text = "Cartão bancário"
        Me.CkCartao.UseVisualStyleBackColor = True
        '
        'RdbDebito
        '
        Me.RdbDebito.AutoSize = True
        Me.RdbDebito.Enabled = False
        Me.RdbDebito.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RdbDebito.Location = New System.Drawing.Point(133, 121)
        Me.RdbDebito.Name = "RdbDebito"
        Me.RdbDebito.Size = New System.Drawing.Size(66, 21)
        Me.RdbDebito.TabIndex = 108
        Me.RdbDebito.TabStop = True
        Me.RdbDebito.Text = "Débito"
        Me.RdbDebito.UseVisualStyleBackColor = True
        '
        'RdbCredito
        '
        Me.RdbCredito.AutoSize = True
        Me.RdbCredito.Enabled = False
        Me.RdbCredito.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RdbCredito.Location = New System.Drawing.Point(199, 121)
        Me.RdbCredito.Name = "RdbCredito"
        Me.RdbCredito.Size = New System.Drawing.Size(69, 21)
        Me.RdbCredito.TabIndex = 109
        Me.RdbCredito.TabStop = True
        Me.RdbCredito.Text = "Crédito"
        Me.RdbCredito.UseVisualStyleBackColor = True
        '
        'GpCartao
        '
        Me.GpCartao.Controls.Add(Me.TxtLimite)
        Me.GpCartao.Controls.Add(Me.Label12)
        Me.GpCartao.Controls.Add(Me.CmbBandeira)
        Me.GpCartao.Controls.Add(Me.TxtCVV)
        Me.GpCartao.Controls.Add(Me.Label9)
        Me.GpCartao.Controls.Add(Me.Label7)
        Me.GpCartao.Controls.Add(Me.TxtDiaVencimento)
        Me.GpCartao.Controls.Add(Me.TxtDiaFechamento)
        Me.GpCartao.Controls.Add(Me.Label6)
        Me.GpCartao.Controls.Add(Me.Label5)
        Me.GpCartao.Controls.Add(Me.TxtNomeTitular)
        Me.GpCartao.Controls.Add(Me.Label4)
        Me.GpCartao.Controls.Add(Me.TxtValidade)
        Me.GpCartao.Controls.Add(Me.Label3)
        Me.GpCartao.Controls.Add(Me.TxtNumCartao)
        Me.GpCartao.Controls.Add(Me.Label2)
        Me.GpCartao.Enabled = False
        Me.GpCartao.Location = New System.Drawing.Point(13, 160)
        Me.GpCartao.Name = "GpCartao"
        Me.GpCartao.Size = New System.Drawing.Size(463, 313)
        Me.GpCartao.TabIndex = 110
        Me.GpCartao.TabStop = False
        Me.GpCartao.Text = "Dados do cartão"
        '
        'TxtLimite
        '
        Me.TxtLimite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLimite.Enabled = False
        Me.TxtLimite.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtLimite.Location = New System.Drawing.Point(354, 274)
        Me.TxtLimite.Name = "TxtLimite"
        Me.TxtLimite.Size = New System.Drawing.Size(103, 21)
        Me.TxtLimite.TabIndex = 124
        Me.TxtLimite.Text = "R$ 0,00"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(351, 254)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(106, 17)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "Limite de compra"
        '
        'CmbBandeira
        '
        Me.CmbBandeira.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbBandeira.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbBandeira.Enabled = False
        Me.CmbBandeira.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbBandeira.FormattingEnabled = True
        Me.CmbBandeira.ItemHeight = 15
        Me.CmbBandeira.Location = New System.Drawing.Point(133, 161)
        Me.CmbBandeira.Name = "CmbBandeira"
        Me.CmbBandeira.Size = New System.Drawing.Size(324, 23)
        Me.CmbBandeira.TabIndex = 114
        '
        'TxtCVV
        '
        Me.TxtCVV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCVV.Enabled = False
        Me.TxtCVV.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtCVV.Location = New System.Drawing.Point(14, 161)
        Me.TxtCVV.Name = "TxtCVV"
        Me.TxtCVV.Size = New System.Drawing.Size(103, 21)
        Me.TxtCVV.TabIndex = 122
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(130, 141)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 17)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Bandeira"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 17)
        Me.Label7.TabIndex = 123
        Me.Label7.Text = "CVV"
        '
        'TxtDiaVencimento
        '
        Me.TxtDiaVencimento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiaVencimento.Enabled = False
        Me.TxtDiaVencimento.Location = New System.Drawing.Point(14, 274)
        Me.TxtDiaVencimento.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.TxtDiaVencimento.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtDiaVencimento.Name = "TxtDiaVencimento"
        Me.TxtDiaVencimento.Size = New System.Drawing.Size(103, 19)
        Me.TxtDiaVencimento.TabIndex = 121
        Me.TxtDiaVencimento.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'TxtDiaFechamento
        '
        Me.TxtDiaFechamento.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiaFechamento.Enabled = False
        Me.TxtDiaFechamento.Location = New System.Drawing.Point(14, 218)
        Me.TxtDiaFechamento.Maximum = New Decimal(New Integer() {31, 0, 0, 0})
        Me.TxtDiaFechamento.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtDiaFechamento.Name = "TxtDiaFechamento"
        Me.TxtDiaFechamento.Size = New System.Drawing.Size(103, 19)
        Me.TxtDiaFechamento.TabIndex = 120
        Me.TxtDiaFechamento.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(168, 17)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "Dia do vencimento da fatura"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 17)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Dia do fechamento da fatura"
        '
        'TxtNomeTitular
        '
        Me.TxtNomeTitular.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeTitular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNomeTitular.Enabled = False
        Me.TxtNomeTitular.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeTitular.Location = New System.Drawing.Point(133, 105)
        Me.TxtNomeTitular.Name = "TxtNomeTitular"
        Me.TxtNomeTitular.Size = New System.Drawing.Size(324, 21)
        Me.TxtNomeTitular.TabIndex = 111
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(130, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 115
        Me.Label4.Text = "Nome do titular"
        '
        'TxtValidade
        '
        Me.TxtValidade.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValidade.Enabled = False
        Me.TxtValidade.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtValidade.Location = New System.Drawing.Point(14, 105)
        Me.TxtValidade.Mask = "00/00"
        Me.TxtValidade.Name = "TxtValidade"
        Me.TxtValidade.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtValidade.Size = New System.Drawing.Size(103, 21)
        Me.TxtValidade.TabIndex = 114
        Me.TxtValidade.Text = "0000"
        Me.TxtValidade.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 17)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Validade"
        '
        'TxtNumCartao
        '
        Me.TxtNumCartao.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNumCartao.Enabled = False
        Me.TxtNumCartao.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNumCartao.Location = New System.Drawing.Point(14, 50)
        Me.TxtNumCartao.Mask = "0000 0000 0000 0000"
        Me.TxtNumCartao.Name = "TxtNumCartao"
        Me.TxtNumCartao.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.TxtNumCartao.Size = New System.Drawing.Size(443, 21)
        Me.TxtNumCartao.TabIndex = 112
        Me.TxtNumCartao.Text = "0000000000000000"
        Me.TxtNumCartao.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 17)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Número do cartão"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(24, 485)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 17)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Vincular a conta"
        '
        'CmbContaVinculada
        '
        Me.CmbContaVinculada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbContaVinculada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbContaVinculada.Enabled = False
        Me.CmbContaVinculada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbContaVinculada.FormattingEnabled = True
        Me.CmbContaVinculada.Location = New System.Drawing.Point(27, 505)
        Me.CmbContaVinculada.Name = "CmbContaVinculada"
        Me.CmbContaVinculada.Size = New System.Drawing.Size(400, 23)
        Me.CmbContaVinculada.TabIndex = 112
        '
        'TxtParcelas
        '
        Me.TxtParcelas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParcelas.Enabled = False
        Me.TxtParcelas.Location = New System.Drawing.Point(27, 562)
        Me.TxtParcelas.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.TxtParcelas.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtParcelas.Name = "TxtParcelas"
        Me.TxtParcelas.Size = New System.Drawing.Size(103, 19)
        Me.TxtParcelas.TabIndex = 125
        Me.TxtParcelas.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(24, 542)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(124, 17)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Máximo de parcelas "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(196, 542)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 17)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Intervalo"
        '
        'TxtIntervalo
        '
        Me.TxtIntervalo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIntervalo.Enabled = False
        Me.TxtIntervalo.Location = New System.Drawing.Point(199, 562)
        Me.TxtIntervalo.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.TxtIntervalo.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TxtIntervalo.Name = "TxtIntervalo"
        Me.TxtIntervalo.Size = New System.Drawing.Size(103, 19)
        Me.TxtIntervalo.TabIndex = 127
        Me.TxtIntervalo.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'PnnIntervalo
        '
        Me.PnnIntervalo.Controls.Add(Me.RdbMeses)
        Me.PnnIntervalo.Controls.Add(Me.RdbDia)
        Me.PnnIntervalo.Enabled = False
        Me.PnnIntervalo.Location = New System.Drawing.Point(308, 537)
        Me.PnnIntervalo.Name = "PnnIntervalo"
        Me.PnnIntervalo.Size = New System.Drawing.Size(162, 52)
        Me.PnnIntervalo.TabIndex = 128
        '
        'RdbMeses
        '
        Me.RdbMeses.AutoSize = True
        Me.RdbMeses.Enabled = False
        Me.RdbMeses.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RdbMeses.Location = New System.Drawing.Point(81, 25)
        Me.RdbMeses.Name = "RdbMeses"
        Me.RdbMeses.Size = New System.Drawing.Size(72, 21)
        Me.RdbMeses.TabIndex = 110
        Me.RdbMeses.TabStop = True
        Me.RdbMeses.Text = "Mese(s)"
        Me.RdbMeses.UseVisualStyleBackColor = True
        '
        'RdbDia
        '
        Me.RdbDia.AutoSize = True
        Me.RdbDia.Enabled = False
        Me.RdbDia.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RdbDia.Location = New System.Drawing.Point(15, 25)
        Me.RdbDia.Name = "RdbDia"
        Me.RdbDia.Size = New System.Drawing.Size(60, 21)
        Me.RdbDia.TabIndex = 109
        Me.RdbDia.TabStop = True
        Me.RdbDia.Text = "Dia(s)"
        Me.RdbDia.UseVisualStyleBackColor = True
        '
        'BtnAddCarteira
        '
        Me.BtnAddCarteira.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BtnAddCarteira.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnAddCarteira.Enabled = False
        Me.BtnAddCarteira.FlatAppearance.BorderSize = 0
        Me.BtnAddCarteira.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddCarteira.Location = New System.Drawing.Point(446, 506)
        Me.BtnAddCarteira.Name = "BtnAddCarteira"
        Me.BtnAddCarteira.Size = New System.Drawing.Size(24, 18)
        Me.BtnAddCarteira.TabIndex = 129
        Me.BtnAddCarteira.UseVisualStyleBackColor = True
        '
        'FrmNovaFormaPgSaida
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(490, 649)
        Me.Controls.Add(Me.BtnAddCarteira)
        Me.Controls.Add(Me.PnnIntervalo)
        Me.Controls.Add(Me.TxtIntervalo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtParcelas)
        Me.Controls.Add(Me.CmbContaVinculada)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GpCartao)
        Me.Controls.Add(Me.RdbCredito)
        Me.Controls.Add(Me.RdbDebito)
        Me.Controls.Add(Me.CkCartao)
        Me.Controls.Add(Me.CkAvista)
        Me.Controls.Add(Me.TxtDescrição)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaFormaPgSaida"
        Me.Opacity = 0.98R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaFormaPgSaida"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.GpCartao.ResumeLayout(False)
        Me.GpCartao.PerformLayout()
        CType(Me.TxtDiaVencimento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDiaFechamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtParcelas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtIntervalo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnIntervalo.ResumeLayout(False)
        Me.PnnIntervalo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents CkAvista As CheckBox
    Friend WithEvents CkCartao As CheckBox
    Friend WithEvents RdbDebito As RadioButton
    Friend WithEvents RdbCredito As RadioButton
    Friend WithEvents GpCartao As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtCVV As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtDiaVencimento As NumericUpDown
    Friend WithEvents TxtDiaFechamento As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNomeTitular As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtValidade As MaskedTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNumCartao As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbBandeira As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents CmbContaVinculada As ComboBox
    Friend WithEvents TxtParcelas As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TxtIntervalo As NumericUpDown
    Friend WithEvents PnnIntervalo As Panel
    Friend WithEvents RdbMeses As RadioButton
    Friend WithEvents RdbDia As RadioButton
    Friend WithEvents BtnAddCarteira As Button
    Friend WithEvents TxtLimite As TextBox
    Friend WithEvents Label12 As Label
End Class
