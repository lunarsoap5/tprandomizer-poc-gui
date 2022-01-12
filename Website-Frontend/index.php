<?php //File fetcher
	function get_dir($d, $c){
		$dir = $d."/*".$c.".*"; // Example: download/gci/filename.us.gci or rel/filname.GZ2E01.gct
		$f = glob($dir);
		$f = array_combine($f, array_map('filectime', $f));
		arsort($f);
		echo key($f);
	};

?>
<!DOCTYPE html>
<html>
	<head>
		<link rel="icon" target="_blank" href="favicon.png">
		<title>TP Randomizer</title>
		<meta property="og:title" content="Twilight Princess Randomizer" />
		<meta property="og:url" content="https://rando.tpspeed.run/" />
		<meta property="og:image" content="https://rando.tpspeed.run/img/logo.png" />
		<meta property="og:description" content="The official Twilight Princess Randomizer website! From download to setup and even tools!" />
		<link rel="stylesheet" target="_blank" href="css/style.css">
	</head>
	<body>
		<script>
			function tabControl(evt, cityName) {
				// Declare all variables
				var i, tabcontent, tablinks;

				// Get all elements with class="tabcontent" and hide them
				tabcontent = document.getElementsByClassName("tabcontent");
				for (i = 0; i < tabcontent.length; i++) {
					tabcontent[i].style.display = "none";
				}

				// Get all elements with class="tablinks" and remove the class "active"
				tablinks = document.getElementsByClassName("tablinks");
				for (i = 0; i < tablinks.length; i++) {
					tablinks[i].className = tablinks[i].className.replace(" active", "");
				}

				// Show the current tab, and add an "active" class to the button that opened the tab
				document.getElementById(cityName).style.display = "block";
				evt.currentTarget.className += " active";
				}
		</script>
		<img src="img/logo.png"/>
		<div id="IsIE">
			<b>Your web browser is obsolete.</b>
			<br />
			Update your browser for more security, and in order to see this website.
			<br />
			There are plenty of other browsers far more secure and modern, for example 
			<a target="_blank" href="https://www.google.com/chrome/" style="color: red;">Chrome</a>
			 or 
			<a target="_blank" href="https://www.mozilla.org/en-US/firefox/new/" style="color: red;">Firefox.</a>
		</div>
		<div id="IsNotIE">
			<div class="blackbg">
				<div class="tab">
					<button class="tablinks" onclick="tabControl(event, 'randomizationSettingsTab')">Randomization Settings</button>
					<button class="tablinks" onclick="tabControl(event, 'gameplaySettingsTab')">Gameplay Settings</button>
					<button class="tablinks" onclick="tabControl(event, 'excludedChecksTab')">Excluded Checks</button>
					<button class="tablinks" onclick="tabControl(event, 'startingInventoryTab')">Starting Inventory</button>
					<button class="tablinks" onclick="tabControl(event, 'cosmeticsAndQuirksTab')">Cosmetics and Quirks</button>
				</div>
				  
				  <!-- Tab content -->
				<div id="randomizationSettingsTab" class="tabcontent">
					<div class="leftColumn">
						<fieldset id="logicSettingsFieldset">
							<legend>Logic Settings</legend>
							<label for="Logic Rules Fieldset">Logic Rules:</label>
							<select name="Logic Rules Fieldset" id="logicRulesFieldset">
								<option value="0">Glitchless</option>
								<option value="1">Glitched</option>
								<option value="2">No Logic</option>
							</select>
							<br/>
							<label for="Game Region Fieldset">Game Region:</label>
							<select name="Game Region Fieldset" id="gameRegionFieldset">
								<option value="0">NTSC (US)</option>
								<option value="1">PAL (EUR)</option>
								<option value="2">JP (JAP)</option>
							</select>
							<br/>
							<label for="Seed Number Fieldset">Seed Number:</label>
							<select name="Seed Number Fieldset" id="seedNumberFieldset">
								<option value="0">0</option>
								<option value="1">1</option>
								<option value="2">2</option>
								<option value="3">3</option>
								<option value="4">4</option>
								<option value="5">5</option>
								<option value="6">6</option>
								<option value="7">7</option>
								<option value="8">8</option>
								<option value="9">9</option>
							</select>
						</fieldset>
						<fieldset id="accessOptionsFieldset">
							<legend> Access Options</legend>
							<label for="Castle Requirements">Hyrule Castle Requirements:</label>
							<select name="Castle Requirements" id="castleRequirementsFieldset">
								<option value="0">Open</option>
								<option value="1">Fused Shadows</option>
								<option value="2">Mirror Shards</option>
								<option value="3">All Dungeons</option>
								<option value="4">Vanilla</option>
							</select>
							<br/>
							<label for="Palace Requirements">Palace of Twilight Requirements:</label>
							<select name="Palace Requirements" id="palaceRequirementsFieldset">
								<option value="0">Open</option>
								<option value="1">Fused Shadows</option>
								<option value="2">Mirror Shards</option>
								<option value="3">Vanilla</option>
							</select>
							<br/>
							<label for="Faron Woods Logic">Faron Woods Logic:</label>
							<select name="Faron Woods  Logic" id="faronLogicFieldset">
								<option value="0">Open</option>
								<option value="1">Closed</option>
							</select>
							<br/>
							<input type="checkbox" id="mdhCheckbox" name="MDH Logic" value="">
							<label for="MDH Logic"> Skip Midna's Desperate Hour</label><br>
							<input type="checkbox" id="introCheckbox" name="Intro Logic" value="">
							<label for="Intro Logic"> Skip Intro </label><br>
						</fieldset>
					</div>
					<fieldset id="itemPoolOptionsFieldset">
					<legend>Item Pool Options</legend>
						<fieldset id="dungeonItemOptionsFieldset">
						<legend>Dungeon Items</legend>
							<label for="Small Keys">Small Keys:</label>
							<select name="Small Keys" id="smallKeyOptions">
								<option value="1">Vanilla</option>
								<option value="2">Own Dungeon</option>
								<option value="3">Any Dungeon</option>
								<option value="4">Keysanity</option>
								<option value="5">Keysey</option>
							</select>
							<br/>
							<label for="Big Keys">Big Keys:</label>
							<select name="Big Keys" id="bigKeyOptions">
								<option value="0">Vanilla</option>
								<option value="1">Own Dungeon</option>
								<option value="2">Any Dungeon</option>
								<option value="3">Keysanity</option>
								<option value="4">Keysey</option>
							</select>
							<br/>
							<label for="Maps and Compasses">Maps and Compasses:</label>
							<select name="Maps and Compasses" id="mapAndCompassOptions">
								<option value="0">Vanilla</option>
								<option value="1">Own Dungeon</option>
								<option value="2">Any Dungeon</option>
								<option value="3">Anywhere</option>
								<option value="4">Start With</option>
							</select>
						</fieldset>
						<fieldset id="itemCategoriesFieldset">
						<legend>Item Categories</legend>
							<input type="checkbox" id="goldenBugsCheckbox" name="Golden Bugs" value="">
							<label for="Golden Bugs"> Golden Bugs </label><br>
							<input type="checkbox" id="skyCharacterCheckbox" name="Sky Characters" value="">
							<label for="Sky Characters"> Sky Characters </label><br>
							<input type="checkbox" id="giftsFromNPCsCheckbox" name="Gifts From NPCs" value="">
							<label for="Gifts From NPCs"> Gifts From NPCs </label><br>
							<input type="checkbox" id="poesCheckbox" name="Poes" value="">
							<label for="Poes"> Poes </label><br>
							<input type="checkbox" id="shopItemsCheckbox" name="Shop Items" value="">
							<label for="Shop Items"> Shop Items </label><br>
							<input type="checkbox" id="hiddenSkillsCheckbox" name="Hidden Skills" value="">
							<label for="Hidden Skills"> Hidden Skills </label><br>
							<label for="Foolish Items">Foolish Items:</label>
							<select name="Foolish Items" id="foolishItemOptions">
								<option value="0">None</option>
								<option value="1">Few</option>
								<option value="2">Many</option>
								<option value="3">Mayhem</option>
								<option value="4">Nightmare</option>
							</select>
						</fieldset>
					</fieldset>
				</div>
				  
				<div id="gameplaySettingsTab" class="tabcontent">
					<fieldset id="clearedTwilightsFieldset">
						<legend>Cleared Twilights</legend>
						<input type="checkbox" id="faronTwilightCheckbox" name="Faron Twilight Checkbox" value="">
						<label for="Faron Twilight Checkbox"> Faron Twilight Cleared </label><br>
						<input type="checkbox" id="eldinTwilightCheckbox" name="Eldin Twilight Checkbox" value="">
						<label for="Eldin Twilight Checkbox"> Eldin Twilight Cleared </label><br>
						<input type="checkbox" id="lanayruTwilightCheckbox" name="Lanayru Twilight Checkbox" value="">
						<label for="Lanayru Twilight Checkbox"> Lanayru Twilight Cleared </label><br>
					</fieldset>
					<fieldset id="cutscenesAndMundaneSkipsFieldset">
						<legend>Cutscenes/Mundane Skips</legend>
						<input type="checkbox" id="skipMinorCutscenesCheckbox" name="Skip Minor Cutscenes Checkbox" value="">
						<label for="Skip Minor Cutscenes Checkbox"> Skip Minor Cutscenes </label><br>
						<input type="checkbox" id="msPuzzleCheckbox" name="Master Sword Puzzle Checkbox" value="">
						<label for="Master Sword Puzzle Checkbox"> Skip Master Sword Puzzle </label><br>
					</fieldset>
				</div>
				  
				<div id="excludedChecksTab" class="tabcontent">
					<select id="checksToBeExcludedListbox" multiple="multiple" size="10" width="20%">
						<?php 
							$files = glob('World/Checks/*/*/*.json');
								$i = 0;
							foreach ($files as $file) 
							{
								$file = preg_replace('/\\.[^.\\s]{3,4}$/', '', $file);
								echo "<option value='$i'>".pathinfo($file, PATHINFO_BASENAME)."</option>"; 
								$i++;
							}
						?>
					</select>	
					<input id="excludeCheckButton" value=">" type="button"> 			  
					<input id="unexcludeCheckButton" value="<" type="button">
					<select id="excludedChecksListbox" multiple="multiple" size = "10"  width="20%"><option>volvo</option></select>
				</div>

				<div id="startingInventoryTab" class="tabcontent">
					<select id="listOfImportantItemsListbox" multiple="multiple" size="10" width="20%">
						<?php 
							$important_items = file_get_contents("StartingItems.txt");
							$important_items = explode("\n", $important_items);
							$i = 0;
							foreach ($important_items as $important_item) 
							{
								list($value, $name) = explode(",", $important_item);
								$name = str_replace("_"," ", $name);
								echo "<option value='$value'>".$name."</option>"; 
								$i++;
							}
						?>
					</select>	
					<input id="addToInventoryButton" value=">" type="button"> 			  
					<input id="removeFromInventoryButton" value="<" type="button">
					<select id="startingItemsListbox" multiple="multiple" size = "10"  width="20%"><option>volvo</option></select>
				</div>

				<div id="cosmeticsAndQuirksTab" class="tabcontent">
					<div class="leftColumn">
						<fieldset id="additionalSettingsFieldset">
							<legend>Additional Settings</legend>
							<input type="checkbox" id="fastIBCheckbox" name="Fast IB Checkbox" value="">
							<label for="Fast IB Checkbox"> Fast Iron Boots </label><br>
							<input type="checkbox" id="quickTransformCheckbox" name="Quick Transform Checkbox" value="">
							<label for="Quick Transform Checkbox"> Quick Transform </label><br>
							<input type="checkbox" id="transformAnywhereCheckbox" name="Transform Anywhere Checkbox" value="">
							<label for="Transform Anywhere Checkbox"> Transform Anywhere</label><br>
						</fieldset>
						<fieldset id="musicAndSFXFieldset">
							<legend> Music and SFX </legend>
							<input type="checkbox" id="randomizeBGMCheckbox" name="Randomize BGM Checkbox" value="">
							<label for="Randomize BGM Checkbox"> Randomize Background Music </label><br>
							<input type="checkbox" id="randomizeFanfaresCheckbox" name="Randomize Fanfares Checkbox" value="">
							<label for="Randomize Fanfares Checkbox"> Randomize Fanfares </label><br>
							<input type="checkbox" id="disableEnemyBGMCheckbox" name="Disable Enemy BGM Checkbox" value="">
							<label for="Disable Enemy BGM Checkbox"> Disable Enemy Background Music?</label><br>
						</fieldset>
					</div>
					<fieldset id="itemPoolOptionsFieldset">
					<legend>Item Pool Options</legend>
						<label for="Tunic Color Fieldset">Tunic Color:</label>
						<select name="Tunic Color Fieldset" id="tunicColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Green</option>
							<option value="3">Blue</option>
							<option value="4">Yellow</option>
							<option value="5">Purple</option>
							<option value="6">Gray</option>
							<option value="7">Black</option>
							<option value="8">White</option>
						</select>
						<br/>
						<label for="Lantern Color Fieldset">Lantern Color:</label>
						<select name="Lantern Color Fieldset" id="lanternColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Orange</option>
							<option value="3">Yellow</option>
							<option value="4">Lime Green</option>
							<option value="5">Dark Green</option>
							<option value="6">Blue</option>
							<option value="7">Purple</option>
							<option value="8">Black</option>
							<option value="9">White</option>
							<option value="10">Cyan</option>
						</select>
						<br/>
						<label for="Midna Hair Color Fieldset">Midna Hair Color:</label>
						<select name="Midna Hair Color Fieldset" id="midnaHairColorFieldset">
							<option value="0">Default</option>
							<option value="1">Blue</option>
						</select>
						<br/>
						<label for="Heart Color Fieldset">Heart Color:</label>
						<select name="Heart Color Fieldset" id="heartColorFieldset">
							<option value="0">Default</option>
							<option value="1">Rainbow</option>
							<option value="2">Teal</option>
							<option value="3">Pink</option>
							<option value="4">Orange</option>
							<option value="5">Blue</option>
							<option value="6">Purple</option>
							<option value="7">Green</option>
							<option value="8">Black</option>
						</select>
						<br/>
						<label for="A Button Color Fieldset">A Button Color:</label>
						<select name="A Button Color Fieldset" id="aButtonColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Orange</option>
							<option value="3">Yellow</option>
							<option value="4">Dark Green</option>
							<option value="5">Purple</option>
							<option value="6">Black</option>
							<option value="7">Grey</option>
							<option value="8">Pink</option>
						</select>
						<br/>
						<label for="B Button Color Fieldset">B Button Color:</label>
						<select name="B Button Color Fieldset" id="bButtonColorFieldset">
							<option value="0">Default</option>
							<option value="1">Orange</option>
							<option value="2">Pink</option>
							<option value="3">Green</option>
							<option value="4">Blue</option>
							<option value="5">Purple</option>
							<option value="6">Black</option>
							<option value="7">Teal</option> 
						</select>
						<br/>
						<label for="X Button Color Fieldset">X Button Color:</label>
						<select name="X Button Color Fieldset" id="xButtonColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Orange</option>
							<option value="3">Yellow</option>
							<option value="4">Lime Green</option>
							<option value="5">Dark Green</option>
							<option value="6">Blue</option>
							<option value="7">Purple</option>
							<option value="8">Black</option>
							<option value="9">Pink</option>
							<option value="10">Cyan</option>
						</select>
						<br/>
						<label for="Y Button Color Fieldset">Y Button Color:</label>
						<select name="Y Button Color Fieldset" id="yButtonColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Orange</option>
							<option value="3">Yellow</option>
							<option value="4">Lime Green</option>
							<option value="5">Dark Green</option>
							<option value="6">Blue</option>
							<option value="7">Purple</option>
							<option value="8">Black</option>
							<option value="9">Pink</option>
							<option value="10">Cyan</option>
						</select>
						<br/>
						<label for="Z Button Color Fieldset">Z Button Color:</label>
						<select name="Z Button Color Fieldset" id="zButtonColorFieldset">
							<option value="0">Default</option>
							<option value="1">Red</option>
							<option value="2">Orange</option>
							<option value="3">Yellow</option>
							<option value="4">Lime Green</option>
							<option value="5">Dark Green</option>
							<option value="6">Purple</option>
							<option value="7">Black</option>
							<option value="8">Light Blue</option>
						</select>
					</fieldset>
				</div>
				<br/>
				<label for="Settings String Text Box">Settings String:</label>
  				<input type="text" id="settingsStringTextbox" name="Settings String Text Box">
				<input id="generateSeedButton" value="Generate" type="button">
			</div>
			<div class="blackbg">
				<h1>Tools and resources</h1>
				<hr />
				<br />
				<table>
					<tr>
						<td class="rBor">
							<a target="_blank" href="https://takarikka.github.io/TP-Tracker/"><img src="img/github.png" /></a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://docs.google.com/spreadsheets/d/1quJjkAGV7asF1CNRtJEDNsy9Oga7hmzGLe09u2zxdJI/edit#gid=1131787935"><img src="img/sheets.png" /></a>
						</td>
						<td class="rBor">
							<a target="_blank" href="http://tp.docs.aecx.cc/Yet+Another+GameCube+Documentation/index.html"><img src="img/yagcd.png" /></a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://github.com/zsrtp"><img src="img/tp.png" /></a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://wiki.tpspeed.run/Main_Page"><img src="img/wiki.png" /></a>
						</td>
						<td>
							<a target="_blank" href="https://discord.tpspeed.run/"><img src="img/discord.png" /></a>
						</td>
					</tr>
					<tr>
						<td class="rBor">
							<a target="_blank" href="https://takarikka.github.io/TP-Tracker/">Taka's Item Tracker</a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://docs.google.com/spreadsheets/d/1quJjkAGV7asF1CNRtJEDNsy9Oga7hmzGLe09u2zxdJI/edit#gid=1131787935">Rando Dev Sheet</a>
						</td>
						<td class="rBor">
							<a target="_blank" href="http://tp.docs.aecx.cc/Yet+Another+GameCube+Documentation/index.html">YAGCD</a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://github.com/zsrtp">TP Devs</a>
						</td>
						<td class="rBor">
							<a target="_blank" href="https://wiki.tpspeed.run/Main_Page">TP Speedrun Wiki</a>
						</td>
						<td>
							<a target="_blank" href="https://discord.tpspeed.run/">Discord</a>
						</td>
					</tr>
				</table>
			</div>
			<div class="blackbg" style="padding: 0px; margin-bottom: 0px;">
				<p>
					v1.09 - Made with 
					<img style="display: inline; margin: 0px 0px -10px;" src="img/heart.png" />
					 by 
					<a target="_blank" href="https://github.com/zsrtp/Randomizer-Frontend" target="_blank" style="color: #d62013;">Luneyes</a>!<br/>
					
					Logo and background image are property of Nintendo. No infringement intended. We love you guys!<br/>
					
					Logo edited by <a target="_blank" href="https://twitter.com/MelonSpeedruns" target="_blank" style="color: #d62013;">MelonSpeedruns</a>!
					
				</p>
			</div>
		</div>
	</body>
	<script src="script.js"></script>
</html>
