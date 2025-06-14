using UnityEngine;

namespace Utils
{
    // This is a SingletonObject class that we will use for other classes to inherit singleton behaviour from.
    public class SingletonObject<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        // We never create another one, as following the singleton design principles.

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null)
                    {
                        Debug.LogError("Instance of " + typeof(T) + "required in the scene, but there is none.");
                    }
                }

                return instance;
            }
        }
    }
}