Imports AutoMapper
Imports Model

Public Class ReservationProfile
    Inherits Profile


    Public Class ReservationProfile
        Inherits Profile

        Public Sub New()
            CreateMap(Of Reservation, ReservationGetDto)() _
                .ForMember(
                    Function(dest) dest.ReservationDate,
                    Sub(opt) opt.MapFrom(Function(src) If(src.ReservationDate Is Nothing, DateTime.MinValue, src.ReservationDate))
                ) _
                .ForMember(
                    Function(dest) dest.ExpirationDate,
                    Sub(opt) opt.MapFrom(Function(src) If(src.ExpirationDate Is Nothing, DateTime.MinValue, src.ExpirationDate))
                ) _
                .ForMember(
                    Function(dest) dest.UserId,
                    Sub(opt) opt.MapFrom(Function(src) If(src.UserId Is Nothing, 0, src.UserId))
                ) _
                .ForMember(
                    Function(dest) dest.BookId,
                    Sub(opt) opt.MapFrom(Function(src) If(src.Book Is Nothing, 0, src.BookId))
                ) _
                .ReverseMap()

            CreateMap(Of ReservationPostDto, Reservation)()
            CreateMap(Of ReservationPutDto, Reservation)()
        End Sub
    End Class


End Class
