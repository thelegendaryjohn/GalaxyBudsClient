﻿using System;
using System.Diagnostics;
using System.Reflection;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using GalaxyBudsClient.Interface.Items;
using Serilog;

namespace GalaxyBudsClient.Interface.Pages
{
 	public class CreditsPage : AbstractPage
	{
		public override Pages PageType => Pages.Credits;
		
		private readonly DetailListItem _versionItem;
		
		public CreditsPage()
		{   
			InitializeComponent();
			_versionItem = this.FindControl<DetailListItem>("Version");
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		public override void OnPageShown()
		{
			_versionItem.Description = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "x.x.x.x";
			Log.Debug(this.GetType().Name + " shown");
		}

		public override void OnPageHidden()
		{
			Log.Debug(this.GetType().Name + " hidden");
		}

		private void BackButton_OnPointerPressed(object? sender, PointerPressedEventArgs e)
		{
			MainWindow.Instance.Pager.SwitchPage(Pages.Home);
		}

		private void OpenWebsite(String url)
		{
			var psi = new ProcessStartInfo
			{
				FileName = url,
				UseShellExecute = true
			};
			Process.Start(psi);
		}

		private void Telegram_OnPointerPressed(object? sender, PointerPressedEventArgs e)
		{
			OpenWebsite("https://t.me/ThePBone");
		}

		private void Website_OnPointerPressed(object? sender, PointerPressedEventArgs e)
		{
			OpenWebsite("https://timschneeberger.me");
		}

		private void GitHub_OnPointerPressed(object? sender, PointerPressedEventArgs e)
		{
			OpenWebsite("https://github.com/ThePBone/GalaxyBudsClient");
		}
	}
}
