//  <copyright file="MainViewModel.cs" company="Joan van Houten">
// 
//      Copyright (c) 2017 Joan van Houten - All rights reserved.
// -----------------------------------------------------------------------------
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
// 
// </copyright>
// 
//  SVN         : $Id$
// 
//  Description : 
// 
//  Decisions   :
// 
//  History     :
//  - Date: 2017-10-06, Author: Joan van Houten
//    Reason for change: Initial version
// -----------------------------------------------------------------------------

namespace WpfApp.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows.Data;

    using BAModel;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using JetBrains.Annotations;

    using WpfApp.Services;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    [PublicAPI]
    [SuppressMessage( "ReSharper", "CommentTypo", Justification = "Its OK" )]
    public class MainViewModel : ViewModelBase
    {
        #region  Fields

        /// <summary>
        /// The trip service
        /// </summary>
        private readonly ITripService _tripService;

        /// <summary>
        /// The end date backfield
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// The selected activity
        /// </summary>
        private Activity _selectedActivity;

        /// <summary>
        /// The selected destination
        /// </summary>
        private Destination _selectedDestination;

        /// <summary>
        /// The selected lodging
        /// </summary>
        private Lodging _selectedLodging;

        /// <summary>
        /// The selected trip backfield
        /// </summary>
        private Trip _selectedTrip;

        /// <summary>
        /// The start date backfield
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// The trip activity list
        /// </summary>
        private IList< Activity > _tripActivityList;

        #endregion

        #region  Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// <param name="tripService">The trip service.</param>
        public MainViewModel( ITripService tripService )
        {
            _tripService = tripService;

            var trips = _tripService.GetTrips();

            TripListViewSource = new CollectionViewSource
                                     {
                                         Source = trips
                                     };

            if ( SelectedTrip != null )
            {
                TripActivityList = new List<Activity>( SelectedTrip.Activities );
            }

            DestinationViewSource = new CollectionViewSource
                                        {
                                            Source = _tripService.GetDestinations()
                                        };

            LodgingsViewSource = new CollectionViewSource
                                     {
                                         Source = _tripService.GetLodgings()
                                     };

            var activities = _tripService.GetActivities();

            ActivityViewSource = new CollectionViewSource
                                     {
                                         Source = activities
                                     };

            SelectedTrip = trips.FirstOrDefault();

            SelectedActivity = activities.FirstOrDefault();

            AddActivityCmd = new RelayCommand( AddActivityCmdExec );
            CreateNewTripCmd = new RelayCommand( CreateNewTripCmdExec );
            SaveTripCmd = new RelayCommand( SaveTripCmdExec );
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the activity list.
        /// </summary>
        /// <value>
        /// The activity list.
        /// </value>
        public CollectionViewSource ActivityViewSource { get; set; }

        /// <summary>
        /// Gets or sets the add activity command.
        /// </summary>
        /// <value>
        /// The add activity command.
        /// </value>
        public RelayCommand AddActivityCmd { get; set; }

        /// <summary>
        /// Gets or sets the create new trip command.
        /// </summary>
        /// <value>
        /// The create new trip command.
        /// </value>
        public RelayCommand CreateNewTripCmd { get; set; }

        /// <summary>
        /// Gets or sets the destination list.
        /// </summary>
        /// <value>
        /// The destination list.
        /// </value>
        public CollectionViewSource DestinationViewSource { get; set; }

        /// <summary>
        /// Gets or sets the trip end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime EndDate
        {
            get => _endDate;
            set => Set( ref _endDate, value );
        }

        /// <summary>
        /// Gets or sets the lodging list.
        /// </summary>
        /// <value>
        /// The lodging list.
        /// </value>
        public CollectionViewSource LodgingsViewSource { get; set; }

        /// <summary>
        /// Gets or sets the save trip command.
        /// </summary>
        /// <value>
        /// The save trip command.
        /// </value>
        public RelayCommand SaveTripCmd { get; set; }

        /// <summary>
        /// Gets or sets the selected activity.
        /// </summary>
        /// <value>
        /// The selected activity.
        /// </value>
        public Activity SelectedActivity
        {
            get => _selectedActivity;
            set => Set( ref _selectedActivity, value );
        }

        /// <summary>
        /// Gets or sets the selected destination.
        /// </summary>
        /// <value>
        /// The selected destination.
        /// </value>
        public Destination SelectedDestination
        {
            get => _selectedDestination;
            set => Set( ref _selectedDestination, value );
        }

        /// <summary>
        /// Gets or sets the selected lodging.
        /// </summary>
        /// <value>
        /// The selected lodging.
        /// </value>
        public Lodging SelectedLodging
        {
            get => _selectedLodging;
            set => Set( ref _selectedLodging, value );
        }

        /// <summary>
        /// Gets or sets the selected trip.
        /// </summary>
        /// <value>
        /// The selected trip.
        /// </value>
        public Trip SelectedTrip
        {
            get => _selectedTrip;

            set
            {
                _selectedTrip = value;

                StartDate = value.StartDate;
                EndDate = value.EndDate;

                var destinations = DestinationViewSource.Source as IEnumerable< Destination >;

                SelectedDestination =
                    destinations?.FirstOrDefault( d => d.DestinationID == value.DestinationID );

                var lodgings = LodgingsViewSource.Source as IEnumerable< Lodging >;

                SelectedLodging = lodgings?.FirstOrDefault( l => l.LodgingID == value.LodgingID );

                TripActivityList = new List< Activity >( value.Activities );
            }
        }

        /// <summary>
        /// Gets or sets the trip start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public DateTime StartDate
        {
            get => _startDate;
            set => Set( ref _startDate, value );
        }

        /// <summary>
        /// Gets or sets the trip activity list.
        /// </summary>
        /// <value>
        /// The trip activity list.
        /// </value>
        public IList< Activity > TripActivityList
        {
            get => _tripActivityList;
            set => Set( ref _tripActivityList, value );
        }

        /// <summary>
        /// Gets or sets the trip ListView source.
        /// </summary>
        /// <value>
        /// The trip ListView source.
        /// </value>
        public CollectionViewSource TripListViewSource { get; set; }

        #endregion

        #region Other methods

        /// <summary>
        /// Adds the activity command execute.
        /// </summary>
        private void AddActivityCmdExec()
        {
            Console.WriteLine( @"AddActivityCmdExec" );
        }

        /// <summary>
        /// Creates the new trip command execute.
        /// </summary>
        private void CreateNewTripCmdExec()
        {
            Console.WriteLine( @"CreateNewTripCmdExec" );
        }

        /// <summary>
        /// Saves the trip command execute.
        /// </summary>
        private void SaveTripCmdExec()
        {
            Console.WriteLine( @"SaveTripCmdExec" );
        }

        #endregion
    }
}
