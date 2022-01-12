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

document.getElementById('excludeCheckButton').addEventListener("click", addExcludedCheck);
function addExcludedCheck()
{
	var checkList = document.getElementById('checksToBeExcludedListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('excludedChecksListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
}

document.getElementById('unexcludeCheckButton').addEventListener("click", removeExcludedCheck);
function removeExcludedCheck()
{
	var checkList = document.getElementById('excludedChecksListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('checksToBeExcludedListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
}

document.getElementById('addToInventoryButton').addEventListener("click", addItemToInventory);
function addItemToInventory()
{
	var checkList = document.getElementById('listOfImportantItemsListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('startingItemsListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
}

document.getElementById('removeFromInventoryButton').addEventListener("click", removeFromInventory);
function removeFromInventory()
{
	var checkList = document.getElementById('startingItemsListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('listOfImportantItemsListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
}

document.getElementById('generateSeedButton').addEventListener("click", setSettingsString);
function setSettingsString()
    {
		var settingsStringRaw = [];
        settingsStringRaw[0] = document.getElementById('logicRulesFieldset')[document.getElementById('logicRulesFieldset').selectedIndex].value;
        settingsStringRaw[1] = document.getElementById('castleRequirementsFieldset')[document.getElementById('castleRequirementsFieldset').selectedIndex].value;
        settingsStringRaw[2] = document.getElementById('palaceRequirementsFieldset')[document.getElementById('palaceRequirementsFieldset').selectedIndex].value;
        settingsStringRaw[3] = document.getElementById('faronLogicFieldset')[document.getElementById('faronLogicFieldset').selectedIndex].value;
        settingsStringRaw[4] = document.getElementById('mdhCheckbox').checked;
        settingsStringRaw[5] = document.getElementById('introCheckbox').checked;
        settingsStringRaw[6] = document.getElementById('smallKeyOptions')[document.getElementById('smallKeyOptions').selectedIndex].value;
		settingsStringRaw[7] = document.getElementById('bigKeyOptions')[document.getElementById('bigKeyOptions').selectedIndex].value;
        settingsStringRaw[8] = document.getElementById('mapAndCompassOptions')[document.getElementById('mapAndCompassOptions').selectedIndex].value;
        settingsStringRaw[9] = document.getElementById('goldenBugsCheckbox').checked;
        settingsStringRaw[10] = document.getElementById('poesCheckbox').checked;
        settingsStringRaw[11] = document.getElementById('giftsFromNPCsCheckbox').checked;
        settingsStringRaw[12] = document.getElementById('shopItemsCheckbox').checked;
        settingsStringRaw[13] = document.getElementById('faronTwilightCheckbox').checked;
        settingsStringRaw[14] = document.getElementById('eldinTwilightCheckbox').checked;
        settingsStringRaw[15] = document.getElementById('lanayruTwilightCheckbox').checked;
        settingsStringRaw[16] = document.getElementById('skipMinorCutscenesCheckbox').checked;
        settingsStringRaw[17] = document.getElementById('msPuzzleCheckbox').checked;
        settingsStringRaw[18] = document.getElementById('fastIBCheckbox').checked;
        settingsStringRaw[19] = document.getElementById('quickTransformCheckbox').checked;
        settingsStringRaw[20] = document.getElementById('transformAnywhereCheckbox').checked;
        settingsStringRaw[21] = document.getElementById('foolishItemOptions')[document.getElementById('foolishItemOptions').selectedIndex].value;
		var i,options = null;
		for (i = 0; i < document.getElementById('startingItemsListbox').length; i++)
		{
			if (options == null)
			{
				options = document.getElementById('startingItemsListbox').options[i].value;
			}	
			else
			{
				options = options + "," + document.getElementById('startingItemsListbox').options[i].value;
			}
			
		}
		settingsStringRaw[22] = options;
		options = null;
		for (i = 0; i < document.getElementById('excludedChecksListbox').length; i++)
		{
			if (options == null)
			{
				options = document.getElementById('excludedChecksListbox').options[i].value;
			}
			else
			{
				options = options + "," + document.getElementById('excludedChecksListbox').options[i].value;
			}
		}
		settingsStringRaw[23] = options;
        settingsStringRaw[24] = document.getElementById('tunicColorFieldset')[document.getElementById('tunicColorFieldset').selectedIndex].value;
        settingsStringRaw[25] = document.getElementById('midnaHairColorFieldset')[document.getElementById('midnaHairColorFieldset').selectedIndex].value;
        settingsStringRaw[26] = document.getElementById('lanternColorFieldset')[document.getElementById('lanternColorFieldset').selectedIndex].value;
        settingsStringRaw[27] = document.getElementById('heartColorFieldset')[document.getElementById('heartColorFieldset').selectedIndex].value;
        settingsStringRaw[28] = document.getElementById('aButtonColorFieldset')[document.getElementById('aButtonColorFieldset').selectedIndex].value;
        settingsStringRaw[29] = document.getElementById('bButtonColorFieldset')[document.getElementById('bButtonColorFieldset').selectedIndex].value;
        settingsStringRaw[30] = document.getElementById('xButtonColorFieldset')[document.getElementById('xButtonColorFieldset').selectedIndex].value;
        settingsStringRaw[31] = document.getElementById('yButtonColorFieldset')[document.getElementById('yButtonColorFieldset').selectedIndex].value;
        settingsStringRaw[32] = document.getElementById('zButtonColorFieldset')[document.getElementById('zButtonColorFieldset').selectedIndex].value;
        settingsStringRaw[33] = document.getElementById('randomizeBGMCheckbox').checked;
        settingsStringRaw[34] = document.getElementById('randomizeFanfaresCheckbox').checked;
        settingsStringRaw[35] = document.getElementById('disableEnemyBGMCheckbox').checked;
        settingsStringRaw[36] = document.getElementById('gameRegionFieldset')[document.getElementById('gameRegionFieldset').selectedIndex].value;
        settingsStringRaw[37] = document.getElementById('hiddenSkillsCheckbox').checked;
        settingsStringRaw[38] = document.getElementById('skyCharacterCheckbox').checked;
        settingsStringRaw[39] = document.getElementById('seedNumberFieldset')[document.getElementById('seedNumberFieldset').selectedIndex].value;
		alert(settingsStringRaw);
    }







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