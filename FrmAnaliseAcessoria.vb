Public Class FrmAnaliseAcessoria

    Public IdSetor As Integer

    Public Sub CarregaInicio()

        DtProdutos.Rows.Clear()

        Dim Lqtrabalhista As New LqTrabalhistaDataContext
        Lqtrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaRiscosSetor = From setor In Lqtrabalhista.RiscosSetores
                               Where setor.IdSetor = IdSetor
                               Select setor.IdRisco

        For Each row In BuscaRiscosSetor.ToList

            'busca o risco

            Dim BuscaRisco = From rsc In Lqtrabalhista.Riscos
                             Where rsc.IdRisco = row
                             Select rsc.Descricao

            DtProdutos.Rows.Add(row, BuscaRisco.First)

        Next

        PintaGrafico()

    End Sub
    Private Sub FrmAnaliseAcessoria_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CarregaInicio()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovoMapa.PintaSetores()

        Me.Cursor = Cursors.Arrow

        Me.Close()

    End Sub

    Public Sub PintaGrafico()

        Me.Cursor = Cursors.WaitCursor

        Dim LstTitulos As New ListBox
        Dim LstValores As New ListBox
        Dim LstPCtge As New ListBox

        LstTitulos.Items.Add(0)
        LstTitulos.Items.Add(1)
        LstTitulos.Items.Add(2)
        LstTitulos.Items.Add(3)
        LstTitulos.Items.Add(4)
        LstTitulos.Items.Add(5)
        LstTitulos.Items.Add(6)
        LstTitulos.Items.Add(7)
        LstTitulos.Items.Add(8)
        LstTitulos.Items.Add(9)
        LstTitulos.Items.Add(10)

        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)
        LstValores.Items.Add(0)

        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)
        LstPCtge.Items.Add(0)

        For Each row As DataGridViewRow In DtProdutos.Rows

            Dim Ind1 As String = row.Cells(2).Value
            If Ind1 <> "" Then
                LstValores.Items(1) += 1
            End If
            Dim Ind2 As String = row.Cells(3).Value
            If Ind2 <> "" Then
                LstValores.Items(2) += 1
            End If
            Dim Ind3 As String = row.Cells(4).Value
            If Ind3 <> "" Then
                LstValores.Items(3) += 1
            End If
            Dim Ind4 As String = row.Cells(5).Value
            If Ind4 <> "" Then
                LstValores.Items(4) += 1
            End If
            Dim Ind5 As String = row.Cells(6).Value
            If Ind5 <> "" Then
                LstValores.Items(5) += 1
            End If
            Dim Ind6 As String = row.Cells(7).Value
            If Ind6 <> "" Then
                LstValores.Items(6) += 1
            End If
            Dim Ind7 As String = row.Cells(8).Value
            If Ind7 <> "" Then
                LstValores.Items(7) += 1
            End If
            Dim Ind8 As String = row.Cells(9).Value
            If Ind8 <> "" Then
                LstValores.Items(8) += 1
            End If
            Dim Ind9 As String = row.Cells(10).Value
            If Ind9 <> "" Then
                LstValores.Items(9) += 1
            End If

        Next

        'cacula porcentagem dos items

        Dim TotalContado As Integer = 0

        For i As Integer = 0 To LstValores.Items.Count - 1 Step 1

            TotalContado += LstValores.Items(i)

        Next

        Dim It1 As Integer = LstValores.Items(1).ToString
        Dim It2 As Integer = LstValores.Items(2).ToString
        Dim It3 As Integer = LstValores.Items(3).ToString
        Dim It4 As Integer = LstValores.Items(4).ToString
        Dim It5 As Integer = LstValores.Items(5).ToString
        Dim It6 As Integer = LstValores.Items(6).ToString
        Dim It7 As Integer = LstValores.Items(7).ToString
        Dim It8 As Integer = LstValores.Items(8).ToString
        Dim It9 As Integer = LstValores.Items(9).ToString

        LstValores.Items(10) = TotalContado

        Dim Zoom_ As Decimal = (((DtProdutos.Rows.Count * 100) / 100)) / 100

        LstPCtge.Items(1) = ((It1 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(2) = ((It2 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(3) = ((It3 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(4) = ((It4 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(5) = ((It5 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(6) = ((It6 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(7) = ((It7 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(8) = ((It8 * 100) / TotalContado) * Zoom_
            LstPCtge.Items(9) = ((It9 * 100) / TotalContado) * Zoom_


        With Chart3

            .Series.Clear()

            .Series.Add("%")
            .Series.Add("Índices")

            .ChartAreas(0).Area3DStyle.Enable3D = True

            .ChartAreas(0).Area3DStyle.Inclination = 30
            .ChartAreas(0).Area3DStyle.Perspective = 0
            .ChartAreas(0).Area3DStyle.Rotation = 30
            .Legends(0).Docking = DataVisualization.Charting.Docking.Bottom
            .Legends(0).Alignment = StringAlignment.Far
            .Legends(0).BackColor = Color.WhiteSmoke
            .ChartAreas(0).BackColor = Color.Transparent


            .ChartAreas(0).AxisX.MajorGrid.LineColor = Color.SlateGray
            .ChartAreas(0).AxisX.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            .ChartAreas(0).AxisX.LineColor = Color.SlateGray
            .ChartAreas(0).AxisX.LabelStyle.ForeColor = Color.SlateGray
            .ChartAreas(0).AxisX.LabelStyle.Font = New Font("Calibri", 10, FontStyle.Bold)

            .ChartAreas(0).AxisX.Title = "Indicadores de risco"
            .ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Center
            .ChartAreas(0).AxisX.TitleFont = New Font("Calibri", 10, FontStyle.Bold)
            .ChartAreas(0).AxisX.TitleForeColor = Color.SlateGray

            .ChartAreas(0).AxisX.TextOrientation = DataVisualization.Charting.TextOrientation.Horizontal

            .ChartAreas(0).AxisY.MajorGrid.LineColor = Color.SlateGray
            .ChartAreas(0).AxisY.MajorGrid.LineDashStyle = DataVisualization.Charting.ChartDashStyle.Dot
            .ChartAreas(0).AxisY.LineColor = Color.SlateGray
            .ChartAreas(0).AxisY.LabelStyle.ForeColor = Color.SlateGray
            .ChartAreas(0).AxisY.LabelStyle.Font = New Font("Calibri", 10, FontStyle.Bold)
            .ChartAreas(0).AxisY.IsStartedFromZero = True

            '.ChartAreas(0).AxisY.Title = "Datas"
            '.ChartAreas(0).AxisY.TitleForeColor = Color.SlateGray
            '.ChartAreas(0).AxisY.TitleFont = New Font("Calibri", 8, FontStyle.Bold)

            .ChartAreas(0).AxisX.IsStartedFromZero = True
            .ChartAreas(0).AxisX.Minimum = 0
            .ChartAreas(0).AxisX.Maximum = 11
            .ChartAreas(0).AxisX.Interval = 1

            .ChartAreas(0).AxisY.Interval = 1
            .ChartAreas(0).AxisY.Minimum = 0
            If DtProdutos.Rows.Count < TotalContado Then
                .ChartAreas(0).AxisY.Maximum = TotalContado + 1
            Else
                .ChartAreas(0).AxisY.Maximum = DtProdutos.Rows.Count + 1
            End If


            For i As Integer = .Series.Count - 1 To 0 Step -1

                .Series(i).ChartType = DataVisualization.Charting.SeriesChartType.Column
                .Series(i).LabelForeColor = Color.SlateGray
                .Series(i).IsVisibleInLegend = True
                .Series(i).Points.Add(0)

            Next

            '.Series(0).Points.DataBindXY(LstEspera.Items, xEntradas2)1
            .Series(1).Points.DataBindXY(LstTitulos.Items, LstValores.Items)
            .Series(0).Points.DataBindXY(LstTitulos.Items, LstPCtge.Items)

            .Series(1).Points(1).Color = Color.FromArgb(180, Color.DarkOrange)
            .Series(0).Points(1).Label = LstPCtge.Items(1) * 100
            .Legends(1).CustomItems(0).Color = Color.FromArgb(220, Color.DarkOrange)
            .Series(1).Points(2).Color = Color.FromArgb(180, Color.DarkGreen)
            .Legends(1).CustomItems(1).Color = Color.FromArgb(220, Color.DarkGreen)
            .Series(1).Points(3).Color = Color.FromArgb(180, Color.DarkRed)
            .Legends(1).CustomItems(2).Color = Color.FromArgb(220, Color.DarkRed)
            .Series(1).Points(4).Color = Color.FromArgb(180, Color.Orange)
            .Legends(1).CustomItems(3).Color = Color.FromArgb(220, Color.Orange)
            .Series(1).Points(5).Color = Color.FromArgb(180, Color.Green)
            .Legends(1).CustomItems(4).Color = Color.FromArgb(220, Color.Green)
            .Series(1).Points(6).Color = Color.FromArgb(180, Color.Red)
            .Legends(1).CustomItems(5).Color = Color.FromArgb(220, Color.Red)
            .Series(1).Points(7).Color = Color.FromArgb(180, Color.LightYellow)
            .Legends(1).CustomItems(6).Color = Color.FromArgb(220, Color.LightYellow)
            .Series(1).Points(8).Color = Color.FromArgb(180, Color.LightGreen)
            .Legends(1).CustomItems(7).Color = Color.FromArgb(220, Color.LightGreen)
            .Series(1).Points(9).Color = Color.FromArgb(180, Color.LightCoral)
            .Legends(1).CustomItems(8).Color = Color.FromArgb(220, Color.LightCoral)
            .Series(1).Points(10).Color = Color.FromArgb(180, Color.Chocolate)
            .Legends(1).CustomItems(9).Color = Color.FromArgb(220, Color.Chocolate)

            .Series(0).IsValueShownAsLabel = True
            .Series(1).IsValueShownAsLabel = True

            .Series(0).Color = Color.FromArgb(255, Color.SlateGray)

            .Series(0).IsVisibleInLegend = True
            .Series(1).IsVisibleInLegend = True

        End With

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        Me.Cursor = Cursors.WaitCursor

        'salva os valores


        FrmNovoMapa.PintaSetores()

        Me.Close()

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

    End Sub

    Private Sub DtProdutos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellEndEdit
        PintaGrafico()
        If DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = 0 Then
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = ""
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.WhiteSmoke
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionBackColor = Color.Gainsboro
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = Color.DarkSlateGray
        Else
            'pinta a celula
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.OldLace
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionBackColor = Color.SlateGray
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = Color.WhiteSmoke
        End If

        For Each row As DataGridViewRow In DtProdutos.Rows
            If row.Cells(2).Value = "" Then
                row.Cells(2).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(2).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(3).Value = "" Then
                row.Cells(3).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(3).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(4).Value = "" Then
                row.Cells(4).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(4).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(5).Value = "" Then
                row.Cells(5).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(5).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(6).Value = "" Then
                row.Cells(6).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(6).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(7).Value = "" Then
                row.Cells(7).Style.SelectionBackColor = Color.Gainsboro
            End If
            If row.Cells(8).Value = "" Then
                row.Cells(8).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(8).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(9).Value = "" Then
                row.Cells(9).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(9).Style.SelectionBackColor = Color.SlateGray
            End If
            If row.Cells(10).Value = "" Then
                row.Cells(10).Style.SelectionBackColor = Color.Gainsboro
            Else
                row.Cells(10).Style.SelectionBackColor = Color.SlateGray
            End If
        Next
        PintaGrafico()

    End Sub

    Private Sub DtProdutos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellClick
        If e.ColumnIndex > 1 Then

            If DtProdutos.Rows(e.RowIndex).Cells(2).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(2).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(2).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(3).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(3).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(3).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(4).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(4).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(4).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(5).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(5).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(6).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(6).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(6).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(7).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(7).Style.SelectionBackColor = Color.Gainsboro
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(8).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(8).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(8).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(9).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(9).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(9).Style.SelectionBackColor = Color.SlateGray
            End If
            If DtProdutos.Rows(e.RowIndex).Cells(10).Value = "" Then
                DtProdutos.Rows(e.RowIndex).Cells(10).Style.SelectionBackColor = Color.Gainsboro
            Else
                DtProdutos.Rows(e.RowIndex).Cells(10).Style.SelectionBackColor = Color.SlateGray
            End If

            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionBackColor = Color.DarkSlateGray
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = Color.WhiteSmoke
        End If
    End Sub

    Private Sub DtProdutos_CancelRowEdit(sender As Object, e As QuestionEventArgs) Handles DtProdutos.CancelRowEdit

    End Sub

    Private Sub DtProdutos_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellEnter
        If e.ColumnIndex > 1 Then
            For Each row As DataGridViewRow In DtProdutos.Rows
                If row.Cells(2).Value = "" Then
                    row.Cells(2).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(2).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(3).Value = "" Then
                    row.Cells(3).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(3).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(4).Value = "" Then
                    row.Cells(4).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(4).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(5).Value = "" Then
                    row.Cells(5).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(5).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(6).Value = "" Then
                    row.Cells(6).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(6).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(7).Value = "" Then
                    row.Cells(7).Style.SelectionBackColor = Color.Gainsboro
                End If
                If row.Cells(8).Value = "" Then
                    row.Cells(8).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(8).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(9).Value = "" Then
                    row.Cells(9).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(9).Style.SelectionBackColor = Color.SlateGray
                End If
                If row.Cells(10).Value = "" Then
                    row.Cells(10).Style.SelectionBackColor = Color.Gainsboro
                Else
                    row.Cells(10).Style.SelectionBackColor = Color.SlateGray
                End If
            Next

            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionBackColor = Color.DarkSlateGray
            DtProdutos.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.SelectionForeColor = Color.WhiteSmoke
        End If

    End Sub
End Class