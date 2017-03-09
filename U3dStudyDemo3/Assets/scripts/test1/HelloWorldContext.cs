using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

namespace test1
{
    public class HelloWorldContext : SignalContext {

        public HelloWorldContext(MonoBehaviour contextView) : base(contextView)
        {

        }

        protected override void mapBindings()
        {
            base.mapBindings();

            commandBinder.Bind<HelloWorldSignals>().To<HelloWorldStartCommand>().Once();

            mediationBinder.Bind<HelloWorldView>().To<HelloWorldMediator>();

            injectionBinder.Bind<IsomeMangers>().To<ManagerAsNormalClass>().ToSingleton();
        }
    }

}
