Imports AutoMapper
Imports DataAccess
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Model

Public Class CategoryBs
    Implements ICategoryBs

    Private ReadOnly _repo As ICategoryRepository
    Private ReadOnly _mapper As IMapper

    Public Sub New(repo As ICategoryRepository, mapper As IMapper)
        _repo = repo
        _mapper = mapper
    End Sub

    Public Async Function GetByIdAsync(categoryId As Integer) As Task(Of ApiResponse(Of CategoryGetDto)) Implements ICategoryBs.GetByIdAsync
        If categoryId <= 0 Then
            Throw New BadRequestException("Id değeri sıfırdan büyük olmalıdır.")
        End If

        Dim category = Await _repo.GetByIdAsync(categoryId)

        If category Is Nothing Then
            Throw New NotFoundException("Kaynak bulunamadı")
        End If

        Dim dto = _mapper.Map(Of CategoryGetDto)(category)

        Return ApiResponse(Of CategoryGetDto).Success(StatusCodes.Status200OK, dto)
    End Function

    Public Async Function GetCategoriesAsync() As Task(Of ApiResponse(Of List(Of CategoryGetDto))) Implements ICategoryBs.GetCategoriesAsync
        Dim categories = Await _repo.GetAllAsync(Function(c) Not c.IsDeleted)

        If categories.Count <= 0 Then
            Throw New NotFoundException("Kaynak Bulunamadı.")
        End If

        Dim returnList = _mapper.Map(Of List(Of CategoryGetDto))(categories)

        Return ApiResponse(Of List(Of CategoryGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function GetCategoriesByCategoryNameAsync(categoryName As String) As Task(Of ApiResponse(Of List(Of CategoryGetDto))) Implements ICategoryBs.GetCategoriesByCategoryNameAsync
        If String.IsNullOrEmpty(categoryName) Then
            Throw New BadRequestException("Kategori adı boş olamaz.")
        End If

        Dim categories = Await _repo.GetByCategoryNameAsync(categoryName)

        Dim returnList = _mapper.Map(Of List(Of CategoryGetDto))(categories)

        Return ApiResponse(Of List(Of CategoryGetDto)).Success(StatusCodes.Status200OK, returnList)
    End Function

    Public Async Function InsertAsync(dto As CategoryPostDto) As Task(Of ApiResponse(Of Category)) Implements ICategoryBs.InsertAsync
        If dto.CategoryName.Length < 2 Then
            Throw New BadRequestException("Kategori adı en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of Category)(dto)
        Dim insertedCategory = Await _repo.InsertAsync(entity)

        Return ApiResponse(Of Category).Success(StatusCodes.Status200OK, insertedCategory)
    End Function

    Public Async Function UpdateAsync(dto As CategoryPutDto) As Task(Of ApiResponse(Of NoData)) Implements ICategoryBs.UpdateAsync
        If dto.CategoryId <= 0 Then
            Throw New BadRequestException("Id değeri pozitif bir sayı olmalıdır.")
        End If

        If dto.CategoryName.Length < 2 Then
            Throw New BadRequestException("Kategori adı en az 2 karakterden oluşmalıdır")
        End If

        Dim entity = _mapper.Map(Of Category)(dto)

        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function

    Public Async Function DeleteAsync(id As Integer) As Task(Of ApiResponse(Of NoData)) Implements ICategoryBs.DeleteAsync
        If id <= 0 Then
            Throw New BadRequestException("Id pozitif bir değer olmalıdır")
        End If

        Dim entity = Await _repo.GetByIdAsync(id)
        entity.IsDeleted = True
        Await _repo.UpdateAsync(entity)

        Return ApiResponse(Of NoData).Success(StatusCodes.Status200OK)
    End Function
End Class
