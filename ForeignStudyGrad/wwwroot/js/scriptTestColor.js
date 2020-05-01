//задание с группированием слов
var colorBD = ["white", "rgb(255,255,203)", "rgb(205,205,94)", "rgb(255, 205, 94)", "rgb(180,255,87)", "rgb(255,205,152)", "rgb(0,255,148)", "rgb(255,205,205)", "rgb(67,255,203)", "rgb(222,154,154)", "rgb(126, 205, 205)", "rgb(222,154,207)", "rgb(154,154,207)", "rgb(205,205,255)"];

var wordcolor = [[], [], []];
var numberKoren;//количество корней в задании
var koren = [];//какое слово принадлежит какому корню
var flag;
var lenght;

window.onload = function () {

    var numberTest = 1;
    vhodWordColor(numberTest);


    for (var i = 0; i < lenght; i++) {
        var s = "word" + i;
        this.wordcolor[0][i] = document.getElementById(s);
        this.wordcolor[1][i] = this.koren[i];
        colorWhite(i);
    }



    this.numberKoren = Math.max.apply(null, this.koren);
    flag = 1;

}

//входные данные
function vhodWordColor(numberTest) {
    switch (numberTest) {
        case 1:
            this.lenght = 16;
            this.koren = [1, 2, 3, 4, 5, 2, 2, 3, 1, 4, 5, 2, 3, 1, 2, 3];
            break;
        case 2:
            this.lenght = 21;
            this.koren = [];
            break;
        case 3:
            this.lenght = 4;
            this.koren = [1, 2, 3, 4];
            break;
    };
}

function colorWord() {

    var e = window.event;
    var elem = e.target;
    id1 = elem.id;

    var word = document.getElementById(id1);

    if (flag < numberKoren) {
        word.style.backgroundColor = colorBD[flag];
        flag++;
    } else {
        word.style.backgroundColor = colorBD[flag];
        flag = 1;
    }

    for (var i = 0; i < this.lenght; i++) {
        if (word == this.wordcolor[0][i]) this.wordcolor[2][i] = word.style.backgroundColor;
    }
};

function clickProvColorWord() {
    var selekt = true;
    var color = [];
    var oneColor = true;
    var flagColor = true;
    for (var j = 1; j <= numberKoren; j++) {
        for (var i = 0; i < lenght; i++) {
            if (wordcolor[1][i] == j) {
                if (oneColor) {
                    color[j] = wordcolor[2][i];
                    for (var jj = 1; jj < j; jj++) {
                        if (color[j] == color[jj]) flagColor = false;
                    }
                    if (flagColor) {
                        color[j] = wordcolor[2][i];
                        oneColor = false;
                    }
                    else {
                        wordcolor[0][i].style.backgroundColor = 'white';
                        selekt = false;
                    }
                }
            }
        }
        flagColor = true;
        oneColor = true;
    }
    for (var j = 1; j <= numberKoren; j++) {
        for (var i = 0; i < lenght; i++) {
            if (wordcolor[1][i] == j) {
                if (wordcolor[2][i] != color[j]) {
                    wordcolor[0][i].style.backgroundColor = 'white';
                    selekt = false;
                }
            }
        }
    }

    if (selekt) alert("Good"); else alert("Bad");
}
function colorWhite(i) {
    this.wordcolor[0][i].style.backgroundColor = 'white';
}
function clickProvColorWordNew() {
    for (var i = 0; i < this.lenght; i++) {
        this.wordcolor[1][i] = 'white';
        colorWhite(i);
    }
}