using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
    static float paddleMoveUnitsPerSecond = 10;
    static float ballImpulseForce = 200;
    static float ballLifeTime = 10;
    static float minSpawnTime = 5;
    static float maxSpawnTime = 10;
    static float standardBlockPoints = 1;
    static float bonusBlockPoints = 2;
    static float pickupBlockPoints = 5;
    static float standardBlockProb = 0.75f;
    static float bonusBlockProb = 0.1f;
    static float pickupBlockProb = 0.15f;
    static float ballsRemaining = 17;
    static float freezeDuration = 2;
    static float speedupDuration = 2;
    static float speedupFactor = 2;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    /// <summary>
    /// Gets the duration the ball will remain present
    /// </summary>
    public float BallLifeTime
    {
        get { return ballLifeTime; }
    }

    public float MinSpawnTime
    {
        get { return minSpawnTime; }
    }

    public float MaxSpawnTime
    {
        get { return maxSpawnTime; }
    }

    public float StandardBlockPoints
    {
        get { return standardBlockPoints; }
    }

    public float BonusBlockPoints
    {
        get { return bonusBlockPoints; }
    }

    public float PickupBlockPoints
    {
        get { return pickupBlockPoints; }
    }

    public float StandardBlockProb
    {
        get { return standardBlockProb; }
    }

    public float BonusBlockProb
    {
        get { return bonusBlockProb; }
    }

    public float PickupBlockProb
    {
        get { return pickupBlockProb; }
    }

    public float BallsRemaining
    {
        get { return ballsRemaining; }
    }

    public float FreezeDuaration
    {
        get { return freezeDuration; }
    }

    public float SpeedupDuration
    {
        get { return speedupDuration; }
    }

    public float SpeedupFactor
    {
        get { return speedupFactor; }
    }
    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        StreamReader input = null;

        try
        {
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));
            string names = input.ReadLine();
            string values = input.ReadLine();

            setConfigurationDataFieldValues(values);
        }
        catch (Exception e)
        {

        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }

    void setConfigurationDataFieldValues(string values)
    {
        string[] vals = values.Split(',');
        paddleMoveUnitsPerSecond = float.Parse(vals[0]);
        ballImpulseForce = float.Parse(vals[1]);
        ballLifeTime = float.Parse(vals[2]);
        minSpawnTime = float.Parse(vals[3]);
        maxSpawnTime = float.Parse(vals[4]);
        standardBlockPoints = float.Parse(vals[5]);
        bonusBlockPoints = float.Parse(vals[6]);
        pickupBlockPoints = float.Parse(vals[7]);
        standardBlockProb = float.Parse(vals[8]);
        bonusBlockProb = float.Parse(vals[9]);
        pickupBlockProb = float.Parse(vals[10]);
        ballsRemaining = float.Parse(vals[11]);
        freezeDuration = float.Parse(vals[12]);
        speedupDuration = float.Parse(vals[13]);
        speedupFactor = float.Parse(vals[14]);
    }

    #endregion
}
