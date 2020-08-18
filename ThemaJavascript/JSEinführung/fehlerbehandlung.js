//document.write(sayHello());
window.onerror = function (message, url, line){
    alert("Message: " + message + "\nURL: " + url + "\nLine Number: " + line);
    return true;
}

//nonExistingFunction("blaFasel");


function CallServer(){
    try{
        document.write(sayHello());
        document.write("This line will not be executed");
    }catch (e){
        document.write("Description= " + e.description + "<br/>");
        document.write("Message= " + e.message + "<br/>");
        document.write("Stack= " + e.stack + "<br/><br/>");
        return;
    }finally{
        document.write("This line is guaranteed to execute<br/>");
    }

    document.write("This line will be executed");
}

function imageErrorHandler(){
    alert("Bildladefehler!!!");
    return true;
}

CallServer();
