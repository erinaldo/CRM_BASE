Public Class FrmRiscos

    Public Red As Integer = 0
    Public Green As Integer = 0
    Public Blue As Integer = 255

    Public Sub CarregaInicio()

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrab = From trab In LqTrabalhista.Riscos
                        Where trab.IdRisco Like "*"
                        Select trab.IdRisco, trab.Descricao, trab.Red, trab.Green, trab.Blue

        DtProdutos.Rows.Clear()

        For Each row In BuscaTrab.ToList

            Dim H As Integer = 16
            Dim V As Integer = 16

            Dim PintarBitmap = New Bitmap(H, V)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim Red As Integer = row.Red
            Dim Green As Integer = row.Green
            Dim Blue As Integer = row.Blue

            Pintura.FillRectangle(New SolidBrush(Color.FromArgb(255, Red, Green, Blue)), 0, 0, H, V)

            Dim ImageRer As Image = PintarBitmap

            DtProdutos.Rows.Add(ImageRer, row.IdRisco, row.Descricao, ImageList1.Images(1), Red, Green, Blue)

        Next

    End Sub
    Private Sub FrmRiscos_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub BttAprovarOrc_Click(sender As Object, e As EventArgs) Handles BttAprovarOrc.Click

        Me.Cursor = Cursors.WaitCursor

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaSetor = From setor In LqTrabalhista.Riscos
                         Where setor.IdRisco Like "*"
                         Select setor.Red, setor.Green, setor.Blue, setor.IdRisco
                         Order By IdRisco Descending

        Dim Acrescentar As Integer = 101

        If Red < Green Then

            Red += Acrescentar

            If Red > 255 Then
                Green = Red - 255
                Red = 255
            End If

        End If

        If Green < Blue Then

            Green += Acrescentar

            If Green > 255 Then
                Blue = Green - 255
                Green = 255
            End If

        End If

        If Blue < Red Then

            Blue += Acrescentar

            If Blue > 255 Then
                Red = Blue - 255
                Blue = 255
            End If

        End If

        Dim NovaCor As Color = Color.FromArgb(255, Red, Green, Blue)

        FrmNovoRisco.PnnCor.BackColor = NovaCor

        FrmNovoRisco.Red = Red
        FrmNovoRisco.Green = Green
        FrmNovoRisco.Blue = Blue

        FrmNovoRisco.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

        Me.Cursor = Cursors.Arrow

    End Sub
End Class