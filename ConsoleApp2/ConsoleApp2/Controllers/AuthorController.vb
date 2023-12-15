Imports Business
Imports infrastructure
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc
Imports Model

Namespace LM.WebAPI.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class AuthorsController
        Inherits BaseController

        Private ReadOnly _authorBs As IAuthorBs

        Public Sub New(authorBs As IAuthorBs)
            _authorBs = authorBs
        End Sub

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of AuthorGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet>
        Public Async Function GetAllAuthors() As Task(Of ActionResult)
            Dim response = Await _authorBs.GetAuthorsAsync()
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of AuthorGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byauthorname")>
        Public Async Function GetAuthorsByAuthorName(<FromQuery> authorName As String) As Task(Of ActionResult)
            Dim response = Await _authorBs.GetAuthorsByAuthorNameAsync(authorName)
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of AuthorGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bybirthdate")>
        Public Async Function GetAuthorsByBirthDate(<FromQuery> birthDate As Date) As Task(Of ActionResult)
            Dim response = Await _authorBs.GetAuthorsByBirthDateAsync(birthDate)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of AuthorGetDto)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("{id}")>
        Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
            Dim response = Await _authorBs.GetByIdAsync(id)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of Author)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPost>
        Public Async Function SaveNewAuthor(<FromBody> dto As AuthorPostDto) As Task(Of ActionResult)
            Dim response = Await _authorBs.InsertAsync(dto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.AuthorId}, response.Data)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPut>
        Public Async Function UpdateAuthor(<FromBody> dto As AuthorPutDto) As Task(Of IActionResult)
            Dim response = Await _authorBs.UpdateAsync(dto)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpDelete("{id}")>
        Public Async Function DeleteAuthor(<FromRoute> id As Integer) As Task(Of IActionResult)
            Dim response = Await _authorBs.DeleteAsync(id)
            Return SendResponse(response)
        End Function

    End Class
End Namespace
