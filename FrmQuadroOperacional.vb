Public Class FrmQuadroOperacional


    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub Label38_Click(sender As Object, e As EventArgs) Handles Label38.Click

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles BttNovoCargo.Click

        LblTituloCargo.ForeColor = Color.SlateGray
        LblTituloCargo.BackColor = Color.Gainsboro

        Pnndash.Visible = False

        PnnColaboradores.Visible = False
        PnnParceiro.Visible = False
        PnnEquipe.Visible = False
        PnnCargos.Visible = True

        BttNovoCargo.Visible = False
        BttBuscarCargo.Visible = False

        PnnCargos.Dock = DockStyle.Fill

        'carrega Beneficios


        Dim buscaBeneficios = From ben In LqBase.Beneficios
                              Where ben.IdBeneficio Like "*"
                              Select ben.IdBeneficio, ben.Descricao

        LstIdBeneficio.Items.Clear()

        For Each row In buscaBeneficios.ToList

            LstIdBeneficio.Items.Add(row.IdBeneficio)
            CmbBenefiicio.Items.Add(row.Descricao)

        Next

        'desailita

        PnnParceiros.Visible = False
        PnnColaborador.Visible = False

    End Sub

    Private Sub TxtValorRemun_TextChanged(sender As Object, e As EventArgs) Handles TxtValorRemun.TextChanged

        If TxtValorRemun.Text = "" Then
            TxtValorRemun.Text = 0
            TxtValorRemun.SelectAll()
        Else
            Dim Valor As Decimal = TxtValorRemun.Text

            If Valor > 0 Then
                CkRemunHora.Enabled = True
                CkMensal.Enabled = True
            Else
                CkRemunHora.Enabled = False
                CkMensal.Enabled = False
                TxtDiaFechamento.Enabled = False

                CkRemunHora.Checked = False
                CkMensal.Checked = False
            End If

        End If

    End Sub

    Private Sub TxtNomeDoCargo_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeDoCargo.TextChanged

        If TxtNomeDoCargo.Text <> "" Then
            TxtValorRemun.Enabled = True
            TxtComVenda.Enabled = True
        Else
            TxtValorRemun.Enabled = False
            TxtComVenda.Enabled = False
            TxtValorRemun.Text = "R$ 0,00"
            TxtComVenda.Text = "0,00%"
        End If

    End Sub

    Private Sub TxtValorRemun_GotFocus(sender As Object, e As EventArgs) Handles TxtValorRemun.GotFocus

        TxtValorRemun.Text = FormatNumber(TxtValorRemun.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtValorRemun_LostFocus(sender As Object, e As EventArgs) Handles TxtValorRemun.LostFocus

        If TxtValorRemun.Text = "" Then
            TxtValorRemun.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
        Else
            TxtValorRemun.Text = FormatCurrency(TxtValorRemun.Text, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub TxtComVenda_TextChanged(sender As Object, e As EventArgs) Handles TxtComVenda.TextChanged

        If TxtComVenda.Text = "" Then
            TxtComVenda.Text = 0
            TxtComVenda.SelectAll()
        Else

            TxtComVenda.Text = TxtComVenda.Text.Replace("%", "")

            Dim Valor As Decimal = TxtComVenda.Text

            If Valor > 0 Then

                If TxtComVenda.Text > 0 Then
                    CkRemunHora.Enabled = True
                Else
                    CkRemunHora.Enabled = False
                End If

                CkMensal.Enabled = True
            Else
                CkRemunHora.Enabled = False
                CkMensal.Enabled = False
                TxtDiaFechamento.Enabled = False

                CkRemunHora.Checked = False
                CkMensal.Checked = False
            End If

        End If

    End Sub

    Private Sub CkMensal_CheckedChanged(sender As Object, e As EventArgs) Handles CkMensal.CheckedChanged

        If CkMensal.Checked = True Or CkRemunHora.Checked = True Then

            TxtDiaFechamento.Enabled = True
            CmbBenefiicio.Enabled = True
            bttAddBeneficio.Enabled = True

            CkSelecionarD.Enabled = True
            CkSelecionarS.Enabled = True
            CkSelecionarT.Enabled = True
            CkSelecionarQ.Enabled = True
            CkSelecionarQu.Enabled = True
            CkSelecionarSe.Enabled = True
            CkSelecionarSa.Enabled = True

            CkFolgaEscala.Enabled = True

        Else

            TxtDiaFechamento.Enabled = False
            TxtDiaFechamento.Value = 1
            CmbBenefiicio.Enabled = False
            CmbBenefiicio.Text = ""
            bttAddBeneficio.Enabled = False

            CkSelecionarD.Enabled = False
            CkSelecionarS.Enabled = False
            CkSelecionarT.Enabled = False
            CkSelecionarQ.Enabled = False
            CkSelecionarQu.Enabled = False
            CkSelecionarSe.Enabled = False
            CkSelecionarSa.Enabled = False

            CkSelecionarD.Checked = False
            CkSelecionarS.Checked = False
            CkSelecionarT.Checked = False
            CkSelecionarQ.Checked = False
            CkSelecionarQu.Checked = False
            CkSelecionarSe.Checked = False
            CkSelecionarSa.Checked = False

            CkFolgaEscala.Enabled = False
            CkFolgaEscala.Checked = False

        End If

    End Sub

    Public LstIdBeneficio As New ListBox

    Private Sub bttAddBeneficio_Click(sender As Object, e As EventArgs) Handles bttAddBeneficio.Click

        FrmNovobeneficio.Show(Me)

    End Sub

    Private Sub CmbBenefiicio_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbBenefiicio.SelectedIndexChanged

        If CmbBenefiicio.Items.Contains(CmbBenefiicio.Text) Then

            TxtValorBeneficio.Enabled = True

        Else

            TxtValorBeneficio.Enabled = False
            TxtValorBeneficio.Text = "R$ 0,00"

        End If

    End Sub

    Public Primeiro As Boolean = False

    Private Sub FrmQuadroOperacional_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Popula_Dash()

    End Sub

    Public Sub Popula_Dash()

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        Dim BuscaQuadro = From quad In LqBase.Funcionarios
                          Where quad.IdFuncionario Like "*" And quad.IdCargo <> 0
                          Select quad.IdFuncionario

        LblColaboradores.Text = BuscaQuadro.Count

        Dim BuscaCargos = From quad In LqBase.Cargos
                          Where quad.IdCargo
                          Select quad.IdCargo

        LblCargos.Text = BuscaCargos.Count

        'busca parceiros

        Dim BuscaParceiros = From parc In LqBase.ParceirosComerciais
                             Where parc.IdParceiro Like "*"
                             Select parc.IdParceiro

        LblParceiros.Text = BuscaParceiros.Count

        'verifica 

        Dim LqOficina As New LqOficinaDataContext
        LqOficina.Connection.ConnectionString = FrmPrincipal.ConnectionStringOficina

        Dim InicioDatas As Date = Today.Date.AddMonths(-2)

        Dim LstDemandaRecebida As New ListBox
        Dim LstDemandaExecução As New ListBox
        Dim LstDemandaConcluido As New ListBox

        Dim LstDemandaFunci As New ListBox
        Dim Funcionarios As New ListBox

        Dim Dias As New ListBox

        Dim Recebidos As Integer = 0
        Dim Executando As Integer = 0
        Dim Concluido As Integer = 0

        While InicioDatas <= Today

            Dim BuscaVistoriaInciada = From vist In LqOficina.Vistorias
                                       Where vist.Concluido = True And vist.NivelReq = 0 And vist.DataInicioVistoria.Value.Date = InicioDatas.Date
                                       Select vist.DataInicioVistoria, vist.IdTecnico

            Dias.Items.Add(InicioDatas.Date)

            If BuscaVistoriaInciada.Count > 0 Then

                Recebidos += BuscaVistoriaInciada.Count

                LstDemandaRecebida.Items.Add(Recebidos)
                LstDemandaExecução.Items.Add(Executando)
                LstDemandaConcluido.Items.Add(Concluido)

                Dim LstCargos As New ListBox

                For Each row2 In BuscaVistoriaInciada.ToList

                    'busca cargos capazes de executar

                    Dim BuscaCargo = From car In LqBase.Funcionarios
                                     Where car.IdFuncionario = row2.IdTecnico
                                     Select car.IdCargo

                    If BuscaCargo.Count > 0 Then
                        LstCargos.Items.Add(BuscaCargo.First)
                    Else
                        LstCargos.Items.Add(0)
                    End If

                Next

                Dim todos As Integer = 0

                For i As Integer = 0 To LstCargos.Items.Count - 1 Step 1

                    Dim BuscaTodos = From car In LqBase.Funcionarios
                                     Where car.IdCargo = LstCargos.Items(i).ToString
                                     Select car.IdFuncionario

                    todos += BuscaTodos.Count

                Next

                LstDemandaFunci.Items.Add(todos)

            End If

            'pinta todos

            Dim BuscasoluçãoVistoria = From vist In LqOficina.Vistorias
                                           Where vist.Concluido = True And vist.NivelReq = 1 And vist.DataInicioVistoria.Value.Date = InicioDatas.Date
                                           Select vist.DataInicioVistoria, vist.IdTecnico

            If BuscasoluçãoVistoria.Count > 0 Then

                Recebidos -= BuscasoluçãoVistoria.Count
                Executando += BuscasoluçãoVistoria.Count

                LstDemandaRecebida.Items.Add(Recebidos)
                LstDemandaExecução.Items.Add(Executando)
                LstDemandaConcluido.Items.Add(Concluido)

                Dim LstCargos As New ListBox

                For Each row2 In BuscasoluçãoVistoria.ToList

                    'busca cargos capazes de executar

                    Dim BuscaCargo = From car In LqBase.Funcionarios
                                     Where car.IdFuncionario = row2.IdTecnico
                                     Select car.IdCargo

                    If BuscaCargo.Count > 0 Then
                        LstCargos.Items.Add(BuscaCargo.First)
                    Else
                        LstCargos.Items.Add(0)
                    End If

                Next

                Dim todos As Integer = 0

                For i As Integer = 0 To LstCargos.Items.Count - 1 Step 1

                    Dim BuscaTodos = From car In LqBase.Funcionarios
                                     Where car.IdCargo = LstCargos.Items(i).ToString
                                     Select car.IdFuncionario

                    todos += BuscaTodos.Count

                Next

                LstDemandaFunci.Items.Add(todos)

            End If

            Dim BuscaVistoriaConc = From vist In LqOficina.Vistorias
                                    Where vist.Concluido = True And vist.NivelReq = 2 And vist.DataInicioVistoria.Value.Date = InicioDatas.Date
                                    Select vist.DataInicioVistoria, vist.IdTecnico

            If BuscaVistoriaConc.Count > 0 Then

                Executando -= BuscaVistoriaConc.Count
                Concluido += BuscaVistoriaConc.Count

                LstDemandaRecebida.Items.Add(Recebidos)
                LstDemandaExecução.Items.Add(Executando)
                LstDemandaConcluido.Items.Add(Concluido)

                Dim LstCargos As New ListBox

                For Each row2 In BuscasoluçãoVistoria.ToList

                    'busca cargos capazes de executar

                    Dim BuscaCargo = From car In LqBase.Funcionarios
                                     Where car.IdFuncionario = row2.IdTecnico
                                     Select car.IdCargo

                    If BuscaCargo.Count > 0 Then
                        LstCargos.Items.Add(BuscaCargo.First)
                    Else
                        LstCargos.Items.Add(0)
                    End If

                Next

                Dim todos As Integer = 0

                For i As Integer = 0 To LstCargos.Items.Count - 1 Step 1

                    Dim BuscaTodos = From car In LqBase.Funcionarios
                                     Where car.IdCargo = LstCargos.Items(i).ToString
                                     Select car.IdFuncionario

                    todos += BuscaTodos.Count

                Next

                LstDemandaFunci.Items.Add(todos)

            End If

            If Dias.Items.Count > LstDemandaRecebida.Items.Count Then

                If LstDemandaRecebida.Items.Count > 0 Then
                    LstDemandaRecebida.Items.Add(Recebidos)
                    LstDemandaExecução.Items.Add(Executando)
                    LstDemandaConcluido.Items.Add(Concluido)

                    LstDemandaFunci.Items.Add(LstDemandaFunci.Items(LstDemandaFunci.Items.Count - 1).ToString)
                Else
                    LstDemandaRecebida.Items.Add(Recebidos)
                    LstDemandaExecução.Items.Add(Executando)
                    LstDemandaConcluido.Items.Add(Concluido)

                    If LstDemandaFunci.Items.Count > 0 Then
                        LstDemandaFunci.Items.Add(LstDemandaFunci.Items(LstDemandaFunci.Items.Count - 1).ToString)
                    Else
                        LstDemandaFunci.Items.Add(0)
                    End If
                End If

            End If

            InicioDatas = InicioDatas.AddDays(1)

        End While

        'Corrige erros

        If LstDemandaFunci.Items.Count > Dias.Items.Count Then

            LstDemandaFunci.Items.RemoveAt(LstDemandaFunci.Items.Count - 1)

        End If

        If LstDemandaExecução.Items.Count > Dias.Items.Count Then

            LstDemandaExecução.Items.RemoveAt(LstDemandaExecução.Items.Count - 1)

        End If

        If LstDemandaConcluido.Items.Count > Dias.Items.Count Then

            LstDemandaConcluido.Items.RemoveAt(LstDemandaConcluido.Items.Count - 1)

        End If

        If LstDemandaRecebida.Items.Count > Dias.Items.Count Then

            LstDemandaRecebida.Items.RemoveAt(LstDemandaRecebida.Items.Count - 1)

        End If

        'Chart1.Series(3).Points.DataBindXY(Dias.Items, LstDemandaFunci.Items)
        'Chart1.Series(2).Points.DataBindXY(Dias.Items, LstDemandaExecução.Items)
        'Chart1.Series(1).Points.DataBindXY(Dias.Items, LstDemandaConcluido.Items)
        'Chart1.Series(0).Points.DataBindXY(Dias.Items, LstDemandaRecebida.Items)

    End Sub

    Private Sub TxtValorBeneficio_TextChanged(sender As Object, e As EventArgs) Handles TxtValorBeneficio.TextChanged

        If TxtValorBeneficio.Text = "" Then

            TxtValorBeneficio.Text = 0
            TxtValorBeneficio.SelectAll()

        Else

            'verifica se acaa com %

            If TxtValorBeneficio.Text.EndsWith("%") Then

            Else

                Dim ValorBeneficio As Decimal = TxtValorBeneficio.Text

                If ValorBeneficio > 0 Then

                    RdbbVlrSemanalmente.Enabled = True
                    RdbVlrDiareamente.Enabled = True
                    RdbVlrMensalmente.Enabled = True

                Else

                    RdbbVlrSemanalmente.Enabled = False
                    RdbVlrDiareamente.Enabled = False
                    RdbVlrMensalmente.Enabled = False

                    RdbbVlrSemanalmente.Checked = False
                    RdbVlrDiareamente.Checked = False
                    RdbVlrMensalmente.Checked = False

                End If


            End If

        End If

    End Sub

    Private Sub TxtValorBeneficio_GotFocus(sender As Object, e As EventArgs) Handles TxtValorBeneficio.GotFocus

        TxtValorBeneficio.Text = FormatNumber(TxtValorBeneficio.Text, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub TxtValorBeneficio_LostFocus(sender As Object, e As EventArgs) Handles TxtValorBeneficio.LostFocus

        If TxtValorBeneficio.Text = "" Then
            TxtValorBeneficio.Text = FormatCurrency(0, NumDigitsAfterDecimal:=2)
        Else
            TxtValorBeneficio.Text = FormatCurrency(TxtValorBeneficio.Text, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub CkRemunHora_CheckedChanged(sender As Object, e As EventArgs) Handles CkRemunHora.CheckedChanged

        If CkMensal.Checked = True Or CkRemunHora.Checked = True Then

            TxtDiaFechamento.Enabled = True
            CmbBenefiicio.Enabled = True
            bttAddBeneficio.Enabled = True

            CkSelecionarD.Enabled = True
            CkSelecionarS.Enabled = True
            CkSelecionarT.Enabled = True
            CkSelecionarQ.Enabled = True
            CkSelecionarQu.Enabled = True
            CkSelecionarSe.Enabled = True
            CkSelecionarSa.Enabled = True

            CkFolgaEscala.Checked = True

        Else

            TxtDiaFechamento.Enabled = False
            TxtDiaFechamento.Value = 1
            CmbBenefiicio.Enabled = False
            CmbBenefiicio.Text = ""
            bttAddBeneficio.Enabled = False


            CkSelecionarD.Enabled = False
            CkSelecionarS.Enabled = False
            CkSelecionarT.Enabled = False
            CkSelecionarQ.Enabled = False
            CkSelecionarQu.Enabled = False
            CkSelecionarSe.Enabled = False
            CkSelecionarSa.Enabled = False

            CkSelecionarD.Checked = False
            CkSelecionarS.Checked = False
            CkSelecionarT.Checked = False
            CkSelecionarQ.Checked = False
            CkSelecionarQu.Checked = False
            CkSelecionarSe.Checked = False
            CkSelecionarSa.Checked = False

            CkFolgaEscala.Checked = False
            CkFolgaEscala.Enabled = False

        End If

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RdbVlrDiareamente.CheckedChanged

        If RdbVlrMensalmente.Checked = True Or RdbVlrDiareamente.Checked = True Or RdbbVlrSemanalmente.Checked = True Then
            CkDesconto.Enabled = True
            BttVincular.Enabled = True
            Atribuição = RdbVlrDiareamente.Text
        ElseIf RdbVlrMensalmente.Checked = False And RdbVlrDiareamente.Checked = False And RdbbVlrSemanalmente.Checked = False Then
            CkDesconto.Enabled = False
            BttVincular.Enabled = False
            CkDesconto.Checked = False
        End If

    End Sub

    Private Sub RdbVlrMensalmente_CheckedChanged(sender As Object, e As EventArgs) Handles RdbVlrMensalmente.CheckedChanged

        If RdbVlrMensalmente.Checked = True Or RdbVlrDiareamente.Checked = True Or RdbbVlrSemanalmente.Checked = True Then
            CkDesconto.Enabled = True
            BttVincular.Enabled = True
            Atribuição = RdbVlrMensalmente.Text
        ElseIf RdbVlrMensalmente.Checked = False And RdbVlrDiareamente.Checked = False And RdbbVlrSemanalmente.Checked = False Then
            CkDesconto.Enabled = False
            BttVincular.Enabled = False
            CkDesconto.Checked = False
        End If

    End Sub

    Private Sub RdbbVlrSemanalmente_CheckedChanged(sender As Object, e As EventArgs) Handles RdbbVlrSemanalmente.CheckedChanged

        If RdbVlrMensalmente.Checked = True Or RdbVlrDiareamente.Checked = True Or RdbbVlrSemanalmente.Checked = True Then
            CkDesconto.Enabled = True
            BttVincular.Enabled = True
            Atribuição = RdbbVlrSemanalmente.Text
        ElseIf RdbVlrMensalmente.Checked = False And RdbVlrDiareamente.Checked = False And RdbbVlrSemanalmente.Checked = False Then
            CkDesconto.Enabled = False
            BttVincular.Enabled = False
            CkDesconto.Checked = False
        End If

    End Sub

    Dim Atribuição As String

    Private Sub BttVincular_Click(sender As Object, e As EventArgs) Handles BttVincular.Click

        'adiciona no grid

        DtBeneficios.Rows.Add(LstIdBeneficio.Items(CmbBenefiicio.SelectedIndex).ToString, CmbBenefiicio.Text, TxtValorBeneficio.Text, Atribuição, CkDesconto.CheckState, My.Resources.Cancel_40972)

        CmbBenefiicio.Text = ""


    End Sub

    Private Sub CmbBenefiicio_TextChanged(sender As Object, e As EventArgs) Handles CmbBenefiicio.TextChanged

        If CmbBenefiicio.Items.Contains(CmbBenefiicio.Text) Then

            TxtValorBeneficio.Enabled = True

        Else

            TxtValorBeneficio.Enabled = False
            TxtValorBeneficio.Text = "R$ 0,00"

        End If

    End Sub

    Private Sub Label49_Click(sender As Object, e As EventArgs) Handles Label49.Click

    End Sub

    Private Sub CkSelecionarD_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarD.CheckedChanged

        If CkSelecionarD.Checked = True Then
            'muda a cor do domingo
            LblD.BackColor = Color.DarkOrange
            LblD.ForeColor = Color.WhiteSmoke
            '
            TxtInicioD.Enabled = True
            TxtTerminoD.Enabled = True
            TxtIntervaloD.Enabled = True
            TxtInicioD.Text = "00:00"
            TxtTerminoD.Text = "00:00"
            TxtIntervaloD.Text = "00:00"

            CalculaJornada()

            TxtInicioD.Focus()

        Else
            'muda a cor do domingo
            LblD.BackColor = Color.Gainsboro
            LblD.ForeColor = Color.DarkSlateGray
            '
            TxtInicioD.Enabled = False
            TxtTerminoD.Enabled = False
            TxtIntervaloD.Enabled = False
            TxtInicioD.Text = ""
            TxtTerminoD.Text = ""
            TxtIntervaloD.Text = ""

        End If
    End Sub

    Private Sub CkSelecionarS_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarS.CheckedChanged

        If CkSelecionarS.Checked = True Then
            'muda a cor do domingo
            LblS.BackColor = Color.DarkOrange
            LblS.ForeColor = Color.WhiteSmoke
            '
            TxtInicioS.Enabled = True
            TxtTerminoS.Enabled = True
            TxtIntervaloS.Enabled = True
            TxtInicioS.Text = "00:00"
            TxtTerminoS.Text = "00:00"
            TxtIntervaloS.Text = "00:00"

            CalculaJornada()

            TxtInicioS.Focus()

        Else
            'muda a cor do domingo
            LblS.BackColor = Color.Gainsboro
            LblS.ForeColor = Color.DarkSlateGray
            '
            TxtInicioS.Enabled = False
            TxtTerminoS.Enabled = False
            TxtIntervaloS.Enabled = False
            TxtInicioS.Text = ""
            TxtTerminoS.Text = ""
            TxtIntervaloS.Text = ""

        End If

    End Sub

    Private Sub TxtInicioSeX_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioSe.TextChanged

        If TxtInicioSe.Text.Length = 5 Then
            Try

                TxtInicioSe.Text = FormatDateTime(TxtInicioSe.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoSe.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtInicioSe.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub CkSelecionarT_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarT.CheckedChanged
        If CkSelecionarT.Checked = True Then
            'muda a cor do domingo
            LblT.BackColor = Color.DarkOrange
            LblT.ForeColor = Color.WhiteSmoke
            '
            TxtInicioT.Enabled = True
            TxtTerminoT.Enabled = True
            TxtIntervaloT.Enabled = True
            TxtInicioT.Text = "00:00"
            TxtTerminoT.Text = "00:00"
            TxtIntervaloT.Text = "00:00"

            CalculaJornada()

            TxtInicioT.Focus()

        Else
            'muda a cor do domingo
            LblT.BackColor = Color.Gainsboro
            LblT.ForeColor = Color.DarkSlateGray
            '
            TxtInicioT.Enabled = False
            TxtTerminoT.Enabled = False
            TxtIntervaloT.Enabled = False
            TxtInicioT.Text = ""
            TxtTerminoT.Text = ""
            TxtIntervaloT.Text = ""

        End If

    End Sub

    Private Sub CkSelecionarQ_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarQ.CheckedChanged
        If CkSelecionarQ.Checked = True Then
            'muda a cor do domingo
            LblQ.BackColor = Color.DarkOrange
            LblQ.ForeColor = Color.WhiteSmoke
            '
            TxtInicioQ.Enabled = True
            TxtTerminoQ.Enabled = True
            TxtIntervaloQ.Enabled = True
            TxtInicioQ.Text = "00:00"
            TxtTerminoQ.Text = "00:00"
            TxtIntervaloQ.Text = "00:00"

            CalculaJornada()

            TxtInicioQ.Focus()

        Else
            'muda a cor do domingo
            LblQ.BackColor = Color.Gainsboro
            LblQ.ForeColor = Color.DarkSlateGray
            '
            TxtInicioQ.Enabled = False
            TxtTerminoQ.Enabled = False
            TxtIntervaloQ.Enabled = False
            TxtInicioQ.Text = ""
            TxtTerminoQ.Text = ""
            TxtIntervaloQ.Text = ""

        End If

    End Sub

    Private Sub CkSelecionarQu_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarQu.CheckedChanged
        If CkSelecionarQu.Checked = True Then
            'muda a cor do domingo
            LblQu.BackColor = Color.DarkOrange
            LblQu.ForeColor = Color.WhiteSmoke
            '
            TxtInicioQu.Enabled = True
            TxtTerminoQu.Enabled = True
            TxtIntervaloQu.Enabled = True
            TxtInicioQu.Text = "00:00"
            TxtTerminoQu.Text = "00:00"
            TxtIntervaloQu.Text = "00:00"

            CalculaJornada()

            TxtInicioQu.Focus()

        Else
            'muda a cor do domingo
            LblQu.BackColor = Color.Gainsboro
            LblQu.ForeColor = Color.DarkSlateGray
            '
            TxtInicioQu.Enabled = False
            TxtTerminoQu.Enabled = False
            TxtIntervaloQu.Enabled = False
            TxtInicioQu.Text = ""
            TxtTerminoQu.Text = ""
            TxtIntervaloQu.Text = ""

        End If

    End Sub

    Private Sub CkSelecionarSe_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarSe.CheckedChanged
        If CkSelecionarSe.Checked = True Then
            'muda a cor do domingo
            LblSe.BackColor = Color.DarkOrange
            LblSe.ForeColor = Color.WhiteSmoke
            '
            TxtInicioSe.Enabled = True
            TxtTerminoSe.Enabled = True
            TxtIntervaloSe.Enabled = True
            TxtInicioSe.Text = "00:00"
            TxtTerminoSe.Text = "00:00"
            TxtIntervaloSe.Text = "00:00"

            CalculaJornada()

            TxtInicioSe.Focus()

        Else
            'muda a cor do domingo
            LblSe.BackColor = Color.Gainsboro
            LblSe.ForeColor = Color.DarkSlateGray
            '
            TxtInicioSe.Enabled = False
            TxtTerminoSe.Enabled = False
            TxtIntervaloSe.Enabled = False
            TxtInicioSe.Text = ""
            TxtTerminoSe.Text = ""
            TxtIntervaloSe.Text = ""

        End If

    End Sub

    Private Sub CkSelecionarSa_CheckedChanged(sender As Object, e As EventArgs) Handles CkSelecionarSa.CheckedChanged
        If CkSelecionarSa.Checked = True Then
            'muda a cor do domingo
            LblSa.BackColor = Color.DarkOrange
            LblSa.ForeColor = Color.WhiteSmoke
            '
            TxtInicioSa.Enabled = True
            TxtTerminoSa.Enabled = True
            TxtIntervaloSa.Enabled = True
            TxtInicioSa.Text = "00:00"
            TxtTerminoSa.Text = "00:00"
            TxtIntervaloSa.Text = "00:00"

            CalculaJornada()

            TxtInicioSa.Focus()

        Else
            'muda a cor do domingo
            LblSa.BackColor = Color.Gainsboro
            LblSa.ForeColor = Color.DarkSlateGray
            '
            TxtInicioSa.Enabled = False
            TxtTerminoSa.Enabled = False
            TxtIntervaloSa.Enabled = False
            TxtInicioSa.Text = ""
            TxtTerminoSa.Text = ""
            TxtIntervaloSa.Text = ""

        End If

    End Sub

    Public Sub CalculaJornada()

        Dim Domingo As Date = Today
        Dim Segunda As Date = Today
        Dim Terça As Date = Today
        Dim Quarta As Date = Today
        Dim Quinta As Date = Today
        Dim Sexta As Date = Today
        Dim Sabado As Date = Today

        Dim HRAcum As Integer = 0

        If CkSelecionarD.Checked = True Then

            Domingo = Today & " " & TxtInicioD.Text

            While Domingo < Today & " " & TxtTerminoD.Text
                HRAcum += 1
                Domingo = Domingo.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloD.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarS.Checked = True Then

            Segunda = Today & " " & TxtInicioS.Text

            While Segunda < Today & " " & TxtTerminoS.Text
                HRAcum += 1
                Segunda = Segunda.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloS.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarT.Checked = True Then

            Terça = Today & " " & TxtInicioT.Text

            While Terça < Today & " " & TxtTerminoT.Text
                HRAcum += 1
                Terça = Terça.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloT.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarQ.Checked = True Then

            Quarta = Today & " " & TxtInicioQ.Text

            While Quarta < Today & " " & TxtTerminoQ.Text
                HRAcum += 1
                Quarta = Quarta.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloQ.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarQu.Checked = True Then

            Quinta = Today & " " & TxtInicioQu.Text

            While Quinta < Today & " " & TxtTerminoQu.Text
                HRAcum += 1
                Quinta = Quinta.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloQu.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarSe.Checked = True Then

            Sexta = Today & " " & TxtInicioSe.Text

            While Sexta < Today & " " & TxtTerminoSe.Text
                HRAcum += 1
                Sexta = Sexta.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloSe.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        If CkSelecionarSa.Checked = True Then

            Sabado = Today & " " & TxtInicioSa.Text

            While Sabado < Today & " " & TxtTerminoSa.Text
                HRAcum += 1
                Sabado = Sabado.AddMinutes(1)
            End While

            Dim Intervalo As Date = Today & " " & TxtIntervaloSa.Text

            While Intervalo > Today & " " & "00:00"
                HRAcum -= 1
                Intervalo = Intervalo.AddMinutes(-1)
            End While

        End If

        Dim Hr As Integer
        Dim Mn As Integer

        Dim HrTT As Integer

        While HRAcum > 0

            If Mn < 59 Then

                Mn += 1
                HRAcum -= 1

            Else

                HRAcum -= 1

                Mn = 0
                Hr += 1

            End If

        End While

        Dim HrString As String = Hr

        If HrString.Length < 2 Then
            HrString = "0" & Hr
        End If

        Dim MinString As String = Mn

        If MinString.Length < 2 Then
            MinString = "0" & Mn
        End If
        LblJonada.Text = HrString & ":" & MinString & " HS/Semana"

    End Sub

    Private Sub TxtInicioD_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioD.TextChanged

        If TxtInicioD.Text.Length = 5 Then
            Try

                TxtInicioD.Text = FormatDateTime(TxtInicioD.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoD.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoD.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtInicioD_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioD.GotFocus
        TxtInicioD.SelectAll()
    End Sub

    Private Sub TxtTerminoD_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoD.TextChanged

        If TxtTerminoD.Text.Length = 5 Then
            Try

                TxtTerminoD.Text = FormatDateTime(TxtTerminoD.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloD.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloD.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminoD_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoD.GotFocus
        TxtTerminoD.SelectAll()
    End Sub

    Private Sub TxtintervaloD_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloD.TextChanged


        If TxtIntervaloD.Text.Length = 5 Then
            Try

                TxtIntervaloD.Text = FormatDateTime(TxtIntervaloD.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloD.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervaloD_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloD.GotFocus
        TxtIntervaloD.SelectAll()
    End Sub

    Private Sub TxtIntervaloD_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloD.LostFocus
        If TxtIntervaloD.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloD.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminoD_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoD.LostFocus
        If TxtTerminoD.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoD.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioD_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioD.LostFocus
        If TxtInicioD.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioD.Text = "00:00"
        End If
    End Sub

    Private Sub TxtInicioSeg_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioS.TextChanged

        If TxtInicioS.Text.Length = 5 Then
            Try

                TxtInicioS.Text = FormatDateTime(TxtInicioS.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoS.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoS.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtInicioS_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioS.GotFocus
        TxtInicioS.SelectAll()
    End Sub

    Private Sub TxtTerminoS_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoS.TextChanged

        If TxtTerminoS.Text.Length = 5 Then
            Try

                TxtTerminoS.Text = FormatDateTime(TxtTerminoS.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloS.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloS.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminoS_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoS.GotFocus
        TxtTerminoS.SelectAll()
    End Sub

    Private Sub TxtintervaloS_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloS.TextChanged


        If TxtIntervaloS.Text.Length = 5 Then
            Try

                TxtIntervaloS.Text = FormatDateTime(TxtIntervaloS.Text, DateFormat.ShortTime)

                CalculaJornada()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervaloS_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloS.GotFocus
        TxtIntervaloS.SelectAll()
    End Sub

    Private Sub TxtIntervaloS_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloS.LostFocus
        If TxtIntervaloS.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloS.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminoS_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoS.LostFocus
        If TxtTerminoS.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoS.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioS_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioS.LostFocus
        If TxtInicioS.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioS.Text = "00:00"
        End If
    End Sub

    Private Sub TxtInicioT_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioT.TextChanged

        If TxtInicioT.Text.Length = 5 Then
            Try

                TxtInicioT.Text = FormatDateTime(TxtInicioT.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoT.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoT.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtIniciot_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioT.GotFocus
        TxtInicioT.SelectAll()
    End Sub

    Private Sub TxtTerminoT_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoT.TextChanged

        If TxtTerminoT.Text.Length = 5 Then
            Try

                TxtTerminoT.Text = FormatDateTime(TxtTerminoT.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloT.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloT.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminoT_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoT.GotFocus
        TxtTerminoT.SelectAll()
    End Sub

    Private Sub TxtintervaloT_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloT.TextChanged


        If TxtIntervaloT.Text.Length = 5 Then
            Try

                TxtIntervaloT.Text = FormatDateTime(TxtIntervaloT.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloT.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervaloT_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloT.GotFocus
        TxtIntervaloT.SelectAll()
    End Sub

    Private Sub TxtIntervaloT_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloT.LostFocus
        If TxtIntervaloT.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloT.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminoT_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoT.LostFocus
        If TxtTerminoT.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoT.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioT_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioT.LostFocus
        If TxtInicioT.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioT.Text = "00:00"
        End If
    End Sub


    Private Sub TxtInicioq_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioQ.TextChanged

        If TxtInicioQ.Text.Length = 5 Then
            Try

                TxtInicioQ.Text = FormatDateTime(TxtInicioQ.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoQ.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoQ.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtInicioq_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioQ.GotFocus
        TxtInicioQ.SelectAll()
    End Sub

    Private Sub TxtTerminoq_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoQ.TextChanged

        If TxtTerminoQ.Text.Length = 5 Then
            Try

                TxtTerminoQ.Text = FormatDateTime(TxtTerminoQ.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloQ.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloQ.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminoq_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoQ.GotFocus
        TxtTerminoQ.SelectAll()
    End Sub

    Private Sub Txtintervaloq_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloQ.TextChanged


        If TxtIntervaloQ.Text.Length = 5 Then
            Try

                TxtIntervaloQ.Text = FormatDateTime(TxtIntervaloQ.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloQ.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervaloq_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloQ.GotFocus
        TxtIntervaloQ.SelectAll()
    End Sub

    Private Sub TxtIntervaloq_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloQ.LostFocus
        If TxtIntervaloQ.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloQ.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminoq_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoQ.LostFocus
        If TxtTerminoQ.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoQ.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioQ_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioQ.LostFocus
        If TxtInicioQ.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioQ.Text = "00:00"
        End If
    End Sub

    Private Sub TxtInicioqu_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioQu.TextChanged

        If TxtInicioQu.Text.Length = 5 Then
            Try

                TxtInicioQu.Text = FormatDateTime(TxtInicioQu.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoQu.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoQu.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtInicioqu_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioQu.GotFocus
        TxtInicioQu.SelectAll()
    End Sub

    Private Sub TxtTerminoqu_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoQu.TextChanged

        If TxtTerminoQu.Text.Length = 5 Then
            Try

                TxtTerminoQu.Text = FormatDateTime(TxtTerminoQu.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloQu.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloQu.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminoqu_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoQu.GotFocus
        TxtTerminoQu.SelectAll()
    End Sub

    Private Sub Txtintervaloqu_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloQu.TextChanged


        If TxtIntervaloQu.Text.Length = 5 Then
            Try

                TxtIntervaloQu.Text = FormatDateTime(TxtIntervaloQu.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloQu.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervaloqu_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloQu.GotFocus
        TxtIntervaloQu.SelectAll()
    End Sub

    Private Sub TxtIntervaloqu_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloQu.LostFocus
        If TxtIntervaloQu.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloQu.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminoqu_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoQu.LostFocus
        If TxtTerminoQu.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoQu.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioQu_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioQu.LostFocus
        If TxtInicioQu.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioQu.Text = "00:00"
        End If
    End Sub


    Private Sub TxtIniciose_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioSe.TextChanged

        If TxtInicioSe.Text.Length = 5 Then
            Try

                TxtInicioSe.Text = FormatDateTime(TxtInicioSe.Text, DateFormat.ShortTime)
                TxtTerminoSe.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoSe.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtIniciose_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioSe.GotFocus
        TxtInicioSe.SelectAll()
    End Sub

    Private Sub TxtTerminose_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoSe.TextChanged

        If TxtTerminoSe.Text.Length = 5 Then
            Try

                TxtTerminoSe.Text = FormatDateTime(TxtTerminoSe.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloSe.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloSe.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminose_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoSe.GotFocus
        TxtTerminoSe.SelectAll()
    End Sub

    Private Sub Txtintervalose_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloSe.TextChanged


        If TxtIntervaloSe.Text.Length = 5 Then
            Try

                TxtIntervaloSe.Text = FormatDateTime(TxtIntervaloSe.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloSe.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervalose_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloSe.GotFocus
        TxtIntervaloSe.SelectAll()
    End Sub

    Private Sub TxtIntervalse_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloSe.LostFocus
        If TxtIntervaloSe.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloSe.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminose_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoSe.LostFocus
        If TxtTerminoSe.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoSe.Text = "00:00"
        End If

    End Sub

    Private Sub TxtInicioSe_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioSe.LostFocus
        If TxtInicioSe.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioSe.Text = "00:00"
        End If
    End Sub


    Private Sub TxtIniciosa_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioSa.TextChanged

        If TxtInicioSa.Text.Length = 5 Then
            Try

                TxtInicioSa.Text = FormatDateTime(TxtInicioSa.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtTerminoSa.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtTerminoSa.Text = "00:00"
            End Try

        End If

    End Sub

    Private Sub TxtIniciosa_GotFocus(sender As Object, e As EventArgs) Handles TxtInicioSa.GotFocus
        TxtInicioSa.SelectAll()
    End Sub

    Private Sub TxtTerminosa_TextChanged(sender As Object, e As EventArgs) Handles TxtTerminoSa.TextChanged

        If TxtTerminoSa.Text.Length = 5 Then
            Try

                TxtTerminoSa.Text = FormatDateTime(TxtTerminoSa.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloSa.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
                TxtIntervaloSa.Text = "00:00"

            End Try

        End If

    End Sub

    Private Sub TxtTerminosa_GotFocus(sender As Object, e As EventArgs) Handles TxtTerminoSa.GotFocus
        TxtTerminoSa.SelectAll()
    End Sub

    Private Sub Txtintervalosa_TextChanged(sender As Object, e As EventArgs) Handles TxtIntervaloSa.TextChanged


        If TxtIntervaloSa.Text.Length = 5 Then
            Try

                TxtIntervaloSa.Text = FormatDateTime(TxtIntervaloSa.Text, DateFormat.ShortTime)

                CalculaJornada()

                TxtIntervaloSa.Focus()

            Catch ex As Exception
                MsgBox("O Valor informado é invalido.", vbOKOnly)
            End Try

        End If


    End Sub

    Private Sub TxtIntervalosa_GotFocus(sender As Object, e As EventArgs) Handles TxtIntervaloSa.GotFocus
        TxtIntervaloSa.SelectAll()
    End Sub

    Private Sub TxtIntervalosa_LostFocus(sender As Object, e As EventArgs) Handles TxtIntervaloSa.LostFocus
        If TxtIntervaloSa.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtIntervaloSa.Text = "00:00"
        End If
    End Sub

    Private Sub TxtTerminosa_LostFocus(sender As Object, e As EventArgs) Handles TxtTerminoSa.LostFocus
        If TxtTerminoSa.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtTerminoSa.Text = "00:00"
        End If

    End Sub

    Private Sub TxtIniciosa_LostFocus(sender As Object, e As EventArgs) Handles TxtInicioSa.LostFocus
        If TxtInicioSa.Text.Length < 5 Then
            MsgBox("O Valor informado é invalido.", vbOKOnly)
            TxtInicioSa.Text = "00:00"
        End If
    End Sub

    Private Sub BttSalvarCargo_Click(sender As Object, e As EventArgs) Handles BttSalvarCargo.Click

        Pnndash.Visible = True
        PnnCargos.Visible = False

        PnnColaboradores.Visible = True
        PnnParceiro.Visible = True
        PnnEquipe.Visible = True
        PnnDisCargo.Visible = True

        BttNovoCargo.Visible = True
        BttBuscarCargo.Visible = True

        'cria novo cargo

        LqBase.InsereNovoCargo(TxtNomeDoCargo.Text, TxtValorRemun.Text, TxtComVenda.Text.Replace("%", ""), CkMensal.CheckState, CkRemunHora.CheckState, TxtDiaFechamento.Value, 0)

        'buscaUltimoCadastro

        Dim buscaCargo = From carg In LqBase.Cargos
                             Where carg.IdCargo Like "*"
                             Select carg.IdCargo
                             Order By IdCargo Descending

        'varre beneficios

        For Each row As DataGridViewRow In DtBeneficios.Rows

            Dim _IdCargo As Integer = buscaCargo.First
            Dim _IdBeneficio As Integer = row.Cells(0).Value

            Dim _ValorBeneficio As Decimal = row.Cells(2).Value

            Dim Desconto As Boolean = row.Cells(4).Value

            LqBase.InsereNovoBeneficioCargo(_IdCargo, _IdBeneficio, row.Cells(1).Value, Desconto, _ValorBeneficio, row.Cells(3).Value)

        Next

        'verifica e salva escala

        If CkSelecionarD.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioD.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoD.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloD.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 1, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarS.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioS.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoS.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloS.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 2, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarT.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioT.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoT.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloT.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 3, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarQ.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioQ.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoQ.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloQ.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 4, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarQu.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioQu.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoQu.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloQu.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 5, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarSe.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioSe.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoSe.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloSe.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 6, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        If CkSelecionarSa.Checked = True Then

            Dim _IdCargo As Integer = buscaCargo.First
            Dim HrInicio As Date = Today.Date & " " & TxtInicioSa.Text
            Dim HrTermino As Date = Today.Date & " " & TxtTerminoSa.Text
            Dim HrINtervalo As Date = Today.Date & " " & TxtIntervaloSa.Text

            LqBase.InsereNovaEscalaCargo(_IdCargo, 7, HrInicio.TimeOfDay, HrTermino.TimeOfDay, HrINtervalo.TimeOfDay, CkFolgaEscala.CheckState)

        End If

        'limpa e torna invisivel

        PnnCargos.Visible = False

        TxtNomeCompleto.Text = ""

        Popula_Dash()

        If LblCargos.Text = 1 Then

            If MsgBox("Ainda não possuo um usuário para uso das ferramentas, vou redirecioná-lo para o primeiro cadastro funcional.", MsgBoxStyle.OkOnly) Then

                BttNovoColaborador.PerformClick()

            End If

        End If

    End Sub

    Private Sub TxtInicioS_TextChanged(sender As Object, e As EventArgs) Handles TxtInicioS.TextChanged

    End Sub

    Private Sub CkFolgaEscala_CheckedChanged(sender As Object, e As EventArgs) Handles CkFolgaEscala.CheckedChanged


    End Sub

    Private Sub CkFolgaEscala_EnabledChanged(sender As Object, e As EventArgs) Handles CkFolgaEscala.EnabledChanged

        If CkFolgaEscala.Enabled = False Then
            LblJonada.Text = "00:00 HS/Semana"
        End If

    End Sub

    Private Sub RdbSeguradora_CheckedChanged(sender As Object, e As EventArgs) Handles RdbSeguradora.CheckedChanged

        If RdbSeguradora.Checked = True Or RdbTerceiro.Checked = True Or RdbPrestador.Checked = True Then

            TxtCnpj.Enabled = True

        End If

        If RdbSeguradora.Checked = False And RdbTerceiro.Checked = False And RdbPrestador.Checked = False Then

            TxtCnpj.Enabled = False
            TxtCnpj.Text = ""

        End If

    End Sub

    Private Sub RdbTerceiro_CheckedChanged(sender As Object, e As EventArgs) Handles RdbTerceiro.CheckedChanged

        If RdbSeguradora.Checked = True Or RdbTerceiro.Checked = True Or RdbPrestador.Checked = True Then

            TxtCnpj.Enabled = True

        End If

        If RdbSeguradora.Checked = False And RdbTerceiro.Checked = False And RdbPrestador.Checked = False Then

            TxtCnpj.Enabled = False
            TxtCnpj.Text = ""

        End If

    End Sub

    Private Sub RdbPrestador_CheckedChanged(sender As Object, e As EventArgs) Handles RdbPrestador.CheckedChanged

        If RdbSeguradora.Checked = True Or RdbTerceiro.Checked = True Or RdbPrestador.Checked = True Then

            TxtCnpj.Enabled = True

        End If

        If RdbSeguradora.Checked = False And RdbTerceiro.Checked = False And RdbPrestador.Checked = False Then

            TxtCnpj.Enabled = False
            TxtCnpj.Text = ""

        End If

    End Sub

    Private Sub TxtCnpj_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCnpj.MaskInputRejected

    End Sub

    Private Sub TxtCnpj_TextChanged(sender As Object, e As EventArgs) Handles TxtCnpj.TextChanged

        If TxtCnpj.Text.Length = 14 Then

            TxtIe.Enabled = True

        Else

            TxtIe.Text = ""
            TxtIe.Enabled = False

        End If

    End Sub

    Private Sub TxtIe_TextChanged(sender As Object, e As EventArgs) Handles TxtIe.TextChanged

        If TxtIe.Text <> "" Then

            TxtRazaoSocial.Enabled = True

        Else

            TxtRazaoSocial.Enabled = False

        End If

    End Sub

    Private Sub TxtRazaoSocial_TextChanged(sender As Object, e As EventArgs) Handles TxtRazaoSocial.TextChanged

        If TxtRazaoSocial.Text <> "" Then

            TxtNomeFantasia.Enabled = True

        Else

            TxtNomeFantasia.Enabled = False
            TxtNomeFantasia.Text = ""

        End If

    End Sub

    Private Sub TxtNomeFantasia_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeFantasia.TextChanged

        If TxtNomeFantasia.Text <> "" Then

            TxtCepParceiro.Enabled = True

        Else

            TxtCepParceiro.Text = ""
            TxtCepParceiro.Enabled = False

        End If

    End Sub

    Private Sub TxtCepParceiro_TextChanged(sender As Object, e As EventArgs) Handles TxtCepParceiro.TextChanged

        If TxtCepParceiro.Text.Length = 8 Then

            BttBuscarCepParceiro.Enabled = True

            BttBuscarCepParceiro.PerformClick()

        Else

            BttBuscarCepParceiro.Enabled = False

        End If

    End Sub

    Public LstIdEndereço As New ListBox
    Public LstIdPaisesTodos As New ListBox
    Public LstidEstadoTodos As New ListBox
    Public LstIdCidadeTodos As New ListBox
    Public LstidBairroTodos As New ListBox

    Public LstIdBairro As New ListBox
    Public LstdescricaoEstado As New ListBox
    Public LstSiglaEstado As New ListBox
    Public LstdescricaoPais As New ListBox
    Public LstSiglaPais As New ListBox
    Private Sub BttBuscarCepParceiro_Click(sender As Object, e As EventArgs) Handles BttBuscarCepParceiro.Click

        'LIMPA TODOS OS COMBOX

        CmbPais.Items.Clear()
        CmbEstado.Items.Clear()
        CmbCidade.Items.Clear()
        CmbBairro.Items.Clear()

        LstIdPaisesTodos.Items.Clear()
        LstidEstadoTodos.Items.Clear()
        LstIdCidadeTodos.Items.Clear()
        LstIdBairro.Items.Clear()
        LstdescricaoEstado.Items.Clear()
        LstSiglaEstado.Items.Clear()
        LstdescricaoPais.Items.Clear()
        LstSiglaPais.Items.Clear()

        CmbPais.Text = Nothing
        CmbEstado.Text = Nothing
        CmbCidade.Text = Nothing
        CmbBairro.Text = Nothing
        TxtNumeroParceiro.Text = Nothing

        TxtNumeroParceiro.Enabled = False
        CmbPais.Enabled = False
        CmbEstado.Enabled = False
        CmbCidade.Enabled = False
        CmbBairro.Enabled = False

        Dim LqCadastros As New DtCadastroDataContext

        'busca pelo CEP

        Dim BuscaCep = From Cep In LqCadastros.Enderecos
                       Where Cep.CEP = TxtCepParceiro.Text
                       Select Cep.IdBairro, Cep.IdAbreviacao, Cep.IdEndereco, Cep.Descricao

        LstIdEndereço.Items.Clear()
        CmbEndereço.Items.Clear()

        For Each row In BuscaCep.ToList
            LstIdEndereço.Items.Add(row.IdEndereco)
            LstIdBairro.Items.Add(row.IdBairro)
            'busca descricao
            Dim Buscadescricao = From desc In LqCadastros.DescricaoLogradouros
                                 Where desc.IdDescricaoLog = row.IdAbreviacao
                                 Select desc.Abreviacao

            CmbEndereço.Items.Add(Buscadescricao.First & row.Descricao)
        Next

        'busca paises

        Dim BuscaPais = From pai In LqCadastros.Paises
                        Where pai.IdPais Like "*"
                        Select pai.Descricao, pai.Sigla, pai.IdPais

        LstIdPaisesTodos.Items.Clear()
        LstSiglaPais.Items.Clear()
        LstdescricaoPais.Items.Clear()
        CmbPais.Items.Clear()

        For Each row In BuscaPais.ToList

            LstIdPaisesTodos.Items.Add(row.IdPais)
            LstSiglaPais.Items.Add(row.Sigla)
            LstdescricaoPais.Items.Add(row.Descricao)
            CmbPais.Items.Add(row.Sigla & " - " & row.Descricao)

        Next

        If BuscaCep.Count = 0 Then

            CmbEndereço.Enabled = True

            FrmEndereço._CEP = TxtCepParceiro.Text

            FrmEndereço.Show(Me)

        ElseIf BuscaCep.Count = 1 Then

            CmbEndereço.Enabled = False
            CmbEndereço.SelectedIndex = 0

            'verifica se o bairro esta preenchido

            If LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString = 0 Then
                CmbPais.Enabled = True
            Else
                CmbPais.Enabled = False
                CmbEstado.Enabled = False
                CmbCidade.Enabled = False
                CmbBairro.Enabled = False

                'seleciona o restante
                Dim BuscaBairro = From cid In LqCadastros.Bairro
                                  Where cid.IdBairro = Val(LstIdBairro.Items(CmbEndereço.SelectedIndex).ToString)
                                  Select cid.IdCidade, cid.Descricao, cid.IdBairro

                LstidBairroTodos.Items.Clear()
                CmbBairro.Items.Clear()

                Dim _indexBairro As Integer

                For Each row In BuscaBairro.ToList
                    LstidBairroTodos.Items.Add(row.IdBairro)
                    CmbBairro.Items.Add(row.Descricao)

                    If row.IdBairro = BuscaBairro.First.IdBairro Then
                        _indexBairro = LstidBairroTodos.Items.Count - 1
                    End If

                Next

                CmbBairro.SelectedIndex = _indexBairro

                'busca cidades

                Dim BuscaCidade = From cid In LqCadastros.Cidade
                                  Where cid.IdCidade Like "*"
                                  Select cid.IdEstado, cid.Descricao, cid.IdCidade

                LstIdCidadeTodos.Items.Clear()
                CmbCidade.Items.Clear()

                Dim _indexCid As Integer

                For Each row In BuscaCidade.ToList

                    LstIdCidadeTodos.Items.Add(row.IdCidade)
                    CmbCidade.Items.Add(row.Descricao)

                    If row.IdCidade = BuscaBairro.First.IdCidade Then
                        _indexCid = LstIdCidadeTodos.Items.Count - 1
                    End If

                Next

                CmbCidade.SelectedIndex = _indexCid

                'busca Estados

                Dim BuscaEstado = From cid In LqCadastros.Estados
                                  Where cid.IdEstado Like "*"
                                  Select cid.IdPais, cid.Descricao, cid.Sigla, cid.IdEstado

                LstidEstadoTodos.Items.Clear()
                CmbEstado.Items.Clear()

                Dim _indexEst As Integer

                For Each row In BuscaEstado.ToList

                    LstidEstadoTodos.Items.Add(row.IdEstado)
                    CmbEstado.Items.Add(row.Sigla & " - " & row.Descricao)

                    If row.IdEstado = BuscaCidade.First.IdEstado Then
                        _indexEst = LstidEstadoTodos.Items.Count - 1
                    End If

                Next

                CmbEstado.SelectedIndex = _indexEst

                Dim BuscaPaisTodos = From cid In LqCadastros.Paises
                                     Where cid.IdPais Like "*"
                                     Select cid.IdPais, cid.Descricao, cid.Sigla

                LstIdPaisesTodos.Items.Clear()
                CmbPais.Items.Clear()

                Dim _indexPais As Integer

                For Each row In BuscaPaisTodos.ToList

                    LstIdPaisesTodos.Items.Add(row.IdPais)
                    CmbPais.Items.Add(row.Sigla & " - " & row.Descricao)

                    If row.IdPais = BuscaEstado.First.IdPais Then
                        _indexPais = LstIdPaisesTodos.Items.Count - 1
                    End If

                Next

                CmbPais.SelectedIndex = _indexPais

                TxtNumeroParceiro.Enabled = True
                TxtNumeroParceiro.Focus()

            End If

        ElseIf BuscaCep.Count > 1 Then

            CmbEndereço.Enabled = True

        End If

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Pnndash.Visible = False

        PnnParceiros.Visible = True
        PnnParceiros.Dock = DockStyle.Fill

        'desailita

        PnnColaborador.Visible = False
        PnnCargos.Visible = False

    End Sub

    Dim LstIdNacionalidade As New ListBox
    Dim LstIdCargos As New ListBox
    Dim LstRenberacai As New ListBox

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles BttNovoColaborador.Click

        Pnndash.Visible = False

        PnnCargos.Visible = False

        PnnColaborador.Visible = True
        PnnColaborador.Dock = DockStyle.Fill


        PnnColaboradores.Visible = True
        PnnParceiro.Visible = False
        PnnEquipe.Visible = False
        PnnDisCargo.Visible = False

        BttNovoColaborador.Visible = False
        BttBuscarColaborador.Visible = False

        'carrega nacioalidade

        Dim BuscaNacionalidade = From nac In LqBase.Nacionalidades
                                 Where nac.IdNacionalidade Like "*"
                                 Select nac.Nacionalidade, nac.IdNacionalidade

        LstIdNacionalidade.Items.Clear()
        CmbNacionalidade.Items.Clear()

        For Each row In BuscaNacionalidade.ToList

            LstIdNacionalidade.Items.Add(row.IdNacionalidade)
            CmbNacionalidade.Items.Add(row.Nacionalidade)

        Next

        'busca cargos

        Dim BuscaCargos = From car In LqBase.Cargos
                          Where car.IdCargo Like "*"
                          Select car.IdCargo, car.RemuneracaoBase, car.Descricao

        LstIdCargos.Items.Clear()
        LstRenberacai.Items.Clear()
        CmbCargo.Items.Clear()

        For Each row In BuscaCargos.ToList

            LstIdCargos.Items.Add(row.IdCargo)
            LstRenberacai.Items.Add(row.RemuneracaoBase)
            CmbCargo.Items.Add(row.Descricao)

        Next


        'desailita

        PnnParceiros.Visible = False
        PnnCargos.Visible = False

    End Sub

    Private Sub TxtNumeroParceiro_TextChanged(sender As Object, e As EventArgs) Handles TxtNumeroParceiro.TextChanged

        If TxtNumeroParceiro.Text <> "" Then

            TxtTituloParceiro.Enabled = True
            TxtComplParceiro.Enabled = True
            NmDiaFechamento.Enabled = True
            BttSalvarParceiro.Enabled = True

        Else

            TxtTituloParceiro.Enabled = False
            NmDiaFechamento.Enabled = False
            BttSalvarParceiro.Enabled = False

            TxtTituloParceiro.Text = ""
            TxtComplParceiro.Text = ""
            NmDiaFechamento.Value = 1

        End If

    End Sub

    Private Sub BttSalvarParceiro_Click(sender As Object, e As EventArgs) Handles BttSalvarParceiro.Click

        Pnndash.Visible = True
        PnnParceiros.Visible = False

        Dim Validação As String

        If RdbPrestador.Checked = True Then

            Validação = RdbPrestador.Text

        ElseIf RdbSeguradora.Checked = True Then

            Validação = RdbSeguradora.Text

        ElseIf RdbTerceiro.Checked = True Then

            Validação = RdbTerceiro.Text

        End If

        'cria novo parceiro

        Dim lqOficina As New LqOficinaDataContext

        lqOficina.InsereNovoParceiro(TxtCnpj.Text, TxtIe.Text, TxtRazaoSocial.Text, TxtNomeFantasia.Text, LstIdEndereço.Items(CmbEndereço.SelectedIndex).ToString, TxtNumeroParceiro.Text, TxtComplParceiro.Text, NmDiaFechamento.Value, Validação)

        Dim BuscaParceiro = From pc In lqOficina.Seguradoras
                            Where pc.Tipo Like Validação And pc.RazaoSocial Like TxtRazaoSocial.Text
                            Select pc.IdCadSeguradora

        'varre 

        For Each row As DataGridViewRow In DtItensParceiros.Rows

            lqOficina.InsereNovoItemParceiro(row.Cells(0).Value.ToString, row.Cells(1).Value.ToString, row.Cells(2).Value.ToString)

        Next

        RdbSeguradora.Checked = False
        RdbTerceiro.Checked = False
        RdbPrestador.Checked = False

        PnnCargos.Visible = False
        PnnColaborador.Visible = False
        PnnParceiros.Enabled = False

        Popula_Dash()

    End Sub

    Private Sub TxtTituloParceiro_TextChanged(sender As Object, e As EventArgs) Handles TxtTituloParceiro.TextChanged

        If TxtTituloParceiro.Text <> "" Then
            CmbTipoVerificacao.Enabled = True
        Else
            CmbTipoVerificacao.Enabled = False
            CmbTipoVerificacao.Text = ""
        End If

    End Sub

    Private Sub CmbTipoVerificacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoVerificacao.SelectedIndexChanged

        If CmbTipoVerificacao.Items.Contains(CmbTipoVerificacao.Text) Then

            BttAddCmpl.Enabled = True

        Else

            BttAddCmpl.Enabled = False

        End If

        If CmbTipoVerificacao.Text = "" Then

            BttAddCmpl.Enabled = False

        End If

    End Sub

    Private Sub BttAddCmpl_Click(sender As Object, e As EventArgs) Handles BttAddCmpl.Click

        DtItensParceiros.Rows.Add(TxtTituloParceiro.Text, CmbTipoVerificacao.Text, CmbTipoVerificacao.SelectedIndex, My.Resources.Cancel_40972)

    End Sub

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then

            CmbNacionalidade.Enabled = True

        Else

            CmbNacionalidade.Text = ""
            CmbNacionalidade.Enabled = False

        End If

    End Sub

    Private Sub CmbNacionalidade_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbNacionalidade.SelectedIndexChanged

        If CmbNacionalidade.Items.Contains(CmbNacionalidade.Text) Then

            CmbEstadoCivil.Enabled = True

        Else

            CmbEstadoCivil.Text = ""
            CmbEstadoCivil.Enabled = False

        End If
    End Sub

    Private Sub CmbEstadoCivil_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbEstadoCivil.SelectedIndexChanged

        If CmbEstadoCivil.Items.Contains(CmbEstadoCivil.Text) Then

            TxtTelefoneResid.Enabled = True
            TxtCelular.Enabled = True
            TxtCPF.Enabled = True

        Else

            TxtTelefoneResid.Enabled = False
            TxtCelular.Enabled = False
            TxtCPF.Enabled = False

            TxtTelefoneResid.Text = ""
            TxtCelular.Text = ""
            TxtCPF.Text = ""

        End If

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub

    Private Sub TxtCPF_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged

        If TxtCPF.Text.Length = 11 Then

            TxtRg.Enabled = True

        Else

            TxtRg.Enabled = False
            TxtRg.Text = ""

        End If

    End Sub

    Private Sub TxtRg_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtRg.MaskInputRejected

    End Sub

    Private Sub TxtRg_TextChanged(sender As Object, e As EventArgs) Handles TxtRg.TextChanged

        If TxtRg.Text.Length >= 5 Then

            TxtNomeMae.Enabled = True

        Else

            TxtNomeMae.Enabled = False
            TxtNomeMae.Text = ""

        End If
    End Sub

    Private Sub TxtNomeMae_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeMae.TextChanged

        If TxtNomeMae.Text <> "" Then

            TxtNomePai.Enabled = True
            TxtCep.Enabled = True

        Else

            TxtNomePai.Enabled = False
            TxtNomePai.Text = ""
            TxtCep.Enabled = False
            TxtCep.Text = ""

        End If

    End Sub

    Dim _IdEndereco As Integer = -1

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TxtCep.Text.Length = 8 Then

            'busca endereco

            Dim buscaEndereco = From ende In LqBase.Enderecos
                                Where ende.CEP = TxtCep.Text
                                Select ende.IdEndereco, ende.Descricao, ende.IdBairro, ende.IdAbreviacao, ende.DescricaoLogradouros

            If buscaEndereco.Count > 0 Then

                _IdEndereco = buscaEndereco.First.IdEndereco

                'busca abrviação 

                Dim BuscaAbreviação = From abre In LqBase.DescricaoLogradouros
                                      Where abre.IdDescricaoLog = buscaEndereco.First.IdAbreviacao
                                      Select abre.Abreviacao

                TxtEndereco.Text = BuscaAbreviação.First & " " & buscaEndereco.First.Descricao

                'busca bairro

                Dim buscaBairro = From bai In LqBase.Bairro
                                  Where bai.IdBairro = buscaEndereco.First.IdBairro
                                  Select bai.Descricao, bai.IdCidade

                TxtBairro.Text = buscaBairro.First.Descricao

                'busca cidade 

                Dim BuscaCidade = From cid In LqBase.Cidade
                                  Where cid.IdCidade = buscaBairro.First.IdCidade
                                  Select cid.IdEstado, cid.Descricao

                TxtCidade.Text = BuscaCidade.First.Descricao

                'busca estado

                Dim BuscaEstado = From est In LqBase.Estados
                                  Where est.IdEstado = BuscaCidade.First.IdEstado
                                  Select est.IdPais, est.Sigla, est.Descricao

                TxtEstado.Text = BuscaEstado.First.Sigla & " - " & BuscaEstado.First.Descricao

                'busca pais

                Dim BuscaPais = From pai In LqBase.Paises
                                Where pai.IdPais = BuscaEstado.First.IdPais
                                Select pai.Sigla, pai.Descricao

                TxtPais.Text = BuscaPais.First.Sigla & " - " & BuscaPais.First.Descricao

                'habilita campos

                TxtNumero.Enabled = True

            Else

                'Try
                Me.Cursor = Cursors.WaitCursor

                Dim ds As New DataSet()
                Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
                ds.ReadXml(xml)
                TxtEndereco.Text = ds.Tables(0).Rows(0)("logradouro").ToString()
                TxtBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
                TxtCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
                TxtEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()
                TxtPais.Text = "Brasil"

                TxtNumero.Enabled = True
                TxtNumero.Focus()

                'verfica tipo de logradouro

                Dim BuscTipoLog = From log In LqBase.DescricaoLogradouros
                                  Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                  Select log.IdDescricaoLog

                Dim _IdDescricaoLog As Integer

                If BuscTipoLog.Count > 0 Then

                    _IdDescricaoLog = BuscTipoLog.First

                Else

                    LqBase.InsereDescricaoEndereco(ds.Tables(0).Rows(0)("tipo_logradouro").ToString(), ds.Tables(0).Rows(0)("tipo_logradouro").ToString())

                    'verfica tipo de logradouro

                    Dim BuscTipoLogA = From log In LqBase.DescricaoLogradouros
                                       Where log.Descricao Like ds.Tables(0).Rows(0)("tipo_logradouro").ToString()
                                       Select log.IdDescricaoLog

                    _IdDescricaoLog = BuscTipoLogA.First

                End If


                'insere endereco

                'verifica estado

                Dim BuscaPais = From est In LqBase.Paises
                                Where est.Descricao Like TxtPais.Text
                                Select est.IdPais

                If BuscaPais.Count > 0 Then
                    'verifica a existencia do estado 

                    Dim BuscaEstado = From est In LqBase.Estados
                                      Where est.IdPais = BuscaPais.First And est.Descricao Like TxtEstado.Text
                                      Select est.IdEstado

                    If BuscaEstado.Count > 0 Then
                        'verifica a existencia do estado 

                        Dim BuscaCidade = From est In LqBase.Cidade
                                          Where est.IdEstado = BuscaEstado.First And est.Descricao Like TxtCidade.Text
                                          Select est.IdCidade

                        If BuscaCidade.Count > 0 Then
                            'verifica a existencia do estado 

                            Dim BuscaBairro = From est In LqBase.Bairro
                                              Where est.IdCidade = BuscaCidade.First And est.Descricao Like TxtBairro.Text
                                              Select est.IdBairro

                            If BuscaBairro.Count > 0 Then
                                'verifica a existencia do estado 

                                Dim Buscaloradouro = From est In LqBase.Enderecos
                                                     Where est.IdBairro = BuscaBairro.First And est.Descricao Like TxtEndereco.Text
                                                     Select est.IdEndereco

                                If Buscaloradouro.Count = 0 Then

                                    LqBase.InsereEndereco(BuscaBairro.First, TxtEndereco.Text, TxtCep.Text, 0)

                                End If

                            Else

                                LqBase.InsereBairro(BuscaCidade.First, TxtCidade.Text)

                                'verifica a existencia do estado 

                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                   Where est.IdCidade = BuscaCidade.First And est.Descricao Like TxtCidade.Text
                                                   Select est.IdBairro

                                If BuscaBairroA.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like TxtEndereco.Text
                                                         Select est.IdEndereco

                                    If Buscaloradouro.Count = 0 Then

                                        LqBase.InsereEndereco(BuscaBairroA.First, TxtEndereco.Text, TxtCep.Text, _IdDescricaoLog)

                                    End If

                                End If

                            End If

                        Else

                            LqBase.InsereCidade(BuscaEstado.First, TxtCidade.Text)

                            'verifica a existencia do estado 

                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                               Where est.IdEstado = BuscaEstado.First And est.Descricao Like TxtCidade.Text
                                               Select est.IdCidade

                            If BuscaCidadeA.Count > 0 Then

                                LqBase.InsereBairro(BuscaCidadeA.First, TxtBairro.Text)

                                'verifica a existencia do estado 

                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like TxtBairro.Text
                                                   Select est.IdBairro

                                If BuscaBairroA.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like TxtEndereco.Text
                                                         Select est.IdEndereco

                                    If Buscaloradouro.Count = 0 Then

                                        LqBase.InsereEndereco(BuscaBairroA.First, TxtEndereco.Text, TxtCep.Text, _IdDescricaoLog)

                                    End If

                                End If

                            End If

                        End If

                    Else

                        LqBase.InsereEstado(BuscaPais.First, TxtEstado.Text, "", 0)

                        'verifica a existencia do estado 

                        Dim BuscaEstadoA = From est In LqBase.Estados
                                           Where est.IdPais = BuscaPais.First And est.Descricao Like TxtEstado.Text
                                           Select est.IdEstado

                        If BuscaEstadoA.Count > 0 Then

                            LqBase.InsereCidade(BuscaEstadoA.First, TxtCidade.Text)

                            'verifica a existencia do estado 

                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like TxtCidade.Text
                                               Select est.IdCidade

                            If BuscaCidadeA.Count > 0 Then

                                LqBase.InsereBairro(BuscaCidadeA.First, TxtBairro.Text)

                                'verifica a existencia do estado 

                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like TxtBairro.Text
                                                   Select est.IdBairro

                                If BuscaBairroA.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like TxtEndereco.Text
                                                         Select est.IdEndereco

                                    If Buscaloradouro.Count = 0 Then

                                        LqBase.InsereEndereco(BuscaBairroA.First, TxtEndereco.Text, TxtCep.Text, _IdDescricaoLog)

                                    End If

                                End If

                            End If

                        End If

                    End If

                Else

                    LqBase.InserePais(TxtPais.Text, "", 0)

                    Dim BuscaPaisA = From est In LqBase.Paises
                                     Where est.IdPais Like TxtPais.Text
                                     Select est.IdPais

                    If BuscaPaisA.Count > 0 Then

                        'verifica a existencia do estado 

                        Dim BuscaEstadoA = From est In LqBase.Estados
                                           Where est.IdPais = BuscaPaisA.First And est.Descricao Like TxtEstado.Text
                                           Select est.IdEstado

                        If BuscaEstadoA.Count > 0 Then

                            LqBase.InsereCidade(BuscaEstadoA.First, TxtCidade.Text)

                            'verifica a existencia do estado 

                            Dim BuscaCidadeA = From est In LqBase.Cidade
                                               Where est.IdEstado = BuscaEstadoA.First And est.Descricao Like TxtCidade.Text
                                               Select est.IdCidade

                            If BuscaCidadeA.Count > 0 Then

                                LqBase.InsereBairro(BuscaCidadeA.First, TxtBairro.Text)

                                'verifica a existencia do estado 

                                Dim BuscaBairroA = From est In LqBase.Bairro
                                                   Where est.IdCidade = BuscaCidadeA.First And est.Descricao Like TxtBairro.Text
                                                   Select est.IdBairro

                                If BuscaBairroA.Count > 0 Then
                                    'verifica a existencia do estado 

                                    Dim Buscaloradouro = From est In LqBase.Enderecos
                                                         Where est.IdBairro = BuscaBairroA.First And est.Descricao Like TxtEndereco.Text
                                                         Select est.IdEndereco

                                    If Buscaloradouro.Count = 0 Then

                                        LqBase.InsereEndereco(BuscaBairroA.First, TxtEndereco.Text, TxtCep.Text, _IdDescricaoLog)

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

                Me.Cursor = Cursors.Arrow

            End If

        Else

            TxtEndereco.Enabled = False
            TxtNumero.Enabled = False
            TxtComplemento.Enabled = False
            TxtBairro.Enabled = False
            TxtCidade.Enabled = False
            TxtEstado.Enabled = False
            TxtPais.Enabled = False

            TxtEndereco.Text = ""
            TxtNumero.Text = ""
            TxtComplemento.Text = ""
            TxtBairro.Text = ""
            TxtCidade.Text = ""
            TxtEstado.Text = ""
            TxtPais.Text = ""

        End If

    End Sub

    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then

            TxtComplemento.Enabled = True
            CmbCargo.Enabled = True

        Else

            TxtComplemento.Enabled = False
            CmbCargo.Enabled = False

            TxtComplemento.Text = ""
            CmbCargo.Text = ""

        End If

    End Sub

    Private Sub CmbCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCargo.SelectedIndexChanged

        If CmbCargo.Items.Contains(CmbCargo.Text) Then

            TxtRemuneração.Maximum = LstRenberacai.Items(CmbCargo.SelectedIndex).ToString
            TxtRemuneração.Minimum = LstRenberacai.Items(CmbCargo.SelectedIndex).ToString
            TxtRemuneração.Value = LstRenberacai.Items(CmbCargo.SelectedIndex).ToString

            TxtRemuneração.Enabled = True

            BttSalvarColaborador.Enabled = True

        Else

            TxtRemuneração.Maximum = 0
            TxtRemuneração.Minimum = 0
            TxtRemuneração.Value = 0

            TxtRemuneração.Enabled = False

            BttSalvarColaborador.Enabled = False

        End If

    End Sub

    Private Sub BttSalvarColaborador_Click(sender As Object, e As EventArgs) Handles BttSalvarColaborador.Click

        If Primeiro = False Then

            Pnndash.Visible = True
            PnnColaborador.Visible = False

            PnnColaboradores.Visible = True
            PnnParceiro.Visible = True
            PnnEquipe.Visible = True
            PnnDisCargo.Visible = True

            BttNovoColaborador.Visible = True
            BttBuscarColaborador.Visible = True

            'insere Colaborador

            LqBase.InsereColaborador(TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, _IdEndereco, TxtEndereco.Text, TxtNumero.Text, TxtComplemento.Text, TxtBairro.Text, TxtCidade.Text, TxtEstado.Text, TxtPais.Text, TxtTelefoneResid.Text, TxtCelular.Text, "", "", "", "", "", "", "", Nothing, LstIdCargos.Items(CmbCargo.SelectedIndex).ToString, CmbCargo.Text, LstIdNacionalidade.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, 0, "", "", "", "", "", False, "", "")

            'busca colaborador recem cadastrado

            Dim BuscaColaborador = From col In LqBase.Funcionarios
                                   Where col.CPF Like TxtCPF.Text And col.IdCargo <> 0
                                   Select col.IdFuncionario

            'verifica se nick existe

            Dim Contexto As String = TxtNomeCompleto.Text

            Dim str As String = Contexto
            Dim separador As String = " "
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            Dim _Nick As String = LstPalavras.Items(0).ToString & "." & LstPalavras.Items(LstPalavras.Items.Count - 1).ToString

            'insere novo login

            LqBase.InsereLogin(_Nick, "123@mudar", BuscaColaborador.First, 0)

            TxtNomeCompleto.Text = ""

            Popula_Dash()

        Else

            Pnndash.Visible = True
            PnnColaborador.Visible = False

            'insere Colaborador

            LqBase.InsereColaborador(TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, TxtNomePai.Text, TxtNomeMae.Text, TxtCep.Text, _IdEndereco, TxtEndereco.Text, TxtNumero.Text, TxtComplemento.Text, TxtBairro.Text, TxtCidade.Text, TxtEstado.Text, TxtPais.Text, TxtTelefoneResid.Text, TxtCelular.Text, "", "", "", "", "", "", "", Nothing, LstIdCargos.Items(CmbCargo.SelectedIndex).ToString, CmbCargo.Text, LstIdNacionalidade.Items(CmbNacionalidade.SelectedIndex).ToString, CmbNacionalidade.Text, 0, 0, "", 0, "", "", "", False, "", "")

            'busca colaborador recem cadastrado

            Dim BuscaColaborador = From col In LqBase.Funcionarios
                                   Where col.CPF Like TxtCPF.Text
                                   Select col.IdFuncionario

            'verifica se nick existe

            Dim Contexto As String = TxtNomeCompleto.Text

            Dim str As String = Contexto
            Dim separador As String = " "
            Dim palavras As String() = str.Split(separador)
            Dim LstPalavras As New ListBox
            Dim palavra As String

            For Each palavra In palavras
                LstPalavras.Items.Add(palavra)
            Next

            Dim _Nick As String = LstPalavras.Items(0).ToString & "." & LstPalavras.Items(LstPalavras.Items.Count - 1).ToString

            'insere novo login

            LqBase.InsereLogin(_Nick, "123@mudar", BuscaColaborador.First, 0)

            TxtNomeCompleto.Text = ""

            Popula_Dash()

            Me.Close()

            FrmLogin.TxtNick.Text = _Nick
            FrmLogin.TxtPassword.Text = "123@mudar"

            FrmPrincipal.Visible = False
            FrmPrincipal.Opacity = 100

            FrmLogin.Visible = True
            FrmLogin.Opacity = 97

            Me.Visible = False

            FrmLogin.BttSalvar.PerformClick()

            'insere o usuario recem cadastrado

        End If

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Pnndash.Visible = True
        Panel30.Visible = False

        Popula_Dash()

    End Sub

    Private Sub Pnndash_Paint(sender As Object, e As PaintEventArgs) Handles Pnndash.Paint

    End Sub

    Private Sub Pnndash_VisibleChanged(sender As Object, e As EventArgs) Handles Pnndash.VisibleChanged


    End Sub
End Class