namespace Assets.Code.HappyBananaStudio.OurAshes.Tactics.Main.Commons.Models.Maps.Coordinates.Offset.Interfaces
{
    /// <summary>
    /// Offset Coordinates Interface
    /// </summary>
    public interface IOffsetCoordinates
    {
        int GetCol();

        OffsetCoordinateType GetOffsetCoordinateType();

        int GetRow();
    }
}