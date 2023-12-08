Imports infrastructure
Imports Model

Public Class BorrowedBookRepository
    Inherits BaseRepository(Of BorrowedBook, LibraryManagementDBContext)
    Implements IBorrowedBookRepository

    Public Async Function GetByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook)) Implements IBorrowedBookRepository.GetByBookIdAsync
        Return Await GetAllAsync(Function(bb) bb.BookId = bookId AndAlso bb.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByBorrowDateAsync(borrowDate As Date, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook)) Implements IBorrowedBookRepository.GetByBorrowDateAsync
        Return Await GetAllAsync(Function(bb) bb.BorrowDate = borrowDate AndAlso bb.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByIdAsync(borrowedBookId As Integer, ParamArray includeList As String()) As Task(Of BorrowedBook) Implements IBorrowedBookRepository.GetByIdAsync
        Return Await GetAsync(Function(bb) bb.BorrowedBookId = borrowedBookId AndAlso bb.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByReturnDateAsync(returnDate As Date, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook)) Implements IBorrowedBookRepository.GetByReturnDateAsync
        Return Await GetAllAsync(Function(bb) bb.ReturnDate = returnDate AndAlso bb.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByReturnedAsync(isReturned As Boolean, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook)) Implements IBorrowedBookRepository.GetByReturnedAsync
        Return Await GetAllAsync(Function(bb) bb.Returned = isReturned AndAlso bb.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook)) Implements IBorrowedBookRepository.GetByUserIdAsync
        Return Await GetAllAsync(Function(bb) bb.UserId = userId AndAlso bb.IsDeleted = False, includeList)
    End Function
End Class

