Imports AutoMapper
Imports DataAccess
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Model

Public Class BorrowedBookBs
    Implements IBorrowedBookBs

    Private ReadOnly _repo As IBorrowedBookRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IBorrowedBookRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetBorrowedBooksAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksAsync
        Dim borrowedBooks = Await _repo.GetAllAsync(Function(c) Not c.IsDeleted, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBorrowedBooksByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksByBookIdAsync
        If bookId <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim borrowedBooks = Await _repo.GetByBookIdAsync(bookId, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBorrowedBooksByBorrowDateAsync(borrowDate As DateTime, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksByBorrowDateAsync
        Dim borrowedBooks = Await _repo.GetByBorrowDateAsync(borrowDate, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBorrowedBooksByReturnDateAsync(returnDate As DateTime, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksByReturnDateAsync
        Dim borrowedBooks = Await _repo.GetByReturnDateAsync(returnDate, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBorrowedBooksByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksByUserIdAsync
        If userId <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim borrowedBooks = Await _repo.GetByUserIdAsync(userId, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBorrowedBooksByReturnedAsync(isReturned As Boolean, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BorrowedBookGetDto))) Implements IBorrowedBookBs.GetBorrowedBooksByReturnedAsync
        Dim borrowedBooks = Await _repo.GetByReturnedAsync(isReturned, includeList)

        If borrowedBooks.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı")
        End If

        Dim returnList = _mapper.Map(Of List(Of BorrowedBookGetDto))(borrowedBooks)

        Return ApiResponse(Of List(Of BorrowedBookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetByIdAsync(borrowedBookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of BorrowedBookGetDto)) Implements IBorrowedBookBs.GetByIdAsync
        If borrowedBookId <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim borrowedBook = Await _repo.GetByIdAsync(borrowedBookId, includeList)

        If borrowedBook Is Nothing Then
            Throw New NotFoundException("Kaynak Bulunamadı")
        End If

        Dim dto = _mapper.Map(Of BorrowedBookGetDto)(borrowedBook)

        Return ApiResponse(Of BorrowedBookGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function InsertAsync(dto As BorrowedBookPostDto) As Task(Of ApiResponse(Of BorrowedBook)) Implements IBorrowedBookBs.InsertAsync
        If dto.BookId <= 0 Then
            Throw New BadRequestException("Kitap id pozitif bir değer olmalıdır")
        End If

        If dto.UserId <= 0 Then
            Throw New BadRequestException("Kullanıcı id pozitif bir değer olmalıdır")
        End If

        Dim entity = _mapper.Map(Of BorrowedBook)(dto)

        Dim insertedBorrowedBook = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of BorrowedBook).Success(StatusCodes.Status200OK, insertedBorrowedBook)
    End Function

    Public Async Function UpdateAsync(dto As BorrowedBookPutDto) As Task(Of ApiResponse(Of NoData)) Implements IBorrowedBookBs.UpdateAsync
        If dto.BorrowedBookId <= 0 Then
            Throw New BadRequestException("Ödünç alınan kitap id pozitif bir değer olmalıdır.")
        End If

        If dto.BookId <= 0 Then
            Throw New BadRequestException("Kitap id 0'dan büyük bir değer olmalıdır")
        End If

        If dto.UserId <= 0 Then
            Throw New BadRequestException("Kullanıcı id 0'dan büyük bir değer olmalıdır")
        End If

        Dim entity = _mapper.Map(Of BorrowedBook)(dto)

        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements IBorrowedBookBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function
End Class
