using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utility
{
    public enum GameplayEvent
    {
        GameStart, GameEnd
    }

    public class EventBus
    {
        private readonly Dictionary<GameplayEvent, List<Action<BaseEventParams>>> _subscription = new();

        public void Subscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            if (_subscription.ContainsKey(eventType) == false)
                _subscription.Add(eventType, new List<Action<BaseEventParams>>());

            if (_subscription[eventType].Contains(handler) == false)
                _subscription[eventType].Add(handler);
        }

        public void Unsubscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            if (_subscription.ContainsKey(eventType) == false)
                return;

            var handlersList = _subscription[eventType];
            handlersList.Remove(handler);
        }

        public void Publish(GameplayEvent eventType, BaseEventParams eventParams)
        {
            if (_subscription.ContainsKey(eventType) == false)
                return;

            var handlers = _subscription[eventType];
            foreach (var handler in handlers)
                handler?.Invoke(eventParams);
        }
    }
}
