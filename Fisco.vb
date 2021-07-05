Imports System.IO
Imports System.Net
Imports System.Text
Imports Newtonsoft.Json

Public Class Fisco
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Cursor = Cursors.WaitCursor

        FrmPrincipal.CarregaDashboard()

        Me.Close()

    End Sub

    Dim Ambiente As Boolean = False

    Dim LstCFOPSel As New ListBox

    Private Sub Fisco_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblCnpj.Text = FrmPrincipal.CNPJ

        Dim _CNPJ As String = FrmPrincipal.CNPJ.Replace(".", "").Replace("-", "").Replace("/", "")

        If Ambiente = False Then

            _CNPJ = "06990590000123"

        End If

        'consulta no sintegra

        Dim baseUrlDadosST As String = "https://www.sintegraws.com.br/api/v1/execute-api.php?token=BD8E5225-DB81-499F-8A7E-8C25986082B4" & "&cnpj=" & _CNPJ & "&plugin=ST"

        Dim syncClientDadosST = New WebClient()
        Dim contentDadosST = syncClientDadosST.DownloadString(baseUrlDadosST)

        Dim result_byte As Byte() = Encoding.Default.GetBytes(contentDadosST)
        Dim TextURLDevolvida As String = Encoding.UTF8.GetString(result_byte)

        Dim readImagemUsuario = (JsonConvert.DeserializeObject(Of List(Of ClsSintegraWS.Root))("[" & TextURLDevolvida & "]"))

        LblRazao.Text = readImagemUsuario.Item(0).Nome_empresarial

        LblIE.Text = readImagemUsuario.Item(0).Inscricao_estadual

        LblNomeFantasia.Text = readImagemUsuario.Item(0).Nome_fantasia

        LblCNAE.Text = readImagemUsuario.Item(0).Cnae_principal.Code & " - " & readImagemUsuario.Item(0).Cnae_principal.Text

        'procura detalhes cadastrais

        Dim baseUrlDadosRF As String = "https://www.sintegraws.com.br/api/v1/execute-api.php?token=BD8E5225-DB81-499F-8A7E-8C25986082B4" & "&cnpj=" & _CNPJ & "&plugin=RF"

        Dim syncClientDadosRF = New WebClient()
        Dim contentDadosRF = syncClientDadosRF.DownloadString(baseUrlDadosRF)

        Dim result_byteDadosRF As Byte() = Encoding.Default.GetBytes(contentDadosRF)
        Dim TextURLDevolvidaDadosRF As String = Encoding.UTF8.GetString(result_byteDadosRF)

        Dim readDadosRF = (JsonConvert.DeserializeObject(Of List(Of ClsSintegraRF.Root))("[" & TextURLDevolvidaDadosRF & "]"))

        Dim C As Integer = 0

        LstSecundárias.Items.Clear()

        For i As Integer = 0 To readDadosRF.Item(0).atividades_secundarias.Count - 1

            LstSecundárias.Items.Add(readDadosRF.Item(0).atividades_secundarias.Item(i).code & " - " & readDadosRF.Item(0).atividades_secundarias.Item(i).text)

        Next

        LstSocios.Items.Clear()

        For i As Integer = 0 To readDadosRF.Item(0).qsa.Count - 1

            Dim Nome As String = readDadosRF.Item(0).qsa.Item(i).nome_rep_legal

            If Nome = " " Then

                Nome = readDadosRF.Item(0).qsa.Item(i).nome

            End If

            LstSocios.Items.Add(readDadosRF.Item(0).qsa.Item(i).qual & " - " & Nome)

        Next

        LstFiliais.Items.Clear()

        For i As Integer = 0 To readDadosRF.Item(0).cnpjs_do_grupo.Count - 1

            LstFiliais.Items.Add(readDadosRF.Item(0).cnpjs_do_grupo.Item(i).cnpj & " - " & readDadosRF.Item(0).cnpjs_do_grupo.Item(i).tipo & "(" & readDadosRF.Item(0).cnpjs_do_grupo.Item(i).uf & ")")

        Next

        Dim LstRegimes As New ListBox

        LstRegimes.Items.Add("1 - Simples Nacional")
        LstRegimes.Items.Add("2 - Simples Nacional - excesso de sublimite da receita bruta")
        LstRegimes.Items.Add("3 - Normal - regime periódico de apuração")

        Dim Regime As String

        If readImagemUsuario.Item(0).Regime_tributacao.StartsWith("Normal") Then

            Regime = LstRegimes.Items(2).ToString

            LblSimples.Text = "Não"

        ElseIf readImagemUsuario.Item(0).Regime_tributacao.StartsWith("Simples Nacional") Then

            LblSimples.Text = "Sim"

            'consulta dados do simples

        ElseIf readImagemUsuario.Item(0).Regime_tributacao.StartsWith("Simples Nacional - excesso") Then

            LblSimples.Text = "Sim"

            'consulta dados do simples

        End If

        LblRegime.Text = Regime

        LblCapitalSocial.Text = FormatCurrency(readDadosRF.Item(0).capital_social.Replace(".", ""), NumDigitsAfterDecimal:=2)

        LblMunicipio.Text = readImagemUsuario.Item(0).Ibge.Codigo_municipio & " - " & readImagemUsuario.Item(0).Municipio

        LblUf.Text = readImagemUsuario.Item(0).Ibge.Codigo_uf & " - " & readImagemUsuario.Item(0).Uf

        Dim _Endereco As String = ""

        'busca dados do 
        Dim ds As New DataSet()
        Dim xml As String = "http://cep.republicavirtual.com.br/web_cep.php?cep=@cep&formato=xml".Replace("@cep", readImagemUsuario.Item(0).Cep)
        ds.ReadXml(xml)

        Dim Complemento As String

        If readImagemUsuario.Item(0).Complemento <> "" Then
            Complemento = " (" & readImagemUsuario.Item(0).Complemento & ")"
        End If

        _Endereco &= " " & ds.Tables(0).Rows(0)("tipo_logradouro").ToString() & " " & ds.Tables(0).Rows(0)("logradouro").ToString() & ", " & readImagemUsuario.Item(0).Numero & Complemento
        _Endereco &= ", " & ds.Tables(0).Rows(0)("bairro").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("cidade").ToString()
        _Endereco &= ", " & ds.Tables(0).Rows(0)("uf").ToString()

        LblEndereco.Text = _Endereco

        'procura ICMS pelo estado

        'carrega imagem do ususario

        Dim baseUrlICMS As String = "http://www.iarasoftware.com.br/consulta_icms_uf.php?CodUf=" & LblUf.Text.ToCharArray(0, 2)

        'carrega informações no site

        ' Chamada sincrona
        Dim syncClientICMS = New WebClient()
        Dim contentICMS = syncClientICMS.DownloadString(baseUrlICMS)

        Dim readICMS = JsonConvert.DeserializeObject(Of List(Of Classe_Veiculos_Oficina.Trib))(contentICMS)

        TxtICMS.Text = readICMS.Item(0).ICMS

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        Dim BuscaCFOP = From cfop In LqFinanceiro.CFOP_PDR
                        Where cfop.IdTrib Like "*"
                        Select cfop.ICMS, cfop.IPI, cfop.Padrao, cfop.CFOP, cfop.Tipo, cfop.IdTrib

        DtCotFinal.Rows.Clear()
        LstCFOPSel.Items.Clear()

        For Each row In BuscaCFOP.ToList

            Dim Result As String

            If row.Padrao = True Then
                Result = "Sim"
            End If

            DtCotFinal.Rows.Add(Result, row.Tipo, row.CFOP, row.ICMS, row.IPI, ImageList1.Images(1), row.IdTrib)

            LstCFOPSel.Items.Add(row.CFOP)

        Next

    End Sub

    Dim LstCFOP As New ListBox

    Private Sub CmbTipoOperacao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoOperacao.SelectedIndexChanged

        If CmbTipoOperacao.Items.Contains(CmbTipoOperacao.Text) Then

            'verifica os tipos de tranzação necessária

            If CmbTipoOperacao.Text = "Vendas" Then

                'busca CFOP

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                Dim BuscaSaidasCFOP = From _CF In LqFinanceiro.CFOP
                                      Where _CF.idCFOP > 4999 And _CF.idCFOP < 5200
                                      Select _CF.descricao, _CF.Aplicacao, _CF.idCFOP

                CmbCFOP.Items.Clear()
                LstCFOP.Items.Clear()

                For Each row In BuscaSaidasCFOP.ToList
                    If Not LstCFOPSel.Items.Contains(row.idCFOP & " - " & row.descricao) Then
                        CmbCFOP.Items.Add(row.idCFOP & " - " & row.descricao)
                        LstCFOP.Items.Add(row.idCFOP)
                    End If
                Next

                CmbCFOP.Enabled = True

            End If

        Else

            CmbCFOP.Text = ""
            CmbCFOP.Items.Clear()

            CmbCFOP.Enabled = False

        End If

    End Sub

    Private Sub CmbCFOP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbCFOP.SelectedIndexChanged

        If CmbCFOP.Items.Contains(CmbCFOP.Text) Then

            TxtICMS.Enabled = True
            TxtIPI.Enabled = True
            CkPadrao.Enabled = True
            BttAddCFOP.Enabled = True

            'busca na minha api qual o valor de ICMS para aquele estado


        Else

            TxtIPI.Enabled = True
            CkPadrao.Enabled = False
            BttAddCFOP.Enabled = False

            TxtIPI.Text = ""
            CkPadrao.Checked = False

        End If

    End Sub

    Private Sub BttAddCFOP_Click(sender As Object, e As EventArgs) Handles BttAddCFOP.Click

        'adiciona no grid

        Dim ResulCheck As String

        If CkPadrao.Checked = True Then
            ResulCheck = "Sim"
        Else
            ResulCheck = ""
        End If

        DtCotFinal.Rows.Add(ResulCheck, CmbTipoOperacao.SelectedItem, CmbCFOP.SelectedItem, TxtICMS.Text, TxtIPI.Text, ImageList1.Images(1))

        'adiciona CFOPs

        Dim LqFinanceiro As New LqFinanceiroDataContext
        LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

        LqFinanceiro.InsereNovaCFOP_PDR(CmbCFOP.SelectedItem, CmbTipoOperacao.SelectedItem, TxtICMS.Text, TxtIPI.Text, CkPadrao.CheckState)

        DtCotFinal.Rows(DtCotFinal.Rows.Count - 1).Cells(6).Value = LqFinanceiro.CFOP_PDR.ToList.Last.IdTrib

        'limpa campos

        CmbTipoOperacao.Items.Clear()
        CmbTipoOperacao.Text = ""

        CmbCFOP.Items.Clear()
        CmbCFOP.Text = ""
        CkPadrao.Checked = False

        TxtIPI.Text = 0

        CmbCFOP.Enabled = False
        TxtIPI.Enabled = False
        CkPadrao.Enabled = False

        BttAddCFOP.Enabled = False


    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub DtCotFinal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtCotFinal.CellContentClick

        If DtCotFinal.Columns(e.ColumnIndex).Name = "ClmDeletar" Then

            If MsgBox("Deseja realmente remover este item da lista?", vbExclamation + MsgBoxStyle.YesNo) = DialogResult.Yes Then

                Dim LqFinanceiro As New LqFinanceiroDataContext
                LqFinanceiro.Connection.ConnectionString = FrmPrincipal.ConnectionStringFinanceiro

                'remove item

                LqFinanceiro.DeleteCFOP_PDR(DtCotFinal.Rows(e.RowIndex).Cells(6).Value)

                'busca novos dados

                Dim BuscaCFOP = From cfop In LqFinanceiro.CFOP_PDR
                                Where cfop.IdTrib Like "*"
                                Select cfop.ICMS, cfop.IPI, cfop.Padrao, cfop.CFOP, cfop.Tipo, cfop.IdTrib

                DtCotFinal.Rows.Clear()
                LstCFOPSel.Items.Clear()

                For Each row In BuscaCFOP.ToList

                    Dim Result As String

                    If row.Padrao = True Then
                        Result = "Sim"
                    End If

                    DtCotFinal.Rows.Add(Result, row.Tipo, row.CFOP, row.ICMS, row.IPI, ImageList1.Images(1), row.IdTrib)

                    LstCFOPSel.Items.Add(row.CFOP)

                Next

            End If

        End If

    End Sub
End Class