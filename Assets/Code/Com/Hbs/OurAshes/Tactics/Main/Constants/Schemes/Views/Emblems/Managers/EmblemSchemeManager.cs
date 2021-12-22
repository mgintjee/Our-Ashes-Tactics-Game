using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Optionals;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Impls;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Schemes.Emblems.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Sprites.IDs;
using System.Collections.Generic;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Constants.Schemes.Views.Emblems.Managers
{
    /// <summary>
    /// Emblem Scheme Manager to host the Emblem Scheme Impls
    /// </summary>
    public static class EmblemSchemeManager
    {
        // Todo
        private static readonly ISet<IEmblemScheme> EmblemSchemes =
            new HashSet<IEmblemScheme>()
            {
                EmblemScheme.Builder.Get()
                    .SetEmblemSchemeID(EmblemSchemeID.Alpha)
                    .SetIconSpriteID(SpriteID.Circle)
                    .SetForegroundSpriteID(SpriteID.Circle)
                    .SetBackgroundSpriteID(SpriteID.Circle)
                    .Build(),
                EmblemScheme.Builder.Get()
                    .SetEmblemSchemeID(EmblemSchemeID.Bravo)
                    .SetIconSpriteID(SpriteID.Circle)
                    .SetForegroundSpriteID(SpriteID.Circle)
                    .SetBackgroundSpriteID(SpriteID.Circle)
                    .Build(),
                EmblemScheme.Builder.Get()
                    .SetEmblemSchemeID(EmblemSchemeID.Charlie)
                    .SetIconSpriteID(SpriteID.Circle)
                    .SetForegroundSpriteID(SpriteID.Circle)
                    .SetBackgroundSpriteID(SpriteID.Circle)
                    .Build(),
            };

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="emblemSchemeID"></param>
        /// <returns></returns>
        public static Optional<IEmblemScheme> GetScheme(EmblemSchemeID emblemSchemeID)
        {
            foreach (IEmblemScheme scheme in EmblemSchemes)
            {
                if (emblemSchemeID == scheme.GetEmblemSchemeID())
                {
                    return Optional<IEmblemScheme>.Of(scheme);
                }
            }
            return Optional<IEmblemScheme>.Empty();
        }
    }
}