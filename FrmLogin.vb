Imports System.Data
Imports System.Data.Sql
Imports System.IO
Imports System.Net
Imports System.Text
Imports Microsoft.Win32
Imports MySql.Data.MySqlClient
Imports System.Runtime.Serialization.Json
Imports Newtonsoft.Json
Public Class FrmLogin

    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        End

    End Sub

    Dim Conn As New DtCadastroDataContext

    Dim myCommand As New MySqlCommand
    Dim myAdapter As New MySqlDataAdapter
    Dim myData As New DataTable
    Dim SQL As String

    Dim IPIAra As String = "179.113.183.177"

    Public Sub Verifica_Ftp()

        Const localFile As String = "C:\arquivo.bin"
        Const remoteFile As String = "/IARA/OFICINA/"
        Const host As String = "ftp://ftp.oficinalivreesco1.hospedagemdesites.ws"
        Const username As String = "oficinalivreesco1"
        Const password As String = "IARA1q2w3e4r5t6y7u*"

        '1. Cria uma requisição: deve estar no formato ftp://hostname
        'e não apensa ftp.myhost.com
        Dim URI As String = host & remoteFile
        Dim ftp As System.Net.FtpWebRequest = CType(FtpWebRequest.Create(URI), FtpWebRequest)

        '2. Define as credenciais
        ftp.Credentials = New System.Net.NetworkCredential(username, password)

        '3. Definindo a ação
        ftp.KeepAlive = False
        'definindo uma transferencia binária e não textual
        ftp.UseBinary = True
        'Define a ação (neste caso fazer um downloa de um arquivo)
        ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory

        '4. se voce estiver usando um método que envia um arquivo 
        '5. Obtem a resposta da requisição ftp e do stream associado
        Using response As System.Net.FtpWebResponse = CType(ftp.GetResponse, System.Net.FtpWebResponse)

            Using responseStream As IO.Stream = response.GetResponseStream


                'MsgBox(response.GetResponseStream)

            End Using

        End Using

        '6. Fim 
    End Sub


    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LblStatus.Text = "Conectando"


    End Sub

    Public C As Integer = 1
    Dim CTotal As Integer = 10

    Public Sub LOAD_Form()

        Me.Refresh()

        'abre o ddns_cliente

        Dim conn As MySqlConnection

        conn = New MySqlConnection

        conn.ConnectionString = "server=ddns-iara.mysql.uhserver.com;user id=ddns_iara;password=IARA1q2w3e4r*;database=ddns_iara"

        Dim Sql As String = "SELECT `IdCliente`, `IP`, `Data`, `Hora`, `Matriz`, `IdClienteReew`, 'CNPJ' FROM `IPS_RENEW` where cnpj like 'I.A.R.A.'"

        Try

            conn.Open()

            'consulta banco

            Try

                myCommand.Connection = conn

                myCommand.CommandText = Sql

                myAdapter.SelectCommand = myCommand

                myAdapter.Fill(myData)

                For Each item As DataRow In myData.Rows

                    IPIAra = item.Item(1).ToString

                Next

                FrmPrincipal._IpIara = IPIAra

            Catch ex As Exception

            End Try

            Timer1.Enabled = False

        Catch ex As Exception

            Timer1.Enabled = True

        End Try

        Me.Refresh()

        'consulta atualização no ftp IARA
        'Verifica_Ftp()

        If IO.Directory.Exists("C:\Iara\Ini") Then

            'verifica arquivo

            If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                'Le arquivo de inicialização

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

                                FrmPrincipal._Ip = _IP
                                FrmPrincipal._Instancia = _Instancia
                                FrmPrincipal._portaSQL = Val(_PortaSql)

                                _IP = _IP.Replace("U", "")

                                'public

                                Dim Instancia As String = ""

                                If FrmPrincipal._Instancia <> "" Then

                                    Instancia = "\" & FrmPrincipal._Instancia

                                End If

                                If _Instancia <> "" And _PortaSql <> "" And _IP <> "" Then

                                    TxtDoc.Text = (palavra0)

                                End If

                                FrmPrincipal.ConnectionStringBase = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringComercial = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Comercial;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringEstoqueLocal = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= EstoqueLocal;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringFinanceiro = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Financeiro;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringOficina = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Oficina;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                FrmPrincipal.ConnectionStringTrabalhista = "Data Source=" & _IP & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Trabalhista;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                                FrmPrincipal.ConnectionStringEstoqueDistribuidorOnLine = "Data Source= " & IPIAra & "\SQLEXPRESS, 14333;Initial Catalog= EstoqueDistribuidorOnLine;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringIARA = "Data Source=" & IPIAra & "\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
                                    FrmPrincipal.ConnectionStringTransportePrestadorOnline = "Data Source=" & IPIAra & "\SQLEXPRESS, 14333;Initial Catalog= TransportePrestadorOnline;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                                    LblStatus.Text = ""

                                End If

                        Next

                    Next

                    'verifica se esta maquina possui licensas pelo mac

                    'verifica mac

                    Dim mc As System.Management.ManagementClass
                    Dim mo As System.Management.ManagementBaseObject
                    mc = New Management.ManagementClass("Win32_NetworkAdapterConfiguration")
                    Dim moc As Management.ManagementObjectCollection = mc.GetInstances

                    Dim _MAC As String = ""

                    For Each mo In moc
                        If mo.Item("IPenabled") = True Then
                            _MAC = mo.Item("MacAddress")
                        End If
                    Next

                    LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase

                    LqIara.Connection.ConnectionString = FrmPrincipal.ConnectionStringIARA

                    FrmPrincipal.Visible = False

                    LblVersão.Text = "V." & My.Application.UICulture.CompareInfo.Version.ToString

                    Try

                        Dim ConecctionServer As String = FrmPrincipal.ConnectionStringBase
                        Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                'PicLocal.BackgroundImage = My.Resources.globe_connected_21031

                                TxtNick.Enabled = True

                                Dim BuscaLicensas = From lic In LqBase.ChavesInterno
                                                    Where lic.MAC Like _MAC
                                                    Select lic.IdChave
                                'atualiza

                                LqBase.AtualizaDadosChaveInterno(BuscaLicensas.First, FrmPrincipal._Ip, _MAC, "")

                                Dim BuscaUsuarios = From usu In LqBase.Funcionarios
                                                    Where usu.IdFuncionario Like "*"
                                                    Select usu.IdFuncionario

                                If BuscaUsuarios.Count = 0 Then

                                    Timer1.Enabled = False

                                    Me.Opacity = 0

                                    FrmBemVindo.Show()

                                End If

                            Else

                                PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030

                                'TxtNick.Enabled = False
                                TxtNick.Text = ""

                            End If


                        End Using

                    Catch ex As Exception

                        PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030

                        'TxtNick.Enabled = False
                        TxtNick.Text = ""

                    End Try

                    Try

                        Dim ConecctionServer As String = FrmPrincipal.ConnectionStringIARA
                        Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                'PicCioud.BackgroundImage = My.Resources.globe_connected_21031

                                TxtNick.Enabled = True

                                Dim BuscaUsuarios = From usu In LqBase.Funcionarios
                                                    Where usu.IdFuncionario Like "*"
                                                    Select usu.IdFuncionario

                                If BuscaUsuarios.Count = 0 Then

                                    Timer1.Enabled = False

                                    Me.Opacity = 0

                                    FrmBemVindo.Show()

                                End If

                            Else

                                PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                            End If

                        End Using

                    Catch ex As Exception

                        PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                    End Try

                    Timer2.Enabled = False

                    TxtNick.Focus()

                Else

                    'Abre a mensagem para configuração

                    Timer1.Enabled = False

                    Me.Opacity = 0

                    FrmBemVindo.Show()

                End If

            Else

                'Abre a mensagem para configuração

                Timer1.Enabled = False

                Me.Opacity = 0

                FrmBemVindo.Show()

            End If

        Else

            'Abre a mensagem para configuração

            Timer1.Enabled = False

            Me.Opacity = 0

            FrmBemVindo.Show()

        End If

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If CTotal = 10 Then
            'abre o ddns_cliente

            Dim conn As MySqlConnection

            conn = New MySqlConnection

            conn.ConnectionString = "server=ddns-iara.mysql.uhserver.com;user id=ddns_iara;password=IARA1q2w3e4r*;database=ddns_iara"

            Dim Sql As String = "SELECT `IdCliente`, `IP`, `Data`, `Hora`, `Matriz`, `IdClienteReew`, 'CNPJ' FROM `IPS_RENEW` where cnpj like 'I.A.R.A.'"

            Try

                conn.Open()

                'consulta banco

                Try

                    myCommand.Connection = conn

                    myCommand.CommandText = Sql

                    myAdapter.SelectCommand = myCommand

                    myAdapter.Fill(myData)

                    For Each item As DataRow In myData.Rows

                        IPIAra = item.Item(1).ToString

                    Next

                    FrmPrincipal._IpIara = IPIAra

                Catch ex As Exception

                End Try

                Timer1.Enabled = False

            Catch ex As Exception

                Timer1.Enabled = False

            End Try

            CTotal = 0

        Else

            CTotal += 1

        End If

    End Sub

    Dim LqBase As New DtCadastroDataContext
    Dim LqIara As New LqJarbesDataContext
    Public Shared Function VerificaLogin(Login As String, Pass As String, Doc As String) As ClasseLogin

        Dim baseUrl As String = "http://www.iarasoftware.com.br/login_net_new.php?User=" & Login & "&Pass=" & Pass & "&Doc=" & Doc.Replace(",", ".")

        Try
            ' Chamada sincrona
            Dim syncClient = New WebClient()
            Dim content = syncClient.DownloadString(baseUrl)

            ' Cria o serializados Json e trata a resposta
            Dim serializer As New DataContractJsonSerializer(GetType(ClasseLogin))
            Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                ' deserializa o objeto JSON usando o tipo de dados
                Dim weatherData = DirectCast(serializer.ReadObject(ms), ClasseLogin)
                Return weatherData
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

        'conecta com o servidor remoto para verificar usuario, devolve a chave correspondente, conn MYSQL

        Dim ConnRemoto As String

        Dim baseUrl As String = "http://www.iarasoftware.com.br/login_net_new.php?User=" & TxtNick.Text & "&Pass=" & TxtPassword.Text & "&Doc=" & TxtDoc.Text.Replace(",", ".")

        LqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
        LqIara.Connection.ConnectionString = FrmPrincipal.ConnectionStringIARA

        'FrmPrincipal.TtOficina.Visible = False

        'Try
        If Not TxtNick.Text.EndsWith("master") Then

            Dim ChaveEncontrada As String = ""
            Dim NomeComplemento As String = ""
            Dim IdUsuario As String = "0"
            Dim RazaoSocial As String = ""
            Dim CNPJ As String = ""
            Dim Endereco As String = ""
            Dim Telefone As String = ""
            Dim Email As String = ""
            Dim IE As String = ""
            Dim Complemento As String = ""
            Dim Numero As String = ""
            Dim NomeFantasia As String = ""

            FrmPrincipal.TtComercial.Enabled = False
            'FrmPrincipal.TtEstoque.Enabled = False
            FrmPrincipal.TtOficina.Enabled = False
            FrmPrincipal.TtFinanceiro.Enabled = False

            FrmQuadroOperacional.Primeiro = True

            'busca acesso da chave

            Dim BuscaChave = From chav In LqBase.ChavesInterno
                             Where chav.IPInt Like FrmPrincipal._Ip
                             Select chav.IdProduto, chav.NumeroDaChave, chav.ValidadeDias, chav.DataLiberacaoo, chav.IdClienteIARA

            'MsgBox(FrmPrincipal.ConnectionStringBase)
            If ChaveEncontrada.Length = 0 Then

                'verifica se chave já consta no banco de dados

                'busca na iara a validade

                If TxtPassword.Text <> "000000" Then

                    'cadastra o usuario na base de dados local caso ainda não tenha sido feita

                    Dim BuscaUsuario = From user In LqBase.Login
                                       Where user.Nick Like TxtNick.Text And user.Pass Like TxtPassword.Text
                                       Select user.IdColaborador

                    If BuscaUsuario.Count = 0 Then

                        'insere novo login na base local
                        LqBase.InsereLogin(TxtNick.Text, TxtPassword.Text, IdUsuario, 0)

                        'libera portais de acesso

                        FrmPrincipal.TtComercial.Enabled = True
                        FrmPrincipal.TtEstoque.Enabled = True
                        FrmPrincipal.TtOficina.Enabled = True
                        FrmPrincipal.TtFinanceiro.Enabled = True

                        FrmQuadroOperacional.Primeiro = False

                    Else


                        'insere novo login na base local
                        LqBase.InsereLogin(TxtNick.Text, TxtPassword.Text, BuscaUsuario.First, 0)

                        'libera portais de acesso

                        FrmPrincipal.TtComercial.Enabled = True
                        FrmPrincipal.TtEstoque.Enabled = True
                        FrmPrincipal.TtOficina.Enabled = True
                        FrmPrincipal.TtFinanceiro.Enabled = True

                        FrmQuadroOperacional.Primeiro = False

                    End If

                    'Try
                    ' Chamada sincrona
                    Dim syncClient = New WebClient()
                        Dim content = syncClient.DownloadString(baseUrl)

                        'Dim arquivoJson = JObject.Parse(content)

                        ' Cria o serializados Json e trata a resposta
                        Dim serializer As New DataContractJsonSerializer(GetType(ClasseLogin))
                    Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                        ' deserializa o objeto JSON usando o tipo de dados
                        Dim weatherData = DirectCast(serializer.ReadObject(ms), ClasseLogin)
                        Dim read = JsonConvert.DeserializeObject(Of List(Of ClasseLogin))(content)
                        If read.Count > 0 Then
                            ChaveEncontrada = (read.Item(0).ChaveOficina)
                            NomeComplemento = (read.Item(0).NomeCompleto)
                            IdUsuario = (read.Item(0).IdUsuario)
                            RazaoSocial = (read.Item(0).RazaoSocial)
                            CNPJ = (read.Item(0).CNPJ)
                            Endereco = (read.Item(0).Endereco)
                            IE = (read.Item(0).IE)
                            Telefone = (read.Item(0).Telefone)
                            Email = (read.Item(0).Email)
                            Numero = (read.Item(0).Numero)
                            Complemento = (read.Item(0).Complemento)
                            NomeFantasia = (read.Item(0).NomeFantasia)

                            FrmPrincipal.LblNomeUsuario.Text = NomeComplemento
                            FrmPrincipal.LblCargo.Text = ""
                            FrmPrincipal.LblChaveEnc.Text = ChaveEncontrada
                            FrmPrincipal.RazaoSocial = RazaoSocial
                            FrmPrincipal.CNPJ = "30.694.650/0001-45"
                            FrmPrincipal.Endereco = Endereco
                            FrmPrincipal.Telefone = Telefone
                            FrmPrincipal.Email = Email
                            FrmPrincipal.IE = IE
                            FrmPrincipal.Complemento = Complemento
                            FrmPrincipal.Numero = Numero
                            FrmPrincipal.NomeFantasia = NomeFantasia

                            'FrmPrincipal.Timer1.Enabled = True

                            Me.Visible = False

                            FrmPrincipal.IdUsuario = IdUsuario
                            'FrmPrincipal.WindowState = FormWindowState.Minimized

                            FrmPrincipal.CarregaDashboard()

                            FrmPrincipal.Show()

                            FrmPrincipal.Visible = True

                        Else
                            MsgBox("O usuário não foi encontrado!", vbOKOnly)
                        End If
                        'Return weatherData
                    End Using

                    'Catch ex As Exception

                    '    If MsgBox("Não foi possível conectar ao servidor remoto :(" & Chr(13) & ex.StackTrace, vbOKOnly) = MsgBoxResult.Ok Then

                    '        Me.Visible = True

                    '        FrmSinc.Close()

                    '    End If

                    'End Try

                Else

                    '
                    If Application.OpenForms.OfType(Of FrmTrocarSenha)().Count() = 0 Then

                        ' Chamada sincrona
                        Dim syncClient = New WebClient()
                        Dim content = syncClient.DownloadString(baseUrl)

                        ' Cria o serializados Json e trata a resposta
                        Dim serializer As New DataContractJsonSerializer(GetType(ClasseLogin))
                        Using ms = New MemoryStream(Encoding.Unicode.GetBytes(content))
                            ' deserializa o objeto JSON usando o tipo de dados
                            Dim weatherData = DirectCast(serializer.ReadObject(ms), ClasseLogin)
                            Dim read = JsonConvert.DeserializeObject(Of List(Of ClasseLogin))(content)

                            If read.Count > 0 Then
                                ChaveEncontrada = (read.Item(0).ChaveOficina)
                                NomeComplemento = (read.Item(0).NomeCompleto)
                                IdUsuario = (read.Item(0).IdUsuario)
                                RazaoSocial = (read.Item(0).RazaoSocial)
                                CNPJ = (read.Item(0).CNPJ)

                                'abre processo pra atualizar senha

                                FrmTrocarSenha.ChaveEnc = ChaveEncontrada
                                FrmTrocarSenha.NomeUsuario = TxtNick.Text
                                FrmTrocarSenha.Show(Me)

                            Else

                                MsgBox("Usuário não encontrado!", MsgBoxStyle.OkOnly)

                            End If

                            'Return weatherData
                        End Using


                    End If

                End If

            End If

        End If

        'Catch ex As Exception

        '    MsgBox("Houve um erro ao iniciar a plataforma, tente realizar o login novamente.", MsgBoxStyle.OkOnly)

        'End Try

    End Sub

    Private Sub TxtNick_TextChanged(sender As Object, e As EventArgs) Handles TxtNick.TextChanged

        If TxtNick.Text <> "" Then
            TxtPassword.Enabled = True
        Else
            TxtPassword.Text = ""
            TxtPassword.Enabled = False
        End If

    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles TxtPassword.TextChanged

        If TxtPassword.Text <> "" And TxtPassword.Text.Length > 5 Then

            BttSalvar.Visible = True

        Else

            BttSalvar.Visible = False

        End If

    End Sub

    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPassword.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Then

            e.Handled = True

            BttSalvar.PerformClick()

        End If

    End Sub

    Private Sub TxtNick_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNick.KeyPress

        If e.KeyChar = Convert.ToChar(Keys.Return) Or e.KeyChar = Convert.ToChar(Keys.Tab) Then

            e.Handled = True

            TxtPassword.Focus()

        End If

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub

    Private Sub Panel1_Click(sender As Object, e As EventArgs) Handles Panel1.Click

        If Application.OpenForms.OfType(Of FrmConfig)().Count() = 0 Then

            FrmConfig.Show(Me)

        End If

    End Sub

    Private Sub LblVersão_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PicLocal_Click(sender As Object, e As EventArgs) Handles PicLocal.Click

        If IO.Directory.Exists("C:\Iara\Ini") Then

            'verifica arquivo

            If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                'cria arquivo de inicialização

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

                                ElseIf _INstancia = "" And _PortaSql <> "" And _IP <> "" Then

                                    _INstancia = (palavra0)

                                End If

                                FrmConfigRede.TxtIp.Text = _IP
                                FrmConfigRede.TxtPortaSQL.Text = _PortaSql
                                FrmConfigRede.TxtNomeInstancia.Text = _INstancia

                            End If

                        Next

                    Next

                    FrmConfigRede.Show()

                Else

                    'Abre a mensagem para configuração

                    Timer1.Enabled = False

                    Me.Opacity = 0

                    FrmBemVindo.Show()

                End If

            Else

                'Abre a mensagem para configuração

                Timer1.Enabled = False

                Me.Opacity = 0

                FrmBemVindo.Show()

            End If

        Else

            'Abre a mensagem para configuração

            Timer1.Enabled = False

            Me.Opacity = 0

            FrmBemVindo.Show()

        End If

    End Sub

    Dim Local As Boolean = False
    Dim IARA As Boolean = False

    Public Function BuscaIP()
        Dim myHost As String = System.Net.Dns.GetHostName
        Dim myIPs As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(myHost)

        Dim ip As String
        For Each myIP As System.Net.IPAddress In myIPs.AddressList

            ip = myIP.ToString
        Next
        FrmPrincipal._Ip = (ip)
        Return ip
    End Function

    Dim VarreInterno As Integer = 0
    Dim VarreExterno As Integer = 0

    Dim C0 As Integer = 2
    Dim C1 As Integer = 2

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        'pinga ip interno

        If FrmPrincipal._Ip.EndsWith("U") Then

            BuscaIP()

            Dim Lqbase As New DtCadastroDataContext

            If IO.Directory.Exists("C:\Iara\Ini") Then

                'verifica arquivo

                If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                    'cria arquivo de inicialização

                    Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                    'verifica se o arquivo existe
                    If Not File.Exists(Arquivo) Then
                        ' Cria um arquivo para escrita
                        Using sw As FileStream = File.Create(Arquivo)

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text

                            Dim Instancia As String

                            If FrmPrincipal._Instancia <> "" Then

                                Instancia = "\" & FrmPrincipal._Instancia

                            End If

                            Dim ConecctionServer As String = "Data Source=" & FrmPrincipal._Ip & Instancia & ", " & FrmPrincipal._portaSQL & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Lqbase.Connection.ConnectionString = ConecctionServer

                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            sw.Close()

                            'FrmLogin.Timer1.Enabled = True

                        End Using
                    Else
                        File.Delete(Arquivo)
                        ' Cria um arquivo para escrita
                        Using sw As FileStream = File.Create(Arquivo)

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text
                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            'FrmLogin.Timer1.Enabled = True

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

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text

                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            'FrmLogin.Timer1.Enabled = True

                        End Using
                    Else
                        File.Delete(Arquivo)
                        ' Cria um arquivo para escrita
                        Using sw As FileStream = File.Create(Arquivo)

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text


                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            'FrmLogin.Timer1.Enabled = True

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

                        Dim EstaMaquina As String = "U"

                        Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'FrmLogin.Timer1.Enabled = True

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)

                        Dim EstaMaquina As String = "U"

                        Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                    "CNPJ:" & TxtDoc.Text

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'FrmLogin.Timer1.Enabled = True

                    End Using
                    Return

                End If

            End If

        End If

        Dim _IpNew As String = FrmPrincipal._Ip.Replace("U", "")

        If VarreInterno = C0 Then

            Try

                If My.Computer.Network.Ping(_IpNew) = True Then
                    Dim ElapseTime As New Stopwatch
                    ElapseTime.Start()
                    My.Computer.Network.Ping(_IpNew)
                    ElapseTime.Stop()

                    ' avisa que pingou
                    PicLocal.BackgroundImage = My.Resources.globe_connected_21031
                    FrmPrincipal.PicLocal.BackgroundImage = My.Resources.globe_connected_21031
                    Local = True
                Else
                    PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                    FrmPrincipal.PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                    Local = False
                    BuscaIP()

                    Dim Lqbase As New DtCadastroDataContext

                    If IO.Directory.Exists("C:\Iara\Ini") Then

                        'verifica arquivo

                        If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                            'cria arquivo de inicialização

                            Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                            'verifica se o arquivo existe
                            If Not File.Exists(Arquivo) Then
                                ' Cria um arquivo para escrita
                                Using sw As FileStream = File.Create(Arquivo)

                                    Dim EstaMaquina As String = "U"

                                    Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                    Dim Instancia As String

                                    If FrmPrincipal._Instancia <> "" Then

                                        Instancia = "\" & FrmPrincipal._Instancia

                                    End If

                                    Dim ConecctionServer As String = "Data Source=" & FrmPrincipal._Ip & Instancia & ", " & FrmPrincipal._portaSQL & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                                    Lqbase.Connection.ConnectionString = ConecctionServer

                                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                    sw.Write(texto, 0, texto.Length)

                                    sw.Close()

                                    'FrmLogin.Timer1.Enabled = True

                                End Using
                            Else
                                File.Delete(Arquivo)
                                ' Cria um arquivo para escrita
                                Using sw As FileStream = File.Create(Arquivo)

                                    Dim EstaMaquina As String = "U"

                                    Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                    sw.Write(texto, 0, texto.Length)

                                    'FrmLogin.Timer1.Enabled = True

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

                                    Dim EstaMaquina As String = "U"

                                    Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                    sw.Write(texto, 0, texto.Length)

                                    'FrmLogin.Timer1.Enabled = True

                                End Using
                            Else
                                File.Delete(Arquivo)
                                ' Cria um arquivo para escrita
                                Using sw As FileStream = File.Create(Arquivo)

                                    Dim EstaMaquina As String = "U"

                                    Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text


                                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                    sw.Write(texto, 0, texto.Length)

                                    'FrmLogin.Timer1.Enabled = True

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

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                'FrmLogin.Timer1.Enabled = True

                            End Using
                        Else
                            File.Delete(Arquivo)
                            ' Cria um arquivo para escrita
                            Using sw As FileStream = File.Create(Arquivo)

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                            "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                        "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text



                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                'FrmLogin.Timer1.Enabled = True

                            End Using
                            Return

                        End If

                    End If

                End If

            Catch ex As Exception

                'TxtNick.Enabled = False
                PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                FrmPrincipal.PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                Local = False

            End Try

        Else

            VarreInterno += 1

        End If

        'pinga ip interno

        If VarreExterno = C0 Then

            Try

                If My.Computer.Network.Ping(FrmPrincipal._IpIara) = True Then
                    Dim ElapseTime As New Stopwatch
                    ElapseTime.Start()
                    My.Computer.Network.Ping(FrmPrincipal._IpIara)
                    ElapseTime.Stop()

                    ' avisa que pingou
                    PicCioud.BackgroundImage = My.Resources.globe_connected_21031
                    FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_connected_21031

                    IARA = True
                Else
                    PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
                    FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                    IARA = False
                    Timer1.Enabled = True
                End If

                VarreExterno = 2

            Catch ex As Exception

                PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
                FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                IARA = False

                VarreExterno = 30

            End Try

        Else

            VarreExterno += 1

        End If

        If IARA = True Or Local = True Then

            TxtNick.Enabled = True

        End If


    End Sub

    Private Sub LblStatus_Click(sender As Object, e As EventArgs) Handles LblStatus.Click

    End Sub

    Private Sub LblStatus_TextChanged(sender As Object, e As EventArgs) Handles LblStatus.TextChanged

        If LblStatus.Text = "Conectando" Then
            LOAD_Form()
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        Dim _IpNew As String = FrmPrincipal._Ip.Replace("U", "")

        Try

            If My.Computer.Network.Ping(_IpNew) = True Then
                Dim ElapseTime As New Stopwatch
                ElapseTime.Start()
                My.Computer.Network.Ping(_IpNew)
                ElapseTime.Stop()

                ' avisa que pingou
                PicLocal.BackgroundImage = My.Resources.globe_connected_21031
                FrmPrincipal.PicLocal.BackgroundImage = My.Resources.globe_connected_21031
                Local = True
            Else
                PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                FrmPrincipal.PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030
                Local = False
                BuscaIP()

                Dim Lqbase As New DtCadastroDataContext

                If IO.Directory.Exists("C:\Iara\Ini") Then

                    'verifica arquivo

                    If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                        'cria arquivo de inicialização

                        Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                        'verifica se o arquivo existe
                        If Not File.Exists(Arquivo) Then
                            ' Cria um arquivo para escrita
                            Using sw As FileStream = File.Create(Arquivo)

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                Dim Instancia As String

                                If FrmPrincipal._Instancia <> "" Then

                                    Instancia = "\" & FrmPrincipal._Instancia

                                End If

                                Dim ConecctionServer As String = "Data Source=" & FrmPrincipal._Ip & Instancia & ", " & FrmPrincipal._portaSQL & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                                Lqbase.Connection.ConnectionString = ConecctionServer

                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                sw.Close()

                                'FrmLogin.Timer1.Enabled = True

                            End Using
                        Else
                            File.Delete(Arquivo)
                            ' Cria um arquivo para escrita
                            Using sw As FileStream = File.Create(Arquivo)

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                'FrmLogin.Timer1.Enabled = True

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

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                'FrmLogin.Timer1.Enabled = True

                            End Using
                        Else
                            File.Delete(Arquivo)
                            ' Cria um arquivo para escrita
                            Using sw As FileStream = File.Create(Arquivo)

                                Dim EstaMaquina As String = "U"

                                Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text


                                Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                                sw.Write(texto, 0, texto.Length)

                                'FrmLogin.Timer1.Enabled = True

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

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text

                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            'FrmLogin.Timer1.Enabled = True

                        End Using
                    Else
                        File.Delete(Arquivo)
                        ' Cria um arquivo para escrita
                        Using sw As FileStream = File.Create(Arquivo)

                            Dim EstaMaquina As String = "U"

                            Dim TextoString As String = "IP:" & FrmPrincipal._Ip & EstaMaquina & Chr(13) &
                        "Porta:" & FrmPrincipal._portaSQL & Chr(13) &
                    "Instancia:" & FrmPrincipal._Instancia & Chr(13) &
                        "CNPJ:" & TxtDoc.Text



                            Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                            sw.Write(texto, 0, texto.Length)

                            'FrmLogin.Timer1.Enabled = True

                        End Using
                        Return

                    End If

                End If

            End If

            Dim IPRemoto As String = "www.iarasoftware.com.br"

            If My.Computer.Network.Ping(IPRemoto) = True Then
                Dim ElapseTime As New Stopwatch
                ElapseTime.Start()
                My.Computer.Network.Ping(IPRemoto)
                ElapseTime.Stop()

                ' avisa que pingou
                PicCioud.BackgroundImage = My.Resources.globe_connected_21031
                FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_connected_21031
                'Remot = True
            Else
                PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
                FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
                'Local = False

            End If
        Catch ex As Exception

            'TxtNick.Enabled = False
            PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
            FrmPrincipal.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030
            'Local = False

        End Try

    End Sub
End Class