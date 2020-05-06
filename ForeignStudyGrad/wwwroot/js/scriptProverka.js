function proverka() {
    console.log(clickSelect() + ' ' + clickProvColorWord() + ' ' + clickProvPrilSuch());
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
}