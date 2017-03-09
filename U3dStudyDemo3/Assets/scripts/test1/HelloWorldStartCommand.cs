using UnityEngine;
using strange.extensions.command.impl;
namespace test1
{
    public class HelloWorldStartCommand : Command {

        public override void Execute()
        {
            //base.Execute();

            Debug.Log("hello World");
        }
    }
}
