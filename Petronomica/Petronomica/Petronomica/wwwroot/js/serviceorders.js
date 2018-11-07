
function ProductConfigResult(msg) {
    //document.getElementById("result").style.innerHTML = msg;
    window.location.href = 'OrderSettings?id' + id;
}
//function Result(msg) {
//    document.getElementById("result").style.innerHTML = msg;
//   // window.location.href = 'OrderSettings?id' + id;
//}
//function PreOrder(id) {
//    var url = 'Services/OrderSettings?id='+id;
//    //window.location.href = url;
//    httpGetAsync(url, Result);
//}
function ProductConfig(id) {
    var url = 'Services/ProductConfig?id=' + id;
    window.location.href = url;
  //  httpGetAsync(url + 0, ProductConfigResult);
}
function CardAnimOver(x) {

    x.style.border ='4px solid darkseagreen';
    x.style.opacity='60%';
}
function CardAnimLost(x) {

    x.style.border='none';
    x.style.opacity = '90%';
}
function OrderType() {
    var url = 'Services/Get?id=';
  
    httpGetAsync(url + 0, Result);
}