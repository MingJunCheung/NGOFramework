using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMain : UIBase
{
    public Button btn1;
    public Button btn2;


    public void Start()
    {
        btn1.onClick.AddListener(OnBtn1Click);
        btn2.onClick.AddListener(OnBtn2Click);
    }

    public void OnBtn1Click()
    {
        MessagerManager.Instance.SendNamedMsg(4);
    }

    public void OnBtn2Click()
    {

    }
}
