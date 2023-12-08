Imports System.Collections.Generic
Imports System.Threading.Tasks
Imports infrastructure
Imports Model


Public Interface IUserBs
    Function GetUsersAsync() As Task(Of ApiResponse(Of List(Of UserGetDto)))
    Function GetUsersByFullNameAsync(fullName As String) As Task(Of ApiResponse(Of List(Of UserGetDto)))
    Function GetByIdAsync(userId As Integer) As Task(Of ApiResponse(Of UserGetDto))
    Function InsertAsync(dto As UserPostDto) As Task(Of ApiResponse(Of User))
    Function UpdateAsync(dto As UserPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))
    Function LogInAsync(userName As String, password As String, ParamArray includeList As String()) As Task(Of ApiResponse(Of UserGetDto))
End Interface

