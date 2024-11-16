<?php
$username = $_GET['username'] ?? null;
$usernameSdk = $_GET['username_sdk'] ?? null;
$response = [];

if ($username === null || $usernameSdk === null) {
    http_response_code(400);
    echo "Missing required parameters.";
    exit;
}

// VALIDATE STEAM CREDENTIALS AND SDK
function validateSteamCredentials($username, $usernameSdk, &$response) {
    $isValid = false;

    $url = "https://api.steampowered.com/ISteamUser/GetFriendList/v1/?key={$usernameSdk}&steamid={$username}";

    // cURL CALL
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    $output = curl_exec($ch);
    curl_close($ch);

    // DECODE RESPONSE
    $response = json_decode($output, true);

    // VALIDATE
    if (isset($response['friendslist']['friends']) && count($response['friendslist']['friends']) > 0) {
        $isValid = true;
        $folderName = $username;
        $folderPath = __DIR__ . '/../../accounts/' . $folderName;
        if (!file_exists($folderPath)) {
            mkdir($folderPath, 0777, true);
        }

        if (file_exists($folderPath)) {
            $friendsJson = json_encode($response);
            file_put_contents($folderPath . '/friends.json', $friendsJson);
        } else {
            $friendsJson = json_encode($response);
            file_put_contents($folderPath . '/friends.json', $friendsJson);
        }
    }

    return $isValid;
}

$responseData = [];
if (validateSteamCredentials($username, $usernameSdk, $response)) {
    http_response_code(200);
    $responseData = ['status' => 'success', 'message' => 'Steam Account Friends Valid', 'data' => $response];
} else {
    http_response_code(400);
    $responseData = ['status' => 'error', 'message' => 'Steam Account Friends Invalid'];
}

header('Content-Type: application/json');
echo json_encode($responseData);
?>
