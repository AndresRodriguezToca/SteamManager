// TOOLTIP TIPPY.JS
tippy('[data-tippy-content]', {
    followCursor: true,
    delay: 10,
    arrow: false,
    theme: 'steam',
    animation: 'fade',
});

$(document).ready(function(){
    $(document).on("click", "#sidebar-menu-col-exp", function(){
        $(this).toggleClass("sidebar-collapse sidebar-expand");
        $(this).toggleClass("fa-square-caret-left fa-square-caret-right");

        if ($(this).hasClass("sidebar-expand")) {
            $("#aside-sidebar a > span").hide();
            $("#aside-sidebar a > .avatar-container").removeClass("d-flex").addClass("d-none");
            $("#title-expanded").attr("hidden", "hidden");
            $("#title-collapsed").removeAttr("hidden");
            $("#development-badge").attr("hidden", "hidden");
            $("#aside-sidebar").width("100px");
            $(".fixed-container").css("margin", "0 100px");
        } else {
            $("#aside-sidebar a > span").show();
            $("#aside-sidebar a > .avatar-container").removeClass("d-none").addClass("d-flex");
            $("#title-expanded").removeAttr("hidden");
            $("#title-collapsed").attr("hidden", "hidden");
            $("#development-badge").removeAttr("hidden");
            $("#aside-sidebar").width("max-content");
            $(".fixed-container").css("margin", "0 300px");
        }

        // DATA - LINK
        $('[data-link="openRepo"]').on('click', function() {
            window.open('https://github.com/AndresRodriguezToca/SteamManager', '_blank');
        });
        $('[data-link="openCom"]').on('click', function() {
            window.open('https://discord.gg/2qnSyYex2s', '_blank');
        });
        $('[data-link="openDon"]').on('click', function() {
            window.open('https://www.paypal.com/donate/?hosted_button_id=AQQQN2TFPZET4', '_blank');
        });
    });
});

