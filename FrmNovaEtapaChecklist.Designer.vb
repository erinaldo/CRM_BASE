<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNovaEtapaChecklist
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnnInformativo = New System.Windows.Forms.Panel()
        Me.PnnInfo = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDetalhesEtapa = New System.Windows.Forms.TextBox()
        Me.LblTituloChecklist = New System.Windows.Forms.Label()
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.RdbInteração = New System.Windows.Forms.RadioButton()
        Me.RdbPergunta = New System.Windows.Forms.RadioButton()
        Me.GpModoInteração = New System.Windows.Forms.GroupBox()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PnnInformativo.SuspendLayout()
        Me.PnnInfo.SuspendLayout()
        Me.GpModoInteração.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Location = New System.Drawing.Point(0, 403)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(447, 36)
        Me.Panel2.TabIndex = 45
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(352, 5)
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
        Me.Panel3.Location = New System.Drawing.Point(352, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(95, 36)
        Me.Panel3.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PnnInformativo)
        Me.Panel1.Controls.Add(Me.GpModoInteração)
        Me.Panel1.Controls.Add(Me.LblTituloChecklist)
        Me.Panel1.Controls.Add(Me.TxtDescrição)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(447, 514)
        Me.Panel1.TabIndex = 43
        '
        'PnnInformativo
        '
        Me.PnnInformativo.Controls.Add(Me.PnnInfo)
        Me.PnnInformativo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInformativo.Location = New System.Drawing.Point(0, 134)
        Me.PnnInformativo.Name = "PnnInformativo"
        Me.PnnInformativo.Size = New System.Drawing.Size(443, 376)
        Me.PnnInformativo.TabIndex = 49
        '
        'PnnInfo
        '
        Me.PnnInfo.Controls.Add(Me.Label4)
        Me.PnnInfo.Controls.Add(Me.TxtDetalhesEtapa)
        Me.PnnInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnInfo.Enabled = False
        Me.PnnInfo.Location = New System.Drawing.Point(0, 0)
        Me.PnnInfo.Name = "PnnInfo"
        Me.PnnInfo.Size = New System.Drawing.Size(443, 376)
        Me.PnnInfo.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label4.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Location = New System.Drawing.Point(10, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Detalhe da etapa"
        '
        'TxtDetalhesEtapa
        '
        Me.TxtDetalhesEtapa.Location = New System.Drawing.Point(123, 12)
        Me.TxtDetalhesEtapa.Multiline = True
        Me.TxtDetalhesEtapa.Name = "TxtDetalhesEtapa"
        Me.TxtDetalhesEtapa.Size = New System.Drawing.Size(310, 217)
        Me.TxtDetalhesEtapa.TabIndex = 47
        '
        'LblTituloChecklist
        '
        Me.LblTituloChecklist.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.LblTituloChecklist.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloChecklist.Font = New System.Drawing.Font("Calibri", 8.0!)
        Me.LblTituloChecklist.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTituloChecklist.Location = New System.Drawing.Point(0, 0)
        Me.LblTituloChecklist.Name = "LblTituloChecklist"
        Me.LblTituloChecklist.Size = New System.Drawing.Size(443, 28)
        Me.LblTituloChecklist.TabIndex = 39
        Me.LblTituloChecklist.Text = "Cadastro de nova categoria para o checklist"
        Me.LblTituloChecklist.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtDescrição
        '
        Me.TxtDescrição.Location = New System.Drawing.Point(125, 41)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(310, 21)
        Me.TxtDescrição.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(8, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Titulo da etapa "
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(443, 510)
        Me.TreeView1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(447, 28)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Cadastro de novo Processo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'RdbInteração
        '
        Me.RdbInteração.AutoSize = True
        Me.RdbInteração.Location = New System.Drawing.Point(6, 28)
        Me.RdbInteração.Name = "RdbInteração"
        Me.RdbInteração.Size = New System.Drawing.Size(79, 17)
        Me.RdbInteração.TabIndex = 0
        Me.RdbInteração.Text = "Informativo"
        Me.RdbInteração.UseVisualStyleBackColor = True
        '
        'RdbPergunta
        '
        Me.RdbPergunta.AutoSize = True
        Me.RdbPergunta.Location = New System.Drawing.Point(112, 28)
        Me.RdbPergunta.Name = "RdbPergunta"
        Me.RdbPergunta.Size = New System.Drawing.Size(120, 17)
        Me.RdbPergunta.TabIndex = 1
        Me.RdbPergunta.Text = "Pergunta e resposta"
        Me.RdbPergunta.UseVisualStyleBackColor = True
        '
        'GpModoInteração
        '
        Me.GpModoInteração.Controls.Add(Me.RdbPergunta)
        Me.GpModoInteração.Controls.Add(Me.RdbInteração)
        Me.GpModoInteração.Enabled = False
        Me.GpModoInteração.Location = New System.Drawing.Point(11, 68)
        Me.GpModoInteração.Name = "GpModoInteração"
        Me.GpModoInteração.Size = New System.Drawing.Size(469, 60)
        Me.GpModoInteração.TabIndex = 48
        Me.GpModoInteração.TabStop = False
        Me.GpModoInteração.Text = "Modo de interação"
        '
        'FrmNovaEtapaChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 439)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmNovaEtapaChecklist"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmNovaEtapaChecklist"
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PnnInformativo.ResumeLayout(False)
        Me.PnnInfo.ResumeLayout(False)
        Me.PnnInfo.PerformLayout()
        Me.GpModoInteração.ResumeLayout(False)
        Me.GpModoInteração.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LblTituloChecklist As Label
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInformativo As Panel
    Friend WithEvents PnnInfo As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtDetalhesEtapa As TextBox
    Friend WithEvents GpModoInteração As GroupBox
    Friend WithEvents RdbPergunta As RadioButton
    Friend WithEvents RdbInteração As RadioButton
End Class
