var lengthSelect;//количество предложений с селектами
var rez = [];
var wordSelectLength;//колличество селектов
var wordSelect = [[], []];
function selIndex(ii) {
	var selectStr = "<select size=\"1\" id=\"sel" + ii + "\"> <option>-</option>";
	for (var i = 0; i < wordSelectLength; i++) {
		selectStr += "<option>" + rez[i] + "</option>";
	}
	selectStr += "</select>";
	return selectStr;
}

window.onload = function () {
	var numberTest = 1;
	vhodWordSelect(numberTest);
	var ii = 0;
	for (var j = 0; j < lengthSelect; j++) {
		var s1 = "select" + j;
		var str = document.getElementById(s1).innerHTML;
		var nach = 0;
		var konec = 0;
		var s = "";
		var pos = -1;
		while ((pos = str.indexOf('|', pos + 1)) != -1) {
			konec = pos;

			s += str.substring(nach, konec) + selIndex(ii);
			nach = konec + 1;
			ii++;
		}
		s += str.substring(nach);

		document.getElementById(s1).innerHTML = s;
	}
}

//входные данные
function vhodWordSelect(numberTest) {
	switch (numberTest) {
		case 1:
			this.wordSelectLength = 7;
			this.lengthSelect = 7;
			this.rez = ["получает", "обрабатывает", "использует", "хранит", "увеличивается", "собирают", "обрабатывают"];
			break;
		case 2:

			break;
		case 3:

			break;
	};
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
	if (selekt) alert("Good"); else alert("Bad");
}

function clickSelectNew() {
	for (var i = 0; i < wordSelectLength; i++) {
		wordSelect[0][i].value = "-";
	}
}
