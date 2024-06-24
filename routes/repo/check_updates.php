<?php

$repoOwner = 'AndresRodriguezToca';
$repoName = 'SteamManager';
$currentBranch = 'development_web_base';

// ENV VARIABLES
function loadEnv()
{
    $envFile = __DIR__ . '/.env';
    if (!file_exists($envFile)) {
        throw new Exception('.env file not found');
    }

    $env = file_get_contents($envFile);
    $lines = explode("\n", $env);

    foreach ($lines as $line) {
        $line = trim($line);
        if (!$line || strpos($line, '#') === 0) {
            continue;
        }

        list($key, $value) = explode('=', $line, 2);
        $key = trim($key);
        $value = trim($value);

        if (!array_key_exists($key, $_SERVER) && !array_key_exists($key, $_ENV)) {
            putenv("$key=$value");
            $_ENV[$key] = $value;
            $_SERVER[$key] = $value;
        }
    }
}
loadEnv();

$accessToken = getenv('GITHUB_ACCESS_TOKEN');

$apiUrl = "https://api.github.com/repos/$repoOwner/$repoName/branches";

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $apiUrl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, array(
    "Authorization: token $accessToken",
    "User-Agent: Your-App-Name"
));

$response = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
    exit;
}

curl_close($ch);

$branches = json_decode($response, true);

$masterBranchSha = '';
foreach ($branches as $branch) {
    if ($branch['name'] === 'master') {
        $masterBranchSha = $branch['commit']['sha'];
        break;
    }
}

if (!$masterBranchSha) {
    echo "Master branch not found or SHA not retrieved.";
    exit;
}

$compareUrl = "https://api.github.com/repos/$repoOwner/$repoName/compare/$masterBranchSha...$currentBranch";

$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $compareUrl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, array(
    "Authorization: token $accessToken",
    "User-Agent: Your-App-Name"
));

$response = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
    exit;
}

curl_close($ch);

$comparison = json_decode($response, true);

if (isset($comparison['ahead_by']) && $comparison['ahead_by'] > 0) {
    $responseData = [
        'status' => 'success',
        'message' => "There are {$comparison['ahead_by']} commits ahead of master in $currentBranch",
        'data' => true
    ];
    http_response_code(200);
    echo json_encode($responseData);
} else {
    $responseData = [
        'status' => 'success',
        'message' => "No updates found in $currentBranch that are ahead of master",
        'data' => false
    ];
    http_response_code(200);
    echo json_encode($responseData);
}
?>
