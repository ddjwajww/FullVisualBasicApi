Imports AutoMapper
Imports Model


Public Class BookProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Book, BookGetDto)() _
            .ForMember(
                Function(dest) dest.AvailableCopies,
                Sub(opt) opt.MapFrom(Function(src) If(src.AvailableCopies Is Nothing, 0, src.AvailableCopies))
            ) _
            .ForMember(
                Function(dest) dest.Title,
                Sub(opt) opt.MapFrom(Function(src) If(src.Title Is Nothing, String.Empty, src.Title))
            ) _
            .ForMember(
                Function(dest) dest.CategoryName,
                Sub(opt) opt.MapFrom(Function(src) If(src.Category.CategoryName Is Nothing, String.Empty, src.Category.CategoryName))
            ) _
            .ForMember(
                Function(dest) dest.AuthorName,
                Sub(opt) opt.MapFrom(Function(src) If(src.Author.AuthorName Is Nothing, String.Empty, src.Author.AuthorName))
            ) _
            .ForMember(
                Function(dest) dest.PublishDate,
                Sub(opt) opt.MapFrom(Function(src) If(src.PublishDate Is Nothing, DateTime.MinValue, src.PublishDate))
            ) _
            .ReverseMap()

        CreateMap(Of BookPostDto, Book)()
        CreateMap(Of BookPutDto, Book)()
    End Sub

End Class
