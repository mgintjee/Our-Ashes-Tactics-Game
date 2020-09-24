#**Our-Ashes-Tactics-Game**
- Ambitious Game that has been in the works (At least conceptually) since 2012
- Strategy/Simulation Turn-based HexTile Mech Game

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
- Have a ExceptionUtil similar to Logger to allow for easier string generation
- Have the talon's determine whether to allow the "Human" to control or the "Pilot"