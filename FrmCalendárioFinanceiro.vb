Public Class FrmCalendárioFinanceiro
    Private Sub BttSalvarMarkup_Click(sender As Object, e As EventArgs) Handles BttSalvarMarkup.Click

        FrmPrincipal.Timer1.Enabled = True
        Me.Close()

    End Sub

    Private Sub FrmCalendárioFinanceiro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim D0 As Date = Today.Date

        LblD01.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD02.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD03.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD04.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD05.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD06.Text = FormatDateTime(D0, DateFormat.LongDate)

        D0 = D0.AddDays(1)
        LblD07.Text = FormatDateTime(D0, DateFormat.LongDate)

    End Sub
End Class