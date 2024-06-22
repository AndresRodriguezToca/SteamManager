<?php
    /**
     * MODULES & COMPONENTS AUTOLOADER
     *
     * @package     SimplyEMR
     * @author      Andres Rodriguez Toca <rodrigueztoca21@gmail.com>
    */

    spl_autoload_register(function ($class) {
        $prefix = 'SteamManager\\Modules\\';
        $base_dir = __DIR__ . '/modules/';
        
        $len = strlen($prefix);
        if (strncmp($prefix, $class, $len) !== 0) {
            return;
        }
        
        $relative_class = substr($class, $len);
        $file = $base_dir . str_replace('\\', '/', $relative_class) . '.php';
        
        if (file_exists($file)) {
            require $file;
        }
    });

    spl_autoload_register(function ($class) {
        $prefix = 'SteamManager\\Components\\';
        $base_dir = __DIR__ . '/components/';
        
        $len = strlen($prefix);
        if (strncmp($prefix, $class, $len) !== 0) {
            return;
        }
        
        $relative_class = substr($class, $len);
        $file = $base_dir . str_replace('\\', '/', $relative_class) . '.php';
        
        if (file_exists($file)) {
            require $file;
        }
    });
