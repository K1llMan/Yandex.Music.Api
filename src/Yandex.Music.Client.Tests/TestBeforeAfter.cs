using System;
using System.Diagnostics;
using System.Reflection;

using Xunit.Sdk;

namespace Yandex.Music.Client.Tests
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class TestBeforeAfter: BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            Debug.WriteLine(methodUnderTest.Name);
        }

        public override void After(MethodInfo methodUnderTest)
        {
            Debug.WriteLine(methodUnderTest.Name);
        }
    }
}
