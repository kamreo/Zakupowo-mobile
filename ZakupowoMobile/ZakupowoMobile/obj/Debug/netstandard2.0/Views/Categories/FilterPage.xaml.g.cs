//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("ZakupowoMobile.Views.Categories.FilterPage.xaml", "Views/Categories/FilterPage.xaml", typeof(global::ZakupowoMobile.Views.Categories.FilterPage))]

namespace ZakupowoMobile.Views.Categories {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\Categories\\FilterPage.xaml")]
    public partial class FilterPage : global::Rg.Plugins.Popup.Pages.PopupPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Entry productName;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Slider minValue;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Slider maxValue;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Picker StateBinder;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Span range;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(FilterPage));
            productName = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "productName");
            minValue = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Slider>(this, "minValue");
            maxValue = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Slider>(this, "maxValue");
            StateBinder = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Picker>(this, "StateBinder");
            range = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Span>(this, "range");
        }
    }
}