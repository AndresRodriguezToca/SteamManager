<?php
    // LOAD GLOBALS
    require_once("globals.php");

    // CLASSES / COMPONETS
    use SteamManager\Modules;

    // CHECK IF ACCOUNT ALREADY SAVED
        $env = parse_ini_file(__DIR__ . '/.env');
    if (isset($env['main_account']) && isset($env['main_account_sdk'])) {
        if ($env['main_account'] == $_POST["username"] && $env['main_account_sdk'] == $_POST["username_sdk"]) {
            // LOAD CURRENT USER SETTINGS
            loadAccountData();
        } else {
            // HANDLE REMEMBER ACCOUNT
            if ($_POST["rememberAccount"] == 1) {
                // OVERRIDE ACCOUNT INFORMATION
                $dotenv = \Dotenv\Dotenv::createImmutable(__DIR__);
                $dotenv->load();
                $newEnvValues = [
                    'remember_account' => '1',
                    'main_account' => $_POST["username"],
                    'main_account_sdk' => $_POST["username_sdk"]
                ];
                file_put_contents('.env', '');
                foreach ($newEnvValues as $key => $value) {
                    $newLine = "$key=$value" . PHP_EOL;
                    file_put_contents('.env', $newLine, FILE_APPEND | LOCK_EX);
                }
                // LOAD NEW USER
                loadAccountData();
            } else if($_POST["rememberAccount"] == 0) {
                // LOAD NEW USER
                loadAccountData($_POST["username"]);
            }
        }
    } else {
        // BACK TO LOGIN PAGE
        header("Location: index.php");
        exit();
    }

    function loadAccountData($username = null){
        // LOAD SAVED ACCOUNT
        if($username != null){

        } 
        // LOAD TEMPORARY ACCOUNT
        else {

        }
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Login Page");
            $simplyHeader->includeAdditionalCSS($GLOBALS["webroot"] . "/library/css/loading.css");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body class="bc-steam">
        <div class="container">
            <!-- LOADING ANIMATION -->
            <div id="loadingContainer">
                <div data-aos="zoom-in-up" style="height: 100vh; display: flex; flex-direction: column; justify-content: center; align-items: center;">
                    <div class="loader"></div>
                    <p data-aos="zoom-in-up" id="loadingMessage">Loading Account Information...</p>
                </div>
            </div>
        </div>
        
        
        <!-- LOGIN PAGE -->
        <?php
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
    </body>
</html>
