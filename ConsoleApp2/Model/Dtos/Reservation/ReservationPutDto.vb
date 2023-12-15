Imports infrastructure

Public Class ReservationPutDto
    Implements IDto

    Public Property ReservationId As Integer
    Public Property UserId As Integer
    Public Property BookId As Integer
    Public Property Active As Boolean
    Public Property ReservationDate As DateTime
    Public Property ExpirationDate As DateTime
End Class
