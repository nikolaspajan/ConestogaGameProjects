using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiltPlatform : MonoBehaviour
{
    private float rotationZ = 0f;
    private float rotationX = 0f;

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3) 
        { 
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotationZ += 40 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
              rotationZ -= 40 * Time.deltaTime;
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rotationX += 40 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rotationX -= 40 * Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                rotationZ += 40 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                rotationZ -= 40 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rotationX += 40 * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotationX -= 40 * Time.deltaTime;
            }
        }
        
        rotationZ = Mathf.Clamp(rotationZ, -25, 25);
        var rotZ = transform.localEulerAngles;
        rotZ.z = rotationZ;
        transform.localEulerAngles = rotZ;

        rotationX = Mathf.Clamp(rotationX, -25, 25);
        var rotX = transform.localEulerAngles;
        rotX.x = rotationX;
        transform.localEulerAngles = rotX;
    }
}
