function createCookie(cookieName, cookieValue, daysToExpire) {
    var date = new Date();
    date.setTime(date.getTime() + (daysToExpire * 24 * 60 * 60 * 1000));
    document.cookie = cookieName + "=" + cookieValue + "; expires=" + date.toGMTString();
}
function getCookie(cookieName) {
    var name = cookieName + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
function checkCookie() {
    var user = getCookie("testCookie");
    if (user != "")
        alert("Welcome Back " + user + "!!!");
    else {
        user = prompt("Please enter your name");
        num = prompt("How many days you want to store your name on your computer?");
        if (user != "" && user != null) {
            createCookie("testCookie", user, num);
        }
    }
}