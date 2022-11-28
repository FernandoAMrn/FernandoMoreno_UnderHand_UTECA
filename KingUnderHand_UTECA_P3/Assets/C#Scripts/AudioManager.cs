using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AudioClip_Soundtracks
{
    SONG_1, SONG_2
}

public enum AudioClip_SFX
{
    CARD_ATTK, CARD_DF, CARD_DEATH, CARD_PICKUP, CARD_PLACE, VICTORY_B, VICTORY_W
}
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource audioSource;
    public AudioSource audioSourceEffectRfr;

    public AudioClip[] audioClipsSoundtrack;
    public AudioClip[] audioClipsSFX;

    public float soundTrackVolume;
    public float sfxVolume;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        else
        {
            instance = this;
        }
    }
  

    public void SetAudioClipSoundtrack(AudioClip_Soundtracks audioClip_Soundtracks)
    {
        audioSource.Stop();
        audioSource.PlayDelayed(0.5f);
        audioSource.PlayOneShot(audioClipsSoundtrack[(int)audioClip_Soundtracks], soundTrackVolume);
    }

    public void SetAudioClipSFX(AudioClip_SFX audioClip_SFX)
    {
        audioSource.Stop();
        audioSource.PlayOneShot(audioClipsSFX[(int)audioClip_SFX], sfxVolume);
    }
}
