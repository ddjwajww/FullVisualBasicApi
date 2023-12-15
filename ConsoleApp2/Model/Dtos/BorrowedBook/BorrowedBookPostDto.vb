Imports infrastructure

Public Class BorrowedBookPostDto
    Implements IDto

    Public Property UserId As Integer
    Public Property BookId As Integer
    Public Property BorrowDate As DateTime
    Public Property ReturnDate As DateTime
    Public Property Returned As Boolean
End Class
