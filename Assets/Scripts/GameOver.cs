using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool gameOver = false;
    private GameObject player;

    private PlayerController playerController;
    private Weapon weapon;
    private ZombieSpawnManager zombieSpawnManager;

    private FirstPersonView firstPersonView;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombieSpawnManager = GameObject.Find("Zombie Spawn Manager").GetComponent<ZombieSpawnManager>();
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        weapon = playerController.GetComponentInChildren<Weapon>();
        firstPersonView = playerController.GetComponentInChildren<FirstPersonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.playerHealth <= 0)
        { if (gameOver == false)
            {
                GameOverFunction();
                gameOver = true;
            }
        }
    }
    public void GameOverFunction()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
        playerController.enabled = false;
        weapon.enabled = false;
        firstPersonView.enabled = false;
        
    }
    public void Retry()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
        gameOver = false;
        playerController.enabled = true;
        weapon.enabled = true;
        player.transform.position = new Vector3(0,1,0);
        playerController.playerHealth = 100;
        zombieSpawnManager.score = 0;
        firstPersonView.enabled = true;
        zombieSpawnManager.enemyCount = 0;
        zombieSpawnManager.waveNumber = 1;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Zombie"))
        {
            Destroy(g);
        }
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
