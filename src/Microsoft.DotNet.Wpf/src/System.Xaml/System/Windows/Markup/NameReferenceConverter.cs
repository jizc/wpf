﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable

using System.ComponentModel;
using System.Globalization;
using System.Xaml;

namespace System.Windows.Markup
{
    public class NameReferenceConverter: TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            ArgumentNullException.ThrowIfNull(context);

            var nameResolver = (IXamlNameResolver)context.GetService(typeof(IXamlNameResolver));
            if (nameResolver is null)
            {
                throw new InvalidOperationException(SR.MissingNameResolver);
            }

            string name = value as string;
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidOperationException(SR.MustHaveName);
            }

            object obj = nameResolver.Resolve(name);
            if (obj is null)
            {
                string[] names = new string[] { name };
                obj = nameResolver.GetFixupToken(names, true);
            }

            return obj;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (context is null || (context.GetService(typeof(IXamlNameProvider)) as  IXamlNameProvider) is null)
            {
                return false;
            }

            if (destinationType == typeof(string))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            ArgumentNullException.ThrowIfNull(context);

            var nameProvider = (IXamlNameProvider)context.GetService(typeof(IXamlNameProvider));
            if (nameProvider is null)
            {
                throw new InvalidOperationException(SR.MissingNameProvider);
            }

            return nameProvider.GetName(value);
        }
    }
}
