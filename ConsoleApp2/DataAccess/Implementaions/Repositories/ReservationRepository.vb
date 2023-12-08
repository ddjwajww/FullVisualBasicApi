Imports infrastructure
Imports Model

Public Class ReservationRepository
    Inherits BaseRepository(Of Reservation, LibraryManagementDBContext)
    Implements IReservationRepository

    Public Async Function GetByActiveAsync(isActive As Boolean, ParamArray includeList As String()) As Task(Of List(Of Reservation)) Implements IReservationRepository.GetByActiveAsync
        Return Await GetAllAsync(Function(r) r.Active = isActive AndAlso r.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of List(Of Reservation)) Implements IReservationRepository.GetByBookIdAsync
        Return Await GetAllAsync(Function(r) r.BookId = bookId AndAlso r.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByExpirationDateAsync(expirationDate As Date, ParamArray includeList As String()) As Task(Of List(Of Reservation)) Implements IReservationRepository.GetByExpirationDateAsync
        Return Await GetAllAsync(Function(r) r.ExpirationDate = expirationDate AndAlso r.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByIdAsync(reservationId As Integer, ParamArray includeList As String()) As Task(Of Reservation) Implements IReservationRepository.GetByIdAsync
        Return Await GetAsync(Function(r) r.ReservationId = reservationId AndAlso r.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByReservationDateAsync(reservationDate As Date, ParamArray includeList As String()) As Task(Of List(Of Reservation)) Implements IReservationRepository.GetByReservationDateAsync
        Return Await GetAllAsync(Function(r) r.ReservationDate = reservationDate AndAlso r.IsDeleted = False, includeList)
    End Function

    Public Async Function GetByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of List(Of Reservation)) Implements IReservationRepository.GetByUserIdAsync
        Return Await GetAllAsync(Function(r) r.UserId = userId AndAlso r.IsDeleted = False, includeList)
    End Function
End Class

