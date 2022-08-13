using Boogops.Core.Events;
using FluentAssertions;
using Xunit;

namespace Boogops.Core.Tests;

public class DispatcherTests
{
    [Fact]
    public async Task AddedEventHandler_IsHandled()
    {
        // Arrange
        var eventHandler = new TestEventHandler();

        // Act
        Dispatcher.Register(eventHandler);
        var results = await Dispatcher.RaiseAsync(new TestEvent());

        // Assert
        eventHandler.IsHandled.Should().BeTrue();
    }

    private class TestEvent : IEvent
    {
        public Guid TraceId { get; set; }
    }

    private class TestEventHandler : IHandleEvent<TestEvent>
    {
        public Task<CoreResult> HandleAsync(TestEvent @event)
        {
            IsHandled = true;
            return Task.FromResult(CoreResult.Success);
        }
        
        public bool IsHandled { get; private set; }

        public string Name => "TestEventHandler";
    }
}