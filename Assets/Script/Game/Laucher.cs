using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEditorInternal;
using UnityEngine;
using VContainer;

public class Laucher : MonoBehaviour
{
    public LaucherType laucherType = LaucherType.None;



    [Inject]
    public void Start1()
    {
        Debug.Log($"Start1()");
    }


    [Inject]
    void Start()
    {
        Debug.Log($"Start()");
        return;
        DontDestroyOnLoad(this);
        GameManager.Instance.Init(this);
        GameObject go = Resources.Load("NetManager") as GameObject;
        GameObject.Instantiate(go);

        if (laucherType == LaucherType.None)
        {
            if (Application.isEditor) return;


            var args = GetCommandlineArgs();

            if (args.TryGetValue("-mode", out string mode))
            {
                switch (mode)
                {
                    case "server":
                        GameManager.Instance.LauchGame(LaucherType.Server);
                        break;
                    case "host":
                        GameManager.Instance.LauchGame(LaucherType.Host);
                        break;
                    case "client":
                        GameManager.Instance.LauchGame(LaucherType.Client);
                        break;
                }
            }
        }
        else
        {
            GameManager.Instance.LauchGame(laucherType);
        }
    }



    private Dictionary<string, string> GetCommandlineArgs()
    {
        Dictionary<string, string> argDictionary = new Dictionary<string, string>();

        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; ++i)
        {
            var arg = args[i].ToLower();
            if (arg.StartsWith("-"))
            {
                var value = i < args.Length - 1 ? args[i + 1].ToLower() : null;
                value = (value?.StartsWith("-") ?? false) ? null : value;

                argDictionary.Add(arg, value);
            }
        }
        return argDictionary;
    }
}

public class MonoInstance :Single<MonoInstance>
{
    public MonoBehaviour mono;

    public void Init()
    {
        mono = new MonoBehaviour();
    }
}

/// <summary>
/// 启动参数
/// </summary>
public enum LaucherType
{
    Server,
    Client,
    Host,
    None
}

/// <summary>
/// 单利模式
/// </summary>
/// <typeparam name="T"></typeparam>
public  class Single<T> where T :class, new()
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}