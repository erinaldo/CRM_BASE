Public Class ClsSintegraRF
    Public Class AtividadePrincipal
        Public Property text As String
        Public Property code As String
    End Class

    Public Class AtividadesSecundaria
        Public Property text As String
        Public Property code As String
    End Class

    Public Class Qsa
        Public Property qual As String
        Public Property qual_rep_legal As String
        Public Property nome_rep_legal As String
        Public Property pais_origem As String
        Public Property nome As String
    End Class

    Public Class Ibge
        Public Property codigo_municipio As String
        Public Property codigo_uf As String
    End Class

    Public Class CnpjsDoGrupo
        Public Property cnpj As String
        Public Property uf As String
        Public Property tipo As String
    End Class

    Public Class Root
        Public Property code As String
        Public Property status As String
        Public Property message As String
        Public Property atividade_principal As List(Of AtividadePrincipal)
        Public Property data_situacao As String
        Public Property complemento As String
        Public Property nome As String
        Public Property uf As String
        Public Property telefone As String
        Public Property email As String
        Public Property atividades_secundarias As List(Of AtividadesSecundaria)
        Public Property qsa As List(Of Qsa)
        Public Property situacao As String
        Public Property bairro As String
        Public Property tipo_logradouro As Object
        Public Property logradouro As String
        Public Property numero As String
        Public Property cep As String
        Public Property municipio As String
        Public Property abertura As String
        Public Property sigla_natureza_juridica As String
        Public Property natureza_juridica As String
        Public Property cnpj As String
        Public Property ultima_atualizacao As String
        Public Property tipo As String
        Public Property fantasia As String
        Public Property efr As String
        Public Property motivo_situacao As String
        Public Property situacao_especial As String
        Public Property data_situacao_especial As String
        Public Property capital_social As String
        Public Property extra As Object
        Public Property porte As String
        Public Property ibge As Ibge
        Public Property cnpjs_do_grupo As List(Of CnpjsDoGrupo)
    End Class

End Class
