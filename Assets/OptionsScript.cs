using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsScript : MonoBehaviour
{
    public void Back(){
        SceneManager.LoadScene("MainMenu");
    }
}
