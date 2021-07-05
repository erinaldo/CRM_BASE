<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnderecosEncontradosExpedicao
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
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.BttLiberarEntregador = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PnnInferior.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(800, 28)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Enderecos com produtos disponiveis"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel9)
        Me.PnnInferior.Controls.Add(Me.BttLiberarEntregador)
        Me.PnnInferior.Controls.Add(Me.Button1)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 412)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(800, 38)
        Me.PnnInferior.TabIndex = 69
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(462, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(338, 5)
        Me.Panel9.TabIndex = 27
        '
        'BttLiberarEntregador
        '
        Me.BttLiberarEntregador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttLiberarEntregador.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttLiberarEntregador.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BttLiberarEntregador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttLiberarEntregador.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BttLiberarEntregador.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttLiberarEntregador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BttLiberarEntregador.Location = New System.Drawing.Point(231, 0)
        Me.BttLiberarEntregador.Margin = New System.Windows.Forms.Padding(4)
        Me.BttLiberarEntregador.Name = "BttLiberarEntregador"
        Me.BttLiberarEntregador.Size = New System.Drawing.Size(231, 38)
        Me.BttLiberarEntregador.TabIndex = 33
        Me.BttLiberarEntregador.Text = "Validar como disponível"
        Me.BttLiberarEntregador.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.Button1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 38)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Divergencia"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmEnderecosEncontradosExpedicao
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmEnderecosEncontradosExpedicao"
        Me.Text = "FrmEnderecosEncontradosExpedicao"
        Me.PnnInferior.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel9 As Panel
    Friend WithEvents BttLiberarEntregador As Button
    Friend WithEvents Button1 As Button
End Class
