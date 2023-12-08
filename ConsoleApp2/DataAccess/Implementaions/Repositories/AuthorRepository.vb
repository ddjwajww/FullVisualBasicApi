Imports infrastructure
Imports Model

Public Class AuthorRepository
    Inherits BaseRepository(Of Author, LibraryManagementDBContext)
    Implements IAuthorRepository

    Public Async Function GetByBirthDateAsync(birthDate As Date) As Task(Of List(Of Author)) Implements IAuthorRepository.GetByBirthDateAsync
        Return Await GetAllAsync(Function(a) a.BirthDate = birthDate AndAlso a.IsDeleted = False)
    End Function

    Public Async Function GetByAuthorNameAsync(authorName As String) As Task(Of List(Of Author)) Implements IAuthorRepository.GetByAuthorNameAsync
        Return Await GetAllAsync(Function(a) a.AuthorName = authorName AndAlso a.IsDeleted = False)
    End Function

    Public Async Function GetByIdAsync(authorId As Integer) As Task(Of Author) Implements IAuthorRepository.GetByIdAsync
        Return Await GetAsync(Function(a) a.AuthorId = authorId AndAlso a.IsDeleted = False)
    End Function
End Class

