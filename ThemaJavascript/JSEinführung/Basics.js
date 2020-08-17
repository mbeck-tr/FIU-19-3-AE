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


var emptyArray = [];
var filledArray = [10,20,30];
var constructedArray = new Array(10);

console.log(emptyArray);
console.log(filledArray);
console.log(constructedArray);
console.log(filledArray.length);
console.log(filledArray[1]);
filledArray[1] = 40;
console.log(filledArray[1]);


var myArray = [];
for (var i=0; i <= 5; i++){
    myArray[i] = i*2;
}

for (var i=0; i < myArray.length; i++){
    document.write(myArray[i] + "<br/>");
}

console.log(myArray.length);

var pushArray = [];
for (var i=0; i <= 5; i++){
    pushArray.push(i*2);
}

console.log(pushArray.length);
for(var i=0; i <= 5; i++){
    document.write(pushArray.pop() + "<br/>");
}

console.log(pushArray.length);

var shiftArray = [1,2,3,4];
console.log("Length: " + shiftArray.length);
console.log(shiftArray.shift());
console.log("Length: " + shiftArray.length);
console.log(shiftArray);

var unshiftArray = [2,3,4];
unshiftArray.unshift(10);
console.log(unshiftArray);

unshiftArray.sort((a,b) => {return a-b});
console.log("sort: " + unshiftArray);

unshiftArray.reverse();
console.log("reverse: " + unshiftArray);

myArray = [1,2,8,7,5];
myArray.splice(2,2,3,4);
console.log("splice: " + myArray);

console.log("indexOf 3: " + myArray.indexOf(3));

myArray.push(3);
console.log(myArray);
console.log("lastIndexOf 3: " + myArray.lastIndexOf(3));

console.log("filtered: " + myArray.filter(IsEven));


function IsEven(value, index, array){
    if (value % 2 == 0){
        return true;
    }
    else{
        return false;
    }
}

var names = ["Sam", "Max", "Indi", "Sam", "Peter", "Max", "Paul", "Indi","Mary"];
var uniqueItems = names.filter((value,index,array) => {
    return array.indexOf(value) == index;
});

console.log("unique: " + uniqueItems);

var Array2D = new Array(3);
for (var i=0; i < 3; i++)
    Array2D[i] = new Array(3);

Array2D[0][0] = "1";
Array2D[0][1] = "2";
Array2D[0][2] = "3";

Array2D[1][0] = "4";
Array2D[1][1] = "5";
Array2D[1][2] = "6";

Array2D[2][0] = "7";
Array2D[2][1] = "8";
Array2D[2][2] = "9";

for (var i = 0; i <3; i++){
    for (var j = 0; j < 3; j++){
        document.write(Array2D[i][j] + "&emsp;");
    }
    document.write("<br/>");
}