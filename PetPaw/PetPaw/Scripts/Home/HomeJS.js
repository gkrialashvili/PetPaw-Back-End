$(document).ready(function() {
    $("#addPet").click(function () {
        var category = $("#exampleFormControlSelect1 option:selected").text();
        var type = $('input[name=optradio]:checked').val();
        var title = $("#tittletext").val();
        var location = $("#cityselect option:selected").text();
        var contactPersonName = $("#contactpersontext").val();
        var phoneNumber = $("#numberselect option:selected").text() + $("#mobilenumber").val();
        var price = $("#price").val();
        var currency = $("#priceselect option:selected").text();
        var age = $("#age").val();
        var breed = $("#breedtext").val();
        var gender = $("#gendertext").val();
        var description = $("#comment").val();
        console.log(category);
        var data = new FormData();
        for (var i = 0; i < $("#validatedCustomFile").length; i++) {
            var file = $("#validatedCustomFile")[i].files[0];
            data.append("Image", file);
        }
        $.ajax({
            method: "POST",
            url: "/Home/AddPetPicture/",
            contentType: false, // Not to set any content header
            processData: false, // Not to process data
            data: data,
            success: function (result) {
                var res = result;
                $.ajax({
                    method: "POST",
                    url: "/Home/AddPetInfo/",
                    data: {
                        "ID": result,
                        "Type": type,
                        "Title": title,
                        "Location": location,
                        "ContactPerson": contactPersonName,
                        "PhoneNumber": phoneNumber,
                        "Price": price,
                        "Age": age,
                        "Breed": breed,
                        "Gender": gender,
                        "Description": description,
                        "Currency": currency
                        
                    }
                });
            }
        });
    });
});