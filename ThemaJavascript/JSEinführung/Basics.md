# JavaScript Basics

- JS ist case-sensitiv
- Kommentare
    - single line: `//`
    - multi line: `/* ... */`
- Datentypen
    - Numbers -> 5 oder 5.234
    - Boolean -> true/false
    - String -> "MyString" oder 'MyString'

---

## Konvertierung

- `parseInt()`
- `parseFloat()`
- `isNan()`

---

## Zeichenfoglen in JavaScript

- Concatenating
    - using + operator
    - using `concat()` method
- Literal: einfaches oder doppeltes Anführungszeichen
- `toLowerCase()`
- `toUpperCase()`
- Länge eines Strings:
    - Property: length
- Leerzeichen entfernen: trim()
    - `var a = " AB ";a.trim(); --> "AB"`
- Ersetzungen:
    - `var myString = "Hello JavaScript"; var result = myString.replace("JavaScript","World");console.log(result); --> Output: Hello World`