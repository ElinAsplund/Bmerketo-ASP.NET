//Header-menu
try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function () {
        const element = document.querySelector(toggleBtn.getAttribute('data-target'))

        if (!element.classList.contains('menu-show')) {
            element.classList.add('menu-show')
            element.classList.remove('menu-hide')

            toggleBtn.classList.add('btn-dark')
            toggleBtn.classList.remove('btn-white')
        }

        else {
            element.classList.remove('menu-show')
            element.classList.add('menu-hide')

            toggleBtn.classList.add('btn-white')
            toggleBtn.classList.remove('btn-dark')
        }
    })
} catch { }

//Footer
function footerPosition(element, scrollHeight, innerHeight) {
    try {
        const _element = document.querySelector(element)
        const isTallerThanScreen = scrollHeight >= (innerHeight + _element.scrollHeight)

        _element.classList.toggle('position-fixed-bottom', !isTallerThanScreen)
        _element.classList.toggle('position-static', isTallerThanScreen)
    } catch { }
}
footerPosition('footer', document.body.scrollHeight, window.innerHeight)


//Validations
function removeAspValidation(errorSpan) {
    if (errorSpan.innerText !== null)
        errorSpan.classList.add("d-none")
}

function validateInputSwitch(element, errorMsg, label) {
    errorMsg.innerText = "";

    const regExName = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;
    const regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;



    if (element.value === "")
        errorMsg.innerText = `Please enter a ${label}.`;

    switch (label) {
        case "first name":
            if (element.value.length < 2)
                errorMsg.innerText = `Your ${label} must contain at least 2 characters!`;

            if (!regExName.test(element.value))
                errorMsg.innerText = `Please enter a ${label}.`;

            if (errorMsg.innerText === "")
                firstNameOK = true;

            break;

        case "last name":
            if (element.value.length < 2)
                errorMsg.innerText = `Your ${label} must contain at least 2 characters!`;

            if (!regExName.test(element.value))
                errorMsg.innerText = `Please enter a ${label}.`;

            if (errorMsg.innerText === "")
                lastNameOK = true;

            break;

        case "street name":
            break;

        case "postal code":
            break;

        case "city":
            break;

        case "email":
            if (!regExEmail.test(element.value))
                errorMsg.innerText = `Please enter a valid ${label}.`;

            if (element.value === "")
                errorMsg.innerText = `Please enter an ${label}.`;

            if (errorMsg.innerText === "")
                emailOK = true;

            break;

        case "password":
            if (element.value.length < 8)
                errorMsg.innerText = `Your ${label} must contain at least 8 characters!`;

            if (element.value === "")
                errorMsg.innerText = `Please enter a ${label}.`;

            if (errorMsg.innerText === "")
                passwordOK = true;

            break;

        case "confirm password":
            if (element.value.length < 8)
                errorMsg.innerText = `Your confirmed password must contain at least 8 characters!`;

            if (element.value === "")
                errorMsg.innerText = `Please confirm the password.`;

            if (errorMsg.innerText === "")
                passwordOK = true;

            break;

    }
}

function validateInput(event) {
    try {
        let element = event.target;
        const errorMsg = document.querySelector(`#${element.id}-error`);
        const errorSpan = document.querySelector(`#${element.id}-span`);

        let inputName = (element.id).replace("-", " ");

        removeAspValidation(errorSpan)

        if (validateInputSwitch(element, errorMsg, inputName))
            return true;

    } catch { }
}


//Each value by its own error-validation
function validationErrorMsgPresent(label) {
    const error = document.querySelector(`#${label}-error`);
    const input = document.querySelector(`#${label}`);

    if (input.value !== "") {
        if (error.innerText === "") {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}


function validateErrorFirstName() {

    return validationErrorMsgPresent("first-name");
}

function validateErrorLastName() {

    return validationErrorMsgPresent("last-name");
}

function validateErrorStreetName() {

    return validationErrorMsgPresent("street-name");
}

function validateErrorPostalCode() {

    return validationErrorMsgPresent("postal-code");
}

function validateErrorCity() {

    return validationErrorMsgPresent("city");
}

function validateErrorEmail() {

    return validationErrorMsgPresent("email");
}

function validateErrorPassword() {

    return validationErrorMsgPresent("password");
}

function validateErrorConfirmPassword() {

    return validationErrorMsgPresent("confirm-password");
}

//Validation of all inputs
function validateAll(event) {
    try {
        event.preventDefault();

        const errorMsg = document.querySelector('#form-error');

        var firstNameOK = validateErrorFirstName();
        var lastNameOK = validateErrorLastName();
        var streetNameOK = validateErrorStreetName();
        var postalCodeOK = validateErrorPostalCode();
        var cityOK = validateErrorCity();
        var emailOK = validateErrorEmail();
        var passwordOK = validateErrorPassword();
        var confirmPasswordOK = validateErrorConfirmPassword();

        if (firstNameOK && lastNameOK && streetNameOK && postalCodeOK && cityOK && emailOK && passwordOK && confirmPasswordOK)
            event.target.submit();
        else
            errorMsg.innerText = "Please enter the form correctly.";

    } catch { }
}