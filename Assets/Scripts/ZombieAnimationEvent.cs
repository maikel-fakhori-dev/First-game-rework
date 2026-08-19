using Unity.VisualScripting;
using UnityEngine;

public class ZombieAnimationEvent : MonoBehaviour
{
    private ZombieController zombieController;
    private GameObject player;
    private GameObject zombie;
    private bool isTouching;

    private PlayerController playerController;
    private Weapon weapon;


    private void Awake()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        weapon = playerController.GetComponentInChildren<Weapon>();
        playerController.enabled = true;
        weapon.enabled = true;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        zombieController = GetComponentInParent<ZombieController>();
        

    }
    void DealDamage()
    {
        if ( zombieController.canAttack == true)
        {
            zombieController.DoDamage();
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("touching not in if statement");
    //    if (collision.gameObject == player)
    //    {
    //        isTouching = true;
    //        Debug.Log("touching");
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject == player)
    //    {
    //        isTouching = false;
    //    }
    //}
    // Update is called once per frame
    void Update()
    {
        
    }


}
