//входные данные
function vhodWordColor(numberTest) {
	switch (numberTest) {
		case "Test1Theme":
			this.lenght = 16;
			this.koren = [1, 2, 3, 4, 5, 2, 2, 3, 1, 4, 5, 2, 3, 1, 2, 3];
			break;
		case "Test2Theme":
			this.lenght = 21;
			this.koren = [1,2,3,1,4,5,6,4,7,8,9,2,6,1,3,5,7,2,8,9,8];
			break;
		case 3:
			this.lenght = 4;
			this.koren = [1, 2, 3, 4];
			break;
	};
	console.log("Входные данные для задачи с цветом переданы");
}

//входные данные
function vhodWordPrilSuch(numberTest) {
	switch (numberTest) {
		case "Test1Theme":
			this.lengthPrilSuch = 10;
			this.rezPril = ["научная", "техническая", "политическая", "экономическая", "военная", "математические", "вычислительных", "", "электронно", ""];
			break;
		case "Test2Theme":
			this.lengthPrilSuch = 9;
			this.rezPril = ["6222", "688130", "704643962", "13045637", "125829120", "38654706009", "114301006", "9083813978", "914793674e14"];
			break;
		case 3:

			break;
	};
	console.log("Входные данные для задачи с прилагательными переданы");
}

//входные данные
function vhodWordSelect(numberTest) {
	switch (numberTest) {
		case "Test1Theme":
			this.wordSelectLength = 7;
			this.lengthSelect = 6;
			this.rez = ["получает", "обрабатывает", "использует", "хранит", "увеличивается", "собирают", "обрабатывают"];
			break;
		case "Test2Theme":
			this.wordSelectLength = 6;
			this.lengthSelect = 6;
			this.rez = ["можно измерить", "принимает значения", "кодируется", "содержит", "содержит", "используют"];
			break;
		case 3:

			break;
	};
	console.log("Входные данные для задачи с селектами переданы");
}