$(document).ready(function() {
    $("#signButton").click(function () {
        var email = $("#email").val();
        var password = $("#password").val();
        $.ajax({
            type: "POST",
            url: "/Account/Login",
            data: {
                "email": email,
                "password": password
            },
            success: function(response) {
                if (response==1) {
                    $("#erorr").html("Fill in all fields");
                }
                if (response == 2) {
                    $("#erorr").html("No such email");
                }
                if (response == 3) {
                    $("#erorr").html("Password is incorrect");
                }
                if (response == 4) {
                    $("#erorr").html("problems occured while logging in");
                }
                if (response == 0) {
                    location.href="../Home/Index";
                }
            }
        });
    });
});