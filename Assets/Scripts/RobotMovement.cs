using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public GameObject[] guidePosts;
    public int currentGuidePost = 0;

    private Animator animator;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        TeleportToFirstPost();
    }

    void TeleportToFirstPost() {
        transform.position = guidePosts[0].transform.position;
        currentGuidePost = 0;
        TargetNextGuidePost();
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive) {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, guidePosts[currentGuidePost].transform.position, speed * Time.deltaTime);
        var dist = Vector2.Distance(transform.position, guidePosts[currentGuidePost].transform.position);
        if (dist == 0) {
            TargetNextGuidePost();
        }
    }

    void TargetNextGuidePost() {
        if (currentGuidePost == guidePosts.Length - 1) {
            TeleportToFirstPost();
            return;
        }

        var currentPostPosition = guidePosts[currentGuidePost].transform.position;
        var nextPostPosition = guidePosts[currentGuidePost + 1].transform.position;
        var travelVector = nextPostPosition - currentPostPosition;
        var travelAngle = Vector2.SignedAngle(travelVector, new Vector2(1,0));

        if (travelAngle < 45 && travelAngle >= -45) {
            animator.Play("Robot_Right");
        } else if (travelAngle >= 45 && travelAngle < 135) {
            animator.Play("Robot_Front");
        } else if (travelAngle < -45 && travelAngle >= -135) {
            animator.Play("Robot_Back");
        } else if (travelAngle >= 135 || travelAngle < -135) {
            animator.Play("Robot_Left");
        }

        currentGuidePost += 1;
    }

    public void Kill() {
        alive = false;
        animator.Play("Explosion");
    }

    void ExplosionEnd() {
        Destroy(gameObject);
    }
}
