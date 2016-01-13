// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpServiceStub.cs" company="James Taylor">
//   James Taylor 2016
// </copyright>
// <summary>
//   The help service stub.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Dependy.Tests.TestFactories
{
    using Dependy.Tests.TestInterfaces;

    /// <summary>
    /// The help service stub.
    /// </summary>
    public class HelpServiceStub : IHelpServiceStub
    {
        public HelpServiceStub()
        {
        }

        /// <summary>
        /// The number of help items.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NumberOfHelpItems()
        {
            return 2;
        }
    }
}
