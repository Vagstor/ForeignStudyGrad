var kolProvSelect;
var kolProvPril;
var kolProv;
var i = 0;

var test1 = function(){
	var masProvSelect = masProvPril = [["Да"]];
	var wordProv = ["Да"];
	var wordsProv = ["Да"];
	if ((!clickSelect(wordProv, masProvSelect[i]) == false)
		&&(!clickProvPrilSuch(wordProv, masProvPril[i]) == false)
	&&(!provMasClass(wordsProv) == false)) console.log("Test1 true"); else console.log("Test1 false");

}
var test2 = function(){
	var masProvSelect = masProvPril = [["Да"]];
	var wordProv = ["Да"];
	var wordsProv = [""];
	if ((!clickSelect(wordProv, masProvSelect[i]) == false)
		&&(!clickProvPrilSuch(wordProv, masProvPril[i]) == false)
	&&(!provMasClass(wordsProv) == true)) console.log("Test2 true"); else console.log("Test2 false");
}
var test3 = function(){
	var masProvSelect = masProvPril = [["Да"]];
	var wordProv = ["Нет"];
	var wordsProv = [""];
	if ((!clickSelect(wordProv, masProvSelect[i]) == true)
		&&(!clickProvPrilSuch(wordProv, masProvPril[i]) == true)
	&&(!provMasClass(wordsProv) == true)) console.log("Test3 true"); else console.log("Test3 false");
}










function clickSelect(array, masRez){
	var selekt = true;
	for (var i = 0; i < array.length; i++) {
		if (array[i] != masRez[i]) {
			selekt = false;
		}
	}
	return selekt;
}

function clickProvPrilSuch(array, masRez){
	var selekt = true;
	for (var i = 0; i < array.length; i++) {
		if (array[i] != masRez[i]) {
			selekt = false;
		}
	}
	return selekt;
}
	
function provMasClass(array) {
    var flag = true;
    for (var i = 0; i < array.length; i++) {
        if (array[i] == "") flag = false;
    }
    return flag;
}