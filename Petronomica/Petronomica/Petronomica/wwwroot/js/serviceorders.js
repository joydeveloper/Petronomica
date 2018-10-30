
function Result(msg) {
    document.getElementById("result").style.innerHTML = msg;
}
function PreOrder(id) {
   
    httpGetAsync("/Services/CreatePreOrder?id=" + id, Result);

    
}
function CardAnimOver(x) {

    x.style.backgroundColor='white';
    x.style.opacity='60%';
}
function CardAnimLost(x) {

    x.style.backgroundColor = 'green';
    x.style.opacity = '90%';
}
