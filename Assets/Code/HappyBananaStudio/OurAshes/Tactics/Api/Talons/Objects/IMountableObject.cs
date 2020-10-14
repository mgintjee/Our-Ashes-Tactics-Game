
namespace HappyBananaStudio.OurAshes.Tactics.Api.Talons.Objects
{
    using HappyBananaStudio.OurAshes.Tactics.Api.Coordinates.Objects.Cube;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Actions.Orders;
    using HappyBananaStudio.OurAshes.Tactics.Api.Talons.Reports.Attributes;
    using System.Collections.Generic;

    /// <summary>
    /// Mountable Object Api
    /// </summary>
    public interface IMountableObject
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns>
        /// </returns>
        IMountableAttributesReport GetMountableAttributesReport();

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="cubeCoordinates">
        /// </param>
        /// <returns>
        /// </returns>
        ISet<ITalonActionOrderFireReport> GetTalonActionOrderFireReportSet(ICubeCoordinates cubeCoordinates);
    }
}
