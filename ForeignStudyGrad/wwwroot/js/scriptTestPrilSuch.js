


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

		if (wordPrilSuch[1][i] != rezPril[i]) {
			wordPrilSuch[0][i].value = "";
			selekt = false;
		}
	}
	return selekt;
}


//почистка полей для нового выполнения

function clickProvPrilSuchMew() {

	for (var i = 0; i < lengthPrilSuch; i++) {
		wordPrilSuch[0][i].value = "";
	}
	Console.log("Отчситка полей для задачи с прилагательными выполнена");
}

