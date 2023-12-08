Imports Microsoft.EntityFrameworkCore
Imports Model
Public Class LibraryManagementDBContext
    Inherits DbContext

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("Server = localhost\SQLEXPRESS; Database = LibraryManagementDB; Trusted_Connection = True; TrustServerCertificate=True;")
    End Sub

    Public Property Books As DbSet(Of Book)
    Public Property Authors As DbSet(Of Author)
    Public Property BorrowedBooks As DbSet(Of BorrowedBook)
    Public Property Reservations As DbSet(Of Reservation)
    Public Property Users As DbSet(Of User)
    Public Property Categories As DbSet(Of Category)
    'Public Property AdminPanelUsers As DbSet(Of AdminPanelUser)

End Class
