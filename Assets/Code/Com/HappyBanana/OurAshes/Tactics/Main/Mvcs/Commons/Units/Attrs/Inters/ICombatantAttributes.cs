using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Destructibles.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Fireables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Mountables.Inters;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Movables.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Units.Attrs.Inters
{
    /// <summary>
    /// Unit Attributes Interface
    /// </summary>
    public interface IUnitAttributes
    {
        IDestructibleAttributes GetDestructibleAttributes();

        IFireableAttributes GetFireableAttributes();

        IMountableAttributes GetMountableAttributes();

        IMovableAttributes GetMovableAttributes();
    }
}