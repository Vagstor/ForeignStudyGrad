var numberTest;
var textMas = [];
var masVhodSelect = [];
var dataProvColor = [];
var masProvSelect = [];
var numTextZad;
var kolDetailedAnswer;
var masShortAnswer;
var numberKoren;
var lenght;
var globalFlagOnload = false;
var masDetailedAnswer = [];
var textStr = "";
var textMasOld = [];
var message;
var wordcolor = [[], [], []];
var tablinks = [];

window.onload = function () {
	console.log("Загрузился");
	tablinks = document.getElementsByClassName("tablink");
	//подача номера теста для подачи входных данных
	var numberTest = document.getElementById("Theme").textContent;
	//подача входных данных
	vhod(numberTest);
	//вывод текста
	for (var i = 0; i < numTextZad; i++) {
		var s1 = "textText" + i;
		if (i != 0) textStr = "<p class=\"text_zadanie\">Прочитайте текст и выполните задание.</p>";
		vhodText(textMas);
		document.getElementById(s1).innerHTML = textStr;
		textStr = "";
	}
	//вывод текста, если требуется текст из прошлой темы
	if (textMasOld.length != 0) {
		var s1 = "textTextOld";
		vhodText(textMasOld);
		document.getElementById(s1).innerHTML = textStr;
		textStr = "";
	}
	console.log("Задание с текстовм выведено");
	//передача данных для задания с цветом
	lenght = dataProvColor.length;
	for (var i = 0; i < lenght; i++) {
		var s = "word" + i;
		this.wordcolor[0][i] = document.getElementById(s);
		this.wordcolor[1][i] = dataProvColor[i];
		colorWhite(i);
	}
	console.log("Задание с цветом задано");
	numberKoren = Math.max.apply(null, dataProvColor);
	//вывод задания с селектом на страницу
	kolProvSelect = masVhodSelect.length;
	for (var i = 0; i < kolProvSelect; i++) {
		var s1 = "select" + i;
		var str = this.document.getElementsByClassName(s1);
		for (var j = 0; j < str.length; j++) {
			var nach = 0;
			var konec = 0;
			var s = "";
			var pos = -1;
			while ((pos = str[j].textContent.indexOf('|', pos + 1)) != -1) {
				konec = pos;

				s += str[j].textContent.substring(nach, konec) + selIndex(i, masVhodSelect[i]);
				nach = konec + 1;
			}
			s += str[j].textContent.substring(nach);

			str[j].innerHTML = s;

		}
	}
	this.console.log("Задание с селектом выведено");
	kolDetailedAnswer = masDetailedAnswer.length;
	this.globalFlagOnload = true;
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