﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project445.MovieService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Movie", Namespace="http://schemas.datacontract.org/2004/07/MovieService")]
    [System.SerializableAttribute()]
    public partial class Movie : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullPosterPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int[] GenreIdsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OverviewField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PosterPathField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ReleaseDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double VoteAverageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullPosterPath {
            get {
                return this.FullPosterPathField;
            }
            set {
                if ((object.ReferenceEquals(this.FullPosterPathField, value) != true)) {
                    this.FullPosterPathField = value;
                    this.RaisePropertyChanged("FullPosterPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] GenreIds {
            get {
                return this.GenreIdsField;
            }
            set {
                if ((object.ReferenceEquals(this.GenreIdsField, value) != true)) {
                    this.GenreIdsField = value;
                    this.RaisePropertyChanged("GenreIds");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Overview {
            get {
                return this.OverviewField;
            }
            set {
                if ((object.ReferenceEquals(this.OverviewField, value) != true)) {
                    this.OverviewField = value;
                    this.RaisePropertyChanged("Overview");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PosterPath {
            get {
                return this.PosterPathField;
            }
            set {
                if ((object.ReferenceEquals(this.PosterPathField, value) != true)) {
                    this.PosterPathField = value;
                    this.RaisePropertyChanged("PosterPath");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ReleaseDate {
            get {
                return this.ReleaseDateField;
            }
            set {
                if ((object.ReferenceEquals(this.ReleaseDateField, value) != true)) {
                    this.ReleaseDateField = value;
                    this.RaisePropertyChanged("ReleaseDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double VoteAverage {
            get {
                return this.VoteAverageField;
            }
            set {
                if ((this.VoteAverageField.Equals(value) != true)) {
                    this.VoteAverageField = value;
                    this.RaisePropertyChanged("VoteAverage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MovieService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchMovies", ReplyAction="http://tempuri.org/IService1/SearchMoviesResponse")]
        Project445.MovieService.Movie[] SearchMovies(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SearchMovies", ReplyAction="http://tempuri.org/IService1/SearchMoviesResponse")]
        System.Threading.Tasks.Task<Project445.MovieService.Movie[]> SearchMoviesAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUpcomingMovies", ReplyAction="http://tempuri.org/IService1/GetUpcomingMoviesResponse")]
        Project445.MovieService.Movie[] GetUpcomingMovies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUpcomingMovies", ReplyAction="http://tempuri.org/IService1/GetUpcomingMoviesResponse")]
        System.Threading.Tasks.Task<Project445.MovieService.Movie[]> GetUpcomingMoviesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNowPlayingMovies", ReplyAction="http://tempuri.org/IService1/GetNowPlayingMoviesResponse")]
        Project445.MovieService.Movie[] GetNowPlayingMovies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetNowPlayingMovies", ReplyAction="http://tempuri.org/IService1/GetNowPlayingMoviesResponse")]
        System.Threading.Tasks.Task<Project445.MovieService.Movie[]> GetNowPlayingMoviesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Project445.MovieService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Project445.MovieService.IService1>, Project445.MovieService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Project445.MovieService.Movie[] SearchMovies(string query) {
            return base.Channel.SearchMovies(query);
        }
        
        public System.Threading.Tasks.Task<Project445.MovieService.Movie[]> SearchMoviesAsync(string query) {
            return base.Channel.SearchMoviesAsync(query);
        }
        
        public Project445.MovieService.Movie[] GetUpcomingMovies() {
            return base.Channel.GetUpcomingMovies();
        }
        
        public System.Threading.Tasks.Task<Project445.MovieService.Movie[]> GetUpcomingMoviesAsync() {
            return base.Channel.GetUpcomingMoviesAsync();
        }
        
        public Project445.MovieService.Movie[] GetNowPlayingMovies() {
            return base.Channel.GetNowPlayingMovies();
        }
        
        public System.Threading.Tasks.Task<Project445.MovieService.Movie[]> GetNowPlayingMoviesAsync() {
            return base.Channel.GetNowPlayingMoviesAsync();
        }
    }
}
