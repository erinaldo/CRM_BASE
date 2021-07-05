Public Class FrmNovoLancamento
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        If Application.OpenForms.OfType(Of FrmNovoLancamentoBalancete)().Count() <> 0 Then

            FrmNovoLancamentoBalancete.LeIncio()

        Else

            FrmBalancete.ValidaInicio()

        End If

        Me.Close()

    End Sub

    Public DataEnc As Date

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        If RdbValorReceber.Checked = True Then

            Me.Cursor = Cursors.WaitCursor

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            If CkRepete.Checked = False Then
                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataEnc, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text, CmbCategoria.Text)
            Else

                Dim DataInicio As Date = DataEnc

                Dim Max As Integer = NmRepetir.Value
                Dim C As Integer = 1

                While Max > 0

                    If RdbDias.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddDays(NmVlrRepete.Value)

                        ElseIf RdbMeses.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddMonths(NmVlrRepete.Value)

                    ElseIf RdbAno.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, True, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddYears(NmVlrRepete.Value)

                    End If
                    Max -= 1

                    C += 1

                End While

            End If

        Else

            Me.Cursor = Cursors.WaitCursor

            Dim LqFinanceiro As New LqFinanceiroDataContext
            LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

            If CkRepete.Checked = False Then
                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataEnc, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text, CmbCategoria.Text)
            Else

                Dim DataInicio As Date = DataEnc

                Dim Max As Integer = NmRepetir.Value
                Dim C As Integer = 1

                While Max > 0

                    If RdbDias.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddDays(NmVlrRepete.Value)

                    ElseIf RdbMeses.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddMonths(NmVlrRepete.Value)

                    ElseIf RdbAno.Checked = True Then

                        If CkAferir.Checked = False Then
                            LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                        Else
                            If Max = NmRepetir.Value Then
                                LqFinanceiro.InsereNovaEntradaBalancete(0, TxtValor.Text, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)
                            Else
                                LqFinanceiro.InsereNovaEntradaBalancete(0, 0, 0, 0, DataInicio, False, Today.Date, Now.TimeOfDay, FrmPrincipal.IdUsuario, "1111-11-11", Today.TimeOfDay, 0, 0, False, 0, "", TxtDescricao.Text & "." & C, CmbCategoria.Text)

                                Dim IdBalancete As Integer = 0
                                IdBalancete = LqFinanceiro.BalanceteFinanceiro.ToList.Last.IdItemBalancete

                                LqFinanceiro.InsereNovaAfericao(IdBalancete, False, FrmPrincipal.IdUsuario, DataInicio.AddDays(NmDiasSolicitar.Value * -1), "1111-11-11")

                            End If
                        End If

                        DataInicio = DataInicio.AddYears(NmVlrRepete.Value)

                    End If

                    Max -= 1

                    C += 1

                End While

            End If

        End If

        If Application.OpenForms.OfType(Of FrmNovoLancamentoBalancete)().Count() <> 0 Then

            FrmNovoLancamentoBalancete.LeIncio()

        Else

            FrmBalancete.ValidaInicio()

        End If

        Me.Close()

    End Sub

    Private Sub CkRepete_CheckedChanged(sender As Object, e As EventArgs) Handles CkRepete.CheckedChanged

        If CkRepete.Checked = True Then

            Panel1.Enabled = True

            CkAferir.Enabled = True

        Else

            CkAferir.Enabled = False
            CkAferir.Checked = False

            NmVlrRepete.Value = 1
            RdbDias.Checked = False
            RdbMeses.Checked = False
            RdbAno.Checked = False

            Panel1.Enabled = False

        End If

    End Sub

    Private Sub RdbValorPagar_CheckedChanged(sender As Object, e As EventArgs) Handles RdbValorPagar.CheckedChanged

        'procura na lista de fornecedores
        If RdbValorPagar.Enabled = True Then
            If RdbValorPagar.Checked = True Then
                CmbCategoria.Enabled = True
                CmbCategoria.Items.Clear()
                CmbCategoria.Text = ""

                'busca categorias de lançamento

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim _Tipo As Boolean = False

                If RdbValorReceber.Checked = True Then
                    _Tipo = True
                End If

                Dim BuscaCategoriasFinanceiro = From plan In LqFinanceiro.CategoriaPlanoContas
                                                Where plan.Categoria Like "*" And plan.Tipo = _Tipo
                                                Select plan.IdCategoriaPlano, plan.Categoria

                CmbCategoria.Items.Clear()
                CmbCategoria.Text = ""
                LstIdCategoria.Items.Clear()

                For Each row In BuscaCategoriasFinanceiro.ToList

                    CmbCategoria.Items.Add(row.Categoria)
                    LstIdCategoria.Items.Add(row.IdCategoriaPlano)

                Next

            End If
        End If


    End Sub

    Private Sub RdbDias_CheckedChanged(sender As Object, e As EventArgs) Handles RdbDias.CheckedChanged

        If RdbDias.Checked = True Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = True

        ElseIf RdbDias.Checked = False And RdbMeses.Checked = False And RdbAno.Checked = False Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = False

        End If

    End Sub

    Private Sub RdbMeses_CheckedChanged(sender As Object, e As EventArgs) Handles RdbMeses.CheckedChanged

        If RdbMeses.Checked = True Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = True

        ElseIf RdbDias.Checked = False And RdbMeses.Checked = False And RdbAno.Checked = False Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = False

        End If

    End Sub

    Private Sub RdbAno_CheckedChanged(sender As Object, e As EventArgs) Handles RdbAno.CheckedChanged

        If RdbAno.Checked = True Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = True

        ElseIf RdbDias.Checked = False And RdbMeses.Checked = False And RdbAno.Checked = False Then

            NmRepetir.Value = 1
            NmRepetir.Enabled = False

        End If

    End Sub

    Private Sub TxtValor_TextChanged(sender As Object, e As EventArgs) Handles TxtValor.TextChanged

        If TxtValor.Text = "" Then
            TxtValor.Text = 0
            TxtValor.SelectAll()
        End If

        If TxtValor.Text <> "" Then

            Dim Vlr As Decimal = TxtValor.Text

            If Vlr > 0 Then

                CkRepete.Enabled = True
                BttSalvar.Enabled = True

            Else

                CkRepete.Enabled = False
                CkRepete.Checked = False
                BttSalvar.Enabled = False

            End If

        End If

        If TxtValor.Text = "0,00" Then
            TxtValor.SelectAll()
        End If
    End Sub

    Private Sub TxtValor_LostFocus(sender As Object, e As EventArgs) Handles TxtValor.LostFocus
        Try

            Dim _ValorINserido As Decimal = TxtValor.Text

            TxtValor.Text = FormatCurrency(_ValorINserido, NumDigitsAfterDecimal:=2)

        Catch ex As Exception

            MsgBox("Object valor inserido é invalido.", vbOKOnly)
            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)

        End Try

    End Sub

    Private Sub TxtValor_GotFocus(sender As Object, e As EventArgs) Handles TxtValor.GotFocus

        TxtValor.Text = FormatNumber(TxtValor.Text, NumDigitsAfterDecimal:=2)
        TxtValor.SelectAll()

    End Sub

    Private Sub TxtDescricao_TextChanged(sender As Object, e As EventArgs) Handles TxtDescricao.TextChanged

        If TxtDescricao.Text <> "" Then

            RdbValorPagar.Enabled = True
            RdbValorReceber.Enabled = True

            RdbValorPagar.Checked = True

        Else

            RdbValorPagar.Enabled = False
            RdbValorReceber.Enabled = False

            CmbCategoria.Items.Clear()
            CmbCategoria.Text = ""
            CmbCategoria.Enabled = False

        End If

    End Sub

    Dim LstIdCategoria As New ListBox

    Private Sub RdbValorReceber_CheckedChanged(sender As Object, e As EventArgs) Handles RdbValorReceber.CheckedChanged

        If RdbValorReceber.Enabled = True Then
            If RdbValorReceber.Checked = True Then
                CmbCategoria.Enabled = True
                CmbCategoria.Items.Clear()
                CmbCategoria.Text = ""

                'busca categorias de lançamento

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim _Tipo As Boolean = False

                If RdbValorReceber.Checked = True Then
                    _Tipo = True
                End If

                Dim BuscaCategoriasFinanceiro = From plan In LqFinanceiro.CategoriaPlanoContas
                                                Where plan.Categoria Like "*" And plan.Tipo = _Tipo
                                                Select plan.IdCategoriaPlano, plan.Categoria

                CmbCategoria.Items.Clear()
                CmbCategoria.Text = ""
                LstIdCategoria.Items.Clear()

                For Each row In BuscaCategoriasFinanceiro.ToList

                    CmbCategoria.Items.Add(row.Categoria)
                    LstIdCategoria.Items.Add(row.IdCategoriaPlano)

                Next

            End If
        End If

    End Sub

    Private Sub CmbCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoria.SelectedIndexChanged
        If CmbCategoria.Items.Contains(CmbCategoria.Text) Then
            CmbBeneficiario.Enabled = True
            If RdbValorPagar.Checked = True Then
                'busca fornecedores que nao sao de produtos de consumo

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaFornecedores = From fornec In LqBase.Fornecedores
                                        Where fornec.Prestador = True Or fornec.Comissionado = True
                                        Select fornec.Apelido

                CmbBeneficiario.Items.Clear()
                CmbBeneficiario.Text = ""

                For Each row In BuscaFornecedores.ToList

                    CmbBeneficiario.Items.Add(row)

                Next

            Else
                'busca fornecedores que nao sao de produtos de consumo

                Dim LqBase As New DtCadastroDataContext
                LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                Dim BuscaFornecedores = From fornec In LqBase.Fornecedores
                                        Where fornec.Beneficiario = True
                                        Select fornec.Apelido

                CmbBeneficiario.Items.Clear()
                CmbBeneficiario.Text = ""

                For Each row In BuscaFornecedores.ToList

                    CmbBeneficiario.Items.Add(row)

                Next

            End If

        End If
    End Sub

    Private Sub BttAdicionarFornecedor_Click(sender As Object, e As EventArgs) Handles BttAdicionarFornecedor.Click

        If RdbValorPagar.Checked = True Then
            FrmNovoFornecedor.CkFornecedorInsumo.Checked = False
            FrmNovoFornecedor.CkFornecedorInsumo.Enabled = False
            FrmNovoFornecedor.CkPrestador.Checked = True
            FrmNovoFornecedor.CkTransportadora.Enabled = False

            FrmNovoFornecedor.Show(Me)
        Else
            FrmNovoFornecedor.CkFornecedorInsumo.Enabled = False
            FrmNovoFornecedor.CkFornecedorInsumo.Enabled = False
            FrmNovoFornecedor.CkPrestador.Enabled = False
            FrmNovoFornecedor.CkTransportadora.Enabled = True

            FrmNovoFornecedor.Show(Me)
        End If

    End Sub

    Private Sub BttAddCategoria_Click(sender As Object, e As EventArgs) Handles BttAddCategoria.Click

        FrmNovaCategoriaPlanoContas.Show(Me)

    End Sub

    Private Sub CmbBeneficiario_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBeneficiario.SelectedIndexChanged

        If CmbBeneficiario.Items.Contains(CmbBeneficiario.Text) Then

            TxtValor.Enabled = True

        Else

            TxtValor.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
            TxtValor.Enabled = False

        End If
    End Sub

    Private Sub CkAferir_CheckedChanged(sender As Object, e As EventArgs) Handles CkAferir.CheckedChanged

        If CkAferir.Checked = True Then
            Panel3.Enabled = True
        Else
            Panel3.Enabled = False
            NmDiasSolicitar.Value = 1
        End If

    End Sub

    Private Sub FrmNovoLancamento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class