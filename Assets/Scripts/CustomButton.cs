using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour {


    private string Name;
    public string BtnName{
        get { return Name; }
        set { Name = value;}
    }

    public DynamicCreation ScrollView;

    public void Button_Click()
    {
        Debug.Log("Clicke me - " + Name);
       // ScrollView.ButtonClicked(Name);

    }
}
