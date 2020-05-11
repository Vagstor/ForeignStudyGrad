
function selIndex(ii,masRez) {
	var selectStr = "<select size=\"1\" class=\"sel" + ii + "\"> <option>-</option>";
	for (var i = 0; i < masRez.length; i++) {
		selectStr += "<option>" + masRez[i] + "</option>";
	}
	selectStr += "</select>";
	return selectStr;
}




function clickSelect(array, masRez) {
	var selekt = true;
	console.log(array.length);
	for (var i = 0; i < array.length; i++) {
		if (array[i].options[array[i].selectedIndex].value != masRez[i]) {
			array[i].value = "-";
			selekt = false;
		}
	}
	return selekt;
}

function clickSelectNew() {
	for (var i = 0; i < wordSelectLength; i++) {
		wordSelect[0][i].value = "-";
	}
	Console.log("Отчситка полей для задачи с селектами выполнена");
}
