Public Class FrmNotifficação
    Private Sub FrmNotifficação_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'move para o canto da tela

        Me.Location = New Point(FrmPrincipal.Size.Width - Me.Size.Width, FrmPrincipal.Size.Height - Me.Size.Height)

        Timer1.Enabled = True

    End Sub

    Dim _tempo As Integer

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If _tempo = 6 Then

            Me.Close()

        Else

            _tempo += 1

        End If

    End Sub

    Private Sub FrmNotifficação_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter

    End Sub

    Private Sub FrmNotifficação_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave

        Timer1.Enabled = True

    End Sub

    Private Sub FrmNotifficação_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover

        Timer1.Enabled = False

    End Sub

    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

    End Sub

    Private Sub DtProdutos_MouseHover(sender As Object, e As EventArgs) Handles DtProdutos.MouseHover

        Timer1.Enabled = False

    End Sub

    Private Sub DtProdutos_MouseLeave(sender As Object, e As EventArgs) Handles DtProdutos.MouseLeave

        Timer1.Enabled = True

    End Sub
End Class