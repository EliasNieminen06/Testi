using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    [SerializeField] private AudioSource MusicSource;
    [Range(0f, 1f)] public float MusicVolume = 1f;

    public static AudioManager instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        MusicSource = FindFirstObjectByType<AudioSource>();
        MusicSource.loop = false;
    }

    private AudioClip GetRandomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    private void Update()
    {
        MusicSource.volume = MusicVolume;

        if (MusicSource.isPlaying == false)
        {
            MusicSource.clip = GetRandomClip();
            MusicSource.Play();
        }
    }
}
