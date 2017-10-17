//  <copyright file="ViewModelLocator.cs" company="Joan van Houten">
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
    using GalaSoft.MvvmLight.Ioc;

    using Microsoft.Practices.ServiceLocation;

    using WpfApp.Services;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        #region  Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider( () => SimpleIoc.Default );

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Gets the reference for the MainViewModel.
        /// </summary>
        /// <value>
        /// The MainViewModel reference
        /// </value>
        public static MainViewModel Main
        {
            get
            {
                if ( ! SimpleIoc.Default.ContainsCreated< MainViewModel >() )
                {
                    SimpleIoc.Default.Register< MainViewModel >();
                }

                SimpleIoc.Default.Register< ITripService, TripService >();

                return ServiceLocator.Current.GetInstance< MainViewModel >();
            }
        }

        #endregion

        #region Public methods and operators

        /// <summary>
        /// Cleanups this instance.
        /// </summary>
        public static void Cleanup()
        {
            if ( SimpleIoc.Default.ContainsCreated< MainViewModel >() )
            {
                SimpleIoc.Default.Unregister< MainViewModel >();
            }
        }

        #endregion
    }
}
