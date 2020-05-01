var wordPrilSuch = [[], []];
var lengthPrilSuch;
var rez = [];
window.onload = function () {
	var numberTest = 1;
	vhodWordPrilSuch(numberTest);
}

//входные данные
function vhodWordPrilSuch(numberTest) {
	switch (numberTest) {
		case 1:
			this.lengthPrilSuch = 10;
			this.rez = ["научная", "техническая", "политическая", "экономическая", "военная", "математические", "вычислительных", "", "электронно", ""];
			break;
		case 2:

			break;
		case 3:

			break;
	};
}

function clickProvPrilSuch() {
	var selekt = true;
	for (var i = 0; i < lengthPrilSuch; i++) {
		var s = "such" + i;

		wordPrilSuch[0][i] = document.getElementById(s);
		wordPrilSuch[1][i] = wordPrilSuch[0][i].value;
		if (wordPrilSuch[1][i][wordPrilSuch[1][i].length - 1] == ' ') wordPrilSuch[1][i] = wordPrilSuch[1][i].substring(0, wordPrilSuch[1][i].length - 1);
		wordPrilSuch[1][i] = wordPrilSuch[1][i].toLowerCase();
	}

	for (var i = 0; i < lengthPrilSuch; i++) {

		if (wordPrilSuch[1][i] != rez[i]) {
			wordPrilSuch[0][i].value = "";
			selekt = false;
		}
	}
	if (selekt) alert("Good"); else alert("Bad");
}


//почистка полей для нового выполнения

function clickProvPrilSuchMew() {

	for (var i = 0; i < lengthPrilSuch; i++) {
			wordPrilSuch[0][i].value = "";
	}
}

