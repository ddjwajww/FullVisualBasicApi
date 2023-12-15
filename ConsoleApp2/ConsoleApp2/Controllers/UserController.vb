Imports Microsoft.AspNetCore.Mvc
Imports Microsoft.AspNetCore.Authorization
Imports System.Threading.Tasks
Imports Business
Imports Model
Imports infrastructure

<Route("api/[controller]")>
<ApiController>
Public Class UsersController
    Inherits BaseController

    Private ReadOnly _userBs As IUserBs

    Public Sub New(userBs As IUserBs)
        _userBs = userBs
    End Sub

#Region "deneme"
    ''' <summary>
    ''' GetAllUsers
    ''' </summary>
    ''' <returns></returns>
    '<Authorize>
    <HttpGet("GetAllUsers")>
    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of UserGetDto))))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    Public Async Function GetAllUsers() As Task(Of ActionResult)
        Dim response = Await _userBs.GetUsersAsync()
        Return SendResponse(response)
    End Function

#End Region


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of UserGetDto))))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpGet("byfirstname")>
    Public Async Function GetUsersByFullName(<FromQuery> fullName As String) As Task(Of ActionResult)
        Dim response = Await _userBs.GetUsersByFullNameAsync(fullName)
        Return SendResponse(response)
    End Function


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of UserGetDto)))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpGet("{id}")>
    Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
        Dim response = Await _userBs.GetByIdAsync(id)
        Return SendResponse(response)
    End Function


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of User)))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpPost>
    Public Async Function SaveNewUser(<FromBody> dto As UserPostDto) As Task(Of ActionResult)
        Dim response = Await _userBs.InsertAsync(dto)
        Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.UserId}, response.Data)
    End Function


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpPut>
    Public Async Function UpdateUser(<FromBody> dto As UserPutDto) As Task(Of IActionResult)
        Dim response = Await _userBs.UpdateAsync(dto)
        Return SendResponse(response)
    End Function


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpDelete("{id}")>
    Public Async Function DeleteUser(<FromRoute> id As Integer) As Task(Of IActionResult)
        Dim response = Await _userBs.DeleteAsync(id)
        Return SendResponse(response)
    End Function


    <Produces("application/json", "text/plain")>
    <ProducesResponseType(200, Type:=GetType(ApiResponse(Of UserGetDto)))>
    <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
    <HttpGet("login")>
    Public Async Function LogIn(<FromQuery> userName As String, password As String) As Task(Of IActionResult)
        Dim response = Await _userBs.LogInAsync(userName, password)
        Return SendResponse(response)
    End Function
End Class

