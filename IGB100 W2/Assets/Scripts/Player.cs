using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 50.0f; //Player's movespeed
    private Vector3 position;
    public GameObject projectile;
    public float fireRate = 0.15f;
    private float fireTime;

    public float health = 100.0f;

    public GameObject deathEffect;

    public GameObject[] muzzles;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = transform.position;

        Movement();
        Boundary();

        transform.position = position;

        Shoot();

    }
    //Player input controls
    private void Movement()
    {
        //Right movement
        if (Input.GetKey("d"))
            position.x += moveSpeed * Time.deltaTime;

        //Right movement
        if (Input.GetKey("a"))
            position.x -= moveSpeed * Time.deltaTime;

        //Up movement
        if (Input.GetKey("w"))
            position.z += moveSpeed * Time.deltaTime;

        //Down movement
        if (Input.GetKey("s"))
            position.z -= moveSpeed * Time.deltaTime;
    }
    private void Boundary()
    {
        //X Boundary Checks
        if(position.x > GameManager.instance.xBoundary) position.x = GameManager.instance.xBoundary;
        else if (position.x < -GameManager.instance.xBoundary) position.x = -GameManager.instance.xBoundary;

        //Z Boundary Checks
        if (position.z > GameManager.instance.zBoundary) position.z = GameManager.instance.zBoundary;
        else if (position.z < -GameManager.instance.zBoundary) position.z = -GameManager.instance.zBoundary;
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && Time.time > fireTime)
        {

            //Instantiate(projectile, transform.position, transform.rotation);

            //Loop through muzzles array shooting projectile from each
            for (int i = 0; i <= muzzles.Length-1; i++)
            {
                Instantiate(projectile, muzzles[i].transform.position, muzzles[i].transform.rotation);
            }

            fireTime = Time.time + fireRate;
        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }

}
