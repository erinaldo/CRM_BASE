Imports System.IO
Imports System.Net.Sockets
Imports System.Text

Public Class FrmConfigRede
    Private Sub BttFechar_Click(sender As Object, e As EventArgs) Handles BttFechar.Click

        Me.Close()

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

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

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

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                        End If

                        Conexão.Close()

                    Catch ex As Exception

                        ConecctionServer = "Data Source=" & TxtIp.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                        Try

                            Conexão.Open()

                            If Conexão.State = ConnectionState.Open Then

                                LblConexão.Text = "A conexão foi estabelecida com o servidor."

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

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

                        Else

                            LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

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

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

                            End If

                            Conexão.Close()

                        Catch ex As Exception

                            ConecctionServer = "Data Source=" & TxtIp.Text & "," & TxtPortaSQL.Text & ";Initial Catalog= Master;Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                            Try

                                Conexão.Open()

                                If Conexão.State = ConnectionState.Open Then

                                    LblConexão.Text = "A conexão foi estabelecida com o servidor."

                                Else

                                    LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

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

                            Else

                                LblConexão.Text = "A conexão não pode ser estabelecida com o servidor."

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

    Private Sub BttSalvar_Click(sender As Object, e As EventArgs) Handles BttSalvar.Click

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

                        Dim EstaMaquina As String = ""

                        If CkEsteComputador.Checked = True Then
                            EstaMaquina = "U"
                        End If

                        Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
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

                        sw.Close()

                        'FrmLogin.Timer1.Enabled = True
                        FrmLogin.C = 3

                        Me.Close()

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)

                        Dim EstaMaquina As String = ""

                        If CkEsteComputador.Checked = True Then
                            EstaMaquina = "U"
                        End If

                        Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text


                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'FrmLogin.Timer1.Enabled = True
                        FrmLogin.C = 3

                        Me.Close()

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

                        Dim EstaMaquina As String = ""

                        If CkEsteComputador.Checked = True Then
                            EstaMaquina = "U"
                        End If

                        Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text


                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'FrmLogin.Timer1.Enabled = True
                        FrmLogin.C = 3

                        Me.Close()

                    End Using
                Else
                    File.Delete(Arquivo)
                    ' Cria um arquivo para escrita
                    Using sw As FileStream = File.Create(Arquivo)

                        Dim EstaMaquina As String = ""

                        If CkEsteComputador.Checked = True Then
                            EstaMaquina = "U"
                        End If

                        Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text


                        Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                        sw.Write(texto, 0, texto.Length)

                        'FrmLogin.Timer1.Enabled = True
                        FrmLogin.C = 3

                        Me.Close()

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

                    Dim EstaMaquina As String = ""

                    If CkEsteComputador.Checked = True Then
                        EstaMaquina = "U"
                    End If

                    Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text


                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)

                    'FrmLogin.Timer1.Enabled = True
                    FrmLogin.C = 3

                    Me.Close()

                End Using
            Else
                File.Delete(Arquivo)
                ' Cria um arquivo para escrita
                Using sw As FileStream = File.Create(Arquivo)

                    Dim EstaMaquina As String = ""

                    If CkEsteComputador.Checked = True Then
                        EstaMaquina = "U"
                    End If

                    Dim TextoString As String = "IP:" & TxtIp.Text & EstaMaquina & Chr(13) &
                            "Porta:" & TxtPortaSQL.Text & Chr(13) &
                        "Instancia:" & TxtNomeInstancia.Text


                    Dim texto As Byte() = New UTF8Encoding(True).GetBytes(TextoString)
                    sw.Write(texto, 0, texto.Length)

                    'FrmLogin.Timer1.Enabled = True
                    FrmLogin.C = 3

                    Me.Close()

                End Using
                Return

            End If

        End If

    End Sub

    Private Sub FrmConfigRede_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class