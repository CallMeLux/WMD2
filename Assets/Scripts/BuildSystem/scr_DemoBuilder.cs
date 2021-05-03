using UnityEngine;

public class scr_DemoBuilder : MonoBehaviour
{
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
    Renderer rend;
    
    public GameObject uiElement1;
    public GameObject uiElement2;
    public GameObject uiElement3;
    public GameObject uiElement4;
    public GameObject uiElement5;

    public int object1;
    bool object1Selected;
    public int object2;
    bool object2Selected;
    public int object3;
    bool object3Selected;
    public int object4;
    bool object4Selected;
    public int drkelp;
    bool drkelpSelected;
    float itemslotTemplate2x;
    float itemslotTemplate3x;
    float itemslotTemplate4x;

    float xtest;
    float ytest;

    public GameObject uiInventory;

    // Start is called before the first frame update
void Start()
    {
        // rectransforms for uiElements
        RectTransform recttransform1 = uiElement2.GetComponent<RectTransform>();
        RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
        RectTransform recttransform3 = uiElement4.GetComponent<RectTransform>();
        itemslotTemplate2x = recttransform1.anchoredPosition.x;
        itemslotTemplate3x = recttransform2.anchoredPosition.x;
        itemslotTemplate4x = recttransform3.anchoredPosition.x;
        uiInventory.gameObject.SetActive(false);
        
        // amount of items in hand
        object1 = 0;
        object2 = 0;
        object3 = 0;
        object4 = 0;
        drkelp = 0;
        // can place
        object1Selected = false;
        object2Selected = false;
        object3Selected = false;
        object4Selected = false;
        //
        insidehouse = false;
        canBuild = true;
        canBuildCamera = false;
        rend = FloorBuild.GetComponent<Renderer>();
    }
   void Update()
   {
    xtest = Input.GetAxisRaw("JoystickH");
    ytest = Input.GetAxisRaw("JoystickV");
    FloorBuild.transform.position = destination.transform.position;
    FloorBuild.transform.rotation = destination.transform.rotation;
    //Debug.Log("object1: " + object1);
    //Debug.Log("object2: " + object2);
    //Debug.Log("object3: " + object3);
        //scr_itemAssets playerHousingitemList = GameObject.Find(ItemAssets).GetComponent<scr_itemAssets>();
        
        if (insidehouse)
        {
            uiInventory.gameObject.SetActive(true);
            RaycastFloor();
            /*if (Input.GetKeyDown(KeyCode.R))
                {
                //Debug.Log("you pressed R: " + canBuildCamera);

                canBuildCamera = false;
                destination.SetActive(false);
                }*/
        }
        /*else if (insidehouse && !canBuildCamera) 
            {
            uiInventory.gameObject.SetActive(false);
            HouseStop();
            if (Input.GetKeyDown(KeyCode.R))
                {
                    //Debug.Log("you pressed R: " +canBuildCamera);

                    canBuildCamera = true;
                    destination.SetActive(true);
                    //HouseStop();
                }
            }*/
        else
        {
            uiInventory.gameObject.SetActive(false);
            HouseStop();
        }
    }

