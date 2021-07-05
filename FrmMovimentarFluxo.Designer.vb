<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMovimentarFluxo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMovimentarFluxo))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.CmbContaVinculada = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblSaldoOrigem = New System.Windows.Forms.Label()
        Me.CmbContaDestino = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblSaldoConta02 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtDesconto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BttSalvarFormaDePgSaida = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttNovaConta = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SlateGray
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label4.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Location = New System.Drawing.Point(1, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(365, 32)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Movimentar contas"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel6)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BttNovaConta)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 395)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(365, 36)
        Me.PnnInferior.TabIndex = 62
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(128, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(160, 5)
        Me.Panel6.TabIndex = 27
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(81, 5)
        Me.Panel7.TabIndex = 32
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttSalvarFormaDePgSaida)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(288, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(77, 36)
        Me.Panel12.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(366, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 431)
        Me.Panel1.TabIndex = 63
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 431)
        Me.Panel2.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 17)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Caixa de origem"
        '
        'CmbContaVinculada
        '
        Me.CmbContaVinculada.Enabled = False
        Me.CmbContaVinculada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbContaVinculada.FormattingEnabled = True
        Me.CmbContaVinculada.Location = New System.Drawing.Point(17, 68)
        Me.CmbContaVinculada.Name = "CmbContaVinculada"
        Me.CmbContaVinculada.Size = New System.Drawing.Size(328, 23)
        Me.CmbContaVinculada.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Saldo"
        '
        'LblSaldoOrigem
        '
        Me.LblSaldoOrigem.AutoSize = True
        Me.LblSaldoOrigem.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblSaldoOrigem.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblSaldoOrigem.Location = New System.Drawing.Point(12, 131)
        Me.LblSaldoOrigem.Name = "LblSaldoOrigem"
        Me.LblSaldoOrigem.Size = New System.Drawing.Size(85, 29)
        Me.LblSaldoOrigem.TabIndex = 106
        Me.LblSaldoOrigem.Text = "R$ 0,00"
        '
        'CmbContaDestino
        '
        Me.CmbContaDestino.Enabled = False
        Me.CmbContaDestino.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CmbContaDestino.FormattingEnabled = True
        Me.CmbContaDestino.Location = New System.Drawing.Point(17, 205)
        Me.CmbContaDestino.Name = "CmbContaDestino"
        Me.CmbContaDestino.Size = New System.Drawing.Size(328, 23)
        Me.CmbContaDestino.TabIndex = 108
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Caixa de destino"
        '
        'LblSaldoConta02
        '
        Me.LblSaldoConta02.AutoSize = True
        Me.LblSaldoConta02.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.LblSaldoConta02.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblSaldoConta02.Location = New System.Drawing.Point(12, 269)
        Me.LblSaldoConta02.Name = "LblSaldoConta02"
        Me.LblSaldoConta02.Size = New System.Drawing.Size(85, 29)
        Me.LblSaldoConta02.TabIndex = 110
        Me.LblSaldoConta02.Text = "R$ 0,00"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 242)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 17)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Saldo "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 322)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(115, 17)
        Me.Label7.TabIndex = 111
        Me.Label7.Text = "Valor a transportar"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label8.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label8.Location = New System.Drawing.Point(4, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(340, 1)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Movimentar contas"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtDesconto
        '
        Me.TxtDesconto.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesconto.Enabled = False
        Me.TxtDesconto.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDesconto.Location = New System.Drawing.Point(17, 342)
        Me.TxtDesconto.Name = "TxtDesconto"
        Me.TxtDesconto.Size = New System.Drawing.Size(328, 21)
        Me.TxtDesconto.TabIndex = 113
        Me.TxtDesconto.Text = "R$ 0,00"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gainsboro
        Me.Label9.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label9.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Location = New System.Drawing.Point(10, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(340, 1)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Movimentar contas"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "safebox_78389.png")
        '
        'BttSalvarFormaDePgSaida
        '
        Me.BttSalvarFormaDePgSaida.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvarFormaDePgSaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvarFormaDePgSaida.Enabled = False
        Me.BttSalvarFormaDePgSaida.FlatAppearance.BorderSize = 0
        Me.BttSalvarFormaDePgSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvarFormaDePgSaida.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvarFormaDePgSaida.Name = "BttSalvarFormaDePgSaida"
        Me.BttSalvarFormaDePgSaida.Size = New System.Drawing.Size(18, 19)
        Me.BttSalvarFormaDePgSaida.TabIndex = 29
        Me.BttSalvarFormaDePgSaida.UseVisualStyleBackColor = True
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
        'BttNovaConta
        '
        Me.BttNovaConta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttNovaConta.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttNovaConta.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttNovaConta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttNovaConta.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttNovaConta.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttNovaConta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttNovaConta.ImageKey = "safebox_78389.png"
        Me.BttNovaConta.ImageList = Me.ImageList1
        Me.BttNovaConta.Location = New System.Drawing.Point(0, 0)
        Me.BttNovaConta.Name = "BttNovaConta"
        Me.BttNovaConta.Size = New System.Drawing.Size(128, 36)
        Me.BttNovaConta.TabIndex = 31
        Me.BttNovaConta.Text = "Nova conta"
        Me.BttNovaConta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BttNovaConta.UseVisualStyleBackColor = True
        '
        'FrmMovimentarFluxo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 431)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtDesconto)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblSaldoConta02)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CmbContaDestino)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblSaldoOrigem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CmbContaVinculada)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.ForeColor = System.Drawing.Color.SlateGray
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmMovimentarFluxo"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmMovimentarFluxo"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvarFormaDePgSaida As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents CmbContaVinculada As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LblSaldoOrigem As Label
    Friend WithEvents CmbContaDestino As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LblSaldoConta02 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtDesconto As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents BttNovaConta As Button
    Friend WithEvents ImageList1 As ImageList
End Class
