using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace test1
{
    public class HelloWorldView : View
    {
        public Signal buttonclicked = new Signal();
        private Rect buttonRect = new Rect(0, 0, 200, 50);
        public void OnGUI()
        {
            if(GUI.Button(buttonRect,"message"))
            {
                buttonclicked.Dispatch();
            }
        }
    }
}
