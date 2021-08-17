using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Uinterface
{
    public class GeneralInfoCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI alertText;
        public void SetAlertText(string value) => alertText.text = value;
        public void SetAlertText(int value) => alertText.text = value.ToString();
        public void HideAlertText() => alertText.gameObject.SetActive(false);
    }

}
