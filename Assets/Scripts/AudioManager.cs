using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip backgroundMusic;
    public AudioClip tapSound;

    private AudioSource musicSource;
    private AudioSource sfxSource;

    

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
        musicSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        PlayBackgroundMusic();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            PlayTapSound();

    }
    void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
        else
        {
            Debug.LogError("Background Music AudioClip not assigned!");
        }
    }


    public void PlayTapSound()
    {
        if (tapSound != null)
        {
            sfxSource.PlayOneShot(tapSound);
        }
        else
        {
            Debug.LogError("Click Sound AudioClip not assigned!");
        }
    }
}