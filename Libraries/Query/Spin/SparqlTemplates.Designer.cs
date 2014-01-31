﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1008
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VDS.RDF.Query.Spin {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SparqlTemplates {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SparqlTemplates() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VDS.RDF.Query.Spin.SparqlTemplates", typeof(SparqlTemplates).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PREFIX rdf:&lt;http://www.w3.org/1999/02/22-rdf-syntax-ns#&gt;
        ///PREFIX sd:&lt;http://www.w3.org/ns/sparql-service-description#&gt;
        ///PREFIX dnr:&lt;dotnetrdf-spin:&gt;
        ///
        ///DELETE {
        ///	GRAPH ?g {
        ///		?s ?p ?o .
        ///	} .
        ///	GRAPH ?entailment {
        ///		?s ?subP ?o .
        ///		?s a ?subC .
        ///	} .
        ///	GRAPH @outputGraph {
        ///		?s dnr:typeAdded ?subC .
        ///	} .
        ///}
        ///INSERT {
        ///	GRAPH ?g {
        ///		?s ?resetRequired ?p .
        ///		?s ?p ?otherValues .
        ///	} .
        ///	GRAPH @outputGraph {
        ///		?s ?resetRequired ?p .
        ///		?s dnr:typeRemoved ?subC .
        ///	} .
        ///}
        ///@USING_NAMED
        ///USING NAMED @da [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string DeleteData {
            get {
                return ResourceManager.GetString("DeleteData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to PREFIX rdf:&lt;http://www.w3.org/1999/02/22-rdf-syntax-ns#&gt;
        ///PREFIX sd:&lt;http://www.w3.org/ns/sparql-service-description#&gt;
        ///PREFIX dnr:&lt;dotnetrdf-spin:&gt;
        ///
        ///DELETE {
        ///	GRAPH @outputGraph {
        ///		?s dnr:typeRemoved ?newSupC .
        ///	} .
        ///}
        ///INSERT {
        ///	GRAPH ?g {
        ///		?s ?p ?o .
        ///	} .
        ///	GRAPH ?entailment {
        ///		?s ?supP ?o .
        ///		?s a ?supC .
        ///	} .
        ///	GRAPH @outputGraph {
        ///		?s dnr:typeAdded ?newSupC .
        ///	} .
        ///}
        ///@USING_DEFAULT
        ///@USING_NAMED
        ///USING NAMED @datasetUri
        ///USING NAMED @outputGraph
        ///WHERE {
        ///	GRAPH @datasetUri {
        ///	    ? [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string InsertData {
            get {
                return ResourceManager.GetString("InsertData", resourceCulture);
            }
        }
    }
}
