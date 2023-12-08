Imports infrastructure

Public Class BorrowedBook
    Implements IEntity

    Public Property BorrowedBookId As Integer
    Public Property UserId As Integer?
    Public Property BookId As Integer?
    Public Property BorrowDate As Date?
    Public Property ReturnDate As Date?
    Public Property Returned As Boolean
    Public Property IsDeleted As Boolean
    Public Property User As User
    Public Property Book As Book

End Class