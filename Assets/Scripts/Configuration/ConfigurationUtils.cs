using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    public static ConfigurationData confData;
    #region Properties
    
    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return confData.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return confData.BallImpulseForce;  }
    }

    public static float BallLifeTime
    {
        get { return confData.BallLifeTime; }
    }

    public static float MinSpawnTime
    {
        get { return confData.MinSpawnTime; }
    }

    public static float MaxSpawnTime
    {
        get { return confData.MaxSpawnTime; }
    }

    public static float StandardBlockPoints
    {
        get { return confData.StandardBlockPoints; }
    }

    public static float BonusBlockPoints
    {
        get { return confData.BonusBlockPoints; }
    }

    public static float PickupBlockPoints
    {
        get { return confData.PickupBlockPoints; }
    }

    public static float StandardBlockProb
    {
        get { return confData.StandardBlockProb; }
    }

    public static float BonusBlockProb
    {
        get { return confData.BonusBlockProb; }
    }

    public static float PickupBlockProb
    {
        get { return confData.PickupBlockProb; }
    }

    public static float BallsRemaining
    {
        get { return confData.BallsRemaining; }
    }

    public static float FreezeDuration
    {
        get { return confData.FreezeDuaration; }
    }

    public static float SpeedupDuration
    {
        get { return confData.SpeedupDuration; }
    }

    public static float SpeedupFactor
    {
        get { return confData.SpeedupFactor; }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        confData = new ConfigurationData();
    }
}
