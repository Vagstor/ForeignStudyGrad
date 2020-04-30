var wordcolor = [["word0", "word1", "word2", "word3", "word4", "word5", "word6", "word7", "word8", "word9", "word10", "word11", "word12", "word13", "word14", "word15"],
	["white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white"],
	["rgb(255, 192, 191)", "rgb(196, 255, 244)", "rgb(195, 255, 119)", "rgb(255, 241, 134)", "rgb(239, 203, 255)", "rgb(196, 255, 244)", "rgb(196, 255, 244)", "rgb(195, 255, 119)", "rgb(255, 192, 191)", "rgb(255, 241, 134)", "rgb(239, 203, 255)", "rgb(196, 255, 244)", "rgb(195, 255, 119)", "rgb(255, 192, 191)", "rgb(196, 255, 244)", "rgb(195, 255, 119)"]];
var flag = 0;
var LengthWordCOlor = 16;//количество элементов
var oneWordColor = 5;//первый индекс
var lengthSelect = 6;
jQuery(document).ready(function () {

	
});
window.onload = function () {
	wordcolor[0][0] = document.getElementById('word0');
	wordcolor[0][0].style.backgroundColor = '#ffc0bf';
	wordcolor[0][1] = document.getElementById('word1');
	wordcolor[0][1].style.backgroundColor = '#c4fff4';
	wordcolor[0][2] = document.getElementById('word2');
	wordcolor[0][2] .style.backgroundColor = '#c3ff77';
	wordcolor[0][3] = document.getElementById('word3');
	wordcolor[0][3].style.backgroundColor = '#fff186';
	wordcolor[0][4] = document.getElementById('word4');
	wordcolor[0][4].style.backgroundColor = '#efcbff';
	wordcolor[0][5] = document.getElementById('word5');
	wordcolor[0][6] = document.getElementById('word6');
	wordcolor[0][7]= document.getElementById('word7');
	wordcolor[0][8] = document.getElementById('word8');
	wordcolor[0][9] = document.getElementById('word9');
	wordcolor[0][10] = document.getElementById('word10');
	wordcolor[0][11] = document.getElementById('word11');
	wordcolor[0][12] = document.getElementById('word12');
	wordcolor[0][13] = document.getElementById('word13');
	wordcolor[0][14] = document.getElementById('word14');
	wordcolor[0][15] = document.getElementById('word15');
	for (var i = oneWordColor; i < LengthWordCOlor; i++) {
		wordcolor[0][i].style.backgroundColor = 'white';
	}
	flag = 1;


	for (var j = 0; j < lengthSelect; j++) {
		var s1 = "select" + j;
		var str = document.getElementById(s1).innerHTML;

		var selectStr = "<select size=\"1\"> <option>-</option><option>получать</option><option>собирать</option><option>обрабатывать</option><option>увеличивать</option><option>хранить</option><option>использовать</option></select>";

		var nach = 0;
		var konec = 0;
		var s = "";
		var pos = -1;
		while ((pos = str.indexOf('|', pos + 1)) != -1) {
			konec = pos;

			s += str.substring(nach, konec) + selectStr;
			nach = konec + 1;

		}
		s += str.substring(nach);

		document.getElementById(s1).innerHTML = s;
	}
}
function colorWord() {

	var e = window.event;
	var elem = e.target;
	id1 = elem.id;

	var word = document.getElementById(id1);

	switch (flag) {
		case 1:
			word.style.backgroundColor = '#ffc0bf';
			flag++;
			break;
		case 2:
			word.style.backgroundColor = '#c4fff4';
			flag++;
			break;
		case 3:
			word.style.backgroundColor = '#c3ff77';
			flag++;
			break;
		case 4:
			word.style.backgroundColor = '#fff186';
			flag++;
			break;
		case 5:
			word.style.backgroundColor = '#efcbff';
			flag = 1;
			break;
    }
	for (var i = oneWordColor; i < LengthWordCOlor; i++) {
		if (word == wordcolor[0][i]) wordcolor[1][i] = word.style.backgroundColor;
	}

};

function clickProvColorWord() {
	var selekt = true;
	for (var i = oneWordColor; i < LengthWordCOlor; i++) {
		if (wordcolor[1][i] != wordcolor[2][i]) {
			wordcolor[1][i] = 'white';
			wordcolor[0][i].style.backgroundColor = 'white';
			selekt= false;
		} 
	}
	if (selekt) alert("Good"); else alert("Bad");
}
var wordPrilSuch = [["", "", "", "", "", "", "", "", "", ""], ["", "", "", "", "", "", "", "", "", ""], ["научная", "техническая", "политическая", "экономическая", "военная", "математические", "вычислительных", "", "электронно", ""]];
var lengthPrilSuch = 10;
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

		if (wordPrilSuch[1][i] != wordPrilSuch[2][i]) {
			wordPrilSuch[0][i].value = "";
			selekt = false;
		}
	}
	if (selekt) alert("Good"); else alert("Bad");
}

var wordSelect = [[], [], []]

function clikSelect() {
	var selekt = true;
	if (selekt) alert("Good"); else alert("Bad");
}