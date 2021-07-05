<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUsarSolitaçõesCadatroPeça
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
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.DtProdutos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(0, 0)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(800, 28)
        Me.LblTitulo.TabIndex = 32
        Me.LblTitulo.Text = "Solução aplicada"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtProdutos
        '
        Me.DtProdutos.AllowUserToAddRows = False
        Me.DtProdutos.AllowUserToDeleteRows = False
        Me.DtProdutos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DtProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column4, Me.Column2, Me.Column3})
        Me.DtProdutos.Dock = System.Windows.Forms.DockStyle.Top
        Me.DtProdutos.EnableHeadersVisualStyles = False
        Me.DtProdutos.Location = New System.Drawing.Point(0, 28)
        Me.DtProdutos.Name = "DtProdutos"
        Me.DtProdutos.ReadOnly = True
        Me.DtProdutos.RowHeadersVisible = False
        Me.DtProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtProdutos.Size = New System.Drawing.Size(800, 209)
        Me.DtProdutos.TabIndex = 54
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cod. Solução"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "PN"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.HeaderText = "Descrição do item"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.HeaderText = "Data da solicitação"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Hora da solicitação"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel4)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BttFechar)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(0, 244)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(800, 38)
        Me.PnnInferior.TabIndex = 55
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(201, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(507, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.Button1)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(708, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(92, 38)
        Me.Panel12.TabIndex = 28
        '
        'Button1
        '
        Me.Button1.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(54, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 30
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BttSalvar
        '
        Me.BttSalvar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttSalvar.FlatAppearance.BorderSize = 0
        Me.BttSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttSalvar.Location = New System.Drawing.Point(16, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackColor = System.Drawing.Color.SlateGray
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.Dock = System.Windows.Forms.DockStyle.Left
        Me.BttFechar.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.BttFechar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BttFechar.Location = New System.Drawing.Point(0, 0)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(201, 38)
        Me.BttFechar.TabIndex = 34
        Me.BttFechar.Text = "Novo produto"
        Me.BttFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BttFechar.UseVisualStyleBackColor = False
        '
        'FrmUsarSolitaçõesCadatroPeça
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 282)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.DtProdutos)
        Me.Controls.Add(Me.LblTitulo)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmUsarSolitaçõesCadatroPeça"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmUsarSolitaçõesCadatroPeça"
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents DtProdutos As DataGridView
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Button1 As Button
    Friend WithEvents BttFechar As Button
End Class
