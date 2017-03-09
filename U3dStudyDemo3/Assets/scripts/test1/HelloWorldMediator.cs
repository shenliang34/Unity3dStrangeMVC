using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace test1
{
    public class HelloWorldMediator:Mediator
    {
        [Inject]
        public HelloWorldView view { get; set; }
        [Inject]
        public IsomeMangers manager { get; set; }
        public override void OnRegister()
        {

            view.buttonclicked.AddListener(delegate () { manager.DoManagement(); });
        }
    }
}
