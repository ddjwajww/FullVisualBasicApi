Imports infrastructure

Public Class Reservation
    Implements IEntity

    Public Property ReservationId As Integer
    Public Property UserId As Integer?
    Public Property BookId As Integer?
    Public Property ReservationDate As Date?
    Public Property ExpirationDate As Date?
    Public Property Active As Boolean
    Public Property IsDeleted As Boolean
    Public Property User As User
    Public Property Book As Book

End Class

