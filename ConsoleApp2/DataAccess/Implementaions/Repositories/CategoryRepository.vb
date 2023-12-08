Imports infrastructure
Imports Model

Public Class CategoryRepository
    Inherits BaseRepository(Of Category, LibraryManagementDBContext)
    Implements ICategoryRepository

    Public Async Function GetByCategoryNameAsync(categoryName As String) As Task(Of List(Of Category)) Implements ICategoryRepository.GetByCategoryNameAsync
        Return Await GetAllAsync(Function(c) c.CategoryName = categoryName AndAlso c.IsDeleted = False)
    End Function

    Public Async Function GetByIdAsync(categoryId As Integer) As Task(Of Category) Implements ICategoryRepository.GetByIdAsync
        Return Await GetAsync(Function(c) c.CategoryId = categoryId AndAlso c.IsDeleted = False)
    End Function
End Class

