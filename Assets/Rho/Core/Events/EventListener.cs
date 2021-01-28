using UnityEngine;
using UnityEngine.Events;

namespace rho
{
    public class EventListener : MonoBehaviour
    {
        public Event Event;
        public UnityEvent Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }

    public class EventListener<TArg> : MonoBehaviour
    {
        public Event<TArg> Event;
        public UnityEvent<TArg> Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised(TArg arg)
        {
            Response.Invoke(arg);
        }
    }

    public class EventListener<TArg1, TArg2> : MonoBehaviour
    {
        public Event<TArg1, TArg2> Event;
        public UnityEvent<TArg1, TArg2> Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised(TArg1 arg1, TArg2 arg2)
        {
            Response.Invoke(arg1, arg2);
        }
    }

    public class EventListener<TArg1, TArg2, TArg3> : MonoBehaviour
    {
        public Event<TArg1, TArg2, TArg3> Event;
        public UnityEvent<TArg1, TArg2, TArg3> Response;

        void OnEnable()
        {
            Event.Register(this);
        }

        void OnDisable()
        {
            Event.Unregister(this);
        }

        public void OnEventRaised(TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            Response.Invoke(arg1, arg2, arg3);
        }
    }
}