Imports StructureMap.Configuration.DSL
Imports Donation.Library

Public Class StructureMapRegistry
    Inherits Registry

    Public Sub New()
        [For](Of IDonationManager)().Use(Of DonationManager)()
        [For](Of ICommentManager)().Use(Of CommentManager)()
        [For](Of IGoalManager)().Use(Of GoalManager)()
    End Sub

End Class
