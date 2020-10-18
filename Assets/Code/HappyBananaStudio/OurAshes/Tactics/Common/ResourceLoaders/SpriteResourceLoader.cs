

namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Loggers;
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Impl.Loggers;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class SpriteResourceLoader
    {
        // Provide logging capability
        private static readonly ICodeLogger logger = new CodeLoggerImpl(new StackFrame().GetMethod().DeclaringType);

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
        public class Foreground
        {
            /// <summary>
            /// Todo
            /// </summary>
            /// <param name="emblemBackgroundId">
            /// </param>
            /// <returns>
            /// </returns>
            public static Sprite LoadSpriteForegroundResource(EmblemForegroundIdEnum emblemBackgroundId)
            {
                if (!emblemBackgroundId.Equals(EmblemForegroundIdEnum.None))
                {
                    return LoadSpriteResource(SPRITE_FOLDER_HOME + emblemBackgroundId.ToString());
                }
                else
                {
                    return LoadSpriteForegroundResource(EmblemForegroundIdEnum.Circle);
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
