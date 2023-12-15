Imports infrastructure
Imports Model

Public Interface IReservationBs
    Function GetReservationAsync(ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetReservationByUserIdAsync(userId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetReservationByBookIdAsync(bookId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetReservationByReservationDateAsync(reservationDate As Date, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetReservationByExpirationDateAsync(expirationDate As Date, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetReservationByActiveAsync(isActive As Boolean, ParamArray includeList As String()) As Task(Of ApiResponse(Of List(Of ReservationGetDto)))
    Function GetByIdAsync(reservationId As Integer, ParamArray includeList As String()) As Task(Of ApiResponse(Of ReservationGetDto))
    Function InsertAsync(dto As ReservationPostDto) As Task(Of ApiResponse(Of Reservation))
    Function UpdateAsync(dto As ReservationPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))

End Interface
