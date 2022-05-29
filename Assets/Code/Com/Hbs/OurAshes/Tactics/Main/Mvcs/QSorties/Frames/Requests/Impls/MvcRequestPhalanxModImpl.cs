using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Factions.IDs;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Phalanxes.Details.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class MvcRequestPhalanxModImpl
        : MvcRequestImpl, IMvcRequestPhalanxMod
    {
        private bool isAdd = false;
        private bool isDel = false;
        private bool isMod = false;
        private FactionID factionID = FactionID.None;

        public MvcRequestPhalanxModImpl SetFactionID(FactionID factionID)
        {
            this.factionID = factionID;
            return this;
        }

        public MvcRequestPhalanxModImpl SetIsAdd()
        {
            this.isAdd = true;
            this.isDel = false;
            this.isMod = false;
            return this;
        }

        public MvcRequestPhalanxModImpl SetIsMod()
        {
            this.isAdd = false;
            this.isDel = false;
            this.isMod = true;
            return this;
        }

        public MvcRequestPhalanxModImpl SetIsDel()
        {
            this.isAdd = false;
            this.isDel = true;
            this.isMod = false;
            return this;
        }

        bool IMvcRequestMod.IsAdd()
        {
            return this.isAdd;
        }

        bool IMvcRequestMod.IsDel()
        {
            return this.isDel;
        }

        bool IMvcRequestMod.IsMod()
        {
            return this.isMod;
        }

        FactionID IMvcRequestPhalanxMod.GetFactionID()
        {
            return this.factionID;
        }

        IPhalanxDetails IMvcRequestPhalanxMod.GetPhalanxDetails()
        {
            throw new System.NotImplementedException();
        }
    }
}