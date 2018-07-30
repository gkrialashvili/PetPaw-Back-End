$(document).ready(function() {
    var firstRow;
    $("#addPictureForm").on("click", function () {
        firstRow = $(".customRow")[0].outerHTML;
        $(".customRow:first-child").before(firstRow);
    });
    
    $("#upload").click(function () {
        var description = $("#description").val();
        var data = new FormData();
        for (var i = 0; i < $(".addFile").length; i++) {
            var file = $(".addFile")[i].files[0];
            data.append("Image", file);
        }
        $.ajax({
            method: "POST",
            url: "/Admin/UploadPicture",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            success: function (result) {
                $.ajax({
                    url: "/Admin/AddPictureDescription",
                    method: "POST",
                    data: {
                        "id": result,
                        "description": description
                    }
                });
                if (result == true) {
                    location.href = "/Admin/AddPicture";
                    alert("Successfully Added");
                } else {
                    alert("Something went wrong, please try again");
                }
            }
        });

    });
});
