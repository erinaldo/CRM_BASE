Public Class FrmNovoPais
    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            TxtSigla.Enabled = True
            TxtCodTel.Enabled = True
        Else
            TxtSigla.Enabled = False
            TxtCodTel.Enabled = False
            TxtSigla.Text = ""
            TxtCodTel.Text = ""
        End If

    End Sub

    Private Sub TxtSigla_TextChanged(sender As Object, e As EventArgs) Handles TxtSigla.TextChanged
        If TxtSigla.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Dim LqCadastro As New DtCadastroDataContext
    Public Ori As Integer = 0

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqCadastro.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'salva item

        LqCadastro.InserePais(TxtDescrição.Text, TxtSigla.Text, TxtCodTel.Text)

        If Ori = 0 Then

            'carrega paises
            Dim BuscaPaises = From pa In LqCadastro.Paises
                              Where pa.IdPais Like "*"
                              Select pa.Descricao, pa.IdPais, pa.Sigla

            FrmNacionalidade.LstIdPaises.Items.Clear()
            FrmNacionalidade.Lstdescricao.Items.Clear()
            FrmNacionalidade.lstSigla.Items.Clear()
            FrmNacionalidade.CmbPais.Items.Clear()

            For Each row In BuscaPaises.ToList
                FrmNacionalidade.LstIdPaises.Items.Add(row.IdPais)
                FrmNacionalidade.Lstdescricao.Items.Add(row.Descricao)
                FrmNacionalidade.lstSigla.Items.Add(row.Sigla)
                FrmNacionalidade.CmbPais.Items.Add(row.Sigla & " - " & row.Descricao)
            Next

            FrmNacionalidade.CmbPais.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

        ElseIf Ori = 1 Then

            'carrega paises
            Dim BuscaPaises = From pa In LqCadastro.Paises
                              Where pa.IdPais Like "*"
                              Select pa.Descricao, pa.IdPais, pa.Sigla

            FrmNacionalidade.LstIdPaises.Items.Clear()
            FrmNacionalidade.Lstdescricao.Items.Clear()
            FrmNacionalidade.lstSigla.Items.Clear()
            FrmNacionalidade.CmbPais.Items.Clear()

            For Each row In BuscaPaises.ToList
                FrmNacionalidade.LstIdPaises.Items.Add(row.IdPais)
                FrmNacionalidade.Lstdescricao.Items.Add(row.Descricao)
                FrmNacionalidade.lstSigla.Items.Add(row.Sigla)
                FrmNacionalidade.CmbPais.Items.Add(row.Sigla & " - " & row.Descricao)
            Next

            FrmNacionalidade.CmbPais.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

        End If

        Me.Close()

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
End Class