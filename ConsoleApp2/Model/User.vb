Imports infrastructure

Public Class User
    Implements IEntity

    Public Property UserId As Integer
    Public Property FullName As String
    Public Property UserName As String
    Public Property Email As String
    Public Property Password As String
    Public Property IsDeleted As Boolean
    Public Property BorrowedBooks As List(Of BorrowedBook)
    Public Property Reservations As List(Of Reservation)

End Class

