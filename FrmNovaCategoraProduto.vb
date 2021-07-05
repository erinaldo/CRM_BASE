Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNovaCategoraProduto
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Dim LqGeral As New DtCadastroDataContext
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        ''insere novo bairro

        'insere subcategoria on line

        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_categoria_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Descricao=" & TxtDescrição.Text & "&IdCategoriaVinc=0"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientInsereTodos = New WebClient()
        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

        Dim readCreate = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentInsereTodos & "]")

        If readCreate.Item(0).Create = "OK" Then

            LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            'insere categoria na base on line

            'insere novo bairro

            LqGeral.InsereCategoriaProduto(TxtDescrição.Text)

            'manda dados para o frmcadcolaboradores
            'carrega todos os estados
            Dim BuscaEstados = From est In LqGeral.CategoriasProdutos
                               Where est.IdCategoriaProduto Like "*"
                               Select est.IdCategoriaProduto, est.Descricao

            FrmProduto.CmbCategoria.Items.Clear()
            FrmProduto.LstIdCategoria.Items.Clear()

            For Each row In BuscaEstados.ToList
                FrmProduto.LstIdCategoria.Items.Add(row.IdCategoriaProduto)
                FrmProduto.CmbCategoria.Items.Add(row.Descricao)
            Next

            FrmProduto.CmbCategoria.Enabled = True
            FrmProduto.BttAddCategoria.Enabled = True
            FrmProduto.CmbCategoria.SelectedItem = TxtDescrição.Text

            Me.Close()

        End If

    End Sub
End Class