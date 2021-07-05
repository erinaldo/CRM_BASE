Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmEquipeOperacional
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmEquipeOperacional_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Dim Lstpopulados As New ListBox

    Public Sub CarregaInicio()

        DtFornecedores.Rows.Clear()

        'busca todos os colaboradores on line

        Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_usuarios_todos_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClient = New WebClient()
        Dim content = syncClient.DownloadString(baseUrl)

        Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Colaboradores))(content)

        For Each row In read.ToList

            If row.IdUsuario <> FrmPrincipal.IdUsuario Then
                Dim Image As Image = My.Resources.user_icon_icons1
                Dim UrlEnc As String = ""

                If row.UrlImagem <> "" Then

                    Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & row.UrlImagem

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientImagem = New WebClient()
                    'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                    Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                    Dim img As Image = Image.FromStream(stream)

                    Image = img

                    ImageList1.Images.Add(Image)
                    UrlEnc = baseUrlImagem

                Else

                    ImageList1.Images.Add(My.Resources.user_icon_icons1)

                End If

                DtFornecedores.Rows.Add(ImageList1.Images(0), row.NomeCompleto, row.User, row.Cargo, row.IdVinculoExt, row.IdUsuario, UrlEnc, row.Pass, ImageList2.Images(0))

                ImageList1.Images.Clear()

            Else

                Dim Image As Image = My.Resources.user_icon_icons1
                Dim UrlEnc As String = ""

                If row.UrlImagem <> "" Then

                    Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & row.UrlImagem

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientImagem = New WebClient()
                    'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                    Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                    Dim img As Image = Image.FromStream(stream)

                    Image = img

                    ImageList1.Images.Add(Image)
                    UrlEnc = baseUrlImagem

                Else

                    ImageList1.Images.Add(My.Resources.user_icon_icons1)

                End If

                'pinta o lider no picturebox

                TrEquipe.Nodes.Add(row.NomeCompleto)
                TrEquipe.Nodes(0).Nodes.Add(row.IdVinculoExt)
                TrEquipe.Nodes(0).Nodes.Add(UrlEnc)
                TrEquipe.Nodes(0).Nodes.Add(row.Cargo)
                TrEquipe.Nodes(0).Nodes.Add("Equipe")

                'busca equipes existentes

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaEquipes = From equip In LqBase.ColaboradoEquipe
                                   Where equip.IdLider = row.IdVinculoExt
                                   Select equip.IdFuncionario, equip.NomeFuncionario, equip.UrlImagemFuncionario, equip.CargoFuncionario

                For Each row2 In BuscaEquipes.ToList

                    TrEquipe.Nodes(0).Nodes(3).Nodes.Add(row2.NomeFuncionario)
                    TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(row2.IdFuncionario)
                    TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(row2.CargoFuncionario)
                    TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(row2.UrlImagemFuncionario)

                    'procura no datagrid, se houver apaga

                Next

                ImageList1.Images.Clear()

            End If

        Next

        Dim LstItensApagar As New ListBox

        For Each row3 As DataGridViewRow In DtFornecedores.Rows

            For Each tree As TreeNode In TrEquipe.Nodes(0).Nodes(3).Nodes

                If row3.Cells(4).Value = tree.Nodes(0).Text Then

                    LstItensApagar.Items.Add(row3.Index)

                End If

            Next

        Next

        For i As Integer = LstItensApagar.Items.Count - 1 To 0 Step -1
            '
            Dim Item As Integer = LstItensApagar.Items(i).ToString
            DtFornecedores.Rows.RemoveAt(Item)

        Next

        Pinta_Equipe()

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

    End Sub

    Dim _index As Integer = -1

    Private Sub DtFornecedores_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellClick

        Me.Cursor = Cursors.WaitCursor

        'insere no quadro de equipe

        TrEquipe.Nodes(0).Nodes(3).Nodes.Add(DtFornecedores.SelectedCells(1).Value)
        TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(DtFornecedores.SelectedCells(4).Value)
        TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(DtFornecedores.SelectedCells(3).Value)
        TrEquipe.Nodes(0).Nodes(3).Nodes(TrEquipe.Nodes(0).Nodes(3).Nodes.Count - 1).Nodes.Add(DtFornecedores.SelectedCells(6).Value)

        DtFornecedores.SelectedCells(8).Value = ImageList2.Images(1)
        _index = DtFornecedores.SelectedCells(0).RowIndex

        'insere no banco de dados

        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaEsquipes = From equip In LqBase.Equipes
                            Where equip.IdLider = TrEquipe.Nodes(0).Nodes(0).Text
                            Select equip.NomeLider

        If BuscaEsquipes.Count = 0 Then
            LqBase.InsereNovaEquipe(TrEquipe.Nodes(0).Nodes(0).Text, TrEquipe.Nodes(0).Text, TrEquipe.Nodes(0).Nodes(2).Text, TrEquipe.Nodes(0).Nodes(1).Text)
        End If

        'insere o colaborador a equipe do lider

        Dim _IdLider As Integer = TrEquipe.Nodes(0).Nodes(0).Text
        Dim _NomeLider As String = TrEquipe.Nodes(0).Text
        Dim _CargoLider As String = TrEquipe.Nodes(0).Nodes(2).Text
        Dim _UrlImagemLider As String = TrEquipe.Nodes(0).Nodes(1).Text

        Dim _IdFuncionario As Integer = DtFornecedores.SelectedCells(4).Value
        Dim _NomeFuncionario As String = DtFornecedores.SelectedCells(1).Value
        Dim _CargoFuncionario As String = DtFornecedores.SelectedCells(3).Value
        Dim _UrlImagemFuncionario As String = DtFornecedores.SelectedCells(6).Value

        LqBase.InsereNovoColaboradorEquipe(_IdLider, _NomeLider, _CargoLider, _UrlImagemLider, _IdFuncionario _
                                           , _NomeFuncionario, _CargoFuncionario, _UrlImagemFuncionario)

        Pinta_Equipe()

    End Sub

    Dim Iniciado As Boolean = False

    Public Sub Pinta_Equipe()

        'varre o treenode para confirmar 

        'Insere no grid

        Dim PintarBitmap = New Bitmap(TrEquipe.Nodes(0).Nodes(3).Nodes.Count * 150, (180 + 70) * 2)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        Dim MoveY As Integer = 5
        Dim MoveX As Integer = 5

        For Each tree As TreeNode In TrEquipe.Nodes

            If tree.Nodes(1).Text <> "" Then

                Dim baseUrlImagem As String = tree.Nodes(1).Text

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 30)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 1, 126, 29)
                Pintura.FillEllipse(New SolidBrush(Color.FromArgb(60, Color.Black)), MoveX - 5 + 50, MoveY + 195, 25, 25)

                Dim _RectangleBox As New Rectangle(MoveX - 3, MoveY - 3, 126, 26)

                Pintura.DrawString(tree.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), _RectangleBox)
                MoveY += 30

                Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 160)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 5, 126, 160)

                Pintura.DrawImage(img, MoveX, MoveY, 120, 150)

                MoveY += 150

                Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 35)
                Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 1, 126, 29)
                Dim _RectangleBox1 As New Rectangle(MoveX - 3, MoveY - 3, 126, 26)

                Pintura.DrawString(tree.Nodes(2).Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), _RectangleBox1)

            Else

                ImageList1.Images.Add(My.Resources.user_icon_icons1)

            End If

            MoveY += 55

            For Each treeSel As TreeNode In tree.Nodes(3).Nodes

                If treeSel.Nodes(1).Text <> "" Then

                    Dim baseUrlImagem As String = treeSel.Nodes(2).Text

                    'carrega informações no site

                    ' Chamada sincrona
                    Dim syncClientImagem = New WebClient()
                    'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                    Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                    Dim img As Image = Image.FromStream(stream)

                    Pintura.FillEllipse(New SolidBrush(Color.FromArgb(60, Color.Black)), MoveX - 5 + 50, MoveY - 15, 25, 25)
                    Pintura.FillEllipse(New SolidBrush((Color.SlateGray)), MoveX - 5 + 55, MoveY - 22, 15, 15)

                    If tree.Nodes(3).Nodes.Count > 1 Then

                        If treeSel.Index = 0 Then

                            Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5 + 65, MoveY - 16, 75, 3)

                        ElseIf treeSel.Index > 0 And treeSel.Index < tree.Nodes(3).Nodes.Count - 1 Then

                            Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 15, MoveY - 16, 150, 3)

                        ElseIf treeSel.Index = tree.Nodes(3).Nodes.Count - 1 Then

                            Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 15, MoveY - 16, 75, 3)

                        End If

                    End If

                    'Pintura.FillEllipse(New SolidBrush(Color.FromArgb(60, Color.Black)), MoveX + 150, MoveY + 75, 25, 25)

                    Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 30)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 1, 126, 29)
                    Dim _RectangleBox As New Rectangle(MoveX - 3, MoveY - 3, 126, 26)

                    Pintura.DrawString(treeSel.Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), _RectangleBox)
                    MoveY += 30

                    Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 160)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 5, 126, 160)

                    Pintura.DrawImage(img, MoveX, MoveY, 120, 150)

                    MoveY += 150

                    Pintura.FillRectangle(New SolidBrush(Color.SlateGray), MoveX - 5, MoveY - 5, 130, 35)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.Gainsboro)), MoveX - 3, MoveY - 1, 126, 29)
                    Dim _RectangleBox1 As New Rectangle(MoveX - 3, MoveY - 3, 126, 26)

                    Pintura.DrawString(treeSel.Nodes(1).Text, New Font("Calibri", 8.25), New SolidBrush(Color.WhiteSmoke), _RectangleBox1)

                    treeSel.Nodes.Add(MoveX)
                    treeSel.Nodes.Add(MoveY)
                    treeSel.Nodes.Add(120)
                    treeSel.Nodes.Add(150)

                Else

                    ImageList1.Images.Add(My.Resources.user_icon_icons1)

                End If

                MoveY -= 180
                MoveX += 150

            Next

        Next

        PicEquipe.Size = New Size(TrEquipe.Nodes(0).Nodes(3).Nodes.Count * 150, (180 + 70) * 2)
        PicEquipe.BackgroundImage = PintarBitmap

        If Iniciado = True Then
            DtFornecedores.Rows.RemoveAt(_index)
        End If

        Iniciado = True

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub PicEquipe_Click(sender As Object, e As EventArgs) Handles PicEquipe.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub PicEquipe_MouseClick(sender As Object, e As MouseEventArgs) Handles PicEquipe.MouseClick

        'verifica posiçao onde o mouse foi clicado

        Dim _index_Achado As Integer = -1

        For Each tree As TreeNode In TrEquipe.Nodes(0).Nodes(3).Nodes

            If e.X >= tree.Nodes(3).Text And e.X <= tree.Nodes(3).Text + tree.Nodes(5).Text Then

                If e.Y >= tree.Nodes(4).Text - tree.Nodes(6).Text And e.Y <= tree.Nodes(4).Text Then

                    _index_Achado = (tree.Index)

                End If

            End If

        Next

        If _index_Achado > -1 Then

            If MsgBox("Deseja realmente remover " & TrEquipe.Nodes(0).Nodes(3).Nodes(_index_Achado).Text & " da equipe?", MsgBoxStyle.YesNo + MsgBoxStyle.Information) = MsgBoxResult.Yes Then

                Me.Cursor = Cursors.WaitCursor

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                LqBase.DeletaNovoColaboradorEquipe(TrEquipe.Nodes(0).Nodes(0).Text, TrEquipe.Nodes(0).Nodes(3).Nodes(_index_Achado).Nodes(0).Text)

                Iniciado = False

                DtFornecedores.Rows.Clear()

                TrEquipe.Nodes.Clear()

                CarregaInicio()

            End If

        End If

    End Sub
End Class