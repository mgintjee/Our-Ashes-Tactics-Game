using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.Commons.Fields.Biomes;
using Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Inters;

namespace Assets.Code.Com.HappyBanana.OurAshes.Tactics.Main.Mvcs.QSorties.Frames.Requests.Impls
{
    /// <summary>
    /// Todo
    /// </summary>
    public class FieldBiomeModRequestImpl
        : DefaultRequestImpl, IFieldBiomeModRequest
    {
        // Todo
        private FieldBiome fieldBiome = FieldBiome.None;

        /// <summary>
        /// Todo
        /// </summary>
        /// <param name="fieldBiome"></param>
        public FieldBiomeModRequestImpl SetFieldBiome(FieldBiome fieldBiome)
        {
            this.fieldBiome = fieldBiome;
            return this;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("{0}: Biome:{1}",
                this.GetType().Name, this.fieldBiome);
        }

        /// <inheritdoc/>
        FieldBiome IFieldBiomeModRequest.GetFieldBiome()
        {
            return this.fieldBiome;
        }
    }
}