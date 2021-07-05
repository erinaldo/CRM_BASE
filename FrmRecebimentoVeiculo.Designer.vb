<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRecebimentoVeiculo
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GpComplementar = New System.Windows.Forms.GroupBox()
        Me.PnnSeguradoraSegurado = New System.Windows.Forms.Panel()
        Me.PicLogo = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GpVeículo = New System.Windows.Forms.GroupBox()
        Me.LblAno = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LblVersão = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.LblModelo = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LblFabricante = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.LblChassi = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.LblRenavan = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LblPaís = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LblEstado = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblCidade = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LblBairro = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblCep = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblEndereço = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblNomeCompleto = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCPF = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.GpComplementar.SuspendLayout()
        Me.PnnSeguradoraSegurado.SuspendLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GpVeículo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GpComplementar)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GpVeículo)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 425)
        Me.Panel1.TabIndex = 1
        '
        'GpComplementar
        '
        Me.GpComplementar.Controls.Add(Me.PnnSeguradoraSegurado)
        Me.GpComplementar.Location = New System.Drawing.Point(12, 418)
        Me.GpComplementar.Name = "GpComplementar"
        Me.GpComplementar.Size = New System.Drawing.Size(776, 124)
        Me.GpComplementar.TabIndex = 5
        Me.GpComplementar.TabStop = False
        Me.GpComplementar.Text = "Informações complementares"
        Me.GpComplementar.Visible = False
        '
        'PnnSeguradoraSegurado
        '
        Me.PnnSeguradoraSegurado.Controls.Add(Me.PicLogo)
        Me.PnnSeguradoraSegurado.Controls.Add(Me.Label12)
        Me.PnnSeguradoraSegurado.Controls.Add(Me.Label9)
        Me.PnnSeguradoraSegurado.Controls.Add(Me.Label4)
        Me.PnnSeguradoraSegurado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnSeguradoraSegurado.Location = New System.Drawing.Point(3, 17)
        Me.PnnSeguradoraSegurado.Name = "PnnSeguradoraSegurado"
        Me.PnnSeguradoraSegurado.Size = New System.Drawing.Size(770, 104)
        Me.PnnSeguradoraSegurado.TabIndex = 0
        Me.PnnSeguradoraSegurado.Visible = False
        '
        'PicLogo
        '
        Me.PicLogo.Dock = System.Windows.Forms.DockStyle.Right
        Me.PicLogo.Location = New System.Drawing.Point(459, 0)
        Me.PicLogo.Name = "PicLogo"
        Me.PicLogo.Size = New System.Drawing.Size(311, 104)
        Me.PicLogo.TabIndex = 46
        Me.PicLogo.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 44
        Me.Label12.Text = "Nº Sinistro"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(3, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Franquia"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Seguradora"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Location = New System.Drawing.Point(9, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(589, 54)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Tipo de cobertura"
        '
        'GpVeículo
        '
        Me.GpVeículo.Controls.Add(Me.LblAno)
        Me.GpVeículo.Controls.Add(Me.Label13)
        Me.GpVeículo.Controls.Add(Me.LblVersão)
        Me.GpVeículo.Controls.Add(Me.Label19)
        Me.GpVeículo.Controls.Add(Me.LblModelo)
        Me.GpVeículo.Controls.Add(Me.Label16)
        Me.GpVeículo.Controls.Add(Me.LblFabricante)
        Me.GpVeículo.Controls.Add(Me.Label18)
        Me.GpVeículo.Controls.Add(Me.LblChassi)
        Me.GpVeículo.Controls.Add(Me.Label22)
        Me.GpVeículo.Controls.Add(Me.LblRenavan)
        Me.GpVeículo.Controls.Add(Me.Label24)
        Me.GpVeículo.Controls.Add(Me.Label25)
        Me.GpVeículo.Location = New System.Drawing.Point(9, 244)
        Me.GpVeículo.Name = "GpVeículo"
        Me.GpVeículo.Size = New System.Drawing.Size(776, 136)
        Me.GpVeículo.TabIndex = 3
        Me.GpVeículo.TabStop = False
        Me.GpVeículo.Text = "Dados do veículo"
        '
        'LblAno
        '
        Me.LblAno.AutoSize = True
        Me.LblAno.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblAno.Location = New System.Drawing.Point(595, 78)
        Me.LblAno.Name = "LblAno"
        Me.LblAno.Size = New System.Drawing.Size(9, 13)
        Me.LblAno.TabIndex = 29
        Me.LblAno.Text = " "
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(550, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Ano"
        '
        'LblVersão
        '
        Me.LblVersão.AutoSize = True
        Me.LblVersão.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblVersão.Location = New System.Drawing.Point(595, 104)
        Me.LblVersão.Name = "LblVersão"
        Me.LblVersão.Size = New System.Drawing.Size(9, 13)
        Me.LblVersão.TabIndex = 27
        Me.LblVersão.Text = " "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(550, 104)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Versão"
        '
        'LblModelo
        '
        Me.LblModelo.AutoSize = True
        Me.LblModelo.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblModelo.Location = New System.Drawing.Point(375, 104)
        Me.LblModelo.Name = "LblModelo"
        Me.LblModelo.Size = New System.Drawing.Size(9, 13)
        Me.LblModelo.TabIndex = 12
        Me.LblModelo.Text = " "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(313, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 11
        Me.Label16.Text = "Modelo"
        '
        'LblFabricante
        '
        Me.LblFabricante.AutoSize = True
        Me.LblFabricante.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblFabricante.Location = New System.Drawing.Point(94, 104)
        Me.LblFabricante.Name = "LblFabricante"
        Me.LblFabricante.Size = New System.Drawing.Size(9, 13)
        Me.LblFabricante.TabIndex = 10
        Me.LblFabricante.Text = " "
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 104)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(58, 13)
        Me.Label18.TabIndex = 9
        Me.Label18.Text = "Fabricante"
        '
        'LblChassi
        '
        Me.LblChassi.AutoSize = True
        Me.LblChassi.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblChassi.Location = New System.Drawing.Point(94, 78)
        Me.LblChassi.Name = "LblChassi"
        Me.LblChassi.Size = New System.Drawing.Size(9, 13)
        Me.LblChassi.TabIndex = 6
        Me.LblChassi.Text = " "
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 78)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(38, 13)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "Chassi"
        '
        'LblRenavan
        '
        Me.LblRenavan.AutoSize = True
        Me.LblRenavan.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblRenavan.Location = New System.Drawing.Point(94, 53)
        Me.LblRenavan.Name = "LblRenavan"
        Me.LblRenavan.Size = New System.Drawing.Size(9, 13)
        Me.LblRenavan.TabIndex = 4
        Me.LblRenavan.Text = " "
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(6, 53)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(49, 13)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "RENAVAN"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 26)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(33, 13)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Placa"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LblCPF)
        Me.GroupBox1.Controls.Add(Me.LblPaís)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.LblEstado)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.LblCidade)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.LblBairro)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.LblCep)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.LblEndereço)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LblNomeCompleto)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 76)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 162)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dados do cliente"
        '
        'LblPaís
        '
        Me.LblPaís.AutoSize = True
        Me.LblPaís.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblPaís.Location = New System.Drawing.Point(379, 130)
        Me.LblPaís.Name = "LblPaís"
        Me.LblPaís.Size = New System.Drawing.Size(9, 13)
        Me.LblPaís.TabIndex = 16
        Me.LblPaís.Text = " "
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(313, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 15
        Me.Label11.Text = "País"
        '
        'LblEstado
        '
        Me.LblEstado.AutoSize = True
        Me.LblEstado.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblEstado.Location = New System.Drawing.Point(94, 130)
        Me.LblEstado.Name = "LblEstado"
        Me.LblEstado.Size = New System.Drawing.Size(9, 13)
        Me.LblEstado.TabIndex = 14
        Me.LblEstado.Text = " "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 130)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Estado"
        '
        'LblCidade
        '
        Me.LblCidade.AutoSize = True
        Me.LblCidade.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblCidade.Location = New System.Drawing.Point(476, 104)
        Me.LblCidade.Name = "LblCidade"
        Me.LblCidade.Size = New System.Drawing.Size(9, 13)
        Me.LblCidade.TabIndex = 12
        Me.LblCidade.Text = " "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(414, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Cidade"
        '
        'LblBairro
        '
        Me.LblBairro.AutoSize = True
        Me.LblBairro.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblBairro.Location = New System.Drawing.Point(94, 104)
        Me.LblBairro.Name = "LblBairro"
        Me.LblBairro.Size = New System.Drawing.Size(9, 13)
        Me.LblBairro.TabIndex = 10
        Me.LblBairro.Text = " "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Bairro"
        '
        'LblCep
        '
        Me.LblCep.AutoSize = True
        Me.LblCep.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblCep.Location = New System.Drawing.Point(593, 78)
        Me.LblCep.Name = "LblCep"
        Me.LblCep.Size = New System.Drawing.Size(9, 13)
        Me.LblCep.TabIndex = 8
        Me.LblCep.Text = " "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(550, 78)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "CEP"
        '
        'LblEndereço
        '
        Me.LblEndereço.AutoSize = True
        Me.LblEndereço.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblEndereço.Location = New System.Drawing.Point(94, 78)
        Me.LblEndereço.Name = "LblEndereço"
        Me.LblEndereço.Size = New System.Drawing.Size(9, 13)
        Me.LblEndereço.TabIndex = 6
        Me.LblEndereço.Text = " "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Endereço"
        '
        'LblNomeCompleto
        '
        Me.LblNomeCompleto.AutoSize = True
        Me.LblNomeCompleto.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblNomeCompleto.Location = New System.Drawing.Point(94, 53)
        Me.LblNomeCompleto.Name = "LblNomeCompleto"
        Me.LblNomeCompleto.Size = New System.Drawing.Size(9, 13)
        Me.LblNomeCompleto.TabIndex = 4
        Me.LblNomeCompleto.Text = " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Nome completo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "CPF"
        '
        'LblCPF
        '
        Me.LblCPF.AutoSize = True
        Me.LblCPF.ForeColor = System.Drawing.Color.LightSlateGray
        Me.LblCPF.Location = New System.Drawing.Point(94, 26)
        Me.LblCPF.Name = "LblCPF"
        Me.LblCPF.Size = New System.Drawing.Size(33, 13)
        Me.LblCPF.TabIndex = 17
        Me.LblCPF.Text = " 4444"
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label14.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.Label14.ForeColor = System.Drawing.Color.LightSlateGray
        Me.Label14.Location = New System.Drawing.Point(3, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(583, 34)
        Me.Label14.TabIndex = 18
        Me.Label14.Text = " 4444"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(800, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Recebimento do veículo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Location = New System.Drawing.Point(607, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(178, 54)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Processo Nº"
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label15.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.Label15.ForeColor = System.Drawing.Color.LightSlateGray
        Me.Label15.Location = New System.Drawing.Point(3, 17)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(172, 34)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = " 4444"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmRecebimentoVeiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 725)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmRecebimentoVeiculo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmRecebimentoVeiculo"
        Me.Panel1.ResumeLayout(False)
        Me.GpComplementar.ResumeLayout(False)
        Me.PnnSeguradoraSegurado.ResumeLayout(False)
        Me.PnnSeguradoraSegurado.PerformLayout()
        CType(Me.PicLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GpVeículo.ResumeLayout(False)
        Me.GpVeículo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GpComplementar As GroupBox
    Friend WithEvents PnnSeguradoraSegurado As Panel
    Friend WithEvents PicLogo As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GpVeículo As GroupBox
    Friend WithEvents LblAno As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblVersão As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents LblModelo As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LblFabricante As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents LblChassi As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents LblRenavan As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LblPaís As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents LblEstado As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents LblCidade As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents LblBairro As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblCep As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblEndereço As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblNomeCompleto As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents LblCPF As Label
    Friend WithEvents Label1 As Label
End Class
