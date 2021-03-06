using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;
    public AudioSource musicSource;

    public float lowPitchRange = .95f;
    public float hightPitchRange = 1.05f;

    public static SoundManager instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;

        efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clip)
    {
        int randomIdx = Random.Range(0, clip.Length);

        float randomPitch = Random.Range(lowPitchRange, hightPitchRange);

        efxSource.pitch = randomPitch;

        efxSource.clip = clip[randomIdx];

        efxSource.Play();

    }
    
}
