<?php
$username = $_GET['username'] ?? null;
$usernameSdk = $_GET['username_sdk'] ?? null;
$returnData = $_GET['return'] ?? false;
$response = [];

if ($username === null || $usernameSdk === null) {
    http_response_code(400);
    echo "Missing required parameters.";
    exit;
}

// VALIDATE STEAM CREDENTIALS AND SDK
function validateSteamCredentials($username, $usernameSdk, &$response) {
    $isValid = false;

    $url = "https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={$usernameSdk}&steamids={$username}";

    // cURL CALL
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $output = curl_exec($ch);
    curl_close($ch);

    // DECODE RESPONSE
    $response = json_decode($output, true);

    // VALIDATE
    if (isset($response['response']['players']) && count($response['response']['players']) >= 0 && isset($response['response']['players'][0]) && isset($response['response']['players'][0]["steamid"])) {
        $isValid = true;
    }

    return $isValid;
}

$responseData = [];
if (validateSteamCredentials($username, $usernameSdk, $response)) {
    http_response_code(200);
    if($returnData != false){
        $responseData = ['status' => 'success', 'message' => 'Steam Account & SDK Valid', 'data' => $response];
    } else {
        $responseData = ['status' => 'success', 'message' => 'Steam Account & SDK Valid'];
    }
} else {
    http_response_code(400);
    $responseData = ['status' => 'error', 'message' => 'Steam Account or SDK Invalid'];
}

header('Content-Type: application/json');
echo json_encode($responseData);