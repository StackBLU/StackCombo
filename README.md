<section id="installation">
  
* Copy the following repository link: <br>
`https://raw.githubusercontent.com/StackBLU/MyDalamudPlugins/main/pluginmaster.json` <br>
* Type `/xlsettings` in the game chat window to open the Dalamud Settings window.
* Navigate to the "Experimental" tab.
* Paste the link you copied into the available input box under "Custom Plugin Repositories".
* Ensure the box to the right of the link is checked.
* Press "Save and Close" at the bottom of the settings window.
  <br>You may notice the list of plugins flash briefly on the installer window - this just signifies the list refreshing successfully.
* Navigate to the "All Plugins" tab and search for "StackCombo".
* Click on "StackCombo" and select "Install".
* Click on the settings cog (where you just clicked "Install") to open the configuration.
  <br>Alternatively, type `/sc` in the game chat window.
  
</section>
<br>
<section id="commands">
  
| **Chat command &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;** | **Function** |
| :----------------- |:------------------ |
| `/sc`| Opens the main plugin window, where you can enable/disable features, access settings and more.|
| `/sc set`| Turns a specific feature/option **on** by referring to its internal name.<br>Does not work when in combat.|
| `/sc unset`| Turn a specific feature/option **off** by referring to its internal name.<br>Does not work while in combat.|
| `/sc unsetall`| Turns all features and options **off** at once.|
| `/sc toggle`| Toggles a specific feature/option **on or off** by referring to its internal name.<br>Does not work while in combat.|
| `/sc list`| Prints lists to the game chat based on filter arguments. <br>Requires an appended filter.|
| `/sc list set`<br>`/sc enabled`| Prints a list of all currently enabled features & options in the game chat.|
| `/sc list unset`| Prints a list of all currently disabled features & options in the game chat.|
| `/sc list all`| Prints a list of every feature & option in the game chat, regardless of state.|
| `/sc debug`| Outputs a full debug file to your desktop that can be sent to developers for utilisation in bug-fixing.|
| `/sc debug JOB`| Outputs a debug file to your desktop containing only job-relevant features/options. <br>Replace `JOB` with the appropriate job abbreviation.|

</section>

<p align="center">
  <br> Brought to you by:
  <br><br>
  <img align="center" src="/images/stack.gif" width="100" border-radius="50%" />
</p>