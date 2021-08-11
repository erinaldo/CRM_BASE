Imports System.Text
Imports System.Xml
Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.X509Certificates
Imports System.Security.Cryptography.Xml

Public Class FrmNovoColaboradorCliente
    Public IdCliente As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Close()

    End Sub

    Public Sub CarregaFuncoes()

        LstIdFuncao.Items.Clear()
        CmbFuncao.Items.Clear()

        'busca funções

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim BuscaFuncao = From func In LqTrabalhista.FuncoesClientes
                          Where func.IdCliente = IdCliente
                          Select func.IdFuncaoCliente, func.Descricao

        For Each it In BuscaFuncao.ToList

            LstIdFuncao.Items.Add(it.IdFuncaoCliente)
            CmbFuncao.Items.Add(it.Descricao)

        Next

        'verifica se habilita funcao
        If NomeFuncao <> "" Then
            CmbFuncao.SelectedItem = NomeFuncao
        End If

    End Sub
    Private Sub BttFunções_Click(sender As Object, e As EventArgs)

        Me.Cursor = Cursors.WaitCursor

        FrmFuncoesClientes.IdCliente = IdCliente
        FrmFuncoesClientes.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then
            'RdbJuridica.Checked = True
            RdbJuridica.Enabled = True
            RdbFisica.Enabled = True
            RdbJuridica.Checked = False
            RdbFisica.Checked = False
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

            End If

            If RdbFisica.Checked = True Then
                TxtApelido.Text = TxtNomeCompleto.Text
            End If

        Else

            RdbFisica.Enabled = False
            RdbJuridica.Enabled = False
            RdbFisica.Checked = False
            RdbJuridica.Checked = False
            TxtCPF.Enabled = False
            TxtCPF.Text = ""
            TxtApelido.Enabled = False
            TxtApelido.Text = ""

        End If

    End Sub
    Private Sub RdbJuridica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbJuridica.CheckedChanged

        If RdbJuridica.Checked = True Then
            LblDocCPF_CPNJ.Text = "CNPJ"
            LblRG_IE.Text = "IE"
            Ckisento.Visible = True

            'TxtCPF.Enabled = True
        Else
            LblDocCPF_CPNJ.Text = "CPF"
            LblRG_IE.Text = "RG"
            Ckisento.Visible = False
            Ckisento.Checked = False

            TxtCPF.Enabled = False
            TxtIE.Enabled = False

            'TxtCPF.Text = ""
        End If

        TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
        TxtCPF.Enabled = False

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
        LblPais.Text = ""
        TxtNumero.Text = ""
        TxtNumero.Enabled = False
        TxtComplemento.Enabled = False

        TxtNomeCompleto.Enabled = False

    End Sub
    Private Sub RdbFisica_CheckedChanged(sender As Object, e As EventArgs) Handles RdbFisica.CheckedChanged

        If FrmOri = 1 Then
            TxtCPF.Text = FrmEntradaVeículo.TxtDocumento.Text
            TxtCPF.Enabled = False
        End If

        If RdbFisica.Enabled = True Then
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

            TxtTelefone.Enabled = True
            TxtCelular.Enabled = True
            TxtEmail.Enabled = True

            'verifica se habilita funcao
            If NomeFuncao <> "" Then
                CmbFuncao.SelectedItem = NomeFuncao
            End If

        Else

            TxtComplemento.Enabled = False
            TxtTelefone.Enabled = False
            TxtCelular.Enabled = False
            TxtEmail.Enabled = False

            TxtComplemento.Text = ""
            TxtTelefone.Text = ""
            TxtCelular.Text = ""
            TxtEmail.Text = ""

        End If

    End Sub

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
    Private Sub TxtApelido_TextChanged(sender As Object, e As EventArgs) Handles TxtApelido.TextChanged

        If TxtApelido.Text <> "" Then
            TxtCPF.Enabled = True
        Else
            TxtCPF.Enabled = False
        End If

    End Sub

    Public NomeFuncao As String = ""
    Private Sub TxtTelefone_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefone.TextChanged

        If TxtTelefone.Text.Length < 11 Then
            TxtTelefone.Mask = "(00) 0000-00000"
            TxtTelefone.SelectionStart = 14

        ElseIf TxtTelefone.Text.Length = 11 Then
            TxtTelefone.Mask = "(00) 0 0000-00000"
            TxtTelefone.SelectionStart = 15

        ElseIf TxtTelefone.Text.Length = 12 Then
            TxtTelefone.Mask = "(00) 00 0000-00000"
            TxtTelefone.SelectionStart = 16

        ElseIf TxtTelefone.Text.Length = 13 Then
            TxtTelefone.Mask = "(00) 000 0000-00000"
            TxtTelefone.SelectionStart = 17

        End If

        If TxtTelefone.Text.Length > 9 Then
            TxtTelefone.SelectionStart = TxtTelefone.TextLength
        Else
            TxtTelefone.SelectionStart = TxtTelefone.Text.Length
        End If

        Valida_1()

    End Sub

    Private Sub Valida_1()

        If TxtTelefone.Text.Length > 0 Or TxtCelular.Text.Length > 0 Or TxtEmail.Text <> "" Then

            TxtRemuneracao.Enabled = True
            CmbFuncao.Enabled = True
            BttAddProduto.Enabled = True

            TxtRemuneracao.Text = "R$ 0,00"

        Else

            TxtRemuneracao.Text = "R$ 0,00"
            TxtRemuneracao.Enabled = False
            CmbFuncao.Enabled = False
            BttAddProduto.Enabled = False

        End If

    End Sub

    Private Sub TxtCelular_TextChanged(sender As Object, e As EventArgs) Handles TxtCelular.TextChanged

        If TxtCelular.Text.Length < 11 Then
            TxtCelular.Mask = "(00) 0000-00000"
        ElseIf TxtCelular.Text.Length = 11 Then
            TxtCelular.Mask = "(00) 0 0000-00000"
        ElseIf TxtCelular.Text.Length = 12 Then
            TxtCelular.Mask = "(00) 00 0000-00000"
        ElseIf TxtCelular.Text.Length = 13 Then
            TxtCelular.Mask = "(00) 000 0000-00000"
        End If

        TxtCelular.SelectionStart = TxtCelular.TextLength

        Valida_1()

    End Sub

    Dim LstIdFuncao As New ListBox

    Dim Envia As Boolean = False
    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        If CkVinculo.Checked = False Then

            CmbCategoriaTrabalhador.Text = TxtNumeroMatricula.Text

        End If

        'deseja transmitir o xml

        If MsgBox("Deseja enviar as informações do E-Social agora?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
            'transmite alteraçoes

            'salva no banco de dados

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim Persona As Boolean = False

            If RdbFisica.Checked = True Then

                Persona = True

            End If

            If IdColaboradorCliente = 0 Then

                Dim TipoDocN As Integer = 0

                If RdbNIT.Checked = True Then
                    TipoDocN = 1
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 2
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 3
                End If

                LqTrabalhista.InsereColaboradorCliente(IdCliente, TxtNomeCompleto.Text, TxtApelido.Text, Persona, TxtCPF.Text, TxtIE.Text, TxtCep.Text, TxtNumero.Text, TxtComplemento.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, LstIdFuncao.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.Text, TxtRemuneracao.Text, TxttAdmissao.Value, "1111-11-11", CmbGrupo.Text, CmbCategoriaTrabalhador.Text, TipoDocN, TxtNDocEsocial.Text)
                IdColaboradorCliente = LqTrabalhista.ESocial.ToList.Last.IdColaborador
                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2190", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2190")
                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2200", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2200")

            Else

                Dim TipoDocN As Integer = 0

                If RdbNIT.Checked = True Then
                    TipoDocN = 1
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 2
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 3
                End If

                Dim DtDesligamento As Date = "1111-11-11"

                If CkDsligamento.Checked = True Then
                    DtDesligamento = TxtDemissao.Value
                End If

                LqTrabalhista.EditaColaboradorCliente(IdColaboradorCliente, TxtNomeCompleto.Text, TxtApelido.Text, Persona, TxtCPF.Text, TxtIE.Text, TxtCep.Text, TxtNumero.Text, TxtComplemento.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, LstIdFuncao.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.Text, TxtRemuneracao.Text, TxttAdmissao.Value, DtDesligamento, CmbGrupo.Text, CmbCategoriaTrabalhador.Text, TipoDocN, TxtNDocEsocial.Text)

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2205", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2205")

            End If

            '

            'insere o evento trabalhista

            If Remun <> TxtRemuneracao.Text Then

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-1210", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-1210")

            End If


            If CkVinculo.Checked = True Then

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2300", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2300")

            End If

            FrmClientes.CarregaInicio()

            Me.Close()

        Else
            'transmite alteraçoes

            'salva no banco de dados

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim Persona As Boolean = False

            If RdbFisica.Checked = True Then

                Persona = True

            End If

            If IdColaboradorCliente = 0 Then

                Dim TipoDocN As Integer = 0

                If RdbNIT.Checked = True Then
                    TipoDocN = 1
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 2
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 3
                End If

                LqTrabalhista.InsereColaboradorCliente(IdCliente, TxtNomeCompleto.Text, TxtApelido.Text, Persona, TxtCPF.Text, TxtIE.Text, TxtCep.Text, TxtNumero.Text, TxtComplemento.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, LstIdFuncao.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.Text, TxtRemuneracao.Text, TxttAdmissao.Value, "1111-11-11", CmbGrupo.Text, CmbCategoriaTrabalhador.Text, TipoDocN, TxtNDocEsocial.Text)
                IdColaboradorCliente = LqTrabalhista.ColaboradoresCliente.ToList.Last.IdColaboradorCliente
                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2190", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2190")
                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2200", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2200")

            Else

                Dim TipoDocN As Integer = 0

                If RdbNIT.Checked = True Then
                    TipoDocN = 1
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 2
                ElseIf RdbPIS.Checked = True Then
                    TipoDocN = 3
                End If

                Dim DtDesligamento As Date = "1111-11-11"

                If CkDsligamento.Checked = True Then
                    DtDesligamento = TxtDemissao.Value
                End If

                LqTrabalhista.EditaColaboradorCliente(IdColaboradorCliente, TxtNomeCompleto.Text, TxtApelido.Text, Persona, TxtCPF.Text, TxtIE.Text, TxtCep.Text, TxtNumero.Text, TxtComplemento.Text, TxtTelefone.Text, TxtCelular.Text, TxtEmail.Text, LstIdFuncao.Items(CmbFuncao.SelectedIndex).ToString, CmbFuncao.Text, TxtRemuneracao.Text, TxttAdmissao.Value, DtDesligamento, CmbGrupo.Text, CmbCategoriaTrabalhador.Text, TipoDocN, TxtNDocEsocial.Text)

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2205", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2205")

            End If

            '

            'insere o evento trabalhista

            If Remun <> TxtRemuneracao.Text Then

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-1210", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-1210")

            End If

            If CkDsligamento.Checked = True Then

                'LqTrabalhista.InsereESocial(IdCliente, IdColaboradorCliente, "S-2299", Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay)
                'EmiteDocumento("S-2299")

            End If

            FrmClientes.CarregaInicio()

            Me.Close()

        End If

    End Sub

    Public Sub EmiteDocumento(ByVal Evento As String)

        'monta arquivo xml

        Dim Persona As String = "2 - CPF"
        Dim PersonaSel As Integer = 2

        If TxtCPF.Text.Length = 11 Then
            Persona = "2 - CPF"
            PersonaSel = 2
        Else
            Persona = "1 - CNPJ"
            PersonaSel = 1
        End If

        Dim Doc As String

        If PersonaSel = 2 Then

            Doc = "000" & TxtCPF.Text

        Else

            'verifica os inicios

            Dim Valid As String = TxtCPF.Text

            If Valid.StartsWith("1015") Or Valid.StartsWith("1040") Or Valid.StartsWith("1074") Or Valid.StartsWith("1163") Then

                Doc = TxtCPF.Text

            ElseIf Not Valid.StartsWith("1015") And Not Valid.StartsWith("1040") And Not Valid.StartsWith("1074") And Not Valid.StartsWith("1163") Then

                Doc = "000" & TxtCPF.Text.ToCharArray(0, 8)

            End If

        End If

        Dim Mes As Integer = Today.Month

        If Mes.ToString.Length = 1 Then

            Mes = "0" & Mes

        End If

        Dim Dia As Integer = Today.Day

        If Dia.ToString.Length = 1 Then

            Dia = "0" & Dia

        End If

        Dim Hora As Integer = Now.Hour

        If Hora.ToString.Length = 1 Then

            Hora = "0" & Hora

        End If

        Dim Minuto As Integer = Now.Minute

        If Minuto.ToString.Length = 1 Then

            Minuto = "0" & Minuto

        End If

        Dim Segundo As Integer = Now.Second

        If Segundo.ToString.Length = 1 Then

            Segundo = "0" & Segundo

        End If

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        Dim IdSocial As String = LqTrabalhista.ESocial.ToList.Last.IdESocial

        If IdSocial.ToString.Length = 1 Then

            IdSocial = "0000" & IdSocial

        ElseIf IdSocial.ToString.Length = 2 Then

            IdSocial = "000" & IdSocial

        ElseIf IdSocial.ToString.Length = 3 Then

            IdSocial = "00" & IdSocial

        ElseIf IdSocial.ToString.Length = 4 Then

            IdSocial = "0" & IdSocial

        End If


        Dim Identificacao As String = "ID" & PersonaSel & Doc & Today.Year & Mes & Dia & Hora & Minuto & Segundo & IdSocial

        'cria documento xml
        Dim writer As New XmlTextWriter("C:\Iara\ESocial\" & Identificacao & ".xml", Encoding.UTF8)

        'replace 
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;
        ''> (sinal de maior) &gt; 
        ''< (sinal de menor) &lt; 
        ''& (e comercial) &amp;

        'inicia o documento xml

        writer.WriteStartDocument()

        'escreve o elmento raiz

        writer.WriteStartElement("eSocial", "http://www.esocial.gov.br/schema/evt/evt" & Evento & "/v1_0_0")

        writer.WriteStartElement("evt" & Evento)

        writer.WriteElementString("Id", Evento)
        writer.WriteElementString("versao", "1.0")

        writer.WriteStartElement("ideEvento")

        writer.WriteElementString("tpAmb", "8")
        writer.WriteElementString("procEmi", "1")
        writer.WriteElementString("verProc", "1.0.0")

        writer.WriteEndElement()

        writer.WriteStartElement("ideEmpregador")


        writer.WriteElementString("tpInsc", Persona)
        writer.WriteElementString("nrInsc", Doc)

        writer.WriteEndElement()

        writer.WriteStartElement("infoXXX")

        writer.WriteEndElement()

        writer.WriteElementString("Signature", Identificacao)

        writer.WriteEndElement()

        'Escreve o XML para o arquivo e fecha o objeto escritor

        writer.Close()

        'assina o xml

        'selecionar certificado

        SelecionarCertificado("C:\Iara\ESocial\" & Identificacao & ".xml", Identificacao)

    End Sub
    Dim ObjCertificadoX509 As New X509Certificate2
    Dim GetCerificateX509 As New X509Store("MY", StoreLocation.CurrentUser)
    Dim objColecaoCertificadosX509 As New X509Certificate2Collection

    Private Sub AssinarDocumentoXML(ByVal ArqXmlAssinar As String, ByVal TagXml As String, ByVal StrSercialCertifiado As String, ByVal StrIdentificacao As String)

        'Try

        'assina com o certificado selecionados

        ObjCertificadoX509 = objColecaoCertificadosX509.Item(0)

        Dim DocXML As New XmlDocument()

        DocXML.PreserveWhitespace = False
        DocXML.Load(ArqXmlAssinar)

        Dim signedXml As New Xml.SignedXml(DocXML)

        signedXml.SigningKey = ObjCertificadoX509.PrivateKey

        Dim Referencia As New Xml.Reference()
        Referencia.Uri = TagXml

        Dim env As New XmlDsigEnvelopedSignatureTransform

        Referencia.AddTransform(env)

        Dim c14 As New XmlDsigC14NTransform

        Referencia.AddTransform(c14)

        signedXml.AddReference(Referencia)

        Dim KeyInfo As New KeyInfo

        KeyInfo.AddClause(New KeyInfoX509Data(ObjCertificadoX509))

        signedXml.KeyInfo = KeyInfo

        Try

            signedXml.ComputeSignature()

            Dim XmlDigitalSignature As XmlElement
            XmlDigitalSignature = signedXml.GetXml()

            DocXML.DocumentElement.AppendChild(DocXML.ImportNode(XmlDigitalSignature, True))

            Dim EscreverXML As New StreamWriter(ArqXmlAssinar)
            EscreverXML.Write(DocXML.OuterXml)
            EscreverXML.Close()

            If DocXML.GetElementsByTagName(TagXml).Count = 1 Then
                'MsgBox("Existe")
            End If
            'fecha o form

            FrmColaboradoresClientes.CarregaInicio()

            Process.Start("C:\Iara\ESocial\" & StrIdentificacao & ".xml")

            Me.Close()

        Catch ex As Exception

            MsgBox("Certificado não suportado!", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Erro de certificado")
            Process.Start("C:\Iara\ESocial\" & StrIdentificacao & ".xml")

        End Try


        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub SelecionarCertificado(ByVal ArqXmlAssinar As String, ByVal StrIdentificacao As String)

        'Try

        GetCerificateX509.Open(OpenFlags.ReadOnly Or OpenFlags.OpenExistingOnly)

        objColecaoCertificadosX509 = X509Certificate2UI.SelectFromCollection(GetCerificateX509.Certificates,
"Certificado(s) dísponível(is)", "Selecione o certificado.", X509SelectionFlag.SingleSelection)

        If objColecaoCertificadosX509.Count > 0 Then

            AssinarDocumentoXML(ArqXmlAssinar, "Signature", objColecaoCertificadosX509.Item(0).SerialNumber.ToString, StrIdentificacao)

        End If

        'Catch ex As Exception

        '    MsgBox(ex.Message)

        'End Try

    End Sub

    Private Sub TxtRemuneracao_TextChanged(sender As Object, e As EventArgs) Handles TxtRemuneracao.TextChanged

        If TxtRemuneracao.Enabled = True Then
            If TxtRemuneracao.Text = "" Then
                TxtRemuneracao.Text = "0,00"
            End If
        End If

        'verifica se habilita funcao
        If NomeFuncao <> "" Then
            CmbFuncao.SelectedItem = NomeFuncao
        End If

    End Sub

    Private Sub TxtRemuneracao_GotFocus(sender As Object, e As EventArgs) Handles TxtRemuneracao.GotFocus

        If TxtRemuneracao.Text = "" Then
            TxtRemuneracao.Text = "0,00"
        End If

        TxtRemuneracao.Text = FormatNumber(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)

        TxtRemuneracao.SelectAll()

    End Sub

    Private Sub TxtRemuneracao_LostFocus(sender As Object, e As EventArgs) Handles TxtRemuneracao.LostFocus

        If TxtRemuneracao.Enabled = True Then
            If TxtRemuneracao.Text = "" Then
                TxtRemuneracao.Text = "0,00"
            End If

            TxtRemuneracao.Text = FormatCurrency(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Public IdColaboradorCliente As Integer = 0

    Private Sub CmbFuncao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFuncao.SelectedIndexChanged

        If CmbFuncao.Items.Contains(CmbFuncao.Text) Then

            TxttAdmissao.Enabled = True

            CkVinculo.Enabled = True

            If IdColaboradorCliente > 0 Then
                CkDsligamento.Enabled = True
            End If

            TxtNumeroMatricula.Enabled = True
            TxtNumeroMatricula.Text = ""

        Else

            TxttAdmissao.Enabled = False

            CkVinculo.Enabled = False

            TxtNumeroMatricula.Enabled = False
            TxtNumeroMatricula.Text = ""

        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TxtTelefone_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefone.MaskInputRejected

    End Sub

    Private Sub TxtTelefone_TextAlignChanged(sender As Object, e As EventArgs) Handles TxtTelefone.TextAlignChanged

    End Sub

    Dim Remun As Decimal = 0
    Dim Leitura As Boolean = False

    Private Sub FrmNovoColaboradorCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim LqTrabalhista As New LqTrabalhistaDataContext
        LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

        'busca funções

        Dim BuscaFuncao = From func In LqTrabalhista.FuncoesClientes
                          Where func.IdCliente = IdCliente
                          Select func.IdFuncaoCliente, func.Descricao

        For Each it In BuscaFuncao.ToList

            LstIdFuncao.Items.Add(it.IdFuncaoCliente)
            CmbFuncao.Items.Add(it.Descricao)

        Next

        'verifica se habilita funcao
        If NomeFuncao <> "" Then
            CmbFuncao.SelectedItem = NomeFuncao
        End If

        Remun = FormatNumber(TxtRemuneracao.Text, NumDigitsAfterDecimal:=2)

        'busca categoria SST e-social

        Dim BuscaCategoriasEsocial = From es In LqTrabalhista.CategoriasTrabalhadores
                                     Where es.Status = True
                                     Select es.Grupo

        For Each it In BuscaCategoriasEsocial.ToList

            If Not CmbGrupo.Items.Contains(it) Then

                CmbGrupo.Items.Add(it)

            End If

        Next

        If IdColaboradorCliente > 0 Then

            Dim BuscaColaboradorCliente = From cl In LqTrabalhista.ColaboradoresCliente
                                          Where cl.IdColaboradorCliente = IdColaboradorCliente
                                          Select cl.Email, cl.DocColaborador, cl.NomeColaborador, cl.NomeFantasia, cl.IdFuncao, cl.DescricaoFuncao, cl.Cmpl, cl.CEP, cl.Celular, cl.CatTrab, cl.DataAdmissao, cl.DataDesligamento, cl.GrupoTrab, cl.Num, cl.NumDocCatTrab, cl.Personalidade, cl.Remuneracao, cl.RG_IE, cl.Telefone, cl.TipoDocCatTrab

            TxtNomeCompleto.Text = BuscaColaboradorCliente.First.NomeColaborador
            TxtApelido.Text = BuscaColaboradorCliente.First.NomeFantasia
            If BuscaColaboradorCliente.First.Personalidade = False Then
                RdbJuridica.Checked = True
                TxtCPF.Text = BuscaColaboradorCliente.First.DocColaborador
            Else
                RdbFisica.Checked = True
                TxtCPF.Text = BuscaColaboradorCliente.First.DocColaborador
            End If
            If BuscaColaboradorCliente.First.RG_IE = "Isento" Then
                Ckisento.Checked = True
            End If
            Leitura = True
            TxtCPF.Enabled = False

            TxtIE.Text = BuscaColaboradorCliente.First.RG_IE
            TxtCep.Text = BuscaColaboradorCliente.First.CEP
            TxtIE.Enabled = False

            TxtNumero.Text = BuscaColaboradorCliente.First.Num
            TxtComplemento.Text = BuscaColaboradorCliente.First.Cmpl

            '

            TxtTelefone.Text = BuscaColaboradorCliente.First.Telefone
            TxtCelular.Text = BuscaColaboradorCliente.First.Celular
            TxtEmail.Text = BuscaColaboradorCliente.First.Email

            '

            TxtRemuneracao.Text = FormatCurrency(BuscaColaboradorCliente.First.Remuneracao, NumDigitsAfterDecimal:=2)
            CmbFuncao.SelectedItem = BuscaColaboradorCliente.First.DescricaoFuncao
            TxttAdmissao.Value = BuscaColaboradorCliente.First.DataAdmissao

            Dim DtTermino As Date = "1111-11-11"
            If BuscaColaboradorCliente.First.DataDesligamento <> DtTermino Then
                CkDsligamento.Checked = True
                TxtDemissao.Value = BuscaColaboradorCliente.First.DataDesligamento
            End If

            '

            If BuscaColaboradorCliente.First.GrupoTrab <> "" Then
                CkVinculo.Checked = True
                CmbGrupo.SelectedItem = BuscaColaboradorCliente.First.GrupoTrab
                CmbCategoriaTrabalhador.SelectedItem = BuscaColaboradorCliente.First.CatTrab

                If BuscaColaboradorCliente.First.TipoDocCatTrab = 1 Then
                    RdbNIT.Checked = True
                ElseIf BuscaColaboradorCliente.First.TipoDocCatTrab = 2 Then
                    RdbPIS.Checked = True
                ElseIf BuscaColaboradorCliente.First.TipoDocCatTrab = 3 Then
                    RdbPASEP.Checked = True
                End If

                TxtNDocEsocial.Text = BuscaColaboradorCliente.First.NumDocCatTrab

            Else
                TxtNumeroMatricula.Text = BuscaColaboradorCliente.First.CatTrab
            End If

        Else

            Leitura = True

        End If

            TxtNomeCompleto.Focus()

    End Sub

    Private Sub TxtCPF_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCPF.MaskInputRejected

    End Sub

    Private Sub TxtCPF_MouseWheel(sender As Object, e As MouseEventArgs) Handles TxtCPF.MouseWheel

    End Sub

    Private Sub TxtTelefone_Click(sender As Object, e As EventArgs) Handles TxtTelefone.Click

        If TxtTelefone.Text.Length < 11 Then
            TxtTelefone.SelectionStart = TxtTelefone.Text.Length

        ElseIf TxtTelefone.Text.Length = 11 Then
            TxtTelefone.SelectionStart = 16

        ElseIf TxtTelefone.Text.Length = 12 Then
            TxtTelefone.SelectionStart = 17

        ElseIf TxtTelefone.Text.Length = 13 Then
            TxtTelefone.SelectionStart = 18

        End If

    End Sub

    Private Sub TxtCelular_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtCelular.MaskInputRejected

    End Sub

    Private Sub TxtCelular_Click(sender As Object, e As EventArgs) Handles TxtCelular.Click

        TxtCelular.SelectionStart = TxtCelular.Text.Length

    End Sub

    Private Sub TxtTelefone_Resize(sender As Object, e As EventArgs) Handles TxtTelefone.Resize

    End Sub

    Private Sub TxtRemuneracao_Click(sender As Object, e As EventArgs) Handles TxtRemuneracao.Click

        TxtRemuneracao.SelectAll()

    End Sub

    Private Sub BttAddProduto_Click(sender As Object, e As EventArgs) Handles BttAddProduto.Click

        Me.Cursor = Cursors.WaitCursor

        FrmNovaFuncaoCliente.IdCliente = IdCliente
        FrmNovaFuncaoCliente.Show(Me)

        Me.Cursor = Cursors.Arrow

    End Sub

    Private Sub CkDsligamento_CheckedChanged(sender As Object, e As EventArgs) Handles CkDsligamento.CheckedChanged

        If CkDsligamento.Checked = True Then
            TxtDemissao.Enabled = True
        Else
            TxtDemissao.Enabled = False
        End If

    End Sub

    Private Sub CmbGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbGrupo.SelectedIndexChanged

        If CmbGrupo.Text = "" Then
            CmbCategoriaTrabalhador.Enabled = False
            CmbCategoriaTrabalhador.Text = ""
        End If

        If CmbGrupo.Items.Contains(CmbGrupo.Text) Then

            CmbCategoriaTrabalhador.Items.Clear()

            Dim LqTrabalhista As New LqTrabalhistaDataContext
            LqTrabalhista.Connection.ConnectionString = FrmPrincipal.ConnectionStringTrabalhista

            Dim BuscaCategoriasEsocial = From es In LqTrabalhista.CategoriasTrabalhadores
                                         Where es.Status = True And es.Grupo Like CmbGrupo.Text
                                         Select es.Codigo, es.Descricao

            For Each it In BuscaCategoriasEsocial.ToList

                If Not CmbCategoriaTrabalhador.Items.Contains(it.Codigo & "-" & it.Descricao) Then

                    CmbCategoriaTrabalhador.Items.Add(it.Codigo & "-" & it.Descricao)

                End If

            Next

            If CmbCategoriaTrabalhador.Items.Count > 0 Then

                CmbCategoriaTrabalhador.Enabled = True

            End If

        End If
    End Sub

    Private Sub CkVinculo_CheckedChanged(sender As Object, e As EventArgs) Handles CkVinculo.CheckedChanged

        If CkVinculo.Checked = True Then

            CmbGrupo.Enabled = True
            TxtNumeroMatricula.Enabled = False
            TxtNumeroMatricula.Text = ""

        Else

            CmbGrupo.Enabled = False
            CmbGrupo.Text = ""
            If CkVinculo.Enabled = True Then
                TxtNumeroMatricula.Enabled = True
            End If

        End If

    End Sub

    Private Sub CmbGrupo_TextChanged(sender As Object, e As EventArgs) Handles CmbGrupo.TextChanged

        If CmbGrupo.Text = "" Then
            CmbCategoriaTrabalhador.Enabled = False
            CmbCategoriaTrabalhador.Text = ""
        End If

    End Sub

    Private Sub TxtNumeroMatricula_TextChanged(sender As Object, e As EventArgs) Handles TxtNumeroMatricula.TextChanged

        If TxtNumeroMatricula.Text <> "" Then

            BtnSalvar.Enabled = True

        Else

            BtnSalvar.Enabled = False

        End If

    End Sub

    Private Sub CmbCategoriaTrabalhador_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCategoriaTrabalhador.SelectedIndexChanged

        If CmbCategoriaTrabalhador.Items.Contains(CmbCategoriaTrabalhador.Text) Then

            RdbNIT.Enabled = True
            RdbPASEP.Enabled = True
            RdbPIS.Enabled = True

        Else

            RdbNIT.Enabled = False
            RdbPASEP.Enabled = False
            RdbPIS.Enabled = False

            RdbNIT.Checked = False
            RdbPASEP.Checked = False
            RdbPIS.Checked = False

            TxtNDocEsocial.Enabled = False
            TxtNDocEsocial.Text = ""

        End If

    End Sub

    Private Sub TxtNDocEsocial_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtNDocEsocial.MaskInputRejected

    End Sub

    Private Sub TxtNDocEsocial_TextChanged(sender As Object, e As EventArgs) Handles TxtNDocEsocial.TextChanged

        If TxtNDocEsocial.Text.Length = TxtNDocEsocial.Mask.Replace(",", "").Replace("/", "").Replace("-", "").Length Then
            BtnSalvar.Enabled = True
        Else
            BtnSalvar.Enabled = True
        End If

    End Sub
End Class