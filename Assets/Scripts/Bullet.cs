using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10f;

    private GameObject zombie;
    private GameObject floor;
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    void Start()
    {
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
            Debug.Log("hit");
            Destroy(gameObject);
            collision.gameObject.GetComponent<ZombieController>().zombieHealth -= bulletDamage;
        }

        if (collision.gameObject == floor)
        {
            Destroy(gameObject);
        }
    }
}
