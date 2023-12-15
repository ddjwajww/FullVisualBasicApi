Imports AutoMapper
Imports Model

Public Class BorrowedBookProfile
    Inherits Profile
    Public Sub New()
        CreateMap(Of BorrowedBook, BorrowedBookGetDto)() _
            .ForMember(Function(dest) dest.UserId,
            Sub(opt) opt.MapFrom(Function(src) If(src.UserId Is Nothing, 0, src.UserId))
        ) _
        .ForMember(
            Function(dest) dest.BookId,
            Sub(opt) opt.MapFrom(Function(src) If(src.BookId Is Nothing, 0, src.BookId))
        ) _
        .ForMember(
            Function(dest) dest.BorrowDate,
            Sub(opt) opt.MapFrom(Function(src) If(src.BorrowDate Is Nothing, DateTime.MinValue, src.BorrowDate))
        ) _
        .ForMember(
            Function(dest) dest.ReturnDate,
            Sub(opt) opt.MapFrom(Function(src) If(src.ReturnDate Is Nothing, DateTime.MinValue, src.ReturnDate))
        ) _
        .ReverseMap()

        CreateMap(Of BorrowedBookPostDto, BorrowedBook)()
        CreateMap(Of BorrowedBookPutDto, BorrowedBook)()
    End Sub
End Class
