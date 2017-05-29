// ***********************************************************************
// Copyright (c) 2017 Yowko Tsai
// ***********************************************************************

using System;
using Microsoft.VisualStudio.TestPlatform.TestGeneration.Data;
using Microsoft.VisualStudio.TestPlatform.TestGeneration.Model;
using System.ComponentModel.Composition;

namespace xUnit.net.TestGenerator
{
    /// <summary>
    /// The provider for the NUnit 3 unit test framework.
    /// </summary>
    [Export(typeof(IFrameworkProvider))]
    public class xUnitFrameworkProvider : FrameworkProviderBase
    {
    
        /// <summary>
        /// Initializes a new instance of the <see cref="xUnitFrameworkProvider"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to use to get the interfaces required.</param>
        /// <param name="configurationSettings">The configuration settings object to be used to determine how the test method is generated.</param>
        /// <param name="naming">The naming object used to decide how projects, classes and methods are named and created.</param>
        /// <param name="directory">The directory object to use for directory operations.</param>
        [ImportingConstructor]
        public xUnitFrameworkProvider(IServiceProvider serviceProvider, IConfigurationSettings configurationSettings, INaming naming, IDirectory directory)
            : base(new xUnitSolutionManager(serviceProvider, naming, directory), new xUnitUnitTestProjectManager(serviceProvider, naming), new xUnitUnitTestClassManager(configurationSettings, naming))
        {
        }
        

        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        public override string Name => "xUnit.net 2.0";

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        public override string AssemblyName => "xunit.framework";
    }
}
