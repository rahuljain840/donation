Public Class CommentModel
    Private _donationID As Guid
    Public Property ID() As Guid
        Get
            Return _donationID
        End Get
        Set(ByVal value As Guid)
            _donationID = value
        End Set
    End Property

    Private _user As UserModel
    Public Property User() As UserModel
        Get
            Return _user
        End Get
        Set(ByVal value As UserModel)
            _user = value
        End Set
    End Property

    Private _dateAdded As Date
    Public Property DateAdded() As Date
        Get
            Return _dateAdded
        End Get
        Set(ByVal value As Date)
            _dateAdded = value
        End Set
    End Property

    Private _comment As String = String.Empty
    Public Property Comment() As String
        Get
            Return _comment
        End Get
        Set(ByVal value As String)
            _comment = value
        End Set
    End Property
End Class
