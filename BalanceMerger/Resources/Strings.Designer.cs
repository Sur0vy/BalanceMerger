﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalanceMerger.Resources {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BalanceMerger.Resources.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Document.
        /// </summary>
        internal static string sDoc {
            get {
                return ResourceManager.GetString("sDoc", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Balance.
        /// </summary>
        internal static string sSheetName {
            get {
                return ResourceManager.GetString("sSheetName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Status.
        /// </summary>
        internal static string sStatus {
            get {
                return ResourceManager.GetString("sStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Success!.
        /// </summary>
        internal static string stDone {
            get {
                return ResourceManager.GetString("stDone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Failure.
        /// </summary>
        internal static string stFailure {
            get {
                return ResourceManager.GetString("stFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Excel files|*.xls;*.xlsx.
        /// </summary>
        internal static string stFilterXls {
            get {
                return ResourceManager.GetString("stFilterXls", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Excel files|*.xlsx.
        /// </summary>
        internal static string stFilterXlsx {
            get {
                return ResourceManager.GetString("stFilterXlsx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Tip.
        /// </summary>
        internal static string sTip {
            get {
                return ResourceManager.GetString("sTip", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на -merged.
        /// </summary>
        internal static string stMerge {
            get {
                return ResourceManager.GetString("stMerge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Open balance.
        /// </summary>
        internal static string stOpenBHeader {
            get {
                return ResourceManager.GetString("stOpenBHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Open journal.
        /// </summary>
        internal static string stOpenJHeader {
            get {
                return ResourceManager.GetString("stOpenJHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Processing....
        /// </summary>
        internal static string stProcess {
            get {
                return ResourceManager.GetString("stProcess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Save.
        /// </summary>
        internal static string stSaveHeader {
            get {
                return ResourceManager.GetString("stSaveHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Success.
        /// </summary>
        internal static string stSuccess {
            get {
                return ResourceManager.GetString("stSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Need check.
        /// </summary>
        internal static string stWarning {
            get {
                return ResourceManager.GetString("stWarning", resourceCulture);
            }
        }
    }
}
