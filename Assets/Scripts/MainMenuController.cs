using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
   


    public void OnStartClick()
    {
        SceneManager.LoadScene("Zombie Fight Scene");
        Time.timeScale = 1;
    }

    public void OnExitClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
