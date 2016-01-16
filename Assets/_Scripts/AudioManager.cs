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
        LEVEL_CLEARED,
        STAR,
        TICK
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
            if(amount > 0)
            {
                while(source.volume < amount)
                {
                    source.volume += 0.05f;
                    yield return new WaitForSeconds(0.5f);
                }
            }
            else if (amount < 0)
            {
                while (source.volume > Mathf.Abs( amount))
                {
                    source.volume -= 0.05f;
                    yield return new WaitForSeconds(0.1f);
                }
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
            case SFX.STAR:
                return _audioSources[6];
            case SFX.TICK:
                return _audioSources[7];
        }


        return null;
    }
	
    void OnDestroy()
    {
        PlayerPrefs.SetInt(GameConstants.MUTE_KEY, (_isMute == false) ? 0 : 1 );
        PlayerPrefs.Save();
    }
}
