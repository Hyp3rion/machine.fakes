using System.Collections.Generic;
using Machine.Fakes.Internal;
using Machine.Specifications;

namespace Machine.Fakes
{
    /// <summary>
    /// Base class for the simpler cases than <see cref="WithSubject{TSubject}"/>. 
    /// This class only contains the shortcuts for creating fakes via "An" and "Some".
    /// </summary>
    public abstract class WithFakes  
    {
        private static IFakeEngine _fakeEngine;

        /// <summary>
        /// Creates a new instance of the <see cref="WithFakes"/> class.
        /// </summary>
        protected WithFakes()
        {
            _fakeEngine = FakeEngineInstaller.InstallFor(GetType());
        }

        /// <summary>
        ///   Creates a fake of the type specified by <typeparamref name = "TInterfaceType" />.
        /// </summary>
        /// <typeparam name = "TInterfaceType">The type to create a fake for. (Should be an interface or an abstract class)</typeparam>
        /// <returns>
        ///   An newly created fake implementing <typeparamref name = "TInterfaceType" />.
        /// </returns>
        public static TInterfaceType An<TInterfaceType>() where TInterfaceType : class
        {
            return _fakeEngine.Stub<TInterfaceType>();
        }

        /// <summary>
        ///   Creates a list containing 3 fake instances of the type specified
        ///   via <typeparamref name = "TInterfaceType" />.
        /// </summary>
        /// <typeparam name = "TInterfaceType">Specifies the item type of the list. This should be an interface or an abstract class.</typeparam>
        /// <returns>An <see cref = "IList{T}" />.</returns>
        public static IList<TInterfaceType> Some<TInterfaceType>() where TInterfaceType : class
        {
            return _fakeEngine.CreateFakeCollectionOf<TInterfaceType>();
        }

        Cleanup after = () =>
        {
            _fakeEngine = null;
        };
    }
}