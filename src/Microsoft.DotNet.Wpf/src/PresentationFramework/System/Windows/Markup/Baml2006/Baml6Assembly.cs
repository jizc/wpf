// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Reflection;
using MS.Internal.WindowsBase;

namespace System.Windows.Baml2006
{
    internal class Baml6Assembly
    {
        // Information needed to resolve a BamlAssembly to a CLR Assembly
        public readonly string Name;
        private Assembly _assembly;

        /// <summary>
        /// </summary>
        /// <param name="name">A fully qualified assembly name</param>
        public Baml6Assembly(string name)
        {
            ArgumentNullException.ThrowIfNull(name);

            Name = name;
            _assembly = null;
        }

        public Baml6Assembly(Assembly assembly)
        {
            ArgumentNullException.ThrowIfNull(assembly);

            Name = null;
            _assembly = assembly;
        }

        public Assembly Assembly
        {
            get
            {
                if (_assembly != null)
                {
                    return _assembly;
                }

                AssemblyName assemblyName = new AssemblyName(Name);
                _assembly = SafeSecurityHelper.GetLoadedAssembly(assemblyName);
                if (_assembly == null)
                {
                    byte[] publicKeyToken = assemblyName.GetPublicKeyToken();
                    if (assemblyName.Version != null || assemblyName.CultureInfo != null || publicKeyToken != null)
                    {
                        try
                        {
                            _assembly = Assembly.Load(assemblyName.FullName);
                        }
                        catch
                        {
                            AssemblyName shortName = new AssemblyName(assemblyName.Name);
                            if (publicKeyToken != null)
                            {
                                shortName.SetPublicKeyToken(publicKeyToken);
                            }
                            _assembly = Assembly.Load(shortName);
                        }
                    }
                    else
                    {
                        _assembly = Assembly.LoadWithPartialName(assemblyName.Name);
                    }
                }
                return _assembly;
            }
        }
    }
}
