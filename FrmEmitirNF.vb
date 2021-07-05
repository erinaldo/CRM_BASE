Public Class FrmEmitirNF

    Dim docNFe As New XDocument
    Dim nmArqXSD As String

    Dim Dlg As New OpenFileDialog

    Private Sub FrmEmitirNF_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub


End Class