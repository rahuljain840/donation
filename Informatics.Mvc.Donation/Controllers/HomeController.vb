Imports Donation.Library
Imports StructureMap

Public Class HomeController
    Inherits System.Web.Mvc.Controller

#Region "Property declarations"
    Private CommentManagerContext As ICommentManager
    Private GoalManagerContext As IGoalManager
#End Region

#Region "Constructor"
    ''' <summary>
    ''' For structure map DI
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        Me.New(ObjectFactory.GetInstance(Of ICommentManager), ObjectFactory.GetInstance(Of IGoalManager))
    End Sub

    ''' <summary>
    ''' For structure map DI
    ''' </summary>
    ''' <param name="commentManager"></param>
    ''' <param name="goalManager"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal commentManager As ICommentManager, ByVal goalManager As IGoalManager)
        Me.CommentManagerContext = commentManager
        Me.GoalManagerContext = goalManager
    End Sub
#End Region

#Region "Public Methods"
    ''' <summary>
    ''' Index page
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Index() As ActionResult
        TempData("Donations") = Nothing
        TempData("Comments") = Nothing

        Dim dashboard As New DashboardModel
        dashboard.Comments = New List(Of CommentModel)

        Return View(dashboard)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    ''' <summary>
    ''' Get all comments
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Comments() As ActionResult
        Dim commentsList = CommentManagerContext.AllComments(Me)

        Return PartialView("_Comments", commentsList)
    End Function

    Function Goal() As ActionResult
        Return PartialView("_Goals")
    End Function

    ''' <summary>
    ''' Get donations toal.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <HttpGet>
    Function GoalValue() As ActionResult

        Dim totalDonation = GoalManagerContext.GoalValue(Me)

        Return Json(New With {.success = True, .totalDonation = totalDonation}, JsonRequestBehavior.AllowGet)
    End Function
#End Region

End Class
