
function Result(msg) {
    //document.getElementById("result").style.innerHTML = msg;
  //  console.log(msg);
    window.location.href = 'OrderSettings?id' + id;
}
function PreOrder(id) {
    var url = 'Services/OrderSettings?id='+id;
    //httpGetAsyncP(url, Result);
  
            ////console.log("lnkLogout_Confirm clciked.");

            window.location.href = url;
      
   

  
}
function CardAnimOver(x) {

    x.style.border ='4px solid darkseagreen';
    x.style.opacity='60%';
}
function CardAnimLost(x) {

    x.style.border='none';
    x.style.opacity = '90%';
}
