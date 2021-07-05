Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmListaColaboradores
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Private Sub FrmListaColaboradores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

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

            DtFornecedores.Rows.Add(ImageList1.Images(0), row.NomeCompleto, row.User, row.Cargo, row.IdVinculoExt, row.IdUsuario, UrlEnc, row.Pass)

            ImageList1.Images.Clear()

        Next

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        FrmCadColaboradores.Show(Me)

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

    End Sub

    Private Sub DtFornecedores_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellDoubleClick

        FrmCadColaboradores._IdInterno = DtFornecedores.SelectedCells(4).Value
        FrmCadColaboradores._IdExterno = DtFornecedores.SelectedCells(5).Value
        FrmCadColaboradores.NomeCompleto = DtFornecedores.SelectedCells(1).Value
        FrmCadColaboradores.NomeUsuario = DtFornecedores.SelectedCells(2).Value
        FrmCadColaboradores.SenhaUsuario = DtFornecedores.SelectedCells(7).Value

        If DtFornecedores.SelectedCells(6).Value <> "" Then

            Dim baseUrlImagem As String = DtFornecedores.SelectedCells(6).Value

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagem = New WebClient()
            'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
            Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

            Dim img As Image = Image.FromStream(stream)

            FrmCadColaboradores.PicImagem.BackgroundImage = img
            FrmCadColaboradores.PicImagem.BackgroundImageLayout = ImageLayout.Zoom

        End If

        FrmCadColaboradores.Show(Me)

    End Sub

End Class