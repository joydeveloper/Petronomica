
function Result(msg) {
    document.getElementById("result").style.innerHTML = msg;
}
function PreOrder(id) {
   
    httpGetAsync("/Services/CreatePreOrder?id=" + id, Result);

    
}
function CardAnimOver(x) {

    x.style.border ='2px solid darkseagreen';
    x.style.opacity='60%';
}
function CardAnimLost(x) {

    x.style.border='none';
    x.style.opacity = '90%';
}
