<?php
    class Account {
        private $steamid;
        private $communityvisibilitystate;
        private $profilestate;
        private $personaname;
        private $lastlogoff;
        private $commentpermission;
        private $profileurl;
        private $avatar;
        private $avatarmedium;
        private $avatarfull;
        private $personastate;
        private $realname;
        private $primaryclanid;
        private $timecreated;
        private $personastateflags;
        private $loccountrycode;
        private $gameid;
        private $gameserverip;
        private $gameextrainfo;
        private $cityid;
        private $locstatecode;
        private $loccityid;

        public function __construct($steamAPIResponse) {
            $json = json_decode($steamAPIResponse, true);
            $player = $json['response']['players'][0];

            $this->steamid = $player['steamid'];
            $this->communityvisibilitystate = $player['communityvisibilitystate'];
            $this->profilestate = $player['profilestate'];
            $this->personaname = $player['personaname'];
            $this->lastlogoff = $player['lastlogoff'];
            $this->commentpermission = $player['commentpermission'];
            $this->profileurl = $player['profileurl'];
            $this->avatar = $player['avatar'];
            $this->avatarmedium = $player['avatarmedium'];
            $this->avatarfull = $player['avatarfull'];
            $this->personastate = $player['personastate'];
            $this->realname = $player['realname'];
            $this->primaryclanid = $player['primaryclanid'];
            $this->timecreated = $player['timecreated'];
            $this->personastateflags = $player['personastateflags'];
            $this->loccountrycode = $player['loccountrycode'];
            $this->gameid = $player['gameid'];
            $this->gameserverip = $player['gameserverip'];
            $this->gameextrainfo = $player['gameextrainfo'];
            $this->cityid = $player['cityid'];
            $this->locstatecode = $player['locstatecode'];
            $this->loccityid = $player['loccityid'];
        }

        public function getSteamID() {
            return $this->steamid;
        }

        public function getCommunityState() {
            return $this->communityvisibilitystate;
        }

        public function getProfileState() {
            return $this->profilestate;
        }

        public function getPersonName() {
            return $this->personaname;
        }

        public function getLastLogoff() {
            return $this->lastlogoff;
        }

        public function getCommentPermission() {
            return $this->commentpermission;
        }

        public function getProfileURL() {
            return $this->profileurl;
        }

        public function getAvatar() {
            return $this->avatar;
        }

        public function getAvatarMedium() {
            return $this->avatarmedium;
        }

        public function getAvatarFull() {
            return $this->avatarfull;
        }

        public function getPersonAsState() {
            return $this->personastate;
        }

        public function getRealName() {
            return $this->realname;
        }

        public function getCredentialsPrimaryClanID() {
            return $this->primaryclanid;
        }

        public function getTimeCreated() {
            return $this->timecreated;
        }

        public function getPersonaStateFlags() {
            return $this->personastateflags;
        }

        public function getLocalCountryCode() {
            return $this->loccountrycode;
        }

        public function getGameID() {
            return $this->gameid;
        }

        public function getGameServerIP() {
            return $this->gameserverip;
        }

        public function getGameExtraInfo() {
            return $this->gameextrainfo;
        }

        public function getCityID() {
            return $this->cityid;
        }

        public function getLocalStateCode() {
            return $this->locstatecode;
        }

        public function getLocalCityID() {
            return $this->loccityid;
        }
    }
