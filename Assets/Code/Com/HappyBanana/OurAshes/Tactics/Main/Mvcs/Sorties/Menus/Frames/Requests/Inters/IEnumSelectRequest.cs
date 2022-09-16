using System;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Sorties.Menus.Frames.Requests.Inters
{
    public interface IEnumSelectRequest<TEnum>
        : IQSortieMenuMvcRequest
        where TEnum : Enum
    {
        TEnum GetEnum();

        Type GetEnumType();
    }
}