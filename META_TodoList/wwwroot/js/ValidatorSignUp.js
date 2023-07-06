
function ValidatorSignUp(options) {
    function appendError_SignUpMess(inputSignUpElement, rule) {
        var formMessElement = inputSignUpElement.parentElement.querySelector(options.errorSelector)
        var errorMess = rule.check(inputSignUpElement.value)
        if (errorMess) {
            formMessElement.innerHTML = errorMess
        }
        else {
            formMessElement.innerHTML = ''
        }
        return !errorMess
    }

    var formSignUpElement = document.querySelector(options.form)
    if (formSignUpElement) {
        formSignUpElement.onSubmit = function (e) {
            e.preventDefault()

            var isFormSignUpData = true

            options.rules.forEach(function (rule) {
                var InputSignUpElement = formSignUpElement.querySelector(rule.selector)
                var isSignUpData = appendError_SignUpMess(InputSignUpElement, rule)
                if (!isSignUpData) {
                    isFormSignUpData = false;
                }
            })
            if (isFormSignUpData) {
                if (typeof options.onSubmit === "function") {
                    var validSignUpInput = formSignUpElement.querySelectorAll("[Name]")
                    var arrSignUpForm = Array.from(validSignUpInput).reduce(function (values, input) {
                        return (values[input.name] = input.value) && values
                    }, {})
                    options.onSubmit(arrSignUpForm)

                }
            }
        }
        options.rules.forEach(function (rule) {
            var InputSignUpElement = formSignUpElement.querySelector(rule.selector)
            if (InputSignUpElement) {
                InputSignUpElement.onblur = function () {
                    appendError_SignUpMess(InputSignUpElement, rule)
                }
            }
        })
    }
}

// HÀM KIẾM TRA Ô INPUT CỦA ĐĂNG KÝ 
ValidatorSignUp.isRequired = function (selector) {
    return {
        selector: selector,
        check: function (value) {
            return value ? undefined : "Please ! Write Your ID"
        }
    };

}

// HÀM KIỂM TRA EMAIL
ValidatorSignUp.isEmail = function (selector) {
    return {
        selector: selector,
        check: function (value) {
            var regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/
            return regex.test(value) ? undefined : "Please ! Write Your Valid Email"
        }
    };

}

// HÀM KIỂM TRA MẬT KHẨU 
ValidatorSignUp.isPass = function (selector, min) {
    return {
        selector: selector,
        check: function (value) {
            return value >= min ? undefined : "Please ! Write Your Pass At Least 6 Letter"
        }
    };

}

// HÀM KIỂM TRA NHẬP LẠI MẬT KHẨU
ValidatorSignUp.isRePass = function (selector, valueConfirm) {
    return {
        selector: selector,
        check: function (value) {
            return value === valueConfirm() ? undefined : "Please ! Write Your Pass Again"
        }
    };
}








