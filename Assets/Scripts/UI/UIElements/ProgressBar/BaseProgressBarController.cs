using UnityEngine;

namespace UI.UIElements.ProgressBar
{
    public abstract class BaseProgressBarController : MonoBehaviour
    {
        [SerializeField] private ProgressBarModal progressBarModal;

        protected ProgressBarModal ProgressBarModal
        {
            get => progressBarModal;
            set => progressBarModal = value;
        }

        public abstract void SetPercentageAmount(float percentage);
    }
}