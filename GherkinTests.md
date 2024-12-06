Given:
	A player approaches the screen while the idle animation is playing
When:
	The player taps the screen
Then:
	The idle animation will stop and the level select screen will be displayed


Given:
	The player is playing the game and desires to move the player character
When:
	The player drags the joystick around the control area
Then:
	The player character will move in accordance with the joystick movement.


Given:
	The player is on the level select screen
When:
	The player presses on any of the 5 Stage icons
Then:
The textbox on the right of the screen will display a large version of that stage sprite, and a brief text description of that stage of the life cycle.


Given:
	The player is on the level select screen
When:
	The player presses the start button
Then:
	The game will load the correct stage of the game (determined by the active stage).


Given:
	The player has completed a stage, or is on the level select page
When:
	The player presses Start, Continue, Or next level
Then:
	While the game is loading the relevant scene, a land acknowledgment and loading bar will be shown to the player.


Given:
	The player is on the loading screen/Land acknowledgment screen
When:
	The level load is complete, and the screen displays the text “press anywhere to continue”, and the player taps the screen
Then:
	The screen will disappear, and the relevant scene will be shown to the player. 


Given:
	The player is inside a playable scene (River, Ocean, Spawning)
When:
	The player taps the pause button in the top left of the screen
Then:
	The game will be paused and the player given the option to continue, or return to the main menu via a dialog box centered on the screen. (During development there will also be a quit button, but this will be removed for production)


Given:
	The player is in the Fry stage of the River level
When:
	The player navigates the player character to collide with a food object
Then:
	The player health/food bar will increase some amount determined by the food type


Given:
	The player is in the Alevin stage of the River level
When:
	The player is crushed by the boot object for more than 3 seconds
Then:
	The player will be presented with a death screen and a description of why the player died, and given the option to try again, continue, or return to the main menu. 


Given:
	The player is in the Fry or Smolt stage of the River level
When:
	The player collides with a predator's hit box, (Eagle, Shark, Sculpin…) IF the players health is below the predators AC
Then:
	The player will be shown a death screen with the relevant text and image for the type of predator that killed the player, Describing why although the player ‘lost’ it is still an important aspect of the salmon life cycle. 

Given:
	The player is in the Spawning Stage
When:
	The player presses the jump button
Then:
	The player character will jump




