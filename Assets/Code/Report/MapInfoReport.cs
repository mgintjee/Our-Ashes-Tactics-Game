using System;

/// <summary>
/// Todo
/// </summary>
public class MapInfoReport
{
    #region Private Fields

    private readonly int mapSeed = -1;
    private readonly int mapRadius = -1;
    private readonly bool mapMirrored;

    #endregion Private Fields

    #region Private Constructors

    private MapInfoReport(int mapSeed, int mapRadius, bool mapMirrored)
    {
        this.mapSeed = mapSeed;
        this.mapRadius = mapRadius;
        this.mapMirrored = mapMirrored;
    }

    #endregion Private Constructors

    #region Public Methods

    public int GetMapSeed()
    {
        return this.mapSeed;
    }

    public int GetMapRadius()
    {
        return this.mapRadius;
    }

    public bool GetMapMirrored()
    {
        return this.mapMirrored;
    }

    #endregion Public Methods

    #region Public Classes

    public class Builder
    {
        #region Private Fields

        private int mapSeed = -1;
        private int mapRadius = -1;
        private bool mapMirrored;
        private bool setMapMirrored = false;

        #endregion Private Fields

        #region Public Methods

        public MapInfoReport Build()
        {
            // Check that the MapSeed has been set
            if (this.mapSeed < 0 ||
                // Check that the MapRadius has been set and is valid
                this.mapRadius < 2 ||
                // Check that the MapMirrored has been set
                !setMapMirrored)
            {
                throw new ArgumentException("Unable to construct ?" +
                    this.GetType() + ". Invalid Parameters." +
                    "\n>mapSeed=" + this.mapSeed +
                    "\n>mapRadius=" + this.mapRadius +
                    "\n>setMapMirrored=" + this.setMapMirrored);
            }
            return new MapInfoReport(this.mapSeed, this.mapRadius, this.mapMirrored);
        }

        public Builder SetMapSeed(int mapSeed)
        {
            this.mapSeed = mapSeed;
            return this;
        }

        public Builder SetMapRadius(int mapRadius)
        {
            this.mapRadius = mapRadius;
            return this;
        }

        public Builder SetMapMirrored(bool mapMirrored)
        {
            this.mapMirrored = mapMirrored;
            this.setMapMirrored = true;
            return this;
        }

        #endregion Public Methods
    }

    #endregion Public Classes
}