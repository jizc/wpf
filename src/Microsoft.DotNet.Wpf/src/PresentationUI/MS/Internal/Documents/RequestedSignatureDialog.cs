﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Windows.TrustUI;

namespace MS.Internal.Documents
{
    internal sealed partial class RequestedSignatureDialog : DialogBaseForm
    {
        #region Constructors
        //------------------------------------------------------
        //
        //  Constructors
        //
        //------------------------------------------------------

        /// <summary>
        /// Constructor
        /// </summary>
        internal RequestedSignatureDialog(DocumentSignatureManager docSigManager)
        {
            ArgumentNullException.ThrowIfNull(docSigManager);

            //Init private fields
            _documentSignatureManager = docSigManager;

            // Initialize the "Must Sign By:" field
            _dateTimePicker.MinDate = DateTime.Now;
            _dateTimePicker.Value = DateTime.Now.AddDays(10);
        }
        #endregion Constructors

        #region Private Methods
        //------------------------------------------------------
        //
        //  Private Methods
        //
        //------------------------------------------------------


        /// <summary>
        /// oKButton_Click
        /// </summary>
        private void _addButton_Click(object sender, EventArgs e)
        {
            //Check to see this the input is valid
            if (ValidateUserData())
            {
                //Create SignatureResource to pass back to DocumentSignatureManager
                SignatureResources sigResources = new SignatureResources
                {
                    //Get the user data.
                    _subjectName = _requestedSignerNameTextBox.Text,
                    _reason = _intentComboBox.Text,
                    _location = _requestedLocationTextBox.Text
                };

                //Add the SignatureDefinition.
                _documentSignatureManager.OnAddRequestSignature(sigResources,_dateTimePicker.Value);

                //Close the Add Request dialog
                Close();
            }
            else
            {
                System.Windows.MessageBox.Show(
                                    SR.DigitalSignatureWarnErrorReadOnlyInputError,
                                    SR.DigitalSignatureWarnErrorSigningErrorTitle,
                                    System.Windows.MessageBoxButton.OK, 
                                    System.Windows.MessageBoxImage.Exclamation
                                    );
            }
        }

        /// <summary>
        /// ValidateUserData.  Check the user input is valid.
        /// </summary>
        private bool ValidateUserData()
        {
            bool rtnvalue = false;
            
            //Remove extra white space.
            string requestSignerName = _requestedSignerNameTextBox.Text.Trim();
            string intentComboBoxText = _intentComboBox.Text.Trim();

            //Do the text/combo contain any text?
            if (!String.IsNullOrEmpty(requestSignerName) &&
                !String.IsNullOrEmpty(intentComboBoxText))
            {
                rtnvalue = true;
            }

            return rtnvalue;
        }

        #endregion Private Methods

        #region Private Fields
        //------------------------------------------------------    
        //    
        //  Private Fields
        //    
        //------------------------------------------------------

        private DocumentSignatureManager _documentSignatureManager;               

        #endregion Private Fields

        #region Protected Methods
        //------------------------------------------------------
        //
        //  Protected Methods
        //
        //------------------------------------------------------

        /// <summary>
        /// ApplyResources
        /// </summary>
        protected override void ApplyResources()
        {
            base.ApplyResources();

            //Get localized strings.
            _addButton.Text = SR.RequestSignatureDialogAdd;
            _cancelButton.Text = SR.RequestSignatureDialogCancel;            
            _requestSignerNameLabel.Text = SR.RequestSignatureDialogRequestSignerNameLabel;
            _intentLabel.Text = SR.RequestSignatureDialogIntentLabel;
            _requestLocationLabel.Text = SR.RequestSignatureDialogLocationLabel;
            _signatureAppliedByDateLabel.Text = SR.RequestSignatureDialogSignatureAppliedByDateLabel;
            Text = SR.RequestSignatureDialogTitle;

            //Load the Intent/Reason combo
            _intentComboBox.Items.Add(SR.DigSigIntentString1);
            _intentComboBox.Items.Add(SR.DigSigIntentString2);
            _intentComboBox.Items.Add(SR.DigSigIntentString3);
            _intentComboBox.Items.Add(SR.DigSigIntentString4);
            _intentComboBox.Items.Add(SR.DigSigIntentString5);
            _intentComboBox.Items.Add(SR.DigSigIntentString6);
        }

        #endregion Protected Methods
    }
}
