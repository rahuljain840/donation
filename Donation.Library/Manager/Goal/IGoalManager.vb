Imports System.Web.Mvc

Public Interface IGoalManager

#Region "Interface Methods"

    ''' <summary>
    ''' Get goal value.
    ''' </summary>
    ''' <param name="controller"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function GoalValue(controller As Controller) As Double

#End Region

End Interface
