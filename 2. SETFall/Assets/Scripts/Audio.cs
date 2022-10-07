using UnityEngine;
using System;
public class Audio : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        //for each sound clip set the clip, volume and pitch
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    //play the audio clip
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    //stop the audio clip
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
