function proverka() {

    for (var i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-red", "");
        tablinks[i].className = tablinks[i].className.replace(" w3-green", "");
    }

    for (var i = 0; i < kolProvSelect; i++) {
        var s = "sel" + i;
        var ss = "select" + i;
        var wordProv = document.getElementsByClassName(s);
    if (!clickSelect(wordProv, masProvSelect[i])) {

        document.getElementById("select").className += " w3-red";
        } else document.getElementById("select").className += " w3-green";
    }
    if (!clickProvColorWord()) {
        document.getElementById("color").className += " w3-red";
        } else document.getElementById("color").className += " w3-green";
    
    //проверка всех заданий с сравнением слов
    for (var i = 0; i < kolProvPril; i++) {
        var s = "srav" + i;
        var ss = "such" + i;
        var wordProv = document.getElementsByClassName(ss);
        if (!clickProvPrilSuch(wordProv, masProvPril[i])) {
            document.getElementById(s).className += " w3-red";
        } else document.getElementById(s).className += " w3-green";
    }

    //проверка заданий с развернутым ответом
    for (var i = 0; i < kolProv; i++) {
        s = "prov" + i;
        ss = "question" + i;
        var wordsProv = document.getElementsByClassName(ss);
        if (!provMasClass(wordsProv)) {
            document.getElementById(s).className += " w3-red";
        } else document.getElementById(s).className += " w3-green";
    }

}


function provColor(func, ev) {
    if (!func) {
        ev.className += " w3-red";
    } else ev.className += " w3-red";
}

function provMasClass(array) {
    var flag = true;
    for (var i = 0; i < array.length; i++) {
        if (array[i].value == "") flag = false;
    }
    return flag;
}