using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Commons.Builders.Inters;
using Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Unity.Inters;

namespace Assets.Code.Com.Hbs.OurAshes.Tactics.Main.Mvcs.Commons.Scripts.Builders.Inters
{
    /// <summary>
    /// Script Builder class Interface
    /// </summary>
    public interface IScriptBuilder<T>
        : IBuilder<T>
    {
        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScriptBuilder<T> SetName(string name);

        /// <summary>
        /// Todo
        /// </summary>
        /// <returns></returns>
        IScriptBuilder<T> SetParent(IUnityScript unityScript);
    }
}