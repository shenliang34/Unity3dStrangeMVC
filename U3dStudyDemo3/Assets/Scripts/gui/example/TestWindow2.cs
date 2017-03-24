using UnityEngine;
using System.Collections;

public class TestWindow2 : GameWindow
{
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    protected override void Awake()
    {
        this.Resize(700, 300);

        //设置标题地址
        titlePath = "mainui/title";

        base.Awake();
    }

    protected override void OnGUI()
    {
        base.OnGUI();

        GUI.skin = null;
        GUI.Label(new Rect(500, 100, 100, 20), "这是Testwindow2");
    }
}
