using UnityEngine;
using System.Collections;

public class WindowManager : MonoBehaviour
{

    // Use this for initialization

    private TestWidnow testwindow;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(0,0,100,100),"打开界面"))
        {
            testwindow = gameObject.AddComponent<TestWidnow>();
        }

        if(GUI.Button(new Rect(100,0,100,100),"关闭界面"))
        {
            if(testwindow)
            {
                Destroy(testwindow);
            }
        }
    }
}
