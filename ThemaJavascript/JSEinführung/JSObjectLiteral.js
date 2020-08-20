var liste = [];

liste.push(127356);
liste.push("zeichenfolge");
liste.push("132,Name,bla,fasel,true");

var objektListe = [];

var myObject = {name:"Michael",age:24,maennlich:true};

console.log(myObject.age);
console.log(myObject.name);
console.log(myObject.maennlich);

if (myObject.maennlich === true){
    console.log("Anrede: Herr" );
}

if ("true" == true){
    console.log("ist gleich");
}

if (myObject.age === 24){
    console.log("Datentyp und Wert stimmen überein");
}

objektListe.push(myObject);
var zweitesObjekt = {name:"Susi",age:25,maennlich:false};
objektListe.push(zweitesObjekt);

for (var i=0; i<objektListe.length;i++){
    console.log(objektListe[i].name);
    console.log(objektListe[i].age);
    console.log(objektListe[i].maennlich);
}