using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;

    void Start()
    {
        RandomizePosition();
    }
    void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")) RandomizePosition();
    }
}
