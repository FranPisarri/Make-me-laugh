using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioClip meow;
    [SerializeField] AudioClip laugh;
    [SerializeField] AudioClip card;
    [SerializeField] AudioClip fight;
    [SerializeField] AudioSource m_audiosource;
    [SerializeField] private NPCDialogTrigger meowSound;
    [SerializeField] private DarknessTrigger laughSound;
    [SerializeField] private CardTrigger cardSound;
    [SerializeField] private CardTrigger card2Sound;
    [SerializeField] private Fight fightSound;


    private void Start()
    {
        m_audiosource = GetComponent<AudioSource>();

        meowSound.Onhit.AddListener(MeowSound);
        laughSound.Onhit.AddListener(LaughSound);
        cardSound.Onhit.AddListener(CardSound);
        card2Sound.Onhit.AddListener(CardSound);
        fightSound.Onhit.AddListener(FightSound);
    }

    private void Update()
    {
        m_audiosource.volume = VolumeController.Instance.SFXVolume;
    }

    private void MeowSound()
    {

        m_audiosource.clip = meow;
        m_audiosource.PlayOneShot(meow);

    }

    public void LaughSound()
    {
        m_audiosource.clip = laugh;
        m_audiosource.PlayOneShot(laugh);
    }
    public void CardSound()
    {
        m_audiosource.clip = card;
        m_audiosource.PlayOneShot(card);
    }

    public void FightSound()
    {
        m_audiosource.clip = fight;
        m_audiosource.PlayOneShot(fight);
    }
}
