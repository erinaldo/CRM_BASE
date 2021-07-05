<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQuadro
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TrQuadro = New System.Windows.Forms.TreeView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PicHierarquia = New System.Windows.Forms.PictureBox()
        Me.BttAdd = New System.Windows.Forms.Button()
        Me.BttEdit = New System.Windows.Forms.Button()
        Me.BttBlock = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PicHierarquia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PicHierarquia)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1104, 501)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quadro geral"
        '
        'TrQuadro
        '
        Me.TrQuadro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TrQuadro.Location = New System.Drawing.Point(0, 0)
        Me.TrQuadro.Name = "TrQuadro"
        Me.TrQuadro.Size = New System.Drawing.Size(271, 482)
        Me.TrQuadro.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TrQuadro)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(271, 482)
        Me.Panel1.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.BttAdd)
        Me.Panel2.Controls.Add(Me.BttEdit)
        Me.Panel2.Controls.Add(Me.BttBlock)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(274, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(827, 37)
        Me.Panel2.TabIndex = 6
        '
        'PicHierarquia
        '
        Me.PicHierarquia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PicHierarquia.Location = New System.Drawing.Point(274, 53)
        Me.PicHierarquia.Name = "PicHierarquia"
        Me.PicHierarquia.Size = New System.Drawing.Size(827, 445)
        Me.PicHierarquia.TabIndex = 7
        Me.PicHierarquia.TabStop = False
        '
        'BttAdd
        '
        Me.BttAdd.BackgroundImage = Global.CRM_BASE.My.Resources.Resources._1486564412_plus_81511
        Me.BttAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAdd.FlatAppearance.BorderSize = 0
        Me.BttAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAdd.Location = New System.Drawing.Point(3, 3)
        Me.BttAdd.Name = "BttAdd"
        Me.BttAdd.Size = New System.Drawing.Size(30, 30)
        Me.BttAdd.TabIndex = 4
        Me.BttAdd.UseVisualStyleBackColor = True
        '
        'BttEdit
        '
        Me.BttEdit.BackgroundImage = Global.CRM_BASE.My.Resources.Resources._1486564394_edit_81508
        Me.BttEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttEdit.FlatAppearance.BorderSize = 0
        Me.BttEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttEdit.Location = New System.Drawing.Point(39, 3)
        Me.BttEdit.Name = "BttEdit"
        Me.BttEdit.Size = New System.Drawing.Size(30, 30)
        Me.BttEdit.TabIndex = 5
        Me.BttEdit.UseVisualStyleBackColor = True
        '
        'BttBlock
        '
        Me.BttBlock.BackgroundImage = Global.CRM_BASE.My.Resources.Resources._1486564409_lock_81509
        Me.BttBlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBlock.FlatAppearance.BorderSize = 0
        Me.BttBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBlock.Location = New System.Drawing.Point(75, 3)
        Me.BttBlock.Name = "BttBlock"
        Me.BttBlock.Size = New System.Drawing.Size(30, 30)
        Me.BttBlock.TabIndex = 3
        Me.BttBlock.UseVisualStyleBackColor = True
        '
        'FrmQuadro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 590)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FrmQuadro"
        Me.Text = "FrmQuadro"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PicHierarquia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TrQuadro As TreeView
    Friend WithEvents BttEdit As Button
    Friend WithEvents BttAdd As Button
    Friend WithEvents BttBlock As Button
    Friend WithEvents PicHierarquia As PictureBox
    Friend WithEvents Panel2 As Panel
End Class
