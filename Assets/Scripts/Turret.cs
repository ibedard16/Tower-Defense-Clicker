﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public TurretMaker parent;
    public float fireSpeed = 1;

    private float cooldown = 0;

    void Start()
    {
        
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown < 0) cooldown = 0;
        if(cooldown == 0){
            if(parent.WM.getRobots().Count > 0){
                float min = -1;
                RobotMovement closest = null;
                foreach (RobotMovement r in parent.WM.getRobots()){
                    float dist = Vector3.Distance(r.transform.position, transform.position);
                    if(dist < min || min == -1){
                        min = dist;
                        closest = r;
                    }
                }
                Vector3 diff = closest.transform.position - transform.position;
                float ang = Vector3.Angle(diff, new Vector3(0, 1, 0));

                if(ang > 157.5){
                    TransitionTo("FireDown");
                }else if(ang > 112.5 && diff.x > 0){
                    TransitionTo("FireDownRight");
                }else if(ang > 67.5 && diff.x > 0){
                    TransitionTo("FireRight");
                }else if(ang > 22.5 && diff.x > 0){
                    TransitionTo("FireUpRight");
                }else if(ang > 112.5 && diff.x < 0){
                    TransitionTo("FireDownLeft");
                }else if(ang > 67.5 && diff.x < 0){
                    TransitionTo("FireLeft");
                }else if(ang > 22.5 && diff.x < 0){
                    TransitionTo("FireUpLeft");
                }else{
                    TransitionTo("FireUp");
                }
                Fire(closest);
                //print("Closest Robot: " + min);
            }else{
                //print("No Robots");
            }
        }
    }

    void Fire(RobotMovement r){
        cooldown = fireSpeed;
    }

    private string currentAnimation;
    void TransitionTo(string name)
    {
        // Check if the animation is already playing or not/
        //if (currentAnimation != name)
        //{
            currentAnimation = name;
            GetComponent<Animator>().Play(name);
        //}
    }
}