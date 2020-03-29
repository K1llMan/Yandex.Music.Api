using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

using Xunit.Sdk;

namespace Yandex.Music.Api.Tests
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
