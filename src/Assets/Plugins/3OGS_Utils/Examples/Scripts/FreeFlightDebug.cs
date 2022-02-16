/*
 * @author jLautaroCabral-3ogs
 * @version 0.1.1 
**/

using _3OGS.Debug;
using _3OGS.Utils;
using UnityEngine;

public class FreeFlightDebug : MonoBehaviour {

	void Start () {
        _3OGS_Utils.CreateKeyCodeAction(KeyCode.F1,
                () => {
                    if (_3OGS_Utils.IsBuildForProduction()) return;

                    CameraSwitcher.CurrentCamera.gameObject.SetActive(false);

                    _3OGS_Debug.UseFreeLookCamera(transform.position);
                });

        GameObject btnPanel = _3OGS_Debug.CreateButtonPanel(transform.position);
        DebugButtonPanel.AddButton(btnPanel.GetComponent<DebugButtonPanel>(), "Test 1", () => _3OGS_Debug.TextPopup("Test1", Vector3.up));
        DebugButtonPanel.AddButton(btnPanel.GetComponent<DebugButtonPanel>(), "Test 2", () => {
            _3OGS_Debug.UseRotateAroundTargetCamera(transform);
        });

        GameObject debugBtn = DebugButtonPanel.AddButton(btnPanel.GetComponent<DebugButtonPanel>(), "Test 3", () => _3OGS_Debug.TextPopup("Test3", Vector3.up));

        if (debugBtn != null)
            debugBtn.GetComponent<DebugButton>().SetOnClickAction(() => { _3OGS_Debug.TextPopup("Action replace test", debugBtn.transform.position + debugBtn.transform.right * (_3OGS_Utils.GetButtonSize().x / 2 + _3OGS_Utils.GetButtonPanelOffset())); });

    }
}
