
function forward() {
    var imageNumber = getImageNumber();
    imageNumber++;
    if (imageNumber == 6) imageNumber = "1";

    var path = getPath();
    document.getElementById("image").setAttribute("src", path + "Image" + imageNumber + ".png");
}

function back() {
    var imageNumber = getImageNumber();
    imageNumber--;
    if (imageNumber == 0) imageNumber = "5";

    var path = getPath();
    document.getElementById("image").setAttribute("src", path + "Image" + imageNumber + ".png");
}

function setImage() {
    var imageNumber = document.getElementById("imageNumber").value;
    imageNumber = parseInt(imageNumber);
    if (isNaN(imageNumber)) {
        alert("Bitte Zahl eingeben")
    }
    else {
        if (imageNumber > 5 || imageNumber < 1)
            alert("kein Bild vorhanden");
        else {
            var path = getPath();
            document.getElementById("image").setAttribute("src", path + "Image" + imageNumber + ".png");
            document.getElementById("beschriftung").innerHTML = "Bildnr. " + imageNumber;
            var history = document.getElementById("history").innerHTML
            document.getElementById("history").innerHTML = history + "<tr><td>Bildnr: " + imageNumber +"</td></tr>";
        }
    }
}

function getImageNumber() {
    var imageElement = document.getElementById("image");
    var srcAttribute = imageElement.getAttribute("src");
    var startIndex = srcAttribute.lastIndexOf("/") + 6;
    var endIndex = startIndex + 1;
    var imageNumber = srcAttribute.substring(startIndex, endIndex);
    return parseInt(imageNumber);
}

function getPath() {
    var imageElement = document.getElementById("image");
    var srcAttribute = imageElement.getAttribute("src");
    return srcAttribute.substring(0, srcAttribute.lastIndexOf("/") + 1);
}