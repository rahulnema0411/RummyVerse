using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip coinCollectionSound;
    public AudioClip backgroundMusic;
    public AudioClip keyCollectionSound;
    public AudioClip levelCompleteSound;
    public AudioClip playerHurtSound;
    public AudioClip gameWinSound;

    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectSource;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            backgroundMusicSource = gameObject.AddComponent<AudioSource>();
            soundEffectSource = gameObject.AddComponent<AudioSource>();
            
            backgroundMusicSource.clip = backgroundMusic;
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void PlayCoinCollectionSound()
    {
        soundEffectSource.PlayOneShot(coinCollectionSound);
    }

    public void PlayKeyCollectionSound()
    {
        soundEffectSource.PlayOneShot(keyCollectionSound);
    }

    public void PlayGameWinSound()
    {
        soundEffectSource.PlayOneShot(gameWinSound);
    }

    public void PlayLevelCompleteSound()
    {
        soundEffectSource.PlayOneShot(levelCompleteSound);
    }

    public void PlayPlayerHurtSound()
    {
        soundEffectSource.PlayOneShot(playerHurtSound);
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = volume;
    }
    
    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectSource.volume = volume;
    }
}
