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
    private TMP_InputField _answerField;
    [SerializeField]
    private int _minValue = 1;
    [SerializeField]
    private int _maxValue = 10;
    
    private int _number1;
    private int _number2;
    private int _answer;
    private int _userAnswer;
    public int score = 0;

    private int RandomNumber()
    {
        return Random.Range(_minValue, _maxValue + 1);
    }

    private void GenerateEquasion()
    {
        _number1 = RandomNumber();
        _number2 = RandomNumber();
        _answer = _number1 + _number2;

        _number1Text.text = _number1.ToString();
        _number2Text.text = _number2.ToString();
    }

    public void CheckAnswer()
    {
        _userAnswer = int.Parse(_answerField.text);
        if (_userAnswer == _answer)
        {
            _feedbackText.text = "Правильно!";
            score += 1;
        }
        else
        {
            _feedbackText.text = $"Неправильно :( Правильный ответ: {_answer}.";
            score -= 1;
        }
    }

    public void NewEquation()
    {
        _answerField.text = null;
        _feedbackText.text = null;
        GenerateEquasion();
    }

    void Start()
    {
        GenerateEquasion();
    }

}
