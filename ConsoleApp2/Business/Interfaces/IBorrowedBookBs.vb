Imports infrastructure
Imports Model

Public Interface IBorrowedBookBs
    Function GetBorrowedBooksAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetBorrowedBooksByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetBorrowedBooksByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetBorrowedBooksByBorrowDateAsync(borrowDate As Date, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetBorrowedBooksByReturnDateAsync(returnDate As Date, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetBorrowedBooksByReturnedAsync(isReturned As Boolean, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto)))
    Function GetByIdAsync(borrowedBookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of BorrowedBookGetDto))
    Function InsertAsync(dto As BorrowedBookPostDto) As Task(Of ApiResponse(Of BorrowedBook))
    Function UpdateAsync(dto As BorrowedBookPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))

End Interface
