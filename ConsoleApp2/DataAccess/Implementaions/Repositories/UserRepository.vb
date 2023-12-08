Imports infrastructure
Imports Model

Public Class UserRepository
    Inherits BaseRepository(Of User, LibraryManagementDBContext)
    Implements IUserRepository

    Public Async Function GetByFullNameAsync(fullName As String) As Task(Of List(Of User)) Implements IUserRepository.GetByFullNameAsync
        Return Await GetAllAsync(Function(u) u.FullName = fullName AndAlso u.IsDeleted = False)
    End Function

    Public Async Function GetByIdAsync(userId As Integer) As Task(Of User) Implements IUserRepository.GetByIdAsync
        Return Await GetAsync(Function(u) u.UserId = userId AndAlso u.IsDeleted = False)
    End Function

    Public Async Function GetByUserNameAndPasswordAsync(userName As String, password As String, ParamArray includeList As String()) As Task(Of User) Implements IUserRepository.GetByUserNameAndPasswordAsync
        Return Await GetAsync(Function(x) x.UserName = userName AndAlso x.Password = password AndAlso x.IsDeleted = False, includeList)
    End Function
End Class

