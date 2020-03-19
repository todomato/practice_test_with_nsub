
using System;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace UnitTestProject1
{
    public class UnitTest2
    {
        [Test]
        public void Test_CreatingSubstitute_MutipleInterfaces()
        {
            var command = Substitute.For<ICommand, IDisposable>();

            var runner = new CommandRunner(command);
            runner.RunCommand();

            command.Received().Execute();
            ((IDisposable)command).Received().Dispose();
        }
    }

    public interface ICommand: IDisposable
    {
        void Execute();
    }

    class CommandRunner
    {
        private ICommand _command;

        public CommandRunner(ICommand command)
        {
            _command = command;
        }

        public void RunCommand()
        {
            _command.Execute();
            _command.Dispose();
        }
    }
}