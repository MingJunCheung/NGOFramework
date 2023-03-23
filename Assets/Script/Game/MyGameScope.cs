using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MyGameScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<TestClass>(Lifetime.Singleton);
    }
}

public class TestClass
{
    public void Log()
    {
        Debug.Log($"ÕâÊÇ¸ötestClass");
    }
}
