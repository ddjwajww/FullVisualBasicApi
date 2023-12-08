Imports System.Threading.Tasks
Imports infrastructure
Imports Model

Public Interface IBookRepository
    Inherits IBaseRepository(Of Book)

    Function GetByTitleAsync(title As String, ParamArray includeList As String()) As Task(Of List(Of Book))
    Function GetByAuthorAsync(authorId As Integer, ParamArray includeList As String()) As Task(Of List(Of Book))
    Function GetByCategoryAsync(categoryId As Integer, ParamArray includeList As String()) As Task(Of List(Of Book))
    Function GetByAvailableCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of List(Of Book))
    Function GetByTotalCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of List(Of Book))
    Function GetByIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of Book)

End Interface

