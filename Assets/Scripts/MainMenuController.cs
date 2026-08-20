using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    private GameObject player;

    private PlayerController playerController;
    private Weapon weapon;

    public void OnStartClick()
    {
        SceneManager.LoadScene("Zombie Fight Scene");
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        weapon = playerController.GetComponentInChildren<Weapon>();
        playerController.enabled = true;
        weapon.enabled = true;
    }

    public void OnExitClick()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
