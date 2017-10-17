//  <copyright file="TripService.cs" company="Joan van Houten">
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

namespace WpfApp.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BAModel;

    using JetBrains.Annotations;

    /// <inheritdoc cref="ITripService" />
    [UsedImplicitly]
    public class TripService : ITripService
    {
        #region  Fields

        /// <summary>
        /// The context
        /// </summary>
        private readonly BAEntities _context;

        #endregion

        #region  Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TripService"/> class.
        /// </summary>
        public TripService()
        {
            _context = new BAEntities();

            _context.Database.Log = Console.WriteLine;
        }

        #endregion

        #region Public methods and operators

        /// <inheritdoc cref="ITripService.GetActivities" />
        public IEnumerable< Activity > GetActivities()
        {
            return _context.Activities.OrderBy( a => a.Name ).ToList();
        }

        /// <inheritdoc cref="ITripService.GetDestinations" />
        public IEnumerable< Destination > GetDestinations()
        {
            return _context.Destinations.OrderBy( d => d.Name ).ToList();
        }

        /// <inheritdoc cref="ITripService.GetLodgings" />
        public IEnumerable< Lodging > GetLodgings()
        {
            return _context.Lodgings.OrderBy( l => l.LodgingName ).ToList();
        }

        /// <inheritdoc cref="ITripService.GetTrips" />
        public IEnumerable< Trip > GetTrips()
        {
            return _context.Trips.Include( "Activities" ).OrderBy( t => t.Destination.Name ).ToList();
        }

        #endregion
    }
}
