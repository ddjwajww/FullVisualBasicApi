Imports AutoMapper
Imports DataAccess
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Model

Public Class BookBs
    Implements IBookBs

    Private ReadOnly _repo As IBookRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IBookRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetBooksAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto))) Implements IBookBs.GetBooksAsync
        Dim books = Await _repo.GetAllAsync(Function(c) Not c.IsDeleted, includeList:=includeList)

        If books.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BookGetDto))(books)

        Return ApiResponse(Of List(Of BookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBooksByAuthorIdAsync(author As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto))) Implements IBookBs.GetBooksByAuthorIdAsync
        If author <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim books = Await _repo.GetByAuthorAsync(author, includeList)

        If books.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BookGetDto))(books)

        Return ApiResponse(Of List(Of BookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBooksByAvailableCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto))) Implements IBookBs.GetBooksByAvailableCopiesAsync
        If min > max Then
            Throw New BadRequestException("Maximum değer minimum değerden büyük olmalıdır")
        End If

        If min < 0 OrElse max < 0 Then
            Throw New BadRequestException("Lütfen pozitif değerler giriniz")
        End If

        Dim books = Await _repo.GetByAvailableCopiesAsync(min, max, includeList)

        If books.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BookGetDto))(books)

        Return ApiResponse(Of List(Of BookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBooksByCategoryIdAsync(category As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto))) Implements IBookBs.GetBooksByCategoryIdAsync
        If category <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim books = Await _repo.GetByCategoryAsync(category, includeList)

        If books.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BookGetDto))(books)

        Return ApiResponse(Of List(Of BookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetBooksByTotalCopiesAsync(min As Integer, max As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of BookGetDto))) Implements IBookBs.GetBooksByTotalCopiesAsync
        If min > max Then
            Throw New BadRequestException("Maximum değer minimum değerden büyük olmalıdır")
        End If

        If min < 0 OrElse max < 0 Then
            Throw New BadRequestException("Lütfen pozitif değerler giriniz")
        End If

        Dim books = Await _repo.GetByTotalCopiesAsync(min, max, includeList)

        If books.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of BookGetDto))(books)

        Return ApiResponse(Of List(Of BookGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetByIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of BookGetDto)) Implements IBookBs.GetByIdAsync
        If bookId <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim book = Await _repo.GetByIdAsync(bookId, includeList)

        If book Is Nothing Then
            Throw New NotFoundException("Kaynak bulunamadı")
        End If

        Dim dto = _mapper.Map(Of BookGetDto)(book)

        Return ApiResponse(Of BookGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function InsertAsync(dto As BookPostDto) As Task(Of ApiResponse(Of Book)) Implements IBookBs.InsertAsync
        If dto.Title.Length < 2 Then
            Throw New BadRequestException("Kitap adı en az 2 karakterden oluşmalıdır")
        End If

        If dto.CategoryId <= 0 Then
            Throw New BadRequestException("Kategori id değeri 0'dan büyük olmalıdır")
        End If

        If dto.AuthorId <= 0 Then
            Throw New BadRequestException("Yazar id değeri 0'dan büyük olmalıdır")
        End If

        If dto.TotalCopies <= 0 Then
            Throw New BadRequestException("Toplam kopya sayısı 0'dan büyük olmalıdır")
        End If

        Dim entity = _mapper.Map(Of Book)(dto)

        Dim insertedBook = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of Book).Success(StatusCodes.Status200OK, insertedBook)
    End Function

    Public Async Function UpdateAsync(dto As BookPutDto) As Task(Of ApiResponse(Of NoData)) Implements IBookBs.UpdateAsync
        If dto.BookId <= 0 Then
            Throw New BadRequestException("Id değeri 0'dan büyük olmalıdır")
        End If

        If dto.Title.Length < 2 Then
            Throw New BadRequestException("Kitap adı en az 2 karakterden oluşmalıdır")
        End If

        If dto.CategoryId <= 0 Then
            Throw New BadRequestException("Kategori id değeri 0'dan büyük olmalıdır")
        End If

        If dto.AuthorId <= 0 Then
            Throw New BadRequestException("Yazar id değeri 0'dan büyük olmalıdır")
        End If

        If dto.TotalCopies <= 0 Then
            Throw New BadRequestException("Toplam kopya sayısı 0'dan büyük olmalıdır")
        End If

        Dim entity = _mapper.Map(Of Book)(dto)

        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements IBookBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function
End Class
