var wordcolor = [["word0", "word1", "word2", "word3", "word4", "word5", "word6", "word7", "word8", "word9", "word10", "word11", "word12", "word13", "word14", "word15"],
	["white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white", "white"],
	["red", "blue", "green", "blue", "yellow", "violet", "blue", "green" ,"red", "yellow", "violet","blue", "green","red", "blue", "green"]];
var flag = 0;
var n = 16;
jQuery(document).ready(function () {

	
});
window.onload = function () {
	wordcolor[0][0] = document.getElementById('word0');
	wordcolor[0][1] = document.getElementById('word1');
	wordcolor[0][2] = document.getElementById('word2');
	wordcolor[0][3] = document.getElementById('word3');
	wordcolor[0][4] = document.getElementById('word4');
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
	for (var i = 0; i < n; i++) {
		wordcolor[0][i].style.backgroundColor = 'white';
	}
	flag = 1;
}
function colorWord() {

	var e = window.event;
	var elem = e.target;
	id1 = elem.id;

	var word = document.getElementById(id1);

	switch (flag) {
		case 1:
			word.style.backgroundColor = 'red';
			flag++;
			break;
		case 2:
			word.style.backgroundColor = 'blue';
			flag++;
			break;
		case 3:
			word.style.backgroundColor = 'green';
			flag++;
			break;
		case 4:
			word.style.backgroundColor = 'yellow';
			flag++;
			break;
		case 5:
			word.style.backgroundColor = 'violet';
			flag = 1;
			break;
    }
	for (var i = 0; i < n; i++) {
		if (word == wordcolor[0][i]) wordcolor[1][i] = word.style.backgroundColor;
	}

};

function clickProv() {
	var selekt = true;
	for (var i = 0; i < n; i++) {
		if (wordcolor[1][i] != wordcolor[2][i]) {
			wordcolor[1][i] = 'white';
			wordcolor[0][i].style.backgroundColor = 'white';
			selekt= false;
		} 
	}
	if (selekt) alert("Good"); else alert("Bad");
}