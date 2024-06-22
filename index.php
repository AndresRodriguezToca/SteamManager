<?php
    // LOAD GLOBALS
    require_once("globals.php");

    // CLASSES / COMPONETS
    use SteamManager\Modules;

?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Login Page");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body class="d-flex justify-content-center align-items-center" style="height: 100vh; background-image: url('library/assets/lake-4541454_1920.jpg');">
        <!-- LOGIN PAGE -->
        <div data-tilt>
            <div class="container-sm bc-steam rounded shadow-lg p-4 mb-5 bg-body-tertiary rounded" style="max-width: 500px;">
                <form action="main_page.php" method="post">
                    <div class="mt-3 mb-3 text-center">
                        <i class="fas fa-brands fa-steam fa-5x"></i>
                    </div>
                    <h2 class="text-center text-steam-color">Steam Manager</h2>
                    <p class="text-center"><i class="fa-regular fa-circle fa-beat-fade text-warning" id="steamOnlineIcon"></i> <span id="steamStatusMessage">Checking if Steam Online...</span></p>
                    <hr>
                    <div data-aos="fade-right" class="input-group mb-3">
                        <label class="input-group-text" for="username"><i class="fas fa-user icon"></i></label>
                        <input autocomplete="off" type="text" class="form-control" name="username" id="username" aria-describedby="username" placeholder="Account ID">
                        <button class="btn btn-outline-primary" type="button" id="username_how_to" data-bs-toggle="modal" data-bs-target="#staticAccountID">Account ID?</button>
                    </div>
                    <div data-aos="fade-left" class="input-group">
                        <label class="input-group-text" for="username_sdk"><i class="fas fa-key icon"></i></label>
                        <input autocomplete="off" type="text" class="form-control" name="username_sdk" id="username_sdk" aria-describedby="username_sdk" placeholder="Personal SDK">
                        <button class="btn btn-outline-primary" type="button" id="username_sdk_how_to" data-bs-toggle="modal" data-bs-target="#staticPersonalSDK">Personal SDK?</button>
                    </div>
                    <div data-aos="fade-up" class="mt-3 mb-3 text-center">
                        <button type="submit" class="btn btn-outline-primary btn-block">Access Account</button>
                    </div>
                    <hr>
                    <p class="text-center">Publicly Distributed Free of Use by <a href="https://github.com/AndresRodriguezToca" target="_blank">AndresRodriguezToca</a></p>
                    <p class="text-center"><a href="https://github.com/AndresRodriguezToca/SteamManager" target="_blank">Repository</a> <a href="#" target="_blank">Confidentiality</a> <a href="https://discord.gg/2qnSyYex2s" target="_blank">Community</a></p>
                </form>
            </div>
        </div>
        <!-- HOW TO GET ACCOUNT ID -->
        <div class="modal fade" id="staticAccountID" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Steam's Account ID</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="list-group">
                        <p class="list-group-item list-group-item-action m-0 active" aria-current="true">
                            How can I find my SteamID?
                        </p>
                        <div class="list-group-item list-group-item-action">
                            <p>
                                <h4>Steam Desktop App & Web</h4>
                                <ol>
                                    <li>Click your Steam Profile</li>
                                    <li>Choose from the dropdown "Account Details"</li>
                                    <img class="img-fluid" src="<?php echo $GLOBALS["webroot"] ?>/library/assets/Screenshot 2024-06-22 141628.png" alt="Steam Profile Screenshot">
                                    <li>Just below your name you should be able to see in gray "Steam ID: [Number]"</li>
                                    <img class="img-fluid" src="<?php echo $GLOBALS["webroot"] ?>/library/assets/Screenshot 2024-06-22 142107.png" alt="Steam Account Details Screenshot">
                                </ol>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Understood</button>
                </div>
                </div>
            </div>
        </div>
        <!-- HOW TO GET PERSONAL SDK -->
        <div class="modal fade" id="staticPersonalSDK" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="staticBackdropLabel">Steam's Personal API SDK</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="list-group">
                        <p class="list-group-item list-group-item-action m-0 active" aria-current="true">
                            How can I find my SteamID?
                        </p>
                        <div class="list-group-item list-group-item-action">
                            <p>
                                <h4>Only Steam Desktop Web</h4>
                                <ol>
                                    <li>Access your Steam Account with any browser of your choice</li>
                                    <li>Add a new tab and click the following highlighted link to copy to clipboard, then paste on your browser search box. <a href="#" onclick="copyToClipboard('https://steamcommunity.com/dev/apikey')">https://steamcommunity.com/dev/apikey</a></li>
                                    <li>Follow Steam's steps to create your own SDK API</li>
                                    <li>If you need assistance, feel free to reach me out. Alternatively you could also look for any videos online.</li>
                                </ol>
                            </p>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-bs-dismiss="modal">Understood</button>
                </div>
                </div>
            </div>
        </div>
        <!-- REMEMBER MY ACCOUNT? -->
        <div class="modal fade" id="rememberAccount" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-6" id="staticBackdropLabel">Would you like Steam Manager to remember this account?</h1>
                </div>
                <div class="modal-body">
                    <div class="list-group">
                        <p>
                            If "Yes", please note that the information will be saved locally on the application directory. Your information will <b>never</b> be stored by Steam Manager onto any external applications outside your machine.
                        </p>
                    </div>
                    <div class="text-center mb-3 row">
                        <div class="col-6">
                            <button type="button" class="btn btn-sm btn-outline-primary m-2" data-bs-dismiss="modal" id="rememberAccount"><b>Yes, do remember</b></button>
                        </div>
                        <div class="col-6">
                            <button type="button" class="btn btn-sm btn-outline-primary m-2" data-bs-dismiss="modal" id="dontRememberAccount"><b>No, don't remember</b></button>
                        </div>
                        <div clas="col-12 text-center">
                            <small><u>This will be asked only once per installation. You can change this later.</u></small>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
        <?php
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
        <script>
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
                        // CHECK IF ACCOUNT NEEDS REMEMBER
                        let askRememberAccount = <?php  
                            if (file_exists(__DIR__ . '/.env')) {
                                $env = parse_ini_file(__DIR__ . '/.env');
                                if (isset($env['remember_account'])) {
                                    echo json_encode($env['remember_account']);
                                } else {
                                    echo json_encode("Missing");
                                }
                            } else {
                                file_put_contents(__DIR__ . '/.env', "remember_account=Missing");
                                echo json_encode("Missing");
                            }
                        ?>;

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
                        url: '<?php echo $GLOBALS['webroutes']; ?>/account/get_validate_sdk.php',
                        type: 'GET',
                        data: {
                            username: $("#username").val(),
                            username_sdk: $("#username_sdk").val()
                        },
                        success: function(response) {
                            if(response.status == "success"){
                                $("form").attr("action", "main_page.php").attr("method", "post");
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
        </script>
    </body>
</html>
