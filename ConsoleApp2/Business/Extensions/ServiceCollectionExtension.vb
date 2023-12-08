Imports DataAccess
Imports Microsoft.Extensions.DependencyInjection
Imports System.Runtime.CompilerServices

Public Module ServiceCollectionExtensions
    <Extension()>
    Public Sub AddBusinessServices(services As IServiceCollection)
        services.AddAutoMapper(GetType(UserProfile))
        '-------------------------------------------

        'services.AddScoped(Of IBookBs, BookBs)()
        'services.AddScoped(Of IBookRepository, BookRepository)()

        'services.AddScoped(Of IAuthorBs, AuthorBs)()
        'services.AddScoped(Of IAuthorRepository, AuthorRepository)()

        'services.AddScoped(Of ICategoryBs, CategoryBs)()
        'services.AddScoped(Of ICategoryRepository, CategoryRepository)()

        'services.AddScoped(Of IBorrowedBookBs, BorrowedBookBs)()
        'services.AddScoped(Of IBorrowedBookRepository, BorrowedBookRepository)()

        'services.AddScoped(Of IReservationBs, ReservationBs)()
        'services.AddScoped(Of IReservationRepository, ReservationRepository)()

        services.AddScoped(Of IUserBs, UserBs)()
        services.AddScoped(Of IUserRepository, UserRepository)()

        'services.AddScoped(Of IAdminPanelUserBs, AdminPanelUserBs)()
        'services.AddScoped(Of IAdminPanelUserRepository, AdminPanelUserRepository)()
    End Sub
End Module

