<aside data-aos="fade-right" class="bc-steam">
  <h5 class="pt-3"><i class="fas fa-brands fa-steam"></i> Steam Manager</h5>
  <span class="badge text-bg-info">Development Build: 0.0.4 "Alpha"</span>
  <hr>
  <a data-aos="fade-right" data-aos-delay="100" href="javascript:void(0)" active>
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
            <div id="<?php echo $SteamID ?>_image_loader" class="avatar-wrapper" data-tippy-content="<?php echo $accountName ?>">
                <img width="30px" src="<?php echo $avatarUrl ?>" class="avatar-style rounded">
            </div>
        <?php
        }
        echo '</div>';
    ?>
  </a>
  <a data-aos="fade-right" data-aos-delay="200" href="javascript:void(0)">
    <i class="fas fa-book" aria-hidden="true"></i>
    Library Collection
  </a>
  <a data-aos="fade-right" data-aos-delay="300" href="javascript:void(0)">
    <i class="fas fa-heart" aria-hidden="true"></i>
    Steam Wishlist
  </a>
  <a data-aos="fade-right" data-aos-delay="400" href="javascript:void(0)">
    <i class="fas fa-users" aria-hidden="true"></i>
    Friends
  </a>
  <hr>
  <a data-aos="fade-right" data-aos-delay="500" href="javascript:void(0)">
    <i class="fas fa-cog" aria-hidden="true"></i>
    Settings
  </a>
  <a data-aos="fade-right" data-aos-delay="600" href="javascript:void(0)">
    <i class="fas fa-lock" aria-hidden="true"></i>
    Confidentiality
  </a>
  <hr>
  <a data-aos="fade-right" data-aos-delay="700" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    Repository 
  </a>
  <a data-aos="fade-right" data-aos-delay="800" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    Community
  </a>
  <a data-aos="fade-right" data-aos-delay="900" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    Donate
  </a>
</aside>