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


//Validation

function removeAspValidation(errorSpan) {
    if (errorSpan.innerText !== null)
        errorSpan.classList.add("d-none")
}


function validateName(element, errorDiv, label) {
    errorDiv.innerText = ""
    const regEx = /^[a-öA-Ö]+(?:[ é'-][a-öA-Ö]+)*$/;

    //if (errorDiv.innerText !== null || errorDiv.innerText !== "")
    //    errorDiv.classList.add('mt-1')


    if (element.value === null || element.value === "") {
        errorDiv.innerText = `Please enter a ${label}!`

    } else if (element.value.length < 2) {
        errorDiv.innerText = `Your ${label} must contain at least 2 letters!`;

    } else if (!regEx.test(element.value)) {
        errorDiv.innerText = `Please enter a valid ${label}.`;
    }

    if (errorDiv.innerText === "") {
        return true;
    }
}


function validateFirstName(event) {
    try {
        const errorDiv = document.querySelector('#first-name-error');
        let element = event.target;

        const errorSpan = document.querySelector('#first-name-span');
        removeAspValidation(errorSpan)

        if (validateName(element, errorDiv, "first name"))
            return true;

    } catch { }
}

function validateLastName(event) {
    try {
        const errorDiv = document.querySelector('#last-name-error');
        let element = event.target;

        const errorSpan = document.querySelector('#last-name-span');
        removeAspValidation(errorSpan)


        if (validateName(element, errorDiv, "last name"))
            return true;

    } catch { }
}

function validateInput(element, errorDiv, label) {
    errorDiv.innerText = ""

    //if (errorDiv.innerText !== null || errorDiv.innerText !== "")
    //    errorDiv.classList.add('mt-1')

    if (element.value === null || element.value === "") {
        errorDiv.innerText = `Please enter a ${label}!`

        if (label === "confirm password")
            errorDiv.innerText = `Please confirm the password!`
    }

    if (errorDiv.innerText === null || errorDiv.innerText === "")
        return true;
}


function validateStreetName(event) {
    try {
        const errorDiv = document.querySelector('#street-name-error');
        let element = event.target;

        const errorSpan = document.querySelector('#street-name-span');
        removeAspValidation(errorSpan)

        if (validateInput(element, errorDiv, "street name"))
            return true;

    } catch { }
}

function validatePostalCode(event) {
    try {
        const errorDiv = document.querySelector('#postal-code-error');
        let element = event.target;

        const errorSpan = document.querySelector('#postal-code-span');
        removeAspValidation(errorSpan)

        if (validateInput(element, errorDiv, "postal code"))
            return true;

    } catch { }
}

function validateCity(event) {
    try {
        const errorDiv = document.querySelector('#city-error');
        let element = event.target;

        const errorSpan = document.querySelector('#city-span');
        removeAspValidation(errorSpan)

        if (validateInput(element, errorDiv, "city"))
            return true;

    } catch { }
}


function validateEmail(event) {
    try {
        const errorDiv = document.querySelector('#email-error');
        let element = event.target;
        errorDiv.innerText = "";
        const regEx = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        const errorSpan = document.querySelector('#email-span');
        removeAspValidation(errorSpan)

        if (errorDiv.innerText !== null || errorDiv.innerText !== "")
            errorDiv.classList.add('mt-1')


        if (element.value === null || element.value === "") {
            errorDiv.innerText = `Please enter an email!`
        } else if (!regEx.test(element.value)) {
            errorDiv.innerText = `Please enter a valid email.`;
        }

        if (errorDiv.innerText === null || errorDiv.innerText === "")
            return true;

    } catch { }
}

function validatePassword(event) {
    try {
        const errorDiv = document.querySelector('#password-error');
        let element = event.target;

        const errorSpan = document.querySelector('#password-span');
        removeAspValidation(errorSpan)

        if (validateInput(element, errorDiv, "password"))
            return true;

    } catch { }
}

function validateConfirmPassword(event) {
    try {
        const errorDiv = document.querySelector('#confirm-password-error');
        let element = event.target;

        const errorSpan = document.querySelector('#confirm-password-span');
        removeAspValidation(errorSpan)

        if (validateInput(element, errorDiv, "confirm password"))
            return true;

    } catch { }
}

//Each value by its own-validation
function validateErrorFirstName() {
    let firstNameOK = false;
    const errorFirstName = document.querySelector('#first-name-error');
    const inputFirstName = document.querySelector('#first-name-input');

    if (inputFirstName.value !== "") {
        if (errorFirstName.innerText === "") {
            firstNameOK = true;
        } else {
            firstNameOK = false;
        }
    } else {
        firstNameOK = false;
    }

    return firstNameOK;
}

function validateErrorLastName() {
    let lastNameOK = false;
    const errorLastName = document.querySelector('#last-name-error');
    const inputLastName = document.querySelector('#last-name-input');

    if (inputLastName.value !== "") {
        if (errorLastName.innerText === "") {
            lastNameOK = true;
        } else {
            lastNameOK = false;
        }
    } else {
        lastNameOK = false;
    }

    return lastNameOK;
}

function validateErrorStreetName() {
    let streetNameOK = false;
    const errorStreetName = document.querySelector('#street-name-error');
    const inputStreetName = document.querySelector('#street-name-input');

    if (inputStreetName.value !== "") {
        if (errorStreetName.innerText === "") {
            streetNameOK = true;
        } else {
            streetNameOK = false;
        }
    } else {
        streetNameOK = false;
    }

    return streetNameOK;
}

function validateErrorPostalCode() {
    let postalCodeOK = false;
    const errorPostalCode = document.querySelector('#postal-code-error');
    const inputPostalCode = document.querySelector('#postal-code-input');

    if (inputPostalCode.value !== "") {
        if (errorPostalCode.innerText === "") {
            postalCodeOK = true;
        } else {
            postalCodeOK = false;
        }
    } else {
        postalCodeOK = false;
    }

    return postalCodeOK;
}

function validateErrorCity() {
    let cityOK = false;
    const errorCity = document.querySelector('#city-error');
    const inputCity = document.querySelector('#city-input');

    if (inputCity.value !== "") {
        if (errorCity.innerText === "") {
            cityOK = true;
        } else {
            cityOK = false;
        }
    } else {
        cityOK = false;
    }

    return cityOK;
}

function validateErrorEmail() {
    let emailOK = false;
    const errorEmail = document.querySelector('#email-error');
    const inputEmail = document.querySelector('#email-input');

    if (inputEmail.value !== "") {
        if (errorEmail.innerText === "") {
            emailOK = true;
        } else {
            emailOK = false;
        }
    } else {
        emailOK = false;
    }

    return emailOK;
}

function validateErrorPassword() {
    let passwordOK = false;
    const errorPassword = document.querySelector('#password-error');
    const inputPassword = document.querySelector('#password-input');

    if (inputPassword.value !== "") {
        if (errorPassword.innerText === "") {
            passwordOK = true;
        } else {
            passwordOK = false;
        }
    } else {
        passwordOK = false;
    }

    return passwordOK;
}

function validateErrorConfirmPassword() {
    let confirmPasswordOK = false;
    const errorConfirmPassword = document.querySelector('#confirm-password-error');
    const inputConfirmPassword = document.querySelector('#confirm-password-input');

    if (inputConfirmPassword.value !== "") {
        if (errorConfirmPassword.innerText === "") {
            confirmPasswordOK = true;
        } else {
            confirmPasswordOK = false;
        }
    } else {
        confirmPasswordOK = false;
    }

    return confirmPasswordOK;
}

//Validation all
function validateAll(event) {
    try {
        event.preventDefault();

        const errorDiv = document.querySelector('#form-error');

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
            errorDiv.innerText = "Please enter the form correctly.";

    } catch { }
}
