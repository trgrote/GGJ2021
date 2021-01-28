using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace rho
{
    [CreateAssetMenu(menuName = "Rho/Event")]
    public class Event : ScriptableObject
    {
        List<EventListener> _listeners = new List<EventListener>();

        public void Raise()
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised();
            }
        }

        public void Register(EventListener listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

    public class Event<TArg> : ScriptableObject
    {
        List<EventListener<TArg>> _listeners = new List<EventListener<TArg>>();

        public void Raise(TArg arg)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(arg);
            }
        }

        public void Register(EventListener<TArg> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener<TArg> listener)
        {
            _listeners.Remove(listener);
        }
    }

    public class Event<TArg1, TArg2> : ScriptableObject
    {
        List<EventListener<TArg1, TArg2>> _listeners = new List<EventListener<TArg1, TArg2>>();

        public void Raise(TArg1 arg11, TArg2 arg2)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(arg11, arg2);
            }
        }

        public void Register(EventListener<TArg1, TArg2> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener<TArg1, TArg2> listener)
        {
            _listeners.Remove(listener);
        }
    }

    public class Event<TArg1, TArg2, TArg3> : ScriptableObject
    {
        List<EventListener<TArg1, TArg2, TArg3>> _listeners = new List<EventListener<TArg1, TArg2, TArg3>>();

        public void Raise(TArg1 arg11, TArg2 arg2, TArg3 arg3)
        {
            for (var i = _listeners.Count - 1; i >= 0 ; --i)
            {
                _listeners[i].OnEventRaised(arg11, arg2, arg3);
            }
        }

        public void Register(EventListener<TArg1, TArg2, TArg3> listener)
        {
            _listeners.Add(listener);
        }

        public void Unregister(EventListener<TArg1, TArg2, TArg3> listener)
        {
            _listeners.Remove(listener);
        }
    }
}