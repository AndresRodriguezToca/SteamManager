// INITIATE ANIMATIONS
AOS.init();

// COPY TO CLIPBOARD
function copyToClipboard(text){
    navigator.clipboard.writeText(text);
    alertify.set('notifier','position', 'top-right');
    alertify.success('<i class="fa-regular fa-clipboard"></i> Copied to Clipboard');
    return false;
}