Imports System.Threading.Tasks
Imports infrastructure
Imports Model

Public Interface ICategoryRepository
    Inherits IBaseRepository(Of Category)

    Function GetByCategoryNameAsync(categoryName As String) As Task(Of List(Of Category))
    Function GetByIdAsync(categoryId As Integer) As Task(Of Category)

End Interface

