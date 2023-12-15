Imports infrastructure

Public Class BorrowedBookGetDto
    Implements IDto

    Public Property BorrowedBookId As Integer
    Public Property UserId As Integer
    Public Property BookId As Integer
    Public Property BorrowDate As DateTime
    Public Property ReturnDate As DateTime
    Public Property Returned As Boolean
End Class
