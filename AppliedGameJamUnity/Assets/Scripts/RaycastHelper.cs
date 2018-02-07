using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class RaycastHelper  {

    public const float MAX_RAY_DISTANCE = 100000f;

    public static Vector3 GetMousePositionInScene(float y = 0) {
        Plane plane = new Plane(Vector3.up, y);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance = 0f;// MAX_RAY_DISTANCE;
        if (plane.Raycast(ray, out distance)) {
            Vector3 hitPoint = ray.GetPoint(distance);
            return hitPoint;
        }
        return Vector3.zero;


        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //// create a plane at 0,0,0 whose normal points to +Y:
        //Plane hPlane = new Plane(Vector3.up, Vector3.zero);
        //// Plane.Raycast stores the distance from ray.origin to the hit point in this variable:
        //float distance = 0;
        //// if the ray hits the plane...
        //if (hPlane.Raycast(ray, out distance)) {
        //    // get the hit point:
        //    temp.transform.position = ray.GetPoint(distance);
        //}
    }
}
