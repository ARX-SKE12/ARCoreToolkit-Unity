# ARCore Toolkit

Toolkit for ARCore in Unity Platform based on Example of ARCore

## Usage

* Add `ARCorekit Controller` Prefab from `Assets/ARCoreKit/Toolkit/ARCorekit Controller.prefab` to your Unity Scene

### Plane Tracking

* Create the script that has `void OnNewPlanesDetected(List<TrackedPlane> trackedPlanes)` to get new planes.
* In your script, add `GameObject.FindObjectOfType<PlaneStreamer>().Register(gameObject);` to your `Start()` method.
* You can look on our `PlaneGenerator` as example of this.

### Plane Generator

It is used for generating plane based on plane prefab that has `PlaneBehaviour`.

* Add `Plane Generator` Prefab from `Assets/ARCoreKit/Toolkit/Plane Generator.prefab` to your Unity Scene.
* Drag `Plane Prefab` and `Plane Material` to `Plane Generator`

### Plane with collider

In this toolkit, we provide `PlaneCollider` Prefab which is worked with colliding to rigidbody of Unity.

### Customizing Plane

* Create the script that has `void OnUpdateMesh(Mesh mesh)` method.
* Add this script to your plane that has `Plane Behaviour` script.
* Based on mesh in `OnUpdateMesh`, you can use it to customize your own plane.

### Example
For moreunderstanding, we provide example scene in this toolkit. You can check or build it at `Assets/ARCoreToolkit/Example/Scenes/ExampleScene.unity`.
