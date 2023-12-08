Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Interface IBaseRepository(Of TEntity As {Class, IEntity})

    Function GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList As String() = Nothing) As Task(Of List(Of TEntity))
    Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of TEntity)
    Function InsertAsync(entity As TEntity) As Task(Of TEntity)
    Function UpdateAsync(entity As TEntity) As Task
    Function DeleteAsync(entity As TEntity) As Task

End Interface
