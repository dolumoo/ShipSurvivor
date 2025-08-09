using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class Singleton < T > : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<T>();

                    if (_instance == null)
                    {
                        Debug.Log("인스턴스 없음!");
                    }
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log("싱글톤 에러!");
                Destroy(gameObject);
            }
        }
    }
}
