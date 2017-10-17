﻿//  <copyright file="ITripService.cs" company="Joan van Houten">
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
//  - Date: 2017-10-09, Author: Joan van Houten
//    Reason for change: Initial version
// -----------------------------------------------------------------------------

namespace WpfApp.Services
{
    using System.Collections.Generic;

    using BAModel;

    /// <summary>
    /// The interface
    /// </summary>
    public interface ITripService
    {
        #region Public methods and operators

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <returns>the activities</returns>
        IEnumerable< Activity > GetActivities();

        /// <summary>
        /// Gets the destinations.
        /// </summary>
        /// <returns>A list of destinations</returns>
        IEnumerable< Destination > GetDestinations();

        /// <summary>
        /// Gets the lodgings.
        /// </summary>
        /// <returns>the lodgings</returns>
        IEnumerable< Lodging > GetLodgings();

        /// <summary>
        /// Gets the trips.
        /// </summary>
        /// <returns>the trips</returns>
        IEnumerable< Trip > GetTrips();

        #endregion
    }
}
