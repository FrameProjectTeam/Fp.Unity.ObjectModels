using UnityEngine;

namespace Fp.ObjectModels.Singletons
{
    public abstract class SingletonBehavior<T> : MonoBehaviour
        where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_singletonDestroyed)
                {
                    Debug.LogError($"[Singleton] Instance \"{typeof(T).Name}\" was been destroyed.");
                    return null;
                }

                if (_instance != null)
                {
                    return _instance;
                }

                T[] activeObjects = FindObjectsOfType<T>(false);

                if (activeObjects.Length > 1)
                {
                    Debug.LogWarning($"[Singleton] Found more than one({activeObjects.Length}) instance of \"{typeof(T).Name}\". Singleton shouldn't be more than 1 instance. Will select only first.");
                }
                else if (activeObjects.Length == 0)
                {
                    var singleton = new GameObject
                    {
                        name = $"{typeof(T).Name} [Singleton]",
                        hideFlags = HideFlags.HideAndDontSave
                    };

                    DontDestroyOnLoad(singleton);

                    return _instance = singleton.AddComponent<T>();
                }

                _instance = activeObjects[0];

                return _instance;
            }
        }

        private static bool _singletonDestroyed = false;

        public void OnDestroy () {
            _singletonDestroyed = true;
        }
    }
}