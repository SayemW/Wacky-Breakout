using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    public static bool Initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        Initialized = true;
        audioSource = source;
        if (audioClips.Count == 0)
        {
            audioClips.Add(AudioClipName.MenuHover,
            Resources.Load<AudioClip>("NeonHum"));
            audioClips.Add(AudioClipName.MenuClick,
                Resources.Load<AudioClip>("lightOn"));
            audioClips.Add(AudioClipName.BlockHit,
                Resources.Load<AudioClip>("BreakBlock"));
            audioClips.Add(AudioClipName.Freeze,
                Resources.Load<AudioClip>("freeze"));
            audioClips.Add(AudioClipName.SpeedUp,
                Resources.Load<AudioClip>("foom_0"));
            audioClips.Add(AudioClipName.PadHit,
                Resources.Load<AudioClip>("qubodupImpactWood"));
            audioClips.Add(AudioClipName.Music,
                Resources.Load<AudioClip>("BitGameSound"));
        }    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
