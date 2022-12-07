using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public GameObject spawnObject;
    public BoxCollider Area;
    public float maxTime;
    public float minTime;

    //current time
    private float time;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomTime();
        time = minTime;
        if (time >= spawnTime)
        {
          if (GameObject.Find("spawnObject")) return;
          SpawnObject();
          SetRandomTime();
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spawnObject")
        {
            Destroy(spawnObject);
        }
    }
    void SpawnObject()
    {
            time = minTime;
            Bounds bounds = this.Area.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            this.transform.position = new Vector3(Mathf.Round(x), 0, Mathf.Round(z));
            Instantiate(spawnObject, this.transform.position, spawnObject.transform.rotation);

    }

    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
