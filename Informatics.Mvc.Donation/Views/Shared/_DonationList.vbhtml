@ModelType IEnumerable(Of Donation.Library.DonationModel)

<table id="tblDonation" class="display" cellspacing="0" width="100%">
    <thead>
        <tr>
            <th>Name</th>
            <th>Donation</th>
            <th>Donation date</th>
        </tr>
    </thead>
    <tbody>
        @For Each donationItem In Model
            @<tr id="@donationItem.ID">
                <td>@donationItem.Name</td>
                <td>
                    @donationItem.Amount.ToString("C", New System.Globalization.CultureInfo("en-US"))
                </td>
                <td>@donationItem.DateAdded.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)</td>
            </tr>
        Next
    </tbody>
</table>

