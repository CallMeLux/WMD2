using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_BuildSystem : MonoBehaviour
{
    [SerializeField]
    GameObject cameraMover;
    [SerializeField]
    GameObject ItemListt;
    [SerializeField]
    Transform CamChild;

    [SerializeField]
    GameObject FloorBuild;
    [SerializeField]
    GameObject FloorPrefab;
    [SerializeField]
    public bool canBuild;
    public bool canBuildCamera;
    public bool insidehouse;
    [SerializeField]
    GameObject destination;
    [SerializeField]
    LayerMask floorMask;
    [SerializeField]
    LayerMask wallMask;
    RaycastHit Hit;
    Renderer rend;
    
    void Start()
    {
        insidehouse = false;
        canBuild = true;
        canBuildCamera = false;
        rend = FloorBuild.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FloorBuild.transform.position = destination.transform.position;
        FloorBuild.transform.rotation = destination.transform.rotation;
        //scr_itemAssets playerHousingitemList = GameObject.Find(ItemAssets).GetComponent<scr_itemAssets>();
        
        if (insidehouse && canBuildCamera)
        {
            RaycastFloor();
            if (Input.GetKeyDown(KeyCode.R))
                {
                Debug.Log("you pressed R: " + canBuildCamera);
                canBuildCamera = false;
                cameraMover.transform.localPosition = new Vector3 (0f,2.2f,-1.96f);
                destination.SetActive(false);
                }
        }
        else if (insidehouse && !canBuildCamera) 
            {
            HouseStop();
            if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("you pressed R: " +canBuildCamera);
                    canBuildCamera = true;
                    cameraMover.transform.localPosition = new Vector3 (0f,1f,1f);
                    destination.SetActive(true);
                    //HouseStop();
                }
            }
    }

    void RaycastFloor()
    {
        if(Input.GetMouseButtonDown(0) && canBuild)
            {
            Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
            }
        if (Input.GetKeyDown(KeyCode.Alpha1))
            {
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().kelpDollarsPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(true);
            Debug.Log("working");
            }
        if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().chairObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().chairPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(true);
                //Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().paintingObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().paintingPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(true);
                //Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
                //Debug.Log("working");
                }
            if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyStandObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyStandPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(true);
                //Debug.Log("working");
                }
    }
    //void RaycastWall() {}
    void HouseStop()
    {
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().chairObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().paintingObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().kelpDollarsObject.SetActive(false);
    }
}

