using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DynamicCreation_extrawork: MonoBehaviour {


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
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");
        //NameList.Add("David");
        //NameList.Add("Joe");
        //NameList.Add("Jason");
        //NameList.Add("Michelle");
        //NameList.Add("Stephanie");
        //NameList.Add("Zoe");



        GameObject parentContent = GameObject.Find("Content") as GameObject;
        RectTransform parentTransform = (RectTransform)parentContent.transform;

       // Debug.Log(parentTransform.rect.width);
        // setting it to parent length 
        var leftOverCell = parentTransform.rect.width;
        //GameObject rowItem = Instantiate(rowPrefab) as GameObject;
        //RectTransform rowTransform = (RectTransform)rowItem.transform;
        //rowItem.transform.SetParent(parentTransform,false);

        GameObject rowItem = null ;
        RectTransform rowTransform = null;

        Vector3 locaPos = new Vector3(0, 0, 0);

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
                buttonController.BtnName = str; 
                //adding listener to the button
                Button itemBt = itemButtonCell.GetComponent<Button>();
                itemBt.onClick.AddListener(buttonController.Button_Click);
            
                //truncating the str length OF TEXT COMPONENT     
                if (str.Length > 25  || leftOverCell < str.Length){
                    itemButtonCell.GetComponentInChildren<Text>().text = str.Substring(0, 25) + "..";
                    itemButtonCell.GetComponentInChildren<Text>().fontSize = (int)(itemButtonCell.GetComponent<RectTransform>().rect.width %
                                                                         itemButtonCell.GetComponent<RectTransform>().rect.height );
                }
                else{
                    itemButtonCell.GetComponentInChildren<Text>().text = str;
                }

                //SETTING TEXT COMPONENTS
                RectTransform textComponent = itemButtonCell.GetComponentInChildren<Text>().GetComponent<RectTransform>();
                Vector2 dimensionText = textComponent.sizeDelta;
                dimensionText.x = str.Length; //width 
                dimensionText.y = parentTransform.rect.height;//height
                textComponent.sizeDelta = dimensionText;

                //SETTING IMAGE COMPONENTS
                RectTransform imageComponent = itemButtonCell.GetComponentInChildren<Image>().GetComponent<RectTransform>();
                Vector2 dimensionImage = imageComponent.sizeDelta;
                dimensionImage.x = 15; //width 
                dimensionImage.y = 15;//height
                imageComponent.sizeDelta = dimensionImage;


                //Setting the BUTTON CELL COMPONENT 
                float totalWidth = dimensionImage.x 
                                                 + dimensionText.x+10;
                RectTransform buttonTransform = (RectTransform)itemButtonCell.transform;
                buttonTransform.sizeDelta = new Vector2(totalWidth,rowTransform.GetComponent<RectTransform>().rect.height);
                //leftOverCell -= (newCellReq + totalWidth);

                //moving the X axis
                //Vector2 positonButton = buttonTransform.position;
                //positonButton.x += buttonTransform.rect.width;
                //buttonTransform.position = positonButton;
                buttonTransform.position = rowTransform.position + locaPos;
                locaPos = buttonTransform.position + new Vector3(buttonTransform.rect.width, buttonTransform.rect.y,0);


                // transform the game object 
                //var pos = rowTransform.position;
                //Debug.Log(str+ "[ "+ itemButtonCell.GetComponent<RectTransform>().name +" ] - itemButtonCell.transform.position.x = " + totalWidth);
                //pos.x += (newCellReq+ totalWidth);
                //rowTransform.position = pos;    //updating the pos 

                itemButtonCell.transform.SetParent(rowTransform,false);
                Debug.Log("+++ "+((RectTransform)itemButtonCell.transform).GetComponent<RectTransform>().rect.width);
                leftOverCell -= ((RectTransform)itemButtonCell.transform).GetComponent<RectTransform>().rect.width;
                //setting the width     
                //RectTransform buttonTransform = (RectTransform)itemButtonCell.transform;
                //var sd = itemButtonCell.GetComponentInChildren<Image>().GetComponent<RectTransform>().rect.width;
                //var ds = itemButtonCell.GetComponentInChildren<Text>().GetComponent<RectTransform>().rect.width;
                //float totalWidth = itemButtonCell.GetComponentInChildren<Image>().GetComponent<RectTransform>().rect.width + 
                //                                 itemButtonCell.GetComponentInChildren<Text>().GetComponent<RectTransform>().rect.width;
                
                //buttonTransform.sizeDelta = new Vector2(totalWidth,rowTransform.GetComponent<RectTransform>().rect.height); 

                //leftOverCell -= (newCellReq + itemButtonCell.GetComponent<RectTransform>().rect.width);

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
