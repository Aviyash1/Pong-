using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Sound Effects")]
    public AudioClip paddleHit;
    public AudioClip wallHit;
    public AudioClip winP1;
    public AudioClip winP2;

    [Header("Music")]
    public AudioClip bgm;

    [Header("Volume Settings")]
    [Range(0f, 1f)] public float musicVolume = 0.25f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic();
    }

    // Paddle hit
    public void PlayPaddleHit()
    {
        if (paddleHit != null && sfxSource != null)
        {
            sfxSource.pitch = Random.Range(0.95f, 1.05f);
            sfxSource.PlayOneShot(paddleHit, sfxVolume);
        }
    }

    // Wall hit
    public void PlayWallHit()
    {
        if (wallHit != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(wallHit, sfxVolume);
        }
    }

    // Player 1 win
    public void PlayWinP1()
    {
        if (winP1 != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(winP1, sfxVolume);
        }
    }

    // Player 2 win
    public void PlayWinP2()
    {
        if (winP2 != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(winP2, sfxVolume);
        }
    }

    // Background music
    public void PlayMusic()
    {
        if (bgm != null && musicSource != null)
        {
            musicSource.clip = bgm;
            musicSource.loop = true;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    // Toggle all sound
    public void ToggleSound(bool value)
    {
        AudioListener.volume = value ? 1f : 0f;
    }

    // Change music volume at runtime (optional for sliders)
    public void SetMusicVolume(float value)
    {
        musicVolume = value;

        if (musicSource != null)
            musicSource.volume = musicVolume;
    }

    // Change SFX volume at runtime (optional for sliders)
    public void SetSFXVolume(float value)
    {
        sfxVolume = value;
    }
}