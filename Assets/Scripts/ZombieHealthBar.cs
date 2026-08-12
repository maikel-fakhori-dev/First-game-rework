using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealthBar : MonoBehaviour
{
    public Slider zombieHealthBar;

    private ZombieController zombieController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        
        zombieController = GetComponentInParent<ZombieController>();
        zombieHealthBar.maxValue = zombieController.zombieHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (zombieController != null)
        {
            zombieHealthBar.value = zombieController.zombieHealth;
        }
    }
}
