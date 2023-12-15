Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports System.Threading.Tasks

Imports Model
Imports infrastructure
Imports Business

Namespace LM.WebAPI.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class ReservationsController
        Inherits BaseController

        Private ReadOnly _reservationBs As IReservationBs

        Public Sub New(reservationBs As IReservationBs)
            _reservationBs = reservationBs
        End Sub


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet>
        Public Async Function GetAllReservations() As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationAsync("User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byuserid")>
        Public Async Function GetReservationsByUserId(<FromQuery> userId As Integer) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationByUserIdAsync(userId, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bybookid")>
        Public Async Function GetReservationsByBookId(<FromQuery> bookId As Integer) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationByBookIdAsync(bookId, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byreservationdate")>
        Public Async Function GetReservationsByReservationDate(<FromQuery> reservationDate As DateTime) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationByReservationDateAsync(reservationDate, "User", "Book")
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byexpirationdate")>
        Public Async Function GetReservationsByExpirationDate(<FromQuery> expirationDate As DateTime) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationByExpirationDateAsync(expirationDate, "User", "Book")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of ReservationGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("byactive")>
        Public Async Function GetReservationsByActive(<FromQuery> isActive As Boolean) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetReservationByActiveAsync(isActive, "User", "Book")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of ReservationGetDto)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("{id}")>
        Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
            Dim response = Await _reservationBs.GetByIdAsync(id, "User", "Book")
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of Reservation)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPost>
        Public Async Function SaveNewReservation(<FromBody> dto As ReservationPostDto) As Task(Of ActionResult)
            Dim response = Await _reservationBs.InsertAsync(dto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.ReservationId}, response.Data)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPut>
        Public Async Function UpdateReservation(<FromBody> dto As ReservationPutDto) As Task(Of IActionResult)
            Dim response = Await _reservationBs.UpdateAsync(dto)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpDelete("{id}")>
        Public Async Function DeleteReservation(<FromRoute> id As Integer) As Task(Of IActionResult)
            Dim response = Await _reservationBs.DeleteAsync(id)
            Return SendResponse(response)
        End Function
    End Class

End Namespace
