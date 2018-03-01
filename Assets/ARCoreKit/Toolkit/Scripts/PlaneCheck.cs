using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCoreInternal;

public class PlaneCheck : MonoBehaviour {
    

    public void ChangePlaneStatus()
    {
        //LifecycleManager.Instance.DisableSession();
        GameObject.FindObjectOfType<ARCoreSession>().SessionConfig.EnablePlaneFinding = !GameObject.FindObjectOfType<ARCoreSession>().SessionConfig.EnablePlaneFinding;
        LifecycleManager.Instance.EnableSession();
    }



}
