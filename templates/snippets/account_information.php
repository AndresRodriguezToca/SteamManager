<?php
    // CLASSES / COMPONETS
    use SteamManager\Modules;
?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Account Information");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body>
		<div class="container">
			<div class="row">
				<div class="d-flex justify-content-center">
					<?php
						// DISPLAY A PICTURE OF EVERY ACCOUNT
						$folderPath = __DIR__ . '/../../accounts/';
						$secondaryAccounts = json_decode($_ENV["secondary_accounts"], true);
						$mainAccount = $_ENV["main_account"];
						array_unshift($secondaryAccounts, $mainAccount); // Include main account in the list
						
						$accountsCount = count($secondaryAccounts);
						
						foreach ($secondaryAccounts as $account) {
					?>
							<div class="m-2">
								<?php
									$accountData = json_decode(file_get_contents($folderPath . $account . '/account.json'), true);
									$avatarUrl = $accountData['response']['players'][0]['avatarfull'];
									$accountName = $accountData['response']['players'][0]['personaname'];
									$SteamID = $accountData['response']['players'][0]['steamid'];
								?>
								<div id="<?php echo $SteamID ?>_image_loader" class="avatar-wrapper" data-tippy-content="<?php echo $accountName ?>">
									<img src="<?php echo $avatarUrl ?>" class="img-fluid rounded mx-auto d-block">
								</div>
							</div>
					<?php
						}
					?>
				</div>
			</div>
		</div>
    </body>
</html>
