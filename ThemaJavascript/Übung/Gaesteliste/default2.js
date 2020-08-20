// alert("alert");
// var promptValue = prompt("Zeit");
// console.log(promptValue);

var gaesteListe = [];
// {name: "Hans",address: "Musterweg 1 11111 Musterstadt",tel:"123456789",email:"hans@hans.org",date:"10.10.2010",come:"11:00",go:"12:00"}

function AddGuest() { //Eventhandler für Hinzufügen-Button
    var gastObject = CreateObject();
    gaesteListe.push(gastObject);
    document.getElementById("txtbID").value = gaesteListe.length;
    Update();
}

function CreateObject(UseSystemTime = true) { // erzeugt ein Gast-Objekt
    
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
    var gast = {
        name:document.getElementById("txtbName").value,
        address: document.getElementById("txtbAdresse").value,
        tel:document.getElementById("txtbTel").value,
        email:document.getElementById("txtbEmail").value,
        date: gastDatumKommen,
        come: gastZeitKommen,
        go: gastZeitGehen,
        ToString: function () {
            return this.name +
            ", " + this.address +
            ", Tel. " + this.tel +
            ", Email: " + this.email +
            ", Datum: " + this.date +
            ", Kommen: " + this.come +
            ", Gehen: " + this.go
        }
    };
    
    return gast;
}

function UpdateTable() { //Schreibt die HTML-Tabelle aus dem Gaesteliste-Array
    var tabellenHTML = "";
    var gaeste = gaesteListe.filter(CheckEqualDateTime);
    for (var i = 0; i < gaeste.length; i++) { 
        var gast = gaeste[i]; 
        tabellenHTML += "<tr onclick='change(" + i + ")'><td>" + gast.name + "</td><td>"
            + gast.address + "</td><td>"
            + gast.tel + "</td><td>"
            + gast.email + "</td><td>"
            + gast.date + "</td><td>"
            + gast.come + "</td><td>"
            + gast.go + "</td></tr>";
    }
    document.getElementById("tabelle").innerHTML = tabellenHTML;
}

function change(listIndex) { //Eventhandler für Tabellen-Zeilen-Click
    var gast = gaesteListe[listIndex];
    document.getElementById("txtbID").value = (listIndex + 1);
    document.getElementById("txtbName").value = gast.name;
    document.getElementById("txtbAdresse").value = gast.address;
    document.getElementById("txtbTel").value = gast.tel;
    document.getElementById("txtbEmail").value = gast.email;
    document.getElementById("txtbDatum").value = gast.date;
    document.getElementById("txtbZeit").value = gast.come;
    Update();
}

function UpdateList() { //Schreibt die HTML-Liste aus dem Gaesteliste-Array
    var listeHTML = "";
    for (var i = 0; i < gaesteListe.length; i++) {
        listeHTML += "<li>" + gaesteListe[i].ToString() + "</li>";
    }
    document.getElementById("liste").innerHTML = listeHTML;
}

function ChangeGuest() { //Eventhandler für Ändern-Button
    var guestRecord = CreateObject(false);
    var guestID = document.getElementById("txtbID").value;

    var datum = new Date();
    var gastZeitGehen = datum.getHours() + ":";
    gastZeitGehen += datum.getMinutes();
    
    guestRecord.go = prompt("Gehenszeit?", gastZeitGehen);

    gaesteListe.splice(guestID - 1, 1, guestRecord);
    Update();
}

var index = 0;

function sort(column) { //Eventhandler für Click auf Spaltenheader
    switch (column) {
        case "name":
            gaesteListe = gaesteListe.sort((a,b)=>{
                if (a.name > b.name) return 1; else return -1;
            });
            break;
        case "address":
            gaesteListe = gaesteListe.sort((a,b)=>{
                if (a.address > b.address) return 1; else return -1;
            });
            break;
        case "tel":
            gaesteListe = gaesteListe.sort((a,b)=>{
                if (a.tel > b.tel) return 1; else return -1;
            });
            break;
        case "email":
            gaesteListe = gaesteListe.sort((a,b)=>{
                if (a.email > b.email) return 1; else return -1;
            });
            break;
        case "date":
        case "come":
            gaesteListe = gaesteListe.sort((a,b)=>{
                if (a.date > b.date) return 1; else return -1;
            });
            gaesteListe = gaesteListe.sort((a, b) => {
                if (a.date == b.date) {
                    index = "come";
                    return (a, b) => {return a.come >  b.come ? 1 : -1};
                } else return 0;
            });
            break;
        default:
            break;
    }
    Update();
}

function Update() { UpdateList(); UpdateTable(); }

function CheckEqualDateTime(v, i, a) {
    
    if (document.getElementById("cbFilter").checked) {

        var id = document.getElementById("txtbID").value;
        var datum = gaesteListe[id - 1].date;
        var zeitKommen = gaesteListe[id - 1].come;
        var zeitGehen = gaesteListe[id - 1].go;
        
        if (datum == v.date) {
            if (v.go < zeitKommen || v.come > zeitGehen)
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