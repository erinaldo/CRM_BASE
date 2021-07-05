Public Class FrmSetoresClientes
    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovoSetorCliente.IdCliente = IdCliente
        FrmNovoSetorCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Public IdCliente As Integer

    Public Sub CarregaInicio()

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaSetor = From setor In LqTrabalhista.SetoresClientes
                         Where setor.IdCliente = IdCliente
                         Select setor.CorSetor, setor.IdSetorCliente, setor.NomeSetor
                         Order By IdSetorCliente Descending

        DtProdutos.Rows.Clear()

        For Each row In BuscaSetor.ToList

            Dim H As Integer = 16
            Dim V As Integer = 16

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Contexto As String = BuscaSetor.First.CorSetor

            Dim str As String = row.CorSetor
            Dim separador As String = "."
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            Dim Red As Integer = LstPalavras.Items(0).ToString
            Dim Green As Integer = LstPalavras.Items(1).ToString
            Dim Blue As Integer = LstPalavras.Items(2).ToString

            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(255, Red, Green, Blue)), 0, 0, H, V)

            Dim ImageRer As Image = PintarBitmap

            Dim BuscaFuncoes = From func In LqTrabalhista.FuncoesClientesSetores
                               Where func.IdSetorCliente = row.IdSetorCliente
                               Select func.IdSetorCliente

            Dim BuscaRisco = From func In LqTrabalhista.RiscosSetores
                             Where func.IdSetor = row.IdSetorCliente
                             Select func.IdRisco

            DtProdutos.Rows.Add(ImageRer, row.IdSetorCliente, row.NomeSetor, BuscaRisco.Count, BuscaFuncoes.Count, ImageList2.Images(0), ImageList2.Images(1))

        Next

    End Sub

    Private Sub FrmSetoresClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmListaClientes.CarregaInicio()

        Me.Close()

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            If MsgBox("Tem certeza que deseja remover este cliente, lembre-se, se ele possuir histórico de atividade no sistema, o mesmo não poderá ser removido." & Chr(13) & "Deseja realmente prosseguir?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                'remove da lista

                Dim LqTrabalhista As New LqTrabalhistaDataContext
                LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                LqTrabalhista.DeletaSetorCliente(DtProdutos.Rows(e.RowIndex).Cells(1).Value)
                'traz informaçoes novas

                CarregaInicio()

            End If

        ElseIf DtProdutos.Columns(e.ColumnIndex).Name = "ClmEditar" Then

            Me.Cursor = Cursors.WaitCursor

            'carrega informações do cliente

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdSetor As Integer = DtProdutos.Rows(e.RowIndex).Cells(1).Value

            Dim ConsultaBase = From bas In LqTrabalhista.SetoresClientes
                               Where bas.IdCliente = IdCliente And bas.IdSetorCliente = IdSetor
                               Select bas.NomeSetor, bas.CorSetor

            FrmNovoSetorCliente.TxtNomeSetor.Text = ConsultaBase.First.NomeSetor

            'abre o form

            FrmNovoSetorCliente.IdCliente = IdCliente
            FrmNovoSetorCliente.IdSetor = IdSetor

            Dim Contexto As String = ConsultaBase.First.CorSetor

            Dim str As String = Contexto
            Dim separador As String = "."
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            Dim Red As Integer = LstPalavras.Items(0).ToString
            Dim Green As Integer = LstPalavras.Items(1).ToString
            Dim Blue As Integer = LstPalavras.Items(2).ToString

            FrmNovoSetorCliente.Red = Red
            FrmNovoSetorCliente.Green = Green
            FrmNovoSetorCliente.Blue = Blue

            FrmNovoSetorCliente.PnnCor.BackColor = Color.FromArgb(255, Red, Green, Blue)
            FrmNovoSetorCliente.Show(Me)

            Me.Cursor = Cursors.Arrow

        End If

    End Sub
End Class