using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public enum AudioType
    {
        HEART_BEAT,
        SILENT_ROOM,
        WINDMILL_IN_GARDEN
    }

    public AudioSource heartBeat;
    public AudioSource silentRoom;
    public AudioSource WindmillInGarden;

    void Awake()
    {
        instance = this;
    }

    public void Play(AudioType audioType)
    {
        StopAll();
        switch (audioType)
        {
            case AudioType.HEART_BEAT:
                heartBeat.Play();
                break;
            case AudioType.SILENT_ROOM:
                silentRoom.Play();
                break;
            case AudioType.WINDMILL_IN_GARDEN:
                WindmillInGarden.Play();
                break;
        }
    }

    public void StopAll()
    {
        heartBeat.Stop();
        silentRoom.Stop();
        WindmillInGarden.Stop();
    }

    public void ChangeVolume(float volume)
    {
        heartBeat.volume = volume;
        silentRoom.volume = volume;
        WindmillInGarden.volume = volume;
    }

    public float GetVolume()
    {
        return heartBeat.volume;
    }

    public void ChangePitch(float pitch)
    {
        heartBeat.pitch = pitch;
        silentRoom.pitch = pitch;
        WindmillInGarden.pitch = pitch;
    }
}