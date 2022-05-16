using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISoundService
{
    void Play(AudioClip clip,bool isLoop = false);
    void Play(string name,bool isLoop = false);
    void RePlay(string name);
    void ChangeMute(AudioClip clip);
    void ChangeMute(string name);
    void Stop(string name);
    void Pause(string name);
    void Stop();

    void FadeOut(string name,float fadeTime);
    void FadeIn(string name,float fadeTime);
}

public class SoundManager : MonoBehaviour, ISoundService
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    //別名(name)をキーとした管理用Dictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //AudioSource（スピーカー）を同時に鳴らしたい音の数だけ用意
    private AudioSource[] audioSourceList = new AudioSource[20];

    public class FadeAudioSource
    {
        public AudioSource source;//オーディオソース
        public float fadeTime;//フェードの時間
        public bool isFadeIn;//フェードインかアウトか
    }

    private List<FadeAudioSource> fadeAudioSources = new List<FadeAudioSource>();

    private void Awake()
    {
        //DontDestroyObjectManager.DontDestroyOnLoad(this.gameObject);

        //auidioSourceList配列の数だけAudioSourceを自分自身に生成して配列に格納
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        //soundDictionaryにセット
        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    private void Update()
    {
        FadeAudio();
    }

    void FadeAudio()
    {
        if(fadeAudioSources.Count <= 0) return;
        //
        for(int i =0;i < fadeAudioSources.Count;i++)
        {
            FadeAudioSource fadeAudioSource = fadeAudioSources[i];
            if (fadeAudioSource.isFadeIn)
            {
                AudioSource source = fadeAudioSource.source;
                if ((!source.isPlaying) && (source.volume >= 1))
                {
                    fadeAudioSources.RemoveAt(i);
                    continue;
                }
                source.volume += (Time.deltaTime) / fadeAudioSource.fadeTime;

            }
            else
            { 
                AudioSource source = fadeAudioSource.source;
                if ((!source.isPlaying) && (source.volume <= 0)) {
                    source.volume = 1;
                    fadeAudioSources.RemoveAt(i);
                    continue;
                }
                source.volume += (Time.deltaTime  * -1) / fadeAudioSource.fadeTime;

            }

        }
    }

    //未使用のAudioSourceの取得 全て使用中の場合はnullを返却
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }

        return null; //未使用のAudioSourceは見つかりませんでした
    }

    //指定されたAudioClipを使用中のAudioSourceを全て取得 使用中ではない場合はnullを返却
    private List<AudioSource> GetUsingAudioSources(AudioClip clip)
    {
        var usingAudioSources = new List<AudioSource>();

        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].clip != null)
            {
                if (audioSourceList[i].clip.name == clip.name)
                    usingAudioSources.Add(audioSourceList[i]);
            }
        }

        if (usingAudioSources.Count > 0) return usingAudioSources;

        return null; //使用中のAudioSourceは見つかりませんでした
    }

    //指定されたAudioClipを未使用のAudioSourceで再生
    public void Play(AudioClip clip,bool isLoop = false)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //再生できませんでした
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    //指定された別名で登録されたAudioClipを再生
    public void Play(string name,bool isLoop = false)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            Play(soundData.audioClip,isLoop); //見つかったら、再生
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    //指定されたAudioClipを使用中で一時停止中のAudioSourceを再開
    public void RePlay(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //再開するものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
        }
    }

    //指定された別名で登録されたAudioClipを使用中で一時停止中のAudioSourceを再開
    public void RePlay(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            RePlay(soundData.audioClip); //見つかったら、再開
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    //指定されたAudioClipを使用中のAudioSourceを停止
    public void Stop(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //停止するものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        } 
    }

    //指定された別名で登録されたAudioClipを使用中のAudioSourceを停止
    public void Stop(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            Stop(soundData.audioClip); //見つかったら、停止
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    //指定されたAudioClipを使用中のAudioSourceを一時停止
    public void Pause(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //一時停止するものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    //指定された別名で登録されたAudioClipを使用中のAudioSourceを一時停止
    public void Pause(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
           Pause(soundData.audioClip); //見つかったら、一時停止
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    //指定されたAudioClipを使用中のAudioSourceをミュート
    public void ChangeMute(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //ミュートするものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    //指定された別名で登録されたAudioClipを使用中のAudioSourceをミュート
    public void ChangeMute(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            ChangeMute(soundData.audioClip); //見つかったら、ミュート
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    //使用中全てのAudioSourceを停止
    public void Stop()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i].Stop();
        }
    }

    public void FadeIn(AudioClip clip, float fadeTime)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //一時停止するものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            FadeAudioSource fadeAudioSource = new FadeAudioSource();
            audioSource.volume = 0;
            fadeAudioSource.source = audioSource;
            fadeAudioSource.fadeTime = fadeTime;
            fadeAudioSource.isFadeIn = true;
            fadeAudioSources.Add(fadeAudioSource);
        }
    }

    public void FadeIn(string name, float fadeTime)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            FadeIn(soundData.audioClip, fadeTime); //見つかったら、ミュート
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }

    public void FadeOut(AudioClip clip,float fadeTime)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //一時停止するものがありませんでした
        foreach (AudioSource audioSource in audioSources)
        {
            FadeAudioSource fadeAudioSource = new FadeAudioSource();
            fadeAudioSource.source = audioSource;
            fadeAudioSource.fadeTime = fadeTime;
            fadeAudioSource.isFadeIn = false;
            fadeAudioSources.Add(fadeAudioSource);   
        }
    }

    public void FadeOut(string name, float fadeTime)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //管理用Dictionary から、別名で探索
        {
            FadeOut(soundData.audioClip,fadeTime); //見つかったら、ミュート
        }
        else
        {
            Debug.LogWarning($"その別名は登録されていません:{name}");
        }
    }
}
