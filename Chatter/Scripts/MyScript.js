// toggle class scroll 
$(window).scroll(function () {
    if ($(this).scrollTop() > 50) {
        $('.navbar-trans').addClass('afterscroll');
    } else {
        $('.navbar-trans').removeClass('afterscroll');
    }

});


$.get("@Url.Action("TestJson","Chats")", function (serverResponse) {
    var jsonTest = JSON.parse(serverResponse);
    console.log(jsonTest);
    $("#response").text(jsonTest.firstName);
});