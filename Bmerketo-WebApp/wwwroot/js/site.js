//At register product-view
//Disable negative numbers on input-fields of type number and removing the 0 at first view.
let element = document.querySelector("#price-input");
let button = document.querySelector("#btn-product-submit");

if (element) {
    if (element.value == 0)
        element.value = "";
}

if (element) {
    element.addEventListener("input", function () {
        if (element.value < 0)
            element.value = Math.abs(element.value);
    });
}

//This should be taken care of by validating properly
if (button) {
    button.addEventListener("click", function () {
        if (element.value == "")
            element.value = 0;
    });
}

//Header menu toggle on small screens
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