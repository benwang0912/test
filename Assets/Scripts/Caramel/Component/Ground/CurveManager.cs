﻿using UnityEngine;
using System.Collections;

public class CurveManager : MonoBehaviour
{
    //in the Curve
    
    void Awake()
    {
        Transform ground = transform.GetChild(0), newground;
        float d = (2 * Mathf.PI) / GroundCount, theta = d;
        float dz = Distance / GroundCount, z = dz;
        float forward = IsForward ? 1f : -1f ;
        //spiral track???
        //float d0 = (Mathf.PI) / GroundCount, thetad0 = d0;
        //float d1 = (Mathf.PI) / GroundCount, thetad1 = d1;
        //float dx = DeltaX / GroundCount, x = dx;

        ground.localPosition = new Vector3(0f, -Radius);
        ground.localRotation = Quaternion.Euler(180f * Vector3.up);

        //to set StartCurveMotion
        ground.gameObject.AddComponent<StartCurveMotion>();
        StartCurveMotion scm = ground.GetComponent<StartCurveMotion>();
        Transform parent = transform.parent;
        scm.Cm = this;
        scm.Radius = Radius - 1f;
        scm.Distance = IsForward ? Distance : -Distance;
        scm.CurveCenter = transform.localPosition;
        

        for (int i = 1; i <= GroundCount; ++i)
        {
            newground = Instantiate(ground);
            newground.parent = transform;
            newground.localPosition = new Vector3(Radius * Mathf.Cos(theta - Mathf.PI / 2), Radius * Mathf.Sin(theta - Mathf.PI / 2), forward * z);
            newground.localRotation = Quaternion.Euler(180f * Vector3.up + -theta * 180 / Mathf.PI * Vector3.forward);
            theta += d;
            z += dz;
        }

        //ground.gameObject.AddComponent<StartCurveMotion>();
    }
    
    public float Radius, Distance;
    public int GroundCount;
    public bool IsForward, CurveStart = false;
}