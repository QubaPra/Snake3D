using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector3 direction = Vector3.zero;
    private Vector3 input;
    public AudioSource collectAudio;
    public AudioSource drinkAudio;
    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        // Only allow turning up or down while moving in the x-axis
        //if (direction.x != 0f)
        //{
        PlayerStats.Instance.pressedKey();
        if (Input.GetKeyDown(KeyCode.W))
        {
            input = Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            input = Vector3.back;
        }
        //}
        // Only allow turning left or right while moving in the y-axis
        //else if (direction.z != 0f)
        //{
        if (Input.GetKeyDown(KeyCode.D))
        {
            input = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            input = Vector3.left;
        }
        //}
    }

    private void FixedUpdate()
    {
        // Set the new direction based on the input
        if (input != Vector3.zero)
        {
            direction = input;
        }

        // Set each segment's position to be the same as the one it follows. We
        // must do this in reverse order so the position is set to the previous
        // position, otherwise they will all be stacked on top of each other.
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        // Move the snake in the direction it is facing
        // Round the values to ensure it aligns to the grid
        float x = Mathf.Round(transform.position.x) + direction.x;
        float z = Mathf.Round(transform.position.z) + direction.z;

        transform.position = new Vector3(x, 0.0f, z);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
    }

    public void ResetState()
    {
        direction = Vector3.right;
        transform.position = Vector3.zero;

        // Start at 1 to skip destroying the head
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        // Clear the list but add back this as the head
        segments.Clear();
        segments.Add(transform);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            PlayerStats.Instance.addPointP2();
            collectAudio.Play();
            Grow();
        }
        else if (other.gameObject.CompareTag("Collider") || other.gameObject.CompareTag("Player1"))
        {
            PlayerStats.Instance.P2reset();
            ResetState();
        }
        else if (other.gameObject.CompareTag("Beer"))
        {
            drinkAudio.Play();
            //piwo();
        }
    }

    public void piwo()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            input = Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            input = Vector3.forward;
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            input = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            input = Vector3.left;
        }
    }

    void Awake()
    {

    }
}
