using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initializes the game
/// </summary>
public class GameInitializer : MonoBehaviour 
{
    /// <summary>
    /// Awake is called before Start
    /// </summary>
	void Awake()
    {
        // EffectUtils
        EffectUtils.speedUpEffectMonitor = Camera.main.GetComponent<SpeedUpEffectMonitor>();

        // Clear Event Manager
        EventManager.clearAll();

        // initialize screen utils
        ScreenUtils.Initialize();

        // initialize configuration utils
        ConfigurationUtils.Initialize();
    }
}
