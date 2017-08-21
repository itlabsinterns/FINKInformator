$(document).ready(function () {
    init();
    getPrograms();
    attachProgramEvents();
    attachEvents();

    function init() {
        $("#Zadolzitelni").hide();
        $("#Izborni").hide();
        var year = 0;
        var program = 0;
        var semester = 0;
    }

    function getInfoAndFillLists(program, forRequest) {
        $.ajax({
            type: 'GET',
            url: "http://localhost:4329/programs/" + program + "/" + forRequest,
            dataType: 'json',
            success: function (data) {
                $("#Zadolzitelni").append('<a style="text-align:center; color: white !important; background-color: dimgray!important;" id="zad" class="list-group-item forli"><b>ЗАДОЛЖИТЕЛНИ ПРЕДМЕТИ</b></a>');

                $("#Izborni").append('<a style="text-align:center; color: white !important; background-color: dimgray!important;" id="zad" class="list-group-item forli"><b>ИЗБОРНИ ПРЕДМЕТИ</b></a>');

                $.each(data, function (i, item) {
                    var course = $('<a id="' + item.Course.CourseId + '" class="list-group-item forli ">' + item.Course.CourseName + '</a>');

                    if (item.IsMandatory)
                        $("#Zadolzitelni").append(course);
                    else
                        $("#Izborni").append(course);
                });

                $("#Zadolzitelni").show();
                if ($("#Izborni > a").length > 1) {
                    $("#Izborni").show();
                }

                while ($("#Zadolzitelni > a").length <= 5) {
                    $("#Zadolzitelni").append('<a class="list-group-item forli">-ИЗБОРЕН ПРЕДМЕТ-</a>');
                }
            }
        })
    }

    function getPrograms() {
        $.ajax({
            type: 'GET',
            url: "http://localhost:4329/programs/",
            dataType: 'json',
            success: function (data) {
                $.each(data.Programs, function (i, item) {
                    $("#programsButtonContainer").append('<button programId=' + item.ProgramId + ' style="margin-bottom:4%;" type="button" class="btn btn-lg btn-block btn-danger" ><b>' + item.ProgramName.toUpperCase() + '</b></button>')
                })
            }
        })
    }

    function scroll_to_div(div_id) {
        $('html,body').animate(
        {
            scrollTop: $("#" + div_id).offset().top
        },
        1000);
    }

    function errorDiv(message) {
        $("#error").remove();
        $("#programsContainer").prepend('<div id="error" style="margin-top:8%;" class="alert alert-danger alert-dismissable fade in text-center"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Предупредување! </strong>'
        + message + '</div>');
    }

    function attachProgramEvents() {
        $("#programsButtonContainer").on("click", ".btn", function () {
            program = $(this).attr("programId");
            scroll_to_div('yearContainer');
        })

    }

    function attachEvents() {
        $(".godina").click(function () {
            if (program == 0) {
                scroll_to_div('programsContainer');
                errorDiv("Не избравте смер");
            } else {
                scroll_to_div('semesterContainer');
                year = $(this).attr("year");
            }
        })

        $("#semesterButtonContainer").on("click", ".btn", (function () {
            if (year == 0 && program == 0) {
                errorDiv("Не избравте смер и година");
                scroll_to_div('programsContainer');
            }
            else if (year == 0) {
                errorDiv("Не избравте година");
                scroll_to_div('programsContainer');
            }
            else if (program == 0) {
                errorDiv("Не избравте смер");
                scroll_to_div('programsContainer');
            } else {
                semester = $(this).attr("semester");
                console.log(year + " " + semester);
                var final = (year * 2) + (semester - 2);
                $("#Zadolzitelni").empty();
                $("#Izborni").empty();
                getInfoAndFillLists(program, final);
                scroll_to_div('coursesContainer');
            }
        }))

        $("#coursesContainer").on("click", "a", function () {
            $.ajax({
                type: 'GET',
                url: "http://localhost:4329/courses/" + this.id,
                dataType: 'json',
                success: function (data) {

                    $("#modalTitle").text(data.Course.CourseName);
                    $("#modalBody").text(data.Course.CourseDescription);
                    $("#myModal").modal();
                }
            })
        })
    }

})