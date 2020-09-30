#**Our-Ashes-Tactics-Game**
- Ambitious Game that has been in the works (At least conceptually) since 2012
- Strategy/Simulation Turn-based Hex Mech Game
- Comparable to Battletech but probs worse

## Goals:
- Similar to Battle Brothers in a lot of ways except with giant bro-bots
- Simulation capable (Allow idle play for those who want it)
- World map that is affected by player actions by expanding territory of factions (Need to make said world map)

## Todo List:
- Implement Pilots (Similar to how Battle Brothers are generated)
- Implement World Map generation that is made up of giant hex tiles
- Update all reports to use GetType().Name to remove namespaces in logging
- Update Behaviors to generate their own reports and have a aggregated report that contains all of the sub-reports
- Have a world map that the battles zoom in on and exist on top of a world tile maybe have a new scene that generates the landscape by using some parameters from the world map to minimize unused world tiles off screen
- Update what information reports contain
- Have a ExceptionUtil similar to Logger to allow for easier string generation (Done. Just need to update to utilize it)
- Have the talon's determine whether to allow the "Human" to control or the "Pilot"
- Have the pilots look like Among Us style (Arms are overrated)
- Have the talons look less ...terrible
- Update Talons to have a utility slot
- Update what the factions are
- Update the spawning system
- Add Weapon/Talon Animations
- Add different battle types (Ambush, King of the hill, deathmatch)
- Update weapons to track their index
- Have day and night cycle working at some point
- Have armor be dynamic as the battle goes on, you lose armor or something based off of penetration (If the penetration makes the armor remaining negative, lose 1 armor point?)
- Update the logging system for reporting how the turns are going