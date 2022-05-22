namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters
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