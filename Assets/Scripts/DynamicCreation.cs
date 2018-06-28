using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DynamicCreation : MonoBehaviour {


    public GameObject bttnPreFab;
    public GameObject rowPrefab;
    private List<string> NameList = new List<string>();

    public GameObject mPrefabs;
  //  private float rowLength = 0 ;
    private int rowNumber = 0;
    private const int CELL_OFFSET = 10;

    // Awake
    void Awake()
    {
        //bttnPreFab = Resources.Load<GameObject>("Button");
    }

	// Use this for initialization
    // Use this for initialization
    void Start()
    {

        NameList.Add("Alan");
        NameList.Add("AmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmy");
        NameList.Add("Brian");
        NameList.Add("Carrie");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Alan");
        NameList.Add("AmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmy");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("Alan");
        NameList.Add("AmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmyAmy");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");
        NameList.Add("David");
        NameList.Add("Joe");
        NameList.Add("Jason");
        NameList.Add("Michelle");
        NameList.Add("Stephanie");
        NameList.Add("Zoe");



        GameObject parentContent = GameObject.Find("Content") as GameObject;
        RectTransform parentTransform = (RectTransform)parentContent.transform;

        Debug.Log(parentTransform.rect.width);
        // setting it to parent length 
        var leftOverCell = parentTransform.rect.width;
        //GameObject rowItem = Instantiate(rowPrefab) as GameObject;
        //RectTransform rowTransform = (RectTransform)rowItem.transform;
        //rowItem.transform.SetParent(parentTransform,false);

        GameObject rowItem = null ;
        RectTransform rowTransform = null;


        foreach (string str in NameList)
        {
            if (bttnPreFab != null)
            {
                // getting the new cell requirement 
                var newCellReq = (str.Length );
                Debug.Log("newCellReq :: " +newCellReq+"\t leftOverCell :: " + leftOverCell);
                if (newCellReq >= leftOverCell || rowNumber == 0  ){
                    // create new row 

                    rowItem = Instantiate(rowPrefab) as GameObject;
                    rowItem.transform.SetParent(parentContent.transform,false);
                    rowTransform = (RectTransform)rowItem.transform;
                    rowItem.name = "Row" + rowNumber;
                    rowNumber++;
                    leftOverCell = parentTransform.rect.width;//reset for size
                }
                //adding new row over 
                    
                //add new button cell into row
                GameObject itemButtonCell = Instantiate(bttnPreFab) as GameObject;
                itemButtonCell.AddComponent<CustomButton>();
                itemButtonCell.name = "Button" + str;
                CustomButton buttonController = itemButtonCell.GetComponent<CustomButton>();
                //truncating    
                if (str.Length > 12  || leftOverCell < str.Length){
                  //  string ls = str.Substring(0, 25);
                   // ls += "..";
                    itemButtonCell.GetComponentInChildren<Text>().text = str.Substring(0, 15) + "..";
                    itemButtonCell.GetComponentInChildren<Text>().fontSize = (int)(itemButtonCell.GetComponent<RectTransform>().rect.width %
                                                                         itemButtonCell.GetComponent<RectTransform>().rect.height );
             
                }
                else{
                    itemButtonCell.GetComponentInChildren<Text>().text = str;
                }
                  
                buttonController.BtnName = str;
                    //adding listener to the button
                    Button itemBt = itemButtonCell.GetComponent<Button>();
                    itemBt.onClick.AddListener(buttonController.Button_Click);
               
               
                // transform the game object 


                var pos = rowTransform.position;
                Debug.Log(str+ "[ "+ itemButtonCell.GetComponent<RectTransform>().name +" ] - itemButtonCell.transform.position.x = " + itemButtonCell.GetComponent<RectTransform>().rect.width);
                pos.x += (newCellReq+ itemButtonCell.GetComponent<RectTransform>().rect.width);
                rowTransform.position = pos;
                //itemButtonCell.transform.position += new Vector3(0,0.5f, 0);
                    

                itemButtonCell.transform.SetParent(rowTransform,false);
                leftOverCell -= (newCellReq + itemButtonCell.GetComponent<RectTransform>().rect.width);

            }
            else
                Debug.Log("CUSTOMM FAILED");
            
        }


    }

    public void ButtonClicked(string str)
    {
        Debug.Log(str + " button clicked.");

    }
}
