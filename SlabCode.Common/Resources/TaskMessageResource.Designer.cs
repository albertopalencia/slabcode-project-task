﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SlabCode.Common.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class TaskMessageResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TaskMessageResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SlabCode.Common.Resources.TaskMessageResource", typeof(TaskMessageResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to la fecha ejecucion debe estar en el rango de fechas de inicio y final del
        ///proyecto.
        /// </summary>
        public static string MensajeFechaFueraDelRango {
            get {
                return ResourceManager.GetString("MensajeFechaFueraDelRango", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tarea actualizada exitosamente.
        /// </summary>
        public static string MensajeTareaActualizada {
            get {
                return ResourceManager.GetString("MensajeTareaActualizada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tarea completada exitosamente.
        /// </summary>
        public static string MensajeTareaCompletada {
            get {
                return ResourceManager.GetString("MensajeTareaCompletada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tarea creada exitosamente.
        /// </summary>
        public static string MensajeTareaCreada {
            get {
                return ResourceManager.GetString("MensajeTareaCreada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Tarea eliminada exitosamente.
        /// </summary>
        public static string MensajeTareaEliminada {
            get {
                return ResourceManager.GetString("MensajeTareaEliminada", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No existe una tarea para ese id.
        /// </summary>
        public static string MensajeTareaNoExiste {
            get {
                return ResourceManager.GetString("MensajeTareaNoExiste", resourceCulture);
            }
        }
    }
}
