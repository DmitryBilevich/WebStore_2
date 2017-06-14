
   

function createAccount() {
    var firstName = $(".cr-account-input-fistName").val();
    var lastName = $(".cr-account-input-lastName").val();
    var password = $(".cr-account-input-password").val();
    var confirmPassword = $(".cr-account-input-confirmPassword").val();
    var email = $(".cr-account-input-email").val();
    if (confirmPassword == password) {
        var user = { firstName: firstName, lastName: lastName, password: password, email: email }
        $.ajax({
            url: "/user/createaccount",
            type: "POST",
            data: user,
            success: function(response) {
                alert(response.Massange);
                if (!response.IsCreate) {
                    $(".cr-account-input-emai").addClass("cr-account-input-error");
                    $(".email-error").removeClass("hidden");
                }
                
            }
        });
    } else {
        $(".cr-account-input-password").addClass("cr-account-input-error");
        $(".password-error").removeClass("hidden");
        $(".cr-account-input-confirmPassword").addClass("cr-account-input-error");
        $(".confirmPassword-error").removeClass("hidden");
    }
}