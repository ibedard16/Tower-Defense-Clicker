﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float speed;
    public GameObject[] guidePosts;
    public int currentGuidePost = 0;
    public WaveMaker wave;
    public bool alive = true;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
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
            RemovePlayerHealth();
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

    void RemovePlayerHealth() {
        wave.RemoveLife();
        ExplosionEnd();
    }

    public void Kill() {
        wave.TM.AddKill();
        alive = false;
        animator.Play("Explosion");
    }

    void ExplosionEnd() {
        wave.Enemies.Remove(this);
        Destroy(gameObject);
    }
}
