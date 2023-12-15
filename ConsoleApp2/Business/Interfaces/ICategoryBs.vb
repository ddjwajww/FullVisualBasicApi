Imports infrastructure
Imports Model

Public Interface ICategoryBs
    Function GetCategoriesAsync() As Task(Of ApiResponse(Of List(Of CategoryGetDto)))
    Function GetCategoriesByCategoryNameAsync(categoryName As String) As Task(Of ApiResponse(Of List(Of CategoryGetDto)))
    Function GetByIdAsync(categoryId As Integer) As Task(Of ApiResponse(Of CategoryGetDto))
    Function InsertAsync(dto As CategoryPostDto) As Task(Of ApiResponse(Of Category))
    Function UpdateAsync(dto As CategoryPutDto) As Task(Of ApiResponse(Of NoData))
    Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData))

End Interface
