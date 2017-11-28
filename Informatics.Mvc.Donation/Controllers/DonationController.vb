Imports System.Web.Mvc
Imports System.Net
Imports Donation.Library
Imports StructureMap

Namespace Controllers
    Public Class DonationController
        Inherits Controller

#Region "Property declarations"
        Private CommentManagerContext As ICommentManager
        Private DonationManagerContext As IDonationManager
#End Region

#Region "Constructor"
        ''' <summary>
        ''' For structure map DI
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            Me.New(ObjectFactory.GetInstance(Of IDonationManager), ObjectFactory.GetInstance(Of ICommentManager))
        End Sub

        ''' <summary>
        ''' For structure map DI
        ''' </summary>
        ''' <param name="donationManager"></param>
        ''' <param name="commentManager"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal donationManager As IDonationManager, ByVal commentManager As ICommentManager)
            Me.DonationManagerContext = donationManager
            Me.CommentManagerContext = commentManager
        End Sub

#End Region

#Region "Public Methods"
        ''' <summary>
        ''' Index View
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function Index() As ActionResult
            Return View()
        End Function

        ''' <summary>
        ''' Add index
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <HttpGet>
        Function Add() As ActionResult
            Return PartialView("_AddDonation")
        End Function

        ''' <summary>
        ''' Add donation and comment
        ''' </summary>
        ''' <param name="donation"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <HttpPost>
        Function Add(donation As DonationBO) As ActionResult
            If Not ModelState.IsValid Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim donationModel As New DonationModel With
                {
                    .ID = New Guid(),
                    .Amount = donation.Amount,
                    .DateAdded = Date.UtcNow,
                    .Name = donation.Name
                }

            DonationManagerContext.AddDonation(donationModel, Me)

            If Not String.IsNullOrWhiteSpace(donation.Comment) Then
                Dim rndmValue As Integer = CInt(Int((4 * Rnd()) + 1))

                Dim commentModel As New CommentModel With
                    {
                        .ID = Guid.NewGuid(),
                        .Comment = donation.Comment,
                        .DateAdded = Date.UtcNow,
                        .User = New UserModel With
                                {
                                    .Name = donation.Name,
                                    .ImageUrl = "/images/profile/p" + rndmValue.ToString() + ".jpg"
                                }
                    }

                CommentManagerContext.AddComment(commentModel, Me)
            End If

            Return Json(New With {.success = True})
        End Function

        ''' <summary>
        ''' List donations
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function List() As ActionResult
            Dim donations = DonationManagerContext.AllDonation(Me)

            Return PartialView("_DonationList", donations)
        End Function
#End Region

    End Class
End Namespace