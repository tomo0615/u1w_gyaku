using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _bgmAudioSource = default;

    [SerializeField]
    private AudioSource _seAudioSource = default;

    private Dictionary<AudioType, AudioClip> _bgmList;

    private Dictionary<AudioType, AudioClip> _seList;

    [Inject]
    public void Construct(AudioTable audioTable)
    {
        _bgmList = new Dictionary<AudioType, AudioClip>
        {
            {AudioType.TitleBGM, audioTable.titleBGM},
            {AudioType.GameBGM, audioTable.gameBGM },
            {AudioType.ResultBGM, audioTable.resultBGM}
        };

        _seList = new Dictionary<AudioType, AudioClip>
        {
            {AudioType.ButtonOK, audioTable.buttonOk},
            {AudioType.ButtonCancel, audioTable.buttonCancel},

            {AudioType.UnitAttack, audioTable.unitAttack},
            {AudioType.UnitDamage, audioTable.unitDamage},
            {AudioType.UnitDeath, audioTable.unitDeath},

            {AudioType.EnemyAttack, audioTable.enemyAttack},
            {AudioType.EnemyDamage, audioTable.enemyDamage},
            {AudioType.EnemyDestory, audioTable.enemyDestroy},

            {AudioType.Win, audioTable.win},
            {AudioType.Lose, audioTable.lose},
        };
    }

    public void PlayBGM(AudioType type)
    {
        _bgmAudioSource.clip = _bgmList[type];
        _bgmAudioSource.Play();
    }

    public void PlaySE(AudioType type)
    {
        _seAudioSource.PlayOneShot(_seList[type]);
    }
}
