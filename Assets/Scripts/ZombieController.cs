using UnityEngine;
using UnityEngine.PlayerLoop;


public class ZombieController : MonoBehaviour
{
    public float zombieSpeed = 1f;
    public float zombieDamage = 10f;
    public float zombieHealth = 100f;
    
    public int scoreAdd;
    

    private GameObject player;
    private ZombieSpawnManager spawnManager;
    //private Rigidbody zombieRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //zombieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        spawnManager = GameObject.Find("Zombie Spawn Manager").GetComponent<ZombieSpawnManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        //zombieRb.AddForce(playerDirection * zombieSpeed);
        //transform.Translate(playerDirection * zombieSpeed);

        playerDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(playerDirection);
        transform.Translate(new Vector3(0,0,zombieSpeed));
       
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().playerHealth -= zombieDamage;
        }

    }
}
