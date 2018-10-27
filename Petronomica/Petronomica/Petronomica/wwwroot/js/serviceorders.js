
function Result(msg) {
    document.getElementById("result").innerHTML = msg;
}
function PreOrder(id) {
    httpGetAsync("/Services/CreatePreOrder?id=" +id, Result);
}