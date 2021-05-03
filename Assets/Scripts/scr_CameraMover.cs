using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_CameraMover : MonoBehaviour
{
    public Transform [] views;
    public float transitionSpeed;
    Transform currentView;
    // Start is called before the first frame update
    void Start()
    {
        currentView = views[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>().insidehouse == true && GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>().canBuildCamera == true)
        {
            Debug.Log("moveback" + currentView);
            currentView = views[0];
        }
        if (Input.GetKeyDown(KeyCode.R) && GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>().insidehouse == false && GameObject.FindGameObjectWithTag("Builder").GetComponent<scr_DemoBuilder>().canBuildCamera == false)
        {
            Debug.Log("move to builder mode" + currentView);
            currentView = views[2];
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && (GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().catchModeOn == false))
        {
            Debug.Log("moveback again" + currentView);
            currentView = views [0];
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && (GameObject.FindGameObjectWithTag("Player").GetComponent<scr_PlayerController>().catchModeOn == true))
        {
            Debug.Log("Catchycatch" + currentView);
            currentView = views[1];
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //lerp position
        this.transform.localPosition = Vector3.Lerp(this.transform.localPosition,currentView.localPosition, Time.deltaTime * transitionSpeed);
    }
}
