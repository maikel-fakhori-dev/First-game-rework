using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;

    public float bulletSpeed = 30f;
    public float bulletPrefabLifeTime = 5.0f;

    public Transform bulletSpawn;

    private InputSystem_Actions action;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }
   private void FireWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized*bulletSpeed,ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
