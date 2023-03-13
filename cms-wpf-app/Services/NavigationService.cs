﻿using cms_wpf_app.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace cms_wpf_app.Services;

    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<TViewModel>() where TViewModel : ViewModel;
    }

    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModel _currentView;
        private readonly Func<Type, ViewModel> _viewModelFactory;

        public ViewModel CurrentView
        {
            get => _currentView;

            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }

