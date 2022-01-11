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
							<label for="Logic Rules">Logic Rules:</label>
							<select name="Logic Rules" id="logicRules">
								<option value=””>Glitchless</option>
								<option value=””>Glitched</option>
								<option value=””>No Logic</option>
							</select>
							<br/>
							<label for="Game Region">Game Region:</label>
							<select name="Game Region" id="gameRegion">
								<option value=””>NTSC (US)</option>
								<option value=””>PAL (EUR)</option>
								<option value=””>JP (JAP)</option>
							</select>
						</fieldset>
						<fieldset id="accessOptionsFieldset">
							<legend> Access Options</legend>
							<label for="Castle Requirements">Hyrule Castle Requirements:</label>
							  <select name="Castle Requirements" id="castleRequirements">
								  <option value=””>Open</option>
								  <option value=””>Fused Shadows</option>
								  <option value=””>Mirror Shards</option>
								  <option value="">All Dungeons</option>
								  <option value="">Vanilla</option>
							  </select>
							  <br/>
							  <label for="Palace Requirements">Palace of Twilight Requirements:</label>
							  <select name="Palace Requirements" id="palaceRequirements">
								  <option value=””>Open</option>
								  <option value=””>Fused Shadows</option>
								  <option value=””>Mirror Shards</option>
								  <option value="">Vanilla</option>
							  </select>
							  <br/>
							  <label for="Faron Woods Logic">Faron Woods Logic:</label>
							  <select name="Faron Woods  Logic" id="faronLogic">
								  <option value=””>Open</option>
								  <option value="">Closed</option>
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
									<option value=””>Vanilla</option>
									<option value=””>Own Dungeon</option>
									<option value=””>Any Dungeon</option>
									<option value="">Keysanity</option>
									<option value="">Keysey</option>
								</select>
								<br/>
								<label for="Big Keys">Big Keys:</label>
								<select name="Big Keys" id="bigKeyOptions">
									<option value=””>Vanilla</option>
									<option value=””>Own Dungeon</option>
									<option value=””>Any Dungeon</option>
									<option value="">Keysanity</option>
									<option value="">Keysey</option>
								</select>
								<br/>
								<label for="Maps and Compasses">Maps and Compasses:</label>
								<select name="Maps and Compasses" id="mapAndCompassOptions">
									<option value=””>Vanilla</option>
									<option value=””>Own Dungeon</option>
									<option value=””>Any Dungeon</option>
									<option value="">Anywhere</option>
									<option value="">Start With</option>
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
									<option value=””>None</option>
									<option value=””>Few</option>
									<option value=””>Many</option>
									<option value="">Mayhem</option>
									<option value="">Nightmare</option>
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
					<h3>Tokyo</h3>
					<p>Tokyo is the capital of Japan.</p>
				  </div>

				  <div id="cosmeticsAndQuirksTab" class="tabcontent">
					<h3>Tokyo</h3>
					<p>Tokyo is the capital of Japan.</p>
				  </div>
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
