Imports Business
Imports infrastructure
Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Mvc
Imports Model

Namespace LM.WebAPI.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class BorrowedBooksController
        Inherits BaseController

        Private ReadOnly _borrowedBookBs As IBorrowedBookBs

        Public Sub New(borrowedBookBs As IBorrowedBookBs)
            _borrowedBookBs = borrowedBookBs
        End Sub

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet>
        Public Async Function GetAllBorrowedBooks() As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksAsync("User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byuserid")>
        Public Async Function GetBorrowedBooksByUserId(<FromQuery> userId As Integer) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksByUserIdAsync(userId, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bybookid")>
        Public Async Function GetBorrowedBooksByBookId(<FromQuery> bookId As Integer) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksByBookIdAsync(bookId, "User", "Book")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byborrowdate")>
        Public Async Function GetBorrowedBooksByBorrowDate(<FromQuery> borrowDate As DateTime) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksByBorrowDateAsync(borrowDate, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byreturndate")>
        Public Async Function GetBorrowedBooksByReturnDate(<FromQuery> returnDate As DateTime) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksByReturnDateAsync(returnDate, "User", "Book")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of BorrowedBookGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byreturned")>
        Public Async Function GetBorrowedBooksByReturned(<FromQuery> isReturned As Boolean) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetBorrowedBooksByReturnedAsync(isReturned, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of BorrowedBookGetDto)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("{id}")>
        Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.GetByIdAsync(id, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of BorrowedBook)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPost>
        Public Async Function SaveNewBorrowedBook(<FromBody> dto As BorrowedBookPostDto) As Task(Of ActionResult)
            Dim response = Await _borrowedBookBs.InsertAsync(dto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.BorrowedBookId}, response.Data)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPut>
        Public Async Function UpdateBorrowedBook(<FromBody> dto As BorrowedBookPutDto) As Task(Of IActionResult)
            Dim response = Await _borrowedBookBs.UpdateAsync(dto)
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpDelete("{id}")>
        Public Async Function DeleteBorrowedBook(<FromRoute> id As Integer) As Task(Of IActionResult)
            Dim response = Await _borrowedBookBs.DeleteAsync(id)
            Return SendResponse(response)
        End Function
    End Class

End Namespace






