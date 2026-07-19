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
            //Debug.DrawRay(bulletSpawn.position, bulletSpawn.forward, Color.white ,10000);
        }
    }
   private void FireWeapon()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            // ...then use the exact point that was hit as the target.
            targetPoint = hit.point;
        }
        else
        {
            // If the ray doesn't hit anything, choose a point 1000 units away
            // along the ray. This gives the bullet somewhere to travel.
            targetPoint = ray.GetPoint(1000f);
        }
        Vector3 shootDirection = (targetPoint - bulletSpawn.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(shootDirection*bulletSpeed,ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
