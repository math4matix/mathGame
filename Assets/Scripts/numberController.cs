using TMPro;
using Unity.Multiplayer.Center.Common;
using UnityEngine;
using UnityEngine.UI;

public class numberController : MonoBehaviour
{
    [SerializeField]
    public TMP_Text _number1Text;
    [SerializeField]
    public TMP_Text _number2Text;
    [SerializeField]
    public TMP_Text _feedbackText;
    [SerializeField]
    public TMP_InputField _answerField;
    [SerializeField]
    public TMP_Text _scoreText;
    [SerializeField]
    private int _minValue = 1;
    [SerializeField]
    private int _maxValue = 10;
    [SerializeField]
    public GameObject cookieObject;
    [SerializeField]
    public GameObject monsterObject;
    [SerializeField]
    private bool plusMinus;
    [SerializeField]
    private int _maxAnswerValue = 10;

    
    private int _number1;
    private int _number2;
    private int _answer;
    private int _userAnswer;
    private int _score = 0;

    public void ShowMonsterImage()
    {
        monsterObject.SetActive(true); // Makes the image visible
    }

    public void HideMonsterImage()
    {
        monsterObject.SetActive(false); // Makes the image invisible
    }
    
    public void ShowCookieImage()
    {
        cookieObject.SetActive(true); // Makes the image visible
    }

    public void HideCookieImage()
    {
        cookieObject.SetActive(false); // Makes the image invisible
    }

    private void GenerateEquasion()
    {
        if (plusMinus == true)
        {
        _number1 = Random.Range(_minValue, _maxValue + 1);
        _number2 = Random.Range(_minValue, _maxAnswerValue - _number1 + 1);
        _answer = _number1 + _number2;

        _number1Text.text = _number1.ToString();
        _number2Text.text = _number2.ToString();
        }
        else
        {
        _number1 = Random.Range(_minValue, _maxValue + 1);
        _number2 = Random.Range(_minValue, _number1 + 1);
        _answer = _number1 - _number2;

        _number1Text.text = _number1.ToString();
        _number2Text.text = _number2.ToString();
        }
    }

    public void CheckAnswer()
    {
        _userAnswer = int.Parse(_answerField.text);
        if (_userAnswer == _answer)
        {
            _feedbackText.text = "Правильно!";
            _score += 1;
            ShowCookieImage();
            MakeFieldReadOnly();
        }
        else
        {
            _feedbackText.text = $"Неправильно :( Правильный ответ: {_answer}.";
            _score -= 1;
            ShowMonsterImage();
            MakeFieldReadOnly();

        }
    }

    public void NewEquation()
    {
        _answerField.text = null;
        _feedbackText.text = null;
        GenerateEquasion();
        MakeFieldEditable();
        _answerField.Select();
        HideCookieImage();
        HideMonsterImage();

    }

        public void MakeFieldReadOnly()
    {
        _answerField.interactable = false; // Disables interaction
    }

    public void MakeFieldEditable()
    {
        _answerField.interactable = true; // Enables interaction
    }

    void Start()
    {
        GenerateEquasion();
        HideCookieImage();
        HideMonsterImage();
        _answerField.Select();
    }

    void Update()
    {
        _scoreText.text = _score.ToString();

    }

}
