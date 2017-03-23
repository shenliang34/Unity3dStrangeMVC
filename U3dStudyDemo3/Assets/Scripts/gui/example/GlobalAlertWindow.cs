using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class GlobalAlertWindow : BaseWindow
{
    // Use this for initialization
    private Button centerBtn;
    private Button leftBtn;
    private Button rightBtn;
    private Text tips;
    public delegate void onComplete();
    
    protected override void Start()
    {
        base.Start();

        //修改位置
        window.transform.localPosition = new Vector3();
    }

    override protected void Awake()
    {
        windowPath = "prefabs/WindowAlertPrefab";
        parentPath = "Canvas";

        base.Awake();

        //取按钮
        centerBtn = window.transform.FindChild("centerBtn").GetComponent<Button>();
        leftBtn = window.transform.FindChild("leftBtn").GetComponent<Button>();
        rightBtn = window.transform.FindChild("rightBtn").GetComponent<Button>();
        tips = window.transform.FindChild("tips").GetComponent<Text>();

        HideAll();
    }

    /// <summary>
    /// 显示中间按钮
    /// </summary>
    /// <param name="tip"></param>
    /// <param name="callback"></param>
    public void showCenter(string tip, Action callback)
    {
        HideAll();

        if(centerBtn)
        {
            centerBtn.gameObject.SetActive(true);
            centerBtn.onClick.AddListener(delegate {
                callback();
                Close();
            });
        }

        if(tips)
        {
            tips.text = tip;
        }
        
        Debug.Log(tips);
    }

    /// <summary>
    /// 显示两边按钮
    /// </summary>
    /// <param name="tip"></param>
    /// <param name="okFunc"></param>
    /// <param name="closeFunc"></param>
    public void showLeftRight(string tip, Action okFunc, Action closeFunc)
    {
        HideAll();

        if(leftBtn)
        {
            leftBtn.gameObject.SetActive(true);
            leftBtn.onClick.AddListener(delegate { okFunc(); Close(); });
        }
        
        if(rightBtn)
        {
            rightBtn.gameObject.SetActive(true);
            rightBtn.onClick.AddListener(delegate { closeFunc(); Close(); });
        }

        if (tips)
        {
            tips.text = tip;
        }
    }

    protected override void OnGUI()
    {
        base.OnGUI();

    }

    /// <summary>
    /// 隐藏所有
    /// </summary>
    private void HideAll()
    {
        if(centerBtn)
        {
            centerBtn.gameObject.SetActive(false);
            centerBtn.onClick.RemoveAllListeners();
        }

        if (leftBtn)
        {
            leftBtn.gameObject.SetActive(false);
            leftBtn.onClick.RemoveAllListeners();
        }

        if (rightBtn)
        {
            rightBtn.gameObject.SetActive(false);
            rightBtn.onClick.RemoveAllListeners();
        }

        if(tips)
        {
            tips.text = "";
        }
    }
}
