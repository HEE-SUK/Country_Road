using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SFX
{
    ONE,
}
public enum BGM
{
    ONE,
}
public class AudioManager : MonoSingleton<AudioManager>
{
    [SerializeField]
	private AudioSource sfxSouce = null;
    [SerializeField]
	private AudioSource bgmSouce = null;

    private string[] bgmList = {"island_theme", "forest_theme", "grave_theme", "outgame_theme"};
    private string[] sfxList = {"button","use_card","move_card","interaction", "attacked","shield","smith_card", "victory", "defeat", "gold", "shuffle"};
    
    private void Start() 
    {
        // 저장데이터 초기화
        sfxSouce.volume = 0.5f;
        bgmSouce.volume = 0.5f;
    }

    public void PlaySfx(SFX _sfxType)
    {
        int sfxNumber = (int)_sfxType;

        AudioClip audioClip = Resources.Load("Sfx/" + this.sfxList[sfxNumber], typeof(AudioClip)) as AudioClip;
        this.sfxSouce.clip = audioClip;
        this.sfxSouce.PlayOneShot(audioClip);
    }

    public void PlayBgm(BGM _bgmNumber)
	{
        int bgmNumber = (int)_bgmNumber;
        AudioClip audioClip = Resources.Load("Bgm/" + this.bgmList[bgmNumber]) as AudioClip;
        this.bgmSouce.clip = audioClip;
        this.bgmSouce.Play();
	}
	public void StopBgm()
	{
        this.bgmSouce.Stop();
	}

    public void SetVolumeSFX(float _volume)
    {
        sfxSouce.volume = _volume;
    }
    public void SetVolumeBGM(float _volume)
    {
        bgmSouce.volume = _volume;
    }
    public float GetVolumeSFX()
    {
        return sfxSouce.volume;
    }
    public float GetVolumeBGM()
    {
        return bgmSouce.volume;
    }
}