Public Class FrmNovaFerramenta

    Dim LqBase As New DtCadastroDataContext

    Dim LstIdCargo As New ListBox

    Private Sub FrmNovaFerramenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim BuscaProfissional = From prof In LqBase.Cargos
                                Where prof.IdCargo Like "*"
                                Select prof.IdCargo, prof.Descricao

        For Each row In BuscaProfissional.ToList

            LstIdCargo.Items.Add(row.IdCargo)

            CmbCargos.Items.Add(row.Descricao)

        Next

    End Sub

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub txtdescrição_TextChanged(sender As Object, e As EventArgs) Handles txtdescrição.TextChanged

        If txtdescrição.Text <> "" Then
            CmbCargos.Enabled = True
            CkNdefinido.Enabled = True
        Else
            CmbCargos.Text = ""
            CmbCargos.Enabled = False
            CkNdefinido.Enabled = False
        End If

    End Sub

    Private Sub CmbCargos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargos.SelectedIndexChanged

        If CmbCargos.Items.Contains(CmbCargos.Text) Then

            BttVincula.Enabled = True

            CkNdefinido.Enabled = False
            CkNdefinido.Checked = False

        Else

            BttVincula.Enabled = False

            CkNdefinido.Enabled = True
            CkNdefinido.Checked = False

        End If

    End Sub

    Private Sub CkNdefinido_CheckedChanged(sender As Object, e As EventArgs) Handles CkNdefinido.CheckedChanged


        If CkNdefinido.Checked = True Then

            If DtProdutos.Rows.Count > 0 Then

                If MsgBox("Existem profissionais vinculados nessa lista, continuar apagará todos os vinculos." & Chr(13) & "Deseja realmente continuar?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    CmbCargos.Text = ""
                    CmbCargos.Enabled = False
                    BttVincula.Enabled = False

                    DtProdutos.Rows.Clear()
                    DtProdutos.Enabled = True

                    BttSalvar.Enabled = True

                    RdbInsumos.Checked = True

                End If

            Else

                DtProdutos.Enabled = False
                BttSalvar.Enabled = True

                CmbCargos.Text = ""
                CmbCargos.Enabled = False
                BttVincula.Enabled = False

                RdbInsumos.Enabled = True
                RdbEPI.Enabled = True

                RdbInsumos.Checked = True


            End If

        Else

            BttSalvar.Enabled = False

            CmbCargos.Text = ""
            CmbCargos.Enabled = True
            BttVincula.Enabled = False

            RdbInsumos.Checked = False
            RdbEPI.Checked = False

            RdbInsumos.Enabled = False
            RdbEPI.Enabled = False

        End If

    End Sub

    Private Sub BttVincula_Click(sender As Object, e As EventArgs) Handles BttVincula.Click

        'insere no grid

        DtProdutos.Rows.Add(LstIdCargo.Items(CmbCargos.SelectedIndex).ToString, CmbCargos.Text, My.Resources.Cancel_40972)

        BttSalvar.Enabled = True

        'limpa camps

        CmbCargos.Text = ""

        txtdescriçãoInsumos.Enabled = True

        RdbInsumos.Enabled = True
        RdbEPI.Enabled = True

        RdbInsumos.Checked = True


    End Sub

    Private Sub CmbCargos_TextChanged(sender As Object, e As EventArgs) Handles CmbCargos.TextChanged

        If CmbCargos.Items.Contains(CmbCargos.Text) Then

            BttVincula.Enabled = True

            CkNdefinido.Enabled = False
            CkNdefinido.Checked = False

        Else

            BttVincula.Enabled = False

            CkNdefinido.Enabled = True
            CkNdefinido.Checked = False

        End If

    End Sub

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'LqBase.inserenova ferramenta

        LqBase.InsereNovaFerramenta(txtdescrição.Text, CkNdefinido.CheckState, "Oficina")

        Dim BuscaFerramenta = From fer In LqBase.Ferramentas
                              Where fer.IdFerramenta Like "*"
                              Select fer.IdFerramenta
                              Order By IdFerramenta Descending

        Dim _IdFerramenta As Integer = BuscaFerramenta.First

        'varre datagrd

        If DtProdutos.Rows.Count > 0 Then

            For Each row As DataGridViewRow In DtProdutos.Rows

                Dim Cod As Integer = row.Cells(0).Value

                LqBase.InsereNovaFerramentaCargo(Cod, _IdFerramenta, txtdescrição.Text)

            Next

        End If

        'insere epi e insumo

        For Each row As DataGridViewRow In DtInsumos.Rows

            If row.Cells(0).Value = RdbInsumos.Text Then
                LqBase.InsereNovoInsumo(row.Cells(1).Value.ToString, _IdFerramenta, False)
            Else
                LqBase.InsereNovoEPI(row.Cells(1).Value.ToString, _IdFerramenta, False)
            End If

        Next

        Me.Close()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RdbInsumos_CheckedChanged(sender As Object, e As EventArgs) Handles RdbInsumos.CheckedChanged

        If RdbInsumos.Checked = True Then

            'busca insumos cadastrados

            txtdescriçãoInsumos.Enabled = True
            txtdescriçãoInsumos.Text = ""

        Else

            txtdescriçãoInsumos.Enabled = True
            txtdescriçãoInsumos.Text = ""

        End If

        If RdbInsumos.Checked = False And RdbEPI.Checked = False Then

            txtdescriçãoInsumos.Enabled = False
            txtdescriçãoInsumos.Text = ""

        End If

    End Sub

    Private Sub BttVinculaInsumo_Click(sender As Object, e As EventArgs) Handles BttVinculaInsumo.Click

        Dim Tipo As String

        If RdbInsumos.Checked = True Then

            Tipo = RdbInsumos.Text

        Else

            Tipo = RdbEPI.Text

        End If

        DtInsumos.Rows.Add(Tipo, txtdescriçãoInsumos.Text, My.Resources.Cancel_40972)

        txtdescriçãoInsumos.Text = ""

    End Sub

    Private Sub txtdescriçãoInsumos_TextChanged(sender As Object, e As EventArgs) Handles txtdescriçãoInsumos.TextChanged

        If txtdescriçãoInsumos.Text <> "" Then

            BttVinculaInsumo.Enabled = True

        Else

            BttVinculaInsumo.Enabled = False

        End If

    End Sub
End Class