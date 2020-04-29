window.onload = init;
function init() {
    var words = document.getElementById("word");
    for (var i = 0; i < words.length; i++) {
        words[i].onclick = colorWords(words[i]);
    }
}
var flag = 0;
function colorWords(word) {
    if (flag == 0) {
        document.all.word.style.background = 'red';
        flag = 1;
    }
    else {
        document.all.word.style.background = 'white';
        flag = 0;
    }
}