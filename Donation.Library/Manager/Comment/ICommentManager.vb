Imports System.Web.Mvc

Public Interface ICommentManager

#Region "Interface Methods"
    ''' <summary>
    ''' Get all comments.
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AllComments(controller As Controller) As List(Of CommentModel)

    ''' <summary>
    ''' Add a comment.
    ''' </summary>
    ''' <param name="commentModel"></param>
    ''' <param name="controller"></param>
    ''' <remarks></remarks>
    Sub AddComment(commentModel As CommentModel, controller As Controller)

#End Region
End Interface
