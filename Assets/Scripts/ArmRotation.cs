using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public GameObject player;
    public int offset = 90;

    private void FixedUpdate()
    {
        //Vector3 diff = GetWorldPosOnPlane(Input.mousePosition, -10) - transform.position;
        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 pos = Input.mousePosition;
        pos.z = 10;
        Vector3 diff = Camera.main.ScreenToWorldPoint(pos);
        diff = worldPos();
        Debug.Log(diff);
        
        diff.Normalize();

        float rotationAngle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        Debug.Log(rotationAngle);

        float angle = AngleBetweenPoints(transform.position, diff);
        transform.rotation = Quaternion.Euler(0f, 0f, angle + 0f);

        //Debug.DrawRay(doo.origin, doo.direction * 10, Color.red);
    }

    private float AngleBetweenPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }



    private Vector3 worldPos()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane xy = new Plane(Vector3.forward, 0);
        if (xy.Raycast(ray, out distance))
            return ray.GetPoint(distance);
        return Vector3.zero;
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(worldPos(), 0.25f);
    }







    private Vector3 GetWorldPosOnPlane(Vector3 screenPos, float z)
    {
        // Change vec3 to forward to up maybe
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
}
