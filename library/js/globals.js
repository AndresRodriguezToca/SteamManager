// INITIATE ANIMATIONS
AOS.init();

// COPY TO CLIPBOARD
function copyToClipboard(text){
    navigator.clipboard.writeText(text);
    alertify.set('notifier','position', 'top-right');
    alertify.success('<i class="fa-regular fa-clipboard"></i> Copied to Clipboard');
    return false;
}

// SCROLL TO FIELD AND SHAKE
function checkValue(fieldID){
    if ($(fieldID).val().trim() === "") {
        // SCROLL TO MISSING FIELD
        $('html, body').animate({
            scrollTop: $(fieldID).offset().top - 50
        }, {
            duration: 150,
            complete: function() {
                // HIGHLIGHT AND SHAKE ANIMATION
                $(fieldID).addClass("shake");

                setTimeout(function () {
                    // REMOVE HIGHLIGHT AND SHAKE EFFECT
                    $(fieldID).removeClass("shake").css("border", "");
                }, 2000);
            }
        });
        return false;
    } else {
        return true;
    }
}

$('.js-glare').tilt({
    glare: true,
    maxGlare: .5
})

$('.js-scale').tilt({
    scale: 1.2
})

// CONSTANTLY CHECK FOR BROWSER INSPECTOR
let errorDisplayed = false;
setInterval(function() {
    if (window.outerWidth - window.innerWidth > 160 || window.outerHeight - window.innerHeight > 160) {
        if (!errorDisplayed) {
            console.info("%cSteam Manager trusts users to not use the Inspector. Keep in mind that wherever you do from this point could potentially break the software.", "color: red; font-size: 16px; font-weight: bold;");
            errorDisplayed = true;
            setTimeout(function() {
                errorDisplayed = false;
            }, 300000);
        }
    }
}, 1000);
