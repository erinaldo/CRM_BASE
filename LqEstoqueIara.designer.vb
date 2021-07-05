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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="EstoqueDistribuidorOnLine")>  _
Partial Public Class LqEstoqueIaraDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertCardapioIProdutosARA(instance As CardapioIProdutosARA)
    End Sub
  Partial Private Sub UpdateCardapioIProdutosARA(instance As CardapioIProdutosARA)
    End Sub
  Partial Private Sub DeleteCardapioIProdutosARA(instance As CardapioIProdutosARA)
    End Sub
  Partial Private Sub InsertCaracteristicasProdutoCardapio(instance As CaracteristicasProdutoCardapio)
    End Sub
  Partial Private Sub UpdateCaracteristicasProdutoCardapio(instance As CaracteristicasProdutoCardapio)
    End Sub
  Partial Private Sub DeleteCaracteristicasProdutoCardapio(instance As CaracteristicasProdutoCardapio)
    End Sub
  Partial Private Sub InsertImagensProdutosIara(instance As ImagensProdutosIara)
    End Sub
  Partial Private Sub UpdateImagensProdutosIara(instance As ImagensProdutosIara)
    End Sub
  Partial Private Sub DeleteImagensProdutosIara(instance As ImagensProdutosIara)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.CRM_BASE.My.MySettings.Default.EstoqueDistribuidorOnLineConnectionString2, mappingSource)
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
	
	Public ReadOnly Property CardapioIProdutosARA() As System.Data.Linq.Table(Of CardapioIProdutosARA)
		Get
			Return Me.GetTable(Of CardapioIProdutosARA)
		End Get
	End Property
	
	Public ReadOnly Property CaracteristicasProdutoCardapio() As System.Data.Linq.Table(Of CaracteristicasProdutoCardapio)
		Get
			Return Me.GetTable(Of CaracteristicasProdutoCardapio)
		End Get
	End Property
	
	Public ReadOnly Property ImagensProdutosIara() As System.Data.Linq.Table(Of ImagensProdutosIara)
		Get
			Return Me.GetTable(Of ImagensProdutosIara)
		End Get
	End Property
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.InsereProdutoBaseIara")>  _
	Public Function InsereProdutoBaseIara( _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdClienteIARA", DbType:="Int")> ByVal idClienteIARA As System.Nullable(Of Integer),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdCodProdInterno", DbType:="Int")> ByVal idCodProdInterno As System.Nullable(Of Integer),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Descricao", DbType:="NText")> ByVal descricao As String,  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="DataPublicacao", DbType:="Date")> ByVal dataPublicacao As System.Nullable(Of Date),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="HoraPublicacao", DbType:="Time")> ByVal horaPublicacao As System.Nullable(Of System.TimeSpan),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="PartNumber", DbType:="NText")> ByVal partNumber As String,  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="ValorUnitario", DbType:="Money")> ByVal valorUnitario As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="QtdadePublicada", DbType:="Money")> ByVal qtdadePublicada As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="MInimoPorVenda", DbType:="Int")> ByVal mInimoPorVenda As System.Nullable(Of Integer),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="MaximoPorVenda", DbType:="Int")> ByVal maximoPorVenda As System.Nullable(Of Integer),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="PrazoEntrega", DbType:="Int")> ByVal prazoEntrega As System.Nullable(Of Integer),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Altura", DbType:="Money")> ByVal altura As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Largura", DbType:="Money")> ByVal largura As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Profundidade", DbType:="Money")> ByVal profundidade As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Peso", DbType:="Money")> ByVal peso As System.Nullable(Of Decimal),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="UnidadeVenda", DbType:="NText")> ByVal unidadeVenda As String,  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Status", DbType:="Bit")> ByVal status As System.Nullable(Of Boolean),  _
				<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="TTEstoque", DbType:="Int")> ByVal tTEstoque As System.Nullable(Of Integer)) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idClienteIARA, idCodProdInterno, descricao, dataPublicacao, horaPublicacao, partNumber, valorUnitario, qtdadePublicada, mInimoPorVenda, maximoPorVenda, prazoEntrega, altura, largura, profundidade, peso, unidadeVenda, status, tTEstoque)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AtualizaDadosProdutoIara")>  _
	Public Function AtualizaDadosProdutoIara(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdItemEstoqueIara", DbType:="Int")> ByVal idItemEstoqueIara As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Altura", DbType:="Money")> ByVal altura As System.Nullable(Of Decimal), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Largura", DbType:="Money")> ByVal largura As System.Nullable(Of Decimal), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Profundidade", DbType:="Money")> ByVal profundidade As System.Nullable(Of Decimal), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Peso", DbType:="Money")> ByVal peso As System.Nullable(Of Decimal), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Status", DbType:="Bit")> ByVal status As System.Nullable(Of Boolean), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="TTEstoque", DbType:="Int")> ByVal tTEstoque As System.Nullable(Of Integer)) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idItemEstoqueIara, altura, largura, profundidade, peso, status, tTEstoque)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.AtualizaDadosQtdadeProdutoIara")>  _
	Public Function AtualizaDadosQtdadeProdutoIara(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdItemEstoqueIara", DbType:="Int")> ByVal idItemEstoqueIara As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Qtdade", DbType:="Int")> ByVal qtdade As System.Nullable(Of Integer)) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idItemEstoqueIara, qtdade)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.InsereCaracteristicaProdutoBaseIara")>  _
	Public Function InsereCaracteristicaProdutoBaseIara(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdItemProdtoIara", DbType:="Int")> ByVal idItemProdtoIara As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Descricao", DbType:="NText")> ByVal descricao As String) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idItemProdtoIara, descricao)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.InsereImagemProdutoBaseIara")>  _
	Public Function InsereImagemProdutoBaseIara(<Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdProduto", DbType:="Int")> ByVal idProduto As System.Nullable(Of Integer), <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="Imagem", DbType:="Image")> ByVal imagem As System.Data.Linq.Binary) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), idProduto, imagem)
		Return CType(result.ReturnValue,Integer)
	End Function
	
	<Global.System.Data.Linq.Mapping.FunctionAttribute(Name:="dbo.InsereCaracteristicaProdutoBaseIara")>  _
	Public Function InsereCaracteristicaProdutoBaseIara1(<Global.System.Data.Linq.Mapping.ParameterAttribute(DbType:="NText")> ByVal descricao As String, <Global.System.Data.Linq.Mapping.ParameterAttribute(Name:="IdItemCardapio", DbType:="Int")> ByVal idItemCardapio As System.Nullable(Of Integer)) As Integer
		Dim result As IExecuteResult = Me.ExecuteMethodCall(Me, CType(MethodInfo.GetCurrentMethod,MethodInfo), descricao, idItemCardapio)
		Return CType(result.ReturnValue,Integer)
	End Function
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.CardapioIProdutosARA")>  _
Partial Public Class CardapioIProdutosARA
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IdItemEstoqueIARA As Integer
	
	Private _IdClienteIARA As System.Nullable(Of Integer)
	
	Private _IdCodProdInterno As System.Nullable(Of Integer)
	
	Private _Descricao As String
	
	Private _DataPublicacao As System.Nullable(Of Date)
	
	Private _HoraPublicacao As System.Nullable(Of System.TimeSpan)
	
	Private _PartNumber As String
	
	Private _ValorUnitario As System.Nullable(Of Decimal)
	
	Private _QtdadePublicada As System.Nullable(Of Decimal)
	
	Private _MInimoPorVenda As System.Nullable(Of Integer)
	
	Private _MaximoPorVenda As System.Nullable(Of Integer)
	
	Private _PrazoEntrega As System.Nullable(Of Integer)
	
	Private _Altura As System.Nullable(Of Decimal)
	
	Private _Largura As System.Nullable(Of Decimal)
	
	Private _Profundidade As System.Nullable(Of Decimal)
	
	Private _Peso As System.Nullable(Of Decimal)
	
	Private _UnidadeVenda As String
	
	Private _Status As System.Nullable(Of Boolean)
	
	Private _TTEstoque As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIdItemEstoqueIARAChanging(value As Integer)
    End Sub
    Partial Private Sub OnIdItemEstoqueIARAChanged()
    End Sub
    Partial Private Sub OnIdClienteIARAChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIdClienteIARAChanged()
    End Sub
    Partial Private Sub OnIdCodProdInternoChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIdCodProdInternoChanged()
    End Sub
    Partial Private Sub OnDescricaoChanging(value As String)
    End Sub
    Partial Private Sub OnDescricaoChanged()
    End Sub
    Partial Private Sub OnDataPublicacaoChanging(value As System.Nullable(Of Date))
    End Sub
    Partial Private Sub OnDataPublicacaoChanged()
    End Sub
    Partial Private Sub OnHoraPublicacaoChanging(value As System.Nullable(Of System.TimeSpan))
    End Sub
    Partial Private Sub OnHoraPublicacaoChanged()
    End Sub
    Partial Private Sub OnPartNumberChanging(value As String)
    End Sub
    Partial Private Sub OnPartNumberChanged()
    End Sub
    Partial Private Sub OnValorUnitarioChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnValorUnitarioChanged()
    End Sub
    Partial Private Sub OnQtdadePublicadaChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnQtdadePublicadaChanged()
    End Sub
    Partial Private Sub OnMInimoPorVendaChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnMInimoPorVendaChanged()
    End Sub
    Partial Private Sub OnMaximoPorVendaChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnMaximoPorVendaChanged()
    End Sub
    Partial Private Sub OnPrazoEntregaChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnPrazoEntregaChanged()
    End Sub
    Partial Private Sub OnAlturaChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnAlturaChanged()
    End Sub
    Partial Private Sub OnLarguraChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnLarguraChanged()
    End Sub
    Partial Private Sub OnProfundidadeChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnProfundidadeChanged()
    End Sub
    Partial Private Sub OnPesoChanging(value As System.Nullable(Of Decimal))
    End Sub
    Partial Private Sub OnPesoChanged()
    End Sub
    Partial Private Sub OnUnidadeVendaChanging(value As String)
    End Sub
    Partial Private Sub OnUnidadeVendaChanged()
    End Sub
    Partial Private Sub OnStatusChanging(value As System.Nullable(Of Boolean))
    End Sub
    Partial Private Sub OnStatusChanged()
    End Sub
    Partial Private Sub OnTTEstoqueChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnTTEstoqueChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdItemEstoqueIARA", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IdItemEstoqueIARA() As Integer
		Get
			Return Me._IdItemEstoqueIARA
		End Get
		Set
			If ((Me._IdItemEstoqueIARA = value)  _
						= false) Then
				Me.OnIdItemEstoqueIARAChanging(value)
				Me.SendPropertyChanging
				Me._IdItemEstoqueIARA = value
				Me.SendPropertyChanged("IdItemEstoqueIARA")
				Me.OnIdItemEstoqueIARAChanged
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdCodProdInterno", DbType:="Int")>  _
	Public Property IdCodProdInterno() As System.Nullable(Of Integer)
		Get
			Return Me._IdCodProdInterno
		End Get
		Set
			If (Me._IdCodProdInterno.Equals(value) = false) Then
				Me.OnIdCodProdInternoChanging(value)
				Me.SendPropertyChanging
				Me._IdCodProdInterno = value
				Me.SendPropertyChanged("IdCodProdInterno")
				Me.OnIdCodProdInternoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Descricao", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Descricao() As String
		Get
			Return Me._Descricao
		End Get
		Set
			If (String.Equals(Me._Descricao, value) = false) Then
				Me.OnDescricaoChanging(value)
				Me.SendPropertyChanging
				Me._Descricao = value
				Me.SendPropertyChanged("Descricao")
				Me.OnDescricaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DataPublicacao", DbType:="Date")>  _
	Public Property DataPublicacao() As System.Nullable(Of Date)
		Get
			Return Me._DataPublicacao
		End Get
		Set
			If (Me._DataPublicacao.Equals(value) = false) Then
				Me.OnDataPublicacaoChanging(value)
				Me.SendPropertyChanging
				Me._DataPublicacao = value
				Me.SendPropertyChanged("DataPublicacao")
				Me.OnDataPublicacaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_HoraPublicacao", DbType:="Time")>  _
	Public Property HoraPublicacao() As System.Nullable(Of System.TimeSpan)
		Get
			Return Me._HoraPublicacao
		End Get
		Set
			If (Me._HoraPublicacao.Equals(value) = false) Then
				Me.OnHoraPublicacaoChanging(value)
				Me.SendPropertyChanging
				Me._HoraPublicacao = value
				Me.SendPropertyChanged("HoraPublicacao")
				Me.OnHoraPublicacaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PartNumber", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property PartNumber() As String
		Get
			Return Me._PartNumber
		End Get
		Set
			If (String.Equals(Me._PartNumber, value) = false) Then
				Me.OnPartNumberChanging(value)
				Me.SendPropertyChanging
				Me._PartNumber = value
				Me.SendPropertyChanged("PartNumber")
				Me.OnPartNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_ValorUnitario", DbType:="Money")>  _
	Public Property ValorUnitario() As System.Nullable(Of Decimal)
		Get
			Return Me._ValorUnitario
		End Get
		Set
			If (Me._ValorUnitario.Equals(value) = false) Then
				Me.OnValorUnitarioChanging(value)
				Me.SendPropertyChanging
				Me._ValorUnitario = value
				Me.SendPropertyChanged("ValorUnitario")
				Me.OnValorUnitarioChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_QtdadePublicada", DbType:="Money")>  _
	Public Property QtdadePublicada() As System.Nullable(Of Decimal)
		Get
			Return Me._QtdadePublicada
		End Get
		Set
			If (Me._QtdadePublicada.Equals(value) = false) Then
				Me.OnQtdadePublicadaChanging(value)
				Me.SendPropertyChanging
				Me._QtdadePublicada = value
				Me.SendPropertyChanged("QtdadePublicada")
				Me.OnQtdadePublicadaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MInimoPorVenda", DbType:="Int")>  _
	Public Property MInimoPorVenda() As System.Nullable(Of Integer)
		Get
			Return Me._MInimoPorVenda
		End Get
		Set
			If (Me._MInimoPorVenda.Equals(value) = false) Then
				Me.OnMInimoPorVendaChanging(value)
				Me.SendPropertyChanging
				Me._MInimoPorVenda = value
				Me.SendPropertyChanged("MInimoPorVenda")
				Me.OnMInimoPorVendaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_MaximoPorVenda", DbType:="Int")>  _
	Public Property MaximoPorVenda() As System.Nullable(Of Integer)
		Get
			Return Me._MaximoPorVenda
		End Get
		Set
			If (Me._MaximoPorVenda.Equals(value) = false) Then
				Me.OnMaximoPorVendaChanging(value)
				Me.SendPropertyChanging
				Me._MaximoPorVenda = value
				Me.SendPropertyChanged("MaximoPorVenda")
				Me.OnMaximoPorVendaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PrazoEntrega", DbType:="Int")>  _
	Public Property PrazoEntrega() As System.Nullable(Of Integer)
		Get
			Return Me._PrazoEntrega
		End Get
		Set
			If (Me._PrazoEntrega.Equals(value) = false) Then
				Me.OnPrazoEntregaChanging(value)
				Me.SendPropertyChanging
				Me._PrazoEntrega = value
				Me.SendPropertyChanged("PrazoEntrega")
				Me.OnPrazoEntregaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Altura", DbType:="Money")>  _
	Public Property Altura() As System.Nullable(Of Decimal)
		Get
			Return Me._Altura
		End Get
		Set
			If (Me._Altura.Equals(value) = false) Then
				Me.OnAlturaChanging(value)
				Me.SendPropertyChanging
				Me._Altura = value
				Me.SendPropertyChanged("Altura")
				Me.OnAlturaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Largura", DbType:="Money")>  _
	Public Property Largura() As System.Nullable(Of Decimal)
		Get
			Return Me._Largura
		End Get
		Set
			If (Me._Largura.Equals(value) = false) Then
				Me.OnLarguraChanging(value)
				Me.SendPropertyChanging
				Me._Largura = value
				Me.SendPropertyChanged("Largura")
				Me.OnLarguraChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Profundidade", DbType:="Money")>  _
	Public Property Profundidade() As System.Nullable(Of Decimal)
		Get
			Return Me._Profundidade
		End Get
		Set
			If (Me._Profundidade.Equals(value) = false) Then
				Me.OnProfundidadeChanging(value)
				Me.SendPropertyChanging
				Me._Profundidade = value
				Me.SendPropertyChanged("Profundidade")
				Me.OnProfundidadeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Peso", DbType:="Money")>  _
	Public Property Peso() As System.Nullable(Of Decimal)
		Get
			Return Me._Peso
		End Get
		Set
			If (Me._Peso.Equals(value) = false) Then
				Me.OnPesoChanging(value)
				Me.SendPropertyChanging
				Me._Peso = value
				Me.SendPropertyChanged("Peso")
				Me.OnPesoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_UnidadeVenda", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property UnidadeVenda() As String
		Get
			Return Me._UnidadeVenda
		End Get
		Set
			If (String.Equals(Me._UnidadeVenda, value) = false) Then
				Me.OnUnidadeVendaChanging(value)
				Me.SendPropertyChanging
				Me._UnidadeVenda = value
				Me.SendPropertyChanged("UnidadeVenda")
				Me.OnUnidadeVendaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Status", DbType:="Bit")>  _
	Public Property Status() As System.Nullable(Of Boolean)
		Get
			Return Me._Status
		End Get
		Set
			If (Me._Status.Equals(value) = false) Then
				Me.OnStatusChanging(value)
				Me.SendPropertyChanging
				Me._Status = value
				Me.SendPropertyChanged("Status")
				Me.OnStatusChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TTEstoque", DbType:="Int")>  _
	Public Property TTEstoque() As System.Nullable(Of Integer)
		Get
			Return Me._TTEstoque
		End Get
		Set
			If (Me._TTEstoque.Equals(value) = false) Then
				Me.OnTTEstoqueChanging(value)
				Me.SendPropertyChanging
				Me._TTEstoque = value
				Me.SendPropertyChanged("TTEstoque")
				Me.OnTTEstoqueChanged
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

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.CaracteristicasProdutoCardapio")>  _
Partial Public Class CaracteristicasProdutoCardapio
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IdCaracteristica As Integer
	
	Private _Descricao As String
	
	Private _IditemCardapio As System.Nullable(Of Integer)
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIdCaracteristicaChanging(value As Integer)
    End Sub
    Partial Private Sub OnIdCaracteristicaChanged()
    End Sub
    Partial Private Sub OnDescricaoChanging(value As String)
    End Sub
    Partial Private Sub OnDescricaoChanged()
    End Sub
    Partial Private Sub OnIditemCardapioChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIditemCardapioChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdCaracteristica", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IdCaracteristica() As Integer
		Get
			Return Me._IdCaracteristica
		End Get
		Set
			If ((Me._IdCaracteristica = value)  _
						= false) Then
				Me.OnIdCaracteristicaChanging(value)
				Me.SendPropertyChanging
				Me._IdCaracteristica = value
				Me.SendPropertyChanged("IdCaracteristica")
				Me.OnIdCaracteristicaChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Descricao", DbType:="NText", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Descricao() As String
		Get
			Return Me._Descricao
		End Get
		Set
			If (String.Equals(Me._Descricao, value) = false) Then
				Me.OnDescricaoChanging(value)
				Me.SendPropertyChanging
				Me._Descricao = value
				Me.SendPropertyChanged("Descricao")
				Me.OnDescricaoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IditemCardapio", DbType:="Int")>  _
	Public Property IditemCardapio() As System.Nullable(Of Integer)
		Get
			Return Me._IditemCardapio
		End Get
		Set
			If (Me._IditemCardapio.Equals(value) = false) Then
				Me.OnIditemCardapioChanging(value)
				Me.SendPropertyChanging
				Me._IditemCardapio = value
				Me.SendPropertyChanged("IditemCardapio")
				Me.OnIditemCardapioChanged
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

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.ImagensProdutosIara")>  _
Partial Public Class ImagensProdutosIara
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _IdImagem As Integer
	
	Private _Idproduto As System.Nullable(Of Integer)
	
	Private _Imagem As System.Data.Linq.Binary
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnIdImagemChanging(value As Integer)
    End Sub
    Partial Private Sub OnIdImagemChanged()
    End Sub
    Partial Private Sub OnIdprodutoChanging(value As System.Nullable(Of Integer))
    End Sub
    Partial Private Sub OnIdprodutoChanged()
    End Sub
    Partial Private Sub OnImagemChanging(value As System.Data.Linq.Binary)
    End Sub
    Partial Private Sub OnImagemChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_IdImagem", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property IdImagem() As Integer
		Get
			Return Me._IdImagem
		End Get
		Set
			If ((Me._IdImagem = value)  _
						= false) Then
				Me.OnIdImagemChanging(value)
				Me.SendPropertyChanging
				Me._IdImagem = value
				Me.SendPropertyChanged("IdImagem")
				Me.OnIdImagemChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Idproduto", DbType:="Int")>  _
	Public Property Idproduto() As System.Nullable(Of Integer)
		Get
			Return Me._Idproduto
		End Get
		Set
			If (Me._Idproduto.Equals(value) = false) Then
				Me.OnIdprodutoChanging(value)
				Me.SendPropertyChanging
				Me._Idproduto = value
				Me.SendPropertyChanged("Idproduto")
				Me.OnIdprodutoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Imagem", DbType:="Image", UpdateCheck:=UpdateCheck.Never)>  _
	Public Property Imagem() As System.Data.Linq.Binary
		Get
			Return Me._Imagem
		End Get
		Set
			If (Object.Equals(Me._Imagem, value) = false) Then
				Me.OnImagemChanging(value)
				Me.SendPropertyChanging
				Me._Imagem = value
				Me.SendPropertyChanged("Imagem")
				Me.OnImagemChanged
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
