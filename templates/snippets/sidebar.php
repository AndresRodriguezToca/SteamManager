<aside class="bc-steam">
  <h5 class="pt-3"><i class="fas fa-brands fa-steam"></i> Steam Manager</h5>
  <a href="javascript:void(0)">
    <i class="fas fa-user" aria-hidden="true"></i>
    Account Information<br>
    <?php
        $folderPath = __DIR__ . '/../../accounts/';
        $secondaryAccounts = json_decode($_ENV["secondary_accounts"], true);
        $mainAccount = $_ENV["main_account"];
        array_unshift($secondaryAccounts, $mainAccount); // Include main account in the list
        echo '<div class="avatar-container d-flex">';
        foreach ($secondaryAccounts as $account) {
            $accountData = json_decode(file_get_contents($folderPath . $account . '/account.json'), true);
            $avatarUrl = $accountData['response']['players'][0]['avatarfull'];
            $accountName = $accountData['response']['players'][0]['personaname'];
            $SteamID = $accountData['response']['players'][0]['steamid'];
        ?>
            <div id="<?php echo $SteamID ?>_image_loader" class="avatar-wrapper" title="<?php echo $accountName ?>">
                <img width="25px" src="<?php echo $avatarUrl ?>" class="avatar-style rounded">
            </div>
        <?php
        }
        echo '</div>';
    ?>
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-book" aria-hidden="true"></i>
    Library Collection
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-heart" aria-hidden="true"></i>
    Steam Wishlist
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-users" aria-hidden="true"></i>
    Friends
  </a>
  <hr>
  <a href="javascript:void(0)">
    <i class="fas fa-cog" aria-hidden="true"></i>
    Settings
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-lock" aria-hidden="true"></i>
    Confidentiality
  </a>
  <hr>
  <a href="javascript:void(0)">
    <i class="fas fa-github" aria-hidden="true"></i>
    Repository
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-users" aria-hidden="true"></i>
    Community
  </a>
  <a href="javascript:void(0)">
    <i class="fas fa-heart" aria-hidden="true"></i>
    Donate
  </a>
</aside>