Imports Microsoft.Extensions.Configuration
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt
Imports System.Text
Imports System.Security.Claims
Imports System.Collections.Generic

Public Class JwtGenerator
    Private ReadOnly _config As IConfiguration
    Private _tokenOptions As TokenOptions
    Private _expirationDate As Date

    Public Sub New(config As IConfiguration)
        _config = config
        _tokenOptions = _config.GetSection("TokenOptions").Get(Of TokenOptions)()
    End Sub

    Public Function GenerateAccessToken() As AccessToken
        _expirationDate = DateTime.Now.AddMinutes(_tokenOptions.Expiration)

        Dim sKey As New SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey))
        Dim sCredentials As New SigningCredentials(sKey, SecurityAlgorithms.HmacSha256)

        Dim securityToken As New JwtSecurityToken(
            issuer:=_tokenOptions.Issuer,
            audience:=_tokenOptions.Audience,
            expires:=_expirationDate,
            notBefore:=DateTime.Now,
            claims:=New List(Of Claim) From {
                New Claim("RoleId", "1"),
                New Claim("RoleId", "2"),
                New Claim("RoleId", "3")
            },
            signingCredentials:=sCredentials
        )

        Dim jwtHandler As New JwtSecurityTokenHandler()
        Dim token As String = jwtHandler.WriteToken(securityToken)

        Return New AccessToken() With {
            .Token = token,
            .ExpirationDate = _expirationDate,
            .Claims = Nothing
        }
    End Function
End Class

