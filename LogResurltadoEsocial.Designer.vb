<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogResurltadoEsocial
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
        Me.LblResult = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LblResult
        '
        Me.LblResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LblResult.Location = New System.Drawing.Point(0, 0)
        Me.LblResult.Name = "LblResult"
        Me.LblResult.Size = New System.Drawing.Size(800, 450)
        Me.LblResult.TabIndex = 0
        Me.LblResult.Text = "Label1"
        '
        'LogResurltadoEsocial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.LblResult)
        Me.Name = "LogResurltadoEsocial"
        Me.Text = "LogResurltadoEsocial"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblResult As Label
End Class
