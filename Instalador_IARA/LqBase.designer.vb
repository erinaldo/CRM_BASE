﻿'------------------------------------------------------------------------------
' <auto-generated>
'     O código foi gerado por uma ferramenta.
'     Versão de Tempo de Execução:4.0.30319.42000
'
'     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
'     o código for gerado novamente.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="Base")>  _
Partial Public Class LqBaseDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertChavesInterno(instance As ChavesInterno)
    End Sub
  Partial Private Sub UpdateChavesInterno(instance As ChavesInterno)
    End Sub
  Partial Private Sub DeleteChavesInterno(instance As ChavesInterno)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.Instalador_IARA.My.MySettings.Default.BaseConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property ChavesInterno() As System.Data.Linq.Table(Of ChavesInterno)
		Get
			Return Me.GetTable(Of ChavesInterno)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.InsereChavesInterno")>  _
	Public Function InsereChavesInterno(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdProduto", DbType:="NText")> ByVal idProduto As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="NumeroDaChave", DbType:="NText")> ByVal numeroDaChave As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="ValidadeDias", DbType:="Int")> ByVal validadeDias As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="DataLiberacao", DbType:="Date")> ByVal dataLiberacao As System.Nullable(Of Date), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="HoraLiberacao", DbType:="Time")> ByVal horaLiberacao As System.Nullable(Of System.TimeSpan), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="DataAtivacao", DbType:="Date")> ByVal dataAtivacao As System.Nullable(Of Date), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="HoraAtivacao", DbType:="Time")> ByVal horaAtivacao As System.Nullable(Of System.TimeSpan), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="CPNJ_CPF", DbType:="NText")> ByVal cPNJ_CPF As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdClienteIara", DbType:="Int")> ByVal idClienteIara As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IpInt", DbType:="NText")> ByVal ipInt As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="MAC", DbType:="NText")> ByVal mAC As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IpExt", DbType:="NText")> ByVal ipExt As String) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idProduto, numeroDaChave, validadeDias, dataLiberacao, horaLiberacao, dataAtivacao, horaAtivacao, cPNJ_CPF, idClienteIara, ipInt, mAC, ipExt)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AtualizaDadosChaveInterno")>  _
	Public Function AtualizaDadosChaveInterno(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdChave", DbType:="Int")> ByVal idChave As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdIPInt", DbType:="NText")> ByVal idIPInt As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="MAC", DbType:="NText")> ByVal mAC As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IpExt", DbType:="NText")> ByVal ipExt As String) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idChave, idIPInt, mAC, ipExt)
		Return CType(result.ReturnValue,Integer)
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.ChavesInterno")>  _
Partial Public Class ChavesInterno
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IdChave As Integer
	
	Private _IdProduto As String
	
	Private _NumeroDaChave As String
	
	Private _ValidadeDias As System.Nullable(Of Integer)
	
	Private _DataLiberacaoo As System.Nullable(Of Date)
	
	Private _HoraLiberacao As System.Nullable(Of System.TimeSpan)
	
	Private _DataAtivacao As System.Nullable(Of Date)
	
	Private _HoraAtivacao As System.Nullable(Of System.TimeSpan)
	
	Private _CNPJ_CPF As String
	
	Private _IdClienteIARA As System.Nullable(Of Integer)
	
	Private _IPInt As String
	
	Private _MAC As String
	
	Private _IpExt As String
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIdChaveChanging(value As Integer)
    End Sub
    Partial Private Sub OnIdChaveChanged()
    End Sub
    Partial Private Sub OnIdProdutoChanging(value As String)
    End Sub
    Partial Private Sub OnIdProdutoChanged()
    End Sub
    Partial Private Sub OnNumeroDaChaveChanging(value As String)
    End Sub
    Partial Private Sub OnNumeroDaChaveChanged()
    End Sub
    Partial Private Sub OnValidadeDiasChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnValidadeDiasChanged()
    End Sub
    Partial Private Sub OnDataLiberacaooChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnDataLiberacaooChanged()
    End Sub
    Partial Private Sub OnHoraLiberacaoChanging(value As System.Nullable(Of System.TimeSpan))
    End Sub
    Partial Private Sub OnHoraLiberacaoChanged()
    End Sub
    Partial Private Sub OnDataAtivacaoChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnDataAtivacaoChanged()
    End Sub
    Partial Private Sub OnHoraAtivacaoChanging(value As System.Nullable(Of System.TimeSpan))
    End Sub
    Partial Private Sub OnHoraAtivacaoChanged()
    End Sub
    Partial Private Sub OnCNPJ_CPFChanging(value As String)
    End Sub
    Partial Private Sub OnCNPJ_CPFChanged()
    End Sub
    Partial Private Sub OnIdClienteIARAChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIdClienteIARAChanged()
    End Sub
    Partial Private Sub OnIPIntChanging(value As String)
    End Sub
    Partial Private Sub OnIPIntChanged()
    End Sub
    Partial Private Sub OnMACChanging(value As String)
    End Sub
    Partial Private Sub OnMACChanged()
    End Sub
    Partial Private Sub OnIpExtChanging(value As String)
    End Sub
    Partial Private Sub OnIpExtChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdChave", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IdChave() As Integer
		Get
			Return Me._IdChave
		End Get
		Set
			If ((Me._IdChave = value)  _
						= false) Then
				Me.OnIdChaveChanging(value)
				Me.SendPropertyChanging
				Me._IdChave = value
				Me.SendPropertyChanged("IdChave")
				Me.OnIdChaveChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdProduto", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property IdProduto() As String
		Get
			Return Me._IdProduto
		End Get
		Set
			If (String.Equals(Me._IdProduto, value) = false) Then
				Me.OnIdProdutoChanging(value)
				Me.SendPropertyChanging
				Me._IdProduto = value
				Me.SendPropertyChanged("IdProduto")
				Me.OnIdProdutoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_NumeroDaChave", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property NumeroDaChave() As String
		Get
			Return Me._NumeroDaChave
		End Get
		Set
			If (String.Equals(Me._NumeroDaChave, value) = false) Then
				Me.OnNumeroDaChaveChanging(value)
				Me.SendPropertyChanging
				Me._NumeroDaChave = value
				Me.SendPropertyChanged("NumeroDaChave")
				Me.OnNumeroDaChaveChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ValidadeDias", DbType:="Int")>  _
	Public Property ValidadeDias() As System.Nullable(Of Integer)
		Get
			Return Me._ValidadeDias
		End Get
		Set
			If (Me._ValidadeDias.Equals(value) = false) Then
				Me.OnValidadeDiasChanging(value)
				Me.SendPropertyChanging
				Me._ValidadeDias = value
				Me.SendPropertyChanged("ValidadeDias")
				Me.OnValidadeDiasChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DataLiberacaoo", DbType:="Date")>  _
	Public Property DataLiberacaoo() As System.Nullable(Of Date)
		Get
			Return Me._DataLiberacaoo
		End Get
		Set
			If (Me._DataLiberacaoo.Equals(value) = false) Then
				Me.OnDataLiberacaooChanging(value)
				Me.SendPropertyChanging
				Me._DataLiberacaoo = value
				Me.SendPropertyChanged("DataLiberacaoo")
				Me.OnDataLiberacaooChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_HoraLiberacao", DbType:="Time")>  _
	Public Property HoraLiberacao() As System.Nullable(Of System.TimeSpan)
		Get
			Return Me._HoraLiberacao
		End Get
		Set
			If (Me._HoraLiberacao.Equals(value) = false) Then
				Me.OnHoraLiberacaoChanging(value)
				Me.SendPropertyChanging
				Me._HoraLiberacao = value
				Me.SendPropertyChanged("HoraLiberacao")
				Me.OnHoraLiberacaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DataAtivacao", DbType:="Date")>  _
	Public Property DataAtivacao() As System.Nullable(Of Date)
		Get
			Return Me._DataAtivacao
		End Get
		Set
			If (Me._DataAtivacao.Equals(value) = false) Then
				Me.OnDataAtivacaoChanging(value)
				Me.SendPropertyChanging
				Me._DataAtivacao = value
				Me.SendPropertyChanged("DataAtivacao")
				Me.OnDataAtivacaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_HoraAtivacao", DbType:="Time")>  _
	Public Property HoraAtivacao() As System.Nullable(Of System.TimeSpan)
		Get
			Return Me._HoraAtivacao
		End Get
		Set
			If (Me._HoraAtivacao.Equals(value) = false) Then
				Me.OnHoraAtivacaoChanging(value)
				Me.SendPropertyChanging
				Me._HoraAtivacao = value
				Me.SendPropertyChanged("HoraAtivacao")
				Me.OnHoraAtivacaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CNPJ_CPF", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property CNPJ_CPF() As String
		Get
			Return Me._CNPJ_CPF
		End Get
		Set
			If (String.Equals(Me._CNPJ_CPF, value) = false) Then
				Me.OnCNPJ_CPFChanging(value)
				Me.SendPropertyChanging
				Me._CNPJ_CPF = value
				Me.SendPropertyChanged("CNPJ_CPF")
				Me.OnCNPJ_CPFChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdClienteIARA", DbType:="Int")>  _
	Public Property IdClienteIARA() As System.Nullable(Of Integer)
		Get
			Return Me._IdClienteIARA
		End Get
		Set
			If (Me._IdClienteIARA.Equals(value) = false) Then
				Me.OnIdClienteIARAChanging(value)
				Me.SendPropertyChanging
				Me._IdClienteIARA = value
				Me.SendPropertyChanged("IdClienteIARA")
				Me.OnIdClienteIARAChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IPInt", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property IPInt() As String
		Get
			Return Me._IPInt
		End Get
		Set
			If (String.Equals(Me._IPInt, value) = false) Then
				Me.OnIPIntChanging(value)
				Me.SendPropertyChanging
				Me._IPInt = value
				Me.SendPropertyChanged("IPInt")
				Me.OnIPIntChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MAC", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property MAC() As String
		Get
			Return Me._MAC
		End Get
		Set
			If (String.Equals(Me._MAC, value) = false) Then
				Me.OnMACChanging(value)
				Me.SendPropertyChanging
				Me._MAC = value
				Me.SendPropertyChanged("MAC")
				Me.OnMACChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IpExt", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property IpExt() As String
		Get
			Return Me._IpExt
		End Get
		Set
			If (String.Equals(Me._IpExt, value) = false) Then
				Me.OnIpExtChanging(value)
				Me.SendPropertyChanging
				Me._IpExt = value
				Me.SendPropertyChanged("IpExt")
				Me.OnIpExtChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class
