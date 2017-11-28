@ModelType DonationBO
@Scripts.Render("~/bundles/jqueryval")

@*Html.BeginForm("Register", "Account", FormMethod.Post, New With {.class = "form-horizontal", .role = "form"})*@
@Using Ajax.BeginForm("Add", "Donation", vbNull,
                     New AjaxOptions With {
                         .OnSuccess = "dashboard.addDonationSuccessCallback", .HttpMethod = "POST", .OnFailure = "dashboard.addDonationFailureCallback"},
                     New With {.class = "form-horizontal", .role = "form", .id = "addDonationForm"})

    @Html.AntiForgeryToken()

    @*@Html.ValidationSummary("", New With {.class = "text-danger"})*@
    @<text>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Name, New With {.class = "col-md-4 control-label required"})
            <div class="col-md-8">
                @Html.TextBoxFor(Function(m) m.Name, New With {.maxlength = 100, .class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Name)
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Amount, New With {.class = "col-md-4 control-label required"})
            <div class="col-md-8">
                @Html.TextBoxFor(Function(m) m.Amount, New With {.max = 9999999999, .class = "form-control", .id = "textbxDonationAmount", .type = "number"})
                @Html.ValidationMessageFor(Function(m) m.Amount)
            </div>
        </div>
        <div class="form-group">
            @Html.LabelFor(Function(m) m.Comment, New With {.class = "col-md-4 control-label"})
            <div class="col-md-8">
                @Html.TextAreaFor(Function(m) m.Comment, New With {.class = "form-control"})
                @Html.ValidationMessageFor(Function(m) m.Comment)
            </div>
        </div>
        <div class="form-group hidden">
            <div class="col-md-offset-2 col-md-10">
                <input type="submit" class="btn btn-default" value="Submit" />
            </div>
        </div>
    </text>
End Using
