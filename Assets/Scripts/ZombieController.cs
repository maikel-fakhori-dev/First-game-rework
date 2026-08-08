using UnityEngine;
using UnityEngine.PlayerLoop;


public class ZombieController : MonoBehaviour
{
    public float zombieSpeed = 1f;
    public float zombieDamage = 10f;
    public float zombieHealth = 100f;
    public int scoreAdd;
    public Animator zombieAnimator;

    private bool canAttack;
    private GameObject player;
    private ZombieSpawnManager spawnManager;
    
    //private Rigidbody zombieRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        zombieAnimator = GetComponentInChildren<Animator>();
        //zombieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Zombie Spawn Manager").GetComponent<ZombieSpawnManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        canAttack = zombieAnimator.GetBool("canAttack");
        Vector3 playerDistance = player.transform.position - transform.position;
        Vector3 playerDirection = playerDistance.normalized;
        //zombieRb.AddForce(playerDirection * zombieSpeed);
        //transform.Translate(playerDirection * zombieSpeed);

        playerDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(playerDirection);

        if (canAttack == false)
        {
            transform.Translate(new Vector3(0, 0, zombieSpeed));
        }
       
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        if (zombieHealth <= 0)
        {
            spawnManager.AddScore(scoreAdd);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().playerHealth -= zombieDamage;
            zombieAnimator.SetBool("canAttack",true);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player)
        {
            zombieAnimator.SetBool("canAttack", false);
        }
    }
}
