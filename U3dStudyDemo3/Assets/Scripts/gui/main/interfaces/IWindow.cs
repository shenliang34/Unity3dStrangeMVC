
interface IWindow
{
    bool Modal { get; set; } //是否需要模态 model

    int WindowType { get; set; }//窗口类型

    float Width { get; }//宽

    float Height { get; }//高

    void Show();//显示
    void Close();//关闭

    void OnShow();//显示界面  界面完全打开时调用
    void OnClose();//界面关闭 界面完全关闭时调用

    void InitWindow();//界面初始化
}

