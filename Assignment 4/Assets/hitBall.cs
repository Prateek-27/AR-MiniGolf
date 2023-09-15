using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

using UnityEngine.UI;

public class hitBall : MonoBehaviour
{
    [SerializeField] float speed = 60.0f;
    public GameObject debugger;
    private Vector2 startingPosition;
    private Rigidbody rb;
    private Vector3 initialBallPos;
    public GameObject startFlag;

    float touchTimeStart, touchTimeFinish, timeInterval;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //debugger = GameObject.Find("/Debugger/Panel/Text");
        initialBallPos = transform.position;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            if (touch.phase == TouchPhase.Began)
            {
                touchTimeStart = Time.time;
                startingPosition = touch.position;
            }
           if (touch.phase == TouchPhase.Ended)
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                Vector2 direction = touch.position - startingPosition;
                Vector3 velocity = new Vector3(direction.x, 0.0f, direction.y).normalized * speed * timeInterval;
                //debugger.GetComponent<Text>().text = transform.position.ToString();
                rb.AddForce(velocity);
            }
        }
        if(transform.position.y < -10)
        {
            startFlag = GameObject.Find("/StartFlag");
            //debugger.GetComponent<Text>().text = startFlag.transform.position.ToString();
            rb.isKinematic = true;
            Vector3 newpos = new Vector3(startFlag.transform.position.x, startFlag.transform.position.y + 0.05f, startFlag.transform.position.z);
            transform.position = startFlag.transform.position;
            rb.isKinematic = false;
            //rb.position = newpos;
        }
    }
}

