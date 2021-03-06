﻿using EPSILab.SolarSystem.Saturn.Model.ReadersService;
using System;

namespace EPSILab.SolarSystem.Saturn.ViewModel.DesignViewModel
{
    /// <summary>
    /// Design view-model for show
    /// </summary>
    class ShowDesignViewModel : DetailsViewModel<Show>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ShowDesignViewModel()
        {
            Element = new Show
                {
                    Start_DateTime = DateTime.Now,
                    End_DateTime = DateTime.Now.AddHours(4),
                    Description = "Praesent tristique nisl tortor, et vulputate nisl vehicula ac. Donec eget venenatis dolor. In at iaculis elit. Aliquam porta consequat odio, non sagittis massa dapibus vitae. Pellentesque ac egestas neque, ac lacinia mauris.",
                    Place = "Amphitheater",
                    Name = "Pellentesque habitant morbi"
                };
        }
    }
}