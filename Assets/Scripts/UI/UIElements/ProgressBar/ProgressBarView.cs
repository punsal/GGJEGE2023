using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UIElements.ProgressBar
{
    /// <summary>
    /// This is an autonomous MonoBehaviour.
    /// ProgressBarView updates its ProgressBar Image with ProgressBarModal.Percentage value.
    /// </summary>
    /// <see cref="ProgressBarModal"/>
    public class ProgressBarView : MonoBehaviour
    {
        private enum State { NotInitialized, Initialized, Error }
        
        [Header("External Dependencies")]
        [SerializeField] private ProgressBarModal progressBarModel;

        [Header("UI Elements Dependencies")]
        [SerializeField] private Image progressBarImage;

        private State _state;

        private void Initialize()
        {
            if (progressBarImage == null)
            {
                LogError("Does not have 'ProgressBar' dependency. Please check the UIElement!");
                _state = State.Error;
                return;
            }

            if (progressBarImage.type != Image.Type.Filled)
            {
                LogError("Does not have 'Filler' typed Image Component. Please check the UIElement!");
                _state = State.Error;
                return;
            }

            if (progressBarModel == null)
            {
                LogError("Should have a ProgressBarModel. Please check the UIElement!");
                _state = State.Error;
                return;
            }

            _state = State.Initialized;
        }

        private void Update()
        {
            switch (_state)
            {
                case State.NotInitialized:
                    Initialize();
                    break;
                case State.Initialized:
                    progressBarImage.fillAmount = progressBarModel.Percentage;
                    break;
                case State.Error:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void LogError(string errorMessage)
        {
            var progressBarTransform = transform;
            var progressBarName = progressBarTransform.name;
            var progressBarParent = progressBarTransform.parent;
            var isParentExist = progressBarParent != null;
            var progressBarParentName = isParentExist ? progressBarParent.name : progressBarName;
            var message = $"{progressBarName} in {progressBarParentName}: {errorMessage}";
            Debug.LogError(message);
        }
    }
}
