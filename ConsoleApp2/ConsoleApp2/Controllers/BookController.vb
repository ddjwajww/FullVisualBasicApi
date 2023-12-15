Imports Business
Imports infrastructure
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc
Imports Model

Namespace LM.WebAPI.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class BooksController
        Inherits BaseController

        Private ReadOnly _bookBs As IBookBs

        Public Sub New(bookBs As IBookBs)
            _bookBs = bookBs
        End Sub

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet>
        Public Async Function GetAllBooks() As Task(Of ActionResult)
            Dim response = Await _bookBs.GetBooksAsync("Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byauthorid")>
        Public Async Function GetBooksByAuthorId(<FromQuery> author As Integer) As Task(Of ActionResult)
            Dim response = Await _bookBs.GetBooksByAuthorIdAsync(author, "Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bycategoryid")>
        Public Async Function GetBooksByCategoryId(<FromQuery> category As Integer) As Task(Of ActionResult)
            Dim response = Await _bookBs.GetBooksByCategoryIdAsync(category, "Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byavailablecopies")>
        Public Async Function GetBooksByAvaibleCopies(<FromQuery> min As Integer, <FromQuery> max As Integer) As Task(Of ActionResult)
            Dim response = Await _bookBs.GetBooksByAvailableCopiesAsync(min, max, "Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bytotalcopies")>
        Public Async Function GetBooksByTotalCopies(<FromQuery> min As Integer, <FromQuery> max As Integer) As Task(Of ActionResult)
            Dim response = Await _bookBs.GetBooksByTotalCopiesAsync(min, max, "Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of BookGetDto)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("{id}")>
        Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
            Dim response = Await _bookBs.GetByIdAsync(id, "Author", "Category")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of Book)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPost>
        Public Async Function SaveNewBook(<FromBody> dto As BookPostDto) As Task(Of ActionResult)
            Dim response = Await _bookBs.InsertAsync(dto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.BookId}, response.Data)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPut>
        Public Async Function UpdateBook(<FromBody> dto As BookPutDto) As Task(Of IActionResult)
            Dim response = Await _bookBs.UpdateAsync(dto)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpDelete("{id}")>
        Public Async Function DeleteBook(<FromRoute> id As Integer) As Task(Of IActionResult)
            Dim response = Await _bookBs.DeleteAsync(id)
            Return SendResponse(response)
        End Function

    End Class
End Namespace

