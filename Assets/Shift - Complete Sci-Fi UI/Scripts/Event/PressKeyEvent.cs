using UnityEngine;
using UnityEngine.Events;

namespace Michsky.UI.Shift
{
    public class PressKeyEvent : MonoBehaviour
    {
        [Header("Key")]
        [SerializeField]
        public KeyCode hotkey;
        public bool pressAnyKey;
        public bool invokeAtStart;

        [Header("Action")]
        [SerializeField]
        public UnityEvent pressAction;

        void Start()
        {
            if (invokeAtStart)
                pressAction.Invoke();
        }

        void Update()
        {
            if (pressAnyKey)
            {
                if (Input.anyKeyDown)
                    pressAction.Invoke();
            }

            else
            {
                if (Input.GetKeyDown(hotkey))
                    pressAction.Invoke();
            }
        }
    }
}