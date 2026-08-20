using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject menuUI;

    private GameObject player;

    private PlayerController playerController;
    private Weapon weapon;
    private FirstPersonView firstPersonView;
    private void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        weapon = playerController.GetComponentInChildren<Weapon>();
       firstPersonView = playerController.GetComponentInChildren<FirstPersonView>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        playerController.enabled = true;
        weapon.enabled = true;
        firstPersonView.enabled = true;
    }
    public void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        playerController.enabled = false;
        weapon.enabled = false;
        firstPersonView.enabled = false;
    }
    public void OnMenuClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
