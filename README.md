#**Our-Ashes-Tactics-Game**
- Ambitious Game that has been in the works (At least conceptually) since 2012
- Strategy/Simulation Turn-based Hex Mech Game
- Comparable to Battletech but probs worse

## Goals:
- Similar to Battle Brothers in a lot of ways except with giant bro-bots
- Simulation capable (Allow idle play for those who want it)
- World map that is affected by player actions by expanding territory of factions (Need to make said world map)

## Todo List:
- **DONE** Update what information reports contain
- **DONE** Have a ExceptionUtil similar to Logger to allow for easier string generation
- **DONE (Via the HopliteReport)** Have the talon's determine whether to allow the "Human" to control or the "Pilot"
- **DONE** Update all reports to use GetType().Name to remove namespaces in logging
- **DONE** Update Behaviors to generate their own reports and have a aggregated report that contains all of the sub-reports
- **DONE** Use emblem generator for the phalanx/faction images (Can be expanded)
- **DONE** Use nato alphabet for phalanx ids 
- **DONE** Implement Pilots (Similar to how Battle Brothers are generated)
- Implement World Map generation that is made up of giant hex tiles
- Have a world map that the battles zoom in on and exist on top of a world tile maybe have a new scene that generates the landscape by using some parameters from the world map to minimize unused world tiles off screen
- Have the pilots look like Among Us style (Arms are overrated)
- Have the talons look less...terrible
- **DONE** Update Talons to have a utility slot (Need to add Utility Models)
- Update what the factions are
- **DONE** Update the spawning system
- **OBE**/**DONE** Add Weapon/Talon Animations
- Add different battle types (Ambush, King of the hill, deathmatch)
- **OBE** Update weapons to track their index
- Have day and night cycle working at some point
- Have armor be dynamic as the battle goes on, you lose armor or something based off of penetration (If the penetration makes the armor remaining negative, lose 1 armor point?)
- Update the logging system for reporting how the turns are going
- Update how to create the game log using the reports
- Need to finally implement the UI instead of relying on logs
- Change the base of the Talon to be the Faction color. It seems pretty obv to determine wihch tile a talon is on
- Have the callsigns be unique per faction (NOT PER PHALANX)
- **DONE** Break out talon emblem generation into some util/manager. "public static GameObject GetTalonEmblem(...)"
- Have a pop-up with detailed talon combat results (Per weapon, each roll, ...)
- **DONE** Simplify Talon/Weapon objects by just tracking the the attribute structures and going from there (Ideally, I want to simplify the complexity)
- **DONE** Since I do not plan on animating weapons, I should remove the weapon scripts. And jsut add the game objects to the talon game object and keep track of the weapons as objects (Not game objects)
- **DONE** Arguably remove the scripts for most Talon functionality if I have a manager involved to move the game object
- Update the sprites to no longer have a black outline. I think I can use Unity's Outline component to get the effect I desire