Imports System.ComponentModel.DataAnnotations

Public Class DonationBO
    <Required>
    <MaxLength(100)>
    <Display(Name:="Name")>
    Public Property Name As String

    <Required>
    <Display(Name:="Donation")>
    Public Property Amount As Double

    <Display(Name:="Comment")>
    <MaxLength(512)>
    Public Property Comment As String

End Class
