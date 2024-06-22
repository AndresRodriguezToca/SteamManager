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
        <div data-tilt >
            <div class="container-sm bc-steam rounded shadow-lg p-4 mb-5 bg-body-tertiary rounded" style="max-width: 500px;">
                <form action="validate_login.php" method="post">
                    <div class="mt-3 mb-3 text-center">
                        <i class="fas fa-brands fa-steam fa-5x"></i>
                    </div>
                    <h2 class="text-center text-steam-color">Steam Manager</h2>
                    <hr>
                    <div data-aos="fade-right" class="input-group mb-3">
                        <label class="input-group-text" for="username"><i class="fas fa-user icon"></i></label>
                        <input autocomplete="off" type="text" class="form-control" id="username" aria-describedby="username" placeholder="Account ID">
                        <button class="btn btn-outline-primary" type="button" id="username_how_to">Account ID?</button>
                    </div>
                    <div data-aos="fade-left" class="input-group">
                        <label class="input-group-text" for="username_sdk"><i class="fas fa-key icon"></i></label>
                        <input autocomplete="off" type="text" class="form-control" id="username_sdk" aria-describedby="username_sdk" placeholder="Personal SDK">
                        <button class="btn btn-outline-primary" type="button" id="username_sdk_how_to">Personal SDK?</button>
                    </div>
                    <div data-aos="fade-up" class="mt-3 mb-3 text-center">
                        <button type="submit" class="btn btn-outline-primary btn-block">Access Account</button>
                    </div>
                    <hr>
                    <p class="text-center">Publicly Distributed Free of Use by <a href="https://github.com/AndresRodriguezToca">AndresRodriguezToca</a></p>
                </form>
            </div>
        </div>
        <?php
        
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
    </body>
</html>
