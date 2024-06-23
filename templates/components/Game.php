<?php
    /**
     * @package   Steam Manager (Modules)
     * @author    Andres Rodriguez Toca <rodrigueztoca21@gmail.com>
     */

     namespace SteamManager\Components;
    
    class Game {
        private $appId;
        private $name;
        private $playtimeForever;
        private $iconUrl;
        private $hasCommunityVisibleStats;
        private $playtimeWindowsForever;
        private $playtimeMacForever;
        private $playtimeLinuxForever;
        private $lastPlayedTime;
        private $hasLeaderboards;
        private $gameType;
        private $shortDescription;
        private $supportedLanguage;
        private $developers;
        private $publishers;
        private $priceFinalFormatted;
        private $platformsWindows;
        private $platformsMac;
        private $platformsLinux;
        private $metacritic;
        private $categories;
        private $genres;

        public function __construct($appId, $name, $playtimeForever, $iconUrl, $hasCommunityVisibleStats, $playtimeWindowsForever, $playtimeMacForever, $playtimeLinuxForever, $lastPlayedTime, $hasLeaderboards) {
            $this->appId = $appId;
            $this->name = $name;
            $this->playtimeForever = $playtimeForever;
            $this->iconUrl = $iconUrl;
            $this->hasCommunityVisibleStats = $hasCommunityVisibleStats;
            $this->playtimeWindowsForever = $playtimeWindowsForever;
            $this->playtimeMacForever = $playtimeMacForever;
            $this->playtimeLinuxForever = $playtimeLinuxForever;
            $this->lastPlayedTime = $lastPlayedTime;
            $this->hasLeaderboards = $hasLeaderboards;
        }

        public function setAdditionalInfo($gameType, $shortDescription, $supportedLanguage, $developers, $publishers, $priceFinalFormatted, $platformsWindows, $platformsMac, $platformsLinux, $metacritic, $categories, $genres) {
            $this->gameType = $gameType;
            $this->shortDescription = $shortDescription;
            $this->supportedLanguage = $supportedLanguage;
            $this->developers = $developers;
            $this->publishers = $publishers;
            $this->priceFinalFormatted = $priceFinalFormatted;
            $this->platformsWindows = $platformsWindows;
            $this->platformsMac = $platformsMac;
            $this->platformsLinux = $platformsLinux;
            $this->metacritic = $metacritic;
            $this->categories = $categories;
            $this->genres = $genres;
        }

        // Getters for all properties
        public function getAppId() { return $this->appId; }
        public function getName() { return $this->name; }
        public function getPlaytimeForever() { return $this->playtimeForever; }
        public function getIconUrl() { return $this->iconUrl; }
        public function hasCommunityVisibleStats() { return $this->hasCommunityVisibleStats; }
        public function getPlaytimeWindowsForever() { return $this->playtimeWindowsForever; }
        public function getPlaytimeMacForever() { return $this->playtimeMacForever; }
        public function getPlaytimeLinuxForever() { return $this->playtimeLinuxForever; }
        public function getLastPlayedTime() { return $this->lastPlayedTime; }
        public function hasLeaderboards() { return $this->hasLeaderboards; }
        public function getGameType() { return $this->gameType; }
        public function getShortDescription() { return $this->shortDescription; }
        public function getSupportedLanguage() { return $this->supportedLanguage; }
        public function getDevelopers() { return $this->developers; }
        public function getPublishers() { return $this->publishers; }
        public function getPriceFinalFormatted() { return $this->priceFinalFormatted; }
        public function getPlatformsWindows() { return $this->platformsWindows; }
        public function getPlatformsMac() { return $this->platformsMac; }
        public function getPlatformsLinux() { return $this->platformsLinux; }
        public function getMetacritic() { return $this->metacritic; }
        public function getCategories() { return $this->categories; }
        public function getGenres() { return $this->genres; }
    }
