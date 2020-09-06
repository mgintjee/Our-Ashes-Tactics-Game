
using System;

/// <summary>
/// Todo
/// </summary>
public class RandomNumberGeneratorUtil
{
    #region Private Fields

    // Todo
    private static Random random = null;

    // Todo
    private static int seed = 22;

    #endregion Private Fields

    #region Public Methods

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static float GetNextFloat()
    {
        return GetNextInt(100) / 100f;
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <returns></returns>
    public static int GetNextInt()
    {
        return random.Next();
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static int GetNextInt(int upperBound)
    {
        return random.Next(upperBound);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="lowerBound"></param>
    /// <param name="upperBound"></param>
    /// <returns></returns>
    public static int GetNextInt(int lowerBound, int upperBound)
    {
        return random.Next(lowerBound, upperBound);
    }

    /// <summary>
    /// Todo
    /// </summary>
    /// <param name="newSeed"></param>
    public static void SetSeed(int newSeed)
    {
        seed = newSeed;
        BuildRandom();
    }

    #endregion Public Methods

    #region Private Methods

    /// <summary>
    /// Todo
    /// </summary>
    private static void BuildRandom()
    {
        // Check that the Random is non-null
        if (random == null)
        {
            // Build the Random object with the seed
            random = new Random(seed);
        }
    }

    #endregion Private Methods
}