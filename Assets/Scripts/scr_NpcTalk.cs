using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class scr_NpcTalk : MonoBehaviour
{
    public AudioSource thisSource;
    public AudioClip blobSound;
    public AudioClip ringSound;
    public GameObject particleEffect;
    RaycastHit  hit;
    float distance = 6f;
    public Text dialogText;
    public Text blobfishCaughtText;
    public Text coinsText;
    //public GameObject uiCanvasItems;
    public GameObject demoBuilder;
    public GameObject sidDialogCanvas;
    public GameObject marlonDialogCanvas;
    public GameObject mrGrabsDialogCanvas;
    public GameObject opalDialogCanvas;
    public GameObject shopCanvas;
    public GameObject uiCanvas;
    public Button sidOkButton;
    public Button mrGrabsOkButton;
    public Button marlonOkButton;
    public Button opalOkButton;
    public Button mrGrabsNoButton;
    public Button marlonNoButton;
    public Button opalNoButton;

    public GameObject sidkkButton, mrGrabskkButton, marlonkkButton,opalkkButton,konchhButton;

    public Button shopOk_Button;
    public Button konchButton;
    public Button tvButton;
    public Button tableButton;
    public Button gameConsoleButton;
    [SerializeField]
    GameObject boughtobject;
        [SerializeField]
    GameObject boughtobject2;
        [SerializeField]
    GameObject boughtobject3;
        [SerializeField]
    GameObject boughtobject4;
    public int dialogtransition;

    public int blobFishCaught;
    static int levelscompleted = 0;
    static int itemsbought = 0;
    static int coins = 0;
    public int rings;
    static int whatLevel = 0;
    public Text mrGrabsText;

    static int whatScene = 0;
    bool talking;

    // Start is called before the first frame update
    void Start()
    {

        talking = false;
        if(whatLevel == 1)
        {
            SetCountText(0);

        }

        if(whatLevel == 2)
        {
            SetRingText(0);
        }

        
        coinsText.text = "Coins: " + coins.ToString();
        //uiCanvasItems.SetActive(false);
        blobFishCaught = 0;
        Button okButton = sidOkButton.GetComponent<Button>();
        Button okButton1 = mrGrabsOkButton.GetComponent<Button>();
        Button okButton2 = marlonOkButton.GetComponent<Button>();
        Button okButton3 = opalOkButton.GetComponent<Button>();
        Button noButton = mrGrabsNoButton.GetComponent<Button>();
        Button noButton1 = marlonNoButton.GetComponent<Button>();
        Button noButton2 = opalNoButton.GetComponent<Button>();

        Button shopButton = shopOk_Button.GetComponent<Button>();
        Button konchbuyButton = konchButton.GetComponent<Button>();
        Button tablebuyButton = tableButton.GetComponent<Button>(); 
        Button tvbuyButton = tvButton.GetComponent<Button>();
        Button gameConsoleBuyButton = gameConsoleButton.GetComponent<Button>();
        okButton.onClick.AddListener(OkButton);
        shopButton.onClick.AddListener(ShopOkButton);
        konchbuyButton.onClick.AddListener(KonchBuyButton);
        tablebuyButton.onClick.AddListener(TvBuyButton);
        tvbuyButton.onClick.AddListener(TableBuyButton);
        gameConsoleBuyButton.onClick.AddListener(GameConsoleButton);

        okButton1.onClick.AddListener(MrGrabsOkButton);
        okButton2.onClick.AddListener(MarlonOkButton);
        okButton3.onClick.AddListener(OpalOkButton);
        noButton.onClick.AddListener(MrGrabsNoButton);
        noButton1.onClick.AddListener(MarlonNoButton);
        noButton2.onClick.AddListener(OpalNoButton);


        sidDialogCanvas.SetActive(false);
        shopCanvas.SetActive(false);
        boughtobject.SetActive(false);
        boughtobject2.SetActive(false);
        boughtobject3.SetActive(false);
        boughtobject4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(sceneName: "S_HubWorld");
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(sceneName: "S_BlobFishing");
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
              SceneManager.LoadScene(sceneName: "S_InflatablePants");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
              SceneManager.LoadScene(sceneName: "S_WMD");
        }
        if (whatScene >= 1 && rings == 20)
        {
         levelscompleted = levelscompleted + 1;
         SceneManager.LoadScene(sceneName: "S_HubWorld");
         
        }//ObstacleCourse
        
        if (whatScene >= 1 && blobFishCaught == 28 )
        {
         levelscompleted = levelscompleted + 1;
         SceneManager.LoadScene(sceneName: "S_HubWorld");
         Time.timeScale = 1f;
         SetCoinText(30);
         SetCountText(1);
        }//BlobFishing

        

        if (levelscompleted == 2)
        {
            mrGrabsText.text = "What are you talking about a Drink? You didn't order a drink Benji Boy. ARG ARG ARG";
        }
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton3))
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, LayerMask.GetMask("Sid")))
            {
            sidDialogCanvas.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            Debug.Log(Cursor.lockState);
            Debug.Log (Time.timeScale);
            talking = true;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(sidkkButton);

            if (dialogtransition <=1)
            {
                dialogtransition = 1;
            }
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, LayerMask.GetMask("Marlon")))
            {
                marlonDialogCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                talking = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(marlonkkButton);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, LayerMask.GetMask("Opal")))
            {
                opalDialogCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                talking = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(opalkkButton);
            }
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance, LayerMask.GetMask("MrGrabs")))
            {
                mrGrabsDialogCanvas.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                talking = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mrGrabskkButton);
            }
        }
    }
    public void ShopOpen()
    {
        demoBuilder.GetComponent<scr_DemoBuilder>().insidehouse = true;
        demoBuilder.GetComponent<scr_DemoBuilder>().canBuildCamera = true;
        shopCanvas.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(konchhButton);
    }

    public void SetCountText(int anumber)
    {
        blobFishCaught = blobFishCaught + anumber;
        blobfishCaughtText.text = "Blobfish Caught: " + blobFishCaught.ToString() + " / 28";
        thisSource.PlayOneShot(blobSound);
        Instantiate(particleEffect, this.transform.position, this.transform.rotation);
    }

    public void SetCoinText(int acoin)
    {
                coins = coins + acoin;
                Debug.Log("coins" + coins);
                Debug.Log("acoin" + acoin);
                coinsText.text = "Coins: " + coins.ToString();
                thisSource.PlayOneShot(ringSound);
    }

 public void SetRingText(int acoin)
    {
                rings = rings + acoin;
                Debug.Log("coins" + coins);
                Debug.Log("acoin" + acoin);
                blobfishCaughtText.text = "Rings: " + rings.ToString() + " / 20";
                Instantiate(particleEffect, this.transform.position, this.transform.rotation);
    }




        void OkButton()
    {
        Debug.Log("You have clicked the ok Button");
        sidDialogCanvas.SetActive(false);
        ShopOpen();
    }
        void MrGrabsOkButton()
        {
            if(levelscompleted >= 2)
            {
                // change scene
                SceneManager.LoadScene(sceneName: "S_WMD");
                whatScene = 3;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
            }
            else
            {
            mrGrabsDialogCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
            }
        }
        void OpalOkButton()
        {
            //chance scene
            SceneManager.LoadScene(sceneName: "S_InflatablePants");
            whatScene = whatScene + 1;
            whatLevel = 2;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        void MarlonOkButton()
        {
            // change scene
            SceneManager.LoadScene(sceneName: "S_BlobFishing");
            whatScene = whatScene + 1;
            whatLevel = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        void MrGrabsNoButton()
        {
            mrGrabsDialogCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        void OpalNoButton()
        {
            opalDialogCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        void MarlonNoButton()
        {
            marlonDialogCanvas.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    void ShopOkButton()
    {
        
        shopCanvas.SetActive(false); 
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        Debug.Log("You have clicked the ok Button");
        demoBuilder.GetComponent<scr_DemoBuilder>().insidehouse = false;
    }
    void KonchBuyButton()
    {
        if(levelscompleted >= 2 && itemsbought == 0 && coins >= 5)
        {
        demoBuilder.GetComponent<scr_DemoBuilder>().object1 = 1;
        demoBuilder.GetComponent<scr_DemoBuilder>().uiElement1.SetActive(true);
        boughtobject.SetActive(true);
        itemsbought = 1;
        SetCoinText(-5);
        }


    }
    void TvBuyButton()
    {
        if(levelscompleted >= 2 && itemsbought == 1 && coins >= 15)
        {
        demoBuilder.GetComponent<scr_DemoBuilder>().object2 = 1;
        demoBuilder.GetComponent<scr_DemoBuilder>().uiElement2.SetActive(true);
        boughtobject2.SetActive(true);
        itemsbought = 2;
        SetCoinText(-15);
        }
        
    }
    void TableBuyButton()
    {
        if(levelscompleted >= 2 && itemsbought == 2 && coins >= 10)
        {
        demoBuilder.GetComponent<scr_DemoBuilder>().object3 = 1;
        demoBuilder.GetComponent<scr_DemoBuilder>().uiElement3.SetActive(true);
        boughtobject3.SetActive(true);
        itemsbought = 3;
        SetCoinText(-10);
        }
    }
    void GameConsoleButton()
    {
        if(levelscompleted >= 2 && itemsbought == 3 && coins >= 20)
        {
        demoBuilder.GetComponent<scr_DemoBuilder>().object4 = 1;
        demoBuilder.GetComponent<scr_DemoBuilder>().uiElement4.SetActive(true);
        boughtobject4.SetActive(true);
        itemsbought = 4;
        SetCoinText(-5);
        }
    }
}
