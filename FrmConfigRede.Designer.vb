<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConfigRede
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblRespostaPorta = New System.Windows.Forms.Label()
        Me.LblRespostas = New System.Windows.Forms.Label()
        Me.LblConexão = New System.Windows.Forms.Label()
        Me.CkInstanciaPadrão = New System.Windows.Forms.CheckBox()
        Me.CkPortaPadrão = New System.Windows.Forms.CheckBox()
        Me.CkEsteComputador = New System.Windows.Forms.CheckBox()
        Me.TxtNomeInstancia = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPortaSQL = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtIp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 331)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(508, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 331)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(1, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(507, 1)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(1, 330)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(507, 1)
        Me.Panel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(507, 31)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Configurações"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblRespostaPorta
        '
        Me.LblRespostaPorta.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRespostaPorta.Location = New System.Drawing.Point(31, 195)
        Me.LblRespostaPorta.Name = "LblRespostaPorta"
        Me.LblRespostaPorta.Size = New System.Drawing.Size(432, 13)
        Me.LblRespostaPorta.TabIndex = 213
        '
        'LblRespostas
        '
        Me.LblRespostas.ForeColor = System.Drawing.Color.SlateGray
        Me.LblRespostas.Location = New System.Drawing.Point(31, 129)
        Me.LblRespostas.Name = "LblRespostas"
        Me.LblRespostas.Size = New System.Drawing.Size(432, 13)
        Me.LblRespostas.TabIndex = 212
        '
        'LblConexão
        '
        Me.LblConexão.ForeColor = System.Drawing.Color.SlateGray
        Me.LblConexão.Location = New System.Drawing.Point(31, 258)
        Me.LblConexão.Name = "LblConexão"
        Me.LblConexão.Size = New System.Drawing.Size(429, 23)
        Me.LblConexão.TabIndex = 211
        '
        'CkInstanciaPadrão
        '
        Me.CkInstanciaPadrão.AutoSize = True
        Me.CkInstanciaPadrão.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkInstanciaPadrão.Location = New System.Drawing.Point(360, 238)
        Me.CkInstanciaPadrão.Name = "CkInstanciaPadrão"
        Me.CkInstanciaPadrão.Size = New System.Drawing.Size(108, 17)
        Me.CkInstanciaPadrão.TabIndex = 210
        Me.CkInstanciaPadrão.Text = "Instâncias padrão"
        Me.CkInstanciaPadrão.UseVisualStyleBackColor = True
        '
        'CkPortaPadrão
        '
        Me.CkPortaPadrão.AutoSize = True
        Me.CkPortaPadrão.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkPortaPadrão.Location = New System.Drawing.Point(360, 175)
        Me.CkPortaPadrão.Name = "CkPortaPadrão"
        Me.CkPortaPadrão.Size = New System.Drawing.Size(85, 17)
        Me.CkPortaPadrão.TabIndex = 209
        Me.CkPortaPadrão.Text = "Porta padrão"
        Me.CkPortaPadrão.UseVisualStyleBackColor = True
        '
        'CkEsteComputador
        '
        Me.CkEsteComputador.AutoSize = True
        Me.CkEsteComputador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CkEsteComputador.Location = New System.Drawing.Point(360, 109)
        Me.CkEsteComputador.Name = "CkEsteComputador"
        Me.CkEsteComputador.Size = New System.Drawing.Size(103, 17)
        Me.CkEsteComputador.TabIndex = 208
        Me.CkEsteComputador.Text = "Este computador"
        Me.CkEsteComputador.UseVisualStyleBackColor = True
        '
        'TxtNomeInstancia
        '
        Me.TxtNomeInstancia.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNomeInstancia.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtNomeInstancia.Location = New System.Drawing.Point(34, 238)
        Me.TxtNomeInstancia.Name = "TxtNomeInstancia"
        Me.TxtNomeInstancia.Size = New System.Drawing.Size(319, 17)
        Me.TxtNomeInstancia.TabIndex = 207
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(31, 222)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 13)
        Me.Label3.TabIndex = 206
        Me.Label3.Text = "Nome da instância do SQL"
        '
        'TxtPortaSQL
        '
        Me.TxtPortaSQL.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPortaSQL.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtPortaSQL.Location = New System.Drawing.Point(34, 175)
        Me.TxtPortaSQL.Name = "TxtPortaSQL"
        Me.TxtPortaSQL.Size = New System.Drawing.Size(319, 17)
        Me.TxtPortaSQL.TabIndex = 205
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(31, 159)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(207, 13)
        Me.Label12.TabIndex = 204
        Me.Label12.Text = "Informe a porta de conexão com o servidor"
        '
        'TxtIp
        '
        Me.TxtIp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIp.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtIp.Location = New System.Drawing.Point(34, 109)
        Me.TxtIp.Name = "TxtIp"
        Me.TxtIp.Size = New System.Drawing.Size(319, 17)
        Me.TxtIp.TabIndex = 203
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(195, 13)
        Me.Label7.TabIndex = 202
        Me.Label7.Text = "Informe o IP do servidor de hospedagem"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(12, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(485, 21)
        Me.Label2.TabIndex = 201
        Me.Label2.Text = "Dados do acesso local"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 292)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(507, 38)
        Me.PnnInferior.TabIndex = 214
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(410, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(410, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(97, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(59, 8)
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
        Me.BttSalvar.Location = New System.Drawing.Point(18, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'FrmConfigRede
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(509, 331)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblRespostaPorta)
        Me.Controls.Add(Me.LblRespostas)
        Me.Controls.Add(Me.LblConexão)
        Me.Controls.Add(Me.CkInstanciaPadrão)
        Me.Controls.Add(Me.CkPortaPadrão)
        Me.Controls.Add(Me.CkEsteComputador)
        Me.Controls.Add(Me.TxtNomeInstancia)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPortaSQL)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtIp)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmConfigRede"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmConfigRede"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents LblRespostaPorta As Label
    Friend WithEvents LblRespostas As Label
    Friend WithEvents LblConexão As Label
    Friend WithEvents CkInstanciaPadrão As CheckBox
    Friend WithEvents CkPortaPadrão As CheckBox
    Friend WithEvents CkEsteComputador As CheckBox
    Friend WithEvents TxtNomeInstancia As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPortaSQL As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtIp As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
End Class
