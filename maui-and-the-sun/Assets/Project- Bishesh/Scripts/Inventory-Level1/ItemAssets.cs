using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
   public static ItemAssets Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite dirtSprite;

    public Sprite soilSprite;
    public Sprite leavesSprite;
    public Sprite vege1Sprite;
    public Sprite vege2Sprite;
    public Sprite vege3Sprite;
    public Sprite vege4Sprite;
    public Sprite vege5Sprite;
    public Sprite meatSprite;
    public Sprite smallStonesSprite;
    public Sprite largeStonesSprite;
    public Sprite fireSprite;
    public Sprite branchesSprite;

    public Sprite hoeSprite;
    public Sprite paddleSprite;
    public Sprite patuSprite;
    public Sprite bananaSprite;
    public Sprite chickenSprite;
    public Sprite carrotSprite;
    public Sprite pumpkinSprite;


   

}
