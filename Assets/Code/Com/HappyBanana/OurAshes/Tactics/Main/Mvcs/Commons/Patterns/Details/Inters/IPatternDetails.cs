using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Views.Canvases.Colors.IDs;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Patterns.Details.Inters
{
    public interface IPatternDetails
    {
        ColorID GetPrimaryColorID();

        ColorID GetSecondaryColorID();

        ColorID GetTertiaryColorID();
    }
}