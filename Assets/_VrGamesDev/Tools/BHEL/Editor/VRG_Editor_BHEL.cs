using UnityEditor;
using UnityEngine;

using VrGamesDev.BHEL;

///#IGNORE
//  This namespace is the base to all the editor classes of VRG packages
namespace VrGamesDev.Editor
{
    public class VRG_Editor_BHEL : VRG_Editor
    {
        public new static string m_Prefabs = "Tools/BHEL/Prefabs/";

        [MenuItem("Tools/Vr Games Dev/BHEL", false, 10001)]
        public static void VRG_Bhel() => AddVRG_Bhel();

        public static void AddVRG_Bhel()
        {
            VRG_Bhel inScene_VRG_Bhel = GameObject.FindObjectOfType<VRG_Bhel>();
            if (inScene_VRG_Bhel == null)
            {
                CreatePrefab(m_Prefabs + "VRG_Bhel", true);
            }
            else
            {
                Debug.Log("<color=red>ERROR: </color> There is already a VRG_BHEL object in the scene");
            }
        }

    }
}