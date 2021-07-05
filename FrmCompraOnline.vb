Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmCompraOnline
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    'carrega compra online

    Public Sub CarregaInicio()

        DtProdutoSugestao.Rows.Clear()

        'carrega imagem do ususario

        'desenha timeline

        Dim LqComercial As New LqComercialDataContext
        LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

        Dim BuscaComercial = From ped In LqComercial.PedidoOnLine
                             Where ped.IdPedidoOnLine Like "*"
                             Select ped.VlrCompra, ped.Qtdade, ped.Status_posicao, ped.IdPedidoOnLine, ped.IdExternoPedido, ped.ChaveFornecedor

        For Each row In BuscaComercial.ToList

            Dim baseUrl As String = "http://www.iarasoftware.com.br/consulta_pedidos_online.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdPedido=" & row.IdExternoPedido

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim readImagemUsuario = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ConsultaPedidoOnline))(content)

            Dim Status_Encontrado As Integer = row.Status_posicao

            If readImagemUsuario.Count = 0 Then
                Status_Encontrado = row.Status_posicao
            Else
                Status_Encontrado = readImagemUsuario.Item(0).Status + 1
            End If

            Dim PintarBitmap = New Bitmap(5000, 1000)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            Dim X As Integer = 0
            Dim Size As Integer = 450
            Dim Y As Integer = ((1000 / 2) - (Size / 2)) + 150

            '1
            Dim stringFormat As StringFormat = New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            Dim _RectangleBox As New Rectangle(X, Y, Size, Size)

            Dim Status As String = ""

            If Status_Encontrado = 0 Then
                Status = "Aguardando análise de compra"
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)

                Pintura.DrawString("1", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)
            Else
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)

                Pintura.DrawString("1", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)
            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '2
            If Status_Encontrado = 1 Then
                Status = "Aguardando confirmação de pagamento"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("2", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("2", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '3
            If Status_Encontrado = 2 Then
                Status = "Aguardando confirmação da quantidade em estoque"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("3", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("3", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '4
            If Status_Encontrado = 3 Then

                Status = "Aguardando separação do item"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("4", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("4", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '5
            If Status_Encontrado = 4 Then

                Status = "Aguardando coleta/retirada"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("5", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("5", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '6
            If Status_Encontrado = 5 Then

                Status = "Pacote coletado, aguardando confirmação da entrega"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("6", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("6", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If

            X += Size + ((5000 - (Size * 7)) / 7)
            '7
            If Status_Encontrado = 6 Then

                Status = "Pacote entregue"

                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("7", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.WhiteSmoke), _RectangleBox, stringFormat)

            Else

                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X, Y, Size, Size)
                Pintura.FillEllipse(New SolidBrush(Color.SlateGray), X + 20, Y + 20, Size - 40, Size - 40)
                Pintura.FillEllipse(New SolidBrush(Color.WhiteSmoke), X + 30, Y + 30, Size - 60, Size - 60)
                _RectangleBox = New Rectangle(X, Y, Size, Size)

                Pintura.DrawString("7", New Font("Calibri", 240, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBox, stringFormat)

            End If


            Pintura.FillRectangle(New SolidBrush(Color.SlateGray), 0, Y - 250, X + 205 + 225, 150)
            Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), 5, Y - 245, (X + 205 + 225) - 10, 140)
            Dim _RectangleBoxTit As New Rectangle(205, Y - 245, X - 10, 140)


            Pintura.DrawString(Status, New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxTit, stringFormat)

            Dim PintarBitmapQt = New Bitmap(1000, 1000)

            Dim PinturaQt = Graphics.FromImage(PintarBitmapQt)

            Dim XQt As Integer = 0
            Dim SizeQt As Integer = 950
            Dim YQt As Integer = ((1000 / 2) - (SizeQt / 2)) + 150

            '1
            Dim stringFormatQt As StringFormat = New StringFormat()
            stringFormatQt.Alignment = StringAlignment.Center
            stringFormatQt.LineAlignment = StringAlignment.Center
            Dim _RectangleBoxQt As New Rectangle(5, Y - 245, SizeQt, 140)

            PinturaQt.FillRectangle(New SolidBrush(Color.SlateGray), 0, Y - 250, SizeQt, 150)
            PinturaQt.FillRectangle(New SolidBrush(Color.WhiteSmoke), 5, Y - 245, SizeQt - 10, 140)
            PinturaQt.DrawString("Qtdade", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQt, stringFormatQt)

            Dim _RectangleBoxQtT As New Rectangle(5, Y + 5, SizeQt - 10, SizeQt - 510)
            Dim _RectangleBoxQtT_0 As New Rectangle(0, Y, SizeQt, SizeQt - 500)

            PinturaQt.FillRectangle(New SolidBrush(Color.SlateGray), _RectangleBoxQtT_0)
            PinturaQt.FillRectangle(New SolidBrush(Color.WhiteSmoke), _RectangleBoxQtT)

            Try
                PinturaQt.DrawString(readImagemUsuario.Item(0).Qtdade, New Font("Calibri", 100, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQtT, stringFormatQt)
            Catch ex As Exception
                PinturaQt.DrawString(row.Qtdade, New Font("Calibri", 100, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQtT, stringFormatQt)
            End Try

            Dim PintarBitmapVlr = New Bitmap(1000, 1000)

            Dim PinturaVlr = Graphics.FromImage(PintarBitmapVlr)

            Dim XVlr As Integer = 0
            Dim SizeVlr As Integer = 950
            Dim YVlr As Integer = ((1000 / 2) - (SizeVlr / 2)) + 150

            '1
            Dim stringFormatVlr As StringFormat = New StringFormat()
            stringFormatVlr.Alignment = StringAlignment.Center
            stringFormatVlr.LineAlignment = StringAlignment.Center
            Dim _RectangleBoxVlr As New Rectangle(5, Y - 245, SizeVlr, 140)

            PinturaVlr.FillRectangle(New SolidBrush(Color.SlateGray), 0, Y - 250, SizeVlr, 150)
            PinturaVlr.FillRectangle(New SolidBrush(Color.WhiteSmoke), 5, Y - 245, SizeVlr - 10, 140)
            PinturaVlr.DrawString("Valor da compra", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQt, stringFormatQt)

            Dim _RectangleBoxVlrT As New Rectangle(5, Y + 5, SizeVlr - 10, SizeVlr - 510)
            Dim _RectangleBoxVlrT_0 As New Rectangle(0, Y, SizeVlr, SizeVlr - 500)

            PinturaVlr.FillRectangle(New SolidBrush(Color.SlateGray), _RectangleBoxVlrT_0)
            PinturaVlr.FillRectangle(New SolidBrush(Color.WhiteSmoke), _RectangleBoxVlrT)

            Try
                PinturaVlr.DrawString(FormatCurrency(readImagemUsuario.Item(0).SubTotal.Replace(".", ","), NumDigitsAfterDecimal:=2), New Font("Calibri", 100, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQtT, stringFormatQt)
            Catch ex As Exception
                PinturaVlr.DrawString(FormatCurrency(row.VlrCompra * row.Qtdade, NumDigitsAfterDecimal:=2), New Font("Calibri", 100, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQtT, stringFormatQt)
            End Try

            'pinta status pagamento

            Dim PintarBitmapPag = New Bitmap(1000, 1000)

            Dim PinturaPag = Graphics.FromImage(PintarBitmapPag)

            Dim XPag As Integer = 0
            Dim SizePag As Integer = 950
            Dim YPag As Integer = ((1000 / 2) - (SizePag / 2)) + 150

            '1
            Dim stringFormatPag As StringFormat = New StringFormat()
            stringFormatPag.Alignment = StringAlignment.Center
            stringFormatPag.LineAlignment = StringAlignment.Center
            Dim _RectangleBoxPag As New Rectangle(5, Y - 245, SizeVlr, 140)

            PinturaPag.FillRectangle(New SolidBrush(Color.SlateGray), 0, Y - 250, SizePag, 150)
            PinturaPag.FillRectangle(New SolidBrush(Color.WhiteSmoke), 5, Y - 245, SizePag - 10, 140)
            PinturaPag.DrawString("Status do pg", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQt, stringFormatQt)

            Dim _RectangleBoxPagT As New Rectangle(5, Y + 5, SizePag - 10, SizePag - 510)
            Dim _RectangleBoxPagT_0 As New Rectangle(0, Y, SizePag, SizePag - 500)
            Dim _RectangleBoxPagT_1 As New Rectangle(((_RectangleBoxPagT_0.Width / 2) - (Size / 4)), (Y + (Size / 8)), SizePag / 4, SizePag / 4)

            PinturaPag.FillRectangle(New SolidBrush(Color.SlateGray), _RectangleBoxPagT_0)
            PinturaPag.FillRectangle(New SolidBrush(Color.WhiteSmoke), _RectangleBoxPagT)

            'pinta a posiçao do status

            Dim baseUrlPg As String = "http://www.iarasoftware.com.br/consulta_pg_pedido.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&IdPedido=" & row.IdExternoPedido

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClientPg = New WebClient()
            Dim contentPg = syncClientPg.DownloadString(baseUrlPg)

            Dim readPg = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.ConsultaPg))(contentPg)
            Dim _RectangleBoxPagT_2 As New Rectangle(5, (Y + _RectangleBoxPagT.Height) - 140, SizePag - 10, 140)

            If readPg.Count = 0 Then
                PinturaPag.DrawImage(My.Resources.alert_icon_icons_com_52395, _RectangleBoxPagT_1)
                PinturaPag.DrawString("Aguardando pagamentos", New Font("Calibri", 60, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxPagT_2, stringFormatQt)
            Else
                If readPg.Item(0).Status = 0 Then
                    PinturaPag.DrawImage(My.Resources.img_checklist, _RectangleBoxPagT_1)
                    PinturaPag.DrawString("Aguardando liberação", New Font("Calibri", 60, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxPagT_2, stringFormatQt)
                ElseIf readPg.Item(0).Status = 1 Then
                    PinturaPag.DrawImage(My.Resources.check_ok_accept_apply_1582, _RectangleBoxPagT_1)
                    PinturaPag.DrawString("Aprovado", New Font("Calibri", 60, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxPagT_2, stringFormatQt)
                End If
            End If

            'pinta fornecedor

            Dim PintarBitmapFornecedor = New Bitmap(4000, 1000)

            Dim PinturaFornecedor = Graphics.FromImage(PintarBitmapFornecedor)

            Dim XFornecedor As Integer = 0
            Dim SizeFornecedor As Integer = 950
            Dim YFornecedor As Integer = ((1000 / 2) - (1000 / 2)) + 150

            '1
            Dim stringFormatFornecedor As StringFormat = New StringFormat()
            stringFormatFornecedor.Alignment = StringAlignment.Center
            stringFormatFornecedor.LineAlignment = StringAlignment.Center
            Dim _RectangleBoxFornecedor As New Rectangle(5, Y - 245, 4000 - 10, 140)

            PinturaFornecedor.FillRectangle(New SolidBrush(Color.SlateGray), 0, Y - 250, 4000, 150)
            PinturaFornecedor.FillRectangle(New SolidBrush(Color.WhiteSmoke), 5, Y - 245, 4000 - 10, 140)
            PinturaFornecedor.DrawString("Dados do fornecedor", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedor, stringFormatFornecedor)

            Dim _RectangleBoxFornecedorT As New Rectangle(5, Y + 5, SizeFornecedor - 10, SizeFornecedor - 510)
            Dim _RectangleBoxFornecedorT_0 As New Rectangle(0, Y, SizeFornecedor, SizeFornecedor - 500)

            PinturaFornecedor.FillRectangle(New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorT_0)
            PinturaFornecedor.FillRectangle(New SolidBrush(Color.WhiteSmoke), _RectangleBoxFornecedorT)

            PinturaFornecedor.DrawString("", New Font("Calibri", 100, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxQtT, stringFormatQt)

            Dim _RectangleBoxFornecedorD As New Rectangle(1105, Y + 5, 4000 - 1100 - 10, SizeFornecedor - 510)
            Dim _RectangleBoxFornecedorD_0 As New Rectangle(1100, Y, 4000 - 1100, SizeFornecedor - 500)

            PinturaFornecedor.FillRectangle(New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorD_0)
            PinturaFornecedor.FillRectangle(New SolidBrush(Color.WhiteSmoke), _RectangleBoxFornecedorD)

            'pinta imagem do logo se conseguir

            Try

                Dim baseUrlImagem As String = "http://www.iarasoftware.com.br/" & readImagemUsuario.Item(0).Logotipo

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClientImagem = New WebClient()
                'syncClientImagem.DownloadFile(New Uri(baseUrlImagem), row.lcl_arq.ToString)
                Dim stream As Stream = syncClientImagem.OpenRead(baseUrlImagem)

                Dim img As Image = Image.FromStream(stream)

                PinturaFornecedor.DrawImage(img, _RectangleBoxFornecedorD)

            Catch ex As Exception

                PinturaFornecedor.DrawImage(My.Resources.unavailable1, _RectangleBoxFornecedorT)

            End Try

            Try

                Dim _RectangleBoxFornecedorB As New Rectangle(1105, Y + 5 + 50, 4000 - 1100 - 20, 150)
                Dim stringFornecedorB As StringFormat = New StringFormat()
                stringFornecedorB.Alignment = StringAlignment.Near
                stringFornecedorB.LineAlignment = StringAlignment.Near

                PinturaFornecedor.DrawString("Razão social: " & readImagemUsuario.Item(0).NomeFornecedor, New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(1105, Y + 5 + 250, 4000 - 1100 - 20, 150)
                PinturaFornecedor.DrawString("CNPJ: " & readImagemUsuario.Item(0).Doc, New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(2505, Y + 5 + 250, 4000 - 2600 - 20, 150)
                PinturaFornecedor.DrawString("Pedido: " & row.IdExternoPedido, New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(1105, Y + 5 + 450, 4000 - 1100 - 20, 150)

            Catch ex As Exception

                Dim _RectangleBoxFornecedorB As New Rectangle(1105, Y + 5 + 50, 4000 - 1100 - 20, 150)
                Dim stringFornecedorB As StringFormat = New StringFormat()
                stringFornecedorB.Alignment = StringAlignment.Near
                stringFornecedorB.LineAlignment = StringAlignment.Near

                PinturaFornecedor.DrawString("Razão social: ND", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(1105, Y + 5 + 250, 4000 - 1100 - 20, 150)
                PinturaFornecedor.DrawString("CNPJ: ND", New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(2505, Y + 5 + 250, 4000 - 2600 - 20, 150)
                PinturaFornecedor.DrawString("Pedido: " & row.IdExternoPedido, New Font("Calibri", 80, FontStyle.Bold), New SolidBrush(Color.SlateGray), _RectangleBoxFornecedorB, stringFornecedorB)
                _RectangleBoxFornecedorB = New Rectangle(1105, Y + 5 + 450, 4000 - 1100 - 20, 150)

            End Try

            Dim Imagem_Pintada As Image = PintarBitmap
            Dim Imagem_Qt As Image = PintarBitmapQt
            Dim Imagem_Vlr As Image = PintarBitmapVlr
            Dim Imagem_Fornecedor As Image = PintarBitmapFornecedor
            Dim Imagem_Pag As Image = PintarBitmapPag

            If readImagemUsuario.Count = 0 Then
                DtProdutoSugestao.Rows.Add("", Imagem_Fornecedor, Imagem_Pag, Imagem_Pintada, Imagem_Qt, Imagem_Vlr)
            Else
                DtProdutoSugestao.Rows.Add(row.ChaveFornecedor, Imagem_Fornecedor, Imagem_Pag, Imagem_Pintada, Imagem_Qt, Imagem_Vlr)
            End If

        Next

    End Sub

    Private Sub FrmCompraOnline_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Dim Contador As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Contador = 3 Then
            Contador = 0
            CarregaInicio()
        Else
            Contador += 1
        End If

    End Sub
End Class