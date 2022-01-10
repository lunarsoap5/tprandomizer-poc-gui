// Dropdown menus
var headers = document.querySelectorAll('.dropdown-container header');
for(var i = 0; i < headers.length; i++) {
	headers[i].addEventListener('click', openCurrAccordion);
}
function openCurrAccordion(e) {
	for(var i = 0; i < headers.length; i++) {
		var parent = headers[i].parentElement;
		var article = headers[i].nextElementSibling;

		if (this === headers[i] && !parent.classList.contains('open')) {
			parent.classList.add('open');
			article.style.maxHeight = article.scrollHeight + 'px';
		}
		else {
			parent.classList.remove('open');
			article.style.maxHeight = '0px';
		}
	}
}

// Dolphin Version toggle
function DolVer(ver) {

	var low5 = document.getElementsByClassName('low5');
	var high5 = document.getElementsByClassName('high5');
	var spanLow5 = document.getElementsByClassName('spanLow5');
	var spanHigh5 = document.getElementsByClassName('spanHigh5');

	if (ver === 'high5') {
		for (i = 0; i < low5.length; i++) {
			low5[i].style.display = 'none';
			high5[i].style.display = 'block';
		}
		for (i = 0; i < spanLow5.length; i++) {
			spanLow5[i].style.display = 'none';
			spanHigh5[i].style.display = 'inline';
		}
	}
	else if (ver === 'low5') {
		for (i = 0; i < high5.length; i++) {
			low5[i].style.display = 'block';
			high5[i].style.display = 'none';
		}
		for (i = 0; i < spanHigh5.length; i++) {
			spanLow5[i].style.display = 'inline';
			spanHigh5[i].style.display = 'none';
		}
	}
}

// Game Version toggle
function GameVer(ver) {
	var usa = document.getElementsByClassName('usa');
	var eur = document.getElementsByClassName('eur');
	var jap = document.getElementsByClassName('jap');

	if (ver === 'usa') {
		for (i = 0; i < usa.length; i++) {
			usa[i].style.display = 'inline';
			eur[i].style.display = 'none';
			jap[i].style.display = 'none';
		}
	}
	else if (ver === 'eur') {
		for (i = 0; i < eur.length; i++) {
			usa[i].style.display = 'none';
			eur[i].style.display = 'inline';
			jap[i].style.display = 'none';
		}
	}
	else if (ver === 'jap') {
		for (i = 0; i < jap.length; i++) {
			usa[i].style.display = 'none';
			eur[i].style.display = 'none';
			jap[i].style.display = 'inline';
		}
	}
}







//Shit Detector
function isIE() {
  ua = navigator.userAgent;
  var is_ie = ua.indexOf("MSIE ") > -1 || ua.indexOf("Trident/") > -1;
  
  return is_ie; 
}
if (isIE()){
	document.getElementById('IsIE').style.display = 'block';
	document.getElementById('IsNotIE').style.display = 'none';
	
}else{
	document.getElementById('IsNotIE').style.display = 'block';
	document.getElementById('IsIE').style.display = 'none';
}