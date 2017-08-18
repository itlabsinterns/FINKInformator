$(document).ready(function () {

    getPrograms();
    $("#Zadolzitelni").hide();
    $("#Izborni").hide();
    var year = 0;
    var program = 0;
    var semester = 0;
    var forRequest;
    $("#programsButtonContainer").on("click","#25",function(){
        program = 25;
        scroll_to_div('yearContainer');
    })
    $("#programsButtonContainer").on("click","#26",function(){
        program = 26;
        scroll_to_div('yearContainer');
    })
    $("#programsButtonContainer").on("click","#27",function(){
        program = 27;
        scroll_to_div('yearContainer');
    })
        $("#programsButtonContainer").on("click","#28",function(){
        program = 28;
        scroll_to_div('yearContainer');
    })
    $("#prvaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('programsContainer');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('semesterContainer');
        year = 1;
        }   
    })
    $("#vtoraGodina").click(function () {
        if (program == 0) {
            scroll_to_div('programsContainer');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('semesterContainer');
        year = 2;
        }
    })
    $("#tretaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('programsContainer');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('semesterContainer');
        year = 3;
        }
    })
    $("#cetvrtaGodina").click(function () {
        if (program == 0) {
            scroll_to_div('programsContainer');
            errorDiv("Не избравте смер");
        }else{
        scroll_to_div('semesterContainer');
        year = 4;
        }
    })
    $("#prvSemestar").click(function () {
        if(year == 0 && program == 0){
            errorDiv("Не избравте смер и година");
            scroll_to_div('programsContainer');
        }
        else if (year == 0){
            errorDiv("Не избравте година");
            scroll_to_div('programsContainer');
        }
        else if (program == 0){
            errorDiv("Не избравте смер");
            scroll_to_div('programsContainer');
        }else{
        semester = 1;
        forRequest = year * 2 + semester - 2;
        $("#Zadolzitelni").empty();
        $("#Izborni").empty();
        getInfoAndFillLists(program, forRequest);
        scroll_to_div('coursesContainer');
        }
    })
    $("#vtorSemestar").click(function () {
        if(year == 0 && program == 0){
            errorDiv("Не избравте смер и година");
            scroll_to_div('programsContainer');
        }
        else if (year == 0){
            errorDiv("Не избравте година");
            scroll_to_div('programsContainer');
        }
        else if (program == 0){
            errorDiv("Не избравте смер");
            scroll_to_div('programsContainer');
        }else{
        semester = 2;
        forRequest = year * 2 + semester - 2;
        $("#Zadolzitelni").empty();
        $("#Izborni").empty();
        getInfoAndFillLists(program, forRequest);
        scroll_to_div('coursesContainer');
        }
    })

    function getInfoAndFillLists(program, forRequest) {
        $.ajax({
            type: 'GET',
            url: "http://localhost:4329/programs/" + program + "/" + forRequest,
            dataType: 'json',
            success: function (data) {
                $("#Zadolzitelni").append('<a style="text-align:center; color: white !important; background-color: dimgray!important;" id="zad" class="list-group-item forli"><b>ЗАДОЛЖИТЕЛНИ ПРЕДМЕТИ</b></a>')
                $("#Izborni").append('<a style="text-align:center; color: white !important; background-color: dimgray!important;" id="zad" class="list-group-item forli"><b>ИЗБОРНИ ПРЕДМЕТИ</b></a>')
                $.each(data, function (i, item) {
                    if (item.IsMandatory == true) {
                        $("#Zadolzitelni").append('<a id="' + item.Course.CourseId + '" class="list-group-item forli ">' + item.Course.CourseName + '</a>')
                    } else {
                        $("#Izborni").append('<a id=' + item.Course.CourseId + ' class="list-group-item forli ">' + item.Course.CourseName + '</a>')
                    
                    }    
                })
                $("#Zadolzitelni").show();
                if($("#Izborni > a").length>1){
                    $("#Izborni").show();
                }
             while($("#Zadolzitelni > a").length<=5){
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
                    $("#programsButtonContainer").append('<button id=' + item.ProgramId + ' style="margin-bottom:4%;" type="button" class="btn btn-lg btn-block btn-danger" ><b>'+ item.ProgramName.toUpperCase() +'</b></button>')
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
        $("#error").remove();
        $("#programsContainer").prepend('<div id="error" style="margin-top:8%;" class="alert alert-danger alert-dismissable fade in text-center"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>Предупредување! </strong>' 
        + message + '</div>');
    }


    $("#coursesContainer").on("click","a",function(){
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