using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 direction = Vector2.right;

    //[Header("Snake speed")]
    //public float speed = 1.0f;

    List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;

    void Start()
    {
        ResetState();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.A)) direction = Vector2.left;
        else if (Input.GetKeyDown(KeyCode.S)) direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.D)) direction = Vector2.right;
    }


    void FixedUpdate()
    {
        for(int i = (segments.Count - 1); i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
         transform.position = new Vector3(Mathf.Round(transform.position.x) + direction.x, Mathf.Round(transform.position.y) + direction.y, 0.0f);
    }

    void ResetState()
    {
        for(int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        for(int i = 1; i < initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
        transform.position = Vector3.zero;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food")) Grow();
        else if (collision.CompareTag("Obstacle")) ResetState();
    }

    void Grow()
    {
        Transform newSegment = Instantiate(segmentPrefab);
        newSegment.position = segments[segments.Count - 1].position; // позиция новой соответствует хвосту текущей змейки
        segments.Add(newSegment);
    }
}
