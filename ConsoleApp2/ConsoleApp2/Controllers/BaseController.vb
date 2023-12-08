Imports infrastructure
Imports Microsoft.AspNetCore.Http
Imports Microsoft.AspNetCore.Mvc


Public Class BaseController
    Inherits ControllerBase

    Public Function SendResponse(Of T)(response As ApiResponse(Of T)) As ActionResult
        If response.StatusCode = StatusCodes.Status204NoContent Then
            Return New ObjectResult(Nothing) With {.StatusCode = response.StatusCode}
        End If

        Return New ObjectResult(response) With {.StatusCode = response.StatusCode}
    End Function
End Class

