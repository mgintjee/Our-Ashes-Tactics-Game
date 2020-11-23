namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Canvas;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WidgetGridUtil
    {
        // Todo
        private static readonly float maxCols = 9;

        // Todo
        private static readonly float maxRows = 7;

        // Todo
        private static float canvasHeight = int.MinValue;

        // Todo
        private static float canvasHeightStep = int.MinValue;

        // Todo
        private static float canvasWidth = int.MinValue;

        // Todo
        private static float canvasWidthStep = int.MinValue;

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetCanvasHeight()
        {
            return canvasHeight;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetCanvasHeightStep()
        {
            return canvasHeightStep;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetCanvasWidth()
        {
            return canvasWidth;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        public static float GetCanvasWidthStep()
        {
            return canvasWidthStep;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetWidgetDimensionsFrom(ICanvasGridCoordinates canvasGridDimensions)
        {
            if (canvasGridDimensions.GetY() <= maxRows &&
                canvasGridDimensions.GetX() <= maxCols &&
                canvasGridDimensions.GetY() >= 0 &&
                canvasGridDimensions.GetX() >= 0)
            {
                return new Vector2(canvasGridDimensions.GetX() * canvasWidthStep, canvasGridDimensions.GetY() * canvasHeightStep);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "\n\t>Row=? < MaxRows=?" +
                    "\n\t>Col=? < MaxCols=?",
                    new StackFrame().GetMethod().Name,
                    canvasGridDimensions.GetY(), maxRows, canvasGridDimensions.GetX(), maxCols);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="canvasGridPosition">
        /// </param>
        /// <param name="canvasGridDimensions">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vector2 GetWidgetPositionFrom(ICanvasGridCoordinates canvasGridPosition, ICanvasGridCoordinates canvasGridDimensions)
        {
            if (canvasGridPosition.GetY() <= maxRows &&
                canvasGridPosition.GetX() <= maxCols &&
                canvasGridPosition.GetY() >= 0 &&
                canvasGridPosition.GetX() >= 0)
            {
                Vector2 canvasPosition = new Vector2(
                    (canvasGridPosition.GetX() * canvasWidthStep) - canvasWidth / 2,
                    (canvasGridPosition.GetY() * canvasHeightStep) - canvasHeight / 2);
                Vector2 widgetDimensions = GetWidgetDimensionsFrom(canvasGridDimensions);
                if (canvasPosition.x > 0)
                {
                    canvasPosition.x -= widgetDimensions.x / 2;
                }
                else
                {
                    canvasPosition.x += widgetDimensions.x / 2;
                }
                if (canvasPosition.y > 0)
                {
                    canvasPosition.y -= widgetDimensions.y / 2;
                }
                else
                {
                    canvasPosition.y += widgetDimensions.y / 2;
                }
                return canvasPosition;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "\n\t>Row=? < MaxRows=?" +
                    "\n\t>Col=? < MaxCols=?",
                    new StackFrame().GetMethod().Name,
                    canvasGridPosition.GetY(), maxRows, canvasGridPosition.GetX(), maxCols);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newCanvasHeight">
        /// </param>
        public static void SetCanvasHeight(float newCanvasHeight)
        {
            canvasHeight = newCanvasHeight;
            canvasHeightStep = canvasHeight / maxRows;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newCanvasWidth">
        /// </param>
        public static void SetCanvasWidth(float newCanvasWidth)
        {
            canvasWidth = newCanvasWidth;
            canvasWidthStep = canvasWidth / maxCols;
        }
    }
}