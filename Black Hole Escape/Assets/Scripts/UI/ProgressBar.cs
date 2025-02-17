using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    public float moveSpeed = 1f;        
    public float downwardPush = 0.5f;   
    public Transform endPoint;          
    public string nextSceneName;        

    private LineRenderer lineRenderer;

    void Start()
    {
        // Add a LineRenderer component dynamically
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 1.25f;
        lineRenderer.endWidth = 1.25f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Standard shader
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void Update()
    {
        if (transform.position.y < endPoint.position.y)  // Check if the object reached the endpoint
        {
            MoveUpward();
            UpdateTrail();
        }
        else
        {
            TransitionToNextScene();
        }
    }

    void MoveUpward()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }

    void UpdateTrail()
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Asteroid"))
        {
            MoveSlightlyDownward();
        }
    }

    void MoveSlightlyDownward()
    {
        transform.position -= new Vector3(0, downwardPush, 0);
    }

    void TransitionToNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName); // Load the next scene
        }
        else
        {
            Debug.LogError("Next scene name is not set! Assign it in the Inspector.");
        }
    }
}

