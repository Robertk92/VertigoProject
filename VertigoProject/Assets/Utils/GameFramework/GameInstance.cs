using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.GameFramework
{
    public class GameInstance : MonoBehaviour
    {
        /// <summary>
        /// First Awake of the scene
        /// </summary>
        protected virtual void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
