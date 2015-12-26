using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestionsScreenController : MonoBehaviour {

    public Text QuestionText;
    public Text LevelNumber;
    public Text Heading;
    public Text Time;
    public Text AnswerBox;
    public TallyMarksWidgetController TallyMarksWidget;
    public static event System.Action<bool> LevelCompleted;
    public NumpadController Numpad;
    public GameObject PauseMenu;

    int _currentQuestionIndex;
    List<Question> _questionsList;
    LevelConfig _levelConfig;

    int _correctCounter, _mistakeCounter;
    Coroutine _timerCoroutine;
	
	void Start () {

        GameScenePopup.ContinueClicked += OnPopupContinueClicked;
        GameController.Instance.IsGamePaused = true;

        _levelConfig = GameController.Instance.LevelToPlay;
        LevelNumber.text = "Level " + _levelConfig.LevelNumber.ToString();

        _correctCounter = 0;
        _mistakeCounter = 0;
        _currentQuestionIndex = 0;

        IQuestionGenerator questionGenerator = QuestionFactory.Instance.GetGenerator(_levelConfig.DifficultyLevel);
        _questionsList = questionGenerator.GenerateQuestions(_levelConfig.NumberOfQuestions);

        StartCoroutine(RefreshForNextQuestion());
        AudioManager.Instance.AdjustBackgroundVolume(-0.995f);
        
    }
    
    void Update()
    {
        AnswerBox.text = Numpad.Text;
    }

    public IEnumerator TimerTick()
    {
        
        int seconds = 0;
        int totalTime = (int)_levelConfig.TimeLimit * 60; // Minutes into seconds

        while(seconds < totalTime)
        {
            yield return new WaitForSeconds(1f);
            if(!GameController.Instance.IsGamePaused)
                seconds++;
            Time.text = (totalTime - seconds).ToString() + " Secs";
        }

        if (LevelCompleted != null)
            LevelCompleted(false);
    }

    public IEnumerator RefreshForNextQuestion()
    {
        
        QuestionText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.45f);

        Question question = _questionsList[_currentQuestionIndex];
        QuestionText.text = question.Text;

        QuestionText.GetComponent<Animator>().SetTrigger("FadeOut");
        AnswerBox.text = "";

        Heading.text = (_levelConfig.NumberOfQuestions - _currentQuestionIndex).ToString();
        
    }

    public void OnNextClicked()
    {
        Numpad.ClearText();
        AudioManager.Instance.PlaySound(AudioManager.SFX.CLICK);
        Question question = _questionsList[_currentQuestionIndex];
        print(_currentQuestionIndex);
        if(AnswerBox.text == question.Answer) //if answer is correct
        {
            _correctCounter++;
            TallyMarksWidget.FillNext(TallyMarkController.TALLY_MARK.TICK);
            AudioManager.Instance.PlaySound(AudioManager.SFX.CORRECT_ANSWER);
        }
        else //if answer is wrong
        {
            TallyMarksWidget.FillNext(TallyMarkController.TALLY_MARK.CROSS);
            AudioManager.Instance.PlaySound(AudioManager.SFX.WRONG_ANSWER);
            if (++_mistakeCounter > _levelConfig.NumberOfMistakes) //if chances are finished
            {
                if (LevelCompleted != null)
                {
                    LevelCompleted(false);
                    if (_timerCoroutine != null)
                        StopCoroutine(_timerCoroutine);
                    return;
                }
            }        
        }

        if (++_currentQuestionIndex > (_levelConfig.NumberOfQuestions-1)) // if all questions are completed
        {
            
            if (LevelCompleted != null)
            {
                LevelCompleted(true);
                if (_timerCoroutine != null)
                    StopCoroutine(_timerCoroutine);
            }
        }
        else //if questions are remaining
            StartCoroutine( RefreshForNextQuestion());
    }

    void OnPopupContinueClicked()
    {
        if (GameController.Instance.IsGamePaused)
        {
            GameController.Instance.IsGamePaused = false;

            if (_levelConfig.TimeLimit != 0)
                _timerCoroutine = StartCoroutine(TimerTick());
            else
                Time.gameObject.SetActive(false);
        }
        else
        {
            GameController.Instance.IsGamePaused = true;
            GameController.Instance.LoadScene(GameConstants.GAME_PLAY_SCENE);
        }
    }

    public void OnPauseClicked()
    {
        GameController.Instance.IsGamePaused = true;
        PauseMenu.SetActive(true);
    }

    public void OnBoardClicked()
    {

    }

    void OnDestroy()
    {
        GameScenePopup.ContinueClicked -= OnPopupContinueClicked;
    }
}
