'Imports Microsoft.AspNetCore.Builder
'Imports Microsoft.AspNetCore.Diagnostics
'Imports Microsoft.AspNetCore.Http
'Imports System.Text.Json

'Public Module UseCustomExceptionHandler
'    <Runtime.CompilerServices.Extension>
'    Public Sub UseCustomException(app As IApplicationBuilder)
'        app.UseExceptionHandler(
'            Sub([errorHandler] As IApplicationBuilder)
'                [errorHandler].Run(
'                    Async Function(context)
'                        ' Bu iki satırla yakalanan exception tipindeki nesneyi alıyoruz
'                        Dim exceptionFeature = context.Features.Get(Of IExceptionHandlerFeature)()
'                        Dim exception = exceptionFeature.Error

'                        Dim statusCode = StatusCodes.Status500InternalServerError

'                        If TypeOf exception Is BadRequestException Then
'                            statusCode = StatusCodes.Status400BadRequest
'                        End If

'                        ' Burada response'u hazırlıyoruz
'                        context.Response.ContentType = "application/json"
'                        context.Response.StatusCode = statusCode

'                        ' Response'u oluşturduk
'                        Dim response = ApiResponse(Of NoData).Fail(statusCode, exception.Message)

'                        ' Bu nesneyi de responsun içine JSON'a dönüştürüp yazdık
'                        Await context.Response.WriteAsync(JsonSerializer.Serialize(response))

'                    End Function
'                )
'            End Sub
'        )
'    End Sub
'End Module



Imports Business
Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports System.Text.Json

Public Class GlobalExceptionHandlingMiddleware


    Private ReadOnly _nextt As RequestDelegate

    Public Sub New(nextt As RequestDelegate)
        _nextt = nextt
    End Sub


    Public Async Function Invoke(context As HttpContext) As Task

        Dim errorMessage As Exception = Nothing

        Try
            Await _nextt(context)

        Catch ex As Exception
            errorMessage = ex
        End Try


        Await HandleExceptionAsync(context, errorMessage)


    End Function


    Private Async Function HandleExceptionAsync(context As HttpContext, exception As Exception) As Task

        context.Response.ContentType = "application/json"

        Dim response = context.Response

        Dim apiResponse = New ApiResponse(Of NoData)

        If TypeOf exception Is NotFoundException Then
            response.StatusCode = StatusCodes.Status404NotFound
            apiResponse.StatusCode = StatusCodes.Status404NotFound
            apiResponse.ErrorMessages = New List(Of String) From {"İstenen sonuç bulunamadı", "HATA", "Lütfen tekrar deneyiniz..."}

        ElseIf TypeOf exception Is NoContentException Then
            response.StatusCode = StatusCodes.Status204NoContent
            apiResponse.StatusCode = StatusCodes.Status204NoContent
            apiResponse.ErrorMessages = New List(Of String) From {"İstenen sonuç bulunamadı", "HATA", "Lütfen tekrar deneyiniz...", "Sunucu kaynaklı bir hata olabilir!"}

        ElseIf TypeOf exception Is BadRequestException Then
            response.StatusCode = StatusCodes.Status400BadRequest
            apiResponse.StatusCode = StatusCodes.Status400BadRequest
            apiResponse.ErrorMessages = New List(Of String) From {"İstenen sonuç bulunamadı", "HATA", "Lütfen tekrar deneyiniz...", "Veri çekilemedi, format içeriklerini kontrol ediniz"}

        Else
            response.StatusCode = StatusCodes.Status500InternalServerError
            apiResponse.StatusCode = StatusCodes.Status500InternalServerError
            apiResponse.ErrorMessages = New List(Of String) From {"Sunucu kaynaklı beklenmedik bir hata ile karşılandı", "HATA", "Url isteklerini, parametre değerlerini vs. lütfen kontrol ediniz"}
        End If

        Dim exResult = JsonSerializer.Serialize(apiResponse)

        Await context.Response.WriteAsync(exResult)

    End Function


End Class

'app.UseMiddleware(Of GlobalExceptionHandlingMiddleware)()
