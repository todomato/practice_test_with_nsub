using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace UnitTestProject1
{
    public class UnitTestForException
    {
        [Test]
        public void Test_ThrowException()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.Add(-1, -1).Returns(x => throw new Exception());

            Action act = () => calculator.Add(-1, -1);

            act.Should().Throw<Exception>();
        }

        [Test]
        public void Test_Throw_ForNonVoidAndVoid()
        {
            var calculator = Substitute.For<ICalculator>();

            calculator.When(x => x.Add(-2,-2))
                .Do((x => throw new Exception()));

            Action act = () => calculator.Add(-2, -2);

            act.Should().Throw<Exception>();
        }
    }
}