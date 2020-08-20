var liste = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

var neueListe = liste.filter(FilterFunktion);

neueListe = liste.filter(function (element){
    return element % 2 == 0 ? false : true;
});

neueListe = liste.filter((item)=>{
    return item % 3 == 0 ? true : false; 
})

console.log(neueListe);


function FilterFunktion(value) {
    if (value % 2 == 0)
        return true;
    else
        return false;
}