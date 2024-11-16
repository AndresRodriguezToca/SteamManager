$(document).ready(async function() {
    for (const SteamID of accountsID) {
        try {
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

                // COMPILE ACCOUNT INFORMATION
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
                    
                    // COMPILE GAMES
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
                        await updateLoadingMessage(`Asking Steam for ${accountName}'s Friends...`);
                        
                        // COMPILE FRIENDS
                        const friendsResponse = await $.ajax({
                            url: rootFetchFriends,
                            type: 'GET',
                            data: {
                                username: SteamID,
                                username_sdk: username_sdk
                            }
                        });
                        if (friendsResponse.status === "success") {
                            const friendsCount = friendsResponse.data.friendslist.friends.length;
                            const friendsBadge = `<span class="position-absolute translate-middle badge rounded-pill bg-success" style="top: 25px;">${friendsCount} <i class="fa-solid fa-user-friends"></i></span>`;
                            $(`#${SteamID}_image_loader`).append(friendsBadge);
                            await updateLoadingMessage(`Asking Steam for ${accountName}'s Wishlist...`);
                            
                            // COMPILE WISHLIST
                            const wishlistResponse = await $.ajax({
                                url: rootFetchWishlist,
                                type: 'GET',
                                data: {
                                    username: SteamID,
                                    username_sdk: username_sdk
                                }
                            });
                            if (wishlistResponse.status === "success") {
                                const wishlistCount = Object.keys(wishlistResponse.data).length;
                                const wishlistBadge = `<span class="position-absolute translate-middle badge rounded-pill bg-warning" style="top: 50px;">${wishlistCount} <i class="fa-solid fa-heart"></i></span>`;
                                $(`#${SteamID}_image_loader`).append(wishlistBadge);
                            } else {
                                alertify.set('notifier', 'position', 'top-right');
                                alertify.error("<i class='fa-solid fa-circle-exclamation'></i> Failed to fetch wishlist for ${accountName}.<br>" + wishlistResponse.message);
                            }
                        } else {
                            alertify.set('notifier', 'position', 'top-right');
                            alertify.error("<i class='fa-solid fa-circle-exclamation'></i> Failed to fetch friends for ${accountName}.<br>" + friendsResponse.message);
                        }
                        
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