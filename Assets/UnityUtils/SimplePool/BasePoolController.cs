using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HandsomeStudio.PoolSystem
{
    public abstract class BasePoolController
    {
        public bool autoInstance = true;
        public int preloadAmount = 1;
        protected Transform m_spawnParent = null;

        public abstract void Init(Transform spawnParent = null, int preload = 0);
    }
}