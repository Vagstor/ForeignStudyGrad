function proverka() {
    
    for (var i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" w3-red", "");
        tablinks[i].className = tablinks[i].className.replace(" w3-green", "");
    }
    if (!clickSelect()) {

        document.getElementById("select").className += " w3-red";
    } else document.getElementById("select").className += " w3-green";
    if (!clickProvColorWord()) {
        document.getElementById("color").className += " w3-red";
    } else document.getElementById("color").className += " w3-green";
    if (!clickProvPrilSuch()) {
        document.getElementById("srav").className += " w3-red";
    } else document.getElementById("srav").className += " w3-green";

    sininomPred = document.getElementsByClassName("sininomPred");

    if (!provMasClass(sininomPred)) {
        document.getElementById("prov0").className += " w3-red";
    } else document.getElementById("prov0").className += " w3-green";
    question = document.getElementsByClassName("question");

    if (!provMasClass(question)) {
        document.getElementById("prov1").className += " w3-red";
    } else document.getElementById("prov1").className += " w3-green";
    nameText = document.getElementsByClassName("nameText");

    if (!provMasClass(nameText)) {
        document.getElementById("prov2").className += " w3-red";
    } else document.getElementById("prov2").className += " w3-green";
    textNew = document.getElementsByClassName("textNew");

    if (!provMasClass(textNew)) {
        document.getElementById("prov3").className += " w3-red";
    } else document.getElementById("prov3").className += " w3-green";
    console.log(clickSelect() + ' ' + clickProvColorWord() + ' ' + clickProvPrilSuch() + ' ' + provMasClass(sininomPred));
}

function provMasClass(array) {
    var flag = true;
    for (var i = 0; i < array.length; i++) {
        console.log(array[i].value);
        if (array[i].value == "") flag = false;
    }
    return flag;
}
