Imports System.Web.Mvc

Public Class DonationManager
    Implements IDonationManager

#Region "Public Methods"

    ''' <summary>
    ''' Get all donations from temp data.
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function AllDonation(controller As Controller) As List(Of DonationModel) Implements IDonationManager.AllDonation
        Dim donations

        If controller.TempData("Donations") Is Nothing Then
            donations = New List(Of DonationModel)
        Else
            donations = CType(controller.TempData.Peek("Donations"), List(Of DonationModel))
            controller.TempData.Keep("Donations")
        End If

        Return donations
    End Function

    ''' <summary>
    ''' Add a donations to temp data.
    ''' </summary>
    ''' <param name="donationModel"></param>
    ''' <param name="controller"></param>
    ''' <remarks></remarks>
    Public Sub AddDonation(donationModel As DonationModel, controller As Controller) Implements IDonationManager.AddDonation
        Dim donations

        If controller.TempData("Donations") Is Nothing Then
            donations = New List(Of DonationModel)
        Else
            donations = CType(controller.TempData("Donations"), List(Of DonationModel))
        End If

        donations.Insert(0, donationModel)
        controller.TempData("Donations") = donations
    End Sub

#End Region

End Class
