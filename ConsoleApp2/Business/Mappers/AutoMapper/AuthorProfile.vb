Imports AutoMapper
Imports Model

Public Class AuthorProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Author, AuthorGetDto)() _
            .ForMember(
                Function(dest) dest.AuthorName,
                Sub(opt) opt.MapFrom(Function(src) If(src.AuthorName Is Nothing, String.Empty, src.AuthorName))
            ) _
            .ForMember(
                Function(dest) dest.BirthDate,
                Sub(opt) opt.MapFrom(Function(src) src.BirthDate)) _
            .ReverseMap()

        CreateMap(Of AuthorPostDto, Author)()
        CreateMap(Of AuthorPutDto, Author)()
    End Sub


End Class
