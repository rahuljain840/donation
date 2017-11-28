Imports System.Web.Mvc

Public Interface IDonationManager

#Region "Interface Methods"
    ''' <summary>
    ''' Get all donations.
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function AllDonation(controller As Controller) As List(Of DonationModel)

    ''' <summary>
    ''' Add a donation
    ''' </summary>
    ''' <param name="donationModel"></param>
    ''' <param name="controller"></param>
    ''' <remarks></remarks>
    Sub AddDonation(donationModel As DonationModel, controller As Controller)

#End Region

End Interface

