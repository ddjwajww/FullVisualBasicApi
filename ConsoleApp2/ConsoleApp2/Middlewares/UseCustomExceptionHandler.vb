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
