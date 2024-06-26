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
            $simplyHeader->includeAdditionalCSS($GLOBALS["webroot"] . "/library/css/games_collection.css");
			$simplyHeader->_includeSimplyMeta();
			$simplyHeader->_includeSimplyCSS();
			$simplyHeader->_includeGlobalsCSS();
		?>
	</head>
    <body>
		<div class="container">
			<div class="row">
                <!-- FILTERS SECTION -->
                <form action="" method="POST" class="bc-steam sticky-top p-4">
                    <div data-aos="fade-right" class="input-group mb-3 aos-init aos-animate">
                        <label class="input-group-text" for="username"><i class="fas fa-search icon"></i></label>
                        <input autocomplete="off" type="text" class="form-control" name="username" id="username" aria-describedby="username" placeholder="Search by Name">
                        <button class="btn btn-outline-primary" type="button" id="username_how_to" data-bs-toggle="modal" data-bs-target="#staticAccountID">Account ID?</button>
                    </div>
                </form>
                
			    <?php
                    // DISPLAY A PICTURE OF EVERY ACCOUNT AND THEIR GAMES
                    $folderPath = __DIR__ . '/../../accounts/';
                    $secondaryAccounts = json_decode($_ENV["secondary_accounts"], true);
                    $mainAccount = $_ENV["main_account"];
                    array_unshift($secondaryAccounts, $mainAccount);

                    $processedGames = [];
                    $gamesToDisplay = [];

                    // COMPILE GAME DATA
                    foreach ($secondaryAccounts as $account) {
                        // FETCH ACCOUNT PICTURE
                        $accountInformation = json_decode(file_get_contents($folderPath . $account . '/account.json'), true);
                        $avatarUrl = $accountInformation['response']['players'][0]['avatarfull'];
                        // FETCH ACCOUNT GAMES
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

                                // STORE GAME INFO
                                $gamesToDisplay[] = [
                                    'name' => $gameName,
                                    'image' => $gameImage,
                                    'owner_profile_picture' => $avatarUrl
                                ];
                            }
                        }
                    }

                    // SORT GAME LIST ALPHABETICALLY
                    usort($gamesToDisplay, function($a, $b) {
                        return strcmp($a['name'], $b['name']);
                    });

                    // DISPLAY SORTED GAMES
                    foreach ($gamesToDisplay as $game) {
                        ?>
                        <div data-aos="zoom-in" class="col-3 mt-5">
                            <div data-tilt class="game-wrapper js-glare-scale tilt-parent" data-tippy-content="<?php echo htmlspecialchars($game['name']) ?>">
                                <img src="<?php echo $game['owner_profile_picture'] ?>" class="avatar-style tilt-child avatar-game-owner rounded">
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
