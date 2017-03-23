
interface IWindow
{
    bool Modal { get; set; } //是否需要模态 model

    int WindowType { get; set; }//窗口类型

    float Width { get; }//宽

    float Height { get; }//高

    EWindowID WidowId { get; set; }//窗口

    void Show();//显示
    void Close();//关闭

    void BeforeShow();//显示界面前
    void BeforeClose();//关闭界面前

    void InitWindow();//界面初始化
}

