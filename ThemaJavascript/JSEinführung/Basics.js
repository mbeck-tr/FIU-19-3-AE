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