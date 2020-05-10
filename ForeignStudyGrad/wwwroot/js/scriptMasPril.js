function provMasPril() {
    var array = document.getElementsByClassName("masPril");
    var flag = false;
    var selekt = true;
    for (var i = 0; i < MasPrilRow; i++) {
        for (var j = 0; j < MasPrilColom; j++) {
            if (array[i].value == masPril[i][j]) flag = true;
        }
        if (!flag) {
            array[i].value = "";
            selekt = false;
        }
        flag = false;
    }
    return selekt;
}

