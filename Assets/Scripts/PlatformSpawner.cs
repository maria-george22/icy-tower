using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int initialPlatforms = 10;  // Number of platforms to spawn initially
    public float minY = 1f;  // Minimum height of platforms (Used only for initial spawn)
    public float maxY = 3f;  // Maximum height of platforms (Used only for initial spawn)
    public float minX = -2f;  // Minimum X position of platforms
    public float maxX = 2f;  // Maximum X position of platforms
    public float moveSpeed = 3f;  // Speed at which platforms move down
    public float platformSpacing = 1f;  // Vertical spacing between platforms
    private bool gameStarted = false; //boolean flag to begin scrolling


    private GameObject[] platforms;  // Array to hold the platforms

    void Start()
    {
        platforms = new GameObject[initialPlatforms];  // Initialize the array to hold the platforms

        // Spawn initial platforms
        for (int i = 0; i < initialPlatforms; i++)
        {
            platforms[i] = SpawnPlatform(i);
        }
    }

    void Update()
    {
        if (!gameStarted) return;

        // Move platforms down like the background
        MovePlatformsDown();

        // Recycle platforms (move them to the top) when they move out of the camera view
        RecyclePlatforms();
    }


    public void StartScrolling()
    {
        gameStarted = true;
    }



    void MovePlatformsDown()
    {
        // Move each platform downwards over time
        foreach (GameObject platform in platforms)
        {
            platform.transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);  // Move platforms down
        }
    }

    void RecyclePlatforms()
    {
        // Loop through each platform and check if it's out of the screen
        for (int i = 0; i < platforms.Length; i++)
        {
            // If the platform is below the camera's view, move it to the top
            if (platforms[i].transform.position.y < Camera.main.transform.position.y - 10f)  // Camera height offset
            {
                // Get the previous platform to calculate the new Y position
                GameObject previousPlatform = (i == 0) ? platforms[platforms.Length - 1] : platforms[i - 1];
                float newY = previousPlatform.transform.position.y + platformSpacing;

                // Randomize X position within limits
                float newX = Random.Range(minX, maxX);

                // Reposition the platform to the top, just above the previous platform
                platforms[i].transform.position = new Vector3(newX, newY, 0f);
            }
        }
    }

    GameObject SpawnPlatform(int index)
    {
        // Randomize the position and size of the platform
        float y = index * platformSpacing;  // Start from 0 and stack platforms vertically with no gaps
        float x = Random.Range(minX, maxX);
        float width = Random.Range(1f, 4f);  // Width of the platform

        // Instantiate the platform at a random position
        GameObject newPlatform = Instantiate(platformPrefab, new Vector3(x, y, 0), Quaternion.identity);
        newPlatform.transform.localScale = new Vector3(width, 0.3f, 0.2f);  // Adjust platform size
        newPlatform.transform.parent = transform;  // Keep it under the spawner's hierarchy

        return newPlatform;
    }
}

