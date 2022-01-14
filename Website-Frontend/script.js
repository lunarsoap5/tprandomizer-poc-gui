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
		for (var i = 0; i < low5.length; i++) {
			low5[i].style.display = 'none';
			high5[i].style.display = 'block';
		}
		for (var i = 0; i < spanLow5.length; i++) {
			spanLow5[i].style.display = 'none';
			spanHigh5[i].style.display = 'inline';
		}
	}
	else if (ver === 'low5') {
		for (var i = 0; i < high5.length; i++) {
			low5[i].style.display = 'block';
			high5[i].style.display = 'none';
		}
		for (var i = 0; i < spanHigh5.length; i++) {
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
		for (var i = 0; i < usa.length; i++) {
			usa[i].style.display = 'inline';
			eur[i].style.display = 'none';
			jap[i].style.display = 'none';
		}
	}
	else if (ver === 'eur') {
		for (var i = 0; i < eur.length; i++) {
			usa[i].style.display = 'none';
			eur[i].style.display = 'inline';
			jap[i].style.display = 'none';
		}
	}
	else if (ver === 'jap') {
		for (var i = 0; i < jap.length; i++) {
			usa[i].style.display = 'none';
			eur[i].style.display = 'none';
			jap[i].style.display = 'inline';
		}
	}
}

