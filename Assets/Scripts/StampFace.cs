using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class StampFace : MonoBehaviour
{
    [SerializeField]
    private bool stamped;
    private bool pressing;

    [Header("Objects")]
    [SerializeField]
    private GameObject window;
    [SerializeField]
    private GameObject stampObject;
    [SerializeField]
    private GameObject stampMarkObject;
    [SerializeField]
    private GameObject stampUI;

    [Header("CurrentSettings")]
    [SerializeField]
    private int friendID;
    [SerializeField]
    private Sprite currentSprite;
    [SerializeField]
    private float currentStampX;
    [SerializeField]
    private float currentStampY;
    [SerializeField]
    private float currentRotationZ;
    [SerializeField]
    private bool altPos;

    [Header("GeneralLocations")]
    [SerializeField]
    private float defaultWindowPositionX;
    [SerializeField]
    private float defaultWindowPositionY;
    [SerializeField]
    private float altWindowPositionX;
    [SerializeField]
    private float altWindowPositionY;
    [SerializeField]
    private float windowPositionX;
    [SerializeField]
    private float windowPositionY;


    [Header("Cecelia 1 (#0)")]
    [SerializeField]
    private Sprite cecelia1Sprite;
    [SerializeField]
    private float cecelia1StampX;
    [SerializeField]
    private float cecelia1StampY;
    [SerializeField]
    private float cecelia1RotationZ;
    [SerializeField]
    private bool cecelia1AltPos;

    [Header("Cecelia 2 (#1)")]
    [SerializeField]
    private Sprite cecelia2Sprite;
    [SerializeField]
    private float cecelia2StampX;
    [SerializeField]
    private float cecelia2StampY;
    [SerializeField]
    private float cecelia2RotationZ;
    [SerializeField]
    private bool cecelia2AltPos;

    [Header("Frog (#2)")]
    [SerializeField]
    private Sprite frogSprite;
    [SerializeField]
    private float frogStampX;
    [SerializeField]
    private float frogStampY;
    [SerializeField]
    private float frogRotationZ;
    [SerializeField]
    private bool frogAltPos;

    [Header("Batthew (#3)")]
    [SerializeField]
    private Sprite batthewSprite;
    [SerializeField]
    private float batthewStampX;
    [SerializeField]
    private float batthewStampY;
    [SerializeField]
    private float batthewRotationZ;
    [SerializeField]
    private bool batthewAltPos;

    [Header("Catrina (#4)")]
    [SerializeField]
    private Sprite catrinaSprite;
    [SerializeField]
    private float catrinaStampX;
    [SerializeField]
    private float catrinaStampY;
    [SerializeField]
    private float catrinaRotationZ;
    [SerializeField]
    private bool catrinaAltPos;

    [Header("Polly (#5)")]
    [SerializeField]
    private Sprite pollySprite;
    [SerializeField]
    private float pollyStampX;
    [SerializeField]
    private float pollyStampY;
    [SerializeField]
    private float pollyRotationZ;
    [SerializeField]
    private bool pollyAltPos;

    [Header("Great Sage of the East (#6)")]
    [SerializeField]
    private Sprite greatSageOfTheEastSprite;
    [SerializeField]
    private float greatSageOfTheEastStampX;
    [SerializeField]
    private float greatSageOfTheEastStampY;
    [SerializeField]
    private float greatSageOfTheEastRotationZ;
    [SerializeField]
    private bool greatSageOfTheEastAltPos;

    [Header("Mark (#7)")]
    [SerializeField]
    private Sprite markSprite;
    [SerializeField]
    private float markStampX;
    [SerializeField]
    private float markStampY;
    [SerializeField]
    private float markRotationZ;
    [SerializeField]
    private bool markAltPos;

    [Header("Debug")]
    [SerializeField]
    private bool manualPositioningMode;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        windowPositionX = defaultWindowPositionX;
        windowPositionY = defaultWindowPositionY;
        if (manualPositioningMode) {
            StartStampage(friendID);
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!stamped)
        {
            if (Input.GetKey(KeyCode.S))
            {
                pressing = true;
            }
            else
            {
                pressing = false;
            }


            if (manualPositioningMode && !pressing)
            {
                stampMarkObject.SetActive(true);
                stampMarkObject.transform.position = Input.mousePosition;
                currentStampX = stampMarkObject.transform.localPosition.x;
                currentStampY = stampMarkObject.transform.localPosition.y;
            }
            
        }

        
    }

    public void StartStampage(int id)
    {
        friendID = id;
        StartCoroutine(StampWindow());
    }

    IEnumerator StampWindow()
    {
        UpdateCurrent(friendID);
        UpdateScene();
        stampMarkObject.SetActive(false);
        stampObject.SetActive(false);
        
        stampUI.SetActive(true);
        while (pressing == false) yield return null;
        stampObject.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        stampObject.transform.localPosition = new Vector2(currentStampX, currentStampY);
        while (pressing == true) yield return null;
        
        // Leave a Mark!
        stamped = true;
        stampMarkObject.SetActive(true);
        UpdateScene();
        stampUI.SetActive(false);

        yield return new WaitForSeconds(1);
        stampObject.SetActive(false);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }

    void UpdateScene()
    {
        if (altPos)
        {
            windowPositionX = altWindowPositionX;
            windowPositionY = altWindowPositionY;
        }
        else
        {
            windowPositionX = defaultWindowPositionX;
            windowPositionY = defaultWindowPositionY;
        }

        window.GetComponent<Image>().sprite = currentSprite;
        stampMarkObject.transform.localPosition = new Vector2(currentStampX, currentStampY);
        stampMarkObject.transform.Rotate(0, 0, currentRotationZ);
        stampObject.transform.localPosition = new Vector2(currentStampX + 50, currentStampY + 50);
        window.transform.localPosition = new Vector2(windowPositionX, windowPositionY);

    }

    void UpdateCurrent(int friendID)
    {
        switch (friendID)
        {
            case 0:
                currentSprite = cecelia1Sprite;
                currentStampX = cecelia1StampX;
                currentStampY = cecelia1StampY;
                currentRotationZ = cecelia1RotationZ;
                altPos = cecelia1AltPos;
                return;
            case 1:
                currentSprite = cecelia2Sprite;
                currentStampX = cecelia2StampX;
                currentStampY = cecelia2StampY;
                currentRotationZ = cecelia2RotationZ;
                altPos = cecelia2AltPos;
                return;
            case 2:
                currentSprite = frogSprite;
                currentStampX = frogStampX;
                currentStampY = frogStampY;
                currentRotationZ = frogRotationZ;
                altPos = frogAltPos;
                return;
            case 3:
                currentSprite = batthewSprite;
                currentStampX = batthewStampX;
                currentStampY = batthewStampY;
                currentRotationZ = batthewRotationZ;
                altPos = batthewAltPos;
                return;
            case 4:
                currentSprite = catrinaSprite;
                currentStampX = catrinaStampX;
                currentStampY = catrinaStampY;
                currentRotationZ = catrinaRotationZ;
                altPos = catrinaAltPos;
                return;
            case 5:
                currentSprite = pollySprite;
                currentStampX = pollyStampX;
                currentStampY = pollyStampY;
                currentRotationZ = pollyRotationZ;
                altPos = pollyAltPos;
                return;
            case 6:
                currentSprite = greatSageOfTheEastSprite;
                currentStampX = greatSageOfTheEastStampX;
                currentStampY = greatSageOfTheEastStampY;
                currentRotationZ = greatSageOfTheEastRotationZ;
                altPos = greatSageOfTheEastAltPos;
                return;
            case 7:
                currentSprite = markSprite;
                currentStampX = markStampX;
                currentStampY = markStampY;
                currentRotationZ = markRotationZ;
                altPos = markAltPos;
                return;
        }
        
    }
}
