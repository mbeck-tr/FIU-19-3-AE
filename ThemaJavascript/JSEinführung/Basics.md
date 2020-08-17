# JavaScript Basics

- JS ist case-sensitiv
- Kommentare
    + single line: `//`
    + multi line: `/* ... */`
- Datentypen
    + Numbers -> 5 oder 5.234
    + Boolean -> true/false
    + String -> "MyString" oder 'MyString'

---

## Konvertierung

- Methoden
    + `parseInt()`
    + `parseFloat()`
    + `isNan()`

---

## Zeichenfoglen in JavaScript

- Concatenating
    + using + operator
    + using `concat()` method
- Literal: einfaches oder doppeltes Anführungszeichen
- `toLowerCase()`
- `toUpperCase()`
- Länge eines Strings:
    + Property: length
- Leerzeichen entfernen: trim()
    + `var a = " AB ";a.trim(); --> "AB"`
- Ersetzungen:
    + `var myString = "Hello JavaScript"; var result = myString.replace("JavaScript","World");console.log(result); --> Output: Hello World`
- Substrings
    + `substring()`
    + `substr()` Nicht in ie8 und kleiner
    + `slice()`

---

## Conditional Statements

- Verzeigung
    + `if (Condition) statement else statement`
    + Ternary Operator
        - `var text = userInput % 2 == 0 ? "even" : "odd";` 
---

## Switch Statements

```JavaScript
switch(userInput){
    case 1:
        statement1;
        break;
    case 2:
        statement2;
        break;
    case 3:
    case 4:
        statement3;
        break;
    default:
        statementDefault;
        break;
}
```

---

## Schleifen

### Fussgesteuerte Schleifen

 - `do { statements; } while (condition);`

### Kopfgesteuerte Schleifen

- `while (condition) {statements; }` 

### Zählergesteuerte Schleifen

- `for (initialisation; boolean Condition; update variable) { statements; }`
    ```JavaScript
    for (var start = 0; start <= 10; start = start + 2){ document.write(start + "<br/>");}
    ```

### Schleife vorzeitig beenden

- `break`

---

## Arrays

- Sammlungen Index 0 basierend
- Zugriff erfolgt über Index --> []

### Mutator-Methods
- push(), pop()
- shift(), unshift()
- reverse()
- sort(sortFunction)
- splice(index,deleteCount,item1, item2, item...)

### Non-Mutator-Methods
- indexOf()
- lastIndexOf()
- filter()

### Mehrdimensionale Arrays

- Syntax wie jacked Arrays in C#
- ArrayBezeichner[index1][index2]