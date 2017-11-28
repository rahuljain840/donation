Public Class DashboardModel

    Private _goalTarget As Double = 100000
    Public Property GoalTarget() As Double
        Get
            Return _goalTarget
        End Get
        Set(ByVal value As Double)
            _goalTarget = value
        End Set
    End Property

    Private _donations As IEnumerable(Of DonationModel)
    Public Property Donations() As IEnumerable(Of DonationModel)
        Get
            Return _donations
        End Get
        Set(ByVal value As IEnumerable(Of DonationModel))
            _donations = value
        End Set
    End Property

    Private _comments As IEnumerable(Of CommentModel)
    Public Property Comments() As IEnumerable(Of CommentModel)
        Get
            Return _comments
        End Get
        Set(ByVal value As IEnumerable(Of CommentModel))
            _comments = value
        End Set
    End Property

    Sub New()

        Donations = New List(Of DonationModel)

    End Sub

End Class
