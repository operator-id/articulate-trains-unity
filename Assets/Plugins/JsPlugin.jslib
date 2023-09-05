mergeInto(LibraryManager.library, {
    ShowItemNugget: function (itemIdUtf8) {
        var itemId = UTF8ToString(itemIdUtf8);
        console.log(itemId);
        player = parent.GetPlayer();
        player.SetVar(itemId + "_nugget_start", true);
    }
});