
using System;

using Android.App;
using Android.Runtime;

namespace ZendeskBindingsApp
{
    [Application]
    public class AppSingleton : Application
    {
        public AppSingleton(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate(); 
            Com.Zendesk.Logger.Logger.Loggable = true;

            var zendiskUrl = "";
            var zendiskApplicationId = "";
            var zendiskOauthClientId = "";
            Com.Zendesk.Sdk.Network.Impl.ZendeskConfig.Instance.Init(this, zendiskUrl, zendiskApplicationId, zendiskOauthClientId);
            var identity = new Com.Zendesk.Sdk.Model.Access.AnonymousIdentity.Builder().Build();
            Com.Zendesk.Sdk.Network.Impl.ZendeskConfig.Instance.SetIdentity(identity);

        }
    }
}
