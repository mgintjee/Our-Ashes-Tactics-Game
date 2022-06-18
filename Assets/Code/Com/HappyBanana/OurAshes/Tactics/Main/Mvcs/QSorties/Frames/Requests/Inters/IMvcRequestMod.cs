namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
{
    /// <summary>
    /// Todo
    /// </summary>
    public interface IMvcRequestMod
        : IQSortieMenuMvcRequest
    {
        bool IsAdd();

        bool IsMod();

        bool IsDel();
    }
}