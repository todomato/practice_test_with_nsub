﻿using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Test]
        public void Test1()
        {
            const int actual = 1;
            const int expected = 1;
            actual.Should().Be(expected);
        }

        [Test]
        public void Test2()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2).Returns(3);

            var actual = calculator.Add(1, 2);
            actual.Should().Be(3);
        }

        [Test]
        public void Test_ReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(1, 2);

            calculator.Received().Add(1, 2);
            calculator.DidNotReceive().Add(5, 7);
        }

        [Test]
        public void Test_DidNotReceivedSpecificCall()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(5, 7);

            calculator.Received().Add(5, 7);
        }

        [Test]
        public void Test_SetPropertyValue()
        {
            ICalculator calculator = Substitute.For<ICalculator>();

            calculator.Mode.Returns("DEC");
            "DEC".Should().Be(calculator.Mode);

            calculator.Mode = "HEX";
            "HEX".Should().Be(calculator.Mode);
        }

        [Test]
        public void Test_PassFuncToReturns()
        {
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator
                .Add(Arg.Any<int>(), Arg.Any<int>())
                .Returns(x => (int) x[0] + (int) x[1]);

            var actual = calculator.Add(5, 10);
            actual.Should().Be(15);
        }
    }

    public interface ICalculator
    {
        int Add(int a, int b);
        string Mode { get; set; }
    }
}