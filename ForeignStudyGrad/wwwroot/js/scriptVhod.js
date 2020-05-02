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
	console.log("Входные данные для задачи с цветом переданы");
}

//входные данные
function vhodWordPrilSuch(numberTest) {
	switch (numberTest) {
		case 1:
			this.lengthPrilSuch = 10;
			this.rezPril = ["научная", "техническая", "политическая", "экономическая", "военная", "математические", "вычислительных", "", "электронно", ""];
			break;
		case 2:

			break;
		case 3:

			break;
	};
	console.log("Входные данные для задачи с прилагательными переданы");
}

//входные данные
function vhodWordSelect(numberTest) {
	switch (numberTest) {
		case 1:
			this.wordSelectLength = 7;
			this.lengthSelect = 6;
			this.rez = ["получает", "обрабатывает", "использует", "хранит", "увеличивается", "собирают", "обрабатывают"];
			break;
		case 2:

			break;
		case 3:

			break;
	};
	console.log("Входные данные для задачи с селектами переданы");
}