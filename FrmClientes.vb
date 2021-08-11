Imports System.IO
Imports System.Net
Imports Newtonsoft.Json

Public Class FrmClientes

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then
            'RdbJuridica.Checked = True
            RdbJuridica.Enabled = False
            RdbFisica.Enabled = False

            If Application.OpenForms.OfType(Of FrmEntradaVeículo)().Count() > 0 Then

                TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
                TxtCPF.Enabled = False

                If TxtCPF.Text.Length = 14 Then
                    LblDocCPF_CPNJ.Text = "CNPJ"
                    LblRG_IE.Text = "IE"
                    Ckisento.Visible = True

                    TxtApelido.Enabled = True

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                    'RdbJuridica.Checked = True
                Else
                    LblDocCPF_CPNJ.Text = "CPF"
                    LblRG_IE.Text = "RG"

                    TxtApelido.Enabled = False
                    TxtApelido.Text = TxtNomeCompleto.Text

                    Ckisento.Visible = False
                    Ckisento.Checked = False
                    RdbFisica.Checked = True

                    TxtCPF.Enabled = False
                    TxtIE.Enabled = True
                End If

            ElseIf Application.OpenForms.OfType(Of FrmNovoORçamento)().Count() > 0 Then

                TxtCPF.Enabled = True

            ElseIf Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                RdbJuridica.Checked = True
                TxtApelido.Enabled = True

                RdbJuridica.Enabled = True
                RdbFisica.Enabled = True

            End If

            If RdbFisica.Checked = True Then
                TxtApelido.Text = TxtNomeCompleto.Text
            End If

        Else

            RdbFisica.Checked = False
            RdbJuridica.Checked = False
            TxtCPF.Enabled = False
            TxtCPF.Text = ""
            TxtApelido.Enabled = False
            TxtApelido.Text = ""

        End If

    End Sub
    Private Sub RdbJuridica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbJuridica.CheckedChanged
        SelecionaPersonalidade()
    End Sub
    Private Sub Ckisento_CheckedChanged(sender As Object, e As EventArgs) Handles Ckisento.CheckedChanged
        If Ckisento.Checked = True Then
            TxtIE.Enabled = False
            TxtIE.Text = "Isento"
            TxtCep.Focus()
        Else
            TxtIE.Enabled = True
            TxtIE.Text = ""
        End If
    End Sub
    Private Sub TxtIE_TextChanged(sender As Object, e As EventArgs) Handles TxtIE.TextChanged
        If TxtIE.Text <> "" Then
            TxtCep.Enabled = True
        Else
            TxtCep.Text = ""
            TxtCep.Enabled = False
        End If
    End Sub
    Dim LstIdFuncionarios As New ListBox

    Private Sub LimpaTodos()
        TxtNomeCompleto.Text = ""
        RdbJuridica.Checked = False
        RdbFisica.Checked = False

        TxtCPF.Text = ""
        TxtIE.Text = ""
        LblEndereco.Text = ""
        LblBairro.Text = ""
        LblCidade.Text = ""
        LblEstado.Text = ""
        TxtNumero.Text = ""
        TxtNumero.Enabled = False
        TxtComplemento.Enabled = False

        TxtNomeCompleto.Enabled = False

    End Sub
    Private Sub RdbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFisica.CheckedChanged
        SelecionaPersonalidade()
    End Sub

    Private Sub SelecionaPersonalidade()

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True
            TxtCPF.Mask = "00,000,000/0000-00"

            TxtCPF.Enabled = False
            TxtApelido.Visible = True
            TxtApelido.Focus()

        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False
            TxtCPF.Mask = "000,000,000-00"

            TxtCPF.Enabled = True
            TxtIE.Enabled = False

            If TxtCPF.Text <> "" Then
                TxtIE.Enabled = True
            End If
            TxtApelido.Visible = False
            TxtCPF.Focus()

        End If

        If FrmOri = 1 Then
            TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
            TxtCPF.Enabled = False
            TxtIE.Focus()

        End If

    End Sub
    Public FrmOri As Integer

    Dim LqCadastros As New DtCadastroDataContext
    Dim LqBase As New DtCadastroDataContext

    Public LstIdEndereço As New ListBox
    Public LstIdBairro As New ListBox

    Public LstIdPaisesTodos As New ListBox
    Public LstSiglaPais As New ListBox
    Public LstdescricaoPais As New ListBox

    Public LstIdCidadeTodos As New ListBox

    Public LstidEstadoTodos As New ListBox
    Public LstSiglaEstado As New ListBox
    Public LstdescricaoEstado As New ListBox

    Public LstIdBairroTodos As New ListBox
    Public _IdEndereco As Integer

    Private Sub TxtCep_TextChanged(sender As Object, e As EventArgs) Handles TxtCep.TextChanged

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

        If TxtCep.Text.Length = 8 Then

            Dim _Endereco As String = ""

            'busca dados do 
            Dim ds As New DataSet()
            Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", TxtCep.Text)
            ds.ReadXml(xml)

            LblEndereco.Text = ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString()
            LblBairro.Text = ds.Tables(0).Rows(0)("bairro").ToString()
            LblCidade.Text = ds.Tables(0).Rows(0)("cidade").ToString()
            LblEstado.Text = ds.Tables(0).Rows(0)("uf").ToString()

            TxtNumero.Enabled = True
            TxtNumero.Focus()

        Else

            LblEndereco.Enabled = False
            TxtNumero.Enabled = False
            TxtComplemento.Enabled = False
            LblBairro.Enabled = False
            LblCidade.Enabled = False
            LblEstado.Enabled = False
            LblPais.Enabled = False

            LblEndereco.Text = ""
            TxtNumero.Text = ""
            TxtComplemento.Text = ""
            LblBairro.Text = ""
            LblCidade.Text = ""
            LblEstado.Text = ""

        End If

    End Sub
    Private Sub TxtNumero_TextChanged(sender As Object, e As EventArgs) Handles TxtNumero.TextChanged

        If TxtNumero.Text <> "" Then

            TxtComplemento.Enabled = True

            BttSetores.Enabled = True
            BttFunções.Enabled = True
            BttColaboradores.Enabled = True

        Else

            TxtComplemento.Enabled = False

            BttSetores.Enabled = False
            BttFunções.Enabled = False
            BttColaboradores.Enabled = False

            TxtComplemento.Text = ""

        End If

    End Sub

    Public IdCliente As Integer = 0
    Private Sub TxtCPF_TextChanged(sender As Object, e As EventArgs) Handles TxtCPF.TextChanged

        If TxtCPF.Enabled = True Then
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            If RdbFisica.Checked = True Then

                If TxtCPF.Text.Length = 11 Then
                    If Leitura = True Then
                        'busca se chave é valida
                        Dim BuscaDOC = From doc In LqTrabalhista.ColaboradoresCliente
                                       Where doc.DocColaborador Like TxtCPF.Text And doc.IdCliente = IdCliente
                                       Select doc.NomeColaborador

                        If BuscaDOC.Count = 0 Then
                            TxtIE.Enabled = True
                            TxtIE.Focus()
                        Else
                            MsgBox("Este documento já esta cadastrado no banco de dados", MsgBoxStyle.OkOnly)
                            TxtCPF.Text = ""
                        End If
                    Else
                        TxtIE.Enabled = True
                        TxtIE.Focus()
                    End If

                ElseIf TxtCPF.Text.Length < 11 Then
                    TxtIE.Text = ""
                    TxtIE.Enabled = False
                End If

            Else

                If TxtCPF.Text.Length = 14 Then
                    If Leitura = True Then
                        'busca se chave é valida
                        Dim BuscaDOC = From doc In LqTrabalhista.ColaboradoresCliente
                                       Where doc.DocColaborador Like TxtCPF.Text And doc.IdCliente = IdCliente
                                       Select doc.NomeColaborador

                        If BuscaDOC.Count = 0 Then
                            TxtIE.Enabled = True
                            Ckisento.Checked = False
                            Ckisento.Enabled = True
                            Ckisento.Visible = True
                            TxtIE.Focus()
                        Else
                            MsgBox("Este documento já esta cadastrado no banco de dados", MsgBoxStyle.OkOnly)
                            TxtCPF.Text = ""
                        End If
                    Else
                        TxtIE.Enabled = True
                        TxtIE.Focus()
                    End If

                ElseIf TxtCPF.Text.Length < 12 Then

                    TxtIE.Text = ""
                    TxtIE.Enabled = False
                    Ckisento.Checked = False
                    Ckisento.Checked = False
                    Ckisento.Visible = False

                    TxtCPF.Mask = "000,000,000-000"

                ElseIf TxtCPF.Text.Length > 11 Then

                    TxtCPF.Mask = "00,000,000/0000-00"

                End If

            End If
        End If

    End Sub
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        'atualiza dados

        If Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

            FrmListaClientes.CarregaInicio()

        End If

        Me.Close()

    End Sub

    Private Sub TxtPais_TextChanged(sender As Object, e As EventArgs)



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BttSalvarColaborador.Click

        If IdCliente = 0 Then

            LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Documento As String = ""

            If TxtCPF.Text.Length = 11 Then

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text.Replace(" ", "")

            Else

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text

            End If

            'salva colaborador

            LqCadastros.InsereCliente(TxtNomeCompleto.Text, Documento, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, "Brasil", 0, 0, "", 0, TxtApelido.Text)

            'pega ultimo Id

            Dim BuscaUltimoID = From ult In LqBase.Clientes
                                Where ult.IdCliente Like "*"
                                Select ult.IdCliente
                                Order By IdCliente Descending

            Dim UltimID As Integer = BuscaUltimoID.First

            'atualiza id do cliente 

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.AtualizaSetorIdClientetodos(IdCliente)

            'insere na base on-line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_cliente_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Doc=" & Documento & "&NomeCliente=" & TxtNomeCompleto.Text & "&email=ND&celular=ND&cep=" & TxtCep.Text & "&endereco=" & LblEndereco.Text & "&bairro=" & LblBairro.Text & "&cidade=" & LblCidade.Text & "&estado=" & LblEstado.Text & "&pais=Brasil&numero=" & TxtNumero.Text & "&complemento=" & TxtComplemento.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                LqCadastros.AtualizaIdVinculoExtCliente(UltimID, read.Item(0).Id)

            End If
            'carrega colaboradores

            If Application.OpenForms.OfType(Of FrmEntradaVeículo)().Count() > 0 Then

                FrmEntradaVeículo.TxtDocumento.Text = TxtCPF.Text
                FrmEntradaVeículo.BttBuscarCliente.PerformClick()

            ElseIf Application.OpenForms.OfType(Of FrmNovoORçamento)().Count() > 0 Then

                'atualiza 

                Dim LqComercial As New LqComercialDataContext
                LqComercial.Connection.ConnectionString = FrmPrincipal.ConnectionStringComercial

                Dim BUscaCliente = From cli In LqBase.Clientes
                                   Where cli.CPF_CNPJ Like TxtCPF.Text
                                   Select cli.IdCliente

                LqComercial.AtualizaClienteOrcameto(FrmNovoORçamento.LblNumOrcamento.Text, BUscaCliente.First)

                FrmNovoORçamento.Close()

            ElseIf Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                FrmListaClientes.CarregaInicio()

            End If

        Else

            'atualiza dados

            If Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then

                FrmListaClientes.CarregaInicio()

            End If

        End If

        Me.Close()

    End Sub

    Public Leitura As Boolean = False

    Private Sub FrmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'verifica a origem do form

        If Application.OpenForms.OfType(Of FrmListaClientes)().Count() > 0 Then
            'adiciona nos vinculos
            BttSetores.Visible = True
            BttFunções.Visible = True
            BttColaboradores.Visible = True

            Label4.Text = "Razão Social"

        Else

            BttSetores.Visible = False
            BttFunções.Visible = False
            BttColaboradores.Visible = False

            Label4.Text = "Nome completo"

        End If

        CarregaInicio()

    End Sub
    Public Sub CarregaInicio()

        DtFornecedores.Rows.Clear()

        'busca colaboradores para o cliente

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaTrabalhista = From trab In LqTrabalhista.ColaboradoresCliente
                               Where trab.IdCliente = IdCliente
                               Select trab.IdColaboradorCliente, trab.DescricaoFuncao, trab.NomeColaborador

        For Each row In BuscaTrabalhista.ToList

            DtFornecedores.Rows.Add(row.IdColaboradorCliente, row.NomeColaborador, row.DescricaoFuncao, "", ImgLstIco.Images(1), ImgLstIco.Images(0), ImgLstIco.Images(8), ImgLstIco.Images(7))

        Next

    End Sub

    Private Sub TxtApelido_TextChanged(sender As Object, e As EventArgs) Handles TxtApelido.TextChanged

        If TxtApelido.Text <> "" Then
            TxtCPF.Enabled = True
        Else
            TxtCPF.Enabled = False
        End If

    End Sub

    Private Sub BttSetores_Click(sender As Object, e As EventArgs) Handles BttSetores.Click
        If IdCliente = 0 Then

            LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Documento As String = ""

            If TxtCPF.Text.Length = 11 Then

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text.Replace(" ", "")

            Else

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text

            End If

            'salva colaborador

            LqCadastros.InsereCliente(TxtNomeCompleto.Text, Documento, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, "Brasil", 0, 0, "", 0, TxtApelido.Text)

            'pega ultimo Id

            Dim BuscaUltimoID = From ult In LqBase.Clientes
                                Where ult.IdCliente Like "*"
                                Select ult.IdCliente
                                Order By IdCliente Descending

            Dim UltimID As Integer = BuscaUltimoID.First

            IdCliente = UltimID

            'atualiza id do cliente 

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.AtualizaSetorIdClientetodos(IdCliente)

            'insere na base on-line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_cliente_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Doc=" & Documento & "&NomeCliente=" & TxtNomeCompleto.Text & "&email=ND&celular=ND&cep=" & TxtCep.Text & "&endereco=" & LblEndereco.Text & "&bairro=" & LblBairro.Text & "&cidade=" & LblCidade.Text & "&estado=" & LblEstado.Text & "&pais=Brasil&numero=" & TxtNumero.Text & "&complemento=" & TxtComplemento.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                LqCadastros.AtualizaIdVinculoExtCliente(UltimID, read.Item(0).Id)

            End If
            'carrega colaboradores

        End If

        Me.Cursor = Cursors.WaitCursor

        FrmSetoresClientes.IdCliente = IdCliente
        FrmSetoresClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttFunções_Click(sender As Object, e As EventArgs) Handles BttFunções.Click
        If IdCliente = 0 Then

            LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Documento As String = ""

            If TxtCPF.Text.Length = 11 Then

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text.Replace(" ", "")

            Else

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text

            End If

            'salva colaborador

            LqCadastros.InsereCliente(TxtNomeCompleto.Text, Documento, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, "Brasil", 0, 0, "", 0, TxtApelido.Text)

            'pega ultimo Id

            Dim BuscaUltimoID = From ult In LqBase.Clientes
                                Where ult.IdCliente Like "*"
                                Select ult.IdCliente
                                Order By IdCliente Descending

            Dim UltimID As Integer = BuscaUltimoID.First

            IdCliente = UltimID

            'atualiza id do cliente 

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.AtualizaSetorIdClientetodos(IdCliente)

            'insere na base on-line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_cliente_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Doc=" & Documento & "&NomeCliente=" & TxtNomeCompleto.Text & "&email=ND&celular=ND&cep=" & TxtCep.Text & "&endereco=" & LblEndereco.Text & "&bairro=" & LblBairro.Text & "&cidade=" & LblCidade.Text & "&estado=" & LblEstado.Text & "&pais=Brasil&numero=" & TxtNumero.Text & "&complemento=" & TxtComplemento.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                LqCadastros.AtualizaIdVinculoExtCliente(UltimID, read.Item(0).Id)

            End If
            'carrega colaboradores

        End If

        Me.Cursor = Cursors.WaitCursor

        FrmFuncoesClientes.IdCliente = IdCliente
        FrmFuncoesClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub BttColaboradores_Click(sender As Object, e As EventArgs) Handles BttColaboradores.Click
        If IdCliente = 0 Then

            LqCadastros.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

            Dim Documento As String = ""

            If TxtCPF.Text.Length = 11 Then

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text.Replace(" ", "")

            Else

                TxtCPF.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                Documento = TxtCPF.Text

            End If

            'salva colaborador

            LqCadastros.InsereCliente(TxtNomeCompleto.Text, Documento, TxtIE.Text, RdbJuridica.Checked, TxtCep.Text, 0, LblEndereco.Text, TxtNumero.Text, TxtComplemento.Text, LblBairro.Text, LblCidade.Text, LblEstado.Text, "Brasil", 0, 0, "", 0, TxtApelido.Text)

            'pega ultimo Id

            Dim BuscaUltimoID = From ult In LqBase.Clientes
                                Where ult.IdCliente Like "*"
                                Select ult.IdCliente
                                Order By IdCliente Descending

            Dim UltimID As Integer = BuscaUltimoID.First

            IdCliente = UltimID

            'atualiza id do cliente 

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            LqTrabalhista.AtualizaSetorIdClientetodos(IdCliente)

            'insere na base on-line

            Dim baseUrl As String = "http://www.iarasoftware.com.br/create_cliente_local.php?ChaveOficina=" & FrmPrincipal.LblChaveEnc.Text & "&Doc=" & Documento & "&NomeCliente=" & TxtNomeCompleto.Text & "&email=ND&celular=ND&cep=" & TxtCep.Text & "&endereco=" & LblEndereco.Text & "&bairro=" & LblBairro.Text & "&cidade=" & LblCidade.Text & "&estado=" & LblEstado.Text & "&pais=Brasil&numero=" & TxtNumero.Text & "&complemento=" & TxtComplemento.Text

            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)
            Dim read = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Create))("[" & content & "]")

            If read.Count > 0 Then

                LqCadastros.AtualizaIdVinculoExtCliente(UltimID, read.Item(0).Id)

            End If
            'carrega colaboradores

        End If

        Me.Cursor = Cursors.WaitCursor

        FrmNovoColaboradorCliente.IdCliente = IdCliente

        FrmNovoColaboradorCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub DtFornecedores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtFornecedores.CellContentClick

        Me.Cursor = Cursors.WaitCursor

        If DtFornecedores.Columns(e.ColumnIndex).Name = "ClmExcluirCliente" Then

            If MsgBox("Deseja realmente excluir o colaborador " & DtFornecedores.Rows(e.RowIndex).Cells(1).Value, MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                Dim LqTrabalhista As New LqTrabalhistaDataContext
                LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

                LqTrabalhista.DeletaColaboradorCliente(DtFornecedores.Rows(e.RowIndex).Cells(0).Value)
                Me.Cursor = Cursors.Arrow

            End If

        ElseIf DtFornecedores.Columns(e.ColumnIndex).Name = "ClmEditarCliente" Then

            FrmNovoColaboradorCliente.IdCliente = IdCliente
            FrmNovoColaboradorCliente.IdColaboradorCliente = DtFornecedores.Rows(e.RowIndex).Cells(0).Value
            FrmNovoColaboradorCliente.Show(Me)
            Me.Cursor = Cursors.Arrow

        ElseIf DtFornecedores.Columns(e.ColumnIndex).Name = "ClmCAT" Then

            Form2210.Show(Me)

            Form2210.TxtDodCliente.Text = TxtCPF.Text
            Form2210.TxtDodCliente.Text &= TxtCPF.Text.ToCharArray(12, 2)
            Form2210.TxtDodCliente.Enabled = False
            Form2210.CmbTodosClientes.Enabled = False

            'busca doc do colaborador
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdColaborador As Integer = DtFornecedores.Rows(e.RowIndex).Cells(0).Value

            Dim BuscaColaborador = From col In LqTrabalhista.ColaboradoresCliente
                                   Where col.IdCliente = IdCliente And col.IdColaboradorCliente = IdColaborador
                                   Select col.IdColaboradorCliente, col.NomeColaborador, col.DocColaborador, col.CatTrab, col.GrupoTrab

            Form2210.LStDoColab.Items.Clear()
            Form2210.CmbColaboradores.Items.Clear()
            Form2210.LstIdColaborador.Items.Clear()

            For Each row In BuscaColaborador.ToList
                Form2210.LStDoColab.Items.Add(row.DocColaborador)
                Form2210.CmbColaboradores.Items.Add(row.NomeColaborador)
                Form2210.LstIdColaborador.Items.Add(row.IdColaboradorCliente)

                If row.GrupoTrab = "" Then
                    Form2210.LstMatricula.Items.Add(row.CatTrab)
                    Form2210.LstGrupoTrab.Items.Add("")
                Else
                    Form2210.LstGrupoTrab.Items.Add(row.CatTrab.ToCharArray(0, 3))
                    Form2210.LstMatricula.Items.Add("")
                End If
            Next

            Form2210.TxtDocColaborador.Text = BuscaColaborador.First.DocColaborador
            Form2210.TxtDocColaborador.Enabled = False

            Form2210.CmbColaboradores.SelectedItem = DtFornecedores.Rows(e.RowIndex).Cells(1).Value
            Form2210.CmbColaboradores.Enabled = False

            Me.Cursor = Cursors.Arrow

        ElseIf DtFornecedores.Columns(e.ColumnIndex).Name = "ClmASO" Then

            Frm2220.Show(Me)

            Frm2220.TxtDodCliente.Text = TxtCPF.Text
            Frm2220.TxtDodCliente.Text &= TxtCPF.Text.ToCharArray(12, 2)
            Frm2220.TxtDodCliente.Enabled = False
            Frm2220.CmbTodosClientes.Enabled = False

            'busca doc do colaborador
            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim IdColaborador As Integer = DtFornecedores.Rows(e.RowIndex).Cells(0).Value

            Dim BuscaColaborador = From col In LqTrabalhista.ColaboradoresCliente
                                   Where col.IdCliente = IdCliente And col.IdColaboradorCliente = IdColaborador
                                   Select col.IdColaboradorCliente, col.NomeColaborador, col.DocColaborador, col.CatTrab, col.GrupoTrab

            Frm2220.LStDoColab.Items.Clear()
            Frm2220.CmbColaboradores.Items.Clear()
            Frm2220.LstIdColaborador.Items.Clear()

            For Each row In BuscaColaborador.ToList
                Frm2220.LStDoColab.Items.Add(row.DocColaborador)
                Frm2220.CmbColaboradores.Items.Add(row.NomeColaborador)
                Frm2220.LstIdColaborador.Items.Add(row.IdColaboradorCliente)

                If row.GrupoTrab = "" Then
                    Frm2220.LstMatricula.Items.Add(row.CatTrab)
                    Frm2220.LstGrupoTrab.Items.Add("")
                Else
                    Frm2220.LstGrupoTrab.Items.Add(row.CatTrab.ToCharArray(0, 3))
                    Frm2220.LstMatricula.Items.Add("")
                End If
            Next

            Frm2220.TxtDocColaborador.Text = BuscaColaborador.First.DocColaborador
            Frm2220.TxtDocColaborador.Enabled = False

            Frm2220.CmbColaboradores.SelectedItem = DtFornecedores.Rows(e.RowIndex).Cells(1).Value
            Frm2220.CmbColaboradores.Enabled = False

            Me.Cursor = Cursors.Arrow

        End If

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub
End Class