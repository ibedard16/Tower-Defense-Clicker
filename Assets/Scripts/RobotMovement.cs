using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public GameObject[] guidePosts;
    public int currentGuidePost = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = guidePosts[0].transform.position;
        currentGuidePost = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, guidePosts[currentGuidePost].transform.position, speed * Time.deltaTime);
        var dist = Vector2.Distance(transform.position, guidePosts[currentGuidePost].transform.position);
        if (dist == 0) {
            currentGuidePost += 1;
            if (currentGuidePost >= guidePosts.Length) {
                Start();
            }
        }
    }
}
