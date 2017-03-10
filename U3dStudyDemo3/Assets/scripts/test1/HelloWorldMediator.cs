using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;

namespace test1
{
    
    public class HelloWorldMediator:Mediator
    {
        //**依赖注入//
        [Inject]
        public HelloWorldView view { get; set; }
        [Inject]
        public IsomeMangers manager { get; set; }
        public override void OnRegister()
        {

            view.buttonclicked.AddListener(delegate () { manager.DoManagement(); });
        }

        public override void OnRemove()
        {
            //base.OnRemove();
            view.buttonclicked.RemoveListener(delegate () {manager.DoManagement(); });
        }
    }
}
