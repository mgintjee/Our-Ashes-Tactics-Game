/*
* HappyBananaStudio
* Author: Matthew Gintjee
*/

using Assets.Code.HappyBananaStudio.OurAshesTactics.Common.Enums;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.HappyBananaStudio.OurAshesTactics.Common.ResourceLoaders
{
    /// <summary>
    /// Todo
    /// </summary>
    public class SpriteResourceLoader
    {
        // Provide logging capability
        private static readonly Common.Loggers.Logger logger = new Common.Loggers.Logger(new StackFrame().GetMethod().DeclaringType);

        // Todo
        private static readonly string NULL_SPRITE_PATH = SPRITE_FOLDER_HOME + "Circle";

        // Todo
        private static readonly string SPRITE_FOLDER_HOME = "Sprites/";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath">
        /// </param>
        /// <returns>
        /// </returns>
        private static Sprite LoadSpriteResource(string spritePath)
        {
            Sprite sprite = Resources.Load<Sprite>(spritePath);
            if (sprite == null)
            {
                logger.Warn("Failed to load sprite with Path=?", spritePath);
                sprite = Resources.Load<Sprite>(NULL_SPRITE_PATH);
            }
            return sprite;
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Background
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemBackgroundId">
            /// </param>
            /// <returns>
            /// </returns>
            public static Sprite LoadSpriteBackgroundResource(EmblemBackgroundIdEnum emblemBackgroundId)
            {
                if (!emblemBackgroundId.Equals(EmblemBackgroundIdEnum.None))
                {
                    return LoadSpriteResource(SPRITE_FOLDER_HOME + emblemBackgroundId.ToString());
                }
                else
                {
                    return LoadSpriteBackgroundResource(EmblemBackgroundIdEnum.Circle);
                }
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        public class Icon
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemIconId">
            /// </param>
            /// <returns>
            /// </returns>
            public static Sprite LoadSpriteIconResource(EmblemIconIdEnum emblemIconId)
            {
                if (!emblemIconId.Equals(EmblemIconIdEnum.None))
                {
                    return LoadSpriteResource(SPRITE_FOLDER_HOME + emblemIconId.ToString());
                }
                else
                {
                    return LoadSpriteIconResource(EmblemIconIdEnum.Circle);
                }
            }
        }
    }
}