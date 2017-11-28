@ModelType Donation.Library.DashboardModel

@Code
    ViewData("Title") = "Donation Page"
End Code

@Styles.Render("~/Content/datatable",
                    "/Content/jquery-ui.css")
@Scripts.Render("~/Scripts/jquery.unobtrusive-ajax.min.js",
                     "~/bundles/datatable",
                     "/Scripts/jquery-ui.js",
                     "/Scripts/raphael-2.1.4.min.js",
                     "/Scripts/justgage.js",
                     "~/Scripts/PageScripts/dashboard.js")

@*<div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
        <p><a href="http://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>*@

<div class="main">

    <div class="row">
        <div class="container">
            <div class="col-sm-6" id="divComments">
                @Html.Partial("_Comments", Model.Comments)
            </div>
            <div class="col-sm-6" id="divGoals">
                @Html.Partial("_Goals")
            </div>
        </div>
    </div>

    <div class="row divListDonation">
        <div class="container">
            <div class="col-sm-12">
                <div class="section-top-inner">
                    <div class="panel-group">
                        <div class="panel panel-success">
                            <div class="panel-heading">
                                <div class="row">
                                    <div class="col-sm-4 pull-left">
                                        <h3 class="panelHeading">Donations</h3>
                                    </div>
                                    <div class="col-sm-8 pull-right">
                                        <button id="btnAddDonation" class="pull-right btn text-center"><span class="glyphicon glyphicon-plus"></span> Add Donation</button>
                                    </div>
                                </div>
                            </div>
                            <div class="panel-body" id="divDonationList">
                                @Html.Partial("_DonationList", Model.Donations)
                            </div>
                        </div>
                    </div>
                    <div id="divAddDonation" title="Add Donation">
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

