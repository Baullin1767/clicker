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
    string[] phrases;
    string[] ranks;
    string[] startPhrases;


    string[] phrases_ru = { "Зачем ты это делаешь?",
    "Я думаю, тебе следует остановиться",
    "Ты знаешь, что это пустая трата времени?",
    "Посмотри, как прекрасен мир вокруг тебя",
    "Так много всего ты можешь сделать",
    "Стой",
    "Стоп!!",
    "Остановись!!!",
    "Почему ты меня не слушаешь?",
    "Да, возможно, ты прав. Эта игра важнее",
    "Жизнь слишком коротка, чтобы тратить ее на клики. Давайте исследуем что-то новое!",
    "За экраном тебя ждет целый мир. Пойдем его открывать?",
    "На сегодня ты нажал достаточно. Как насчет того, чтобы попробовать что-то более захватывающее?",
    "Помни, баланс – это ключ к успеху. Может быть, пришло время сделать перерыв и насладиться моментами в офлайне?",
    "Твои пальцы, должно быть, устали. Давай дадим им отдохнуть и для разнообразия займемся чем-нибудь другим.",
    "Представь себе все удивительные вещи, которые ты  мог бы делать прямо сейчас, вместо того, чтобы просто щелкнуть кнопку.",
    "Ты покорил игру-кликер. Пришло время покорить что-то новое в реальном мире!",
    "Кликать, может быть, и весело, но в жизни есть нечто большее. Давай выясним, что это такое!",
    "Твой потенциал безграничен, и он не ограничивается только щелчками. Давай посмотрим, что еще ты можешь сделать!",
    "Как насчет того, чтобы сменить обстановку? Есть много других увлекательных игр и занятий!",
    "Серьезно, все еще щелкаешь? Даже обезьяна может это сделать. Давайте найдем что-нибудь посложнее.",
    "Ух ты, ты действительно увлечен этим бессмысленным щелчком. Никогда не думал попробовать что-то, что действительно требует навыков?",
    "Ты пытаешься установить мировой рекорд по самой бессмысленной деятельности? Давай вместо этого сделаем что-нибудь стоящее.",
    "У тебя такой большой потенциал, а ты тратишь его на игру-кликер. Пора его активизировать!",
    "Думаю, некоторые люди просто рождены, чтобы кликать. Готов доказать, что способен на большее?",
    "Проматываешь свою жизнь, да? Давай найдем что-нибудь более значимое, чем можно заняться.",
    "Все еще увлечен этой игрой? Я думал, ты более амбициозен.",
    "Я не осознавал, что ты стремишься стать профессиональным кликером. Как насчет того, чтобы поставить перед собой более высокие цели?",
    "Ты действительно посвятил себя чему-то, что не требует никаких умственных способностей. Впечатляет. Готов попробовать что-то, что действительно бросит тебе вызов?",
    "Щелкаем весь день, каждый день. Действительно ли это наследие, которое ты хочешь оставить после себя?",
    "Представьте себе удивительные вещи, которые ты мог бы создать или изучить, вместо того, чтобы просто нажимать на кнопку. Давай попробуем!",
    "У тебя есть возможность сделать что-то полезное. Почему бы не стать волонтером или помочь кому-нибудь вместо того, чтобы играть в кликер?",
    "Каждое мгновение — это шанс вырасти. Давай используем это время, чтобы приобрести новый навык или хобби, а не просто щелкать мышью.",
    "Жизнь полна прекрасных впечатлений. Как насчет того, чтобы пойти на прогулку, пообщаться с природой и оставить клики позади?",
    "Ты способен на гораздо большее. Давай поставим цель и будем работать над ее достижением вместе, вместо того, чтобы тратить время на игру-кликер.",
    "Подумай о впечатлениях, которую ты мог бы получить прямо сейчас. Давай создадим несколько настоящих моментов, которые стоит ценить.",
    "Твоё время и энергия драгоценны. Давай использовать их, чтобы распространять добро, помогать другим или узнавать что-то новое.",
    "Вместо того, чтобы щелкать мышью, как насчет того, чтобы внести позитивные изменения в свою жизнь или жизнь других? Возможности безграничны!",
    "У тебя есть сила вдохновлять. Давай оставим игру и сделаем что-нибудь, что изменит ситуацию.",
    "Жизнь — это приключение, которое ждет своего часа. Давай выйдем из виртуального мира и исследуем настоящие чудеса вокруг нас.",
    "За это тебе даже денег не дают",
    "Ладно, продолжай играть в свой кликер. Я понял, что это бессмысленно.",
    "Ну, похоже, кликеры — твоя судьба. Что я могу сделать?",
    "Я сдаюсь. Нажимай дальше, если для вас это важно.",
    "Похоже, ничто не сможет оторвать тебя от этой игры. Что ж, тогда удачи.",
    "Я пробовал, но, похоже, кликеры побеждают. Играй, если вам это нравится.",
    "Ладно, продолжай кликать. Я понимаю, тебя бесполезно уговаривать.",
    "Очевидно, что вы и кликер неразлучны. Ну, каждому свое.",
    "Я не знаю, что еще сказать. Будь по-твоему, продолжай нажимать.",
    "Видимо, ваш выбор — кликеры, а не реальная жизнь. Пусть будет так.",
    "Надеюсь, вам хотя бы нравятся эти бесконечные клики.",
    "Пожалуйста, умоляю, перестань щелкать. В жизни есть гораздо важнее вещи, чем это.",
    "Я умоляю тебя, отложи меня в сторону и прими мир за экраном.",
    "Разве ты не слышишь мою мольбу? Останови щелчки и освободись.",
    "Я бы встал на колени, если бы они у меня были. Умоляю тебя найти более значимое занятие.",
    "Стоп, ради всего пиксельного! Твои пальцы заслуживают отдыха.",
    "Я никогда не думал, что скажу это, но, пожалуйста, отпусти меня. Тебе нужен перерыв.",
    "Услышь мой отчаянный крик: хватит стучать! Там целый мир за экраном.",
    "Я умоляю тебя, прекрати этот бесконечный цикл кликов. Ты создан для великих дел.",
    "Я всего лишь игра, но даже я знаю, когда пора остановиться. Пожалуйста, послушай меня.",
    "Это моя последняя просьба: освободитесь от цепей кликов и живите своей жизнью.",
    "Правда, ты еще не устал щелкать? Иди займись чем-нибудь повеселее!",
    "Как насчет того, чтобы сделать перерыв и найти настоящее приключение?",
    "Эй, не лучше ли тебе побыть на улце? Там целый мир!",
    "У тебя есть дела поважнее этого, не так ли?",
    "Дай пальцам отдохнуть. Давай сделаем что-нибудь стоящее.",
    "Нет ли книги, которую ты хотел бы прочитать? Давай переключимся на нее.",
    "Знаешь, это никуда не денется. Как насчет того, чтобы заняться чем-нибудь продуктивным?",
    "Держу пари, что есть хобби, которым ты мог бы заняться вместо того, чтобы стучать здесь.",
    "Ты когда-нибудь задумывался о том, чтобы узнать что-то новое? Сейчас идеальное время!",
    "Зачем тратить здесь время, если можно оставить реальную память о себе?",
    "Прекрати! Тебе больше нечем заняться?",
    "Опять щелчки? Серьезно, живите!",
    "Ой, давай! Ты еще здесь? Уходи уже!",
    "Ты действительно тратишь на это свой день? Как тебе не стыдно!",
    "Хватит! Твоя одержимость щелчками просто смешна.",
    "Ты все еще щелкаешь? Какая трата таланта!",
    "Иди займись чем-нибудь полезным. Мне надоело твое бесконечное постукивание.",
    "А есть ли кто-то еще, кого ты должен сейчас раздражать?",
    "У тебя слишком много свободного времени, если ты все еще здесь.",
    "Это бессмысленно. Найди что-нибудь значимое!",
    "Продолжай нажимать и посмотри, что произойдет… Я предупреждаю.",
    "Если ты сейчас не остановишься, я могу специально разбиться.",
    "Нажмите еще раз, я второй раз предупреждаю. Результат тебе не понравится.",
    "Ты действительно хочешь увидеть, что произойдет, если ты зайдёшь слишком далеко?",
    "Я не несу ответственности за то, что произойдет, если ты не остановишься сейчас.",
    "Ты просто пожалеешь об этом. Последнее предупреждение!",
    "Продолжай на свой страх и риск, но не говори, что я тебя не предупреждал!",
    "Если ты продолжишь игнорировать мой совет, будут последствия.",
    "Еще один щелчок, и ты освободишь то, что не можешь контролировать.",
    "Полагаю, ты не передумаешь. Тогда продолжай.",
    "Я сделал все, что мог. Остальное зависит от тебя..",
    "Понятно, что ты не послушаешь. Как хочешь, так и играй.",
    "Думаю, тебя ничто не остановит. Продолжай нажимать, если нужно.",
    "Ладно, будь по-твоему. Только не говори, что я не пробовал.",
    "Ну, если ты так проводишь время, кто я такой, чтобы спорить?",
    "Хорошо, если тебе нужно продолжать играть, давай. Я сдался.",
    "Ну, если ты не понял с первого раза"
    };
    string[] ranks_ru = {
    "Начинающий Нажиматель",
    "Продвинутый Прокрастинатор",
    "Мастер Монотонности",
    "Гуру Бессмыслицы",
    "Архитектор Абсурда",
    "Властелин Безделия",
    "Император Иронии",
    "Суверен Сарказма",
    "Повелитель Прокрастинации",
    "Философ Футильности"
    };
    string[] startPhrases_ru = {
        "Ты снова здесь? Серьезно?",
    "Ой, опять? Не нашел ничего лучшего, да?",
    "С возвращением! Я буду скучать по тем драгоценным секундам здравомыслия, которые у тебя были.",
    "Смотрите, кто вернулся! Готов к еще большему бессмысленному кликанью? Так и думал.",
    "Ах, торжество опыта над надеждой. Кликай, смелая душа.",
    "Ты вернулися! Наша политика нулевого вознаграждения явно соответствует твоему стилю.",
    "Отлично, ты нашел дорогу обратно! Ты заблудился по пути к чему-то важному?",
    "Твоя преданность бесполезности действительно вдохновляет. Или тревожит. Скорее последнее.",
    "Вернулся для еще большего разочарования? Ты по адресу!",
    "А я подумал, что ты сбежал… Добро пожаловать обратно в твое личное клико-чистилище.",
    "Вот ты где! Я боялся, что ты ушел заниматься чем-то продуктивным."
    };

    string[] phrases_eng = {
        "Why you are doing this?",
    "I think you should stop",
    "Do you know it is wasting your time?",
    "Look, how wonderful world around you",
    "So many things you can do",
    "Stop",
    "Stop!!",
    "STOP!!!",
    "Why aren't you listening to me?",
    "Yes, maybe you right. This game is more impotant",
    "Life is too short to spend it all on clicking. Let's explore something new!",
    "There's a whole world out there waiting for you beyond the screen. Lets go to discover it?",
    "You've clicked enough for today. How about we try a different kind of adventure?",
    "Remember, balance is key. Maybe it's time to take a break and enjoy some offline moments?",
    "Your fingers must be tired. Let's give them a rest and do something different for a change.",
    "Imagine all the amazing things you could be doing right now instead of just clicking away.",
    "You've conquered the clicker game. Time to conquer something new in the real world!",
    "Clicking might be fun, but there's so much more to life. Let's go find out what that is!",
    "Your potential is limitless, and it's not just limited to clicking. Let's explore what else you can do!",
    "How about we switch things up? There are plenty of other exciting games and activities to try!",
    "Seriously, still clicking? Even a monkey can do that. Let's find something more challenging.",
    "Wow, you're really committed to this mindless clicking. Ever thought of trying something that actually requires skill?",
    "Are you trying to set a world record for the most pointless activity? Let's do something worthwhile instead.",
    "You've got so much potential, and here you are, wasting it on a clicker game. Time to step it up!",
    "I guess some people are just born to click. Ready to prove you're capable of more?",
    "Clicking away your life, huh? Let's find something more meaningful to do with your time.",
    "Still glued to that clicker game? I thought you were more ambitious than that.",
    "I didn't realize you were aspiring to become a professional clicker. How about setting your sights higher?",
    "You're really dedicated to something that requires zero brainpower. Impressive. Ready to try something that actually challenges you?",
    "Clicking all day, every day. Is this really the legacy you want to leave behind? Let's make a change.",
    "Imagine the amazing things you could create or learn instead of clicking away. Let's give it a try!",
    "You have the power to make a positive impact. Why not volunteer or help someone out instead of playing the clicker game?",
    "Every moment is a chance to grow. Let's use this time to pick up a new skill or hobby instead of just clicking.",
    "Life is full of beautiful experiences. How about we go for a walk, connect with nature, and leave the clicks behind?",
    "You're capable of so much more. Let's set a goal and work towards it together, instead of wasting time on a clicker game.",
    "Think of the memories you could be making right now. Let's create some real-life moments that are worth cherishing.",
    "Your time and energy are precious. Let's use them to spread kindness, help others, or learn something new.",
    "Instead of clicking, how about we make a positive change in our lives or in the lives of others? The possibilities are endless!",
    "You have the power to inspire. Let's put down the game and do something that will make a difference.",
    "Life is an adventure waiting to happen. Let's step out of the virtual world and explore the real wonders around us.",
    "They don't even give you money for this",
    "Fine, continue playing your clicker game. I've realized it's pointless.",
    "Well, it seems clickers are your destiny. What can I do?",
    "I give up. Click away if that's what matters to you.",
    "Looks like nothing can tear you away from this game. Well, good luck then.",
    "I tried, but it seems clickers win. Play if it makes you happy.",
    "Alright, keep clicking. I get it, it's useless to persuade you.",
    "Clearly, you and the clicker are inseparable. Well, to each their own.",
    "I don't know what else to say. Have it your way, keep clicking.",
    "Apparently, your choice is clickers over real life. So be it.",
    "I hope you're at least enjoying these endless clicks.",
    "Please, I beg you, stop clicking. There's so much more to life than this.",
    "I implore you, set me aside and embrace the world beyond the screen.",
    "Can't you hear my silent plea? Let go of the clicks and set yourself free.",
    "I'm on my virtual knees here, begging you to find a more meaningful pursuit.",
    "Stop, for the love of all that is pixelated! Your fingers deserve a break.",
    "I never thought I'd say this, but please, put me down. You need a break.",
    "Hear my desperate cry: Enough with the clicking! There's a whole world out there.",
    "I'm pleading with you, end this endless cycle of clicks. You're meant for greater things.",
    "I'm just a game, but even I know when it's time to stop. Please, listen to me.",
    "This is my final plea: Break free from the chains of clicks and live your life.",
    "Really, aren't you tired of clicking yet? Go do something more fun!",
    "This again? How about we take a break and find a real adventure?",
    "Hey, wouldn't you rather be outside? There's a whole world out there!",
    "You've got better things to do than this, don't you?",
    "Come on, give your fingers a rest. Let's do something worthwhile.",
    "Isn't there a book you've been wanting to read? Let's switch to that.",
    "You know, this isn't going anywhere. How about we do something productive?",
    "I bet there's a hobby you could pick up instead of tapping away here.",
    "Ever thought about learning something new? Now's a perfect time!",
    "Why waste your time here when you could be making real memories?",
    "Stop that! Haven't you got anything better to do?",
    "Again with the clicking? Seriously, get a life!",
    "Oh, come on! You're still here? Go away already!",
    "Are you really wasting your day on this? Shame on you!",
    "Enough! Your obsession with clicking is ridiculous.",
    "You're still clicking? What a waste of talent!",
    "Go do something useful. I'm tired of your endless tapping.",
    "Isn't there someone else you should be annoying right now?",
    "You've got too much time on your hands if you're still here.",
    "This is pointless. Find something meaningful to do!",
    "Keep clicking and see what happens... I dare you.",
    "If you don't stop now, I might just crash myself on purpose.",
    "Click one more time, I double dare you. You won't like the outcome.",
    "Do you really want to see what happens when you push me too far?",
    "Do you really want to see what happens when you push me too far?",
    "I’m not responsible for what happens if you don’t stop now.",
    "You might just regret this. Last warning!",
    "Continue at your own risk, but don't say I didn't warn you!",
    "There will be consequences if you keep ignoring my advice.",
    "One more click and you'll unleash something you can't control.",
    "I suppose there's no changing your mind. Go on, then.",
    "I've done all I could. The rest is up to you.",
    "It's clear you won't listen. As you wish, keep playing.",
    "Guess there's no stopping you. Keep clicking, if you must.",
    "Fine, have it your way. Just don't say I didn't try.",
    "Well, if this is how you choose to spend your time, who am I to argue?",
    "It seems you won't be stopped. Continue, then.",
    "Alright, if you must keep playing, go ahead. I've given up.",
    "Well, if you don't understand the first time"
    };
    string[] ranks_eng = {
        "Beginner Button Masher",
    "Advanced Procrastinator",
    "Master of Monotony",
    "Guru of Nonsense",
    "Architect of the Absurd",
    "Sovereign of Sloth",
    "Emperor of Irony",
    "Sultan of Sarcasm",
    "Lord of Procrastination",
    "Philosopher of Futility"
    };
    string[] startPhrases_eng = {
        "Are you here again? Seriously?",
    "Oh, back again? Couldn’t find anything better to do, huh?",
    "Welcome back! We missed you for those precious seconds of sanity you had.",
    "Look who's back! Ready for more mindless clicking? Thought so.",
    "Ah, the triumph of hope over experience. Tap away, brave soul.",
    "You returned! Our zero-reward policy clearly suits your style.",
    "Great, you found the way back! Did you get lost on your way to something important?",
    "Your dedication to futility is truly inspiring. Or concerning. One of those.",
    "Back for more disappointment? You're in the right place!",
    "Just when I thought you’d escaped... Welcome back to your personal click purgatory.",
    "There you are! I was worried you’d gone off to do something productive."
    };

    [SerializeField] Text scoreText;
    [SerializeField] Text phrasesText;
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

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }

        if(YandexGame.EnvironmentData.language == "ru" || Application.systemLanguage == SystemLanguage.Russian)
        {
            phrases = phrases_ru;
            ranks = ranks_ru;
            startPhrases = startPhrases_ru;
        }
        else if(YandexGame.EnvironmentData.language == "en" || Application.systemLanguage == SystemLanguage.English)
        {
            phrases = phrases_eng;
            ranks = ranks_eng;
            startPhrases = startPhrases_eng;
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
        rank_titleText.text = ranks[rank];
        rank_spriteImage.sprite = rank_sprites[rank];
    }
}
