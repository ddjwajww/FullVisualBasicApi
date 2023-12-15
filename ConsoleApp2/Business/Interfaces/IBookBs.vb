Imports infrastructure
Imports Model

Public Interface IBookBs
    Function GetBooksAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto)))
    Function GetBooksByAuthorIdAsync(author As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto)))
    Function GetBooksByCategoryIdAsync(category As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto)))
    Function GetBooksByAvailableCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto)))
    Function GetBooksByTotalCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto)))
    Function GetByIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of BookGetDto))
    Function InsertAsync(dto As BookPostDto) As Task(Of ApiResponse(Of Book))
    Function UpdateAsync(dto As BookPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))

End Interface
