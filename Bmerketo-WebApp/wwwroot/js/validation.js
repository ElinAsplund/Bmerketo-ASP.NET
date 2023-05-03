//-----------------Remove and add class-----------------
//For subscribe-form
function removeAddClassSubscribe() {
    try {
        const subscribeError = document.querySelector(`#subscribe-email-error`);
        const subscribeSpan = document.querySelector(`#subscribe-email-span`);

        if (subscribeError.innerText !== "")
            subscribeError.classList.add('subscribe-error')
        else
            subscribeError.classList.remove('subscribe-error')

        if (subscribeSpan.innerText !== "")
            subscribeSpan.classList.add('subscribe-error')
        else
            subscribeSpan.classList.remove('subscribe-error')

    } catch { }
}

//For contact-form
//function removeAddClassContact() {
//    try {
//        const aspError = document.querySelector(`#contact-asp-validation`);

//        if (aspError.innerText === "Your comment has now been sent!") {
//            aspError.classList.add('text-success')
//            aspError.classList.remove('text-danger')
//        } else {
//            aspError.classList.remove('text-success')
//            aspError.classList.add('text-danger')
//        }

//    } catch { }
//}
//removeAddClassContact()

//For asp-validation
function removeAspValidation(errorSpan) {
    if (errorSpan.innerText !== null)
        errorSpan.classList.add("d-none")
}

//-------------------------VALIDATIONS-------------------------
function validateInput(event) {
    try {
        let element = event.target;
        const errorMsg = document.querySelector(`#${element.id}-error`);
        const errorSpan = document.querySelector(`#${element.id}-span`);

        let inputName = (element.id).replace(/-/g, " ");

        removeAspValidation(errorSpan)

        if (validateInputSwitch(element, errorMsg, inputName))
            return true;

    } catch { }
}

