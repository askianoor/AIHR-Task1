﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Task1.Domain {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GlobalResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public GlobalResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Task1.Domain.GlobalResource", typeof(GlobalResource).Assembly);
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
        ///   Looks up a localized string similar to Add Course Error: {0}.
        /// </summary>
        public static string AddCourseError {
            get {
                return ResourceManager.GetString("AddCourseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to Add this item!.
        /// </summary>
        public static string CanNotAdd {
            get {
                return ResourceManager.GetString("CanNotAdd", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to Delete this item!.
        /// </summary>
        public static string CanNotDelete {
            get {
                return ResourceManager.GetString("CanNotDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This item is not available!.
        /// </summary>
        public static string CanNotFound {
            get {
                return ResourceManager.GetString("CanNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to Update this item!.
        /// </summary>
        public static string CanNotUpdate {
            get {
                return ResourceManager.GetString("CanNotUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The item is already exist!.
        /// </summary>
        public static string DuplicateMsg {
            get {
                return ResourceManager.GetString("DuplicateMsg", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Remove Course Error: {0}.
        /// </summary>
        public static string RemoveCourseError {
            get {
                return ResourceManager.GetString("RemoveCourseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Update Course Error: {0}.
        /// </summary>
        public static string UpdateCourseError {
            get {
                return ResourceManager.GetString("UpdateCourseError", resourceCulture);
            }
        }
    }
}
