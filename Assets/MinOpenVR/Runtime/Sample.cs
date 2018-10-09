using System;
using UnityEngine;
using Valve.VR;


namespace MinOpenVR
{
    public class Sample : MonoBehaviour
    {
        class VR : IDisposable
        {
            CVRSystem m_system;

            EVRInitError m_error;
            public EVRInitError Error
            {
                get { return m_error; }
            }

            public bool IsInitialized
            {
                get
                {
                    return m_system != null;
                }
            }

            public VR()
            {
                m_system = OpenVR.Init(ref m_error, EVRApplicationType.VRApplication_Scene);
            }

            public void Dispose()
            {
                OpenVR.Shutdown();
            }
        }

        VR m_vr;

        private void OnEnable()
        {
            m_vr = new VR();

            if(!m_vr.IsInitialized)
            {
                Debug.LogWarning(m_vr.Error);
                enabled = false;
            }
        }

        private void OnDisable()
        {
            if (m_vr != null)
            {
                m_vr.Dispose();
                m_vr = null;
            }
        }
    }
}
