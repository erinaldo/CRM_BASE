Imports System.IO

Public Class FrmAtualizar
    Private Sub FrmAtualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Dim Vlr_Espera As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If Vlr_Espera = 1 Then
            Timer1.Enabled = False

            Me.Refresh()
            Me.Focus()

            'verifica pasta de atualização

            For Each path In IO.Directory.GetDirectories("C:\Iara\Uteis\UPDATE").ToList

                For Each itens In IO.Directory.GetFiles(path.ToString)

                    DtItensBDD.Rows.Add(ImageList1.Images(3), itens.ToString, "Aguardando rotina")
                    Me.Refresh()

                Next

            Next

            Dim IP As String
            Dim Instancia As String
            Dim Porta As String

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

                                        If palavra0 = "" Then

                                            _PortaSql = 0

                                        End If

                                    ElseIf _INstancia = "" And _PortaSql <> "" And _IP <> "" Then

                                        _INstancia = (palavra0)

                                    End If

                                    If _IP.EndsWith("U") Then

                                        _IP = _IP.Remove(_IP.Length - 1, 1)

                                    End If

                                    IP = _IP
                                    Porta = _PortaSql
                                    Instancia = _INstancia

                                End If

                            Next

                        Next

                    End If

                End If

            End If


            Dim _Porta As String = ""

            If Porta <> "" Or Porta = 0 Then

                _Porta = "," & Porta

            End If


            Instancia = "\" & Instancia

            'roda atualizadores
            Dim Err As String

            For Each row As DataGridViewRow In DtItensBDD.Rows

                row.Cells(0).Value = ImageList1.Images(2)
                DtItensBDD.Refresh()

                Dim SQLString As String = IO.File.OpenText(row.Cells(1).Value.ToString).ReadToEnd()

                Dim Tabela As String

                Dim str As String = SQLString
                Dim separador As String = "!"
                Dim palavras As String() = str.Split(separador)
                Dim LstPalavras As New ListBox
                Dim palavra As String

                Dim _IP As String = Form1.TxtIp.Text
                Dim _PortaSql As String = Form1.TxtPortaSQL.Text
                Dim _INstancia As String = Form1.TxtNomeInstancia.Text

                Dim _PortaSql_exe As String = ""

                If _PortaSql <> "" And _PortaSql > 0 Then

                    _PortaSql_exe = "," & _PortaSql

                End If

                _INstancia = "\" & _INstancia

                For Each palavra In palavras
                    LstPalavras.Items.Add(palavra)
                Next

                Dim Script As String
                If LstPalavras.Items.Count > 1 Then
                    Tabela = LstPalavras.Items(0).ToString
                    Script = LstPalavras.Items(1).ToString
                Else
                    Tabela = "Master"
                    Script = LstPalavras.Items(0).ToString
                End If

                'Try

                Dim ConecctionServer As String = ""

                ConecctionServer = "Data Source=" & _IP & _INstancia & _PortaSql_exe & ";Initial Catalog=" & Tabela & ";Persist Security Info=True;User ID=sqlsystem;Password=1q2w3e4r*"

                'carrega 

                Using Conexão As New SqlClient.SqlConnection(ConecctionServer)

                    Dim ConnState As Boolean = False

                    'MsgBox(ConnState & " " & ConecctionServer)

                    Try

                        Dim SQLCommand1 As New SqlClient.SqlCommand(Script, Conexão)

                        Conexão.Open()

                        SQLCommand1.ExecuteNonQuery()

                        row.Cells(0).Value = ImageList1.Images(0)
                        row.Cells(2).Value = "Sucesso"

                        Conexão.Close()

                        'row.Visible = False

                    Catch ex As Exception

                        'verifica se o status do erro é passivel de sucesso

                        Dim Success As Boolean = False

                        If ex.Message.ToString.StartsWith("Os nomes de colunas em cada tabela devem ser exclusivos") Then

                            row.Cells(0).Value = ImageList1.Images(0)
                            row.Cells(2).Value = "Sucesso"
                            Success = True

                            Conexão.Close()

                        ElseIf ex.Message.ToString.StartsWith("Já existe") Then

                            row.Cells(0).Value = ImageList1.Images(0)
                            row.Cells(2).Value = "Sucesso"
                            Success = True

                            Conexão.Close()

                        End If

                        If Success = False Then

                            row.Cells(0).Value = ImageList1.Images(1)
                            row.Cells(2).Value = ex.Message & " " & ConecctionServer

                            Err += 1
                            Conexão.Close()

                        End If

                    End Try

                    'adiciona pra ver se onsegue inserir


                End Using

                row.Selected = True

                DtItensBDD.Refresh()

                DtItensBDD.CurrentCell = DtItensBDD(0, row.Index)

            Next

            If Err = 0 Then
                End
            Else
                If (MsgBox("O processamento dos lotes foi processado, porém foram encontrados " &
                       Err & " erros, deseja vê-los agora?", MsgBoxStyle.YesNo
                       ) = DialogResult.No) Then

                    End

                Else

                    PnnEnd.Visible = True

                End If
            End If

        Else
            Vlr_Espera += 1
        End If

    End Sub

    Private Sub DtItensBDD_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensBDD.CellContentClick

    End Sub

    Private Sub DtItensBDD_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtItensBDD.CellDoubleClick

        FrmStatusErro.LblStt.Text = DtItensBDD.Rows(e.RowIndex).Cells(2).Value
        FrmStatusErro.Show(Me)

    End Sub
End Class