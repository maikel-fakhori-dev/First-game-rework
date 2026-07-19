using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage = 10f;

    private GameObject zombie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       zombie = GameObject.FindWithTag("Zombie");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
            zombie.GetComponent<ZombieController>().zombieHealth -= bulletDamage;
        }
    }
}
