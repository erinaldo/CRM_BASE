Imports System.Net
Imports Newtonsoft.Json

Public Class FrmNovoFabricante

    Public FormOri As Integer
    Dim lqGeral As New DtCadastroDataContext
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Private Sub Panel12_Paint(sender As Object, e As PaintEventArgs) Handles Panel12.Paint

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        ''insere novo bairro

        'insere subcategoria on line

        Dim baseUrlInsereTodos As String = "http://www.iarasoftware.com.br/create_fabricante_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Descricao=" & TxtDescrição.Text

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientInsereTodos = New WebClient()
        Dim contentInsereTodos = syncClientInsereTodos.DownloadString(baseUrlInsereTodos)


        Dim readCreate = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & contentInsereTodos & "]")

        If readCreate.Item(0).Create = "OK" Then

            lqGeral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            'insere novo bairro

            lqGeral.Inserefabricante(TxtDescrição.Text)

            'manda dados para o frmcadcolaboradores

            'busca fabricante
            Dim BuscaFabricante = From est In lqGeral.Fabricantes
                                      Where est.IdFabricante Like "*"
                                      Select est.IdFabricante, est.Fabricante

            If Application.OpenForms.OfType(Of FrmProduto)().Count() > 0 Then

                FrmProduto.LstIdFabricante.Items.Clear()
                FrmProduto.CmbFabricante.Items.Clear()

                For Each row In BuscaFabricante.ToList
                    FrmProduto.LstIdFabricante.Items.Add(row.IdFabricante)
                    FrmProduto.CmbFabricante.Items.Add(row.Fabricante)
                Next
                FrmProduto.CmbFabricante.SelectedItem = TxtDescrição.Text

            ElseIf Application.OpenForms.OfType(Of FrmCadastrarSolicitacaoProduto)().Count() > 0 Then

                FrmCadastrarSolicitacaoProduto.CmbFabricante.Items.Clear()

                For Each row In BuscaFabricante.ToList
                    FrmCadastrarSolicitacaoProduto.CmbFabricante.Items.Add(row.Fabricante)
                Next
                FrmCadastrarSolicitacaoProduto.CmbFabricante.SelectedItem = TxtDescrição.Text

            End If

            Me.Close()

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class