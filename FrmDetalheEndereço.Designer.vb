<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetalheEndereço
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PnnInferior = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblNomeEndereco = New System.Windows.Forms.Label()
        Me.LblStatus = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LblCod = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblDEscrição = New System.Windows.Forms.Label()
        Me.TxtQtdade = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtQtdadeDisponivel = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LblDataEntrada = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DtBaixas = New System.Windows.Forms.DataGridView()
        Me.LblNumNf = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.BttBuscarCliente = New System.Windows.Forms.Button()
        Me.BttFechar = New System.Windows.Forms.Button()
        Me.BtnMovimentar = New System.Windows.Forms.Button()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PnnInferior.SuspendLayout()
        Me.Panel12.SuspendLayout()
        CType(Me.DtBaixas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.SlateGray
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(698, 26)
        Me.Label1.TabIndex = 178
        Me.Label1.Text = "Detalhes do endereço"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PnnInferior
        '
        Me.PnnInferior.BackColor = System.Drawing.Color.SlateGray
        Me.PnnInferior.Controls.Add(Me.Panel5)
        Me.PnnInferior.Controls.Add(Me.Panel12)
        Me.PnnInferior.Controls.Add(Me.BtnMovimentar)
        Me.PnnInferior.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnnInferior.Location = New System.Drawing.Point(1, 558)
        Me.PnnInferior.Name = "PnnInferior"
        Me.PnnInferior.Size = New System.Drawing.Size(698, 36)
        Me.PnnInferior.TabIndex = 179
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(173, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(453, 5)
        Me.Panel5.TabIndex = 27
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.SlateGray
        Me.Panel12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel12.Controls.Add(Me.BttBuscarCliente)
        Me.Panel12.Controls.Add(Me.BttFechar)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel12.Location = New System.Drawing.Point(626, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(72, 36)
        Me.Panel12.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SlateGray
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1, 594)
        Me.Panel1.TabIndex = 180
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SlateGray
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(699, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1, 594)
        Me.Panel2.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 17)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Nome do endereço"
        '
        'LblNomeEndereco
        '
        Me.LblNomeEndereco.AutoSize = True
        Me.LblNomeEndereco.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNomeEndereco.Location = New System.Drawing.Point(12, 73)
        Me.LblNomeEndereco.Name = "LblNomeEndereco"
        Me.LblNomeEndereco.Size = New System.Drawing.Size(115, 17)
        Me.LblNomeEndereco.TabIndex = 183
        Me.LblNomeEndereco.Text = "Nome do endereço"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblStatus.Location = New System.Drawing.Point(532, 73)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(115, 17)
        Me.LblStatus.TabIndex = 185
        Me.LblStatus.Text = "Nome do endereço"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(532, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 17)
        Me.Label4.TabIndex = 184
        Me.Label4.Text = "Status do endereço"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 17)
        Me.Label3.TabIndex = 186
        Me.Label3.Text = "Cod. do produto armazenado"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Gainsboro
        Me.Label5.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label5.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Location = New System.Drawing.Point(11, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(681, 20)
        Me.Label5.TabIndex = 187
        Me.Label5.Text = "Dados da armazenagem"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblCod
        '
        Me.LblCod.AutoSize = True
        Me.LblCod.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblCod.Location = New System.Drawing.Point(12, 178)
        Me.LblCod.Name = "LblCod"
        Me.LblCod.Size = New System.Drawing.Size(15, 17)
        Me.LblCod.TabIndex = 188
        Me.LblCod.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 17)
        Me.Label6.TabIndex = 189
        Me.Label6.Text = "Descrição do produto"
        '
        'LblDEscrição
        '
        Me.LblDEscrição.AutoSize = True
        Me.LblDEscrição.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDEscrição.Location = New System.Drawing.Point(12, 234)
        Me.LblDEscrição.Name = "LblDEscrição"
        Me.LblDEscrição.Size = New System.Drawing.Size(115, 17)
        Me.LblDEscrição.TabIndex = 190
        Me.LblDEscrição.Text = "Nome do endereço"
        '
        'TxtQtdade
        '
        Me.TxtQtdade.AutoSize = True
        Me.TxtQtdade.ForeColor = System.Drawing.Color.DarkOrange
        Me.TxtQtdade.Location = New System.Drawing.Point(225, 178)
        Me.TxtQtdade.Name = "TxtQtdade"
        Me.TxtQtdade.Size = New System.Drawing.Size(15, 17)
        Me.TxtQtdade.TabIndex = 192
        Me.TxtQtdade.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(225, 151)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 17)
        Me.Label8.TabIndex = 191
        Me.Label8.Text = "Qt armazendada"
        '
        'TxtQtdadeDisponivel
        '
        Me.TxtQtdadeDisponivel.AutoSize = True
        Me.TxtQtdadeDisponivel.ForeColor = System.Drawing.Color.DarkOrange
        Me.TxtQtdadeDisponivel.Location = New System.Drawing.Point(363, 178)
        Me.TxtQtdadeDisponivel.Name = "TxtQtdadeDisponivel"
        Me.TxtQtdadeDisponivel.Size = New System.Drawing.Size(15, 17)
        Me.TxtQtdadeDisponivel.TabIndex = 194
        Me.TxtQtdadeDisponivel.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(363, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 17)
        Me.Label9.TabIndex = 193
        Me.Label9.Text = "Qt disponível"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(532, 151)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 17)
        Me.Label7.TabIndex = 195
        Me.Label7.Text = "Data da entrada"
        '
        'LblDataEntrada
        '
        Me.LblDataEntrada.AutoSize = True
        Me.LblDataEntrada.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblDataEntrada.Location = New System.Drawing.Point(532, 178)
        Me.LblDataEntrada.Name = "LblDataEntrada"
        Me.LblDataEntrada.Size = New System.Drawing.Size(15, 17)
        Me.LblDataEntrada.TabIndex = 196
        Me.LblDataEntrada.Text = "0"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Gainsboro
        Me.Label10.Font = New System.Drawing.Font("Calibri", 10.0!)
        Me.Label10.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Location = New System.Drawing.Point(11, 278)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(681, 20)
        Me.Label10.TabIndex = 197
        Me.Label10.Text = "Baixas do endereço"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DtBaixas
        '
        Me.DtBaixas.AllowUserToAddRows = False
        Me.DtBaixas.AllowUserToDeleteRows = False
        Me.DtBaixas.AllowUserToResizeColumns = False
        Me.DtBaixas.AllowUserToResizeRows = False
        Me.DtBaixas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DtBaixas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DtBaixas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DtBaixas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtBaixas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DtBaixas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtBaixas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column5, Me.Column2, Me.Column3, Me.Column4, Me.Column15})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 7.8!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtBaixas.DefaultCellStyle = DataGridViewCellStyle2
        Me.DtBaixas.Enabled = False
        Me.DtBaixas.EnableHeadersVisualStyles = False
        Me.DtBaixas.GridColor = System.Drawing.Color.Gainsboro
        Me.DtBaixas.Location = New System.Drawing.Point(12, 310)
        Me.DtBaixas.MultiSelect = False
        Me.DtBaixas.Name = "DtBaixas"
        Me.DtBaixas.ReadOnly = True
        Me.DtBaixas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DtBaixas.RowHeadersVisible = False
        Me.DtBaixas.RowHeadersWidth = 51
        Me.DtBaixas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtBaixas.RowTemplate.Height = 30
        Me.DtBaixas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtBaixas.ShowCellErrors = False
        Me.DtBaixas.ShowCellToolTips = False
        Me.DtBaixas.ShowEditingIcon = False
        Me.DtBaixas.ShowRowErrors = False
        Me.DtBaixas.Size = New System.Drawing.Size(676, 231)
        Me.DtBaixas.TabIndex = 198
        '
        'LblNumNf
        '
        Me.LblNumNf.AutoSize = True
        Me.LblNumNf.ForeColor = System.Drawing.Color.DarkOrange
        Me.LblNumNf.Location = New System.Drawing.Point(363, 73)
        Me.LblNumNf.Name = "LblNumNf"
        Me.LblNumNf.Size = New System.Drawing.Size(15, 17)
        Me.LblNumNf.TabIndex = 200
        Me.LblNumNf.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(363, 47)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 17)
        Me.Label12.TabIndex = 199
        Me.Label12.Text = "Documento vinculado"
        '
        'BttBuscarCliente
        '
        Me.BttBuscarCliente.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.check_ok_accept_apply_1582
        Me.BttBuscarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttBuscarCliente.FlatAppearance.BorderSize = 0
        Me.BttBuscarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttBuscarCliente.Location = New System.Drawing.Point(10, 8)
        Me.BttBuscarCliente.Name = "BttBuscarCliente"
        Me.BttBuscarCliente.Size = New System.Drawing.Size(18, 22)
        Me.BttBuscarCliente.TabIndex = 25
        Me.BttBuscarCliente.UseVisualStyleBackColor = True
        '
        'BttFechar
        '
        Me.BttFechar.BackgroundImage = Global.CRM_BASE.My.Resources.Resources.Delete_80_icon_icons_com_57340
        Me.BttFechar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BttFechar.FlatAppearance.BorderSize = 0
        Me.BttFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BttFechar.Location = New System.Drawing.Point(46, 8)
        Me.BttFechar.Name = "BttFechar"
        Me.BttFechar.Size = New System.Drawing.Size(18, 22)
        Me.BttFechar.TabIndex = 26
        Me.BttFechar.UseVisualStyleBackColor = True
        '
        'BtnMovimentar
        '
        Me.BtnMovimentar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BtnMovimentar.Dock = System.Windows.Forms.DockStyle.Left
        Me.BtnMovimentar.FlatAppearance.BorderColor = System.Drawing.Color.DimGray
        Me.BtnMovimentar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnMovimentar.Font = New System.Drawing.Font("Calibri", 8.25!)
        Me.BtnMovimentar.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BtnMovimentar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMovimentar.Location = New System.Drawing.Point(0, 0)
        Me.BtnMovimentar.Name = "BtnMovimentar"
        Me.BtnMovimentar.Size = New System.Drawing.Size(173, 36)
        Me.BtnMovimentar.TabIndex = 33
        Me.BtnMovimentar.Text = "Mover itens estocados"
        Me.BtnMovimentar.UseVisualStyleBackColor = True
        '
        'Column5
        '
        Me.Column5.HeaderText = "IdBaixa"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Visible = False
        Me.Column5.Width = 125
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "Separador"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "Data da baixa"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 125
        '
        'Column4
        '
        Me.Column4.HeaderText = "Hora da baixa"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 125
        '
        'Column15
        '
        Me.Column15.HeaderText = "Qtdade"
        Me.Column15.MinimumWidth = 6
        Me.Column15.Name = "Column15"
        Me.Column15.ReadOnly = True
        Me.Column15.Width = 125
        '
        'FrmDetalheEndereço
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 594)
        Me.Controls.Add(Me.LblNumNf)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DtBaixas)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.LblDataEntrada)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtQtdadeDisponivel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtQtdade)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LblDEscrição)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblCod)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblNomeEndereco)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PnnInferior)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Calibri", 7.8!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmDetalheEndereço"
        Me.Opacity = 0.95R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmDetalheEndereço"
        Me.PnnInferior.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        CType(Me.DtBaixas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PnnInferior As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel12 As Panel
    Friend WithEvents BttBuscarCliente As Button
    Friend WithEvents BttFechar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents LblNomeEndereco As Label
    Friend WithEvents LblStatus As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LblCod As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents LblDEscrição As Label
    Friend WithEvents TxtQtdade As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TxtQtdadeDisponivel As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LblDataEntrada As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents DtBaixas As DataGridView
    Friend WithEvents LblNumNf As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents BtnMovimentar As Button
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
End Class
