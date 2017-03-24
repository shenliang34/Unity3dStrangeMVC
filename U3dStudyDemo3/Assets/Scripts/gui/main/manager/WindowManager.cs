using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    // Use this for initialization
    //窗口集合
    private Dictionary<EWindowID, BaseWindow> windowDict = new Dictionary<EWindowID, BaseWindow>();
    //弹出框栈
    private List<EWindowID> popWindows = new List<EWindowID>();
    //当前弹出
    private List<EWindowID> curWindows = new List<EWindowID>();

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
            OpenWindow(EWindowID.Test);
        }

        if(GUI.Button(new Rect(100,0,100,100), "关闭普通界面"))
        {
            CloseWindow(EWindowID.Test);
        }

        if (GUI.Button(new Rect(200, 0, 100, 100), "打开提示界面"))
        {
            openAlertCenter("打开提示界面",null,null);
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
            OpenWindow(EWindowID.Test2);
        }

        if (GUI.Button(new Rect(700, 0, 100, 100), "关闭普通界面"))
        {
            CloseWindow(EWindowID.Test2);

            //gameObject.transform.Find("Guide").SetSiblingIndex(gameObject.transform.Find("Alert").GetSiblingIndex());
        }

        if (GUI.Button(new Rect(800, 0, 100, 100), "打开确定提示框界面"))
        {
            openAlertCenter("打开确定提示框界面","了解", null);

            //gameObject.transform.Find("Guide").SetSiblingIndex(gameObject.transform.Find("Alert").GetSiblingIndex());
        }
    }

    /// <summary>
    /// 打开界面
    /// </summary>
    public BaseWindow OpenWindow(EWindowID id)
    {
        BaseWindow window = getWindowByid(id);
        if(window == null)
        {
            //添加窗口脚本组件
            switch(id)
            {
                case EWindowID.Alert:
                    window = gameObject.AddComponent<GlobalAlertWindow>();
                    Debug.Log("add alert ");
                    break;
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
            //显示
            window.Show();
            //保存widId
            window.WidowId = id;
            //添加委托
            window.onDestroy += DestroyWindow;

            if(window.CanPop)
            {
                //是否已经存在
                if(curWindows.Contains(id) == false)
                {
                    curWindows.Add(id);
                }
            }

            //顶置窗口
            window.TopWindow();

        }
        Debug.Log(windowDict.Count);
        return window;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isAutoClose"></param>
    /// <returns></returns>
    public BaseWindow OpenWindow(EWindowID id, bool isAutoClose)
    {
        BaseWindow window = OpenWindow(id);
        if(window)
        {

        }
        return window;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DestroyWindow(object sender, EventArgs e)
    {
        BaseWindow window = sender as BaseWindow;
        if (window)
        {
            //
            removeWindowById(window.WidowId);
            //
            //PopWindow();
        }
        
        Debug.Log("DestroyWindow");

        Debug.Log(windowDict.Count);
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    public void CloseWindow(EWindowID id)
    {
        BaseWindow window = getWindowByid(id);
        if(window != null)
        {
            Debug.Log("被动关闭");
            //if(window.CanPop)
            //{
            //    popWindows.Add(id);
            //}

            window.Close();
        }
    }

    /// <summary>
    /// 移除
    /// </summary>
    /// <param name="id"></param>
    public void removeWindowById(EWindowID id)
    {
        if(windowDict.ContainsKey(id))
        {
            BaseWindow window = windowDict[id];
            window.onDestroy -= DestroyWindow;
            windowDict.Remove(id);
        }
    }

    //
    public void removeWindowByClass(BaseWindow window)
    {
        if (windowDict.ContainsValue(window))
        {
            window.onDestroy -= DestroyWindow;
            windowDict.Remove(window.WidowId);
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
    /// 打开只有确定的提示界面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="centerLab"></param>
    /// <param name="callback"></param>
    public void openAlertCenter(string msg,string centerLab,Action callback)
    {
        GlobalAlertWindow window = OpenWindow(EWindowID.Alert) as GlobalAlertWindow;

        window.Show();
        window.showCenter(msg, centerLab, () => {
            Debug.Log("close");
            if(callback != null)
            {
                callback();
            }
        });
    }

    /// <summary>
    /// 打开有确定，取消的提示界面
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="okFunc"></param>
    /// <param name="closeFunc"></param>
    public void openAlertLeftRight(string msg, Action okFunc,Action closeFunc)
    {
        GlobalAlertWindow window = OpenWindow(EWindowID.Alert) as GlobalAlertWindow;
        
        window.Show();
        window.showLeftRight(msg,null,null, () => {
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
        GlobalAlertWindow window = getWindowByid(EWindowID.Alert) as GlobalAlertWindow;
        if (window != null)
        {
            window.Close();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void PopWindow()
    {
        if (popWindows.Count > 0)
        {
            EWindowID id = popWindows[popWindows.Count - 1];

            popWindows.RemoveAt(popWindows.Count - 1);

            OpenWindow(id);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void PushWindow(EWindowID id)
    {
        if(popWindows.Contains(id) == false)
        {
            popWindows.Add(id);
        }
    }
}
