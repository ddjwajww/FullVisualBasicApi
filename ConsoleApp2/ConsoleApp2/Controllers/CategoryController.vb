Imports Microsoft.AspNetCore.Authorization
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc
Imports System.Threading.Tasks

Imports Business
Imports Model
Imports infrastructure

Namespace LM.WebAPI.Controllers
    <Route("api/[controller]")>
    <ApiController>
    Public Class CategoriesController
        Inherits BaseController

        Private ReadOnly _categoryBs As ICategoryBs

        Public Sub New(categoryBs As ICategoryBs)
            _categoryBs = categoryBs
        End Sub


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of CategoryGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet>
        Public Async Function GetAllCategories() As Task(Of ActionResult)
            Dim response = Await _categoryBs.GetCategoriesAsync()
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of List(Of CategoryGetDto))))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("bycategoryname")>
        Public Async Function GetCategoriesByCategoryName(<FromQuery> categoryName As String) As Task(Of ActionResult)
            Dim response = Await _categoryBs.GetCategoriesByCategoryNameAsync(categoryName)
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of CategoryGetDto)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpGet("{id}")>
        Public Async Function GetById(<FromRoute> id As Integer) As Task(Of ActionResult)
            Dim response = Await _categoryBs.GetByIdAsync(id)
            Return SendResponse(response)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of Category)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPost>
        Public Async Function SaveNewCategory(<FromBody> dto As CategoryPostDto) As Task(Of ActionResult)
            Dim response = Await _categoryBs.InsertAsync(dto)
            Return CreatedAtAction(NameOf(GetById), New With {.id = response.Data.CategoryId}, response.Data)
        End Function

        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpPut>
        Public Async Function UpdateCategory(<FromBody> dto As CategoryPutDto) As Task(Of IActionResult)
            Dim response = Await _categoryBs.UpdateAsync(dto)
            Return SendResponse(response)
        End Function


        <Produces("application/json", "text/plain")>
        <ProducesResponseType(200, Type:=GetType(ApiResponse(Of NoData)))>
        <ProducesResponseType(404, Type:=GetType(ApiResponse(Of NoData)))>
        <HttpDelete("{id}")>
        Public Async Function DeleteCategory(<FromRoute> id As Integer) As Task(Of IActionResult)
            Dim response = Await _categoryBs.DeleteAsync(id)
            Return SendResponse(response)
        End Function
    End Class
End Namespace

