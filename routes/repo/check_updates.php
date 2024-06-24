<?php

$repoOwner = 'AndresRodriguezToca';
$repoName = 'SteamManager';
$currentBranch = 'development_web_base';

// GitHub personal access token with 'repo' scope
$accessToken = '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';

// GitHub API endpoint to fetch branches
$apiUrl = "https://api.github.com/repos/$repoOwner/$repoName/branches";

// cURL initialization
$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $apiUrl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, array(
    "Authorization: token $accessToken",
    "User-Agent: Your-App-Name"
));

// Execute cURL request
$response = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
    exit;
}

// Close cURL session
curl_close($ch);

// Decode JSON response
$branches = json_decode($response, true);

// Find master branch
$masterBranchSha = '';
foreach ($branches as $branch) {
    if ($branch['name'] === 'master') {
        $masterBranchSha = $branch['commit']['sha'];
        break;
    }
}

// Check if master branch SHA is fetched
if (!$masterBranchSha) {
    echo "Master branch not found or SHA not retrieved.";
    exit;
}

// GitHub API endpoint to compare branches
$compareUrl = "https://api.github.com/repos/$repoOwner/$repoName/compare/$masterBranchSha...$currentBranch";

// Initialize cURL for comparing branches
$ch = curl_init();
curl_setopt($ch, CURLOPT_URL, $compareUrl);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
curl_setopt($ch, CURLOPT_HTTPHEADER, array(
    "Authorization: token $accessToken",
    "User-Agent: Your-App-Name"
));

// Execute cURL request
$response = curl_exec($ch);
if (curl_errno($ch)) {
    echo 'Error:' . curl_error($ch);
    exit;
}

// Close cURL session
curl_close($ch);

// Decode JSON response
$comparison = json_decode($response, true);

// Check if there are commits ahead of master
if (isset($comparison['ahead_by']) && $comparison['ahead_by'] > 0) {

    $responseData = [
        'status' => 'success',
        'message' => "There are {$comparison['ahead_by']} commits ahead of master in $currentBranch",
        'data' => true
    ];
    http_response_code(200); // OK
    echo json_encode($responseData);
} else {
    $responseData = [
        'status' => 'success',
        'message' => "No updates found in $currentBranch that are ahead of master",
        'data' => false
    ];
    http_response_code(200); // OK
    echo json_encode($responseData);
}
?>
