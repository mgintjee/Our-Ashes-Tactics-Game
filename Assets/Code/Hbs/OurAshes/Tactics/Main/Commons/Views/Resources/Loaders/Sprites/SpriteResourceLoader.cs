using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Exceptions.Utils;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Sprites.IDs;
using System.Diagnostics;
using UnityEngine;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Views.Resources.Loaders.Sprites
{
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
        /// <param name="spriteID"></param>
        /// <returns></returns>
        public static Optional<Sprite> LoadSpriteResource(SpriteID spriteID)
        {
            if (spriteID != SpriteID.None)
            {
                return Optional<Sprite>.Of(LoadSpriteResource(SPRITE_FOLDER_HOME + spriteID.ToString()));
            }
            throw ExceptionUtil.Arguments.Build("Unable to {}. {} is not supported.", new StackFrame().GetMethod().Name);
        }

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="spritePath"></param>
        /// <returns></returns>
        private static Sprite LoadSpriteResource(string spritePath)
        {
            return UnityEngine.Resources.Load<Sprite>(spritePath);
        }
    }
}