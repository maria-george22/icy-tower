using UnityEngine;

public class VerticalBackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    private float height;

    void Start()
    {
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void Update()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);

        // If the background moves completely below the camera
        if (transform.position.y < -height)
        {
            // Move it back to the top of the other background
            transform.position += new Vector3(0, height * 2f, 0);
        }
    }
}
