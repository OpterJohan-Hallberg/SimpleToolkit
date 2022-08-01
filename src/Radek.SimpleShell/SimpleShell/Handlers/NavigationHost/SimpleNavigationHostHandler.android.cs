﻿#if ANDROID

using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Handlers;
using AView = Android.Views.View;

namespace Radek.SimpleShell.Handlers
{
    public partial class SimpleNavigationHostHandler : ViewHandler<ISimpleNavigationHost, CustomFrameLayout>
    {
        public static IPropertyMapper<ISimpleNavigationHost, SimpleNavigationHostHandler> Mapper = new PropertyMapper<ISimpleNavigationHost, SimpleNavigationHostHandler>(ViewHandler.ViewMapper)
        {
        };

        public static CommandMapper<ISimpleNavigationHost, SimpleNavigationHostHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {
        };

        public SimpleNavigationHostHandler(IPropertyMapper mapper, CommandMapper commandMapper)
            : base(mapper ?? Mapper, commandMapper ?? CommandMapper)
        {
        }

        public SimpleNavigationHostHandler()
            : base(Mapper, CommandMapper)
        {
        }

        public CustomFrameLayout Container { get; protected set; }

        protected override CustomFrameLayout CreatePlatformView()
        {
            Container = new CustomFrameLayout(MauiContext.Context);

            return Container;
        }

        public virtual void SetContent(AView view)
        {
            Container.RemoveAllViews();
            Container.AddView(view);
        }
    }
}

#endif