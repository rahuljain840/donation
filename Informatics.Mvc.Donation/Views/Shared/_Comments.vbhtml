@ModelType IEnumerable(Of Donation.Library.CommentModel)

<div class="section-top-inner">
    <div class="panel-group">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3 class="panelHeading">Comments (@Model.Count())</h3>
            </div>
            <div class="panel-body divPanelBody">
                @If Model Is Nothing Or Model.Count() < 1 Then
                    @<div class="no-comment text-center">
                        No comments found.
                    </div>
                Else
                    @<ul class="commentList">
                        @For Each comment In Model
                            @<li>
                                <div class="commenterImage">
                                    <img src="@comment.User.ImageUrl" />
                                </div>
                                <div class="commentText">
                                    <span class="date sub-text"><span>@comment.User.Name</span>,&nbsp;@comment.DateAdded.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture)</span>
                                    <p class="">@comment.Comment</p>
                                </div>
                            </li>
                        Next
                    </ul>
                End If
            </div>
        </div>
    </div>
</div>
