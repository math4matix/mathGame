using UnityEngine;
using UnityEngine.SceneManagement;
public class Control : MonoBehaviour
{
    public string sceneNameChange1;
    public string sceneNameChange2;
    public string sceneNameChange3;


    public void NextScene1()
    {
        SceneManager.LoadScene(sceneNameChange1);
    }
    public void NextScene2()
    {
        SceneManager.LoadScene(sceneNameChange2);
    }
    public void NextScene3()
    {
        SceneManager.LoadScene(sceneNameChange3);
    }
    public void quitApplication()
    {
        Application.Quit();
    }
}