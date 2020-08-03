using System;
using System.Diagnostics;
using UnityEngine;

/// <summary>
/// Todo
/// </summary>
public static class MechSpawnCubeCoordinatesUtil
{
    #region Private Fields

    // Provide logging capability
    private static readonly Logger logger = new Logger(new StackFrame().GetMethod().DeclaringType);

    #endregion Private Fields

    #region Public Methods

    public static CubeCoordinates GetSpawningCubeCoordinatesFor(SpawnIdEnum teamId, int teamIdMechCount, int mechTeamIndex, int mapRadius)
    {
        // Check that the tileInfoReport is non-null
        if (teamIdMechCount > 0 &&
            mechTeamIndex >= 0 &&
            mechTeamIndex < teamIdMechCount &&
            mapRadius >= teamIdMechCount)
        {
            int centerSpawnIndex = Mathf.FloorToInt(teamIdMechCount / 2f);
            int centerIndexDifference = centerSpawnIndex - mechTeamIndex;
            int adjustment = Mathf.Abs(centerIndexDifference);
            logger.Debug("Getting Spawn for: TeamId: ?, TeamIdMechCount: ?, MechTeamIndex: ?, MapRadius: ?, centerIndexDifference: ?",
                teamId, teamIdMechCount, mechTeamIndex, mapRadius, centerIndexDifference);

            int xCoordinate;
            int zCoordinate;
            int yCoordinate;
            // Determine the coordinate values based off of the teamId
            switch (teamId)
            {
                case SpawnIdEnum.NorthEast:
                    xCoordinate = mapRadius;
                    yCoordinate = 0;
                    zCoordinate = -mapRadius;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the yCoordinate by adjustment
                        yCoordinate -= adjustment;
                        // Increment the zCoordinate by adjustment
                        zCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the xCoordinate by adjustment
                        xCoordinate -= adjustment;
                        // Increment the yCoordinate by adjustment
                        yCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                case SpawnIdEnum.East:
                    xCoordinate = 0;
                    yCoordinate = mapRadius;
                    zCoordinate = -mapRadius;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the yCoordinate by adjustment
                        yCoordinate -= adjustment;
                        // Increment the xCoordinate by adjustment
                        xCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the xCoordinate by adjustment
                        xCoordinate -= adjustment;
                        // Increment the zCoordinate by adjustment
                        zCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                case SpawnIdEnum.SouthEast:
                    xCoordinate = -mapRadius;
                    yCoordinate = mapRadius;
                    zCoordinate = 0;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the zCoordinate by adjustment
                        zCoordinate -= adjustment;
                        // Increment the xCoordinate by adjustment
                        xCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the yCoordinate by adjustment
                        yCoordinate -= adjustment;
                        // Increment the zCoordinate by adjustment
                        zCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                case SpawnIdEnum.SouthWest:
                    xCoordinate = -mapRadius;
                    yCoordinate = 0;
                    zCoordinate = mapRadius;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the zCoordinate by adjustment
                        zCoordinate -= adjustment;
                        // Increment the yCoordinate by adjustment
                        yCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the yCoordinate by adjustment
                        yCoordinate -= adjustment;
                        // Increment the xCoordinate by adjustment
                        xCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                case SpawnIdEnum.West:
                    xCoordinate = 0;
                    yCoordinate = -mapRadius;
                    zCoordinate = mapRadius;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the xCoordinate by adjustment
                        xCoordinate -= adjustment;
                        // Increment the yCoordinate by adjustment
                        yCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the zCoordinate by adjustment
                        zCoordinate -= adjustment;
                        // Increment the xCoordinate by adjustment
                        xCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                case SpawnIdEnum.NorthWest:
                    xCoordinate = mapRadius;
                    yCoordinate = -mapRadius;
                    zCoordinate = 0;

                    // Adjust to the Right
                    if (centerIndexDifference > 0)
                    {
                        // Decrement the xCoordinate by adjustment
                        xCoordinate -= adjustment;
                        // Increment the zCoordinate by adjustment
                        zCoordinate += adjustment;
                    }
                    // Adjust to the Left
                    else if (centerIndexDifference < 0)
                    {
                        // Decrement the zCoordinate by adjustment
                        zCoordinate -= adjustment;
                        // Increment the zCoordinate by adjustment
                        yCoordinate += adjustment;
                    }
                    // Otherwise it is the center Index
                    break;

                default:
                    throw new ArgumentException("Unable to get spawning " + typeof(CubeCoordinates) + ". Invalid TeamId: " + teamId);
            }
            logger.Debug("xCoordinate: ?, yCoordinate: ?, zCoordinate: ?",
                xCoordinate, yCoordinate, zCoordinate);
            return new CubeCoordinates(xCoordinate, yCoordinate, zCoordinate);
        }
        else
        {
            throw new ArgumentException("Unable to get spawning " + typeof(CubeCoordinates) + ". Invalid Parameters.");
        }
    }

    #endregion Public Methods
}