<?php
    // CLASSES / COMPONETS
    use SteamManager\Modules;
?>
<!DOCTYPE html>
<html lang="en">
    <head>
		<?php
			// INITIATE CLASS
			$simplyHeader = new Modules\Header("Steam Manager - Games Collection");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body>
		<div class="container">
			<div class="row">
			<?php
// DISPLAY A PICTURE OF EVERY ACCOUNT AND THEIR GAMES
$folderPath = __DIR__ . '/../../accounts/';
$secondaryAccounts = json_decode($_ENV["secondary_accounts"], true);
$mainAccount = $_ENV["main_account"];
array_unshift($secondaryAccounts, $mainAccount);

$processedGames = [];
$gamesToDisplay = [];

// Collect game data
foreach ($secondaryAccounts as $account) {
    $accountData = json_decode(file_get_contents($folderPath . $account . '/games.json'), true);
    $games = $accountData['response']['games'];

    foreach ($games as $game) {
        if (in_array($game['appid'], $processedGames)) {
            continue;
        }

        $gameData = null;
        $gameFilePath = __DIR__ . '/../../library/games_data/' . $game['appid'] . '.json';

        if (file_exists($gameFilePath)) {
            $gameData = json_decode(file_get_contents($gameFilePath), true);
        } else {
            $gameData = json_decode(file_get_contents('https://store.steampowered.com/api/appdetails?appids=' . $game['appid']), true);
            file_put_contents($gameFilePath, json_encode($gameData));
        }

        if (isset($gameData) && $gameData[$game['appid']]['success']) {
            $gameName = $gameData[$game['appid']]['data']['name'];
            $gameImage = $gameData[$game['appid']]['data']['header_image'];
            $processedGames[] = $game['appid'];

            // Store game info for sorting
            $gamesToDisplay[] = [
                'name' => $gameName,
                'image' => $gameImage
            ];
        }
    }
}

// Sort games alphabetically by name
usort($gamesToDisplay, function($a, $b) {
    return strcmp($a['name'], $b['name']);
});

// Display sorted games
foreach ($gamesToDisplay as $game) {
    ?>
    <div class="col-2 m-2">
        <div class="game-wrapper js-glare-scale" data-tippy-content="<?php echo htmlspecialchars($game['name']) ?>">
            <img src="<?php echo htmlspecialchars($game['image']) ?>" class="img-fluid rounded mx-auto d-block">
        </div>
    </div>
    <?php
}
?>

			</div>
		</div>
    </body>
</html>
