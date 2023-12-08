Imports System.Threading.Tasks
Imports infrastructure
Imports Model

Public Interface IUserRepository
    Inherits IBaseRepository(Of User)

    Function GetByFullNameAsync(fullName As String) As Task(Of List(Of User))
    Function GetByIdAsync(userId As Integer) As Task(Of User)
    Function GetByUserNameAndPasswordAsync(userName As String, password As String, ParamArray includeList As String()) As Task(Of User)

End Interface

