using System;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace XamarinFormsWebViewSample
{
    public partial class XamarinFormsWebViewSamplePage : ContentPage
    {
        private const string WebViewUrl = "http://krystianczaplicki.com/webview/";
        private const string LoginCallback = "login";
        private const string DisplayLoginAlertFunctioName = "displayLoginAlert";
        private const string Username = "User";

        public XamarinFormsWebViewSamplePage()
        {
            InitializeComponent();

            var serializer = new JsonSerializer();
            var webView = new HybridWebView(serializer)
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = new Thickness(20, 30),
                Uri = new Uri(WebViewUrl)
            };

            webView.RegisterCallback(LoginCallback, (arg) =>
            {
                var loginForm = serializer.Deserialize<LoginFormDto>(arg);
                var result = loginForm.Username == Username;
                webView.CallJsFunction(DisplayLoginAlertFunctioName, new[] { result.ToString() });
            });

            Content = webView;
        }
    }
}
