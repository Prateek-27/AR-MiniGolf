using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
public class spawn_ufo_windmill : MonoBehaviour
{
    public GameObject windmill; // Windmill Prefab
    public GameObject ufo; // UFO Prefab
    public Vector3 spawnLocation; // The location to spawn the prefab
    public GameObject planeManagerGO;
    public ARRaycastManager raycastManager; 
    public ARPlaneManager planeManager;
    public GameObject debugger;
    public GameObject collider; // Collider Prefab
    public bool movement;
    GameObject obj;
    GameObject cube;
    public bool ufoplace = false;
    public bool windmillplace = false;
    public GameObject ball;
    public bool colliderPlace = false;

    void Start()
    {
        raycastManager = planeManagerGO.GetComponent<ARRaycastManager>(); 
        planeManager = planeManagerGO.GetComponent<ARPlaneManager>();
        //debugger = GameObject.Find("/Debugger/Panel/Text");
    }

    public void UFO()
    {
        // Place / Spawn UFO
        // Raycast from the touch position into the AR environment
        Ray raycasted = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.Log(debugger.GetComponent<Text>().text);
        //debugger.GetComponent<Text>().text = "UFO Debugg";
        //GameObject obj = Instantiate(ufo);

        if (Physics.Raycast(raycasted, out hit))
        {
            ARPlane planeSelected = hit.transform.GetComponent<ARPlane>();
            if (planeSelected != null)
            {
                colliderPlace = false;
                //debugger.GetComponent<Text>().text = planeSelected.transform.position.ToString();
                spawnLocation = new Vector3(planeSelected.transform.position.x, planeSelected.transform.position.y + ufo.transform.localScale.y/2, planeSelected.transform.position.z);
                obj = Instantiate(ufo, spawnLocation, Quaternion.identity);
                movement = true;
                ufoplace = true;
                //moveLeft(obj);


            }

            // Spawn the object at the hit position and rotation
            //GameObject obj = Instantiate(windmill);
            //debugger.GetComponent<Text>().text = "Debugg";

        }
    }

    public void Windmill()
    {
        // Place / Spawn Windmill
        // Raycast from the touch position into the AR environment
        Ray raycasted = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Debug.Log(debugger.GetComponent<Text>().text);
        //debugger.GetComponent<Text>().text = "UFO Debugg";
        //GameObject obj = Instantiate(ufo);

        if (Physics.Raycast(raycasted, out hit))
        {
            ARPlane planeSelected = hit.transform.GetComponent<ARPlane>();
            if (planeSelected != null)
            {
                colliderPlace = false;
                //debugger.GetComponent<Text>().text = planeSelected.transform.position.ToString();
                obj = Instantiate(windmill, planeSelected.transform.position, Quaternion.Euler(0, 0, 0));
                
                movement = true;
                //moveLeft(obj);


            }

            // Spawn the object at the hit position and rotation
            //GameObject obj = Instantiate(windmill);
            //debugger.GetComponent<Text>().text = "Debugg";

        }
    }

    public void moveLeft()
    {
        if (movement)
        {
            
            if (colliderPlace)
            {
                //debugger.GetComponent<Text>().text = "CUBE Left";
                cube.transform.position = new Vector3(cube.transform.position.x - 0.25f, cube.transform.position.y, cube.transform.position.z);
            }
            else
            {
                //debugger.GetComponent<Text>().text = "OBJ Left";
                obj.transform.position = new Vector3(obj.transform.position.x - 0.25f, obj.transform.position.y, obj.transform.position.z);
            }
            
        }
    }

    public void moveRight()
    {
        if (movement)
        {
            //debugger.GetComponent<Text>().text = "Right";
            if (colliderPlace)
            {
                //debugger.GetComponent<Text>().text = "CUBE Right";
                cube.transform.position = new Vector3(cube.transform.position.x + 0.25f, cube.transform.position.y, cube.transform.position.z);
            }
            else
            {
                //debugger.GetComponent<Text>().text = "OBJ Right";
                obj.transform.position = new Vector3(obj.transform.position.x + 0.25f, obj.transform.position.y, obj.transform.position.z);
            }
            
        }
    }

    public void moveUp()
    {
        if (movement)
        {
            //debugger.GetComponent<Text>().text = "Up";
            if (colliderPlace)
            {
                //debugger.GetComponent<Text>().text = "CUBE Up";
                cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z + 0.25f);
            }
            else
            {
                //debugger.GetComponent<Text>().text = "OBJ Up";
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z + 0.25f);
            }
            
        }
    }

    public void moveDown()
    {
        if (movement)
        {
            //debugger.GetComponent<Text>().text = "Down";
            if (colliderPlace)
            {
                //debugger.GetComponent<Text>().text = "CUBE Down";
                cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, cube.transform.position.z - 0.25f);
            }
            else
            {
                //debugger.GetComponent<Text>().text = "OBJ Down";
                obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, obj.transform.position.z - 0.25f);
            }
            
        }
    }

    public void rotateLeft()
    {
        //debugger.GetComponent<Text>().text = "Rot Left";
        obj.transform.Rotate(0f , -90.0f, 0.0f);
    }

    public void rotateRight()
    {
        //debugger.GetComponent<Text>().text = "Rot Right";
        obj.transform.Rotate(0f, 90.0f, 0.0f);
    }

    public void sizeUp()
    {
        //debugger.GetComponent<Text>().text = "SIZE UP";
        if (colliderPlace)
        {
            cube.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
            
    }

    public void sizeDown()
    {
        //debugger.GetComponent<Text>().text = "SIZE DOWN";
        
        if (colliderPlace)
        {
            cube.transform.localScale += new Vector3(-0.1f, -0.1f, -0.1f);
        }
    }


    public void finishEdit()
    {
        movement = false;
        if (!colliderPlace)
        {
            obj.GetComponent<MoveUFO>().move = true;
        }
        else
        {
            //debugger.GetComponent<Text>().text = "MESH OFF";
            //cube.GetComponent<MeshRenderer>().enabled = false;
            spawnLocation = new Vector3(cube.transform.position.x, cube.transform.position.y + cube.transform.localScale.y / 2, cube.transform.position.z);
            cube.transform.position = spawnLocation;
            
        }
    }

    public void playMode()
    {
        planeManagerGO.GetComponent<PlaneSelection>().buildmode = false;
        //GameObject.Find("/StartFlag/ball").GetComponent<Rigidbody>().isKinematic = false;
        Vector3 spawnPos = GameObject.Find("/StartFlag").transform.position;
        GameObject golfball = Instantiate(ball, spawnPos + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
        colliderPlace = false;

    }

    public void placeCollider()
    {
        colliderPlace = true;
        movement = true;
        Ray raycasted = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //debugger.GetComponent<Text>().text = "UFO Debugg";
        //GameObject obj = Instantiate(ufo);

        if (Physics.Raycast(raycasted, out hit))
        {
            ARPlane planeSelected = hit.transform.GetComponent<ARPlane>();
            if (planeSelected != null)
            {
                //spawnLocation = new Vector3(planeSelected.transform.position.x, planeSelected.transform.position.y + cube.transform.localScale.y / 2, planeSelected.transform.position.z);
                cube = Instantiate(collider, planeSelected.transform.position, Quaternion.identity);
                //debugger.GetComponent<Text>().text = "COLLIDER" ;
            }
        }
    }

   

}
