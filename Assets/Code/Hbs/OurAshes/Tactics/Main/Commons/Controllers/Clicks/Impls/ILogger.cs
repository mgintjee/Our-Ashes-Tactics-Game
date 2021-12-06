using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Controllers.Clicks.Impls
{
    /// <summary>
    /// Click Interface
    /// </summary>
    public struct Click : IClick
    {
        private readonly float x;
        private readonly float y;

        float IClick.GetX()
        {
            return x;
        }

        float IClick.GetY()
        {
            return y;
        }
    }
}