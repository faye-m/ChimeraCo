﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_MonsterComponentOrderRandomizerScript : MonoBehaviour
{
    //private variable lists and numbers to handle randomizing the order forms for the game 
    [SerializeField] private string[] topcomponentTags = new string[] {"mon_A_Top","mon_B_Top","mon_C_Top","mon_D_Top"};
    [SerializeField] private string[] midcomponentTags = new string[] {"mon_A_Mid","mon_B_Mid","mon_C_Mid","mon_D_Mid"};
    [SerializeField] private string[] botcomponentTags = new string[] {"mon_A_Bot","mon_B_Bot","mon_C_Bot","mon_D_Bot"};
    [SerializeField] private int maxArrayRange = 3;
    [SerializeField] private int randomNumber;
    [SerializeField] private List<string> Order1 = new List<string>();
    [SerializeField] private List<string> Order2 = new List<string>();
    [SerializeField] private List<string> Order3 = new List<string>();

    //private variable arrays and images/sprites to handle UI display on needed monstercomponent parts
    [SerializeField] private GameObject[] OrderListGO;
    [SerializeField] private Image[] Order1Images;
    [SerializeField] private Image[] Order2Images;
    [SerializeField] private Image[] Order3Images;
    [SerializeField] private Sprite[] mcTopSprites;
    [SerializeField] private Sprite[] mcMidSprites;
    [SerializeField] private Sprite[] mcBotSprites;

    //private variables that store the player's partchoice information
    [SerializeField] private GameObject[] monsterComponents;
    
    //variables to handle the matching checker and display the success or failure
    [SerializeField] private bool isMatching = false;
    [SerializeField] private Image sCondDisplayImage;
    [SerializeField] private Sprite[] sCondSprites;
    [SerializeField] private float currentDisplaySucessTimer = 0f;
    [SerializeField] private float turnOffSuccessDisplayTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        sCondDisplayImage.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        SpawnOrderDetails();
        HandleDisplaySuccessCondition();
    }

    private void LateUpdate()
    {
        DisplayUIPanels();
    }

    public void ConfirmSelectionButton()
    {
        if (Order1[0] == monsterComponents[0].tag && Order1[1] == monsterComponents[1].tag && Order1[2] == monsterComponents[2].tag)
        {
            isMatching = true;
            if (isMatching) ClearMonsterTypeOrder(Order1); 
        }

        else if (Order2[0] == monsterComponents[0].tag && Order2[1] == monsterComponents[1].tag && Order2[2] == monsterComponents[2].tag)
        {
            isMatching = true;
            if (isMatching) ClearMonsterTypeOrder(Order2);
        }

        else if (Order3[0] == monsterComponents[0].tag && Order3[1] == monsterComponents[1].tag && Order3[2] == monsterComponents[2].tag)
        {
            isMatching = true;
            if (isMatching) ClearMonsterTypeOrder(Order3);
        }

        if (isMatching)
        {
            //code to display success here
            sCondDisplayImage.sprite = sCondSprites[0];
            sCondDisplayImage.enabled = true;
            //add points to player score here
            isMatching = false;
        }

        else 
        {
            //code to display failure here and reduce amount of lives
            sCondDisplayImage.sprite = sCondSprites[1];
            sCondDisplayImage.enabled = true;
        }
    }

    private void HandleDisplaySuccessCondition()
    {
        currentDisplaySucessTimer += Time.deltaTime;
        if (currentDisplaySucessTimer >= turnOffSuccessDisplayTime) 
        {
            sCondDisplayImage.enabled = false;
            currentDisplaySucessTimer = 0;
        }
    }

    private void RandomizeMonsterTypeOrder(List<string> OrderList) 
    {
        //randomize top component needed and insert it within the order list inputted into the function
        maxArrayRange = topcomponentTags.Length;
        randomNumber = Random.Range(0, maxArrayRange);
        OrderList.Add(topcomponentTags[randomNumber]);

        //randomize mid component needed and insert it within the order list inputted into the function
        maxArrayRange = midcomponentTags.Length;
        randomNumber = Random.Range(0, maxArrayRange);
        OrderList.Add(midcomponentTags[randomNumber]);

        //randomize bot component needed and insert it within the order list inputted into the function
        maxArrayRange = botcomponentTags.Length;
        randomNumber = Random.Range(0, maxArrayRange);
        OrderList.Add(botcomponentTags[randomNumber]);
    }

    private void ClearMonsterTypeOrder(List<string> OrderList)
    {
        for (int n = OrderList.Count - 1 ; n >= 0; n--) { OrderList.RemoveAt(n); }
    }

    private void SpawnOrderDetails() 
    {
        //check if corresponding lists are empty and if they are empty, respawns another set of component orders
        if (Order1.Count == 0) RandomizeMonsterTypeOrder(Order1);
        if (Order2.Count == 0) RandomizeMonsterTypeOrder(Order2);
        if (Order3.Count == 0) RandomizeMonsterTypeOrder(Order3);
    }

    private void DisplayUIPanels()
    {
        if (Order1.Count > 0) DisplayComponentOrders(Order1, Order1Images);
        if (Order2.Count > 0) DisplayComponentOrders(Order2, Order2Images);
        if (Order3.Count > 0) DisplayComponentOrders(Order3, Order3Images);
    }

    private void DisplayComponentOrders(List<string> OrderList, Image[] OrderImages) 
    {
        //display current component orders in the given order list
        for (int i = 0; i < OrderList.Count; i++) 
        {
            string tag = OrderList[i];

            if (i == 0)
            {
                switch (tag)
                {
                    case "mon_A_Top":
                        OrderImages[i].sprite = mcTopSprites[0];
                        break;
                    case "mon_B_Top":
                        OrderImages[i].sprite = mcTopSprites[1];
                        break;
                    case "mon_C_Top":
                        OrderImages[i].sprite = mcTopSprites[2];
                        break;
                    case "mon_D_Top":
                        OrderImages[i].sprite = mcTopSprites[3];
                        break;
                    default:
                        OrderImages[i].sprite = null;
                        break;
                }
            }

            if (i == 1)
            {
                switch (tag)
                {
                    case "mon_A_Mid":
                        OrderImages[i].sprite = mcMidSprites[0];
                        break;
                    case "mon_B_Mid":
                        OrderImages[i].sprite = mcMidSprites[1];
                        break;
                    case "mon_C_Mid":
                        OrderImages[i].sprite = mcMidSprites[2];
                        break;
                    case "mon_D_Mid":
                        OrderImages[i].sprite = mcMidSprites[3];
                        break;
                    default:
                        OrderImages[i].sprite = null;
                        break;
                }
            }

            if (i == 2)
            {
                switch (tag)
                {
                    case "mon_A_Bot":
                        OrderImages[i].sprite = mcBotSprites[0];
                        break;
                    case "mon_B_Bot":
                        OrderImages[i].sprite = mcBotSprites[1];
                        break;
                    case "mon_C_Bot":
                        OrderImages[i].sprite = mcBotSprites[2];
                        break;
                    case "mon_D_Bot":
                        OrderImages[i].sprite = mcBotSprites[3];
                        break;
                    default:
                        OrderImages[i].sprite = null;
                        break;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //checks the tag on the component and stores this into the game object array, monsterComponents
        for (int a = 0; a < topcomponentTags.Length; a++) if (other.tag == topcomponentTags[a]) monsterComponents[0] = other.gameObject;
        for (int b = 0; b < topcomponentTags.Length; b++) if (other.tag == midcomponentTags[b]) monsterComponents[1] = other.gameObject;
        for (int c = 0; c < topcomponentTags.Length; c++) if (other.tag == botcomponentTags[c]) monsterComponents[2] = other.gameObject;
    }
}
