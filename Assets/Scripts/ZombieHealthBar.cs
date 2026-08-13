using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthBar : MonoBehaviour
{
    public Slider zombieHealthBar;

    private GameObject player;
    private ZombieController zombieController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        
        zombieController = GetComponentInParent<ZombieController>();
        zombieHealthBar.maxValue = zombieController.zombieHealth;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieController != null)
        {
            zombieHealthBar.value = zombieController.zombieHealth;
        }

        if (math.abs(transform.position.x - player.transform.position.x)> 4 || math.abs(transform.position.z - player.transform.position.z) > 4)
        {
            zombieHealthBar.gameObject.SetActive(false);
        }
        else
        {
            zombieHealthBar.gameObject.SetActive(true);
        }
    }
}
