<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSolicitaçõesCadastro
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.LblTitulo = New System.Windows.Forms.Label()
        Me.DtProdutos = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.BttAddnovo = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BttSalvar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LblCódigo = New System.Windows.Forms.Label()
        Me.LblPn = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LblDescrição = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblVinculo = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblDataSol = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LblHoraSol = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PIcImagem = New System.Windows.Forms.PictureBox()
        Me.LblCategoria = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LblSubcategoria = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.PIcImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblTitulo
        '
        Me.LblTitulo.BackColor = System.Drawing.Color.SlateGray
        Me.LblTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.LblTitulo.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.LblTitulo.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.LblTitulo.Location = New System.Drawing.Point(1, 1)
        Me.LblTitulo.Name = "LblTitulo"
        Me.LblTitulo.Size = New System.Drawing.Size(504, 28)
        Me.LblTitulo.TabIndex = 32
        Me.LblTitulo.Text = "Solicitações de cadastro"
        Me.LblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtProdutos
        '
        Me.DtProdutos.AllowUserToAddRows = False
        Me.DtProdutos.AllowUserToDeleteRows = False
        Me.DtProdutos.BackgroundColor = System.Drawing.Color.White
        Me.DtProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtProdutos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtProdutos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtProdutos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtProdutos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column5, Me.Column4, Me.Column6, Me.Column2, Me.Column3})
        Me.DtProdutos.EnableHeadersVisualStyles = False
        Me.DtProdutos.Location = New System.Drawing.Point(15, 489)
        Me.DtProdutos.Name = "DtProdutos"
        Me.DtProdutos.ReadOnly = True
        Me.DtProdutos.RowHeadersVisible = False
        Me.DtProdutos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtProdutos.Size = New System.Drawing.Size(1066, 41)
        Me.DtProdutos.TabIndex = 55
        Me.DtProdutos.Visible = False
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.Column1.HeaderText = "Cod. Solução"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 83
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
        'Column6
        '
        Me.Column6.HeaderText = "Vinculo"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 300
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
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 551)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(504, 38)
        Me.PnnInferior.TabIndex = 56
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(391, 5)
        Me.Panel4.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttAddnovo)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Controls.Add(Me.BttSalvar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(391, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(113, 38)
        Me.Panel12.TabIndex = 28
        '
        'BttAddnovo
        '
        Me.BttAddnovo.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.add_1_icon
        Me.BttAddnovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttAddnovo.FlatAppearance.BorderSize = 0
        Me.BttAddnovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttAddnovo.Location = New System.Drawing.Point(77, 8)
        Me.BttAddnovo.Name = "BttAddnovo"
        Me.BttAddnovo.Size = New System.Drawing.Size(20, 20)
        Me.BttAddnovo.TabIndex = 30
        Me.BttAddnovo.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(43, 8)
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
        Me.BttSalvar.Location = New System.Drawing.Point(10, 8)
        Me.BttSalvar.Name = "BttSalvar"
        Me.BttSalvar.Size = New System.Drawing.Size(20, 20)
        Me.BttSalvar.TabIndex = 29
        Me.BttSalvar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(504, 1)
        Me.Panel1.TabIndex = 57
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1, 589)
        Me.Panel3.TabIndex = 59
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(505, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1, 589)
        Me.Panel5.TabIndex = 60
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel6.Location = New System.Drawing.Point(0, 589)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(506, 1)
        Me.Panel6.TabIndex = 61
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.Gainsboro
        Me.Label29.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label29.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Location = New System.Drawing.Point(12, 39)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(483, 20)
        Me.Label29.TabIndex = 69
        Me.Label29.Text = "Dados do item"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Código"
        '
        'LblCódigo
        '
        Me.LblCódigo.AutoSize = True
        Me.LblCódigo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCódigo.Location = New System.Drawing.Point(127, 71)
        Me.LblCódigo.Name = "LblCódigo"
        Me.LblCódigo.Size = New System.Drawing.Size(39, 13)
        Me.LblCódigo.TabIndex = 71
        Me.LblCódigo.Text = "Label2"
        '
        'LblPn
        '
        Me.LblPn.AutoSize = True
        Me.LblPn.ForeColor = System.Drawing.Color.SlateGray
        Me.LblPn.Location = New System.Drawing.Point(127, 96)
        Me.LblPn.Name = "LblPn"
        Me.LblPn.Size = New System.Drawing.Size(39, 13)
        Me.LblPn.TabIndex = 73
        Me.LblPn.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Part. Number"
        '
        'LblDescrição
        '
        Me.LblDescrição.AutoSize = True
        Me.LblDescrição.ForeColor = System.Drawing.Color.SlateGray
        Me.LblDescrição.Location = New System.Drawing.Point(127, 121)
        Me.LblDescrição.Name = "LblDescrição"
        Me.LblDescrição.Size = New System.Drawing.Size(39, 13)
        Me.LblDescrição.TabIndex = 75
        Me.LblDescrição.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Descrição"
        '
        'LblVinculo
        '
        Me.LblVinculo.AutoSize = True
        Me.LblVinculo.ForeColor = System.Drawing.Color.SlateGray
        Me.LblVinculo.Location = New System.Drawing.Point(127, 144)
        Me.LblVinculo.Name = "LblVinculo"
        Me.LblVinculo.Size = New System.Drawing.Size(39, 13)
        Me.LblVinculo.TabIndex = 77
        Me.LblVinculo.Text = "Label6"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 144)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 76
        Me.Label7.Text = "Vinculo"
        '
        'LblDataSol
        '
        Me.LblDataSol.AutoSize = True
        Me.LblDataSol.ForeColor = System.Drawing.Color.SlateGray
        Me.LblDataSol.Location = New System.Drawing.Point(127, 168)
        Me.LblDataSol.Name = "LblDataSol"
        Me.LblDataSol.Size = New System.Drawing.Size(39, 13)
        Me.LblDataSol.TabIndex = 79
        Me.LblDataSol.Text = "Label4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Data da solicitação"
        '
        'LblHoraSol
        '
        Me.LblHoraSol.AutoSize = True
        Me.LblHoraSol.ForeColor = System.Drawing.Color.SlateGray
        Me.LblHoraSol.Location = New System.Drawing.Point(365, 168)
        Me.LblHoraSol.Name = "LblHoraSol"
        Me.LblHoraSol.Size = New System.Drawing.Size(39, 13)
        Me.LblHoraSol.TabIndex = 81
        Me.LblHoraSol.Text = "Label4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(261, 168)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(98, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Hora da solicitação"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Gainsboro
        Me.Label2.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label2.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Location = New System.Drawing.Point(12, 222)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(483, 20)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Origem da solicitação"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PIcImagem
        '
        Me.PIcImagem.Location = New System.Drawing.Point(26, 255)
        Me.PIcImagem.Name = "PIcImagem"
        Me.PIcImagem.Size = New System.Drawing.Size(449, 290)
        Me.PIcImagem.TabIndex = 83
        Me.PIcImagem.TabStop = False
        '
        'LblCategoria
        '
        Me.LblCategoria.AutoSize = True
        Me.LblCategoria.ForeColor = System.Drawing.Color.SlateGray
        Me.LblCategoria.Location = New System.Drawing.Point(127, 193)
        Me.LblCategoria.Name = "LblCategoria"
        Me.LblCategoria.Size = New System.Drawing.Size(39, 13)
        Me.LblCategoria.TabIndex = 85
        Me.LblCategoria.Text = "Label4"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 84
        Me.Label9.Text = "Categoria"
        '
        'LblSubcategoria
        '
        Me.LblSubcategoria.AutoSize = True
        Me.LblSubcategoria.ForeColor = System.Drawing.Color.SlateGray
        Me.LblSubcategoria.Location = New System.Drawing.Point(365, 193)
        Me.LblSubcategoria.Name = "LblSubcategoria"
        Me.LblSubcategoria.Size = New System.Drawing.Size(39, 13)
        Me.LblSubcategoria.TabIndex = 87
        Me.LblSubcategoria.Text = "Label4"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(260, 193)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 86
        Me.Label10.Text = "Subcategoria"
        '
        'FrmSolicitaçõesCadastro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(506, 590)
        Me.Controls.Add(Me.LblSubcategoria)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblCategoria)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.PIcImagem)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblHoraSol)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblDataSol)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblVinculo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LblDescrição)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.LblPn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblCódigo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.DtProdutos)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.LblTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmSolicitaçõesCadastro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSolicitaçõesCadastro"
        CType(Me.DtProdutos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.PIcImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitulo As Label
    Friend WithEvents DtProdutos As DataGridView
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttFechar As Button
    Friend WithEvents BttSalvar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents BttAddnovo As Button
    Friend WithEvents Label29 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents LblCódigo As Label
    Friend WithEvents LblPn As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LblDescrição As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblVinculo As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblDataSol As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LblHoraSol As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents PIcImagem As PictureBox
    Friend WithEvents LblCategoria As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LblSubcategoria As Label
    Friend WithEvents Label10 As Label
End Class
