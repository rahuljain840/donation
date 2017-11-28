Imports System.Web.Mvc

Public Class GoalManager
    Implements IGoalManager

#Region "Public Methods"

    ''' <summary>
    ''' Get goal value fromt temp data
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GoalValue(controller As Controller) As Double Implements IGoalManager.GoalValue
        If controller.TempData("Donations") Is Nothing Then
            Return 0
        End If

        Dim donations As List(Of DonationModel) = CType(controller.TempData.Peek("Donations"), List(Of DonationModel))
        controller.TempData.Keep("Donations")

        Return donations.Sum(Function(d) d.Amount)
    End Function

#End Region

End Class
