using UnityEngine; 

public class CameraBillboard : MonoBehaviour
 {
    public Camera Camera_;
    [Tooltip(" if true the game object will be positioned just in front of the cameras near clip plane")]
    public bool PositionInFrontOfCamera;
    [Tooltip("the offset to position the object when PositionInFrontOfCamera is true")]
    public float Offset = 0.001f;

    private Transform transform_;
 
    void Awake()
    {
        // if no camera has been specified just use main camera
        if (Camera_ == null) Camera_ = Camera.main;
        transform_ = base.transform;
    }
 
    void LateUpdate()
    {
        // get forward vector of the camera and normalize it
        Vector3 vec = Camera_.transform.forward.normalized;
 
        // set the position of the game object just inside the cameras near clipping plane so it blocks the camera view
        if (this.PositionInFrontOfCamera) this.transform.position = Camera_.transform.position + (vec * (Camera_.nearClipPlane + this.Offset));
 
        // orient the game object to look at the camera
        this.transform_.LookAt(this.transform_.position + Camera_.transform.rotation * Vector3.back, Camera_.transform.rotation * Vector3.up);
    }
 }