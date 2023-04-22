# DCS_MOD_Sync  
  
The 85th SQN DCS Livery(Mod) Sync Application

Readme!

Alpha 0.6.0.1

The 85th SQN DCS Mod Sync is intended to be used by members of the Borderline Tactical's 85th Squadron (Fictional). The Mod Sync App keeps the client’s files up to date with an FTP 
server that may from time to time be updated with new skins and liveries. Without these skins and liveries, members will not be able to see the wonderfully crafted skins that others use.

Using Version 0.6 and later - Place the Application where desired, but do not place on the Desktop, the App will update later and create a shortcut for you.

Updating from 0.4 and earlier to 0.5 and later
1. If using AutoDetect Folders, Rename the OGN_Mods folder in Users/[Yourname]/DCS/ folder to 85TH_Mods
2. Run the 0.5 version of the Mod Sync. If it needs to download all the skins again, check the folder name or the mods folder in the options. There may be a few files that need u
pdating/deleting.. This is Normal.

Updating from Version 0.1 or 0.2
1. Skip before and after use sections.
2. DELETE old version exe and use this one.
3. This version should delete the old symbolic links, but if you experience trouble, delete the link and then rebuild links.

Before Use
1. Backup any personal skins/mods in your Users/[Yourname]/DCS/Liveries folder.
2. Delete all folders in your Users/[Yourname]/DCS/Liveries folder.

How to Use.
1. Run the Application, duh.
2. Select the "Verify" Button.
3. Wait until verification against the server has been completed. This can result in; (note, you are the client)
	a. The Client is Sync'd with the Server - Nothing more required.
	b. The Client is missing some files and you will be shown a total number of files and the total size required to download to complete the sync.
	c. The Client has files that have since been deleted from the server.
	d. The Client is missing files and has files that have since been deleted, moved or renamed on the server.
4. If a. from above, the "File Synchronisation Status" Light will turn green. - No further Action required.
5. If b. c. or d. from above, then the client is required to select "Update" button which will remedy the above deficiencies.
6. After the update has completed the "File Synchronisation Status" Light will turn green. - No further Action required.
7. The Client may now select "Exit" or they can Select Verify again to double check the update was successful.
8. The Client may also use the "Rebuild Links" button to just rebuild the Directory links in the Liveries folder (in case they were deleted.)

