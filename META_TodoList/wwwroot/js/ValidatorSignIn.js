// HÀM ĐĂNG NHẬP
function ValidatorSignIn(options) {
    // HÀM XUẤT HIỆN THÔNG BÁO LỖI
    function appendErrorMess(inputElement, rule) {
        var formMessElement = inputElement.parentElement.querySelector(options.errorSelector)
        var errorMess = rule.check(inputElement.value)
        if (errorMess) {
            formMessElement.innerHTML = errorMess
        }
        else {
            formMessElement.innerHTML = ''
        }
        return !errorMess
    }
    // NHẬN DATA ĐĂNG NHẬP TỪ WEB
    var formElement = document.querySelector(options.form)
    if (formElement) {
        formElement.onSubmit = function (e) {
            e.preventDefault();

            var isFormData = true

            options.rules.forEach(function (rule) {
                var inputElement = formElement.querySelector(rule.selector)
                var isData = appendErrorMess(inputElement, rule)
                if (!isData) {
                    isFormData = false;
                }
            })
            if (isFormData) {
                if (typeof options.onSubmit === "function") {
                    var validInput = formElement.querySelectorAll("[Name]")
                    var arrForm = Array.from(validInput).reduce(function (values, input) {
                        return (values[input.name] = input.value) && values
                    }, {})
                    options.onSubmit(arrForm)
                }
            }

        }

        options.rules.forEach(function (rule) {
            var inputElement = formElement.querySelector(rule.selector)
            if (inputElement) {
                inputElement.onblur = function () {
                    appendErrorMess(inputElement, rule)
                }
            }
        })
    }
}
// HÀM KIỂM TRA Ô INPUT
ValidatorSignIn.isRequired = function (selector) {
    return {
        selector: selector,
        check: function (value) {
            return value ? undefined : "Please ! Write Your ID"
        }
    };

}
// HÀM KIỂM TRA  MẬT KHẨU 
ValidatorSignIn.isPass = function (selector, min) {
    return {
        selector: selector,
        check: function (value) {
            return value.length >= min ? undefined : `Please ! Write Your Password Minimize ${min} Letter`
        }
    };
}



