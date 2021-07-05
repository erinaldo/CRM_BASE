Public Class FrmDataLancamento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        FrmBalancete.ValidaInicio()

        Me.Close()

    End Sub

    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs)

    End Sub

    Private Sub BttAprovarCompra_Click(sender As Object, e As EventArgs) Handles BttAprovarCompra.Click

        FrmNovoLancamento.DataEnc = DateTimePicker1.Value.ToString

        'MsgBox(FrmNovoLancamento.DataEnc)

        FrmNovoLancamento.Show(FrmBalancete)

        Me.Close()

    End Sub
End Class