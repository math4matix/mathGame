using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;

public class MathQuizManager : MonoBehaviour
{
    [Header("Problem and Input Field References")]
    public TMP_Text[] problemTexts; // Array of problem Text UI elements
    public TMP_InputField[] answerInputs; // Array of InputField UI elements
    public Button checkButton; // Button to check all answers
    public Button resetButton; // Button to reset the game
    public TMP_Text feedbackText; // Feedback for the current round
    public TMP_Text scoreText; // Text to display total score
    public int maxNumber = 10; // Maximum number for problems

    private int[] problems; // Array of problem values
    private int totalScore; // Total correct answers across rounds

    void Start()
    {
        totalScore = 0; // Initialize score
        UpdateScoreText(); // Update the score display
        InitializeGame(); // Set up the game for the first time

        // Add listeners to buttons
        checkButton.onClick.AddListener(CheckAnswers);
        resetButton.onClick.AddListener(InitializeGame);
    }

    void InitializeGame()
    {
        // Generate and shuffle problems
        problems = new int[maxNumber];
        for (int i = 0; i < problems.Length; i++)
        {
            problems[i] = i + 1; // Random values from 0 to 10
        }
        ShuffleArray(problems);

        // Assign problems to text boxes and clear input fields
        for (int i = 0; i < problemTexts.Length; i++)
        {
            problemTexts[i].text = problems[i].ToString();
            answerInputs[i].text = "";
            answerInputs[i].image.color = Color.white; // Reset input field colors
        }

        // Clear feedback
        feedbackText.text = "Реши примеры!";
    }

    public void CheckAnswers()
    {
        int correctAnswers = 0;

        // Loop through all problems and validate answers
        for (int i = 0; i < problems.Length; i++)
        {
            int expectedAnswer = maxNumber - problems[i];
            int playerAnswer;

            // Check if input is valid and correct
            if (int.TryParse(answerInputs[i].text, out playerAnswer) && playerAnswer == expectedAnswer)
            {
                correctAnswers++;
                answerInputs[i].image.color = Color.green; // Highlight correct answer field
            }
            else
            {
                answerInputs[i].image.color = Color.red; // Highlight incorrect answer field
            }
        }

        // Update feedback and score
        feedbackText.text = correctAnswers + " из " + maxNumber + " правильных ответов!";
        totalScore += correctAnswers;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Очки: " + totalScore.ToString();
    }

    private void ShuffleArray(int[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            int temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}