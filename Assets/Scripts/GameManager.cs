using DG.Tweening;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text scoreText;
    public Text phrasesText;
    int score;
    Subject<int> phraseEvent = new Subject<int>();
    int index;
    public string[] phrases;

    int phraseInterval;

    IShowAd showAd;

    void Start()
    {
        phraseInterval = Random.Range(40, 60);
        phraseEvent
            .Where(_ => score >= phraseInterval)
            .Subscribe(_ => { RandomText(); });
    }

    public void OnClick()
    {
        score++;
        phraseEvent.OnNext(score);
        scoreText.text = score.ToString();
    }
    public void RandomText() 
    {
        phrasesText.text = phrases[index];
        index++;
        if(index == phrases.Length)
        {
            index = 0;
        }
        scoreText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phrasesText.transform.DOShakeScale(0.15f, 1f, 10, 90f, true, ShakeRandomnessMode.Harmonic);
        phraseInterval = Random.Range(40, 60);
        showAd.ShowAdd();
    }
}
