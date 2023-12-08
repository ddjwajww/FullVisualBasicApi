Imports Microsoft.AspNetCore.Http
Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports AutoMapper
Imports infrastructure
Imports Model
Imports DataAccess

Public Class UserBs
    Implements IUserBs

    Private ReadOnly _repo As IUserRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IUserRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetByIdAsync(userId As Integer) As Task(Of ApiResponse(Of UserGetDto)) Implements IUserBs.GetByIdAsync
        If userId <= 0 Then
            Throw New BadRequestException("Kullanıcı id pozitif bir değer olmalıdır.")
        End If

        Dim user = Await _repo.GetByIdAsync(userId)

        If user Is Nothing Then
            Throw New NotFoundException("Kaynak bulunamadı")
        End If

        Dim dto = _mapper.Map(Of UserGetDto)(user)

        Return ApiResponse(Of UserGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function GetUsersAsync() As Task(Of ApiResponse(Of List(Of UserGetDto))) Implements IUserBs.GetUsersAsync
        Dim users = Await _repo.GetAllAsync(Function(u) Not u.IsDeleted)

        If users.Count <= 0 Then
            Throw New NotFoundException("Kaynak bulunamadı")
        End If

        Dim returnList = _mapper.Map(Of List(Of UserGetDto))(users)

        Return ApiResponse(Of List(Of UserGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetUsersByFullNameAsync(fullName As String) As Task(Of ApiResponse(Of List(Of UserGetDto))) Implements IUserBs.GetUsersByFullNameAsync
        If String.IsNullOrEmpty(fullName) Then
            Throw New BadRequestException("İsim boş olamaz.")
        End If

        Dim users = Await _repo.GetByFullNameAsync(fullName)
        Dim returnList = _mapper.Map(Of List(Of UserGetDto))(users)

        Return ApiResponse(Of List(Of UserGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function InsertAsync(dto As UserPostDto) As Task(Of ApiResponse(Of User)) Implements IUserBs.InsertAsync
        If dto.FullName.Length < 2 Then
            Throw New BadRequestException("İsim en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of User)(dto)
        Dim insertedUser = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of User).Success(StatusCodes.Status200OK, insertedUser)
    End Function

    Public Async Function UpdateAsync(dto As UserPutDto) As Task(Of ApiResponse(Of NoData)) Implements IUserBs.UpdateAsync
        If dto.UserId <= 0 Then
            Throw New BadRequestException("Id değeri pozitif bir sayı olmalıdır.")
        End If

        If dto.FullName.Length < 2 Then
            Throw New BadRequestException("İsim en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of User)(dto)
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements IUserBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function LogInAsync(userName As String, password As String, ParamArray includeList As String()) As Task(Of ApiResponse(Of UserGetDto)) Implements IUserBs.LogInAsync
        If String.IsNullOrEmpty(userName) Then
            Throw New BadRequestException("Kullanıcı adı boş bırakılamaz.")
        End If
        If String.IsNullOrEmpty(password) Then
            Throw New BadRequestException("Şifre boş bırakılamaz.")
        End If
        If userName.Length <= 2 Then
            Throw New BadRequestException("Kullanıcı adı en az 2 karakter olmalıdır.")
        End If

        Dim user = Await _repo.GetByUserNameAndPasswordAsync(userName, password, includeList)

        If user Is Nothing Then
            Throw New BadRequestException("Kullanıcı bulunamadı.")
        End If

        Dim list = _mapper.Map(Of UserGetDto)(user)

        Return ApiResponse(Of UserGetDto).Success(StatusCodes.Status200OK, list)
    End Function
End Class

