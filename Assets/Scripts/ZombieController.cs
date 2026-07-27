using UnityEngine;
using UnityEngine.PlayerLoop;

public class ZombieController : MonoBehaviour
{
    public float zombieSpeed = 1f;
    public float zombieDamage = 10f;
    public float zombieHealth = 100f;

    private GameObject player;

    //private Rigidbody zombieRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //zombieRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerDirection = (player.transform.position - transform.position).normalized;
        //zombieRb.AddForce(playerDirection * zombieSpeed);
        transform.Translate(playerDirection * zombieSpeed);

        playerDirection.y = 0;

        transform.rotation = Quaternion.LookRotation(playerDirection);
       
    }
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        if (zombieHealth <= 0)
        {
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
