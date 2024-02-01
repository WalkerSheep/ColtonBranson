using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject AudioHolder;
    public AudioSource MusicSource;
    [Range(0,1)]
    public float MusicVolume = 0.1f;
    [Range(0,1)]
    public float SFXVolume = 1;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MusicSource.volume = MusicVolume;
        
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void PlaySound(AudioClip clip,Vector3 position,float MinRandom = 0.9f,float MaxRandom = 1.2f)
    {
        GameObject spawned = Instantiate(AudioHolder,position,Quaternion.identity);
        AudioSource source = spawned.GetComponent<AudioSource>();
        source.clip = clip;
        source.pitch = Random.Range(MinRandom,MaxRandom);
        source.volume = SFXVolume;
        source.Play();
        Destroy(spawned,clip.length);
    }
}
