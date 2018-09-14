﻿using System.ComponentModel;
using Sdl.Community.projectAnonymizer.Helpers;
using Sdl.Community.projectAnonymizer.Interfaces;
using Sdl.Community.projectAnonymizer.Models;
using Sdl.Community.projectAnonymizer.Process_Xliff;
using Sdl.Core.Settings;

namespace Sdl.Community.projectAnonymizer.Batch_Task
{
	public class AnonymizerSettings : SettingsGroup, IAnonymizerSettings
	{
		private BindingList<RegexPattern> _regexPatterns = new BindingList<RegexPattern>();
		private readonly bool _defaultListAlreadyAdded = false;

		public bool? ArePatternsEncrypted
		{
			get => GetSetting<bool?>(nameof(ArePatternsEncrypted));
			set => GetSetting<bool?>(nameof(ArePatternsEncrypted)).Value = value;
		}

		public bool? IsOldVersion
		{
			get => GetSetting<bool?>(nameof(IsOldVersion));
			set => GetSetting<bool?>(nameof(IsOldVersion)).Value = value;
		}

		public bool? IsProjectEncrypted
		{
			get => GetSetting<bool?>(nameof(IsProjectEncrypted));
			set => GetSetting<bool?>(nameof(IsProjectEncrypted)).Value = value;
		}

		public bool IsNewFile
		{
			get => GetSetting<bool>(nameof(IsNewFile));
			set => GetSetting<bool>(nameof(IsNewFile)).Value = value;
		}


		public bool? ShouldAnonymize
		{
			get => GetSetting<bool?>(nameof(ShouldAnonymize));
			set => GetSetting<bool?>(nameof(ShouldAnonymize)).Value = value;
		}

		public BindingList<RegexPattern> RegexPatterns
		{
			get => GetSetting<BindingList<RegexPattern>>(nameof(RegexPatterns));

			set => GetSetting<BindingList<RegexPattern>>(nameof(RegexPatterns)).Value = value;
		}

		public string EncryptionKey
		{
			//get => GetSetting<string>(AnonymizeData.EncryptData(nameof(EncryptionKey), Constants.Key));
			get => GetSetting<string>(nameof(EncryptionKey));
			set => GetSetting<string>(nameof(EncryptionKey)).Value = AnonymizeData.EncryptData(value, Constants.Key);
		}

		public bool DefaultListAlreadyAdded
		{
			get => GetSetting<bool>(nameof(DefaultListAlreadyAdded));
			set => GetSetting<bool>(nameof(DefaultListAlreadyAdded)).Value = value;
		}
		public bool SelectAll
		{
			get => GetSetting<bool>(nameof(SelectAll));
			set => GetSetting<bool>(nameof(SelectAll)).Value = value;
		}
		public bool EnableAll
		{
			get => GetSetting<bool>(nameof(EnableAll));
			set => GetSetting<bool>(nameof(EnableAll)).Value = value;
		}
		public bool EncryptAll
		{
			get => GetSetting<bool>(nameof(EncryptAll));
			set => GetSetting<bool>(nameof(EncryptAll)).Value = value;
		}
		//Initialize settings with default regex list
		public void AddPattern(RegexPattern pattern)
		{
			_regexPatterns.Add(pattern);
		}

		public BindingList<RegexPattern> GetRegexPatterns()
		{
			return RegexPatterns;
		}

		public string GetEncryptionKey()
		{
			return EncryptionKey;
		}

		protected override object GetDefaultValue(string settingId)
		{
			switch (settingId)
			{
				case nameof(RegexPatterns):
					return _regexPatterns;
				case nameof(EncryptionKey):
					return "<dummy-encryption-key>";
			}
			return base.GetDefaultValue(settingId);
		}


	}
}
