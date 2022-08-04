using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{    
    public List<MusicSetup> musicSetups;
    public List<VFXSetup> vFXSetups;

    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public VFXSetup GetVFXByType(VFXType vFXType)
    {
        return vFXSetups.Find(i => i.vFXType == vFXType);
    }
}

public enum MusicType
{
    TYPE_01,
    TYPE_02,
    TYPE_03
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip audioClip;
}


public enum VFXType
{
    TYPE_01,
    TYPE_02,
    TYPE_03
}

[System.Serializable]
public class VFXSetup
{
    public VFXType vFXType;
    public AudioClip audioClip;
}