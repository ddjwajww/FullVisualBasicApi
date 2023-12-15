Imports AutoMapper
Imports Model

Public Class CategoryProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of Category, CategoryGetDto)() _
            .ForMember(
            Function(dest) dest.CategoryName,
                    Sub(opt) opt.MapFrom(Function(src) If(src.CategoryName Is Nothing, " ", src.CategoryName)))

        CreateMap(Of CategoryPostDto, Category)()
        CreateMap(Of CategoryPutDto, Category)()
    End Sub


End Class
