using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("Play");
    }

    public void Tutorial(){
        SceneManager.LoadScene("Tutorial");
    }

    public void Options(){
        SceneManager.LoadScene("Options");
    }

    public void QuitGame(){
        Application.Quit();
    }
}
