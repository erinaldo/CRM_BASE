Imports System.Net
Imports Newtonsoft.Json

Public Class FrmVinculoModeloProduto
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub

    Dim LstIdFabricante As New ListBox
    Dim LstIdModelo As New ListBox

    Private Sub BttSalvarProduto_Click(sender As Object, e As EventArgs) Handles BttSalvarProduto.Click

        Me.Cursor = Cursors.WaitCursor

        'insere associação

        'atualiza  grid para inserção

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        LqOficina.InsereFabricanteModelo(CmbFabricantes.SelectedItem, Nothing)
        LqOficina.InsereModeloVeiculo(LqOficina.FabricantesVeiculo.ToList.Last.Idfabricante, CmbModelos.SelectedItem, LstAnoFabricacao.Items(CmbAnoFab.SelectedIndex).ToString, LstCombustivel.Items(CmbAnoFab.SelectedIndex).ToString)

        'verifica se contem flex 

        Dim Combustivel As String = LstCombustivel.Items(CmbAnoFab.SelectedIndex).ToString

        If CmbModelos.SelectedItem.ToString.ToLower.Contains("flex") Then

            Combustivel = "Flex"

        End If

        FrmProduto.DtVinculoExterno.Rows.Add("Oficina", CmbFabricantes.SelectedItem & " - " & CmbModelos.SelectedItem & " (" & LstAnoFabricacao.Items(CmbAnoFab.SelectedIndex).ToString & " - " & Combustivel & ")", LqOficina.Modelos.ToList.Last.IdModelo, True, FrmProduto.ImageList1.Images(1), CmbFabricantes.SelectedItem, CmbModelos.SelectedItem, 0, LstAnoFabricacao.Items(CmbAnoFab.SelectedIndex).ToString, LstCombustivel.Items(CmbAnoFab.SelectedIndex).ToString)

        'fecha o form
        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Private Sub FrmVinculoModeloProduto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'procura na AIP

        Dim baseUrlImagemUsuario As String = "http://fipeapi.appspot.com/api/1/carros/marcas.json"

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientImagemUsuario = New WebClient()
        Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

        Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.MarcasAPI_Veiculos))(contentImagemUsuario)

        For Each item In readImagemUsuario.ToList

            LstIdFabricante.Items.Add(item.id)
            CmbFabricantes.Items.Add(item.name)

        Next

    End Sub

    Private Sub CmbFabricantes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFabricantes.SelectedIndexChanged

        If CmbFabricantes.Items.Contains(CmbFabricantes.Text) Then

            Me.Cursor = Cursors.WaitCursor

            'procura modelos para o fabricante na fipe

            Dim baseUrlImagemUsuario As String = "http://fipeapi.appspot.com/api/1/carros/veiculos/" & LstIdFabricante.Items(CmbFabricantes.SelectedIndex).ToString & ".json"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagemUsuario = New WebClient()
            Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

            Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ModelosAPI_Veiculos))(contentImagemUsuario)

            LstIdModelo.Items.Clear()
            CmbModelos.Items.Clear()

            'cria lista de exclusão

            Dim LstExclusao As New ListBox

            For Each item As DataGridViewRow In FrmProduto.DtVinculoExterno.Rows

                LstExclusao.Items.Add(item.Cells(1).Value)

            Next

            For Each item In readImagemUsuario.ToList

                If Not LstExclusao.Items.Contains(CmbFabricantes.SelectedItem & " - " & item.name) Then
                    LstIdModelo.Items.Add(item.id)
                    CmbModelos.Items.Add(item.name)
                End If

            Next

            CmbModelos.Enabled = True

        Else

            CmbModelos.Enabled = False
            CmbModelos.Text = ""

        End If

        Me.Cursor = Cursors.Arrow

    End Sub

    Public LstAnoFabricacao As New ListBox
    Public LstCombustivel As New ListBox

    Private Sub CmbModelos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbModelos.SelectedIndexChanged

        If CmbModelos.Items.Contains(CmbModelos.Text) Then

            Me.Cursor = Cursors.WaitCursor

            'procura modelos para o fabricante na fipe

            Dim baseUrlImagemUsuario As String = "Http://fipeapi.appspot.com/api/1/carros/veiculo/" & LstIdFabricante.Items(CmbFabricantes.SelectedIndex).ToString & "/" & LstIdModelo.Items(CmbModelos.SelectedIndex).ToString & ".json"

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientImagemUsuario = New WebClient()
            Dim contentImagemUsuario = syncClientImagemUsuario.DownloadString(baseUrlImagemUsuario)

            Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.AnoFabMod))(contentImagemUsuario)

            LstAnoFabricacao.Items.Clear()
            CmbAnoFab.Items.Clear()
            LstCombustivel.Items.Clear()

            'cria lista de exclusão

            Dim LstExclusao As New ListBox

            For Each item As DataGridViewRow In FrmProduto.DtVinculoExterno.Rows

                LstExclusao.Items.Add(item.Cells(1).Value)

            Next


            For Each item In readImagemUsuario.ToList

                'procura modelos para o fabricante na fipe

                Dim baseUrlDet As String = "Http://fipeapi.appspot.com/api/1/carros/veiculo/" & LstIdFabricante.Items(CmbFabricantes.SelectedIndex).ToString & "/" & LstIdModelo.Items(CmbModelos.SelectedIndex).ToString & "/" & item.key & ".json"

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientDet = New WebClient()
                Dim contentDet = syncClientDet.DownloadString(baseUrlDet)

                Dim readDet = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.DetFabMod))("[" & contentDet & "]")

                If Not LstExclusao.Items.Contains(CmbFabricantes.SelectedItem & " - " & CmbModelos.SelectedItem & " (" & readDet.Item(0).ano_modelo & " - " & readDet.Item(0).combustivel & ")") Then

                    Dim Combustivel As String = readDet.Item(0).combustivel

                    If readDet.Item(0).veiculo.ToString.ToLower.Contains("flex") Then

                        Combustivel = "Flex"

                    End If

                    CmbAnoFab.Items.Add(readDet.Item(0).ano_modelo & " - " & Combustivel)
                    LstAnoFabricacao.Items.Add(readDet.Item(0).ano_modelo)
                    LstCombustivel.Items.Add(Combustivel)

                End If

            Next

        End If

        CmbAnoFab.Enabled = True

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub CmbFabricantes_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbFabricantes.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            CmbModelos.Focus()
        End If

    End Sub

    Private Sub CmbModelos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbModelos.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            e.Handled = True
            BttSalvarProduto.Focus()
        End If

    End Sub

    Private Sub CmbAnoFab_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnoFab.SelectedIndexChanged

        If CmbAnoFab.Items.Contains(CmbAnoFab.Text) Then

            BttSalvarProduto.Enabled = True

        Else

            BttSalvarProduto.Enabled = False

        End If

    End Sub
End Class