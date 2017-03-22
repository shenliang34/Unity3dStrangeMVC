using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    // Use this for initialization
    private GlobalAlertWindow alertWindow;
    //窗口集合
    private Dictionary<EWindowID, BaseWindow> windowDict = new Dictionary<EWindowID, BaseWindow>();
    //

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,100),"打开普通界面"))
        {
            openWindow(EWindowID.Test);
        }

        if(GUI.Button(new Rect(100,0,100,100), "关闭普通界面"))
        {
            closeWindow(EWindowID.Test);
        }

        if (GUI.Button(new Rect(200, 0, 100, 100), "打开提示界面"))
        {
            openAlertCenter("打开提示界面",null);
        }

        if (GUI.Button(new Rect(300, 0, 100, 100), "关闭提示界面"))
        {
            //关闭界面
            closeAlertWindow();
        }

        if (GUI.Button(new Rect(400, 0, 100, 100), "打开提示确定界面"))
        {
            //关闭界面
            openAlertLeftRight("打开提示确定界面", null ,null);
        }

        if (GUI.Button(new Rect(500, 0, 100, 100), "关闭提示界面"))
        {
            //关闭界面
            closeAlertWindow();
        }

        if (GUI.Button(new Rect(600, 0, 100, 100), "打开普通界面"))
        {
            openWindow(EWindowID.Test2);
        }

        if (GUI.Button(new Rect(700, 0, 100, 100), "关闭普通界面"))
        {
            closeWindow(EWindowID.Test2);
        }
    }

    /// <summary>
    /// 打开界面
    /// </summary>
    public void openWindow(EWindowID id)
    {
        BaseWindow window = getWindowByid(id);
        if(window == null)
        {
            switch(id)
            {
                case EWindowID.Test:
                    window = gameObject.AddComponent<TestWindow>();
                    break;
                case EWindowID.Test2:
                    window = gameObject.AddComponent<TestWindow2>();
                    break;
                default:
                    break;
            }
        }

        if(window)
        {
            //存储window
            windowDict[id] = window;
            window.Show();
        }
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public void closeWindow(EWindowID id)
    {
        BaseWindow window = getWindowByid(id);
        if(window != null)
        {
            window.Close();
        }
    }

    /// <summary>
    /// 移除
    /// </summary>
    /// <param name="id"></param>
    public void removeWindow(EWindowID id)
    {
        if(windowDict.ContainsKey(id))
        {
            windowDict.Remove(id);
        }
    }

    /// <summary>
    /// 根据id获取窗口
    /// </summary>
    /// <param name="id"></param>
    public BaseWindow getWindowByid(EWindowID id)
    {
        BaseWindow window = null;
        if(windowDict.ContainsKey(id) == true)
        {
            window = windowDict[id];
        }

        return window;
    }

    /// <summary>
    /// 打开提示界面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="callback"></param>
    public void openAlertCenter(string msg,Action callback)
    {
        if (alertWindow == null)
        {
            alertWindow = gameObject.AddComponent<GlobalAlertWindow>();
        }
        alertWindow.Show();
        alertWindow.showCenter(msg, () => {
            Debug.Log("close");
            if(callback != null)
            {
                callback();
            }
        });
    }

    public void openAlertLeftRight(string msg, Action okFunc,Action closeFunc)
    {
        if (alertWindow == null)
        {
            alertWindow = gameObject.AddComponent<GlobalAlertWindow>();
        }
        alertWindow.Show();
        alertWindow.showLeftRight(msg, () => {
            Debug.Log("sure");
            if (okFunc != null)
            {
                okFunc();
            }
        }, () => {
            Debug.Log("close");
            if (closeFunc != null)
            {
                closeFunc();
            }
        });
    }

    /// <summary>
    /// 关闭提示界面
    /// </summary>
    private void closeAlertWindow()
    {
        if (alertWindow)
        {
            alertWindow.Close();
        }
    }
}
