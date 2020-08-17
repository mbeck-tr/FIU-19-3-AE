var myVariable = 100;
console.log(myVariable);

myVariable = "Assigning a string value";
console.log(myVariable);

var a = 10;
var b = 20;
var c = a + b;
console.log(c);

a = "Hello ";
b = "JavaScript";
c = a + b;
console.log(c);

a = "Number is: ";
b = 10;
c = a + b;
console.log(c);

a = "50";
b = 10;
c = a + b;
console.log(c);

a = "50";
b = 10;
c = a - b;
console.log(c);

a = "50kjasdfh";
b = 10;
c = a - b;
console.log(c); // NaN --> Not a number

a = "50";
a = parseInt(a);
b = 10;
c = a + b;
console.log(c);

a = "50.234";
a = parseFloat(a);
b = 10;
c = a + b;
console.log(c);

a = "50kjasdfh";
b = 10;
c = a - b;
if (isNaN(c)) {
    console.log("Ergebnis ist keine Zahl")
}else{
    console.log(c);
}

a = "Hello";
b = "JavaScript";
c = a.concat(", ", b);
console.log(c);


console.log("Hello \"JavaScript\"");
console.log('Hello \'JavaScript\'');

console.log('Hello "JavaScript"');
console.log("Hello 'JavaScript'");


var str = "JavaScript Strings";
var result = str.substring(4,10); // Startindex, Endindex
console.log(result);
result = str.substring(10,0);
console.log(result);

result = str.substr(4,10); // Startindex, Anzahl an Zeichen
console.log(result);
result = str.substr(11); // Startindex bis Ende
console.log(result);

result = str.slice(0,10); //Startindex, Endindex
console.log(result);
result = str.slice(10,0);
console.log(result);
result = str.slice(11); // Startindex bis Ende
console.log(result);


a = 1223; // UserInput
var text = "";
if (a % 2 == 0){
    text = "even";
}else
{
    text = "odd";
}

text = a % 2 == 0 ? "even" : "odd"; //Ternary Operator
