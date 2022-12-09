using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    /**Successful rotate around world Script.**/
    //serlialized to show up in inspector for rotating around planet.
    [SerializeField] private Camera camera;
    [SerializeField] private Transform AroundWorld;
    private Vector3 Position;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Position = camera.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = Position - camera.ScreenToViewportPoint(Input.mousePosition);

            //set point to move camera around (planet's origin)
            camera.transform.position = AroundWorld.position; //new Vector3();

            camera.transform.Rotate(new Vector3(x: 1, y: 0, z: 0), direction.y * 180); //apply rotation on X axis
            camera.transform.Rotate(new Vector3(x: 0, y: 1, z: 0), -direction.x * 180, Space.World); //apply rotation on y axis, relative to the parameter space.world
            camera.transform.Translate(new Vector3(x: 0, y: 0, z: -20));

            Position = camera.ScreenToViewportPoint(Input.mousePosition);

        }
        if (Input.GetMouseButton(1))
        {
            Debug.Log("want the character to move here");
            // I need to put a raycast here that collides with the ground to select a face.
            
        }

    }
}
