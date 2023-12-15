
Imports AutoMapper ' IMapper namespace'ini ekleyin
Imports DataAccess
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Model ' StatusCodes namespace'ini ekleyin

Public Class ReservationBs
    Implements IReservationBs

    Private ReadOnly _repo As IReservationRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As IReservationRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetByIdAsync(reservationId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of ReservationGetDto)) Implements IReservationBs.GetByIdAsync
        If reservationId <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim reservation = Await _repo.GetByIdAsync(reservationId, includeList)

        If reservation Is Nothing Then
            Throw New NotFoundException("Kaynak Bulunamadı")
        End If

        Dim dto = _mapper.Map(Of ReservationGetDto)(reservation)

        Return ApiResponse(Of ReservationGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function GetReservationAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationAsync
        Dim reservations = Await _repo.GetAllAsync(Function(c) Not c.IsDeleted, includeList:=includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetReservationByActiveAsync(isActive As Boolean, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationByActiveAsync
        Dim reservations = Await _repo.GetByActiveAsync(isActive, includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetReservationByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationByBookIdAsync
        If bookId <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim reservations = Await _repo.GetByBookIdAsync(bookId, includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetReservationByExpirationDateAsync(expirationDate As DateTime, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationByExpirationDateAsync
        Dim reservations = Await _repo.GetByExpirationDateAsync(expirationDate, includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetReservationByReservationDateAsync(reservationDate As DateTime, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationByReservationDateAsync
        Dim reservations = Await _repo.GetByReservationDateAsync(reservationDate, includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetReservationByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto))) Implements IReservationBs.GetReservationByUserIdAsync
        If userId <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim reservations = Await _repo.GetByUserIdAsync(userId, includeList)

        If reservations.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of ReservationGetDto))(reservations)

        Return ApiResponse(Of List(Of ReservationGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function InsertAsync(dto As ReservationPostDto) As Task(Of ApiResponse(Of Reservation)) Implements IReservationBs.InsertAsync
        If dto.BookId <= 0 Then
            Throw New BadRequestException("Kitap id pozitif bir değer olmalıdır")
        End If

        If dto.UserId <= 0 Then
            Throw New BadRequestException("Kullanıcı id pozitif bir değer olmalıdır")
        End If

        Dim entity = _mapper.Map(Of Reservation)(dto)
        Dim insertedReservation = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of Reservation).Success(StatusCodes.Status200OK, insertedReservation)
    End Function

    Public Async Function UpdateAsync(dto As ReservationPutDto) As Task(Of ApiResponse(Of NoData)) Implements IReservationBs.UpdateAsync
        If dto.ReservationId <= 0 Then
            Throw New BadRequestException("Rezervasyon id pozitif bir değer olmalıdır.")
        End If

        If dto.BookId <= 0 Then
            Throw New BadRequestException("Kitap id pozitif bir değer olmalıdır")
        End If

        If dto.UserId <= 0 Then
            Throw New BadRequestException("Kullanıcı id pozitif bir değer olmalıdır")
        End If

        Dim entity = _mapper.Map(Of Reservation)(dto)
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements IReservationBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

End Class
