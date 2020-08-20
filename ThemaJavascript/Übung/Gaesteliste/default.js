// alert("alert");
// var promptValue = prompt("Zeit");
// console.log(promptValue);

var gaesteListe = [];
// "Hans,Musterweg 1,11111 Musterstadt,123456789,hans@hans.org,10.10.2010,11:00"

function AddGuest() { //Eventhandler für Hinzufügen-Button
    var gastRecord = CreateRecord();
    gaesteListe.push(gastRecord);
    document.getElementById("txtbID").value = gaesteListe.length;
    Update();
}

function CreateRecord(UseSystemTime = true) { // erzeugt aus den Formulardaten einen CSV-String
    var gastname = document.getElementById("txtbName").value;
    var gastAdresse = document.getElementById("txtbAdresse").value;
    var gastTel = document.getElementById("txtbTel").value;
    var gastEmail = document.getElementById("txtbEmail").value;
    var gastDatumKommen;
    var gastZeitKommen;
    var gastZeitGehen = "00:00";

    if (UseSystemTime) {
        var datum = new Date();
        gastDatumKommen = datum.getFullYear() + "-";
        gastDatumKommen += datum.getMonth() < 9 ? "0" + (datum.getMonth() + 1) : datum.getMonth() + 1;
        gastDatumKommen += "-";
        gastDatumKommen += datum.getDate();

        gastZeitKommen = datum.getHours() + ":";
        gastZeitKommen += datum.getMinutes();
    } else {
        gastDatumKommen = document.getElementById("txtbDatum").value;
        gastZeitKommen = document.getElementById("txtbZeit").value;
    }

    var gastRecord = gastname + "," +
        gastAdresse + "," +
        gastTel + "," +
        gastEmail + "," +
        gastDatumKommen + "," +
        gastZeitKommen + "," +
        gastZeitGehen;
    return gastRecord;
}

function UpdateTable() { //Schreibt die HTML-Tabelle aus dem Gaesteliste-Array
    var tabellenHTML = "";
    var gefilterteGaesteListe = gaesteListe.filter(CheckEqualDateTime);
    for (var i = 0; i < gefilterteGaesteListe.length; i++) {
        var gast = gefilterteGaesteListe[i].split(",");
        tabellenHTML += "<tr onclick='change(" + i + ")'><td>" + gast[0] + "</td><td>"
            + gast[1] + "</td><td>"
            + gast[2] + "</td><td>"
            + gast[3] + "</td><td>"
            + gast[4] + "</td><td>"
            + gast[5] + "</td><td>"
            + gast[6] + "</td></tr>";
    }
    document.getElementById("tabelle").innerHTML = tabellenHTML;
}

function change(recordID) { //Eventhandler für Tabellen-Zeilen-Click
    var gast = gaesteListe[recordID].split(",");
    document.getElementById("txtbID").value = (recordID + 1);
    document.getElementById("txtbName").value = gast[0];
    document.getElementById("txtbAdresse").value = gast[1];
    document.getElementById("txtbTel").value = gast[2];
    document.getElementById("txtbEmail").value = gast[3];
    document.getElementById("txtbDatum").value = gast[4];
    document.getElementById("txtbZeit").value = gast[5];
    Update();
}

function UpdateList() { //Schreibt die HTML-Liste aus dem Gaesteliste-Array
    var listeHTML = "";
    for (var i = 0; i < gaesteListe.length; i++) {
        listeHTML += "<li>" + gaesteListe[i] + "</li>";
    }
    document.getElementById("liste").innerHTML = listeHTML;
}

function ChangeGuest() { //Eventhandler für Ändern-Button
    var guestRecord = CreateRecord(false);
    var guestID = document.getElementById("txtbID").value;

    var datum = new Date();
    var gastZeitGehen = datum.getHours() + ":";
    gastZeitGehen += datum.getMinutes();
    var gastZeitGehen = prompt("Gehenszeit?", gastZeitGehen);

    guestRecord = guestRecord.substring(0, guestRecord.lastIndexOf(","));
    guestRecord += "," + gastZeitGehen;

    gaesteListe.splice(guestID - 1, 1, guestRecord);
    Update();
}

var index = 0;

function sort(column) { //Eventhandler für Click auf Spaltenheader
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

function SortByGlobalIndex(gast1, gast2) { // Sortierfunktion
    if (gast1.split(",")[index] > gast2.split(",")[index])
        return 1;
    else if (gast1.split(",")[index] < gast2.split(",")[index])
        return -1;
    else return 0;
}


function Update() { UpdateList(); UpdateTable(); }

function CheckEqualDateTime(v, i, a) {
    console.log(document.getElementById("cbFilter").checked);
    if (document.getElementById("cbFilter").checked) {

        var id = document.getElementById("txtbID").value;
        var datum = gaesteListe[id - 1].split(",")[4]
        var zeitKommen = gaesteListe[id - 1].split(",")[5]
        var zeitGehen = gaesteListe[id - 1].split(",")[6];
        var gast = v.split(",");
        
        if (datum == gast[4]) {
            if (gast[6] < zeitKommen || gast[5] > zeitGehen)
                return false;
            else return true;
        }
        
        return false;
    }
    return true;
}

// zeit: 11:30-13:30

// zeit: 
// 9:30-10:30
// 9:30-12:30
// 9:30-14:30

// 12:30-13:00
// 12:30-14:30
// 14:00-