function validateInputSwitch(element, errorMsg, label) {
    errorMsg.innerText = "";

    const regExName = /^[a-�A-�]+(?:[ �'-][a-�A-�]+)*$/;
    const regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    const regExPhoneNumber = /^(?=.{7})\+?\d[\d\s-]*\d$/;


    if (element.value === "")
        errorMsg.innerText = `Please enter a ${label}.`;

    switch (label) {
        case "first name":
            if (element.value.length < 2)
                errorMsg.innerText = `Your ${label} must contain at least 2 characters!`;

            if (!regExName.test(element.value))
                errorMsg.innerText = `Please enter a ${label}.`;
            break;

        case "last name":
            if (element.value.length < 2)
                errorMsg.innerText = `Your ${label} must contain at least 2 characters!`;

            if (!regExName.test(element.value))
                errorMsg.innerText = `Please enter a ${label}.`;
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
            break;

        case "password":
            if (element.value.length < 8)
                errorMsg.innerText = `Your ${label} must contain at least 8 characters!`;

            if (element.value === "")
                errorMsg.innerText = `Please enter a ${label}.`;
            break;

        case "confirm password":
            if (element.value.length < 8)
                errorMsg.innerText = `Your confirmed password must contain at least 8 characters!`;

            if (element.value === "")
                errorMsg.innerText = `Please confirm the password.`;
            break;

        case "login email":
            //if (!regExEmail.test(element.value))
            //    errorMsg.innerText = `Please enter a valid email.`;

            if (element.value === "")
                errorMsg.innerText = `Please enter a email.`;
            break;

        case "login password":
            //if (element.value.length < 8)
            //    errorMsg.innerText = `Your password contains at least 8 characters!`;

            if (element.value === "")
                errorMsg.innerText = `Please enter a password.`;
            break;

        case "subscribe email":
            //if (!regExEmail.test(element.value))
            //    errorMsg.innerText = `Please enter a valid email.`;

            if (element.value === "")
                errorMsg.innerText = `Please enter an email.`;
            break;

        case "contact full name":
            if (element.value === "")
                errorMsg.innerText = `Please enter a name.`;

            if (element.value.length < 2)
                errorMsg.innerText = `Your name must contain at least 2 characters!`;

            if (!regExName.test(element.value))
                errorMsg.innerText = `Please enter a name.`;
            break;

        case "contact email":
            if (!regExEmail.test(element.value))
                errorMsg.innerText = `Please enter a valid email.`;
            if (element.value === "")
                errorMsg.innerText = `Please enter an email.`;
            break;

        case "contact phone number":
            if (!regExPhoneNumber.test(element.value))
                errorMsg.innerText = `Please enter a valid phone number.`;
            if (element.value === "")
                errorMsg.innerText = `Please enter a phone number.`;
            break;

        case "contact comment":
            if (element.value === "")
                errorMsg.innerText = `Please enter a comment.`;

            if (element.value.length < 10)
                errorMsg.innerText = `Your name must contain at least 10 characters!`;
            break;
    }

    removeAddClassSubscribe()
}

//--------Checks if any error-message is present--------
function validationErrorMsgPresent(label) {
    const error = document.querySelector(`#${label}-error`);
    const input = document.querySelector(`#${label}`);

    if (input.value == "") return false;
    if (error.innerText === "") return true;

    return false;
}

//-------------------Validation of all, checks error-messages-------------------
//---User register form---
function validateAll(event) {
    try {
        event.preventDefault();

        const errorMsg = document.querySelector('#form-error');

        var firstNameOK = validationErrorMsgPresent("first-name");
        var lastNameOK = validationErrorMsgPresent("last-name");
        var streetNameOK = validationErrorMsgPresent("street-name");
        var postalCodeOK = validationErrorMsgPresent("postal-code");
        var cityOK = validationErrorMsgPresent("city");;
        var emailOK = validationErrorMsgPresent("email");
        var passwordOK = validationErrorMsgPresent("password");
        var confirmPasswordOK = validationErrorMsgPresent("confirm-password");

        if (firstNameOK && lastNameOK && streetNameOK && postalCodeOK && cityOK && emailOK && passwordOK && confirmPasswordOK)
            event.target.submit();
        else
            errorMsg.innerText = "Please enter the form correctly.";

    } catch { }
}

//---Login form---
function validateAllLogin(event) {
    try {
        event.preventDefault();

        const errorMsg = document.querySelector('#form-error');

        var emailOK = validationErrorMsgPresent("login-email")
        var passwordOK = validationErrorMsgPresent("login-password")

        if (emailOK && passwordOK)
            event.target.submit();
        else
            errorMsg.innerText = "Please enter the form correctly.";

    } catch { }
}

//---Contact form---
function validateAllContact(event) {
    try {
        event.preventDefault();

        const errorMsg = document.querySelector('#form-error');

        var nameOK = validationErrorMsgPresent("contact-full-name")
        var emailOK = validationErrorMsgPresent("contact-email")
        var phoneNumberOK = validationErrorMsgPresent("contact-phone-number")
        var commentOK = validationErrorMsgPresent("contact-comment")

        if (nameOK && emailOK && phoneNumberOK && commentOK)
            event.target.submit();
        else
            errorMsg.innerText = "Please enter the form correctly.";

    } catch { }
}

//---Subscribe form---
function validateSubscribe(event) {
    try {
        event.preventDefault();

        const regExEmail = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        const errorMsg = document.querySelector('#subscribe-email-error');
        const subscribeInput = document.querySelector('#subscribe-email');

        if (subscribeInput.value === "") {
            errorMsg.innerText = `Please enter an email.`;
        } else if (!regExEmail.test(subscribeInput.value)) {
            errorMsg.innerText = `Please enter a valid email.`;
            errorMsg.classList.remove('text-white', 'bg-success')
        } else {
            errorMsg.innerText = `You are now subscribed for the newsletter.`;
            errorMsg.classList.add('text-white', 'bg-success')
            subscribeInput.value = "";
        }

        removeAddClassSubscribe()

    } catch { }
}