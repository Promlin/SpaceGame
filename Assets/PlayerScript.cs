using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject lazerShot;
    public Transform lazerGun; //position of object
    public float shotDelay;//задержка выстрела
    public float xMin, xMax, zMin, zMax;
    public float speed;
    public float tilt;
    Rigidbody playerShip;

    float nextShot;

    // Start is called before the first frame update
    void Start()
    {
        //Вызывается при попадании объектов на сцену
        playerShip = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Вызывается на каждый кадр (постоянные действия)
        float moveHorizontal = Input.GetAxis("Horizontal");
        //[-1 - left   +1 - right]
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical)*speed;
        
        playerShip.rotation = Quaternion.Euler(tilt * playerShip.velocity.z, 0, -tilt * playerShip.velocity.x);

        float newXposition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float newZposition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(newXposition, 0, newZposition);


        if (Time.time > nextShot && Input.GetButton("Fire1")) 
        {
            Instantiate(lazerShot, lazerGun.position, Quaternion.identity);
            nextShot = Time.time + shotDelay;
        }
        
    }
}
