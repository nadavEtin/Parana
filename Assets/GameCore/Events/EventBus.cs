﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts.Utility
{
    public enum GameplayEvent
    {
        Error
    }

    public class EventBus
    {
        private readonly Dictionary<GameplayEvent, List<Action<BaseEventParams>>> _subscription = new();

        public void Subscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            if (_subscription.ContainsKey(eventType) == false)
                _subscription.Add(eventType, new List<Action<BaseEventParams>>());

            var handlerList = _subscription[eventType];
            if (handlerList.Contains(handler) == false)
                handlerList.Add(handler);
        }

        public void Unsubscribe(GameplayEvent eventType, Action<BaseEventParams> handler)
        {
            _subscription[eventType]?.Remove(handler);
        }

        public void Publish(GameplayEvent eventType, BaseEventParams eventParams)
        {
            if (_subscription.ContainsKey(eventType) == false)
                return;
            
            foreach (var handler in _subscription[eventType])
                handler?.Invoke(eventParams);
        }
    }
}
