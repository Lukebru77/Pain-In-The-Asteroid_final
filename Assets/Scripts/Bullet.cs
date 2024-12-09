using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10000f;
    private bool isTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity *= speed;
        transform.rotation = Quaternion.Euler(90f, 0, 0f);
        Destroy(gameObject, 0.5f);
    }

    private void Update()
    {
        rb.AddForce(transform.up * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Asteroids")
        {
            Destroy(gameObject);
        }
    }
}
