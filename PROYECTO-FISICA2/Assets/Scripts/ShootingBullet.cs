using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootingBullet : MonoBehaviour
{
    public float speed = 0f;
    public float angle = 0f;
    public float mass;
    public Rigidbody2D rb;
    public Transform firepoint;
    float distance = 0f;
    Tank tank;
    public Text distanceTxt;
    public Text xVelocity;
    public Text yVelocity;
    public bool onAir = false;
    public GameObject dotPrefab;


    void Start()
    {
        firepoint = GameObject.Find("ShootingPoint").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D >();
        rb.mass = mass;
        rb.velocity = transform.right * speed;
        tank = GameObject.Find("Tank").GetComponent<Tank>();
        distanceTxt = GameObject.Find("DistanceText").GetComponent<Text>();
        xVelocity = GameObject.Find("XVel").GetComponent<Text>();
        yVelocity = GameObject.Find("YVel").GetComponent<Text>();
        Vector2 pos = transform.position;
        Tank tanque = tank.GetComponent<Tank>();
    }

    void Update()
    {
        distanceTxt.text = getDistance().ToString();

        if (rb.velocity.y > 0.01f || rb.velocity.y < -0.01f)
        {
            yVelocity.text = getYvelocity().ToString();
        } else
        {
            yVelocity.text = "0";
        }

        if (rb.velocity.x > 0.01f)
        {
            xVelocity.text = getXvelocity().ToString();
        }
        else
        {
            xVelocity.text = "0";
        }

        xVelocity.text = getXvelocity().ToString();

        Debug.Log("X" + transform.position.x);
        Debug.Log("Y" + transform.position.y);

        GameObject dot = GameObject.Instantiate(dotPrefab, transform.position, tank.rotationpoint.rotation);
        Destroy(dot, 5f);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            xVelocity.text = "0";
            yVelocity.text = "0";
            tank.instanceBullet = false;
            Destroy(this.gameObject);
            onAir = false;
        }


    }

    public float getXvelocity()
    {

        return rb.velocity.x;
    }

    public float getYvelocity()
    {
        return rb.velocity.y;
    }

    public float getDistance()
    {
        distance = (transform.position.x - firepoint.transform.position.x);
        return distance;
    }
}
