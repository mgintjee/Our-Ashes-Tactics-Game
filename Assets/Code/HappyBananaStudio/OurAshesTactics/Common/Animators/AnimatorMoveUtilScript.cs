/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Objects.Coordinates;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Api.Reports.Talons.Action;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Managers;
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
    private static readonly Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers.Logger logger =
        new Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

    private List<ICubeCoordinates> cubeCoordinatesList = null;

    private ICubeCoordinates currentCubeCoordinates = null;

    // Todo
    private ITalonActionOrderReport talonActionOrderReport = null;

    private float timeSince = 0f;

    public void AnimateTalonActionOrderReport(ITalonActionOrderReport talonActionOrderReport)
    {
        if (talonActionOrderReport.GetActionType().Equals(ActionTypeEnum.Move))
        {
            logger.Debug("Setting ?", talonActionOrderReport);
            this.talonActionOrderReport = talonActionOrderReport;
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
            Vector3 currentCubeCoordinatesPosition = GameMapObjectManager.GetHexTileObjectFrom(currentCubeCoordinates)
                .GetHexTileScript().GetTransform().position;
            currentCubeCoordinatesPosition = new Vector3(currentCubeCoordinatesPosition.x, 0, currentCubeCoordinatesPosition.z);
            Transform talonTransform = RosterObjectManager.GetTalonObjectFrom(this.talonActionOrderReport.GetActingTalonIdentificationReport())
                .GetTalonScript().GetTransform();

            if (currentCubeCoordinatesPosition != talonTransform.position)
            {
                this.timeSince += Time.fixedDeltaTime;
                Vector3 directionVector = Vector3.Lerp(talonTransform.position, currentCubeCoordinatesPosition, this.timeSince);
                talonTransform.position = directionVector;
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