namespace HappyBananaStudio.OurAshes.Tactics.Common.ResourceLoaders
{
    using HappyBananaStudio.OurAshes.Tactics.Common.Enums.Schemes.Emblem;
    using HappyBananaStudio.OurAshes.Tactics.Common.Utils.Exceptions;
    using System.Diagnostics;
    using UnityEngine;

    /// <summary>
    /// Todo
    /// </summary>
    public class SpriteResourceLoader
    {
        // Todo
        private static readonly string SPRITE_FOLDER_HOME = "Sprites/";

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemSpriteId">
        /// </param>
        /// <returns>
        /// </returns>
        public static Sprite LoadSpriteResource(EmblemSpriteIdEnum emblemSpriteId)
        {
            if (!emblemSpriteId.Equals(EmblemSpriteIdEnum.None))
            {
                return LoadSpriteResource(SPRITE_FOLDER_HOME + emblemSpriteId.ToString());
            }
            else
            {
                throw ArgumentExceptionUtil.Build("Unable to ?. ? is not supported.", new StackFrame().GetMethod().Name);
            }
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath">
        /// </param>
        /// <returns>
        /// </returns>
        private static Sprite LoadSpriteResource(string spritePath)
        {
            return Resources.Load<Sprite>(spritePath);
        }
    }
}