Options Menu.
The options menu can be accessed through the button above the go/nogo Status lights in the top left of the window. It looks like a dot followed by a dash over 3 lines, surrounded by a circle.
The Option menus has the following options;
1. Allows custom location to store the 85th SQN DCS Mods that are downloaded (handy if you have limited C: drive space.) Note: this must be any drive on the same computer as the DCS install.
2. Allows custom liveries folder location, in case you store your liveries somewhere else. (Note you will need to symbolically link from the DCS Users folder to this one yourself.
3. Adjust the number of Download threads, between 1 and 10. Those with fast internet, can use up to 10, if you have slow internet, limit this number to the lower end of the scale.
4. Check box to automatically download after verification, if you are happy to just go ahead and download straight away.
5. Check box to automatically rebuild links after download... Uncheck it if you want to manually rebuilds yourself later for whatever reason.
Advanced Application Options
6. Applcation Folder allows you to select a new location for the Application, this should not need changing unless you wish to put the application in a new location without moving it manually..
The application will not move until a new version is downloaded.
7. The Last checkbox is used if you no longer wish to use this mod and it deletes all links and files associated with the Mod Sync. It is Custom (own liveries in liveries folder safe).
Select this checkbox then click "Ok", the operation will be completed immediately. 

Note, that when you click OK in the options menu, the App will rebuild links regardless.

How it Works
When selecting the "Verify" button, the application;
	1. Looks for and selects the Users Saved Games DCS folder.
	2. Looks for and creates the 85th_Mods, and Liveries folder (in the default locations, or as selected in the Options menu).
	3. Contacts the 85th SQN FTP server and obtains a list of files from the server.
	4. Compares this list to the files that are loaded into the Clients DCS/85th_Mods folder
	5. Any discrepancies are added to a list and totals displayed to the Client in the "Status" field.
	6. Makes that list available to the Update function for action.
	
When Selecting the "Update" button;
	1. If you haven't verified or the Verification status is green - nothing.
	2. If you have verified, the application will;
		2.1. If the File has been deleted, moved or renamed on the server - Delete the local version.
		2.2. If the file is on the server and not on the client - The Application will download the file to the users DCS/85th_Mods folder.
	3. Rebuild the links as be the next section (default unless checkbox unchecked in the options menu).

When selecting the "Rebuild Links" Button;
	1. deletes any Junction links in the DCS/Liveries folder.
	2. Scan the users DCS/85th_Mods for the livery folders for each aircraft.
	3. Create the aircrafts folder in the DCS/Liveries folder.
	4. Creates Directory Junctions in the Aircrafts folders to the relevant aircrafts folders in the 85th_Mods folder.
	
After Use
1. Restore any personal skins, taking care not to overwrite the Symbolic Links from the application.
2. Keep checking regularly for updates.

The UI
The "85th SQN DCS Server" indicator light will let you know if the server is offline (Red) or online (Green). (although this does not mean it is up to date.)
The "File Synchronisation Status" indicator lets you know that you haven't verified, or if you have, that you need to download some updates (Red)
	or that you have completed Verification and you are synchronised (Green).
The "Status" Line advises the applications current/latest action and process feedback.

Notes:
During download, the application makes 4 (default, changed in options download threads) different connections to the FTP server, therefore you will be downloading 
	4 (default) files at one time. This is to improve download speed for those with fast internet (the server maxes at about 4-8 Mb/s per connection/file.)
Symbolic links in the liveries for should be safe. This App only deletes link to the OGN_Mods folder.
You cannot Update before verifying.

Application Updates:
There is a new feature that checks the application version against the latest release version on the Git. When there is a new release version you will be notified every time you
open the app, until it is updated.
1. You can cancel this and continue to use the app but it will tell you there is an update on the next restart.
2. You then have a choice to download the app yourself (in which case you will be taken to the website to download) or;
3. You can let the app do it for you. If you select this, the app will download the latest version from the Git to your Downloads folder, then extract the updated exe to the App 
folder (see options above), restart the app to the new version and delete the old version. You don't even need to lift a finger.

FAQs
Q: Can I use my own Skins.
A: Yes, place them as you would in the DCS/Liveries folder, making sure the name is different from the 85th SQN Mods.

Q: Why do I need to download if a file/folder was moved/renamed.
A: Currently the Application cannot determine if a file is new, renamed or moved, therefore it is safer to delete the old file and download the renamed/moved file.

Q: Why are the mods placed in the DCS/85th_Mods folder?
A: To allow the app to delete files that have been deleted from the server without (“blaket” WTF is this word) wiping everything in the Liveries folder that isn't on the server, it was necessary to place it in its own hole. That ensure you can keep your own skins from other sources and still use 85th SQN's.
	
Q: How Stable is the App?
A: The App is still highly developmental and fragile. Until this is more widely used, all the fail points are yet to be discovered. Please be patient as we work on improving this app.	
	
Q: I've got a problem/suggestion, Who can I talk to?
A: Raise an issue on the GitHub https://github.com/Azza276/DCS_MOD_Sync/issues. Or talk to Azza276 of Borderline Tactical

Version Change Notes:

Beta - 0.6.1

`+` Added New Port parameter for the FTP Server (non-standard port number used).

`=` Fixed FTP Server connection issues (related to port number above).

`=` Other Minor code cleanup (commented out unnecessary code).

`=` Fixed Server Online indication (incorrect port being interrogated).

Beta - 0.6

`+` Added new App Update Check and Download Feature (https://github.com/Azza276/85th_DCS_MOD_Sync/issues/16).

`+` Added to Options the ability to change the Application folder directory.

`+` Added selection in Options that will Fix/Clean the Mod Folders and Links. (https://github.com/Azza276/85th_DCS_MOD_Sync/issues/19).

`+` Added When Ap gets updated it puts a shortcut on the Desktop.

`=` Changed some code to align with B|Tac 85th SQN a bit more.

`=` Increased the size of the Application Window. She ain't no small Baby App anymore.

Alpha - 0.5

`-` Removed references to the Oz Gaming Network (OGN) from the code and app Window as the 85th are no longer associated with OGN.

`=` Changed Indicator lights as it's no longer the season.

`=` Changed the Background Picture to something a little more exciting.

`=` Changed the UI colour as the Blue clashed with the new background image.

Alpha - 0.4

 `=` Fixed - Update/Download not starting if the size of the download is greater than 2GB. This was due to counting size in Bytes and the value of bytes over 2GB is bigger the what can be stored in an integer, causing the app to overflow and trip up.

Alpha - 0.3 Hotfix 1

`=` On new installs without a liveries folder yet, the app would not auto detect correctly ask the user to use the options menu to manually select. This should not happen, and has been fixed so that the liveries folder is created if it is not there and autodetect selects the folder regardless, and the folder is created during Verification.

Alpha - 0.3

`+` Options menu. Can select mod download location, livery folder locations, number of downlad threads, select auto download after verification, auto link rebuilding after download.

`+` Exception handling for a number of different cases, including symbolic link creation, FTP server overload/offline, DCS folders not found.

`=` Improved the File Verification Time significantly

`=` Do not need to run the App as Admin. No longer using symbolic links, which req admin, instead using Directory Junctions, which do not require admin.

`=` Fixed Directory Link creation after Update.


Alpha - 0.2

`+` Progress bar movement during Verification to indicate the Program is still actually running. Does not indicate progress.

`+` "Rebuild Links" Button so you can just rebuild the symbolic links without deleting files and re-downloading (Added for additional debug if required.)

`=` Changed Download progress bar to be more progressive. It now goes to protests, and updates regularly (in accordance with amount of data downloaded to total amount.) This should make it clear that the	files are still being downloaded.

`=` Fixed the Verification stating you need to download files after completing an update. - Forgot to flush the files to download variable after a download.

`=` Changed the indicator light to Xmas Theme - 'tis the season.
 

