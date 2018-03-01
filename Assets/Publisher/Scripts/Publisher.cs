
using System.Collections.Generic;
using UnityEngine;

namespace PublisherKit {
    public class Publisher : MonoBehaviour
    {
        List<GameObject> subscribers = new List<GameObject>();

        public void Register(GameObject subscriber)
        {
            subscribers.Add(subscriber);
        }

        protected void Broadcast(string methodName, object data = null)
        {
            foreach (GameObject subscriber in subscribers)
                subscriber.SendMessage(methodName, data, SendMessageOptions.DontRequireReceiver);
        }
    }
}
