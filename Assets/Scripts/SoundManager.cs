using UnityEngine;
using YG;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioClip _paintSound;
    [SerializeField] private AudioClip _xpSound;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip[] _music;
    [SerializeField] private GameObject _musicOnIcon, _musicOffIcon;
    private AudioSource _audioSource;
    private bool _musicActive = true;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (YG2.saves.MusicActive)
        {
            int index = Random.Range(0, _music.Length);
            _audioSource.clip = _music[index];
            _audioSource.Play();
        }
        else
        {
            _musicActive = false;
            _musicOnIcon.SetActive(false);
            _musicOffIcon.SetActive(true);
        }
    }
    public void PaintingSound()
    {
        _audioSource.PlayOneShot(_paintSound);
    }
    public void XpSound()
    {
        _audioSource.PlayOneShot(_xpSound);
    }
    public void ClickSound()
    {
        _audioSource.PlayOneShot(_clickSound);
        //if(!_musicActive)

    }
    public void MusicSwitcher()
    {
        if (_musicActive)
        {
            _musicOnIcon.SetActive(false);
            _musicOffIcon.SetActive(true);
            _audioSource.Stop();
            _musicActive = false;
            YG2.saves.MusicActive = false;
            YG2.SaveProgress();
        }
        else
        {
            _musicOnIcon.SetActive(true);
            _musicOffIcon.SetActive(false);
            _audioSource.Play();
            _musicActive = true;
            YG2.saves.MusicActive = true;
            YG2.SaveProgress();
        }
    }
}
