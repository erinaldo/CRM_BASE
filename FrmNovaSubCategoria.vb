Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNovaSubCategoria
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            BtnSalvar.Enabled = True
        Else
            BtnSalvar.Enabled = False
        End If
    End Sub

    Dim LqGeral As New DtCadastroDataContext
    Public IdCategoria As Integer
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        'verifica se a categoria foi inserida, se nao insere

        Dim _IdCategoria As Integer = IdCategoria
        ''insere novo bairro
        Dim LqBase As New DtCadastroDataContext
        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaCategoria = From cat In LqBase.CategoriasProdutos
                             Where cat.IdCategoriaProduto = IdCategoria
                             Select cat.IdCategoriaProduto

        If BuscaCategoria.Count = 0 Then

            LqBase.InsereCategoriaProduto(FrmNovoStudioAvaliacao.SelPrincipal)

            IdCategoria = LqBase.CategoriasProdutos.ToList.Last.IdCategoriaProduto

        End If

        'insere subcategoria on line

        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_subcategoria_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Categoria=" & FrmNovoStudioAvaliacao.SelPrincipal & "&IdSubCategoriaVinc=" & IdCategoria & "&Descricao=" & TxtDescrição.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientInsereTodos = New WebClient()
        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)

        Dim readCreate = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentInsereTodos & "]")

        If readCreate.Item(0).Create = "OK" Then

            'refresh sistem

            Dim baseUrlConsultaSub As String = "http://www.iarasoftware.com.br/consulta_subcategoria_produtos_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Categoria=" & FrmNovoStudioAvaliacao.SelPrincipal

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientConsultaSub = New WebClient()
            Dim contentConsultaSub = syncClientConsultaSub.DownloadString(baseUrlConsultaSub)

            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.SubCategorias))(contentConsultaSub)

            'busca subcategorias cadastradas

            LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim BuscaSubcategorias = From subcat In LqGeral.SubCategoriasProduto
                                     Where subcat.Descricao Like TxtDescrição.Text And IdCategoria = IdCategoria
                                     Select subcat.IdSubCategoria, subcat.Descricao

            If BuscaSubcategorias.Count > 0 Then

                Me.Close()

            Else

                'çadastra local

                LqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                LqGeral.InsereSubcategoriaProduto(IdCategoria, TxtDescrição.Text)

                'manda dados para o frmcadcolaboradores
                'carrega todos os estados
                Dim BuscaEstados = From est In LqGeral.SubCategoriasProduto
                                   Where est.IdCategoria = IdCategoria
                                   Select est.IdSubCategoria, est.Descricao

                If Application.OpenForms.OfType(Of FrmProduto)().Count() > 0 Then

                    FrmProduto.CmbSubcategoria.Items.Clear()
                    FrmProduto.LstIdSubCategorias.Items.Clear()

                    For Each row In BuscaEstados.ToList
                        FrmProduto.LstIdSubCategorias.Items.Add(row.IdSubCategoria)
                        FrmProduto.CmbSubcategoria.Items.Add(row.Descricao)
                    Next

                    FrmProduto.CmbSubcategoria.Enabled = True
                    FrmProduto.BttAddSubcategoria.Enabled = True
                    FrmProduto.CmbSubcategoria.SelectedItem = TxtDescrição.Text

                    Me.Close()

                ElseIf Application.OpenForms.OfType(Of FrmCadastrarSolicitacaoProduto)().Count() > 0 Then

                    FrmCadastrarSolicitacaoProduto.CmbCategria.Items.Clear()

                    For Each row In BuscaEstados.ToList
                        FrmCadastrarSolicitacaoProduto.CmbCategria.Items.Add(row.Descricao)
                    Next

                    FrmCadastrarSolicitacaoProduto.BttAddSubcategoria.Enabled = True
                    FrmCadastrarSolicitacaoProduto.CmbCategria.SelectedItem = TxtDescrição.Text

                    Me.Close()

                End If

            End If

        End If

    End Sub
End Class