Public Class FrmNovobeneficio

    Dim LqBase As New DtCadastroDataContext
    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then

            BttSalvar.Enabled = True
        Else

            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'salva eneficio no bdd

        LqBase.InsereNovoBeneficio(txtdescrição.Text)

        'popula na lista de eneficios

        Dim SalvaValor As String = txtdescrição.Text

        Dim buscaBeneficios = From ben In LqBase.Beneficios
                              Where ben.IdBeneficio Like "*"
                              Select ben.IdBeneficio, ben.Descricao

        FrmQuadroOperacional.LstIdBeneficio.Items.Clear()
        FrmQuadroOperacional.CmbBenefiicio.Items.Clear()

        For Each row In buscaBeneficios.ToList

            FrmQuadroOperacional.LstIdBeneficio.Items.Add(row.IdBeneficio)
            FrmQuadroOperacional.CmbBenefiicio.Items.Add(row.Descricao)

        Next

        FrmQuadroOperacional.CmbBenefiicio.SelectedItem = SalvaValor

        Me.Close()

    End Sub
End Class