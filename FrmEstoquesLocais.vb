Public Class FrmEstoquesLocais
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Dim LqEstoque As New LqEstoqueLocalDataContext
    Dim LqBase As New DtCadastroDataContext

    Public Sub PIntaEstoques()

        'limpa treeview

        TrEstoque.Nodes.Clear()

        'busca estoques 

        LqEstoque.Connection.ConnectionString = FrmPrincipal.ConnectionStringEstoqueLocal

        Dim BuscaEstoques = From est In LqEstoque.EstoquesLocais
                            Where est.IdEstoque Like "*"
                            Select est.NomeEstoque, est.IdEstoque, est.Status, est.TipoEstoque

        Dim X As Decimal = 115
        Dim Y As Decimal = 0

        Dim MX As Decimal = 75
        Dim _MY As Decimal = 45

        Dim LstTiposEstoques As New ListBox

        For Each row In BuscaEstoques.ToList

            TrEstoque.Nodes.Add(row.NomeEstoque)

            'insere valores

            TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes.Add(row.IdEstoque)

            TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes.Add(X)
            TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes.Add(Y)

            TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes.Add(row.TipoEstoque)
            TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes.Add("Quadras")

            Dim BuscaQuadra = From est In LqEstoque.QuadrasEstoqueLocal
                              Where est.IdEstoque = row.IdEstoque
                              Select est.IdQuadra, est.NomeQuadra

            Dim TrQuadras As TreeNode = TrEstoque.Nodes(TrEstoque.Nodes.Count - 1).Nodes(4)

            Dim X1 As Decimal = 115

            For Each row1 In BuscaQuadra.ToList

                TrQuadras.Nodes.Add(row1.NomeQuadra)

                TrQuadras.Nodes(TrQuadras.Nodes.Count - 1).Nodes.Add(row1.IdQuadra)
                TrQuadras.Nodes(TrQuadras.Nodes.Count - 1).Nodes.Add(X1)
                TrQuadras.Nodes(TrQuadras.Nodes.Count - 1).Nodes.Add(Y)

                TrQuadras.Nodes(TrQuadras.Nodes.Count - 1).Nodes.Add("Quadras")

                'busca rua

                Dim BuscaRua = From est In LqEstoque.RuasEstoqueLocal
                               Where est.IdQuadra = row1.IdQuadra
                               Select est.IdRua, est.NomeRua

                Dim TrRua As TreeNode = TrQuadras.Nodes(TrQuadras.Nodes.Count - 1).Nodes(3)

                Dim X2 As Decimal = 115

                For Each row2 In BuscaRua.ToList

                    TrRua.Nodes.Add(row2.NomeRua)

                    TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add(row2.IdRua)

                    TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add(X2)
                    TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add(Y)

                    TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes.Add("Predios")

                    'busca Predio

                    Dim BuscaPredio = From est In LqEstoque.PredioEstoqueLocal
                                      Where est.IdRua = row2.IdRua
                                      Select est.IdPredio, est.NomePredio

                    Dim TrPredio As TreeNode = TrRua.Nodes(TrRua.Nodes.Count - 1).Nodes(3)

                    Dim X3 As Decimal = 115

                    For Each row3 In BuscaPredio.ToList

                        TrPredio.Nodes.Add(row3.NomePredio)

                        TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add(row3.IdPredio)

                        TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add(X3)
                        TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add(Y)

                        TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes.Add("Andares")

                        'busca Andar

                        Dim BuscaAndar = From est In LqEstoque.AndarEstoqueLocal
                                         Where est.IdPredio = row3.IdPredio
                                         Select est.IdAndar, est.NomeAndar

                        Dim TrAndar As TreeNode = TrPredio.Nodes(TrPredio.Nodes.Count - 1).Nodes(3)

                        Dim X4 As Decimal = 115

                        For Each row4 In BuscaAndar.ToList

                            TrAndar.Nodes.Add(row4.NomeAndar)

                            TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add(row4.IdAndar)

                            TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add(X4)
                            TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add(Y)

                            TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes.Add("Endereços")

                            'busca Andar

                            Dim BuscaEndereõ = From est In LqEstoque.EnderecoEstoqueLocal
                                               Where est.IdAndar = row4.IdAndar
                                               Select est.IdEndereco, est.NomeEndereco, est.Altura, est.Largura, est.Profundidade, est.Peso

                            Dim TrEndereço As TreeNode = TrAndar.Nodes(TrAndar.Nodes.Count - 1).Nodes(3)

                            Dim x5 As Decimal = 115

                            For Each row5 In BuscaEndereõ.ToList

                                TrEndereço.Nodes.Add(row5.NomeEndereco)

                                TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes.Add(row5.IdEndereco)
                                TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes.Add(x5)
                                TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes.Add(Y)
                                TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes.Add("Armazenagem")

                                Dim TrArmazenado As TreeNode = TrEndereço.Nodes(TrEndereço.Nodes.Count - 1).Nodes(3)

                                TrArmazenado.Nodes.Add(row5.Altura)
                                TrArmazenado.Nodes.Add(row5.Largura)
                                TrArmazenado.Nodes.Add(row5.Profundidade)
                                TrArmazenado.Nodes.Add(row5.Peso)
                                TrArmazenado.Nodes.Add("Item armazenado")

                                Dim TrItemArmazenado As TreeNode = TrArmazenado.Nodes(4)

                                'busca detalhes do armazenamento

                                Dim BuscaArmazenagem = From arm In LqEstoque.Armazenagem
                                                       Where arm.Endereco Like row5.IdEndereco
                                                       Select arm.IdProduto, arm.Qt

                                If BuscaArmazenagem.Count > 0 Then

                                    TrItemArmazenado.Nodes.Add(BuscaArmazenagem.First.IdProduto)
                                    TrItemArmazenado.Nodes.Add(BuscaArmazenagem.First.Qt)

                                    'busca dados do produto

                                    Dim BusaProduto = From prod In LqBase.Produtos
                                                      Where prod.IdProduto = BuscaArmazenagem.First.IdProduto
                                                      Select prod.Altura, prod.Largura, prod.Profundidade, prod.Peso

                                    TrItemArmazenado.Nodes.Add(BusaProduto.First.Altura)
                                    TrItemArmazenado.Nodes.Add(BusaProduto.First.Largura)
                                    TrItemArmazenado.Nodes.Add(BusaProduto.First.Profundidade)
                                    TrItemArmazenado.Nodes.Add(BusaProduto.First.Peso)

                                Else

                                    TrItemArmazenado.Nodes.Add(0)
                                    TrItemArmazenado.Nodes.Add(0)
                                    TrItemArmazenado.Nodes.Add(0)
                                    TrItemArmazenado.Nodes.Add(0)
                                    TrItemArmazenado.Nodes.Add(0)
                                    TrItemArmazenado.Nodes.Add(0)

                                End If

                                x5 += 210

                            Next

                            X4 += 210

                        Next

                        X3 += 210

                    Next

                    X2 += 210

                Next

                X1 += 210

            Next

            Y = 0
            X += 210

            If MX < X Then

                MX = X

            End If

        Next

        Dim X_Integer As Integer = MX
        Dim Y_Integer As Integer = 100

        Dim PintarBitmap1 = New Bitmap(X_Integer, Y_Integer)

        Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

        'pinta moldura do estoque

        'Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 103, 20, X_Integer - 10, 20)
        Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

        Pintura1.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

        For Each row As TreeNode In TrEstoque.Nodes

            'pinta estoque encontrado

            Dim XLido_0 As Decimal = row.Nodes(1).Text
            Dim YLido_0 As Decimal = row.Nodes(2).Text

            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_0, YLido_0, 200, 95)
            Pintura1.DrawString(row.Nodes(0).Text & "." & row.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_0, YLido_0 + 5)
            Pintura1.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_0, YLido_0 + 23, 95, 1)

            '

            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_0 + 180, YLido_0 + 30, 17, 10)
            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_0 + 180, YLido_0 + 30 + (12 * 1), 17, 10)
            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_0 + 180, YLido_0 + 30 + (12 * 2), 17, 10)
            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_0 + 180, YLido_0 + 30 + (12 * 3), 17, 10)
            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)

            Pintura1.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_0 + 23, YLido_0 + 5 + 22)



            Dim PesoArm As Decimal = 0

            Dim AlturaArm As Decimal = 0
            Dim LarguraArm As Decimal = 0
            Dim ProfundidadeArm As Decimal = 0

            Dim TT As Decimal = 0

            Dim CalculaUsado As Decimal = 0

            'varre totais
            For Each row1 As TreeNode In row.Nodes(4).Nodes
                For Each row2 As TreeNode In row1.Nodes(3).Nodes
                    For Each row3 As TreeNode In row2.Nodes(3).Nodes
                        For Each row4 As TreeNode In row3.Nodes(3).Nodes
                            For Each row5 As TreeNode In row4.Nodes(3).Nodes

                                AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                                LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                                ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                                PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                                Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                                TT += TotalM3

                                Dim AlturaIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(2).Text
                                Dim LarguraIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(3).Text
                                Dim ProfundidadeIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(4).Text
                                Dim Qt As Integer = row5.Nodes(3).Nodes(4).Nodes(1).Text

                                Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                                    CalculaUsado += M3

                            Next
                        Next
                    Next
                Next
            Next

            'calcula a quantidade ocupada do endereço

            Dim PCTG As Decimal = 0

            Try

                PCTG = (CalculaUsado * 100) / TT

            Catch ex As Exception

            End Try

            'verifica

            If PCTG > 0 And PCTG < 20 Then

                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)

            ElseIf PCTG >= 20 And PCTG < 40 Then

                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 3), 17, 10)

            ElseIf PCTG >= 40 And PCTG < 60 Then

                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 3), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_0 + 180, YLido_0 + 30 + (12 * 2), 17, 10)

            ElseIf PCTG >= 60 And PCTG < 80 Then

                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 3), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_0 + 180, YLido_0 + 30 + (12 * 2), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_0 + 180, YLido_0 + 30 + (12 * 1), 17, 10)

            ElseIf PCTG >= 80 And PCTG < 101 Then

                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 4), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_0 + 180, YLido_0 + 30 + (12 * 3), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_0 + 180, YLido_0 + 30 + (12 * 2), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_0 + 180, YLido_0 + 30 + (12 * 1), 17, 10)
                Pintura1.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_0 + 180, YLido_0 + 30, 17, 10)

            End If


            Pintura1.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_0 + 23, YLido_0 + 5 + (3 * 17))
            Pintura1.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_0 + 23, YLido_0 + 5 + (4 * 17))

            'insere botões de ações

            Pintura1.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_0 + 20, YLido_0 + 20, 1, 80)
                Pintura1.DrawImage(My.Resources.add_1_icon, XLido_0 + 3, YLido_0 + 30, 12, 12)

            Next

            PicEstoque.BackgroundImage = PintarBitmap1

        PicEstoque.Size = New Size(X_Integer, Y_Integer)

    End Sub
    Private Sub FrmEstoquesLocais_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PIntaEstoques()

    End Sub

    Private Sub PicEstoque_Click(sender As Object, e As EventArgs) Handles PicEstoque.Click

    End Sub

    Private Sub PicEstoque_MouseClick(sender As Object, e As MouseEventArgs) Handles PicEstoque.MouseClick

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                If Application.OpenForms.OfType(Of FrmNovoEstoqueLocal)().Count = 0 Then
                    FrmNovoEstoqueLocal.Show(Me)
                End If

            End If

            End If

        If Application.OpenForms.OfType(Of FrmNovoEstoqueLocal)().Count = 0 And e.X > 80 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicEstoque.Width, PicEstoque.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            For Each row As TreeNode In TrEstoque.Nodes

                'pinta estoque encontrado

                Dim XLido_0 As Decimal = row.Nodes(1).Text
                Dim YLido_0 As Decimal = row.Nodes(2).Text

                'verifica se existe algo para seleccionar

                If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                    If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                        'FrmQuadrasEstoqueLocal.IdEstoque = row.Nodes(0).Text

                        If Application.OpenForms.OfType(Of FrmQuadrasEstoqueLocal)().Count = 0 Then
                            FrmQuadrasEstoqueLocal.Show(Me)
                        End If

                    End If

                End If

                'verifica se painel pode ser seleccionado

                If e.X >= XLido_0 And e.X < XLido_0 + 200 Then

                    If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                        Parent = row.Index

                        _IdEstoqueGeral = row.Nodes(0).Text

                        Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                        For Each row1 As TreeNode In row.Nodes(4).Nodes

                            'pinta estoque encontrado

                            Dim XLido_1 As Decimal = row1.Nodes(1).Text
                            Dim YLido_1 As Decimal = row1.Nodes(2).Text

                            X_Integer = XLido_1 + 210

                        Next

                    End If

                End If

            Next

            TrEstoque.SelectedNode = TrEstoque.Nodes(Parent)

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicQ.Size = New Size(X_Integer, Y_Integer)


            Dim PintarBitmap = New Bitmap(PicQ.Width, PicQ.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

            'pinta selecionado

            For Each row1 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes

                'pinta estoque encontrado

                Dim XLido_1 As Decimal = row1.Nodes(1).Text
                Dim YLido_1 As Decimal = row1.Nodes(2).Text

                Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                Pintura.DrawString(row1.Nodes(0).Text & "." & row1.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                '

                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)

                Dim PesoArm As Decimal = 0

                Dim AlturaArm As Decimal = 0
                Dim LarguraArm As Decimal = 0
                Dim ProfundidadeArm As Decimal = 0

                Dim TT As Decimal = 0

                Dim CalculaUsado As Decimal = 0

                'varre totais
                For Each row2 As TreeNode In row1.Nodes(3).Nodes
                    For Each row3 As TreeNode In row2.Nodes(3).Nodes
                        For Each row4 As TreeNode In row3.Nodes(3).Nodes
                            For Each row5 As TreeNode In row4.Nodes(3).Nodes

                                AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                                LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                                ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                                PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                                Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                                TT += TotalM3

                                Dim AlturaIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(2).Text
                                Dim LarguraIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(3).Text
                                Dim ProfundidadeIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(4).Text
                                Dim Qt As Integer = row5.Nodes(3).Nodes(4).Nodes(1).Text

                                Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                                CalculaUsado += M3

                            Next
                        Next
                    Next
                Next

                'calcula a quantidade ocupada do endereço

                Dim PCTG As Decimal = 0

                Try

                    PCTG = (CalculaUsado * 100) / TT

                Catch ex As Exception

                End Try

                'verifica

                If PCTG > 0 And PCTG < 20 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                ElseIf PCTG >= 20 And PCTG < 40 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)

                ElseIf PCTG >= 40 And PCTG < 60 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)

                ElseIf PCTG >= 60 And PCTG < 80 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)

                ElseIf PCTG >= 80 And PCTG < 101 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_1 + 180, YLido_1 + 30, 17, 10)

                End If

                Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next


                PicEstoque.Image = Nothing

            PicQ.Image = Nothing

            PicRuas.Image = Nothing

            PicPredios.Image = Nothing

            PicAndares.Image = Nothing

            PicEndereços.Image = Nothing

            '
            PicRuas.BackgroundImage = Nothing

            PicPredios.BackgroundImage = Nothing

            PicAndares.BackgroundImage = Nothing

            PicEndereços.BackgroundImage = Nothing

            '
            PicEstoque.Image = PintarBitmap1

            PicQ.BackgroundImage = PintarBitmap

            PicQ.Image = Nothing

        End If

    End Sub

    Public Sub DesenhaQuadras()

        Dim X_Integer As Integer
        Dim Y_Integer As Integer = 100

        Dim PintarBitmap1 = New Bitmap(PicEstoque.Width, PicEstoque.Height)

        Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

        'verifica se existe no treeview

        For Each row As TreeNode In TrEstoque.Nodes

            'pinta estoque encontrado

            Dim XLido_0 As Decimal = row.Nodes(1).Text
            Dim YLido_0 As Decimal = row.Nodes(2).Text

            'verifica se painel pode ser seleccionado

            If row.Nodes(0).Text = _IdEstoqueGeral Then

                Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                For Each row1 As TreeNode In row.Nodes(4).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row1.Nodes(1).Text
                    Dim YLido_1 As Decimal = row1.Nodes(2).Text

                    X_Integer = XLido_1 + 210

                Next

            End If


        Next

        If X_Integer = 0 Then
            X_Integer = 100
        End If

        PicQ.Size = New Size(X_Integer, Y_Integer)


        Dim PintarBitmap = New Bitmap(PicQ.Width, PicQ.Height)

        Dim Pintura = Graphics.FromImage(PintarBitmap)

        'procura todos as quadras

        'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

        Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

        'pinta selecionado

        For Each row1 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes

            'pinta estoque encontrado

            Dim XLido_1 As Decimal = row1.Nodes(1).Text
            Dim YLido_1 As Decimal = row1.Nodes(2).Text

            Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
            Pintura.DrawString(row1.Nodes(0).Text & "." & row1.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
            Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

            '

            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
            Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

            Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)



            Dim PesoArm As Decimal = 0

            Dim AlturaArm As Decimal = 0
            Dim LarguraArm As Decimal = 0
            Dim ProfundidadeArm As Decimal = 0

            Dim TT As Decimal = 0

            'varre totais
            For Each row2 As TreeNode In row1.Nodes(3).Nodes
                For Each row3 As TreeNode In row2.Nodes(3).Nodes
                    For Each row4 As TreeNode In row3.Nodes(3).Nodes
                        For Each row5 As TreeNode In row4.Nodes(3).Nodes

                            AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                            LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                            ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                            PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                            Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                            TT += TotalM3

                        Next
                    Next
                Next
            Next

            Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
            Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

            'insere botões de ações

            Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
            Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

            X_Integer = XLido_1 + 210

        Next


        PicQ.Image = Nothing

        PicRuas.Image = Nothing

        PicPredios.Image = Nothing

        PicAndares.Image = Nothing

        PicEndereços.Image = Nothing

        '
        PicRuas.BackgroundImage = Nothing

        PicPredios.BackgroundImage = Nothing

        PicAndares.BackgroundImage = Nothing

        PicEndereços.BackgroundImage = Nothing

        '
        PicEstoque.Image = PintarBitmap1

        PicQ.BackgroundImage = PintarBitmap

        PicQ.Image = Nothing


    End Sub
    Public Sub DesenhaRuas()

        Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicQ.Width, PicQ.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Desenha As Boolean = False

            'verifica se existe no treeview

            For Each row As TreeNode In TrEstoque.Nodes

                For Each row1 As TreeNode In row.Nodes(4).Nodes

                    If row.Nodes(0).Text = _IdEstoqueGeral Then

                        'pinta estoque encontrado

                        Dim XLido_0 As Decimal = row1.Nodes(1).Text
                        Dim YLido_0 As Decimal = row1.Nodes(2).Text

                    'verifica se existe algo para seleccionar

                    If row1.Nodes(0).Text = _IdQuadraGeral Then

                        _IdQuadraGeral = row1.Nodes(0).Text

                            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                            Parent1 = row1.Index

                            For Each row2 As TreeNode In row1.Nodes(3).Nodes

                                'pinta estoque encontrado

                                Dim XLido_1 As Decimal = row2.Nodes(1).Text
                                Dim YLido_1 As Decimal = row2.Nodes(2).Text

                                X_Integer = XLido_1 + 210

                            Next


                        End If

                End If

                Next
            Next

            TrEstoque.SelectedNode = TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1)

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicRuas.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicRuas.Width, PicRuas.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

            'pinta selecionado

            For Each row2 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes

                'pinta estoque encontrado

                Dim XLido_1 As Decimal = row2.Nodes(1).Text
                Dim YLido_1 As Decimal = row2.Nodes(2).Text

                Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                Pintura.DrawString(row2.Nodes(0).Text & "." & row2.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                '

                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)


                Dim PesoArm As Decimal = 0

                Dim AlturaArm As Decimal = 0
                Dim LarguraArm As Decimal = 0
                Dim ProfundidadeArm As Decimal = 0

                Dim TT As Decimal = 0

                'varre totais

                For Each row3 As TreeNode In row2.Nodes(3).Nodes
                    For Each row4 As TreeNode In row3.Nodes(3).Nodes
                        For Each row5 As TreeNode In row4.Nodes(3).Nodes

                            AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                            LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                            ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                            PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                            Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                            TT += TotalM3

                        Next
                    Next
                Next

                Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                'insere botões de ações

                Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                X_Integer = XLido_1 + 210

            Next

            PicQ.Image = Nothing

            PicRuas.Image = Nothing

            PicPredios.Image = Nothing

            PicAndares.Image = Nothing

            PicEndereços.Image = Nothing

            '
            PicPredios.BackgroundImage = Nothing

            PicAndares.BackgroundImage = Nothing

            PicEndereços.BackgroundImage = Nothing

            PicQ.Image = PintarBitmap1

            '
            PicRuas.BackgroundImage = PintarBitmap

            PicRuas.Image = Nothing

    End Sub
    Public Sub DesenhaPredios()

        Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicQ.Width, PicQ.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Desenha As Boolean = False

            'verifica se existe no treeview

            For Each row2 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row2.Nodes(1).Text
                    Dim YLido_0 As Decimal = row2.Nodes(2).Text

                'verifica se painel pode ser seleccionado

                If _IdRuaGeral = row2.Nodes(0).Text Then

                    _IdRuaGeral = row2.Nodes(0).Text

                    Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                    Parent2 = row2.Index

                    Desenha = True

                    For Each row3 As TreeNode In row2.Nodes(3).Nodes

                        'pinta estoque encontrado

                        Dim XLido_1 As Decimal = row3.Nodes(1).Text
                        Dim YLido_1 As Decimal = row3.Nodes(2).Text

                        X_Integer = XLido_1 + 210

                    Next

                End If

            End If

            Next

            TrEstoque.SelectedNode = TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2)

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicPredios.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicPredios.Width, PicPredios.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row3.Nodes(1).Text
                    Dim YLido_1 As Decimal = row3.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row3.Nodes(0).Text & "." & row3.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)


                    Dim PesoArm As Decimal = 0

                    Dim AlturaArm As Decimal = 0
                    Dim LarguraArm As Decimal = 0
                    Dim ProfundidadeArm As Decimal = 0

                    Dim TT As Decimal = 0

                    'varre totais

                    For Each row4 As TreeNode In row3.Nodes(3).Nodes
                        For Each row5 As TreeNode In row4.Nodes(3).Nodes

                            AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                            LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                            ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                            PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                            Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                            TT += TotalM3

                        Next
                    Next

                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

                PicPredios.Image = Nothing

                PicAndares.Image = Nothing

                PicEndereços.Image = Nothing

                '

                PicAndares.BackgroundImage = Nothing

                PicEndereços.BackgroundImage = Nothing

                '

                PicRuas.Image = PintarBitmap1

                PicPredios.BackgroundImage = PintarBitmap

                PicPredios.Image = Nothing

            End If

    End Sub
    Public Sub DesenhaAndares()

        Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicPredios.Width, PicPredios.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            Dim Desenha As Boolean = False

            For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row3.Nodes(1).Text
                    Dim YLido_0 As Decimal = row3.Nodes(2).Text

                'verifica se existe algo para seleccionar

                If row3.Nodes(0).Text = _IdPredioGeral Then

                    _IdPredioGeral = row3.Nodes(0).Text

                    Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                    Parent3 = row3.Index

                    Desenha = True

                    For Each row4 As TreeNode In row3.Nodes(3).Nodes

                        'pinta estoque encontrado

                        Dim XLido_1 As Decimal = row4.Nodes(1).Text
                        Dim YLido_1 As Decimal = row4.Nodes(2).Text

                        X_Integer = XLido_1 + 210

                    Next

                End If

            End If

            Next

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicAndares.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicAndares.Width, PicAndares.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row3.Nodes(1).Text
                    Dim YLido_1 As Decimal = row3.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row3.Nodes(0).Text & "." & row3.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)

                    'faz calculo de capacidade de armazenagem

                    Dim PesoArm As Decimal = 0

                    Dim AlturaArm As Decimal = 0
                    Dim LarguraArm As Decimal = 0
                    Dim ProfundidadeArm As Decimal = 0

                    Dim TT As Decimal = 0

                    'varre totais

                    For Each row4 As TreeNode In row3.Nodes(3).Nodes

                        AlturaArm = row4.Nodes(3).Nodes(0).Text / 1000
                        LarguraArm = row4.Nodes(3).Nodes(1).Text / 1000
                        ProfundidadeArm = row4.Nodes(3).Nodes(2).Text / 1000
                        PesoArm += row4.Nodes(3).Nodes(3).Text / 1000

                        Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                        TT += TotalM3

                    Next

                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

            End If

            PicPredios.Image = Nothing

            PicAndares.Image = Nothing

            PicEndereços.Image = Nothing

            '

            PicEndereços.BackgroundImage = Nothing

            '

            PicPredios.Image = PintarBitmap1

            PicAndares.BackgroundImage = PintarBitmap

            PicAndares.Image = Nothing


    End Sub
    Public Sub DesenhaEnderecos()

        Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicAndares.Width, PicAndares.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            Dim Desenha As Boolean = False

            For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row3.Nodes(1).Text
                    Dim YLido_0 As Decimal = row3.Nodes(2).Text

                'verifica se painel pode ser seleccionado

                If row3.Nodes(0).Text = _IdAndarGeral Then

                    _IdAndarGeral = row3.Nodes(0).Text

                    Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                        Parent4 = row3.Index

                        Desenha = True

                        For Each row4 As TreeNode In row3.Nodes(3).Nodes

                            'pinta estoque encontrado

                            Dim XLido_1 As Decimal = row4.Nodes(1).Text
                            Dim YLido_1 As Decimal = row4.Nodes(2).Text

                            X_Integer = XLido_1 + 210

                        Next

                End If

            End If

            Next

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicEndereços.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicEndereços.Width, PicEndereços.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row4 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes(Parent4).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row4.Nodes(1).Text
                    Dim YLido_1 As Decimal = row4.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row4.Nodes(0).Text & "." & row4.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)

                'faz calculo de capacidade de armazenagem

                Dim PesoArm As Decimal = row4.Nodes(3).Nodes(3).Text / 1000

                Dim AlturaArm As Decimal = row4.Nodes(3).Nodes(0).Text / 1000
                    Dim LarguraaArm As Decimal = row4.Nodes(3).Nodes(1).Text / 1000
                    Dim ProfundidadeArm As Decimal = row4.Nodes(3).Nodes(2).Text / 1000

                    Dim TotalM3 As Decimal = (((AlturaArm * LarguraaArm) * ProfundidadeArm))

                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TotalM3, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

            PicEndereços.Image = Nothing

            PicAndares.Image = PintarBitmap1

                PicEndereços.BackgroundImage = PintarBitmap

                PicEndereços.Image = Nothing

            End If

    End Sub
    Private Sub PicEstoque_MouseMove(sender As Object, e As MouseEventArgs) Handles PicEstoque.MouseMove

        'LblTitulo.Text = "Estoques " & e.X & " x " & e.Y

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                Me.Cursor = Cursors.Hand

            Else

                Me.Cursor = Cursors.Arrow

            End If

        Else

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub PicQ_Click(sender As Object, e As EventArgs) Handles PicQ.Click

    End Sub

    Dim Parent As Integer
    Dim Parent1 As Integer

    Dim _IdEstoqueGeral As Integer
    Dim _IdQuadraGeral As Integer
    Dim _IdRuaGeral As Integer
    Dim _IdPredioGeral As Integer
    Dim _IdAndarGeral As Integer
    Dim _IdEndereçoGeral As Integer

    Private Sub PicQ_MouseClick(sender As Object, e As MouseEventArgs) Handles PicQ.MouseClick

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                'FrmQuadrasEstoqueLocal.IdEstoque = _IdEstoqueGeral

                If Application.OpenForms.OfType(Of FrmQuadrasEstoqueLocal)().Count = 0 Then
                    FrmQuadrasEstoqueLocal.Show(Me)
                End If

            End If

            End If

        If Application.OpenForms.OfType(Of FrmQuadrasEstoqueLocal)().Count = 0 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicQ.Width, PicQ.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Desenha As Boolean = False

            'verifica se existe no treeview

            For Each row As TreeNode In TrEstoque.Nodes

                For Each row1 As TreeNode In row.Nodes(4).Nodes

                    If row.Nodes(0).Text = _IdEstoqueGeral Then

                        'pinta estoque encontrado

                        Dim XLido_0 As Decimal = row1.Nodes(1).Text
                        Dim YLido_0 As Decimal = row1.Nodes(2).Text

                        'verifica se existe algo para seleccionar

                        If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                            If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                                FrmNovaRua.IdEstoque = row.Nodes(0).Text
                                FrmNovaRua.IdQuadra = row1.Nodes(0).Text

                                If Application.OpenForms.OfType(Of FrmNovaRua)().Count = 0 Then
                                    FrmNovaRua.Show(Me)
                                End If

                            End If

                        End If

                        'verifica se painel pode ser seleccionado

                        If e.X >= XLido_0 And e.X <= XLido_0 + 200 Then

                            If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                                _IdQuadraGeral = row1.Nodes(0).Text

                                Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                                Parent1 = row1.Index

                                For Each row2 As TreeNode In row1.Nodes(3).Nodes

                                    'pinta estoque encontrado

                                    Dim XLido_1 As Decimal = row2.Nodes(1).Text
                                    Dim YLido_1 As Decimal = row2.Nodes(2).Text

                                    X_Integer = XLido_1 + 210

                                Next

                            End If

                        End If

                    End If

                Next
            Next


            'calcula a quantidade ocupada do endereço

            Dim PCTG As Decimal = 0

            TrEstoque.SelectedNode = TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1)

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicRuas.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicRuas.Width, PicRuas.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

            'pinta selecionado

            For Each row2 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes

                'pinta estoque encontrado

                Dim XLido_1 As Decimal = row2.Nodes(1).Text
                Dim YLido_1 As Decimal = row2.Nodes(2).Text

                Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                Pintura.DrawString(row2.Nodes(0).Text & "." & row2.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                '

                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)


                Dim PesoArm As Decimal = 0

                Dim AlturaArm As Decimal = 0
                Dim LarguraArm As Decimal = 0
                Dim ProfundidadeArm As Decimal = 0

                Dim TT As Decimal = 0

                Dim CalculaUsado As Decimal = 0

                'varre totais

                For Each row3 As TreeNode In row2.Nodes(3).Nodes
                    For Each row4 As TreeNode In row3.Nodes(3).Nodes
                        For Each row5 As TreeNode In row4.Nodes(3).Nodes

                            AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                            LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                            ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                            PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                            Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                            TT += TotalM3

                            Dim AlturaIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(2).Text
                            Dim LarguraIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(3).Text
                            Dim ProfundidadeIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(4).Text
                            Dim Qt As Integer = row5.Nodes(3).Nodes(4).Nodes(1).Text

                            Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                            CalculaUsado += M3

                        Next
                    Next
                Next

                Try

                    PCTG = (CalculaUsado * 100) / TT

                Catch ex As Exception

                End Try

                'verifica

                If PCTG > 0 And PCTG < 20 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                ElseIf PCTG >= 20 And PCTG < 40 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)

                ElseIf PCTG >= 40 And PCTG < 60 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)

                ElseIf PCTG >= 60 And PCTG < 80 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)

                ElseIf PCTG >= 80 And PCTG < 101 Then

                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_1 + 180, YLido_1 + 30, 17, 10)

                End If

                Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                'insere botões de ações

                Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                X_Integer = XLido_1 + 210

            Next

            PicQ.Image = Nothing

            PicRuas.Image = Nothing

            PicPredios.Image = Nothing

            PicAndares.Image = Nothing

            PicEndereços.Image = Nothing

            '
            PicPredios.BackgroundImage = Nothing

            PicAndares.BackgroundImage = Nothing

            PicEndereços.BackgroundImage = Nothing

            PicQ.Image = PintarBitmap1

            '
            PicRuas.BackgroundImage = PintarBitmap

            PicRuas.Image = Nothing

        End If

    End Sub

    Private Sub PicRuas_Click(sender As Object, e As EventArgs) Handles PicRuas.Click

    End Sub

    Dim Parent2 As Integer

    Private Sub PicRuas_MouseClick(sender As Object, e As MouseEventArgs) Handles PicRuas.MouseClick

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                FrmNovaRua.IdEstoque = _IdEstoqueGeral
                FrmNovaRua.IdQuadra = _IdQuadraGeral

                If Application.OpenForms.OfType(Of FrmNovaRua)().Count = 0 Then
                    FrmNovaRua.Show(Me)
                End If

            End If

        End If


        If Application.OpenForms.OfType(Of FrmNovoPredioEstoqueLocal)().Count = 0 And e.X > 80 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicQ.Width, PicQ.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            Dim Desenha As Boolean = False

            'verifica se existe no treeview

            For Each row2 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row2.Nodes(1).Text
                    Dim YLido_0 As Decimal = row2.Nodes(2).Text

                    'verifica se existe algo para seleccionar

                    If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                        If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                            FrmNovoPredioEstoqueLocal.IdEstoque = TrEstoque.Nodes(Parent).Nodes(0).Text
                            FrmNovoPredioEstoqueLocal.IdRua = row2.Nodes(0).Text

                            If Application.OpenForms.OfType(Of FrmNovoPredioEstoqueLocal)().Count = 0 Then
                                FrmNovoPredioEstoqueLocal.Show(Me)
                            End If

                        End If

                    End If

                    TrEstoque.Visible = False

                    'verifica se painel pode ser seleccionado

                    If e.X >= XLido_0 And e.X <= XLido_0 + 200 Then

                        If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                            _IdRuaGeral = row2.Nodes(0).Text

                            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                            Parent2 = row2.Index

                            Desenha = True

                            For Each row3 As TreeNode In row2.Nodes(3).Nodes

                                'pinta estoque encontrado

                                Dim XLido_1 As Decimal = row3.Nodes(1).Text
                                Dim YLido_1 As Decimal = row3.Nodes(2).Text

                                X_Integer = XLido_1 + 210

                            Next

                        End If

                    End If

                End If

            Next

            TrEstoque.SelectedNode = TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2)

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicPredios.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicPredios.Width, PicPredios.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row3.Nodes(1).Text
                    Dim YLido_1 As Decimal = row3.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row3.Nodes(0).Text & "." & row3.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)


                    Dim PesoArm As Decimal = 0

                    Dim AlturaArm As Decimal = 0
                    Dim LarguraArm As Decimal = 0
                    Dim ProfundidadeArm As Decimal = 0

                    Dim TT As Decimal = 0

                    Dim CalculaUsado As Decimal = 0

                    'varre totais

                    For Each row4 As TreeNode In row3.Nodes(3).Nodes
                        For Each row5 As TreeNode In row4.Nodes(3).Nodes

                            AlturaArm = row5.Nodes(3).Nodes(0).Text / 1000
                            LarguraArm = row5.Nodes(3).Nodes(1).Text / 1000
                            ProfundidadeArm = row5.Nodes(3).Nodes(2).Text / 1000
                            PesoArm += row5.Nodes(3).Nodes(3).Text / 1000

                            Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                            TT += TotalM3


                            Dim AlturaIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(2).Text
                            Dim LarguraIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(3).Text
                            Dim ProfundidadeIt As Decimal = row5.Nodes(3).Nodes(4).Nodes(4).Text
                            Dim Qt As Integer = row5.Nodes(3).Nodes(4).Nodes(1).Text

                            Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                            CalculaUsado += M3

                        Next
                    Next

                    Dim PCTG As Decimal = 0

                    Try

                        PCTG = (CalculaUsado * 100) / TT

                    Catch ex As Exception

                    End Try

                    'verifica

                    If PCTG > 0 And PCTG < 20 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    ElseIf PCTG >= 20 And PCTG < 40 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)

                    ElseIf PCTG >= 40 And PCTG < 60 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)

                    ElseIf PCTG >= 60 And PCTG < 80 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)

                    ElseIf PCTG >= 80 And PCTG < 101 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_1 + 180, YLido_1 + 30, 17, 10)

                    End If

                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

                PicRuas.Image = Nothing

                PicPredios.Image = Nothing

                PicAndares.Image = Nothing

                PicEndereços.Image = Nothing

                '

                PicAndares.BackgroundImage = Nothing

                PicEndereços.BackgroundImage = Nothing

                '

                PicRuas.Image = PintarBitmap1

                PicPredios.BackgroundImage = PintarBitmap

                PicPredios.Image = Nothing

            End If

        End If

    End Sub

    Private Sub PicQuadras_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    Dim Parent3 As Integer

    Private Sub PicPredios_MouseClick(sender As Object, e As MouseEventArgs) Handles PicPredios.MouseClick

        Panel5.VerticalScroll.Value = Panel5.VerticalScroll.Maximum

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                FrmNovoPredioEstoqueLocal.IdRua = _IdRuaGeral
                FrmNovoPredioEstoqueLocal.IdEstoque = _IdEstoqueGeral

                If Application.OpenForms.OfType(Of FrmNovoPredioEstoqueLocal)().Count = 0 Then

                    FrmNovoPredioEstoqueLocal.Show(Me)

                End If

            End If

            End If

        If Application.OpenForms.OfType(Of FrmNovaRuaEstoque)().Count = 0 And e.X > 80 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicPredios.Width, PicPredios.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            Dim Desenha As Boolean = False

            For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row3.Nodes(1).Text
                    Dim YLido_0 As Decimal = row3.Nodes(2).Text

                    'verifica se existe algo para seleccionar

                    If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                        If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                            FrmNovoAndarEstoqueLocal.IdEstoque = TrEstoque.Nodes(Parent).Nodes(0).Text
                            'FrmNovoAndarEstoqueLocal.IdRua = row3.Nodes(0).Text

                            If Application.OpenForms.OfType(Of FrmNovoAndarEstoqueLocal)().Count = 0 Then
                                FrmNovoAndarEstoqueLocal.Show(Me)
                            End If

                        End If

                    End If

                    'verifica se painel pode ser seleccionado

                    If e.X >= XLido_0 And e.X <= XLido_0 + 200 Then

                        If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                            _IdPredioGeral = row3.Nodes(0).Text

                            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                            Parent3 = row3.Index

                            Desenha = True

                            For Each row4 As TreeNode In row3.Nodes(3).Nodes

                                'pinta estoque encontrado

                                Dim XLido_1 As Decimal = row4.Nodes(1).Text
                                Dim YLido_1 As Decimal = row4.Nodes(2).Text

                                X_Integer = XLido_1 + 210

                            Next

                        End If

                    End If

                End If

            Next

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicAndares.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicAndares.Width, PicAndares.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row3.Nodes(1).Text
                    Dim YLido_1 As Decimal = row3.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row3.Nodes(0).Text & "." & row3.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)

                    'faz calculo de capacidade de armazenagem

                    Dim PesoArm As Decimal = 0

                    Dim AlturaArm As Decimal = 0
                    Dim LarguraArm As Decimal = 0
                    Dim ProfundidadeArm As Decimal = 0

                    Dim TT As Decimal = 0

                    Dim CalculaUsado As Decimal = 0

                    'varre totais

                    For Each row4 As TreeNode In row3.Nodes(3).Nodes

                        AlturaArm = row4.Nodes(3).Nodes(0).Text / 1000
                        LarguraArm = row4.Nodes(3).Nodes(1).Text / 1000
                        ProfundidadeArm = row4.Nodes(3).Nodes(2).Text / 1000
                        PesoArm += row4.Nodes(3).Nodes(3).Text / 1000

                        Dim TotalM3 As Decimal = (((AlturaArm * LarguraArm) * ProfundidadeArm))

                        TT += TotalM3

                        Dim AlturaIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(2).Text
                        Dim LarguraIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(3).Text
                        Dim ProfundidadeIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(4).Text
                        Dim Qt As Integer = row4.Nodes(3).Nodes(4).Nodes(1).Text

                        Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                        CalculaUsado += M3

                    Next


                    Dim PCTG As Decimal = 0

                    Try

                        PCTG = (CalculaUsado * 100) / TT

                    Catch ex As Exception

                    End Try

                    'verifica

                    If PCTG > 0 And PCTG < 20 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    ElseIf PCTG >= 20 And PCTG < 40 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)

                    ElseIf PCTG >= 40 And PCTG < 60 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)

                    ElseIf PCTG >= 60 And PCTG < 80 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)

                    ElseIf PCTG >= 80 And PCTG < 101 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_1 + 180, YLido_1 + 30, 17, 10)

                    End If

                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TT, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

            End If

            PicPredios.Image = Nothing

            PicAndares.Image = Nothing

            PicEndereços.Image = Nothing

            '

            PicEndereços.BackgroundImage = Nothing

            '

            PicPredios.Image = PintarBitmap1

            PicAndares.BackgroundImage = PintarBitmap

            PicAndares.Image = Nothing

        End If

    End Sub

    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint

    End Sub

    Private Sub PicAndares_Click(sender As Object, e As EventArgs) Handles PicAndares.Click


    End Sub

    Private Sub PicPredios_Click(sender As Object, e As EventArgs) Handles PicPredios.Click

    End Sub

    Dim Parent4 As Integer

    Private Sub PicAndares_MouseClick(sender As Object, e As MouseEventArgs) Handles PicAndares.MouseClick

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                FrmNovoAndarEstoqueLocal.IdEstoque = _IdEstoqueGeral
                'FrmNovoAndarEstoqueLocal.IdRua = _IdPredioGeral

                If Application.OpenForms.OfType(Of FrmNovoAndarEstoqueLocal)().Count = 0 Then

                    FrmNovoAndarEstoqueLocal.Show(Me)

                End If

            End If

            End If

        If Application.OpenForms.OfType(Of FrmNovoAndarEstoqueLocal)().Count = 0 And e.X > 80 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicAndares.Width, PicAndares.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            Dim Desenha As Boolean = False

            For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row3.Nodes(1).Text
                    Dim YLido_0 As Decimal = row3.Nodes(2).Text

                    'verifica se existe algo para seleccionar

                    If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                        If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                            FrmNovoEnderecoEstoqueLocal.IdEstoque = TrEstoque.Nodes(Parent).Nodes(0).Text
                            'FrmNovoEnderecoEstoqueLocal.IdRua = row3.Nodes(0).Text

                            If Application.OpenForms.OfType(Of FrmNovoEnderecoEstoqueLocal)().Count = 0 Then
                                FrmNovoEnderecoEstoqueLocal.Show(Me)
                            End If

                        End If

                    End If

                    'verifica se painel pode ser seleccionado

                    If e.X >= XLido_0 And e.X <= XLido_0 + 200 Then

                        If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                            _IdAndarGeral = row3.Nodes(0).Text

                            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                            Parent4 = row3.Index

                            Desenha = True

                            For Each row4 As TreeNode In row3.Nodes(3).Nodes

                                'pinta estoque encontrado

                                Dim XLido_1 As Decimal = row4.Nodes(1).Text
                                Dim YLido_1 As Decimal = row4.Nodes(2).Text

                                X_Integer = XLido_1 + 210

                            Next

                        End If

                    End If

                End If

            Next

            If X_Integer = 0 Then
                X_Integer = 100
            End If

            PicEndereços.Size = New Size(X_Integer, Y_Integer)

            Dim PintarBitmap = New Bitmap(PicEndereços.Width, PicEndereços.Height)

            Dim Pintura = Graphics.FromImage(PintarBitmap)

            'procura todos as quadras

            'Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            If Desenha = True Then

                Pintura.DrawImage(My.Resources.add_1_icon, 30, 20, 50, 50)

                'pinta selecionado

                For Each row4 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes(Parent4).Nodes(3).Nodes

                    'pinta estoque encontrado

                    Dim XLido_1 As Decimal = row4.Nodes(1).Text
                    Dim YLido_1 As Decimal = row4.Nodes(2).Text

                    Pintura.FillRectangle(New SolidBrush(Color.Gainsboro), XLido_1, YLido_1, 200, 95)
                    Pintura.DrawString(row4.Nodes(0).Text & "." & row4.Text, New Font("Calibri", 10), New SolidBrush(Color.SlateGray), XLido_1, YLido_1 + 5)
                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1, YLido_1 + 23, 95, 1)

                    '

                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30, 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                    Pintura.DrawRectangle(New Pen(New SolidBrush(Color.Silver), 1), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    Pintura.DrawString(FormatPercent(0, NumDigitsAfterDecimal:=2), New Font("Calibri", 16), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + 22)

                    'faz calculo de capacidade de armazenagem

                    Dim PesoArm As Decimal = row4.Nodes(3).Nodes(3).Text / 1000

                    Dim AlturaArm As Decimal = row4.Nodes(3).Nodes(0).Text / 1000
                    Dim LarguraaArm As Decimal = row4.Nodes(3).Nodes(1).Text / 1000
                    Dim ProfundidadeArm As Decimal = row4.Nodes(3).Nodes(2).Text / 1000

                    Dim Calculausado As Decimal = 0

                    Dim AlturaIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(2).Text
                    Dim LarguraIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(3).Text
                    Dim ProfundidadeIt As Decimal = row4.Nodes(3).Nodes(4).Nodes(4).Text
                    Dim Qt As Integer = row4.Nodes(3).Nodes(4).Nodes(1).Text

                    Dim M3 As Decimal = (((AlturaIt / 1000) * (LarguraIt / 1000)) * (ProfundidadeIt / 1000)) * Qt

                    CalculaUsado += M3

                    Dim TotalM3 As Decimal = (((AlturaArm * LarguraaArm) * ProfundidadeArm))

                    Dim PCTG As Decimal = 0

                    Try

                        PCTG = (Calculausado * 100) / (TotalM3)

                    Catch ex As Exception

                    End Try

                    'verifica

                    If PCTG > 0 And PCTG < 20 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)

                    ElseIf PCTG >= 20 And PCTG < 40 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)

                    ElseIf PCTG >= 40 And PCTG < 60 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)

                    ElseIf PCTG >= 60 And PCTG < 80 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)

                    ElseIf PCTG >= 80 And PCTG < 101 Then

                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 4), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Green)), XLido_1 + 180, YLido_1 + 30 + (12 * 3), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 2), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Yellow)), XLido_1 + 180, YLido_1 + 30 + (12 * 1), 17, 10)
                        Pintura.FillRectangle(New SolidBrush(Color.FromArgb(150, Color.Red)), XLido_1 + 180, YLido_1 + 30, 17, 10)

                    End If
                    Pintura.DrawString("Capacidade (M3): " & FormatNumber(TotalM3, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (3 * 17))
                    Pintura.DrawString("Capacidade (TN): " & FormatNumber(PesoArm, NumDigitsAfterDecimal:=3), New Font("Calibri", 8), New SolidBrush(Color.SlateGray), XLido_1 + 23, YLido_1 + 5 + (4 * 17))

                    'insere botões de ações

                    Pintura.FillRectangle(New SolidBrush(Color.WhiteSmoke), XLido_1 + 20, YLido_1 + 20, 1, 80)
                    Pintura.DrawImage(My.Resources.add_1_icon, XLido_1 + 3, YLido_1 + 30, 12, 12)

                    X_Integer = XLido_1 + 210

                Next

                PicAndares.Image = Nothing
                PicEndereços.Image = Nothing

                PicAndares.Image = PintarBitmap1

                PicEndereços.BackgroundImage = PintarBitmap

                PicEndereços.Image = Nothing

            End If

        End If

    End Sub

    Private Sub PicEndereços_Click(sender As Object, e As EventArgs) Handles PicEndereços.Click

    End Sub

    Dim Parent5 As Integer

    Private Sub PicEndereços_MouseClick(sender As Object, e As MouseEventArgs) Handles PicEndereços.MouseClick

        If e.X >= 30 And e.X < 80 Then

            If e.Y >= 20 And e.Y <= 70 Then

                FrmNovoEnderecoEstoqueLocal.IdEstoque = _IdEstoqueGeral
                'FrmNovoEnderecoEstoqueLocal.IdRua = _IdAndarGeral

                If Application.OpenForms.OfType(Of FrmNovoEnderecoEstoqueLocal)().Count = 0 Then

                    FrmNovoEnderecoEstoqueLocal.Show(Me)

                End If

            End If

            End If

        If Application.OpenForms.OfType(Of FrmNovoEnderecoEstoqueLocal)().Count = 0 And e.X > 80 Then

            Dim X_Integer As Integer
            Dim Y_Integer As Integer = 100

            Dim PintarBitmap1 = New Bitmap(PicEndereços.Width, PicEndereços.Height)

            Dim Pintura1 = Graphics.FromImage(PintarBitmap1)

            'verifica se existe no treeview

            For Each row3 As TreeNode In TrEstoque.Nodes(Parent).Nodes(4).Nodes(Parent1).Nodes(3).Nodes(Parent2).Nodes(3).Nodes(Parent3).Nodes(3).Nodes(Parent4).Nodes(3).Nodes

                If TrEstoque.Nodes(Parent).Nodes(0).Text = _IdEstoqueGeral Then

                    'pinta estoque encontrado

                    Dim XLido_0 As Decimal = row3.Nodes(1).Text
                    Dim YLido_0 As Decimal = row3.Nodes(2).Text

                    'verifica se existe algo para seleccionar

                    If e.X >= XLido_0 + 3 And e.X < XLido_0 + 3 + 12 Then

                        If e.Y >= YLido_0 + 30 And e.Y <= YLido_0 + 30 + 12 Then

                            FrmNovoEnderecoEstoqueLocal.IdEstoque = TrEstoque.Nodes(Parent).Nodes(0).Text
                            'FrmNovoEnderecoEstoqueLocal.IdRua = row3.Nodes(0).Text

                            If Application.OpenForms.OfType(Of FrmNovoEnderecoEstoqueLocal)().Count = 0 Then
                                FrmNovoEnderecoEstoqueLocal.Show(Me)
                            End If

                        End If

                    End If

                    'verifica se painel pode ser seleccionado

                    If e.X >= XLido_0 And e.X <= XLido_0 + 200 Then

                        If e.Y >= YLido_0 And e.Y <= YLido_0 + 95 Then

                            Pintura1.DrawRectangle(New Pen(New SolidBrush(Color.SlateGray), 1), XLido_0, YLido_0, 200, 95)

                            Parent5 = row3.Index

                            For Each row4 As TreeNode In row3.Nodes(3).Nodes

                                'pinta estoque encontrado

                                'Dim XLido_1 As Decimal = row4.Nodes(1).Text
                                'Dim YLido_1 As Decimal = row4.Nodes(2).Text

                                'X_Integer = XLido_1 + 210

                            Next

                        End If

                    End If

                End If

            Next

            'procura todos as quadras

            Pintura1.FillRectangle(New SolidBrush(Color.Gainsboro), 110, 5, 1, 130)

            PicEndereços.Image = Nothing

            PicEndereços.Image = PintarBitmap1

        End If

    End Sub

    Private Sub Panel8_Paint(sender As Object, e As PaintEventArgs) Handles Panel8.Paint

    End Sub
End Class