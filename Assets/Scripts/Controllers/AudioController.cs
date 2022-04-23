using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    private AudioSource[] _sources;

    protected override void Awake()
    {
        base.Awake();
        _sources = GetComponents<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        for(int i =0; i<_sources.Length; ++i)
        {
            if (!_sources[i].isPlaying)
            {
                _sources[i].clip = clip;
                _sources[i].Play();
                break;
            }
        }
    }
}
