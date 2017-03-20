using UnityEngine;
using System;

enum EWindowType
{
    Normal,//正常窗口
    Alert  //提示窗口
}

public class BaseWindow : MonoBehaviour , IWindow
{
    //是否模态
    private bool modal;
    //窗口类型
    private int windowType;
    //宽
    private float width;
    //高
    private float height;

    /// <summary>
    /// 是否模态
    /// </summary>
    public bool Modal
    {
        get
        {
            return modal;
        }

        set
        {
            modal = value;
        }
    }
    /// <summary>
    /// 窗口类型
    /// </summary>
    public int WindowType
    {
        get
        {
            return windowType;
        }

        set
        {
            windowType = value;
        }
    }
    /// <summary>
    /// 宽
    /// </summary>
    public float Width
    {
        get
        {
            return width;
        }
    }
    /// <summary>
    /// 高
    /// </summary>
    public float Height
    {
        get
        {
            return height;
        }
    }
    /// <summary>
    /// 界面初始化
    /// </summary>
    public void InitWindow()
    {

    }
    /// <summary>
    /// 界面显示
    /// </summary>
    public void Show()
    {
        
    }
    /// <summary>
    /// 界面关闭
    /// </summary>
    public void Close()
    {

    }

    /// <summary>
    /// 缓动结束后显示
    /// </summary>
    public void OnShow()
    {

    }

    /// <summary>
    /// 缓动结束后关闭
    /// </summary>
    public void OnClose()
    {

    }

    /// <summary>
    /// 设置宽高
    /// </summary>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public void Resize(float width,float height)
    {
        this.width = width;
        this.height = height;
    }

    // Use this for initialization
    virtual protected void Start()
    {

    }

    // Update is called once per frame
    virtual protected void Update()
    {

    }

    virtual protected void OnGUI()
    {
        //Debug.Log("我是基类中的OnGUI");
    }
}
