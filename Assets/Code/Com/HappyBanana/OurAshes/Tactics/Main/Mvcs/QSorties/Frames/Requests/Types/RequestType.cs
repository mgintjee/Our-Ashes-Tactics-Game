namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Types
{
    /// <summary>
    /// Todo
    /// </summary>
    public enum RequestType
    {
        None,

        PopUpDisable,

        DetailsField,
        DetailsPhalanx,
        DetailsSortie,
        DetailsUnit,
        DetailsFaction,

        FieldIDSelect,
        FieldIDPopUp,
        FieldBiomeSelect,
        FieldBiomePopUp,
        FieldSizeSelect,
        FieldSizePopUp,
        FieldShapeSelect,
        FieldShapePopUp,
        FieldRandomize,

        FactionIDSelect,
        FactionIDPopUp,
        FactionPhalanxIDMinusPopUp,
        FactionPhalanxIDAddPopUp,
        FactionPhalanxIDMinusMod,
        FactionPhalanxIDAddMod,

        PhalanxIDSelect,
        PhalanxIDPopUp,
        PhalanxUnitIDAddPopUp,
        PhalanxUnitIDAddMod,
        PhalanxUnitIDMinusPopUp,
        PhalanxUnitIDMinusMod,

        UnitIDPopUp,
        UnitIDSelect,
        UnitModelIDPopUp,
        UnitArmorGearIDPopUp,
        UnitCabinGearIDPopUp,
        UnitEngineGearIDPopUp,
        UnitWeaponGearIDAddPopUp,
        UnitWeaponGearIDMinusPopUp,

        SortieStart,
        FactionRandomize,
        UnitMod,
        SortieRandomize,
        UnitModelIDSelect,
    }
}