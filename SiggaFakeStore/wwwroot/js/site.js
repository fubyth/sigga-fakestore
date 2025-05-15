function favoriteProduct(checkBox, userId) {
    console.log(checkBox.value, userId);

    if(checkBox.checked){
        var endpoint = '/Home/AddFavoriteProduct';
    } else{
        var endpoint = '/Home/RemoveFavoriteProduct';
    }
    
    $.post(endpoint, {
        id: checkBox.value,
        user: userId,
    }, function (data) {
        console.log(data);
    });

  }