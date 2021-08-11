Imports System.DirectoryServices
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Runtime.Serialization.Json
Imports System.ServiceProcess
Imports System.Text
Imports Microsoft.SqlServer.Management.Smo.Wmi
Imports MySql.Data.MySqlClient
Imports Newtonsoft.Json

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Pnn1.Visible = True
        Pnn1.Dock = DockStyle.Fill

        Pnn2.Visible = False

        'carrega versao atual do programa

        LblVersao.Text = "Versão. " & My.Application.Info.Version.ToString

        BtnAvançar.Focus()

    End Sub

    Dim Stagio As Integer = -1


    Private Sub StartStop()

        'MsgBox(System.Net.Dns.GetHostName())

        If MsgBox("Vou interromper o serviço de banco de dados por alguns instantes para executar as novas operções.", vbOKOnly + MsgBoxStyle.Information) Then

            Try

                Dim server As System.ServiceProcess.ServiceController
                'server.MachineName = My.Computer.Name

                Dim service As ServiceController
                'service.MachineName = My.Computer.Name
                'service.ServiceName = "MSSQLSERVER"

                'service = New ServiceController().

                'service.Stop()
                'MsgBox("Start")
                Timer2.Enabled = True

                'End If



                'ServiceController1.MachineName = TxtIp.Text

                'ServiceController1.Stop()

                'ServiceController1.Start()

            Catch ex As Exception

                MsgBox(ex.Message)

            End Try

        End If

    End Sub
    Private Sub BtnAvançar_Click(sender As Object, e As EventArgs) Handles BtnAvançar.Click

        RdbBdd.Enabled = True
        RdbLigarIara.Enabled = True

        BtnAvançar.Enabled = False
        BttVoltar.Enabled = False

        If Pnn1.Visible = True Then

            Pnn2.Visible = True
            Pnn2.Dock = DockStyle.Fill

            Pnn1.Visible = False
            BtnAvançar.Enabled = False
            BttVoltar.Enabled = True

            If IO.Directory.Exists("C:\Iara\Ini") Then

                'verifica arquivo

                If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                    'cria arquivo de inicialização

                    Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                    If File.Exists(Arquivo) Then

                        RdbBdd.Checked = True

                        ' Cria um arquivo para escrita
                        ' Abre o arquivo para leitura
                        Dim Texto As String
                        Using sr As StreamReader = File.OpenText(Arquivo)
                            Texto = sr.ReadToEnd
                        End Using

                        Dim str As String = Texto
                        Dim separador As String = Chr(13)
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        Dim _IP As String = ""
                        Dim _PortaSql As String = ""
                        Dim _INstancia As String = ""

                        For Each palavra In palavras

                            Dim str0 As String = palavra
                            Dim separador0 As String = ":"
                            Dim palavras0 As String() = str0.Split(separador0)
                            Dim LstPalavras0 As New ListBox
                            Dim palavra0 As String

                            Dim Conta As Boolean = False

                            For Each palavra0 In palavras0

                                If Conta = False Then
                                    Conta = True
                                Else
                                    If _IP = "" And _PortaSql = "" And _INstancia = "" Then

                                        _IP = (palavra0)

                                    ElseIf _PortaSql = "" And _IP <> "" And _INstancia = "" Then

                                        _PortaSql = (palavra0)

                                        If palavra0 = "" Then

                                            _PortaSql = 0

                                        End If

                                    ElseIf _INstancia = "" And _PortaSql <> "" And _IP <> "" Then

                                        _INstancia = (palavra0)

                                    End If

                                    If _IP.EndsWith("U") Then

                                        '_IP = _IP.Remove(_IP.Length - 1, 1)

                                        CkEsteComputador.Checked = True
                                        BuscaIP()

                                    Else

                                        TxtIp.Text = _IP

                                    End If

                                    TxtPortaSQL.Text = _PortaSql
                                    TxtNomeInstancia.Text = _INstancia

                                End If

                            Next

                        Next

                        BtnAvançar.Enabled = True

                    End If

                End If

            End If

            Stagio = 0

        ElseIf Pnn2.Visible = True Then

            If Stagio = 0 Then

                PnnServidor.Visible = False
                PnnDataBases.Visible = True

                PnnDataBases.Dock = DockStyle.Fill

                DtDataBases.Rows.Clear()

                If RdbBdd.Checked = True Then

                    'varre todas as pastas

                    For Each path In IO.Directory.GetDirectories("C:\Iara\Uteis\BDD").ToList

                        For Each itens In IO.Directory.GetFiles(path.ToString)

                            DtDataBases.Rows.Add(ImageList1.Images(3), itens.ToString, "Aguardando rotina")

                        Next

                    Next

                End If

                BtnAvançar.Enabled = True
                BttVoltar.Enabled = True

                Stagio = 1

                BtnAvançar.PerformClick()

            ElseIf Stagio = 1 Then

                'StartStop()

                'cria tabelas

                Dim Err As Integer = 0

                For Each row As DataGridViewRow In DtDataBases.Rows

                    row.Cells(0).Value = ImageList1.Images(2)
                    DtDataBases.Refresh()

                    Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

                    'Try

                    Dim ConecctionServer As String

                    Dim Instancia As String = ""

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim Porta As String = ""
                    If TxtPortaSQL.Text <> "" Or TxtPortaSQL.Text = 0 Then

                        Porta = "," & TxtPortaSQL.Text

                    End If

                    ConecctionServer = "Data Source=" & TxtIp.Text & Instancia & Porta & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    'carrega 

                    Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                        Dim ConnState As Boolean = False

                        'MsgBox(ConnState & " " & ConecctionServer)

                        Try

                            Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                            Conexão.Open()

                            SQLCommand1.ExecuteNonQuery()

                            row.Cells(0).Value = ImageList1.Images(0)
                            row.Cells(2).Value = "Sucesso"

                            Conexão.Close()

                            'row.Visible = False

                        Catch ex As Exception

                            row.Cells(0).Value = ImageList1.Images(1)
                            row.Cells(2).Value = ex.Message

                            Err += 1
                            Conexão.Close()

                        End Try

                        'adiciona pra ver se onsegue inserir


                    End Using

                    row.Selected = True

                    DtDataBases.Refresh()

                    DtDataBases.CurrentCell = DtDataBases(0, row.Index)

                Next

                'le a pasta bdd do sql

                If Err = 0 Then

                    DtItensBDD.Rows.Clear()

                    If RdbBdd.Checked = True Then

                        'carrega os arquivos 
                        Dim Direct As String = "C:\Iara\Uteis\BDD"

                        For Each path In IO.Directory.GetDirectories(Direct).ToList

                            For Each itens In IO.Directory.GetDirectories(path.ToString)

                                If Not itens.ToString.EndsWith("Dsc") And Not itens.ToString.EndsWith("Insert") And Not itens.ToString.EndsWith("Inserts") Then
                                    For Each itens_sub In IO.Directory.GetFiles(itens.ToString)

                                        Dim Base As String = path.ToString.Remove(0, Direct.ToString.Length).Remove(0, 5)
                                        DtItensBDD.Rows.Add(ImageList1.Images(3), itens_sub.ToString, Base, "Aguardando rotina")

                                    Next
                                End If

                            Next

                        Next

                    End If

                    PnnDataBases.Visible = False
                    PnnTabelas.Visible = True
                    PnnTabelas.Dock = DockStyle.Fill
                    BtnAvançar.Enabled = True
                    BttVoltar.Enabled = True

                    Stagio = 2

                    'BtnAvançar.PerformClick()

                Else

                    'varre e torna invisivel os que não rodaram

                    For Each row As DataGridViewRow In DtItensBDD.Rows

                        If row.Cells(3).Value = "Sucesso" Then
                            row.Visible = False
                        End If

                    Next

                    BttRodarNovamente.Visible = True
                    BttVoltar.Enabled = True

                End If


            ElseIf Stagio = 2 Then

                Dim Err As Integer = 0

                For Each row As DataGridViewRow In DtItensBDD.Rows

                    row.Cells(0).Value = ImageList1.Images(2)
                    DtItensBDD.Refresh()

                    Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

                    'Try

                    Dim ConecctionServer As String

                    Dim Instancia As String = ""

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim Porta As String = ""
                    If TxtPortaSQL.Text <> "" Then

                        Porta = "," & TxtPortaSQL.Text

                    End If

                    ConecctionServer = "Data Source=" & TxtIp.Text & Instancia & Porta & ";Initial Catalog=" & row.Cells(2).Value.ToString & ";Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                        'adiciona pra ver se onsegue inserir

                        Try

                            Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                            Conexão.Open()

                            SQLCommand1.ExecuteNonQuery()

                            row.Cells(0).Value = ImageList1.Images(0)
                            row.Cells(3).Value = "Sucesso"

                            Conexão.Close()

                        Catch ex As Exception

                            row.Cells(0).Value = ImageList1.Images(1)
                            row.Cells(3).Value = ex.Message.ToString

                            Err += 1
                        End Try

                    End Using

                    row.Selected = True

                    DtItensBDD.Refresh()

                    DtItensBDD.CurrentCell = DtItensBDD(0, row.Index)

                Next

                Stagio = 3

                If Err = 0 Then

                    'popula cnpj e busca chave

                    Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                    If File.Exists(Arquivo) Then
                        ' Cria um arquivo para escrita
                        ' Abre o arquivo para leitura
                        Dim Texto As String
                        Using sr As StreamReader = File.OpenText(Arquivo)
                            Texto = sr.ReadToEnd
                        End Using

                        Dim str As String = Texto
                        Dim separador As String = Chr(13)
                        Dim palavras As String() = str.Split(separador)
                        Dim LstPalavras As New ListBox
                        Dim palavra As String

                        Dim _IP As String = ""
                        Dim _Instancia As String = ""
                        Dim _PortaSql As String = ""
                        For Each palavra In palavras

                            Dim str0 As String = palavra
                            Dim separador0 As String = ":"
                            Dim palavras0 As String() = str0.Split(separador0)
                            Dim LstPalavras0 As New ListBox
                            Dim palavra0 As String

                            Dim Conta As Boolean = False

                            For Each palavra0 In palavras0

                                If Conta = False Then
                                    Conta = True
                                Else
                                    If _IP = "" And _PortaSql = "" And _Instancia = "" Then

                                        _IP = (palavra0)

                                    ElseIf _PortaSql = "" And _IP <> "" And _Instancia = "" Then

                                        _PortaSql = (palavra0)

                                    ElseIf _Instancia = "" And _PortaSql <> "" And _IP <> "" Then

                                        _Instancia = (palavra0)

                                    End If

                                    _IP = _IP.Replace("U", "")

                                    'public

                                    Dim Instancia As String = ""

                                    If _Instancia <> "" Then

                                        Instancia = "\" & _Instancia

                                    End If

                                    If _Instancia <> "" And _PortaSql <> "" And _IP <> "" Then

                                        TxtCNPJ.Text = (palavra0)

                                    End If

                                End If

                            Next

                        Next

                    End If

                    'If TxtCNPJ.Text <> "" Then

                    'End If

                    PnnLicensas.Visible = True
                    PnnLicensas.Dock = DockStyle.Fill

                    PnnTabelas.Visible = False

                    BtnAvançar.Visible = False
                    BtnConcluir.Visible = True
                    BtnConcluir.Enabled = True
                    BttVoltar.Enabled = False

                    BttBuscarLicensas.PerformClick()

                    BtnAvançar.PerformClick()

                Else

                    BtnAvançar.Enabled = False

                    BttVoltar.Enabled = True

                    BttRodarTabelaAgain.Visible = True

                End If

            ElseIf Stagio = 3 Then

                PnnLicensas.Visible = True
                PnnLicensas.Dock = DockStyle.Fill

                PnnTabelas.Visible = False

                BttBuscarLicensas.PerformClick()

                Dim Err As Integer = 0

                If Err = 0 Then

                    BtnAvançar.Visible = False
                    BtnConcluir.Visible = True

                    BttVoltar.Enabled = True

                    TxtCNPJ.Focus()

                Else

                    BtnAvançar.Visible = False
                    BtnConcluir.Visible = True

                    BttVoltar.Enabled = True

                    For Each row As DataGridViewRow In DtItensBDD.Rows

                        If row.Cells(3).Value = "Sucesso" Then
                            row.Visible = False
                        End If

                    Next

                    BttRodarNovamente.Visible = True

                    BttRodarTabelaAgain.Visible = True

                End If

            End If

        End If


    End Sub

    Private Sub BttRemover_Click(sender As Object, e As EventArgs) Handles BttRemover.Click

        Me.Close()

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RdbBdd.CheckedChanged

        If RdbBdd.Checked = True Then
            PnnServidor.Visible = True
            PnnServidor.Dock = DockStyle.Fill

            PnnDataBases.Visible = False
            PnnTabelas.Visible = False

            BtnConcluir.Visible = False
            BtnAvançar.Visible = True

            Stagio = 0

            TxtIp.Text = ""

        ElseIf RdbLigarIara.Checked = True Then

            PnnServidor.Visible = True
            PnnServidor.Dock = DockStyle.Fill

            PnnDataBases.Visible = False
            PnnTabelas.Visible = False

            BtnConcluir.Visible = False
            BtnAvançar.Visible = True

            Stagio = 0

            TxtIp.Text = ""

        End If

    End Sub

    Dim _Etapa As Boolean = False
    Private Sub BttSalvar_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PnnServidor_Paint(sender As Object, e As PaintEventArgs) Handles PnnServidor.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        If Pnn2.Visible = True Then

        End If


    End Sub

    Private Sub TxtIp_TextChanged(sender As Object, e As EventArgs) Handles TxtIp.TextChanged

        If TxtIp.Text = "" Then
            LblRespostas.Text = ""
        End If

    End Sub

    Private Sub BttRodarNovamente_Click(sender As Object, e As EventArgs) Handles BttRodarNovamente.Click

        'recoloca na lista

        For Each row As DataGridViewRow In DtDataBases.Rows

            row.Cells(0).Value = ImageList1.Images(3)
            row.Cells(2).Value = "Aguardando rotina"

        Next

        Dim Err As Integer = 0

        For Each row As DataGridViewRow In DtDataBases.Rows

            row.Cells(0).Value = ImageList1.Images(2)
            DtDataBases.Refresh()

            Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

            'Try

            Dim Instancia As String = ""

            If TxtNomeInstancia.Text <> "" Then

                Instancia = "\" & TxtNomeInstancia.Text

            End If

            Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog=" & row.Cells(2).Value.ToString & ";Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

            Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                'adiciona pra ver se onsegue inserir

                Try

                    Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                    Conexão.Open()

                    SQLCommand1.ExecuteNonQuery()

                    row.Cells(0).Value = ImageList1.Images(0)
                    row.Cells(2).Value = "Sucesso"

                    Conexão.Close()

                Catch ex As Exception

                    row.Cells(0).Value = ImageList1.Images(1)
                    row.Cells(2).Value = ex.Message.ToString

                    Err += 1

                End Try

            End Using

            row.Selected = True

            DtDataBases.Refresh()

            DtDataBases.CurrentCell = DtDataBases(0, row.Index)

        Next

        If Err = 0 Then
            BttRodarNovamente.Visible = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

        Dim Err As Integer = 0

        For Each row As DataGridViewRow In DtItensBDD.Rows

            row.Cells(0).Value = ImageList1.Images(2)
            DtItensBDD.Refresh()

            Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

            'Try

            Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & ";Initial Catalog=" & row.Cells(2).Value.ToString & ";Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

            Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                'adiciona pra ver se onsegue inserir

                Try

                    Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                    Conexão.Open()

                    SQLCommand1.ExecuteNonQuery()

                    row.Cells(0).Value = ImageList1.Images(0)
                    row.Cells(3).Value = "Sucesso"

                    Conexão.Close()

                Catch ex As Exception

                    row.Cells(0).Value = ImageList1.Images(1)
                    row.Cells(3).Value = ex.Message.ToString

                    Err += 1
                End Try

            End Using

            row.Selected = True

            'Catch ex As Exception

            '    row.Cells(0).Value = ImageList1.Images(1)
            '    row.Cells(3).Value = ex.Message.ToString

            'End Try

            DtItensBDD.Refresh()

            DtItensBDD.CurrentCell = DtItensBDD(0, row.Index)

        Next

        If Err = 0 Then

            If MsgBox("Tabelas criadas!") = MsgBoxResult.Ok Then

                BtnAvançar.Text = "Concluir"
                BtnAvançar.Enabled = True

            End If

        Else

            BtnAvançar.Text = "Concluir"
            BtnAvançar.Enabled = True

            BttRodarTabelaAgain.Visible = True

        End If

    End Sub

    Private Sub BttRodarTabelaAgain_Click(sender As Object, e As EventArgs) Handles BttRodarTabelaAgain.Click

        'recoloca na lista

        For Each row As DataGridViewRow In DtItensBDD.Rows

            row.Cells(0).Value = ImageList1.Images(3)
            row.Cells(3).Value = "Agaurdando rotina"

        Next

        Dim Err As Integer = 0

        For Each row As DataGridViewRow In DtItensBDD.Rows

            row.Cells(0).Value = ImageList1.Images(2)
            DtItensBDD.Refresh()

            Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

            'Try

            Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & ", " & TxtPortaSQL.Text & ";Initial Catalog=" & row.Cells(2).Value.ToString & ";Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

            Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                'adiciona pra ver se onsegue inserir

                Try

                    Dim SQLCommand1 As New SqlClient.SqlCommand(SQLString, Conexão)

                    Conexão.Open()

                    SQLCommand1.ExecuteNonQuery()

                    row.Cells(0).Value = ImageList1.Images(0)
                    row.Cells(3).Value = "Sucesso"

                    Conexão.Close()

                Catch ex As Exception

                    row.Cells(0).Value = ImageList1.Images(1)
                    row.Cells(3).Value = ex.Message.ToString

                    Err += 1
                End Try

            End Using

            row.Selected = True

            'Catch ex As Exception

            '    row.Cells(0).Value = ImageList1.Images(1)
            '    row.Cells(3).Value = ex.Message.ToString

            'End Try

            DtItensBDD.Refresh()

            DtItensBDD.CurrentCell = DtItensBDD(0, row.Index)

        Next

    End Sub

    Private Sub BttVoltar_Click(sender As Object, e As EventArgs) Handles BttVoltar.Click

        BtnConcluir.Visible = False
        BtnAvançar.Visible = True

        If Stagio = 0 Then

            Pnn1.Visible = True
            Pnn1.Dock = DockStyle.Fill

            Pnn2.Visible = False
            BtnAvançar.Enabled = True
            BttVoltar.Enabled = False

            Stagio = -1

        ElseIf Stagio = 1 Then

            Pnn2.Visible = True
            Pnn2.Dock = DockStyle.Fill

            PnnServidor.Visible = True
            PnnDataBases.Visible = False

            PnnDataBases.Dock = DockStyle.Fill

            BtnAvançar.Enabled = True
            BttVoltar.Enabled = True

            Stagio = 0

            'BtnAvançar.PerformClick()

        ElseIf Stagio = 2 Then

            'StartStop()

            PnnTabelas.Visible = False
            PnnDataBases.Visible = True

            PnnDataBases.Dock = DockStyle.Fill

            BtnAvançar.Enabled = True
            BttVoltar.Enabled = True

            'cria tabelas

            Stagio = 1

        ElseIf Stagio = 3 Then

            PnnDataBases.Visible = False
            PnnTabelas.Visible = True
            PnnTabelas.Dock = DockStyle.Fill
            BtnAvançar.Enabled = True
            BttVoltar.Enabled = True

            Stagio = 2

        ElseIf Stagio = 4 Then

                PnnLicensas.Visible = True
                PnnLicensas.Dock = DockStyle.Fill

                PnnTabelas.Visible = False

                BttBuscarLicensas.PerformClick()

                Dim Err As Integer = 0

                If Err = 0 Then

                    BtnAvançar.Visible = False
                    BtnConcluir.Visible = True

                    BttVoltar.Enabled = True

                    TxtCNPJ.Focus()

                Else

                    BtnAvançar.Visible = False
                    BtnConcluir.Visible = True

                    BttVoltar.Enabled = True

                    For Each row As DataGridViewRow In DtItensBDD.Rows

                        If row.Cells(3).Value = "Sucesso" Then
                            row.Visible = False
                        End If

                    Next

                    BttRodarNovamente.Visible = True

                    BttRodarTabelaAgain.Visible = True

                End If

            End If

    End Sub

    Public _idChave As Integer = 0
    Public _idCliente As Integer = 0

    Public IPIara As String = "179.113.183.177"

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BtnConcluir.Click

        If IO.Directory.Exists("C:\Iara\Ini") Then

            'verifica arquivo

            If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                'cria arquivo de inicialização

                Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                TxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals

                'verifica se o arquivo existe
                If Not File.Exists(Arquivo) Then
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                        "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)

                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        If _idChave <> 0 Then
                            'solicita licensas

                            Dim ConecctionServer As String = "Data Source=" & IPIara & "\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqIara As New LqIaraDataContext

                            LqIara.Connection.ConnectionString = ConecctionServer

                            Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqBase As New LqBaseDataContext
                            LqBase.Connection.ConnectionString = ConecctionServerBase

                            For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            'busca licensas

                            Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                                   Where lic.IDChaveIARA = _idChave
                                                   Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                            For Each item In BuscaLicensasUso.ToList

                                If item.TipoLicencaIARA = True Then

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                Else

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                End If


                            Next

                        End If

                        FrmAtualizar.Show(Me)

                        'FrmFinalizar.ShowDialog()

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                        "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)


                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If


                        If _idChave <> 0 Then
                            'solicita licensas

                            Dim ConecctionServer As String = "Data Source=" & IPIara & "\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqIara As New LqIaraDataContext

                            LqIara.Connection.ConnectionString = ConecctionServer

                            Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqBase As New LqBaseDataContext
                            LqBase.Connection.ConnectionString = ConecctionServerBase

                            For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            'busca licensas

                            Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                                   Where lic.IDChaveIARA = _idChave
                                                   Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                            For Each item In BuscaLicensasUso.ToList

                                If item.TipoLicencaIARA = True Then

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                Else

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                End If


                            Next
                        End If

                        FrmAtualizar.Show(Me)

                        'FrmFinalizar.ShowDialog()

                    End Using
                    Return
                End If

            Else

                'cria arquivo de inicialização

                Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                'verifica se o arquivo existe
                If Not File.Exists(Arquivo) Then
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                        "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)


                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        If _idChave <> 0 Then
                            'solicita licensas

                            Dim ConecctionServer As String = "Data Source=" & IPIara & "\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqIara As New LqIaraDataContext

                            LqIara.Connection.ConnectionString = ConecctionServer

                            Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqBase As New LqBaseDataContext
                            LqBase.Connection.ConnectionString = ConecctionServerBase

                            For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            'busca licensas

                            Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                                   Where lic.IDChaveIARA = _idChave
                                                   Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                            For Each item In BuscaLicensasUso.ToList

                                If item.TipoLicencaIARA = True Then

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                Else

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                End If

                            Next
                        End If

                        End

                        'FrmFinalizar.ShowDialog()

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                        "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)


                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        If _idChave <> 0 Then
                            'solicita licensas

                            Dim ConecctionServer As String = "Data Source=" & IPIara & "\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqIara As New LqIaraDataContext

                            LqIara.Connection.ConnectionString = ConecctionServer

                            Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Dim LqBase As New LqBaseDataContext
                            LqBase.Connection.ConnectionString = ConecctionServerBase

                            For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Est-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-00"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                                LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                            Next

                            'verifica chhave interna

                            Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                                  Where cha.IdProduto Like "Ofi-01"
                                                  Select cha.IdChave

                            For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                                LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                            Next

                            'busca licensas

                            Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                                   Where lic.IDChaveIARA = _idChave
                                                   Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                            For Each item In BuscaLicensasUso.ToList

                                If item.TipoLicencaIARA = True Then

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                Else

                                    If item.IpInt <> "" Then

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                    Else

                                        FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                    End If

                                End If

                            Next
                        End If

                        End

                        'FrmFinalizar.ShowDialog()

                    End Using
                    Return
                End If

            End If

        Else

            IO.Directory.CreateDirectory("C:\Iara\Ini\")
            'cria string de conexão

            Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

            'verifica se o arquivo existe
            If Not File.Exists(Arquivo) Then
                ' Cria um arquivo para escrita
                Using sw As FileStream = File.Create(Arquivo)
                    Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                    "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)

                    Dim Instancia As String

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)


                    If _idChave <> 0 Then
                        'solicita licensas

                        Dim ConecctionServer As String = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Dim LqIara As New LqIaraDataContext

                        LqIara.Connection.ConnectionString = ConecctionServer

                        Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Dim LqBase As New LqBaseDataContext
                        LqBase.Connection.ConnectionString = ConecctionServerBase

                        For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Est-00"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Est-01"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Ofi-00"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Ofi-01"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        'busca licensas

                        Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                               Where lic.IDChaveIARA = _idChave
                                               Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                        For Each item In BuscaLicensasUso.ToList

                            If item.TipoLicencaIARA = True Then

                                If item.IpInt <> "" Then

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                Else

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                End If

                            Else

                                If item.IpInt <> "" Then

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                Else

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                End If

                            End If

                        Next
                    End If

                    End

                    'FrmFinalizar.ShowDialog()


                End Using
            Else
                File.Delete(Arquivo)
                ' Cria um arquivo para escrita
                Using sw As FileStream = File.Create(Arquivo)
                    Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                    "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text & Chr(13) &
                    "CNPJ:" & TxtCNPJ.Text & Chr(13)

                    Dim Instancia As String

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)

                    If _idChave <> 0 Then
                        'solicita licensas

                        Dim ConecctionServer As String = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Dim LqIara As New LqIaraDataContext

                        LqIara.Connection.ConnectionString = ConecctionServer

                        Dim ConecctionServerBase As String = "Data Source=" & TxtIp.Text & Instancia & "," & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Dim LqBase As New LqBaseDataContext
                        LqBase.Connection.ConnectionString = ConecctionServerBase

                        For i As Integer = QtDskEst To LblQtDeskEstoque.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Estoque")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveEst00 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Est-00"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveEst00.Count To LblQtDeskEstoque.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Est-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtMobEst To LblQtMobEstoque.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Estoque")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveEst01 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Est-01"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveEst01.Count To LblQtMobEstoque.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Est-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtDskOfi To LblQtDeskOficina.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", True, "", "", "", _idCliente, "Oficina")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveOfi00 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Ofi-00"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveOfi00.Count To LblQtDeskOficina.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Ofi-00", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        For i As Integer = QtMobOfi To LblQtMobOficina.Text - 1 Step 1

                            LqIara.InsereNovaLicensaChaveIara(_idChave, "", False, "", "", "", _idCliente, "Oficina")

                        Next

                        'verifica chhave interna

                        Dim BuscaChaveOfi01 = From cha In LqBase.ChavesInterno
                                              Where cha.IdProduto Like "Ofi-01"
                                              Select cha.IdChave

                        For i As Integer = BuscaChaveOfi01.Count To LblQtMobOficina.Text - 1 Step 1

                            LqBase.InsereChavesInterno("Ofi-01", LblChave.Text, LblTelefone.Text, Today.Date, Now.TimeOfDay, "1111-11-11", Today.TimeOfDay, TxtCNPJ.Text, _idCliente, "", "", "")

                        Next

                        'busca licensas

                        Dim BuscaLicensasUso = From lic In LqIara.LicensasIara
                                               Where lic.IDChaveIARA = _idChave
                                               Select lic.DispositivoClienteIARA, lic.Modulo, lic.TipoLicencaIARA, lic.IpInt, lic.Ipext

                        For Each item In BuscaLicensasUso.ToList

                            If item.TipoLicencaIARA = True Then

                                If item.IpInt <> "" Then

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                Else

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.Desktop_Acer_43256, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                End If

                            Else

                                If item.IpInt <> "" Then

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_connected_21031, item.Modulo, item.DispositivoClienteIARA, item.IpInt, item.Ipext)

                                Else

                                    FrmFinalizar.DtResumoContrato.Rows.Add(My.Resources.smartphone_phone_phone_android_xperia_mobile_2513, My.Resources.globe_disconnected_21030, item.Modulo, "Não autenticado", item.IpInt, item.Ipext)

                                End If

                            End If

                        Next
                    End If

                    End

                    'FrmFinalizar.ShowDialog()

                End Using
                Return

            End If

        End If


    End Sub

    Private Sub RdbLigarIara_CheckedChanged(sender As Object, e As EventArgs) Handles RdbLigarIara.CheckedChanged
        If RdbBdd.Checked = True Then
            PnnServidor.Visible = True
            PnnServidor.Dock = DockStyle.Fill

            PnnDataBases.Visible = False
            PnnTabelas.Visible = False

            BtnConcluir.Visible = False
            BtnAvançar.Visible = True

            Stagio = 0

            TxtIp.Text = ""

        ElseIf RdbLigarIara.Checked = True Then

            PnnServidor.Visible = True
            PnnServidor.Dock = DockStyle.Fill

            PnnDataBases.Visible = False
            PnnTabelas.Visible = False

            BtnConcluir.Visible = False
            BtnAvançar.Visible = True

            Stagio = 0

            TxtIp.Text = ""

        End If

    End Sub

    Private Sub CkEsteComputador_CheckedChanged(sender As Object, e As EventArgs) Handles CkEsteComputador.CheckedChanged

        If CkEsteComputador.Checked = True Then
            BuscaIP()
            If TxtIp.Text <> "" Then

                Dim Dot As Integer = 0

                For i As Integer = 0 To TxtIp.Text.Length - 1

                    Dim Campo As String = TxtIp.Text.ToCharArray(i, 1)

                    If Campo = "." Then

                        Dot += 1

                    End If

                Next

                If Dot = 3 Then

                    If My.Computer.Network.Ping(TxtIp.Text) = True Then
                        Dim ElapseTime As New Stopwatch
                        ElapseTime.Start()
                        My.Computer.Network.Ping(TxtIp.Text)
                        ElapseTime.Stop()

                        ' avisa que pingou
                        LblRespostas.Text = "Ping no servidor " & TxtIp.Text & " resposta:" & FormatNumber(ElapseTime.Elapsed.TotalSeconds.ToString(), NumDigitsAfterDecimal:=2) & "ms"
                    Else
                        LblRespostas.Text = "Ping falhou (timeout) : " & Now.TimeOfDay.ToString()
                    End If

                End If

            Else

                BtnAvançar.Enabled = False

            End If

        Else
            TxtIp.Text = ""
            TxtIp.Enabled = True
        End If

    End Sub

    Public Function BuscaIP()
        Dim myHost As String = System.Net.Dns.GetHostName
        Dim myIPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(myHost)

        Dim ip As String
        For Each myIP As System.Net.IPAddress In myIPs.AddressList

            ip = myIP.ToString
        Next
        TxtIp.Text = (ip)
        TxtIp.Enabled = False
        Return ip
    End Function

    Private Sub TxtPortaSQL_TextChanged(sender As Object, e As EventArgs) Handles TxtPortaSQL.TextChanged

        If TxtPortaSQL.Text = "" Then

            LblRespostaPorta.Text = ""

        End If

    End Sub

    Private Sub TxtNomeInstancia_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeInstancia.TextChanged

        If TxtNomeInstancia.Text = "" Then

            LblConexão.Text = ""

        Else

            BtnAvançar.Enabled = True

        End If

    End Sub

    Private Sub LblConexão_Click(sender As Object, e As EventArgs) Handles LblConexão.Click

    End Sub

    Private Sub TxtIp_LostFocus(sender As Object, e As EventArgs) Handles TxtIp.LostFocus

        If TxtIp.Text <> "" Then

            Dim Dot As Integer = 0

            For i As Integer = 0 To TxtIp.Text.Length - 1

                Dim Campo As String = TxtIp.Text.ToCharArray(i, 1)

                If Campo = "." Then

                    Dot += 1

                End If

            Next

            If Dot = 3 Then

                Try

                    If My.Computer.Network.Ping(TxtIp.Text) = True Then
                        Dim ElapseTime As New Stopwatch
                        ElapseTime.Start()
                        My.Computer.Network.Ping(TxtIp.Text)
                        ElapseTime.Stop()

                        ' avisa que pingou
                        LblRespostas.Text = "Ping no servidor " & TxtIp.Text & " resposta:" & FormatNumber(ElapseTime.Elapsed.TotalSeconds.ToString(), NumDigitsAfterDecimal:=2) & "ms"
                    Else
                        LblRespostas.Text = "Ping falhou (timeout) : " & Now.TimeOfDay.ToString()
                    End If

                Catch ex As Exception

                    LblRespostas.Text = "Ping falhou (timeout) : " & Now.TimeOfDay.ToString()

                End Try

            End If

        Else

            LblRespostas.Text = ""

            BtnAvançar.Enabled = False

        End If

    End Sub

    Dim intervaloTempo As Integer = 0
    Dim LbPing As New ListBox

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '' verifica o tempo que passou
        If intervaloTempo = 4 Then
            ' a cada 2 minutos reinicia o contador do tempo
            intervaloTempo = 0
            ' e faz o ping
            If My.Computer.Network.Ping(TxtIp.Text) = True Then
                ' avisa que pingou
                LbPing.Items.Add("Ping no servidor " & TxtIp.Text & " as " & Now.TimeOfDay.ToString())
            Else
                LbPing.Items.Add("Ping falhou (timeout) : " & Now.TimeOfDay.ToString())
            End If

            Timer1.Enabled = False

            MsgBox(LbPing.Items.Count)

        Else
            'se não passou 2 minutos incrementa o contador
            intervaloTempo += 1
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CkPortaPadrão.CheckedChanged

        If CkPortaPadrão.Checked = True Then

            TxtPortaSQL.Enabled = False
            TxtPortaSQL.Text = "1433"

            If IsPortOpen(TxtIp.Text, TxtPortaSQL.Text) = True Then

                LblRespostaPorta.Text = "A porta esta funcionando normalmente"

            Else

                LblRespostaPorta.Text = "A porta não esta funcionando."

            End If


        Else

            TxtPortaSQL.Enabled = True
            TxtPortaSQL.Text = ""

        End If

    End Sub

    Private Function IsPortOpen(ByVal Host As String, ByVal PortNumber As Integer) As Boolean
        Dim Client As TcpClient = Nothing
        Try
            Client = New TcpClient(Host, PortNumber)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not Client Is Nothing Then
                Client.Close()
            End If
        End Try
    End Function

    Private Sub TxtPortaSQL_LostFocus(sender As Object, e As EventArgs) Handles TxtPortaSQL.LostFocus

        If TxtPortaSQL.Text <> "" Then

            If IsPortOpen(TxtIp.Text, TxtPortaSQL.Text) = True Then

                LblRespostaPorta.Text = "A porta esta funcionando normalmente"

            Else

                LblRespostaPorta.Text = "A porta não esta funcionando."

            End If

            If TxtNomeInstancia.Text <> "" Then

                Dim ConecctionServer As String

                LblConexão.Visible = True

                ConecctionServer = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    'adiciona pra ver se onsegue inserir

                    Try

                        Conexão.Open()

                        If Conexão.State = ConnectionState.Open Then

                            LblConexão.Text = "A conexão foi estabelecida com o servidor."

                            BtnAvançar.Enabled = True

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                            BtnAvançar.Enabled = False

                        End If

                        Conexão.Close()

                    Catch ex As Exception

                        LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                    End Try

                End Using


            Else

                LblConexão.Text = ""

            End If

        Else

            LblRespostaPorta.Text = ""

        End If

    End Sub

    Private Sub TxtNomeInstancia_LostFocus(sender As Object, e As EventArgs) Handles TxtNomeInstancia.LostFocus

        If TxtNomeInstancia.Text <> "" Then

            Dim ConecctionServer As String

            If CkInstanciaPadrão.Checked = True Then

                ConecctionServer = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    'adiciona pra ver se onsegue inserir

                    Try

                        Conexão.Open()

                        If Conexão.State = ConnectionState.Open Then

                            LblConexão.Text = "A conexão foi estabelecida com o servidor."

                            BtnAvançar.Enabled = True

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                            BtnAvançar.Enabled = False

                        End If

                        Conexão.Close()

                    Catch ex As Exception

                        ConecctionServer = "Data Source=" & TxtIp.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Try

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                LblConexão.Text = "A conexão foi estabelecida com o servidor."

                                BtnAvançar.Enabled = True

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                                BtnAvançar.Enabled = False

                            End If

                            Conexão.Close()

                        Catch ex1 As Exception

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                        End Try


                    End Try

                End Using

            Else

                ConecctionServer = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    'adiciona pra ver se onsegue inserir

                    Try

                        Conexão.Open()

                        If Conexão.State = ConnectionState.Open Then

                            LblConexão.Text = "A conexão foi estabelecida com o servidor."

                            BtnAvançar.Enabled = True

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                            BtnAvançar.Enabled = False

                        End If

                        Conexão.Close()

                    Catch ex As Exception

                        LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                    End Try

                End Using

            End If

        Else

            LblConexão.Text = ""

        End If

    End Sub

    Private Sub CkInstanciaPadrão_CheckedChanged(sender As Object, e As EventArgs) Handles CkInstanciaPadrão.CheckedChanged

        If CkInstanciaPadrão.Checked = True Then

            TxtNomeInstancia.Text = "SQLEXPRESS"
            TxtNomeInstancia.Enabled = False
            If TxtNomeInstancia.Text <> "" Then

                Dim ConecctionServer As String

                If CkInstanciaPadrão.Checked = True Then

                    Dim PortaUs As String = ""
                    If TxtPortaSQL.Text <> "" Then

                        PortaUs = "," & PortaUs

                    End If

                    ConecctionServer = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & PortaUs & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                        'adiciona pra ver se onsegue inserir

                        Try

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                LblConexão.Text = "A conexão foi estabelecida com o servidor."

                                BtnAvançar.Enabled = True

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                                BtnAvançar.Enabled = False

                            End If

                            Conexão.Close()

                        Catch ex As Exception

                            ConecctionServer = "Data Source=" & TxtIp.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Try

                                Conexão.Open()

                                If Conexão.State = ConnectionState.Open Then

                                    LblConexão.Text = "A conexão foi estabelecida com o servidor."

                                    BtnAvançar.Enabled = True

                                Else

                                    LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                                    BtnAvançar.Enabled = False

                                End If

                                Conexão.Close()

                            Catch ex1 As Exception

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                            End Try


                        End Try

                    End Using

                Else

                    ConecctionServer = "Data Source=" & TxtIp.Text & "\" & TxtNomeInstancia.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                        'adiciona pra ver se onsegue inserir

                        Try

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                LblConexão.Text = "A conexão foi estabelecida com o servidor."

                                BtnAvançar.Enabled = True

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                                BtnAvançar.Enabled = False

                            End If

                            Conexão.Close()

                        Catch ex As Exception

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                        End Try

                    End Using

                End If

            Else

                LblConexão.Text = ""

            End If

        Else

            TxtNomeInstancia.Text = ""
            TxtNomeInstancia.Enabled = True

        End If

    End Sub

    Dim QtDskEst As Integer = 0
    Dim QtMobEst As Integer = 0
    Dim QtDskOfi As Integer = 0
    Dim QtMobOfi As Integer = 0

    Dim conn As New MySqlConnection
    Dim myCommand As New MySqlCommand
    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim SQL As String

    Private Sub BttBuscarLicensas_Click(sender As Object, e As EventArgs) Handles BttBuscarLicensas.Click

        Me.Cursor = Cursors.WaitCursor

        QtDskEst = 0
        QtMobEst = 0
        QtDskOfi = 0
        QtMobOfi = 0

        Try

            'busca orcamentos abertos 

            TxtCNPJ.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            Dim baseUrl As String = "http://www.iarasoftware.com.br/valida_chave.php?Doc=" & TxtCNPJ.Text
            TxtCNPJ.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            'carrega informações no site

            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            Dim read = JsonConvert.DeserializeObject(Of List(Of ClsJSON.Acesso))(content)

            Dim Aprovados As Integer = 0
            Dim Perdido As Integer = 0
            Dim Aberto As Integer = 0

            If read.Count > 0 Then
                For Each row In read.ToList
                    LblChave.Text = row.ChaveOficina
                    LblRazaoSocial.Text = row.Razao & " - " & row.FAntasia
                    LblTelefone.Text = row.Telefone
                    LblEmail.Text = row.Email
                Next

                BtnConcluir.Enabled = True
                BtnAvançar.Enabled = False

                Dim baseUrl_chave As String = "http://www.iarasoftware.com.br/reseta_correlacoes_interna.php?ChaveOficina=" & LblChave.Text

                'carrega informações no site

                ' Chamada sincrona
                Dim syncClient_Chave = New WebClient()
                Dim content_Chave = syncClient.DownloadString(baseUrl_chave)

                Me.Cursor = Cursors.Arrow

            Else

                If MsgBox("Não encontrei nenhuma licensa vincula a este CNPJ, deseja gerar uma licensa agora?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                    If MsgBox("No momento não é possível gerar uma licensa dinamicamente, por favor entre em contato com um de nossos representantes para solicitar um acesso." & Chr(13) & "Obrigado ;)") = MsgBoxResult.Ok Then

                        End

                    End If
                    'FrmSolicitaPrimeiroAcesso.Show(Me)

                Else

                    Me.Cursor = Cursors.Arrow

                End If

            End If

        Catch ex As Exception

            MsgBox("Houve uma falha na comunicação com o servidor remoto :(")
            Me.Cursor = Cursors.Arrow

        End Try

    End Sub

    Private Sub LblRespostaPorta_Click(sender As Object, e As EventArgs) Handles LblRespostaPorta.Click

    End Sub

    Private Sub LblRespostaPorta_TextChanged(sender As Object, e As EventArgs) Handles LblRespostaPorta.TextChanged

        If LblRespostaPorta.Text = "A porta esta funcionando normalmente" Then
            BtnAvançar.Enabled = True
        End If

    End Sub

    Private Sub TxtCNPJ_TextChanged(sender As Object, e As EventArgs) Handles TxtCNPJ.TextChanged

        If TxtCNPJ.Text.Length = 14 Then

            BttBuscarLicensas.Enabled = True

        Else

            BttBuscarLicensas.Enabled = False

        End If

    End Sub

    Private Sub RdbAtualizar_CheckedChanged(sender As Object, e As EventArgs) Handles RdbAtualizar.CheckedChanged

        If RdbAtualizar.Checked = True Then

            If MsgBox("Deseja atualizar os bancos de dados?" & Chr(13) &
                      "Após a atualização o instalador fechará automáticamente." & Chr(13) & Chr(13) &
                      "Deseja prosseguir?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

                FrmAtualizar.Show(Me)

            End If

        Else


            End If

    End Sub

    Private Sub PnnAddDeskEstoque_Paint(sender As Object, e As PaintEventArgs) Handles PnnAddDeskEstoque.Paint

    End Sub

    Dim VlrMensal As Decimal = 0

    Private Sub PnnAddDeskEstoque_Click(sender As Object, e As EventArgs) Handles PnnAddDeskEstoque.Click

        LblQtDeskEstoque.Text += 1

        PnnMnnDeskEstoque.Visible = True

        Dim VlrUnit As Decimal = LblVlrUnitDeskEst.Text
        Dim Qt As Integer = LblQtDeskEstoque.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal += SubTotal

        LblSubDeskEst.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnMnnDeskEstoque_Paint(sender As Object, e As PaintEventArgs) Handles PnnMnnDeskEstoque.Paint

    End Sub

    Private Sub PnnMnnDeskEstoque_Click(sender As Object, e As EventArgs) Handles PnnMnnDeskEstoque.Click

        LblQtDeskEstoque.Text -= 1

        Dim VlrUnit As Decimal = LblVlrUnitDeskEst.Text
        Dim Qt As Integer = LblQtDeskEstoque.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal -= SubTotal

        If LblQtDeskEstoque.Text = QtDskEst Then

            PnnMnnDeskEstoque.Visible = False

            VlrMensal -= VlrUnit

        End If

        LblSubDeskEst.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnMnnMobEstoque_Paint(sender As Object, e As PaintEventArgs) Handles PnnMnnMobEst.Paint

    End Sub

    Private Sub PnnMnnMobEstoque_Click(sender As Object, e As EventArgs) Handles PnnMnnMobEst.Click

        LblQtMobEstoque.Text -= 1

        Dim VlrUnit As Decimal = LblVlrUnitMobEst.Text
        Dim Qt As Integer = LblQtMobEstoque.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal -= SubTotal

        If LblQtMobEstoque.Text = QtMobEst Then

            PnnMnnMobEst.Visible = False

            VlrMensal -= VlrUnit

        End If

        LblSubMobEst.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnAddMobEstoque_Paint(sender As Object, e As PaintEventArgs) Handles PnnAddMobEstoque.Paint

    End Sub

    Private Sub PnnAddMobEstoque_Click(sender As Object, e As EventArgs) Handles PnnAddMobEstoque.Click

        LblQtMobEstoque.Text += 1

        PnnMnnMobEst.Visible = True

        Dim VlrUnit As Decimal = LblVlrUnitMobEst.Text
        Dim Qt As Integer = LblQtMobEstoque.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal += SubTotal

        LblSubMobEst.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnMnnDeskOfi_Paint(sender As Object, e As PaintEventArgs) Handles PnnMnnDeskOfi.Paint

    End Sub

    Private Sub PnnMnnDeskOfi_Click(sender As Object, e As EventArgs) Handles PnnMnnDeskOfi.Click

        LblQtDeskOficina.Text -= 1

        Dim VlrUnit As Decimal = LblVlrUnitDeskOfi.Text
        Dim Qt As Integer = LblQtDeskOficina.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal -= SubTotal

        If LblQtDeskOficina.Text = QtDskOfi Then

            PnnMnnDeskOfi.Visible = False

            VlrMensal -= VlrUnit

        End If

        LblSubDeskOfi.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnMnnMobEst_Paint(sender As Object, e As PaintEventArgs) Handles PnnMnnMobOfi.Paint

    End Sub

    Private Sub PnnMnnMobEst_Click(sender As Object, e As EventArgs) Handles PnnMnnMobOfi.Click

        LblQtMobOficina.Text -= 1

        Dim VlrUnit As Decimal = LblVlrUnitMobOfi.Text
        Dim Qt As Integer = LblQtMobOficina.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal -= SubTotal

        If LblQtMobOficina.Text = QtMobOfi Then

            PnnMnnMobOfi.Visible = False

            VlrMensal -= VlrUnit

        End If

        LblSubMobOfi.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnAddMobEst_Paint(sender As Object, e As PaintEventArgs) Handles PnnAddMobEst.Paint

    End Sub

    Private Sub PnnAddDeskOfi_Paint(sender As Object, e As PaintEventArgs) Handles PnnAddDeskOfi.Paint

    End Sub

    Private Sub PnnAddDeskOfi_Click(sender As Object, e As EventArgs) Handles PnnAddDeskOfi.Click

        LblQtDeskOficina.Text += 1

        PnnMnnDeskOfi.Visible = True

        Dim VlrUnit As Decimal = LblVlrUnitDeskOfi.Text
        Dim Qt As Integer = LblQtDeskOficina.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal += SubTotal

        LblSubDeskOfi.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub PnnAddMobEst_Click(sender As Object, e As EventArgs) Handles PnnAddMobEst.Click

        LblQtMobOficina.Text += 1

        PnnMnnMobOfi.Visible = True

        Dim VlrUnit As Decimal = LblVlrUnitMobOfi.Text
        Dim Qt As Integer = LblQtMobOficina.Text
        Dim SubTotal As Decimal = VlrUnit * Qt

        VlrMensal += SubTotal

        LblSubMobOfi.Text = FormatCurrency(SubTotal, NumDigitsAfterDecimal:=2)

    End Sub

    Private Sub LblSubDeskEst_Click(sender As Object, e As EventArgs) Handles LblSubDeskEst.Click

    End Sub

    Private Sub LblSubDeskEst_TextChanged(sender As Object, e As EventArgs) Handles LblSubDeskEst.TextChanged

        If LblSubDeskEst.Text <> "" And LblSubDeskOfi.Text <> "" And LblSubMobEst.Text <> "" And LblSubMobOfi.Text <> "" Then
            Dim VlrEstDesk As Decimal = LblSubDeskEst.Text
            Dim VlrEstMob As Decimal = LblSubMobEst.Text
            Dim VlrOfiDesk As Decimal = LblSubDeskOfi.Text
            Dim VlrOfiMob As Decimal = LblSubMobOfi.Text

            Dim Total As Decimal = (VlrEstDesk + VlrEstMob + VlrOfiDesk + VlrOfiMob)

            LblValorMensal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub LblSubMobEst_Click(sender As Object, e As EventArgs) Handles LblSubMobEst.Click

    End Sub

    Private Sub LblSubMobEst_TextChanged(sender As Object, e As EventArgs) Handles LblSubMobEst.TextChanged

        If LblSubDeskEst.Text <> "" And LblSubDeskOfi.Text <> "" And LblSubMobEst.Text <> "" And LblSubMobOfi.Text <> "" Then
            Dim VlrEstDesk As Decimal = LblSubDeskEst.Text
            Dim VlrEstMob As Decimal = LblSubMobEst.Text
            Dim VlrOfiDesk As Decimal = LblSubDeskOfi.Text
            Dim VlrOfiMob As Decimal = LblSubMobOfi.Text

            Dim Total As Decimal = (VlrEstDesk + VlrEstMob + VlrOfiDesk + VlrOfiMob)

            LblValorMensal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub LblSubDeskOfi_TextChanged(sender As Object, e As EventArgs) Handles LblSubDeskOfi.TextChanged

        If LblSubDeskEst.Text <> "" And LblSubDeskOfi.Text <> "" And LblSubMobEst.Text <> "" And LblSubMobOfi.Text <> "" Then
            Dim VlrEstDesk As Decimal = LblSubDeskEst.Text
            Dim VlrEstMob As Decimal = LblSubMobEst.Text
            Dim VlrOfiDesk As Decimal = LblSubDeskOfi.Text
            Dim VlrOfiMob As Decimal = LblSubMobOfi.Text

            Dim Total As Decimal = (VlrEstDesk + VlrEstMob + VlrOfiDesk + VlrOfiMob)

            LblValorMensal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub LblSubMobOfi_TextChanged(sender As Object, e As EventArgs) Handles LblSubMobOfi.TextChanged

        If LblSubDeskEst.Text <> "" And LblSubDeskOfi.Text <> "" And LblSubMobEst.Text <> "" And LblSubMobOfi.Text <> "" Then
            Dim VlrEstDesk As Decimal = LblSubDeskEst.Text
            Dim VlrEstMob As Decimal = LblSubMobEst.Text
            Dim VlrOfiDesk As Decimal = LblSubDeskOfi.Text
            Dim VlrOfiMob As Decimal = LblSubMobOfi.Text

            Dim Total As Decimal = (VlrEstDesk + VlrEstMob + VlrOfiDesk + VlrOfiMob)

            LblValorMensal.Text = FormatCurrency(Total, NumDigitsAfterDecimal:=2)
        End If

    End Sub

    Private Sub TxtCNPJ_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCNPJ.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttBuscarLicensas.PerformClick()

        End If

    End Sub

    Private Sub LblValorMensal_Click(sender As Object, e As EventArgs) Handles LblValorMensal.Click

    End Sub

    Private Sub LblValorMensal_TextChanged(sender As Object, e As EventArgs) Handles LblValorMensal.TextChanged

        If LblValorMensal.Text > 0 Then

            BtnConcluir.Enabled = True

        Else

            BtnConcluir.Enabled = False

        End If

    End Sub

    Private Sub LblSubDeskOfi_Click(sender As Object, e As EventArgs) Handles LblSubDeskOfi.Click

    End Sub

    Private Sub LblSubMobOfi_Click(sender As Object, e As EventArgs) Handles LblSubMobOfi.Click

    End Sub

    Private Sub Panel7_Paint(sender As Object, e As PaintEventArgs) Handles Panel7.Paint

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If Timer2.Enabled = True Then

            Dim server As System.ServiceProcess.ServiceController
            Dim service As ServiceController = New ServiceController("MSSQLSERVER")

            If ((service.Status.Equals(ServiceControllerStatus.Stopped)) Or (service.Status.Equals(ServiceControllerStatus.StopPending))) Then

                'service.Start()

                If MsgBox("Tudo certo, agora e só aguardar a conclusão das tarefas, isso pode levar algum tempo.") Then
                    Timer2.Enabled = False
                End If


            Else

                'service.Stop()
                'MsgBox("Start")
                'Timer2.Enabled = True

            End If

        End If

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class
