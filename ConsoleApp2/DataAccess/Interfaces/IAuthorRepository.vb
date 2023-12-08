Imports System.Threading.Tasks
Imports infrastructure
Imports Model
Public Interface IAuthorRepository
    Inherits IBaseRepository(Of Author)

    Function GetByAuthorNameAsync(authorName As String) As Task(Of List(Of Author))
    Function GetByBirthDateAsync(birthDate As Date) As Task(Of List(Of Author))
    Function GetByIdAsync(authorId As Integer) As Task(Of Author)

End Interface

