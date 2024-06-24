<aside id="aside-sidebar" data-aos="fade-right" class="bc-steam position-absolute">
  <i class="fa-solid fa-square-caret-left sidebar-collapse fa-3x" id="sidebar-menu-col-exp"></i>
  <div class="tilt-parent" data-tilt>
    <h5 class="pt-3"><i class="fas fa-brands fa-steam"></i> <span id="title-expanded">Steam Manager</span><span id="title-collapsed" hidden>SM</span></h5>
    <div class="tilt-child text-center" id="development-badge">
      <span class="badge text-bg-info js-glare">Development Build: Alpha</span>
    </div>
  </div>
  <hr>
  <a data-aos="fade-right" data-aos-delay="100" href="javascript:void(0)">
    <i class="fas fa-user" aria-hidden="true"></i>
    <span>Account Information</span><br>
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
  <a data-aos="fade-right" data-aos-delay="200" href="javascript:void(0)" active>
    <i class="fas fa-gamepad" aria-hidden="true"></i>
    <span>Games Collection</span>
  </a>
  <a data-aos="fade-right" data-aos-delay="300" href="javascript:void(0)">
    <i class="fas fa-heart" aria-hidden="true"></i>
    <span>Steam Wishlist</span>
  </a>
  <a data-aos="fade-right" data-aos-delay="400" href="javascript:void(0)">
    <i class="fas fa-users" aria-hidden="true"></i>
    <span>Friends</span>
  </a>
  <hr>
  <a data-aos="fade-right" data-aos-delay="500" href="javascript:void(0)">
    <i class="fas fa-cog" aria-hidden="true"></i>
    <span>Settings</span>
  </a>
  <a data-aos="fade-right" data-aos-delay="600" href="javascript:void(0)">
    <i class="fas fa-lock" aria-hidden="true"></i>
    <span>Confidentiality</span>
  </a>
  <hr>
  <a data-aos="fade-right" data-aos-delay="700" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    <span>Repository</span>
  </a>
  <a data-aos="fade-right" data-aos-delay="800" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    <span>Community</span>
  </a>
  <a data-aos="fade-right" data-aos-delay="900" href="javascript:void(0)">
    <i class="fas fa-external-link-alt" aria-hidden="true"></i>
    <span>Donate</span>
  </a>
</aside>