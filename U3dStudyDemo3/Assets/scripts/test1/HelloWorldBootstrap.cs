using UnityEngine;
using System.Collections;

using strange.extensions.context.impl;

namespace test1
{
    public class HelloWorldBootstrap:ContextView
    {
        void Awake()
        {
            this.context = new HelloWorldContext(this);
        }
    }
}
