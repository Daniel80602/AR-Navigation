using Unity.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using ZXing;

public class QrCodeRecenter : MonoBehaviour {

    [SerializeField]
    private ARSession session;
    [SerializeField]
    private XROrigin sessionOrigin;
    [SerializeField]
    private ARCameraManager cameraManager;
    [SerializeField]
    private TargetHandler targetHandler;
    [SerializeField]
    private GameObject qrCodeScanningPanel;
    [SerializeField]
    private GameObject AppCanvas;
    [SerializeField] 
    private GameObject Back1;
    [SerializeField] 
    private GameObject Back2;
    

    private Texture2D cameraImageTexture;
    private IBarcodeReader reader = new BarcodeReader(); // create a barcode reader instance
    private bool scanningEnabled = false;

    private void OnEnable() {
        cameraManager.frameReceived += OnCameraFrameReceived;
    }

    private void OnDisable() {
        cameraManager.frameReceived -= OnCameraFrameReceived;
    }

    private void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs) {
        if (!scanningEnabled) {
            return;
        }

        if (!cameraManager.TryAcquireLatestCpuImage(out XRCpuImage image)) {
            return;
        }

        var conversionParams = new XRCpuImage.ConversionParams {
            inputRect = new RectInt(0, 0, image.width, image.height),
            outputDimensions = new Vector2Int(image.width / 2, image.height / 2),
            outputFormat = TextureFormat.RGBA32,
            transformation = XRCpuImage.Transformation.MirrorY
        };

        int size = image.GetConvertedDataSize(conversionParams);
        var buffer = new NativeArray<byte>(size, Allocator.Temp);
        image.Convert(conversionParams, buffer);
        image.Dispose();

        cameraImageTexture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false);

        cameraImageTexture.LoadRawTextureData(buffer);
        cameraImageTexture.Apply();
        buffer.Dispose();

        var result = reader.Decode(cameraImageTexture.GetPixels32(), cameraImageTexture.width, cameraImageTexture.height);

        if (result != null) {
            SetQrCodeRecenterTarget(result.Text);
            ToggleScanning();
            RedirectToNextCanvas();
        }
    }

    private void SetQrCodeRecenterTarget(string targetText) {
        TargetFacade currentTarget = targetHandler.GetCurrentTargetByTargetText(targetText);
        if (currentTarget != null) {
            session.Reset();
            sessionOrigin.transform.position = currentTarget.transform.position;
            sessionOrigin.transform.rotation = currentTarget.transform.rotation;
        }
    }

    public void ToggleScanning() {
        scanningEnabled = !scanningEnabled;
        qrCodeScanningPanel.SetActive(scanningEnabled);
    }

    public void RedirectToNextCanvas() {
        if (AppCanvas != null) {
            qrCodeScanningPanel.SetActive(false);
            AppCanvas.SetActive(true); 
            Back1.SetActive(false);
            Back2.SetActive(false);
        } else {
            Debug.LogWarning("Next canvas reference not set!");
        }
    }

}
