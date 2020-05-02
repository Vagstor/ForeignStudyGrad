//переменные для задачи с прилогательными
var wordPrilSuch = [[], []];
var lengthPrilSuch;
var rezPril = [];
//переменные для задачи с цветом
var wordcolor = [[], [], []];
var numberKoren;//количество корней в задании
var koren = [];//какое слово принадлежит какому корню
var flag;
var lenght;
//переменные для задачи с селектами
var lengthSelect;//количество предложений с селектами
var rez = [];
var wordSelectLength;//колличество селектов
var wordSelect = [[], []];

window.onload = function () {
	console.log("Загрузился");
	//подача номера теста для подачи входных данных
	var numberTest = 1;
	//объявление элементов для scriptColor.js
	vhodWordColor(numberTest);

	for (var i = 0; i < lenght; i++) {
		var s = "word" + i;
		this.wordcolor[0][i] = document.getElementById(s);
		this.wordcolor[1][i] = this.koren[i];
		colorWhite(i);
	}

	this.numberKoren = Math.max.apply(null, this.koren);
	flag = 1;
	console.log("Задание с цветом объявлено");
	//объявление элементов для scriptTestPrilSuch.js
	vhodWordPrilSuch(numberTest);
	console.log("Задание с прилагательными объявлено");
	//объявление элементов для scriptSelect.js
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
	console.log("Задание с селектами объявлено");
}
function colorWhite(i) {
	this.wordcolor[0][i].style.backgroundColor = 'white';
}