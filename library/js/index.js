
$(document).ready(function() {
    // CHECK IF STEAM STORE PAGE IS ONLINE
    function checkSteamPageStatus() {
        var iframe = document.createElement('iframe');
        iframe.style.display = 'none';
        iframe.src = 'https://store.steampowered.com/';

        iframe.onload = function() {
            $("#steamOnlineIcon").removeClass("text-warning").addClass("text-success");
            $("#steamStatusMessage").text("Steam Online");
        };

        iframe.onerror = function() {
            $("#steamOnlineIcon").removeClass("text-warning").addClass("text-danger");
            $("#steamStatusMessage").text("Offline or Couldn't Connect to Steam");
        };

        document.body.appendChild(iframe);
    }

    checkSteamPageStatus();

    // INTERCEPT SUBMIT
    $("form").on("submit", function(event) {
        event.preventDefault();
        if(!checkValue($("#username"))){
            alertify.set('notifier','position', 'top-right');
            alertify.error('<i class="fa-solid fa-circle-exclamation"></i> Account ID Missing / Invalid');
        } else if(!checkValue($("#username_sdk"))){
            alertify.set('notifier','position', 'top-right');
            alertify.error('<i class="fa-solid fa-circle-exclamation"></i> Personal SDK Missing / Invalid');
        } else {
            // IF MISSING
            if(askRememberAccount == "Missing"){
                $("#rememberAccount").modal('show');
            } else {
                loginAccount(askRememberAccount);
            }
        }
    });

    // REMEMBER ACCOUNT TRIGGERS
    $("#rememberAccount").on("click", function(){
        loginAccount(1)
    });
    $("#dontRememberAccount").on("click", function(){
        loginAccount(0)
    });

    // LOGIN ACCOUNT
    function loginAccount(rememberAccount){
        // VALIDATE SDK
        $.ajax({
            url: rootValidateSDK,
            type: 'GET',
            data: {
                username: $("#username").val(),
                username_sdk: $("#username_sdk").val(),
                return: false
            },
            success: function(response) {
                if(response.status == "success"){
                    $("form").attr("action", "compiler_page.php").attr("method", "post");
                    $("<input>").attr({
                        type: "hidden",
                        name: "rememberAccount",
                        value: rememberAccount
                    }).appendTo("form");
                    $("form").unbind('submit').submit();
                } else {
                    alertify.set('notifier','position', 'top-right');
                    alertify.error("<i class='fa-solid fa-circle-exclamation'></i> SDK Validation Failed.<br>" + response.message);
                }
            },
            error: function(xhr, status, error) {
                alertify.set('notifier','position', 'top-right');
                alertify.error("<i class='fa-solid fa-circle-exclamation'></i> Couldn't Access Account.<br>" + error);
            }
        });
    }
});