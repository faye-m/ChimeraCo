using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cs_MonsterComponentSelectionScript : MonoBehaviour
{
    [SerializeField] private GameObject[] monsterComponentsList;
    [SerializeField] private int componentIndex;

    // Start is called before the first frame update
    void Start()
    {
        GetAllMonsterComponents();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetAllMonsterComponents() 
    {
        //creates a game object array that identifies the number of children attached to the gameobject and sets that number as the array size
        monsterComponentsList = new GameObject[transform.childCount];

        // takes all the children inside the gameobject and adds them into the array
        for (int n = 0; n < transform.childCount; n++) monsterComponentsList[n] = transform.GetChild(n).gameObject;

        //toggle off all children in the gameobject
        foreach (GameObject go in monsterComponentsList) go.SetActive(false);

        //toggle on the first component in the list
        if (monsterComponentsList[0]) monsterComponentsList[0].SetActive(true);
    }

    public void ToggleMonsterComponentsLeft() 
    {
        // toggle off current model
        monsterComponentsList[componentIndex].SetActive(false);

        //set new component index to toggle through current component list inside the gameobject depending on the button pressed
        componentIndex --;

        //set index back to the start or end of the selection list
        if (componentIndex < 0) componentIndex = monsterComponentsList.Length - 1;

        //toggle on the new model
        monsterComponentsList[componentIndex].SetActive(true);
    }

    public void ToggleMonsterComponentsRight() 
    {
        // toggle off current model
        monsterComponentsList[componentIndex].SetActive(false);

        //set new component index to toggle through current component list inside the gameobject depending on the button pressed
        componentIndex ++;

        //set index back to the start or end of the selection list
        if (componentIndex >= monsterComponentsList.Length) componentIndex = 0;

        //toggle on the new model
        monsterComponentsList[componentIndex].SetActive(true);
    }
}
