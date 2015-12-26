using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class to control audio effects for the game
/// </summary>
public class AudioManager : MonoBehaviour {
    
    public enum SFX
    {
        CLICK,
        CORRECT_ANSWER,
        WRONG_ANSWER,
        LEVEL_FAILED,
        LEVEL_CLEARED
    }
    
    public static AudioManager Instance;
    private Coroutine _backgroundVolumeCoroutine;
    private AudioSource _backgroundMusic;
    private bool _isMute;
    public bool IsMute
    {
        get
        {
            return _isMute;
        }
        set
        {
            _isMute = value;
            SetBackgroundMusicMute(_isMute);
        }
    }

    AudioSource[] _audioSources;

    void Awake () {
        if (Instance == null)
        {
            Instance = this;
            _audioSources = GetComponents<AudioSource>();
            _backgroundMusic =  _audioSources[0];
            IsMute = (PlayerPrefs.GetInt(GameConstants.MUTE_KEY) == 0) ? false : true;
            
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public void SetBackgroundMusicMute(bool mute)
    {
        if (!mute)
            _backgroundMusic.Play();
        else
            _backgroundMusic.Stop();
    }

    /// <summary>
    /// takes the amount of level to be decreased or increased
    /// giving a positive value will increase the level
    /// and giving the negative value will decrease the level
    /// </summary>
    /// <param name="amount"></param>
    public void AdjustBackgroundVolume(float amount)
    {
        if (_backgroundVolumeCoroutine != null)
            StopCoroutine(_backgroundVolumeCoroutine);
        _backgroundVolumeCoroutine = StartCoroutine( AdjustVolume(_audioSources[0], amount));
    }

    IEnumerator AdjustVolume(AudioSource source, float amount)
    {
        if (source != null)
        {
            float increment = amount / 10;
            for (int i = 0; i < 10; i++)
            {
                source.volume += increment;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }

    public void PlaySound(SFX sound)
    {
        if (!_isMute)
        {
            AudioSource source = GetAudioSource(sound);
            if (source != null)
                source.Play();
        }
    }

    AudioSource GetAudioSource(SFX sound)
    {
        switch (sound)
        {
            
            case SFX.CLICK:
                return _audioSources[1];
            case SFX.CORRECT_ANSWER:
                return _audioSources[2];
            case SFX.WRONG_ANSWER:
                return _audioSources[3];
            case SFX.LEVEL_CLEARED:
                return _audioSources[4];
            case SFX.LEVEL_FAILED:
                return _audioSources[5];
        }

        return null;
    }
	
    void OnDestroy()
    {
        PlayerPrefs.SetInt(GameConstants.MUTE_KEY, (_isMute == false) ? 0 : 1 );
        PlayerPrefs.Save();
    }
}
