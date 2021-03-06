﻿using EPSILab.SolarSystem.Saturn.ViewModel.Interfaces;
using EPSILab.SolarSystem.Saturn.ViewModel.Objects;
using EPSILab.SolarSystem.Saturn.WindowsPhone8.Helpers.BackgroundTask;
using EPSILab.SolarSystem.Saturn.WindowsPhone8.Resources;
using EPSILab.SolarSystem.Saturn.WindowsPhone8.TileFactory.Tiles;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace EPSILab.SolarSystem.Saturn.WindowsPhone8
{
    /// <summary>
    /// Default page
    /// </summary>
    public partial class MainPage
    {
        #region Constructor

        /// <summary>
        /// Constructor. Register to the MVVM Light Messenger
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            Messenger.Default.Register<object>(this, GoToAboutPage);
            Messenger.Default.Register<VisualGenericItem>(this, ShowDetailsPage);
        }

        #endregion

        #region Attributes

        /// <summary>
        /// Selected panorama group to restore when the user goes back to this page
        /// </summary>
        private VisualGenericGroup _selectedPanoramaGroup;

        #endregion

        #region Methods

        /// <summary>
        /// Show the details page according the type of the element (news, conference, member or show)
        /// </summary>
        /// <param name="item">Item to show. Can be a news, a conference, a member or a show</param>
        private void ShowDetailsPage(VisualGenericItem item)
        {
            if (item != null)
            {
                if (App.IsInternetAvailable)
                {
                    string url = string.Format("/{0}Page.xaml?Id={1}", item.Type, item.Id);
                    Uri uri = new Uri(url, UriKind.Relative);
                    NavigationService.Navigate(uri);
                }
                else
                {
                    MessageBox.Show(AppResources.MSG_CHECK_NETWORK);
                }
            }
        }

        /// <summary>
        /// Go the about page
        /// </summary>
        private void GoToAboutPage(object element)
        {
            NavigationService.Navigate(new Uri("/AboutPage.xaml", UriKind.Relative));
        }

        #endregion

        #region Events

        /// <summary>
        /// Raised when the page is loaded
        /// </summary>
        /// <param name="e">Navigation event arguments</param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (_selectedPanoramaGroup != null)
            {
                int index = Panorama.Items.Cast<VisualGenericGroup>().TakeWhile(item => item != _selectedPanoramaGroup).Count();
                Panorama.DefaultItem = Panorama.Items[index];
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                IMainViewModel viewModel = (IMainViewModel)DataContext;

                if (viewModel.LoadMenuCommand.CanExecute(this))
                {
                    viewModel.LoadMenuCommand.Execute(this);
                }

                BackgroundTaskRegistrationHelper taskRegistration = new BackgroundTaskRegistrationHelper();
                taskRegistration.Register();

                ApplicationTileManager tileManager = new ApplicationTileManager();
                await tileManager.UpdateAsync();
            }
        }

        /// <summary>
        /// Raised when the user change the default displayed panorama item
        /// </summary>
        /// <param name="sender">Panorama</param>
        /// <param name="e">Event args which contains the new and the old selected item</param>
        private void LlsMenu_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Panorama.SelectedItem is PanoramaItem)
            {
                _selectedPanoramaGroup = (VisualGenericGroup)(Panorama.SelectedItem as PanoramaItem).Content;
            }
        }

        #endregion
    }
}