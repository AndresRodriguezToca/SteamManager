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
