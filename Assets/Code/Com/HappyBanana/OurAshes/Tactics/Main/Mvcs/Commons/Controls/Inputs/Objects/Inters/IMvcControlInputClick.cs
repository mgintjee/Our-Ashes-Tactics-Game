using System.Numerics;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Controls.Inputs.Objects.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcControlInputClick
        : IMvcControlInput
    {
        Vector2 GetWorldCoords();

        int GetClickId();
    }
}