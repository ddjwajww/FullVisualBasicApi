Imports AutoMapper
Imports Model

Public Class UserProfile
    Inherits Profile

    Public Sub New()
        CreateMap(Of User, UserGetDto)() _
            .ForMember(
                Function(dest) dest.FullName,
                Sub(opt) opt.MapFrom(
                    Function(src) If(src.FullName Is Nothing, "", src.FullName)
                )
            ) _
            .ReverseMap()

        CreateMap(Of UserPostDto, User)()
        CreateMap(Of UserPutDto, User)()
    End Sub
End Class

