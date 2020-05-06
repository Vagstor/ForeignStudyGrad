
function selIndex(ii) {
	var selectStr = "<select size=\"1\" id=\"sel" + ii + "\"> <option>-</option>";
	for (var i = 0; i < wordSelectLength; i++) {
		selectStr += "<option>" + rez[i] + "</option>";
	}
	selectStr += "</select>";
	return selectStr;
}




function clickSelect() {
	var selekt = true;
	for (var i = 0; i < wordSelectLength; i++) {
		var s = "sel" + i;
		wordSelect[0][i] = document.getElementById(s);
		wordSelect[1][i] = wordSelect[0][i].options[wordSelect[0][i].selectedIndex].value;
		if (wordSelect[1][i] != rez[i]) {
			wordSelect[0][i].value = "-";
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
