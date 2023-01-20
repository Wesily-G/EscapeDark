using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource soundSource;
    public AudioSource bgmSource;
    
    public void playSoundOnce(string soundPath){
        AudioClip clip = (AudioClip)Resources.Load(soundPath);
        if(clip != null){
            soundSource.PlayOneShot(clip);
        }else{
            Debug.Log("Error sound path");
        }
    }
    public void changeBGM(string soundPath){
        AudioClip clip = (AudioClip)Resources.Load(soundPath);
        if (clip != null) {
            bgmSource.clip = clip;
        } else {
            Debug.Log("Error sound path");
        }
    }

}
