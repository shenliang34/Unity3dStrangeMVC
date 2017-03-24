//using DG.Tweening;
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
    //地址
    protected string titlePath;
    //0 
    private int guiStatus;

    override protected void Start()
    {
        base.Start();

        //名字
        if (titleName)
        {
            titleImg.sprite = Sprite.Create(titleName, new Rect(0, 0, titleName.width, titleName.height), new Vector2());
            titleImg.rectTransform.sizeDelta = new Vector2(titleName.width, titleName.height);
        }

        //设置位置
        resetBgPosition();

        //关闭按钮事件
        closeBtn.onClick.AddListener(onClickCloseBtn);
    }

    protected override void Awake()
    {
        //加载资源
        windowPath = "prefabs/WindowNormalPrefab";
        parentPath = "Canvas/Window";

        base.Awake();

        //
        window.transform.localPosition = new Vector3();

        //Image winImage = window.GetComponent<Image>();
        //Tweener tweener = winImage.rectTransform.DOMove(Vector3.zero, 1f);
        //tweener.SetUpdate(true);
        //tweener.SetEase(Ease.Linear);
        //tweener.onComplete = delegate () { Debug.Log("完成"); };
        //winImage.material.DOFade(0, 1f).onComplete = delegate () { Debug.Log("褪色完成"); };


        window.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(Screen.width,Screen.height);

        //获取背景
        Transform bg = window.transform.Find("bg");
        bgImg = bg.GetComponent<Image>();
        Vector2 bgPos = new Vector2(this.Width, this.Height);
        bgImg.rectTransform.sizeDelta = bgPos;//设置背景大小

        //获取标题背景
        Transform titleBg = bg.transform.Find("titleBg");
        titleBgImg = titleBg.GetComponent<Image>();

        //获取按钮
        Transform btn = bg.transform.Find("closeBtn");
        closeBtn = btn.GetComponent<Button>();

        //获取标题
        Transform titleTf = bg.transform.Find("title");
        titleImg = titleTf.GetComponent<Image>();

        //标题名字
        titleName = Resources.Load(titlePath) as Texture2D;

        resetBgPosition();
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
        
        //resetBgPosition();

        // Debug.Log("我是父类中的OnGUI");
        base.OnGUI();//调用基类中的onGUI
        
    }

    //重置位置
    private void resetBgPosition()
    {
        ////背景位置
        if (bgImg)
        {
            bgImg.rectTransform.position = new Vector3((Screen.width - this.Width) * 0.5f, (Screen.height - this.Height) * 0.5f + this.Height);
        }

        ////标题背景位置
        if (titleBgImg)
        {
            titleBgImg.rectTransform.localPosition = new Vector3(this.Width * 0.5f, -22, 0);
        }

        ////关闭按钮位置
        if (closeBtn)
        {
            closeBtn.transform.localPosition = new Vector3(this.Width - 1, -1, 0);
        }

        ////标题
        if (titleName != null)
        {
            titleImg.transform.localPosition = new Vector3(this.Width * 0.5f, -23, 0);
        }
    }

    //
    private void OnDestroy()
    {
        closeBtn.onClick.RemoveListener(onClickCloseBtn);
    }


}
