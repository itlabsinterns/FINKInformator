$(document).ready(function () {

    getPrograms();

    $("#zadolzitelni").hide();
    $("#izborni").hide();
    var year = 0;
    var program = 0;
    var semester = 0;
    var forRequest;
    $("#img1").on("click","#25",function(){
        program = 25;
        scroll_to_div('img2');
    })
    $("#img1").on("click","#26",function(){
        program = 26;
        scroll_to_div('img2');
    })
    $("#img1").on("click","#27",function(){
        program = 27;
        scroll_to_div('img2');
    })
        $("#img1").on("click","#28",function(){
        program = 28;
        scroll_to_div('img2');
    })
    $("#prvaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('img1');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('img3');
        year = 1;
        }   
    })
    $("#vtoraGodina").click(function () {
        if (program == 0) {
            scroll_to_div('img1');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('img3');
        year = 2;
        }
    })
    $("#tretaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('img1');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('img3');
        year = 3;
        }
    })
    $("#cetvrtaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('img1');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('img3');
        year = 4;
        }
    })
    $("#prvSemestar").click(function () {
        if(year == 0 && program == 0){
            errorDiv("Не избравте смер и година");
            scroll_to_div('img1');
        }
        else if (year == 0){
            errorDiv("Не избравте година");
            scroll_to_div('img2');
        }
        else if (program == 0){
            errorDiv("Не избравте смер");
            scroll_to_div('img1');
        }else{
        semester = 1;
        forRequest = year * 2 + semester - 2;
        $("#Zadolzitelni").empty();
        $("#Izborni").empty();
        getInfoAndFillLists(program, forRequest);
        scroll_to_div('img4');
        }
    })
    $("#vtorSemestar").click(function () {
        if(year == 0 && program == 0){
            errorDiv("Не избравте смер и година");
            scroll_to_div('img1');
        }
        else if (year == 0){
            errorDiv("Не избравте година");
            scroll_to_div('img2');
        }
        else if (program == 0){
            errorDiv("Не избравте смер");
            scroll_to_div('img1');
        }else{
        semester = 2;
        forRequest = year * 2 + semester - 2;
        $("#Zadolzitelni").empty();
        $("#Izborni").empty();
        getInfoAndFillLists(program, forRequest);
        scroll_to_div('img4');
        }
    })

    function getInfoAndFillLists(program, forRequest) {
        $.ajax({
            type: 'GET',
            url: "http://localhost:4329/programs/" + program + "/" + forRequest,
            dataType: 'json',
            success: function (data) {
                $.each(data, function (i, item) {
                    if (item.IsMandatory == true) {
                        $("#Zadolzitelni").append('<a id="' + item.Course.CourseId + '" class="list-group-item list-group-item-danger">' + item.Course.CourseName + '</a>')
                    } else {
                        $("#Izborni").append('<a id=' + item.Course.CourseId + ' class="list-group-item list-group-item-success">' + item.Course.CourseName + '</a>')

                    }
                })
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
                    $("#img1").append('<button id=' + item.ProgramId + ' style="position:absolute; left:20%;right:20%; width:60%; top:' + (3+i)*10 + '%; " type="button" class="btn btn-lg btn-danger" >'+ item.ProgramName +'</button>')
                })
            }
        })
    }

    function scroll_to_div(div_id) {
        $('html,body').animate(
        {
            scrollTop: $("#" + div_id).offset().top
        },
        2000);
    }

    function errorDiv(message){
        $("#img1").prepend('<div style="left:20%; top:15%; width:60%;" class="alert alert-danger alert-dismissable fade in abs"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Предупредување! </strong>' 
        + message + '</div>');
    }


    $("#img4").on("click","a",function(){
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

})