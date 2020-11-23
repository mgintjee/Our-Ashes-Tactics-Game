namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Talons
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.GameTypes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Phalanxes;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.RandomNumberGenerators;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class TalonSpawnCubeCoordinatesUtil
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // TODO: Update this for whichever game type is being played
        // Todo: Figure out best approach for this
        public static ICubeCoordinates GetSpawningCubeCoordinatesFor(GameTypeEnum gameType)
        {
            switch (gameType)
            {
                case GameTypeEnum.FactionSkirmish:
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
        public static ICubeCoordinates GetSpawningCubeCoordinatesFor(PhalanxId teamId, int teamIdMechCount, int mechTeamIndex, int mapRadius)
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
                    case PhalanxId.Charlie:
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

                    case PhalanxId.Alfa:
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

                    case PhalanxId.Echo:
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

                    case PhalanxId.Foxtrot:
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

                    case PhalanxId.Bravo:
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

                    case PhalanxId.Delta:
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
                return new CubeCoordinatesImpl(xCoordinate, yCoordinate, zCoordinate);
            }
            else
            {
                throw new ArgumentException("Unable to get spawning " + typeof(ICubeCoordinates) + ". Invalid Parameters.");
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="gameType">
        /// </param>
        /// <returns>
        /// </returns>
        private static ICubeCoordinates GetSpawningCubeCoordinatesForDeathmatch(GameTypeEnum gameType)
        {
            ISet<ICubeCoordinates> cubeCoordinatesSet = GameMapObjectManager.GetAllCubeCoordinatesSet();
            ICubeCoordinates randomCubeCoordinates = new List<ICubeCoordinates>(cubeCoordinatesSet)
                [RandomNumberGeneratorUtil.GetNextInt(cubeCoordinatesSet.Count)];
            if (GameMapObjectManager.GetHexTileObjectFrom(randomCubeCoordinates)
                .GetHexTileInformationReport().GetTalonIdentificationReport() != null)
            {
                return GetSpawningCubeCoordinatesForDeathmatch(gameType);
            }
            return randomCubeCoordinates;
        }
    }
}