
namespace HappyBananaStudio.OurAshes.Tactics.Common.Utils.Widgets
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Diagnostics;
    using System.Runtime.InteropServices.WindowsRuntime;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public static class WidgetGridUtil
    {
        // Todo
        private static readonly float maxRows = 7;
        // Todo
        private static readonly float maxCols = 9;
        // Todo
        private static float canvasWidth = int.MinValue;
        // Todo
        private static float canvasHeight = int.MinValue;
        // Todo
        private static float canvasWidthStep = int.MinValue;
        // Todo
        private static float canvasHeightStep = int.MinValue;
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newCanvasWidth"></param>
        public static void SetCanvasWidth(float newCanvasWidth)
        {
            canvasWidth = newCanvasWidth;
            canvasWidthStep = canvasWidth / maxCols;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="newCanvasHeight"></param>
        public static void SetCanvasHeight(float newCanvasHeight)
        {
            canvasHeight = newCanvasHeight;
            canvasHeightStep = canvasHeight / maxRows;
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static float GetCanvasHeight()
        {
            return canvasHeight;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        public static float GetCanvasWidth()
        {
            return canvasWidth;
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="dimensionCoordinates"></param>
        /// <returns></returns>
        public static Vector2 GetWidgetDimensionsFrom(Vector2 dimensionCoordinates)
        {
            if (dimensionCoordinates.y <= maxRows &&
                dimensionCoordinates.x <= maxCols &&
                dimensionCoordinates.y >= 0 &&
                dimensionCoordinates.x >= 0)
            {
                return new Vector2(dimensionCoordinates.x * canvasWidthStep, dimensionCoordinates.y * canvasHeightStep);
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "\n\t>Row=? < MaxRows=?" +
                    "\n\t>Col=? < MaxCols=?",
                    new StackFrame().GetMethod().Name,
                    dimensionCoordinates.y, maxRows, dimensionCoordinates.x, maxCols);
            }
        }
        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="positionCoordinates"></param>
        /// <param name="dimensionCoordinates"></param>
        /// <returns></returns>
        public static Vector2 GetWidgetPositionFrom(Vector2 positionCoordinates, Vector2 dimensionCoordinates)
        {
            if (positionCoordinates.y <= maxRows &&
                positionCoordinates.x <= maxCols &&
                positionCoordinates.y >= 0 &&
                positionCoordinates.x >= 0)
            {
                Vector2 canvasPosition = new Vector2((positionCoordinates.x * canvasWidthStep) - canvasWidth/2,
                    (positionCoordinates.y * canvasHeightStep) - canvasHeight / 2);
                Vector2 widgetDimensions = GetWidgetDimensionsFrom(dimensionCoordinates);
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
                    canvasPosition.y -= widgetDimensions.y/ 2;
                }
                else
                {
                    canvasPosition.y+= widgetDimensions.y / 2;
                }
                return canvasPosition;
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. Invalid parameters. " +
                    "\n\t>Row=? < MaxRows=?" +
                    "\n\t>Col=? < MaxCols=?",
                    new StackFrame().GetMethod().Name,
                    positionCoordinates.y, maxRows, positionCoordinates.x, maxCols);
            }
        }
    }
}
