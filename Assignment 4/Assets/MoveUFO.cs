using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUFO : MonoBehaviour
{
    private float speed = 1f; // Speed
    private float radius = 0.01f; // Redius (Fixed)
    private float angle = 0f; // Angle of UFO
    public bool move = false;

    void Update()
    {
        if (move == true)
        {
            // Calculate New Position of the GameObject based on the current angle and radius
            float x = Mathf.Sin(angle) * radius;
            float y = transform.position.y; 
            float z = Mathf.Cos(angle) * radius; 

            // Update the position
            transform.position = new Vector3(transform.position.x + x, y, transform.position.z + z);

            // Increment the angle 
            angle += speed * Time.deltaTime;

            // Reset angle if > 360
            if (angle > 360f)
            {
                angle -= 360f;
            }
        }
        
    }


}
