function UserResult(msg) {
    document.getElementById("userinfo").style.innerHTML = msg;
    console.log(msg);
}
(function GetUserInfo() {
    var url = 'GetUserInfo';
    httpGetAsyncP(url, UserResult);
}());
function httpGetAsyncP(theUrl, callback) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
            callback(xmlHttp.responseText);
    }
    xmlHttp.open("POST", theUrl, true);
    xmlHttp.send(null);
}