using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitter : MonoBehaviour
{
    public GameObject asteroid;
    public float minDelay, maxDelay;
    float nextLaunch;

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLaunch)
        {
            float size  = transform.localScale.x;
            float xPos = Random.Range(-size/2, size/2);
            Vector3 asteroidPosition = new Vector3(xPos, 0, transform.position.z);

            GameObject newAsteroid = Instantiate(asteroid, asteroidPosition, Quaternion.identity);

            float resize = Random.Range(0.3f, 1);
            newAsteroid.transform.localScale *= resize;

            nextLaunch = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
