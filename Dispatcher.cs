using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityThreadDispatcher
{
    public class Dispatcher : MonoBehaviour
    {
        public static Dispatcher Instance =>
            _instance != null ? _instance : new GameObject().AddComponent<Dispatcher>();
        
        private static Dispatcher _instance;
        
        private readonly Queue<Action> _dispatchQueue = new Queue<Action>();
        private readonly object _queueLock = new object();

        public void Enqueue(Action action)
        {
            lock (_queueLock)
            {
                _dispatchQueue.Enqueue(action);
            }
        }

        private void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("UnityThreadDispatcher instance already exists.");
                Destroy(gameObject);
                return;
            }
            
            _instance = this;
        }

        private void Update()
        {
            lock (_queueLock)
            {
                if (_dispatchQueue.Count <= 0) return;

                var action = _dispatchQueue.Dequeue();
                action?.Invoke();
            }
        }

        private void OnDestroy()
        {
            if (_instance == this) _instance = null;
        }
    }
}