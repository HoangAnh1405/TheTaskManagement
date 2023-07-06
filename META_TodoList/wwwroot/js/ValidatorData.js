// ĐĂNG NHẬP
ValidatorSignIn({
    form: "#form_id",
    errorSelector: ".form_message",
    rules: [
        ValidatorSignIn.isRequired("#id_name"),
        ValidatorSignIn.isPass("#id_pass", 6)
    ],
    onSubmit: function (data) {
        JSON.stringify(data)
    }
})




//ĐĂNG KÝ
ValidatorSignUp({
    form: ".sign_up_alter",
    errorSelector: ".form_message",
    rules: [
        ValidatorSignUp.isRequired(".id_name_ID"),
        ValidatorSignUp.isEmail(".email_name_EM"),
        ValidatorSignUp.isPass(".pass_name_PS", 6),
        ValidatorSignUp.isRePass(".repass_name_RPS", function () {
            return document.querySelector(".pass_name_PS").value;
        })
    ],
    onSubmit: function (data) {
        fetch(API_URLS.SignUp, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(data)
        });
    }
})



