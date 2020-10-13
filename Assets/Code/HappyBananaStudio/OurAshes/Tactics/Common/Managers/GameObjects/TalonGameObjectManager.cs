/// <summary>
/// Company: HappyBananaStudio
/// Author: Matthew Gintjee
/// </summary>
/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Information;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Coordinates;
using HappyBananaStudio.OurAshesTactics.Common.Utils.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects
{
    /// <summary>
    /// Todo
    /// </summary>
    public class TalonGameObjectManager
    {
        private readonly static IDictionary<ITalonIdentificationReport, GameObject> talonIdentificationReportGameObjectDictionary =
            new Dictionary<ITalonIdentificationReport, GameObject>();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector3 GetTalonWorldPosition(ITalonIdentificationReport talonIdentificationReport)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                return talonIdentificationReportGameObjectDictionary[talonIdentificationReport].transform.position;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonIdentificationReport">
        /// </param>
        /// <param name="newWorldPosition">
        /// </param>
        public static void UpdateTalonWorldPosition(ITalonIdentificationReport talonIdentificationReport, Vector3 newWorldPosition)
        {
            if (talonIdentificationReportGameObjectDictionary.ContainsKey(talonIdentificationReport))
            {
                newWorldPosition.y = 0;
                talonIdentificationReportGameObjectDictionary[talonIdentificationReport].transform.position = newWorldPosition;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is not tracked",
                    new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport), talonIdentificationReport);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonInformationReport">
        /// </param>
        /// <param name="spawnCubeCoordinates">
        /// </param>
        public static void AddTalonGameObject(ITalonInformationReport talonInformationReport, ICubeCoordinates spawnCubeCoordinates)
        {
            if (talonInformationReport != null &&
                spawnCubeCoordinates != null)
            {
                if (!talonIdentificationReportGameObjectDictionary.ContainsKey(talonInformationReport.GetTalonIdentificationReport()))
                {
                    GameObject talonGameObject = null;
                    talonIdentificationReportGameObjectDictionary.Add(talonInformationReport.GetTalonIdentificationReport(), talonGameObject);
                    UpdateTalonWorldPosition(talonInformationReport.GetTalonIdentificationReport(),
                        CubeCoordinatesPositionUtil.CubeCoordinatesToWorldVector(spawnCubeCoordinates));
                }
                else
                {
                    throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. ?=? is already being tracked",
                        new StackFrame().GetMethod().Name, typeof(ITalonIdentificationReport),
                        talonInformationReport.GetTalonIdentificationReport());
                }
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid Parameters. " +
                    "\n\t>? is null: ?" +
                    "\n\t>? is null: ?",
                    new StackFrame().GetMethod().Name,
                    typeof(ITalonInformationReport), (talonInformationReport == null),
                    typeof(ICubeCoordinates), (spawnCubeCoordinates == null));
            }
        }
    }
}
