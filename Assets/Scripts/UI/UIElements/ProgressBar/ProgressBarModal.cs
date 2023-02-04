using System;
using UnityEngine;

namespace UI.UIElements.ProgressBar
{
    /// <summary>
    /// Every ProgressBarView in Game should have a Modal.
    /// Create a new ProgressBarModal in Resources folder or in a custom folder.
    /// Attach ProgressBarModal asset to ProgressBarView.
    /// Attach ProgressBarModal asset to ProgressBarController or create a new controller then attach.
    /// </summary>
    [CreateAssetMenu(fileName = "ProgressBarModal-New", menuName = "Modals/Create New ProgressBarModal", order = 0)]
    public class ProgressBarModal : ScriptableObject
    {
        [SerializeField] private float percentage;

        /// <summary>
        /// Acceptable range is [0.0f, 1.0f]
        /// </summary>
        public float Percentage
        {
            get => percentage;
            set
            {
                if (value is > 1.0f or < 0f)
                {
                    throw new ArgumentOutOfRangeException($"Acceptable range is [0.0f, 1.0f]");
                }

                percentage = value;
            }
        }
    }
}