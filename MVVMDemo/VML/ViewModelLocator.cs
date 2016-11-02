using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace MVVMDemo.VML
{
	public class ViewModelLocator
	{
		// Using a DependencyProperty as the backing store for AutoHookedUpViewModel.
		// This enables animation, styling, binding, etc...
		public static readonly DependencyProperty AutoHookedUpViewModelProperty = DependencyProperty.RegisterAttached("AutoHookedUpViewModel"	// name of attached property
			, typeof(bool)	// type of attached property
			, typeof(ViewModelLocator)	// type of property parent object
			, new PropertyMetadata(defaultValue: false, propertyChangedCallback: AutoHookedUpViewModelChanged));

		// Getter for AutoHookedUpViewModel property
		public static bool GetAutoHookedUpViewModel(DependencyObject obj)
		{
			return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
		}

		// Setter for AutoHookedUpViewModel property
		public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value)
		{
			obj.SetValue(AutoHookedUpViewModelProperty, value);
		}

		// Call back function for recognition of property change
		private static void AutoHookedUpViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			if (DesignerProperties.GetIsInDesignMode(d))
				return;

			var viewType = d.GetType();

			string str = viewType.FullName;
			str = str.Replace(".Views.", ".ViewModel.");

			string viewTypeName = str;
			string viewModelTypeName = viewTypeName + "Model";
			Type viewModelType = Type.GetType(viewModelTypeName);
			var viewModel = Activator.CreateInstance(viewModelType);

			((FrameworkElement)d).DataContext = viewModel;
		}
	}
}
