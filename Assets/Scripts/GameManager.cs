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
    [SerializeField] string[] phrases;
    [SerializeField] string[] startPhrases;
    Subject<int> phraseEvent = new Subject<int>();

    int score;
    int index;

    int rank;
    [SerializeField] Text rank_titleText;
    [SerializeField] Image rank_spriteImage;
    [SerializeField] Sprite[] rank_sprites;

    [SerializeField] AudioClip[] soundsClick;

    int phraseInterval;

    AudioSource audioSource;

    string path_to_phrases_file;
    string path_to_ranks_file;
    [Serializable]
    private class PhrasesContainer
    {
        public string[] phrases;
        public string[] startPhrases;
    }
    [Serializable]
    private class RanksContainer
    {
        public string[] ranks;
    }

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }

        path_to_phrases_file = Application.dataPath;
        path_to_ranks_file = Application.dataPath;
        if (Application.systemLanguage == SystemLanguage.English || YandexGame.EnvironmentData.language == "en")
        {
            path_to_phrases_file += "/phrases_eng.json";
            path_to_ranks_file += "/ranks_eng.json";
        }
        else if (Application.systemLanguage == SystemLanguage.Russian || YandexGame.EnvironmentData.language == "ru")
        {
            path_to_phrases_file += "/phrases_ru.json";
            path_to_ranks_file += "/ranks_ru.json";
        }

        if (File.Exists(path_to_phrases_file))
        {
            string json = File.ReadAllText(path_to_phrases_file);
            PhrasesContainer container = JsonUtility.FromJson<PhrasesContainer>(json);
            phrases = container.phrases;
            startPhrases = container.startPhrases;
        }

    }

    void Start()
    {
        phraseEvent
            .Where(_ => score >= phraseInterval)
            .Subscribe(_ => { RandomText(); });
        phraseEvent
            .Where(_ => rank < 9 && index == 0 && score != 0 && score >= phraseInterval)
            .Subscribe(_ => {
                rank++;
                YandexGame.savesData.rank = rank;
                UpdateRank();
            });
        UpdateRank();
        scoreText.text = score.ToString();
        phraseInterval = score + UnityEngine.Random.Range(30, 40);
        audioSource = GetComponent<AudioSource>();
        if (score > 0)
        {
            phrasesText.text = startPhrases[UnityEngine.Random.Range(0, startPhrases.Length)];
        }
    }

    public void GetLoad()
    {
        score = YandexGame.savesData.score;
        index = YandexGame.savesData.index;
        rank = YandexGame.savesData.rank;
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
        YandexGame.NewLeaderboardScores("clicker", score);

        if (index >= phrases.Length)
        {
            index = 0;
        }
        scoreText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phrasesText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phraseInterval += UnityEngine.Random.Range(30, 50);
    }

    private void UpdateRank()
    {
        if (File.Exists(path_to_ranks_file))
        {
            string json = File.ReadAllText(path_to_ranks_file);
            RanksContainer container = JsonUtility.FromJson<RanksContainer>(json);
            rank_titleText.text = container.ranks[rank];
        }
        rank_spriteImage.sprite = rank_sprites[rank];
    }
}
