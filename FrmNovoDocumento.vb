Public Class FrmNovoDocumento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged
        If TxtDescrição.Text <> "" Then
            TxtSigla.Enabled = True
        Else
            TxtSigla.Enabled = False
            TxtSigla.Text = ""
        End If
    End Sub

    Private Sub TxtSigla_TextChanged(sender As Object, e As EventArgs) Handles TxtSigla.TextChanged
        If TxtSigla.Text <> "" Then
            TxtMascara.Enabled = True
        Else
            TxtMascara.Enabled = False
            TxtMascara.Text = ""
        End If
    End Sub

    Private Sub TxtMascara_TextChanged(sender As Object, e As EventArgs) Handles TxtMascara.TextChanged
        If TxtMascara.Text <> "" Then
            BttSalvar.Enabled = True
        Else
            BttSalvar.Enabled = False
        End If
    End Sub

    Public FrmOri As Integer
    Dim LqGEral As New DtCadastroDataContext
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

        'salva
        LqGEral.InsereDocumento(TxtDescrição.Text, TxtSigla.Text, TxtMascara.Text)

        If FrmOri = 0 Then

            'carrega documentos

            'busca documentos
            Dim BuscaDocs = From doc In LqGEral.Documentos
                            Where doc.IdDocumento Like "*"
                            Select doc.Descricao, doc.IdDocumento, doc.Mascara, doc.Sigla

            FrmNovoVinculoParental.LstIdDocumento.Items.Clear()
            FrmNovoVinculoParental.LstSigla.Items.Clear()
            FrmNovoVinculoParental.Lstdescricao.Items.Clear()
            FrmNovoVinculoParental.CmbDocumento.Items.Clear()

            For Each row In BuscaDocs.ToList

                FrmNovoVinculoParental.LstIdDocumento.Items.Add(row.IdDocumento)
                FrmNovoVinculoParental.LstSigla.Items.Add(row.Sigla)
                FrmNovoVinculoParental.Lstdescricao.Items.Add(row.descricao)
                FrmNovoVinculoParental.CmbDocumento.Items.Add(row.Sigla & " - " & row.descricao)

            Next

            FrmNovoVinculoParental.CmbDocumento.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

        End If

        Me.Close()

    End Sub

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        LqGEral.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        'salva
        LqGEral.InsereDocumento(TxtDescrição.Text, TxtSigla.Text, TxtMascara.Text)

        If FrmOri = 0 Then

            'carrega documentos

            'busca documentos
            Dim BuscaDocs = From doc In LqGEral.Documentos
                            Where doc.IdDocumento Like "*"
                            Select doc.Descricao, doc.IdDocumento, doc.Mascara, doc.Sigla

            FrmNovoVinculoParental.LstIdDocumento.Items.Clear()
            FrmNovoVinculoParental.LstSigla.Items.Clear()
            FrmNovoVinculoParental.Lstdescricao.Items.Clear()
            FrmNovoVinculoParental.CmbDocumento.Items.Clear()

            For Each row In BuscaDocs.ToList

                FrmNovoVinculoParental.LstIdDocumento.Items.Add(row.IdDocumento)
                FrmNovoVinculoParental.LstSigla.Items.Add(row.Sigla)
                FrmNovoVinculoParental.Lstdescricao.Items.Add(row.Descricao)
                FrmNovoVinculoParental.CmbDocumento.Items.Add(row.Sigla & " - " & row.Descricao)

            Next

            FrmNovoVinculoParental.CmbDocumento.SelectedItem = TxtSigla.Text & " - " & TxtDescrição.Text

        End If

        Me.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttFechar.Click
        Me.Close()
    End Sub
End Class