document.getElementById('excludeCheckButton').addEventListener("click", addExcludedCheck);
function addExcludedCheck()
{
	var checkList = document.getElementById('baseExcludedChecksListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('addedExcludedChecksListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
	setSettingsString();
}

document.getElementById('unexcludeCheckButton').addEventListener("click", removeExcludedCheck);
function removeExcludedCheck()
{
	var checkList = document.getElementById('addedExcludedChecksListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('baseExcludedChecksListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
	setSettingsString();
}

document.getElementById('addToInventoryButton').addEventListener("click", addItemToInventory);
function addItemToInventory()
{
	var checkList = document.getElementById('baseImportantItemsListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('addedImportantItemsListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
	setSettingsString();
}

document.getElementById('removeFromInventoryButton').addEventListener("click", removeFromInventory);
function removeFromInventory()
{
	var checkList = document.getElementById('addedImportantItemsListbox');
	var strUser = checkList[checkList.selectedIndex].value;
	let newExcludedCheck = new Option(checkList[checkList.selectedIndex].text, strUser);
	document.getElementById('baseImportantItemsListbox').add(newExcludedCheck, undefined);
	checkList.remove(checkList.selectedIndex);
	setSettingsString();
}

var settingsLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ23456789";
document.getElementById('generateSeedButton').addEventListener("click", setSettingsString);
document.getElementById('logicRulesFieldset').onchange = setSettingsString;
document.getElementById('gameRegionFieldset').onchange = setSettingsString;
document.getElementById('seedNumberFieldset').onchange = setSettingsString;
document.getElementById('castleRequirementsFieldset').onchange = setSettingsString;
document.getElementById('palaceRequirementsFieldset').onchange = setSettingsString;
document.getElementById('faronLogicFieldset').onchange = setSettingsString;
document.getElementById('mdhCheckbox').addEventListener("click", setSettingsString);
document.getElementById('introCheckbox').addEventListener("click", setSettingsString);
document.getElementById('smallKeyFieldset').onchange = setSettingsString;
document.getElementById('bigKeyFieldset').onchange = setSettingsString;
document.getElementById('mapAndCompassFieldset').onchange = setSettingsString;
document.getElementById('goldenBugsCheckbox').addEventListener("click", setSettingsString);
document.getElementById('skyCharacterCheckbox').addEventListener("click", setSettingsString);
document.getElementById('giftsFromNPCsCheckbox').addEventListener("click", setSettingsString);
document.getElementById('poesCheckbox').addEventListener("click", setSettingsString);
document.getElementById('shopItemsCheckbox').addEventListener("click", setSettingsString);
document.getElementById('hiddenSkillsCheckbox').addEventListener("click", setSettingsString);
document.getElementById('foolishItemFieldset').onchange = setSettingsString;
document.getElementById('faronTwilightCheckbox').addEventListener("click", setSettingsString);
document.getElementById('eldinTwilightCheckbox').addEventListener("click", setSettingsString);
document.getElementById('lanayruTwilightCheckbox').addEventListener("click", setSettingsString);
document.getElementById('skipMinorCutscenesCheckbox').addEventListener("click", setSettingsString);
document.getElementById('msPuzzleCheckbox').addEventListener("click", setSettingsString);
document.getElementById('fastIBCheckbox').addEventListener("click", setSettingsString);
document.getElementById('quickTransformCheckbox').addEventListener("click", setSettingsString);
document.getElementById('transformAnywhereCheckbox').addEventListener("click", setSettingsString);
document.getElementById('randomizeBGMCheckbox').addEventListener("click", setSettingsString);
document.getElementById('randomizeFanfaresCheckbox').addEventListener("click", setSettingsString);
document.getElementById('disableEnemyBGMCheckbox').addEventListener("click", setSettingsString);
document.getElementById('tunicColorFieldset').onchange = setSettingsString;
document.getElementById('lanternColorFieldset').onchange = setSettingsString;
document.getElementById('midnaHairColorFieldset').onchange = setSettingsString;
document.getElementById('heartColorFieldset').onchange = setSettingsString;
document.getElementById('aButtonColorFieldset').onchange = setSettingsString;
document.getElementById('bButtonColorFieldset').onchange = setSettingsString;
document.getElementById('xButtonColorFieldset').onchange = setSettingsString;
document.getElementById('yButtonColorFieldset').onchange = setSettingsString;
document.getElementById('zButtonColorFieldset').onchange = setSettingsString;
document.getElementById('importSettingsStringButton').addEventListener("click", importSettingsString);

function importSettingsString()
{
	parseSettingsString(document.getElementById('settingsStringTextbox').value);
}

function setSettingsString()
    {
		var settingsStringRaw = [];
        settingsStringRaw[0] = document.getElementById('logicRulesFieldset').selectedIndex;
        settingsStringRaw[1] = document.getElementById('castleRequirementsFieldset').selectedIndex;
        settingsStringRaw[2] = document.getElementById('palaceRequirementsFieldset').selectedIndex;
        settingsStringRaw[3] = document.getElementById('faronLogicFieldset').selectedIndex;
        settingsStringRaw[4] = document.getElementById('mdhCheckbox').checked;
        settingsStringRaw[5] = document.getElementById('introCheckbox').checked;
        settingsStringRaw[6] = document.getElementById('smallKeyFieldset').selectedIndex
		settingsStringRaw[7] = document.getElementById('bigKeyFieldset').selectedIndex
        settingsStringRaw[8] = document.getElementById('mapAndCompassFieldset').selectedIndex;
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
        settingsStringRaw[21] = document.getElementById('foolishItemFieldset').selectedIndex;
		var i = null;
		var options = [];
		for (var i = 0; i < document.getElementById('addedImportantItemsListbox').length; i++)
		{
			options.push(document.getElementById('addedImportantItemsListbox').options[i].value);
		}
		settingsStringRaw[22] = options;
		options = [];
		for (var i = 0; i < document.getElementById('addedExcludedChecksListbox').length; i++)
		{
			options.push(document.getElementById('addedExcludedChecksListbox').options[i].value);
		}
		settingsStringRaw[23] = options;
        settingsStringRaw[24] = document.getElementById('tunicColorFieldset').selectedIndex;
        settingsStringRaw[25] = document.getElementById('midnaHairColorFieldset').selectedIndex;
        settingsStringRaw[26] = document.getElementById('lanternColorFieldset').selectedIndex;
        settingsStringRaw[27] = document.getElementById('heartColorFieldset').selectedIndex;
        settingsStringRaw[28] = document.getElementById('aButtonColorFieldset').selectedIndex;
        settingsStringRaw[29] = document.getElementById('bButtonColorFieldset').selectedIndex;
        settingsStringRaw[30] = document.getElementById('xButtonColorFieldset').selectedIndex;
        settingsStringRaw[31] = document.getElementById('yButtonColorFieldset').selectedIndex;
        settingsStringRaw[32] = document.getElementById('zButtonColorFieldset').selectedIndex;
        settingsStringRaw[33] = document.getElementById('randomizeBGMCheckbox').checked;
        settingsStringRaw[34] = document.getElementById('randomizeFanfaresCheckbox').checked;
        settingsStringRaw[35] = document.getElementById('disableEnemyBGMCheckbox').checked;
        settingsStringRaw[36] = document.getElementById('gameRegionFieldset').selectedIndex;
        settingsStringRaw[37] = document.getElementById('hiddenSkillsCheckbox').checked;
        settingsStringRaw[38] = document.getElementById('skyCharacterCheckbox').checked;
        settingsStringRaw[39] = document.getElementById('seedNumberFieldset').selectedIndex;
		document.getElementById('settingsStringTextbox').value = getSettingsString(settingsStringRaw);
    }



	function getSettingsString(settingsStringRaw)
        {
            var bits = "";
            //Get the properties of the class that contains the settings values so we can iterate through them.
			for (var i =0; i < settingsStringRaw.length; i++)
			{
				var settingValue = settingsStringRaw[i]
                var i_bits = "";
                if (typeof(settingValue) == "boolean") //Settings that only have two options (Shuffle Golden Bugs, etc.)
                {
                    if (settingValue)
                    {
                        i_bits = "1";
                    }
                    else
                    {
                        i_bits = "0";
                    } 
                }
                if (typeof(settingValue) == "number") //Settings that have multiple options (Hyrule Castle Requirements, etc.)
                {
                    //Pad the integer value to 4 bits. No drop down menu uses more than 15 options so this is a safe bet.
                    i_bits = padBits((settingValue >>> 0).toString(2), 4); 
                }
                if (typeof(settingValue) == "object") //Starting Items list
                    {
                         for (var j=0; j< settingValue.length; j++)
                            {
                                //We pad the byte to 8 bits since item IDs don't go over 0xFF
                                i_bits += padBits((settingValue[j] >>> 0).toString(2), 9);
                            }
                        //Place this at the end of the bit string. Will be useful when decoding to know when we've reached the end of the list.
                        i_bits += "111111111"; 
                    }
                bits += i_bits;
            }
            return btoa(bitStringToText(bits));
        }

function padBits(num, size) {
	var s = "000000000" + num;
	return s.substr(s.length-size);
}

function bitStringToText(bits)
{
	var result = "";
	//Pad the string to a value of 5
	while (bits.length % 5 != 0)
	{
		bits += "0";
	}
		
	for (var i = 0; i < bits.length; i+=5)
	{
		var value = "";
		for (var j = 0; j < 5; j++)
		{
			value = value + bits[i +j];
		}
		byteValue = parseInt(value, 2);
		result += index_to_letter(byteValue);
	}
	return result;
}

function textToBitString(text)
{
	byteToBinary = "";
	for(var i=0; i < text.length; i++)
	{
		var index = letter_to_index(text[i]);
		byteToBinary += padBits((index >>> 0).toString(2), 5); 
	}
	while (byteToBinary.length % 5 != 0)
	{
		byteToBinary = byteToBinary.slice(0,byteToBinary.length-1);
	}
	return byteToBinary;
}

function index_to_letter(index) 
{ 
	var c = settingsLetters[index]; 
	return c; 
}
function letter_to_index(letter)
{ 
	for (var i = 0; i < settingsLetters.length; i++)
	{
		if (letter == settingsLetters[i])
		{
			return i;
		}
	}
	return 0; 
}

var arrayOfSettingsItems =
[
	"logicRulesFieldset",
	"castleRequirementsFieldset",
	"palaceRequirementsFieldset",
	"faronLogicFieldset",
	"mdhCheckbox",
	"introCheckbox",
	"smallKeyFieldset",
	"bigKeyFieldset",
	"mapAndCompassFieldset",
	"goldenBugsCheckbox",
	"poesCheckbox",
	"giftsFromNPCsCheckbox",
	"shopItemsCheckbox",
	"faronTwilightCheckbox",
	"eldinTwilightCheckbox",
	"lanayruTwilightCheckbox",
	"skipMinorCutscenesCheckbox",
	"msPuzzleCheckbox",
	"fastIBCheckbox",
	"quickTransformCheckbox",
	"transformAnywhereCheckbox",
	"foolishItemFieldset",
	"addedImportantItemsListbox",
	"addedExcludedChecksListbox",
	"tunicColorFieldset",
	"midnaHairColorFieldset",
	"lanternColorFieldset",
	"heartColorFieldset",
	"aButtonColorFieldset",
	"bButtonColorFieldset",
	"xButtonColorFieldset",
	"yButtonColorFieldset",
	"zButtonColorFieldset",
	"randomizeBGMCheckbox",
	"randomizeFanfaresCheckbox",
	"disableEnemyBGMCheckbox",
	"gameRegionFieldset",
	"hiddenSkillsCheckbox",
	"skyCharacterCheckbox",
	"seedNumberFieldset"
];

function parseSettingsString(settingsString)
{
	settingsString = atob(settingsString);
	//Convert the settings string into a binary string to be interpreted.
	var bitString = textToBitString(settingsString);
	for(var i =0; i < arrayOfSettingsItems.length; i++)
	{
		var currentSettingsItem = arrayOfSettingsItems[i];
		var evaluatedByteString = "";
		var settingBitWidth = 0;
		var reachedEndofList = false;
		if (currentSettingsItem.includes("Checkbox"))
		{
			var value = parseInt(bitString[0],2);
			if (value == 1)
			{
				document.getElementById(currentSettingsItem).checked = true;
			} 
			else
			{
				document.getElementById(currentSettingsItem).checked = false;
			}
			bitString = bitString.substring(1);
		}
		if (currentSettingsItem.includes("Fieldset"))
		{
			settingBitWidth = 4;
			//We want to get the binary values in the string in 4 bit pieces since that is what is was encrypted with.
			for (var j = 0; j < settingBitWidth; j++)
			{
				evaluatedByteString += bitString[0];
				bitString = bitString.substring(1);
			}
			document.getElementById(currentSettingsItem).selectedIndex = parseInt(bitString,2);
		}
		if (currentSettingsItem.includes("Listbox"))
		{
			//We want to get the binary values in the string in 8 bit pieces since that is what is was encrypted with.
			settingBitWidth = 9;
			while (!reachedEndofList)
			{
				for (var j = 0; j < settingBitWidth; j++)
				{
					evaluatedByteString += bitString[0];
					bitString = bitString.substring(1);
				}
				itemIndex = parseInt(evaluatedByteString, 2);
				if (itemIndex != 511) //Checks for the padding that was put in place upon encryption to know it has reached the end of the list.
				{
					var checkList = document.getElementById(currentSettingsItem.replace("added", "base"));
					for(var j=0; j < checkList.options.length; j++)
					{
						if (itemIndex == checkList.options[j].value)
						{
							var checkListOptionValue = checkList.options[j].value;
							let itemOption = new Option(checkList.options[j].text, checkListOptionValue);
							document.getElementById(currentSettingsItem).add(itemOption, undefined);
						}
					}
				}
				else
				{
					reachedEndofList = true;
				}
				evaluatedByteString = "";
			}
		}
	}
	return;
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