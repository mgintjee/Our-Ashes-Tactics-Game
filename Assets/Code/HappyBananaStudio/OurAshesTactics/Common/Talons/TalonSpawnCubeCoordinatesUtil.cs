/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Exceptions;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.RandomNumberGenerators;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Coordinates.Cube;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Managers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Talons
{
    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonSpawnCubeCoordinatesUtil
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // TODO: Update this for whichever game type is being played
        // Todo: Figure out best approach for this
        public static ICubeCoordinates GetSpawningCubeCoordinatesFor(GameTypeEnum gameType)
        {
            switch (gameType)
            {
                case GameTypeEnum.Deathmatch:
                    return GetSpawningCubeCoordinatesForDeathmatch(gameType);

                default:
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not supported.",
                        new StackFrame().GetMethod().Name, typeof(GameTypeEnum), gameType);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="teamId">
        /// </param>
        /// <param name="teamIdMechCount">
        /// </param>
        /// <param name="mechTeamIndex">
        /// </param>
        /// <param name="mapRadius">
        /// </param>
        /// <returns>
        /// </returns>
        public static ICubeCoordinates GetSpawningCubeCoordinatesFor(PhalanxIdEnum teamId, int teamIdMechCount, int mechTeamIndex, int mapRadius)
        {
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
                    case PhalanxIdEnum.PhalanxNorthEast:
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

                    case PhalanxIdEnum.PhalanxEast:
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

                    case PhalanxIdEnum.PhalanxSouthEast:
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

                    case PhalanxIdEnum.PhalanxSouthWest:
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

                    case PhalanxIdEnum.PhalanxWest:
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

                    case PhalanxIdEnum.PhalanxNorthWest:
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
                        throw new ArgumentException("Unable to get spawning " + typeof(ICubeCoordinates) + ". Invalid TeamId: " + teamId);
                }
                logger.Debug("xCoordinate: ?, yCoordinate: ?, zCoordinate: ?",
                    xCoordinate, yCoordinate, zCoordinate);
                return new CubeCoordinates(xCoordinate, yCoordinate, zCoordinate);
            }
            else
            {
                throw new ArgumentException("Unable to get spawning " + typeof(ICubeCoordinates) + ". Invalid Parameters.");
            }
        }

        private static ICubeCoordinates GetSpawningCubeCoordinatesForDeathmatch(GameTypeEnum gameType)
        {
            HashSet<ICubeCoordinates> cubeCoordinatesSet = GameMapObjectManager.GetAllCubeCoordinatesSet();
            ICubeCoordinates randomCubeCoordinates = new List<ICubeCoordinates>(cubeCoordinatesSet)[RandomNumberGeneratorUtil.GetNextInt(cubeCoordinatesSet.Count)];
            if (GameMapObjectManager.FindHexTileObjectFrom(randomCubeCoordinates).GetHexTileInformationReport().GetTalonIdentificationReport() != null)
            {
                return GetSpawningCubeCoordinatesForDeathmatch(gameType);
            }
            return randomCubeCoordinates;
        }
    }
}