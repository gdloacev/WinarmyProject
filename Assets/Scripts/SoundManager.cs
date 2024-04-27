using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource _audioSFX = null;
    [SerializeField] AudioSource _audioMusic = null;
    [SerializeField] List<AudioClip> _SFXClips = new();
    [SerializeField] List<AudioClip> _MusicClips = new();

    public void PlayMusic(int index, bool loop = false) { 
        _audioMusic.Stop();
        _audioMusic.clip = _MusicClips[index];
        _audioMusic.loop = loop;
        _audioMusic.Play();
    }

    public void PlayOneShot(int index) => _audioMusic.PlayOneShot(_SFXClips[index]);
}
