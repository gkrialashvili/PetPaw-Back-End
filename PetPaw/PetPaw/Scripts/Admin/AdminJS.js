$(document).ready(function() {
    var firstRow;
    $("#addPictureForm").on("click", function () {
        firstRow = $(".customRow")[0].outerHTML;
        $(".customRow:first-child").before(firstRow);
    });
    
    $("#upload").click(function () {
        var description = $(".description").val();
        var data = new FormData();
        for (var i = 0; i < $(".addFile").length; i++) {
            var file = $(".addFile")[i].files[0];
            data.append("Image", file);
        }
        $.ajax({
            method: "POST",
            url: "/Admin/UploadPicture/" + description,
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            success: function (result) {
                if (result == true) {
                    location.href = "/Admin/AddPicture";
                    alert("Successfully Added");
                } else {
                    alert("Something went wrong, please try again");
                }
            }
        });

    });
    $(".addOrDeleteSliderPicture").on("click", function () {
        var pictureID = $(this).data("id");
        $.ajax({
            url: "/Admin/ActivatePicture",
            method: "post",
            data: { "ID": pictureID },
            success: function (response) {
                if (response == 0) {
                    $("td").find("[data-id='" + pictureID + "']").text("გააქტიურება");
                    $("tr").find("[data-isactive='" + pictureID + "']").text("False");
                } else {
                    $("td").find("[data-id='" + pictureID + "']").text("დეაქტივაცია");
                    $("tr").find("[data-isactive='" + pictureID + "']").text("True");
                }
            }
        });
    });
});
