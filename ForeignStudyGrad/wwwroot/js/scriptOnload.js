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
var numTextZad;
var textStr = "";
var tablinks =[];
var textMas = [];
var MasPrilColom;
var MasPrilRow;
var masPril = [[], []];
var masFunc = [];
var kolProv;
var kolProvPril;
var textMasOld;
var kolProvSelect;
var masProvSelect=[];

window.onload = function () {
	console.log("Загрузился");
	tablinks = document.getElementsByClassName("tablink");
	//подача номера теста для подачи входных данных
	var numberTest = document.getElementById("Theme").textContent;
	console.log(numberTest);
	vhod(numberTest);
	for (var i = 0; i < numTextZad; i++) {
		var s1 = "textText" + i;
		if (i != 0) textStr = "<p class=\"text_zadanie\">Прочитайте текст и выполните задание.</p>";
		vhodText(textMas);
		document.getElementById(s1).innerHTML = textStr;
		textStr = "";
		console.log(i);
	}
	if (textMasOld != undefined) {
		var s1 = "textTextOld";
		vhodText(textMasOld);
		document.getElementById(s1).innerHTML = textStr;
		textStr = "";
	}
	
	//объявление элементов для scriptColor.js
	lenght = koren.length;
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
	
	console.log("Задание с прилагательными объявлено");
	//объявление элементов для scriptSelect.js
	kolProvSelect = masProvSelect.length;
	this.console.log(kolProvSelect);
	for (var i = 0; i < kolProvSelect; i++) {
		var s1 = "select" + i;
		var str = this.document.getElementsByClassName(s1);
		this.console.log(str.length);
		for (var j = 0; j < str.length; j++) {
			var nach = 0;
			var konec = 0;
			var s = "";
			var pos = -1;
			while ((pos = str[j].textContent.indexOf('|', pos + 1)) != -1) {
				konec = pos;

				s += str[j].textContent.substring(nach, konec) + selIndex(i, masProvSelect[i]);
				nach = konec + 1;
			}
			s += str[j].textContent.substring(nach);

			str[j].innerHTML = s;

		}
	}
	console.log("Задание с селектами объявлено");
}
function colorWhite(i) {
	this.wordcolor[0][i].style.backgroundColor = 'white';
}

function vhodText(textMas) {
	var pClass = "<p class = \"text_test\">";
	var p = "</p>";
	textMas.forEach(function (text) {
		textStr += pClass + text + p;
	});
}