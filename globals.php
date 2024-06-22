<?php

// GLOBAL VARIABLES
$GLOBALS['webroot'] = __DIR__;
$GLOBALS['weblibrary'] = $GLOBALS['webroot'] . "/library/";
$GLOBALS['webtemplates'] = $GLOBALS['webroot'] . "/templates/";
$GLOBALS['webnodes'] = $GLOBALS['webroot'] . "/library/node_modules";

// AUTOLOAD (COMPOSER)
require_once $GLOBALS['webroot'] . '/library/vendor/autoload.php';

// AUTOLOAD (COMPONENTS & MODULES)
require_once $GLOBALS['webroot'] . '/templates/autoload.php';