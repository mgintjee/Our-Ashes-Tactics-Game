namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.ResourceLoaders.Sprites
{
    using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Frameworks.Models.Talons.Customizations.Emblem.Enums;
    using HappyBananaStudio.OurAshes.Tactics.Main.Common.Exceptions;
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
        public static Sprite LoadSpriteResource(EmblemId emblemSpriteId)
        {
            if (emblemSpriteId != EmblemId.None)
            {
                return LoadSpriteResource(SPRITE_FOLDER_HOME + emblemSpriteId.ToString());
            }
            else
            {
                throw ExceptionUtil.Argument.Build("Unable to ?. ? is not supported.", new StackFrame().GetMethod().Name);
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