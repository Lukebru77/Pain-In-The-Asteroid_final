using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    float speed;
    public float topSpeed, bottomSpeed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(topSpeed, bottomSpeed);

        Vector3 rot;
        rot.x = Random.Range(-20, 20);
        rot.y = Random.Range(-20, 20);
        rot.z = Random.Range(-20, 20);

        rb.AddTorque(rot);

        transform.localScale = Vector3.one * Random.Range(0.5f,3f);

        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.back*Time.deltaTime *Random.Range(topSpeed,bottomSpeed));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Destroy(gameObject);
            Ui.score++;
            Ui.gm.UpdateScore();
        }
        else if (collision.transform.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}