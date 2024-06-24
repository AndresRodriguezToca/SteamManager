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
<html class="bc-steam" lang="en">
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


        <?php
        
            $simplyHeader->includeAdditionalJS($GLOBALS['weblibrary'] . '/js/sidebar.js');
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsJS();
        ?>
    </body>
</html>
