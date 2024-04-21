using DG.Tweening;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text phrasesText;
    int score;
    Subject<int> phraseEvent = new Subject<int>();
    int index;
    [SerializeField] string[] phrases;
    [SerializeField] string[] startPhrases;
    [SerializeField] AudioClip[] soundsClick;

    int phraseInterval;

    AudioSource audioSource;
    private void Awake()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();
        phraseInterval = score + Random.Range(30, 40);
        index = PlayerPrefs.GetInt("Index");
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        phraseEvent
            .Where(_ => score >= phraseInterval)
            .Subscribe(_ => { RandomText(); });
        if(score > 0)
        {
            phrasesText.text = startPhrases[Random.Range(0, startPhrases.Length)];
        }
    }

    public void OnClick()
    {
        score++;
        phraseEvent.OnNext(score);
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(soundsClick[Random.Range(0, soundsClick.Length)]);
    }
    public void RandomText() 
    {
        phrasesText.text = phrases[index];
        index++;
        PlayerPrefs.SetInt("Index", index);
        PlayerPrefs.SetInt("Score", score);
        if(index == phrases.Length)
        {
            index = 0;
        }
        scoreText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phrasesText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phraseInterval += Random.Range(30, 50);
    }
}
