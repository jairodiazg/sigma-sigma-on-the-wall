using UnityEngine;
using UnityEngine.UI; // Required for Slider

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] Slider musicVolumeSlider;

    public AudioClip bgMusic;
    public AudioClip bgAmbiance;
    public AudioClip playerRun;
    public AudioClip playerAtkMiss;
    public AudioClip playerAtkHit;

    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    private void Start()
    {
        musicSource.clip = bgMusic;

        // Load saved volume or default to 0.5
        float savedVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 0.5f);

        // Prevent it from starting at 0 due to missing saved value
        if (savedVolume <= 0.01f)
            savedVolume = 0.5f;

        musicSource.volume = savedVolume;

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = savedVolume;
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        }

        musicSource.Play();
    }


    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        PlayerPrefs.Save(); // Save immediately
    }

}
