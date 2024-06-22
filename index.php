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
			$simplyHeader->_includeSimplyJS();
			$simplyHeader->_includeGlobalsCSS();
			$simplyHeader->_includeGlobalsJS();
		?>
	</head>
<body>
    <div class="container">
        <form action="validate_login.php" method="post">
            
            <h2 class="text-center"><i class="fa-brands fa-steam fa-5x mb-5"></i><br>Steam Manager</h2>
            <div class="mb-3">
                <label for="username" class="form-label"><i class="fas fa-user icon"></i> Steam Account ID</label>
                <input type="text" class="form-control" id="username" name="username" required>
            </div>
            <div class="mb-3">
                <label for="sdk" class="form-label"><i class="fas fa-key icon"></i> Personal Steam SDK</label>
                <input type="text" class="form-control" id="sdk" name="sdk" required>
            </div>
            <button type="submit" class="btn btn-custom btn-block">Access Account</button>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
