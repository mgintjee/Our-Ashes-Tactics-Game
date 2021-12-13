using Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Hbs.OurAshes.Tactics.Main.Commons.Builders.Scripts.Inters
{
    /// <summary>
    /// Script Builder class Interface
    /// </summary>
    public interface IBuilderScript<T> : IBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IBuilderScript<T> SetName(string name);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IBuilderScript<T> SetParent(IUnityScript unityScript);
    }
}