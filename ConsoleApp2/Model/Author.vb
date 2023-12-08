Imports System.Security.Principal
Imports infrastructure


Public Class Author
    Implements IEntity

    Public Property AuthorId As Integer
    Public Property AuthorName As String
    Public Property BirthDate As Date
    Public Property PicturePath As String
    Public Property IsDeleted As Boolean
    Public Property Books As List(Of Book)

End Class

