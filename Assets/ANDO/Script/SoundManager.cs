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
}

public class SoundManager : MonoBehaviour,ISoundService
{
    [System.Serializable]
    public class SoundData
    {
        public string name;
        public AudioClip audioClip;
    }

    [SerializeField]
    private SoundData[] soundDatas;

    //�ʖ�(name)���L�[�Ƃ����Ǘ��pDictionary
    private Dictionary<string, SoundData> soundDictionary = new Dictionary<string, SoundData>();

    //AudioSource�i�X�s�[�J�[�j�𓯎��ɖ炵�������̐������p��
    private AudioSource[] audioSourceList = new AudioSource[20];

    private void Awake()
    {
        //auidioSourceList�z��̐�����AudioSource���������g�ɐ������Ĕz��Ɋi�[
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }

        //soundDictionary�ɃZ�b�g
        foreach (var soundData in soundDatas)
        {
            soundDictionary.Add(soundData.name, soundData);
        }
    }

    //���g�p��AudioSource�̎擾 �S�Ďg�p���̏ꍇ��null��ԋp
    private AudioSource GetUnusedAudioSource()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            if (audioSourceList[i].isPlaying == false) return audioSourceList[i];
        }

        return null; //���g�p��AudioSource�͌�����܂���ł���
    }

    //�w�肳�ꂽAudioClip���g�p����AudioSource��S�Ď擾 �g�p���ł͂Ȃ��ꍇ��null��ԋp
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

        return null; //�g�p����AudioSource�͌�����܂���ł���
    }

    //�w�肳�ꂽAudioClip�𖢎g�p��AudioSource�ōĐ�
    public void Play(AudioClip clip,bool isLoop = false)
    {
        var audioSource = GetUnusedAudioSource();
        if (audioSource == null) return; //�Đ��ł��܂���ł���
        audioSource.clip = clip;
        audioSource.loop = isLoop;
        audioSource.Play();
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���Đ�
    public void Play(string name,bool isLoop = false)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            Play(soundData.audioClip,isLoop); //����������A�Đ�
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�w�肳�ꂽAudioClip���g�p���ňꎞ��~����AudioSource���ĊJ
    public void RePlay(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //�ĊJ������̂�����܂���ł���
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
        }
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���g�p���ňꎞ��~����AudioSource���ĊJ
    public void RePlay(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            RePlay(soundData.audioClip); //����������A�ĊJ
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�w�肳�ꂽAudioClip���g�p����AudioSource���~
    public void Stop(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //��~������̂�����܂���ł���
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        } 
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���g�p����AudioSource���~
    public void Stop(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            Stop(soundData.audioClip); //����������A��~
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�w�肳�ꂽAudioClip���g�p����AudioSource���ꎞ��~
    public void Pause(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //�ꎞ��~������̂�����܂���ł���
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Pause();
        }
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���g�p����AudioSource���ꎞ��~
    public void Pause(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
           Pause(soundData.audioClip); //����������A�ꎞ��~
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�w�肳�ꂽAudioClip���g�p����AudioSource���~���[�g
    public void ChangeMute(AudioClip clip)
    {
        var audioSources = GetUsingAudioSources(clip);
        if (audioSources == null) return; //�~���[�g������̂�����܂���ł���
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.mute = !audioSource.mute;
        }
    }

    //�w�肳�ꂽ�ʖ��œo�^���ꂽAudioClip���g�p����AudioSource���~���[�g
    public void ChangeMute(string name)
    {
        if (soundDictionary.TryGetValue(name, out var soundData)) //�Ǘ��pDictionary ����A�ʖ��ŒT��
        {
            ChangeMute(soundData.audioClip); //����������A�~���[�g
        }
        else
        {
            Debug.LogWarning($"���̕ʖ��͓o�^����Ă��܂���:{name}");
        }
    }

    //�g�p���S�Ă�AudioSource���~
    public void Stop()
    {
        for (var i = 0; i < audioSourceList.Length; ++i)
        {
            audioSourceList[i].Stop();
        }
    }

    public void FadeIn()
    {

    }
}