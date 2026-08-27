using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10f;

    private GameObject zombie;
    private GameObject floor;
    // Start is called once before the first execution of Update after the MonoBehaviour is create
    private AudioSource audioSource;
    public AudioClip zombieDamaged;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        floor = GameObject.Find("Floor");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            //Debug.Log("hit");
            
            collision.gameObject.GetComponent<ZombieController>().zombieHealth -= bulletDamage;
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(zombieDamaged,0.5f);
            }
            Destroy(gameObject,1);
        }

        if (collision.gameObject == floor)
        {
            Destroy(gameObject);
        }
    }
   
}
