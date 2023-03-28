try {
    const toggleBtn = document.querySelector('[data-option="toggle"]')
    toggleBtn.addEventListener('click', function() {
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
} catch {}