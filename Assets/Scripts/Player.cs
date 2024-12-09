using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel;

        vel = transform.right * Input.GetAxisRaw("Horizontal");
        vel += transform.forward * Input.GetAxisRaw("Vertical"); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            AssBlast();
        }

        rb.AddForce(vel * speed);
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody bullet = GetComponent<Rigidbody>();
    }

    void AssBlast()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        //If the player touches an asteroid...
        if (collision.transform.tag == "Asteroids")
        {
            //...then the player dies
            Destroy(gameObject);
            //Then you SHOULD get sent to the death screen
            SceneManager.LoadScene(2);
        }

    }
    
}
