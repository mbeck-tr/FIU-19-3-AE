function IsEven(){
    var number = document.getElementById("txbNumber").value;
    if (number%2 == 0) {
        alert(number + " is even number");
    }else{
        alert(number + " is odd number");
    }
}