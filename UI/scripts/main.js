function scroll_to_div(div_id) {
    $('html,body').animate(
    {
        scrollTop: $("#" + div_id).offset().top
    },
    2000);
}
$(document).ready(function () {
    $("#zadolzitelni").hide();
    $("#izborni").hide();
    var year = 0;
    var program = 0;
    var semester = 0;
    var forRequest;
    $("#kni").click(function () {
        program = 25;
    });
    $("#pet").click(function () {
        program = 26;
    })
    $("#mt").click(function () {
        program = 28;
    })
    $("#iki").click(function () {
        program = 27;
    })
    $("#prvaGodina").click(function () {
        if (program == 0) {
            alert("izberi Programa");
        }
        year = 1;
    })
    $("#vtoraGodina").click(function () {
        if (program == 0) {
            alert("izberi Programa");
        }
        year = 2;
    })
    $("#tretaGodina").click(function () {
        if (program == 0) {
            alert("izberi Programa");
        }
        year = 3;
    })
    $("#cetvrtaGodina").click(function () {
        if (program == 0) {
            alert("izberi Programa");
        }
        year = 4;
    })
    $("#prvSemestar").click(function () {
        $("#zadolzitelni").show();
        $("#izborni").show();
        if (year == 0)
            alert("izberi Godina");
        if (program == 0)
            alert("izberi Programa");
        semester = 1;
        forRequest = year * 2 + semester - 2;
        getInfoAndFillLists(program, forRequest);
    })
    $("#vtorSemestar").click(function () {
        $("#zadolzitelni").show();
        $("#izborni").show();
        if (year == 0)
            alert("izberi Godina");
        if (program == 0)
            alert("izberi Programa");
        semester = 2;
        forRequest = year * 2 + semester - 2;
        getInfoAndFillLists(program, forRequest);
    })

    function getInfoAndFillLists(program, forRequest) {
        $.ajax({
            type: 'GET',
            url: "http://localhost:4329/programs/" + program + "/" + forRequest,
            dataType: 'json',
            success: function (data) {
                $.each(data, function (i, item) {
                    if (item.IsMandatory == true) {
                        $("#Zadolzitelni").append('<a id=' + item.Course.CourseId + ' class="custom list-group-item">' + item.Course.CourseName + '</a>')
                    } else {
                        $("#Izborni").append('<a id=' + item.Course.CourseId + ' class="custom list-group-item">' + item.Course.CourseName + '</a>')

                    }
                })
            }
        })
    }
})