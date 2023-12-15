Imports infrastructure

Public Class BookGetDto
    Implements IDto

    Public Property BookId As Integer
    Public Property Title As String
    Public Property AuthorId As Integer
    Public Property CategoryId As Integer
    Public Property PicturePath As String
    Public Property CategoryName As String
    Public Property AuthorName As String
    Public Property PublishDate As DateTime
    Public Property TotalCopies As Integer
    Public Property AvailableCopies As Integer
End Class
