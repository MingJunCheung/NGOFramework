using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : Single<UIManager>
{
    public UIRoot UIRoot { get; private set; }

    public Dictionary<UIType, UIBase> uiDic = new Dictionary<UIType, UIBase>();

    public void Init()
    {
        var ui = Resources.Load("UIRoot") as GameObject;
        UIRoot = GameObject.Instantiate(ui).GetComponent<UIRoot>();
    }

    public void OpneUI(UIType type)
    {
        if (IsUIOpen(type))
        {
            return;
        }

    }

    public void CloseUI(UIType type)
    {
        if (uiDic.TryGetValue(type, out UIBase uiComponent))
        {
            uiDic.Remove(type);
            GameObject.Destroy(uiComponent.gameObject);
        }
    }

    public bool IsUIOpen(UIType type)
    {
        return uiDic.ContainsKey(type);
    }

    public T GetUIComponent<T>(UIType type) where T : UIBase
    {
        if (uiDic.TryGetValue(type,out UIBase uiComponent))
        {
            return (T)uiComponent;
        }
        return null;
    }
}

public class UIFlagAtribute : Attribute
{
    public UIType uiType;
    public string prefabPath;

    public UIFlagAtribute(UIType uiType, string prefabPath)
    {
        this.uiType = uiType;
        this.prefabPath = prefabPath;
    }
}

public enum UIType
{
    UIMain,
}

public enum UILayer
{
    Normal,
    Tips,
}
