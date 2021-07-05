Imports System.Net
Imports Newtonsoft.Json

Public Class FrmCadSeviçosvb
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TxtDescrição.TextChanged

        If TxtDescrição.Text <> "" Then

            TxtTME.Enabled = True

        Else

            TxtTME.Text = ""

            TxtTME.Enabled = False

        End If

    End Sub

    Dim LqBase As New DtCadastroDataContext

    Dim LstIdProfissionais As New ListBox

    Private Sub FrmCadSeviçosvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'busca profissionais

        Dim BuscaProfissional = From prof In LqBase.Cargos
                                Where prof.IdCargo Like "*"
                                Select prof.Descricao, prof.IdCargo

        LstIdProfissionais.Items.Clear()
        CmbProfissionais.Items.Clear()

        For Each row In BuscaProfissional.ToList

            LstIdProfissionais.Items.Add(row.IdCargo)
            CmbProfissionais.Items.Add(row.Descricao)

        Next

        BttSalvar.Enabled = True

        CmbFerramenta.Enabled = True

        RdbFeraamenta.Enabled = True
        RdbInsumos.Enabled = True

        Dim LstInserdos As New ListBox

        'busca ferramentas compativei na lista

        'verifica ferramenta de uso comum

        Dim Buscaferramentas = From fer In LqBase.Ferramentas
                               Where fer.IdFerramenta Like "*"
                               Select fer.NVinculado, fer.IdFerramenta, fer.Descricao

        CmbFerramenta.Items.Clear()
        LstIdFerramenta.Items.Clear()

        For Each row In Buscaferramentas.ToList

            'verifica compatibilidade

            If row.NVinculado = True Then

                CmbFerramenta.Items.Add(row.Descricao)
                LstIdFerramenta.Items.Add(row.IdFerramenta)

            Else

                'verifica se possue liberação em algum dos profissionas da lista

                For Each row1 As DataGridViewRow In DtProdutos.Rows

                    Dim Cod As Integer = row1.Cells(0).Value

                    Dim VinculoCargo = From car In LqBase.VinculoFerramentasCargos
                                       Where car.IdCargo = Cod And car.IdFerramenta = row.IdFerramenta
                                       Select car.Descricao

                    If VinculoCargo.Count > 0 Then

                        If Not LstInserdos.Items.Contains(row.IdFerramenta) Then
                            CmbFerramenta.Items.Add(row.Descricao)
                            LstIdFerramenta.Items.Add(row.IdFerramenta)
                            LstInserdos.Items.Add(row.IdFerramenta)

                        End If

                    End If

                Next

            End If

        Next


    End Sub

    Private Sub TxtTME_TextChanged(sender As Object, e As EventArgs) Handles TxtTME.TextChanged

        If TxtTME.Text <> "" Then

            If TxtTME.Text.Length = 5 Then

                Try

                    TxtTME.Text = FormatDateTime(TxtTME.Text, DateFormat.ShortTime)
                    CmbProfissionais.Enabled = True
                    CkNDesignado.Enabled = True

                Catch ex As Exception

                    MsgBox("O valor inserido não é válido.")

                    CmbProfissionais.Enabled = False
                    CkNDesignado.Enabled = False

                    CmbProfissionais.Text = ""

                End Try

            End If

        End If

    End Sub

    Private Sub CmbProfissionais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbProfissionais.SelectedIndexChanged

        If CmbProfissionais.Items.Contains(CmbProfissionais.Text) Then

            NmQtdadeProfiissional.Enabled = True
            BttVincularProfissionais.Enabled = True

        Else

            NmQtdadeProfiissional.Enabled = False
            BttVincularProfissionais.Enabled = False

            NmQtdadeProfiissional.Value = 1

        End If

    End Sub

    Private Sub CkNDesignado_CheckedChanged(sender As Object, e As EventArgs) Handles CkNDesignado.CheckedChanged

        If CkNDesignado.Checked = True Then

            If DtProdutos.Rows.Count > 0 Then

                If MsgBox("Há profssionais designados para este serviço, continuar irá apagar toda a lista.", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    CmbProfissionais.Text = ""
                    CmbFerramenta.Text = ""

                    CmbFerramenta.Enabled = True

                    NmQtdadeProfiissional.Value = 1

                    BttVincularProfissionais.Enabled = False
                    CmbProfissionais.Enabled = False
                    NmQtdadeProfiissional.Enabled = False

                    RdbFeraamenta.Enabled = False
                    RdbInsumos.Enabled = False

                    BttSalvar.Enabled = True

                    DtProdutos.Rows.Clear()

                    RdbFeraamenta.Enabled = True
                    RdbInsumos.Enabled = True

                    Dim LstInserdos As New ListBox

                    'busca ferramentas compativei na lista

                    'verifica ferramenta de uso comum

                    Dim Buscaferramentas = From fer In LqBase.Ferramentas
                                           Where fer.IdFerramenta Like "*"
                                           Select fer.NVinculado, fer.IdFerramenta, fer.Descricao

                    CmbFerramenta.Items.Clear()
                    LstIdFerramenta.Items.Clear()

                    For Each row In Buscaferramentas.ToList

                        'verifica compatibilidade

                        If row.NVinculado = True Then

                            CmbFerramenta.Items.Add(row.Descricao)
                            LstIdFerramenta.Items.Add(row.IdFerramenta)

                        Else

                            'verifica se possue liberação em algum dos profissionas da lista

                            For Each row1 As DataGridViewRow In DtProdutos.Rows

                                Dim Cod As Integer = row1.Cells(0).Value

                                Dim VinculoCargo = From car In LqBase.VinculoFerramentasCargos
                                                   Where car.IdCargo = Cod And car.IdFerramenta = row.IdFerramenta
                                                   Select car.Descricao

                                If VinculoCargo.Count > 0 Then

                                    If Not LstInserdos.Items.Contains(row.IdFerramenta) Then
                                        CmbFerramenta.Items.Add(row.Descricao)
                                        LstIdFerramenta.Items.Add(row.IdFerramenta)
                                        LstInserdos.Items.Add(row.IdFerramenta)

                                    End If

                                End If

                            Next

                        End If

                    Next

                End If

            Else

                CmbProfissionais.Text = ""
                CmbFerramenta.Text = ""

                CmbFerramenta.Enabled = True

                BttVincularProfissionais.Enabled = False
                CmbProfissionais.Enabled = False
                NmQtdadeProfiissional.Enabled = False

                RdbFeraamenta.Enabled = False
                RdbInsumos.Enabled = False

                BttSalvar.Enabled = True

                NmQtdadeProfiissional.Value = 1

                RdbFeraamenta.Enabled = True
                RdbInsumos.Enabled = True

                Dim LstInserdos As New ListBox

                'busca ferramentas compativei na lista

                'verifica ferramenta de uso comum

                Dim Buscaferramentas = From fer In LqBase.Ferramentas
                                       Where fer.IdFerramenta Like "*"
                                       Select fer.NVinculado, fer.IdFerramenta, fer.Descricao

                CmbFerramenta.Items.Clear()
                LstIdFerramenta.Items.Clear()

                For Each row In Buscaferramentas.ToList

                    'verifica compatibilidade

                    If row.NVinculado = True Then

                        CmbFerramenta.Items.Add(row.Descricao)
                        LstIdFerramenta.Items.Add(row.IdFerramenta)

                    Else

                        'verifica se possue liberação em algum dos profissionas da lista

                        For Each row1 As DataGridViewRow In DtProdutos.Rows

                            Dim Cod As Integer = row1.Cells(0).Value

                            Dim VinculoCargo = From car In LqBase.VinculoFerramentasCargos
                                               Where car.IdCargo = Cod And car.IdFerramenta = row.IdFerramenta
                                               Select car.Descricao

                            If VinculoCargo.Count > 0 Then

                                If Not LstInserdos.Items.Contains(row.IdFerramenta) Then
                                    CmbFerramenta.Items.Add(row.Descricao)
                                    LstIdFerramenta.Items.Add(row.IdFerramenta)
                                    LstInserdos.Items.Add(row.IdFerramenta)

                                End If

                            End If

                        Next

                    End If

                Next

            End If

        Else

            CmbFerramenta.Items.Clear()
            LstIdFerramenta.Items.Clear()

            CmbFerramenta.Enabled = False
            RdbFeraamenta.Enabled = False
            RdbInsumos.Enabled = False

            CmbProfissionais.Enabled = True
            BttSalvar.Enabled = False

        End If

    End Sub

    Private Sub NmQtdadeProfiissional_ValueChanged(sender As Object, e As EventArgs) Handles NmQtdadeProfiissional.ValueChanged

    End Sub

    Private Sub BttVincularProfissionais_Click(sender As Object, e As EventArgs) Handles BttVincularProfissionais.Click

        BttSalvar.Enabled = True

        CkNDesignado.Enabled = False

        DtProdutos.Rows.Add(LstIdProfissionais.Items(CmbProfissionais.SelectedIndex).ToString, CmbProfissionais.Text, NmQtdadeProfiissional.Value, My.Resources.Cancel_40972)

        CmbProfissionais.Text = ""
        CmbFerramenta.Text = ""

        CmbFerramenta.Enabled = True

        RdbFeraamenta.Enabled = True
        RdbInsumos.Enabled = True

        Dim LstInserdos As New ListBox

        'busca ferramentas compativei na lista

        'verifica ferramenta de uso comum

        Dim Buscaferramentas = From fer In LqBase.Ferramentas
                               Where fer.IdFerramenta Like "*"
                               Select fer.NVinculado, fer.IdFerramenta, fer.Descricao

        CmbFerramenta.Items.Clear()
        LstIdFerramenta.Items.Clear()

        For Each row In Buscaferramentas.ToList

            'verifica compatibilidade

            If row.NVinculado = True Then

                CmbFerramenta.Items.Add(row.Descricao)
                LstIdFerramenta.Items.Add(row.IdFerramenta)

            Else

                'verifica se possue liberação em algum dos profissionas da lista

                For Each row1 As DataGridViewRow In DtProdutos.Rows

                    Dim Cod As Integer = row1.Cells(0).Value

                    Dim VinculoCargo = From car In LqBase.VinculoFerramentasCargos
                                       Where car.IdCargo = Cod And car.IdFerramenta = row.IdFerramenta
                                       Select car.Descricao

                    If VinculoCargo.Count > 0 Then

                        If Not LstInserdos.Items.Contains(row.IdFerramenta) Then
                            CmbFerramenta.Items.Add(row.Descricao)
                            LstIdFerramenta.Items.Add(row.IdFerramenta)
                            LstInserdos.Items.Add(row.IdFerramenta)

                        End If

                    End If

                Next

            End If

        Next

    End Sub

    Dim LstIdFerramenta As New ListBox

    Private Sub RdbFeraamenta_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFeraamenta.CheckedChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If RdbFeraamenta.Enabled = True Then

            If RdbFeraamenta.Checked = True Then

                Dim LstInserdos As New ListBox

                'busca ferramentas compativei na lista

                'verifica ferramenta de uso comum

                Dim Buscaferramentas = From fer In LqBase.Ferramentas
                                       Where fer.IdFerramenta Like "*"
                                       Select fer.NVinculado, fer.IdFerramenta, fer.Descricao

                CmbFerramenta.Items.Clear()
                LstIdFerramenta.Items.Clear()

                For Each row In Buscaferramentas.ToList

                    'verifica compatibilidade

                    If row.NVinculado = True Then

                        CmbFerramenta.Items.Add(row.Descricao)
                        LstIdFerramenta.Items.Add(row.IdFerramenta)

                    Else

                        'verifica se possue liberação em algum dos profissionas da lista

                        For Each row1 As DataGridViewRow In DtProdutos.Rows

                            Dim Cod As Integer = row1.Cells(0).Value

                            Dim VinculoCargo = From car In LqBase.VinculoFerramentasCargos
                                               Where car.IdCargo = Cod And car.IdFerramenta = row.IdFerramenta
                                               Select car.Descricao

                            If VinculoCargo.Count > 0 Then

                                If Not LstInserdos.Items.Contains(row.IdFerramenta) Then
                                    CmbFerramenta.Items.Add(row.Descricao)
                                    LstIdFerramenta.Items.Add(row.IdFerramenta)
                                    LstInserdos.Items.Add(row.IdFerramenta)

                                End If

                            End If

                        Next

                    End If

                Next

            End If

        End If

    End Sub

    Private Sub CmbFerramenta_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFerramenta.SelectedIndexChanged

        If CmbFerramenta.Items.Contains(CmbFerramenta.Text) Then

            NmQdadeFerramenta.Enabled = True

            BttVinculaFerramenta.Enabled = True

        Else

            NmQdadeFerramenta.Enabled = False
            NmQdadeFerramenta.Value = 1


            BttVinculaFerramenta.Enabled = False

        End If

    End Sub

    Private Sub BttVinculaFerramenta_Click(sender As Object, e As EventArgs) Handles BttVinculaFerramenta.Click

        Dim TipoString As String

        'busca viculos obrigattorios

        If RdbInsumos.Checked = True Then

            TipoString = RdbInsumos.Text

        ElseIf RdbFeraamenta.Checked = True Then

            TipoString = RdbFeraamenta.Text

        End If

        DtFerramentas.Rows.Add(TipoString, LstIdFerramenta.Items(CmbFerramenta.SelectedIndex).ToString, CmbFerramenta.Text, NmQdadeFerramenta.Value, My.Resources.Cancel_40972)

        If RdbFeraamenta.Checked = True Then

            Dim Cod As Integer = LstIdFerramenta.Items(CmbFerramenta.SelectedIndex).ToString

            Dim BuscaInsumoFerramenta = From fer In LqBase.EPI
                                        Where fer.IdFerramenta = Cod
                                        Select fer.IdEpi, fer.Descricao

            For Each row2 In BuscaInsumoFerramenta.ToList

                DtFerramentas.Rows.Add("E.P.I.", row2.IdEpi, CmbFerramenta.Text & " - " & row2.Descricao, 1, My.Resources.capacete)

            Next

        End If

        CmbFerramenta.Text = ""

    End Sub

    Private Sub RdbInsumos_CheckedChanged(sender As Object, e As EventArgs) Handles RdbInsumos.CheckedChanged

        If RdbInsumos.Enabled = True Then

            If RdbInsumos.Checked = True Then

                Dim LstInserdos As New ListBox

                'busca ferramentas compativei na lista

                'verifica ferramenta de uso comum

                Dim Buscaferramentas = From fer In LqBase.Insumos
                                       Where fer.UsoComum = True
                                       Select fer.IdInsumo, fer.Descricao, fer.IdFerramenta

                CmbFerramenta.Items.Clear()
                LstIdFerramenta.Items.Clear()

                For Each row In Buscaferramentas.ToList

                    'verifica compatibilidade

                    CmbFerramenta.Items.Add(row.Descricao)
                    LstIdFerramenta.Items.Add(row.IdInsumo)

                Next


                'vrifca se existe insumos para as ferramentas encontradas

                For Each row1 As DataGridViewRow In DtFerramentas.Rows

                    If row1.Cells(0).Value = RdbFeraamenta.Text Then
                        Dim Cod As Integer = row1.Cells(1).Value

                        Dim BuscaInsumoFerramenta = From fer In LqBase.Insumos
                                                    Where fer.IdFerramenta = Cod
                                                    Select fer.IdInsumo, fer.Descricao

                        For Each row2 In BuscaInsumoFerramenta.ToList

                            CmbFerramenta.Items.Add(row2.Descricao)
                            LstIdFerramenta.Items.Add(row2.IdInsumo)

                        Next
                    End If

                Next
            End If

        End If

    End Sub


    Private Sub DtProdutos_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtProdutos.CellContentClick

        If DtProdutos.Columns(e.ColumnIndex).Name = "ClmExcluir" Then

            DtProdutos.Rows.RemoveAt(e.RowIndex)

            'verifica se há itens

            If DtProdutos.Rows.Count = 0 Then
                CkNDesignado.Enabled = True
                RdbInsumos.Enabled = False
                RdbFeraamenta.Enabled = False
                CmbFerramenta.Text = ""
                CmbFerramenta.Enabled = False
                DtFerramentas.Rows.Clear()

            Else
                CkNDesignado.Enabled = False
            End If
        End If

    End Sub

    Private Sub DtFerramentas_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFerramentas.CellContentClick

        Dim LstIndexApagar As New ListBox

        If DtFerramentas.Columns(e.ColumnIndex).Name = "ClmExcluir1" Then

            Dim IdSel As String = DtFerramentas.Rows(e.RowIndex).Cells(2).Value

            'varre pra ver se tem mais

            For Each row As DataGridViewRow In DtFerramentas.Rows

                If row.Cells(2).Value.ToString.StartsWith(IdSel & " -") Then

                    LstIndexApagar.Items.Add(row.Index)

                End If

            Next

            For i As Integer = LstIndexApagar.Items.Count - 1 To 0 Step -1

                DtFerramentas.Rows.RemoveAt(LstIndexApagar.Items(i).ToString)

            Next

            DtFerramentas.Rows.RemoveAt(e.RowIndex)

        End If

    End Sub

    Private Sub CmbProfissionais_TextChanged(sender As Object, e As EventArgs) Handles CmbProfissionais.TextChanged

        If CmbProfissionais.Items.Contains(CmbProfissionais.Text) Then

            NmQtdadeProfiissional.Enabled = True
            BttVincularProfissionais.Enabled = True

        Else

            NmQtdadeProfiissional.Enabled = False
            BttVincularProfissionais.Enabled = False

            NmQtdadeProfiissional.Value = 1

        End If

    End Sub

    Private Sub CmbFerramenta_TextChanged(sender As Object, e As EventArgs) Handles CmbFerramenta.TextChanged

        If CmbFerramenta.Items.Contains(CmbFerramenta.Text) Then

            NmQdadeFerramenta.Enabled = True

            BttVinculaFerramenta.Enabled = True

        Else

            NmQdadeFerramenta.Enabled = False
            NmQdadeFerramenta.Value = 1


            BttVinculaFerramenta.Enabled = False

        End If

    End Sub

    Public _IdInterno As Integer = 0
    Public _IdExterno As Integer = 0

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        If _IdInterno = 0 Then
            'adiciona serviço ao catalogo

            Dim _TME As Date = Today.Date & " " & TxtTME.Text

            LqBase.InsereNovoServico(TxtDescrição.Text, _TME.TimeOfDay, True, 0, 0, 0, FrmNovoStudioAvaliacao.Ferramenta, FrmSoluçãoNovoStudio._IdCategoria, FrmSoluçãoNovoStudio._IdSubCategoria, 0)

            'Busca ultimo 

            Dim BuscaIdUltimo As Integer = LqBase.Servicos.ToList.Last.IdServico

            'insere serviço na base on line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_servico_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Descricao=" & TxtDescrição.Text & "&TMA=" & (_TME.Minute + (_TME.Hour * 60)) & "&Ativo=0&VlrSugerido=0&IdServicoInt=" & BuscaIdUltimo

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            LqBase.AtualizaVinculoExt_Servico(BuscaIdUltimo, read0.Item(0).Id)

            'busca servico cadastrado

            Dim BuscaServicoCadastrado = From cad In LqBase.Servicos
                                         Where cad.IdServico Like "*"
                                         Select cad.IdServico, cad.Descricao
                                         Order By IdServico Descending

            'varre lista de profissionais hablitados

            For Each row As DataGridViewRow In DtProdutos.Rows

                Dim CodProfissional As Integer = row.Cells(0).Value
                Dim Qtdade As Integer = row.Cells(2).Value

                LqBase.InsereNovoProfissionalServico(CodProfissional, BuscaServicoCadastrado.First.IdServico, Qtdade)

            Next

            'varre a lista de ferramentas, epis, e insumos

            'varre lista de profissionais hablitados

            For Each row As DataGridViewRow In DtFerramentas.Rows

                If row.Cells(0).Value = RdbFeraamenta.Text Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoFerramentaServico(Cod, BuscaServicoCadastrado.First.IdServico, Qtdade)

                ElseIf row.Cells(0).Value = RdbInsumos.Text Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoInsumoServico(Cod, BuscaServicoCadastrado.First.IdServico, Qtdade)

                ElseIf row.Cells(0).Value = "E.P.I." Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoEPIServico(Cod, BuscaServicoCadastrado.First.IdServico)

                End If

            Next

            If Application.OpenForms.OfType(Of FrmSoluçãoNovoStudio)().Count() > 0 Then

                FrmSoluçãoNovoStudio.LstIdServicos.Items.Clear()
                FrmSoluçãoNovoStudio.CmbServicos.Items.Clear()

                For Each row In BuscaServicoCadastrado.ToList
                    FrmSoluçãoNovoStudio.LstIdServicos.Items.Add(row.IdServico)
                    FrmSoluçãoNovoStudio.CmbServicos.Items.Add(row.Descricao)
                Next

                FrmSoluçãoNovoStudio.CmbServicos.SelectedItem = TxtDescrição.Text

                FrmTodosServicos.CarregaInicio()

                Me.Close()

            ElseIf Application.OpenForms.OfType(Of FrmAnalisarveiculo)().Count() > 0 Then

                FrmAnalisarveiculo.CarregaServicos()

                Me.Close()

            ElseIf Application.OpenForms.OfType(Of FrmTodosServicos)().Count() > 0 Then

                FrmTodosServicos.CarregaInicio()

                Me.Close()

            End If

        Else

            'processo de atualização

            Dim _TME As Date = Today.Date & " " & TxtTME.Text

            'Atualiza serviço na base on line

            If _IdExterno <> 0 Then

                Dim baseUrl As String = "http://www.iarasoftware.com.br/atualiza_servico_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Descricao=" & TxtDescrição.Text & "&TMA=" & (_TME.Minute + (_TME.Hour * 60)) & "&Ativo=0&IdServicoInt=" & _IdExterno

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            Else

                'calcula preço com markup

                Dim BuscaProfissionais = From prof In LqBase.ProfissionalServico
                                         Where prof.IdServico = _IdInterno
                                         Select prof.IdProfissional

                Dim VlrTotal As Decimal = 0
                For Each row In BuscaProfissionais.ToList

                    Dim BuscaCargo = From carg In LqBase.Cargos
                                     Where carg.IdCargo = row
                                     Select carg.RemuneracaoBase

                    VlrTotal += BuscaCargo.First

                Next

                VlrTotal /= 220

                Dim BuscaServico = From serv In LqBase.Servicos
                                   Where serv.IdServico = _IdInterno
                                   Select serv.Markup

                Dim VlrFinal As Decimal = VlrTotal * (BuscaServico.First / 100)

                'insere serviço na base on line

                Dim baseUrl As String = "http://www.iarasoftware.com.br/create_servico_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Descricao=" & TxtDescrição.Text & "&TMA=" & (_TME.Minute + (_TME.Hour * 60)) & "&Ativo=0&VlrSugerido=" & VlrFinal & "&IdServicoInt=" & _IdInterno

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient = New WebClient()
                Dim content = syncClient.DownloadString(baseUrl)

                Dim read0 = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

                LqBase.AtualizaVinculoExt_Servico(_IdInterno, read0.Item(0).Id)

            End If

            LqBase.AtualizaServico(_IdInterno, TxtDescrição.Text, _TME.TimeOfDay)

            'busca servico cadastrado

            Dim BuscaServicoCadastrado = From cad In LqBase.Servicos
                                         Where cad.IdServico Like "*"
                                         Select cad.IdServico, cad.Descricao
                                         Order By IdServico Descending

            LqBase.DeletaProfissionalServico(_IdInterno)

            'varre lista de profissionais hablitados

            For Each row As DataGridViewRow In DtProdutos.Rows

                Dim CodProfissional As Integer = row.Cells(0).Value
                Dim Qtdade As Integer = row.Cells(2).Value

                LqBase.InsereNovoProfissionalServico(CodProfissional, BuscaServicoCadastrado.First.IdServico, Qtdade)

            Next

            'varre a lista de ferramentas, epis, e insumos

            LqBase.DeletaFerramentaServico(_IdInterno)

            'varre lista de profissionais hablitados

            For Each row As DataGridViewRow In DtFerramentas.Rows

                If row.Cells(0).Value = RdbFeraamenta.Text Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoFerramentaServico(Cod, BuscaServicoCadastrado.First.IdServico, Qtdade)

                ElseIf row.Cells(0).Value = RdbInsumos.Text Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoInsumoServico(Cod, BuscaServicoCadastrado.First.IdServico, Qtdade)

                ElseIf row.Cells(0).Value = "E.P.I." Then

                    Dim Cod As Integer = row.Cells(1).Value
                    Dim Qtdade As Integer = row.Cells(3).Value

                    LqBase.InsereNovoEPIServico(Cod, BuscaServicoCadastrado.First.IdServico)

                End If

            Next

            FrmTodosServicos.CarregaInicio()

            Me.Close()

        End If

    End Sub

End Class