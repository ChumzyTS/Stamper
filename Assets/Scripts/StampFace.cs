using UnityEngine;

public class StampFace : MonoBehaviour
{
    [SerializeField]
    private bool stamped;

    [Header("Objects")]
    [SerializeField]
    private float stampObject;
    [SerializeField]
    private float stampMarkObject;

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
    private bool altWindowPositionY;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StampWindow(friendID);
    }

    void StampWindow(int friendID)
    {
        UpdateCurrent(friendID);

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
                altPos = frogAltPos;
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
                altPos = catrinaAltPos;
                return;
            case 6:
                currentSprite = greatSageOfTheEastSprite;
                currentStampX = greatSageOfTheEastStampX;
                currentStampY = greatSageOfTheEastStampY;
                currentRotationZ = greatSageOfTheEastRotationZ;
                altPos = greatSageOfTheEastAltPos;
                return;
        }
    }
}
