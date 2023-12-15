Imports AutoMapper
Imports DataAccess
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Model

Public Class AuthorBs
    Implements IAuthorBs

    Private ReadOnly _repo As IAuthorRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IAuthorRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetByIdAsync(authorId As Integer) As Task(Of ApiResponse(Of AuthorGetDto)) Implements IAuthorBs.GetByIdAsync
        If authorId <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim author = Await _repo.GetByIdAsync(authorId)

        If author Is Nothing Then
            Throw New NotFoundException("Kaynak bulunamadı.")
        End If

        Dim dto = _mapper.Map(Of AuthorGetDto)(author)

        Return ApiResponse(Of AuthorGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function GetAuthorsAsync() As Task(Of ApiResponse(Of List(Of AuthorGetDto))) Implements IAuthorBs.GetAuthorsAsync
        Dim authors = Await _repo.GetAllAsync(Function(c) Not c.IsDeleted)

        If authors.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of AuthorGetDto))(authors)

        Return ApiResponse(Of List(Of AuthorGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetAuthorsByAuthorNameAsync(authorName As String) As Task(Of ApiResponse(Of List(Of AuthorGetDto))) Implements IAuthorBs.GetAuthorsByAuthorNameAsync
        If String.IsNullOrEmpty(authorName) Then
            Throw New BadRequestException("Yazar adı boş olamaz.")
        End If

        Dim authors = Await _repo.GetByAuthorNameAsync(authorName)

        Dim returnList = _mapper.Map(Of List(Of AuthorGetDto))(authors)

        Return ApiResponse(Of List(Of AuthorGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetAuthorsByBirthDateAsync(birthDate As Date) As Task(Of ApiResponse(Of List(Of AuthorGetDto))) Implements IAuthorBs.GetAuthorsByBirthDateAsync
        Dim authors = Await _repo.GetByBirthDateAsync(birthDate)

        If authors.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of AuthorGetDto))(authors)

        Return ApiResponse(Of List(Of AuthorGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function InsertAsync(dto As AuthorPostDto) As Task(Of ApiResponse(Of Author)) Implements IAuthorBs.InsertAsync
        If dto.AuthorName.Length < 2 Then
            Throw New BadRequestException("Yazar adı en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of Author)(dto)

        Dim insertedAuthor = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of Author).Success(StatusCodes.Status200OK, insertedAuthor)
    End Function

    Public Async Function UpdateAsync(dto As AuthorPutDto) As Task(Of ApiResponse(Of NoData)) Implements IAuthorBs.UpdateAsync
        If dto.AuthorId <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır.")
        End If

        If dto.AuthorName.Length < 2 Then
            Throw New BadRequestException("Yazar adı en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of Author)(dto)

        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements IAuthorBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function
End Class
