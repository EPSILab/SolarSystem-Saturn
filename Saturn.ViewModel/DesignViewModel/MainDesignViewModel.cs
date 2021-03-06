﻿using System.Collections.ObjectModel;
using EPSILab.SolarSystem.Saturn.ViewModel.Helpers;
using EPSILab.SolarSystem.Saturn.ViewModel.Objects;

namespace EPSILab.SolarSystem.Saturn.ViewModel.DesignViewModel
{
    /// <summary>
    /// Design view-model for the main page
    /// </summary>
    class MainDesignViewModel : MainViewModel
    {
        public MainDesignViewModel()
        {
            Menu = new VisualMenu
            {
                Groups = new ObservableCollection<VisualGenericGroup>
                        {
                            new VisualGenericGroup
                                {
                                    Title = AppResourcesHelper.GetString("LBL_NEWS")
                                },
                            new VisualGenericGroup
                                {
                                    Title = AppResourcesHelper.GetString("LBL_BUREAU")
                                },
                            new VisualGenericGroup
                                {
                                    Title = AppResourcesHelper.GetString("LBL_PROJECTS")
                                },
                            new VisualGenericGroup
                                {
                                    Title = AppResourcesHelper.GetString("LBL_CONFERENCES")
                                },
                            new VisualGenericGroup
                                {
                                    Title = AppResourcesHelper.GetString("LBL_SALONS")
                                }
                        }
            };

            SelectedItem = Menu.Groups[0].Items[0];
        }
    }
}