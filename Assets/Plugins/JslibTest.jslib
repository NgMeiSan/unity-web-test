
mergeInto(LibraryManager.library,
{
    ImportTelegramlibrary: function(callback)
    {
        var script = document.createElement("script");
        script.src = "https://telegram.org/js/telegram-web-app.js";
        script.body = 
        document.head.appendChild(script);

        script.onload = function ()
        {
            console.log("TELEGRAM SCRIPT LOADED");
            {{{ makeDynCall('vi', 'callback') }}} (true);
        };

        script.onerror = function ()
        {
            console.log("TELEGRAM SCRIPT FAILED TO LOAD");
            {{{ makeDynCall('vi', 'callback') }}} (false);
        };
    },

    Alert: function()
    {
        window.alert("Unity to JS Alert!");
    },

    DebugTest: function()
    {
        console.log(window.Telegram);
    },

    GetUserId: function()
    {
        var retunStr = "";

        var tg = window.Telegram.WebApp;
        var user = tg.initDataUnsafe.user;

        if (user) {
            var userId = user.id;
            console.log('User ID:', userId);
            retunStr = userId;
        } else {
            console.log('No user data available');
            return;
        }

        var bufferSize = lengthBytesUTF8(retunStr) + 1
        var buffer = _malloc(bufferSize);

        stringToUTF8(retunStr, buffer, bufferSize);

        return buffer;
    },

    GetSampleData: function()
    {
        var userData = {
            id: 12345,
            username: "example_user",
            is_bot: false
        };

        var jsonString = JSON.stringify(userData);

        var bufferSize = lengthBytesUTF8(jsonString) + 1
        var buffer = _malloc(bufferSize);

        stringToUTF8(jsonString, buffer, bufferSize);

        return buffer;
    }
})