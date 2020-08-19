var gaesteListe = [];
// "Hans,Musterweg 1,11111 Musterstadt,123456789,hans@hans.org,10.10.2010,11:00"

function AddGuest() {
    var gastname = document.getElementById("txtbName").value;
    var gastAdresse = document.getElementById("txtbAdresse").value;
    var gastTel = document.getElementById("txtbTel").value;
    var gastEmail = document.getElementById("txtbEmail").value;
    // var gastDatumKommen = document.getElementById("txtbDatum").value;
    // var gastZeitKommen = document.getElementById("txtbZeit").value;

    var datum = new Date();
    gastDatumKommen = datum.getFullYear() + "-";
    gastDatumKommen += (datum.getMonth() + 1) + "-";
    gastDatumKommen += datum.getDate();

    gastZeitKommen = datum.getHours() + ":";
    gastZeitKommen += datum.getMinutes();
    
    var gastRecord = gastname + "," +
        gastAdresse + "," +
        gastTel + "," +
        gastEmail + "," +
        gastDatumKommen + "," +
        gastZeitKommen;
    gaesteListe.push(gastRecord);

    Update();
}

function UpdateTable() {
    var tabellenHTML = "";
    for (var i = 0; i < gaesteListe.length; i++) {
        var gast = gaesteListe[i].split(",");
        console.log(gast);
        tabellenHTML += "<tr><td>" + gast[0] + "</td><td>"
            + gast[1] + "</td><td>"
            + gast[2] + "</td><td>"
            + gast[3] + "</td><td>"
            + gast[4] + "</td><td>"
            + gast[5] + "</td></tr>";
    }
    document.getElementById("tabelle").innerHTML = tabellenHTML;
}

function UpdateList() {
    var listeHTML = "";
    for (var i = 0; i < gaesteListe.length; i++) {
        listeHTML += "<li>" + gaesteListe[i] + "</li>";
    }
    document.getElementById("liste").innerHTML = listeHTML;
}

var index = 0;

function sort(column) {
    switch (column) {
        case "name":
            index = 0;
            gaesteListe = gaesteListe.sort(SortByGlobalIndex);
            break;
        case "address":
            index = 1;
            gaesteListe = gaesteListe.sort(SortByGlobalIndex);
            break;
        case "tel":
            index = 2;
            gaesteListe = gaesteListe.sort(SortByGlobalIndex);
            break;
        case "email":
            index = 3;
            gaesteListe = gaesteListe.sort(SortByGlobalIndex);
            break;
        case "date":
        case "time":
            index = 4;
            gaesteListe = gaesteListe.sort(SortByGlobalIndex);
            gaesteListe = gaesteListe.sort((a, b) => {
                if (a.split(",")[4] == b.split(",")[4]) {
                    index = 5;
                    return SortByGlobalIndex(a, b);
                } else return 0;
            });
            break;
        default:
            break;
    }
    Update();
}

function SortByGlobalIndex(gast1, gast2) {
    if (gast1.split(",")[index] > gast2.split(",")[index])
        return 1;
    else if (gast1.split(",")[index] < gast2.split(",")[index])
        return -1;
    else return 0;
}


function Update() { UpdateList(); UpdateTable(); }
