using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Sizes;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Constants.Phalanxes
{
    /// <summary>
    /// Todo
    /// </summary>
    public class PhalanxCountConstants
    {
        private static readonly int SMALL_MAX_PHALANX_COUNT = 4;
        private static readonly int MEDIUM_MAX_PHALANX_COUNT = 4;
        private static readonly int LARGE_MAX_PHALANX_COUNT = 6;

        public static int GetMaxPhalanxCounts(FieldSize fieldSize)
        {
            switch (fieldSize)
            {
                case FieldSize.Small:
                    return SMALL_MAX_PHALANX_COUNT;

                case FieldSize.Medium:
                    return MEDIUM_MAX_PHALANX_COUNT;

                case FieldSize.Large:
                    return LARGE_MAX_PHALANX_COUNT;

                case FieldSize.None:
                default:
                    return 0;
            }
        }
    }
}