<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmModeloVeiculo
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
        Me.TxtDescrição = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblCaption = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.TxtDescrição)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.LblCaption)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(1, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(324, 88)
        Me.Panel1.TabIndex = 17
        '
        'TxtDescrição
        '
        Me.TxtDescrição.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescrição.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.TxtDescrição.Location = New System.Drawing.Point(84, 54)
        Me.TxtDescrição.Name = "TxtDescrição"
        Me.TxtDescrição.Size = New System.Drawing.Size(227, 17)
        Me.TxtDescrição.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição"
        '
        'LblCaption
        '
        Me.LblCaption.BackColor = System.Drawing.Color.LightSlateGray
        Me.LblCaption.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblCaption.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.LblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblCaption.Location = New System.Drawing.Point(0, 0)
        Me.LblCaption.Name = "LblCaption"
        Me.LblCaption.Size = New System.Drawing.Size(324, 31)
        Me.LblCaption.TabIndex = 0
        Me.LblCaption.Text = "Novo modelo de veículo"
        Me.LblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SlateGray
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(1, 95)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(324, 36)
        Me.Panel3.TabIndex = 19
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(229, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SlateGray
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.BttSalvar)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(229, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(95, 36)
        Me.Panel5.TabIndex = 26
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(60, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 26
        Me.Button1.UseVisualStyleBackColor = True
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 130)
        Me.Panel2.TabIndex = 20
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(325, 1)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1, 130)
        Me.Panel6.TabIndex = 21
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(326, 1)
        Me.Panel7.TabIndex = 22
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 131)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(326, 1)
        Me.Panel8.TabIndex = 23
        '
        'FrmModeloVeiculo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 132)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel8)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmModeloVeiculo"
        Me.Opacity = 0.97R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmModeloVeiculo"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TxtDescrição As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents LblCaption As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
End Class
