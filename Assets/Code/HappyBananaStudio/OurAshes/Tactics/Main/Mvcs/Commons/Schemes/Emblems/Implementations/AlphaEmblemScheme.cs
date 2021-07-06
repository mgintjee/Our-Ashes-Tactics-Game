using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Schemes.Emblems.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Sprites.IDs;
using Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Implementations.Abstracts;

namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Mvcs.Commons.Schemes.Emblems.Implementations
{
    /// <summary>
    /// Alpha Emblem Scheme Implementation
    /// </summary>
    public class AlphaEmblemScheme
        : AbstractEmblemScheme
    {
        /// <summary>
        /// Todo
        /// </summary>
        public AlphaEmblemScheme()
        {
            this.emblemSchemeID = EmblemSchemeID.Alpha;
            this.backgroundID = SpriteID.Circle;
            this.foregroundID = SpriteID.Circle;
            this.iconID = SpriteID.Circle;
        }
    }
}