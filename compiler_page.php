<?php
    // LOAD GLOBALS
    require_once("globals.php");

    // COMPONENTS / MODULES
    use SteamManager\Modules;

    // CHECK IF ACCOUNT ALREADY SAVED
    $env = parse_ini_file(__DIR__ . '/.env');
    if (isset($env['main_account']) && isset($env['main_account_sdk'])) {
        if ($env['main_account'] != $_POST["username"]) {
            // HANDLE REMEMBER ACCOUNT (OVERRIDE)
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
            }
        }
    } else {
        // BACK TO LOGIN PAGE
        header("Location: index.php");
        exit();
    }
?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Compiler");
            $simplyHeader->includeAdditionalCSS($GLOBALS["webroot"] . "/library/css/loading.css");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body class="bc-steam">
        <div class="container">
            <!-- LOADING ANIMATION -->
            <div class="d-flex justify-content-center align-items-center" id="loadingContainer">
                <div class="js-scale">
                    <div data-tilt class="tilt-parent" data-aos="zoom-in-up" style="height: 60vh; display: flex; flex-direction: column; justify-content: center; align-items: center;">
                        <div class="loader tilt-child"></div>
                        <p class="mt-3 tilt-child" id="loadingMessage">Double-Checking Steam API Connection...</p>
                        <div class="tilt-child d-flex" id="avatarList"></div>
                    </div>
                </div>
            </div>
        </div>
        <!-- LOGIN PAGE -->
        <?php
            $simplyHeader->includeAdditionalJS($GLOBALS['weblibrary'] . '/js/compiler_page.js');
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
        <script>
            // GENERAL VARIABLES
            let rootValidateSDK = '<?php echo $GLOBALS['webroutes']; ?>/account/get_account_information.php';
            let rootFetchGames = '<?php echo $GLOBALS['webroutes']; ?>/games/get_account_games.php';
            let rootFetchFriends = '<?php echo $GLOBALS['webroutes']; ?>/friends/get_account_friends.php';
            let rootFetchWishlist = '<?php echo $GLOBALS['webroutes']; ?>/wishlist/get_account_wishlist.php';
            let username = '<?php echo $_POST["username"]; ?>';
            let username_sdk = '<?php echo $_POST["username_sdk"]; ?>';
            // ACCOUNT(S) TO FETCH
            let accountsID = [
                <?php
                    if ($env['main_account'] != $_POST["username"]) {
                        echo "'". $_POST["username"] ."'";
                    } else {
                        if (isset($env['main_account'])) {
                            echo "'{$env['main_account']}', ";
                        }
                        if (isset($env['secondary_accounts'])) {
                            $secondaryAccounts = explode(',', str_replace(['[', ']'], '', $env['secondary_accounts']));
                            foreach ($secondaryAccounts as $account) {
                                echo "'$account', ";
                            }
                        }
                    }
                ?>
            ];
        </script>
    </body>
</html>
