<?php
    class AccountCollection {
        private $accounts;

        public function __construct() {
            $this->accounts = [];
        }

        public function addAccount(Account $account) {
            if (!isset($this->accounts[$account->getSteamID()])) {
                $this->accounts[$account->getSteamID()] = [
                    'account_info' => $account,
                    'games' => []
                ];
            }
        }

        public function addGameToAccount($steamID, Game $game) {
            if (isset($this->accounts[$steamID])) {
                $this->accounts[$steamID]['games'][] = $game;
            }
        }

        public function getAccounts() {
            return $this->accounts;
        }

        public function getGamesByAccount($steamID) {
            return $this->accounts[$steamID]['games'] ?? [];
        }
    }
