//using cms_wpf_app.Core;
//using System;

//namespace cms_wpf_app.Services
//{
//    public class ParameterNavigationService<TParameter, TViewModel>
//        where TViewModel : ViewModel
//    {


//        private readonly NavigationService? _navigationService;
//        private readonly Func<TParameter, ViewModel>? _viewModelFactory;


//        public ParameterNavigationService(NavigationService navigationService, Func<TParameter, TViewModel> viewModelFactory)
//        {
//            _navigationService = navigationService;
//            _viewModelFactory = viewModelFactory;

//        }

//        public void Navigate(TParameter parameter) 
//        {
//            _navigationService.CurrentView = _viewModelFactory(parameter);
//        }

//    }
//}
