Public Class FrmApontamentosFinanceiros

    Dim MesReferencia As Integer = Today.Month
    Dim AnoReferencia As Integer = Today.Year
    Private Sub FrmApontamentosFinanceiros_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LstMeses As New ListBox

        LstMeses.Items.Add("Janeiro")
        LstMeses.Items.Add("Fevereiro")
        LstMeses.Items.Add("Março")
        LstMeses.Items.Add("Abril")
        LstMeses.Items.Add("Maio")
        LstMeses.Items.Add("Junho")
        LstMeses.Items.Add("Julho")
        LstMeses.Items.Add("Agosto")
        LstMeses.Items.Add("Setembro")
        LstMeses.Items.Add("Outubro")
        LstMeses.Items.Add("Novembro")
        LstMeses.Items.Add("Dezembro")

        If MesReferencia = 0 Then
            AnoReferencia -= 1
            MesReferencia = 12
        End If

        LblMesDescricao.Text = LstMeses.Items(MesReferencia - 1).ToString
        LblAno.Text = AnoReferencia

        ValidaInicio()

    End Sub

    Public Sub ValidaInicio()

        LblD1.Visible = False
        LblD2.Visible = False
        LblD3.Visible = False
        LblD4.Visible = False
        LblD5.Visible = False
        LblD6.Visible = False
        LblD7.Visible = False

        LblD8.Visible = False
        LblD9.Visible = False
        LblD10.Visible = False
        LblD11.Visible = False
        LblD12.Visible = False
        LblD13.Visible = False
        LblD14.Visible = False

        LblD15.Visible = False
        LblD16.Visible = False
        LblD17.Visible = False
        LblD18.Visible = False
        LblD19.Visible = False
        LblD20.Visible = False
        LblD21.Visible = False

        LblD22.Visible = False
        LblD23.Visible = False
        LblD24.Visible = False
        LblD25.Visible = False
        LblD26.Visible = False
        LblD27.Visible = False
        LblD28.Visible = False

        LblD29.Visible = False
        LblD30.Visible = False
        LblD31.Visible = False
        LblD32.Visible = False
        LblD33.Visible = False
        LblD34.Visible = False
        LblD35.Visible = False

        LblD36.Visible = False
        LblD37.Visible = False
        LblD38.Visible = False

        'verifica inicio do mes

        Dim InicioMes As Date = "01/" & MesReferencia & "/" & AnoReferencia
        Dim TerminoMes As Date = InicioMes.AddMonths(1)
        TerminoMes = TerminoMes.AddDays(-1)

        If InicioMes.DayOfWeek = 1 Then

            LblD2.Text = InicioMes.Day
            LblD3.Text = InicioMes.Day + 1
            LblD4.Text = InicioMes.Day + 2
            LblD5.Text = InicioMes.Day + 3
            LblD6.Text = InicioMes.Day + 4
            LblD7.Text = InicioMes.Day + 5
            LblD1.Visible = False
            LblD2.Visible = True
            LblD3.Visible = True
            LblD4.Visible = True
            LblD5.Visible = True
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 6
            LblD9.Text = InicioMes.Day + 7
            LblD10.Text = InicioMes.Day + 8
            LblD11.Text = InicioMes.Day + 9
            LblD12.Text = InicioMes.Day + 10
            LblD13.Text = InicioMes.Day + 11
            LblD14.Text = InicioMes.Day + 12
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 13
            LblD16.Text = InicioMes.Day + 14
            LblD17.Text = InicioMes.Day + 15
            LblD18.Text = InicioMes.Day + 16
            LblD19.Text = InicioMes.Day + 17
            LblD20.Text = InicioMes.Day + 19
            LblD21.Text = InicioMes.Day + 20
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 21
            LblD23.Text = InicioMes.Day + 22
            LblD24.Text = InicioMes.Day + 23
            LblD25.Text = InicioMes.Day + 24
            LblD26.Text = InicioMes.Day + 25
            LblD27.Text = InicioMes.Day + 26
            LblD28.Text = InicioMes.Day + 27
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD29.Text = InicioMes.Day + 28
                LblD29.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD30.Text = InicioMes.Day + 29
                LblD30.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD31.Text = InicioMes.Day + 30
                LblD31.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD32.Text = InicioMes.Day + 31
                LblD32.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 2 Then

            LblD3.Text = InicioMes.Day
            LblD4.Text = InicioMes.Day + 1
            LblD5.Text = InicioMes.Day + 2
            LblD6.Text = InicioMes.Day + 3
            LblD7.Text = InicioMes.Day + 4
            LblD1.Visible = False
            LblD2.Visible = False
            LblD3.Visible = True
            LblD4.Visible = True
            LblD5.Visible = True
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 5
            LblD9.Text = InicioMes.Day + 6
            LblD10.Text = InicioMes.Day + 7
            LblD11.Text = InicioMes.Day + 8
            LblD12.Text = InicioMes.Day + 9
            LblD13.Text = InicioMes.Day + 10
            LblD14.Text = InicioMes.Day + 11
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 12
            LblD16.Text = InicioMes.Day + 13
            LblD17.Text = InicioMes.Day + 14
            LblD18.Text = InicioMes.Day + 15
            LblD19.Text = InicioMes.Day + 16
            LblD20.Text = InicioMes.Day + 17
            LblD21.Text = InicioMes.Day + 18
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 19
            LblD23.Text = InicioMes.Day + 20
            LblD24.Text = InicioMes.Day + 21
            LblD25.Text = InicioMes.Day + 22
            LblD26.Text = InicioMes.Day + 23
            LblD27.Text = InicioMes.Day + 24
            LblD28.Text = InicioMes.Day + 25
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            LblD29.Text = InicioMes.Day + 26
            LblD30.Text = InicioMes.Day + 27
            LblD29.Visible = True
            LblD30.Visible = True

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD31.Text = InicioMes.Day + 28
                LblD31.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD32.Text = InicioMes.Day + 29
                LblD32.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD33.Text = InicioMes.Day + 30
                LblD33.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD34.Text = InicioMes.Day + 31
                LblD34.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 3 Then

            LblD4.Text = InicioMes.Day
            LblD5.Text = InicioMes.Day + 1
            LblD6.Text = InicioMes.Day + 2
            LblD7.Text = InicioMes.Day + 3
            LblD1.Visible = False
            LblD2.Visible = False
            LblD3.Visible = False
            LblD4.Visible = True
            LblD5.Visible = True
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 4
            LblD9.Text = InicioMes.Day + 5
            LblD10.Text = InicioMes.Day + 6
            LblD11.Text = InicioMes.Day + 7
            LblD12.Text = InicioMes.Day + 8
            LblD13.Text = InicioMes.Day + 9
            LblD14.Text = InicioMes.Day + 10
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 11
            LblD16.Text = InicioMes.Day + 12
            LblD17.Text = InicioMes.Day + 13
            LblD18.Text = InicioMes.Day + 14
            LblD19.Text = InicioMes.Day + 15
            LblD20.Text = InicioMes.Day + 16
            LblD21.Text = InicioMes.Day + 17
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 18
            LblD23.Text = InicioMes.Day + 19
            LblD24.Text = InicioMes.Day + 20
            LblD25.Text = InicioMes.Day + 21
            LblD26.Text = InicioMes.Day + 22
            LblD27.Text = InicioMes.Day + 23
            LblD28.Text = InicioMes.Day + 24
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            LblD29.Text = InicioMes.Day + 25
            LblD30.Text = InicioMes.Day + 26
            LblD31.Text = InicioMes.Day + 27

            LblD29.Visible = True
            LblD30.Visible = True
            LblD31.Visible = True

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD32.Text = InicioMes.Day + 28
                LblD32.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD33.Text = InicioMes.Day + 29
                LblD33.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD34.Text = InicioMes.Day + 30
                LblD34.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD35.Text = InicioMes.Day + 31
                LblD35.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 4 Then

            LblD5.Text = InicioMes.Day
            LblD6.Text = InicioMes.Day + 1
            LblD7.Text = InicioMes.Day + 2
            LblD1.Visible = False
            LblD2.Visible = False
            LblD3.Visible = False
            LblD4.Visible = False
            LblD5.Visible = True
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 3
            LblD9.Text = InicioMes.Day + 4
            LblD10.Text = InicioMes.Day + 5
            LblD11.Text = InicioMes.Day + 6
            LblD12.Text = InicioMes.Day + 7
            LblD13.Text = InicioMes.Day + 8
            LblD14.Text = InicioMes.Day + 9
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 10
            LblD16.Text = InicioMes.Day + 11
            LblD17.Text = InicioMes.Day + 12
            LblD18.Text = InicioMes.Day + 13
            LblD19.Text = InicioMes.Day + 14
            LblD20.Text = InicioMes.Day + 15
            LblD21.Text = InicioMes.Day + 16
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 17
            LblD23.Text = InicioMes.Day + 18
            LblD24.Text = InicioMes.Day + 19
            LblD25.Text = InicioMes.Day + 20
            LblD26.Text = InicioMes.Day + 21
            LblD27.Text = InicioMes.Day + 22
            LblD28.Text = InicioMes.Day + 23
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            LblD29.Text = InicioMes.Day + 24
            LblD30.Text = InicioMes.Day + 25
            LblD31.Text = InicioMes.Day + 26
            LblD32.Text = InicioMes.Day + 27

            LblD29.Visible = True
            LblD30.Visible = True
            LblD31.Visible = True
            LblD32.Visible = True

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD33.Text = InicioMes.Day + 28
                LblD33.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD34.Text = InicioMes.Day + 29
                LblD34.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD35.Text = InicioMes.Day + 30
                LblD35.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD36.Text = InicioMes.Day + 31
                LblD36.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 5 Then

            LblD6.Text = InicioMes.Day
            LblD7.Text = InicioMes.Day + 1

            LblD1.Visible = False
            LblD2.Visible = False
            LblD3.Visible = False
            LblD4.Visible = False
            LblD5.Visible = False
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 2
            LblD9.Text = InicioMes.Day + 3
            LblD10.Text = InicioMes.Day + 4
            LblD11.Text = InicioMes.Day + 5
            LblD12.Text = InicioMes.Day + 6
            LblD13.Text = InicioMes.Day + 7
            LblD14.Text = InicioMes.Day + 8
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 9
            LblD16.Text = InicioMes.Day + 10
            LblD17.Text = InicioMes.Day + 11
            LblD18.Text = InicioMes.Day + 12
            LblD19.Text = InicioMes.Day + 13
            LblD20.Text = InicioMes.Day + 14
            LblD21.Text = InicioMes.Day + 15
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 16
            LblD23.Text = InicioMes.Day + 17
            LblD24.Text = InicioMes.Day + 18
            LblD25.Text = InicioMes.Day + 19
            LblD26.Text = InicioMes.Day + 20
            LblD27.Text = InicioMes.Day + 21
            LblD28.Text = InicioMes.Day + 22
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            LblD29.Text = InicioMes.Day + 23
            LblD30.Text = InicioMes.Day + 24
            LblD31.Text = InicioMes.Day + 25
            LblD32.Text = InicioMes.Day + 26
            LblD33.Text = InicioMes.Day + 27

            LblD29.Visible = True
            LblD30.Visible = True
            LblD31.Visible = True
            LblD32.Visible = True
            LblD33.Visible = True

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD34.Text = InicioMes.Day + 28
                LblD34.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD35.Text = InicioMes.Day + 29
                LblD35.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD36.Text = InicioMes.Day + 30
                LblD36.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD37.Text = InicioMes.Day + 31
                LblD37.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 6 Then

            LblD7.Text = InicioMes.Day
            LblD1.Visible = False
            LblD2.Visible = False
            LblD3.Visible = False
            LblD4.Visible = False
            LblD5.Visible = False
            LblD6.Visible = False
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 1
            LblD9.Text = InicioMes.Day + 2
            LblD10.Text = InicioMes.Day + 3
            LblD11.Text = InicioMes.Day + 4
            LblD12.Text = InicioMes.Day + 5
            LblD13.Text = InicioMes.Day + 6
            LblD14.Text = InicioMes.Day + 7
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 8
            LblD16.Text = InicioMes.Day + 9
            LblD17.Text = InicioMes.Day + 10
            LblD18.Text = InicioMes.Day + 11
            LblD19.Text = InicioMes.Day + 12
            LblD20.Text = InicioMes.Day + 13
            LblD21.Text = InicioMes.Day + 14
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 15
            LblD23.Text = InicioMes.Day + 16
            LblD24.Text = InicioMes.Day + 17
            LblD25.Text = InicioMes.Day + 18
            LblD26.Text = InicioMes.Day + 19
            LblD27.Text = InicioMes.Day + 20
            LblD28.Text = InicioMes.Day + 21
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            LblD29.Text = InicioMes.Day + 22
            LblD30.Text = InicioMes.Day + 23
            LblD31.Text = InicioMes.Day + 24
            LblD32.Text = InicioMes.Day + 25
            LblD33.Text = InicioMes.Day + 26
            LblD34.Text = InicioMes.Day + 27

            LblD29.Visible = True
            LblD30.Visible = True
            LblD31.Visible = True
            LblD32.Visible = True
            LblD33.Visible = True
            LblD34.Visible = True

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD35.Text = InicioMes.Day + 28
                LblD35.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD36.Text = InicioMes.Day + 29
                LblD36.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD37.Text = InicioMes.Day + 30
                LblD37.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD38.Text = InicioMes.Day + 31
                LblD38.Visible = True
            End If

        ElseIf InicioMes.DayOfWeek = 0 Then

            LblD1.Text = InicioMes.Day
            LblD2.Text = InicioMes.Day + 1
            LblD3.Text = InicioMes.Day + 2
            LblD4.Text = InicioMes.Day + 3
            LblD5.Text = InicioMes.Day + 4
            LblD6.Text = InicioMes.Day + 5
            LblD7.Text = InicioMes.Day + 6

            LblD1.Visible = True
            LblD2.Visible = True
            LblD3.Visible = True
            LblD4.Visible = True
            LblD5.Visible = True
            LblD6.Visible = True
            LblD7.Visible = True

            'semana 2

            LblD8.Text = InicioMes.Day + 7
            LblD9.Text = InicioMes.Day + 8
            LblD10.Text = InicioMes.Day + 9
            LblD11.Text = InicioMes.Day + 10
            LblD12.Text = InicioMes.Day + 11
            LblD13.Text = InicioMes.Day + 12
            LblD14.Text = InicioMes.Day + 13
            LblD8.Visible = True
            LblD9.Visible = True
            LblD10.Visible = True
            LblD11.Visible = True
            LblD12.Visible = True
            LblD13.Visible = True
            LblD14.Visible = True

            'semana 3

            LblD15.Text = InicioMes.Day + 14
            LblD16.Text = InicioMes.Day + 15
            LblD17.Text = InicioMes.Day + 16
            LblD18.Text = InicioMes.Day + 17
            LblD19.Text = InicioMes.Day + 18
            LblD20.Text = InicioMes.Day + 19
            LblD21.Text = InicioMes.Day + 20
            LblD15.Visible = True
            LblD16.Visible = True
            LblD17.Visible = True
            LblD18.Visible = True
            LblD19.Visible = True
            LblD20.Visible = True
            LblD21.Visible = True

            'semana 4

            LblD22.Text = InicioMes.Day + 21
            LblD23.Text = InicioMes.Day + 22
            LblD24.Text = InicioMes.Day + 23
            LblD25.Text = InicioMes.Day + 24
            LblD26.Text = InicioMes.Day + 25
            LblD27.Text = InicioMes.Day + 26
            LblD28.Text = InicioMes.Day + 27
            LblD22.Visible = True
            LblD23.Visible = True
            LblD24.Visible = True
            LblD25.Visible = True
            LblD26.Visible = True
            LblD27.Visible = True
            LblD28.Visible = True

            'semana 5

            If TerminoMes > InicioMes.AddDays(28) Then
                LblD29.Text = InicioMes.Day + 28
                LblD29.Visible = True
            End If

            If TerminoMes > InicioMes.AddDays(29) Then
                LblD30.Text = InicioMes.Day + 29
                LblD30.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(30) Then
                LblD31.Text = InicioMes.Day + 30
                LblD31.Visible = True
            End If
            If TerminoMes > InicioMes.AddDays(31) Then
                LblD32.Text = InicioMes.Day + 31
                LblD32.Visible = True
            End If
        End If

        LblAno.Text = AnoReferencia

    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If Application.OpenForms.OfType(Of FrmBalancete)().Count() <> 0 Then

            FrmBalancete.ValidaInicio()

        Else

            FrmPrincipal.CarregaDashboard()

        End If

        Me.Close()

    End Sub

    Private Sub LblD1_VisibleChanged(sender As Object, e As EventArgs) Handles LblD1.VisibleChanged

        If LblD1.Visible = True Then

            Dim Data As Date = LblD1.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD1.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD1.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD1.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD1.Visible = True
            LblSaidaD1.Visible = True
            LblSaldoD1.Visible = True

        Else

            LblEntradaD1.Visible = False
            LblSaidaD1.Visible = False
            LblSaldoD1.Visible = False

        End If


    End Sub
    Private Sub LblD2_VisibleChanged(sender As Object, e As EventArgs) Handles LblD2.VisibleChanged

        If LblD2.Visible = True Then

            Dim Data As Date = LblD2.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD2.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD2.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD2.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD2.Visible = True
            LblSaidaD2.Visible = True
            LblSaldoD2.Visible = True

        Else

            LblEntradaD2.Visible = False
            LblSaidaD2.Visible = False
            LblSaldoD2.Visible = False

        End If


    End Sub
    Private Sub LblD3_VisibleChanged(sender As Object, e As EventArgs) Handles LblD3.VisibleChanged

        If LblD3.Visible = True Then

            Dim Data As Date = LblD3.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD3.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD3.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD3.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD3.Visible = True
            LblSaidaD3.Visible = True
            LblSaldoD3.Visible = True

        Else

            LblEntradaD3.Visible = False
            LblSaidaD3.Visible = False
            LblSaldoD3.Visible = False

        End If


    End Sub
    Private Sub LblD4_VisibleChanged(sender As Object, e As EventArgs) Handles LblD4.VisibleChanged

        If LblD4.Visible = True Then

            Dim Data As Date = LblD4.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD4.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD4.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD4.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD4.Visible = True
            LblSaidaD4.Visible = True
            LblSaldoD4.Visible = True

        Else

            LblEntradaD4.Visible = False
            LblSaidaD4.Visible = False
            LblSaldoD4.Visible = False

        End If


    End Sub
    Private Sub LblD5_VisibleChanged(sender As Object, e As EventArgs) Handles LblD5.VisibleChanged

        If LblD5.Visible = True Then

            Dim Data As Date = LblD5.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD5.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD5.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD5.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD5.Visible = True
            LblSaidaD5.Visible = True
            LblSaldoD5.Visible = True

        Else

            LblEntradaD5.Visible = False
            LblSaidaD5.Visible = False
            LblSaldoD5.Visible = False

        End If


    End Sub
    Private Sub LblD6_VisibleChanged(sender As Object, e As EventArgs) Handles LblD6.VisibleChanged

        If LblD6.Visible = True Then

            Dim Data As Date = LblD6.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD6.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD6.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD6.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD6.Visible = True
            LblSaidaD6.Visible = True
            LblSaldoD6.Visible = True

        Else

            LblEntradaD6.Visible = False
            LblSaidaD6.Visible = False
            LblSaldoD6.Visible = False

        End If


    End Sub
    Private Sub LblD7_VisibleChanged(sender As Object, e As EventArgs) Handles LblD7.VisibleChanged

        If LblD7.Visible = True Then

            Dim Data As Date = LblD7.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD7.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD7.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD7.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD7.Visible = True
            LblSaidaD7.Visible = True
            LblSaldoD7.Visible = True

        Else

            LblEntradaD7.Visible = False
            LblSaidaD7.Visible = False
            LblSaldoD7.Visible = False

        End If

    End Sub

    'semana 2

    Private Sub LblD8_VisibleChanged(sender As Object, e As EventArgs) Handles LblD8.VisibleChanged

        If LblD8.Visible = True Then

            Dim Data As Date = LblD8.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD8.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD8.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD8.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD8.Visible = True
            LblSaidaD8.Visible = True
            LblSaldoD8.Visible = True

        End If

    End Sub
    Private Sub LblD9_VisibleChanged(sender As Object, e As EventArgs) Handles LblD9.VisibleChanged

        If LblD9.Visible = True Then

            Dim Data As Date = LblD9.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD9.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD9.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD9.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD9.Visible = True
            LblSaidaD9.Visible = True
            LblSaldoD9.Visible = True

        End If

    End Sub
    Private Sub LblD10_VisibleChanged(sender As Object, e As EventArgs) Handles LblD10.VisibleChanged

        If LblD10.Visible = True Then

            Dim Data As Date = LblD10.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD10.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD10.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD10.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD10.Visible = True
            LblSaidaD10.Visible = True
            LblSaldoD10.Visible = True

        End If

    End Sub
    Private Sub LblD11_VisibleChanged(sender As Object, e As EventArgs) Handles LblD11.VisibleChanged

        If LblD11.Visible = True Then

            Dim Data As Date = LblD11.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD11.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD11.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD11.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD11.Visible = True
            LblSaidaD11.Visible = True
            LblSaldoD11.Visible = True

        End If

    End Sub
    Private Sub LblD12_VisibleChanged(sender As Object, e As EventArgs) Handles LblD12.VisibleChanged

        If LblD12.Visible = True Then

            Dim Data As Date = LblD12.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD12.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD12.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD12.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD12.Visible = True
            LblSaidaD12.Visible = True
            LblSaldoD12.Visible = True

        End If

    End Sub
    Private Sub LblD13_VisibleChanged(sender As Object, e As EventArgs) Handles LblD13.VisibleChanged

        If LblD13.Visible = True Then

            Dim Data As Date = LblD13.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD13.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD13.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD13.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD13.Visible = True
            LblSaidaD13.Visible = True
            LblSaldoD13.Visible = True

        End If

    End Sub
    Private Sub LblD14_VisibleChanged(sender As Object, e As EventArgs) Handles LblD14.VisibleChanged

        If LblD14.Visible = True Then

            Dim Data As Date = LblD14.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0


            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD14.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD14.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD14.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD14.Visible = True
            LblSaidaD14.Visible = True
            LblSaldoD14.Visible = True

        End If

    End Sub

    'semana 3

    Private Sub LblD15_VisibleChanged(sender As Object, e As EventArgs) Handles LblD15.VisibleChanged

        If LblD15.Visible = True Then

            Dim Data As Date = LblD15.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD15.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD15.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD15.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD15.Visible = True
            LblSaidaD15.Visible = True
            LblSaldoD15.Visible = True

        End If

    End Sub
    Private Sub LblD16_VisibleChanged(sender As Object, e As EventArgs) Handles LblD16.VisibleChanged

        If LblD16.Visible = True Then

            Dim Data As Date = LblD16.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD16.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD16.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD16.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD16.Visible = True
            LblSaidaD16.Visible = True
            LblSaldoD16.Visible = True

        End If

    End Sub
    Private Sub LblD17_VisibleChanged(sender As Object, e As EventArgs) Handles LblD17.VisibleChanged

        If LblD17.Visible = True Then

            Dim Data As Date = LblD17.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD17.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD17.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD17.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD17.Visible = True
            LblSaidaD17.Visible = True
            LblSaldoD17.Visible = True

        End If

    End Sub
    Private Sub LblD18_VisibleChanged(sender As Object, e As EventArgs) Handles LblD18.VisibleChanged

        If LblD18.Visible = True Then

            Dim Data As Date = LblD18.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD18.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD18.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD18.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD18.Visible = True
            LblSaidaD18.Visible = True
            LblSaldoD18.Visible = True

        End If

    End Sub
    Private Sub LblD19_VisibleChanged(sender As Object, e As EventArgs) Handles LblD19.VisibleChanged

        If LblD19.Visible = True Then

            Dim Data As Date = LblD19.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD19.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD19.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD19.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD19.Visible = True
            LblSaidaD19.Visible = True
            LblSaldoD19.Visible = True

        End If

    End Sub
    Private Sub LblD20_VisibleChanged(sender As Object, e As EventArgs) Handles LblD20.VisibleChanged

        If LblD20.Visible = True Then

            Dim Data As Date = LblD20.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD20.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD20.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD20.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD20.Visible = True
            LblSaidaD20.Visible = True
            LblSaldoD20.Visible = True

        End If

    End Sub
    Private Sub LblD21_VisibleChanged(sender As Object, e As EventArgs) Handles LblD21.VisibleChanged

        If LblD21.Visible = True Then

            Dim Data As Date = LblD21.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD21.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD21.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD21.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD21.Visible = True
            LblSaidaD21.Visible = True
            LblSaldoD21.Visible = True

        End If

    End Sub

    'semana 4

    Private Sub LblD22_VisibleChanged(sender As Object, e As EventArgs) Handles LblD22.VisibleChanged

        If LblD22.Visible = True Then

            Dim Data As Date = LblD22.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD22.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD22.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD22.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD22.Visible = True
            LblSaidaD22.Visible = True
            LblSaldoD22.Visible = True

        End If

    End Sub
    Private Sub LblD23_VisibleChanged(sender As Object, e As EventArgs) Handles LblD23.VisibleChanged

        If LblD23.Visible = True Then

            Dim Data As Date = LblD23.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD23.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD23.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD23.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD23.Visible = True
            LblSaidaD23.Visible = True
            LblSaldoD23.Visible = True

        End If

    End Sub
    Private Sub LblD24_VisibleChanged(sender As Object, e As EventArgs) Handles LblD24.VisibleChanged

        If LblD24.Visible = True Then

            Dim Data As Date = LblD24.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD24.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD24.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD24.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD24.Visible = True
            LblSaidaD24.Visible = True
            LblSaldoD24.Visible = True

        End If

    End Sub
    Private Sub LblD25_VisibleChanged(sender As Object, e As EventArgs) Handles LblD25.VisibleChanged

        If LblD25.Visible = True Then

            Dim Data As Date = LblD25.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD25.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD25.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD25.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD25.Visible = True
            LblSaidaD25.Visible = True
            LblSaldoD25.Visible = True

        End If

    End Sub
    Private Sub LblD26_VisibleChanged(sender As Object, e As EventArgs) Handles LblD26.VisibleChanged

        If LblD26.Visible = True Then

            Dim Data As Date = LblD26.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD26.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD26.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD26.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD26.Visible = True
            LblSaidaD26.Visible = True
            LblSaldoD26.Visible = True

        End If

    End Sub
    Private Sub LblD27_VisibleChanged(sender As Object, e As EventArgs) Handles LblD27.VisibleChanged

        If LblD27.Visible = True Then

            Dim Data As Date = LblD27.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD27.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD27.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD27.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD27.Visible = True
            LblSaidaD27.Visible = True
            LblSaldoD27.Visible = True

        End If

    End Sub
    Private Sub LblD28_VisibleChanged(sender As Object, e As EventArgs) Handles LblD28.VisibleChanged

        If LblD28.Visible = True Then

            Dim Data As Date = LblD28.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next

            LblEntradaD28.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD28.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD28.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD28.Visible = True
            LblSaidaD28.Visible = True
            LblSaldoD28.Visible = True

        End If

    End Sub

    'semana 4

    Private Sub LblD29_VisibleChanged(sender As Object, e As EventArgs) Handles LblD29.VisibleChanged

        If LblD29.Visible = True Then

            Dim Data As Date = LblD29.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD29.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD29.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD29.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD29.Visible = True
            LblSaidaD29.Visible = True
            LblSaldoD29.Visible = True

        Else

            LblEntradaD29.Visible = False
            LblSaidaD29.Visible = False
            LblSaldoD29.Visible = False

        End If

    End Sub
    Private Sub LblD30_VisibleChanged(sender As Object, e As EventArgs) Handles LblD30.VisibleChanged

        If LblD30.Visible = True Then

            Dim Data As Date = LblD30.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD30.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD30.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD30.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD30.Visible = True
            LblSaidaD30.Visible = True
            LblSaldoD30.Visible = True

        Else

            LblEntradaD30.Visible = False
            LblSaidaD30.Visible = False
            LblSaldoD30.Visible = False

        End If

    End Sub
    Private Sub LblD31_VisibleChanged(sender As Object, e As EventArgs) Handles LblD31.VisibleChanged

        If LblD31.Visible = True Then

            Dim Data As Date = LblD31.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD31.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD31.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD31.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD31.Visible = True
            LblSaidaD31.Visible = True
            LblSaldoD31.Visible = True

        Else

            LblEntradaD31.Visible = False
            LblSaidaD31.Visible = False
            LblSaldoD31.Visible = False

        End If

    End Sub
    Private Sub LblD32_VisibleChanged(sender As Object, e As EventArgs) Handles LblD32.VisibleChanged

        If LblD32.Visible = True Then

            Dim Data As Date = LblD32.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD32.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD32.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD32.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD32.Visible = True
            LblSaidaD32.Visible = True
            LblSaldoD32.Visible = True

        Else

            LblEntradaD32.Visible = False
            LblSaidaD32.Visible = False
            LblSaldoD32.Visible = False

        End If

    End Sub
    Private Sub LblD33_VisibleChanged(sender As Object, e As EventArgs) Handles LblD33.VisibleChanged

        If LblD33.Visible = True Then

            Dim Data As Date = LblD33.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD33.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD33.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD33.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD33.Visible = True
            LblSaidaD33.Visible = True
            LblSaldoD33.Visible = True

        Else

            LblEntradaD33.Visible = False
            LblSaidaD33.Visible = False
            LblSaldoD33.Visible = False

        End If

    End Sub
    Private Sub LblD34_VisibleChanged(sender As Object, e As EventArgs) Handles LblD34.VisibleChanged

        If LblD34.Visible = True Then

            Dim Data As Date = LblD34.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD34.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD34.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD34.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD34.Visible = True
            LblSaidaD34.Visible = True
            LblSaldoD34.Visible = True

        Else

            LblEntradaD34.Visible = False
            LblSaidaD34.Visible = False
            LblSaldoD34.Visible = False

        End If

    End Sub
    Private Sub LblD35_VisibleChanged(sender As Object, e As EventArgs) Handles LblD35.VisibleChanged

        If LblD35.Visible = True Then

            Dim Data As Date = LblD35.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD35.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD35.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD35.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD35.Visible = True
            LblSaidaD35.Visible = True
            LblSaldoD35.Visible = True

        Else

            LblEntradaD35.Visible = False
            LblSaidaD35.Visible = False
            LblSaldoD35.Visible = False

        End If

    End Sub

    'semana 6

    Private Sub LblD36_VisibleChanged(sender As Object, e As EventArgs) Handles LblD36.VisibleChanged

        If LblD36.Visible = True Then

            Dim Data As Date = LblD36.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD36.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD36.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD36.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD36.Visible = True
            LblSaidaD36.Visible = True
            LblSaldoD36.Visible = True

        Else

            LblEntradaD36.Visible = False
            LblSaidaD36.Visible = False
            LblSaldoD36.Visible = False

        End If

    End Sub
    Private Sub LblD37_VisibleChanged(sender As Object, e As EventArgs) Handles LblD37.VisibleChanged

        If LblD37.Visible = True Then

            Dim Data As Date = LblD37.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD37.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD37.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD37.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD37.Visible = True
            LblSaidaD37.Visible = True
            LblSaldoD37.Visible = True

        Else

            LblEntradaD37.Visible = False
            LblSaidaD37.Visible = False
            LblSaldoD37.Visible = False

        End If

    End Sub
    Private Sub LblD38_VisibleChanged(sender As Object, e As EventArgs) Handles LblD38.VisibleChanged

        If LblD38.Visible = True Then

            Dim Data As Date = LblD38.Text & "/" & MesReferencia & "/" & AnoReferencia
            'busca lancamentos para a data

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            Dim BuscaLancamentoDia = From lanc In LqFinanceiro.BalanceteFinanceiro
                                     Where lanc.Vencimento <= Data
                                     Select lanc.Status, lanc.Valor, lanc.Tipo, lanc.Vencimento, lanc.DataBaixa

            Dim VlrEnt As Decimal = 0
            Dim VlrSaida As Decimal = 0

            Dim VlrEntSld As Decimal = 0
            Dim VlrSaidaSld As Decimal = 0

            For Each row In BuscaLancamentoDia.ToList

                Dim DataBaixa As Date = row.DataBaixa

                If DataBaixa = "1111-11-11" Then

                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                Else
                    If row.Vencimento = Data Then
                        If row.Tipo = True Then

                            VlrEnt += row.Valor

                        Else

                            VlrSaida += row.Valor

                        End If
                    Else
                        If row.Tipo = True Then

                            VlrEntSld += row.Valor

                        Else

                            VlrSaidaSld += row.Valor

                        End If
                    End If

                End If

            Next


            LblEntradaD38.Text = FormatCurrency(VlrEnt, NumDigitsAfterDecimal:=2)
            LblSaidaD38.Text = FormatCurrency(VlrSaida, NumDigitsAfterDecimal:=2)

            LblSaldoD38.Text = FormatCurrency(VlrEnt - VlrSaida + (VlrEntSld - VlrSaidaSld), NumDigitsAfterDecimal:=2)

            LblEntradaD38.Visible = True
            LblSaidaD38.Visible = True
            LblSaldoD38.Visible = True

        Else

            LblEntradaD38.Visible = False
            LblSaidaD38.Visible = False
            LblSaldoD38.Visible = False

        End If

    End Sub

    Private Sub LblD1_Click(sender As Object, e As EventArgs) Handles LblD1.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD1.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD2_Click(sender As Object, e As EventArgs) Handles LblD2.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD2.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD3_Click(sender As Object, e As EventArgs) Handles LblD3.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD3.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD4_Click(sender As Object, e As EventArgs) Handles LblD4.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD4.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD5_Click(sender As Object, e As EventArgs) Handles LblD5.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD5.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD6_Click(sender As Object, e As EventArgs) Handles LblD6.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD6.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD7_Click(sender As Object, e As EventArgs) Handles LblD7.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD7.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD8_Click(sender As Object, e As EventArgs) Handles LblD8.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD8.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub

    Private Sub LblD9_Click(sender As Object, e As EventArgs) Handles LblD9.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD9.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD10_Click(sender As Object, e As EventArgs) Handles LblD10.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD10.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD11_Click(sender As Object, e As EventArgs) Handles LblD11.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD11.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD12_Click(sender As Object, e As EventArgs) Handles LblD12.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD12.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD13_Click(sender As Object, e As EventArgs) Handles LblD13.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD13.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD14_Click(sender As Object, e As EventArgs) Handles LblD14.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD14.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD15_Click(sender As Object, e As EventArgs) Handles LblD15.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD15.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub

    Private Sub LblD16_Click(sender As Object, e As EventArgs) Handles LblD16.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD16.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD17_Click(sender As Object, e As EventArgs) Handles LblD17.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD17.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD18_Click(sender As Object, e As EventArgs) Handles LblD18.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD18.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD19_Click(sender As Object, e As EventArgs) Handles LblD19.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD19.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD20_Click(sender As Object, e As EventArgs) Handles LblD20.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD20.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD21_Click(sender As Object, e As EventArgs) Handles LblD21.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD21.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD22_Click(sender As Object, e As EventArgs) Handles LblD22.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD22.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub

    Private Sub LblD23_Click(sender As Object, e As EventArgs) Handles LblD23.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD23.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD24_Click(sender As Object, e As EventArgs) Handles LblD24.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD24.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD25_Click(sender As Object, e As EventArgs) Handles LblD25.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD25.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD26_Click(sender As Object, e As EventArgs) Handles LblD26.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD26.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD27_Click(sender As Object, e As EventArgs) Handles LblD27.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD27.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD28_Click(sender As Object, e As EventArgs) Handles LblD28.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD28.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD29_Click(sender As Object, e As EventArgs) Handles LblD29.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD29.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub

    Private Sub LblD30_Click(sender As Object, e As EventArgs) Handles LblD30.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD30.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD31_Click(sender As Object, e As EventArgs) Handles LblD31.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD31.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD32_Click(sender As Object, e As EventArgs) Handles LblD32.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD32.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD33_Click(sender As Object, e As EventArgs) Handles LblD33.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD33.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD34_Click(sender As Object, e As EventArgs) Handles LblD34.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD34.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD35_Click(sender As Object, e As EventArgs) Handles LblD35.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD35.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD36_Click(sender As Object, e As EventArgs) Handles LblD36.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD36.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD37_Click(sender As Object, e As EventArgs) Handles LblD37.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD37.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub
    Private Sub LblD38_Click(sender As Object, e As EventArgs) Handles LblD38.Click

        FrmNovoLancamentoBalancete.DataEnc = LblD38.Text & "/" & MesReferencia & "/" & AnoReferencia
        FrmNovoLancamentoBalancete.LeIncio()

        FrmNovoLancamentoBalancete.Show(Me)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        MesReferencia += 1

        Dim LstMeses As New ListBox

        LstMeses.Items.Add("Janeiro")
        LstMeses.Items.Add("Fevereiro")
        LstMeses.Items.Add("Março")
        LstMeses.Items.Add("Abril")
        LstMeses.Items.Add("Maio")
        LstMeses.Items.Add("Junho")
        LstMeses.Items.Add("Julho")
        LstMeses.Items.Add("Agosto")
        LstMeses.Items.Add("Setembro")
        LstMeses.Items.Add("Outubro")
        LstMeses.Items.Add("Novembro")
        LstMeses.Items.Add("Dezembro")

        If MesReferencia = 13 Then
            AnoReferencia += 1
            MesReferencia = 1
        End If

        LblMesDescricao.Text = LstMeses.Items(MesReferencia - 1).ToString

        ValidaInicio()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        MesReferencia -= 1

        Dim LstMeses As New ListBox

        LstMeses.Items.Add("Janeiro")
        LstMeses.Items.Add("Fevereiro")
        LstMeses.Items.Add("Março")
        LstMeses.Items.Add("Abril")
        LstMeses.Items.Add("Maio")
        LstMeses.Items.Add("Junho")
        LstMeses.Items.Add("Julho")
        LstMeses.Items.Add("Agosto")
        LstMeses.Items.Add("Setembro")
        LstMeses.Items.Add("Outubro")
        LstMeses.Items.Add("Novembro")
        LstMeses.Items.Add("Dezembro")

        If MesReferencia = 0 Then
            AnoReferencia -= 1
            MesReferencia = 12
        End If

        LblMesDescricao.Text = LstMeses.Items(MesReferencia - 1).ToString

        ValidaInicio()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        AnoReferencia += 1

        ValidaInicio()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        AnoReferencia -= 1

        ValidaInicio()

    End Sub
End Class