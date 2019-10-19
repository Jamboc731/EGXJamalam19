using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //REQUIRES TWO AUDIOSOURCES

    #region Singleton
    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    private float m_OriginalPitch = 1;
    public float m_PitchVariance;

    public AudioSource m_BGMSource; //SET TO LOOP
    public AudioSource m_SFXSource;

    public AudioClip[] m_PunchSounds;
    public AudioClip m_ShotgunNoise;
    public AudioClip m_RoundWinSFX;
    public AudioClip m_RoundWinBGM;
    public AudioClip[] m_StandardBGM;

    private void Start()
    {
        PlayBGM();
    }

    //Call this with AudioManager.instance.PlayAudio(GetComponent<AudioSource>(), [audio clip]);
    public void PlayAudio(AudioSource audioSource, AudioClip clip)
    {
        audioSource.pitch = Random.Range(m_OriginalPitch - m_PitchVariance, m_OriginalPitch + m_PitchVariance);
        audioSource.PlayOneShot(clip);
    }

    //Call this with AudioManager.instance.PlayOnHit(m_AudioSource);
    public void PlayOnHit(AudioSource audioSource, bool isShotgun)
    {
        if (isShotgun)
        {
            PlayAudio(audioSource, m_ShotgunNoise);
        }
        else
        {
            int hitSound = Random.Range(0, m_PunchSounds.Length);
            PlayAudio(audioSource, m_PunchSounds[hitSound]);

        }
    }

    public void PlayBGM() //Call on Scene Load
    {
        int backgroundMusic = Random.Range(0, m_StandardBGM.Length);
        m_BGMSource.clip = m_StandardBGM[backgroundMusic];
        m_BGMSource.Play();
    }

    public void PlayOnWin() //Call on Player Death
    {
        m_SFXSource.clip = m_RoundWinSFX;
        m_BGMSource.clip = m_RoundWinBGM;
        m_BGMSource.Play();
        m_SFXSource.Play();

    }
}