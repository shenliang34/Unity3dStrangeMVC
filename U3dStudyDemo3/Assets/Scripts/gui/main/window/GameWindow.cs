using UnityEngine;
using UnityEngine.UI;

public class GameWindow : BaseWindow
{
    //标题
    private Image titleBgImg;
    //背景
    private Image bgImg;
    //关闭按钮
    private Button closeBtn;
    //标题
    private Image titleImg;
    //标题名字
    private Texture2D titleName;
    //ui的父节点
    private GameObject mainUI;
    //当前Window
    private GameObject window;
    //地址
    protected string titlePath;
    //父节点
    protected string parentPath;

    override protected void Start()
    {
        //加载资源

        //this.WindowType = EWindowType.Normal;

        //this.Resize(500,300);
        GameObject prefab = Resources.Load("mainui/windowPrefab") as GameObject;
        GameObject window = Instantiate(prefab);

        //设置父节点
        mainUI = GameObject.Find(parentPath);
        window.transform.SetParent(mainUI.transform);

        //获取背景
        Transform bg = window.transform.Find("bg");
        bgImg = bg.GetComponent<Image>();
        Vector2 bgPos = new Vector2(this.Width, this.Height);
        bgImg.rectTransform.sizeDelta = bgPos;//设置背景大小

        //获取标题背景
        Transform titleBg = window.transform.Find("titleBg");
        titleBgImg = titleBg.GetComponent<Image>();

        //获取按钮
        Transform btn = window.transform.Find("closeBtn");
        closeBtn = btn.GetComponent<Button>();

        //获取标题
        Transform titleTf = window.transform.Find("title");
        titleImg = titleTf.GetComponent<Image>();


        titleName = Resources.Load(titlePath) as Texture2D;
        titleImg.sprite = Sprite.Create(titleName,new Rect(0,0,titleName.width,titleName.height),new Vector2());
        titleImg.rectTransform.sizeDelta = new Vector2(titleName.width,titleName.height);

        //设置位置
        resetBgPosition();

        //关闭按钮事件
        closeBtn.onClick.AddListener(onClickCloseBtn);
    }

    private void onClickCloseBtn()
    {
        Debug.Log("close");
        this.Close();
    }

    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="path"></param>
    private Texture loadTexture(string spriteName)
    {
        return Resources.Load<Texture>("mainui/" + spriteName);
    }

    // Use this for initialization

    override protected void OnGUI()
    {
        //GUI.DrawTexture(new Rect(50, 50, this.Width, this.Height), bgTexture);
        //Screen.width
        resetBgPosition();

        // Debug.Log("我是父类中的OnGUI");
        base.OnGUI();//调用基类中的onGUI
    }

    //重置位置
    private void resetBgPosition()
    {
        //背景位置
        if (bgImg)
        {
            bgImg.rectTransform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        }

        //标题背景位置
        if(titleBgImg)
        {
            titleBgImg.rectTransform.position = new Vector3(Screen.width * 0.5f, (Screen.height * 0.5f + this.Height * 0.5f - 22), 0);
        }

        //关闭按钮位置
        if(closeBtn)
        {
            closeBtn.transform.position = new Vector3(Screen.width * 0.5f + this.Width * 0.5f - 12, (Screen.height * 0.5f + this.Height * 0.5f) - 21, 0);
        }

        //标题
        if (titleName != null)
        {
           // Rect pos = new Rect(, titleName.width, titleName.height);
            //GUI.DrawTexture(pos, titleName);
            titleImg.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f + this.Height * 0.5f - 24, 0);
        }
    }
}
