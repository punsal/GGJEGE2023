using System;
using UnityEngine;

namespace UI.UIElements.ProgressBar
{
    public class BasicProgressBarAmount : BaseProgressBarController
    {
        public override void SetPercentageAmount(float percentage)
        {
            try
            {
                ProgressBarModal.Percentage = percentage;
            }
            catch (ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Debug.LogError(argumentOutOfRangeException.Message);
                ProgressBarModal.Percentage = 0;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
                throw;
            }
        }
    }
}