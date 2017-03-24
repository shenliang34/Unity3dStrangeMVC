using UnityEngine;
using System;



public class BaseWindow : MonoBehaviour , IWindow
{
    //是否模态
    private bool modal;
    //窗口类型
    private int windowType;
    //
    private EWindowID windowId;
    //宽
    private float width;
    //高
    private float height;
    //被动关闭后可弹出

    protected bool canPop;
    //是否销毁
    protected bool isDestroy;
    //ui的父节点
    protected GameObject mainUI;
    //当前Window
    protected GameObject window;
    //父节点
    protected string parentPath;
    //窗口路径
    protected string windowPath;

    //
    public event EventHandler onDestroy;
    //
    public event EventHandler onStart;

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
    /// 
    /// </summary>
    public EWindowID WidowId
    {
        get
        {
            return windowId;
        }

        set
        {
            windowId = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool CanPop
    {
        get
        {
            return canPop;
        }

        set
        {
            canPop = value;
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
    virtual public float Width
    {
        get
        {
            return width;
        }
    }
    /// <summary>
    /// 高
    /// </summary>
    virtual public float Height
    {
        get
        {
            return height;
        }
    }
    /// <summary>
    /// 界面初始化
    /// </summary>
    virtual public void InitWindow()
    {

    }
    /// <summary>
    /// 界面显示
    /// </summary>
    virtual public void Show()
    {
        if (window)
        {
            BeforeShow();

            window.SetActive(true);
        }
    }
    /// <summary>
    /// 界面关闭
    /// </summary>
    virtual public void Close()
    {
        if (window)
        {
            window.SetActive(false);
            //如果需要销毁就销毁
            if(isDestroy)
            {
                Destroy(window);//销毁生成的物体
                Destroy(this);//销毁脚本
            }
        }
        //返回
        if(onDestroy != null)
        {
            onDestroy(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// 显示前
    /// </summary>
    virtual public void BeforeShow()
    {

    }

    /// <summary>
    /// 关闭前
    /// </summary>
    virtual public void BeforeClose()
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

    //顶置窗口
    public void TopWindow()
    {
        if(mainUI && window)
        {
            //统计数量
            int count = mainUI.transform.childCount;
            //调换层次
            window.transform.SetSiblingIndex(count);
            //mainUI.transform.GetChild(0);
        }
    }

    /// <summary>
    /// 在这里获取游戏实例
    /// </summary>
    virtual protected void Awake()
    {
        GameObject prefab = Resources.Load(windowPath) as GameObject;
        window = Instantiate(prefab);

        //设置父节点
        mainUI = GameObject.Find(parentPath);
        window.transform.SetParent(mainUI.transform);

        isDestroy = true;
    }

    /// <summary>
    /// 在这里进行游戏状态初始化
    /// </summary>
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
