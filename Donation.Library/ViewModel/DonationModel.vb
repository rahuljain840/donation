Public Class DonationModel

    Private _donationID As Guid
    Public Property ID() As Guid
        Get
            Return _donationID
        End Get
        Set(ByVal value As Guid)
            _donationID = value
        End Set
    End Property

    Private _name As String = String.Empty
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
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


End Class
