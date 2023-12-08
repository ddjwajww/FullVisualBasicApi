Imports System.Threading.Tasks
Imports infrastructure
Imports Model

Public Interface IBorrowedBookRepository
    Inherits IBaseRepository(Of BorrowedBook)

    Function GetByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook))
    Function GetByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook))
    Function GetByBorrowDateAsync(borrowDate As Date, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook))
    Function GetByReturnDateAsync(returnDate As Date, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook))
    Function GetByReturnedAsync(isReturned As Boolean, ParamArray includeList As String()) As Task(Of List(Of BorrowedBook))
    Function GetByIdAsync(borrowedBookId As Integer, ParamArray includeList As String()) As Task(Of BorrowedBook)

End Interface

