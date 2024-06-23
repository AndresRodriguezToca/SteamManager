$(document).ready(async function() {
    const accountsData = [];

    for (const SteamID of accountsID) {
        try {
            const accountData = {
                id: SteamID,
                games: []
            };

            const response = await $.ajax({
                url: rootValidateSDK,
                type: 'GET',
                data: {
                    username: SteamID,
                    username_sdk: username_sdk
                }
            });

            if (response.status === "success") {
                await sleep(100);
                await updateLoadingMessage(`Asking Steam for Account ${SteamID}...`);

                const accountInfoResponse = await $.ajax({
                    url: rootValidateSDK,
                    type: 'GET',
                    data: {
                        username: SteamID,
                        username_sdk: username_sdk,
                        return: true
                    }
                });

                if (accountInfoResponse.status === "success") {
                    const avatarUrl = accountInfoResponse.data.response.players[0].avatarfull;
                    const accountName = accountInfoResponse.data.response.players[0].personaname;
                    const avatarImage = `<div id="${SteamID}_image_loader"><img width="100px" src="${avatarUrl}" class="avatar-style"></div>`;
                    $('#avatarList').append(avatarImage);
                    await updateLoadingMessage(`Asking Steam for ${accountName}'s Games...`);
                    const gamesResponse = await $.ajax({
                        url: rootFetchGames,
                        type: 'GET',
                        data: {
                            username: SteamID,
                            username_sdk: username_sdk
                        }
                    });
                    if (gamesResponse.status === "success") {
                        const gamesCount = gamesResponse.data.response.game_count;
                        const badge = `<span class="position-absolute translate-middle badge rounded-pill bg-primary">${gamesCount} <i class="fa-solid fa-gamepad"></i></span>`;
                        $(`#${SteamID}_image_loader`).append(badge);

                        accountData.games = gamesResponse.data.response.games;
                    } else {
                        alertify.set('notifier', 'position', 'top-right');
                        alertify.error("<i class='fa-solid fa-circle-exclamation'></i> Failed to fetch games for ${accountName}.<br>" + gamesResponse.message);
                    }
                } else {
                    alertify.set('notifier', 'position', 'top-right');
                    alertify.error("<i class='fa-solid fa-circle-exclamation'></i> SDK Validation Failed.<br>" + accountInfoResponse.message);
                }
            } else {
                alertify.set('notifier', 'position', 'top-right');
                alertify.error("<i class='fa-solid fa-circle-exclamation'></i> SDK Validation Failed.<br>" + response.message);
            }

            accountsData.push(accountData);
        } catch (error) {
            alertify.set('notifier', 'position', 'top-right');
            alertify.error("<i class='fa-solid fa-circle-exclamation'></i> Couldn't Access Account.<br>" + error);
        }
    }
    await sleep(100);
    await updateLoadingMessage(`Accessing Steam Manager`);
    await sleep(500);

    // REDIRECT USER TO MAIN PAGE
    window.location.href = `main_page.php`;

    // ANIMATION TO CHANGE THE LOADER TEXT
    async function updateLoadingMessage(message) {
        await $('#loadingMessage').fadeOut('fast', function() {
            $(this).text(message).fadeIn('fast');
        });
        await sleep(300);
    }

    // SLEEP FUNCTION
    function sleep(ms) {
        return new Promise(resolve => setTimeout(resolve, ms));
    }
});