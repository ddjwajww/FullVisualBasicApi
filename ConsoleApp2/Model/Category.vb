Imports infrastructure

Public Class Category
    Implements IEntity

    Public Property CategoryId As Integer
    Public Property CategoryName As String
    Public Property Description As String
    Public Property PicturePath As String
    Public Property IsDeleted As Boolean
    Public Property Books As List(Of Book)

End Class
