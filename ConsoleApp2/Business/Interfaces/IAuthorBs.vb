Imports infrastructure
Imports Model

Public Interface IAuthorBs
    Function GetAuthorsAsync() As Task(Of ApiResponse(Of List(Of AuthorGetDto)))
    Function GetAuthorsByAuthorNameAsync(authorFirstName As String) As Task(Of ApiResponse(Of List(Of AuthorGetDto)))
    Function GetAuthorsByBirthDateAsync(birthDate As Date) As Task(Of ApiResponse(Of List(Of AuthorGetDto)))
    Function GetByIdAsync(authorId As Integer) As Task(Of ApiResponse(Of AuthorGetDto))
    Function InsertAsync(dto As AuthorPostDto) As Task(Of ApiResponse(Of Author))
    Function UpdateAsync(dto As AuthorPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))

End Interface
