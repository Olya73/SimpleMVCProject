
$(document).ready(function () {
    $("#searchLink").click(function () {
        var text = $("#searchLine").val();
        var partialDiv = $("#partialDiv");
        $.ajax({
            cache: false,
            type: "GET",
            url: "Home/PartialSearch",
            data: { "name": text },
            success: function (data) {
                partialDiv.html("");
                partialDiv.html(data);
            },
            error: function (xhr, ajOpt, thrownError) {
                alert("Failed to retrieve students");
            }
        })
    })
    $("#AddAsync").click(function () {
        var partialDiv = $("#toAdd");
        partialDiv.html("<input id='name' type='text'/><input id='familya' type='text'/><input id='ok' onclick = 'Add()' type='submit'/>");

    })
    
})

function Add() {
    var name = $("#name").val();
    var fam = $("#familya").val();
    var partialDiv = $("#partialDiv");
    $.ajax({
        cache: false,
        type: "POST",
        url: "Home/PartialSearchJson",
        data: { "Name": name, "Surname": fam },
        success: function (data) {
            partialDiv.html("");
            var result;
            $.each(data, function (key, val) {
                result += '<p>' + key + ' ' + val + '</p>';
                
            })
            partialDiv.append(result);
            $("#toAdd").hide();
        },
        beforeSend: function () {
            alert('Loading.....');
        },
        error: function (xhr, ajOpt, thrownError) {
            alert("Failed to retrieve students");
        }
    })

}