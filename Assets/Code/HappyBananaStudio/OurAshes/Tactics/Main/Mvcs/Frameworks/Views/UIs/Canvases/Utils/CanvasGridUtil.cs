namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Utils
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Exceptions;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Constants;
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Views.UIs.Canvases.Coordinates.Canvas.Api;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class CanvasGridUtil
    {
        // Todo: Move constants to some constants file
        // Todo
        private static readonly int maxCols = CanvasGridConstants.GetMaxCols();

        // Todo
        private static readonly int maxRows = CanvasGridConstants.GetMaxRows();

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
        /// <returns></returns>
        public static int GetMaxRows()
        {
            return maxRows;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static int GetMaxCols()
        {
            return maxCols;
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
                return new Vector2(canvasGridDimensions.GetX() * canvasWidthStep,
                    canvasGridDimensions.GetY() * canvasHeightStep);
            }
            else
            {
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid parameters. " +
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
        public static Vector2 GetWidgetPositionFrom(ICanvasGridCoordinates canvasGridPosition,
            ICanvasGridCoordinates canvasGridDimensions)
        {
            if (canvasGridPosition.GetY() <= maxRows &&
                canvasGridPosition.GetX() <= maxCols &&
                canvasGridPosition.GetY() >= 0 &&
                canvasGridPosition.GetX() >= 0)
            {
                // Todo: Should have the positions always be the top left/right of the widget
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
                throw ExceptionUtil.Arguments.Build("Unable to ?. Invalid parameters. " +
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