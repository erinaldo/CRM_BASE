Imports System.IO
Imports System.Net.Sockets
Imports System.Text

Public Class FrmPassoAPasso
    Private Sub TxtNomeCompleto_TextChanged(sender As Object, e As EventArgs) Handles TxtNomeCompleto.TextChanged

        If TxtNomeCompleto.Text <> "" Then

            TxtTelefoneResid.Enabled = True
            TxtCelular.Enabled = True
            TxtCPF.Enabled = True

        Else

            TxtTelefoneResid.Enabled = False
            TxtTelefoneResid.Text = ""

            TxtCelular.Enabled = False
            TxtCelular.Text = ""

            TxtCPF.Enabled = False
            TxtCPF.Text = ""

        End If

    End Sub

    Private Sub TxtTelefoneResid_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles TxtTelefoneResid.MaskInputRejected

    End Sub

    Private Sub TxtTelefoneResid_TextChanged(sender As Object, e As EventArgs) Handles TxtTelefoneResid.TextChanged

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

        If TxtRg.Text.Length > 5 Then

            BtnProximo.Enabled = True

        Else

            BtnProximo.Enabled = False

        End If
    End Sub

    Dim Col As Boolean = False

    Dim lqBase As New DtCadastroDataContext
    Dim LqIara As New LqJarbesDataContext

    Private Sub BtnConcluir_Click(sender As Object, e As EventArgs) Handles BtnProximo.Click

        If Col = True Then
            'cadastra usuário mestre

            Dim Instancia As String

            If TxtNomeInstancia.Text <> "" Then

                Instancia = "\" & TxtNomeInstancia.Text

            End If

            'cargo master
            Dim LqBase As New DtCadastroDataContext

            Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

            LqBase.Connection.ConnectionString = ConecctionServer

            LqBase.InsereColaborador(TxtNomeCompleto.Text, TxtCPF.Text, TxtRg.Text, "", "", "", 0, "", 0, "", "", "", "", "", "", "", "", "", "", "", "", "", "", Nothing, 0, "Master", 0, "", 0, 0, "", 0, "", "", "", False, "", "")

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

            Dim _Nick As String = LstPalavras.Items(0).ToString & ".master"

            'insere novo login

            LqBase.InsereLogin(_Nick, "123@mudar", BuscaColaborador.First, 0)

            FrmLogin.TxtNick.Text = _Nick
            FrmLogin.TxtPassword.Text = "123@mudar"
            FrmLogin.Opacity = 97
            FrmLogin.Show()
            FrmLogin.BttSalvar.PerformClick()

            Me.Close()

        Else

            FrmPrincipal._Ip = TxtIp.Text

            FrmPrincipal._portaSQL = TxtPortaSQL.Text

            FrmPrincipal._Instancia = TxtNomeInstancia.Text

            'public

            Dim Instancia As String = ""

            If FrmPrincipal._Instancia <> "" Then

                Instancia = "\" & FrmPrincipal._Instancia

            End If

            FrmPrincipal.ConnectionStringBase = "Data Source=" & FrmPrincipal._Ip & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringComercial = "Data Source=" & FrmPrincipal._Ip & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Comercial;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringEstoqueDistribuidorOnLine = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= EstoqueDistribuidorOnLine;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringEstoqueLocal = "Data Source=" & FrmPrincipal._Ip & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= EstoqueLocal;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringFinanceiro = "Data Source=" & FrmPrincipal._Ip & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Financeiro;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringIARA = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= IARA;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringOficina = "Data Source=" & FrmPrincipal._Ip & Instancia & "," & FrmPrincipal._portaSQL & ";Initial Catalog= Oficina;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"
            FrmPrincipal.ConnectionStringTransportePrestadorOnline = "Data Source=191.13.16.201\SQLEXPRESS, 14333;Initial Catalog= TransportePrestadorOnline;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

            lqBase.Connection.ConnectionString = FrmPrincipal.ConnectionStringBase
            LqIara.Connection.ConnectionString = FrmPrincipal.ConnectionStringIARA

            FrmPrincipal.Visible = False

            FrmLogin.LblVersão.Text = "V." & My.Application.Info.Version.ToString

            Try

                Dim ConecctionServer As String = FrmPrincipal.ConnectionStringBase
                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    Conexão.Open()

                    If Conexão.State = ConnectionState.Open Then

                        FrmLogin.PicLocal.BackgroundImage = My.Resources.globe_connected_21031

                        FrmLogin.TxtNick.Enabled = True

                        Dim BuscaUsuarios = From usu In lqBase.Funcionarios
                                            Where usu.IdFuncionario Like "*"
                                            Select usu.IdFuncionario

                        If BuscaUsuarios.Count = 0 Then

                            Timer1.Enabled = False

                            Me.Opacity = 0

                            FrmBemVindo.Show()

                        End If

                    Else

                        FrmLogin.PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030

                        FrmLogin.TxtNick.Enabled = False
                        FrmLogin.TxtNick.Text = ""

                    End If


                End Using

            Catch ex As Exception

                FrmLogin.PicLocal.BackgroundImage = My.Resources.globe_disconnected_21030

                FrmLogin.TxtNick.Enabled = False
                FrmLogin.TxtNick.Text = ""

            End Try

            Try

                Dim ConecctionServer As String = FrmPrincipal.ConnectionStringIARA
                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    Conexão.Open()

                    If Conexão.State = ConnectionState.Open Then

                        FrmLogin.PicCioud.BackgroundImage = My.Resources.globe_connected_21031

                        FrmLogin.TxtNick.Enabled = True

                        Dim BuscaUsuarios = From usu In lqBase.Funcionarios
                                            Where usu.IdFuncionario Like "*"
                                            Select usu.IdFuncionario

                        If BuscaUsuarios.Count = 0 Then

                            Timer1.Enabled = False

                            Me.Opacity = 0

                            FrmBemVindo.Show()

                        End If

                    Else

                        FrmLogin.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                        FrmLogin.TxtNick.Enabled = False
                        FrmLogin.TxtNick.Text = ""

                    End If

                End Using

            Catch ex As Exception

                FrmLogin.PicCioud.BackgroundImage = My.Resources.globe_disconnected_21030

                FrmLogin.TxtNick.Enabled = False
                FrmLogin.TxtNick.Text = ""

            End Try

            Timer1.Enabled = True

            FrmLogin.TxtNick.Focus()

            FrmLogin.Opacity = 97
            FrmLogin.Show()

            Me.Close()

        End If

        'verifica existencia e instala
    End Sub

    Private Sub TxtIp_TextChanged(sender As Object, e As EventArgs) Handles TxtIp.TextChanged

        If TxtIp.Text = "" Then
            LblRespostas.Text = ""
        End If

    End Sub

    Dim intervaloTempo As Integer = 0
    Dim LbPing As New ListBox

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

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

        Else

            TxtNomeInstancia.Text = ""
            TxtNomeInstancia.Enabled = True

        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnAvançar.Click

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
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text

                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Lqbase.Connection.ConnectionString = ConecctionServer

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'verifica se usuario master ja existe

                        Dim BuscaBase = From Base In Lqbase.Login
                                        Where Base.Nick.ToString.EndsWith("master")
                                        Select Base.IdLogin

                        If BuscaBase.Count = 0 Then

                            PnnPrincipais.Visible = True
                            PnnPrincipais.Dock = DockStyle.Fill

                            PnnAcesso.Visible = False

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False

                            Col = True

                        Else

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False
                            BtnProximo.PerformClick()

                        End If

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Lqbase.Connection.ConnectionString = ConecctionServer

                        'verifica se usuario master ja existe

                        Dim BuscaBase = From Base In Lqbase.Login
                                        Where Base.Nick.ToString.EndsWith("master")
                                        Select Base.IdLogin

                        If BuscaBase.Count = 0 Then

                            PnnPrincipais.Visible = True
                            PnnPrincipais.Dock = DockStyle.Fill

                            PnnAcesso.Visible = False

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False

                            Col = True

                        Else

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False
                            BtnProximo.PerformClick()

                        End If

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
                        "Instancia:" & TxtNomeInstancia.Text

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Lqbase.Connection.ConnectionString = ConecctionServer

                        'verifica se usuario master ja existe

                        Dim BuscaBase = From Base In Lqbase.Login
                                        Where Base.Nick.ToString.EndsWith("master")
                                        Select Base.IdLogin

                        If BuscaBase.Count = 0 Then

                            PnnPrincipais.Visible = True
                            PnnPrincipais.Dock = DockStyle.Fill

                            PnnAcesso.Visible = False

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False

                            Col = True

                        Else

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False
                            BtnProximo.PerformClick()

                        End If

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)
                        Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text

                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        Dim Instancia As String

                        If TxtNomeInstancia.Text <> "" Then

                            Instancia = "\" & TxtNomeInstancia.Text

                        End If

                        Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Lqbase.Connection.ConnectionString = ConecctionServer

                        'verifica se usuario master ja existe

                        Dim BuscaBase = From Base In Lqbase.Login
                                        Where Base.Nick.ToString.EndsWith("master")
                                        Select Base.IdLogin

                        If BuscaBase.Count = 0 Then

                            PnnPrincipais.Visible = True
                            PnnPrincipais.Dock = DockStyle.Fill

                            PnnAcesso.Visible = False

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False

                            Col = True

                        Else

                            BtnProximo.Visible = True
                            BtnAvançar.Visible = False
                            BtnProximo.PerformClick()

                        End If

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
                    "Instancia:" & TxtNomeInstancia.Text

                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)

                    Dim Instancia As String

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    Lqbase.Connection.ConnectionString = ConecctionServer

                    'verifica se usuario master ja existe

                    Dim BuscaBase = From Base In Lqbase.Login
                                    Where Base.Nick.ToString.EndsWith("master")
                                    Select Base.IdLogin

                    If BuscaBase.Count = 0 Then

                        PnnPrincipais.Visible = True
                        PnnPrincipais.Dock = DockStyle.Fill

                        PnnAcesso.Visible = False

                        BtnProximo.Visible = True
                        BtnAvançar.Visible = False

                        Col = True

                    Else

                        BtnProximo.Visible = True
                        BtnAvançar.Visible = False
                        BtnProximo.PerformClick()

                    End If

                End Using
            Else
                File.Delete(Arquivo)
                ' Cria um arquivo para escrita
                Using sw As FileStream = File.Create(Arquivo)
                    Dim TextoString As String = "IP:" & TxtIp.Text & Chr(13) &
                        "Porta:" & TxtPortaSQL.Text & Chr(13) &
                    "Instancia:" & TxtNomeInstancia.Text

                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)

                    Dim Instancia As String

                    If TxtNomeInstancia.Text <> "" Then

                        Instancia = "\" & TxtNomeInstancia.Text

                    End If

                    Dim ConecctionServer As String = "Data Source=" & TxtIp.Text & Instancia & ", " & TxtPortaSQL.Text & ";Initial Catalog= Base;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                    Lqbase.Connection.ConnectionString = ConecctionServer

                    'verifica se usuario master ja existe

                    Dim BuscaBase = From Base In Lqbase.Login
                                    Where Base.Nick.ToString.EndsWith("master")
                                    Select Base.IdLogin

                    If BuscaBase.Count = 0 Then

                        PnnPrincipais.Visible = True
                        PnnPrincipais.Dock = DockStyle.Fill

                        PnnAcesso.Visible = False

                        BtnProximo.Visible = True
                        BtnAvançar.Visible = False

                        Col = True

                    Else

                        BtnProximo.Visible = True
                        BtnAvançar.Visible = False
                        BtnProximo.PerformClick()

                    End If

                End Using
                Return

            End If

        End If

    End Sub

    Private Sub FrmPassoAPasso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'verifica se arquivo de iniciallização existe

        If IO.Directory.Exists("C:\Iara\Ini") Then

            'verifica arquivo

            If IO.File.Exists("C:\Iara\Ini\Initial.ini") Then

                'cria arquivo de inicialização

                Dim Arquivo As String = "C:\Iara\Ini\Initial.ini"

                'verifica se o arquivo existe
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
                                If TxtIp.Text = "" Then

                                    TxtIp.Text = (palavra0)

                                ElseIf TxtPortaSQL.Text = "" And TxtIp.Text <> "" Then

                                    TxtPortaSQL.Text = (palavra0)

                                ElseIf TxtNomeInstancia.Text = "" And TxtPortaSQL.Text <> "" Then

                                    TxtNomeInstancia.Text = (palavra0)

                                End If
                            End If

                        Next

                    Next

                    BtnAvançar.PerformClick()

                    Return

                End If

            End If

        End If

    End Sub
End Class