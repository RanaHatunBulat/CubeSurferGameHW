using System.Collections;using UnityEngine;

namespace VrGamesDev
{
    /// <summary>
    /// Destroy a GameObject after some time, it could destroy itself or its parent
    /// </summary>
    public class VRG_Destroy : VRG_Base
    {
        /// <summary>
        /// The time it will wait to perform the actions
        /// </summary>
        [Tooltip("The time it will wait to perform the actions")]
        [SerializeField] private float m_Delay = 0.0f;
        public float delay
        {
            get
            {
                return this.m_Delay;
            }
            set
            {
                this.m_Delay = value;
            }
        }

        /// <summary>
        /// If false, i will destroy myself, if true, i will destroy my parent (myself included)
        /// </summary>
        [Tooltip("If false, i will destroy myself, if true, i will destroy my parent (myself included)")]
        [SerializeField] private bool m_Parent = false;
        public bool parent
        {
            get
            {
                return this.m_Parent;
            }
            set
            {
                this.m_Parent = value;
            }
        }


        public VRG_Destroy()
        {
            this.m_NextFrame = true;
        }

        // Coroutine funciont of Download
        protected override IEnumerator Do()
        {
            // call my parent
            if (this.m_Parent)
            {
                if (this.transform.parent)
                {
                    Object.Destroy(this.transform.parent.gameObject, this.m_Delay);
                }
                else
                {
                    Object.Destroy(this.gameObject, this.m_Delay);
                }
            }

            // or myself
            else
            {
                Object.Destroy(this.gameObject, this.m_Delay);
            }

            // finish next frame
            yield return null;
        }
    }
}