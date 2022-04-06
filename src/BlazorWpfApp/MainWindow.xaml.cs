// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Windows;
using BlazorWpfApp.Mocks;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Ultron.BladeBoard;
using Ultron.BladeBoard.Abstraction.DataObjects;
using WebviewAppTest;
using WebviewAppTest.Data;

namespace BlazorWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppState _appState = new();

        public MainWindow()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddBlazorWebView();
            serviceCollection.AddSingleton<AppState>(_appState);
            serviceCollection.AddSingleton<WeatherForecastService>()
                .AddSingleton<IBladeBoardDriver, MockBladeBoardDriver>()
                .AddMudServices();
            Resources.Add("services", serviceCollection.BuildServiceProvider());

            InitializeComponent();
        }
    }

    // Workaround for compiler error "error MC3050: Cannot find the type 'local:Main'"
    // It seems that, although WPF's design-time build can see Razor components, its runtime build cannot.
    public partial class Main { }
}
