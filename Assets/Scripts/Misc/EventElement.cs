using System;

namespace Misc
{
    public class EventElement<T>
    {
        protected event Action<T> Event;

        public void Invoke(T data)
        {
            Event?.Invoke(data);
        }

        public static EventElement<T> operator +(EventElement<T> kElement, Action<T> kDelegate)
        {
            kElement.Event += kDelegate;
            return kElement;
        }

        public static EventElement<T> operator -(EventElement<T> kElement, Action<T> kDelegate)
        {
            kElement.Event -= kDelegate;
            return kElement;
        }
    }
}
