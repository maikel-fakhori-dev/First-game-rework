using UnityEngine;

public class ZombieAnimationEvent : MonoBehaviour
{
    private ZombieController zombieController;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zombieController = GetComponentInParent<ZombieController>();
        zombieController.DoDamage();
    }
    void DealDamage()
    {
        zombieController.DoDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
