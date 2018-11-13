﻿using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave {

/// <summary>
/// Create mocks!
/// </summary>
    public static class Mock {

        private static ModuleBuilder moduleBuilder = null;

    /// <summary>
    /// Create a basic mock of an interface or class. The mock will implement exactly the given interface or override public virtual methods.
    /// </summary>
    /// <typeparam name="T">The interface or class to mock.</typeparam>
    /// <example>
    /// The below is a typical usage of this method.
    /// <code>
    /// MyClass mock = Mock.Basic<MyClass>();
    /// </code>
    /// </example>
        public static T Basic<T>() where T : class {
            if(typeof(T).IsInterface)
                return new Internal.MockedType<T>(new Internal.InterfaceEmitter<T>(GetModuleBuilder()).Emit()).Create();
            else
                return new Internal.MockedType<T>(new Internal.ConcreteClassEmitter<T>(GetModuleBuilder()).Emit()).Create();
        }

    /// <summary>
    /// Creates a mock of an interface while extending <c>MonoBehaviour</c>.
    /// <para>You cannot normally create a MonoBehaviour instance. Rather than use this method directly, it is recommended you use the <c>AddMockComponent<>()</c> extension method instead.</para>
    /// </summary>
    /// <typeparam name="T">The interface or class to mock.</typeparam>
        public static T Behaviour<T>() where T : class {
            if(typeof(T).IsInterface)
                return new Internal.MockedType<T>(new Internal.NBehaviourEmitter<T>(GetModuleBuilder()).Emit()).Create();
            else
                return new Internal.MockedType<T>(new Internal.ConcreteClassEmitter<T>(GetModuleBuilder()).Emit()).Create();
        }


    /// <summary>
    /// Generates a <c>MockProxy</c> instance in case you need to manually create mocks.
    /// </summary>
    /// <example>
    /// <code>
    /// class MyMock : NBehaveMock {
    ///     private MockProxy proxy;
    ///     MockProxy NBehave {
    ///         get {
    ///             if(proxy == null)
    ///                 proxy = Mock.Proxy();
    ///             return proxy;
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
        public static Core.MockProxy Proxy() {
            return new Internal.MockProxy();
        }

        private static ModuleBuilder GetModuleBuilder() {
            if(moduleBuilder == null) {
                AssemblyName assemblyName = new AssemblyName();
                assemblyName.Name = "NBehaveMocker";

                AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                moduleBuilder = assemblyBuilder.DefineDynamicModule("NBehaveMocker.mod");
            }

            return moduleBuilder;
        }

    }

}