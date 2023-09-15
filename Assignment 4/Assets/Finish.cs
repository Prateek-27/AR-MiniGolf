using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    GameObject tele2;
    public GameObject debugger;


    private void Start()
    {
        //debugger = GameObject.Find("/Debugger/Panel/Text");
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        //debugger.GetComponent<Text>().text = other.gameObject.name;

        if (other.gameObject.name.Contains("ball"))
        {

            try
            {
                //debugger.GetComponent<Text>().text = other.gameObject.name;
                tele2 = GameObject.Find("/StartFlag");
                other.transform.position = tele2.transform.position + new Vector3(0f, 0.1f, 0f);
                //debugger.GetComponent<Text>().enabled = true;
                //debugger.GetComponent<Text>().text = "YOU WIN";
            }
            catch (Exception e)
            {
                //debugger.GetComponent<Text>().text = "No Touch";
            }

        }

    }
}



