using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    float speed = 20f;
    float angle = 0f;
    public Transform firepoint;
    public Transform rotationpoint;
    public GameObject bulletPrefab;
    public bool instanceBullet = false;
    public static bool isPaused = false;


    void Start()
    {
        rotationpoint.transform.rotation = Quaternion.Euler(Vector3.forward * angle);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && instanceBullet == false)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }

        rotationpoint.transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    public void Shoot()
    { 
        instanceBullet = true;
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firepoint.position, rotationpoint.rotation);

        bullet.GetComponent<ShootingBullet>().speed = speed;
        bullet.GetComponent<ShootingBullet>().angle = angle;
        ShootingBullet bulletScript = bullet.GetComponent<ShootingBullet>();
        bulletScript.onAir = true;
    }

    public void Angle_Changed(string newText)
    {
        float temp = float.Parse(newText);

        if (temp >= 0f && temp <= 90f)
        {
            angle = temp;
        } else
        {
            if (temp > 90f)
            {
                angle = 90f;
            }

            if (temp < 0f)
            {
                angle = 0f;
            }
        }
    }

    public void Velocity_Changed(string newText)
    {
        float temp = float.Parse(newText);

        speed = temp;
    }

    void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }
}
