﻿using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using SolarSystem.Saturn.Model.ReadersService;
using SolarSystem.Saturn.View.WindowsPhone.Helpers.Tasks;
using SolarSystem.Saturn.ViewModel;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace SolarSystem.Saturn.View.WindowsPhone
{
    /// <summary>
    /// Member page
    /// </summary>
    public partial class MembrePage
    {
        #region Constructor

        /// <summary>
        /// Constructor. Register to the MVVM Light Toolkit Messenger
        /// </summary>
        public MembrePage()
        {
            InitializeComponent();

            Messenger.Default.Register<Uri>(this, VisitWebsite);
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="e">Navigation event args</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                int code = int.Parse(NavigationContext.QueryString["Id"]);
                Messenger.Default.Send(code);
            }
        }

        /// <summary>
        /// Opens the link that the user just clicked in Internet Explorer Mobile
        /// </summary>
        /// <param name="sender">WebBrowser</param>
        /// <param name="e">Navigation event arguments</param>
        private void WebBrowser_OnNavigating(object sender, NavigatingEventArgs e)
        {
            e.Cancel = true;
            WebBrowserTaskHelper.OpenBrowser(e.Uri);
        }

        /// <summary>
        /// Raised when the page is unloaded
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Event args</param>
        private void PhoneApplicationPage_OnUnloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.CleanDetailsVM<Membre>(true);
        }

        #endregion

        #region Messenger methods

        /// <summary>
        /// Load the member's page in Internet Explorer mobile
        /// </summary>
        /// <param name="uri">Link of the conference</param>
        private void VisitWebsite(Uri uri)
        {
            if (uri != null)
            {
                WebBrowserTaskHelper.OpenBrowser(uri);
            }
        }

        #endregion
    }
}