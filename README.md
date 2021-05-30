#**Our-Ashes-Tactics-Game**
- Ambitious Game that has been in the works (At least conceptually) since 2012
- Strategy/Simulation Turn-based Hex Mech Game
- Comparable to Battletech/Battle Brothers but probs worse

# Goals:
- Similar to Battle Brothers in a lot of ways except with giant bro-bots
- Simulation capable (Allow idle play for those who want it)
- World map that is affected by player actions by expanding territory of factions (Need to make said world map)

# Todo List:
- **DONE** Update what information reports contain
- **DONE** Have a ExceptionUtil similar to Logger to allow for easier string generation
- **DONE (Via the HopliteReport)** Have the talon's determine whether to allow the "Human" to control or the "Pilot"
- **DONE** Update all reports to use GetType().Name to remove namespaces in logging
- **DONE** Update Behaviors to generate their own reports and have a aggregated report that contains all of the sub-reports
- **DONE** Use emblem generator for the phalanx/faction images (Can be expanded)
- **DONE** Use nato alphabet for phalanx ids 
- **DONE** Simplify Talon/Weapon objects by just tracking the the attribute structures and going from there (Ideally, I want to simplify the complexity)
- **DONE** Since I do not plan on animating weapons, I should remove the weapon scripts. And jsut add the game objects to the talon game object and keep track of the weapons as objects (Not game objects)
- **DONE** Arguably remove the scripts for most Talon functionality if I have a manager involved to move the game object
- **DONE** Update the spawning system
- **OBE**/**DONE** Add Weapon/Talon Animations (BASIC AF but something)
- **DONE** Update Talons to have a utility slot (Need to add Utility Models)
- **DONE** Break out talon emblem generation into some util/manager. "public static GameObject GetTalonEmblem(...)"
- **OBE** Update weapons to track their index
- **DONE** Create Widget Dimension and WidgetPosition structs that are vectors with int values
- **OBE** Update the sprites to no longer have a black outline. I think I can use Unity's Outline component to get the effect I desire
- **DONE** Have armor be dynamic as the battle goes on, you lose armor or something based off of penetration (If the penetration makes the armor remaining negative, lose 1 armor point? Have weapons deal armor damage?)
- **DONE** Have the callsigns be unique per faction (NOT PER PHALANX) Update: Callsigns unique per talon might be best (This would mean I no longer would need to id talon's by the id report and could Id by callsign?)
- **DONE** Add Heavy and Light weapons as well as Weapon Types (Shotgun, Assault, Etc)
- **DONE** Make loadouts for talons similar to how Destiny does? (Need to improve the generation)
- **DONE** Have the frame be the talon model that has its own attributes (Mainly (H/L)weapon/utility slots and base attributes (HP/AP/PP/MP)) and then you can add the armor(1)/engine(1)?
- **DONE** Make weapons have rolls that vary what traits they can have that can affect their attributes
- **DONE** Similar to Destiny where they have rarity where the rarity determines how many of the "perks" are modular (Need to clean up names/and values)
- **DONE** Have a Talon have MountPoints that can store either Weapons/Utilities (So, yes a Talon can enter a battle with 0 weapons) (Should talons have a base attack like ram? Deals damage to both but more for the other? Deals more damage based off of the total armor and health points of the rammer?)
- **DONE** Have health and combat use floats instead of ints for health and damage

## UI Crap:
- Implement World Map generation that is made up of giant hex tiles
- Have a world map that the battles zoom in on and exist on top of a world tile maybe have a new scene that generates the landscape by using some parameters from the world map to minimize unused world tiles off screen
- Have the pilots look like Among Us style (Arms are overrated)
- Have the talons look less...terrible
- Update what the factions are
- Have day and night cycle working at some point
- Update the logging system for reporting how the turns are going
- Update how to create the game log using the reports
- Need to finally implement the UI instead of relying on logs (Added the scoreboard so there is that)
- Have a pop-up with detailed talon combat results (Per weapon, each roll, ...)
- Have doodads on the hexTile tops 

## Game Mechanics Crap:
- Implement Pilots (Similar to how Battle Brothers are generated)
- Add different battle types (Ambush, King of the hill, deathmatch)
- Change the base of the Talon to be the Faction color. It seems pretty obv to determine which tile a talon is on (Which would imply that the ident report is unnecessary?) (Also i think then I just need to worry about the Phalanx Emblem now!!!!)
- Update Talon Construction
- Update the Game to handle Faction (with sets of Phalanxes on the same Faction) and Phalanx (Independent Phalanxes) game types
- Have traits be unique for the loadoutTypes
- Add status/effects of weapons and utilities

## File Structure:
- Update the folder structure to be based off of file type
- Maybe move the gameObjectManager with the MvcViewScript or something
- Start using InheritDoc to minimize common documentation
- Actually have weapon implementations and not just the numbers
