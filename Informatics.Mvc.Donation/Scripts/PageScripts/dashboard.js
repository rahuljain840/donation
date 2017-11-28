var dashboard = (function (window, $) {
    var dialog;

    Number.prototype.formatMoney = function (c, d, t) {
        var n = this,
            c = isNaN(c = Math.abs(c)) ? 2 : c,
            d = d == undefined ? "." : d,
            t = t == undefined ? "," : t,
            s = n < 0 ? "-" : "",
            i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
            j = (j = i.length) > 3 ? j % 3 : 0;
        return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
    };

    function initializeDialog() {
        dialog = $("#divAddDonation").dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                "Save": function (element, event) {
                    $("#addDonationForm").submit();
                },
                Cancel: function () {
                    dialog.dialog("close");
                }
            },
            close: function () {
                dialog.dialog("close");
            },
            width: 'auto'
        });
    }

    function getAsync(url, settings) {
        return Promise.resolve($.ajax(url, settings));
    }

    function showAddDonationForm() {
        var url = '/Donation/Add';

        getAsync(url, { cache: false })
                .then(function (data) {
                    $('#divAddDonation').html(data);
                    dialog.dialog('open');


                    $('#textbxDonationAmount').on('keydown keyup', function (e) {
                        if ($(this).val().length > 9
                            && e.keyCode != 46 // delete
                            && e.keyCode != 8 // backspace
                            && e.keyCode != 9 // tab
                           ) {
                            e.preventDefault();

                        }
                    });
                })
                .catch(function () {
                    alert('Error: There was an error while loading form');
                });
    }

    function initializeGraph(value) {
        var g = new JustGage({
            id: "gauge",
            value: value,
            min: 0,
            max: 100000,
            title: "",
            textRenderer: function (val) {
                return ("$" + val.formatMoney(2));
            }
        });
    }

    $(document).ready(function () {
        initializeDialog();

        initializeDonationsTable();

        $('#btnAddDonation').click(function () {
            showAddDonationForm();
        });

        initializeGraph(0);
    });

    function initializeDonationsTable() {

        $('#tblDonation').DataTable({
            "language": {
                "emptyTable": "No donation(s) available"
            },
            "order": [[2, "desc"]]
        });
    }

    function addDonationFailureCallback(data) {
        alert(data.statusText);
    };

    function addDonationSuccessCallback(data) {
        if (!data.success) {
            alert("Server error");
            return;
        }

        dialog.dialog("close");

        loadDonationsGrid();
        loadCommentsBox();
        updateGoalValue();
    }

    function loadDonationsGrid() {
        var url = '/Donation/List';

        getAsync(url, { cache: false })
                .then(function (data) {
                    $('#divDonationList').html(data);

                    initializeDonationsTable();
                })
                .catch(function () {
                    alert('Error: There was an error while loading form');
                });
    }

    function loadCommentsBox() {
        var url = '/Home/Comments';

        getAsync(url, { cache: false })
                .then(function (data) {
                    $('#divComments').html(data);
                })
                .catch(function () {
                    alert('Error: There was an error while loading form');
                });
    }

    function updateGoalValue() {
        var url = '/Home/GoalValue';

        getAsync(url, { cache: false })
                .then(function (data) {
                    if (data.success) {
                        $('#gauge').html('');
                        initializeGraph(data.totalDonation);
                    }
                })
                .catch(function () {
                    alert('Error: There was an error while loading form');
                });
    }

    return {
        addDonationFailureCallback: addDonationFailureCallback,
        addDonationSuccessCallback: addDonationSuccessCallback
    }

})(window, jQuery);