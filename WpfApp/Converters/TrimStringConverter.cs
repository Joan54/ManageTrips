//  <copyright file="TrimStringConverter.cs" company="Joan van Houten">
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
//  - Date: 2017-10-16, Author: Joan van Houten
//    Reason for change: Initial version
// -----------------------------------------------------------------------------

namespace WpfApp.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Trim a string
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class TrimStringConverter : IValueConverter
    {
        #region Public methods and operators

        /// <inheritdoc />
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture )
        {
            return ( value as string )?.Trim();
        }

        /// <inheritdoc />
        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture )
        {
            return null;
        }

        #endregion
    }
}
