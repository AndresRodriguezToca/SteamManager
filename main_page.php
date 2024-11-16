<?php
    // LOAD GLOBALS
    require_once("globals.php");

    // CLASSES / COMPONETS
    use SteamManager\Modules;

    // ENV VARIABLES
    $dotenv = Dotenv\Dotenv::createImmutable(__DIR__);
    $dotenv->safeLoad();

?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Main Page");
            $simplyHeader->includeAdditionalCSS($GLOBALS['weblibrary'] . '/css/sidebar.css');
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body>
        <!-- INCLUDE SIDEBAR -->
        <?php
            include_once($GLOBALS['webtemplates'] . "/snippets/sidebar.php");
        ?>
        <!-- CONTENT OF SIDEBARS-->
        <div class="fixed-container">
            <!-- ACCOUNT INFORMATION -->
            <div class="collapse show">
                <?php
                    include_once($GLOBALS['webtemplates'] . "/snippets/account_information.php");
                ?>
            </div>
            <!-- GAMES COLLECTION -->
            <div class="collapse">
                <?php
                    // include_once($GLOBALS['webtemplates'] . "/snippets/games_collection.php");
                ?>
            </div>
        </div>

        <?php
        
            $simplyHeader->includeAdditionalJS($GLOBALS['weblibrary'] . '/js/sidebar.js');
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
    </body>
</html>
