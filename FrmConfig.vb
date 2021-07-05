Public Class FrmConfig
    Private Sub TxtIpServidor_TextChanged(sender As Object, e As EventArgs) Handles TxtIpServidor.TextChanged

    End Sub

    Private Sub TxtIpServidor_LostFocus(sender As Object, e As EventArgs) Handles TxtIpServidor.LostFocus

        If TxtIpServidor.Text <> "" Then

            Dim Dot As Integer = 0

            For i As Integer = 0 To TxtIpServidor.Text.Length - 1

                Dim Campo As String = TxtIpServidor.Text.ToCharArray(i, 1)

                If Campo = "." Then

                    Dot += 1

                End If

            Next

            If Dot = 3 Then

                Try

                    If My.Computer.Network.Ping(TxtIpServidor.Text) = True Then
                        Dim ElapseTime As New Stopwatch
                        ElapseTime.Start()
                        My.Computer.Network.Ping(TxtIpServidor.Text)
                        ElapseTime.Stop()

                        ' avisa que pingou
                        LblRespostaTrabalho.Text = "Ping no servidor " & TxtIpServidor.Text & " resposta:" & FormatNumber(ElapseTime.Elapsed.TotalSeconds.ToString(), NumDigitsAfterDecimal:=2) & "ms"
                    Else
                        LblRespostaTrabalho.Text = "Ping falhou (timeout) : " & Now.TimeOfDay.ToString()
                    End If

                Catch ex As Exception

                    LblRespostaTrabalho.Text = "Ping falhou (timeout) : " & Now.TimeOfDay.ToString()

                End Try

            End If

        Else

            LblRespostaTrabalho.Text = ""

        End If

    End Sub

End Class