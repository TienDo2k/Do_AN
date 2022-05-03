// Đối tượng `Validator`
function Validator(options) {
    var selectorRoles = {};
    function validate(inputElement, rule) {
        var rules = selectorRoles[rule.selector];

        var errorMessage;
        var errorElement = inputElement.parentElement.querySelector('.form-message');
        for (var i = 0; i < rules.length; i++) {
            switch (inputElement.type) {
                case 'radio':
                    errorMessage = rules[i](formElement.querySelector(rule.selector + ':checked'));
                    break;
                default:
                    errorMessage = rules[i](inputElement.value);
            }

            if (errorMessage)
                break;
        }

        if (errorMessage) {
            errorElement.innerText = errorMessage;
            inputElement.parentElement.classList.add('invalid');
        } else {
            errorElement.innerText = '';
            inputElement.parentElement.classList.remove('invalid');
        }
        return !errorMessage;
    }



    var formElement = document.querySelector(options.form);

    if (formElement) {
        //formElement.onsubmit = function (e) {
        //    e.preventDefault();
        //    var isFormValid = true;
        //    options.rules.forEach(function (rule) {
        //        var inputElement = formElement.querySelector(rule.selector);
        //        var isvalid = validate(inputElement, rule);
        //        if (!isvalid) {
        //            isFormValid = false;
        //        }
        //    });
        //    if (isFormValid) {
        //        if (typeof options.onSubmit === 'function') {
        //            var enableInput = formElement.querySelectorAll('[name]');
        //            var formValue = Array.from(enableInput).reduce(function (values, input) {
        //                values[input.name] = input.value;
        //                return values;
        //            }, {})
        //            options.onSubmit(formValue);
        //        }
        //    }

        //}

        options.rules.forEach(function (rule) {
            if (Array.isArray(selectorRoles[rule.selector])) {
                selectorRoles[rule.selector].push(rule.test);
            } else {
                selectorRoles[rule.selector] = [rule.test];
            }
            var inputElement = formElement.querySelector(rule.selector);
            inputElement.onblur = function () {
                validate(inputElement, rule);
            }
            inputElement.oninput = function () {
                var errorElement = inputElement.parentElement.querySelector('.form-message');
                errorElement.innerText = '';
                inputElement.parentElement.classList.remove('invalid');
            }
        });
    }
}



// Định nghĩa rules
// Nguyên tắc của các rules:
// 1. Khi có lỗi => Trả ra message lỗi
// 2. Khi hợp lệ => Không trả ra cái gì cả (undefined)
Validator.isRequired = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            return value ? undefined : message || 'Vui lòng nhập trường này'
        }
    };
}

Validator.isEmail = function (selector, message) {
    return {
        selector: selector,
        test: function (value) {
            var regex = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            return regex.test(value) ? undefined : message || 'Trường này phải là email';
        }
    };
}

Validator.minLength = function (selector, min, message) {
    return {
        selector: selector,
        test: function (value) {
            return value.length >= min ? undefined : message || `Vui lòng nhập tối thiểu ${min} kí tự`;
        }
    };
}

Validator.isConfirmed = function (selector, getConfirmValue, message) {
    return {
        selector: selector,
        test: function (value) {
            return value === getConfirmValue() ? undefined : message || 'Giá trị nhập vào không chính xác';
        }
    };
}

