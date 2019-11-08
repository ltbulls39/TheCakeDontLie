using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    public GameObject player;
    public int offset = 90;

    private void FixedUpdate()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Vector3 pos = Input.mousePosition;

        difference.Normalize();

        float rotationAngle2 = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAngle2 + 0f);

        if (rotationAngle2 < -90 || rotationAngle2 > 90)
        {
            if (player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationAngle2);
            }
            else if (player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationAngle2);
            }
        }
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
