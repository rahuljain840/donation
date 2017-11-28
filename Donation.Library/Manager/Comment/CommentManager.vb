Imports System.Web.Mvc

Public Class CommentManager
    Implements ICommentManager

#Region "Public Methods"
    ''' <summary>
    ''' Get all comments from temp data.
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AllComments(controller As Controller) As List(Of CommentModel) Implements ICommentManager.AllComments
        Dim commentsList

        If controller.TempData("Comments") Is Nothing Then
            commentsList = New List(Of CommentModel)
        Else
            commentsList = CType(controller.TempData.Peek("Comments"), List(Of CommentModel))
            controller.TempData.Keep("Comments")
        End If

        Return commentsList
    End Function

    ''' <summary>
    ''' Add comment to temp data.
    ''' </summary>
    ''' <param name="commentModel"></param>
    ''' <param name="controller"></param>
    ''' <remarks></remarks>
    Public Sub AddComment(commentModel As CommentModel, controller As Controller) Implements ICommentManager.AddComment
        Dim comments As List(Of CommentModel)

        If controller.TempData("Comments") Is Nothing Then
            comments = New List(Of CommentModel)
        Else
            comments = CType(controller.TempData("Comments"), List(Of CommentModel))
        End If

        comments.Insert(0, commentModel)
        controller.TempData("Comments") = comments
    End Sub
#End Region

End Class
