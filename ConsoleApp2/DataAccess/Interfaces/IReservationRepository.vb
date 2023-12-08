Imports System.Threading.Tasks
Imports infrastructure
Imports Model

Public Interface IReservationRepository
    Inherits IBaseRepository(Of Reservation)

    Function GetByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of List(Of Reservation))
    Function GetByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of List(Of Reservation))
    Function GetByReservationDateAsync(reservationDate As Date, ParamArray includeList As String()) As Task(Of List(Of Reservation))
    Function GetByExpirationDateAsync(expirationDate As Date, ParamArray includeList As String()) As Task(Of List(Of Reservation))
    Function GetByActiveAsync(isActive As Boolean, ParamArray includeList As String()) As Task(Of List(Of Reservation))
    Function GetByIdAsync(reservationId As Integer, ParamArray includeList As String()) As Task(Of Reservation)

End Interface

