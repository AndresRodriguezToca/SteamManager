<?php
/**
 * @package   Steam Manager (Modules)
 * @author    Andres Rodriguez Toca <rodrigueztoca21@gmail.com>
 */

namespace SteamManager\Modules;
 
class Header{
    // CONFIGURATIONS
    private $pageTitle;
    // GENERATED SECTION
    private $compileMeta, $compileJS, $compileJSAdditional, $compileCSS, $compileCSSAdditional;

    /**
     * INITIALIZES CONSTRUCTOR
     * --------------------
     * @param string    $pageTitle Page Title
     * @param bool      $includeAutoSave True or False if you want to generate with autosave script
     * @param bool      $includeFormTrackerLocker True or False if you want to generate with form locker and session tracking script
     */
    public function __construct($pageTitle){
        $this->compileJSAdditional = "";
        $this->compileCSSAdditional = "";
        $this->pageTitle = $pageTitle;
    }
    /**
     * Includes an additional JS to the compiler. Make sure the path begins from the root.
     * --------------------
     * @param string $path_to_js Path to the JS File taken the root as a reference.
     */
    function includeAdditionalJS($path_to_js):void{
        $this->compileJSAdditional .= '<script type="text/javascript" src="' . $GLOBALS['webroot'] . "/" . $path_to_js . '"></script>';
    }
    /**
     * Includes an additional CSS to the compiler. Make sure the path begins from the root.
     * --------------------
     * @param string $path_to_css Path to the CSS File taken the root as a reference.
     */
    function includeAdditionalCSS($path_to_css):void{
        $this->compileCSSAdditional .= '<link rel=stylesheet href="' . $GLOBALS['webroot'] . "/" . $path_to_css . '"  type="text/css">';
    }
    /**
     * Generate CSS
     */
    private function _generateCSS(): void{
        $this->compileCSS = '
            <link rel="preconnect" href="https://fonts.googleapis.com">
            <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
            <link href="https://fonts.googleapis.com/css2?family=Nunito+Sans:ital,opsz,wght@0,6..12,200..1000;1,6..12,200..1000&display=swap" rel="stylesheet">
            <link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/node_modules/@fortawesome/fontawesome-free/css/all.css" type="text/css">
            <link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/node_modules/bootstrap/dist/css/bootstrap.min.css" type="text/css">
            <link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/node_modules/aos/dist/aos.css" type="text/css">
            <link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/node_modules/alertifyjs/build/css/alertify.css" type="text/css">
            <link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/node_modules/tippy.js/dist/backdrop.css" type="text/css">
        ';

        // ADDITIONALS CSS
        $this->compileCSS .= $this->compileCSSAdditional;
    }
    /**
     * Generate Meta
     */
    private function _generateMeta(): void{
        $this->compileMeta = '
            <meta http-equiv="content-type" content="text/html; charset=UTF-8">
            <meta charset="utf-8">
            <title>'. $this->pageTitle .'</title>
            <meta name="referrer" content="strict-origin" />
            <meta name="generator" content="Steam Manager" />
            <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
        ';
    }
    /**
     * Generate JS
     */
    private function _generateJS(): void{
        $this->compileJS = '
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/jquery/dist/jquery.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/@fortawesome/fontawesome-free/js/all.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/bootstrap/dist/js/bootstrap.min.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/aos/dist/aos.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/tilt.js/src/tilt.jquery.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/alertifyjs/build/alertify.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/@popperjs/core/dist/umd/popper.js"></script>
            <script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/node_modules/tippy.js/dist/tippy-bundle.umd.min.js"></script>
        ';
        // ADDITIONALS JS
        $this->compileJS .= $this->compileJSAdditional;
    }

    /**
     * Compilers & Generate
     */
    private function _generate(): void{
        $this->_generateMeta();
        $this->_generateCSS();
        $this->_generateJS();
        return;
    }
    /**
     * GENERATED AND INCLUDES META
     */
    function _includeSimplyMeta(): void{
        $this->_generate();
        echo $this->compileMeta;
        return;
    }
    /**
     * GENERATED AND INCLUDES THE CSS
     */
    function _includeSimplyCSS(): void{
        $this->_generate();
        echo $this->compileCSS;
        return;
    }
    /**
     * GENERATED AND INCLUDES THE JS
     */
    function _includeSimplyJS(): void{
        $this->_generate();
        echo $this->compileJS;
        return;
    }
    /**
     * GENERATE AND INCLUDE GLOBAL STYLES (CSS)
     */
    function _includeGlobalsCSS(): void{
        echo '<link rel=stylesheet href="' . $GLOBALS['webroot'] .'/library/css/globals.css" type="text/css">';
        return;
    }
    /**
     * GENERATE AND INCLUDE GLOBAL JAVASCRIPT (JS)
     */
    function _includeGlobalsJS(): void{
        echo '<script type="text/javascript" src="' . $GLOBALS['webroot'] .'/library/js/globals.js"></script>';
        return;
    }
    
}