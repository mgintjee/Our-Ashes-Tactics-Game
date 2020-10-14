

namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Animators
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.CodeObjects;
    using HappyBananaStudio.OurAshes.Tactics.Common.Managers.GameObjects;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Collections.Generic;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo Add api and crap for this
    /// </summary>
    public class AnimatorMoveUtilScript
    : MonoBehaviour
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private IList<ICubeCoordinates> cubeCoordinatesList = null;

        // Todo
        private ICubeCoordinates currentCubeCoordinates = null;

        // Todo
        private ITalonActionOrderReport talonActionOrderReport = null;

        // Todo
        private float timeSince = 0f;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="talonActionOrderReport">
        /// </param>
        public void AnimateTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
        {
            if (talonActionOrderReport is ITalonActionOrderReport)
            {
                logger.Debug("Setting ?", talonActionOrderReport);
                this.talonActionOrderReport = (ITalonActionOrderReport)talonActionOrderReport;
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public bool IsAnimating()
        {
            return this.talonActionOrderReport != null;
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            if (this.talonActionOrderReport != null)
            {
                if (this.cubeCoordinatesList == null)
                {
                    this.cubeCoordinatesList = this.talonActionOrderReport.GetPathObject().GetCubeCoordinatesStepList();
                }
                if (this.currentCubeCoordinates == null)
                {
                    this.timeSince = 0f;
                    this.currentCubeCoordinates = this.cubeCoordinatesList[0];
                }
                Vector3 currentCubeCoordinatesPosition = HexTileGameObjectManager.GetHexTileWorldPosition(currentCubeCoordinates);
                currentCubeCoordinatesPosition = new Vector3(currentCubeCoordinatesPosition.x, 0, currentCubeCoordinatesPosition.z);
                Vector3 currentTalonPosition = TalonGameObjectManager.GetTalonWorldPosition(this.talonActionOrderReport.GetActingTalonIdentificationReport());

                if (currentCubeCoordinatesPosition != currentTalonPosition)
                {
                    this.timeSince += Time.fixedDeltaTime;
                    Vector3 directionVector = Vector3.Lerp(currentTalonPosition, currentCubeCoordinatesPosition, this.timeSince);
                    TalonGameObjectManager.UpdateTalonWorldPosition(this.talonActionOrderReport.GetActingTalonIdentificationReport(),
                        directionVector);
                }
                else
                {
                    this.cubeCoordinatesList.Remove(this.currentCubeCoordinates);
                    if (this.cubeCoordinatesList.Count == 0)
                    {
                        GameMapObjectManager.GetHexTileObjectFrom(currentCubeCoordinates)
                            .SetOccupyingTalonIdentificationReport(this.talonActionOrderReport.GetActingTalonIdentificationReport());
                        RosterObjectManager.GetTalonObjectFrom(this.talonActionOrderReport.GetActingTalonIdentificationReport())
                            .SetCubeCoordinates(this.currentCubeCoordinates);
                        this.talonActionOrderReport = null;
                        this.cubeCoordinatesList = null;
                    }
                    this.currentCubeCoordinates = null;
                }
            }
        }
    }
}
