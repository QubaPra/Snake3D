using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Rigidbody _rigidBody;
    private Vector3 _direction = Vector3.zero;
    private List<Transform> segments;
    public Transform segmentPrefab;


    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        Debug.Log("Snake.Start");
        segments = new List<Transform>();
        segments.Add(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(
        Mathf.Round(this.transform.position.x) + _direction.x,
        0.0f,
        Mathf.Round(this.transform.position.z) + _direction.z
        );
    }

    private void Reset()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(this.transform);

        this.transform.position = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }

        else if (other.tag == "Collider")
        {
            Reset();
        }

        if (other.tag == "Segment")
        {

        }
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }
}