    void RaycastFloor()
    {
        if(Input.GetButtonDown("Fire1") && canBuild)
            {
            //Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
            if (object1Selected)
            {
                object1 = object1 - 1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object1Selected = false;
                Destroy(uiElement1);
            if (uiElement2)
            {
            RectTransform recttransform1 = uiElement2.GetComponent<RectTransform>();
            recttransform1.anchoredPosition = new Vector2 ((itemslotTemplate2x -149f), 137f);
            }
            if (uiElement3)
            {
            RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
            recttransform2.anchoredPosition = new Vector2 ((itemslotTemplate3x - 149f), 137);
            itemslotTemplate3x = itemslotTemplate3x - 149f;
            }
            if (uiElement4)
            {
            RectTransform recttransform3 = uiElement4.GetComponent<RectTransform>();
            recttransform3.anchoredPosition = new Vector2 ((itemslotTemplate4x - 149f), 137);
            itemslotTemplate4x = itemslotTemplate4x - 149f;
            }
            }
            if (object2Selected)
            {
                object2 = object2 -1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object2Selected = false;
                Destroy(uiElement2);
            if (uiElement3)
            {
            RectTransform recttransform2 = uiElement3.GetComponent<RectTransform>();
           recttransform2.anchoredPosition = new Vector2 ((itemslotTemplate3x - 149f),137);
           itemslotTemplate3x = itemslotTemplate3x - 149f;
            }
            if (uiElement4)
            {
            RectTransform recttransform3 = uiElement4.GetComponent<RectTransform>();
            recttransform3.anchoredPosition = new Vector2 ((itemslotTemplate4x - 149f), 137);
            itemslotTemplate4x = itemslotTemplate4x - 149f;
            }

            }
            if (object3Selected)
            {
                object3 = object3 - 1;
                Instantiate(FloorPrefab, FloorBuild.transform.position, FloorBuild.transform.rotation);
                object3Selected = false;
                Destroy(uiElement3);

                if (uiElement4)
                {
            RectTransform recttransform3 = uiElement4.GetComponent<RectTransform>();
            recttransform3.anchoredPosition = new Vector2 ((itemslotTemplate4x - 149f), 137);
            itemslotTemplate4x = itemslotTemplate4x - 149f;
                }
            }
            if(object4Selected)
            {
                object4 = object4 - 1;
                Instantiate(FloorPrefab,FloorBuild.transform.position, FloorBuild.transform.rotation);
                object4Selected = false;
                Destroy(uiElement4);
            }
            HouseStop();
            }
        if (Input.GetKeyDown(KeyCode.Alpha1) || (Input.GetAxis("JoystickH") > 0.0f))
            {
            if (object1 > 0)
            {
            object1Selected = true;
            object2Selected = false;
            object3Selected = false;
            object4Selected = false;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().konchObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().konchPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().konchObject.SetActive(true);
            //Debug.Log("working");
            }
            if (object1 <= 0 && object2 >0)
            {
            object1Selected = false;
            object2Selected = true;
            object3Selected = false;
            object4Selected = false;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().drinkObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().drinkPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().drinkObject.SetActive(true);
            Debug.Log("item 2 is now 1"); 
            }
            if (object1 <= 0 && object2 <= 0 && object3 > 0)
            {
            object1Selected = false;
            object2Selected = false;
            object3Selected = true;
            object4Selected = false;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().tableObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().tablePrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
            //Debug.Log("working");
            }
            if (object1 <= 0 && object2 <= 0 && object3 <= 0 && object4 > 0)
            {
            object1Selected = false;
            object2Selected = false;
            object3Selected = false;
            object4Selected = true;
            FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
            FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
            HouseStop();
            ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
            }
            }
        if (Input.GetKeyDown(KeyCode.Alpha2) || (Input.GetAxis("JoystickV") > 0.0f))
            {
            if (object1 > 0)
            {
                if (object2 > 0)
                    {
                    object1Selected = false;
                    object2Selected = true;
                    object3Selected = false;
                    object4Selected = false;
                    FloorBuild = ItemListt.GetComponent<scr_itemAssets>().drinkObject;
                    FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().drinkPrefab;
                    HouseStop();
                    ItemListt.GetComponent<scr_itemAssets>().drinkObject.SetActive(true);
                        //Debug.Log("working");
                    }
                if (object2 <= 0 && object3 > 0)
                    {
                    object1Selected = false;
                    object2Selected = false;
                    object3Selected = true;
                    object4Selected = false;
                    FloorBuild = ItemListt.GetComponent<scr_itemAssets>().tableObject;
                    FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().tablePrefab;
                    HouseStop();
                    ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                    //Debug.Log("working");
                    }
                if (object2 <= 0 && object3 <= 0 && object4 > 0)
                    {
                    object1Selected = false;
                    object2Selected = false;
                    object3Selected = false;
                    object4Selected = true;
                    FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                    FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                    HouseStop();
                    ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                    //Debug.Log("working");
                    }
                if (object2 <= 0 && object3 <= 0 && object4 <=0)
                    {
                        Debug.Log("nothing to press");
                    }
            }
            else if (object1 <= 0)
            {
                if (object2 > 0)
                    {
                    object1Selected = false;
                    object2Selected = false;
                    object3Selected = true;
                    object4Selected = false;
                    FloorBuild = ItemListt.GetComponent<scr_itemAssets>().tableObject;
                    FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().tablePrefab;
                    HouseStop();
                    ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                        //Debug.Log("working");
                    }
                if (object2 <= 0 && object3 > 0)
                    {
                    object1Selected = false;
                    object2Selected = false;
                    object3Selected = false;
                    object4Selected = true;
                    FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                    FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                    HouseStop();
                    ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                    //Debug.Log("working");
                    }
                if (object2 <= 0 && object3 <= 0 && object4 > 0)
                    {
                    Debug.Log("do nothing");
                    }
                if (object2 <= 0 && object3 <= 0 && object4 <=0)
                    {
                        Debug.Log("nothing to press");
                    }
            }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) || (Input.GetAxis("JoystickH") < 0.0f))
                {
            if (object1 > 0 && object2 > 0 && object3 > 0)
            {
                object1Selected = false;
                object2Selected = false;
                object3Selected = true;
                object4Selected = false;
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().tableObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().tablePrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(true);
                //Debug.Log("working");
            }
            if ((object1 > 0 && object2 > 0 && object3 <= 0 && object4 > 0) || (object1 <= 0 && object2 > 0 && object3 > 0 && object4 > 0)|| (object1 > 0 && object2 <= 0 && object3 > 0 && object4 > 0))
            {
                object1Selected = false;
                object2Selected = false;
                object3Selected = false;
                object4Selected = true;
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
                }
                }
            if (Input.GetKeyDown(KeyCode.Alpha4) || (Input.GetAxis("JoystickV") < 0.0f))
                {
                if (object1 >0 && object2 > 0 && object3 > 0 && object4 > 0)
                {
                object1Selected = false;
                object2Selected = false;
                object3Selected = false;
                object4Selected = true;
                FloorBuild = ItemListt.GetComponent<scr_itemAssets>().trophyObject;
                FloorPrefab = ItemListt.GetComponent<scr_itemAssets>().trophyPrefab;
                HouseStop();
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(true);
                }
                if (object1<0 || object2 <0 || object3< 0 || object4 < 0)
                {
                    Debug.Log("nothing to place");
                }
                }
    }
    //void RaycastWall() {}
    void HouseStop()
    {
                ItemListt.GetComponent<scr_itemAssets>().trophyStandObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().konchObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().drinkObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().trophyObject.SetActive(false);
                ItemListt.GetComponent<scr_itemAssets>().tableObject.SetActive(false);
    }

}
