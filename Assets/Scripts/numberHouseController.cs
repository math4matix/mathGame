using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class numberHouseController : MonoBehaviour
{
    [SerializeField]
    private int _minValue = 1;
    [SerializeField]
    private int _maxValue = 10;
    [SerializeField]
    public GameObject cookieObject;
    [SerializeField]
    public GameObject monsterObject;

    private int _number1;
    private int _number2;
    private int _number3;
    private int _number4;
    private int _number5;
    private int _number6;
    private int _number7;
    private int _number8;
    private int _number9;
    private int _number10;
    private int _answer;
    private int _userAnswer1;
    private int _userAnswer2;
    private int _userAnswer3;
    private int _userAnswer4;
    private int _userAnswer5;
    private int _userAnswer6;
    private int _userAnswer7;
    private int _userAnswer8;
    private int _userAnswer9;
    private int _userAnswer10;
    private int nums = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    private int randNums = {};
    // Array of strings to display
    public string[] textArray;

    // List of 10 Text UI elements
    public Text[] textBoxes;


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

    static void Shuffle(int[] array)
    {
        Random rand = new Random();
        int n = array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            int j = rand.Next(0, i + 1);

            // Swap array[i] with the element at random index
            Swap(array, i, j);
        }
    }

    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    
    private void GenerateEquasion()
    {
        randNums = nums.Shuffle();

        

    }
    void DisplayText()
    {
        // Ensure there are 10 text boxes
        if (textBoxes.Length != 10)
        {
            Debug.LogError("Please assign exactly 10 text boxes in the inspector.");
            return;
        }

        // Loop through the array and display text in each box
        for (int i = 0; i < textBoxes.Length; i++)
        {
            // Check if there's corresponding text in the array
            if (i < textArray.Length)
            {
                textBoxes[i].text = textArray[i];
            }
            else
            {
                // Clear any remaining text boxes if the array has fewer elements
                textBoxes[i].text = string.Empty;
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
