Imports infrastructure

Public Class Book
    Implements IEntity

    Public Property BookId As Integer
    Public Property Title As String
    Public Property AuthorId As Integer?
    Public Property CategoryId As Integer?
    Public Property PublishDate As Date?
    Public Property AvailableCopies As Integer?
    Public Property TotalCopies As Integer?
    Public Property PicturePath As String
    Public Property IsDeleted As Boolean
    Public Property Author As Author
    Public Property Category As Category

End Class
