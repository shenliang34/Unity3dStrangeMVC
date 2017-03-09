using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

    // Use this for initialization
    //public int i;
    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public GameObject[] wheelMeshs = new GameObject[4];
    public GameObject obj;

    public delegate void BoilHandler(int param);
    public event BoilHandler BoilEvent;
	void Start () {
        //材质颜色
        obj.GetComponent<Renderer>().material.color = Color.red;
        //for (i = 0; i < 10; i++)
        //{
        //    Debug.Log(i);
        //}
        ////开始函数
        //Debug.Log("hello world");

        speck("小明", Chinese);
        speck("xiaoming", English);
        //
        DelegateLanguage delegateLanguage;
        delegateLanguage = English;
        delegateLanguage += Chinese;
        delegateLanguage("小明");

        this.BoilEvent += Main_BoilEvent;
        this.DebugLog();
	}

    //触发
    private void DebugLog()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i > 90)
            {
                this.BoilEvent(i);
            }
        }
    }

    //委托函数
    private void Main_BoilEvent(int param)
    {
        Debug.Log(param);
    }

    // Update is called once per frame
    void Update () {

        //更新函数

        //Debug.Log("hello world");
        UpdateMeshesPositions();
    }

    private void UpdateMeshesPositions()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 pos;
            Quaternion qua;
            wheelColliders[i].GetWorldPose(out pos, out qua);
            //wheelMeshs[i].transform.position = pos;
            //wheelMeshs[i].transform.rotation = qua;
        }
    }

    private void FixedUpdate()
    {
        float steer = Input.GetAxis("Horizontal");
        wheelColliders[0].steerAngle = steer * 45;
        wheelColliders[1].steerAngle = steer * 45;
        float accelerate = Input.GetAxis("Vertical");
        wheelColliders[2].motorTorque = accelerate * 300;
        wheelColliders[3].motorTorque = accelerate * 300;
    }



    // 当 MonoBehaviour 将被销毁时调用此函数
    private void OnDestroy()
    {

    }

    //委托测试

    private void Chinese(string name)
    {
        Debug.Log("你好，" + name);
    }

    private void English(string name)
    {
        Debug.Log("Hello，" + name);
    }

    private delegate void DelegateLanguage(string name);

    private void speck(string name, DelegateLanguage func)
    {
        func(name);
    }
}
