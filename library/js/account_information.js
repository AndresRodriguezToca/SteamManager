$(function(){
    function getAccountIDActive(){
        $('#accountFlex div[data-selector="enable"]').each(function() {
            // MAKE ELEMENT VISUALLY ACTIVE
            $(this).addClass('active_account');
            $(this).removeClass('inactive_account');
            $('#accountFlex div[data-selector="disable"]').each(function() {
                $(this).addClass('inactive_account');
                $(this).removeClass('active_account');
            });
            // GET ACCOUNT ID
            return $(this).attr('id').replace('_image_loader', '');
        });
    }

    function fetchAccountInformation(){
        
    }
    // GET CURRENT ACTIVE ID
    var accountID = getAccountIDActive();

    // ADD A LISTENER EVENT TO EACH ACCOUNT DATA SELECTOR
    $('#accountFlex div[data-selector]').on('click', function() {
        $('#accountFlex div[data-selector]').attr('data-selector', 'disable');
        $(this).attr('data-selector', 'enable');
        accountID = getAccountIDActive();
    });
})