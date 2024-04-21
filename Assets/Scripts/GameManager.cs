using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
using System;
using System.IO;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using YG;

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

    string path_to_phrases_file;
    [Serializable]
    private class PhrasesContainer
    {
        public string[] phrases;
        public string[] startPhrases;
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        path_to_phrases_file = Application.dataPath;
        if (Application.systemLanguage == SystemLanguage.English)
        {
            path_to_phrases_file += "/phrases_eng.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            path_to_phrases_file += "/phrases_ru.json";
        }

        if (File.Exists(path_to_phrases_file))
        {
            string json = File.ReadAllText(path_to_phrases_file);
            PhrasesContainer container = JsonUtility.FromJson<PhrasesContainer>(json);
            phrases = container.phrases;
            startPhrases = container.startPhrases;
        }

        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
        scoreText.text = score.ToString();
        phraseInterval = score + UnityEngine.Random.Range(30, 40);
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        phraseEvent
            .Where(_ => score >= phraseInterval)
            .Subscribe(_ => { RandomText(); });
        if(score > 0)
        {
            phrasesText.text = startPhrases[UnityEngine.Random.Range(0, startPhrases.Length)];
        }
    }

    public void GetLoad()
    {
        score = YandexGame.savesData.score;
        index = YandexGame.savesData.index;
    }

    public void OnClick()
    {
        score++;
        phraseEvent.OnNext(score);
        scoreText.text = score.ToString();
        audioSource.PlayOneShot(soundsClick[UnityEngine.Random.Range(0, soundsClick.Length)]);
    }
    public void RandomText() 
    {
        phrasesText.text = phrases[index];
        index++;

        YandexGame.savesData.index = index;
        YandexGame.savesData.score = score;
        YandexGame.SaveProgress();

        if (index == phrases.Length)
        {
            index = 0;
        }
        scoreText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phrasesText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phraseInterval += UnityEngine.Random.Range(30, 50);
    }
}
