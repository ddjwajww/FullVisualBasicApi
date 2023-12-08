Imports Microsoft.EntityFrameworkCore
Imports System.Linq.Expressions
Imports System.Threading.Tasks

Public Class BaseRepository(Of TEntity As {Class, IEntity}, TContext As {DbContext, New})
    Implements IBaseRepository(Of TEntity)

    Public Async Function GetAsync(predicate As Expression(Of Func(Of TEntity, Boolean)), ParamArray includeList As String()) As Task(Of TEntity) Implements IBaseRepository(Of TEntity).GetAsync
        Using context = New TContext()
            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)()

            If includeList IsNot Nothing Then
                For Each include In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            Return Await dbSet.SingleOrDefaultAsync(predicate)
        End Using
    End Function

    'Public Async Function IBaseRepository_GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList() As String = Nothing) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity).GetAllAsync
    '    Using context = New TContext()
    '        Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)()

    '        If includeList IsNot Nothing Then
    '            For Each include In includeList
    '                dbSet = dbSet.Include(include)
    '            Next
    '        End If

    '        If predicate Is Nothing Then
    '            Return Await dbSet.ToListAsync()
    '        End If

    '        Return Await dbSet.Where(predicate).ToListAsync()
    '    End Using
    'End Function

    Public Async Function GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList As String() = Nothing) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity).GetAllAsync
        Using context = New TContext()
            Dim dbSet As IQueryable(Of TEntity) = context.Set(Of TEntity)()

            If includeList IsNot Nothing Then
                For Each include In includeList
                    dbSet = dbSet.Include(include)
                Next
            End If

            If predicate Is Nothing Then
                Return Await dbSet.ToListAsync()
            End If

            Return Await dbSet.Where(predicate).ToListAsync()
        End Using
    End Function

    'Public Async Function GetAllAsync(Optional predicate As Expression(Of Func(Of TEntity, Boolean)) = Nothing, Optional includeList As String()) As Task(Of List(Of TEntity)) Implements IBaseRepository(Of TEntity).GetAllAsync

    'End Function

    Public Async Function InsertAsync(entity As TEntity) As Task(Of TEntity) Implements IBaseRepository(Of TEntity).InsertAsync
        Using context = New TContext()
            Dim entityEntry = Await context.Set(Of TEntity)().AddAsync(entity)
            Await context.SaveChangesAsync()
            Return entityEntry.Entity
        End Using
    End Function

    Public Async Function UpdateAsync(entity As TEntity) As Task Implements IBaseRepository(Of TEntity).UpdateAsync
        Using context = New TContext()
            context.Set(Of TEntity)().Update(entity)
            Await context.SaveChangesAsync()
        End Using
    End Function

    Public Async Function DeleteAsync(entity As TEntity) As Task Implements IBaseRepository(Of TEntity).DeleteAsync
        Using context = New TContext()
            context.Set(Of TEntity)().Remove(entity)
            Await context.SaveChangesAsync()
        End Using
    End Function


End Class
