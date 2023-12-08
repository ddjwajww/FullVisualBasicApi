Imports infrastructure
Imports Model

Public Class BookRepository
    Inherits BaseRepository(Of Book, LibraryManagementDBContext)
    Implements IBookRepository

    Public Async Function GetByAuthorAsync(authorId As Integer, ParamArray includeList As String()) As Task(Of List(Of Book)) Implements IBookRepository.GetByAuthorAsync
        Return Await GetAllAsync(Function(book) book.AuthorId = authorId AndAlso book.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByAvailableCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of List(Of Book)) Implements IBookRepository.GetByAvailableCopiesAsync
        Return Await GetAllAsync(Function(book) book.AvailableCopies > min AndAlso book.AvailableCopies < max AndAlso book.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByCategoryAsync(categoryId As Integer, ParamArray includeList As String()) As Task(Of List(Of Book)) Implements IBookRepository.GetByCategoryAsync
        Return Await GetAllAsync(Function(book) book.CategoryId = categoryId AndAlso book.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of Book) Implements IBookRepository.GetByIdAsync
        Return Await GetAsync(Function(book) book.BookId = bookId AndAlso book.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByTitleAsync(title As String, ParamArray includeList As String()) As Task(Of List(Of Book)) Implements IBookRepository.GetByTitleAsync
        Return Await GetAllAsync(Function(book) book.Title = title AndAlso book.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByTotalCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of List(Of Book)) Implements IBookRepository.GetByTotalCopiesAsync
        Return Await GetAllAsync(Function(book) book.TotalCopies > min AndAlso book.TotalCopies < max AndAlso book.IsDeleted = False, includeList)
    End Function
End Class

