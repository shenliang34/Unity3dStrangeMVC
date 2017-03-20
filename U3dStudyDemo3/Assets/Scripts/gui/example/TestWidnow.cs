using UnityEngine;
using System.Collections;

public class TestWidnow : GameWindow
{
    //// Use this for initialization
    protected override void Start()
    {
        this.Resize(700,500);

        parentPath = "Canvas";

        //设置标题地址
        titlePath = "mainui/title";

        base.Start();
    }
}
