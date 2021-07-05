<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInteraçãoChecklist
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LblTituloChecklist = New System.Windows.Forms.Label()
        Me.PnnInteração = New System.Windows.Forms.Panel()
        Me.PnnTexto = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LblTituloPnnInteração = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.LblTituloCategoria = New System.Windows.Forms.Label()
        Me.LblTituloProcesso = New System.Windows.Forms.Label()
        Me.LblTituloDaEtapa = New System.Windows.Forms.Label()
        Me.PnnInformação = New System.Windows.Forms.Panel()
        Me.LblInteração = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.PnnInteração.SuspendLayout()
        Me.PnnTexto.SuspendLayout()
        Me.PnnInformação.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PnnInteração)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 112)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 386)
        Me.Panel1.TabIndex = 37
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 498)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(802, 36)
        Me.Panel2.TabIndex = 38
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(710, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Button1)
        Me.Panel3.Controls.Add(Me.Button2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(710, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(92, 36)
        Me.Panel3.TabIndex = 26
        '
        'LblTituloChecklist
        '
        Me.LblTituloChecklist.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblTituloChecklist.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloChecklist.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTituloChecklist.ForeColor = System.Drawing.Color.SeaShell
        Me.LblTituloChecklist.Location = New System.Drawing.Point(0, 0)
        Me.LblTituloChecklist.Name = "LblTituloChecklist"
        Me.LblTituloChecklist.Size = New System.Drawing.Size(802, 28)
        Me.LblTituloChecklist.TabIndex = 36
        Me.LblTituloChecklist.Text = "Titulo do checklist: "
        Me.LblTituloChecklist.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInteração
        '
        Me.PnnInteração.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnnInteração.Controls.Add(Me.PnnInformação)
        Me.PnnInteração.Controls.Add(Me.PnnTexto)
        Me.PnnInteração.Controls.Add(Me.LblTituloPnnInteração)
        Me.PnnInteração.Controls.Add(Me.Label11)
        Me.PnnInteração.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnInteração.Location = New System.Drawing.Point(0, 0)
        Me.PnnInteração.Name = "PnnInteração"
        Me.PnnInteração.Size = New System.Drawing.Size(798, 382)
        Me.PnnInteração.TabIndex = 30
        '
        'PnnTexto
        '
        Me.PnnTexto.Controls.Add(Me.TreeView1)
        Me.PnnTexto.Controls.Add(Me.Label10)
        Me.PnnTexto.Controls.Add(Me.Label9)
        Me.PnnTexto.Controls.Add(Me.TextBox1)
        Me.PnnTexto.Location = New System.Drawing.Point(0, 50)
        Me.PnnTexto.Name = "PnnTexto"
        Me.PnnTexto.Size = New System.Drawing.Size(64, 44)
        Me.PnnTexto.TabIndex = 28
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(126, 102)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(653, 181)
        Me.TreeView1.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Imagens"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Resposta por escrito"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(126, 18)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(653, 78)
        Me.TextBox1.TabIndex = 0
        '
        'LblTituloPnnInteração
        '
        Me.LblTituloPnnInteração.BackColor = System.Drawing.Color.Gainsboro
        Me.LblTituloPnnInteração.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloPnnInteração.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.LblTituloPnnInteração.ForeColor = System.Drawing.Color.SlateGray
        Me.LblTituloPnnInteração.Location = New System.Drawing.Point(0, 0)
        Me.LblTituloPnnInteração.Name = "LblTituloPnnInteração"
        Me.LblTituloPnnInteração.Size = New System.Drawing.Size(794, 50)
        Me.LblTituloPnnInteração.TabIndex = 24
        Me.LblTituloPnnInteração.Text = "Pergunta da etapa"
        Me.LblTituloPnnInteração.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Gainsboro
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.Label11.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(794, 378)
        Me.Label11.TabIndex = 26
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.arrow_left_16743
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(16, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 29
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.arrow_right_16742
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(57, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'LblTituloCategoria
        '
        Me.LblTituloCategoria.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.LblTituloCategoria.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloCategoria.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTituloCategoria.ForeColor = System.Drawing.Color.SeaShell
        Me.LblTituloCategoria.Location = New System.Drawing.Point(0, 28)
        Me.LblTituloCategoria.Name = "LblTituloCategoria"
        Me.LblTituloCategoria.Size = New System.Drawing.Size(802, 28)
        Me.LblTituloCategoria.TabIndex = 44
        Me.LblTituloCategoria.Text = "Titulo da categoria: "
        Me.LblTituloCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTituloProcesso
        '
        Me.LblTituloProcesso.BackColor = System.Drawing.Color.DarkSlateGray
        Me.LblTituloProcesso.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloProcesso.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTituloProcesso.ForeColor = System.Drawing.Color.SeaShell
        Me.LblTituloProcesso.Location = New System.Drawing.Point(0, 56)
        Me.LblTituloProcesso.Name = "LblTituloProcesso"
        Me.LblTituloProcesso.Size = New System.Drawing.Size(802, 28)
        Me.LblTituloProcesso.TabIndex = 43
        Me.LblTituloProcesso.Text = "Titulo do processo definido:"
        Me.LblTituloProcesso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTituloDaEtapa
        '
        Me.LblTituloDaEtapa.BackColor = System.Drawing.Color.DarkGoldenrod
        Me.LblTituloDaEtapa.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTituloDaEtapa.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTituloDaEtapa.ForeColor = System.Drawing.Color.SeaShell
        Me.LblTituloDaEtapa.Location = New System.Drawing.Point(0, 84)
        Me.LblTituloDaEtapa.Name = "LblTituloDaEtapa"
        Me.LblTituloDaEtapa.Size = New System.Drawing.Size(802, 28)
        Me.LblTituloDaEtapa.TabIndex = 42
        Me.LblTituloDaEtapa.Text = "Titulo da etapa do processo:"
        Me.LblTituloDaEtapa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PnnInformação
        '
        Me.PnnInformação.Controls.Add(Me.LblInteração)
        Me.PnnInformação.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnnInformação.Location = New System.Drawing.Point(0, 50)
        Me.PnnInformação.Name = "PnnInformação"
        Me.PnnInformação.Size = New System.Drawing.Size(794, 328)
        Me.PnnInformação.TabIndex = 29
        '
        'LblInteração
        '
        Me.LblInteração.BackColor = System.Drawing.Color.WhiteSmoke
        Me.LblInteração.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblInteração.Font = New System.Drawing.Font("Calibri", 14.25!)
        Me.LblInteração.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.LblInteração.Location = New System.Drawing.Point(0, 0)
        Me.LblInteração.Name = "LblInteração"
        Me.LblInteração.Size = New System.Drawing.Size(794, 328)
        Me.LblInteração.TabIndex = 25
        Me.LblInteração.Text = "Pergunta da etapa"
        Me.LblInteração.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmInteraçãoChecklist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 534)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.LblTituloDaEtapa)
        Me.Controls.Add(Me.LblTituloProcesso)
        Me.Controls.Add(Me.LblTituloCategoria)
        Me.Controls.Add(Me.LblTituloChecklist)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmInteraçãoChecklist"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmInteraçãoChecklist"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.PnnInteração.ResumeLayout(False)
        Me.PnnTexto.ResumeLayout(False)
        Me.PnnTexto.PerformLayout()
        Me.PnnInformação.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LblTituloChecklist As Label
    Friend WithEvents PnnInteração As Panel
    Friend WithEvents PnnTexto As Panel
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LblTituloPnnInteração As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents LblTituloCategoria As Label
    Friend WithEvents LblTituloProcesso As Label
    Friend WithEvents LblTituloDaEtapa As Label
    Friend WithEvents PnnInformação As Panel
    Friend WithEvents LblInteração As Label
End Class
