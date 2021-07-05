<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBemVindo
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
        Me.Pnn1 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnConcluir = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BttRemover = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Pnn1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnn1
        '
        Me.Pnn1.Controls.Add(Me.Label11)
        Me.Pnn1.Controls.Add(Me.Label10)
        Me.Pnn1.Controls.Add(Me.Label9)
        Me.Pnn1.Controls.Add(Me.Label8)
        Me.Pnn1.Controls.Add(Me.Label5)
        Me.Pnn1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pnn1.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Pnn1.Location = New System.Drawing.Point(397, 1)
        Me.Pnn1.Name = "Pnn1"
        Me.Pnn1.Size = New System.Drawing.Size(632, 491)
        Me.Pnn1.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label11.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Location = New System.Drawing.Point(0, 385)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(632, 109)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Ainda não existem cargos cadastrados. Para inserirmos um novo usuario, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "é necess" &
    "ario que você me informe qual função ele ira desempenhar."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(0, 295)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(632, 90)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Lembre-se, o primeiro usuário não possui restrições para criar outros perfis," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ma" &
    "ntenha esta senha segura."
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label9.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Location = New System.Drawing.Point(0, 205)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(632, 90)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Percebi que que este e a primeira vez que meu banco de dados e executado," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "no pas" &
    "so seguinte, iremos realizar o primeiro cadastro de usuário."
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!)
        Me.Label8.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label8.Location = New System.Drawing.Point(0, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(632, 90)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Bem vindo ao assistente de recursos da " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Interface Autônoma de Redirecionamento e" &
    " Análises, I.A.R.A."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Calibri", 14.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(632, 115)
        Me.Label5.TabIndex = 46
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.BtnConcluir)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(397, 492)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(632, 37)
        Me.Panel5.TabIndex = 7
        '
        'BtnConcluir
        '
        Me.BtnConcluir.BackColor = System.Drawing.Color.SlateGray
        Me.BtnConcluir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnConcluir.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnConcluir.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.BtnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConcluir.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.BtnConcluir.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnConcluir.Location = New System.Drawing.Point(525, 0)
        Me.BtnConcluir.Name = "BtnConcluir"
        Me.BtnConcluir.Size = New System.Drawing.Size(107, 37)
        Me.BtnConcluir.TabIndex = 33
        Me.BtnConcluir.Text = "Ok"
        Me.BtnConcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnConcluir.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1029, 1)
        Me.Panel4.TabIndex = 8
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Panel6.Location = New System.Drawing.Point(0, 529)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1029, 1)
        Me.Panel6.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.LogoIaraTrsnp
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(397, 528)
        Me.Panel1.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.BttRemover)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(397, 106)
        Me.Panel3.TabIndex = 4
        '
        'BttRemover
        '
        Me.BttRemover.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Cancel_40972
        Me.BttRemover.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttRemover.FlatAppearance.BorderSize = 0
        Me.BttRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttRemover.Location = New System.Drawing.Point(12, 12)
        Me.BttRemover.Name = "BttRemover"
        Me.BttRemover.Size = New System.Drawing.Size(20, 20)
        Me.BttRemover.TabIndex = 31
        Me.BttRemover.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label1.ForeColor = System.Drawing.Color.SlateGray
        Me.Label1.Location = New System.Drawing.Point(78, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 50)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "I"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label4.ForeColor = System.Drawing.Color.SlateGray
        Me.Label4.Location = New System.Drawing.Point(78, 324)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 50)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "A"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label2.ForeColor = System.Drawing.Color.SlateGray
        Me.Label2.Location = New System.Drawing.Point(78, 183)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 50)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "A"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Calibri", 24.0!)
        Me.Label3.ForeColor = System.Drawing.Color.SlateGray
        Me.Label3.Location = New System.Drawing.Point(78, 256)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 50)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "R"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 388)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(397, 140)
        Me.Panel2.TabIndex = 1
        '
        'FrmBemVindo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 530)
        Me.Controls.Add(Me.Pnn1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmBemVindo"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmBemVindo"
        Me.Pnn1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BttRemover As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Pnn1 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnConcluir As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel6 As Panel
End Class
